using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Account
{
    //Definir um contrato para implementar a inclusão de usuários e roles iniciais nas tabelas do Identity
    public interface ISeedUserRoleInitial
    {
        void SeedUsers(); //Incluir os usuários
        void SeedRoles(); //Incluir os perfis 
    }
}
