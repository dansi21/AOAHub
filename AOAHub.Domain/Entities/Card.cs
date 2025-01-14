using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOAHub.Domain.Entities
{
    public class Card
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
    }
}
