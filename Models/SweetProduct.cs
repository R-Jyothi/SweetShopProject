using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSweetShop.Models
{
    public class SweetProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("categ")]
        public int categID { get; set; }
        public SweetCategory? categ { get; set; }
        public float price { get; set; }
    }
}
