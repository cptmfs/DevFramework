﻿using DevFramework.Coree.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Entities.Concrete
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        
    }
}
