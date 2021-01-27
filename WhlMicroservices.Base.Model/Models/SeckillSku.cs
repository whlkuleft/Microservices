using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class SeckillSku
    {
        public long Id { get; set; }
        public long SkuId { get; set; }
        public string Title { get; set; }
        public long SeckillPrice { get; set; }
        public string Image { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Enable { get; set; }
    }
}
