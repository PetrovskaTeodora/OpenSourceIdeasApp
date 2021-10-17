using Domain.Models;
using Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Idea : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UniqueCode { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
