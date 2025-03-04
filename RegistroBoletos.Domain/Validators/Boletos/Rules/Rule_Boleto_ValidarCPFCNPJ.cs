using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Boletos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroBoletos.Domain.Validators.Boletos.Rules
{
    public class Rule_Boleto_ValidarCPFCNPJ : BaseRuleValidator
    {
        private readonly string _cpfCnpj;
        private readonly string _pessoa;

        public Rule_Boleto_ValidarCPFCNPJ(string cpfCnpj, string pessoa)
        {
            _cpfCnpj = cpfCnpj;
            _pessoa = pessoa;
        }

        public override string GetValidationError() => $"O CPF/CNPJ de {_pessoa} é inválido. Apenas números são permitidos. Se for um CPF, deve ter 11 caracteres. Se for um CNPJ, deve ter 14 caracteres.";

        public override bool Validate()
        {
            var numeros = new string(_cpfCnpj.Where(char.IsDigit).ToArray());

            if (numeros.Length == 11)
            {
                return ValidarCpf(numeros);
            }
            else if (numeros.Length == 14)
            {
                return ValidarCnpj(numeros);
            }

            return false;
        }

        private static bool ValidarCpf(string cpf)
        {
            if (cpf.All(c => c == cpf[0]))
                return false;

            int soma = 0;
            int resto;

            for (int i = 0; i < 9; i++)
            {
                soma += (cpf[i] - '0') * (10 - i);
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (cpf[9] - '0' != resto)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (cpf[i] - '0') * (11 - i);
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (cpf[10] - '0' != resto)
                return false;

            return true;
        }

        private static bool ValidarCnpj(string cnpj)
        {
            if (cnpj.All(c => c == cnpj[0]))
                return false;

            int[] pesos1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] pesos2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;
            int resto;

            for (int i = 0; i < 12; i++)
            {
                soma += (cnpj[i] - '0') * pesos1[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (cnpj[12] - '0' != resto)
                return false;

            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += (cnpj[i] - '0') * pesos2[i];
            }
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            if (cnpj[13] - '0' != resto)
                return false;

            return true;
        }
    }
}
