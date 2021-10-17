using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class IdeaViewModel
    {
        public Guid Id { get; set; }
 
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The Title must be minimum 3 characters long!")]
        [Required(ErrorMessage = "{0} is a mandatory field")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is a mandatory field")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is a mandatory field")]
        public int UniqueCode { get; set; }
    }
}
