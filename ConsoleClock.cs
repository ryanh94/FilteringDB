using System;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    public class ConsoleClock
    {
        /*
         * Requirement
         *
         * Refactor to use async/await keywords to demonstrate running a long running task on a separate thread
         */

        public async Task PrintTime()
        {
            Console.Clear();
            PrintNow();

            var endTime = DateTime.Now.AddSeconds(10);

            await PrintTimeEveryHalfSecond(endTime);
        }

        private async Task PrintTimeEveryHalfSecond(DateTime until)
        {
            while (until > DateTime.Now)
            {
                await Task.Delay(500);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                PrintNow();
            }
        }

        private void PrintNow()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
