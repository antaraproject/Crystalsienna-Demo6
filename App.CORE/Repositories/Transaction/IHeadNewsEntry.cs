using System;
using System.Web.UI.WebControls;
using App.CORE.Domain;
using App.CORE.Domain.Transaction;

namespace App.CORE.Repositories.Transaction
{
    public interface IHeadNewsEntry : IRepository<EntityHeadNewsEntry>
    {
        void BindDdl(String pMode, ref DropDownList ddl, String pKey, ref String pMsg, String pAccYr, Int16? pCompany_key);
    }
}
