using System.Diagnostics;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            string role = HttpContext.Session.GetString("Role");
            int employeeId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

            if (role == "Admin")
            {
                ViewBag.TotalEmployees = _context.Employees.Count();
                ViewBag.TotalLeaveTypes = _context.LeaveTypes.Count();
                ViewBag.TotalRequests = _context.LeaveRequests.Count();

                ViewBag.Pending = _context.LeaveRequests.Count(x => x.Status == "Pending");
                ViewBag.Approved = _context.LeaveRequests.Count(x => x.Status == "Approved");
                ViewBag.Rejected = _context.LeaveRequests.Count(x => x.Status == "Rejected");
            }
            else
            {
                ViewBag.MyRequests =
                    _context.LeaveRequests.Count(x => x.EmployeeId == employeeId);

                ViewBag.MyPending =
                    _context.LeaveRequests.Count(x =>
                        x.EmployeeId == employeeId &&
                        x.Status == "Pending");

                ViewBag.MyApproved =
                    _context.LeaveRequests.Count(x =>
                        x.EmployeeId == employeeId &&
                        x.Status == "Approved");

                ViewBag.MyRejected =
                    _context.LeaveRequests.Count(x =>
                        x.EmployeeId == employeeId &&
                        x.Status == "Rejected");

                var employee = _context.Employees.FirstOrDefault(x => x.Id == employeeId);

                ViewBag.LeaveBalance = employee?.LeaveBalance ?? 0;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
