using System.ComponentModel.DataAnnotations;

namespace CardInfoProvider.Entities;

public class CardInfo
{
    [Key]
    public int Id { get; set; }
    public string CardName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string ExpiryDate { get; set; } = null!;
    public string CVV { get; set; } = null!;

}
