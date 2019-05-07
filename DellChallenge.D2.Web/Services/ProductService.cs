﻿using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<ProductModel> GetAll()
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Get(int id)
        { 
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest($"products/{id}", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public void Delete(int id)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest($"products/{id}", Method.DELETE, DataFormat.Json);
            var apiResponse = apiClient.Execute(apiRequest);
        }

        public void Update(int id, NewProductModel productToUpdate)
        {
            var apiClient = new RestClient("http://localhost:2534/api");
            var apiRequest = new RestRequest($"products/{id}", Method.PUT, DataFormat.Json);
            apiRequest.AddJsonBody(productToUpdate);
            var apiResponse = apiClient.Execute(apiRequest);
        }
    }
}
