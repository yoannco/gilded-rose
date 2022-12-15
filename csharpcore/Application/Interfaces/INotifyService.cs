namespace Application.Interfaces;

public interface INotifyService
{
    public void NotifyWhatsapp(string message, string phoneNumber);
}