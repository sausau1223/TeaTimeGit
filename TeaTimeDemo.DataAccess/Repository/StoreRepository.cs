using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.Models;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;

namespace TeaTimeDemo.DataAccess.Repository
{
    public class StoreRepository: Repository<Store>, IStoreRepository
    {
        private readonly ApplicationDbContext _db;
        public StoreRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }



        public void Update(Store obj)
        {
            _db.Stores.Update(obj);
   
        }


    }
 
  
}
