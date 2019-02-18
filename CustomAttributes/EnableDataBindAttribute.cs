using System;

namespace TagHelperFun.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class EnableDataBindAttribute : ValueDataBindAttribute
    {
        public EnableDataBindAttribute(string value) : base("") => InitData(value);

		public EnableDataBindAttribute(bool value) : base("") => InitData(value.ToString().ToLower());

		private void InitData(string value)
		{
			_valueTagName = "enable";
			_value = value;
			TagValue = BuildValueTag();
		}
    }
}
