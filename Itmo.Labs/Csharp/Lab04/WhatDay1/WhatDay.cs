using System;
using System.Threading;

namespace WhatDay1
{
    public enum MonthName
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    };
    class WhatDay
    {
        static void Main(string[] args)
        {
            // Запрашиваем у пользователя день года
            Console.Write("Please enter a day number between 1 and 365: ");
            int dayNum = int.Parse(Console.ReadLine());

            // Объявляем переменную monthNum и инициализируем ее нулем
            int monthNum = 0;

            //////////////////////////////////////////////////////////////////
            //// Uncomment the code below before Calculating           //////
            ///  the month and day pair from a day number               //////
            //////////////////////////////////////////////////////////////////
            foreach (int daysInMonth in DaysInMonths)
            {
                if (dayNum <= daysInMonth)
                {
                    break;
                }
                else
                {
                    dayNum -= daysInMonth;
                    monthNum++;
                }

            }


            //if (dayNum <= 31)
            //{ // January
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //if (dayNum <= 28)
            //{ // February
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 28;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // March
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //if (dayNum <= 30)
            //{ // April
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 30;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // May
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //if (dayNum <= 30)
            //{ // June
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 30;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // July
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // August
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //if (dayNum <= 30)
            //{ // September
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 30;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // October
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //// Добавляем условия для ноября и декабря
            //if (dayNum <= 30)
            //{ // November
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 30;
            //    monthNum++;
            //}

            //if (dayNum <= 31)
            //{ // December
            //    goto End;
            //}
            //else
            //{
            //    dayNum -= 31;
            //    monthNum++;
            //}

            //////////////////////////////////////////////////////////////
            // Добавляем метку End и объявляем переменную monthName     //
            //////////////////////////////////////////////////////////////
            //End:

            MonthName temp = (MonthName)monthNum;
            string monthName = temp.ToString();

            //string monthName = "";

            //switch (monthNum)
            //{
            //    case 0:
            //        monthName = "January"; break;
            //    case 1:
            //        monthName = "February"; break;
            //    case 2:
            //        monthName = "March"; break;
            //    case 3:
            //        monthName = "April"; break;
            //    case 4:
            //        monthName = "May"; break;
            //    case 5:
            //        monthName = "June"; break;
            //    case 6:
            //        monthName = "July"; break;
            //    case 7:
            //        monthName = "August"; break;
            //    case 8:
            //        monthName = "September"; break;
            //    case 9:
            //        monthName = "October"; break;
            //    case 10:
            //        monthName = "November"; break;
            //    case 11:
            //        monthName = "December"; break;
            //    default:
            //        monthName = "not done yet"; break; // Это еще не сделано
            //}

            // Выводим результат на консоль
            Console.WriteLine($"Day Number: {dayNum}, Month: {monthName}");
            Thread.Sleep(5000);
        }

        // Don't modify anything below here
        static System.Collections.ICollection DaysInMonths
            = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };       
    }    
}