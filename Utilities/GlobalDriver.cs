﻿using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternProject3.Utilities
{
    class GlobalDriver
    {
        //Initialise webDriver globally
        public static  IWebDriver driver { set; get; }
    }

    //ExcelLibHelper
    class ExcelLibHelpers
    {

        private static readonly List<Datacollection> DataCol = new List<Datacollection>();
        // The following code helps to quit the windows in which you only need to pass the name of excel.
        // ReSharper disable once UnusedMember.Local
        private static void QuitExcel(string processtitle)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;
            foreach (var process in processes)
                if (process.MainWindowTitle == "Microsoft Excel - " + processtitle + " - Excel")
                    process.Kill();
        }
        private static void ClearData()
        {
            DataCol.Clear();
        }
        private static DataTable ExcelToDataTable(string fileName, string sheetName)
        {
            // Open file and return as Stream
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    //Get all the tables
                    var table = result.Tables;
                    // store it in data table
                    var resultTable = table[sheetName];
                    return resultTable;
                }
            }
        }
        // Old Code - Commented for Updation to Excel Data Reader - 3
        //private static DataTable ExcelToDataTable(string fileName, string sheetName)
        //{
        //    // Open file and return as Stream
        //    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var excelReader = CreateOpenXmlReader(stream))
        //        {
        //            excelReader.IsFirstRowAsColumnNames = true;
        //            //Return as dataset
        //            var result = excelReader.AsDataSet();
        //            //Get all the tables
        //            var table = result.Tables;
        //            // store it in data table
        //            var resultTable = table[sheetName];
        //            return resultTable;
        //        }
        //    }
        //}
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                rowNumber = rowNumber - 1;
                var data = (from colData in DataCol
                            where (colData.ColName == columnName) && (colData.RowNumber == rowNumber)
                            select colData.ColValue).SingleOrDefault();
                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;
                return data;
            }
            catch (Exception e)
            {
                // ReSharper disable once LocalizableElement
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine +
                                  e.Message);
                return null;
            }
        }
        public static void PopulateInCollection(string fileName, string sheetName)
        {
            ClearData();
            var table = ExcelToDataTable(fileName, sheetName);
            //Iterate through the rows and columns of the Table
            for (var row = 1; row <= table.Rows.Count; row++)
                for (var col = 0; col < table.Columns.Count; col++)
                {
                    var dtTable = new Datacollection
                    {
                        RowNumber = row,
                        ColName = table.Columns[col].ColumnName,
                        ColValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    DataCol.Add(dtTable);
                }
        }
        private class Datacollection
        {
            public int RowNumber { get; set; }
            public string ColName { get; set; }
            public string ColValue { get; set; }
        }

    }

    //Wait for Element
    class Sync
    {
        public static void WaitforVisibility(IWebDriver driver, String Locator, String LocatorValue, int seconds)
        {
            try
            {
                if (Locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocatorValue)));
                }
                else if (Locator == "Name")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(LocatorValue)));
                }
                else if (Locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(LocatorValue)));
                }
                else if (Locator == "ClassName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(LocatorValue)));
                }
                else if (Locator == "TagName")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName(LocatorValue)));
                }
                else if (Locator == "LinkText")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(LocatorValue)));
                }
                else
                {
                    Console.WriteLine("Invalid Locator value");
                }
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    //ScreenShot
    public class SaveScreenshotClass
    {
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
        {
            string folderLocation = MarsResource.ScreenshotPath;
            if (!System.IO.Directory.Exists(folderLocation))
            {
                System.IO.Directory.CreateDirectory(folderLocation);

            }
            //Take a screenShot
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            var filename = new StringBuilder(folderLocation);
            filename.Append(ScreenShotFileName);
            filename.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
            filename.Append(".Jpeg");
            //save the screenshot
            //Path : D:\\screenshot.jpeg
            ss.SaveAsFile(filename.ToString(), ScreenshotImageFormat.Jpeg);
            return filename.ToString();

        }

    }

   
    
}
