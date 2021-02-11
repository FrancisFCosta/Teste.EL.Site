using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Teste.EL.Site.Infrastructure.Repositories.BaseRepository
{
    public class BaseRepository
    {
        #region [ Atributos ]

        private readonly string _url;
        private const int _tiemout = 120000;
        private string _endPoint;
        protected Dictionary<string, string> _headerAdicional = null;

        #endregion

        #region [ Construtores ]

        public BaseRepository(string url)
        {
            _url = url;
        }

        #endregion

        private string RotaCompleta
        {
            get { return string.Format("{0}{1}", _url, _endPoint); }
        }

        protected T Get<T>(string rota, string jwtToken, Dictionary<string, object> parametros)
        {
            _endPoint = rota;
            return chamar<T>(Method.GET, jwtToken, parametros, null);
        }
        protected T Delete<T>(string rota, string jwtToken, Dictionary<string, object> parametros)
        {
            _endPoint = rota;
            return chamar<T>(Method.DELETE, jwtToken, parametros, null);
        }

        protected T Post<T>(string rota, string jwtToken, object corpoRequisicao)
        {
            _endPoint = rota;
            return chamar<T>(Method.POST, jwtToken, null, corpoRequisicao);
        }

        protected void Put<T>(string rota, string jwtToken, object corpoRequisicao)
        {
            _endPoint = rota;
            chamar<T>(Method.PUT, jwtToken, null, corpoRequisicao);
        }

        private T chamar<T>(Method method, string jwtToken, object parametrosUrl, object corpoRequisicao)
        {
            var cliente = new RestClient(RotaCompleta);

            var request = ObterRequestComHeader(method, jwtToken);
            request.Timeout = _tiemout;
            if (parametrosUrl != null)
                AdicionarParametrosURLRequisicao(parametrosUrl, request);

            if (corpoRequisicao != null)
                request.AddJsonBody(corpoRequisicao);

            var response = cliente.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Created)
                return JsonSerializer.Deserialize<T>(response.Content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default(T);
            else
                throw new Exception($"Codigo Erro (http): {response.StatusCode}, Mensagem:{ response.Content}");
        }

        protected virtual RestRequest ObterRequestComHeader(Method method, string jwtToken)
        {
            var request = new RestRequest(method);

            request.UseDefaultCredentials = true;
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("content-type", "application/json; charset=utf-8");
            request.AddHeader("accept-charset", "Accept-Charset:ISO-8859-1,utf-8;q=0.7,*;q=0.3");

            if (!String.IsNullOrWhiteSpace(jwtToken))
                request.AddHeader("Authorization", $"bearer {jwtToken}");

            return request;
        }
        private void AdicionarParametrosURLRequisicao(object parametros, RestRequest request)
        {
            if (parametros != null)
            {
                var param = parametros as Dictionary<string, object>;
                foreach (var parametro in param)
                    request.AddParameter(parametro.Key, parametro.Value, ParameterType.QueryString);
            }
        }
    }
}
