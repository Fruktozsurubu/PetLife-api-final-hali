using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.Pet;
using Models.User;
using System.Security.Cryptography;

namespace PetLife.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly DataContext _context;

        public PetController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("get-all-pets")]
        public async Task<IActionResult> GetAllOrders()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePet(CreatePet request)
        {
            try
            {

                var pet = new Pet
                {
                    PetId = CreateRandomToken(4),
                    PetImageUrl=request.PetImageUrl,
                    OwnerId= request.OwnerId,
                    Name = request.Name,
                    Age = request.Age,
                    Weight = request.Weight,
                    Type = request.Type,
                    SterilizationStatus = request.SterilizationStatus,
                    Gender = request.Gender,
                    Breed = request.Breed,
                };

                // Burada gelen pet verilerini işleyebilirsiniz
                // Örneğin, bu verileri bir veritabanına kaydedebilirsiniz

                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();

                return Ok("Pet successfully created!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create pet: {ex.Message}");
            }
        }


        [HttpPost("delete-pet")]
        public async Task<IActionResult> DeleteUser(DeletePet request)
        {
            var pet = await _context.Pets.FirstOrDefaultAsync(u => u.PetId == request.PetId);
            if (pet == null)
            {
                return BadRequest("Pet not found.");
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return Ok("Pet Deleted");
        }

        private string CreateRandomToken(int lenght)
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(lenght));
        }

        // Diğer HTTP istekleri buraya eklenebilir: Güncelleme, Silme, Detaylar vs.
    }
}
