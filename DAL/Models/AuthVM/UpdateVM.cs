using System.ComponentModel.DataAnnotations;

namespace Football.Models.AuthVM
{
    public class UpdateVM
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }
    }
}
