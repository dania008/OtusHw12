using System.Collections.Concurrent;
using System.IO;

namespace OtusHw12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Customer customer = new Customer();

            shop.Items.Add(new Item(1, "Товар 1"));
            shop.Items.Add(new Item(2, "Товар 2"));
            shop.Items.Add(new Item(3, "Товар 3"));

            shop.Items.CollectionChanged += customer.OnItemChanged;

            while (true)
            {
                Console.WriteLine("Нажмите A, чтобы добавить новый товар");
                Console.WriteLine("Нажмите D, чтобы удалить товар");
                Console.WriteLine("Нажмите X, чтобы выйти из программы");

                var key = Console.ReadKey().Key;
                Console.WriteLine();

                if (key == ConsoleKey.A)
                {
                    int id = shop.Items.Any() ? shop.Items.Max(x => x.Id) + 1 : 1;
                    string name = $"Товар от {DateTime.Now}";
                    shop.AddItem(new Item(id, name));
                }
                else if (key == ConsoleKey.D)
                {
                    Console.WriteLine("Введите id товара, который нужно удалить:");
                    int id = int.Parse(Console.ReadLine());
                    shop.RemoveItem(id);
                }
                else if (key == ConsoleKey.X)
                {
                    break;
                }
            }
            var library = new ConcurrentDictionary<string, int>();
            var cancelationTokenSource = new CancellationTokenSource();

            var percentageCalculationTask = new Thread(() =>
            {
                while (!cancelationTokenSource.IsCancellationRequested)
                {
                    foreach (var book in library)
                    {
                        var updatedPercentage = book.Value + 1;
                        if (updatedPercentage >= 100)
                        {
                            library.TryRemove(book.Key, out _);
                        }
                        else
                        {
                            library.TryUpdate(book.Key, updatedPercentage, book.Value);
                        }
                    }
                    Thread.Sleep(1000);
                }
            });

            percentageCalculationTask.Start();

            while (true)
            {
                Console.WriteLine("1 - добавить книгу; 2 - вывести список непрочитанного; 3 - выйти");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Введите название книги:");
                    var bookTitle = Console.ReadLine();

                    if (library.ContainsKey(bookTitle))
                    {
                        Console.WriteLine("Книга уже есть в библиотеке");
                    }
                    else
                    {
                        library.TryAdd(bookTitle, 0);
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Список непрочитанных книг:");
                    foreach (var book in library)
                    {
                        Console.WriteLine($"{book.Key} - {book.Value}%");
                    }
                }
                else if (input == "3")
                {
                    cancelationTokenSource.Cancel();
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            List<string> poem = new List<string>();

            Part1 part1 = new Part1();
            Part2 part2 = new Part2();
            Part3 part3 = new Part3();
            Part4 part4 = new Part4();
            Part5 part5 = new Part5();
            Part6 part6 = new Part6();
            Part7 part7 = new Part7();
            Part8 part8 = new Part8();
            Part9 part9 = new Part9();

            part1.AddPart(poem);
            part2.AddPart(part1.Poem);
            part3.AddPart(part2.Poem);
            part4.AddPart(part3.Poem);
            part5.AddPart(part4.Poem);
            part6.AddPart(part5.Poem);
            part7.AddPart(part6.Poem);
            part8.AddPart(part7.Poem);
            part9.AddPart(part8.Poem);

            Console.WriteLine("Part 1:");
            foreach (string line in part1.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 2:");
            foreach (string line in part2.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 3:");
            foreach (string line in part3.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 4:");
            foreach (string line in part4.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 5:");
            foreach (string line in part5.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 6:");
            foreach (string line in part6.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 7:");
            foreach (string line in part7.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 8:");
            foreach (string line in part8.Poem)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nPart 9:");
            foreach (string line in part9.Poem)
            {
                Console.WriteLine(line);
            }
        }

        class Part1
        {
            public List<string> Poem { get; private set; }

            public Part1()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part1 = new List<string>()
        {
            "Вот дом,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part1);
            }
        }

        class Part2
        {
            public List<string> Poem { get; private set; }

            public Part2()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part2 = new List<string>()
        {
            "А это пшеница,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.",
            "Которая мыла чистенько моющею коркой кастрюлю,",
            "Которая стояла на светлице под золотым орлом.\n"
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part2);
            }
        }

        class Part3
        {
            public List<string> Poem { get; private set; }

            public Part3()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part3 = new List<string>()
        {
            "А это веселая птица-синица,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part3);
            }
        }

        class Part4
        {
            public List<string> Poem { get; private set; }

            public Part4()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part4 = new List<string>()
        {
            "Вот кот,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part4);
            }
        }

        class Part5
        {
            public List<string> Poem { get; private set; }

            public Part5()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part5 = new List<string>()
        {
            "Вот пес без хвоста,",
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part5);
            }
        }

        class Part6
        {
            public List<string> Poem { get; private set; }

            public Part6()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part6 = new List<string>()
        {
            "А это корова безрогая,",
            "Лягнувшая старого пса без хвоста,",
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part6);
            }
        }

        class Part7
        {
            public List<string> Poem { get; private set; }

            public Part7()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part7 = new List<string>()
        {
            "А это старушка, седая и строгая,",
            "Которая доит корову безрогую,",
            "Лягнувшую старого пса без хвоста,",
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part7);
            }
        }

        class Part8
        {
            public List<string> Poem { get; private set; }

            public Part8()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part8 = new List<string>()
        {
            "А это ленивый и толстый пастух,",
            "Который бранится с коровницей строгою,",
            "Которая доит корову безрогую,",
            "Лягнувшую старого пса без хвоста,",
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.\n",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part8);
            }
        }

        class Part9
        {
            public List<string> Poem { get; private set; }

            public Part9()
            {
                Poem = new List<string>();
            }

            public void AddPart(List<string> poem)
            {
                List<string> part9 = new List<string>()
        {
            "Вот два петуха,",
            "Которые будят того пастуха,",
            "Который бранится с коровницей строгою,",
            "Которая доит корову безрогую,",
            "Лягнувшую старого пса без хвоста,",
            "Который за шиворот треплет кота,",
            "Который пугает и ловит синицу,",
            "Которая часто ворует пшеницу,",
            "Которая в темном чулане хранится",
            "В доме,",
            "Который построил Джек.",
        };
                Poem = new List<string>(poem);
                Poem.AddRange(part9);
            }
        }
    }

}