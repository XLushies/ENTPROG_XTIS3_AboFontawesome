using ENTPROG_XTIS3_Abo.Models;

namespace ENTPROG_XTIS3_Abo.Repositories

{
    public interface XProductRepository
    {
        IEnumerable<Products> GetAll();


        Products GetById(int id);


        void Add(Products product);


        void Update(Products product);


        void Delete(int id);


        void Save();


        Products GetByNameDescriptionUnit(string name, string description, string unit);


    }
}
