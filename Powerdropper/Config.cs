using System;
using System.Collections.Generic;
using System.Text;

namespace Powerdropper
{
    class Config
    {
        [Replacement(Name = "MYURI")]
        public string Uri;

        [Replacement(Name = "HackForums.gigajew")]
        public string Namespace;

        [Replacement(Name = "Dropper")]
        public string Classname;

        [Replacement(Name = "Run")]
        public string MethodName;

        [Replacement(Name = "loadApplication")]
        public string MethodName2;

        [Replacement(Name = "downloadApplicationData")]
        public string MethodName3;

        [Replacement (Name = "APPLICATION_DATA")]
        public string ApplicationData;

        [Replacement(Name = "TARGET_URI")]
        public string TargetUri;
    }
}
