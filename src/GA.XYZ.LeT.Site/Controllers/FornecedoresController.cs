using System;
using GA.XYZ.LeT.Application.IServices;
using GA.XYZ.LeT.Application.ViewModels;
using GA.XYZ.LeT.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace GA.XYZ.LeT.Site.Controllers {

    public class FornecedoresController : BaseController
    {
        private readonly IFornecedorApplicationService _fornecedorService;
        private readonly IContatoApplicationService _contatoService;

        public FornecedoresController(IFornecedorApplicationService fornecedorService, IContatoApplicationService contatoService, IDomainNotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _fornecedorService = fornecedorService;
            _contatoService = contatoService;
        }

        [HttpGet]
        [Route("listar-fornecedores")]
        public IActionResult Index(string search, int pagina = 1){
            return View( _fornecedorService.ObterTodos(search).ToPagedList(pagina, 2));
        }

        [Route("detalhes/{id:guid}")]
        public IActionResult Details(Guid? id){

            if (id == null){
                return NotFound();
            }

            var fornecedorViewModel = _fornecedorService.ObterPorId(id.Value);
            fornecedorViewModel.Contatos = _contatoService.ObterContatoPorFornecedor(id.Value);
            if (fornecedorViewModel == null){
                return NotFound();
            }

            ViewBag.ExibirBotaoExcluir = true;
            ViewBag.ExibirBotaoEditar = false;

            return View(fornecedorViewModel);
        }

        [Route("novo-fornecedor")]
        public IActionResult Create(){
            return View(new FornecedorViewModel());
        }

        [HttpPost]
        [Route("novo-fornecedor")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FornecedorViewModel fornecedorViewModel){
            if (!ModelState.IsValid)
                return View(fornecedorViewModel);

            _fornecedorService.Registrar(fornecedorViewModel);

            if (OperacaoValida())
                ViewBag.RetornoStatus = "success,Fornecedor cadastrado com sucesso!";
            else
                ViewBag.RetornoStatus = "error,Erro ao cadastrar!";

            return View(fornecedorViewModel);
        }

        [Route("editar/{id:guid}")]
        public IActionResult Edit(Guid? id){
            if (id == null){
                return NotFound();
            }

            var fornecedorViewModel = _fornecedorService.ObterPorId(id.Value);
            fornecedorViewModel.Contatos = _contatoService.ObterContatoPorFornecedor(id.Value);
            if (fornecedorViewModel == null){
                return NotFound();
            }

            ViewBag.ExibirBotaoExcluir = false;
            ViewBag.ExibirBotaoEditar = true;

            return View(fornecedorViewModel);
        }

        [HttpPost]
        [Route("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FornecedorViewModel fornecedorViewModel){

            if (!ModelState.IsValid)
                return View(fornecedorViewModel);

            _fornecedorService.Atualizar(fornecedorViewModel);

            if (OperacaoValida())
                ViewBag.RetornoStatus = "success,Fornecedor atualizado com sucesso!";
            else
                ViewBag.RetornoStatus = "error,Erro ao atualizar!";

            return View(fornecedorViewModel);
        }

        [Route("deletar/{id:guid}")]
        public IActionResult Delete(Guid? id){
            if (id == null){
                return NotFound();
            }

            var fornecedorViewModel = _fornecedorService.ObterPorId(id.Value);
            
            if (fornecedorViewModel == null){
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("deletar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id){
            _fornecedorService.Excluir(id);

            return RedirectToAction("Index");
        }





        //Contatos

        public IActionResult ListarContatos(Guid id) {
            ViewBag.FornecedorId = id;
            if (id == null) {
                return NotFound();
            }

            return PartialView("_ContatoList", _contatoService.ObterContatoPorFornecedor(id));
        }

        [Route("adicionar-contato/{id:guid}")]
        public IActionResult AdicionarContato(Guid id) {
            if (id == null) {
                return NotFound();
            }
            ViewBag.IdFornecedor = id;
            var contatoViewModel = new ContatoViewModel { IdFornecedor = id };
            return PartialView("_ContatoIncluir",contatoViewModel);
        }

        [HttpPost]
        [Route("adicionar-contato/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarContato(ContatoViewModel contatoViewModel) {
            contatoViewModel.Id = Guid.NewGuid();
            if (ModelState.IsValid) {
                _contatoService.Registrar(contatoViewModel);

                string url = Url.Action("ListarContatos", "Fornecedores", new { id = contatoViewModel.IdFornecedor });
                return Json(new { success = true, url = url });
            }

            return PartialView("_ContatoIncluir", contatoViewModel);
        }

        [Route("editar-contato/{id:guid}")]
        public IActionResult EditarContato(Guid? id) {
            if (id == null) {
                return NotFound();
            }
            return PartialView("_ContatoEditar", _contatoService.ObterPorId(id.Value));
        }

        [HttpPost]
        [Route("editar-contato/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditarContato(ContatoViewModel contatoViewModel) {
            ModelState.Clear();
            _contatoService.Atualizar(contatoViewModel);

            if (OperacaoValida()) {
                var url = Url.Action("ListarContatos", "Fornecedores", new { id = contatoViewModel.IdFornecedor });
                return Json(new { success = true, url = url });
            }

            return PartialView("_ContatoEditar", contatoViewModel);
        }

        [Route("deletar-contato/{id:guid}")]
        public IActionResult DeletarContato(Guid? id) {
            if (id == null) {
                return NotFound();
            }

            var contatoViewModel = _contatoService.ObterPorId(id.Value);

            if (contatoViewModel == null) {
                return NotFound();
            }
            return PartialView("_ContatoDelete", contatoViewModel);
        }

        [HttpPost, ActionName("DeletarContato")]
        [Route("deletar-contato/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarContatoConfirmar(Guid id) {
            var contato = _contatoService.ObterPorId(id);
            _contatoService.Excluir(id);

            string url = Url.Action("ListarContatos", "Fornecedores", new { id = contato.IdFornecedor });
            return Json(new { success = true, url = url });
        }
    }
}
