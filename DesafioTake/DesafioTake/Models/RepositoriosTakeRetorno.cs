using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioTake.Models
{
    public class RepositoriosTakeRetorno
    {
        string nomePadrao = "Não encontrado";
        string descricaoPadrao = "-";
        IEnumerable<dynamic> Repositorios { get; set; }

        [JsonProperty("avatar")]
        public string Avatar
        {
            get
            {
                if (Repositorios.Count() == 0)
                    return "";

                return Repositorios.ToArray()[0].owner.avatar_url;
            }
        }
        [JsonProperty("nome1")]
        public string Nome1
        {
            get
            {
                if (Repositorios.Count() >= 1)
                    return Repositorios.ToArray()[0].full_name;
                else
                    return nomePadrao;
            }
        }
        [JsonProperty("descricao1")]
        public string Descricao1
        {
            get
            {
                if (Repositorios.Count() >= 1)
                    return Repositorios.ToArray()[0].description;
                else
                    return descricaoPadrao;
            }
        }
        [JsonProperty("nome2")]
        public string Nome2
        {
            get
            {
                if (Repositorios.Count() >= 2)
                    return Repositorios.ToArray()[1].full_name;
                else
                    return nomePadrao;
            }
        }
        [JsonProperty("descricao2")]
        public string Descricao2
        {
            get
            {
                if (Repositorios.Count() >= 2)
                    return Repositorios.ToArray()[1].description;
                else
                    return descricaoPadrao;
            }
        }
        [JsonProperty("nome3")]
        public string Nome3
        {
            get
            {
                if (Repositorios.Count() >= 3)
                    return Repositorios.ToArray()[2].full_name;
                else
                    return nomePadrao;
            }
        }
        [JsonProperty("descricao3")]
        public string Descricao3
        {
            get
            {
                if (Repositorios.Count() >= 3)
                    return Repositorios.ToArray()[2].description;
                else
                    return descricaoPadrao;
            }
        }
        [JsonProperty("nome4")]
        public string Nome4
        {
            get
            {
                if (Repositorios.Count() >= 4)
                    return Repositorios.ToArray()[3].full_name;
                else
                    return nomePadrao;
            }
        }
        [JsonProperty("descricao4")]
        public string Descricao4
        {
            get
            {
                if (Repositorios.Count() >= 4)
                    return Repositorios.ToArray()[3].description;
                else
                    return descricaoPadrao;
            }
        }
        [JsonProperty("nome5")]
        public string Nome5
        {
            get
            {
                if (Repositorios.Count() >= 5)
                    return Repositorios.ToArray()[4].full_name;
                else
                    return nomePadrao;
            }
        }
        [JsonProperty("descricao5")]
        public string Descricao5
        {
            get
            {
                if (Repositorios.Count() >= 5)
                    return Repositorios.ToArray()[4].description;
                else
                    return descricaoPadrao;
            }
        }

        public RepositoriosTakeRetorno(IEnumerable<dynamic> listaRepositorios)
        {
            Repositorios = listaRepositorios;
        }
    }
}