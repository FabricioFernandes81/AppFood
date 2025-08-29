using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class CuisinesDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public CuisinesDto(string code, string name)
        {
            Code = code;
            Name = name;
        }
        public CuisinesDto()
        {
        }
    }
}
