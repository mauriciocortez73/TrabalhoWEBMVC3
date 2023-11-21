using Microsoft.AspNetCore.Mvc;
using TrabalhoWEBMVC3.Models;

namespace TrabalhoWEBMVC3.Controllers
{
    public class QueryController : Controller
    {
        private readonly Contexto contexto;

        public QueryController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Clientes(string nome)
        {

            List<Cliente> lista = new List<Cliente>();

            if (nome == null)
            {   
                lista = contexto.Clientes.OrderBy(c => c.nome).ToList();
            }
            else
            { 
                lista = contexto.Clientes.Where(o => o.nome == nome)
                    .OrderBy(c => c.nome).ToList();
            }

            return View(lista);
        }

        public IActionResult Pesquisa() 
        { 
            return View();
        }






        public IActionResult Empresas(string descricao)
        {
            List<Empresa> lista = new List<Empresa>();

            if (descricao == null)
            {
                lista = contexto.Empresas.OrderBy(c => c.descricao).ToList();
            }
            else
            {
                lista = contexto.Empresas.Where(o => o.descricao == descricao)
                    .OrderBy(c => c.descricao).ToList();
            }
            return View(lista);
        }

        public IActionResult PesquisaEmpresa()
        {
            return View();
        }





        public IActionResult Impressoras(string descricao)
        {
            List<Impressora> lista = new List<Impressora>();

            if (descricao == null) 
            {
                lista = contexto.Impressoras.OrderBy(c => c.descricao).ToList();
            }
            else 
            { 
                lista = contexto.Impressoras.Where(o => o.descricao == descricao)
                    .OrderBy(c => c.descricao).ToList(); 
            }
            

            return View(lista);
        }
        public IActionResult PesquisaImpressora()
        {
            return View();
        }




        public IActionResult Pedidos(string impressorasID)
        {
            List<Pedido> lista = new List<Pedido>();

            if (impressorasID == null) 
            { 
                lista = contexto.Pedidos.OrderBy(c => c.impressorasID).ToList(); 
            }
            else
            {
                lista = contexto.Pedidos.OrderBy(c => c.impressorasID).ToList();
            }
            

            return View(lista);
        }

        public IActionResult PesquisaPedidos()
        {
            return View();
        }








        public IActionResult Tonners(string descricao)
        {
            List<Tonner> lista = new List<Tonner>();

            if (descricao == null)
            {
                lista = contexto.Tonners.OrderBy(c => c.descricao).ToList();
            }
            else
            {
                lista = contexto.Tonners.Where(o => o.descricao == descricao)
                    .OrderBy(c => c.descricao).ToList();
            }
            

            return View(lista);
        }

        public IActionResult PesquisaTonners()
        {
            return View();
        }
    }
}
