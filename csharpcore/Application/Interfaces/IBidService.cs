namespace Application.Interfaces;

public interface IBidService
{
    public bool PriceBetterThan10Percent(float price);

    public void AddBid(float price);

    public void CreateBid(string name, float startPrice);
}