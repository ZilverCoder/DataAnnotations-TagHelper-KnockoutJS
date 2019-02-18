namespace TagHelperFun.CustomAttributes
{
    public class CssClassTagAttribute : TagAttribute
    {
		public CssClassTagAttribute(string tagValue) : base("class", tagValue) {}
    }
}
