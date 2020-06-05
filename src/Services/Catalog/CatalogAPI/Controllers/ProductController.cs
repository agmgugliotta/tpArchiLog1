using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CatalogAPI.Data;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class ProductController : ControllerBase
    {
        private readonly CatalogDbContext _db;
        public ProductController(CatalogDbContext db)
        {
            _db = db;
        }

        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProducts()
        {
            var products = _db.Products.Where(x => x.DeletedAt == null);

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> PostProduct([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                return Created("", product);
            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.ID == id);
            if (product == null)
                return NotFound();
            _db.Remove(product);
            //product.DeletedAt = DateTime.Now;

            await _db.SaveChangesAsync();
            return NoContent();
        }


        /*[HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ApiVersion("1", Deprecated = true)]
        public async Task<ActionResult> GetProducts()
        {
            return Ok(new List<Product>());
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ApiVersion("2")]
        public async Task<ActionResult> GetProducts_V2()
        {
            return Ok(null);
        }*/
    }
}
