using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.categories
{
    public class GetCategoryDto
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int ItemCount { get; set; }
        public bool HasViolations { get; set; } = false;
        public bool CanEdit { get; set; } = true;
        public string Status { get; set; }
        public List<string>? Items { get; set; }
        public bool Available { get; set; } = true;

    }
}
