namespace LeaveManagementSystem.Helpers
{
    public static class SessionHelper
    {
        public static bool IsAdmin(HttpContext context)
        {
            return context.Session.GetString("Role") == "Admin";
        }
    }
}
