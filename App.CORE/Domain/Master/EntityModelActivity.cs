using System;

namespace App.CORE.Domain.Master
{
    public class EntityModelActivity
    {
        public Int32 MAST_MODEL_ACTIVITY_KEY { get; set; }
        public String ACTIVITY_CODE { get; set; }
        public String ACTIVITY_DESC { get; set; }
        public String ACTIVITY_LOGO { get; set; }

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
        public EntityModelActivity() { }
    }
}
