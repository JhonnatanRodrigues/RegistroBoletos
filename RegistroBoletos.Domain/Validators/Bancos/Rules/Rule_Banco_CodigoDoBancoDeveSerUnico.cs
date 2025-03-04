using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Bancos;

namespace RegistroBoletos.Domain.Validators.Bancos.Rules
{
    public class Rule_Banco_CodigoDoBancoDeveSerUnico : BaseRuleValidator
    {
        private readonly Banco _banco;
        private readonly IRepBanco _repBanco;

        public Rule_Banco_CodigoDoBancoDeveSerUnico(Banco banco, IRepBanco repBanco)
        {
            _banco = banco;
            _repBanco = repBanco;
        }

        public override string GetValidationError() => $"O código do banco: '{_banco.CodigoBanco}', já existe!";

        public override bool Validate()
        {
            var bancoJaCadastrado = _repBanco.Consulta.Any(p => p.CodigoBanco == _banco.CodigoBanco && p.Id != _banco.Id);

            return !bancoJaCadastrado;
        }
    }
}
