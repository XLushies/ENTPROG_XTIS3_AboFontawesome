using System.ComponentModel.DataAnnotations;

namespace ENTPROG_XTIS3_Abo.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Representative { get; set; }

        [Required]
        public string ContactNo { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
