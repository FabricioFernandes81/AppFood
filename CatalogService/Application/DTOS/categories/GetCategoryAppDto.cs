using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.categories
{
    public class GetCategoryAppDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Seqsuence { get; set; }
        public int Index { get; set; }
        public string Template { get; set; }

        public List<GetItemAppDto> Items {  get; set; }
    }

    public class GetItemAppDto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao {  get; set; }
        public string Status { get; set; }
        public string ProductId {  get; set; }
        public List<optionGroupsAppDto> OptionGroups { get; set; }
        public List<ContextModifiersDto> contextModifiers { get; set; }
        
        public List<customizationModifiersDto> CustomizationModifiers { get; set; }

    }

    public class optionGroupsAppDto 
    { 
        public string Id { get; set; }
        public string Nome {  get; set; }
        public int Min {  get; set; }
        public int Max { get; set; }
        public int Sequence { get; set; }
        public int Index { get; set; }
        public string Status { get; set; }
        public List<OptionsAppDto> Options {  get; set; }
    }

    public class OptionsAppDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string ProductId { get; set; }
        public string Status { get; set; }
        public int Sequence { get; set; }
        public int Index { get; set; }
    }

    public class ContextModifiersDto
    {
        public string CatalogContext { get; set; }
        public string ItemContextId { get; set; }
    }

    public class customizationModifiersDto
    {
        public string Id { get; set; }
        public string CustomizationOptionId { get; set; }
        public string ParentCustomizationOptionId { get; set; }

        public string Status { get; set; }
    }
}
