using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public static class FirebaseConn<T> where T : class
    {
        private static FirebaseClient client = new FirebaseClient("https://desafioapistone.firebaseio.com/");               

        public static List<T> RecuperarDadosList(string colecao)
        {
            try
            {
                var funcionarios = new List<T>();
                var dadosFirebase = client.Child(colecao).OnceAsync<T>().Result;

                foreach (var dado in dadosFirebase)
                {
                    funcionarios.Add(dado.Object);
                }

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void IncluirDados(string colecao, T classe)
        {
            try
            {
                var dados = JsonConvert.SerializeObject(classe);
                client.Child(colecao).PostAsync(dados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
