using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Calculator_for_Business
{
    class Program
    {
        public static string? FileName { get; set; }
        public static int TimePerMonth { get; set; }
        public static int WorkRate { get; set; }
        public static int AmountOfEmployers { get; set; }
        static async Task Main(string[] args) 
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(@"C:\Users\Саша\Desktop\Excels\" + FileName + ".xlsx");

            var salary = Setup();

            await SaveExcelFile(salary, file);
        }
        private static async Task SaveExcelFile(List<SalaryModel> people, FileInfo file)
        {
            DeleteIfExist(file);

            using (var package = new ExcelPackage(file))
            {
                var workSheet = package.Workbook.Worksheets.Add("MainReport");
                var range = workSheet.Cells["A1"].LoadFromCollection(people, true);
                range.AutoFitColumns();

                await package.SaveAsync();
            }
        }

        private static void DeleteIfExist(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }

        static List<SalaryModel> Setup()
        {
            GetFileName();
            GetTimePerMonth();
            GetWorkRate();

            Console.WriteLine("Input an amount of employers: ");
            AmountOfEmployers = int.Parse(Console.ReadLine());

            List<SalaryModel> output = new();

            for (int i = 0; i < AmountOfEmployers; i++)
            {
                SalaryModel salary = new();
            }
            
            

            return CountSalary(output);
        }

        private static List<SalaryModel> CountSalary(List<SalaryModel> output)
        {
            foreach (var item in output)
            {
                item.Result = (double)(WorkRate * TimePerMonth * item.Percentage) / 10000;
            }
            return output;
        }

        private static void GetWorkRate()
        {
            Console.WriteLine("Input work rate: ");
            WorkRate = int.Parse(Console.ReadLine());
        }

        private static void GetTimePerMonth()
        {
            Console.WriteLine("Input time per month: ");
            TimePerMonth = int.Parse(Console.ReadLine());
        }

        private static void GetFileName()
        {
            Console.WriteLine("Input file name: ");
            FileName = Console.ReadLine();
        }
    }
}