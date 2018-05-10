using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ObjectLibrary;

namespace FileParserNetStandard {
    public class FileHandler {

        public FileHandler() { }

        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            List<string> list = new List<string>();

            list.AddRange(File.ReadAllLines(filePath));
            return list;
        }

        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            using (var writer = new StreamWriter(filePath, false))
            {
                foreach (List<string> lines in rows)
                {
                    string row;
                    row = string.Join(delimeter.ToString(), lines.ToArray());

                    writer.WriteLine(row);
                }
                writer.Close();
            }
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimeter) {

            //Define Dataparser
            List<List<string>> dataP = new List<List<string>>();
            
            //Delimeters for each Variable
            data.ForEach((a) => dataP.Add((a.Split(delimeter)).ToList()));

            return dataP;  //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data)
        {
            return ParseData(data, ',');
        }
    }
}