using CRUD_DEMO.Data;
using CRUD_DEMO.Models;
using CRUD_DEMO.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DEMO.Controllers
{
    //localhost:xxxx/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            var allProducts = dbContext.Products.ToList();

            return Ok(allProducts);
        }

        [HttpGet("getProductById/{id:guid}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if(product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("addProduct")]
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var productEntity = new Product()
            {
                Nombre = addProductDto.Nombre,
                Detalles = addProductDto.Detalles,
                Precio = addProductDto.Precio,
                Cantidad = addProductDto.Cantidad,
            };

            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();

            return Ok(productEntity);
        }

        [HttpPut("updateProduct/{id:guid}")]
        public IActionResult UpdateProduct(Guid id, UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            product.Nombre = updateProductDto.Nombre;
            product.Detalles = updateProductDto.Detalles;
            product.Precio = updateProductDto.Precio;
            product.Cantidad = updateProductDto.Cantidad;

            dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpPut("sellProduct/{id:guid}")]
        public IActionResult SellProduct(Guid id, SellProductDto sellProductDto)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            if (product.Cantidad < sellProductDto.Cantidad)
            {
                return BadRequest(new { message = "No hay cantidad suficiente de productos en stock." });
            }


            product.Cantidad = product.Cantidad - sellProductDto.Cantidad;

            dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("deleteProduct/{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = dbContext.Products.Find(id);

            if (product is null)
            {
                return NotFound();
            }

            dbContext.Products.Remove(product);

            dbContext.SaveChanges();
            return Ok(product);
        }
    }
}
