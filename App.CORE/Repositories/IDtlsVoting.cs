using System;
using App.CORE.Domain.Master;
using System.Web.UI.WebControls;

namespace App.CORE.Repositories
{
    public interface IDtlsVoting : IRepository<EntityDtlsVoting>
    {
        void BindDdl(ref DropDownList ddl, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
