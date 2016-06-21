using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.Dto.Queries
{
    public class PaginationContainerResult
    {
        public PaginationDTO PaginationDTO { get; set; }
        public IList Data { get; set; }
    }
}
