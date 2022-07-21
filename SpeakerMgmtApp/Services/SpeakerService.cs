using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpeakerMgmtApp.Models;
using SpeakerMgmtApp.ViewModels;

namespace SpeakerMgmtApp.Services
{
    public class SpeakerService
    {
        private SpeakersDbContext _dbContext;
        private IHttpContextAccessor _accessor;

        public SpeakerService(SpeakersDbContext dbContext, IHttpContextAccessor accessor)
        {
            _dbContext = dbContext;
            _accessor = accessor;
        }

        public Task<List<Speaker>> GetSpeakers()
        {
            return _dbContext.Speakers.ToListAsync();
        }

        public SpeakerViewModel SaveSpeaker(SpeakerViewModel viewModel)
        {
            // Process the image
            ProcessUploadedFileToDB(viewModel);

            // Add new Speaker object
            var speaker = new Speaker
            {
                SpeakerFullName = viewModel.FullName,
                SpeakerFirstName = viewModel.SpeakerFirstName,
                SpeakerLastName = viewModel.SpeakerLastName,
                Qualification = viewModel.Qualification,
                Experience = viewModel.Experience,
                SpeakingDate = viewModel.SpeakingDate,
                SpeakingTime = viewModel.SpeakingTime,
                Venue = viewModel.Venue,
                HotelName = viewModel.HotelName,
                ContactFirstName = viewModel.ContactFirstName,
                ContactLastName = viewModel.ContactLastName,
                ContactEmail = viewModel.ContactEmail,
                ContactPhoneNumber = viewModel.ContactPhoneNumber,
                ProfilePicture = viewModel.FileName,
                ProfilePictureName = viewModel.FileName,
                ProfilePictureFileType = viewModel.FileType,
                ProfilePrictureExtension = viewModel.FileExtension,
                ProfilePictureData = viewModel.Image,
                CreatedDate = DateTime.Now
            };

            _dbContext.Add(speaker);
            _dbContext.SaveChanges();

            return viewModel;
        }


        // Test getting all file content
        public SpeakerViewModel ProcessUploadedFileToDB(SpeakerViewModel viewModel)
        {

            if (viewModel.SpeakerPicture != null)
            {
                #region Read File Content
                var filePath = Path.GetFullPath(viewModel.SpeakerPicture.FileName);
                var fileExtension = Path.GetExtension(viewModel.SpeakerPicture.FileName);
                var mimeType = viewModel.SpeakerPicture.ContentType;
                var fileName = Path.GetFileName(viewModel.SpeakerPicture.FileName);
                byte[] fileData;

                // Create a new memoryStream
                using (var target = new MemoryStream())
                {
                    viewModel.SpeakerPicture.CopyTo(target); // Copy file to stream
                    fileData = target.ToArray(); // Convert stream to byte array
                }
                #endregion

                viewModel.FileType = mimeType;
                viewModel.FileName = fileName;
                viewModel.FileExtension = fileExtension;
                viewModel.Image = fileData;
            }


            return viewModel;

        }

        

    }
}
