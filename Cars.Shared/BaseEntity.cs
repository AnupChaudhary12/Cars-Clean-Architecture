// we can also use this class to add some common properties to all our entities
// Also we can name shared folder as common or base folder
using System.ComponentModel.DataAnnotations;

namespace Cars.Shared
{
    /// <summary>
    /// This class is used to add some common properties to all our entities
    /// </summary>
    public abstract class BaseEntity
    {
        [Required,Key]
        public int Id { get; set; }
        //public DateTime? CreatedTime { get; set; }
        //public DateTime? ModifiedTime { get; set; }

    }
}
