using CardProject.Bl.Extensions.ExpressionsExtensions;
using CardProject.Bl.Helpers.Interfaces;
using CardProject.Bl.Models.Descriptor.Filter;
using CardProject.Data.Entity.Card.Debit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Bl.Helpers.Implementations
{
    public class FilterHelper : IFilterHelper
    {
        public async Task<Expression<Func<DebitCard, bool>>> CreateDebitCardFilterExpression(IEnumerable<FilterDescriptor> filters)
        {
            Expression<Func<DebitCard, bool>> resultExpression = null;

            var idFilter = filters.Where(x => x.Member == nameof(DebitCard.Id));
            if (idFilter.Any())
            {
                filters = filters.Where(x => x.Member != nameof(DebitCard.Id));
                IList<Guid> ids = new List<Guid>(idFilter.Count());
                foreach(var filter in idFilter)
                {
                    ids.Add(new Guid(filter.Value));
                }
                Expression<Func<DebitCard, bool>> idExpression = (x => ids.Any(z => z == x.Id));

                if(resultExpression == null)
                {
                    resultExpression = idExpression;
                }
                else
                {
                    resultExpression = resultExpression.AndAlso(idExpression);
                }
            }
            

            return resultExpression;
        }
    }
}
