using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        [DisplayName("Check-in date")]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Now;

        [DisplayName("Check-out date")]
        [BindProperty(SupportsGet = true)]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public bool IsSearchEnabled { get; set; } = false;

        public List<RoomTypeModel>? AvailableRoomTypes { get; set; }

        public RoomSearchModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            if (IsSearchEnabled)
            {
                AvailableRoomTypes = _db.GetAvailableRoomTypes(CheckInDate, CheckOutDate);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(
                new
                {
                    IsSearchEnabled = true,
                    CheckInDate = CheckInDate.ToString("yyyy-MM-dd"),
                    CheckOutDate = CheckOutDate.ToString("yyyy-MM-dd")
                }
            );
        }
    }
}