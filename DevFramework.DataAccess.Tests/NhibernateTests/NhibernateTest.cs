﻿using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.DataAccess.Tests.NhibernateTests
{
    [TestClass]
    public class NhibernateTest
    {
        [TestClass]
        public class NhibernateTests
        {
            [TestMethod]
            public void Get_all_returns_all_products()
            {
                NhProductDal productDal = new NhProductDal(new SqlServerHelper());

                var result = productDal.GetList();

                Assert.AreEqual(81, result.Count);
            }
            [TestMethod]
            public void Get_all_with_paramater_returns_filtered_products()
            {
                NhProductDal productDal = new NhProductDal(new SqlServerHelper());

                var result = productDal.GetList(p => p.ProductName.Contains("ab"));

                Assert.AreEqual(4, result.Count);
            }
        }
    }
}