using Megasave.Application.Contracts.Persistence;
using Megasave.Persistence.Repositories;
using Megasave.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Megasave.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataConnection") ?? throw new InvalidOperationException("Connection string not found.");
            services.AddDbContext<MopaneDbContext>(options =>
                 options.UseMySql(connectionString, new MySqlServerVersion(new Version(5, 7, 41))));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IAlertRepository, AlertRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBatchRepository, BatchRepository>();
            services.AddScoped<ICashRequestRepository, CashRequestRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPayTypeRepository, PayTypeRepository>();
            services.AddScoped<ISupplierRepository, SuppliesRepository>();
            services.AddScoped<ITargetRepository, TargetRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IBatchHistoryRepository, BatchHistoryRepository>();

            return services;
        }
    }
}