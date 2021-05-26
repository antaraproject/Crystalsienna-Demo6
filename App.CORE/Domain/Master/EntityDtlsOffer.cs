using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsOffer
    {
        public Int32 DTLS_OFFER_KEY { get; set; }
        public String OFFER_NAME { get; set; }
        public String OFFER_PER { get; set; }
        public String OFFER_IMG { get; set; }
        public String OFFER_NOTE { get; set; }

        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntityDtlsOffer() { }


    }
}
