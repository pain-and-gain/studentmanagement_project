using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class Subject
    {
        public Subject()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
        }

        public string SubjectId { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
    }
}
