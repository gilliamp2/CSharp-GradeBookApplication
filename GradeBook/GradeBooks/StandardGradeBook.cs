using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook (String name) : base(name)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}
