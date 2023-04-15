using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Итоговый_проект
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tuple = GetUserData();
            ShowData(tuple);
        }

        static (string, string, int, string, int) GetUserData()
        {
            (string name, string surname, int age, string haveIApet, int favcolors) userData;

            Console.Write("Введите ваше имя: ");
            userData.name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            userData.surname = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            userData.age = Convert.ToInt32(Console.ReadLine());
            CheckInformation(ref userData.age);

            Console.Write("Есть ли у вас питомец?(есть или нету): ");
            userData.haveIApet = Console.ReadLine();
            InformationAboutPets(ref userData.haveIApet);

            Console.Write("Сколько в у вас любимых цветов? ");
            userData.favcolors = Convert.ToInt32(Console.ReadLine());
            CheckInformation(ref userData.favcolors);
            GetColors(userData.favcolors);

            return userData;

        }

        static void ShowData((string name, string surname, int age, string haveIPet, int favcolors) GetUserData)
        {
            var tuple = GetUserData;
            Console.WriteLine("\n------------------\n");
            Console.WriteLine("Вот что я узнал о вас: ");

            Console.WriteLine($"Ваше имя: {tuple.name}.");
            Console.WriteLine($"Ваша фамилия: {tuple.surname}.");
            Console.WriteLine($"Ваш возраст: {tuple.age}.");
            Console.WriteLine($"Количество ваших любимых цветов: {tuple.favcolors}");

        }

        static void InformationAboutPets(ref string haveIPet)
        {
            while (haveIPet != "нету" && haveIPet != "есть")
            {
                switch (haveIPet)
                {
                    case "нету":
                        break;

                    case "есть":
                        Console.Write("Сколько у вас питомцев? ");
                        int pet = Convert.ToInt32(Console.ReadLine());
                        CheckInformation(ref pet);
                        string[] arrayWithNicknames = GetAnArrayOfNickname(pet);
                        break;
                    default:
                        Console.WriteLine("Вы ответили неверно, повторите попытку!");
                        Console.Write("Есть ли у вас питомец?(есть или нету): ");
                        haveIPet = Console.ReadLine();
                        break;
                }
            }
        }

        static string[] GetAnArrayOfNickname(int numberOfPets)
        {
            string[] arrayOfNicknames = new string[numberOfPets];

            for (int i = 0; i < numberOfPets; i++)
            {
                Console.Write($"Введите кличку вашего {i + 1}-ого питомца: ");
                arrayOfNicknames[i] = Console.ReadLine();
            }
            return arrayOfNicknames;
        }

        static string[] GetColors(int numberOfColors)
        {
            string[] arrayOfColors = new string[numberOfColors];
            for (int i = 0; i < numberOfColors; i++)
            {
                Console.Write($"Ваш {i + 1} любимый цвет: ");
                arrayOfColors[i] = Console.ReadLine();
            }
            return arrayOfColors;
        }

        static void CheckInformation(ref int userData)
        {
            while (true)
            {
                if (userData <= 0)
                {
                    Console.WriteLine("Вы ввели некорректные данные! Повторите попытку.");
                    userData = int.Parse(Console.ReadLine());
                }
                else break;
            }
        }


    }
}
