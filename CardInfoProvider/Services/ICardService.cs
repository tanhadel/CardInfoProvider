using CardInfoProvider.Entities;
using CardInfoProvider.Models;

namespace CardInfoProvider.Services;

public interface ICardService
{
    Task<bool> AddCardInfo(CardInfo cardInfo);
    Task SaveChangesAsync();
}