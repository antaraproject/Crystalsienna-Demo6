using System;
using System.Data;

namespace App.CORE.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        //TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //// This method was not in the videos, but I thought it would be useful to add.
        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);

        DataTable Get<T>(String pMode, T pKey, String pSEARCH_TEXT, ref String pMsg, String pAccYr, Int16? pCompany_key);

        Byte SaveChanges<T1,T2>(String pMode, TEntity oEntity, T1 pValue, ref T2 pKey, ref String pMsg, String pAccYr, Int16? pCompany_key);

    }
}
