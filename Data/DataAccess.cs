using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace Interview.Data
{
    public class DataAccess
    {
        public DataAccess(DataAccessOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            ConnectionString = options.ConnectionString;
        }

        public DataAccess(string connection) : this(new DataAccessOptions { ConnectionString = connection })
        {
        }

        protected string ConnectionString { get; }

        public Table<TEntity> GetTable<TEntity>() where TEntity : class
        {
            Table<TEntity> table = null;

            Transaction(context =>
            {
                table = context.GetTable<TEntity>();
            });

            return table;
        }

        public void InsertAll<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Transaction(ctx =>
            {
                var table = ctx.GetTable<TEntity>();

                table.InsertAllOnSubmit(entities);
            });
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            Transaction(ctx =>
            {
                var table = ctx.GetTable<TEntity>();

                table.InsertOnSubmit(entity);
            });
        }

        public List<TResult> Query<TEntity, TResult>(Func<IQueryable<TEntity>, IQueryable<TResult>> query) where TEntity : class
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            List<TResult> result = null;
            Transaction(ctx =>
            {
                var table = ctx.GetTable<TEntity>();
                result = query(table).ToList();
            });

            return result;
        }

        public void Transaction<TEntity>(Action<DataContext, Table<TEntity>> transaction) where TEntity : class
        {
            Transaction(ctx =>
            {
                var table = ctx.GetTable<TEntity>();
                transaction?.Invoke(ctx, table);
            });
        }

        public void Transaction(Action<DataContext> transaction, bool submitChanges = true)
        {
            using (var context = new DataContext(ConnectionString))
            {
                transaction?.Invoke(context);

                if (submitChanges)
                {
                    context.SubmitChanges();
                }
            }
        }

        public bool TableExists<TEntity>() where TEntity : class
        {
            bool tableExists = false;
            Transaction(context =>
            {
                if (!context.DatabaseExists())
                {
                    tableExists = false;
                    return;
                }

                try
                {
                    _ = context.GetTable<TEntity>().ToList();
                    tableExists = true;
                }
                catch (SqlException)
                {
                    tableExists = false;
                }
            }, false);

            return tableExists;
        }
    }
}
