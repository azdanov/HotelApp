using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime CheckInDate { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime CheckOutDate { get; set; }

        [DisplayName("First name")]
        [BindProperty]
        public string? FirstName { get; set; }

        [DisplayName("Last name")]
        [BindProperty]
        public string? LastName { get; set; }

        public RoomTypeModel? RoomType { get; set; }

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            if (RoomTypeId > 0)
            {
                RoomType = _db.GetRoomTypeById(RoomTypeId);
            }
        }

        public IActionResult OnPost()
        {
            if (RoomTypeId > 0 && FirstName != null && LastName != null)
            {
                _db.BookGuest(FirstName, LastName, CheckInDate, CheckOutDate, RoomTypeId);
            }

            return RedirectToPage("/Index");
        }
    }
}