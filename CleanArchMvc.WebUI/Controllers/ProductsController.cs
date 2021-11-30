using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService; //Somente leitura
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        public ProductsController (IProductService productService,
            ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productService; //atribuir minha variável a injeção da instância.
            _categoryService = categoryService;
            _environment = environment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }
        [HttpGet()]
        public async Task<IActionResult> Create() //Apresenta um formulário para o usuário informar os dados
        {
            ViewBag.CategoryId =
                new SelectList(await _categoryService.GetCategories(), "Id", "Name"); //Usando a instância para retornar toda a lista da categoria, usando o Id e o nome.
            return View();
        }
        [HttpPost()]
        public async Task<IActionResult> Create(ProductDTO productDTO) //Apresenta um formulário para o usuário informar os dados
        {
            if (ModelState.IsValid) //Verifica se o modelo é válido
            {
                await _productService.Add(productDTO); //Se for válido ele inclui um produto 
                return RedirectToAction(nameof(Index));// E retorna.
            }
            return View(productDTO);
        }
        [HttpGet()]
        public async Task<IActionResult> Edit(int? id) //Apresenta um formulário para o usuário informar os dados
        {
            ViewBag.CategoryId =
               new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            if (id == null) return NotFound();

            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound();

            return View(productDTO);
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid) //valido se os dados foram informados corretamente
            {
                try
                {
                    await _productService.Update(productDTO); //Se for vd eu atualizo os dados
                }

                catch (Exception)
                {
                    throw; //Senão eu lanço uma exeception
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }
        [HttpGet()]
        public async Task<IActionResult> Delete(int? id) //Apresenta um formulário para o usuário informar os dados
        {
            ViewBag.CategoryId =
               new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            if (id == null) return NotFound();

            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound();

            return View(productDTO);
        }
        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null) return NotFound();

            var productDTO = await _productService.GetById(id);

            if (productDTO == null) return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDTO.Image);
            var exists = System.IO.File.Exists(image);

            return View(productDTO);
        }
    }
}
