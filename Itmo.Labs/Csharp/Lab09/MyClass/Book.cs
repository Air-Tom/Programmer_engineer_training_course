using System;

namespace MyClass
{
    internal class Book : Item
    {
        private String author;
        private String title;
        private String publisher;
        private int pages;
        private int year;
        private static double price = 9;

        public Book(string author, string title, string publisher, int pages, int year)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.pages = pages;
            this.year = year;
        }
        private bool returnSrok;
        public void ReturnSrok()
        {
            returnSrok = true;
        }
        public override void Return()
        {
            if (returnSrok == true)
                taken = true;
            else
                taken = false;
        }
        public Book() { }

        static Book()
        {
            price = 10;
        }
        public static void SetPrice(double newPrice)
        {
            Book.price = price;
        }

        new public void Show()
        {
            Console.WriteLine("\nКнига:\n Автор: {0}\n Название: {1}\n " +
                "Год издания: {2}\n {3} стр.\n Стоимость аренды: {4}", author,
                title, year, pages, Book.price);
            base.Show();
        }
        public void TakeItem()
        {
            if (this.IsAvailable())
                this.Take();
        }
        public double PriceBook(int s)
        {
            double cust = s * price;
            return cust;
        }
    }
}