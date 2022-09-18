using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSweetShop.Models
{
    public class Offer
    {
        public int id { get; set; }
        [ForeignKey("Product")]
        public int prodID { get; set; }
        public SweetProduct? Product { get; set; }
        
        public string AmountType { get; set; }
        public int offer { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
    }
}
