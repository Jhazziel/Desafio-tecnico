using Microsoft.AspNetCore.Mvc;
using Restaurante.Gustov.Modelos;
using Restaurante.Gustov.Servicios.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Gustov.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            this._categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetMenusAsync()
        {
            try
            {
                var menus = await this._categoriaService.GetCategoriaAsync();
                return Ok(menus);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> AddMenuAsync(Categoria categoria)
        {
            try
            {
                var saveCategoria = await this._categoriaService.AddCategoriaAsync(categoria);
                return CreatedAtRoute("GetCategoria", new { id = saveCategoria.CategoriaId }, saveCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}", Name = "GetCategoria")]
        public async Task<ActionResult<Menu>> GetMenuByIdAsync(int id)
        {
            try
            {
                var categorias = await this._categoriaService.GetCategoriaByIdAsync(id);
                return categorias != null ? Ok(categorias) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
