using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class GetItemsByCategoryQuery
    {
        public string CategoryId { get; }
        public string OwnerId { get; }
        public GetItemsByCategoryQuery(string categoryId, string ownerId)
        {
            CategoryId = categoryId;
            OwnerId = ownerId;
        }
    }
}
