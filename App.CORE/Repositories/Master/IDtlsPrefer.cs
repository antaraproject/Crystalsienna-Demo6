using System;
using System.Web.UI.WebControls;
using App.CORE.Domain.Master;
namespace App.CORE.Repositories.Master
{
   public interface IDtlsPrefer : IRepository<EntityDtlsPrefer>
    {
        void BindDdl(ref DropDownList ddl,ref string pMsg,string pAccYr,Int16? pCompany_key);
    }
}
