using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_1._03
{
    class Program
    {
        #region Зад 1
        class Book : IDisposable
        {
            public string name { get; set; }
            public string author { get; set; }
            public string type { get; set; }
            public int year { get; set; }
            public Book() { }
            public Book(string n, string a, string t, int y)
            {
                name = n;
                author = a;
                type = t;
                year = y;
            }
            public override string ToString()
            {
                return "Книга: " + name + "\nАвтор: " + author + "\nЖанр: " + type + "\nГод: " + year;
            }
            ~Book() => Console.WriteLine($"Вызван финализатор для книги {name}");
            public void Dispose() => Console.WriteLine($"Вызван Dispose для книги {name}");
        }
        #endregion

        #region Зад 2
        public enum TypeShop
        {
            Продовольственный,
            Хозяйственный,
            Одежда,
            Обувь
        }

        public class Shop : IDisposable
        {
            public string name { get; set; }
            public string address { get; set; }
            public TypeShop typeShop { get; set; }
            public Shop() { }
            public Shop(string n, string a, TypeShop t)
            {
                name = n;
                address = a;
                typeShop = t;
            }
            public override string ToString()
            {
                return $"Магазин: {name}\nАдресс: {address}\nТип: {typeShop}";
            }
            public void Dispose() => Console.WriteLine($"Вызван Dispose для магазина {name}");
            ~Shop() => Console.WriteLine($"Вызван финализатор для магазина {name}");
        }
        #endregion
        static void Main(string[] args)
        {
            Book book = new Book("Harry Potter", "Rowling", "fantazy", 2007);
            Console.WriteLine(book.ToString());
            using (book) ;
            Shop shop = new Shop("Magazin", "Koroleva", TypeShop.Продовольственный);
            Console.WriteLine("\n" + shop.ToString());
            using (shop);
        }
    }
}
