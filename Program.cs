using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Interview.Data;

namespace Interview
{
    static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Start of Application");

            var dataAccess = new DataAccess(ConfigHelper.ConnectionStrings.Demo);

            var tableExists = dataAccess.TableExists<CommonColour>();

            if (!tableExists)
            {
                // Migrate database to latest
                var migrator = new Migrator(dataAccess);
                migrator.CreateTable<CommonColour>();
            }

            ColoursService coloursService = new ColoursService(dataAccess);
            var commonColours = coloursService.GetCommonColours().ToList();

            Console.WriteLine($"{commonColours.Count} common colours found: ");
            foreach (var colour in commonColours)
            {
                Console.WriteLine(colour);
            }
            Console.WriteLine();

            Console.Write($"Save these to the {nameof(CommonColour)}s table? (y/n) ");

            var seedCommonColours = YesNo();

            if (seedCommonColours)
            {
                Console.WriteLine("Clearing old data...");
                dataAccess.Transaction<CommonColour>((ctx, table) =>
                {
                    table.DeleteAllOnSubmit(table);
                });
                Console.WriteLine("Common colours data cleared");

                List<CommonColour> mappedCommonColours = new List<CommonColour>();

                int index = 0;
                foreach (var commonColour in commonColours)
                {
                    mappedCommonColours.Add(new CommonColour
                    {
                        ID = index++,
                        Color = coloursService.ToRgb(commonColour)
                    });
                }

                Console.WriteLine("Saving...");
                dataAccess.InsertAll(mappedCommonColours);
                Console.WriteLine($"Saved {mappedCommonColours.Count} common colours");
            }

            ConsoleClock time = new ConsoleClock();
            await time.PrintTime();

            Console.ReadLine();
        }

        public static bool YesNo()
        {
            ConsoleKey keyPress;
            do
            {
                keyPress = Console.ReadKey(true).Key;
            } while (keyPress != ConsoleKey.Y && keyPress != ConsoleKey.N);

            Console.WriteLine(keyPress);
            return keyPress == ConsoleKey.Y;
        }
    }
}
