using Application.Interfaces;

namespace GildedRose;

using System;
using Twilio; 
using Twilio.Rest.Api.V2010.Account; 
using Twilio.Types; 

public class NotifyService : INotifyService
{
    private readonly string accountSid = "AC688bf5bd4e82901cf909d7e9231898cc";
    private readonly string authToken = "1a7b29902dd6c85dee2a26c24714929a";

    public NotifyService()
    {
        TwilioClient.Init(accountSid, authToken);
    }
    
    public void NotifyPhone(string message, string phoneNumber)
    {
        var messageOptions = new CreateMessageOptions(new PhoneNumber(phoneNumber));
        messageOptions.MessagingServiceSid = "MG4698a22d26e0432300001a899abbdcca";
        messageOptions.Body = message;
 
        var sending = MessageResource.Create(messageOptions);
        Console.WriteLine(sending.Body);
    }
}