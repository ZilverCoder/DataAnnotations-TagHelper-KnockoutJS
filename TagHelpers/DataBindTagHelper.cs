using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Caterpillar.Web.Global.CustomAttributes;
using System.Reflection;
using System;

namespace TagHelperFun.Web.TagHelpers
{
	/// <summary>
	/// All the knockout data-bind options avaible
	/// </summary>
	public enum DataBindOptions
	{
		CssAttribute,
		DateAttribute,
		DoubleAttribute,
		EnableAttribute,
		MaskAttribute,
		NoDataAttribute,
		OptionsAttribute,
		ValueAttribute
	}

	[HtmlTargetElement("input", Attributes = "asp-for")]
	public class ValueDataBindTagHelper : TagHelper
	{
		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		public Dictionary<string, string> AllTheAttributeValues => new Dictionary<string, string>();

		public static readonly IReadOnlyDictionary<string, DataBindOptions> AllBindings = new Dictionary<string, DataBindOptions>
		{
			{nameof(CssClassTagAttribute), DataBindOptions.CssAttribute},
			{nameof(DateDataBindAttribute), DataBindOptions.DateAttribute},
			{nameof(DoubleDataBindAttribute), DataBindOptions.DoubleAttribute},
			{nameof(EnableDataBindAttribute), DataBindOptions.EnableAttribute},
			{nameof(MaskDataBindAttribute), DataBindOptions.MaskAttribute},
			{nameof(NoDataValTagAttribute), DataBindOptions.NoDataAttribute},
			{nameof(OptionsDataBindAttribute), DataBindOptions.OptionsAttribute},
			{nameof(ValueDataBindAttribute), DataBindOptions.ValueAttribute},
		};

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			base.Process(context, output);
			
			var valueFromAttribute = GetDataBindValue(For.Metadata.ContainerType.GetProperty(For.Name), AllBindings, AllTheAttributeValues);

			if (valueFromAttribute.Count > 0)
			{
				foreach (var x in valueFromAttribute)
				{
					if (context.AllAttributes[x.Key] == null)
					{
						output.Attributes.Add(x.Key, x.Value);
					}
				}
			}
		}

		private static Dictionary<string, string> GetDataBindValue(PropertyInfo propertyInfo, IReadOnlyDictionary<string, DataBindOptions> allBindings, Dictionary<string, string> allTheAttributeValues)
		{
			foreach (var x in propertyInfo.GetCustomAttributes())
			{
				allBindings.TryGetValue(x.GetType().Name, out var dataBindOption);
				var checkIsCustomAttribute = allBindings.TryGetValue(x.GetType().Name, out dataBindOption);
				if (checkIsCustomAttribute)
				{
					allTheAttributeValues.Add((x as TagAttribute).TagName, (x as TagAttribute).OriginalValue);
				}
			}
			return allTheAttributeValues;
		}
	}
}
