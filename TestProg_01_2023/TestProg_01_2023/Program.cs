using System;
using System.Collections.Generic;
using System.IO;

// Начал писать эту программу в 11:42
// Для кода использовай свой архив шаблонов кода
// Закончил программу в 12:30 (но я и не особо спешил :)

namespace TestProg_01_2023
{
	class Program
	{
		#region MyPrint
		public static void print<Type>(Type Input)
		{
			Console.WriteLine(Input);
		}

		public static void println<Type>(Type Input)
		{
			// Печать строки без переноса каретки
			Console.Write(Input);
		}
		#endregion

		static void Main()
		{
			MainCore a = new MainCore();

			a.Answer();
		}

		public class MainCore
		{
			public string nameOfFile = "Numbers.txt";
			public bool isFileBeRead = false;

			public void ReadFile()
			{
				if (OpenInputFiles(nameOfFile) == true) isFileBeRead = true;
			}

			public List<string> InputLine = new List<string>();

			// Метод чтения строк из входного файла. 
			// Возвращает false, если входной файл не был найден
			public bool OpenInputFiles(string nameInputFile)
			{
				if (nameInputFile == "") nameInputFile = nameOfFile;

				try
				{
					using (StreamReader fs = new StreamReader(nameInputFile))
					{
						string currentLine = "";
						while ((currentLine = fs.ReadLine()) != null)
						{
							//Console.WriteLine(currentLine);
							InputLine.Add(currentLine);
						}
					}
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine("Файл не удалось прочитать:");
					Console.WriteLine(e.Message);
					return false;
				}
			}

			public int countOfNumbers = 0;
			public int maxOfNumbers = 0;

			public void SearchMax()
			{
				if (isFileBeRead == true)
				{
					foreach (string value in InputLine) 
					{
						int num;
						bool success = int.TryParse(value, out num);

						if (success == true) // Если строка - действительна была числом
						{
							countOfNumbers++;

							if (num > maxOfNumbers) maxOfNumbers = num;
						}							
					}
				}
				else 
				{
					print("Файл не найден, его обработка не возможна.");
				}
			}

			public void Answer()
			{
				ReadFile();
				SearchMax();

				if (isFileBeRead == false)
				{
					print("К сожалнеию, программе не удалось найти и обработать входной файл. Проверьте его существование в директории ");
				}
				else
				{
					if (countOfNumbers == 0)
					{
						print("Во входном файле не были обнаружены числа. Проверьте его правильность");
					}
					else
					{
						print("Файл успешно обработан!");
						print("");
						print("Всего числел в фалйе: " + countOfNumbers);
						print("Наибольшее число: " + maxOfNumbers);
					}
				}
			}
		}
	}
}
