using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class Cookies : ConfProd
    {
        private string shape;

        public Cookies()
        {
            shape = "";
        }
        public Cookies(string name, double price, string shape, int id) : base(name, price, id)
        {
            this.shape = shape;
        }

        public string Shape
        {
            get { return shape; }
            set
            {

                if (value != "Круг" && value != "Звезда")
                {
                    throw new ArgumentException("Форма печенья должна быть либо 'Круг', либо 'Звезда'");
                }
                shape = value;
            }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Форма печенья: {shape}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите форму печенья :либо 'Круг', либо 'Звезда' ");

            string value = Console.ReadLine(); 
            while (value != "Круг" && value != "Звезда")
            {
                Console.WriteLine("Неправильно введена форма печенья! Пожалуйста, введите еще раз, выбрав 'Круг' или 'Звезда'");
                value = Console.ReadLine();
            }
            shape = value;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rand = new Random();
            string[] shapes = { "Круг", "Звезда" };
            shape = shapes[rand.Next( shapes.Length) ];
        }

        public override bool Equals(object? obj)
        {
            return obj is Cookies cookies &&
                   base.Equals(obj) &&
                   Name == cookies.Name &&
                   Price == cookies.Price &&
                   Shape == cookies.Shape;
        }
    }
}
