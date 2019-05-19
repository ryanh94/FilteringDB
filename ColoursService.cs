using System.Linq;
using Interview.Data;
using System.Collections.Generic;
using System.Drawing;
using DataModel;

namespace Interview
{
    using ColourTranslator = ColorTranslator;

    public class ColoursService
    {

        /*
         * Requirement
         *
         * 1. Take the data in Samples1 and Samples2 in the Demo Db (Found in the Server Explorer)
         *    and print to the console those values that are common to each table.
         * 2. Format the data in individual RGB component values, e.g. #5acb97 is RGB(90,203,151)
         * 3. Bonus - Write the RGB values to a new table CommonColor
         */

        //static readonly string ConnectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = Demo; Integrated Security = True";
        private readonly DataAccess _dataAccess;

        public ColoursService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<string> GetCommonColours()
        {
            //results from table 1
            var getColourList1 = _dataAccess.Query<Colours1, string>(colors => colors.Select(c => c.Color));
            //results from table 2
            var getColourList2 = _dataAccess.Query<Colours2, string>(colors => colors.Select(c => c.Color));

            //check for common values in both tables
            var filteredResults = getColourList1.Where(x => getColourList2.Contains(x));

            return filteredResults;
        }

        public IEnumerable<string> ToRgb(IEnumerable<string> htmlColours)
        {
            foreach (var htmlColour in htmlColours)
            {
                var rgb = ToRgb(htmlColour);
                yield return rgb;
            }
        }

        public string ToRgb(string htmlColour)
        {
            var color = ColourTranslator.FromHtml(htmlColour);
            var rgb = string.Format($"RGB({color.R},{color.G},{color.B})");

            return rgb;
        }
    }
}



/*
The answer is
#5acb97
#99a8d9
#ef5840
#9c1826
#039604
#29d8cb
#15641f
#ab8c37
#9b3659
#cbb3d1
#3accaf
#2c10cd
#668e3c
#63543e
#619b33
*/


/*
The answer is:
RGB(90,203,151)
RGB(153,168,217)
RGB(239,88,64)
RGB(156,24,38)
RGB(3,150,4)
RGB(41,216,203)
RGB(21,100,31)
RGB(171,140,55)
RGB(155,54,89)
RGB(203,179,209)
RGB(58,204,175)
RGB(44,16,205)
RGB(102,142,60)
RGB(99,84,62)
RGB(97,155,51)
 */

