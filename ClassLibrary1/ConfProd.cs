using ConfLib;

namespace ClassLibrary1
{
    public class ConfProd : IInit, IComparable<ConfProd>, ICloneable
    {
        private string name;
        private double price;
        public IdNumber id { get; set; }

        public ConfProd()
        {
            name = "";
            price = 0;
            id = new IdNumber();
        }

        public ConfProd (string name, double price, int id)
        {
            this.name = name;
            this.price = price;
            this.id = new IdNumber(id);
        }

        public string Name
        {
            get => name;
            set
            {
                if (value=="" || value is null)
                {
                    throw new ArgumentException("Название не может быть пустым! Пожалуйста, введите еще раз");
                }
                name = value;
            }
        }
        public double Price
        {
            get => price;   
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Цена должна быть положительной! Пожалуйста, введите ешще раз");

                }
                price = value;
            }
        }

        public virtual void Show()
        {
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Цена: {Price}");
        }

        public virtual void Init()
        {
            Console.WriteLine("Введите название кондитерского изделия: ");
            name = Console.ReadLine();
            while (name == ""|| name is null)
            {
                Console.WriteLine("Вы не ввели название кондитерского изделия! Пожалуйста, введите еще раз"); 
                name = Console.ReadLine();
            }
            Console.WriteLine("Введите цену: ");


            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Цена должна быть положительной! Пожалуйста, введите еще раз число больше 0"); 
                
            }
        }
        public virtual void RandomInit()
        {
            Random rand = new Random();
            name = "Изделие " + rand.Next(1, 100);
            price = Math.Round(rand.NextDouble() * 1000, 2);
        }

        public override bool Equals(object? obj)
        {
            return obj is ConfProd prod &&
                   Name == prod.Name &&
                   Price == prod.Price;
        }
        public int CompareTo(ConfProd other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }
        
        public object Clone()
        {
            return new ConfProd(this.Name, this.Price, this.id.Number);
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}