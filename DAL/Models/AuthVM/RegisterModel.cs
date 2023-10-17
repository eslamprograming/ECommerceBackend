using System.ComponentModel.DataAnnotations;

namespace Football.Models.AuthVM
{
    public class RegisterModel
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }
        //public string? Role { get; set; }    
    }
}
