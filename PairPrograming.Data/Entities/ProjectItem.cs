using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairPrograming.Data.Entities
{
    public class ProjectItem
    {
        public ProjectItem(){}
        public ProjectItem(string name){
            Name = name;
        }
        public int Id {get; set;}

        public string Name {get; set;} = string.Empty;
    }
}