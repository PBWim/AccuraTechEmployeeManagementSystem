namespace Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Repository.Base;

    /// <summary>
    /// Department Model
    /// </summary>
    public class Department : IBaseEntity
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