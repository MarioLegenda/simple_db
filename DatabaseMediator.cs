using System.Net.Sockets;
using database.Database;
using database.Tokenizer;
using database.Validation;

namespace database;

public class DatabaseMediator: IRunningMediator
{
    private readonly Driver _driver;
    
    public DatabaseMediator(Driver driver)
    {
        _driver = driver;
    }
    
    public void Notify(string command, NetworkStream stream)
    {
        // validate the incoming request through a number of validators
        // this could be written to be more simple but want to be in the fancy world of OOP
        // for example, this could be just a simple function. 
                
        // If you need to extend the validation, just add another validator 
        try
        {
            Validator validator = new Validator();

            validator
                .AddValidator(new InvalidNumberOfTokens(command))
                .AddValidator(new InvalidOperation(command))
                .AddValidator(new ReadIsInteger(command));
                
            validator.Validate();
        }
        catch (ArgumentException e)
        {
            database.Server.StreamWriter.Write(stream, "Error: " + e.Message + "\r\n"); 
        }

        // create the token to determine if a request is either read or write
        Token token = new Tokenizer.Tokenizer(command).Tokenize();
        // create the driver with the dsn string
        
        // when we have a token, we can determine if the token is
        // either read or write. at this point, the values of GetTokenType()
        // must be either write or read since they are validated and tokenized.
        if (token.GetTokenType() == "write")
        {
            IWriter writer = _driver.GetWriter();
            writer.Write(token.GetTokenData());
            
            database.Server.StreamWriter.Write(stream, "Success" + Environment.NewLine);
        } 
        else if (token.GetTokenType() == "read")
        {
            IReader reader = _driver.GetReader();
            string value = reader.Read(token.GetTokenData());
            
            database.Server.StreamWriter.Write(stream, value + Environment.NewLine);
        }
    }
}