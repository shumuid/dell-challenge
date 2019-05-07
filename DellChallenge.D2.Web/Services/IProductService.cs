using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        ProductModel Get(int id);
        ProductModel Add(NewProductModel newProduct);
        void Delete(int id);
        void Update(int id, NewProductModel productToUpdate);
    }
}