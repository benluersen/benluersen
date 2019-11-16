using System;
using System.Collections.Generic;
using System.Text;

namespace _538_10_sided_die
{
    public class BusinessLogic
    {
        public double RollGame(int numPlays)
        {
            Random rnd = new Random();
            double finalAvg = 0.0;
            for (int i = 0; i < numPlays; i++)
            {
                List<int> rollList = new List<int>();
                int counter = 0;
                string rollResult = "0.";
                bool exit = false;
                int roll = rnd.Next(0, 10);
                rollList.Add(roll);
                while (!exit)
                {
                    roll = rnd.Next(0, 10);
                    if (roll == 0)
                    {
                        exit = true;
                    }
                    else if (roll <= rollList[counter])
                    {
                        rollList.Add(roll);
                        counter++;
                    }
                }
                foreach (var thing in rollList)
                {
                    rollResult += $"{thing}";
                }
                double rollResultdouble = Convert.ToDouble(rollResult);
                finalAvg += rollResultdouble;
            }
            finalAvg = finalAvg / (numPlays);
            return finalAvg;
        }
    }
}
