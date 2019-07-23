using Firebase.Database;
using System;

namespace Repository
{    
    public class FirebaseConn
    {
        private static FirebaseClient client;

        public FirebaseConn()
        {
            client = new FirebaseClient("https://desafioapistone.firebaseio.com/");
        }               

        public static void IncluirDados(string colecao, string dados)
        {
            try
            {
                client.Child(colecao).PostAsync(dados);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
