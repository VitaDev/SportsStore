﻿namespace SportsStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SportsStore.Models;
    using SportsStore.Models.ViewModels;

    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(int productPage = 1)
            => this.View(new ProductsListViewModel
            {
                Products = this.repository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = this.repository.Products.Count()
                }
            });
    }
}
