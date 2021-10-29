using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class Student
    {
        public Student()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            Classes = new HashSet<Class>();
        }

        public string StudentId { get; set; }
        public string Name { get; set; }
        public DateTime? Birth { get; set; }
        public string Address { get; set; }
        public string Proficiency { get; set; }
        public string SchoolYearId { get; set; }

        public virtual SchoolYear SchoolYear { get; set; }
        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
