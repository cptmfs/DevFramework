using DevFramework.Coree.DataAccess.NHihabernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {

        NhibernateHelper _nhibernateHelper;
        public NhProductDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public List<ProductDetails> GetProductDetails()
        {
            using (var session=_nhibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryId
                             select new ProductDetails
                             {
                                 ProductId = p.ProductId,
                                 CategoryName = c.CategoryName,
                                 ProductName = p.ProductName
                             };
                return result.ToList();
            }
        }
    }
}
