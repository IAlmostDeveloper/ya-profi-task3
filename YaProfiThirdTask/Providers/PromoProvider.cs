using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaProfiThirdTask.Entities;
using YaProfiThirdTask.Extensions;
using YaProfiThirdTask.Repositories;

namespace YaProfiThirdTask.Providers
{
    /// <summary>
    /// Класс с бизнес-логикой работы с промоакциями, участниками, призами, результатами розыгрышей
    /// </summary>
    public class PromoProvider : IPromoProvider
    {
        private readonly IPromoRepository promoRepository;

        public PromoProvider(IPromoRepository promoRepository)
        {
            this.promoRepository = promoRepository;
        }

        public Participant AddParticipantToPromo(int id, Participant participant)
        {
            return promoRepository.AddParticipantToPromo(id, participant);
        }

        public Prize AddPrizeToPromo(int id, Prize prize)
        {
            return promoRepository.AddPrizeToPromo(id, prize);
        }

        public Promo AddPromo(Promo promo)
        {
            return promoRepository.AddPromo(promo);
        }

        public Participant DeleteParticipantFromPromo(int promoId, int participantId)
        {
            return promoRepository.DeleteParticipantFromPromo(promoId, participantId);
        }

        public Prize DeletePrizeFromPromo(int promoId, int prizeId)
        {
            return promoRepository.DeletePrizeFromPromo(promoId, prizeId);
        }

        public Promo DeletePromo(int id)
        {
            return promoRepository.DeletePromo(id);
        }

        public Promo GetPromo(int id)
        {
            return promoRepository.GetPromo(id);
        }

        public IEnumerable<Promo> GetPromos()
        {
            return promoRepository.GetPromos();
        }

        public RaffleResults StartRaffle(int id)
        {
            var promo = promoRepository.GetPromo(id);

            if (promo.Participants.Count == promo.Prizes.Count)
            {
                promo.Participants.Shuffle();
                promo.Prizes.Shuffle();
                var results = new RaffleResults();
                for (var i = 0; i < promo.Participants.Count; i++)
                    results.raffleResults.Add(new RaffleResult(promo.Participants[i], promo.Prizes[i]));
                return results;
            }
            else
                return new RaffleResults();
        }

        public Promo UpdatePromo(int id, Promo promo)
        {
            return promoRepository.UpdatePromo(id, promo);
        }
    }
}
