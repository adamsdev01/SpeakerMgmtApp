using System;
using System.Collections.Generic;

namespace SpeakerMgmtApp.Models
{
    public partial class Speaker
    {
        public int Id { get; set; }
        public string? SpeakerFirstName { get; set; }
        public string? SpeakerLastName { get; set; }
        public string? Qualification { get; set; }
        public string? Experience { get; set; }
        public DateTime? SpeakingDate { get; set; }
        public string? Venue { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProfilePictureName { get; set; }
        public string? ProfilePictureFileType { get; set; }
        public string? ProfilePrictureExtension { get; set; }
        public byte[]? ProfilePictureData { get; set; }
        public string? HotelName { get; set; }
        public string? ContactFirstName { get; set; }
        public string? ContactLastName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? SpeakingTime { get; set; }
        public string? SpeakerFullName { get; set; }
        public string? SpeakerNumber { get; set; }
    }
}
