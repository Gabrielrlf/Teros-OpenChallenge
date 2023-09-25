﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerosOpenBanking.Infra.Context;

namespace TerosOpenBanking.Infra.Migrations
{
    [DbContext(typeof(RequestDataContext))]
    partial class RequestDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("TerosOpenBanking.Domain.Entity.RequestDataModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discovery")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrganisationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DataModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Discovery = "testetesteteste.teste",
                            Image = "testeteste.png",
                            Name = "teste"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
