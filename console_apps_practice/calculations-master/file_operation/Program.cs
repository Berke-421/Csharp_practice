using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example7
{
    class Program
    {
        // Oluşturulma tarihi/Created At: 21 Ekim 2025 / 21 October 2025
        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            byte choose;
            bool menuActive = true;

            Console.WriteLine(@"Files in D:\aad: ");
            fileHandler.List();

            Console.WriteLine();
            Console.WriteLine("Select operation type: ");
            Console.WriteLine("1: Operate on existing file || 2: Create new file");

            while (true)
            {
                choose = Convert.ToByte(Console.ReadLine());

                if (choose == 1) { fileHandler.Select(); }

                else if (choose == 2) { fileHandler.Create(); }

                else
                {
                    Console.WriteLine("Error: Invalid operation choice");
                    continue;
                }

                Console.WriteLine("1: Write to file");
                Console.WriteLine("2: Delete file");
                Console.WriteLine("3: View file");
                Console.WriteLine("4: Write to file (details option currently calls Write)");
                Console.WriteLine("5: Exit/cancel");

                while (menuActive)
                {
                    Console.Write("Enter new operation: ");
                    choose = Convert.ToByte(Console.ReadLine());

                    switch (choose)
                    {
                        case 1:
                            fileHandler.Write();
                            break;

                        case 2:
                            fileHandler.Delete();
                            break;

                        case 3:
                            fileHandler.Read();
                            break;

                        case 4:
                            fileHandler.Write();
                            break;

                        case 5:
                            menuActive = false;
                            break;

                        default:
                            Console.WriteLine("Error: No choice entered");
                            break;
                    }
                }

                ConsoleKeyInfo xc = Console.ReadKey(true);

                Console.WriteLine("Press 'x' to terminate the program");
                Console.WriteLine("Press 'c' to perform another operation");

                if (xc.Key == ConsoleKey.X) break;
                if (xc.Key == ConsoleKey.C) continue;
            }
        }
    }

    class FileHandler
    {
        public string FilePath { get; private set; }

        public string? fileName { get; private set; }
        public string? newFileName { get; private set; }

        public DirectoryInfo entries { get; private set; } // to list files inside folder
        private string? folderPath; // assigned from constructor parameter

        public FileInfo targetFile { get; private set; }

        private bool isSelected;
        public List<string?> buffer { get; private set; }

        private string? line;

        public FileHandler(string folderPathParam = @"D:\aad")
        {
            folderPath = folderPathParam;
            entries = new DirectoryInfo(folderPath);
            buffer = new List<string?>();

            isSelected = true;

            FilePath = @"D:\asd\bos.txt";
        }

        public void Write()
        {
            buffer.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                line = Console.ReadLine();

                if (line == "q" || line == "x") break;

                else buffer.Add(line);

            }

            using (StreamWriter sw = targetFile.AppendText())
            {
                if (targetFile.Exists)
                {
                    foreach (string? bb in buffer) { sw.WriteLine(bb); }
                }

                else
                {
                    Console.WriteLine("File not found");
                }

            }

            Console.ResetColor();
        }

        public void Select()
        {
            Console.WriteLine("Select the file: ");

            while (true)
            {
                fileName = Console.ReadLine();

                if (string.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("Error: File name cannot be empty");
                    continue;
                }

                else
                {
                    FilePath = $"D:\\aad\\{fileName}.txt";
                    targetFile = new FileInfo(FilePath);
                    isSelected = false;
                }

                break;
            }
        }

        public void Read()
        {
            if (isSelected)
            {
                Console.WriteLine("No file selected");
            }

            else
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string? li;
                    while ((li = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(li);
                    }
                }
            }
        }

        public void GetFileInfo()
        {
            if (isSelected)
            {
                Console.WriteLine("No file selected");
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n--- File Information ---\n");

                Console.WriteLine($"Full Path : {targetFile.FullName}");
                Console.WriteLine($"Creation Time : {targetFile.CreationTime}");
                Console.WriteLine($"File Size (bytes) : {targetFile.Length}");
                Console.WriteLine($"Containing Folder : {targetFile.DirectoryName}");

                Console.ResetColor();
            }
        }

        public void Create()
        {
            Console.WriteLine("Enter the name of the file to create: ");
            while (true)
            {
                newFileName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newFileName))
                {
                    Console.WriteLine("New file name cannot be empty");
                    continue;
                }

                else break;
            }

            targetFile = new FileInfo($"D:\\aad\\{newFileName}.txt");

            using (FileStream fs = targetFile.Create())
            {

            }
        }

        public void List()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(folderPath);

            Console.WriteLine();

            foreach (var fi in entries.GetFiles())
            {
                Console.WriteLine(fi.Name);
            }

            Console.ResetColor();
        }

        public void Delete()
        {

            if (isSelected)
            {
                Console.WriteLine("No file selected");
                return;
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine($"File to delete: {targetFile.FullName}");
            Console.Write("Do you confirm? (Y/N): ");

            string? answer = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("Confirmation not received. Operation canceled.");
                Console.ResetColor();
                return;
            }

            answer = answer.Trim().ToLowerInvariant();
            if (answer == "y" || answer == "yes")
            {
                try
                {
                    if (targetFile.Exists)
                    {
                        targetFile.Delete();
                        Console.WriteLine("File deleted successfully.");
                        // Selected file no longer exists; set selection flag back to true
                        isSelected = true;
                        FilePath = @"D:\asd\bos.txt";
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while deleting: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Operation canceled.");
            }

            Console.ResetColor();
        }
    }
}