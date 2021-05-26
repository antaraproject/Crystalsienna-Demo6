using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using App.CORE.Domain.Setup;

namespace App.CORE.Repositories.Setup
{
    public interface ISysUserType : IRepository<EntitySysUserType>
    {
        void BindDdl(ref DropDownList ddl, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
