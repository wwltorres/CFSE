using System;
using System.Linq;
using CFSE.Application.Interface;
using CFSE.Application.Dto.Queries;
using System.Linq.Dynamic;
using System.Collections;

namespace CFSE.Application.CommandQuery
{
    public class GenericQuery : GenericCQ
    {
        public IQueryable _query;
        public PaginationDTO _PDTO;
        public string _sort;
        public int _total = 0;

        public GenericQuery(IDBContextCFSE db) : base(db){ }

        public void Init(IQueryable query, PaginationDTO pDTO, string sort)
        {
            _query = query;
            _PDTO = pDTO;
            _sort = sort;

            count();
            ApplyPagination();
            ApplySort();
        }

        public void count()
        {
            _total = (_PDTO != null) ? _query.Count() : _total;
        }

        public void ApplyPagination()
        {
            if (_PDTO != null)
            {
                _query.Skip((_PDTO.Offset - 1) * _PDTO.Limit);
                _query.Take(_PDTO.Limit);
            }
        }
        
        public void ApplySort()
        {
            if (!string.IsNullOrEmpty(_sort))
            {
                _query.OrderBy(_sort);
            }
        }

        public Object BuildResult(IList list)
        {
            Object result; 

            if(_PDTO != null)
            { 
                // Pagination Results
                PaginationContainerResult pResult = new PaginationContainerResult();

                _PDTO.Total = _total;
                _PDTO.TotalPage = _total / _PDTO.Limit;
                pResult.PaginationDTO = _PDTO;
                pResult.Data = list;

                result = pResult;
            }
            else
            { 
                // List Results
                result = list;
            }
            
            return result;
        }
        
    }
}
