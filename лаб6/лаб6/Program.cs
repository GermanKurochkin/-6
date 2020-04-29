using System;

namespace лаб6
{
    class Program
    {
        static char[] DeleteChar(char[] mas, int numberDeleted)
        {
            char[] masNew = new char[mas.Length - 1];
            int n = 0;
            for (int i=0;i<mas.Length;i++)
                if(i!= numberDeleted)
                {
                    masNew[n] = mas[i];
                    n++;
                }
            return masNew;
        }
        static char[] Delete(char[] masStroki)
        {
            bool ok = true;
            int m = masStroki.Length - 1;
            while (masStroki[m] == ' ')
            {
                DeleteChar(masStroki, m);
                m--;
            }
            for (int i = 0; i < masStroki.Length - 1; i++)
            {

                if (masStroki[i] == ' ' || masStroki[i] == '.' || masStroki[i] == '?' || masStroki[i] == '!' || masStroki[i] == ',' || masStroki[i] == ':' || masStroki[i] == ';')
                    if (masStroki[i + 1] == '.' || masStroki[i + 1] == '?' || masStroki[i + 1] == '!' || masStroki[i + 1] == ',' || masStroki[i + 1] == ':' || masStroki[i + 1] == ';')
                    {
                        masStroki = DeleteChar(masStroki, i + 1);
                        i--;
                        ok = false;
                    }

            }
            if (!ok)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Удалены лишние знаки");
                Console.ResetColor();
            }

