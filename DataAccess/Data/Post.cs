using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulletinboard.Back.DataAccess.Data
{
    public class Post
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string CreatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? UpdatedUserId { get; set; }

        public DateTime? DeletedDate { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? DeletedUserId { get; set; }
    }
}
