using CleanArchMvc.Application.DTOs;
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
        private readonly ICategoryService _categoryService; //somente leitura
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService; //Atribui minha variável a injeção da inta^cnia 
        }
        [HttpGet]
        //Está usando meus erviço e retornando uma lista de categorias.
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategories(); //Processa, recebendo o servico, chamado GetCategories
            return View(categories);
        }
        [HttpGet()]
        public IActionResult Create() //Apresenta um formulário para o usuário informar os dados
        {
            return View();
        }

        //Método Create para receber o POST
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid) //Verifica se o modelo é válido
            {
                await _categoryService.Add(category); //Se for válido ele inclui na categoria 
                return RedirectToAction(nameof(Index));// E retorna.
            }
            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid) //valido se os dados foram informados corretamente
            {
                try
                {
                    await _categoryService.Update(categoryDTO); //Se for vd eu atualizo os dados
                }

                catch (Exception)
                {
                    throw; //Senão eu lanço uma exeception
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

    }
}
