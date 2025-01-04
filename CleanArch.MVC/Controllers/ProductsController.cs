using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService productService) 
        {
            _service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetProducts();
            return View(result);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Price")]
        ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _service.Add(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();
            var productViewModel = await _service.GetById(id);

            if (productViewModel == null) return NotFound();
            return View(productViewModel);
        }
        
        [HttpPost()]
        public IActionResult Edit([Bind("Id,Name,Description,Price")]
        ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(productViewModel);
                }
                catch (Exception ex) 
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var productViewModel = await _service.GetById(id);

            if(productViewModel == null) return NotFound();
            return View(productViewModel);
        }
        [HttpPost(), ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id) 
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productVM = await _service.GetById(id);

            if (productVM == null)
            {
                return NotFound();
            }

            return View(productVM);
        }
    }
}
