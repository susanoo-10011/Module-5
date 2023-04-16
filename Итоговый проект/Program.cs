using System;

namespace Итоговый_проект
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tuple = GetUserData();
            ShowData(tuple);
        }

        static (string, string, int, string[], string[]) GetUserData()
        {
            (string name, string surname, int age, string[] petNames, string[] favcolors) userData;

            Console.Write("Введите ваше имя: ");
            userData.name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            userData.surname = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            userData.age = Convert.ToInt32(Console.ReadLine());
            CheckInformation(ref userData.age);

            Console.Write("Есть ли у вас питомец?(есть или нету): ");
            string haveIPet = Console.ReadLine();
            int pet = 0;
            while (true)
            {
                if (haveIPet == "есть")
                {
                    Console.Write("Сколько у вас питомцев? ");
                    pet = Convert.ToInt32(Console.ReadLine());
                    CheckInformation(ref pet);
                    break;
                }
                else if (haveIPet == "нету") break;
                else
                {
                    Console.WriteLine("Вы ответили неверно, повторите попытку!");
                    Console.Write("Есть ли у вас питомец?(есть или нету): ");
                    haveIPet = Console.ReadLine();
                }
            }
            userData.petNames = GetAnArrayOfNickname(pet);

            Console.Write("Сколько в у вас любимых цветов? ");
            int colors = Convert.ToInt32(Console.ReadLine());
            CheckInformation(ref colors);
            userData.favcolors = GetColors(colors);

            return userData;
        }

        static void ShowData((string name, string surname, int age, string[] petNames, string[] favcolors) GetUserData)
        {
            var (name, surname, age, petNames, favcolors) = GetUserData;
            Console.WriteLine("\n------------------\n");
            Console.WriteLine("Вот что я узнал о вас: ");
            Console.WriteLine($"Ваше имя: {name}.");
            Console.WriteLine($"Ваша фамилия: {surname}.");
            Console.WriteLine($"Ваш возраст: {age}.");
            for(int i = 0; i < petNames.Length; i++)
                Console.WriteLine($"Вашего {i+1}-ого питомца зовут '{petNames[i]}' ");
            Console.Write($"Ваши любимые цвета: ");
            for(int i = 0; i < favcolors.Length; i++)
                Console.Write($" {favcolors[i]} |");
            Console.WriteLine();
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
