using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (String name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var rankingThreshold = (int)Math.Ceiling(Students.Count * 0.2);
            var studentGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            
            if (studentGrades[rankingThreshold - 1] <= averageGrade)
            {
                return ('A');
            }

            else if (studentGrades[(rankingThreshold*2) - 1] <= averageGrade)
            {
                return ('B');
            }
            else if (studentGrades[(rankingThreshold*3) - 1] <= averageGrade)
            {
                return ('C');
            }
            else if (studentGrades[(rankingThreshold*4) - 1] <= averageGrade)
            {
                return ('D');
            }
            return ('F');
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked gradind requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked gradind requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

    }
}
