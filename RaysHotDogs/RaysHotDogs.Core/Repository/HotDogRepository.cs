using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup () {
                HotDogGroupID = 1,
                Title = "Meatlovers",
                ImagePath = "",
                HotDogs = new List<HotDog>() {
                    new HotDog()
                    {
                        HotDogId = 1,
                        Name = "Regular Hot Dog",
                        ShortDescription = "The best there is on this planet",
                        Description = "Manchego smelly cheese danish fontina. Hard cheese",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Regular Bun", "Sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 2,
                        Name = "Haute Dog",
                        ShortDescription = "The classy one",
                        Description = "Bacon ipsum dolor amet turduccken ham t-bone shank",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() {"Baked bun", "Gormet sausage" },
                        Price = 10,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 3,
                        Name = "Extra Long",
                        ShortDescription = "For when a regular one isn't enough",
                        Description = "Bacon ipsum dolor amet turduccken ham t-bone shank",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Extra Long bun", "Extra Long Gormet sausage" },
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new HotDogGroup () {
                HotDogGroupID = 2,
                Title = "Veggie lovers",
                ImagePath = "",
                HotDogs = new List<HotDog>() {
                    new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Hot Dog",
                        ShortDescription = "American for non-meat-lovers",
                        Description = "Manchego smelly cheese danish fontina. Hard cheese",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Bun", "Vegetarian Sausage", "Ketchup" },
                        Price = 8,
                        IsFavorite = false
                    },
                    new HotDog()
                    {
                        HotDogId = 5,
                        Name = "Haute Dog Veggie",
                        ShortDescription = "Classy and veggie",
                        Description = "Bacon ipsum dolor amet turduccken ham t-bone shank",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime = 15,
                        Ingredients = new List<string>() {"Baked bun", "Gormet vegiteble sausage" },
                        Price = 10,
                        IsFavorite = true
                    },
                    new HotDog()
                    {
                        HotDogId = 6,
                        Name = "Extra Long Veggie",
                        ShortDescription = "For when a regular one isn't enough",
                        Description = "Bacon ipsum dolor amet turduccken ham t-bone shank",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime = 10,
                        Ingredients = new List<string>() {"Extra Long bun", "Extra Long Gormet sausage" },
                        Price = 8,
                        IsFavorite = false
                    }
                }
            }
        };

        public List<HotDog> GetAllHotDogs()
        {
            IEnumerable<HotDog> hotDogs = 
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }

        public HotDog GetHotDogById (int hotDogId)
        {
            IEnumerable<HotDog> hotDogs = 
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.HotDogId == hotDogId
                select hotDog;
            return hotDogs.FirstOrDefault();
        }

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogGroups;
        }

        public List<HotDog> GetHotDogsforGroup(int hotDogGroupId)
        {
            var group = hotDogGroups.Where(h => h.HotDogGroupID == hotDogGroupId).FirstOrDefault();
            if (group != null)
            {
                return group.HotDogs;
            }
            else
            {
                return null;
            }
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            IEnumerable<HotDog> hotDogs = 
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                where hotDog.IsFavorite
                select hotDog;
            return hotDogs.ToList<HotDog>();
        }
    }
}
