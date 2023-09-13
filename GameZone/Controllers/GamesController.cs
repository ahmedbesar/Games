using cloudscribe.Pagination.Models;

namespace GameZone.Controllers
{

    public class GamesController : Controller
    {
        private readonly ICategories oCategory;
        private readonly IDevices oDevices;
        private readonly IGames oGames;
        private readonly GameZoneDBContext Context;
        public GamesController(ICategories oCategory, IDevices oDevices, IGames oGames, GameZoneDBContext oDbContext)
        {
            this.oCategory = oCategory;
            this.oDevices = oDevices;
            this.oGames = oGames;
            this.Context = oDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List(int pagenumber = 1, int pagesize = 3)
        {
            var games =oGames.GetAll(pagenumber,pagesize);
            var result = new PagedResult<Game>()
            {

                Data = games.ToList(),
                PageNumber = pagenumber,
                PageSize = pagesize,
                TotalItems = oGames.tatalGames()

            };

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateGameFormViewModel viewModel = new CreateGameFormViewModel()
            {
                Categories = oCategory.GetSelectedCategories(),
                Devices= oDevices.GetSelectedDevices(),
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = oCategory.GetSelectedCategories();
                model.Devices =oDevices.GetSelectedDevices();
                return View(model);
            }
           await oGames.Create(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
