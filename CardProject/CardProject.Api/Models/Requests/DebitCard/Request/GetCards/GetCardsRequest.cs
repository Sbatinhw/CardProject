using CardProject.Api.Models.Descriptor.Filter;

namespace CardProject.Api.Models.Requests.DebitCard.Request.GetCards
{
    public class GetCardsRequest
    {
        public ICollection<FilterDescriptorDto> Filters { get; set; }
    }
}
