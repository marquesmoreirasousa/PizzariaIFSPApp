using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzariaIFSPApp.Util
{
    internal class Seguranca
    {
        //https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
        public static string ComputeSha256Hash(string text)
        {
            // Create a SHA256   
            SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        //https://stackoverflow.com/questions/34715501/validating-password-using-regex-c-sharp
        public static bool ValidarSenha(string senha)
        {
            var possuiNumeros = new Regex(@"[0-9]+");
            var possuiMaiusc = new Regex(@"[A-Z]+");
            var possuiOito = new Regex(@".{8,}");

            var valido = possuiNumeros.IsMatch(senha) && 
                         possuiMaiusc.IsMatch(senha) && 
                         possuiOito.IsMatch(senha);
            return valido;
        }
        public static bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11)
                return false;
            else
            {
                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (Convert.ToInt32(cpf[i]) - 48) * (10 - i);

                int digito = (11 - (soma % 11)) > 9 ? 0 : 11 - (soma % 11);
                if (digito == Convert.ToInt32(cpf[9] - 48))
                {
                    soma = 0;
                    for (int i = 0; i < 10; i++)
                        soma += (Convert.ToInt32(cpf[i]) - 48) * (11 - i);

                    digito = (11 - (soma % 11)) > 9 ? 0 : 11 - (soma % 11);
                    if (digito == Convert.ToInt32(cpf[10] - 48))
                        return true;
                }
            }
            return false;
        }
    }
}
