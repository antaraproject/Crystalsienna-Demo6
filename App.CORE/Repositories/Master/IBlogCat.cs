using App.CORE.Domain.Master;
using System;
using System.Web.UI.WebControls;

namespace App.CORE.Repositories.Master
{
    public interface IBlogCat : IRepository<EntityBlogCat>
    {
        void BindDdl(ref DropDownList ddl, Int32 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
