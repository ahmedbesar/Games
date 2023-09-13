

using GameZone.Models;

namespace GameZone.Bl
{
    public interface IGames
    {
       Task Create(CreateGameFormViewModel model);
        public List<Game> GetAll(int pgnum, int pgsize);
        public int tatalGames();
    }
    
    public class ClsGames:IGames
    {
        private readonly IMapper Mapper;
        private readonly GameZoneDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;
       public ClsGames(GameZoneDBContext context,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
            this.Mapper = mapper;
          
        }

        public List<Game> GetAll(int pgnum, int pgsize)
        {
            try
            {
                var lstGames = _context.Games.Skip(pgnum * pgsize - pgsize).Take(pgsize).ToList() ;
                return lstGames;
            }
            catch
            {
                return new List<Game>();
            }
        }
        public int tatalGames()
        {
            return _context.Games.Count();
        }
        public async Task Create(CreateGameFormViewModel model)
        {

            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover)}";

            var path = Path.Combine(_imagesPath, coverName);

            using var stream = File.Create(path);


            var game = Mapper.Map<Game>(model);

            game.GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();


            _context.Add(game);
            _context.SaveChanges();
        }


    }
}
