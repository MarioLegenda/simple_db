namespace database.Validation;

public class ReadIsInteger: IValidator
{
    private string _command;

    public ReadIsInteger(string command)
    {
        _command = command;
    }

    public void Validate()
    {
        string[] split = _command.Split(":");
        string isRead = split[0];

        if (isRead == "read")
        {
            string shouldBeInteger = split[1];
            if (int.TryParse(shouldBeInteger, out int number)) {}
            else
            {
                throw new ArgumentException("A read operation must have an integer as its ID value in the form of 'read:{id}'");
            }
        }
    }
}