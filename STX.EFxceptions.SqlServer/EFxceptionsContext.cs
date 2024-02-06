﻿// ----------------------------------------------------------------------------------
// Copyright(c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.Core;
using STX.EFxceptions.Interfaces.Brokers.DbErrorBroker;
using STX.EFxceptions.Interfaces.Services.EFxceptions;
using STX.EFxceptions.SqlServer.Base.Brokers.DbErrorBroker;
using STX.EFxceptions.SqlServer.Base.Services.Foundations;

namespace STX.EFxceptions.SqlServer
{
    public class EFxceptionsContext : DbContextBase<SqlException>
    {
        public EFxceptionsContext(DbContextOptions<EFxceptionsContext> options)
            : base(options)
        { }

        protected EFxceptionsContext()
            : base()
        { }

        protected override IDbErrorBroker<SqlException> CreateErrorBroker() =>
            new SqlServerErrorBroker();

        protected override IEFxceptionService CreateEFxceptionService(
            IDbErrorBroker<SqlException> errorBroker)
        {
            return new SqlServerEFxceptionService(errorBroker);
        }
    }
}
