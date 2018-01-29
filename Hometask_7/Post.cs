using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hometask_7
{
    class Post
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(180), MinLength(3), Required]
        public string Title { get; set; }

        [Column(TypeName = "datetime2"), Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
