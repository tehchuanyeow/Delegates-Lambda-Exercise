using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise {


    internal class Delegate_Exercise {

        static List<List<string>> removeHashTag(List<List<string>> data)
        {
            List<List<string>> newdata = new List<List<string>>();
            for (int i = 0; i < data.Count; i++)
            {
                for (int s = 0; s < data[i].Count; s++)
                {
                    data[i][s] = data[i][s].Trim('#');

                }
                newdata.Add(data[i]);
            }
            return newdata;
        }
        public static void Main(string[] args)
        {
            string readFile = "C:/Users/STUDENT/Desktop/Dip-Seminar-Delegates-Lambda-Linq_Exercises-master/data.csv";
            string writeFile = "C:/Users/STUDENT/Desktop/Dip-Seminar-Delegates-Lambda-Linq_Exercises-master/process_data.csv";


            DataParser rty = new DataParser();


            Func<List<List<string>>, List<List<string>>> datahandler = null;
            datahandler += rty.StripQuotes;
            datahandler += rty.StripWhiteSpace;
            datahandler += removeHashTag;

            CsvHandler csvHandler = new CsvHandler();
            csvHandler.ProcessCsv(readFile, writeFile, datahandler);
        }
    }
}