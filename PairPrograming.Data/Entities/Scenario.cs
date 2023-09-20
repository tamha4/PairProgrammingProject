using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairPrograming.Data.Entities
{
    public class Scenario
    {
        public int Id { get; set; }

        public List<string> GameScenes = new List<string>();
        
    }
}