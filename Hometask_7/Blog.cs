using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hometask_7
{
    class Blog
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(180), MinLength(3), Required]
        public string Title { get; set; }

        [MaxLength(180), MinLength(3), Required]
        public string BloggerName { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public Blog()
        {
            Posts = new List<Post>();
        }
    }
}
