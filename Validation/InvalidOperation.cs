namespace database.Validation;

public class InvalidOperation: IValidator
{
    private string _command;

    public InvalidOperation(string command)
    {
        _command = command;
    }
    
    public void Validate()
    {
        string[] split = _command.Split(":");
        string operation = split[0];
        
        if (operation != "write" && operation != "read")
        {
            throw new ArgumentException("An operation can be either read or write");
        }
    }
}