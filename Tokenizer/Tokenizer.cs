namespace database.Tokenizer;

public class Tokenizer
{
    private string _command;
    
    public Tokenizer(string command)
    {
        _command = command;
    }

    public Token Tokenize()
    {
        string[] split = _command.Split(":");

        return new Token(split[0].ToLower(), split[1].Trim());
    }
}