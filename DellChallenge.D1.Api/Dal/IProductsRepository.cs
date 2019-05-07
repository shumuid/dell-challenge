using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProduct(int id);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}
