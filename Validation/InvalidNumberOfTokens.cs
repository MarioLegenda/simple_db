namespace database.Validation;

public class InvalidNumberOfTokens: IValidator
{
    private string _command;

    public InvalidNumberOfTokens(string command)
    {
        _command = command;
    }
    
    public void Validate()
    {
        string[] split = _command.Split(":");
        if (split.Length != 2)
        {
            throw new ArgumentException("Invalid token. Token must be either write:{token} or read:{id}");
        }
    }
}