using System;

namespace App.CORE.Domain.Master
{
    public class EntityModelCategory
    {

        public Int32 MAST_MODEL_CATEGORY_KEY { get; set; }
        public String CATEGORY_CODE { get; set; }
        public String CATEGORY_DESC { get; set; }
        public String CATEGORY_TYPE { get; set; }
        public String CATEGORY_FILE_NAME { get; set; }
        public String PAGE_TITLE { get; set; }
        public String META_DESC { get; set; }
        public String META_KEYWORD { get; set; }

        public Byte TAG_LOCKED { get; set; }
        public Byte TAG_APPROVED { get; set; }
        public Int32 MAST_APPROVED_BY_KEY { get; set; }
        public DateTime APPROVE_DATE { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityModelCategory() { }
    }
}
