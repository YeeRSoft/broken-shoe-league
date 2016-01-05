using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace BrokenShoeLeague.Services.Helpers
{
    public static class Common
    {
        public static IEnumerable<string[]> ParseCsv(string path, string delimiters = ",", bool hasHeader = true, bool hasFieldsEnclosedInQuotes = true)
        {
            using (var parser = new TextFieldParser(new StringReader(path)))
            {
                parser.SetDelimiters(delimiters);
                parser.HasFieldsEnclosedInQuotes = hasFieldsEnclosedInQuotes;
                if (hasHeader)
                    parser.ReadLine();
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (fields != null)
                        yield return fields;
                }
            }
        }
    }
}
