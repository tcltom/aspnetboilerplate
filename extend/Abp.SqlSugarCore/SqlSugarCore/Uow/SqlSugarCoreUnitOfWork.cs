using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.Transactions.Extensions;
using SqlSugar;

namespace Abp.SqlSugarCore.Uow
{
    /// <summary>
    /// Implements Unit of work for SqlSugarCore.
    /// </summary>
    public class SqlSugarCoreUnitOfWork : UnitOfWorkBase, ITransientDependency
    {
        private readonly SqlSugarClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="SqlSugarCoreUnitOfWork"/>.
        /// </summary>
        public SqlSugarCoreUnitOfWork(
            SqlSugarClient client,
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkDefaultOptions defaultOptions,
            IUnitOfWorkFilterExecuter filterExecuter)
            : base(
                  connectionStringResolver,
                  defaultOptions,
                  filterExecuter)
        {
            _client = client;
        }

        protected override void BeginUow()
        {
            if (Options.IsTransactional == true)
            {
                _client.Ado.BeginTran();
            }
        }

        public override void SaveChanges()
        {
           
        }

        public override Task SaveChangesAsync()
        {
            return Task.FromResult(0);
        }

        /// <summary>
        /// Commits transaction and closes database connection.
        /// </summary>
        protected override void CompleteUow()
        {
            SaveChanges();
            if (_client.Ado.Transaction != null)
            {
                _client.Ado.CommitTran();
            }
        }

        protected override Task CompleteUowAsync()
        {
            CompleteUow();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Rollbacks transaction and closes database connection.
        /// </summary>
        protected override void DisposeUow()
        {
            if (_client.Ado.Transaction != null)
            {
                _client.Ado.Transaction.Rollback();
                _client.Ado.Transaction.Dispose();
                _client.Ado.Transaction = null;
            }
        }
    }
}