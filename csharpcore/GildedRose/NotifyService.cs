namespace GildedRose;

using System;
using Twilio; 
using Twilio.Rest.Api.V2010.Account; 
using Twilio.Types; 

public class NotifyService
{
    private readonly string accountSid = "AC688bf5bd4e82901cf909d7e9231898cc";
    private readonly string authToken = "088194206f8f24726e20c6c096d668aa";

    public NotifyService()
    {
        TwilioClient.Init(accountSid, authToken);
    }
    
    public void NotifyWhatsapp(string message, string phoneNumber)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber($"whatsapp:{phoneNumber}"));
        messageOptions.From = new PhoneNumber("whatsapp:+14155238886");  
        messageOptions.Body = message;
 
        var sending = MessageResource.Create(messageOptions);
        Console.WriteLine(sending.Body);
    }
}