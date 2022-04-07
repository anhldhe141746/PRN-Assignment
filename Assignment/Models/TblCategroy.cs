using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TblCategroy
    {
        public TblCategroy()
        {
            TblQuestions = new HashSet<TblQuestion>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }
        public int? CatFkAdid { get; set; }
        public string CatEncyptedstring { get; set; }

        public virtual TblAdmin CatFkAd { get; set; }
        public virtual ICollection<TblQuestion> TblQuestions { get; set; }
    }
}
