using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Models
{
    public class LeaveType
    {
        public int Id { get; set; }

        [Required]
        public string LeaveName { get; set; }

        [Required]
        public int TotalDays { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}
