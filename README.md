# DataAnnotations-TagHelper-KnockoutJS
Custom Attributes with Tag Helper extension for .NET Core to write KnockoutJS data-bind attributes.

This is an update for previous project by @fabiosilvalima to work with the new Tag Helpers instead of Html Helpers

Full credit for he's custom attributes
https://github.com/fabiosilvalima/FSL.MvcDataAnnotationsHtmlHelpersKnockoutJS

## Tip
Inside DataBindTagHelper where you get your name for the property that's being passed there might be a problem if you are using a pattern for your backend. So just put a break point and check that 'For.Name' returns the same property name as the class with the annotation.
