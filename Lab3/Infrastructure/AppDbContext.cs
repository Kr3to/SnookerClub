using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    { 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            var folder = Environment.SpecialFolder.LocalApplicationData; 
            var path = Environment.GetFolderPath(folder); 
            DbPath = System.IO.Path.Join(path, "reservations.db"); 
        }

        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<MatchEntity> Matches { get; set; }
        public DbSet<HallOfFame> HallOfFame { get; set; }

        private string DbPath { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>().HasKey(p => p.Id);
            modelBuilder.Entity<MatchEntity>().HasKey(m => m.MatchId);

            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Player1)
                .WithMany(p => p.MatchesAsPlayer1)
                .HasForeignKey(m => m.Player1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MatchEntity>()
                .HasOne(m => m.Player2)
                .WithMany(p => p.MatchesAsPlayer2)
                .HasForeignKey(m => m.Player2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReservationEntity>().HasData(
                new ReservationEntity() { Id = 1, CustomerName = "John Doe", PlayTimeHours = 2, ReservationDate = new DateTime(2015, 11, 21) },
                new ReservationEntity() { Id = 2, CustomerName = "Jane Smith", PlayTimeHours = 3, ReservationDate = new DateTime(2016, 11, 21) }
            );

            modelBuilder.Entity<HallOfFame>().HasData(
                new HallOfFame { Id = 1, Name = "Ronnie O'Sullivan", Age = 45, Titles = 7 },
                new HallOfFame { Id = 2, Name = "Stephen Hendry", Age = 52, Titles = 7 },
                new HallOfFame { Id = 3, Name = "Steve Davis", Age = 63, Titles = 6 },
                new HallOfFame { Id = 4, Name = "Mark Selby", Age = 41, Titles = 4 },
                new HallOfFame { Id = 5, Name = "John Higgins", Age = 49, Titles = 4 }
            );

            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // Dodanie roli użytkownika
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = USER_ROLE_ID
            });

            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@example.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                PasswordHash = ph.HashPassword(null, "1234Abcd!"),
            };


            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            // Dodanie drugiego użytkownika
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@example.com",
                EmailConfirmed = true,
                UserName = "userexample",
                NormalizedUserName = "USEREXAMPLE",
                NormalizedEmail = "USER@EXAMPLE.COM",
                PasswordHash = ph.HashPassword(null, "user123PASSW!@#")
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);

            // Przypisanie roli USER drugiemu użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

        }
    } 
}
