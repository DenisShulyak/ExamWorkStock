using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace ExamWork
{
    class Program
    {

      /*  private void BoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == 13)
            {
                

            }
        }*/

        static void Main(string[] args)
        {
                using (StreamWriter stream = new StreamWriter("Stock.txt"))
                {
                    stream.Write("1)Телефон");
                    stream.Write(" 2)Пылесос");
                    stream.Write(" 3)Утюг");
                    stream.Write(" 4)Шкаф");
                }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Склад");

                Console.WriteLine("1)Просмотр товаров на складе");
                Console.WriteLine("2)Добавление товаров");
                Console.WriteLine("3)Сохранение данных в xml");
                Console.WriteLine("Выберите действие: ");

                try
                {
                int act = int.Parse(Console.ReadLine());
                    if (act == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Товары на складе: ");
                        using (StreamReader stream = new StreamReader("Stock.txt"))
                        {

                            string str = stream.ReadLine();
                            var data = str.Split(' ').ToList();

                            for (int i = 0; i < data.Count; i++)
                            {
                                Console.WriteLine(data[i]);
                            }

                        }
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();

                    }
                    else if (act == 2)
                    {
                        string nameProduct;
                        int countData;
                        while (true)
                        {
                            Console.Clear();

                            Console.WriteLine("Добавление товара на склад");
                            Console.WriteLine("Введите название товара: ");
                            nameProduct = Console.ReadLine();
                            using (StreamReader stream = new StreamReader("Stock.txt"))
                            {
                                string str = stream.ReadLine();
                                var data = str.Split(' ').ToList();

                                for (int i = 0; i < data.Count; i++)
                                {
                                    if (data[i] == (" " + (i + 1) + ")" + nameProduct) || data[i] == ((i + 1) + ")" + nameProduct))
                                    {
                                        Console.WriteLine("Такой товар уже есть!");
                                        Console.ReadLine();
                                        continue;
                                    }

                                }
                                countData = data.Count;
                                break;

                            }
                        }
                        using (StreamWriter streamWriter = File.AppendText("Stock.txt"))
                        {
                            streamWriter.Write(" " + (countData + 1) + ")" + nameProduct);
                        }
                    }
                    else if (act == 3)
                    {

                        using (StreamReader streamReader = new StreamReader("Stock.txt"))
                        {

                            string str = streamReader.ReadLine();
                            var data = str.Split(' ').ToList();


                            //Stock stock = new Stock();


                            var listStock = new List<Stock>();


                            for (int i = 0; i < data.Count; i++)
                            {
                                Stock stock = new Stock();
                                listStock.Add(stock);
                                listStock[i].productStock = data[i];
                            }

                            for (int i = 0; i < data.Count; i++
                                )
                            {
                                var serializer = new XmlSerializer(typeof(Stock));
                                if (i == 0)
                                {
                                    using (var stream = File.Create("dataStock.xml"))
                                    {
                                        serializer.Serialize(stream, listStock[i]);
                                    }
                                }
                                else
                                {
                                    using (var stream = File.Open("dataStock.xml", FileMode.Append))
                                    {
                                        serializer.Serialize(stream, listStock[i]);
                                    }
                                }
                            }
                           

                        }
                    }
                }
                catch { Console.WriteLine("Такого дейсвия нет!"); }
                Console.ReadLine();

            }

                Console.ReadLine();
        }
    }
}
