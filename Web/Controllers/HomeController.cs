using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;

        public HomeController(IUnitOfWork<Owner> owner,IUnitOfWork<PortfolioItem> portfolio)
        {
            this._owner = owner;
            this._portfolio = portfolio;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().FirstOrDefault(),
                PortfolioItems = _portfolio.Entity.GetAll()
            };
            return View(viewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
