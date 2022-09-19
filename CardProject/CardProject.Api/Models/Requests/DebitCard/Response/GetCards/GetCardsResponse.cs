using CardProject.Api.Models.Dto.Card.Debit;

namespace CardProject.Api.Models.Requests.DebitCard.Response.GetCards
{
    public class GetCardsResponse
    {
        public ICollection<DebitCardDto> DebitCards;
    }
}
