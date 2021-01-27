﻿using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class PayLog
    {
        public long OrderId { get; set; }
        public long? TotalFee { get; set; }
        public long? UserId { get; set; }
        public string TransactionId { get; set; }
        public bool? Status { get; set; }
        public bool? PayType { get; set; }
        public string BankType { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? PayTime { get; set; }
        public DateTime? ClosedTime { get; set; }
        public DateTime? RefundTime { get; set; }
    }
}
