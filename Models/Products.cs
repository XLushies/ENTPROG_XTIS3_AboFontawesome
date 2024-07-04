using System.ComponentModel.DataAnnotations;

namespace ENTPROG_XTIS3_Abo.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Qty { get; set; } = 0;

        [Required]
        public string Unit { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
