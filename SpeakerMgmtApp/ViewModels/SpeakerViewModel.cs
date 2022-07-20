using SpeakerMgmtApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SpeakerMgmtApp.ViewModels
{
    public class SpeakerViewModel : EditImageViewModel
    {
        public List<Speaker>? Speakers { get; set; }

        public Speaker Speaker { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? SpeakerFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? SpeakerLastName { get; set; }

        [Required]
        [Display(Name = "Qualification")]
        public string? Qualification { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public string? Experience { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? SpeakingDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time")]
        public TimeSpan? SpeakingTime { get; set; }

        [Required]
        [Display(Name = "Stage")]
        public string? Venue { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public string? HotelName { get; set; }

        [Required]
        [Display(Name = "Contact First Name")]
        public string? ContactFirstName { get; set; }

        [Required]
        [Display(Name = "Contact Last Name")]
        public string? ContactLastName { get; set; }

        [Required]
        [Display(Name = "Contact Email")]
        public string? ContactEmail { get; set; }

        [Required]
        [Display(Name = "Contact Phone #")]
        public string? ContactPhoneNumber { get; set; }

        // For Upload
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? FileExtension { get; set; }
        public string? FileDescription { get; set; }

        // Image as bytes
        public byte[]? Image { get; set; }


        // For  testing purposes
        [Display(Name = "Speaker Name")]
        public string FullName
        {
            get
            {
                return SpeakerFirstName + " " + SpeakerLastName;
            }
        }

        #region Upload 
        [Display(Name = "Upload Speaker Photo")]
        public IFormFile? UploadPhoto { get; }
        #endregion
    }
}
