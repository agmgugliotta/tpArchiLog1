using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApiLibrary.Core.Controllers;
using CatalogAPI.Core.Entity;
using CatalogAPI.Data;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [ApiVersion("1")]
    public class ProductController : BaseController<Product, int, CatalogDbContext>
    {
        public override int AcceptRange { get; set; } = 25;

        public ProductController(CatalogDbContext db) : base(db)
        {
        }

    }
}
