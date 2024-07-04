using AutoMapper;
using ENTPROG_XTIS3_Abo.Models;
using ENTPROG_XTIS3_Abo.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ENTPROG_XTIS3_Abo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(XProductRepository productrepository, IMapper mapper)
        {
            _productRepository = (ProductRepository?)productrepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            var productViewModels = _mapper.Map<IEnumerable<ProductsViewModel>>(products);
            return View(productViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductsViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.GetByNameDescriptionUnit(productViewModel.Name, productViewModel.Description, productViewModel.Unit);
                if (product != null)
                {
                    product.Qty += 1;
                    product.DateModified = DateTime.Now;
                    _productRepository.Update(product);
                }
                else
                {
                    productViewModel.Qty = 1;
                    productViewModel.DateAdded = DateTime.Now;
                    product = _mapper.Map<Products>(productViewModel);
                    _productRepository.Add(product);
                }
                _productRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = _mapper.Map<ProductsViewModel>(product);
            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductsViewModel productViewModel)
        {
            if (id != productViewModel.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Products>(productViewModel);
                _productRepository.Update(product);
                _productRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(productViewModel);
        }

        public IActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var productViewModel = _mapper.Map<ProductsViewModel>(product);
            return View(productViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Delete(id);
            _productRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
