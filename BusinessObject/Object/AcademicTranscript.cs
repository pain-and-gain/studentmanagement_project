using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class AcademicTranscript
    {
        public string TranscriptId { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public double? Test15Min { get; set; }
        public double? Test45Min { get; set; }
        public double? FinalTest { get; set; }
        public double? Average { get; set; }
        public int? Semester { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
