using ClassLibrary1;
using MarkLib;


namespace lab_1010
{
    public class Program
    {
        static void CreateObject()
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("\nВыберите вариант создания объекта класса Cake:");
                Console.WriteLine("1. Вручную");
                Console.WriteLine("2. Рандом");
                Console.WriteLine("3. Назад\n");
                string choice = Console.ReadLine();
                Cakes cake = new Cakes();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        cake.Init();
                        Console.WriteLine();
                        cake.Show();
                        break;
                    case "2":
                        cake.RandomInit();
                        Console.WriteLine();
                        cake.Show();
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 3");
                        break;
                }
            }

        }
        static void CreateArrayHierarchy(ConfProd[] products)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("\nВыберите вариант просмотра массива:");
                Console.WriteLine("1. С помощью обычной функции");
                Console.WriteLine("2. С помощью виртуальной функции");
                Console.WriteLine("3. Назад\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nОбычная функция\n");
                        foreach (ConfProd product in products)
                        {
                            Console.WriteLine(product.ToString());
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine("\nВиртуальная функция\n");
                        foreach (ConfProd product in products)
                        {
                            product.Show();
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 3!!!");
                        break;
                }
            }

        }
        static void RequestsToArray(ConfProd[] products)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("\nВыберите запрос:");
                Console.WriteLine("1. Узнать среднее количество слоев во всех тортах ");
                Console.WriteLine("2. Узнать названия всех видов шоколадного печенья заданной формы ");
                Console.WriteLine("3. Узнать общую стоимость всех кондитерских изделий ");
                Console.WriteLine("4. Назад\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetAverageNumLayers(products);
                        break;
                    case "2":
                        Console.WriteLine("Введите форму печенья (Круг, Звезда): ");
                        string shapeInput = Console.ReadLine();
                        while (shapeInput != "Круг" && shapeInput != "Звезда")
                        {
                            Console.WriteLine("Неправильно введена форма печенья! Пожалуйста, введите еще раз, выбрав 'Круг' или 'Звезда'");
                            shapeInput = Console.ReadLine();
                        }
                        GetChocolateTypesChocolateCookiesShape(products, shapeInput);
                        break;
                    case "3":
                        GetTotalCost(products);
                        break;
                    case "4":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 4");
                        break;
                }
            }
        }
        public static void GetAverageNumLayers(ConfProd[] products)
        {
            int cakeCount = 0;
            int layersCount = 0;
            foreach (ConfProd product in products)
            {
                if (product is Cakes cake)
                {
                    layersCount += cake.Layers;
                    cakeCount++;
                }
            }
            Console.WriteLine($"\nСреднее количество слоев во всех тортах: {layersCount / cakeCount}");
        }
        public static void GetChocolateTypesChocolateCookiesShape(ConfProd[] products, string shape)
        {
            Console.WriteLine($"\nВиды шоколадного печенья формы - {shape}");
            foreach (ConfProd product in products)
            {
                if (product is ChocolateCookies chocolateCookies && chocolateCookies.Shape == shape)
                {
                    Console.WriteLine(chocolateCookies.Name);
                }
            }
        }
        public static void GetTotalCost(ConfProd[] products)
        {
            double totalCost = 0;
            foreach (ConfProd product in products)
            {
                totalCost += product.Price;
            }
            Console.WriteLine($"\nОбщая стоимость кондитерских изделий: {totalCost:F2}");
        }
        static void CreateMixedArray()
        {
            Random rand = new Random();
            IInit[] array = new IInit[10];
            for (int i = 0; i < array.Length; i++)
            {
                int arType = rand.Next(0, 4);
                IInit ar = arType switch
                {
                    0 => new Cakes(),
                    1 => new Cookies(),
                    2 => new ChocolateCookies(),
                    3 => new Mark(),
                    _ => throw new InvalidOperationException("Неизвестный тип продукта! Пожалуйста, введите еще раз")
                };
                ar.RandomInit();
                array[i] = ar;

            }
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("\nВыберите действие над смешанным массивом:");
                Console.WriteLine("1. Вывести список всех элементов смешанного массива");
                Console.WriteLine("2. Вывести количество объектов каждого класса");
                Console.WriteLine("3. Назад\n");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nСписок всех элементов массива\n");
                        foreach (var ar in array)
                        {
                            if (ar is ConfProd confProd)
                            {
                                confProd.Show();
                                Console.WriteLine();
                            }
                            else if (ar is Cakes cake)
                            {
                                cake.Show();
                                Console.WriteLine();
                            }
                            else if (ar is Cookies cookie)
                            {
                                cookie.Show();
                                Console.WriteLine();
                            }
                            else if (ar is ChocolateCookies chocolateCookies)
                            {
                                chocolateCookies.Show();
                                Console.WriteLine();
                            }
                            else if (ar is Mark mark)
                            {
                                mark.Show();
                                Console.WriteLine();
                            }
                        }
                        break;
                    case "2":
                        int confCount = 0;
                        int cakeCount = 0;
                        int cookiesCount = 0;
                        int chocolateCookiesCount = 0;
                        int markCount = 0;
                        foreach (var ar in array)
                        {
                            if (ar is ConfProd) confCount++;
                            if (ar is Cakes) cakeCount++;
                            if (ar is Cookies) cookiesCount++;
                            if (ar is ChocolateCookies) chocolateCookiesCount++;
                            if (ar is Mark) markCount++;
                        }
                        Console.WriteLine("\nКоличество объектов каждого класса:");
                        Console.WriteLine(confCount);
                        Console.WriteLine(cakeCount);
                        Console.WriteLine(cookiesCount);
                        Console.WriteLine(chocolateCookiesCount);
                        Console.WriteLine(markCount);
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 3");
                        break;
                }
            }
        }
        static ConfProd[] CreateArray(int size)
        {
            ConfProd[] products = new ConfProd[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                int productType = rand.Next(0, 3);
                ConfProd product = productType switch
                {
                    0 => new Cakes(),
                    1 => new Cookies(),
                    2 => new ChocolateCookies(),
                    _ => throw new InvalidOperationException("Неизвестный тип продукта. Пожалуйста, введите еще раз")
                };
                product.RandomInit();
                products[i] = product;

            }
            return products;

        }
        static void ShowMainMenu()
        {
            Console.WriteLine("Главное меню\n");
            Console.WriteLine("Выберите опцию");
            Console.WriteLine("1. Создать объект класса");
            Console.WriteLine("2. Создать массив иерархии");
            Console.WriteLine("3. Запросы");
            Console.WriteLine("4. Смешанный массив");
            Console.WriteLine("5. Сортировка");
            Console.WriteLine("6. Клонирование объектов");
            Console.WriteLine("7. Завершить работу\n");
        }
        static void SortIComparable(ConfProd[] products)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Бинарный поиск ");
                Console.WriteLine("2. Назад");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите цену для поиска:");
                        double priceToFind = Convert.ToDouble(Console.ReadLine());
                        int index = Array.BinarySearch(products, new ConfProd("", priceToFind, 1));
                        if (index >= 0)
                        {
                            Console.WriteLine($"\nНайден объект с ценой {priceToFind:F2}:");
                            products[index].Show();

                        }
                        else Console.WriteLine("Объект с такой ценой не найден!");
                        break;
                    case "2":
                        isRun = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 2");
                        break;

                }
            }

        }
        static void SortIComparer(ConfProd[] products)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Бинарный поиск ");
                Console.WriteLine("2. Назад");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название для поиска");
                        string nameToFind = Console.ReadLine();
                        int index = Array.BinarySearch(products, new ConfProd(nameToFind, 0, 1), new ConfProd());
                        if (index >= 0)
                        {
                            Console.WriteLine($"\nНайден объект с названием {nameToFind:F2}:");
                            products[index].Show();

                        }
                        else Console.WriteLine("Объект с такой ценой не найден!");
                        break;
                    case "2":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 2");
                        break;

                }
            }

        }



        static void SortArray(ConfProd[] products)
        {
            bool isRun = true;
            while (isRun)
            {
                Console.WriteLine("\nВыберите сортировку:");
                Console.WriteLine("1. Сортировка по цене");
                Console.WriteLine("2. Сортировка по названию");
                Console.WriteLine("3. назад");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Array.Sort(products);
                        Console.WriteLine("Массив отсортирован по цене!");
                        foreach (ConfProd product in products)
                        {
                            product.Show();
                            Console.WriteLine();

                        }
                        SortIComparable(products);
                        break;
                    case "2":
                        Array.Sort(products, new ConfProd());
                        Console.WriteLine("Массив отсортирован по названию!");
                        foreach (ConfProd product in products)
                        {
                            product.Show();
                            Console.WriteLine();

                        }
                        SortIComparer(products);
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 3");
                        break;


                }
            }
        }
        static void CloneArray()
        {
            ConfProd originalProduct = new ConfProd("Изделие 1", 100.50, 35);
            Console.WriteLine("Оригинальный объект: ");
            originalProduct.Show();
            Console.WriteLine(originalProduct.id.ToString());
            ConfProd cloneProduct = (ConfProd)originalProduct.Clone();
            Console.WriteLine("\nКлон:");
            cloneProduct.Show();
            Console.WriteLine(cloneProduct.id.ToString());
            ConfProd shallowCopiedProduct = (ConfProd)originalProduct.ShallowCopy();
            Console.WriteLine("\nповерхн.скоп объект");
            shallowCopiedProduct.Show();
            Console.WriteLine(shallowCopiedProduct.id.ToString());

            Console.WriteLine("\nПроверка на равенство объектов:");
            Console.WriteLine($"Оригинал и клонированный: {originalProduct.Equals(cloneProduct)}");
            Console.WriteLine($"Оригинал и поверхностно скопированный: {originalProduct.Equals(shallowCopiedProduct)}");
            Console.WriteLine("\nПроверка на равенство ссылок:");
            Console.WriteLine($"Оригинал и клонированный: {ReferenceEquals(originalProduct, cloneProduct)}");
            Console.WriteLine($"Оригинал и поверхностно скопированный: {ReferenceEquals(originalProduct, shallowCopiedProduct)}");
            Console.WriteLine("\nПроверка на равенство ссылочного типа (id):");
            Console.WriteLine($"Оригинал и клонированный: {ReferenceEquals(originalProduct.id, cloneProduct.id)}");
            Console.WriteLine($"Оригинал и поверхностно скопированный: {ReferenceEquals(originalProduct.id, shallowCopiedProduct.id)}");


        }

        static void Main(string[] args)
        {
            ConfProd[] products = CreateArray(20);
            bool isRun = true;
            while (isRun)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateObject();
                        break;
                    case "2":
                        CreateArrayHierarchy(products);
                        break;
                    case "3":
                        RequestsToArray(products);
                        break;
                    case "4":
                        CreateMixedArray();
                        break;
                    case "5":
                        SortArray(CreateArray(5));
                        break;
                    case "6":
                        CloneArray();
                        break;
                    case "7":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка, выбран неверный номер! Пожалуйста, введите еще раз число от 1 до 7");
                        break;

                }
            }
        }
    }
}

