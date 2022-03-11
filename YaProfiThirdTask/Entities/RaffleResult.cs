using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YaProfiThirdTask.Entities
{
    /// <summary>
    /// Класс результата проведения розыгрыша
    /// </summary>
    public class RaffleResult
    {
        public RaffleResult(Participant winner, Prize prize)
        {
            Winner = winner;
            Prize = prize;
        }
        /// <summary>
        /// объект типа “Участник”
        /// </summary>
        public Participant Winner { get; set; }
        /// <summary>
        ///  объект типа “Приз”
        /// </summary>
        public Prize Prize { get; set; }

    }
}
