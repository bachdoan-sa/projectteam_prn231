using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppRazorpage.Pages.ProductOwner
{
    public class CreateAuctionEventModel : PageModel
    {
        [BindProperty]
        public double? StartingPrice { get; set; }

        [BindProperty]
        public double? ExpectedPrice { get; set; }

        [BindProperty]
        public double? MinRaise { get; set; }

        [BindProperty]
        public double? MaxRaise { get; set; }

        [BindProperty]
        public DateTime? BeginDateTime { get; set; }

        [BindProperty]
        public DateTime? EndDateTime { get; set; }

        [BindProperty]
        public double? FinalPrice { get; set; }
        public void OnPost()
        {

        }
    }
}
