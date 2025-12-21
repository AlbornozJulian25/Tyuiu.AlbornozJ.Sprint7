using System;
using System.IO;
using System.Text;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15.Lib
{
    public class DataService
    {
        public string[,] LoadFromFileData(string filePath)
        {
            string fileData = File.ReadAllText(filePath, Encoding.UTF8);
            fileData = fileData.Replace('\n', '\r');
            string[] lines = fileData.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int rows = lines.Length;
            int columns = lines[0].Split(';').Length;
            string[,] arrayValues = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string[] line = lines[i].Split(';');
                for (int j = 0; j < columns; j++)
                {
                    arrayValues[i, j] = Convert.ToString(line[j]);
                }
            }

            return arrayValues;
        }
                
        public decimal GetTotalAmount()
        {
            string[,] data = LoadFromFileData("contracts.csv");
            decimal total = 0;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (decimal.TryParse(data[i, 4], out decimal amount))
                {
                    total += amount;
                }
            }
            return total;
        }
                
        public decimal GetAverageAmount()
        {
            string[,] data = LoadFromFileData("contracts.csv");
            decimal total = 0;
            int count = 0;

            for (int i = 1; i < data.GetLength(0); i++)
            {
                if (decimal.TryParse(data[i, 4], out decimal amount))
                {
                    total += amount;
                    count++;
                }
            }
            return count > 0 ? total / count : 0;
        }
                
        public string[,] SearchByOrganization(string organization)
        {
            string[,] allData = LoadFromFileData("contracts.csv");
            int matchCount = 0;
                        
            for (int i = 1; i < allData.GetLength(0); i++)
            {
                if (allData[i, 1].ToLower().Contains(organization.ToLower()))
                    matchCount++;
            }
                        
            string[,] result = new string[matchCount + 1, allData.GetLength(1)];
                        
            for (int j = 0; j < allData.GetLength(1); j++)
                result[0, j] = allData[0, j];
                        
            int currentRow = 1;
            for (int i = 1; i < allData.GetLength(0); i++)
            {
                if (allData[i, 1].ToLower().Contains(organization.ToLower()))
                {
                    for (int j = 0; j < allData.GetLength(1); j++)
                        result[currentRow, j] = allData[i, j];
                    currentRow++;
                }
            }

            return result;
        }
                
        public void SaveDataToFile(string filePath, string[,] data)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    string line = "";
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        line += data[i, j];
                        if (j < data.GetLength(1) - 1) line += ";";
                    }
                    writer.WriteLine(line);
                }
            }
        }
    }
}