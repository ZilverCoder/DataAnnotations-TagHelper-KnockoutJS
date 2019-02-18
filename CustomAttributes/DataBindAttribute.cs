using System;

namespace TagHelperFun.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class DataBindAttribute : TagAttribute
    {
        public DataBindAttribute(string tagValue) : base(tagValue) {}
        
        public override void InitData() => TagName = "data-bind";
    }
}
