using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogAPI.Data;
using CatalogAPI.Models;
using ApiLibrary.Core.Controllers;

namespace CatalogAPI.Controllers
{
    [ApiVersion("1")]
    public class CategoryController : BaseController<Category, int, CatalogDbContext>
    {
        public override int AcceptRange { get; set; } = 10;

        public CategoryController(CatalogDbContext context) : base(context)
        {
        }
    }
}
