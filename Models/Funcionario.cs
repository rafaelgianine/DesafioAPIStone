using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Funcionario
    {
        public const int salarioMinimo = 954; // valor em vigencia de 07/2019

        public string matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public decimal salario_bruto { get; set; }
        public string data_de_admissao { get; set; }
        public int pesoArea
        {
            get
            {
                switch (area.ToUpper())
                {
                    case "CONTATABILIDADE":
                    case "FINANCEIRO":
                    case "TECNOLOGIA":
                        return 2;
                    case "SERVIÇOS GERAIS":
                        return 3;
                    case "RELACIONAMENTO COM O CLIENTE":
                        return 5;
                    case "DIRETORIA":
                    default:
                        return 1;
                }
            }
        }

        public int pesoSalario
        {
            get
            {
                if (salario_bruto > (salarioMinimo * 8))
                    return 5;
                else if (salario_bruto > (salarioMinimo * 5))
                    return 3;
                else if (salario_bruto > (salarioMinimo * 3))
                    return 2;
                else
                    return 1;
            }
        }

        public int pesoAdmissao
        {
            get
            {
                if (CalcularTempoDeCasa(data_de_admissao) > 8)
                    return 5;
                else if (CalcularTempoDeCasa(data_de_admissao) > 3)
                    return 3;
                else if (CalcularTempoDeCasa(data_de_admissao) > 1)
                    return 2;
                else
                    return 1;
            }
        }

        private static int CalcularTempoDeCasa(string data_admissao)
        {
            var dataAdmissaoDtTime = DateTime.Parse(data_admissao);

            return Convert.ToInt32(Math.Truncate((DateTime.Now - dataAdmissaoDtTime).TotalDays / 365));
        }


        public static List<Funcionario> CarregarFuncionariosList()
        {
            try
            {
                var funcionarios = FirebaseConn<Funcionario>.RecuperarDadosList("funcionarios");

                return funcionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// recebe o json com os dados dos funcionários para serem inseridos em nossa base.
        /// </summary>
        /// <param name="json"></param>
        public static void IncluirFuncionario(string json)
        {
            try
            {
                var funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(json);

                foreach (var funcionario in funcionarios)
                {
                    FirebaseConn<Funcionario>.IncluirDados("funcionarios", funcionario);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
