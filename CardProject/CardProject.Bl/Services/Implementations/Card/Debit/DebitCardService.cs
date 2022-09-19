using CardProject.Data.Repositories.Interfaces;
using CardProject.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardProject.Bl.Services.Interfaces.Card.Debit;
using CardProject.Bl.Models.Card.Debit;
using CardProject.Data.Entity.Card.Debit;
using CardProject.Bl.Models.Descriptor.Filter;
using CardProject.Bl.Helpers.Interfaces;

namespace CardProject.Bl.Services.Implementations.Card.Debit
{
    public class DebitCardService : IDebitCardService
    {
        //TODO: сделать медиатор
        private readonly IRepository _repository;
        private readonly IFilterHelper _filterHelper;
        private readonly IReadOnlyRepository _readOnlyRepository;

        public DebitCardService(
            IRepository repository,
            IFilterHelper filterHelper,
            IReadOnlyRepository readOnlyRepository)
        {
            _repository = repository;
            _filterHelper = filterHelper;
            _readOnlyRepository = readOnlyRepository;
        }
        public async Task Create(DebitCardModel item)
        {
            var card = new DebitCard()
            {
                Id = item.Id,
                Bill = item.Bill
            };
            _repository.Create<DebitCard>(card);
            await _repository.Save();
        }

        public async Task Delete(DebitCardModel item)
        {
            var card = new DebitCard()
            {
                Id = item.Id,
                Bill = item.Bill
            };
            _repository.Delete<DebitCard>(card);
            await _repository.Save();
        }

        public async Task<ICollection<DebitCardModel>> Get(ICollection<FilterDescriptor> filters)
        {
            var filter = await _filterHelper.CreateDebitCardFilterExpression(filters);

            var cards = await _readOnlyRepository.Get<DebitCard>(filter: filter);

            var result = Mapper(cards);

            return result;
        }

        public async Task Update(DebitCardModel item)
        {
            var card = new DebitCard()
            {
                Bill = item.Bill,
                Id = item.Id
            };

            _repository.Update<DebitCard>(card);
            await _repository.Save();
        }

        private ICollection<DebitCardModel> Mapper(ICollection<DebitCard> cards)
        {
            //TODO: убрать это всё в автомаппер
            IList<DebitCardModel> result = new List<DebitCardModel>();

            foreach(var card in cards)
            {
                result.Add(new DebitCardModel()
                {
                    Bill = card.Bill,
                    Id = card.Id
                });
            }

            return result;
        }
    }
}
