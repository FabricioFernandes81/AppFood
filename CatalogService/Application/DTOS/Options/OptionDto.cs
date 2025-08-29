using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.Options
{
    public class OptionDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<OptionContextModifierDto> contextModifiers { get; set; }
        public List<int>? Fraction { get; set; }
    }
}
