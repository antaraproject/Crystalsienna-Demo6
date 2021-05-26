using System;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsNews
    {
        public Int32 DTLS_NEWS_KEY { get; set; }
        public String NEWS_HEADING { get; set; }
        public String SHORT_DESC { get; set; }
        public String NEWS_DESC { get; set; }
        public DateTime NEWS_DATE { get; set; }
        public String NEWS_IMG { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityDtlsNews() { }
    }
}
