using System.IO;
using System;
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

            string originalFilecontent = GetFileContent();
            string filecontentWithHeaderAdded = MergeHeaderWithContent(header, originalFilecontent);
            OverwriteFileContent(filecontentWithHeaderAdded);
        }

        string GetFileContent()
        {
            return File.ReadAllText(_filepath);
        }

        void OverwriteFileContent(string newContent)
        {
            File.WriteAllText(_filepath, newContent);
        }

        string MergeHeaderWithContent(string header, string content)
        {
            return header + content;
        }
    }
}