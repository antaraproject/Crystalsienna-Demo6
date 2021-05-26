using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.CORE.Domain.Setup
{
    public class EntitySysUserType
    {
        public Int32 USER_TYPE_KEY { get; set; }
        public Int16 SYS_SUB_SYSTEM_KEY { get; set; }
        public String USER_TYPE_DESC { get; set; }
        public Byte TAG_DELETE { get; set; }
        public Int16 COMPANY_KEY { get; set; }

        public EntitySysUserType() { }
    }
}
