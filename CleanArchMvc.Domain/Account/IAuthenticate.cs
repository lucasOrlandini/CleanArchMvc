﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Account
{
   public  interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);// referindo ao login do usuário
        Task<bool> RegisterUser(string email, string password); // Registrar o usuário 
        Task Logout();
    }
}
