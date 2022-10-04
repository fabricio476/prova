using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;


namespace Controllers
{

    
    [ApiController]
    [Route("api/folha")]
    public class FolhaPagamentoController : ControllerBase
    {

         private readonly DataContext _context;



         public FolhaPagamentoController(DataContext context) =>
            _context = context;



         // GET: /api/folha/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Folhas.ToList());


        // POST: /api/folha/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {

           Funcionario funcionaio = _context.Funcionarios.FirstOrDefault(f=> f.Cpf == folha.cpfFuncionario);

           FolhaPagamento folha2 = new FolhaPagamento(funcionaio);

            _context.Folhas.Add(folha2);
            _context.SaveChanges();
            return Created("", folha2);
        }


       [HttpGet]
       [Route("buscar/{cpf}/{mes}/{ano}")]
       public IActionResult BuscarFolha([FromRoute] string cpf, string mes, string ano){

         
         FolhaPagamento folha = _context.Folhas.FirstOrDefault(a => a.mes == mes && a.ano == ano && a.cpfFuncionario == cpf);

        Funcionario funcionaio = _context.Funcionarios.FirstOrDefault(f=> f.Cpf == folha.cpfFuncionario);

        folha.funcionario = funcionaio;
           
       
          return Ok(folha);
       }


       [HttpGet]
       [Route("filtrar/{mes}/{ano}")]
       public IActionResult Filtrar(string mes, string ano){

          List<FolhaPagamento> folhas = new List<FolhaPagamento>();
           var busca = _context.Folhas.ToList().Where(f=> f.mes.Equals(mes)  && f.ano.Equals(ano)  );
           
              for(int i =0; i < busca.Count(); i++){

                    busca.ElementAt(1).funcionario = _context.Funcionarios.FirstOrDefault(f=> f.Cpf == busca.ElementAt(i).cpfFuncionario);
              }
           
    

          return Ok(busca.ToList());
       }


           






    }



}