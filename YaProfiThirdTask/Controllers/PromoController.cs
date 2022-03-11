using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YaProfiThirdTask.Entities;
using YaProfiThirdTask.Providers;

namespace YaProfiThirdTask.Controllers
{
    /// <summary>
    /// Класс-контроллер, содержащий эндпоинты для обращения к API
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PromoController : ControllerBase
    {
        private readonly ILogger<PromoController> _logger;
        private readonly IPromoProvider promoProvider;

        public PromoController(ILogger<PromoController> logger, IPromoProvider promoProvider)
        {
            _logger = logger;
            this.promoProvider = promoProvider;
        }

        /// <summary>
        /// Получение краткой информации (без информации об участниках и призах) обо всех промоакциях
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Promo> Get()
        {
            return Ok(promoProvider.GetPromos());
        }
        /// <summary>
        /// Добавление промоакции с возможностью указания названия (name), описания (description) 
        /// Описание – не обязательный параметр, название – обязательный
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody] Promo promo)
        {
            if (string.IsNullOrWhiteSpace(promo.Name))
            {
                return BadRequest();
            }
            else
                return Ok(promoProvider.AddPromo(promo).Id);
        }

        /// <summary>
        /// Получение полной информации (с информацией об участниках и призах) о промоакции по идентификатору
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetPromoById(int id)
        {
            var promo = promoProvider.GetPromo(id);
            if (promo == null)
                return NotFound();
            return Ok(new {id = promo.Id, name= promo.Name, description = promo.Description, prizes=promo.Prizes, participants=promo.Participants});
        }

        /// <summary>
        /// Редактирование промо-акции по идентификатору промо-акции
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdatePromoById(int id, [FromBody] Promo promo)
        {
            var promoToUpdate = promoProvider.UpdatePromo(id, promo);
            if (promoToUpdate == null)
                return NotFound();
            return Ok(promoToUpdate);
        }

        /// <summary>
        /// Удаление промоакции по идентификатору
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeletePromoById(int id)
        {
            var promo = promoProvider.DeletePromo(id);
            if (promo == null)
                return NotFound();
            return Ok(promo);
        }

        /// <summary>
        /// Добавление участника в промоакцию по идентификатору промоакции
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/participant")]
        public ActionResult AddParticipantToPromo(int id, [FromBody] Participant participant)
        {
            return Ok(promoProvider.AddParticipantToPromo(id, participant).Id);
        }

        /// <summary>
        /// Удаление участника из промоакции по идентификаторам промоакции и участника
        /// </summary>
        /// <param name="promoId"></param>
        /// <param name="participantId"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("{promoId}/participant/{participantId}")]
        public ActionResult DeleteParticipantFromPromo(int promoId, int participantId)
        {
            var participant = promoProvider.DeleteParticipantFromPromo(promoId, participantId);
            if (participant == null)
                return NotFound();
            return Ok(participant);
        }

        /// <summary>
        /// Добавление приза в промоакцию по идентификатору промоакции
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prize"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/prize")]
        public ActionResult AddPrizeToPromo(int id, [FromBody] Prize prize)
        {
            var prizeToAdd = promoProvider.AddPrizeToPromo(id, prize);
            return Ok(prizeToAdd.Id);
        }

        /// <summary>
        /// Удаление приза из промоакции по идентификаторам промоакции и приза
        /// </summary>
        /// <param name="promoId"></param>
        /// <param name="prizeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{promoId}/prize/{prizeId}")]
        public ActionResult DeletePrizeFromPromo(int promoId, int prizeId)
        {
            var prize = promoProvider.DeletePrizeFromPromo(promoId, prizeId);
            if (prize == null)
            {
                return NotFound();
            }
            return Ok(prize);
        }

        /// <summary>
        /// Проведение розыгрыша призов в промоакции по идентификатору промоакции
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/raffle")]
        public ActionResult StartRaffle(int id)
        {
            var result = promoProvider.StartRaffle(id);

            if (result.raffleResults.Count == 0)
                return Conflict();

            return Ok(result.raffleResults);
        }
    }
}
