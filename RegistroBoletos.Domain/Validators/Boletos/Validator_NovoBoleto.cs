using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Boletos;
using RegistroBoletos.Domain.Validators.Boletos.Rules;

namespace RegistroBoletos.Domain.Validators.Boletos
{
    public class Validator_NovoBoleto : ValidationGroup
    {
        public Validator_NovoBoleto(Boleto boleto)
        {
            AddValidator(new Rule_Boleto_ValidarCamposObrigatorios(boleto));

            AddValidator(new Rule_Boleto_ValidarCPFCNPJ(boleto.CpfCnpjBeneficiario, "Beneficiário"));
            AddValidator(new Rule_Boleto_ValidarCPFCNPJ(boleto.CpfCnpjPagador, "Pagador"));
        }
    }
}
