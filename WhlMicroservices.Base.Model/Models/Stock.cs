using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class Stock
    {
        public long SkuId { get; set; }
        public int? SeckillStock { get; set; }
        public int? SeckillTotal { get; set; }
        public int StockNum { get; set; }
    }
}
