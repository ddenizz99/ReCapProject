using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public static class FileLength
    {
        public static string CalculateLength(long fileLength)
        {
            string returnLength = "";

            if (fileLength >= 1073741824)
            {
                returnLength += (fileLength / 1073741824) + " GB ";
                fileLength = fileLength % 1073741824;
            }

            if (fileLength >= 1048576)
            {
                returnLength += (fileLength / 1048576) + " MB ";
                fileLength = fileLength % 1048576;
            }

            if (fileLength >= 1024)
            {
                returnLength += (fileLength / 1024) + " KB ";
                fileLength = fileLength % 1024;
            }
            returnLength += fileLength + " B ";

            return returnLength;
        }
    }
}
