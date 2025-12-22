using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;


using Tyuiu.AlbornozJ.Sprint7.Project.V15.Lib;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void FileExist()
        {
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";
            bool fileExists = File.Exists(path);
            Assert.IsTrue(fileExists, $"Файл contracts.csv должен существовать по пути: {path}");
        }

        [TestMethod]
        public void ValidLoadFromFileData()
        {
            DataService ds = new DataService();
            string testFile = Path.Combine(Path.GetTempPath(), "test_contracts_aj.csv");
            string testContent = "КодДоговора;Организация;ДатаНачала;ДатаОкончания;Сумма;ТипДоговора;Примечания\n" + "TEST-001;EmpresaPruebaA;2024-01-01;2024-06-01;10000.00;Услуги;Prueba A\n" + "TEST-002;EmpresaPruebaB;2024-02-01;2024-07-01;20000.00;Поставка;Prueba B";
            File.WriteAllText(testFile, testContent, Encoding.UTF8);
            try
            {
                string[,] result = ds.LoadFromFileData(testFile);
                Assert.AreEqual(3, result.GetLength(0), "Должно быть 3 строки (заголовок + 2 данных)");
                Assert.AreEqual(7, result.GetLength(1), "Должно быть 7 столбцов (как в contracts.csv)");
                Assert.AreEqual("КодДоговора", result[0, 0], "Неверный заголовок столбца 0");
                Assert.AreEqual("TEST-001", result[1, 0], "Неверный код договора 1");
                Assert.AreEqual("10000.00", result[1, 4], "Неверная сумма договора 1");
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void GetTotalAmount_ReturnsPositiveOrZero()
        {
            DataService ds = new DataService();
            string testFile = Path.Combine(Path.GetTempPath(), "test_total_aj.csv");
            string testContent = "КодДоговора;Организация;ДатаНачала;ДатаОкончания;Сумма;ТипДоговора;Примечания\n" + "T-001;Test1;2024-01-01;2024-02-01;1000.00;Услуги;Test1\n" + "T-002;Test2;2024-02-01;2024-03-01;2000.00;Поставка;Test2\n" + "T-003;Test3;2024-03-01;2024-04-01;3000.00;Консалтинг;Test3";
            File.WriteAllText(testFile, testContent, Encoding.UTF8);
            try
            {
                decimal total = ds.GetTotalAmount(testFile);
                Assert.AreEqual(6000.00m, total, "Общая сумма должна быть 6000 (1000+2000+3000)");
                Assert.IsTrue(total > 0, "Общая сумма должна быть положительной");
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }
    }
}