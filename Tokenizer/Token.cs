namespace database.Tokenizer;

public struct Token
{
    private readonly string _tokenType;
    private readonly string _tokenData;
    
    public Token(string tokenType, string tokenData)
    {
        _tokenType = tokenType;
        _tokenData = tokenData;
    }
    
    public string GetTokenType()
    {
        return _tokenType;
    }

    public string GetTokenData()
    {
        return _tokenData;
    }
}