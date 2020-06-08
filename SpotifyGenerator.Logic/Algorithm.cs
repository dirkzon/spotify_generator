using System;
using System.Collections.Generic;

namespace SpotifyGenerator.Logic
{
    public static class Algorithm
    {
        public static double GetValue(List<double> answers, double input)
        {
            answers.Add(input);
            double a = 0;
            int length = answers.Count;
            for (int i = 0; i < length; i++)
            {
                a += answers[i];
            }
            double average = a / length;
            return Math.Round(average, 2);
        }
    }
}
