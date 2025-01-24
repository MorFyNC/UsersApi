using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi3K.Model
{
    public class Users
    {
        [Key]
        public int id_User { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }

    }
}
