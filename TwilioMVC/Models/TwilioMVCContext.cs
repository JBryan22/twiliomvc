using System;

using Microsoft.EntityFrameworkCore;


namespace TwilioMVC.Models
{
    public class TwilioMVCContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseMySql(@"Server=localhost;Port=8889;database=twiliomvc;uid=root;pwd=root;");
    }
}