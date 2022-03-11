using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YaProfiThirdTask.Entities
{
    public class RaffleResults
    {
        public RaffleResults()
        {
            raffleResults = new List<RaffleResult>();
        }
        /// <summary>
        /// Список участников, выигравших призы
        /// </summary>
        public List<RaffleResult> raffleResults { get; set; }
    }
}
