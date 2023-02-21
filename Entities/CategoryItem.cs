using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebELearning.Entities
{
    public class CategoryItem
    {
        private DateTime _releaseDate = DateTime.MinValue;

        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select a valid item from the '{0}' dropdown list")]
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [NotMapped]
        public virtual ICollection<SelectListItem> MediaTypes { get; set; }

        [NotMapped]
        public int ContentId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]

        public DateTime DateTimeReleaseDate
        {
            get
            {
                return (_releaseDate == DateTime.MinValue) ? DateTime.Now : _releaseDate;
            }
            set
            {
                _releaseDate = value;
            }

        }

     

    }
}
