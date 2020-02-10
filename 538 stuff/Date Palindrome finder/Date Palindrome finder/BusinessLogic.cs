using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Palindrome_finder
{
    class BusinessLogic
    {
        public int HowManyPalindromes(string endYear)
        {
            var date = DateTime.Now;
            int palindromeCounter = 0;
            while (date.Year.ToString() != endYear)
            {
                string dateString = date.ToString("MMddyyyy");
                var reversedDateString = new String(dateString.Reverse().ToArray());
                if (dateString == reversedDateString)
                {
                    palindromeCounter++;
                }
                date = date.AddDays(1);
            }
            return palindromeCounter;
        }
    }
}
