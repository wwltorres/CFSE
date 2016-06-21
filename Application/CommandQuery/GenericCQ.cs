using CFSE.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.CommandQuery
{
    public class GenericCQ
    {
        protected readonly IDBContextCFSE _db;

        public GenericCQ(IDBContextCFSE db)
        {
            _db = db;
        }
    }
}
