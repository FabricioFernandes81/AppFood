using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.categories
{
    public class PostCategoryDto
    {
        public string? CategoryId { get; set; }
        public string Name { get; set; }
        public ResourcesStatus? Status { get; set; } = ResourcesStatus.AVAILABLE;
        public int Index { get; set; } = 0;
        public ResourcesType? Template { get; set; } = ResourcesType.DEFAULT ; 

        public List<string>? Catalogs { get; set; }
     }
}
