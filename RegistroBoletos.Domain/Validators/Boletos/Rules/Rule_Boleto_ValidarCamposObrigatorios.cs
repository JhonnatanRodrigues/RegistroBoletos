using RegistroBoletos.Domain.Bases;
using RegistroBoletos.Domain.Entidades.Boletos;

namespace RegistroBoletos.Domain.Validators.Boletos.Rules
{
    public class Rule_Boleto_ValidarCamposObrigatorios : BaseRuleValidator
    {
        private readonly Boleto _boleto;
        private static List<string> _camposNaoPreenchidos = new();

        public Rule_Boleto_ValidarCamposObrigatorios(Boleto boleto)
        {
            _boleto = boleto;
        }

        public override string GetValidationError() => $"Os campos mencionados a baixo são obrigatórios e não foram preenchidos:\n" +
                                                       $"{string.Join("\n", _camposNaoPreenchidos)}";

        public override bool Validate()
        {
            _camposNaoPreenchidos = new List<string>();

            if (string.IsNullOrEmpty(_boleto.NomePagador.Trim()))
                _camposNaoPreenchidos.Add("- Nome do Pagador");

            if (string.IsNullOrEmpty(_boleto.CpfCnpjPagador.Trim()))
                _camposNaoPreenchidos.Add("- CPF/CNPJ do Pagador");

            if (string.IsNullOrEmpty(_boleto.NomeBeneficiario.Trim()))
                _camposNaoPreenchidos.Add("- Nome do Beneficiário");

            if (string.IsNullOrEmpty(_boleto.CpfCnpjBeneficiario.Trim()))
                _camposNaoPreenchidos.Add("- CPF/CNPJ do Beneficiário");

            if (_boleto.Valor <= 0)
                _camposNaoPreenchidos.Add("- Valor");

            if (_boleto.DataVencto == DateTime.MinValue)
                _camposNaoPreenchidos.Add("- Data de vencimento");

            if (_boleto.CodigoBanco == Guid.Empty)
                _camposNaoPreenchidos.Add("- Banco");

            return !_camposNaoPreenchidos.Any();
        }
    }
}
