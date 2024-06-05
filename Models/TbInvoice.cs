using System.ComponentModel.DataAnnotations;

namespace ClothesECommerceProject.Models
{
    public class TbInvoice
    {
        public TbInvoice()
        {
            shoppingCart = new ShoppingCart();
        }
        [Key]
        public int InvoiceId { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public int CustomerId { get; set; }
    }
}
