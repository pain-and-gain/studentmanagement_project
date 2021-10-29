using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject.Object
{
    public partial class Account
    {
        public Account()
        {
            Classes = new HashSet<Class>();
        }

        public string UserId { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
