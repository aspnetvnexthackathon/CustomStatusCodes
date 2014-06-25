using System;
using System.IO;

namespace CustomStatusCodes
{
    public class BackupStreamFeature
    {
        public Stream Body { get; set; }
        public bool? Replace { get; set; }
    }
}