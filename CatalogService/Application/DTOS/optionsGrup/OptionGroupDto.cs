using Application.DTOS.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.optionsGrup
{
    public class OptionGroupDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Sequence { get; set; } = 0;
        public int Min { get; set; }
        public int Max { get; set; }
        public List<OptionDto> Options { get; set; } = new List<OptionDto>();
        public string Type { get; set; } // INGRETIENT, ADDON, BASE, TOPPING
        public int Order { get; set; }
        public bool IsShared { get; set; } = false;
        public List<int> Fractions { get; set; }

    }
}
