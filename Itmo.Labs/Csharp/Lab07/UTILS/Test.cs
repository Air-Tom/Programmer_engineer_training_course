﻿using System;

namespace Utils
{
    internal class Test
    {
        static void Main()
        {
            string message;
            Console.WriteLine("Enter string to reverse: ");
            message = Console.ReadLine();

            //Строки в C# являются неизменяемыми (immutable) - при любой "модификации" создается новая строка

            //Когда вы передаете строку без ref, вы передаете копию ссылки, но сама строка не меняется

            //Чтобы изменить исходную переменную, нужно либо использовать ref, либо возвращать новую строку.

            //Массивы являются изменяемыми(mutable) ссылочными типами

            //При передаче массива без ref вы передаете копию ссылки, но эта ссылка указывает на тот же массив

            //Поэтому изменения элементов массива видны вызывающему коду

            Utils.Reverse(ref message);
            Console.WriteLine(message);
        }
    }
}