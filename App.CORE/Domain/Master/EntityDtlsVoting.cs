using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsVoting
    {
        public Int32 DTLS_VOTING_KEY { get; set; }
        public String VOTING_DESC { get; set; }
        public String VOTING_HEADING { get; set; }
        public DateTime VOTING_DATE { get; set; }
        public String VOTING_IMG { get; set; }
        public String USER_KEY { get; set; }
        public String IMAGE_KEY { get; set; }


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
        public EntityDtlsVoting() { }
    }
}
