using System;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsDiary
    {
        public Int32 DTLS_DIARY_KEY { get; set; }
        public string DIARY_HEADING { get; set; }
        public DateTime DIARY_DATE { get; set; }
        public string SHORT_DESC { get; set; }

        public string DIARY_IMG { get; set; }
        public string LONG_DESC { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityDtlsDiary() { }
    }
}
