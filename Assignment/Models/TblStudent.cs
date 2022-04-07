using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblSetexams = new HashSet<TblSetexam>();
        }

        public int SId { get; set; }
        public string SName { get; set; }
        public string SPassword { get; set; }

        public virtual ICollection<TblSetexam> TblSetexams { get; set; }
    }
}
