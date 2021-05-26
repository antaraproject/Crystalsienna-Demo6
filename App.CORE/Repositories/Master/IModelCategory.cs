using App.CORE.Domain.Master;
using System;
using System.Web.UI.WebControls;

namespace App.CORE.Repositories.Master
{
    public interface IModelCategory : IRepository<EntityModelCategory>
    {
        void BindDdl(ref DropDownList ddl, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
