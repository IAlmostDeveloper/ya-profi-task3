using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaProfiThirdTask.Entities;

namespace YaProfiThirdTask.Repositories
{
    /// <summary>
    /// Класс-репозиторий для хранения обьектов промоакций, участников, призов, результатов розыгрышей. Создан, т.к. в задании не было ни слова про базу данных, только API
    /// </summary>
    public class MockPromoRepository : IPromoRepository
    {
        private readonly List<Promo> _promos;

        private int currentPromoId;
        private int currentParticipantId;
        private int currentPrizeId;
        public MockPromoRepository()
        {
            _promos = new List<Promo>();
            currentPromoId = 1;
            currentParticipantId = 1;
            currentPrizeId = 1;
        }

        public Participant AddParticipantToPromo(int promoId, Participant participant)
        {
            var promo = _promos.Where(x => x.Id == promoId).FirstOrDefault();
            participant.Id = currentParticipantId++;
            promo.Participants.Add(participant);
            return participant;
        }

        public Prize AddPrizeToPromo(int id, Prize prize)
        {
            var promo = _promos.Where(x => x.Id == id).FirstOrDefault();
            prize.Id = currentPrizeId++;
            promo.Prizes.Add(prize);
            return prize;
        }

        public Promo AddPromo(Promo promo)
        {
            promo.Id = currentPromoId++;
            promo.Participants = new List<Participant>();
            promo.Prizes = new List<Prize>();
            _promos.Add(promo);
            return promo;
        }

        public Participant DeleteParticipantFromPromo(int promoId, int participantId)
        {
            var promo = _promos.Where(x => x.Id == promoId).FirstOrDefault();
            if (promo == null)
                return null;
            var participant = promo.Participants.Where(x => x.Id == participantId).FirstOrDefault();
            promo.Participants.Remove(participant);
            return participant;
        }

        public Prize DeletePrizeFromPromo(int promoId, int prizeId)
        {
            var promo = _promos.Where(x => x.Id == promoId).FirstOrDefault();
            if (promo == null)
                return null;
            var prize = promo.Prizes.Where(x => x.Id == prizeId).FirstOrDefault();
            promo.Prizes.Remove(prize);
            return prize;
        }

        public Promo DeletePromo(int id)
        {
            var promo = _promos.Where(x => x.Id == id).FirstOrDefault();
            _promos.Remove(promo);
            return promo;
        }

        public Promo GetPromo(int id)
        {
            return _promos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Promo> GetPromos()
        {
            return _promos;
        }

        public Promo UpdatePromo(int id, Promo updatedPromo)
        {
            var promo = _promos.Where(x => x.Id == id).FirstOrDefault();
            promo.Name = updatedPromo.Name;
            promo.Description = updatedPromo.Description;

            return promo;
        }
    }
}
