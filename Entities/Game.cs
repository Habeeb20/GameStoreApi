using System.ComponentModel.DataAnnotations;
//this file serves as a model
namespace GameStore.Api.Entities
{
    public class Game
    {
        public int Id {get; set;}

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
        
        [Required]
        [StringLength(20)]
        public required string Genre { get; set;}

        
        [Range(1, 200)]
      
        public required decimal Price {get; set;}

        public DateTime ReleaseDate {get; set;}

        [Url]
        [StringLength(100)]
        public  string ImageUri {get; set;}
        
    }
};