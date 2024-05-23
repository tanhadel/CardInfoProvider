namespace CardInfoProvider.Models;

public class CardInfoModel
{
    public string CardholderName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string ExpiryDate { get; set; } = null!;
    public string CVV { get; set; } = null!;
}
