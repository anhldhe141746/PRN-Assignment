using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Models
{
    public partial class TblSetexam
    {
        public int ExamId { get; set; }
        public DateTime? ExamDate { get; set; }
        public int? ExamFkStu { get; set; }
        public string ExamName { get; set; }
        public int? ExamStdScore { get; set; }

        public virtual TblStudent ExamFkStuNavigation { get; set; }
    }
}
