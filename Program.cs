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
            var dataAccess = new DataAccess(ConfigHelper.ConnectionStrings.Demo);

            EnsureDatabaseIsLatest(dataAccess);

            ColoursService coloursService = new ColoursService(dataAccess);

            var commonColours = GetCommonColours(coloursService);

            var seedCommonColours = YesNo($"Save these to the {nameof(CommonColour)}s table? ");

            if (seedCommonColours)
            {
                SeedCommonColours(dataAccess, coloursService, commonColours);
            }

            ConsoleClock time = new ConsoleClock();
            await time.PrintTime();

            Console.ReadLine();
        }

        public static bool YesNo(string question = null)
        {
            question = question ?? string.Empty;
            Console.WriteLine(question + "(y/n) ");
            ConsoleKey keyPress;
            do
            {
                keyPress = Console.ReadKey(true).Key;
            } while (keyPress != ConsoleKey.Y && keyPress != ConsoleKey.N);

            Console.WriteLine(keyPress);
            return keyPress == ConsoleKey.Y;
        }

        private static void EnsureDatabaseIsLatest(DataAccess dataAccess)
        {
            var tableExists = dataAccess.TableExists<CommonColour>();

            if (!tableExists)
            {
                Console.WriteLine("Database is updating to latest...");

                // Migrate database to latest
                var migrator = new Migrator(dataAccess);
                migrator.CreateTable<CommonColour>();

                Console.WriteLine("Database updated");
            }
        }

        private static List<string> GetCommonColours(ColoursService coloursService)
        {
            var commonColours = coloursService.GetCommonColours().ToList();

            Console.WriteLine($"{commonColours.Count} common colours found: ");

            foreach (var colour in commonColours)
            {
                Console.WriteLine(colour);
            }

            Console.WriteLine();

            return commonColours;
        }

        private static void SeedCommonColours(DataAccess dataAccess, ColoursService coloursService, IReadOnlyCollection<string> commonColours)
        {
            Console.WriteLine("Clearing old common colours...");
            // Clear table ready to seed
            DeleteAllCommonColours(dataAccess);
            Console.WriteLine("Old data cleared");

            Console.WriteLine("Saving new common colours...");

            InsertCommonColours(dataAccess, coloursService.ToRgb(commonColours));

            Console.WriteLine($"Saved {commonColours.Count} common colours");
        }

        private static void DeleteAllCommonColours(DataAccess dataAccess)
        {
            dataAccess.Transaction<CommonColour>((ctx, table) =>
            {
                table.DeleteAllOnSubmit(table);
            });
        }

        private static void InsertCommonColours(DataAccess dataAccess, IEnumerable<string> commonColours)
        {
            List<CommonColour> mappedCommonColours = new List<CommonColour>();

            int index = 0;
            foreach (var commonColour in commonColours)
            {
                mappedCommonColours.Add(new CommonColour
                {
                    ID = index++,
                    Color = commonColour
                });
            }

            dataAccess.InsertAll(mappedCommonColours);
        }
    }
}
