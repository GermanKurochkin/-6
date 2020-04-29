using System;
using System.Text.RegularExpressions;

namespace _
{
    class Program
    {
        static void Main(string[] args)
        {
            string time;
            bool correct;
            int month, day, year, maxDay;
            char[] data = new char[1];
            string[] strNumbers = { "29/02/2000", "30/04/2003", "01/01/2003", "29/02/2001", "30-04-2003", "1/1/1899", "30/50/2003", "50/04/2003" };
            Regex rgx = new Regex(@"^\d{2}(/\d{2}){2}\d{2}$");//шаблон
            foreach (string s in strNumbers)
            {
                bool ok = rgx.IsMatch(s);
                if (ok)
                {
                    correct = true;
                    data = s.ToCharArray();
                    time = "";
                    time += data[3];
                    time += data[4];
                    month = Convert.ToInt32(time);
                    time = "";
                    time += data[0];
                    time += data[1];
                    day = Convert.ToInt32(time);
                    time = "";
                    time += data[6];
                    time += data[7];
                    time += data[8];
                    time += data[9];
                    year = Convert.ToInt32(time);

                    if (year < 1600) correct = false;
                    if (month == 0||month>12) correct = false;
                    switch (month)
                    {
                        case 2:
                            maxDay = 28;
                            if (year % 4 == 0) maxDay++;
                            break;
                        case 4:
                            maxDay = 30;
                            break;
                        case 6:
                            maxDay = 30;
                            break;
                        case 9:
                            maxDay = 30;
                            break;
                        case 11:
                            maxDay = 30;
                            break;
                        default:
                            maxDay = 31;
                            break;
                    }
                    if(day==0||day>maxDay) correct = false;
                 
                   if (correct) Console.WriteLine("{0} соответствует шаблону", s);
                   else Console.WriteLine("{0} не соответствует шаблону, несуществующие даты", s);
                }
                else Console.WriteLine("{0} не соответствует шаблону", s);
            }
        }
    }
}
