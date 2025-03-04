namespace RegistroBoletos.Domain.Bases
{
    public abstract class ValidationGroup
    {
        protected ValidationGroup()
        {
        }

        public bool IsValidated { get; private set; }

        private readonly List<BaseRuleValidator> _validators = new();

        public void AddValidator(BaseRuleValidator validator)
        {
            if (validator != null)
                _validators.Add(validator);
        }
        public void Validate()
        {
            List<string> erros = new();

            foreach (var validator in _validators)
            {
                try
                {
                    validator.Check();
                }
                catch (InvalidOperationException ex)
                {
                    erros.Add(ex.Message);
                }
            }

            IsValidated = !erros.Any();

            if (!IsValidated)
                throw new InvalidOperationException(string.Join("\n\n", erros));
        }


    }
}
