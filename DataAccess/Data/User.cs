using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bulletinboard.Back.DataAccess.Data
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Password { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "varchar(200)")]
        public string PhoneNo { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string Address { get; set; } = string.Empty;

        public DateTime? Dob { get; set; }

        public int Role { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string CreatedUserId { get; set; } = string.Empty;

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
