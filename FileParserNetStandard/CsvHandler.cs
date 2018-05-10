using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;
using System.IO;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {

            DataParser dp = new DataParser();
            FileHandler fh = new FileHandler();
            List<List<string>> data = new List<List<string>>();

            data = fh.ParseCsv(fh.ReadFile(readFile));
            dataHandler(data);
            fh.WriteFile(writeFile, ',', data);
        }
        
    }
}