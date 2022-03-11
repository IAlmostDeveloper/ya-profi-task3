using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaProfiThirdTask.Entities;

namespace YaProfiThirdTask.Providers
{
    public interface IPromoProvider
    {
        IEnumerable<Promo> GetPromos();
        Promo AddPromo(Promo promo);
        Promo GetPromo(int id);
        Promo UpdatePromo(int id, Promo promo);
        Promo DeletePromo(int id);
        Participant AddParticipantToPromo(int id, Participant participant);
        Participant DeleteParticipantFromPromo(int promoId, int participantId);
        Prize AddPrizeToPromo(int id, Prize prize);
        Prize DeletePrizeFromPromo(int promoId, int prizeId);
        RaffleResults StartRaffle(int id);
    }
}
