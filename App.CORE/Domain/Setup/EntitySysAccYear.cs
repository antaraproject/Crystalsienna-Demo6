using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.CORE.Domain.Setup
{
    public class EntitySysAccYear
    {
        public Int16 ACCOUNTING_YEAR_KEY { get; set; }
        public String ACCOUNTING_YEAR { get; set; }
        public DateTime ACC_START_DATE { get; set; }
        public DateTime ACC_END_DATE { get; set; }
        public Byte STATUS { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntitySysAccYear() { }
    }
}
