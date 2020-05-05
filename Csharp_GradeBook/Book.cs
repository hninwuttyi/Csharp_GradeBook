using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;

        }
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }


        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public event GradeAddedDelegate GradeAdded;
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            for (var index = 0; index < grades.Count(); index += 1)
            {
                if (grades[index] == 42.1)
                {
                    break;
                }
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;

                case var d when d >= 60:
                    result.letter = 'D';
                    break;

                default:
                    result.letter = 'F';
                    break;
 
            }
            return result;
        }

        private List<double> grades;
        public string Name
        {
            get;
            set;
        }

        public const string categories = "Science";
    }
}
