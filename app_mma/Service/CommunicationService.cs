using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using app_mma.Model;
using app_mma.Util;
using Newtonsoft.Json;

namespace app_mma.Service
{
    public static class CommunicationService
    {


        private static string _url = "http://177.36.237.87/lutadores/api/competidores/";


        public static async Task<List<Lutador>> GetAllLutadores()
        {
            try
            {

                var resp = await HttpUtil.GetAsync(_url);

                if (resp.IsSuccessStatusCode)
                {
                    var resposta = await resp.Content.ReadAsStringAsync();

                    var lutadores = JsonConvert.DeserializeObject<List<Lutador>>(resposta);

                    return lutadores;
                }
                else return null;
                    
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Erro: " + ex.Message);
                return null;
            }

        }
    }
}
