using System;

namespace TagHelperFun.CustomAttributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NoDataValTagAttribute : TagAttribute
	{
		public NoDataValTagAttribute() : base("data-val", "false") { }
	}
}
