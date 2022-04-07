using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TblAdmin
    {
        public TblAdmin()
        {
            TblCategroys = new HashSet<TblCategroy>();
        }

        public int AdId { get; set; }
        public string AdName { get; set; }
        public string AdPassword { get; set; }

        public virtual ICollection<TblCategroy> TblCategroys { get; set; }
    }
}
