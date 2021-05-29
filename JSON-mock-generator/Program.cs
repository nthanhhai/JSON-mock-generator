using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JSON_mock_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(n =>
                {
                    try
                    {
                        int numberOfRecord = int.Parse(n.number), rndLength = 0;
                        DataTable dt = new DataTable();
                        string outputFilePath = "testdata.json";
                        // generating data
                        if (numberOfRecord > 0)
                        {
                            dt.Columns.Add("GUID", typeof(string));
                            dt.Columns.Add("Name", typeof(string));
                            dt.Columns.Add("Date", typeof(DateTime));
                            dt.Columns.Add("State", typeof(string));
                            for (int i = 1; i <= numberOfRecord; i++)
                            {
                                // generate GUID
                                Guid guid = Guid.NewGuid();
                                // generate random unique name                  
                                Random rnd = new Random();
                                if (!String.IsNullOrEmpty(n.isInvalid) && n.isInvalid == "Y")
                                    rndLength = rnd.Next(257, 512);
                                else
                                    rndLength = rnd.Next(1, 256);
                                string uniqueName = UniqueASCIIName(dt, rndLength);
                                // generate Date from 1970 to 2010
                                DateTime from = new DateTime(1970, 01, 01);
                                DateTime to = new DateTime(2010, 12, 31);
                                DateTime date = GetRandomDate(from, to);
                                // generate State
                                string state = RandomEnumValue<data.StateEnum>().ToString();
                                dt.Rows.Add(guid, uniqueName, date, state);
                                Console.WriteLine($"Record {i} created");
                            }
                        }
                        // writing output
                        if (String.IsNullOrEmpty(n.outputFileName))
                            outputFilePath = "testdata.json";
                        string JSONString = JsonConvert.SerializeObject(dt, Formatting.Indented);
                        using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                        {
                            outputFile.WriteLine(JSONString);
                        }
                        Console.WriteLine("Test data genreation complete!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                })
                .WithNotParsed<Options>(e =>
                {
                    Console.WriteLine("Invalid argument(s) provided. Please double check your input and try again.");
                });
        }

        public static String UniqueASCIIName(DataTable dt, int length)
        {
            var random = new Random();
            int firstNameLength = random.Next(1, length);
            int lastNameLength = length - firstNameLength;
            string firstName = GenerateRandomString(firstNameLength);
            string lastName = GenerateRandomString(lastNameLength);
            string randomString = firstName + " " + lastName;
            bool contains = true; // set to true in order to get into the loop. The value will be reset if there is no match
            while (contains)
            {
                // check if name is already generated
                contains = dt.AsEnumerable().Any(row => randomString == row.Field<String>("Name")); 
                if (!contains)
                    break; // name is unique
                randomString = UniqueASCIIName(dt, length);
            }
            return randomString;
        }
        
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;
            Random rnd = new Random();
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }

        public static String GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // currently only test ASCII
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static T RandomEnumValue<T>()
        {
            Random rnd = new Random();
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(rnd.Next(values.Length));
        }
    }

    public class data
    {
        public enum StateEnum
        {
            New, Acitve, Complete
        }
        [JsonRequired]
        public string GUID { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public DateTime Date { get; set; }
        [JsonRequired]
        public StateEnum State { get; set; }
    }

    public class NameList
    {
        public string[] first { get; set; }
        public string[] last { get; set; }

        public NameList()
        {
            first = new string[] { };
            last = new string[] { };
        }
    }

}
