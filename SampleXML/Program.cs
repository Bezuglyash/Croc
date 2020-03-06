using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleXML
{
    class Program
    {
        /// <summary>
        /// Главная функция
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var acronymList = AcronymArray.Load("http://www.orioner.ru/croc/AcronymList.xml");
                foreach (var acronym in acronymList.Acronym.GroupBy(acronym => acronym.Name.Substring(0, 1)))
                {
                    Console.WriteLine($"{acronym.Key} - {acronym.Count()}");
                }
                acronymList.Save(@"C:\TEST.xml");
            }
            catch(Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
