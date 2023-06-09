﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS03;database=CoreBlogDb;integrated security=true;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Server=CoreBlogDb.mssql.somee.com;database=CoreBlogDb;user=amineeatmc_SQLLogin_1;password=kvowlvto9q; integrated security=true;TrustServerCertificate=True;Trusted_Connection=False");
            //optionsBuilder.UseSqlServer("workstation id=CoreBlogDb.mssql.somee.com;packet size=4096;user id=amineeatmc_SQLLogin_1;pwd=kvowlvto9q;data source=CoreBlogDb.mssql.somee.com;persist security info=False;initial catalog=CoreBlogDb TrustServerCertificate=True");
            //workstation id = CoreBlogDb.mssql.somee.com; packet size = 4096; user id = amineeatmc_SQLLogin_1; pwd = kvowlvto9q; data source = CoreBlogDb.mssql.somee.com; persist security info = False; initial catalog = CoreBlogDb
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Message2>()
                .HasOne(x=>x.SenderUser)
                .WithMany(y=>y.WriterSender)
                .HasForeignKey(z=>z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
               .HasOne(x => x.ReceiverUser)
               .WithMany(y => y.WriterReceiver)
               .HasForeignKey(z => z.ReceiverID)
               .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Blog>().ToTable(tb => tb.HasTrigger("AddBlogInRatingTable"));
            modelBuilder.Entity<Comment>().ToTable(tb => tb.HasTrigger("AddScoreInComment"));
        }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Writer>Writers{ get; set; }
        public DbSet<NewsLetter>NewsLetters{ get; set; }
        public DbSet<BlogRaiting>BlogRaitings{ get; set; }
        public DbSet<Notification>Notifications{ get; set; }
        public DbSet<Message>Messages{ get; set; }
        public DbSet<Message2>Message2s{ get; set; }
        public DbSet<Admin>Admins{ get; set; }


    }
}
