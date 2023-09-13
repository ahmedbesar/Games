using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel
    {
        [Required (ErrorMessage ="please Enter game name"), MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "please Enter game Description"), MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [AllowedExtensions(FileSettings.AllowedExtensions),
        MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public string Cover { get; set; } = string.Empty;
        //الي هيتربط بيه 
        [Required(ErrorMessage = "please Enter game Category")]
        public int CategoryId { get; set; }
        //الي هيتملي بيه
        public IEnumerable<SelectListItem> Categories { get; set; }= Enumerable.Empty<SelectListItem>();
        //carry selected devices
        [Required(ErrorMessage = "please Enter supported Devices")]
        public List<int> SelectedDevices { get; set; }= default!;
        //carry all devices
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
