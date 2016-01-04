using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlowUploadFilter
{
    public class AcceptedFileExtensions
    {
        public bool IsExtensionAllowed(IList<string> allowedExtensions, string fileName)
        {
            var isAllowed = false;

            // Extract extension from FileName ("Test.txt" => ".txt")
            var fileExtension = Path.GetExtension(fileName);

            // fileExtension will be empty if the file has no extension
            if (!string.IsNullOrEmpty(fileExtension))
            {
                // GetExtension returns the extension with the leading-zero. The leading zero will be removed here for easier handling:
                fileExtension = fileExtension.TrimStart('.');

                // Search the allowedExtension-List for the file extension (case is ignored)
                // Test.TXT is accepted as well as Test.txt even if only .txt is in the list of allowed extensions
                isAllowed = allowedExtensions.Contains(fileExtension, StringComparer.InvariantCultureIgnoreCase);
            }

            return isAllowed;
        }
    }
}
