using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YaProfiThirdTask.Entities
{
    /// <summary>
    /// Класс промоакции
    /// </summary>
    public class Promo
    {
        /// <summary>
        /// идентификатор промоакции, натуральное число
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// название промоакции, строка
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// описание промоакции, строка
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  возможные призы в промоакции, список объектов типа “Приз”
        /// </summary>
        [JsonIgnore]
        public List<Prize> Prizes { get; set; }
        /// <summary>
        /// участники промоакции, список объектов типа “Участник”
        /// </summary>
        [JsonIgnore]
        public List<Participant> Participants { get; set; }

    }
}
