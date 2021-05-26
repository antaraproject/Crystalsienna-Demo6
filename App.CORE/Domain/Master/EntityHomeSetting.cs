using System;

namespace App.CORE.Domain.Master
{
    public class EntityHomeSetting
    {
        public String BANNER_IMG { get; set; }
        public String ABOUT_DESC { get; set; }
        public String ABOUT_IMG { get; set; }
        public String OFFER_IMG { get; set; }
        public String QUICK_FACT_IMG { get; set; }

        //Quick Fact
        public Int32 DTLS_QUICK_FACT_KEY { get; set; }
        public String QUICK_FACT_NAME { get; set; }

        public String QUICK_FACT { get; set; }

        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }
        public EntityHomeSetting() { }
    }
}
