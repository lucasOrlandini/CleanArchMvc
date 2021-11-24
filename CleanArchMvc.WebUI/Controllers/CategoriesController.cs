using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService  _categoryService; //somente leitura
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService; //Atribui minha variável a injeção da inta^cnia 
        }
        [HttpGet]
        //Está usando meus erviço e retornando uma lista de categorias.
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories();
            return View(categories);
        }
    }
}
