using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class OrderStatus
    {
        public long OrderId { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? PaymentTime { get; set; }
        public DateTime? ConsignTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public DateTime? CommentTime { get; set; }
    }
}
