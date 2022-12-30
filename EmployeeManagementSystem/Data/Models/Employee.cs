namespace Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Shared.Enums;

    /// <summary>
    /// Employee Model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Id
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Employee First Name
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// Employee Last Name
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// Employee Gender
        /// </summary>
        [Required]
        public Gender Gender { get; set; }

        /// <summary>
        /// Employee DOB
        /// </summary>
        [Required]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Employee Address
        /// </summary>
        [Required]
        [MaxLength(500)] 
        public string Address { get; set; }

        /// <summary>
        /// Employee Department Id
        /// </summary>
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Employee Basic Salary
        /// </summary>
        [Required]
        public int BasicSalary { get; set; }

        /// <summary>
        /// Employee Department
        /// </summary>
        public Department Department { get; set; }
    }
}