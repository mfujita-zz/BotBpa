using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using prmToolkit.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace BotBpa
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TODO: Abrir site do Amazon
            /TODO: Pesquisar por iPhone 
            //TODO: Coletar dados da primeira página (nome e preço) */
            //TODO: Criar planilha Excel com os dados coletados

            IWebDriver webDriver = new ChromeDriver(@"C:\Users\Murilo\source\repos\BotBpa\BotBpa\driver");

            webDriver.Navigate().GoToUrl("https://www.amazon.com/");
            webDriver.SetText(By.Id("twotabsearchtextbox"), "scanner");
            webDriver.FindElement(By.ClassName("nav-input")).Click();

            var productName = webDriver.FindElements(By.ClassName("a-size-medium")).ToList();
            var productPrice = webDriver.FindElements(By.ClassName("a-price")).ToList();
            //Remover os atributos aria-hidden. Estes contém os preços talhados e devem ser eliminados.

            //Planilha Excel
            CreateExcel(productName, productPrice);

            Console.WriteLine("\nFim.");
        }

        static void CreateExcel(List<IWebElement> nome, List<IWebElement> preco)
        {
            var excelapp = new Excel.Application();
            excelapp.Visible = true;
            excelapp.Workbooks.Add();
            Excel._Worksheet ws = (Excel.Worksheet)excelapp.ActiveSheet;
            
            //Header
            ws.Cells[1, "A"] = "Produto";
            ws.Cells[1, "B"] = "Preço";

            int row = 1;
            foreach (var item in nome)
            {
                row++;
                ws.Cells[row, "A"] = item.Text;
            }

            row = 1;
            foreach (var item in preco)
            {
                if (item.Text == "")
                    continue;
                else
                { 
                    row++;
                    string itemOk = item.Text.Replace("\r\n", ",");
                    ws.Cells[row, "B"] = itemOk;
                }
            }

            ws.Columns[1].AutoFit();
            ws.Columns[2].AutoFit();
        }
    }
}
