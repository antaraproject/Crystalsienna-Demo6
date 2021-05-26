using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsForum
    {
        public Int32 DTLS_FORUM_KEY { get; set; }
        public String FORUM_HEADING { get; set; }
        public String FORUM_DESC { get; set; }
        public DateTime FORUM_DATE { get; set; }
        public String FORUM_IMG { get; set; }
        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }
        public EntityDtlsForum() { }
    }
}
