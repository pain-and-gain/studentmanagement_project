using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class Class
    {
        public string ClassId { get; set; }
        public string StudentId { get; set; }
        public string ClassName { get; set; }
        public string UserId { get; set; }
        public string SchoolYear { get; set; }

        public virtual SchoolYear SchoolYearNavigation { get; set; }
        public virtual Student Student { get; set; }
        public virtual Account User { get; set; }
    }
}
