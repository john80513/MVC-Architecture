using System;
using System.Linq;
using System.Linq.Expressions;

namespace AP.Models.Interface
{
    /// <summary>
    /// 代表一個Repository的interface。
    /// </summary>
    /// <typeparam name="TEntity">任意model的class</typeparam>
    public interface IUnitOfWorkRepository<TEntity>
    {
        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="instance">要新增到的Entity</param>
        void Create(TEntity instance);

        /// <summary>
        /// 取得第一筆符合條件的內容。如果符合條件有多筆，也只取得第一筆。
        /// </summary>
        /// <param name="predicate">要取得的Where條件。</param>
        /// <returns>取得第一筆符合條件的內容。</returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 取得Entity全部筆數的IQueryable。
        /// </summary>
        /// <returns>Entity全部筆數的IQueryable。</returns>
        IQueryable<TEntity> GetBy();

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="instance">要更新的內容</param>
        void Update(TEntity instance);

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="instance">要被刪除的Entity。</param>
        void Delete(TEntity instance);

        /// <summary>
        /// 儲存異動。
        /// </summary>
        void SaveChanges();
    }
}
