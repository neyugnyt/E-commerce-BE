
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.DTOs
{
    public class CustomerBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDTO> Items { get; set; }
    }
}
