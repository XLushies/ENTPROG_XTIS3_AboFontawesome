using ENTPROG_XTIS3_Abo.Models;

namespace ENTPROG_XTIS3_Abo.Repositories
{
    public class ProductRepository : XProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Products> GetAll()
        {
            return _context.ProductsINV.ToList();
        }

        public Products GetById(int id)
        {
            return _context.ProductsINV.Find(id);
        }

        public void Add(Products product)
        {
            _context.ProductsINV.Add(product);
        }

        public void Update(Products product)
        {
            var existingProduct = _context.ProductsINV.Find(product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Unit = product.Unit;
                existingProduct.Qty = product.Qty;
                existingProduct.DateModified = System.DateTime.Now;
                _context.ProductsINV.Update(existingProduct);
            }
        }

        public void Delete(int id)
        {
            var product = _context.ProductsINV.Find(id);
            if (product != null)
            {
                _context.ProductsINV.Remove(product);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ProductExists(int id)
        {
            return _context.ProductsINV.Any(e => e.ProductID == id);
        }

        public Products GetByNameDescriptionUnit(string name, string description, string unit)
        {
            return _context.ProductsINV.FirstOrDefault(p => p.Name == name && p.Description == description && p.Unit == unit);
        }
    }
}
