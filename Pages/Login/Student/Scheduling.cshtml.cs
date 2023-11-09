using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Your_Music_Depot_Application_DBAS6201.Pages.Login.Student
{
    public class SchedulingModel : PageModel
    {
        public int monthnumber = 2;
        public List<Month> Months = new List<Month>();
        public void OnGet()
        {
            Month months = new Month();
            //months.month = monthnumber;
            //Months.Add(months);
            
        }



        public class Month
        {
            public int month;
        }
    }
}
