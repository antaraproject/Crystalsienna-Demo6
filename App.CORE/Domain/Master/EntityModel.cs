using System;

namespace App.CORE.Domain.Master
{
    public class EntityModel
    {
        public Int32 MAST_MODEL_KEY { get; set; }
        public Int32 USER_KEY { get; set; }
        public Int32 AGE { get; set; }
        public Int32 MAST_MODEL_CATEGORY_KEY { get; set; }
        public String MODEL_CODE { get; set; }
        public String MODEL_NAME { get; set; }
        public String MODEL_DESC { get; set; }
        public String BUST { get; set; }
        public String EYE_COLOUR { get; set; }
        public String SKIN_COLOUR { get; set; }
        public String HEIGHT { get; set; }
        public String DRESS { get; set; }
        public String HAIR_COLOUR { get; set; }
        public String HERITAGE { get; set; }
        public String IMG_FILE_NAME { get; set; }
        public String MULTI_IMAGE_NAME { get; set; }
        public String MODEL_TYPE { get; set; }
        public String MODEL_SHORT_DESC { get; set; }
        public String MAST_MODEL_ACTIVITY_KEY { get; set; }
        public String NICK_NAME { get; set; }
        public String USER_PASSWORD { get; set; }
        public Int32 MAST_SCHEDULE_KEY { get; set; }
        public DateTime SCHEDULE_DATE { get; set; }
        public String FORM_TIME { get; set; }
        public String TO_TIME { get; set; }


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

        public EntityModel() { }
    }
}
