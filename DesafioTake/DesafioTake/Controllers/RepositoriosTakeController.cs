using DesafioTake.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DesafioTake.Controllers
{
    /// <summary>
    /// Consultar os repositórios Git da Take Blip
    /// </summary>
    public class RepositoriosTakeController : ApiController
    {
        /// <summary>
        /// Retorna os repositóris Git da Take Blip
        /// </summary>
        /// <param name="quantidade">Quantidade de registros</param>
        /// <param name="ordem">Ordenação por data de criação ("asc" ou "desc"). Padrão: desc</param>
        /// <param name="linguagem">Filtro por linguagem</param>
        /// <returns></returns>
        public RepositoriosTakeRetorno Get([FromUri] int quantidade = 0, string ordem = null, string linguagem = null)
        {
            try
            {
                string stringJson = BuscarRepositorios(ordem);
                IEnumerable<dynamic> repositoriosFiltrados = FiltrarResultado(stringJson, quantidade, linguagem);

                //Montando objeto de retorno
                RepositoriosTakeRetorno retorno = new RepositoriosTakeRetorno(repositoriosFiltrados);
                
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string BuscarRepositorios(string ordem)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "request");

            string endpoint = "https://api.github.com/orgs/takenet/repos?sort=created";
            if (!string.IsNullOrEmpty(ordem))
                ordem = ordem.ToLower();
            if (ordem == "asc" || ordem == "desc")
                endpoint += "&direction=" + ordem;

            var retorno = httpClient.GetAsync(endpoint);
            retorno.Wait();
            return retorno.Result.Content.ReadAsStringAsync().Result;
        }

        private IEnumerable<dynamic> FiltrarResultado(string stringJson, int quantidade, string linguagem)
        {
            IEnumerable<dynamic> repositoriosFiltrados = (IEnumerable<dynamic>)JsonConvert.DeserializeObject(stringJson);
            
            //filtrando pela linguagem
            if (!string.IsNullOrEmpty(linguagem))
                repositoriosFiltrados = repositoriosFiltrados.Where(x => x.language != null && ((string)x.language).ToUpper() == linguagem.ToUpper());

            //limitando à quantidade solicitada
            if (quantidade > 0)
                repositoriosFiltrados = repositoriosFiltrados.Take(quantidade);

            return repositoriosFiltrados;
        }
    }
}
