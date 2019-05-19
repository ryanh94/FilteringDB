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
            ColoursService coloursService = new ColoursService(dataAccess);

            //Check if table exists if not then create
            CreateNewTableIfDoesNotExist(dataAccess);

            var commonColours = GetCommonColours(coloursService);

            Console.WriteLine($"{commonColours.Count} common colours found: ");

            foreach (var colour in commonColours)
            {
                Console.WriteLine(colour);
            }
            Console.WriteLine();
            Console.Write($"Save these to the {nameof(CommonColour)}s table? (y/n) ");

            //check for user input to save common colours
            var seedCommonColours = YesNo();

            if (seedCommonColours)
            {
                //clear common colours in table
                ClearDatabaseReadyForInsert(dataAccess);

                Console.WriteLine("Clearing old data...");
                Console.WriteLine("Saving...");

                //insert new common colour colours
                InsertCommonColours(dataAccess, coloursService, commonColours);

                Console.WriteLine($"Saved {commonColours.Count} common colours");
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
        private static void CreateNewTableIfDoesNotExist(DataAccess dataAccess)
        {
            var tableExists = dataAccess.TableExists<CommonColour>();

            if (!tableExists)
            {
                // Migrate database to latest
                var migrator = new Migrator(dataAccess);
                migrator.CreateTable<CommonColour>();
            }
        }
        private static List<string> GetCommonColours(ColoursService coloursService)
        {
            var commonColours = coloursService.GetCommonColours().ToList();

            return commonColours;
        }
        private static void ClearDatabaseReadyForInsert(DataAccess dataAccess)
        {
            dataAccess.Transaction<CommonColour>((ctx, table) =>
            {
                table.DeleteAllOnSubmit(table);
            });
        }
        private static void InsertCommonColours(DataAccess dataAccess, ColoursService coloursServiceForRGB, List<string> commonColours)
        {
            List<CommonColour> mappedCommonColours = new List<CommonColour>();

            int index = 0;
            foreach (var commonColour in commonColours)
            {
                mappedCommonColours.Add(new CommonColour
                {
                    ID = index++,
                    Color = coloursServiceForRGB.ToRgb(commonColour)
                });
            }
            dataAccess.InsertAll(mappedCommonColours);
        }
        private static void InsertCommonColours(DataAccess dataAccess, List<string> commonColours)
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
