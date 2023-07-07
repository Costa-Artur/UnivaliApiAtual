using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;

namespace Univali.Api.Extensions;

internal static class CustomerContextExtensions
{
    public static void CustomerInitFluentApi(this ModelBuilder modelBuilder)
    {
        var customer = modelBuilder.Entity<Customer>(); 

        customer.Property(c => c.Name)
            .HasMaxLength(80)
            .IsRequired();

        customer.Property(c => c.CPF)
            .HasMaxLength(11)
            .IsFixedLength();
    }

    public static void AddressInitFluentApi(this ModelBuilder modelBuilder)
    {
        var address = modelBuilder.Entity<Address>();  

        address.Property(a => a.Street)
            .HasMaxLength(50)
            .IsRequired();

        address.Property(a => a.City)
            .HasMaxLength(50)
            .IsFixedLength();
    }

    public static void CustomerContextSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasData(
                new Customer()
                {
                    Id = 1,
                    Name = "Linus Torvalds",
                    CPF = "73473943096",

                },
                new Customer
                {
                    Id = 2,
                    Name = "Bill Gates",
                    CPF = "95395994076",
                });

        modelBuilder.Entity<Address>()
            .HasData(
                    new Address()
                    {
                        Id = 1,
                        Street = "Verão do Cometa",
                        City = "Elvira",
                        CustomerId = 1
                    },
                    new Address()
                    {
                        Id = 2,
                        Street = "Borboletas Psicodélicas",
                        City = "Perobia",
                        CustomerId = 1
                    },
                    new Address()
                    {
                        Id = 3,
                        Street = "Canção Excêntrica",
                        City = "Salandra",
                        CustomerId = 2
                    }
            );
    }
}