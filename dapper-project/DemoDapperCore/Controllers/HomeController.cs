using System.Linq;
using System.Security.Principal;
using DemoDapperCore.Models;
using Infra.Contratos.Interfaces;
using Infra.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace DemoDapperCore.Controllers
{
    public class HomeController : Controller
    {
        //Todo=> implementar maxlength nos campos inputs...
        private readonly ICarroDapper _carroDapper;

        public HomeController(ICarroDapper carroDapper)
        {
            _carroDapper = carroDapper;
        }

        public IActionResult Index() => View(_carroDapper.GetAll().Select(x => (CarroViewModel)x));

        public IActionResult Detalhar(int codigo) => View((CarroViewModel)_carroDapper.Get(codigo));

        
        public IActionResult Novo(int? codigo)
        {
            var viewModel = new CarroViewModel();

            if (codigo.HasValue)
            {
                viewModel = (CarroViewModel)_carroDapper.Get(codigo.Value);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Novo(CarroViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var mensagem = viewModel.Codigo > 0 ? "atualizado" : "cadastrado";
                
                _carroDapper.SaveOrUpdate(BindViewModelToEntidade(viewModel));

                TempData["mensagemSucesso"] = $"Carro {mensagem} com sucesso!";

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Excluir(int codigo)
        {
            //Todo=> implementar delete by codigo.
            _carroDapper.Delete(_carroDapper.Get(codigo));

            TempData["mensagemSucesso"] = "Carro excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private static Carro BindViewModelToEntidade(CarroViewModel viewModel)
        {
            return new Carro
            {
                Codigo = viewModel.Codigo,
                AnoFabricacao = viewModel.AnoFabricacao.Value,
                Fabricante = viewModel.Fabricante,
                Modelo = viewModel.Modelo
            };
        }
    }
}