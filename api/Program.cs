using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.PropertyNamingPolicy = null);
var app = builder.Build();

// In-memory demo data
var products = new List<Product> {
    new("Wheat Seed Premium", "Seed", "P-1001"),
    new("Corn Hybrid", "Seed", "P-1002"),
    new("NPK 20-20-20", "Fertilizer", "P-2001"),
    new("Cattle Feed Premium", "Feed", "P-3001"),
};

var sales = new List<Sale> {
    new(new DateOnly(2024,1,5), "Marmara", "Wheat Seed Premium", "Cooperative", 1_250_000m, 50_000m, 50m),
    new(new DateOnly(2024,1,5), "Ege", "Corn Hybrid", "Distributor", 980_500m, 41_000m, 41m),
    new(new DateOnly(2024,1,6), "Akdeniz", "NPK 20-20-20", "Retail", 650_000m, 26_000m, 26m),
};

app.MapGet("/", () => new { Service = "BI Hybrid Demo API", Version = "v1" });
app.MapGet("/products", () => products);
app.MapGet("/sales", () => sales);
app.MapGet("/kpi/total-sales", () => new { TotalSales = sales.Sum(s => s.Amount) });
app.MapGet("/kpi/sales-by-region", () =>
    sales.GroupBy(s => s.Region).Select(g => new { Region = g.Key, TotalSales = g.Sum(x => x.Amount) }).OrderByDescending(x => x.TotalSales)
);

app.Run();

record Product(string ProductName, string ProductCategory, string SKU);
record Sale(DateOnly Date, string Region, string ProductName, string CustomerType, decimal Amount, decimal QuantityKG, decimal QuantityTON);
