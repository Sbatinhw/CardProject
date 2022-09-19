using CardProject.Bl.Models.Card.Debit;
using CardProject.Bl.Models.Descriptor.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Bl.Services.Interfaces.Card.Debit
{
    public interface IDebitCardService
    {
        public Task Create(DebitCardModel item);
        public Task<ICollection<DebitCardModel>> Get(ICollection<FilterDescriptor> filters);
        public Task Update(DebitCardModel item);
        public Task Delete(DebitCardModel item);

    }
}
