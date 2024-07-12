using IDCJupiterLoadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
namespace IDCJupiterLoadCommon
{
    public sealed class TransactionUtility : BaseData
    {
        public enum OperationType
        {
            Add,
            Update,
            Delete,
            Select,
            Supress
        }

        public static TransactionScope GetTransactionScope(OperationType operationType)
        {
            TransactionScope result = null;
            switch (operationType)
            {
                case OperationType.Add:
                    result = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = TimeSpan.FromSeconds(180.0)
                    });
                    break;
                case OperationType.Update:
                    result = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = TimeSpan.FromSeconds(180.0)
                    });
                    break;
                case OperationType.Delete:
                    result = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.ReadCommitted,
                        Timeout = TimeSpan.FromSeconds(180.0)
                    });
                    break;
                case OperationType.Supress:
                    result = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions
                    {
                        IsolationLevel = IsolationLevel.Unspecified,
                        Timeout = TimeSpan.FromSeconds(180.0)
                    });
                    break;
            }

            return result;
        }
    }
}
