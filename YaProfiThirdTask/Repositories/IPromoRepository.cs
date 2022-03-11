using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaProfiThirdTask.Entities;

namespace YaProfiThirdTask.Repositories
{
    public interface IPromoRepository
    {
        IEnumerable<Promo> GetPromos();
        Promo GetPromo(int id);
        Promo AddPromo(Promo promo);
        Promo UpdatePromo(int id, Promo promo);
        Promo DeletePromo(int id);
        Participant AddParticipantToPromo(int promoId, Participant participant);
        Participant DeleteParticipantFromPromo(int promoId, int participantId);
        Prize AddPrizeToPromo(int id, Prize prize);
        Prize DeletePrizeFromPromo(int promoId, int prizeId);
    }
}
