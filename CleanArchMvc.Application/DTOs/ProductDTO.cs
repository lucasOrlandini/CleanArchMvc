using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
   public  class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is required")] //O usuário tem que informar o valor para o nome.
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")] //O usuário tem que informar o valor para o nome.
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is required")] //O usuário tem que informar o valor para o nome.
        [Column(TypeName = "Decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:c2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get;  set; }

        [Required(ErrorMessage = "The Stock is required")]
        [Range(1,9999)] //minimo e máximo
        [DisplayName("Stock")]

        public int Stock { get;  set; }

        [MaxLength(250)]
        [DisplayName("Image")]
        public string Image { get; set; }
    }
}
