namespace RegistroBoletos.Domain.Bases
{
    public abstract class BaseRuleValidator
    {
        public bool IsValid { get; private set; }

        public abstract bool Validate();
        public abstract string GetValidationError();

        public void Check()
        {
            IsValid = Validate();
            if (!IsValid)
            {
                throw new InvalidOperationException(GetValidationError());
            }
        }
    }
}
