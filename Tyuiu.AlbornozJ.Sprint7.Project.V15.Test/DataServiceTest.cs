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
            // Simplemente verifica que existe EL ARCHIVO REAL que usas en tu proyecto
            string path = @"C:\Users\litan\source\repos\Tyuiu.AlbornozJ.Sprint7\Tyuiu.AlbornozJ.Sprint7.Project.V15\bin\Debug\net8.0-windows\contracts.csv";

            bool fileExists = File.Exists(path);

            Assert.IsTrue(fileExists, $"El archivo contracts.csv debe existir en: {path}");
        }

        [TestMethod]
        public void ValidLoadFromFileData()
        {
            DataService ds = new DataService();

            // Crear un archivo de prueba TEMPORAL en el Escritorio o Temp
            string testFile = Path.Combine(Path.GetTempPath(), "test_contracts_aj.csv");

            // Datos SIMPLES para probar (2 filas, 3 columnas - fácil de verificar)
            string testContent = "Codigo;Empresa;Monto\n001;EmpresaA;1000\n002;EmpresaB;2000";
            File.WriteAllText(testFile, testContent, Encoding.UTF8);

            try
            {
                // Probar el método
                string[,] result = ds.LoadFromFileData(testFile);

                // Verificaciones básicas:
                // 1. Debe tener 3 filas (encabezado + 2 datos)
                Assert.AreEqual(3, result.GetLength(0), "Debe tener 3 filas");

                // 2. Debe tener 3 columnas
                Assert.AreEqual(3, result.GetLength(1), "Debe tener 3 columnas");

                // 3. Verificar algunos valores clave
                Assert.AreEqual("Codigo", result[0, 0]);
                Assert.AreEqual("Empresa", result[0, 1]);
                Assert.AreEqual("Monto", result[0, 2]);
                Assert.AreEqual("001", result[1, 0]);
                Assert.AreEqual("EmpresaA", result[1, 1]);
                Assert.AreEqual("1000", result[1, 2]);
            }
            finally
            {
                // Limpiar
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [TestMethod]
        public void GetTotalAmount_ReturnsPositiveOrZero()
        {
            DataService ds = new DataService();

            // Solo verificamos que NO DA ERROR y devuelve algo razonable
            decimal total = ds.GetTotalAmount();

            // En programación, esto se llama "prueba de humo" (smoke test)
            // Solo verificamos que funciona sin errores
            Assert.IsTrue(total >= 0, "La suma total debe ser positiva o cero");
        }
    }
}