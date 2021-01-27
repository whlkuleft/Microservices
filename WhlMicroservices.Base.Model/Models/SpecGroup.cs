using System;
using System.Collections.Generic;

namespace WhlMicroservices.Base.Model
{
	public partial class SpecGroup
	{
		public long Id { get; set; }
		public long Cid { get; set; }
		public string Name { get; set; }

		public List<SpecParam> Params = new List<SpecParam>();
	}
}
