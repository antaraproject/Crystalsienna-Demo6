using System;

namespace App.CORE.Domain.Master
{
    public class EntityRoster
    {


        public Int32 MAST_ROSTER_KEY { get; set; }
        public DateTime ROSTER_DATE { get; set; }
        public Int32 MAST_TIME_KEY { get; set; }
        public Int32 MAST_MODEL_KEY { get; set; }



        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityRoster() { }
    }
}
