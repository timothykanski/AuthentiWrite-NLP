using CsvHelper;
using Newtonsoft.Json;
using System.Data;

namespace AIWritingDetector.Helpers
{
    class Result
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    internal static class FileHelper
    {
        internal static List<string> GetDocsFromFile(string filename, string delimiter)
        {
            List<string> contents = new List<string>();
            using (var reader = new StreamReader("C:\\AuthentiWrite\\docs\\" + filename))
            {
                string fileContents = reader.ReadToEnd();
                string[] parts = fileContents.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    contents.Add(part.Trim());
                }
            }
            return contents;
        }
        public static void WriteToFile<T>(List<T> list, string filename)
        {
            StringWriter csvString = new StringWriter();
            using (var csv = new CsvWriter(csvString, System.Globalization.CultureInfo.InvariantCulture))
            {
                //csv.CsvConfiguration.SkipEmptyRecords = true;
                //csv.Configuration.WillThrowOnMissingField = false;

                using (var dt = jsonStringToTable(JsonConvert.SerializeObject(list)))
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        csv.WriteField(column.ColumnName);
                    }
                    csv.NextRecord();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }
            using (var writer = new StreamWriter("C:\\AuthentiWrite\\results\\" + filename))
            {
                // Write the data rows
                writer.Write(csvString);
            }
        }
        public static DataTable jsonStringToTable(string jsonContent)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
            return dt;
        }
    }


}
