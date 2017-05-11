using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestRepository.Repository
{
    public interface IRepository<T> where T:class 
    {
        #region 单模型CRUD

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        bool Save(T entity, bool isCommit = true);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool Update(T entity, bool isCommit = true);

        #endregion
    }
}
