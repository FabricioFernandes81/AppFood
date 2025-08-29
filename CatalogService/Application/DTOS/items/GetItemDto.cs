using Application.DTOS.optionsGrup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.items
{
    public class GetItemDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }

        public string Availability { get; set; }  //Disponibilidade do item
        public List<OptionGroupDto> optionGroup { get; set; }
        public bool Hasviolation { get; set; }
        public bool IsIndustrialized { get; set; }
        public string Problems { get; set; }
        public string ProductId { get; set; }

        public  string Type { get; set; } // ITEM, COMBO
        
        public string CategoryId { get; set; }
        public string Status { get; set; } // Available, Unavailable
    }
}
