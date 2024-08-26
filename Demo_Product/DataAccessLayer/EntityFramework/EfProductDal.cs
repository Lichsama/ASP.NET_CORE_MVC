using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal:GenericRepository<Product>, IProductDal
    {

    }
}
