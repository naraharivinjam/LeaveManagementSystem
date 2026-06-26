using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public int LeaveBalance { get; set; } = 20;
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}
