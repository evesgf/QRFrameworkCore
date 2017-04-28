using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestCoreEF.Core;
using TestCoreEF.Dao;

namespace TestCoreEF.Repository
{
    /// <summary>
    /// 仓储实现类
    /// </summary>
    public class Repository<T> : IRepository<T> where T : class
    {
        #region 数据上下文
        private TestDBContext _context;

        UnitOfWork _unitOfWork;

        public Repository(TestDBContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }
        #endregion

        #region 单模型 CRUD 操作

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        public bool Save(T entity, bool isCommit = true)
        {
            _context.Add(entity);
            if (isCommit)
                return _unitOfWork.Commit();
            else
                return false;
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        public bool Update(T entity, bool isCommit = true)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            if (isCommit)
                return _unitOfWork.Commit();
            else
                return false;
        }

        /// <summary>
        /// 增加或者更新一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isSave">是否增加</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        public bool SaveOrUpdate(T entity, bool isSave, bool isCommit = true)
        {
            return isSave ? Save(entity, isCommit) : Update(entity, isCommit);
        }

        /// <summary>
        /// 通过Lamda表达式获取实体
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().SingleOrDefault(predicate);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity">实体模型</param>
        /// <param name="isCommit">是否提交（默认提交）</param>
        /// <returns></returns>
        public bool Delete(T entity, bool isCommit = true)
        {
            if (entity == null) return false;
            _context.Remove(entity);

            if (isCommit)
                return _unitOfWork.Commit();
            else
                return false;
        }

        #endregion
    }
}
