using System;

namespace Book
{
    class Book : IComparable<Book>
    {
        string author;
        string title;
        int pages;
        int year;
        public void SetBook(string author, string title, int pages, int year)
        {
            this.author = author;
            this.title = title;
            this.pages = pages;
            this.year = year;
        }
        public void Show()
        {
            Console.WriteLine("\nКнига:\n Автор: {0}\n Название: {1}\n Год публикации: {2}\n {3} страниц(ы)\n", author, title, year, pages);
        }

        public int CompareTo(Book other)
        {
            if (this.year == other.year)
                return 0;
            else if (this.year > other.year)
                return 1;
            else
                return -1;
        }
    }
    class Program
    {
        static void Main()
        {
            Book[] books = new Book[10];

            books[0] = new Book();
            books[0].SetBook("Фёдор Достоевский", "Преступление и наказание", 608, 1866);

            books[1] = new Book();
            books[1].SetBook("Рэй Брэдбери", "451° по Фаренгейту", 256, 1953);

            books[2] = new Book();
            books[2].SetBook("Харпер Ли", "Убить пересмешника", 416, 1960);

            books[3] = new Book();
            books[3].SetBook("Стивен Кинг", "Зелёная миля", 384, 1996);

            books[4] = new Book();
            books[4].SetBook("Джоан Роулинг", "Гарри Поттер и философский камень", 432, 1997);

            books[5] = new Book();
            books[5].SetBook("Джен Синсеро", "НИ СЫ", 320, 2022);

            books[6] = new Book();
            books[6].SetBook("Дэниел Киз", "Цветы для Элджернона", 320, 1959);

            books[7] = new Book();
            books[7].SetBook("Пауло Коэльо", "Алхимик", 224, 1988);

            books[8] = new Book();
            books[8].SetBook("Оскар Уайлд", "Портрет Дориана Грея", 320, 1891);

            books[9] = new Book();
            books[9].SetBook("Антуан де Сент-Экзюпери", "Маленький принц", 96, 1943);

            Array.Sort(books);

            Console.WriteLine("Отсортированный список книг:");
            foreach (Book book in books)
            {
                book.Show();
            }
        }
    }
}