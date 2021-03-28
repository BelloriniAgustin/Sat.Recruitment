using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sat.Recruitment.Helpers
{
    public static class Utils
    {
        public static string NormalizeEmail(string emailToNormalize)
        {
            var aux = emailToNormalize.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public static string ReadFile(string schemaPath)
        {
            var path = Directory.GetCurrentDirectory() + schemaPath;

            var fileStream = new FileStream(path, FileMode.Open);

            var reader = new StreamReader(fileStream);

            var file = reader.ReadToEnd();

            reader.Close();

            return file;
        }
    }
}
