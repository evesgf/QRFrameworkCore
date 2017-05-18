using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestCoreEF.Repository
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository<T>where T:class
    {
        #region 单模型操作
        /// <summary>
        /// 新增一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool Save(T entity, bool isCommit = true);

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool Update(T entity, bool isCommit = true);

        /// <summary>
        /// 增加或更新一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool SaveOrUpdate(T entity, bool isSave, bool isCommit = true);

        /// <summary>
        /// 通过lamda表达式获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        bool Delete(T entity, bool isCommit = true);
        #endregion
    }
}
