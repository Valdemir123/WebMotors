using AnuncioWebMotors.Data;
using AnuncioWebMotors.Models;
using AnuncioWebMotors.Models.Interface;
using AnuncioWebMotors.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Controllers
{
    public class MercadoController : Controller
    {
        //Listagem
        public async Task<IActionResult> Index(int? _PageId)
        {
            if (_PageId == null)
            {
                _PageId = 1;
            }

            var _api = RestService.For<IMercado_APIservice>("http://desafioonline.webmotors.com.br");
            var _page = await _api.GetMercadoAsync(_PageId);

            return View(_page);
        }
    }
}
