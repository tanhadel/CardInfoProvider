using CardInfoProvider.context;
using CardInfoProvider.Entities;

namespace CardInfoProvider.Services;
public class CardService : ICardService
{
    private readonly CardDbContext _context;

    public CardService(CardDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCardInfo(CardInfo cardInfo)
    {
        _context.CardInfos.Add(cardInfo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}