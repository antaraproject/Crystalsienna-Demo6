using System;

namespace App.CORE.Domain.Master
{
    public class EntitySubscribe
    {
        public Int32 MAST_CITY_KEY { get; set; }
        public Int32 SUBSCRIBE_TOUR_KEY { get; set; }
        public String EMAIL_ID { get; set; }
        public String ACTIVATION_CODE { get; set; }
    



        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntitySubscribe() { }
    }
}
