using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;

namespace ApiWebMySql3dsn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase{
        // Ométodo que será montado abaixo será chamdo via POST
        [HttpPost]
        //Como será utilizado o protocolo http, devemos retornar nos padrões 
        //do protocolo, ou seja, atraves dos códigos existentes. Para isso 
        //Vamos usar o IActionResult como retorno do método
        //A marcação [FromBody] indica que os dados do Produto irão vir
        //dentro do corpo/Body da requisição HTTP

        public IActionResult cadastrar([FromBody] Produto p) {
            //Configurar a conexão copm o Mysql
            MySqlConnection conexao = new MySqlConnection("server=ESN509VMYSQL; database=apimysqlandroid; uid=aluno; pw=Senai1234");
            MySqlCommand sql = new MySqlCommand(
                "Insert INTO AUTO produto (nome, preco, quantidade) VALUES  (@n,@n,@n)",conexao);
            //Passsar os valores de cada @
            sql.Parameters.AddWithValue("@n", p.nome);
            sql.Parameters.AddWithValue("@n", p.preco);
            sql.Parameters.AddWithValue("@n", p.quantidadde);
            conexao.Open();//Abrir a conexão
            //Testar e executar o resultado do comando sql
            if (sql.ExecuteNonQuery() != 0)
            {// se retornar zero então não alterou nada
                conexao.Clone(); //Fecha a conexão e liberar os recursos
                return Ok(p);//Retorna código 200 - Sucesso e exibe o produto "p" cadastro
            }
            else { 
            conexao.Clone() ;
                return NoContent();//Retorno em branco
            }


        }
    }
}