            return masStroki;
        }
        static string Delete(string stroka)
        {

            int first = 0, last = 0;
            char[] masStroki = stroka.ToCharArray();
            stroka = "";           

            try
            {
                masStroki = Delete(masStroki);
                for (int i = 0; i < masStroki.Length; i++)
                {

                    if (masStroki[i] == ' ' || masStroki[i] == '.' || masStroki[i] == '?' || masStroki[i] == '!' || masStroki[i] == ',' || masStroki[i] == ':' || masStroki[i] == ';')
                    {
                                last = i - 1;
                        if (masStroki[first] != masStroki[last])
                        {
                            for (int j = first; j < last + 2; j++)
                                stroka += masStroki[j];
                            if (masStroki[i] != ' ' && i != masStroki.Length - 1)
                            {
                                stroka += masStroki[i + 1];
                                i++;
                            }
                        }
                        else
                        {
                            stroka += masStroki[i];
                            if (i != masStroki.Length - 1 && masStroki[i + 1] == ' ')
                            {
                                stroka += masStroki[i + 1];
                                i++;
                            }
                        }
                        if (i < masStroki.Length - 1)
                        {
                                    if (masStroki[i] != ' ' && i != masStroki.Length - 2) first = i + 2;
                                    else first = i + 1;
                        }
                    }
                    

                }
              
                if (last != masStroki.Length - 2)
                {
                    last = masStroki.Length - 1;
                    if (masStroki[first] != masStroki[last])
                    {
                        for (int j = first; j < last+1 ; j++)
                            stroka += masStroki[j];
                     
                    }
                }
          
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введена неверная строка");
                Console.ResetColor();
            }

            
            return stroka;
        }
        static int  NeedForDelete(int[][] jagMas)
        {

            int zeroNumber, numberDeleted = 0;

            for (int i = 0; i < jagMas.Length; i++)
            {
                zeroNumber = 0;
                for (int j = 0; j < jagMas[i].Length; j++)
                    if (jagMas[i][j] == 0) zeroNumber++;
                if (zeroNumber > 1) numberDeleted++;
            }

            return numberDeleted;
        }
        static int[][] Delete(int[][] jagMas)
        {
            int zeroNumber, numberDeleted=0;

            numberDeleted = NeedForDelete(jagMas);
            int n = 0;
            int[][] jagMasNew = new int[jagMas.Length-numberDeleted][];
         
            for (int i = 0; i < jagMas.Length; i++)
            {
                zeroNumber = 0;
                for (int j = 0; j < jagMas[i].Length; j++)
                    if (jagMas[i][j] == 0) zeroNumber++;
                if (zeroNumber < 2)
                {
                    jagMasNew[n] = new int[jagMas[i].Length];
                    Array.Copy( jagMas[i], jagMasNew[n], jagMas[i].Length);
                    n++;
              
                }
            }
            if (n == 0) jagMasNew = null;
            if (n<jagMas.Length)jagMas = jagMasNew;
            return jagMas;
        }
        static int InputSize(string output)
        {
            int size;
            bool ok;
            string input;
            do
            {
                Console.WriteLine(output);
                input = Console.ReadLine();
                ok = int.TryParse(input, out size);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (size < 1 || size > 20) Console.WriteLine("Некорректный ввод.Введите число от 1 до 20");
            } while (!ok || size < 1 || size > 20);
            return size;
        }
        static int InputElement(string output)
        {
            int element;
            bool ok;
            string input;
            do
            {
                Console.WriteLine(output);
                input = Console.ReadLine();
                ok = int.TryParse(input, out element);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (element < 0 || element > 100) Console.WriteLine("Некорректный ввод.Введите число от 0 до 100");
            } while (!ok || element < 0 || element > 100);
            return element;
        }
        static void WriteString(string stroka)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Полученная строка:");
            Console.WriteLine(stroka);
            Console.ResetColor();
        }
        static void WriteMas(int[][] jagMas)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Полученный массив:");
            for (int i = 0; i < jagMas.Length; i++)
            {
                for (int j = 0; j < jagMas[i].Length; j++)
                    Console.Write($"{jagMas[i][j]} ");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        static void MakeMasWrite(int sizeMas, ref int[][] mas)
        {
            mas = new int[sizeMas][];
            int element, sizeJag;
            for (int i = 0; i < sizeMas; i++)
            {
                sizeJag = InputSize($"Введите количество элементов одномерного массива №{i + 1} в рваном ");
                mas[i] = new int[sizeJag];
                for (int j = 0; j < sizeJag; j++)
                {
                    element = InputElement($"Bведите элемент №{j + 1} рваного массива строки №{i + 1}");
                    mas[i][j] = element;
                }
            }
        }
        static string MakeStringRandom()
        {
            const int size = 7;
            Random rand = new Random();
            string[] masStr = new string[size]
            { 
                "Простой шалаш::: Звонкий гонг! Где окно?",
                "Карл у Клары украл кораллы, Клара у Карла украла кларнет",
                "Пакет под попкорн; Свиристель свиристит свирелью!",
                "Осип   охрип,,,, Архип осип...", 
                "потоп, дрозд, довод и акула",
                "шалаш",
                "КРИК:::: АБВ;;;   слеватрипробела!???!!  "
            };
          
            return masStr[rand.Next(size)];
        }
        static void MakeMasRandom(int sizeMas, ref int[][] mas)
        {
            int sizeJag;
            mas = new int[sizeMas][];
            Random rand = new Random();
            for (int i = 0; i < sizeMas; i++)
            {
                sizeJag = InputSize($"Введите количество элементов одномерного массива №{i + 1} в рваном ");
                mas[i] = new int[sizeJag];
                for (int j = 0; j < sizeJag; j++)
                    mas[i][j] = rand.Next(10);
            }
        }
        static bool RandomOrNot(string first= "1.Использовать рандомные числа от 0 до 10", string second= "2.Ввести числа самостоятельно")
        {
            int randomOrNot;
            string input;
            bool ok, random;
            do
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
                input = Console.ReadLine();
                ok = int.TryParse(input, out randomOrNot);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (randomOrNot < 1 || randomOrNot > 2) Console.WriteLine("Некорректный ввод.Введите число из меню(1 или 2)");
            } while (!ok || randomOrNot < 1 || randomOrNot > 2);
            if (randomOrNot == 1) random = true;
            else random = false;
            return random;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Программа для работы с массивами");
            Console.ResetColor();
            int menu = 10, sizeMas;
            string input, stroka,deletedStroka;
            bool ok, random;
            int[][] jagMas = new int[1][];
            int[][] deletedJagMas = new int[1][];
            while (menu != 0)
            {

                Console.WriteLine("1.Работа со строкой(Удаление слов, начинающихся и заканчивающихся на одинаковые символы)");
                Console.WriteLine("2.Работа с рваным массивом(Удаление строк, в которых есть не менее двух нулей)");
                Console.WriteLine("0.Выход");
                do
                {
                    input = Console.ReadLine();
                    ok = int.TryParse(input, out menu);
                    if (!ok) Console.WriteLine("Некорректный ввод");
                    else if (menu < 0 || menu > 3) Console.WriteLine("Некорректный ввод.Выберите вариант от 0 до 2 из меню");
                } while (!ok || menu < 0 || menu > 3);
                if (menu == 0) break;
                else
                {
                    switch (menu)
                    {
                        case 1:
                            random = RandomOrNot("1.Ввести случайную строку","2.Ввести строку самостоятельно");
                            if (random)
                            {
                                 stroka = MakeStringRandom();
                                WriteString(stroka);
                            }
                            else
                            {
                                Console.WriteLine("Введите строку");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                stroka = Console.ReadLine();
                                Console.ResetColor();
                            }
                            Console.WriteLine("Удаление слов, начинающихся и заканчивающихся на одинаковые символы");
                            deletedStroka = Delete(stroka);
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            if (deletedStroka==stroka) Console.WriteLine("Нечего удалять");
                            else if(deletedStroka=="") Console.WriteLine("Удалена вся строка");
                            else WriteString(deletedStroka);
                            Console.ResetColor();
                            break;
                        case 2:
                            sizeMas = InputSize("Введите количество строк двумерного массива");
                            random = RandomOrNot();
                                if (random)
                                {
                                    MakeMasRandom(sizeMas, ref jagMas);
                                }
                                else
                                {
                                    MakeMasWrite(sizeMas, ref jagMas);
                                }
                            WriteMas(jagMas);
                            Console.WriteLine("Удаление строк, в которых есть не менее двух нулей");
                            deletedJagMas = Delete(jagMas);                        
                            if (deletedJagMas == null) Console.WriteLine("Массив пуст");
                            else if (Array.Equals(deletedJagMas, jagMas)) Console.WriteLine("Нечего удалять");
                            else WriteMas(deletedJagMas);
                           
                            break;
                        
                    }


                }

            }
        }
    }
}
