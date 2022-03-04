using System;
using System.Collections.Generic;
using Multimedi_Broodjes.Data.Entities;
using Multimedi_Broodjes.Data.Repositories;

namespace Multimedi_Broodjes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UpdateLeverancier();

            //var repo = new LeverancierRepo();
            
            //Leverancier leverancier = repo.GetLeverancierById("3;DROP TABLE LEVERANCIERS;");
            
            //Console.WriteLine("Onze huidige leverancies zijn:");
            //Console.WriteLine($"Id: {leverancier.LeverancierID}, naam {leverancier.LeverancierNaam}");

            //foreach (Leverancier leverancier in leveranciers)
            //{
            //    Console.WriteLine($"Id: {leverancier.LeverancierID}, naam {leverancier.LeverancierNaam}");
            //    Console.WriteLine("-----------------------------------");
            //}


        }

        private static void AddLeverancier()
        {
            Console.WriteLine("Hallo. Voer de naam van een nieuwe leverancier in");
            string name = Console.ReadLine();

            Leverancier leverancier = new Leverancier
            {
                LeverancierNaam = name
            };

            var repo = new LeverancierRepo();
            repo.AddLeverancier(leverancier);
        }

        private static void UpdateLeverancier()
        {
            Console.WriteLine("Hallo. Voer de id in van de leverancier die u wilt updaten.");
            int id = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Hallo. Voer de nieuwe naam in van de leverancier");
            string name = Console.ReadLine();

            Leverancier leverancier = new Leverancier
            {
                LeverancierNaam = name
            };

            var repo = new LeverancierRepo();
            repo.UpdateLeverancier(id, leverancier);
        }
    }
}
