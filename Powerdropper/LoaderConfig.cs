using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerdropper
{
    class LoaderConfig
    {
        [Replacement(Name = "powershell-data")]
        public string Base64Data;

        [Replacement (Name = "HackForums.gigajew")]
        public string Namespace;

        [Replacement(Name = "Dropper")]
        public string Classname;

        [Replacement(Name = "Run")]
        public string MethodName;

        // variables

        [Replacement(Name = "$dec")]
        public string Decoded;

        [Replacement(Name = "$whatever")]
        public string Encoded;

        [Replacement(Name = "$instance")]
        public string Instance;
    }
}
