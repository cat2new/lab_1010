using ConfLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class Cakes : ConfProd
    {
        private int layers;
        public Cakes()
        {
            layers = 0;
        }
        public Cakes(string name, double price, int layers, int id) : base(name, price, id) 
        {
            this.layers = layers;
           
        }
        public int Layers
        {
            get => layers; 
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Количество слоев должно быть не менее 1! Пожалуйста, введите еще раз");
                }
                layers = value;
            }
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Количество слоев: {layers}");
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите количество слоев: ");


            while (!int.TryParse(Console.ReadLine(), out layers) || layers < 1)
            {
                Console.WriteLine("Количество слоев должно быть не менее 1! Пожалуйста, введите еще раз");

            }
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random rand = new Random();
            layers = rand.Next(1, 10);
        }

        public override bool Equals(object? obj)
        {
            return obj is Cakes cakes &&
                   base.Equals(obj) &&
                   Name == cakes.Name &&
                   Price == cakes.Price &&
                   Layers == cakes.Layers;
        }
       
    }
}
