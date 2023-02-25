using AdoptionApplication.Server.Services.SpeciesService;
using AdoptionApplication.Shared;
using AdoptionApplication.Shared.Constants;

namespace AdoptionApplication.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        public ICollection<Animal> Animals { get ; set; } = new List<Animal>
            {
                new Animal
                {
                    Id = 1,
                    Name = "Bazylka",
                    SpeciesId = 1,
                    IsAdopted = false,
                    Gender = GenderContants.Female,
                    HealthStatus = HealthStatusContants.Unhealthy,
                    Image = "https://iili.io/HGRJuG1.jpg",
                    ShortDescription = "Śmieszna wiewiórka, lubi jeść",
                    Description = "Bazylka to urocza króliczka o pięknej, jasnorudej sierści. Ma duże, brązowe oczy i długie, puszyste uszy, które ciągle kręcą się na boki,"+
"słysząc każdy dźwięk w otoczeniu.Charakter Bazylki jest bardzo energiczny i zwinny. Lubi skakać, biegać i bawić się na świeżym powietrzu. Jest bardzo"+
"ruchliwa i szybka, dzięki czemu unika niebezpieczeństw i łatwo przemieszcza się po swoim terenie."+
"Bazylka jest także bardzo ciekawska i lubi odkrywać nowe rzeczy. Często chodzi po nowych miejscach,"+
"grzebie w ziemi i przekopywa nowe tunele. Lubi też poznawać nowych ludzi i zwierzęta, zachęcając"+
"do zabawy swoim wesołym podejściem i chęcią do zabawy.Króliczka ta jest także bardzo uparta i"+
"czasem trudno zmusić ją do zrobienia czegoś, czego nie chce.Jednakże jest też bardzo kochana i"+
"przyjacielska, zwłaszcza wobec swoich opiekunów. Lubi pieszczoty i przytulanie, a czasem sama ucieka"+
"do ciepłego kąta, aby odpocząć i zrelaksować się.Ogólnie rzecz biorąc, Bazylka to urocza, pełna energii"+
"i wesoła króliczka o pięknej, jasnorudej sierści. Jej ruchliwość i zwinność sprawiają, że jest doskonałym"+
"towarzyszem zabaw, a jej przyjacielskie nastawienie przyciąga do niej wiele nowych znajomości.",
                    City = "Kraków",
                    Province = "Małopolskie",
                    DateOfBirth = new DateTime(2019, 01, 01),
                    CreateDate = DateTime.UtcNow,
                    Deleted = false,
                },
                new Animal
                {
                    Id = 2,
                    Name = "Chlebusz",
                    SpeciesId = 1,
                    IsAdopted = false,
                    Gender = GenderContants.Male,
                    ShortDescription = "Królik nie z tego świata",
                    Description = "Chlebusz to uroczy królik o miękkim i puszystym, szarym futrze. Ma duże, czarne oczy i długie, uszate uszy, które ciągle kręcą się na boki, słysząc każdy dźwięk w otoczeniu."+
                                    "Charakter Chlebusza jest bardzo przyjacielski i łagodny. Lubi spędzać czas na wypoczynku, leżąc wygodnie na miękkiej poduszce lub grzebiąc w swojej ulubionej zielonej trawie. Jest bardzo łagodny i nieśmiały, ale też ciekawy świata i lubi poznawać nowych ludzi i zwierzęta."+
                                    "Chlebusz jest bardzo aktywny w ciągu dnia, lubi biegać po łące i skakać z jednego miejsca na drugie. Czasami jest też nieco roztrzepany i zapomina o swoich zadaniach, ale zawsze stara się naprawić swoje błędy."+
                                    "Królik ten lubi też dobrą, soczystą marchewkę oraz inne smaczne warzywa, które lubi zjadać podczas swoich przekąsek. Jest bardzo przywiązany do swojej rodziny i lubi spędzać czas z nimi, a także lubi przesypiać większą część dnia."+
                                    "Ogólnie rzecz biorąc, Chlebusz to uroczy, przyjacielski i aktywny królik, który kocha spędzać czas na wypoczynku, ale też chętnie poznaje nowych przyjaciół.",
                    HealthStatus = HealthStatusContants.Healthy,
                    Image = "https://iili.io/HGRJA6F.jpg",
                    City = "Kraków",
                    Province = "Małopolskie",
                    DateOfBirth = new DateTime(2019, 03, 05),
                    CreateDate = DateTime.UtcNow,
                    Deleted = false,
                },
                new Animal
                {
                    Id = 3,
                    Name = "Bamboszek",
                    SpeciesId = 2,
                    IsAdopted = false,
                    Gender = GenderContants.Male,
                    ShortDescription = "Mięciutki Bamboszek szuka domu",
                    Description = "Bamboszek to biały shih tzu o przyjaznym charakterze. Ma krótkie futerko, które jest miękkie w dotyku i wymaga regularnej pielęgnacji. Jego małe, czarne oczy emanują ciepłem i życzliwością, co sprawia, że trudno mu się oprzeć."+
                                    "Bamboszek jest bardzo energiczny i uwielbia bawić się ze swoim właścicielem. Jest to piesek inteligentny, który szybko się uczy i z łatwością zapamiętuje komendy. Lubi też biegać, skakać i bawić się zabawkami, a jego radosny temperament sprawia, że potrafi rozśmieszać każdego."+
                                    "Jest też bardzo przyjacielski i lojalny. Lubi być w bliskim kontakcie ze swoim właścicielem i często chętnie siada na kolanach lub przytula się do niego. Jest też bardzo czuły i wrażliwy, co sprawia, że łatwo go rozpieszczać i dawać mu wiele radości."+
                                    "Podsumowując, Bamboszek to uroczy shih tzu, który jest idealnym towarzyszem dla osób, które cenią sobie energię, inteligencję i lojalność w swoim psie. Jego radosny temperament i przyjacielski charakter sprawiają, że zawsze jest on gotowy do zabawy i pełen życzliwości w stosunku do swojego właściciela.",
                    HealthStatus = HealthStatusContants.Healthy,
                    Image = "https://iili.io/HGAVrG4.jpg",
                    City = "Wrocław",
                    Province = "Dolnośląskie",
                    DateOfBirth = new DateTime(2020, 02, 10),
                    CreateDate = DateTime.UtcNow,
                    Deleted = false,
                }
            };

        private readonly ISpeciesService _speciesService;

        public AnimalService(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        public async Task<Animal> GetAnimalByIdAsync(int id) => Animals.FirstOrDefault(x => x.Id == id);

        public async Task<ICollection<Animal>> GetAnimalsAsync() => Animals;

        public async Task<ICollection<Animal>> GetAnimalsBySpeciesAsync(string speciesUrl)
        {
            var species = await _speciesService.GetSpeciesByUrlAsync(speciesUrl);
            return Animals.Where(x => x.SpeciesId == species.Id).ToList();
        }
    }
}
