using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateMerchantsCommand
    {
        public string Id { get; set; }
        public string UsersId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MainCuisine { get; set; }
        public string DeliveryPhone { get; set; }
    }
}
