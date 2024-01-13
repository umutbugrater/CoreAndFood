using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name Not Empty")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "Please only enter 4-20 length characters")]
        ////[MaxLength(20,ErrorMessage ="Please maximum enter 4-20 characters")]
        ////[MinLength(2, ErrorMessage = "Please minumum enter 2 characters")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "Category Desc Not Empty")]
        public string CategoryDescription { get; set; }

        public bool Status { get; set; }
        public List<Food>? Foods { get; set; }
    }
}
