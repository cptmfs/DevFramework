using DevFramework.Coree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Coree.DataAccess.NHihabernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NhibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NhibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }
        public virtual IQueryable<T> Entities 
        { 
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
            //get
            //{
            //    //if (_entities==null)
            //    //{
            //    //    _entities = _nHibernateHelper.OpenSession().Query<T>();

            //    //}
            //    //return _entities;
            //} 
        }
    }
}
