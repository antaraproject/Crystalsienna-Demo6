using System;
using System.Web.UI.WebControls;
using App.CORE.Domain.Setup;

namespace App.CORE.Repositories.Setup
{
    public interface ISysAccYear : IRepository<EntitySysAccYear>
    {
        void BindDdl(ref DropDownList ddl, Int16 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
