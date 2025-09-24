using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.catalog
{
    public class GetCatalogApiDto
    {
        private string id;
        private string status;
        private List<string> context;
        public string groupId;

        public GetCatalogApiDto(string id, string status, List<string> context, string groupId)
        {
            this.id = id;
            this.status = status;
            this.context = context;
            this.groupId = groupId;
        }

        public string Id { get { return id; } }
        public string Status { get { return status; } }
        public List<string> Context { get { return context; } }
        public string GroupId { get { return groupId; } }
       
    }
}
