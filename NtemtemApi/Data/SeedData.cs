using System;
using System.Linq;
using NtemtemApi.Models;

namespace NtemtemApi.Data
{
    public static class SeedData
    {
        public static void Initialize(NtemtemApiContext context)
        {
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(
                    new Organization
                    {
                        Id = 0,
                        Name = "Philton Dental Services",
                        Details = "Philton Dental Services is dedicated to providing comprehensive dental services nationwide. Book an appointment with us today.",
                        Phone = "233202442452",
                        Country = "Ghana",
                        City = "Accra",
                        Address = "Hs. No. 18 Naa Ata Street, Tesano",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    },
                    new Organization
                    {
                        Id = 0,
                        Name = "Esther Decorations",
                        Details = "Esther Decorations is the best at wedding decorations, bachelorette parties, naming ceremonies, and many more. Make a booking today. Esther Decorations - Decorating our memories of life!",
                        Phone = "233553995074",
                        Country = "Ghana",
                        City = "Accra",
                        Address = "Pent Street 123, Gbawe",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}