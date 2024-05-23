using CardInfoProvider.Entities;
using CardInfoProvider.Models;
using CardInfoProvider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CardInfoProvider.Functions
{
    public class CardCreater(ILogger<CardCreater> logger, ICardService cardService)
    {
        private readonly ILogger<CardCreater> _logger = logger;
        private readonly ICardService _cardService = cardService;

        [Function("CardCreater")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            try
            {
                string massage = await new StreamReader(req.Body).ReadToEndAsync();
                var model = JsonConvert.DeserializeObject<CardInfoModel>(massage);
                if (true)
                {
                    var cardInfo = new CardInfo
                    {
                        CardName = model.CardholderName,
                        CardNumber = model.CardNumber,
                        ExpiryDate = model.ExpiryDate,
                        CVV = model.CVV
                    };
                    if (cardInfo != null)
                    {
                        await _cardService.AddCardInfo(cardInfo);
                        //await _cardService.SaveChangesAsync();
                        return new CreatedResult("", cardInfo);
                    }
                }
                return new BadRequestResult();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}
