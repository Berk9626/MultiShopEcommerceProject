using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _CargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal CargoCompanyDal)
        {
            _CargoCompanyDal = CargoCompanyDal;
        }

        public void TDelete(int id)
        {
            _CargoCompanyDal.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _CargoCompanyDal.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _CargoCompanyDal.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _CargoCompanyDal.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _CargoCompanyDal.Update(entity);
        }
    }
}
