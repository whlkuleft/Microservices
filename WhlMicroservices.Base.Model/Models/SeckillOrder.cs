using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class SeckillOrder
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long OrderId { get; set; }
        public long SkuId { get; set; }
    }
}
