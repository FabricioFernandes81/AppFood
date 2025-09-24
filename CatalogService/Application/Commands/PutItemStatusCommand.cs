using Application.DTOS.items.postStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class PutItemStatusCommand
    {
        public string MerchantId { get; set; }

        public string Id { get; set; }
        public string Status { get; set; }

        public List<PutStatusByCatlogs> StatusByCatlogs { get; set; }

    }
}

