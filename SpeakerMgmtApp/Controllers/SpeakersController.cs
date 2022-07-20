using Microsoft.AspNetCore.Mvc;
using SpeakerMgmtApp.Models;
using SpeakerMgmtApp.Services;
using SpeakerMgmtApp.Helpers;
using SpeakerMgmtApp.ViewModels;
using AutoMapper;

namespace SpeakerMgmtApp.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly SpeakersDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private SpeakerService _speakerService;
        private readonly IMapper _mapper;

        public SpeakersController(SpeakersDbContext context, IWebHostEnvironment webHostEnvironment,
            SpeakerService speakerService, IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _speakerService = speakerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Speaker> speakersList = await _speakerService.GetSpeakers();

            // Map speakersList to return in the View
            var speakers = _mapper.Map<IEnumerable<Speaker>, List<SpeakerViewModel>>(speakersList);

            // Construct viewModel
            SpeakerViewModel viewModel = new SpeakerViewModel
            {
                Speakers = speakersList
            };

            return PartialView("_SpeakersTable", viewModel);
        }

        [HttpGet]
        public IActionResult Create(int? Id)
        {
            var viewModel = new SpeakerViewModel();
            viewModel.Speaker = new Speaker();

            //if (Id.Value > 0 && viewModel.Speaker.Id == 0)
            //{
            //    viewModel.Speaker.Id = Id.Value;    
            //}

            return PartialView("Create", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpeakerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var speaker = _speakerService.SaveSpeaker(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public IActionResult RetrieveImage(int Id)
        {
            byte[] image = GetImageFromDataBase(Id);

            if (image != null)
            {
                return File(image, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            var image = from temp in _context.Speakers where temp.Id == Id select temp.ProfilePictureData;

            byte[] item = image.First();

            return item;
        }
    }
}
