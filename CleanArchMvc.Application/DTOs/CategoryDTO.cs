using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")] //O usuário tem que informar o valor para o nome.
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
