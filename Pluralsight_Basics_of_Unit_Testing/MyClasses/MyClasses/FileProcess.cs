using System;
using System.IO;

namespace MyClasses
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if(string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            return File.Exists(fileName);
        }

        // Move to rtf file Demo_Create_your_unit_test
    }
}
