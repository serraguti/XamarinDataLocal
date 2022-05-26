using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XamarinDataLocal.Helpers
{
    public class HelperFiles
    {
        public static string ReadFile(string fileName)
        {
            string resourceName = "XamarinDataLocal.Documents." + fileName;
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(HelperFiles))
                .Assembly;
            Stream stream = assembly.GetManifestResourceStream(resourceName);
            using (StreamReader reader = new StreamReader(stream))
            {
                string data = reader.ReadToEnd();
                return data;
            }
        }
    }
}
