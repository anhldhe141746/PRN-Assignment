using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TblQuestion
    {
        public int QuestionId { get; set; }
        public string QText { get; set; }
        public string Opa { get; set; }
        public string Opb { get; set; }
        public string Opc { get; set; }
        public string Opd { get; set; }
        public string Cop { get; set; }
        public int? QFkCatid { get; set; }

        public virtual TblCategroy QFkCat { get; set; }
    }
}
