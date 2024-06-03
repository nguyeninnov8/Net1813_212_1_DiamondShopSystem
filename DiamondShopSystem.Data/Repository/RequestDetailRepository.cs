using DiamondShopSystem.Data.Base;
using DiamondShopSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShopSystem.Data.Repository
{
    public class RequestDetailRepository : GenericRepository<RequestDetail>
    {
        public RequestDetailRepository()
        {
        }

        public RequestDetailRepository(Net1804_212_1_DiamondShopSystemContext context) => _context = context;
    }
}
