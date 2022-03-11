using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YaProfiThirdTask.Entities
{
    /// <summary>
    /// Класс приза в промоакции
    /// </summary>
    public class Prize
    {
        /// <summary>
        /// идентификатор приза, натуральное число
        /// </summary>
        [JsonIgnore]
        public int Id { get; set; }
        /// <summary>
        /// описание приза, строка
        /// </summary>
        public string Description { get; set; }

    }
}
