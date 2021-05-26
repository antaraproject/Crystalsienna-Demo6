using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using App.CORE.Domain.Setup;

namespace App.CORE.Repositories.Setup
{
    public interface ISysUser : IRepository<EntitySysUser>
    {
        DataTable Get<T>(String pMode, T pKey, String pSEARCH_TEXT, Int16 pCompanyKey, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
