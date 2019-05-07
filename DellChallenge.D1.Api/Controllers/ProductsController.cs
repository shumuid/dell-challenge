using AutoMapper;
using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository productsRepo, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productsRepo.GetAll());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [EnableCors("AllowReactCors")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productsRepo.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public async Task<IActionResult> Post([FromBody]NewProductDto newProduct)
        {
            var productToAdd = _mapper.Map<Product>(newProduct);

            _productsRepo.Add(productToAdd);

            if (await _productsRepo.SaveAll())
                return CreatedAtRoute("GetProduct", new { id = productToAdd.Id }, productToAdd);

            throw new Exception("Creating the product failed on save.");
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productsRepo.GetProduct(id);

            _productsRepo.Delete(product);

            if (await _productsRepo.SaveAll())
                return Ok();

            return BadRequest("Failed to delete the product.");
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public async Task<IActionResult> Put(int id, NewProductDto product)
        {
            var productFromRepo = await _productsRepo.GetProduct(id);

            productFromRepo.Name = product.Name;

            productFromRepo.Category = product.Category;

            if (await _productsRepo.SaveAll())
                return NoContent();

            throw new Exception($"Updating product with {id} failed on save");
        }
    }
}
