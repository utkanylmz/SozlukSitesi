using Microsoft.EntityFrameworkCore;
using SozlukWebSitesiApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesi.Infrastructure.Persistence.Context
{
    public class SozlukSitesiContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public SozlukSitesiContext()
        {
            
        }
        public SozlukSitesiContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites  { get; set; }
        public DbSet<EMailConfirmation> EMailConfirmations  { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = "Server=DESKTOP-O1SR9H9;Database=SozlukSitesi; Trusted_Connection=True;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
        //Base Entitydedeki dateTime CreteDate alanını her seferinde vermek yerine tam veriyi veri tabanına kaydetmeden önce
        //otomatik verilmesini sağlıyoruz savechanges metodunu ovveride ederek.
        public override int SaveChanges()
        {
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSave()
        {
            var addedEntites = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntities(addedEntites);
        }

        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {   
                if(entity.CreateDate==DateTime.MinValue)
                entity.CreateDate = DateTime.Now;
            }
        }

    }
}
