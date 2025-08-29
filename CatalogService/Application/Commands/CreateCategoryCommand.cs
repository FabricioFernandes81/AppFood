using Application.DTOS.categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCategoryCommand 
    {
        public string MerchantId { get; }
        public string? CategoryId { get; }
        public string Name { get; }
        public string? Description { get; } = null;
        public string Status { get; }
        public int Index { get; } = 0;
        public string Template { get; } = "DEFAULT";

        public List<string>? Catalogs { get; }
        public CreateCategoryCommand(string merchantId, PostCategoryDto postCategoryDto)
        {
            MerchantId = merchantId;
            CategoryId = postCategoryDto.CategoryId;
            Name = postCategoryDto.Name;
            Status = postCategoryDto.Status?.ToString() ?? "AVAILABLE";
            Index = postCategoryDto.Index;
            Template = postCategoryDto.Template?.ToString() ?? "DEFAULT";
            Catalogs = postCategoryDto.Catalogs;
        }
    }
}
