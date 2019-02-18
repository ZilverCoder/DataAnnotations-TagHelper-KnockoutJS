using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace TagHelperFun.CustomAttributes
{
	/// <summary>
	/// A simple Custom Attribute
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
	public class TagAttribute : Attribute
	{
		public TagAttribute(string tagName, string tagValue) : base()
		{
			TagName = tagName;
			TagValue = tagValue;
			InitData();
		}

		public TagAttribute(string tagValue) : base()
		{
			TagValue = tagValue;
			InitData();
		}

		public string TagName { get; set; }

		public string TagValue { get; set; }

		public virtual string OriginalValue => TagValue;

		public virtual string GetValue() => TagValue;

		public string GetTagName() => TagName;

		public virtual void InitData() {}
	}
}
