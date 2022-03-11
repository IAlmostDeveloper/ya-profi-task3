using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YaProfiThirdTask.Entities
{
    /// <summary>
    /// Класс участника промоакции
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// идентификатор участника, натуральное число
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// имя участника, строка
        /// </summary>
        public string Name { get; set; }

    }
}
