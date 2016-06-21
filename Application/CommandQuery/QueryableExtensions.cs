using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Application.CommandQuery
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortFields)
        {
            var expression = source.Expression;
            int count = 0;

            List<SortModel> sortModels = buildQueryFieldSort(sortFields);


            foreach (var item in sortModels)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, item.ColId);
                var method = string.Equals(item.Sort, "desc", StringComparison.OrdinalIgnoreCase) ?
                    (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                    (count == 0 ? "OrderBy" : "ThenBy");
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
            }
            return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;
        }

        private static List<SortModel> buildQueryFieldSort(string sort)
        {
            List<SortModel> smList = new List<SortModel>();

            List<string> sortList = (!string.IsNullOrEmpty(sort)) ? sort.Split(',').ToList<string>() : null;

            foreach (string s in sortList ?? Enumerable.Empty<string>())
            {
                SortModel sm = prepareFieldSort(s);

                smList.Add(sm);
            }

            return smList;
        }

        private static SortModel prepareFieldSort(string field)
        {
            SortModel sm = new SortModel();

            if (field.StartsWith("-"))
            {
                sm.ColId = field.Substring(1);
                sm.Sort = "desc";
            }
            else
            {
                sm.ColId = field;
            }

            return sm;
        }
    }
    
    public class SortModel
    {
        public string Sort { get; set; }
        public string ColId { get; set; }
        
    }
}
