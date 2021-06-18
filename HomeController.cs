using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Domain.Interfaces;
using MvcApplication1.Domain.DAO;
using MvcApplication1.Models;
using MvcApplication1.Domain.Entities;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController()
        {

        }

        public HomeController(IBookRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Bookstore!";

            return View();
        }

        public ActionResult List1()
        {
            //This should be injected using the Dependency Injection in the constructor above
            _repo = new TestBookRepository();
            
            return View(_repo.Books);
        }

        public ActionResult List2()
        {
            //This should be injected using the Dependency Injection in the constructor above
            _repo = new TestBookRepository();
            BooksListViewModel viewModel = new BooksListViewModel();
            viewModel.Books = _repo.Books;

            return View(viewModel);
        }

        public ActionResult Grid()
        {
            //This should be injected using the Dependency Injection in the constructor above
            _repo = new TestBookRepository();
            BooksListViewModel viewModel = new BooksListViewModel();
            viewModel.Books = _repo.Books;

            return View(viewModel);
        }

        public ActionResult DropDownSample()
        {
            //This should be injected using the Dependency Injection in the constructor above
            _repo = new TestBookRepository();
            BooksListViewModel viewModel = new BooksListViewModel();
            viewModel.Authors = _repo.Books.Select(b => b.Author).Distinct();

            return View(viewModel);
        }

        public ActionResult Edit(int Id)
        {
            _repo = new TestBookRepository();
            Book book = _repo.Books.FirstOrDefault(b => b.Id == Id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                //Save Book                
                _repo = new TestBookRepository();
                _repo.SaveBook(book);

                return RedirectToAction("Grid");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
