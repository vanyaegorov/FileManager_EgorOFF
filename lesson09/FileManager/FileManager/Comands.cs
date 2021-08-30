using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    class Comands
    {

        public static void Window()
        {
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            Console.ForegroundColor = ConsoleColor.Green;
            Walls walls = new Walls(100, 30);
            walls.Draw();
        }

        public static void Get_Command()
        {
            int comand = 0;
            Window();
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Для просмотра директорий нажмите 1");
            Console.WriteLine("Для создания директорий нажмите 2");
            Console.WriteLine("Для удаления директорий нажмите 3");
            Console.WriteLine("Для копирования директорий нажмите 4");
            Console.WriteLine("Для получения информации о директории нажмите 5");
            Console.SetCursorPosition(50, 21);
            Console.WriteLine("Для получения информации о файле нажмите 6");
            Console.SetCursorPosition(50, 22);
            Console.WriteLine("Для чтения файла .txt нажмите 7");
            Console.SetCursorPosition(50, 23);
            Console.WriteLine("Для создания файла нажмите 8");
            Console.SetCursorPosition(50, 24);
            Console.WriteLine("Для удаления файла нажмите 9");
            Console.SetCursorPosition(50, 25);
            Console.WriteLine("Для копирования файла нажмите 10");


            Console.SetCursorPosition(0, 27);
            string input = Console.ReadLine();
            bool res = int.TryParse(input, out comand);
            if (res == true)
            {
                comand = Convert.ToInt32(input);
            }
            else
            {
                ErorComand();
            }
            if (comand < 11 && comand <= 0)
            {
                ErorComand();
            }
            if (comand == 1)
            {
                ShowDir();
            }
            try
            {
                if (comand == 2)
                {
                    CreateDir();

                }
            }
            catch (Exception ex)
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введена неверная команда");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();

            }

            if (comand == 3)
            {
                DeleteDir();
            }

            if (comand == 4)
            {
                MuvDir();
            }

            if (comand == 5)
            {

                GetInfo();
            }
            if (comand == 6)
            {
                GetInfoFile();
            }
            if (comand == 7)
            {
                OpenFile();
            }
            if (comand == 8)
            {
                CreateFile();
            }
            if (comand == 9)
            {
                DelFile();
            }
            if (comand == 10)
            {
                CopyFile();
            }
        }

            public static void NewWindow()
            {
                Console.Clear();
                Comands.Window();
                Console.SetCursorPosition(0, 0);
            }

            public static void ErorComand()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введена неверная команда,для продолжения нажмите любую клавишу");
                Console.ReadKey();
                NewWindow();
                Get_Command();
            }

            public static void ShowDir()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите путь к директории:");
                Console.SetCursorPosition(0, 27);
                GetDir();
            }
            public static void CreateDir()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите путь к дирректории:");
                Console.SetCursorPosition(0, 27);
                string path = Console.ReadLine();

                NewWindow();

                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"Введите путь к дирректории: {path}");
                Console.WriteLine("Введите название директории:");
                Console.SetCursorPosition(0, 27);
                string subpath = Console.ReadLine();
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory(subpath);
                NewWindow();

                Console.SetCursorPosition(0, 23);
                Console.WriteLine($"Директория {path}\\{subpath} создана");
                Console.SetCursorPosition(0, 24);
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                NewWindow();
            }

            public static void DeleteDir()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите директорию которую необходимо удалить");
                Console.SetCursorPosition(0, 27);
                string dirName = Console.ReadLine();


                try
                {

                    DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                    dirInfo.Delete(true);
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"Директория {dirInfo} удаленa");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();
                }
                catch (Exception ex)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введена неверная команда");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Для продолжения нажмите любую клавишу");

                    Console.ReadKey();
                    NewWindow();

                }
            }

            public static void MuvDir()
            {
                try
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введите директорию которую необходимо скопировать");
                    Console.SetCursorPosition(0, 27);
                    string oldPath = Console.ReadLine();

                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"Введите директорию которую необходимо скопировать: {oldPath}"); ;
                    Console.WriteLine("Введите новую директорию в которую совершится копирование");
                    Console.SetCursorPosition(0, 27);
                    string newPath = Console.ReadLine();
                    DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
                    if (dirInfo.Exists && Directory.Exists(newPath) == false)
                    {
                        dirInfo.MoveTo(newPath);
                        Console.WriteLine($"Директория {oldPath} скопирована в {newPath}");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        NewWindow();
                    }
                }
                catch (Exception ex)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введена неверная команда");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Для продолжения нажмите любую клавишу");

                    Console.ReadKey();
                    NewWindow();

                }
            }

            public static void GetDir()
            {
                List<String> date = new List<String>();
                List<String> date2 = new List<String>();
                string dirName = Console.ReadLine();
                Console.SetCursorPosition(0, 0);
                if (Directory.Exists(dirName))
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        date.Add(new String() { Str = dirs[i] });
                        string[] dirs_next = Directory.GetDirectories(dirs[i]);
                        for (int j = 0; j < dirs_next.Length; j++)
                        {
                            date.Add(new String() { Str = dirs_next[j] });
                            string[] files_next = Directory.GetFiles(dirs[i]);
                            foreach (string p in files_next)
                                date.Add(new String() { Str = p });
                        }
                    }
                    string[] files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                        date.Add(new String() { Str = s });
                }
                else
                {
                    Comands.NewWindow();
                    Console.WriteLine($"Директория {dirName} не найдена.");
                }
                int temp = 0;
                for (int i = 0; i < date.Count; i++)
                {
                    Console.SetCursorPosition(0, 0);
                    date2.Add(new String() { Str = date[i].Str });
                    Console.WriteLine(date[i].Str);
                    temp++;
                    Comands.NewWindow();
                    if (temp == 20)
                    {

                        do
                        {

                            Console.SetCursorPosition(0, 0);
                            foreach (String p in date2)
                                Console.WriteLine(p.Str);
                            Console.SetCursorPosition(0, 22);
                            Console.WriteLine("Для просмотра следующей страницы нажмите стрелку вправо");
                            Console.SetCursorPosition(0, 27);
                        }
                        while (Console.ReadKey().Key != ConsoleKey.RightArrow);
                        {
                            temp = 0;
                            date2.Clear();
                        }

                    }

                    else
                    {
                        Console.SetCursorPosition(0, 0);
                        foreach (String p in date2)
                            Console.WriteLine(p.Str);
                        Console.SetCursorPosition(0, 27);
                    }

                }

            }

            public static void GetInfo()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите директорию информация о которой нужна");
                Console.SetCursorPosition(0, 27);
                string dirName = Console.ReadLine();
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                if (dirInfo.Exists)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"Название каталога: {dirInfo.Name}");
                    Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
                    Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
                    Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();
                }
                else
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Директория не найдена");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();


                }

            }

            public static void GetInfoFile()
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите директорию файла информация о которой нужна");
                Console.SetCursorPosition(0, 27);
                string path = Console.ReadLine();
                FileInfo fileInf = new FileInfo(path);
                if (fileInf.Exists)

                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Имя файла: {0}", fileInf.Name);
                    Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                    Console.WriteLine("Размер: {0}", fileInf.Length);
                    Console.WriteLine("Расширение: {0}", fileInf.Extension);
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();

                }
                else
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"Файл: {path} не обнаружен");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();
                }
            }

            public static void OpenFile()
            {
                try
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введите адрес файла который нужно открыть");
                    Console.SetCursorPosition(0, 27);
                    string path = Console.ReadLine();
                    using (FileStream fstream = File.OpenRead($"{path}"))
                    {
                        // преобразуем строку в байты
                        byte[] array = new byte[fstream.Length];
                        // считываем данные
                        fstream.Read(array, 0, array.Length);
                        // декодируем байты в строку
                        string textFromFile = System.Text.Encoding.Default.GetString(array);
                        NewWindow();
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine($"Текст из файла: {textFromFile}");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        NewWindow();
                    }
                }

                catch (Exception)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine($"Файл не обнаружен,уточните данные");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();

                }



            }
            public static void CreateFile()
            {
                try
                {

                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введите путь и название файла");
                    Console.SetCursorPosition(0, 27);
                    string path = Console.ReadLine();
                    FileInfo fileInf = new FileInfo(path);
                    DirectoryInfo dirInfo = new DirectoryInfo(path);



                    if (!fileInf.Exists)
                    {
                        NewWindow();
                        fileInf.Create();
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine($"Файл {path} создан");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        NewWindow();

                    }
                    else if (fileInf.Exists || !dirInfo.Exists)
                    {
                        NewWindow();
                        Console.SetCursorPosition(0, 21);
                        Console.WriteLine("Файл уже существует,либо кожанный издевается");
                        Console.WriteLine("Для продолжения нажмите любую клавишу");
                        Console.ReadKey();
                        NewWindow();
                    }
                }
                catch (Exception)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Неверные данные");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();

                }

            }

            public static void DelFile()
            {
            NewWindow();
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Введите путь и название файла");
            Console.SetCursorPosition(0, 27);
            string path = Console.ReadLine();
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {

                fileInf.Delete();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"Файл {path} удален") ;
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                NewWindow();
            }
            else
            {
                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"Файл {path} не найден");
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                NewWindow();

            }

            }

        public static void CopyFile()
        {
            try
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введите файл который необходимо скопировать");
                Console.SetCursorPosition(0, 27);
                string path = Console.ReadLine();

                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine($"Введите файл который необходимо скопировать: {path}"); ;
                Console.WriteLine("Введите новый адрес файла");
                Console.SetCursorPosition(0, 27);
                string newPath = Console.ReadLine();
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    fileInfo.CopyTo(newPath, true);
                    Console.WriteLine($"Файл {path} скопирован в {newPath}");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();
                }
                else 
                {
                    NewWindow();
                    Console.SetCursorPosition(0, 21);
                    Console.WriteLine("Введены неверные данные");
                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.ReadKey();
                    NewWindow();
                }
            }
            catch (Exception ex)
            {
                NewWindow();
                Console.SetCursorPosition(0, 21);
                Console.WriteLine("Введена неверная команда");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Для продолжения нажмите любую клавишу");

                Console.ReadKey();
                NewWindow();

            }
        }



        }
    }

