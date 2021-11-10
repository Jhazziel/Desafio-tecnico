using Microsoft.AspNetCore.Http;
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
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            this._menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Menu>>> GetMenusAsync()
        {
            try
            {
                var menus = await this._menuService.GetMenuAsync();
                return Ok(menus);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost]
        public async Task<ActionResult<Menu>> AddMenuAsync(Menu menu)
        {
            try
            {
                var saveMenu = await this._menuService.AddMenuAsync(menu);
                return CreatedAtRoute("GetMenu", new { menuId = saveMenu.MenuId }, saveMenu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{menuId:int}", Name = "GetMenu")]
        public async Task<ActionResult<Menu>> GetMenuByIdAsync(int menuId)
        {
            try
            {
                var menus = await this._menuService.GetMenuByIdAsync(menuId);
                return menus != null ? Ok(menus) : NotFound();                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getCategoryByDate")]
        public async Task<ActionResult<Menu>> GetCategoryByDateAsync(DateTime date)
        {
            try
            {
                var menus = await this._menuService.GetMenuByDateAsync(Convert.ToDateTime(date));
                return menus != null ? Ok(menus) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
