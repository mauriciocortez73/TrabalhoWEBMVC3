using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoWEBMVC3.Models;

namespace Trabalho2WEBMVC.Controllers
{
    public class DadosController : Controller
    {
        private readonly Contexto contexto;

        public DadosController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult gerarClientes()
        {
            contexto.Database.ExecuteSqlRaw("delete from Clientes");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Clientes', RESEED, 0)");
            Random randNum = new Random();

            string[] vNomeMas = { "Miguel", "Arthur", "Gael", "Théo", "Heitor", "Ravi", "Davi", "Bernardo", "Noah", "Gabriel", "Samuel", "Pedro", "Anthony", "Isaac", "Benício", "Benjamin", "Matheus", "Lucas", "Joaquim", "Nicolas", "Lucca", "Lorenzo", "Henrique", "João Miguel", "Rafael", "Henry", "Murilo", "Levi", "Guilherme", "Vicente", "Felipe", "Bryan", "Matteo", "Bento", "João Pedro", "Pietro", "Leonardo", "Daniel", "Gustavo", "Pedro Henrique", "João Lucas", "Emanuel", "João", "Caleb", "Davi Lucca", "Antônio", "Eduardo", "Enrico", "Caio", "José", "Enzo Gabriel", "Augusto", "Mathias", "Vitor", "Enzo", "Cauã", "Francisco", "Rael", "João Guilherme", "Thomas", "Yuri", "Yan", "Anthony Gabriel", "Oliver", "Otávio", "João Gabriel", "Nathan", "Davi Lucas", "Vinícius", "Theodoro", "Valentim", "Ryan", "Luiz Miguel", "Arthur Miguel", "João Vitor", "Léonovo", "Ravi Lucca", "Apollo", "Thiago", "Tomás", "Martin", "José Miguel", "Erick", "Liam", "Josué" };
            string[] vNomeFem = { "Helena", "Alice", "Laura", "Maria Alice", "Sophia", "Manuela", "Maitê", "Liz", "Cecília", "Isabella", "Luísa", "Eloá", "Heloísa", "Júlia", "Ayla", "Maria Luísa", "Isis", "Elisa", "Antonella", "Valentina", "Maya", "Maria Júlia", "Aurora", "Lara", "Maria Clara", "Lívia", "Esther", "Giovanna", "Sarah", "Maria Cecília", "Lorena", "Beatriz", "Rebeca", "Luna", "Olívia", "Maria Helena", "Mariana", "Isadora", "Melissa", "Maria", "Catarina", "Lavínia", "Alícia", "Maria Eduarda", "Agatha", "Ana Liz", "Yasmin", "Emanuelly", "Ana Clara", "Clara", "Ana Júlia", "Marina", "Stella", "Jade", "Maria Liz", "Ana Laura", "Maria Isis", "Ana Luísa", "Gabriela", "Alana", "Rafaela", "Vitória", "Isabelly", "Bella", "Milena" };
            string[] vDominio = { "UOL", "Gmail", "FEMA", "Globo", "yahoo" };

            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente();
                cliente.nome = (i % 2 == 0) ? vNomeMas[i / 2] : vNomeFem[i / 2];
                cliente.email = cliente.nome.ToLower() + "@" + vDominio[randNum.Next() % 5].ToLower() + ".com.br";
                cliente.empresasID = randNum.Next(1, 5);
                contexto.Clientes.Add(cliente);
            }
            contexto.SaveChanges();

            return View(contexto.Clientes.OrderBy(o => o.nome).ToList());
        }

        public IActionResult gerarEmpresas()
        {
            contexto.Database.ExecuteSqlRaw("delete from Empresas");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Empresas', RESEED, 0)");
            Random randNum = new Random();
            string[] vUni = { "Dell EMC", "SAP Labs Latin America", "SAP Brasil", "CI&T", "Vivo", "Oracle do Brasil", "Logicalis", "INTELBRAS", "Mercado Livre", "Getnet", "ALGAR TELECOM", "IBM Brasil", "Clear Sale", "Cielo", "Cognizant Brasil", "Nextel", "Atento Brasil", "Algar Tech", "Teleperformance", "SENIOR SISTEMAS" };

            for (int i = 0; i < 5; i++)
            {
                Empresa empresa = new Empresa();
                empresa.descricao = vUni[i];
                empresa.cnpj = randNum.Next(1, 99).ToString() + "." + randNum.Next(100, 999).ToString() + "." + randNum.Next(100, 999).ToString() + "/0001-" + randNum.Next(1, 99).ToString();
                contexto.Empresas.Add(empresa);
            }
            contexto.SaveChanges();

            return View(contexto.Empresas.OrderBy(o => o.descricao).ToList());
        }

        public IActionResult gerarImpressoras()
        {
            contexto.Database.ExecuteSqlRaw("delete from Impressoras");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Impressoras', RESEED, 0)");
            Random randNum = new Random();

            string[] vImp = { "Ricoh 3710", "Ricoh 320F", "HP2035", "Lexmark E260", "Lexmark E360", "HP M400", "HP M402dne", "HP M402dn", "HP M403dn", "HPM404", "Samsung M4080FX" };

            for (int i = 0; i < 5; i++)
            {
                Impressora impressora = new Impressora();
                impressora.descricao = vImp[i];
                impressora.patrimonio = randNum.Next(100000, 999999);
                contexto.Impressoras.Add(impressora);
            }
            contexto.SaveChanges();

            return View(contexto.Impressoras.OrderBy(o => o.descricao).ToList());
        }

        public IActionResult gerarTonners()
        {
            contexto.Database.ExecuteSqlRaw("delete from Tonners");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Tonners', RESEED, 0)");
            Random randNum = new Random();

            string[] vTon = { "SP3710X", "505A", "E260", "CF226X", "CF258X", "D201L" };
            double[] vValor = { 100.0 , 150.00 , 255.99 , 59.99, 220.50, 310.00};

            for (int i = 0; i < 5; i++)
            {
                Tonner tonner = new Tonner();
                tonner.descricao = vTon[i];
                tonner.valor = vValor[i];
                tonner.quantidade = randNum.Next(0, 5000);
                contexto.Tonners.Add(tonner);
            }
            contexto.SaveChanges();

            return View(contexto.Tonners.OrderBy(o => o.descricao).ToList());
        }
    }
}
