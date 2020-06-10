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
    public class AnuncioController : Controller
    {
        private readonly AnuncioWebMotorsContext _context;
        public AnuncioController(AnuncioWebMotorsContext context)
        {
            _context = context;
        }



        //Index
        public async Task<IActionResult> Index()
        {
            return View(await _context.Class_Anuncio.ToListAsync());
        }



        //Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não informado!" });
            }

            var class_Anuncio = await _context.Class_Anuncio.FirstOrDefaultAsync(m => m.ID == id);
            if (class_Anuncio == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não encontrado!" });
            }

            return View(class_Anuncio);
        }



        //Create
        public IActionResult Create()
        {
            var _Anuncio = new Class_Anuncio();

            var _marca = new List<Class_Marca>();
            var _modelo = new List<Class_Modelo>();
            var _versao = new List<Class_Versao>();

            ViewBag.Marca_LIST = _marca;
            ViewBag.Modelo_LIST = _modelo;
            ViewBag.Versao_LIST = _versao;
            return View(_Anuncio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Class_Anuncio class_Anuncio)
        {
            var _MarcaId = Convert.ToInt32(class_Anuncio.Marca);
            var _api1 = RestService.For<IMarca_APIservice>("http://desafioonline.webmotors.com.br");
            var _marca = await _api1.GetMarcaAsync();
            class_Anuncio.Marca = _marca.Find(m => m.ID == _MarcaId).Name;

            var _ModeloId = Convert.ToInt32(class_Anuncio.Modelo);
            var _api2 = RestService.For<IModelo_APIservice>("http://desafioonline.webmotors.com.br");
            var _modelo = await _api2.GetModeloAsync(_MarcaId);
            class_Anuncio.Modelo = _modelo.Find(m => m.ID == _ModeloId).Name;

            var _VersaoId = Convert.ToInt32(class_Anuncio.Versao);
            var _api3 = RestService.For<IVersao_APIservice>("http://desafioonline.webmotors.com.br");
            var _versao = await _api3.GetVersaoAsync(_ModeloId);
            class_Anuncio.Versao = _versao.Find(m => m.ID == _VersaoId).Name;

            if (ModelState.IsValid)
            {
                _context.Add(class_Anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Marca_LIST = _marca;
            ViewBag.Modelo_LIST = _modelo;
            ViewBag.Versao_LIST = _versao;
            return View(class_Anuncio);
        }



        //Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não informado!" });
            }
            var class_Anuncio = await _context.Class_Anuncio.FindAsync(id);
            if (class_Anuncio == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não encontrado!" });
            }

            var _MarcaName = class_Anuncio.Marca;
            var _api1 = RestService.For<IMarca_APIservice>("http://desafioonline.webmotors.com.br");
            var _marca = await _api1.GetMarcaAsync();
            var _MarcaId = _marca.Find(m => m.Name == _MarcaName).ID;
            class_Anuncio.Marca = _MarcaId.ToString();

            var _ModeloName = class_Anuncio.Modelo;
            var _api2 = RestService.For<IModelo_APIservice>("http://desafioonline.webmotors.com.br");
            var _modelo = await _api2.GetModeloAsync(_MarcaId);
            var _ModeloId = _modelo.Find(m => m.Name == _ModeloName).ID;
            class_Anuncio.Modelo = _ModeloId.ToString();

            var _VersaoName = class_Anuncio.Versao;
            var _api3 = RestService.For<IVersao_APIservice>("http://desafioonline.webmotors.com.br");
            var _versao = await _api3.GetVersaoAsync(_ModeloId);
            var _VersaoId = _versao.Find(m => m.Name == _VersaoName).ID;
            class_Anuncio.Versao = _VersaoId.ToString();

            ViewBag.Marca_LIST = _marca;
            ViewBag.Modelo_LIST = _modelo;
            ViewBag.Versao_LIST = _versao;
            return View(class_Anuncio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Marca,Modelo,Versao,Ano,Quilometragem,Observacao")] Class_Anuncio class_Anuncio)
        {
            if (id != class_Anuncio.ID)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id diferente do informado!" });
            }

            var _MarcaId = Convert.ToInt32(class_Anuncio.Marca);
            var _api1 = RestService.For<IMarca_APIservice>("http://desafioonline.webmotors.com.br");
            var _marca = await _api1.GetMarcaAsync();

            var _ModeloId = Convert.ToInt32(class_Anuncio.Modelo);
            var _api2 = RestService.For<IModelo_APIservice>("http://desafioonline.webmotors.com.br");
            var _modelo = await _api2.GetModeloAsync(_MarcaId);

            var _VersaoId = Convert.ToInt32(class_Anuncio.Versao);
            var _api3 = RestService.For<IVersao_APIservice>("http://desafioonline.webmotors.com.br");
            var _versao = await _api3.GetVersaoAsync(_ModeloId);


            if (ModelState.IsValid)
            {
                try
                {
                    class_Anuncio.Marca = _marca.Find(m => m.ID == _MarcaId).Name;
                    class_Anuncio.Modelo = _modelo.Find(m => m.ID == _ModeloId).Name;
                    class_Anuncio.Versao = _versao.Find(m => m.ID == _VersaoId).Name;

                    _context.Update(class_Anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Class_AnuncioExists(class_Anuncio.ID))
                    {
                        return RedirectToAction(nameof(Error), new { _Message = "Id não encontrado!" });
                    }
                    else
                    {
                        return RedirectToAction(nameof(Error), new { _Message = "Erro não identificado!" });
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Marca_LIST = _marca;
            ViewBag.Modelo_LIST = _modelo;
            ViewBag.Versao_LIST = _versao;
            return View(class_Anuncio);
        }



        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não informado!" });
            }

            var class_Anuncio = await _context.Class_Anuncio.FirstOrDefaultAsync(m => m.ID == id);
            if (class_Anuncio == null)
            {
                return RedirectToAction(nameof(Error), new { _Message = "Id não encontrado!" });
            }

            return View(class_Anuncio);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var class_Anuncio = await _context.Class_Anuncio.FindAsync(id);
            _context.Class_Anuncio.Remove(class_Anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool Class_AnuncioExists(int id)
        {
            return _context.Class_Anuncio.Any(e => e.ID == id);
        }



        // POST: Error Message
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string _Message)
        {
            var _vm = new ErrorViewModel
            {
                Message = _Message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(_vm);
        }


        // API:
        public async Task<JsonResult> BUSCAR_MarcaAsync()
        {
            var _api = RestService.For<IMarca_APIservice>("http://desafioonline.webmotors.com.br");
            var _marca = await _api.GetMarcaAsync();

            //
            return Json(_marca);
        }
        public async Task<JsonResult> BUSCAR_ModeloAsync(int Id)
        {
            var _api = RestService.For<IModelo_APIservice>("http://desafioonline.webmotors.com.br");
            var _modelo = await _api.GetModeloAsync(Id);

            //
            return Json(_modelo);
        }

        public async Task<JsonResult> BUSCAR_VersaoAsync(int Id)
        {
            var _api = RestService.For<IVersao_APIservice>("http://desafioonline.webmotors.com.br");
            var _versao = await _api.GetVersaoAsync(Id);

            //
            return Json(_versao);
        }
    }
}
