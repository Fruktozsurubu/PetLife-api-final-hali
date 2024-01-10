using System.ComponentModel.DataAnnotations;

namespace Models.Pet
{
    public class DeletePet
    {
        [Required]
        public string PetId { get; set; } = string.Empty;
       
    }
}
