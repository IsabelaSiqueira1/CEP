using Caelum.Stella.CSharp.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CEP
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //Consumir dados de endereço em Json
            string cep = "08152100";
            /*string result = GetEndereco(cep);
            Debug.WriteLine(result);*/


            //Endereço formato Json --- utilizando o componente ViaCEP da biblioteca Caelum 
            //Instancia ViaCEP precisa ser transformada em uma instancia localmente para ser extraida
            ViaCEP viaCEP = new ViaCEP();
            string enderecoJson = viaCEP.GetEnderecoJson(cep);
            Debug.WriteLine(enderecoJson);

            //Endereço formato XML
            string enderecoXML =  viaCEP.GetEnderecoXml(cep);
            Debug.WriteLine(enderecoXML);


            //chamada assincrona
            var task = viaCEP.GetEnderecoJsonAsync(cep);
            Debug.WriteLine(task.Result);

            //acessando partes especificas do endereço
            //utilizando o metodo GetEndereco para acessar o endereço completo e  retornar o que desejar
            var endereco = viaCEP.GetEndereco(cep);
            Debug.WriteLine(String.Format("Logradouro: {0}, Bairro: {1} ", endereco.Logradouro, endereco.Bairro));
        }

        private static string GetEndereco(string cep)
        {
            //Para obter o endereço, acessa o objeto HttpCliente do Csharp.
            //utilizar o get para pegar o endereço url assincrono que vem em forma de task e para finalizar obter esse resultado
            //em forma de string, utiliza-se o Result que vai fazer a conversão
            string url = "https://viacep.com.br/ws/" + cep + "/json/";
            string result = new HttpClient().GetStringAsync(url).Result;
            return result;
        }
    }
}
