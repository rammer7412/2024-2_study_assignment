using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter # of subjects: ");
        int subjectCount = int.Parse(Console.ReadLine());

        Console.Write("Enter # of students: ");
        int stdCount = int.Parse(Console.ReadLine());

        string[,] data = new string[stdCount + 1, subjectCount + 1];

        data[0, 0] = "Name";
        for (int j = 1; j <= subjectCount; j++)
        {
            Console.Write($"Enter name of subject {j}: ");
            data[0, j] = Console.ReadLine();
        }

        for (int i = 1; i <= stdCount; i++)
        {
            Console.Write($"Enter name of student {i}: ");
            data[i, 0] = Console.ReadLine();

            Console.Write($"Enter {data[i, 0]}'s scores (");
            for (int j = 1; j <= subjectCount; j++)
            {
                Console.Write(data[0, j]);
                if (j < subjectCount) Console.Write(", ");
            }
            Console.Write(") separated by spaces: ");

            string[] scores = Console.ReadLine().Split(' ');

            for (int j = 1; j <= subjectCount; j++)
            {
                data[i, j] = scores[j - 1];
            }
        }

        double[] averages = new double[subjectCount];
        for (int j = 1; j <= subjectCount; j++)
        {
            double sum = 0;
            for (int i = 1; i <= stdCount; i++)
            {
                sum += double.Parse(data[i, j]);
            }
            averages[j - 1] = sum / stdCount;
        }

        Tuple<double, double>[] minMaxScores = new Tuple<double, double>[subjectCount];
        for (int j = 1; j <= subjectCount; j++)
        {
            double min = double.MaxValue;
            double max = double.MinValue;
            for (int i = 1; i <= stdCount; i++)
            {
                double score = double.Parse(data[i, j]);
                if (score > max) max = score;
                if (score < min) min = score;
            }
            minMaxScores[j - 1] = new Tuple<double, double>(max, min);
        }

        List<(string name, double total)> studentScores = new List<(string, double)>();
        for (int i = 1; i <= stdCount; i++)
        {
            string name = data[i, 0];
            double total = 0;
            for (int j = 1; j <= subjectCount; j++)
            {
                total += double.Parse(data[i, j]);
            }
            studentScores.Add((name, total));
        }

        studentScores = studentScores.OrderByDescending(s => s.total).ToList();

        Console.WriteLine("\nAverage Scores:");
        for (int j = 0; j < subjectCount; j++)
        {
            Console.WriteLine($"{data[0, j + 1]}: {averages[j]:F2}");
        }

        Console.WriteLine("\nMax and min Scores:");
        for (int j = 0; j < subjectCount; j++)
        {
            Console.WriteLine($"{data[0, j + 1]}: ({minMaxScores[j].Item1}, {minMaxScores[j].Item2})");
        }

        Console.WriteLine("\nStudents ranked by total scores:");
        for (int i = 0; i < studentScores.Count; i++)
        {
            string suffix = GetRankSuffix(i + 1);
            Console.WriteLine($"{studentScores[i].name}: {i + 1}{suffix}");
        }
    }

    static string GetRankSuffix(int rank)
    {
        if (rank % 10 == 1 && rank % 100 != 11) return "st";
        if (rank % 10 == 2 && rank % 100 != 12) return "nd";
        if (rank % 10 == 3 && rank % 100 != 13) return "rd";
        return "th";
    }
}
