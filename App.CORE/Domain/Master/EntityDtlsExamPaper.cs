using System;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsExamPaper
    {
        public Int32 DTLS_EXAM_PAPER_KEY { get; set; }
        public Int32 HEAD_EXAM_PAPER_KEY { get; set; }        
        public String QUESTION_HEADING { get; set; }
        public String OPTION_ONE { get; set; }
        public String OPTION_TWO { get; set; }
        public String OPTION_THREE { get; set; }
        public String OPTION_FOUR { get; set; }
        public String DESCRIPTIVE_ANSWER { get; set; }
        public String CORRECT_OPTION { get; set; }
        public Decimal MARKS { get; set; }
        public Decimal NEGETIVE_MARKS_PER_QTN { get; set; }
        public String ANSWER_EXPLANATION { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityDtlsExamPaper() { }
    }
}
