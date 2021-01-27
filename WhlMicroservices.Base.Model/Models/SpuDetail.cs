using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class SpuDetail
    {
        public long SpuId { get; set; }
        public string Description { get; set; }
        public string GenericSpec { get; set; }
        public string SpecialSpec { get; set; }
        public string PackingList { get; set; }
        public string AfterService { get; set; }
    }
}
