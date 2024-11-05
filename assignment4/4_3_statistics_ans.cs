using System;
using System.Linq;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)

            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            double[] mathScores = new double[stdCount];
            double[] scienceScores = new double[stdCount];
            double[] englishScores = new double[stdCount];
            double[] totalScores = new double[stdCount];
            string[] studentNames = new string[stdCount];

            // 데이터를 배열에 저장
            for (int i = 1; i <= stdCount; i++)
            {
                studentNames[i - 1] = data[i, 1];
                mathScores[i - 1] = double.Parse(data[i, 2]);
                scienceScores[i - 1] = double.Parse(data[i, 3]);
                englishScores[i - 1] = double.Parse(data[i, 4]);
                totalScores[i - 1] = mathScores[i - 1] + scienceScores[i - 1] + englishScores[i - 1];
            }

            // 과목별 평균 계산
            double avgMath = mathScores.Average();
            double avgScience = scienceScores.Average();
            double avgEnglish = englishScores.Average();
            Console.WriteLine("Average Scores:");
            Console.WriteLine($"Math: {avgMath:F2}");
            Console.WriteLine($"Science: {avgScience:F2}");
            Console.WriteLine($"English: {avgEnglish:F2}");

            // 과목별 최대/최소 점수 계산
            double maxMath = mathScores.Max();
            double minMath = mathScores.Min();
            double maxScience = scienceScores.Max();
            double minScience = scienceScores.Min();
            double maxEnglish = englishScores.Max();
            double minEnglish = englishScores.Min();
            Console.WriteLine("\nMax and min Scores:");
            Console.WriteLine($"Math: ({maxMath}, {minMath})");
            Console.WriteLine($"Science: ({maxScience}, {minScience})");
            Console.WriteLine($"English: ({maxEnglish}, {minEnglish})");

            // 학생별 총점 순위 계산
            var ranking = totalScores
                .Select((score, index) => new { Name = studentNames[index], Score = score })
                .OrderByDescending(x => x.Score)
                .Select((x, rank) => new { x.Name, Rank = rank + 1 })
                .ToList();

            Console.WriteLine("\nStudents rank by total scores:");
            foreach (var student in ranking)
            {
                string suffix = student.Rank == 1 ? "st" : student.Rank == 2 ? "nd" : student.Rank == 3 ? "rd" : "th";
                Console.WriteLine($"{student.Name}: {student.Rank}{suffix}");
            }
// --------------------

        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 4th
Bob: 1st
Charlie: 5th
David: 2nd
Eve: 3rd

*/
