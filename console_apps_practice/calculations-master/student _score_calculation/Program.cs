using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GRADES_APP
{
    // Oluşturulma tarihi/Created At: 27 Haziran 2024 / 27 June 2024
    public class SpecialCharacterException : Exception
    {
        public SpecialCharacterException(string message) : base(message)
        {

        }
    }

    public class NameEmptyException : Exception
    {
        public NameEmptyException(string message) : base(message)
        {

        }
    }

    public class GradeException : Exception
    {
        public GradeException(string message) : base(message)
        {

        }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }

    public class GenericException : Exception
    {
        public GenericException(string message) : base(message)
        {

        }
    }
    class Program
    {


        static void Main()
        {
            List<string> students = new List<string>();
            Console.WriteLine("Enter student names:");
            while (true)
            {
                try
                {
                    string? student = Console.ReadLine();
                    bool hasSpecialChar = false;

                    if (string.IsNullOrEmpty(student)) throw new NameEmptyException("no name entered");
                    foreach (char ch in student) if (!char.IsLetter(ch)) hasSpecialChar = true;
                    if (hasSpecialChar) throw new SpecialCharacterException("Special characters and digits are not allowed");
                    if (student == "bitir" || student == "00" || student == "yeter" || student == "kapat" || student == "end") break;
                    students.Add(student);
                }

                catch (SpecialCharacterException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    continue;
                }

                catch (NameEmptyException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    continue;
                }

                catch (IOException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                    continue;
                }

                catch (OutOfMemoryException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Out of memory: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }
                catch (Exception ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Unexpected error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }
            }


            List<int> grades = new List<int>();
            Console.WriteLine("Enter students' grades:");
            for (int i = 0; i < students.Count;)
            {
                try
                {
                    Console.Write($"{students[i]} student's grade:");
                    byte grade = Convert.ToByte(Console.ReadLine());
                    if (grade < 0 || grade > 100) throw new GradeException("Invalid grade");
                    grades.Add(grade);
                    i++;
                }

                catch (GradeException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }

                catch (FormatException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }

                catch (OverflowException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }

                catch (ArgumentNullException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }
            }

            int excellentCount = 0, goodCount = 0, averageCount = 0, passCount = 0, failCount = 0;

            foreach (int score in grades)
            {
                if (score >= 85) excellentCount += 1;
                else if (score > 70 && score < 85) goodCount += 1;
                else if (score > 55 && score < 70) averageCount += 1;
                else if (score > 45 && score < 55) passCount += 1;
                else if (score >= 0 && score < 45) failCount += 1;
            }

            for (int j = 0; j < grades.Count; j++)
            {
                if (grades[j] >= 85)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{students[j]}, EXCELLENT");
                    Console.ResetColor();
                }

                if (grades[j] > 55 && grades[j] < 70)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{students[j]}, GOOD");
                    Console.ResetColor();
                }

                if (grades[j] > 55 && grades[j] < 70)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{students[j]}, AVERAGE");
                    Console.ResetColor();
                }

                if (grades[j] > 45 && grades[j] < 55)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{students[j]}, PASS");
                    Console.ResetColor();
                }

                if (grades[j] >= 0 && grades[j] < 45)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{students[j]}, FAIL");
                    Console.ResetColor();
                }
            }

            Console.WriteLine(new string('-', 20));

            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"EXCELLENT:{excellentCount}");
                Console.ResetColor();
            }

            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"GOOD:{goodCount}");
                Console.ResetColor();
            }

            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"AVERAGE:{averageCount}");
                Console.ResetColor();
            }

            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"PASS:{passCount}");
                Console.ResetColor();
            }

            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"FAIL:{failCount}");
                Console.ResetColor();
            }


            int total = 0;
            for (short i = 0; i < grades.Count; i++) total += grades[i];

            bool exitRequested = false;
            Console.WriteLine("Do you want to save the grades?");
            Console.WriteLine("To save: Yes");
            Console.WriteLine("To not save: No");
            while (true)
            {
                try
                {
                    string? yesOrNo = Console.ReadLine();
                    if (string.IsNullOrEmpty(yesOrNo)) throw new InvalidInputException("Invalid input");
                    if (yesOrNo == "evet" || yesOrNo == "e" || yesOrNo == "yes" || yesOrNo == "Yes" || yesOrNo == "Evet" || yesOrNo == "EVET" || yesOrNo == "YES" ||
                        yesOrNo == "y" || yesOrNo == "Y" || yesOrNo == "E")
                    {
                        break;
                    }

                    if (yesOrNo == "Hayır" || yesOrNo == "Hayir" || yesOrNo == "hayır" || yesOrNo == "hayir" || yesOrNo == "HAYIR" || yesOrNo == "HAYİR" || yesOrNo == "no" ||
                        yesOrNo == "No" || yesOrNo == "NO" || yesOrNo == "N" || yesOrNo == "H" || yesOrNo == "n" || yesOrNo == "n")
                    {
                        exitRequested = true;
                        break;
                    }
                }

                catch (InvalidInputException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }

                catch (GenericException ex)
                {
                    Console.Beep();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("error: " + ex.Message);
                    Console.ResetColor();
                    continue;
                }
            }

            if (exitRequested) return;

            string output = "";
            for (short ii = 0; ii < students.Count; ii++)
            {
                output += $"{students[ii]} student's grade: {grades[ii]}\n";
            }

            float average = (float)total / students.Count;
            string averageStr = $"average: {average}";
            Console.WriteLine($"average: {average}");

            // Full path for the file to be created
            string filePath = "C:\\Users\\berke\\Desktop\\Student_Grades.txt";

            // Content to write
            string fileContent = "Hello, this file was created by C#.";

            // Create the file and write the content
            File.WriteAllText(filePath, output);

            Console.WriteLine("File created successfully.");
        }
    }
}