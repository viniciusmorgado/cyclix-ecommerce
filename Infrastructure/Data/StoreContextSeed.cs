using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                #region ProductBrand
                // Se context não tiver algum (any) ProductBrand em nosso banco de dados.
                if (!context.ProductBrand.Any())
                {
                    // Ler todo o texto do arquivo json brands.json e armazenar na variavel brandsData
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    // Serializa todo conteúdo que está dentro do arquivo json.
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // Para cada item serializado a partir do arquivo json armazenado em brands.
                    foreach (var item in brands)
                    {
                        // Nosso context ira rastrear tudo que adicionarmos ao productbrand.
                        context.ProductBrand.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                #endregion

                #region ProductType
                if (!context.ProductType.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductType.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                #endregion

                #region Product
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
                #endregion
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}