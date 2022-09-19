using CardProject.Api.Models.Dto.Card.Debit;
using CardProject.Api.Models.Requests.DebitCard.Request.CreateCard;
using CardProject.Api.Models.Requests.DebitCard.Request.DeleteCard;
using CardProject.Api.Models.Requests.DebitCard.Request.GetCards;
using CardProject.Api.Models.Requests.DebitCard.Request.UpdateCard;
using CardProject.Api.Models.Requests.DebitCard.Response.CreateCard;
using CardProject.Api.Models.Requests.DebitCard.Response.GetCards;
using CardProject.Bl.Models.Card.Debit;
using CardProject.Bl.Models.Descriptor.Filter;
using CardProject.Bl.Services.Interfaces.Card.Debit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CardProject.Api.Controllers.Api.Card.Debit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitCardController : ControllerBase
    {
        private readonly IDebitCardService _debitCardService;

        public DebitCardController(IDebitCardService debitCardService)
        {
            _debitCardService = debitCardService;
        }

        [HttpDelete("DeleteCard")]
        public async Task<IActionResult> DeleteCard([FromBody] DeleteCardRequest request)
        {
            FilterDescriptor[] filters = new[]
            {
                new FilterDescriptor()
                {
                    Member = nameof(DebitCardModel.Id),
                    Value = request.Id.ToString()
                }
            };

            var items = await _debitCardService.Get(filters);

            await _debitCardService.Delete(items.FirstOrDefault());

            return Ok();
        }

        [HttpPut("UpdateCard")]
        public async Task<IActionResult> UpdateCard([FromBody] UpdateCardRequest request)
        {
            FilterDescriptor[] filter = new[]
            {
                new FilterDescriptor()
                {
                    Member = nameof(request.DebitCard.Id),
                    Value = request.DebitCard.Id.ToString()
                }
            };
            var card = await _debitCardService.Get(filter);

            var updatedCard = card.FirstOrDefault();
            //TODO: под это дело сделать маппер и хелпер для изменения значений
            updatedCard.Bill = request.DebitCard.Bill;

            await _debitCardService.Update(updatedCard);

            return Ok();
        }

        [HttpPost("CreateCard")]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardRequest request)
        {
            var card = new DebitCardModel()
            {
                Id = Guid.NewGuid(),
                Bill = request.Bill
            };

            await _debitCardService.Create(card);

            var result = new CreateCardResponse()
            {
                Id = card.Id
            };

            var options = new JsonSerializerOptions { IncludeFields = true };
            var response = JsonSerializer.Serialize(result, options);

            return Ok(response);
        }

        [HttpPost("GetCards")]
        public async Task<IActionResult> GetCards([FromBody] GetCardsRequest request)
        {
            var filters = new List<FilterDescriptor>();

            foreach(var filterDto in request.Filters)
            {
                filters.Add(new FilterDescriptor()
                {
                    Value = filterDto.Value,
                    Member = filterDto.Member
                });
            }

            var cards = await _debitCardService.Get(filters);

            var cardsDto = new List<DebitCardDto>();

            foreach(var card in cards)
            {
                cardsDto.Add(new DebitCardDto()
                {
                    Id = card.Id,
                    Bill = card.Bill
                });
            }

            var result = new GetCardsResponse()
            {
                DebitCards = cardsDto
            };

            var options = new JsonSerializerOptions { IncludeFields = true };
            var response = JsonSerializer.Serialize(result, options);

            return Ok(response);
        }
    }
}
