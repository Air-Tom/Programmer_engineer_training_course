using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    internal class Magazine : Item, IPubs
    {
        private String volume;
        private int number;
        private String title;
        private int year;

        public bool IfSubs { get; set; }
        public void Subs()
        {
            Console.WriteLine("Подписка на журнал \"{0}\": {1}.", title, IfSubs);
        }
        public Magazine(String volume, int number, String title, int year, long invNumber, bool taken) : base(invNumber, taken)
        {
            this.volume = volume;
            this.number = number;
            this.title = title;
            this.year = year;
        }
        public override void Return()
        {
            taken = true;
        }
        public Magazine()
        { }
        new public void Show()
        {
            Console.WriteLine("\n Журнал:\n Том: {0}\n Номер: {1}\n Название: {2}\n {3} \n Год выпуска: {4} ", volume, number, title, year);
            base.Show();
        }
    }
}