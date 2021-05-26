using System;

namespace App.CORE.Domain.Master
{
    public class EntityDocuents
    {
        public Int32 HEAD_DOCUMENT_KEY { get; set; }
        public Int32 DTLS_DOCUMENTS_KEY { get; set; }
        public Int32 MAST_CATEGORY_KEY { get; set; }
        public Int32 MAST_SUB_CATEGORY_KEY { get; set; }
        public String REMARKS { get; set; }
        public String DOCUMENT_NAME { get; set; }
        public String DOCUMENT_PATH { get; set; }
        public String DETAILS { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }
        public EntityDocuents() { }
    }
}
