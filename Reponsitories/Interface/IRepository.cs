using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Reponsitories.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> Get(List<int> id);
    }
}
