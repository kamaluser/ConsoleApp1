using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public int No { get; set; }
        public string FullName { get; set; }
        public Dictionary<Exam, int> Exams = new Dictionary<Exam, int>();

        public void AddExam(Exam exam, int point)
        {
            Exams.Add(exam, point);
        }

        public int GetExamResult(Exam exam)
        {
            return Exams.ContainsKey(exam) ? Exams[exam] : -1;
        }

        public double GetExamAvg()
        {
            if (Exams.Count == 0)
            {
                return 0;
            }
            return Exams.Values.Average();
        }

        public void RemoveExam(Exam exam)
        {
            Exams.Remove(exam);
        }
    }
}
