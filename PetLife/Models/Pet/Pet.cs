using System.ComponentModel.DataAnnotations;

namespace Models.Pet
{
    public class Pet
    {
        public string PetId { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public string PetImageUrl { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Age { get; set; } = string.Empty;

        public string Weight { get; set; } = string.Empty;

        public int Type { get; set; } 

        public int SterilizationStatus { get; set; } 

        public int Gender { get; set; }

        public int Breed { get; set; } 
    }
}
