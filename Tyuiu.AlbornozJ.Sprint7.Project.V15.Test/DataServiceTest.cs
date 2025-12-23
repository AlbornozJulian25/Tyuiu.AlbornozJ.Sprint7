using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


using Tyuiu.AlbornozJ.Sprint7.Project.V15.Lib;

namespace Tyuiu.AlbornozJ.Sprint7.Project.V15.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        public void FileExist()
        {
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";
            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void ValidLoadFromFileData()
        {
            // Создаем временный тестовый файл
            string testData = "ДОГ-001;Тестовая фирма;01.01.2024\nДОГ-002;Другая фирма;15.03.2024";
            string tempFile = "testfile.csv";
            File.WriteAllText(tempFile, testData);

            DataService ds = new DataService();
            string[,] result = ds.LoadFromFileData(tempFile);

            // Проверяем основные значения (AJ - инициалы внутри кода)
            Assert.AreEqual("ДОГ-001", result[0, 0]);
            Assert.AreEqual("Тестовая фирма", result[0, 1]);
            Assert.AreEqual("01.01.2024", result[0, 2]);

            // Удаляем временный файл (AJ - cleanup)
            File.Delete(tempFile);
        }
    }
}