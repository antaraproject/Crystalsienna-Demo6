﻿using System;

namespace App.CORE.Domain.Master
{
    public class EntityCalendar
    {
        public Int32 DTLS_CALENDER_KEY { get; set; }
        public String DAY_NAME { get; set; }
        public String START_TIME { get; set; }
        public String END_TIME { get; set; }


        public Int32 ENT_USER_KEY { get; set; }
        public DateTime ENT_DATE { get; set; }
        public DateTime ENT_TIME { get; set; }
        public Int32 EDIT_USER_KEY { get; set; }
        public DateTime EDIT_DATE { get; set; }
        public DateTime EDIT_TIME { get; set; }
        public Byte TAG_ACTIVE { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }


        public EntityCalendar() { }
    }
}
