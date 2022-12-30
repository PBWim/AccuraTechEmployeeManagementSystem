using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    /// <summary>
    /// Department Model
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Department Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Department Name
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Department Employees
        /// </summary>
        public List<Employee> Employees { get; set; }
    }
}