using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Commands
{
    //Comando para atualizar
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; } // É preciso do Id do produto parea atualizar.
    }
}
