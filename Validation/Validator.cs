namespace database.Validation;

public class Validator: IValidator
{
    private readonly List<IValidator> _validators = new();

    public Validator AddValidator(IValidator validator)
    {
        _validators.Add(validator);

        return this;
    }

    public void Validate()
    {
        foreach (var validator in _validators)
        {
            validator.Validate();
        }
    }
}