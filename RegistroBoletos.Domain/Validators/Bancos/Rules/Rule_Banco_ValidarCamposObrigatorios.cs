using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Bancos;

namespace RegistroBoletos.Domain.Validators.Bancos.Rules
{
    public class Rule_Banco_ValidarCamposObrigatorios : BaseRuleValidator
    {
        private readonly Banco _banco;
        private static List<string> _camposNaoPreenchidos = new();

        public Rule_Banco_ValidarCamposObrigatorios(Banco banco)
        {
            _banco = banco;
        }

        public override string GetValidationError() => $"Os campos mencionados a baixo não foram preenchidos:\n" +
                                                       $"{string.Join("\n", _camposNaoPreenchidos)}";

        public override bool Validate()
        {
            _camposNaoPreenchidos = new List<string>();

            if (string.IsNullOrEmpty(_banco.NomeBanco.Trim()))
                _camposNaoPreenchidos.Add("- Nome do Banco");

            if (string.IsNullOrEmpty(_banco.CodigoBanco.Trim()))
                _camposNaoPreenchidos.Add("- Código do Banco");

            if (_banco.JuroPerc <= 0)
                _camposNaoPreenchidos.Add("- Percentual de Juros");

            return !_camposNaoPreenchidos.Any();
        }
    }
}
