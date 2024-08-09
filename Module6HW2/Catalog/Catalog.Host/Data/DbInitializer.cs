using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogSizes.Any())
        {
            await context.CatalogSizes.AddRangeAsync(GetPreconfiguredCatalogSizes());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogGenders.Any())
        {
            await context.CatalogGenders.AddRangeAsync(GetPreconfiguredCatalogGenders());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogBrands.Any())
        {
            await context.CatalogBrands.AddRangeAsync(GetPreconfiguredCatalogBrands());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogTypes.Any())
        {
            await context.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTypes());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            var sizes = context.CatalogSizes.ToList();

            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems(sizes));

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogSize> GetPreconfiguredCatalogSizes()
    {
        return new List<CatalogSize>()
        {
            new CatalogSize() { Size = "S" },
            new CatalogSize() { Size = "M" },
            new CatalogSize() { Size = "L" },
            new CatalogSize() { Size = "XL" },
            new CatalogSize() { Size = "XXL" },
            new CatalogSize() { Size = "39" },
            new CatalogSize() { Size = "40" },
            new CatalogSize() { Size = "41" },
        };
    }

    private static IEnumerable<CatalogGender> GetPreconfiguredCatalogGenders()
    {
        return new List<CatalogGender>()
        {
            new CatalogGender() { Gender = "Men" },
            new CatalogGender() { Gender = "Woman" },
        };
    }

    private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>()
        {
            new CatalogBrand() { Brand = "VAUDE" },
            new CatalogBrand() { Brand = "Quiksilver" },
            new CatalogBrand() { Brand = "THE NORTH FACE" },
            new CatalogBrand() { Brand = "Asics" },
            new CatalogBrand() { Brand = "HOKA" },
            new CatalogBrand() { Brand = "Mizuno" },
            new CatalogBrand() { Brand = "Saucony" },
        };
    }

    private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogType>()
        {
            new CatalogType() { Type = "Pants" },
            new CatalogType() { Type = "Jackets" },
            new CatalogType() { Type = "Shoes" },
            new CatalogType() { Type = "T-shirts" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems(List<CatalogSize> catalogSizes)
    {
        return new List<CatalogItem>()
        {
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 1).ToList(), CatalogGenderId = 1, CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 10, Description = "Features:\n• 100% recycled polyester fleece outer\n• Woven knee pads for added durability made from 100% waterproof recycled nylon\n• Knee articulation for added mobility\n• Side slit pockets\n• Secure back zip pocket\n• Elastic waistband with drawstring\n• Elastic cuffs", Name = "VAUDE Me Farley Stretch Pants II", Price = 30, PictureFileName = "1.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 2).ToList(), CatalogGenderId = 1, CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 100, Description = "Features:\n• 100% recycled polyester fleece outer\n• Woven knee pads for added durability made from 100% waterproof recycled nylon\n• Knee articulation for added mobility\n• Side slit pockets\n• Secure back zip pocket\n• Elastic waistband with drawstring\n• Elastic cuffs", Name = "Quiksilver TRACKPANT OTLR 2023", Price = 60, PictureFileName = "2.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 3).ToList(), CatalogGenderId = 1, CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 100, Description = "Features:\n• 100% recycled polyester fleece outer\n• Woven knee pads for added durability made from 100% waterproof recycled nylon\n• Knee articulation for added mobility\n• Side slit pockets\n• Secure back zip pocket\n• Elastic waistband with drawstring\n• Elastic cuffs", Name = "VAUDE Me Badile Pants II 2017", Price = 77, PictureFileName = "3.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 1).ToList(), CatalogGenderId = 1, CatalogTypeId = 1, CatalogBrandId = 3, AvailableStock = 100, Description = "The North Face Denali Men's Sweatpants in Black. Features:\n• Shell made from 100% recycled polyester (fleece)\n• Woven knee pads for added durability made from 100% waterproof recycled nylon\n• Knee articulation for added mobility\n• Side slit pockets\n• Secure back zip pocket\n• Elastic waistband with drawstring\n• Elastic cuffs", Name = "THE NORTH FACE DENALI PANT 2024", Price = 115, PictureFileName = "4.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 2 || i.Id == 1).ToList(), CatalogGenderId = 2, CatalogTypeId = 2, CatalogBrandId = 4, AvailableStock = 100, Description = "The WINTER RUN JACKET is made from soft thermal fabric that is windproof and waterproof to keep you warm and dry. Our ASICS running expert team recommends using it in temperatures below 5\u00b0C. Enhanced warmth thanks to the soft jersey fabric. Insulating, windproof and water-repellent 3-layer softshell panel on the front. ACTIBREEZE technology for increased breathability. Adjustable back vents with easy-to-reach pullers. 2 side zip pockets and 2 large back pockets. High neck to help keep the wind out. Thumbholes on the sleeves. At least 50% of the garment’s main fabric is made from recycled content to reduce waste and carbon emissions.", Name = "Asics WINTER RUN JACKET 2024", Price = 130, PictureFileName = "5.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 3 || i.Id == 1 || i.Id == 4).ToList(), CatalogGenderId = 2, CatalogTypeId = 2, CatalogBrandId = 3, AvailableStock = 100, Description = "Shell made from 100% recycled polyester (fleece)", Name = "THE NORTH FACE W KEMPINSKI JKT'15", Price = 222, PictureFileName = "6.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 6 || i.Id == 7).ToList(), CatalogGenderId = 2, CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = "Lightweight. Airy. Incredibly comfortable.\nMore breathable than ever, the Anacapa returns with an ultra-ventilated upper and the same clear focus on durability. Designed for warmer climates, the Anacapa Low features a 100% rPET knit upper and retains the same iconic HUBBLE\u00ae heel geometry and Vibram\u00ae Megagrip outsole that made its predecessor a trail icon.\nBest suited for hiking.\n· Engineered air mesh made from 100% recycled yarn.\n· Compression molded EVA foam midsole\n· SwallowTail\u00ae heel\n· Hubble heel\u00ae geometry\n· Vibram\u00ae Megagrip rubber outsole with 5mm lugs.\n· Anatomical Achilles construction\n· Recycled polyester materials in the heel, mesh and laces\n· Molded polyurethane sockliner made from 50% soybean oil\n· Late-stage meta rocker\n· Weight: 12.4 oz / 353 g\n· Heel-to-toe drop: 6.00 mm", Name = "HOKA M ANACAPA BREEZE LOW 2023", Price = 95, PictureFileName = "7.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 6 || i.Id == 6).ToList(), CatalogGenderId = 1, CatalogTypeId = 3, CatalogBrandId = 6, AvailableStock = 100, Description = "For runners with a strong, heavy frame and people who are looking for a technical design in a running shoe. This shoe has INFINITY WAVE throughout the entire length for improved cushioning and stability. INFINITY WAVE is very famous among runners for the feeling it provides as well as the design. You will be able to run for a long time without getting tired.", Name = "Mizuno WAVE PROPHECY 13 2024", Price = 220, PictureFileName = "8.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 8 || i.Id == 7).ToList(), CatalogGenderId = 1, CatalogTypeId = 3, CatalogBrandId = 7, AvailableStock = 100, Description = "The Saucony Tempus is the first of its kind, a new approach to stability designed to guide and support your run like never before. - PWRRUN PB cushioning core delivers maximum energy return, while the molded PWRRUN frame wraps and supports your foot from heel to toe.\n- Superior midsole geometry and unmatched fit deliver a fast ride.\n- PWRRUN PB delivers maximum energy return, while the contoured PWRRUN frame delivers seamless support.\n- Signature geometry with an enlarged heel and toe contour creates a smoother, faster feel.\n- Deep midsole contours allow you to sit in the shoe, not on top of it, creating an incredibly customized and supportive fit.\n- A full-length running shoe made with ultra-lightweight PWRRUN PB cushioning for incredible bounce and energy return.\n- PWRRUN cushioning starts above the midsole to support your foot upon landing, while its curved shape and forefoot contact with the ground provide a quick transition during takeoff.\n- A more contoured midsole underfoot allows you to sit deeper in the footbed and allows the shoe to hug your foot for an incredibly soft feel from top to bottom.\n- Signature midsole geometry provides support and a super smooth ride from heel to toe.\n- Lock in the perfect fit with adaptive lacing and a lightweight midfoot saddle.\n- Lightweight, breathable mesh upper.\n- Our FORMFIT design takes into account every contact point of your foot, extending well beyond the laces to provide a customized fit and feel from top to bottom. - Durable XT-900 outsole.", Name = "Saucony TEMPUS 2024", Price = 168, PictureFileName = "9.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 1 || i.Id == 1).ToList(), CatalogGenderId = 1, CatalogTypeId = 4, CatalogBrandId = 3, AvailableStock = 100, Description = "Features FlashDry\u2122 technology that actively wicks away sweat.\n· Short sleeves.\n· Wide neck.\n· FlashDry\u2122 technology wicks away sweat and keeps you dry.\n\nMaterial: 100% polyester.", Name = "THE NORTH FACE Tanken Tank 2020", Price = 20, PictureFileName = "10.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 2 || i.Id == 1).ToList(), CatalogGenderId = 1, CatalogTypeId = 4, CatalogBrandId = 3, AvailableStock = 100, Description = "The North Face Tanken Tee with a crew neck.\n\n· Short sleeves.\n· Elasticated fit.\n· Print on the chest and back.\n\nComposition: 100% polyester.", Name = "THE NORTH FACE Tanken Tee 2020", Price = 22, PictureFileName = "11.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 4).ToList(), CatalogGenderId = 2, CatalogTypeId = 4, CatalogBrandId = 4, AvailableStock = 100, Description = "SS TOP children's T-shirt.\n\n· Made from a mixture of cotton and polyester, which has the property of drying quickly, keeping cool and comfortable.\n· Features a sporty and fashionable design.\n· Decorated with stripes on the back and the ASICS inscription on the front.\n\nComposition: 65% polyester, 35% cotton.", Name = "Asics G SS TOP 2020", Price = 12, PictureFileName = "12.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 6 || i.Id == 7 || i.Id == 8).ToList(), CatalogGenderId = 1, CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = " ", Name = "HOKA M STINSON 5 2022", Price = 140, PictureFileName = "13.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 6 || i.Id == 7 || i.Id == 8).ToList(), CatalogGenderId = 1, CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = " ", Name = "HOKA M STINSON 6 2023", Price = 172, PictureFileName = "14.jpg" },
            new CatalogItem { CatalogItemSizes = catalogSizes.Where(i => i.Id == 6 || i.Id == 7 || i.Id == 8).ToList(), CatalogGenderId = 1, CatalogTypeId = 3, CatalogBrandId = 5, AvailableStock = 100, Description = " ", Name = "HOKA M STINSON 7 2024", Price = 215, PictureFileName = "15.jpg" },
        };
    }
}