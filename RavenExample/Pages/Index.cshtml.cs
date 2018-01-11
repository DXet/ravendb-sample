using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RavenExample.Animals;

namespace RavenExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IAnimalCreateThirdOfLionsService _animalCreateThirdOfLionsRepository;
        private readonly IAnimalGetCreatedToday _animalGetCreatedToday;

        public IndexModel(
            IAnimalRepository animalRepository,
            IAnimalCreateThirdOfLionsService animalCreateThirdOfLionsRepository, 
            IAnimalGetCreatedToday animalGetCreatedToday
            )
        {
            _animalRepository = animalRepository;
            _animalCreateThirdOfLionsRepository = animalCreateThirdOfLionsRepository;
            _animalGetCreatedToday = animalGetCreatedToday;
        }

        public string AnimalName { get; set; }

        public void OnGet()
        {
            //var elf = new Animal(
            //    name: "elf9",
            //    kind: "elephant"
            //    );

            //var elfId = _animalRepository.Create(elf);

            //var elfStoredEntity = _animalRepository.Get(elfId);

            var createdToday = _animalGetCreatedToday.Perform();
            var names = createdToday.Aggregate(string.Empty, (acc, animal) => acc + animal.Name + ", ");
            AnimalName = names;
        }
    }
}
