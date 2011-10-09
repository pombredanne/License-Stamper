/*
 * Copyright (C) 2011 License Stamper
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */

using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LicenseStamper.Domain
{
    public sealed class CSharpfile : IFile
    {
        readonly string _filepath;

        public CSharpfile(string filepath)
        {
            _filepath = filepath;
        }

        public void AddHeader(string header)
        {
            if (string.IsNullOrWhiteSpace(header))
            {
                throw new ArgumentNullException("header");
            }

            OverwriteFileContent(MergeHeaderWithContent(header, GetFileContent()));
        }

        public string RetrieveHeader()
        {
            string[] fileContents = GetFileContentLines();

            if(!FileContainsHeader(fileContents))
            {
                return null;
            }

            List<string> headerLines = new List<string>();
            foreach (string line in fileContents)
            {
                headerLines.Add(line);

                if (LineIsEndOfComment(line))
                {
                    break;
                }
            }
            return string.Join(Environment.NewLine, headerLines);
        }

        string GetFileContent()
        {
            return File.ReadAllText(_filepath);
        }

        string[] GetFileContentLines()
        {
            return File.ReadAllLines(_filepath);
        }

        void OverwriteFileContent(string newContent)
        {
            File.WriteAllText(_filepath, newContent);
        }

        string MergeHeaderWithContent(string header, string content)
        {
            return header + content;
        }

        bool FileContainsHeader(string[] fileContent)
        {
            return LineIsStartOfComment(fileContent[0]);
        }

        bool LineIsStartOfComment(string line)
        {
            return line.Contains("/*");
        }

        bool LineIsEndOfComment(string line)
        {
            return line.Contains("*/");
        }
    }
}