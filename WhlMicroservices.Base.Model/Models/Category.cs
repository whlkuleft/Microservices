using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
    public partial class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long ParentId { get; set; }
        public bool IsParent { get; set; }
        public int Sort { get; set; }
    }
}
