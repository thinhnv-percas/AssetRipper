using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.AvalonEdit.Utils;

namespace ICSharpCode.AvalonEdit.Highlighting;

[Serializable]
public class HighlightingColor : ISerializable, IFreezable, ICloneable, IEquatable<HighlightingColor>
{
	internal static readonly HighlightingColor Empty = FreezableHelper.FreezeAndReturn(new HighlightingColor());

	private string name;

	private FontWeight? fontWeight;

	private FontStyle? fontStyle;

	private bool? underline;

	private HighlightingBrush foreground;

	private HighlightingBrush background;

	private bool frozen;

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			name = value;
		}
	}

	public FontWeight? FontWeight
	{
		get
		{
			return fontWeight;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			fontWeight = value;
		}
	}

	public FontStyle? FontStyle
	{
		get
		{
			return fontStyle;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			fontStyle = value;
		}
	}

	public bool? Underline
	{
		get
		{
			return underline;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			underline = value;
		}
	}

	public HighlightingBrush Foreground
	{
		get
		{
			return foreground;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			foreground = value;
		}
	}

	public HighlightingBrush Background
	{
		get
		{
			return background;
		}
		set
		{
			if (frozen)
			{
				throw new InvalidOperationException();
			}
			background = value;
		}
	}

	public bool IsFrozen => frozen;

	internal bool IsEmptyForMerge
	{
		get
		{
			if (!fontWeight.HasValue && !fontStyle.HasValue && !underline.HasValue && foreground == null)
			{
				return background == null;
			}
			return false;
		}
	}

	public HighlightingColor()
	{
	}

	protected HighlightingColor(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		Name = info.GetString("Name");
		if (info.GetBoolean("HasWeight"))
		{
			FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(info.GetInt32("Weight"));
		}
		if (info.GetBoolean("HasStyle"))
		{
			FontStyle = (FontStyle?)new FontStyleConverter().ConvertFromInvariantString(info.GetString("Style"));
		}
		if (info.GetBoolean("HasUnderline"))
		{
			Underline = info.GetBoolean("Underline");
		}
		Foreground = (HighlightingBrush)info.GetValue("Foreground", typeof(HighlightingBrush));
		Background = (HighlightingBrush)info.GetValue("Background", typeof(HighlightingBrush));
	}

	[SecurityCritical]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info == null)
		{
			throw new ArgumentNullException("info");
		}
		info.AddValue("Name", Name);
		info.AddValue("HasWeight", FontWeight.HasValue);
		if (FontWeight.HasValue)
		{
			info.AddValue("Weight", FontWeight.Value.ToOpenTypeWeight());
		}
		info.AddValue("HasStyle", FontStyle.HasValue);
		if (FontStyle.HasValue)
		{
			info.AddValue("Style", FontStyle.Value.ToString());
		}
		info.AddValue("HasUnderline", Underline.HasValue);
		if (Underline.HasValue)
		{
			info.AddValue("Underline", Underline.Value);
		}
		info.AddValue("Foreground", Foreground);
		info.AddValue("Background", Background);
	}

	public virtual string ToCss()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (Foreground != null)
		{
			Color? color = Foreground.GetColor(null);
			if (color.HasValue)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "color: #{0:x2}{1:x2}{2:x2}; ", new object[3]
				{
					color.Value.R,
					color.Value.G,
					color.Value.B
				});
			}
		}
		if (FontWeight.HasValue)
		{
			stringBuilder.Append("font-weight: ");
			stringBuilder.Append(FontWeight.Value.ToString().ToLowerInvariant());
			stringBuilder.Append("; ");
		}
		if (FontStyle.HasValue)
		{
			stringBuilder.Append("font-style: ");
			stringBuilder.Append(FontStyle.Value.ToString().ToLowerInvariant());
			stringBuilder.Append("; ");
		}
		if (Underline.HasValue)
		{
			stringBuilder.Append("text-decoration: ");
			stringBuilder.Append(Underline.Value ? "underline" : "none");
			stringBuilder.Append("; ");
		}
		return stringBuilder.ToString();
	}

	public override string ToString()
	{
		return "[" + GetType().Name + " " + (string.IsNullOrEmpty(Name) ? ToCss() : Name) + "]";
	}

	public virtual void Freeze()
	{
		frozen = true;
	}

	public virtual HighlightingColor Clone()
	{
		HighlightingColor highlightingColor = (HighlightingColor)MemberwiseClone();
		highlightingColor.frozen = false;
		return highlightingColor;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public sealed override bool Equals(object obj)
	{
		return Equals(obj as HighlightingColor);
	}

	public virtual bool Equals(HighlightingColor other)
	{
		if (other == null)
		{
			return false;
		}
		if (name == other.name)
		{
			FontWeight? fontWeight = this.fontWeight;
			FontWeight? fontWeight2 = other.fontWeight;
			if (fontWeight.HasValue == fontWeight2.HasValue && (!fontWeight.HasValue || fontWeight.GetValueOrDefault() == fontWeight2.GetValueOrDefault()) && fontStyle == other.fontStyle)
			{
				bool? flag = underline;
				bool? flag2 = other.underline;
				if (flag == true == (flag2 == true) && flag.HasValue == flag2.HasValue && object.Equals(foreground, other.foreground))
				{
					return object.Equals(background, other.background);
				}
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (name != null)
		{
			num += 1000000007 * name.GetHashCode();
		}
		num += 1000000009 * fontWeight.GetHashCode();
		num += 1000000021 * fontStyle.GetHashCode();
		if (foreground != null)
		{
			num += 1000000033 * foreground.GetHashCode();
		}
		if (background != null)
		{
			num += 1000000087 * background.GetHashCode();
		}
		return num;
	}

	public void MergeWith(HighlightingColor color)
	{
		FreezableHelper.ThrowIfFrozen(this);
		if (color.fontWeight.HasValue)
		{
			fontWeight = color.fontWeight;
		}
		if (color.fontStyle.HasValue)
		{
			fontStyle = color.fontStyle;
		}
		if (color.foreground != null)
		{
			foreground = color.foreground;
		}
		if (color.background != null)
		{
			background = color.background;
		}
		if (color.underline.HasValue)
		{
			underline = color.underline;
		}
	}
}
