using DidactCore.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DidactEngine.Services.Contexts
{
    public partial class DidactDbContext : DbContext
    {
        public DidactDbContext() { }

        public DidactDbContext(DbContextOptions<DidactDbContext> options) : base(options) { }

        public virtual DbSet<StrictQueue> StrictQueues { get; set; } = null!;

        public virtual DbSet<StrictQueueItem> StrictQueueItems { get; set; } = null!;

        public virtual DbSet<Flow> Flows { get; set; } = null!;

        public virtual DbSet<FlowRun> FlowRuns { get; set; } = null!;

        public virtual DbSet<FlowSchedule> FlowSchedules { get; set; } = null!;

        public virtual DbSet<Organization> Organizations { get; set; } = null!;

        public virtual DbSet<ScheduleType> ScheduleTypes { get; set; } = null!;

        public virtual DbSet<HyperQueue> HyperQueues { get; set; } = null!;

        public virtual DbSet<HyperQueueItem> HyperQueueItems { get; set; } = null!;

        public virtual DbSet<State> States { get; set; } = null!;

        public virtual DbSet<TriggerType> TriggerTypes { get; set; } = null!;

        public virtual DbSet<ExecutionMode> ExecutionModes { get; set; } = null!;

        public virtual DbSet<Engine> Engines { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .AddUserSecrets(GetType().Assembly)
                    .AddEnvironmentVariables()
                    .Build();

                var connectionString = configuration.GetConnectionString("Didact");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException("A connection string was not found for the Didact database.");
                }

                var csBuilder = new SqlConnectionStringBuilder(connectionString)
                {
                    ApplicationName = "Didact",
                    PersistSecurityInfo = true,
                    MultipleActiveResultSets = true,
                    WorkstationID = System.Environment.MachineName,
                    TrustServerCertificate = true
                };

                var databaseProvider = configuration.GetSection("Didact").GetValue<string>("DatabaseProvider");
                switch (databaseProvider)
                {
                    case "SqlServer":
                        optionsBuilder.UseSqlServer(csBuilder.ConnectionString);
                        break;
                    case "PostgreSQL":
                        //optionsBuilder.UsePostgreSQL
                    default:
                        optionsBuilder.UseSqlServer(csBuilder.ConnectionString);
                        break;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.StrictQueueConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StrictQueueItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FlowConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FlowRunConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FlowScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.OrganizationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ScheduleTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.HyperQueueConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.HyperQueueItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TriggerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StateConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EngineConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
