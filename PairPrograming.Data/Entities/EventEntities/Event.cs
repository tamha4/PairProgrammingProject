using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairProgramming.Data.Entities.EventEntities
{
    public class Event
    {
        public int ID { get; set; }
        public string EventDescription { get; set; } = string.Empty;
        public List<string> EventTasks { get; set; } = new List<string>();
        public bool IsComplete
        {
            get
            {
                return (EventTasks.Count <= 0) ? true : false;
            }
        }
    }
}