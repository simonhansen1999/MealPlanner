using Madplan.Authentication;
using Madplan.Models;
using Microsoft.EntityFrameworkCore;

namespace Madplan.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<FoodPlan> FoodPlans { get; set; }
        public DbSet<FamilyGroup> FamilyGroups { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========================
            // AppUser
            // ========================
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(u => u.Role)
                      .IsRequired();

                // One-to-one: User -> Settings
                entity.HasOne(u => u.Settings)
                      .WithOne()
                      .HasForeignKey<AppUserSettings>(s => s.AppUserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.ShoppingLists)
                      .WithOne()
                      .HasForeignKey(g => g.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(r => r.FavoriteFoods)
                     .WithOne()
                     .HasForeignKey(g => g.UserId)
                     .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(u => u.Email).IsUnique();
            });

            // ========================
            // FamilyGroup -> Members
            // ========================
            modelBuilder.Entity<FamilyGroup>()
                .HasMany(fg => fg.Members)
                .WithOne()
                .HasForeignKey(m => m.FamilyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FamilyGroup>()
                .Property(fg => fg.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FamilyMember>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FamilyMember>()
                .HasIndex(m => new { m.FamilyId, m.Email })
                .IsUnique();

            // ========================
            // Food -> Recipe (one-to-one)
            // ========================
            modelBuilder.Entity<Food>()
                .HasOne(f => f.Recipe)
                .WithOne()
                .HasForeignKey<Recipe>(r => r.FoodId);

            // Recipe -> IngredientGroups (one-to-many)
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.IngredientGroups)
                .WithOne()
                .HasForeignKey(g => g.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Food properties
            modelBuilder.Entity<Food>()
                .Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(100);

            // ========================
            // ShoppingList -> AggregatedItems
            // ========================
            modelBuilder.Entity<ShoppingList>()
                .HasMany(sl => sl.AggregatedItems)
                .WithOne()
                .HasForeignKey(ag => ag.ShoppingListId);

            // ========================
            // FoodPlan -> Foods
            // ========================
            modelBuilder.Entity<FoodPlan>()
                .HasMany(p => p.Foods)
                .WithOne()
                .HasForeignKey(f => f.FoodPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // FoodPlan -> Single-user shares
            modelBuilder.Entity<FoodPlan>()
                .HasMany(p => p.SharedWith)
                .WithOne()
                .HasForeignKey(s => s.FoodPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // FoodPlan -> FamilyGroup shares (JOIN entity)
            modelBuilder.Entity<FoodPlan>()
                .HasMany(p => p.SharedWithFamilyGroups)
                .WithOne()
                .HasForeignKey(s => s.FoodPlanId)
                .OnDelete(DeleteBehavior.Cascade);

            // FoodPlanFamilyShare
            modelBuilder.Entity<FoodPlanFamilyGroupShare>()
                .HasOne<FamilyGroup>()
                .WithMany()
                .HasForeignKey(s => s.FamilyGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodPlanFamilyGroupShare>()
                .HasMany(x => x.IndividualPermissions)
                .WithOne()
                .HasForeignKey(x => x.FoodPlanFamilyGroupShareId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodPlanFamilyGroupShare>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<FoodPlanFamilyGroupShare>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // IndividualPermission
            modelBuilder.Entity<IndividualPermission>()
              .HasKey(f => f.Id);

            modelBuilder.Entity<IndividualPermission>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            // ========================
            // Optional: FoodPlanFamilyGroupShare uniqueness
            // ========================
            modelBuilder.Entity<FoodPlanFamilyGroupShare>()
                .HasIndex(s => new { s.FoodPlanId, s.FamilyGroupId })
                .IsUnique();
        }
    }
}
