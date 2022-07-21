namespace SpeakerMgmtApp.ViewModels
{
    public class EditImageViewModel : UploadImageViewModel
    {
        public int Id { get; set; }
        public byte[]? ExistingImage { get; set; }
    }
}
