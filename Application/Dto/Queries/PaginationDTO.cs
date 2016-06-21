using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.Dto.Queries
{
    public class PaginationDTO
    {
        public int TotalPage { get; set; }
        public int Total { get; set; }
        public int Limit { get; set; } = 5;
        public int Offset { get; set; } = 1;
    }
}
