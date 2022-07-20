using System.ComponentModel.DataAnnotations;

namespace SpeakerMgmtApp.ViewModels
{
    public class UploadImageViewModel
    {
        [Display(Name = "Image")]
        public IFormFile? SpeakerPicture { get; set; }
    }
}
