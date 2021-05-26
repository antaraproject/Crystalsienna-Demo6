using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.CORE.Domain.Master
{
    public class EntityDtlsAppointment
    {
        public Int32 DTLS_APPOINTMENT_KEY { get; set; }
        public String TIME_SPAN { get; set; }
        public Double PRICE { get; set; }
        public String EVENT_DATE { get; set; }
        public String EVENT_DAY { get; set; }
        public String DESCRIPTION { get; set; }
        public String USER_EMAIL { get; set; }
        public String TAG_STATUS { get; set; }

        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public String title { get; set; }
        public String start { get; set; }
        public String end { get; set; }
        public EntityDtlsAppointment() { }
    }
}
