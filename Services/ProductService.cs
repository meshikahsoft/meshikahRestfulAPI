using MeshikahRestfulAPI.Models;

namespace MeshikahRestfulAPI.Services;

public static class ProductService
{
    static List<Product> Products { get; }
    static int nextId = 3;
    static ProductService()
    {
        Products = new List<Product>
        {
            new Product { Id = 1, Name = "Classic Italian", IsEndorsed = false },
            new Product { Id = 2, Name = "Veggie", IsEndorsed = true }
        };
    }

    public static List<Product> GetAll() => Products;

    public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

    public static void Add(Product product)
    {
        product.Id = nextId++;
        Products.Add(product);
    }

    public static void Delete(int id)
    {
        var product = Get(id);
        if(product is null)
            return;

        Products.Remove(product);
    }

    public static void Update(Product product)
    {
        var index = Products.FindIndex(p => p.Id == product.Id);
        if(index == -1)
            return;

        Products[index] = product;
    }
}