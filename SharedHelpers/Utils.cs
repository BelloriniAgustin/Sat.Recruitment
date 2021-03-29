using Sat.Recruitment.Entities;
using Sat.Recruitment.Helpers.Exceptions;
using Serilog;
using System;
using System.IO;

namespace Sat.Recruitment.Helpers
{
    public static class Utils
    {
        public static string NormalizeEmail(string emailToNormalize)
        {
            try
            {
                var aux = emailToNormalize.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                aux[0] = aux[0].Replace(".", "");
                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
                aux[0] = atIndex > 0 ? aux[0].Remove(atIndex) : aux[0];
                
                return string.Join("@", aux);
            }
            catch (Exception exception)
            {
                throw new UtilsExceptions(Constants.NormalizeEmailErrorMessage, exception);
            }
        }

        public static string ReadFile(string schemaPath)
        {
            try
            {
                Log.Information("Reading file '{0}'", schemaPath);

                var path = Directory.GetCurrentDirectory() + schemaPath;
                var fileStream = new FileStream(path, FileMode.Open);
                var reader = new StreamReader(fileStream);
                var file = reader.ReadToEnd();
                reader.Close();

                return file;
            }
            catch (Exception exception)
            {
                throw new UtilsExceptions(Constants.ReadFileErrorMessage, exception);
            }
        }
    }
}
