using App.CORE.Domain.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace App.CORE.Repositories.Master
{
    public interface IBookingTime : IRepository<EntityBookingTime>
    {
        void BindDdl(ref DropDownList ddl, Int32 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
