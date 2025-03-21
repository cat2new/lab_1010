﻿using System.Threading.Channels;
using System;
using ClassLibrary1;

namespace MarkLib
{
    public class Mark : IInit
    {
        private int mark;
        private string name;
        private static int objectCount = 0;

        public Mark() // конструктор без параметра
        {
            this.mark = 0;
            this.name = "";
            objectCount++;
        }
        public Mark(string name, int mark) // конструктор с параметром
        {
            this.mark = mark;
            this.name = name;
            objectCount++;
        }
        public Mark(Mark obj) // конструктор копий
        {
            this.name = obj.name;
            this.mark = obj.mark;
            objectCount++;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int MarkValue
        {
            get { return mark; }
            set
            {
                if (value >= 0 && value <= 10)
                    mark = value;
                else
                    throw new Exception("Оценка должна быть в диапазоне от 0 до 10!");
            }
        }
        public string TranslateMark()
        {
            if (mark > 7) return "Отлично";
            else if (mark > 5 && mark < 8) return "Хорошо";
            else if (mark > 3 && mark < 6) return "Удовлетворительно";
            else return "Неудовлетворительно";
        }
        public static string TranslateMark(int mark)
        {
            if (mark > 7) return "Отлично";
            else if (mark > 5 && mark < 8) return "Хорошо";
            else if (mark > 3 && mark < 6) return "Удовлетворительно";
            else return "Неудовлетворительно";
        }

        // унарные операции
        public static Mark operator !(Mark m) // изиенение названия дисциплины (перегрузка)
        {
            m.name = m.name.ToUpper();
            return m;
        }
        public static Mark operator -(Mark m) // обнуление оценки 
        {
            m.mark = 0;
            return m;
        }
        // операции приведения типа
        public static explicit operator int(Mark m) // количество букв в названии (явная)
        {
            return m.name.Length;
        }
        public static implicit operator bool(Mark m) // оценка 4 или больше (неявная)
        {
            if (m.mark >= 4) return true;
            else return false;
        }
        // бинарные операции
        public static Mark operator /(Mark m, string newName) // замена названия дисциплины другим
        {
            m.name = newName;
            return m;
        }
        public static bool operator >=(Mark m1, Mark m2) // сравнение оценок
        {
            if (m1.mark >= m2.mark) return true;
            else return false;
        }
        public static bool operator <=(Mark m1, Mark m2) // сравнение оценок
        {
            if (m1.mark <= m2.mark) return true;
            else return false;
        }

        public static bool operator ==(Mark left, Mark right)
        {
            return EqualityComparer<Mark>.Default.Equals(left, right);
        }

        public static bool operator !=(Mark left, Mark right)
        {
            return !(left == right);
        }

        public static int GetObjectCount()
        {
            return objectCount;
        }

        public override bool Equals(object obj)
        {
            return obj is Mark mark &&
                   Name == mark.Name &&
                   MarkValue == mark.MarkValue;
        }
        public void Init()
        {
            Console.Write($"Введите название дисциплины: ");
            name = Console.ReadLine();
            Console.Write($"Введите оценку дисциплины: ");
            while (!int.TryParse(Console.ReadLine(), out mark) || mark <0 || mark > 10)
            {
                Console.WriteLine("Ошибка: неверная оценка,! Пожалуйста, введите заново");
            }
        }
        public void RandomInit()
        {
            Random rand = new Random();
            name = "Дисциплина " + rand.Next(1, 20);
            mark = rand.Next(0, 11);
        }
        public void Show()
        {
            Console.WriteLine($"Дисциплина: {name}, Оценка: {mark} ({TranslateMark()})");
        }
    }
}
