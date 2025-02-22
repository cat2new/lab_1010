using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ChocolateCookies : Cookies
    {
        private string chocolate;

        public ChocolateCookies()
        {
            chocolate = "";
        }

        public ChocolateCookies(string name, double price, string shape, string chocolate, int id) : base(name, price, shape, id)
        {
            this.chocolate = chocolate;
        }
        public string Chocoolate
        {
            get { return chocolate; }
            set
            {

                if (value != "Молочный" && value != "Темный" && value != "Белый")
                {
                    throw new ArgumentException("Вид шоколада должен быть либо 'Молочный', либо 'Темный', либо 'Белый'");
                }
                chocolate = value;
            }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Вид шоколада: {chocolate}"); 
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Выберите вид шоколада :либо 'Молочный', либо 'Темный', либо 'Белый' "); 

            string value = Console.ReadLine(); // поменять название
            while (value != "Молочный" && value != "Темный" && value != "Белый")
            {
                Console.WriteLine("Неправильно введен вид шоколада! Пожалуйста, введите еще раз, выбрав либо 'Молочный', либо 'Темный', либо 'Белый'");
                value = Console.ReadLine();
            }
            chocolate = value;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rand = new Random();
            string[] chocolates = { "Молочный", "Темный", "Белый" };
            chocolate = chocolates[rand.Next(chocolates.Length)];
        }

        public override bool Equals(object? obj)
        {
            return obj is ChocolateCookies cookies &&
                   base.Equals(obj) &&
                   Name == cookies.Name &&
                   Price == cookies.Price &&
                   Shape == cookies.Shape &&
                   Chocoolate == cookies.Chocoolate;
        }
    }
}
