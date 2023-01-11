using DevFramework.Coree.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Coree.Aspects.Postsharp;
using DevFramework.Coree.DataAccess;
using System.Transactions;
using DevFramework.Coree.Aspects.Postsharp.TransactionAspect;
using DevFramework.Coree.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Coree.Aspects.Postsharp.CacheAspect;
using DevFramework.Coree.Aspects.Postsharp.LogAspect;
using DevFramework.Coree.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Coree.Aspects.Postsharp.PerformanceAspect;
using System.Threading;
using DevFramework.Coree.Aspects.Postsharp.AuthorizationAspects;
using AutoMapper;
using DevFramework.Coree.Utilities.Mappings;

namespace DevFramework.Northwind.Business.Concrete.Managers
{

    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly  IMapper _mapper;

        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }
        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        
        public Product Add(Product product)
        {
            
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            
            {
                    _productDal.Add(product1);
                    //Business Code
                    _productDal.Update(product2);
            }

        }
    }
}
