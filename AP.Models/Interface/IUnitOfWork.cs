﻿using System.Data.Entity;

namespace AP.Models.Interface
{
    public interface IUnitOfWork
    {
        DbContext Context { get; set; }
        void Commit();

        /// <summary>
        /// 取得某一個 Entity 的 Repository。
        /// 如果沒有取過，會 initialise 一個，如果有就取得之前 initialise 的。
        /// </summary>
        /// <typeparam name="TEntity"> Context 裡面 Entity Type </typeparam>
        /// <returns> Entity 的 Repository </returns>
        IUnitOfWorkRepository<TEntity> UoWRepository<TEntity>()
            where TEntity : class;
    }
}
