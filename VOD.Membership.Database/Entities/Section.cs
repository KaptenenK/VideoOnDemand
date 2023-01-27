using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOD.Membership.Database.Entities
{
    public class Section : IEntity
    {
        public int Id { get; set; }
        [MaxLength(80), Required]
        public string Title { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<Video> Videos { get; set; }
    }
}
