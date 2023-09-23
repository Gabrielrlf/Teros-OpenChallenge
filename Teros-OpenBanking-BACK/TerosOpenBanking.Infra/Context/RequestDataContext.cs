using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerosOpenBanking.Domain.Entity;

namespace TerosOpenBanking.Infra.Context
{
    public class RequestDataContext : DbContext
    {
        public DbSet<RequestDataModel> DataModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=TerosOpenBanking.db");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RequestDataModel>()
                .HasData(
                    new RequestDataModel()
                    {
                        Id = 1,
                        Name = "teste",
                        Image = "testeteste.png",
                        Discovery = "testetesteteste.teste"
                    }
                );
        }
        }
}
