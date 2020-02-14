using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Palindrome_finder
{
    class BusinessLogic
    {
        public List<string> HowManyPalindromes(string endYear)
        {
            var date = DateTime.Now;
            List<string> palindromeCounter = new List<string>();
            while (date.Year.ToString() != endYear)
            {
                string dateString = date.ToString("MMddyyyy");
                var reversedDateString = new String(dateString.Reverse().ToArray());
                if (dateString == reversedDateString)
                {
                    palindromeCounter.Add(dateString);
                }
                date = date.AddDays(1);
            }
            return palindromeCounter;
        }
    }
}
