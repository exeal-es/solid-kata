namespace DIP;

public class EmailSender
{
    public void Send(Email email)
    {
        Console.WriteLine($"To: {email.To}, Subject: {email.Subject}, Message: {email.Message}");
    }
}