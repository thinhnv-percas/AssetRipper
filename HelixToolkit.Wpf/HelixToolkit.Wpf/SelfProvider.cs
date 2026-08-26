using System;
using System.Windows.Markup;

namespace HelixToolkit.Wpf;

public abstract class SelfProvider : MarkupExtension
{
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}
}
