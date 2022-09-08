using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProjetRedLineAG.Models;

namespace ProjetRedLineAG.Data
{
    public class ApplicationsContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public static readonly ILoggerFactory loggerFactory

                   = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public IConfiguration Configuration { get; }
        public ApplicationsContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions, IConfiguration configuration) : base(options, operationalStoreOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseLoggerFactory(loggerFactory)  //tie-up DbContext with LoggerFactory object

                .EnableSensitiveDataLogging()

                .UseSqlServer(Configuration.GetConnectionString("ApplicationsContext"));

        }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
                  modelBuilder.Entity<PersonModel>().HasOne(e => e.Entreprise).WithMany().OnDelete(DeleteBehavior.NoAction);
                  modelBuilder.Entity<PersonModel>().HasOne(e => e.Statut).WithMany().OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<PersonModel>().HasOne(e => e.Application).WithMany().OnDelete(DeleteBehavior.SetNull);                


            //    modelBuilder.Entity<List<EntrepriseModel>>().HasNoKey();
            modelBuilder.Entity<ApplicationModel>().HasData(
                      new ApplicationModel()
                      {
                          ApplicationId = 1,
                          TitleApplication = "Non renseigné"
                      }
                    );
            modelBuilder.Entity<EntrepriseModel>().HasData(
                  new EntrepriseModel()
                {
                     EntrepriseId = 1,
                     TitleEntreprise = "Non renseigné"
                 }
                );

            modelBuilder.Entity<StatutModel>().HasData(
                 new StatutModel()
                 {
                     StatutId = 1,
                     TitleStatut = "Non renseigné"
                 }
               );

            modelBuilder.Entity<PersonModel>().HasData(
              new PersonModel()
              {
                  EntrepriseId = 1,
                  Id = 1,
                  LastNamePerson = "Non renseigné",
                  StatutId = 1

              }
              ) ;
        }

        public DbSet<ApplicationModel> Application { get; set; }

        public DbSet<DocumentModel> Document { get; set; }

        public DbSet<DocumentSentModel> DocumentsSent { get; set; }

        public DbSet<PersonSentModel> PersonSent { get; set; }

        public DbSet<EntrepriseModel> Entreprise { get; set; }
        public DbSet<StatutModel> Statut { get; set; }

        public DbSet<PersonModel> Person { get; set; }
    }
}
