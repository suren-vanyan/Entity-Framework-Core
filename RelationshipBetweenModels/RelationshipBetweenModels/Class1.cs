using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationshipBetweenModels
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? TeamId { get; set; } 
        public Team Team { get; set; }  
    }
}
