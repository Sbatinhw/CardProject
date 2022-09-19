using CardProject.Bl.Models.Descriptor.Filter;
using CardProject.Data.Entity.Card.Debit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Bl.Helpers.Interfaces
{
    public interface IFilterHelper
    {
        public Task<Expression<Func<DebitCard, bool>>> CreateDebitCardFilterExpression(IEnumerable<FilterDescriptor> filters);
    }
}
