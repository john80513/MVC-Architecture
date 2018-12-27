﻿using LinqKit;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AP.Service.Helper
{
    public static class PredHelper
    {
        // 將字串條件自動以 Contains 方式加入搜尋條件    
        public static ExpressionStarter<TEntity> GetPred<TEntity, SearchModel>(SearchModel searchParameter)
        {
            var pred = PredicateBuilder.New<TEntity>(true);

            if (searchParameter == null)
            {
                return pred;
            }

            foreach (PropertyInfo item in searchParameter.GetType().GetProperties())
            {
                string ColumnName = item.Name;

                if (item.PropertyType == typeof(string) && typeof(TEntity).GetProperty(ColumnName) != null)
                {
                    var Value = item.GetValue(searchParameter, null);

                    if (Value != null)
                    {
                        Type DbType = typeof(TEntity).GetProperty(ColumnName).PropertyType;
                        Type ParaType = item.PropertyType;

                        if (DbType == ParaType)
                        {
                            MethodInfo method = typeof(TEntity).GetProperty(ColumnName).PropertyType.GetMethod("Contains", new[] { DbType });
                            var someValue = Expression.Constant(Value, DbType);
                            var parameterExp = Expression.Parameter(typeof(TEntity), "type");
                            var propertyExp = Expression.Property(parameterExp, ColumnName);
                            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

                            pred = pred.And(Expression.Lambda<Func<TEntity, bool>>(containsMethodExp, parameterExp));
                        }
                    }
                }
            }
            return pred;
        }
    }
}








