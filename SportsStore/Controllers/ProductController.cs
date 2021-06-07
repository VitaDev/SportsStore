namespace SportsStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SportsStore.Models;

    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List() => this.View(this.repository.Products);
    }
}
