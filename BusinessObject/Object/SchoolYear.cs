using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class SchoolYear
    {
        public SchoolYear()
        {
            Classes = new HashSet<Class>();
            Students = new HashSet<Student>();
        }

        public string SchoolYearId { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
