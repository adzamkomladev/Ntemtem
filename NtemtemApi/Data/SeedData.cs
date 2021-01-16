using System;
using System.Linq;

namespace NtemtemApi.Data
{
    public static class SeedData
    {
        public static void Initialize(NtemtemApiContext context)
        {
            if (!context.Organizations.Any())
            {
                context.Organizations.AddRange(
                    new(
                        0,
                        "Philton Dental Services",
                        "Philton Dental Services is dedicated to providing comprehensive dental services nationwide. Book an appointment with us today.",
                        "233202442452",
                        "Ghana",
                        "Accra",
                        "Hs. No. 18 Naa Ata Street, Tesano",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                        null
                    ),
                    new(
                        0,
                        "Esther Decorations",
                        "Esther Decorations is the best at wedding decorations, bachelorette parties, naming ceremonies, and many more. Make a booking today. Esther Decorations - Decorating our memories of life!",
                        "233553995074",
                        "Ghana",
                        "Accra",
                        "Pent Street 123, Gbawe",
                        null,
                        DateTime.UtcNow,
                        DateTime.UtcNow,
                        null
                    )
                );

                context.SaveChanges();
            }
        }
    }
}