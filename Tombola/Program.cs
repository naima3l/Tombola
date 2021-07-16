using System;
namespace Tombola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*        BENVENUTO          *");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("*           A               *");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("*        TOMBOLA            *");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*****************************");
            Console.ResetColor();

            const int N = 15;
            Menu(N);
        }

        private static void Menu(int n)
        {

            Console.WriteLine("Giochiamo!\nRicordati che devono essere inseriti 15 numeri compresi tra 1 e 90 e non devono essere uguali.");
            int number = 0;
            int found = 0;
            int[] userNumbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Inserisci il {i + 1}° numero");
                while(!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > 90)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Scelta non valida. Bisogna inserire un numero intero compreso tra 1 e 90! \nRiprova!");
                    Console.ResetColor();
                }
                found = Array.IndexOf(userNumbers, number);
                if (found > -1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Il numero scelto è già stato inserito!");
                    Console.ResetColor();
                    i--;
                }
                else
                {
                    userNumbers[i] = number;
                }
            }

            Console.WriteLine("I numeri che hai scelto sono: ");
            PrintNumbers(userNumbers);

            Console.WriteLine("\nOttimo! Adesso scegli il livello di difficoltà. \n1. Facile: verranno estratti 70 numeri \n2. Medio: verranno estratti 40 numeri \n3: Difficile: verranno estratti 20 numeri");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Scelta non valida. Scegli tra 1->Facile, 2->Medio, 3->Difficle \nRiprova!");
                Console.ResetColor();
            }
            Play(choice, userNumbers,n);
        }

        private static void Play(int choice, int[] userNumbers,int n)
        {
            Random random = new Random();
            int estrazioni = 0;
            if (choice == 1)
            {
                estrazioni = 70;
            }
            else if (choice == 2)
            {
                estrazioni = 40;
            }
            else estrazioni = 20;

            int[] ranNumbers = new int[estrazioni];
            int num = 0, found = 0;

            for (int i = 0; i < estrazioni; i++)
            {
                num = random.Next(1, 90);
                found = Array.IndexOf(ranNumbers, num);
                if (found == -1)
                {
                    ranNumbers[i] = num;
                }
                else
                {
                    i--;
                }
            }
            Console.WriteLine("I numeri che ho estratto sono: ");
            PrintNumbers(ranNumbers);

            Check(ranNumbers,userNumbers,n);
        }

        private static void Check(int[] ranNumbers, int[] userNumbers, int n)
        {
            int[] win = new int[15];
            int found = 0,k=0;
            for(int i = 0; i < ranNumbers.Length; i++)
            {
                for(int j = 0; j < userNumbers.Length; j++)
                {
                    if(userNumbers[j] == ranNumbers[i])
                    {
                        found++;
                        win[k] = userNumbers[j];
                        k++;
                    }
                }
            }
            Array.Resize(ref win, found);
            switch (found)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMi dispiace! Hai perso...");
                    Console.ResetColor();
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMi dispiace! Hai perso...");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHai fatto Ambo");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHai fatto Terno");
                    Console.ResetColor();
                    break;
                case 4:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHai fatto Quaterna");
                    Console.ResetColor();
                    break;
                case 15:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nHai fatto TOMBOLA!");
                    Console.ResetColor();
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nHai fatto Cinquina");
                    Console.ResetColor();
                    break;

            }
            if(found >= 2)
            {
                Console.WriteLine("I numeri indivinati sono :");
                PrintNumbers(win);
            }
            Console.WriteLine("\nVuoi rigiocare? Inserisci 1 se vuoi rigiocare, 0 altrimenti.");
            int x;
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Scelta non valida. Scegli 1 se vuoi rigiocare, 0 altrimenti.");
                Console.ResetColor();
            }
            if (x == 1)
            {
                Menu(n);
            }
            else
            {
                Console.WriteLine("Grazie per aver giocato!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*****************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("*          CIAO             *");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("*          CIAO!            *");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("*****************************");
                Console.ResetColor();
            }

        }

        private static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} \t");
            }
        }
    }

    
}
