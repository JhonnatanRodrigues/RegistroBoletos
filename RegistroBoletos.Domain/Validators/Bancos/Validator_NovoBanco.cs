using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Bancos;
using RegistroBoletos.Domain.Validators.Bancos.Rules;

namespace RegistroBoletos.Domain.Validators.Bancos
{
    public class Validator_NovoBanco : ValidationGroup
    {
        public Validator_NovoBanco(Banco banco, IRepBanco repBanco)
        {
            AddValidator(new Rule_Banco_ValidarCamposObrigatorios(banco));
            
            //Essa validação não estava descrita no documento, porém achei necessária, pois a consulta por banco é feita usando o código do banco com isso ela deve ser unica.
            AddValidator(new Rule_Banco_CodigoDoBancoDeveSerUnico(banco, repBanco));
        }
    }
}
