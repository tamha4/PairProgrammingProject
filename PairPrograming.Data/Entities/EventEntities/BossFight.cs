using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PairProgramming.Data.Entities.EnemyEntities;

namespace PairProgramming.Data.Entities.EventEntities
{
    public class BossFight : Event
    {
        public Boss? Boss { get; set; } = new Boss();
    }
}