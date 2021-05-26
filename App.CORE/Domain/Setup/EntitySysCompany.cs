using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.CORE.Domain.Setup
{
    public class EntitySysCompany
    {
        public Int16 COMPANY_KEY { get; set; }
        public String COMPANY_NAME { get; set; }
        public String PROP_NAME { get; set; }
        public String ADDRESS { get; set; }
        public String PINNO { get; set; }
        public String PHONENO { get; set; }
        public String MOBILE { get; set; }
        public String EMAIL { get; set; }
        public String PAN_NO { get; set; }
        public String GSTIN_NO { get; set; }
        public String COMPANY_TAG { get; set; }

        public EntitySysCompany() { }
    }
}
