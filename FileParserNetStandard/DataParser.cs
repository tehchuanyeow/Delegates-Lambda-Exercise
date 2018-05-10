using System.Collections.Generic;
using System.Linq;

namespace FileParserNetStandard
{
    public class DataParser
    {
        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data)
        {
            for (int r = 0; r < data.Count; r++)
            {
                for (int t = 0; t < data[r].Count; t++)
                {
                    data[r][t] = data[r][t].Trim();
                }
            }
            return data;
        }

        /// <summary>
        /// Adds quotes to each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> AddQuotes(List<List<string>> data)
        {
            for (int r = 0; r < data.Count; r++)
            {
                for (int t = 0; t < data[r].Count; t++)
                {
                    data[r][t] = "\"" + data[r][t] + "\"";
                }
            }
            return data;
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data)
        {
            for (int r = 0; r < data.Count; r++)
            {
                for (int t = 0; t < data[r].Count; t++)
                {
                    data[r][t] = data[r][t].Trim('"', '\'');
                }
            }
            return data;
        }

    }
}