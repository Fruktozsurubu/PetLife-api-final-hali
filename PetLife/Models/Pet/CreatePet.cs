using System.ComponentModel.DataAnnotations;

namespace Models.Pet
{
    public class CreatePet
    {
        [Required]
        public string PetId { get; set; } = string.Empty;
        [Required]
        public string OwnerId { get; set; } = string.Empty;
        [Required]

        public string PetImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Evcil hayvanın adı gereklidir.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Evcil hayvanın yaşını belirtiniz.")]
        public string Age { get; set; } = String.Empty;

        [Required(ErrorMessage = "Evcil hayvanın kilosunu belirtiniz.")]
        public string Weight { get; set; } = String.Empty;

        [Required(ErrorMessage = "Evcil hayvanın türünü belirtiniz.")]
        public int Type { get; set; }

        [Required(ErrorMessage = "Evcil hayvanın kısırlık durumunu belirtiniz.")]
        public int SterilizationStatus { get; set; }

        [Required(ErrorMessage = "Evcil hayvanın cinsiyetini belirtiniz.")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Evcil hayvanın cinsini belirtiniz.")]
        public int Breed { get; set; }
    }
}
