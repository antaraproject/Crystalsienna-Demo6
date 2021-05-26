using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsSelfie
    {
        public Int32 DTLS_SELFIE_KEY { get; set; }
        public string SELFIE_DESC { get; set; }
        public string SELFIE_IMG { get; set; }
        public int ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }


        public EntityDtlsSelfie() { }
    }
}
