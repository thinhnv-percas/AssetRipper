using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class MagickScript
{
	private static readonly XmlReaderSettings _ReaderSettings = CreateXmlReaderSettings();

	private XmlDocument _script;

	public ScriptVariables Variables { get; private set; }

	public event EventHandler<ScriptReadEventArgs> Read;

	public event EventHandler<ScriptWriteEventArgs> Write;

	private static XmlReaderSettings CreateXmlReaderSettings()
	{
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
		{
			ValidationType = ValidationType.Schema,
			ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings,
			IgnoreComments = true,
			IgnoreWhitespace = true
		};
		using Stream input = TypeHelper.GetManifestResourceStream(typeof(MagickScript), "ImageMagick.Resources", "MagickScript.xsd");
		using XmlReader schemaDocument = XmlReader.Create(input);
		xmlReaderSettings.Schemas.Add(string.Empty, schemaDocument);
		return xmlReaderSettings;
	}

	private Collection<MagickGeometry> CreateMagickGeometryCollection(XmlElement element)
	{
		Collection<MagickGeometry> collection = new Collection<MagickGeometry>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			collection.Add(Variables.GetValue<MagickGeometry>(item, "value"));
		}
		return collection;
	}

	private static ColorProfile CreateColorProfile(XmlElement element)
	{
		if (element.GetAttribute("name") == "AdobeRGB1998")
		{
			return ColorProfile.AdobeRGB1998;
		}
		if (element.GetAttribute("name") == "AppleRGB")
		{
			return ColorProfile.AppleRGB;
		}
		if (element.GetAttribute("name") == "CoatedFOGRA39")
		{
			return ColorProfile.CoatedFOGRA39;
		}
		if (element.GetAttribute("name") == "ColorMatchRGB")
		{
			return ColorProfile.ColorMatchRGB;
		}
		if (element.GetAttribute("name") == "SRGB")
		{
			return ColorProfile.SRGB;
		}
		if (element.GetAttribute("name") == "USWebCoatedSWOP")
		{
			return ColorProfile.USWebCoatedSWOP;
		}
		throw new NotSupportedException(element.Name);
	}

	private IReadDefines CreateIReadDefines(XmlElement parent)
	{
		return CreateIDefines(parent) as IReadDefines;
	}

	private IDefines CreateIDefines(XmlElement parent)
	{
		if (parent == null)
		{
			return null;
		}
		XmlElement xmlElement = (XmlElement)parent.FirstChild;
		if (xmlElement == null)
		{
			return null;
		}
		switch (xmlElement.Name[0])
		{
		case 'b':
			return CreateBmpWriteDefines(xmlElement);
		case 'd':
			return CreateDdsWriteDefines(xmlElement);
		case 'j':
			switch (xmlElement.Name[2])
			{
			case '2':
				switch (xmlElement.Name[3])
				{
				case 'R':
					return CreateJp2ReadDefines(xmlElement);
				case 'W':
					return CreateJp2WriteDefines(xmlElement);
				}
				break;
			case 'e':
				switch (xmlElement.Name[4])
				{
				case 'R':
					return CreateJpegReadDefines(xmlElement);
				case 'W':
					return CreateJpegWriteDefines(xmlElement);
				}
				break;
			}
			break;
		case 'p':
			switch (xmlElement.Name[1])
			{
			case 'd':
				return CreatePdfReadDefines(xmlElement);
			case 'n':
				return CreatePngReadDefines(xmlElement);
			case 's':
				switch (xmlElement.Name[3])
				{
				case 'R':
					return CreatePsdReadDefines(xmlElement);
				case 'W':
					return CreatePsdWriteDefines(xmlElement);
				}
				break;
			}
			break;
		case 't':
			switch (xmlElement.Name[4])
			{
			case 'R':
				return CreateTiffReadDefines(xmlElement);
			case 'W':
				return CreateTiffWriteDefines(xmlElement);
			}
			break;
		}
		throw new NotSupportedException(xmlElement.Name);
	}

	private IDefines CreateBmpWriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new BmpWriteDefines
		{
			Subtype = Variables.GetValue<BmpSubtype?>(element, "subtype")
		};
	}

	private IDefines CreateDdsWriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new DdsWriteDefines
		{
			ClusterFit = Variables.GetValue<bool?>(element, "clusterFit"),
			Compression = Variables.GetValue<DdsCompression?>(element, "compression"),
			FastMipmaps = Variables.GetValue<bool?>(element, "fastMipmaps"),
			Mipmaps = Variables.GetValue<int?>(element, "mipmaps"),
			MipmapsFromCollection = Variables.GetValue<bool?>(element, "mipmapsFromCollection"),
			WeightByAlpha = Variables.GetValue<bool?>(element, "weightByAlpha")
		};
	}

	private IDefines CreateJp2ReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new Jp2ReadDefines
		{
			QualityLayers = Variables.GetValue<int?>(element, "qualityLayers"),
			ReduceFactor = Variables.GetValue<int?>(element, "reduceFactor")
		};
	}

	private IDefines CreateJp2WriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new Jp2WriteDefines
		{
			NumberResolutions = Variables.GetValue<int?>(element, "numberResolutions"),
			ProgressionOrder = Variables.GetValue<Jp2ProgressionOrder?>(element, "progressionOrder"),
			Quality = Variables.GetSingleArray(element["quality"]),
			Rate = Variables.GetSingleArray(element["rate"])
		};
	}

	private IDefines CreateJpegReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new JpegReadDefines
		{
			BlockSmoothing = Variables.GetValue<bool?>(element, "blockSmoothing"),
			Colors = Variables.GetValue<int?>(element, "colors"),
			DctMethod = Variables.GetValue<DctMethod?>(element, "dctMethod"),
			FancyUpsampling = Variables.GetValue<bool?>(element, "fancyUpsampling"),
			Size = Variables.GetValue<MagickGeometry>(element, "size"),
			SkipProfiles = Variables.GetValue<ProfileTypes?>(element, "skipProfiles")
		};
	}

	private IDefines CreateJpegWriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new JpegWriteDefines
		{
			DctMethod = Variables.GetValue<DctMethod?>(element, "dctMethod"),
			Extent = Variables.GetValue<int?>(element, "extent"),
			OptimizeCoding = Variables.GetValue<bool?>(element, "optimizeCoding"),
			Quality = Variables.GetValue<MagickGeometry>(element, "quality"),
			QuantizationTables = Variables.GetValue<string>(element, "quantizationTables"),
			SamplingFactors = CreateMagickGeometryCollection(element)
		};
	}

	private IDefines CreatePdfReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new PdfReadDefines
		{
			FitPage = Variables.GetValue<MagickGeometry>(element, "fitPage"),
			UseCropBox = Variables.GetValue<bool?>(element, "useCropBox"),
			UseTrimBox = Variables.GetValue<bool?>(element, "useTrimBox")
		};
	}

	private IDefines CreatePngReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new PngReadDefines
		{
			PreserveiCCP = Variables.GetValue<bool>(element, "preserveiCCP"),
			SkipProfiles = Variables.GetValue<ProfileTypes?>(element, "skipProfiles"),
			SwapBytes = Variables.GetValue<bool>(element, "swapBytes")
		};
	}

	private IDefines CreatePsdReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new PsdReadDefines
		{
			AlphaUnblend = Variables.GetValue<bool?>(element, "alphaUnblend")
		};
	}

	private IDefines CreatePsdWriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new PsdWriteDefines
		{
			AdditionalInfo = Variables.GetValue<PsdAdditionalInfo>(element, "additionalInfo")
		};
	}

	private IDefines CreateTiffReadDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new TiffReadDefines
		{
			IgnoreExifPoperties = Variables.GetValue<bool?>(element, "ignoreExifPoperties"),
			IgnoreTags = Variables.GetStringArray(element["ignoreTags"])
		};
	}

	private IDefines CreateTiffWriteDefines(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new TiffWriteDefines
		{
			Alpha = Variables.GetValue<TiffAlpha?>(element, "alpha"),
			Endian = Variables.GetValue<Endian?>(element, "endian"),
			FillOrder = Variables.GetValue<Endian?>(element, "fillOrder"),
			RowsPerStrip = Variables.GetValue<int?>(element, "rowsPerStrip"),
			TileGeometry = Variables.GetValue<MagickGeometry>(element, "tileGeometry")
		};
	}

	private void ExecuteIDrawable(XmlElement element, Collection<IDrawable> drawables)
	{
		switch (element.Name[0])
		{
		case 'a':
			switch (element.Name[1])
			{
			case 'f':
				ExecuteDrawableAffine(element, drawables);
				return;
			case 'l':
				ExecuteDrawableAlpha(element, drawables);
				return;
			case 'r':
				ExecuteDrawableArc(element, drawables);
				return;
			}
			break;
		case 'b':
			switch (element.Name[1])
			{
			case 'e':
				ExecuteDrawableBezier(element, drawables);
				return;
			case 'o':
				ExecuteDrawableBorderColor(element, drawables);
				return;
			}
			break;
		case 'c':
			switch (element.Name[1])
			{
			case 'i':
				ExecuteDrawableCircle(element, drawables);
				return;
			case 'l':
				switch (element.Name[4])
				{
				case 'P':
					ExecuteDrawableClipPath(element, drawables);
					return;
				case 'R':
					ExecuteDrawableClipRule(element, drawables);
					return;
				case 'U':
					ExecuteDrawableClipUnits(element, drawables);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'l':
					ExecuteDrawableColor(element, drawables);
					return;
				case 'm':
					ExecuteDrawableComposite(element, drawables);
					return;
				}
				break;
			}
			break;
		case 'd':
			ExecuteDrawableDensity(element, drawables);
			return;
		case 'e':
			ExecuteDrawableEllipse(element, drawables);
			return;
		case 'f':
			switch (element.Name[1])
			{
			case 'i':
				switch (element.Name[4])
				{
				case 'C':
					ExecuteDrawableFillColor(element, drawables);
					return;
				case 'O':
					ExecuteDrawableFillOpacity(element, drawables);
					return;
				case 'P':
					ExecuteDrawableFillPatternUrl(element, drawables);
					return;
				case 'R':
					ExecuteDrawableFillRule(element, drawables);
					return;
				}
				break;
			case 'o':
				if (element.Name.Length == 4)
				{
					ExecuteDrawableFont(element, drawables);
					return;
				}
				if (element.Name.Length == 13)
				{
					ExecuteDrawableFontPointSize(element, drawables);
					return;
				}
				break;
			}
			break;
		case 'g':
			ExecuteDrawableGravity(element, drawables);
			return;
		case 'l':
			ExecuteDrawableLine(element, drawables);
			return;
		case 'p':
			switch (element.Name[1])
			{
			case 'a':
				ExecuteDrawablePath(element, drawables);
				return;
			case 'o':
				switch (element.Name[2])
				{
				case 'i':
					ExecuteDrawablePoint(element, drawables);
					return;
				case 'l':
					switch (element.Name[4])
					{
					case 'g':
						ExecuteDrawablePolygon(element, drawables);
						return;
					case 'l':
						ExecuteDrawablePolyline(element, drawables);
						return;
					}
					break;
				}
				break;
			case 'u':
				switch (element.Name[4])
				{
				case 'C':
					ExecuteDrawablePushClipPath(element, drawables);
					return;
				case 'P':
					ExecuteDrawablePushPattern(element, drawables);
					return;
				}
				break;
			}
			break;
		case 'r':
			switch (element.Name[1])
			{
			case 'e':
				ExecuteDrawableRectangle(element, drawables);
				return;
			case 'o':
				switch (element.Name[2])
				{
				case 't':
					ExecuteDrawableRotation(element, drawables);
					return;
				case 'u':
					ExecuteDrawableRoundRectangle(element, drawables);
					return;
				}
				break;
			}
			break;
		case 's':
			switch (element.Name[1])
			{
			case 'c':
				ExecuteDrawableScaling(element, drawables);
				return;
			case 'k':
				switch (element.Name[4])
				{
				case 'X':
					ExecuteDrawableSkewX(element, drawables);
					return;
				case 'Y':
					ExecuteDrawableSkewY(element, drawables);
					return;
				}
				break;
			case 't':
				switch (element.Name[6])
				{
				case 'A':
					ExecuteDrawableStrokeAntialias(element, drawables);
					return;
				case 'C':
					ExecuteDrawableStrokeColor(element, drawables);
					return;
				case 'D':
					switch (element.Name[10])
					{
					case 'A':
						ExecuteDrawableStrokeDashArray(element, drawables);
						return;
					case 'O':
						ExecuteDrawableStrokeDashOffset(element, drawables);
						return;
					}
					break;
				case 'L':
					switch (element.Name[10])
					{
					case 'C':
						ExecuteDrawableStrokeLineCap(element, drawables);
						return;
					case 'J':
						ExecuteDrawableStrokeLineJoin(element, drawables);
						return;
					}
					break;
				case 'M':
					ExecuteDrawableStrokeMiterLimit(element, drawables);
					return;
				case 'O':
					ExecuteDrawableStrokeOpacity(element, drawables);
					return;
				case 'P':
					ExecuteDrawableStrokePatternUrl(element, drawables);
					return;
				case 'W':
					ExecuteDrawableStrokeWidth(element, drawables);
					return;
				}
				break;
			}
			break;
		case 't':
			switch (element.Name[1])
			{
			case 'e':
				if (element.Name.Length == 4)
				{
					ExecuteDrawableText(element, drawables);
					return;
				}
				switch (element.Name[4])
				{
				case 'A':
					switch (element.Name[5])
					{
					case 'l':
						ExecuteDrawableTextAlignment(element, drawables);
						return;
					case 'n':
						ExecuteDrawableTextAntialias(element, drawables);
						return;
					}
					break;
				case 'D':
					switch (element.Name[5])
					{
					case 'e':
						ExecuteDrawableTextDecoration(element, drawables);
						return;
					case 'i':
						ExecuteDrawableTextDirection(element, drawables);
						return;
					}
					break;
				case 'E':
					ExecuteDrawableTextEncoding(element, drawables);
					return;
				case 'I':
					switch (element.Name[9])
					{
					case 'l':
						ExecuteDrawableTextInterlineSpacing(element, drawables);
						return;
					case 'w':
						ExecuteDrawableTextInterwordSpacing(element, drawables);
						return;
					}
					break;
				case 'K':
					ExecuteDrawableTextKerning(element, drawables);
					return;
				case 'U':
					ExecuteDrawableTextUnderColor(element, drawables);
					return;
				}
				break;
			case 'r':
				ExecuteDrawableTranslation(element, drawables);
				return;
			}
			break;
		case 'v':
			ExecuteDrawableViewbox(element, drawables);
			return;
		}
		throw new NotSupportedException(element.Name);
	}

	private void ExecuteDrawableAffine(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "scaleX");
		double value2 = Variables.GetValue<double>(element, "scaleY");
		double value3 = Variables.GetValue<double>(element, "shearX");
		double value4 = Variables.GetValue<double>(element, "shearY");
		double value5 = Variables.GetValue<double>(element, "translateX");
		double value6 = Variables.GetValue<double>(element, "translateY");
		drawables.Add(new DrawableAffine(value, value2, value3, value4, value5, value6));
	}

	private void ExecuteDrawableAlpha(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		PaintMethod value3 = Variables.GetValue<PaintMethod>(element, "paintMethod");
		drawables.Add(new DrawableAlpha(value, value2, value3));
	}

	private void ExecuteDrawableArc(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "startX");
		double value2 = Variables.GetValue<double>(element, "startY");
		double value3 = Variables.GetValue<double>(element, "endX");
		double value4 = Variables.GetValue<double>(element, "endY");
		double value5 = Variables.GetValue<double>(element, "startDegrees");
		double value6 = Variables.GetValue<double>(element, "endDegrees");
		drawables.Add(new DrawableArc(value, value2, value3, value4, value5, value6));
	}

	private void ExecuteDrawableBezier(XmlElement element, Collection<IDrawable> drawables)
	{
		IEnumerable<PointD> coordinates = CreatePointDs(element);
		drawables.Add(new DrawableBezier(coordinates));
	}

	private void ExecuteDrawableBorderColor(XmlElement element, Collection<IDrawable> drawables)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		drawables.Add(new DrawableBorderColor(value));
	}

	private void ExecuteDrawableCircle(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "originX");
		double value2 = Variables.GetValue<double>(element, "originY");
		double value3 = Variables.GetValue<double>(element, "perimeterX");
		double value4 = Variables.GetValue<double>(element, "perimeterY");
		drawables.Add(new DrawableCircle(value, value2, value3, value4));
	}

	private void ExecuteDrawableClipPath(XmlElement element, Collection<IDrawable> drawables)
	{
		string value = Variables.GetValue<string>(element, "clipPath");
		drawables.Add(new DrawableClipPath(value));
	}

	private void ExecuteDrawableClipRule(XmlElement element, Collection<IDrawable> drawables)
	{
		FillRule value = Variables.GetValue<FillRule>(element, "fillRule");
		drawables.Add(new DrawableClipRule(value));
	}

	private void ExecuteDrawableClipUnits(XmlElement element, Collection<IDrawable> drawables)
	{
		ClipPathUnit value = Variables.GetValue<ClipPathUnit>(element, "units");
		drawables.Add(new DrawableClipUnits(value));
	}

	private void ExecuteDrawableColor(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		PaintMethod value3 = Variables.GetValue<PaintMethod>(element, "paintMethod");
		drawables.Add(new DrawableColor(value, value2, value3));
	}

	private void ExecuteDrawableComposite(XmlElement element, Collection<IDrawable> drawables)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "compose")
			{
				hashtable["compose"] = Variables.GetValue<CompositeOperator>(attribute);
			}
			else if (attribute.Name == "offset")
			{
				hashtable["offset"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "offset", "compose", "image"))
		{
			drawables.Add(new DrawableComposite((MagickGeometry)hashtable["offset"], (CompositeOperator)hashtable["compose"], (IMagickImage)hashtable["image"]));
			return;
		}
		if (OnlyContains(hashtable, "offset", "image"))
		{
			drawables.Add(new DrawableComposite((MagickGeometry)hashtable["offset"], (IMagickImage)hashtable["image"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "compose", "image"))
		{
			drawables.Add(new DrawableComposite((double)hashtable["x"], (double)hashtable["y"], (CompositeOperator)hashtable["compose"], (IMagickImage)hashtable["image"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "image"))
		{
			drawables.Add(new DrawableComposite((double)hashtable["x"], (double)hashtable["y"], (IMagickImage)hashtable["image"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'composite', allowed combinations are: [offset, compose, image] [offset, image] [x, y, compose, image] [x, y, image]");
	}

	private void ExecuteDrawableDensity(XmlElement element, Collection<IDrawable> drawables)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "density")
			{
				hashtable["density"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "pointDensity")
			{
				hashtable["pointDensity"] = Variables.GetValue<PointD>(attribute);
			}
		}
		if (OnlyContains(hashtable, "density"))
		{
			drawables.Add(new DrawableDensity((double)hashtable["density"]));
			return;
		}
		if (OnlyContains(hashtable, "pointDensity"))
		{
			drawables.Add(new DrawableDensity((PointD)hashtable["pointDensity"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'density', allowed combinations are: [density] [pointDensity]");
	}

	private void ExecuteDrawableEllipse(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "originX");
		double value2 = Variables.GetValue<double>(element, "originY");
		double value3 = Variables.GetValue<double>(element, "radiusX");
		double value4 = Variables.GetValue<double>(element, "radiusY");
		double value5 = Variables.GetValue<double>(element, "startDegrees");
		double value6 = Variables.GetValue<double>(element, "endDegrees");
		drawables.Add(new DrawableEllipse(value, value2, value3, value4, value5, value6));
	}

	private void ExecuteDrawableFillColor(XmlElement element, Collection<IDrawable> drawables)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		drawables.Add(new DrawableFillColor(value));
	}

	private void ExecuteDrawableFillOpacity(XmlElement element, Collection<IDrawable> drawables)
	{
		Percentage value = Variables.GetValue<Percentage>(element, "opacity");
		drawables.Add(new DrawableFillOpacity(value));
	}

	private void ExecuteDrawableFillPatternUrl(XmlElement element, Collection<IDrawable> drawables)
	{
		string value = Variables.GetValue<string>(element, "url");
		drawables.Add(new DrawableFillPatternUrl(value));
	}

	private void ExecuteDrawableFillRule(XmlElement element, Collection<IDrawable> drawables)
	{
		FillRule value = Variables.GetValue<FillRule>(element, "fillRule");
		drawables.Add(new DrawableFillRule(value));
	}

	private void ExecuteDrawableFont(XmlElement element, Collection<IDrawable> drawables)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "family")
			{
				hashtable["family"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "stretch")
			{
				hashtable["stretch"] = Variables.GetValue<FontStretch>(attribute);
			}
			else if (attribute.Name == "style")
			{
				hashtable["style"] = Variables.GetValue<FontStyleType>(attribute);
			}
			else if (attribute.Name == "weight")
			{
				hashtable["weight"] = Variables.GetValue<FontWeight>(attribute);
			}
		}
		if (OnlyContains(hashtable, "family"))
		{
			drawables.Add(new DrawableFont((string)hashtable["family"]));
			return;
		}
		if (OnlyContains(hashtable, "family", "style", "weight", "stretch"))
		{
			drawables.Add(new DrawableFont((string)hashtable["family"], (FontStyleType)hashtable["style"], (FontWeight)hashtable["weight"], (FontStretch)hashtable["stretch"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'font', allowed combinations are: [family] [family, style, weight, stretch]");
	}

	private void ExecuteDrawableFontPointSize(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "pointSize");
		drawables.Add(new DrawableFontPointSize(value));
	}

	private void ExecuteDrawableGravity(XmlElement element, Collection<IDrawable> drawables)
	{
		Gravity value = Variables.GetValue<Gravity>(element, "gravity");
		drawables.Add(new DrawableGravity(value));
	}

	private void ExecuteDrawableLine(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "startX");
		double value2 = Variables.GetValue<double>(element, "startY");
		double value3 = Variables.GetValue<double>(element, "endX");
		double value4 = Variables.GetValue<double>(element, "endY");
		drawables.Add(new DrawableLine(value, value2, value3, value4));
	}

	private void ExecuteDrawablePath(XmlElement element, Collection<IDrawable> drawables)
	{
		IEnumerable<IPath> paths = CreatePaths(element);
		drawables.Add(new DrawablePath(paths));
	}

	private void ExecuteDrawablePoint(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		drawables.Add(new DrawablePoint(value, value2));
	}

	private void ExecuteDrawablePolygon(XmlElement element, Collection<IDrawable> drawables)
	{
		IEnumerable<PointD> coordinates = CreatePointDs(element);
		drawables.Add(new DrawablePolygon(coordinates));
	}

	private void ExecuteDrawablePolyline(XmlElement element, Collection<IDrawable> drawables)
	{
		IEnumerable<PointD> coordinates = CreatePointDs(element);
		drawables.Add(new DrawablePolyline(coordinates));
	}

	private void ExecuteDrawablePushClipPath(XmlElement element, Collection<IDrawable> drawables)
	{
		string value = Variables.GetValue<string>(element, "clipPath");
		drawables.Add(new DrawablePushClipPath(value));
	}

	private void ExecuteDrawablePushPattern(XmlElement element, Collection<IDrawable> drawables)
	{
		string value = Variables.GetValue<string>(element, "id");
		double value2 = Variables.GetValue<double>(element, "x");
		double value3 = Variables.GetValue<double>(element, "y");
		double value4 = Variables.GetValue<double>(element, "width");
		double value5 = Variables.GetValue<double>(element, "height");
		drawables.Add(new DrawablePushPattern(value, value2, value3, value4, value5));
	}

	private void ExecuteDrawableRectangle(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "upperLeftX");
		double value2 = Variables.GetValue<double>(element, "upperLeftY");
		double value3 = Variables.GetValue<double>(element, "lowerRightX");
		double value4 = Variables.GetValue<double>(element, "lowerRightY");
		drawables.Add(new DrawableRectangle(value, value2, value3, value4));
	}

	private void ExecuteDrawableRotation(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "angle");
		drawables.Add(new DrawableRotation(value));
	}

	private void ExecuteDrawableRoundRectangle(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "upperLeftX");
		double value2 = Variables.GetValue<double>(element, "upperLeftY");
		double value3 = Variables.GetValue<double>(element, "lowerRightX");
		double value4 = Variables.GetValue<double>(element, "lowerRightY");
		double value5 = Variables.GetValue<double>(element, "cornerWidth");
		double value6 = Variables.GetValue<double>(element, "cornerHeight");
		drawables.Add(new DrawableRoundRectangle(value, value2, value3, value4, value5, value6));
	}

	private void ExecuteDrawableScaling(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		drawables.Add(new DrawableScaling(value, value2));
	}

	private void ExecuteDrawableSkewX(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "angle");
		drawables.Add(new DrawableSkewX(value));
	}

	private void ExecuteDrawableSkewY(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "angle");
		drawables.Add(new DrawableSkewY(value));
	}

	private void ExecuteDrawableStrokeAntialias(XmlElement element, Collection<IDrawable> drawables)
	{
		bool value = Variables.GetValue<bool>(element, "isEnabled");
		drawables.Add(new DrawableStrokeAntialias(value));
	}

	private void ExecuteDrawableStrokeColor(XmlElement element, Collection<IDrawable> drawables)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		drawables.Add(new DrawableStrokeColor(value));
	}

	private void ExecuteDrawableStrokeDashArray(XmlElement element, Collection<IDrawable> drawables)
	{
		double[] doubleArray = Variables.GetDoubleArray(element["dash"]);
		drawables.Add(new DrawableStrokeDashArray(doubleArray));
	}

	private void ExecuteDrawableStrokeDashOffset(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "offset");
		drawables.Add(new DrawableStrokeDashOffset(value));
	}

	private void ExecuteDrawableStrokeLineCap(XmlElement element, Collection<IDrawable> drawables)
	{
		LineCap value = Variables.GetValue<LineCap>(element, "lineCap");
		drawables.Add(new DrawableStrokeLineCap(value));
	}

	private void ExecuteDrawableStrokeLineJoin(XmlElement element, Collection<IDrawable> drawables)
	{
		LineJoin value = Variables.GetValue<LineJoin>(element, "lineJoin");
		drawables.Add(new DrawableStrokeLineJoin(value));
	}

	private void ExecuteDrawableStrokeMiterLimit(XmlElement element, Collection<IDrawable> drawables)
	{
		int value = Variables.GetValue<int>(element, "miterlimit");
		drawables.Add(new DrawableStrokeMiterLimit(value));
	}

	private void ExecuteDrawableStrokeOpacity(XmlElement element, Collection<IDrawable> drawables)
	{
		Percentage value = Variables.GetValue<Percentage>(element, "opacity");
		drawables.Add(new DrawableStrokeOpacity(value));
	}

	private void ExecuteDrawableStrokePatternUrl(XmlElement element, Collection<IDrawable> drawables)
	{
		string value = Variables.GetValue<string>(element, "url");
		drawables.Add(new DrawableStrokePatternUrl(value));
	}

	private void ExecuteDrawableStrokeWidth(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "width");
		drawables.Add(new DrawableStrokeWidth(value));
	}

	private void ExecuteDrawableText(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		string value3 = Variables.GetValue<string>(element, "value");
		drawables.Add(new DrawableText(value, value2, value3));
	}

	private void ExecuteDrawableTextAlignment(XmlElement element, Collection<IDrawable> drawables)
	{
		TextAlignment value = Variables.GetValue<TextAlignment>(element, "alignment");
		drawables.Add(new DrawableTextAlignment(value));
	}

	private void ExecuteDrawableTextAntialias(XmlElement element, Collection<IDrawable> drawables)
	{
		bool value = Variables.GetValue<bool>(element, "isEnabled");
		drawables.Add(new DrawableTextAntialias(value));
	}

	private void ExecuteDrawableTextDecoration(XmlElement element, Collection<IDrawable> drawables)
	{
		TextDecoration value = Variables.GetValue<TextDecoration>(element, "decoration");
		drawables.Add(new DrawableTextDecoration(value));
	}

	private void ExecuteDrawableTextDirection(XmlElement element, Collection<IDrawable> drawables)
	{
		TextDirection value = Variables.GetValue<TextDirection>(element, "direction");
		drawables.Add(new DrawableTextDirection(value));
	}

	private void ExecuteDrawableTextEncoding(XmlElement element, Collection<IDrawable> drawables)
	{
		Encoding value = Variables.GetValue<Encoding>(element, "encoding");
		drawables.Add(new DrawableTextEncoding(value));
	}

	private void ExecuteDrawableTextInterlineSpacing(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "spacing");
		drawables.Add(new DrawableTextInterlineSpacing(value));
	}

	private void ExecuteDrawableTextInterwordSpacing(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "spacing");
		drawables.Add(new DrawableTextInterwordSpacing(value));
	}

	private void ExecuteDrawableTextKerning(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "kerning");
		drawables.Add(new DrawableTextKerning(value));
	}

	private void ExecuteDrawableTextUnderColor(XmlElement element, Collection<IDrawable> drawables)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		drawables.Add(new DrawableTextUnderColor(value));
	}

	private void ExecuteDrawableTranslation(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		drawables.Add(new DrawableTranslation(value, value2));
	}

	private void ExecuteDrawableViewbox(XmlElement element, Collection<IDrawable> drawables)
	{
		double value = Variables.GetValue<double>(element, "upperLeftX");
		double value2 = Variables.GetValue<double>(element, "upperLeftY");
		double value3 = Variables.GetValue<double>(element, "lowerRightX");
		double value4 = Variables.GetValue<double>(element, "lowerRightY");
		drawables.Add(new DrawableViewbox(value, value2, value3, value4));
	}

	private ImageProfile CreateImageProfile(XmlElement element)
	{
		string value = Variables.GetValue<string>(element, "name");
		string value2 = Variables.GetValue<string>(element, "fileName");
		return new ImageProfile(value, value2);
	}

	private void ExecuteIPath(XmlElement element, Collection<IPath> paths)
	{
		switch (element.Name[0])
		{
		case 'a':
			switch (element.Name[3])
			{
			case 'A':
				ExecutePathArcAbs(element, paths);
				return;
			case 'R':
				ExecutePathArcRel(element, paths);
				return;
			}
			break;
		case 'c':
			switch (element.Name[7])
			{
			case 'A':
				ExecutePathCurveToAbs(element, paths);
				return;
			case 'R':
				ExecutePathCurveToRel(element, paths);
				return;
			}
			break;
		case 'l':
			switch (element.Name[6])
			{
			case 'A':
				ExecutePathLineToAbs(element, paths);
				return;
			case 'H':
				switch (element.Name[16])
				{
				case 'A':
					ExecutePathLineToHorizontalAbs(element, paths);
					return;
				case 'R':
					ExecutePathLineToHorizontalRel(element, paths);
					return;
				}
				break;
			case 'R':
				ExecutePathLineToRel(element, paths);
				return;
			case 'V':
				switch (element.Name[14])
				{
				case 'A':
					ExecutePathLineToVerticalAbs(element, paths);
					return;
				case 'R':
					ExecutePathLineToVerticalRel(element, paths);
					return;
				}
				break;
			}
			break;
		case 'm':
			switch (element.Name[6])
			{
			case 'A':
				ExecutePathMoveToAbs(element, paths);
				return;
			case 'R':
				ExecutePathMoveToRel(element, paths);
				return;
			}
			break;
		case 'q':
			switch (element.Name[16])
			{
			case 'A':
				ExecutePathQuadraticCurveToAbs(element, paths);
				return;
			case 'R':
				ExecutePathQuadraticCurveToRel(element, paths);
				return;
			}
			break;
		case 's':
			switch (element.Name[6])
			{
			case 'C':
				switch (element.Name[13])
				{
				case 'A':
					ExecutePathSmoothCurveToAbs(element, paths);
					return;
				case 'R':
					ExecutePathSmoothCurveToRel(element, paths);
					return;
				}
				break;
			case 'Q':
				switch (element.Name[22])
				{
				case 'A':
					ExecutePathSmoothQuadraticCurveToAbs(element, paths);
					return;
				case 'R':
					ExecutePathSmoothQuadraticCurveToRel(element, paths);
					return;
				}
				break;
			}
			break;
		}
		throw new NotSupportedException(element.Name);
	}

	private void ExecutePathArcAbs(XmlElement element, Collection<IPath> paths)
	{
		IEnumerable<PathArc> pathArcs = CreatePathArcs(element);
		paths.Add(new PathArcAbs(pathArcs));
	}

	private void ExecutePathArcRel(XmlElement element, Collection<IPath> paths)
	{
		IEnumerable<PathArc> pathArcs = CreatePathArcs(element);
		paths.Add(new PathArcRel(pathArcs));
	}

	private void ExecutePathCurveToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPointEnd")
			{
				hashtable["controlPointEnd"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "controlPointStart")
			{
				hashtable["controlPointStart"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x1")
			{
				hashtable["x1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x2")
			{
				hashtable["x2"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y1")
			{
				hashtable["y1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y2")
			{
				hashtable["y2"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPointStart", "controlPointEnd", "end"))
		{
			paths.Add(new PathCurveToAbs((PointD)hashtable["controlPointStart"], (PointD)hashtable["controlPointEnd"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x1", "y1", "x2", "y2", "x", "y"))
		{
			paths.Add(new PathCurveToAbs((double)hashtable["x1"], (double)hashtable["y1"], (double)hashtable["x2"], (double)hashtable["y2"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'curveToAbs', allowed combinations are: [controlPointStart, controlPointEnd, end] [x1, y1, x2, y2, x, y]");
	}

	private void ExecutePathCurveToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPointEnd")
			{
				hashtable["controlPointEnd"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "controlPointStart")
			{
				hashtable["controlPointStart"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x1")
			{
				hashtable["x1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x2")
			{
				hashtable["x2"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y1")
			{
				hashtable["y1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y2")
			{
				hashtable["y2"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPointStart", "controlPointEnd", "end"))
		{
			paths.Add(new PathCurveToRel((PointD)hashtable["controlPointStart"], (PointD)hashtable["controlPointEnd"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x1", "y1", "x2", "y2", "x", "y"))
		{
			paths.Add(new PathCurveToRel((double)hashtable["x1"], (double)hashtable["y1"], (double)hashtable["x2"], (double)hashtable["y2"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'curveToRel', allowed combinations are: [controlPointStart, controlPointEnd, end] [x1, y1, x2, y2, x, y]");
	}

	private void ExecutePathLineToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreatePointDs(item);
		}
		if (OnlyContains(hashtable, "coordinates"))
		{
			paths.Add(new PathLineToAbs((IEnumerable<PointD>)hashtable["coordinates"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathLineToAbs((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'lineToAbs', allowed combinations are: [coordinates] [x, y]");
	}

	private void ExecutePathLineToHorizontalAbs(XmlElement element, Collection<IPath> paths)
	{
		double value = Variables.GetValue<double>(element, "x");
		paths.Add(new PathLineToHorizontalAbs(value));
	}

	private void ExecutePathLineToHorizontalRel(XmlElement element, Collection<IPath> paths)
	{
		double value = Variables.GetValue<double>(element, "x");
		paths.Add(new PathLineToHorizontalRel(value));
	}

	private void ExecutePathLineToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreatePointDs(item);
		}
		if (OnlyContains(hashtable, "coordinates"))
		{
			paths.Add(new PathLineToRel((IEnumerable<PointD>)hashtable["coordinates"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathLineToRel((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'lineToRel', allowed combinations are: [coordinates] [x, y]");
	}

	private void ExecutePathLineToVerticalAbs(XmlElement element, Collection<IPath> paths)
	{
		double value = Variables.GetValue<double>(element, "y");
		paths.Add(new PathLineToVerticalAbs(value));
	}

	private void ExecutePathLineToVerticalRel(XmlElement element, Collection<IPath> paths)
	{
		double value = Variables.GetValue<double>(element, "y");
		paths.Add(new PathLineToVerticalRel(value));
	}

	private void ExecutePathMoveToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "coordinate")
			{
				hashtable["coordinate"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "coordinate"))
		{
			paths.Add(new PathMoveToAbs((PointD)hashtable["coordinate"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathMoveToAbs((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'moveToAbs', allowed combinations are: [coordinate] [x, y]");
	}

	private void ExecutePathMoveToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "coordinate")
			{
				hashtable["coordinate"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "coordinate"))
		{
			paths.Add(new PathMoveToRel((PointD)hashtable["coordinate"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathMoveToRel((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'moveToRel', allowed combinations are: [coordinate] [x, y]");
	}

	private void ExecutePathQuadraticCurveToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPoint")
			{
				hashtable["controlPoint"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x1")
			{
				hashtable["x1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y1")
			{
				hashtable["y1"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPoint", "end"))
		{
			paths.Add(new PathQuadraticCurveToAbs((PointD)hashtable["controlPoint"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x1", "y1", "x", "y"))
		{
			paths.Add(new PathQuadraticCurveToAbs((double)hashtable["x1"], (double)hashtable["y1"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'quadraticCurveToAbs', allowed combinations are: [controlPoint, end] [x1, y1, x, y]");
	}

	private void ExecutePathQuadraticCurveToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPoint")
			{
				hashtable["controlPoint"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x1")
			{
				hashtable["x1"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y1")
			{
				hashtable["y1"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPoint", "end"))
		{
			paths.Add(new PathQuadraticCurveToRel((PointD)hashtable["controlPoint"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x1", "y1", "x", "y"))
		{
			paths.Add(new PathQuadraticCurveToRel((double)hashtable["x1"], (double)hashtable["y1"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'quadraticCurveToRel', allowed combinations are: [controlPoint, end] [x1, y1, x, y]");
	}

	private void ExecutePathSmoothCurveToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPoint")
			{
				hashtable["controlPoint"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x2")
			{
				hashtable["x2"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y2")
			{
				hashtable["y2"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPoint", "end"))
		{
			paths.Add(new PathSmoothCurveToAbs((PointD)hashtable["controlPoint"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x2", "y2", "x", "y"))
		{
			paths.Add(new PathSmoothCurveToAbs((double)hashtable["x2"], (double)hashtable["y2"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'smoothCurveToAbs', allowed combinations are: [controlPoint, end] [x2, y2, x, y]");
	}

	private void ExecutePathSmoothCurveToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "controlPoint")
			{
				hashtable["controlPoint"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x2")
			{
				hashtable["x2"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y2")
			{
				hashtable["y2"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "controlPoint", "end"))
		{
			paths.Add(new PathSmoothCurveToRel((PointD)hashtable["controlPoint"], (PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x2", "y2", "x", "y"))
		{
			paths.Add(new PathSmoothCurveToRel((double)hashtable["x2"], (double)hashtable["y2"], (double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'smoothCurveToRel', allowed combinations are: [controlPoint, end] [x2, y2, x, y]");
	}

	private void ExecutePathSmoothQuadraticCurveToAbs(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "end"))
		{
			paths.Add(new PathSmoothQuadraticCurveToAbs((PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathSmoothQuadraticCurveToAbs((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'smoothQuadraticCurveToAbs', allowed combinations are: [end] [x, y]");
	}

	private void ExecutePathSmoothQuadraticCurveToRel(XmlElement element, Collection<IPath> paths)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "end")
			{
				hashtable["end"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "end"))
		{
			paths.Add(new PathSmoothQuadraticCurveToRel((PointD)hashtable["end"]));
			return;
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			paths.Add(new PathSmoothQuadraticCurveToRel((double)hashtable["x"], (double)hashtable["y"]));
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'smoothQuadraticCurveToRel', allowed combinations are: [end] [x, y]");
	}

	private void ExecuteImage(XmlElement element, IMagickImage image)
	{
		switch (element.Name[0])
		{
		case 'a':
			switch (element.Name[1])
			{
			case 'n':
				switch (element.Name[2])
				{
				case 'i':
					switch (element.Name[9])
					{
					case 'D':
						ExecuteAnimationDelay(element, image);
						return;
					case 'I':
						ExecuteAnimationIterations(element, image);
						return;
					}
					break;
				case 'n':
					ExecuteAnnotate(element, image);
					return;
				}
				break;
			case 'd':
				switch (element.Name[2])
				{
				case 'a':
					switch (element.Name[8])
					{
					case 'B':
						ExecuteAdaptiveBlur(element, image);
						return;
					case 'R':
						ExecuteAdaptiveResize(element, image);
						return;
					case 'S':
						ExecuteAdaptiveSharpen(element, image);
						return;
					case 'T':
						ExecuteAdaptiveThreshold(element, image);
						return;
					}
					break;
				case 'd':
					switch (element.Name[3])
					{
					case 'N':
						ExecuteAddNoise(element, image);
						return;
					case 'P':
						ExecuteAddProfile(element, image);
						return;
					}
					break;
				}
				break;
			case 'l':
				ExecuteAlpha(element, image);
				return;
			case 'u':
				switch (element.Name[4])
				{
				case 'G':
					ExecuteAutoGamma(element, image);
					return;
				case 'L':
					ExecuteAutoLevel(element, image);
					return;
				case 'O':
					ExecuteAutoOrient(image);
					return;
				case 'T':
					ExecuteAutoThreshold(element, image);
					return;
				}
				break;
			}
			break;
		case 'b':
			switch (element.Name[1])
			{
			case 'a':
				ExecuteBackgroundColor(element, image);
				return;
			case 'l':
				switch (element.Name[2])
				{
				case 'a':
					switch (element.Name[5])
					{
					case 'P':
						ExecuteBlackPointCompensation(element, image);
						return;
					case 'T':
						ExecuteBlackThreshold(element, image);
						return;
					}
					break;
				case 'u':
					switch (element.Name[3])
					{
					case 'e':
						ExecuteBlueShift(element, image);
						return;
					case 'r':
						ExecuteBlur(element, image);
						return;
					}
					break;
				}
				break;
			case 'o':
				if (element.Name.Length == 6)
				{
					ExecuteBorder(element, image);
					return;
				}
				if (element.Name.Length == 11)
				{
					ExecuteBorderColor(element, image);
					return;
				}
				break;
			case 'i':
				ExecuteBitDepth(element, image);
				return;
			case 'r':
				ExecuteBrightnessContrast(element, image);
				return;
			}
			break;
		case 'c':
			switch (element.Name[1])
			{
			case 'h':
				switch (element.Name[2])
				{
				case 'r':
					switch (element.Name[6])
					{
					case 'B':
						ExecuteChromaBluePrimary(element, image);
						return;
					case 'G':
						ExecuteChromaGreenPrimary(element, image);
						return;
					case 'R':
						ExecuteChromaRedPrimary(element, image);
						return;
					case 'W':
						ExecuteChromaWhitePoint(element, image);
						return;
					}
					break;
				case 'a':
					ExecuteCharcoal(element, image);
					return;
				case 'o':
					if (element.Name.Length == 4)
					{
						ExecuteChop(element, image);
						return;
					}
					switch (element.Name[4])
					{
					case 'H':
						ExecuteChopHorizontal(element, image);
						return;
					case 'V':
						ExecuteChopVertical(element, image);
						return;
					}
					break;
				}
				break;
			case 'l':
				switch (element.Name[2])
				{
				case 'a':
					switch (element.Name[3])
					{
					case 's':
						ExecuteClassType(element, image);
						return;
					case 'm':
						ExecuteClamp(element, image);
						return;
					}
					break;
				case 'i':
					ExecuteClip(element, image);
					return;
				case 'u':
					ExecuteClut(element, image);
					return;
				case 'o':
					ExecuteClone(element, image);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'l':
					switch (element.Name[5])
					{
					case 'F':
						ExecuteColorFuzz(element, image);
						return;
					case 'm':
						ExecuteColormapSize(element, image);
						return;
					case 'S':
						ExecuteColorSpace(element, image);
						return;
					case 'T':
						ExecuteColorType(element, image);
						return;
					case 'A':
						ExecuteColorAlpha(element, image);
						return;
					case 'D':
						ExecuteColorDecisionList(element, image);
						return;
					case 'i':
						ExecuteColorize(element, image);
						return;
					}
					break;
				case 'm':
					switch (element.Name[3])
					{
					case 'm':
						ExecuteComment(element, image);
						return;
					case 'p':
						switch (element.Name[4])
						{
						case 'o':
							switch (element.Name[6])
							{
							case 'e':
								ExecuteCompose(element, image);
								return;
							case 'i':
								ExecuteComposite(element, image);
								return;
							}
							break;
						case 'r':
							ExecuteCompressionMethod(element, image);
							return;
						}
						break;
					}
					break;
				case 'n':
					if (element.Name.Length == 8)
					{
						ExecuteContrast(element, image);
						return;
					}
					if (element.Name.Length == 15)
					{
						ExecuteContrastStretch(element, image);
						return;
					}
					break;
				case 'p':
					ExecuteCopyPixels(element, image);
					return;
				}
				break;
			case 'a':
				ExecuteCannyEdge(element, image);
				return;
			case 'r':
				ExecuteCrop(element, image);
				return;
			case 'y':
				ExecuteCycleColormap(element, image);
				return;
			}
			break;
		case 'd':
			switch (element.Name[1])
			{
			case 'e':
				switch (element.Name[2])
				{
				case 'n':
					ExecuteDensity(element, image);
					return;
				case 'p':
					ExecuteDepth(element, image);
					return;
				case 'c':
					ExecuteDecipher(element, image);
					return;
				case 's':
					switch (element.Name[3])
					{
					case 'k':
						ExecuteDeskew(element, image);
						return;
					case 'p':
						ExecuteDespeckle(image);
						return;
					}
					break;
				}
				break;
			case 'i':
				ExecuteDistort(element, image);
				return;
			case 'r':
				ExecuteDraw(element, image);
				return;
			}
			break;
		case 'e':
			switch (element.Name[1])
			{
			case 'n':
				switch (element.Name[2])
				{
				case 'd':
					ExecuteEndian(element, image);
					return;
				case 'c':
					ExecuteEncipher(element, image);
					return;
				case 'h':
					ExecuteEnhance(image);
					return;
				}
				break;
			case 'd':
				ExecuteEdge(element, image);
				return;
			case 'm':
				ExecuteEmboss(element, image);
				return;
			case 'q':
				ExecuteEqualize(image);
				return;
			case 'v':
				ExecuteEvaluate(element, image);
				return;
			case 'x':
				ExecuteExtent(element, image);
				return;
			}
			break;
		case 'f':
			switch (element.Name[1])
			{
			case 'i':
				ExecuteFilterType(element, image);
				return;
			case 'o':
				ExecuteFormat(element, image);
				return;
			case 'l':
				switch (element.Name[2])
				{
				case 'i':
					ExecuteFlip(image);
					return;
				case 'o':
					switch (element.Name[3])
					{
					case 'o':
						ExecuteFloodFill(element, image);
						return;
					case 'p':
						ExecuteFlop(image);
						return;
					}
					break;
				}
				break;
			case 'r':
				ExecuteFrame(element, image);
				return;
			case 'x':
				ExecuteFx(element, image);
				return;
			}
			break;
		case 'g':
			switch (element.Name[1])
			{
			case 'i':
				ExecuteGifDisposeMethod(element, image);
				return;
			case 'a':
				switch (element.Name[2])
				{
				case 'm':
					ExecuteGammaCorrect(element, image);
					return;
				case 'u':
					ExecuteGaussianBlur(element, image);
					return;
				}
				break;
			case 'r':
				ExecuteGrayscale(element, image);
				return;
			}
			break;
		case 'h':
			switch (element.Name[1])
			{
			case 'a':
				switch (element.Name[2])
				{
				case 's':
					ExecuteHasAlpha(element, image);
					return;
				case 'l':
					ExecuteHaldClut(element, image);
					return;
				}
				break;
			case 'o':
				ExecuteHoughLine(element, image);
				return;
			}
			break;
		case 'i':
			switch (element.Name[1])
			{
			case 'n':
				switch (element.Name[2])
				{
				case 't':
					switch (element.Name[5])
					{
					case 'l':
						ExecuteInterlace(element, image);
						return;
					case 'p':
						ExecuteInterpolate(element, image);
						return;
					}
					break;
				case 'v':
					switch (element.Name[7])
					{
					case 'F':
						ExecuteInverseFloodFill(element, image);
						return;
					case 'L':
						if (element.Name.Length == 12)
						{
							ExecuteInverseLevel(element, image);
							return;
						}
						if (element.Name.Length == 18)
						{
							ExecuteInverseLevelColors(element, image);
							return;
						}
						break;
					case 'O':
						ExecuteInverseOpaque(element, image);
						return;
					case 'T':
						if (element.Name.Length == 18)
						{
							ExecuteInverseTransparent(element, image);
							return;
						}
						if (element.Name.Length == 24)
						{
							ExecuteInverseTransparentChroma(element, image);
							return;
						}
						break;
					}
					break;
				}
				break;
			case 'm':
				ExecuteImplode(element, image);
				return;
			}
			break;
		case 'l':
			switch (element.Name[1])
			{
			case 'a':
				ExecuteLabel(element, image);
				return;
			case 'e':
				if (element.Name.Length == 5)
				{
					ExecuteLevel(element, image);
					return;
				}
				if (element.Name.Length == 11)
				{
					ExecuteLevelColors(element, image);
					return;
				}
				break;
			case 'i':
				switch (element.Name[2])
				{
				case 'n':
					ExecuteLinearStretch(element, image);
					return;
				case 'q':
					ExecuteLiquidRescale(element, image);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'c':
					ExecuteLocalContrast(element, image);
					return;
				case 'w':
					ExecuteLower(element, image);
					return;
				}
				break;
			}
			break;
		case 'm':
			switch (element.Name[1])
			{
			case 'a':
				switch (element.Name[2])
				{
				case 't':
					ExecuteMatteColor(element, image);
					return;
				case 'g':
					ExecuteMagnify(image);
					return;
				}
				break;
			case 'e':
				switch (element.Name[2])
				{
				case 'a':
					ExecuteMeanShift(element, image);
					return;
				case 'd':
					ExecuteMedianFilter(element, image);
					return;
				}
				break;
			case 'i':
				ExecuteMinify(image);
				return;
			case 'o':
				switch (element.Name[2])
				{
				case 'd':
					ExecuteModulate(element, image);
					return;
				case 'r':
					ExecuteMorphology(element, image);
					return;
				case 't':
					ExecuteMotionBlur(element, image);
					return;
				}
				break;
			}
			break;
		case 'o':
			switch (element.Name[1])
			{
			case 'r':
				switch (element.Name[2])
				{
				case 'i':
					ExecuteOrientation(element, image);
					return;
				case 'd':
					ExecuteOrderedDither(element, image);
					return;
				}
				break;
			case 'i':
				ExecuteOilPaint(element, image);
				return;
			case 'p':
				ExecuteOpaque(element, image);
				return;
			}
			break;
		case 'p':
			switch (element.Name[1])
			{
			case 'a':
				ExecutePage(element, image);
				return;
			case 'e':
				ExecutePerceptible(element, image);
				return;
			case 'o':
				switch (element.Name[2])
				{
				case 'l':
					ExecutePolaroid(element, image);
					return;
				case 's':
					ExecutePosterize(element, image);
					return;
				}
				break;
			case 'r':
				ExecutePreserveColorType(image);
				return;
			}
			break;
		case 'q':
			switch (element.Name[3])
			{
			case 'l':
				ExecuteQuality(element, image);
				return;
			case 'n':
				ExecuteQuantize(element, image);
				return;
			}
			break;
		case 'r':
			switch (element.Name[1])
			{
			case 'e':
				switch (element.Name[2])
				{
				case 'a':
					ExecuteReadMask(element, image);
					return;
				case 'n':
					ExecuteRenderingIntent(element, image);
					return;
				case 'd':
					ExecuteReduceNoise(element, image);
					return;
				case 'g':
					ExecuteRegionMask(element, image);
					return;
				case 'm':
					switch (element.Name[6])
					{
					case 'A':
						switch (element.Name[7])
						{
						case 'r':
							ExecuteRemoveArtifact(element, image);
							return;
						case 't':
							ExecuteRemoveAttribute(element, image);
							return;
						}
						break;
					case 'P':
						ExecuteRemoveProfile(element, image);
						return;
					case 'R':
						ExecuteRemoveRegionMask(image);
						return;
					}
					break;
				case 'P':
					ExecuteRePage(image);
					return;
				case 's':
					switch (element.Name[3])
					{
					case 'a':
						ExecuteResample(element, image);
						return;
					case 'i':
						ExecuteResize(element, image);
						return;
					}
					break;
				}
				break;
			case 'a':
				switch (element.Name[2])
				{
				case 'i':
					ExecuteRaise(element, image);
					return;
				case 'n':
					ExecuteRandomThreshold(element, image);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'l':
					ExecuteRoll(element, image);
					return;
				case 't':
					switch (element.Name[5])
					{
					case 'e':
						ExecuteRotate(element, image);
						return;
					case 'i':
						ExecuteRotationalBlur(element, image);
						return;
					}
					break;
				}
				break;
			}
			break;
		case 's':
			switch (element.Name[1])
			{
			case 'e':
				switch (element.Name[2])
				{
				case 't':
					switch (element.Name[3])
					{
					case 't':
						ExecuteSettings(element, image);
						return;
					case 'A':
						switch (element.Name[4])
						{
						case 'r':
							ExecuteSetArtifact(element, image);
							return;
						case 't':
							switch (element.Name[6])
							{
							case 'e':
								ExecuteSetAttenuate(element, image);
								return;
							case 'r':
								ExecuteSetAttribute(element, image);
								return;
							}
							break;
						}
						break;
					case 'C':
						switch (element.Name[4])
						{
						case 'l':
							ExecuteSetClippingPath(element, image);
							return;
						case 'o':
							ExecuteSetColormap(element, image);
							return;
						}
						break;
					case 'H':
						ExecuteSetHighlightColor(element, image);
						return;
					case 'L':
						ExecuteSetLowlightColor(element, image);
						return;
					}
					break;
				case 'g':
					ExecuteSegment(element, image);
					return;
				case 'l':
					ExecuteSelectiveBlur(element, image);
					return;
				case 'p':
					ExecuteSepiaTone(element, image);
					return;
				}
				break;
			case 'a':
				ExecuteSample(element, image);
				return;
			case 'c':
				ExecuteScale(element, image);
				return;
			case 'h':
				switch (element.Name[2])
				{
				case 'a':
					switch (element.Name[3])
					{
					case 'd':
						switch (element.Name[4])
						{
						case 'e':
							ExecuteShade(element, image);
							return;
						case 'o':
							ExecuteShadow(element, image);
							return;
						}
						break;
					case 'r':
						ExecuteSharpen(element, image);
						return;
					case 'v':
						ExecuteShave(element, image);
						return;
					}
					break;
				case 'e':
					ExecuteShear(element, image);
					return;
				}
				break;
			case 'i':
				ExecuteSigmoidalContrast(element, image);
				return;
			case 'k':
				ExecuteSketch(element, image);
				return;
			case 'o':
				ExecuteSolarize(element, image);
				return;
			case 'p':
				switch (element.Name[2])
				{
				case 'a':
					ExecuteSparseColor(element, image);
					return;
				case 'l':
					ExecuteSplice(element, image);
					return;
				case 'r':
					ExecuteSpread(element, image);
					return;
				}
				break;
			case 't':
				switch (element.Name[2])
				{
				case 'a':
					ExecuteStatistic(element, image);
					return;
				case 'e':
					switch (element.Name[3])
					{
					case 'g':
						ExecuteStegano(element, image);
						return;
					case 'r':
						ExecuteStereo(element, image);
						return;
					}
					break;
				case 'r':
					ExecuteStrip(image);
					return;
				}
				break;
			case 'w':
				ExecuteSwirl(element, image);
				return;
			}
			break;
		case 'v':
			switch (element.Name[2])
			{
			case 'r':
				ExecuteVirtualPixelMethod(element, image);
				return;
			case 'g':
				ExecuteVignette(element, image);
				return;
			}
			break;
		case 'w':
			switch (element.Name[1])
			{
			case 'r':
				if (element.Name.Length == 5)
				{
					ExecuteWrite(element, image);
					return;
				}
				if (element.Name.Length == 9)
				{
					ExecuteWriteMask(element, image);
					return;
				}
				break;
			case 'a':
				if (element.Name.Length == 4)
				{
					ExecuteWave(element, image);
					return;
				}
				if (element.Name.Length == 14)
				{
					ExecuteWaveletDenoise(element, image);
					return;
				}
				break;
			case 'h':
				ExecuteWhiteThreshold(element, image);
				return;
			}
			break;
		case 'k':
			ExecuteKuwahara(element, image);
			return;
		case 'n':
			switch (element.Name[1])
			{
			case 'e':
				ExecuteNegate(element, image);
				return;
			case 'o':
				ExecuteNormalize(image);
				return;
			}
			break;
		case 't':
			switch (element.Name[1])
			{
			case 'e':
				ExecuteTexture(element, image);
				return;
			case 'h':
				switch (element.Name[2])
				{
				case 'r':
					ExecuteThreshold(element, image);
					return;
				case 'u':
					ExecuteThumbnail(element, image);
					return;
				}
				break;
			case 'i':
				switch (element.Name[2])
				{
				case 'l':
					ExecuteTile(element, image);
					return;
				case 'n':
					ExecuteTint(element, image);
					return;
				}
				break;
			case 'r':
				switch (element.Name[2])
				{
				case 'a':
					switch (element.Name[5])
					{
					case 'f':
						ExecuteTransformColorSpace(element, image);
						return;
					case 'p':
						switch (element.Name[6])
						{
						case 'a':
							if (element.Name.Length == 11)
							{
								ExecuteTransparent(element, image);
								return;
							}
							if (element.Name.Length == 17)
							{
								ExecuteTransparentChroma(element, image);
								return;
							}
							break;
						case 'o':
							ExecuteTranspose(image);
							return;
						}
						break;
					case 'v':
						ExecuteTransverse(image);
						return;
					}
					break;
				case 'i':
					ExecuteTrim(image);
					return;
				}
				break;
			}
			break;
		case 'u':
			ExecuteUnsharpMask(element, image);
			return;
		}
		throw new NotSupportedException(element.Name);
	}

	private void ExecuteAnimationDelay(XmlElement element, IMagickImage image)
	{
		image.AnimationDelay = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteAnimationIterations(XmlElement element, IMagickImage image)
	{
		image.AnimationIterations = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteBackgroundColor(XmlElement element, IMagickImage image)
	{
		image.BackgroundColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteBlackPointCompensation(XmlElement element, IMagickImage image)
	{
		image.BlackPointCompensation = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteBorderColor(XmlElement element, IMagickImage image)
	{
		image.BorderColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteChromaBluePrimary(XmlElement element, IMagickImage image)
	{
		image.ChromaBluePrimary = CreatePrimaryInfo(element);
	}

	private void ExecuteChromaGreenPrimary(XmlElement element, IMagickImage image)
	{
		image.ChromaGreenPrimary = CreatePrimaryInfo(element);
	}

	private void ExecuteChromaRedPrimary(XmlElement element, IMagickImage image)
	{
		image.ChromaRedPrimary = CreatePrimaryInfo(element);
	}

	private void ExecuteChromaWhitePoint(XmlElement element, IMagickImage image)
	{
		image.ChromaWhitePoint = CreatePrimaryInfo(element);
	}

	private void ExecuteClassType(XmlElement element, IMagickImage image)
	{
		image.ClassType = Variables.GetValue<ClassType>(element, "value");
	}

	private void ExecuteColorFuzz(XmlElement element, IMagickImage image)
	{
		image.ColorFuzz = Variables.GetValue<Percentage>(element, "value");
	}

	private void ExecuteColormapSize(XmlElement element, IMagickImage image)
	{
		image.ColormapSize = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteColorSpace(XmlElement element, IMagickImage image)
	{
		image.ColorSpace = Variables.GetValue<ColorSpace>(element, "value");
	}

	private void ExecuteColorType(XmlElement element, IMagickImage image)
	{
		image.ColorType = Variables.GetValue<ColorType>(element, "value");
	}

	private void ExecuteComment(XmlElement element, IMagickImage image)
	{
		image.Comment = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteCompose(XmlElement element, IMagickImage image)
	{
		image.Compose = Variables.GetValue<CompositeOperator>(element, "value");
	}

	private void ExecuteCompressionMethod(XmlElement element, IMagickImage image)
	{
		image.CompressionMethod = Variables.GetValue<CompressionMethod>(element, "value");
	}

	private void ExecuteDensity(XmlElement element, IMagickImage image)
	{
		image.Density = Variables.GetValue<Density>(element, "value");
	}

	private void ExecuteDepth(XmlElement element, IMagickImage image)
	{
		image.Depth = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteEndian(XmlElement element, IMagickImage image)
	{
		image.Endian = Variables.GetValue<Endian>(element, "value");
	}

	private void ExecuteFilterType(XmlElement element, IMagickImage image)
	{
		image.FilterType = Variables.GetValue<FilterType>(element, "value");
	}

	private void ExecuteFormat(XmlElement element, IMagickImage image)
	{
		image.Format = Variables.GetValue<MagickFormat>(element, "value");
	}

	private void ExecuteGifDisposeMethod(XmlElement element, IMagickImage image)
	{
		image.GifDisposeMethod = Variables.GetValue<GifDisposeMethod>(element, "value");
	}

	private void ExecuteHasAlpha(XmlElement element, IMagickImage image)
	{
		image.HasAlpha = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteInterlace(XmlElement element, IMagickImage image)
	{
		image.Interlace = Variables.GetValue<Interlace>(element, "value");
	}

	private void ExecuteInterpolate(XmlElement element, IMagickImage image)
	{
		image.Interpolate = Variables.GetValue<PixelInterpolateMethod>(element, "value");
	}

	private void ExecuteLabel(XmlElement element, IMagickImage image)
	{
		image.Label = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteMatteColor(XmlElement element, IMagickImage image)
	{
		image.MatteColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteOrientation(XmlElement element, IMagickImage image)
	{
		image.Orientation = Variables.GetValue<OrientationType>(element, "value");
	}

	private void ExecutePage(XmlElement element, IMagickImage image)
	{
		image.Page = Variables.GetValue<MagickGeometry>(element, "value");
	}

	private void ExecuteQuality(XmlElement element, IMagickImage image)
	{
		image.Quality = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteReadMask(XmlElement element, IMagickImage image)
	{
		image.ReadMask = CreateMagickImage(element);
	}

	private void ExecuteRenderingIntent(XmlElement element, IMagickImage image)
	{
		image.RenderingIntent = Variables.GetValue<RenderingIntent>(element, "value");
	}

	private void ExecuteSettings(XmlElement element, IMagickImage image)
	{
		ExecuteMagickSettings(element, image);
	}

	private void ExecuteVirtualPixelMethod(XmlElement element, IMagickImage image)
	{
		image.VirtualPixelMethod = Variables.GetValue<VirtualPixelMethod>(element, "value");
	}

	private void ExecuteWriteMask(XmlElement element, IMagickImage image)
	{
		image.WriteMask = CreateMagickImage(element);
	}

	private void ExecuteAdaptiveBlur(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.AdaptiveBlur();
			return;
		}
		if (OnlyContains(hashtable, "radius"))
		{
			image.AdaptiveBlur((double)hashtable["radius"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.AdaptiveBlur((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'adaptiveBlur', allowed combinations are: [] [radius] [radius, sigma]");
	}

	private void ExecuteAdaptiveResize(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.AdaptiveResize((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.AdaptiveResize((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'adaptiveResize', allowed combinations are: [geometry] [width, height]");
	}

	private void ExecuteAdaptiveSharpen(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.AdaptiveSharpen();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.AdaptiveSharpen((Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.AdaptiveSharpen((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "channels"))
		{
			image.AdaptiveSharpen((double)hashtable["radius"], (double)hashtable["sigma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'adaptiveSharpen', allowed combinations are: [] [channels] [radius, sigma] [radius, sigma, channels]");
	}

	private void ExecuteAdaptiveThreshold(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "bias")
			{
				hashtable["bias"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "biasPercentage")
			{
				hashtable["biasPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.AdaptiveThreshold((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "bias"))
		{
			image.AdaptiveThreshold((int)hashtable["width"], (int)hashtable["height"], (double)hashtable["bias"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "biasPercentage"))
		{
			image.AdaptiveThreshold((int)hashtable["width"], (int)hashtable["height"], (Percentage)hashtable["biasPercentage"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'adaptiveThreshold', allowed combinations are: [width, height] [width, height, bias] [width, height, biasPercentage]");
	}

	private void ExecuteAddNoise(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "attenuate")
			{
				hashtable["attenuate"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "noiseType")
			{
				hashtable["noiseType"] = Variables.GetValue<NoiseType>(attribute);
			}
		}
		if (OnlyContains(hashtable, "noiseType"))
		{
			image.AddNoise((NoiseType)hashtable["noiseType"]);
			return;
		}
		if (OnlyContains(hashtable, "noiseType", "attenuate"))
		{
			image.AddNoise((NoiseType)hashtable["noiseType"], (double)hashtable["attenuate"]);
			return;
		}
		if (OnlyContains(hashtable, "noiseType", "attenuate", "channels"))
		{
			image.AddNoise((NoiseType)hashtable["noiseType"], (double)hashtable["attenuate"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "noiseType", "channels"))
		{
			image.AddNoise((NoiseType)hashtable["noiseType"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'addNoise', allowed combinations are: [noiseType] [noiseType, attenuate] [noiseType, attenuate, channels] [noiseType, channels]");
	}

	private void ExecuteAddProfile(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<bool>(attribute);
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateProfile(item);
		}
		if (OnlyContains(hashtable, "profile"))
		{
			image.AddProfile((ImageProfile)hashtable["profile"]);
			return;
		}
		if (OnlyContains(hashtable, "profile", "overwriteExisting"))
		{
			image.AddProfile((ImageProfile)hashtable["profile"], (bool)hashtable["overwriteExisting"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'addProfile', allowed combinations are: [profile] [profile, overwriteExisting]");
	}

	private void ExecuteAlpha(XmlElement element, IMagickImage image)
	{
		AlphaOption value = Variables.GetValue<AlphaOption>(element, "value");
		image.Alpha(value);
	}

	private void ExecuteAnnotate(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "angle")
			{
				hashtable["angle"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "boundingArea")
			{
				hashtable["boundingArea"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "gravity")
			{
				hashtable["gravity"] = Variables.GetValue<Gravity>(attribute);
			}
			else if (attribute.Name == "text")
			{
				hashtable["text"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "text", "boundingArea"))
		{
			image.Annotate((string)hashtable["text"], (MagickGeometry)hashtable["boundingArea"]);
			return;
		}
		if (OnlyContains(hashtable, "text", "boundingArea", "gravity"))
		{
			image.Annotate((string)hashtable["text"], (MagickGeometry)hashtable["boundingArea"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "text", "boundingArea", "gravity", "angle"))
		{
			image.Annotate((string)hashtable["text"], (MagickGeometry)hashtable["boundingArea"], (Gravity)hashtable["gravity"], (double)hashtable["angle"]);
			return;
		}
		if (OnlyContains(hashtable, "text", "gravity"))
		{
			image.Annotate((string)hashtable["text"], (Gravity)hashtable["gravity"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'annotate', allowed combinations are: [text, boundingArea] [text, boundingArea, gravity] [text, boundingArea, gravity, angle] [text, gravity]");
	}

	private void ExecuteAutoGamma(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<Channels>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.AutoGamma();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.AutoGamma((Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'autoGamma', allowed combinations are: [] [channels]");
	}

	private void ExecuteAutoLevel(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<Channels>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.AutoLevel();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.AutoLevel((Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'autoLevel', allowed combinations are: [] [channels]");
	}

	private static void ExecuteAutoOrient(IMagickImage image)
	{
		image.AutoOrient();
	}

	private void ExecuteAutoThreshold(XmlElement element, IMagickImage image)
	{
		AutoThresholdMethod value = Variables.GetValue<AutoThresholdMethod>(element, "method");
		image.AutoThreshold(value);
	}

	private void ExecuteBitDepth(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "value")
			{
				hashtable["value"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "channels", "value"))
		{
			image.BitDepth((Channels)hashtable["channels"], (int)hashtable["value"]);
			return;
		}
		if (OnlyContains(hashtable, "value"))
		{
			image.BitDepth((int)hashtable["value"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'bitDepth', allowed combinations are: [channels, value] [value]");
	}

	private void ExecuteBlackThreshold(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "threshold")
			{
				hashtable["threshold"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "threshold"))
		{
			image.BlackThreshold((Percentage)hashtable["threshold"]);
			return;
		}
		if (OnlyContains(hashtable, "threshold", "channels"))
		{
			image.BlackThreshold((Percentage)hashtable["threshold"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'blackThreshold', allowed combinations are: [threshold] [threshold, channels]");
	}

	private void ExecuteBlueShift(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.BlueShift();
			return;
		}
		if (OnlyContains(hashtable, "factor"))
		{
			image.BlueShift((double)hashtable["factor"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'blueShift', allowed combinations are: [] [factor]");
	}

	private void ExecuteBlur(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Blur();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.Blur((Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.Blur((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "channels"))
		{
			image.Blur((double)hashtable["radius"], (double)hashtable["sigma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'blur', allowed combinations are: [] [channels] [radius, sigma] [radius, sigma, channels]");
	}

	private void ExecuteBorder(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<int>(attribute);
		}
		if (OnlyContains(hashtable, "size"))
		{
			image.Border((int)hashtable["size"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Border((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'border', allowed combinations are: [size] [width, height]");
	}

	private void ExecuteBrightnessContrast(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "brightness")
			{
				hashtable["brightness"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "contrast")
			{
				hashtable["contrast"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "brightness", "contrast"))
		{
			image.BrightnessContrast((Percentage)hashtable["brightness"], (Percentage)hashtable["contrast"]);
			return;
		}
		if (OnlyContains(hashtable, "brightness", "contrast", "channels"))
		{
			image.BrightnessContrast((Percentage)hashtable["brightness"], (Percentage)hashtable["contrast"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'brightnessContrast', allowed combinations are: [brightness, contrast] [brightness, contrast, channels]");
	}

	private void ExecuteCannyEdge(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "lower")
			{
				hashtable["lower"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "upper")
			{
				hashtable["upper"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.CannyEdge();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "lower", "upper"))
		{
			image.CannyEdge((double)hashtable["radius"], (double)hashtable["sigma"], (Percentage)hashtable["lower"], (Percentage)hashtable["upper"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'cannyEdge', allowed combinations are: [] [radius, sigma, lower, upper]");
	}

	private void ExecuteCharcoal(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Charcoal();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.Charcoal((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'charcoal', allowed combinations are: [] [radius, sigma]");
	}

	private void ExecuteChop(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "xOffset")
			{
				hashtable["xOffset"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "yOffset")
			{
				hashtable["yOffset"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Chop((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "xOffset", "width", "yOffset", "height"))
		{
			image.Chop((int)hashtable["xOffset"], (int)hashtable["width"], (int)hashtable["yOffset"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'chop', allowed combinations are: [geometry] [xOffset, width, yOffset, height]");
	}

	private void ExecuteChopHorizontal(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "offset");
		int value2 = Variables.GetValue<int>(element, "width");
		image.ChopHorizontal(value, value2);
	}

	private void ExecuteChopVertical(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "offset");
		int value2 = Variables.GetValue<int>(element, "height");
		image.ChopVertical(value, value2);
	}

	private void ExecuteClamp(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<Channels>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Clamp();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.Clamp((Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'clamp', allowed combinations are: [] [channels]");
	}

	private void ExecuteClip(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "inside")
			{
				hashtable["inside"] = Variables.GetValue<bool>(attribute);
			}
			else if (attribute.Name == "pathName")
			{
				hashtable["pathName"] = Variables.GetValue<string>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Clip();
			return;
		}
		if (OnlyContains(hashtable, "pathName", "inside"))
		{
			image.Clip((string)hashtable["pathName"], (bool)hashtable["inside"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'clip', allowed combinations are: [] [pathName, inside]");
	}

	private void ExecuteClut(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<PixelInterpolateMethod>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "image"))
		{
			image.Clut((IMagickImage)hashtable["image"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "method"))
		{
			image.Clut((IMagickImage)hashtable["image"], (PixelInterpolateMethod)hashtable["method"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "method", "channels"))
		{
			image.Clut((IMagickImage)hashtable["image"], (PixelInterpolateMethod)hashtable["method"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'clut', allowed combinations are: [image] [image, method] [image, method, channels]");
	}

	private void ExecuteColorAlpha(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		image.ColorAlpha(value);
	}

	private void ExecuteColorDecisionList(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "fileName");
		image.ColorDecisionList(value);
	}

	private void ExecuteColorize(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "alpha")
			{
				hashtable["alpha"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "alphaBlue")
			{
				hashtable["alphaBlue"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "alphaGreen")
			{
				hashtable["alphaGreen"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "alphaRed")
			{
				hashtable["alphaRed"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "color")
			{
				hashtable["color"] = Variables.GetValue<MagickColor>(attribute);
			}
		}
		if (OnlyContains(hashtable, "color", "alpha"))
		{
			image.Colorize((MagickColor)hashtable["color"], (Percentage)hashtable["alpha"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "alphaRed", "alphaGreen", "alphaBlue"))
		{
			image.Colorize((MagickColor)hashtable["color"], (Percentage)hashtable["alphaRed"], (Percentage)hashtable["alphaGreen"], (Percentage)hashtable["alphaBlue"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'colorize', allowed combinations are: [color, alpha] [color, alphaRed, alphaGreen, alphaBlue]");
	}

	private void ExecuteComposite(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "args")
			{
				hashtable["args"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "compose")
			{
				hashtable["compose"] = Variables.GetValue<CompositeOperator>(attribute);
			}
			else if (attribute.Name == "gravity")
			{
				hashtable["gravity"] = Variables.GetValue<Gravity>(attribute);
			}
			else if (attribute.Name == "offset")
			{
				hashtable["offset"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "image"))
		{
			image.Composite((IMagickImage)hashtable["image"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "compose"))
		{
			image.Composite((IMagickImage)hashtable["image"], (CompositeOperator)hashtable["compose"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "compose", "args"))
		{
			image.Composite((IMagickImage)hashtable["image"], (CompositeOperator)hashtable["compose"], (string)hashtable["args"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "gravity"))
		{
			image.Composite((IMagickImage)hashtable["image"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "gravity", "compose"))
		{
			image.Composite((IMagickImage)hashtable["image"], (Gravity)hashtable["gravity"], (CompositeOperator)hashtable["compose"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "gravity", "compose", "args"))
		{
			image.Composite((IMagickImage)hashtable["image"], (Gravity)hashtable["gravity"], (CompositeOperator)hashtable["compose"], (string)hashtable["args"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "offset"))
		{
			image.Composite((IMagickImage)hashtable["image"], (PointD)hashtable["offset"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "offset", "compose"))
		{
			image.Composite((IMagickImage)hashtable["image"], (PointD)hashtable["offset"], (CompositeOperator)hashtable["compose"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "offset", "compose", "args"))
		{
			image.Composite((IMagickImage)hashtable["image"], (PointD)hashtable["offset"], (CompositeOperator)hashtable["compose"], (string)hashtable["args"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y"))
		{
			image.Composite((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y", "compose"))
		{
			image.Composite((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"], (CompositeOperator)hashtable["compose"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y", "compose", "args"))
		{
			image.Composite((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"], (CompositeOperator)hashtable["compose"], (string)hashtable["args"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'composite', allowed combinations are: [image] [image, compose] [image, compose, args] [image, gravity] [image, gravity, compose] [image, gravity, compose, args] [image, offset] [image, offset, compose] [image, offset, compose, args] [image, x, y] [image, x, y, compose] [image, x, y, compose, args]");
	}

	private void ExecuteContrast(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<bool>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Contrast();
			return;
		}
		if (OnlyContains(hashtable, "enhance"))
		{
			image.Contrast((bool)hashtable["enhance"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'contrast', allowed combinations are: [] [enhance]");
	}

	private void ExecuteContrastStretch(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "blackPoint")
			{
				hashtable["blackPoint"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "whitePoint")
			{
				hashtable["whitePoint"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "blackPoint"))
		{
			image.ContrastStretch((Percentage)hashtable["blackPoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint"))
		{
			image.ContrastStretch((Percentage)hashtable["blackPoint"], (Percentage)hashtable["whitePoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "channels"))
		{
			image.ContrastStretch((Percentage)hashtable["blackPoint"], (Percentage)hashtable["whitePoint"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'contrastStretch', allowed combinations are: [blackPoint] [blackPoint, whitePoint] [blackPoint, whitePoint, channels]");
	}

	private void ExecuteCopyPixels(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "offset")
			{
				hashtable["offset"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "source"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "channels"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry", "channels"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry", "offset"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"], (PointD)hashtable["offset"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry", "offset", "channels"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"], (PointD)hashtable["offset"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry", "x", "y"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "source", "geometry", "x", "y", "channels"))
		{
			image.CopyPixels((IMagickImage)hashtable["source"], (MagickGeometry)hashtable["geometry"], (int)hashtable["x"], (int)hashtable["y"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'copyPixels', allowed combinations are: [source] [source, channels] [source, geometry] [source, geometry, channels] [source, geometry, offset] [source, geometry, offset, channels] [source, geometry, x, y] [source, geometry, x, y, channels]");
	}

	private void ExecuteCrop(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "gravity")
			{
				hashtable["gravity"] = Variables.GetValue<Gravity>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Crop((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "geometry", "gravity"))
		{
			image.Crop((MagickGeometry)hashtable["geometry"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Crop((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "gravity"))
		{
			image.Crop((int)hashtable["width"], (int)hashtable["height"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "width", "height"))
		{
			image.Crop((int)hashtable["x"], (int)hashtable["y"], (int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'crop', allowed combinations are: [geometry] [geometry, gravity] [width, height] [width, height, gravity] [x, y, width, height]");
	}

	private void ExecuteCycleColormap(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "amount");
		image.CycleColormap(value);
	}

	private void ExecuteDecipher(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "passphrase");
		image.Decipher(value);
	}

	private void ExecuteDeskew(XmlElement element, IMagickImage image)
	{
		Percentage value = Variables.GetValue<Percentage>(element, "threshold");
		image.Deskew(value);
	}

	private static void ExecuteDespeckle(IMagickImage image)
	{
		image.Despeckle();
	}

	private void ExecuteDistort(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "bestfit")
			{
				hashtable["bestfit"] = Variables.GetValue<bool>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<DistortMethod>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = Variables.GetDoubleArray(item);
		}
		if (OnlyContains(hashtable, "method", "arguments"))
		{
			image.Distort((DistortMethod)hashtable["method"], (double[])hashtable["arguments"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "bestfit", "arguments"))
		{
			image.Distort((DistortMethod)hashtable["method"], (bool)hashtable["bestfit"], (double[])hashtable["arguments"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'distort', allowed combinations are: [method, arguments] [method, bestfit, arguments]");
	}

	private void ExecuteEdge(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "radius");
		image.Edge(value);
	}

	private void ExecuteEmboss(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Emboss();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.Emboss((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'emboss', allowed combinations are: [] [radius, sigma]");
	}

	private void ExecuteEncipher(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "passphrase");
		image.Encipher(value);
	}

	private static void ExecuteEnhance(IMagickImage image)
	{
		image.Enhance();
	}

	private static void ExecuteEqualize(IMagickImage image)
	{
		image.Equalize();
	}

	private void ExecuteEvaluate(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "evaluateFunction")
			{
				hashtable["evaluateFunction"] = Variables.GetValue<EvaluateFunction>(attribute);
			}
			else if (attribute.Name == "evaluateOperator")
			{
				hashtable["evaluateOperator"] = Variables.GetValue<EvaluateOperator>(attribute);
			}
			else if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "value")
			{
				hashtable["value"] = Variables.GetValue<double>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = Variables.GetDoubleArray(item);
		}
		if (OnlyContains(hashtable, "channels", "evaluateFunction", "arguments"))
		{
			image.Evaluate((Channels)hashtable["channels"], (EvaluateFunction)hashtable["evaluateFunction"], (double[])hashtable["arguments"]);
			return;
		}
		if (OnlyContains(hashtable, "channels", "evaluateOperator", "percentage"))
		{
			image.Evaluate((Channels)hashtable["channels"], (EvaluateOperator)hashtable["evaluateOperator"], (Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "channels", "evaluateOperator", "value"))
		{
			image.Evaluate((Channels)hashtable["channels"], (EvaluateOperator)hashtable["evaluateOperator"], (double)hashtable["value"]);
			return;
		}
		if (OnlyContains(hashtable, "channels", "geometry", "evaluateOperator", "percentage"))
		{
			image.Evaluate((Channels)hashtable["channels"], (MagickGeometry)hashtable["geometry"], (EvaluateOperator)hashtable["evaluateOperator"], (Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "channels", "geometry", "evaluateOperator", "value"))
		{
			image.Evaluate((Channels)hashtable["channels"], (MagickGeometry)hashtable["geometry"], (EvaluateOperator)hashtable["evaluateOperator"], (double)hashtable["value"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'evaluate', allowed combinations are: [channels, evaluateFunction, arguments] [channels, evaluateOperator, percentage] [channels, evaluateOperator, value] [channels, geometry, evaluateOperator, percentage] [channels, geometry, evaluateOperator, value]");
	}

	private void ExecuteExtent(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "backgroundColor")
			{
				hashtable["backgroundColor"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "gravity")
			{
				hashtable["gravity"] = Variables.GetValue<Gravity>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Extent((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "geometry", "backgroundColor"))
		{
			image.Extent((MagickGeometry)hashtable["geometry"], (MagickColor)hashtable["backgroundColor"]);
			return;
		}
		if (OnlyContains(hashtable, "geometry", "gravity"))
		{
			image.Extent((MagickGeometry)hashtable["geometry"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "geometry", "gravity", "backgroundColor"))
		{
			image.Extent((MagickGeometry)hashtable["geometry"], (Gravity)hashtable["gravity"], (MagickColor)hashtable["backgroundColor"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Extent((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "backgroundColor"))
		{
			image.Extent((int)hashtable["width"], (int)hashtable["height"], (MagickColor)hashtable["backgroundColor"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "gravity"))
		{
			image.Extent((int)hashtable["width"], (int)hashtable["height"], (Gravity)hashtable["gravity"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "gravity", "backgroundColor"))
		{
			image.Extent((int)hashtable["width"], (int)hashtable["height"], (Gravity)hashtable["gravity"], (MagickColor)hashtable["backgroundColor"]);
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "width", "height"))
		{
			image.Extent((int)hashtable["x"], (int)hashtable["y"], (int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'extent', allowed combinations are: [geometry] [geometry, backgroundColor] [geometry, gravity] [geometry, gravity, backgroundColor] [width, height] [width, height, backgroundColor] [width, height, gravity] [width, height, gravity, backgroundColor] [x, y, width, height]");
	}

	private static void ExecuteFlip(IMagickImage image)
	{
		image.Flip();
	}

	private void ExecuteFloodFill(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "alpha")
			{
				hashtable["alpha"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "color")
			{
				hashtable["color"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "coordinate")
			{
				hashtable["coordinate"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "target")
			{
				hashtable["target"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "alpha", "x", "y"))
		{
			image.FloodFill((byte)hashtable["alpha"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "coordinate"))
		{
			image.FloodFill((MagickColor)hashtable["color"], (PointD)hashtable["coordinate"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "coordinate", "target"))
		{
			image.FloodFill((MagickColor)hashtable["color"], (PointD)hashtable["coordinate"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "x", "y"))
		{
			image.FloodFill((MagickColor)hashtable["color"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "x", "y", "target"))
		{
			image.FloodFill((MagickColor)hashtable["color"], (int)hashtable["x"], (int)hashtable["y"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "coordinate"))
		{
			image.FloodFill((IMagickImage)hashtable["image"], (PointD)hashtable["coordinate"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "coordinate", "target"))
		{
			image.FloodFill((IMagickImage)hashtable["image"], (PointD)hashtable["coordinate"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y"))
		{
			image.FloodFill((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y", "target"))
		{
			image.FloodFill((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"], (MagickColor)hashtable["target"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'floodFill', allowed combinations are: [alpha, x, y] [color, coordinate] [color, coordinate, target] [color, x, y] [color, x, y, target] [image, coordinate] [image, coordinate, target] [image, x, y] [image, x, y, target]");
	}

	private static void ExecuteFlop(IMagickImage image)
	{
		image.Flop();
	}

	private void ExecuteFrame(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "innerBevel")
			{
				hashtable["innerBevel"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "outerBevel")
			{
				hashtable["outerBevel"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Frame();
			return;
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Frame((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Frame((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "innerBevel", "outerBevel"))
		{
			image.Frame((int)hashtable["width"], (int)hashtable["height"], (int)hashtable["innerBevel"], (int)hashtable["outerBevel"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'frame', allowed combinations are: [] [geometry] [width, height] [width, height, innerBevel, outerBevel]");
	}

	private void ExecuteFx(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "expression")
			{
				hashtable["expression"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "expression"))
		{
			image.Fx((string)hashtable["expression"]);
			return;
		}
		if (OnlyContains(hashtable, "expression", "channels"))
		{
			image.Fx((string)hashtable["expression"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'fx', allowed combinations are: [expression] [expression, channels]");
	}

	private void ExecuteGammaCorrect(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "gamma")
			{
				hashtable["gamma"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "gamma"))
		{
			image.GammaCorrect((double)hashtable["gamma"]);
			return;
		}
		if (OnlyContains(hashtable, "gamma", "channels"))
		{
			image.GammaCorrect((double)hashtable["gamma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'gammaCorrect', allowed combinations are: [gamma] [gamma, channels]");
	}

	private void ExecuteGaussianBlur(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.GaussianBlur((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "channels"))
		{
			image.GaussianBlur((double)hashtable["radius"], (double)hashtable["sigma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'gaussianBlur', allowed combinations are: [radius, sigma] [radius, sigma, channels]");
	}

	private void ExecuteGrayscale(XmlElement element, IMagickImage image)
	{
		PixelIntensityMethod value = Variables.GetValue<PixelIntensityMethod>(element, "method");
		image.Grayscale(value);
	}

	private void ExecuteHaldClut(XmlElement element, IMagickImage image)
	{
		IMagickImage image2 = CreateMagickImage(element["image"]);
		image.HaldClut(image2);
	}

	private void ExecuteHoughLine(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<int>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.HoughLine();
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "threshold"))
		{
			image.HoughLine((int)hashtable["width"], (int)hashtable["height"], (int)hashtable["threshold"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'houghLine', allowed combinations are: [] [width, height, threshold]");
	}

	private void ExecuteImplode(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "amount");
		PixelInterpolateMethod value2 = Variables.GetValue<PixelInterpolateMethod>(element, "method");
		image.Implode(value, value2);
	}

	private void ExecuteInverseFloodFill(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "alpha")
			{
				hashtable["alpha"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "color")
			{
				hashtable["color"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "coordinate")
			{
				hashtable["coordinate"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "target")
			{
				hashtable["target"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "alpha", "x", "y"))
		{
			image.InverseFloodFill((byte)hashtable["alpha"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "coordinate"))
		{
			image.InverseFloodFill((MagickColor)hashtable["color"], (PointD)hashtable["coordinate"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "coordinate", "target"))
		{
			image.InverseFloodFill((MagickColor)hashtable["color"], (PointD)hashtable["coordinate"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "x", "y"))
		{
			image.InverseFloodFill((MagickColor)hashtable["color"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "color", "x", "y", "target"))
		{
			image.InverseFloodFill((MagickColor)hashtable["color"], (int)hashtable["x"], (int)hashtable["y"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "coordinate"))
		{
			image.InverseFloodFill((IMagickImage)hashtable["image"], (PointD)hashtable["coordinate"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "coordinate", "target"))
		{
			image.InverseFloodFill((IMagickImage)hashtable["image"], (PointD)hashtable["coordinate"], (MagickColor)hashtable["target"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y"))
		{
			image.InverseFloodFill((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "x", "y", "target"))
		{
			image.InverseFloodFill((IMagickImage)hashtable["image"], (int)hashtable["x"], (int)hashtable["y"], (MagickColor)hashtable["target"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'inverseFloodFill', allowed combinations are: [alpha, x, y] [color, coordinate] [color, coordinate, target] [color, x, y] [color, x, y, target] [image, coordinate] [image, coordinate, target] [image, x, y] [image, x, y, target]");
	}

	private void ExecuteInverseLevel(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "blackPoint")
			{
				hashtable["blackPoint"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "blackPointPercentage")
			{
				hashtable["blackPointPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "midpoint")
			{
				hashtable["midpoint"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "whitePoint")
			{
				hashtable["whitePoint"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "whitePointPercentage")
			{
				hashtable["whitePointPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint"))
		{
			image.InverseLevel((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "channels"))
		{
			image.InverseLevel((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "midpoint"))
		{
			image.InverseLevel((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (double)hashtable["midpoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "midpoint", "channels"))
		{
			image.InverseLevel((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (double)hashtable["midpoint"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage"))
		{
			image.InverseLevel((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "channels"))
		{
			image.InverseLevel((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "midpoint"))
		{
			image.InverseLevel((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (double)hashtable["midpoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "midpoint", "channels"))
		{
			image.InverseLevel((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (double)hashtable["midpoint"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'inverseLevel', allowed combinations are: [blackPoint, whitePoint] [blackPoint, whitePoint, channels] [blackPoint, whitePoint, midpoint] [blackPoint, whitePoint, midpoint, channels] [blackPointPercentage, whitePointPercentage] [blackPointPercentage, whitePointPercentage, channels] [blackPointPercentage, whitePointPercentage, midpoint] [blackPointPercentage, whitePointPercentage, midpoint, channels]");
	}

	private void ExecuteInverseLevelColors(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "blackColor")
			{
				hashtable["blackColor"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "whiteColor")
			{
				hashtable["whiteColor"] = Variables.GetValue<MagickColor>(attribute);
			}
		}
		if (OnlyContains(hashtable, "blackColor", "whiteColor"))
		{
			image.InverseLevelColors((MagickColor)hashtable["blackColor"], (MagickColor)hashtable["whiteColor"]);
			return;
		}
		if (OnlyContains(hashtable, "blackColor", "whiteColor", "channels"))
		{
			image.InverseLevelColors((MagickColor)hashtable["blackColor"], (MagickColor)hashtable["whiteColor"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'inverseLevelColors', allowed combinations are: [blackColor, whiteColor] [blackColor, whiteColor, channels]");
	}

	private void ExecuteInverseOpaque(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "target");
		MagickColor value2 = Variables.GetValue<MagickColor>(element, "fill");
		image.InverseOpaque(value, value2);
	}

	private void ExecuteInverseTransparent(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		image.InverseTransparent(value);
	}

	private void ExecuteInverseTransparentChroma(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "colorLow");
		MagickColor value2 = Variables.GetValue<MagickColor>(element, "colorHigh");
		image.InverseTransparentChroma(value, value2);
	}

	private void ExecuteKuwahara(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Kuwahara();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.Kuwahara((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'kuwahara', allowed combinations are: [] [radius, sigma]");
	}

	private void ExecuteLevel(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "blackPoint")
			{
				hashtable["blackPoint"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "blackPointPercentage")
			{
				hashtable["blackPointPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "gamma")
			{
				hashtable["gamma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "whitePoint")
			{
				hashtable["whitePoint"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "whitePointPercentage")
			{
				hashtable["whitePointPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint"))
		{
			image.Level((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "channels"))
		{
			image.Level((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "gamma"))
		{
			image.Level((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (double)hashtable["gamma"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPoint", "whitePoint", "gamma", "channels"))
		{
			image.Level((byte)hashtable["blackPoint"], (byte)hashtable["whitePoint"], (double)hashtable["gamma"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage"))
		{
			image.Level((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "channels"))
		{
			image.Level((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "gamma"))
		{
			image.Level((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (double)hashtable["gamma"]);
			return;
		}
		if (OnlyContains(hashtable, "blackPointPercentage", "whitePointPercentage", "gamma", "channels"))
		{
			image.Level((Percentage)hashtable["blackPointPercentage"], (Percentage)hashtable["whitePointPercentage"], (double)hashtable["gamma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'level', allowed combinations are: [blackPoint, whitePoint] [blackPoint, whitePoint, channels] [blackPoint, whitePoint, gamma] [blackPoint, whitePoint, gamma, channels] [blackPointPercentage, whitePointPercentage] [blackPointPercentage, whitePointPercentage, channels] [blackPointPercentage, whitePointPercentage, gamma] [blackPointPercentage, whitePointPercentage, gamma, channels]");
	}

	private void ExecuteLevelColors(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "blackColor")
			{
				hashtable["blackColor"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "whiteColor")
			{
				hashtable["whiteColor"] = Variables.GetValue<MagickColor>(attribute);
			}
		}
		if (OnlyContains(hashtable, "blackColor", "whiteColor"))
		{
			image.LevelColors((MagickColor)hashtable["blackColor"], (MagickColor)hashtable["whiteColor"]);
			return;
		}
		if (OnlyContains(hashtable, "blackColor", "whiteColor", "channels"))
		{
			image.LevelColors((MagickColor)hashtable["blackColor"], (MagickColor)hashtable["whiteColor"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'levelColors', allowed combinations are: [blackColor, whiteColor] [blackColor, whiteColor, channels]");
	}

	private void ExecuteLinearStretch(XmlElement element, IMagickImage image)
	{
		Percentage value = Variables.GetValue<Percentage>(element, "blackPoint");
		Percentage value2 = Variables.GetValue<Percentage>(element, "whitePoint");
		image.LinearStretch(value, value2);
	}

	private void ExecuteLiquidRescale(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageHeight")
			{
				hashtable["percentageHeight"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageWidth")
			{
				hashtable["percentageWidth"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.LiquidRescale((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "percentage"))
		{
			image.LiquidRescale((Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageWidth", "percentageHeight"))
		{
			image.LiquidRescale((Percentage)hashtable["percentageWidth"], (Percentage)hashtable["percentageHeight"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.LiquidRescale((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'liquidRescale', allowed combinations are: [geometry] [percentage] [percentageWidth, percentageHeight] [width, height]");
	}

	private void ExecuteLocalContrast(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "radius");
		Percentage value2 = Variables.GetValue<Percentage>(element, "strength");
		image.LocalContrast(value, value2);
	}

	private void ExecuteLower(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "size");
		image.Lower(value);
	}

	private static void ExecuteMagnify(IMagickImage image)
	{
		image.Magnify();
	}

	private void ExecuteMeanShift(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "colorDistance")
			{
				hashtable["colorDistance"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "size")
			{
				hashtable["size"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "size"))
		{
			image.MeanShift((int)hashtable["size"]);
			return;
		}
		if (OnlyContains(hashtable, "size", "colorDistance"))
		{
			image.MeanShift((int)hashtable["size"], (Percentage)hashtable["colorDistance"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.MeanShift((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height", "colorDistance"))
		{
			image.MeanShift((int)hashtable["width"], (int)hashtable["height"], (Percentage)hashtable["colorDistance"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'meanShift', allowed combinations are: [size] [size, colorDistance] [width, height] [width, height, colorDistance]");
	}

	private void ExecuteMedianFilter(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<int>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.MedianFilter();
			return;
		}
		if (OnlyContains(hashtable, "radius"))
		{
			image.MedianFilter((int)hashtable["radius"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'medianFilter', allowed combinations are: [] [radius]");
	}

	private static void ExecuteMinify(IMagickImage image)
	{
		image.Minify();
	}

	private void ExecuteModulate(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<Percentage>(attribute);
		}
		if (OnlyContains(hashtable, "brightness"))
		{
			image.Modulate((Percentage)hashtable["brightness"]);
			return;
		}
		if (OnlyContains(hashtable, "brightness", "saturation"))
		{
			image.Modulate((Percentage)hashtable["brightness"], (Percentage)hashtable["saturation"]);
			return;
		}
		if (OnlyContains(hashtable, "brightness", "saturation", "hue"))
		{
			image.Modulate((Percentage)hashtable["brightness"], (Percentage)hashtable["saturation"], (Percentage)hashtable["hue"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'modulate', allowed combinations are: [brightness] [brightness, saturation] [brightness, saturation, hue]");
	}

	private void ExecuteMorphology(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "arguments")
			{
				hashtable["arguments"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "iterations")
			{
				hashtable["iterations"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "kernel")
			{
				hashtable["kernel"] = Variables.GetValue<Kernel>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<MorphologyMethod>(attribute);
			}
			else if (attribute.Name == "userKernel")
			{
				hashtable["userKernel"] = Variables.GetValue<string>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMorphologySettings(item);
		}
		if (OnlyContains(hashtable, "method", "kernel"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "arguments"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (string)hashtable["arguments"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "arguments", "channels"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (string)hashtable["arguments"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "arguments", "channels", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (string)hashtable["arguments"], (Channels)hashtable["channels"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "arguments", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (string)hashtable["arguments"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "channels"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "channels", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (Channels)hashtable["channels"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "kernel", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (Kernel)hashtable["kernel"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "userKernel"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (string)hashtable["userKernel"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "userKernel", "channels"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (string)hashtable["userKernel"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "userKernel", "channels", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (string)hashtable["userKernel"], (Channels)hashtable["channels"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "userKernel", "iterations"))
		{
			image.Morphology((MorphologyMethod)hashtable["method"], (string)hashtable["userKernel"], (int)hashtable["iterations"]);
			return;
		}
		if (OnlyContains(hashtable, "settings"))
		{
			image.Morphology((MorphologySettings)hashtable["settings"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'morphology', allowed combinations are: [method, kernel] [method, kernel, arguments] [method, kernel, arguments, channels] [method, kernel, arguments, channels, iterations] [method, kernel, arguments, iterations] [method, kernel, channels] [method, kernel, channels, iterations] [method, kernel, iterations] [method, userKernel] [method, userKernel, channels] [method, userKernel, channels, iterations] [method, userKernel, iterations] [settings]");
	}

	private void ExecuteMotionBlur(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "radius");
		double value2 = Variables.GetValue<double>(element, "sigma");
		double value3 = Variables.GetValue<double>(element, "angle");
		image.MotionBlur(value, value2, value3);
	}

	private void ExecuteNegate(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "onlyGrayscale")
			{
				hashtable["onlyGrayscale"] = Variables.GetValue<bool>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Negate();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.Negate((Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "onlyGrayscale"))
		{
			image.Negate((bool)hashtable["onlyGrayscale"]);
			return;
		}
		if (OnlyContains(hashtable, "onlyGrayscale", "channels"))
		{
			image.Negate((bool)hashtable["onlyGrayscale"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'negate', allowed combinations are: [] [channels] [onlyGrayscale] [onlyGrayscale, channels]");
	}

	private static void ExecuteNormalize(IMagickImage image)
	{
		image.Normalize();
	}

	private void ExecuteOilPaint(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.OilPaint();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.OilPaint((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'oilPaint', allowed combinations are: [] [radius, sigma]");
	}

	private void ExecuteOpaque(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "target");
		MagickColor value2 = Variables.GetValue<MagickColor>(element, "fill");
		image.Opaque(value, value2);
	}

	private void ExecuteOrderedDither(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "thresholdMap")
			{
				hashtable["thresholdMap"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "thresholdMap"))
		{
			image.OrderedDither((string)hashtable["thresholdMap"]);
			return;
		}
		if (OnlyContains(hashtable, "thresholdMap", "channels"))
		{
			image.OrderedDither((string)hashtable["thresholdMap"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'orderedDither', allowed combinations are: [thresholdMap] [thresholdMap, channels]");
	}

	private void ExecutePerceptible(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "epsilon")
			{
				hashtable["epsilon"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "epsilon"))
		{
			image.Perceptible((double)hashtable["epsilon"]);
			return;
		}
		if (OnlyContains(hashtable, "epsilon", "channels"))
		{
			image.Perceptible((double)hashtable["epsilon"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'perceptible', allowed combinations are: [epsilon] [epsilon, channels]");
	}

	private void ExecutePolaroid(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "caption");
		double value2 = Variables.GetValue<double>(element, "angle");
		PixelInterpolateMethod value3 = Variables.GetValue<PixelInterpolateMethod>(element, "method");
		image.Polaroid(value, value2, value3);
	}

	private void ExecutePosterize(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "levels")
			{
				hashtable["levels"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<DitherMethod>(attribute);
			}
		}
		if (OnlyContains(hashtable, "levels"))
		{
			image.Posterize((int)hashtable["levels"]);
			return;
		}
		if (OnlyContains(hashtable, "levels", "channels"))
		{
			image.Posterize((int)hashtable["levels"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "levels", "method"))
		{
			image.Posterize((int)hashtable["levels"], (DitherMethod)hashtable["method"]);
			return;
		}
		if (OnlyContains(hashtable, "levels", "method", "channels"))
		{
			image.Posterize((int)hashtable["levels"], (DitherMethod)hashtable["method"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'posterize', allowed combinations are: [levels] [levels, channels] [levels, method] [levels, method, channels]");
	}

	private static void ExecutePreserveColorType(IMagickImage image)
	{
		image.PreserveColorType();
	}

	private void ExecuteQuantize(XmlElement element, IMagickImage image)
	{
		QuantizeSettings settings = CreateQuantizeSettings(element["settings"]);
		image.Quantize(settings);
	}

	private void ExecuteRaise(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "size");
		image.Raise(value);
	}

	private void ExecuteRandomThreshold(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "high")
			{
				hashtable["high"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "low")
			{
				hashtable["low"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "percentageHigh")
			{
				hashtable["percentageHigh"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageLow")
			{
				hashtable["percentageLow"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "low", "high"))
		{
			image.RandomThreshold((byte)hashtable["low"], (byte)hashtable["high"]);
			return;
		}
		if (OnlyContains(hashtable, "low", "high", "channels"))
		{
			image.RandomThreshold((byte)hashtable["low"], (byte)hashtable["high"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageLow", "percentageHigh"))
		{
			image.RandomThreshold((Percentage)hashtable["percentageLow"], (Percentage)hashtable["percentageHigh"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageLow", "percentageHigh", "channels"))
		{
			image.RandomThreshold((Percentage)hashtable["percentageLow"], (Percentage)hashtable["percentageHigh"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'randomThreshold', allowed combinations are: [low, high] [low, high, channels] [percentageLow, percentageHigh] [percentageLow, percentageHigh, channels]");
	}

	private void ExecuteReduceNoise(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<int>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.ReduceNoise();
			return;
		}
		if (OnlyContains(hashtable, "order"))
		{
			image.ReduceNoise((int)hashtable["order"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'reduceNoise', allowed combinations are: [] [order]");
	}

	private void ExecuteRegionMask(XmlElement element, IMagickImage image)
	{
		MagickGeometry value = Variables.GetValue<MagickGeometry>(element, "region");
		image.RegionMask(value);
	}

	private void ExecuteRemoveArtifact(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "name");
		image.RemoveArtifact(value);
	}

	private void ExecuteRemoveAttribute(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "name");
		image.RemoveAttribute(value);
	}

	private void ExecuteRemoveProfile(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "name");
		image.RemoveProfile(value);
	}

	private static void ExecuteRemoveRegionMask(IMagickImage image)
	{
		image.RemoveRegionMask();
	}

	private static void ExecuteRePage(IMagickImage image)
	{
		image.RePage();
	}

	private void ExecuteResample(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "density")
			{
				hashtable["density"] = Variables.GetValue<PointD>(attribute);
			}
			else if (attribute.Name == "resolutionX")
			{
				hashtable["resolutionX"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "resolutionY")
			{
				hashtable["resolutionY"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "density"))
		{
			image.Resample((PointD)hashtable["density"]);
			return;
		}
		if (OnlyContains(hashtable, "resolutionX", "resolutionY"))
		{
			image.Resample((double)hashtable["resolutionX"], (double)hashtable["resolutionY"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'resample', allowed combinations are: [density] [resolutionX, resolutionY]");
	}

	private void ExecuteResize(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageHeight")
			{
				hashtable["percentageHeight"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageWidth")
			{
				hashtable["percentageWidth"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Resize((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "percentage"))
		{
			image.Resize((Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageWidth", "percentageHeight"))
		{
			image.Resize((Percentage)hashtable["percentageWidth"], (Percentage)hashtable["percentageHeight"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Resize((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'resize', allowed combinations are: [geometry] [percentage] [percentageWidth, percentageHeight] [width, height]");
	}

	private void ExecuteRoll(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "x");
		int value2 = Variables.GetValue<int>(element, "y");
		image.Roll(value, value2);
	}

	private void ExecuteRotate(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "degrees");
		image.Rotate(value);
	}

	private void ExecuteRotationalBlur(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "angle")
			{
				hashtable["angle"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
		}
		if (OnlyContains(hashtable, "angle"))
		{
			image.RotationalBlur((double)hashtable["angle"]);
			return;
		}
		if (OnlyContains(hashtable, "angle", "channels"))
		{
			image.RotationalBlur((double)hashtable["angle"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'rotationalBlur', allowed combinations are: [angle] [angle, channels]");
	}

	private void ExecuteSample(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageHeight")
			{
				hashtable["percentageHeight"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageWidth")
			{
				hashtable["percentageWidth"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Sample((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "percentage"))
		{
			image.Sample((Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageWidth", "percentageHeight"))
		{
			image.Sample((Percentage)hashtable["percentageWidth"], (Percentage)hashtable["percentageHeight"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Sample((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sample', allowed combinations are: [geometry] [percentage] [percentageWidth, percentageHeight] [width, height]");
	}

	private void ExecuteScale(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageHeight")
			{
				hashtable["percentageHeight"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageWidth")
			{
				hashtable["percentageWidth"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Scale((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "percentage"))
		{
			image.Scale((Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageWidth", "percentageHeight"))
		{
			image.Scale((Percentage)hashtable["percentageWidth"], (Percentage)hashtable["percentageHeight"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Scale((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'scale', allowed combinations are: [geometry] [percentage] [percentageWidth, percentageHeight] [width, height]");
	}

	private void ExecuteSegment(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "clusterThreshold")
			{
				hashtable["clusterThreshold"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "quantizeColorSpace")
			{
				hashtable["quantizeColorSpace"] = Variables.GetValue<ColorSpace>(attribute);
			}
			else if (attribute.Name == "smoothingThreshold")
			{
				hashtable["smoothingThreshold"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Segment();
			return;
		}
		if (OnlyContains(hashtable, "quantizeColorSpace", "clusterThreshold", "smoothingThreshold"))
		{
			image.Segment((ColorSpace)hashtable["quantizeColorSpace"], (double)hashtable["clusterThreshold"], (double)hashtable["smoothingThreshold"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'segment', allowed combinations are: [] [quantizeColorSpace, clusterThreshold, smoothingThreshold]");
	}

	private void ExecuteSelectiveBlur(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "threshold")
			{
				hashtable["threshold"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "thresholdPercentage")
			{
				hashtable["thresholdPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "radius", "sigma", "threshold"))
		{
			image.SelectiveBlur((double)hashtable["radius"], (double)hashtable["sigma"], (double)hashtable["threshold"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "threshold", "channels"))
		{
			image.SelectiveBlur((double)hashtable["radius"], (double)hashtable["sigma"], (double)hashtable["threshold"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "thresholdPercentage"))
		{
			image.SelectiveBlur((double)hashtable["radius"], (double)hashtable["sigma"], (Percentage)hashtable["thresholdPercentage"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "thresholdPercentage", "channels"))
		{
			image.SelectiveBlur((double)hashtable["radius"], (double)hashtable["sigma"], (Percentage)hashtable["thresholdPercentage"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'selectiveBlur', allowed combinations are: [radius, sigma, threshold] [radius, sigma, threshold, channels] [radius, sigma, thresholdPercentage] [radius, sigma, thresholdPercentage, channels]");
	}

	private void ExecuteSepiaTone(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<Percentage>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.SepiaTone();
			return;
		}
		if (OnlyContains(hashtable, "threshold"))
		{
			image.SepiaTone((Percentage)hashtable["threshold"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sepiaTone', allowed combinations are: [] [threshold]");
	}

	private void ExecuteSetArtifact(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "name");
		string value2 = Variables.GetValue<string>(element, "value");
		image.SetArtifact(value, value2);
	}

	private void ExecuteSetAttenuate(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "attenuate");
		image.SetAttenuate(value);
	}

	private void ExecuteSetAttribute(XmlElement element, IMagickImage image)
	{
		string value = Variables.GetValue<string>(element, "name");
		string value2 = Variables.GetValue<string>(element, "value");
		image.SetAttribute(value, value2);
	}

	private void ExecuteSetClippingPath(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<string>(attribute);
		}
		if (OnlyContains(hashtable, "value"))
		{
			image.SetClippingPath((string)hashtable["value"]);
			return;
		}
		if (OnlyContains(hashtable, "value", "pathName"))
		{
			image.SetClippingPath((string)hashtable["value"], (string)hashtable["pathName"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'setClippingPath', allowed combinations are: [value] [value, pathName]");
	}

	private void ExecuteSetColormap(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "index");
		MagickColor value2 = Variables.GetValue<MagickColor>(element, "color");
		image.SetColormap(value, value2);
	}

	private void ExecuteSetHighlightColor(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		image.SetHighlightColor(value);
	}

	private void ExecuteSetLowlightColor(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		image.SetLowlightColor(value);
	}

	private void ExecuteShade(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "azimuth")
			{
				hashtable["azimuth"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "colorShading")
			{
				hashtable["colorShading"] = Variables.GetValue<bool>(attribute);
			}
			else if (attribute.Name == "elevation")
			{
				hashtable["elevation"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Shade();
			return;
		}
		if (OnlyContains(hashtable, "azimuth", "elevation"))
		{
			image.Shade((double)hashtable["azimuth"], (double)hashtable["elevation"]);
			return;
		}
		if (OnlyContains(hashtable, "azimuth", "elevation", "colorShading"))
		{
			image.Shade((double)hashtable["azimuth"], (double)hashtable["elevation"], (bool)hashtable["colorShading"]);
			return;
		}
		if (OnlyContains(hashtable, "azimuth", "elevation", "colorShading", "channels"))
		{
			image.Shade((double)hashtable["azimuth"], (double)hashtable["elevation"], (bool)hashtable["colorShading"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'shade', allowed combinations are: [] [azimuth, elevation] [azimuth, elevation, colorShading] [azimuth, elevation, colorShading, channels]");
	}

	private void ExecuteShadow(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "alpha")
			{
				hashtable["alpha"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "color")
			{
				hashtable["color"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Shadow();
			return;
		}
		if (OnlyContains(hashtable, "color"))
		{
			image.Shadow((MagickColor)hashtable["color"]);
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "sigma", "alpha"))
		{
			image.Shadow((int)hashtable["x"], (int)hashtable["y"], (double)hashtable["sigma"], (Percentage)hashtable["alpha"]);
			return;
		}
		if (OnlyContains(hashtable, "x", "y", "sigma", "alpha", "color"))
		{
			image.Shadow((int)hashtable["x"], (int)hashtable["y"], (double)hashtable["sigma"], (Percentage)hashtable["alpha"], (MagickColor)hashtable["color"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'shadow', allowed combinations are: [] [color] [x, y, sigma, alpha] [x, y, sigma, alpha, color]");
	}

	private void ExecuteSharpen(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Sharpen();
			return;
		}
		if (OnlyContains(hashtable, "channels"))
		{
			image.Sharpen((Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.Sharpen((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "channels"))
		{
			image.Sharpen((double)hashtable["radius"], (double)hashtable["sigma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sharpen', allowed combinations are: [] [channels] [radius, sigma] [radius, sigma, channels]");
	}

	private void ExecuteShave(XmlElement element, IMagickImage image)
	{
		int value = Variables.GetValue<int>(element, "leftRight");
		int value2 = Variables.GetValue<int>(element, "topBottom");
		image.Shave(value, value2);
	}

	private void ExecuteShear(XmlElement element, IMagickImage image)
	{
		double value = Variables.GetValue<double>(element, "xAngle");
		double value2 = Variables.GetValue<double>(element, "yAngle");
		image.Shear(value, value2);
	}

	private void ExecuteSigmoidalContrast(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "contrast")
			{
				hashtable["contrast"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "midpoint")
			{
				hashtable["midpoint"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "midpointPercentage")
			{
				hashtable["midpointPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "sharpen")
			{
				hashtable["sharpen"] = Variables.GetValue<bool>(attribute);
			}
		}
		if (OnlyContains(hashtable, "contrast"))
		{
			image.SigmoidalContrast((double)hashtable["contrast"]);
			return;
		}
		if (OnlyContains(hashtable, "contrast", "midpoint"))
		{
			image.SigmoidalContrast((double)hashtable["contrast"], (double)hashtable["midpoint"]);
			return;
		}
		if (OnlyContains(hashtable, "contrast", "midpointPercentage"))
		{
			image.SigmoidalContrast((double)hashtable["contrast"], (Percentage)hashtable["midpointPercentage"]);
			return;
		}
		if (OnlyContains(hashtable, "sharpen", "contrast"))
		{
			image.SigmoidalContrast((bool)hashtable["sharpen"], (double)hashtable["contrast"]);
			return;
		}
		if (OnlyContains(hashtable, "sharpen", "contrast", "midpoint"))
		{
			image.SigmoidalContrast((bool)hashtable["sharpen"], (double)hashtable["contrast"], (double)hashtable["midpoint"]);
			return;
		}
		if (OnlyContains(hashtable, "sharpen", "contrast", "midpointPercentage"))
		{
			image.SigmoidalContrast((bool)hashtable["sharpen"], (double)hashtable["contrast"], (Percentage)hashtable["midpointPercentage"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sigmoidalContrast', allowed combinations are: [contrast] [contrast, midpoint] [contrast, midpointPercentage] [sharpen, contrast] [sharpen, contrast, midpoint] [sharpen, contrast, midpointPercentage]");
	}

	private void ExecuteSketch(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<double>(attribute);
		}
		if (hashtable.Count == 0)
		{
			image.Sketch();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "angle"))
		{
			image.Sketch((double)hashtable["radius"], (double)hashtable["sigma"], (double)hashtable["angle"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sketch', allowed combinations are: [] [radius, sigma, angle]");
	}

	private void ExecuteSolarize(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "factor")
			{
				hashtable["factor"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "factorPercentage")
			{
				hashtable["factorPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Solarize();
			return;
		}
		if (OnlyContains(hashtable, "factor"))
		{
			image.Solarize((double)hashtable["factor"]);
			return;
		}
		if (OnlyContains(hashtable, "factorPercentage"))
		{
			image.Solarize((Percentage)hashtable["factorPercentage"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'solarize', allowed combinations are: [] [factor] [factorPercentage]");
	}

	private void ExecuteSparseColor(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<SparseColorMethod>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateSparseColorArgs(item);
		}
		if (OnlyContains(hashtable, "channels", "method", "args"))
		{
			image.SparseColor((Channels)hashtable["channels"], (SparseColorMethod)hashtable["method"], (IEnumerable<SparseColorArg>)hashtable["args"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "args"))
		{
			image.SparseColor((SparseColorMethod)hashtable["method"], (IEnumerable<SparseColorArg>)hashtable["args"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'sparseColor', allowed combinations are: [channels, method, args] [method, args]");
	}

	private void ExecuteSplice(XmlElement element, IMagickImage image)
	{
		MagickGeometry value = Variables.GetValue<MagickGeometry>(element, "geometry");
		image.Splice(value);
	}

	private void ExecuteSpread(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<PixelInterpolateMethod>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Spread();
			return;
		}
		if (OnlyContains(hashtable, "method", "radius"))
		{
			image.Spread((PixelInterpolateMethod)hashtable["method"], (double)hashtable["radius"]);
			return;
		}
		if (OnlyContains(hashtable, "radius"))
		{
			image.Spread((double)hashtable["radius"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'spread', allowed combinations are: [] [method, radius] [radius]");
	}

	private void ExecuteStatistic(XmlElement element, IMagickImage image)
	{
		StatisticType value = Variables.GetValue<StatisticType>(element, "type");
		int value2 = Variables.GetValue<int>(element, "width");
		int value3 = Variables.GetValue<int>(element, "height");
		image.Statistic(value, value2, value3);
	}

	private void ExecuteStegano(XmlElement element, IMagickImage image)
	{
		IMagickImage watermark = CreateMagickImage(element["watermark"]);
		image.Stegano(watermark);
	}

	private void ExecuteStereo(XmlElement element, IMagickImage image)
	{
		IMagickImage rightImage = CreateMagickImage(element["rightImage"]);
		image.Stereo(rightImage);
	}

	private static void ExecuteStrip(IMagickImage image)
	{
		image.Strip();
	}

	private void ExecuteSwirl(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "degrees")
			{
				hashtable["degrees"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<PixelInterpolateMethod>(attribute);
			}
		}
		if (OnlyContains(hashtable, "degrees"))
		{
			image.Swirl((double)hashtable["degrees"]);
			return;
		}
		if (OnlyContains(hashtable, "method", "degrees"))
		{
			image.Swirl((PixelInterpolateMethod)hashtable["method"], (double)hashtable["degrees"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'swirl', allowed combinations are: [degrees] [method, degrees]");
	}

	private void ExecuteTexture(XmlElement element, IMagickImage image)
	{
		IMagickImage image2 = CreateMagickImage(element["image"]);
		image.Texture(image2);
	}

	private void ExecuteThreshold(XmlElement element, IMagickImage image)
	{
		Percentage value = Variables.GetValue<Percentage>(element, "percentage");
		image.Threshold(value);
	}

	private void ExecuteThumbnail(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "geometry")
			{
				hashtable["geometry"] = Variables.GetValue<MagickGeometry>(attribute);
			}
			else if (attribute.Name == "height")
			{
				hashtable["height"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "percentage")
			{
				hashtable["percentage"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageHeight")
			{
				hashtable["percentageHeight"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "percentageWidth")
			{
				hashtable["percentageWidth"] = Variables.GetValue<Percentage>(attribute);
			}
			else if (attribute.Name == "width")
			{
				hashtable["width"] = Variables.GetValue<int>(attribute);
			}
		}
		if (OnlyContains(hashtable, "geometry"))
		{
			image.Thumbnail((MagickGeometry)hashtable["geometry"]);
			return;
		}
		if (OnlyContains(hashtable, "percentage"))
		{
			image.Thumbnail((Percentage)hashtable["percentage"]);
			return;
		}
		if (OnlyContains(hashtable, "percentageWidth", "percentageHeight"))
		{
			image.Thumbnail((Percentage)hashtable["percentageWidth"], (Percentage)hashtable["percentageHeight"]);
			return;
		}
		if (OnlyContains(hashtable, "width", "height"))
		{
			image.Thumbnail((int)hashtable["width"], (int)hashtable["height"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'thumbnail', allowed combinations are: [geometry] [percentage] [percentageWidth, percentageHeight] [width, height]");
	}

	private void ExecuteTile(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "args")
			{
				hashtable["args"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "compose")
			{
				hashtable["compose"] = Variables.GetValue<CompositeOperator>(attribute);
			}
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateMagickImage(item);
		}
		if (OnlyContains(hashtable, "image", "compose"))
		{
			image.Tile((IMagickImage)hashtable["image"], (CompositeOperator)hashtable["compose"]);
			return;
		}
		if (OnlyContains(hashtable, "image", "compose", "args"))
		{
			image.Tile((IMagickImage)hashtable["image"], (CompositeOperator)hashtable["compose"], (string)hashtable["args"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'tile', allowed combinations are: [image, compose] [image, compose, args]");
	}

	private void ExecuteTint(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "color")
			{
				hashtable["color"] = Variables.GetValue<MagickColor>(attribute);
			}
			else if (attribute.Name == "opacity")
			{
				hashtable["opacity"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "opacity"))
		{
			image.Tint((string)hashtable["opacity"]);
			return;
		}
		if (OnlyContains(hashtable, "opacity", "color"))
		{
			image.Tint((string)hashtable["opacity"], (MagickColor)hashtable["color"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'tint', allowed combinations are: [opacity] [opacity, color]");
	}

	private static void ExecuteTransformColorSpace(XmlElement element, IMagickImage image)
	{
		ColorProfile source = CreateColorProfile(element["source"]);
		ColorProfile target = CreateColorProfile(element["target"]);
		image.TransformColorSpace(source, target);
	}

	private void ExecuteTransparent(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "color");
		image.Transparent(value);
	}

	private void ExecuteTransparentChroma(XmlElement element, IMagickImage image)
	{
		MagickColor value = Variables.GetValue<MagickColor>(element, "colorLow");
		MagickColor value2 = Variables.GetValue<MagickColor>(element, "colorHigh");
		image.TransparentChroma(value, value2);
	}

	private static void ExecuteTranspose(IMagickImage image)
	{
		image.Transpose();
	}

	private static void ExecuteTransverse(IMagickImage image)
	{
		image.Transverse();
	}

	private static void ExecuteTrim(IMagickImage image)
	{
		image.Trim();
	}

	private void ExecuteUnsharpMask(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "amount")
			{
				hashtable["amount"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "threshold")
			{
				hashtable["threshold"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "radius", "sigma"))
		{
			image.UnsharpMask((double)hashtable["radius"], (double)hashtable["sigma"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "amount", "threshold"))
		{
			image.UnsharpMask((double)hashtable["radius"], (double)hashtable["sigma"], (double)hashtable["amount"], (double)hashtable["threshold"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "amount", "threshold", "channels"))
		{
			image.UnsharpMask((double)hashtable["radius"], (double)hashtable["sigma"], (double)hashtable["amount"], (double)hashtable["threshold"], (Channels)hashtable["channels"]);
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "channels"))
		{
			image.UnsharpMask((double)hashtable["radius"], (double)hashtable["sigma"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'unsharpMask', allowed combinations are: [radius, sigma] [radius, sigma, amount, threshold] [radius, sigma, amount, threshold, channels] [radius, sigma, channels]");
	}

	private void ExecuteVignette(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "radius")
			{
				hashtable["radius"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "sigma")
			{
				hashtable["sigma"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<int>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<int>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Vignette();
			return;
		}
		if (OnlyContains(hashtable, "radius", "sigma", "x", "y"))
		{
			image.Vignette((double)hashtable["radius"], (double)hashtable["sigma"], (int)hashtable["x"], (int)hashtable["y"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'vignette', allowed combinations are: [] [radius, sigma, x, y]");
	}

	private void ExecuteWave(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "amplitude")
			{
				hashtable["amplitude"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "length")
			{
				hashtable["length"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "method")
			{
				hashtable["method"] = Variables.GetValue<PixelInterpolateMethod>(attribute);
			}
		}
		if (hashtable.Count == 0)
		{
			image.Wave();
			return;
		}
		if (OnlyContains(hashtable, "method", "amplitude", "length"))
		{
			image.Wave((PixelInterpolateMethod)hashtable["method"], (double)hashtable["amplitude"], (double)hashtable["length"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'wave', allowed combinations are: [] [method, amplitude, length]");
	}

	private void ExecuteWaveletDenoise(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "softness")
			{
				hashtable["softness"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "threshold")
			{
				hashtable["threshold"] = Variables.GetValue<byte>(attribute);
			}
			else if (attribute.Name == "thresholdPercentage")
			{
				hashtable["thresholdPercentage"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "threshold"))
		{
			image.WaveletDenoise((byte)hashtable["threshold"]);
			return;
		}
		if (OnlyContains(hashtable, "threshold", "softness"))
		{
			image.WaveletDenoise((byte)hashtable["threshold"], (double)hashtable["softness"]);
			return;
		}
		if (OnlyContains(hashtable, "thresholdPercentage"))
		{
			image.WaveletDenoise((Percentage)hashtable["thresholdPercentage"]);
			return;
		}
		if (OnlyContains(hashtable, "thresholdPercentage", "softness"))
		{
			image.WaveletDenoise((Percentage)hashtable["thresholdPercentage"], (double)hashtable["softness"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'waveletDenoise', allowed combinations are: [threshold] [threshold, softness] [thresholdPercentage] [thresholdPercentage, softness]");
	}

	private void ExecuteWhiteThreshold(XmlElement element, IMagickImage image)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "channels")
			{
				hashtable["channels"] = Variables.GetValue<Channels>(attribute);
			}
			else if (attribute.Name == "threshold")
			{
				hashtable["threshold"] = Variables.GetValue<Percentage>(attribute);
			}
		}
		if (OnlyContains(hashtable, "threshold"))
		{
			image.WhiteThreshold((Percentage)hashtable["threshold"]);
			return;
		}
		if (OnlyContains(hashtable, "threshold", "channels"))
		{
			image.WhiteThreshold((Percentage)hashtable["threshold"], (Channels)hashtable["channels"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'whiteThreshold', allowed combinations are: [threshold] [threshold, channels]");
	}

	private IMagickImage ExecuteCollection(XmlElement element, IMagickImageCollection collection)
	{
		switch (element.Name[0])
		{
		case 'c':
			switch (element.Name[2])
			{
			case 'a':
				return ExecuteCoalesce(collection);
			case 'm':
				return ExecuteCombine(element, collection);
			}
			break;
		case 'd':
			return ExecuteDeconstruct(collection);
		case 'm':
			switch (element.Name[1])
			{
			case 'a':
				return ExecuteMap(element, collection);
			case 'o':
				switch (element.Name[2])
				{
				case 'r':
					return ExecuteMorph(element, collection);
				case 'n':
					return ExecuteMontage(element, collection);
				case 's':
					return ExecuteMosaic(collection);
				}
				break;
			case 'e':
				return ExecuteMerge(collection);
			}
			break;
		case 'o':
			if (element.Name.Length == 8)
			{
				return ExecuteOptimize(collection);
			}
			switch (element.Name[8])
			{
			case 'P':
				return ExecuteOptimizePlus(collection);
			case 'T':
				return ExecuteOptimizeTransparency(collection);
			}
			break;
		case 'q':
			return ExecuteQuantize(element, collection);
		case 'r':
			switch (element.Name[2])
			{
			case 'P':
				return ExecuteRePage(collection);
			case 'v':
				return ExecuteReverse(collection);
			}
			break;
		case 't':
			return ExecuteTrimBounds(collection);
		case 'a':
			switch (element.Name[6])
			{
			case 'H':
				return ExecuteAppendHorizontally(collection);
			case 'V':
				return ExecuteAppendVertically(collection);
			}
			break;
		case 'e':
			return ExecuteEvaluate(element, collection);
		case 'f':
			return ExecuteFlatten(collection);
		case 's':
			switch (element.Name[5])
			{
			case 'H':
				return ExecuteSmushHorizontal(element, collection);
			case 'V':
				return ExecuteSmushVertical(element, collection);
			}
			break;
		}
		throw new NotSupportedException(element.Name);
	}

	private static IMagickImage ExecuteCoalesce(IMagickImageCollection collection)
	{
		collection.Coalesce();
		return null;
	}

	private static IMagickImage ExecuteDeconstruct(IMagickImageCollection collection)
	{
		collection.Deconstruct();
		return null;
	}

	private IMagickImage ExecuteMap(XmlElement element, IMagickImageCollection collection)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			if (item.Name == "image")
			{
				hashtable["image"] = CreateMagickImage(item);
			}
			else if (item.Name == "settings")
			{
				hashtable["settings"] = CreateQuantizeSettings(item);
			}
		}
		if (OnlyContains(hashtable, "image"))
		{
			collection.Map((IMagickImage)hashtable["image"]);
			return null;
		}
		if (OnlyContains(hashtable, "image", "settings"))
		{
			collection.Map((IMagickImage)hashtable["image"], (QuantizeSettings)hashtable["settings"]);
			return null;
		}
		throw new ArgumentException("Invalid argument combination for 'map', allowed combinations are: [image] [image, settings]");
	}

	private IMagickImage ExecuteMorph(XmlElement element, IMagickImageCollection collection)
	{
		int value = Variables.GetValue<int>(element, "frames");
		collection.Morph(value);
		return null;
	}

	private static IMagickImage ExecuteOptimize(IMagickImageCollection collection)
	{
		collection.Optimize();
		return null;
	}

	private static IMagickImage ExecuteOptimizePlus(IMagickImageCollection collection)
	{
		collection.OptimizePlus();
		return null;
	}

	private static IMagickImage ExecuteOptimizeTransparency(IMagickImageCollection collection)
	{
		collection.OptimizeTransparency();
		return null;
	}

	private IMagickImage ExecuteQuantize(XmlElement element, IMagickImageCollection collection)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			hashtable[item.Name] = CreateQuantizeSettings(item);
		}
		if (hashtable.Count == 0)
		{
			collection.Quantize();
			return null;
		}
		if (OnlyContains(hashtable, "settings"))
		{
			collection.Quantize((QuantizeSettings)hashtable["settings"]);
			return null;
		}
		throw new ArgumentException("Invalid argument combination for 'quantize', allowed combinations are: [] [settings]");
	}

	private static IMagickImage ExecuteRePage(IMagickImageCollection collection)
	{
		collection.RePage();
		return null;
	}

	private static IMagickImage ExecuteReverse(IMagickImageCollection collection)
	{
		collection.Reverse();
		return null;
	}

	private static IMagickImage ExecuteTrimBounds(IMagickImageCollection collection)
	{
		collection.TrimBounds();
		return null;
	}

	private static IMagickImage ExecuteAppendHorizontally(IMagickImageCollection collection)
	{
		return collection.AppendHorizontally();
	}

	private static IMagickImage ExecuteAppendVertically(IMagickImageCollection collection)
	{
		return collection.AppendVertically();
	}

	private IMagickImage ExecuteCombine(XmlElement element, IMagickImageCollection collection)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			hashtable[attribute.Name] = Variables.GetValue<ColorSpace>(attribute);
		}
		if (hashtable.Count == 0)
		{
			return collection.Combine();
		}
		if (OnlyContains(hashtable, "colorSpace"))
		{
			return collection.Combine((ColorSpace)hashtable["colorSpace"]);
		}
		throw new ArgumentException("Invalid argument combination for 'combine', allowed combinations are: [] [colorSpace]");
	}

	private IMagickImage ExecuteEvaluate(XmlElement element, IMagickImageCollection collection)
	{
		EvaluateOperator value = Variables.GetValue<EvaluateOperator>(element, "evaluateOperator");
		return collection.Evaluate(value);
	}

	private static IMagickImage ExecuteFlatten(IMagickImageCollection collection)
	{
		return collection.Flatten();
	}

	private static IMagickImage ExecuteMerge(IMagickImageCollection collection)
	{
		return collection.Merge();
	}

	private IMagickImage ExecuteMontage(XmlElement element, IMagickImageCollection collection)
	{
		MontageSettings settings = CreateMontageSettings(element["settings"]);
		return collection.Montage(settings);
	}

	private static IMagickImage ExecuteMosaic(IMagickImageCollection collection)
	{
		return collection.Mosaic();
	}

	private IMagickImage ExecuteSmushHorizontal(XmlElement element, IMagickImageCollection collection)
	{
		int value = Variables.GetValue<int>(element, "offset");
		return collection.SmushHorizontal(value);
	}

	private IMagickImage ExecuteSmushVertical(XmlElement element, IMagickImageCollection collection)
	{
		int value = Variables.GetValue<int>(element, "offset");
		return collection.SmushVertical(value);
	}

	private void ExecuteMagickReadSettings(XmlElement element, MagickReadSettings readSettings)
	{
		switch (element.Name[0])
		{
		case 'b':
			switch (element.Name[1])
			{
			case 'a':
				ExecuteBackgroundColor(element, readSettings);
				return;
			case 'o':
				ExecuteBorderColor(element, readSettings);
				return;
			}
			break;
		case 'c':
			switch (element.Name[2])
			{
			case 'l':
				switch (element.Name[5])
				{
				case 'S':
					ExecuteColorSpace(element, readSettings);
					return;
				case 'T':
					ExecuteColorType(element, readSettings);
					return;
				}
				break;
			case 'm':
				ExecuteCompressionMethod(element, readSettings);
				return;
			}
			break;
		case 'd':
			switch (element.Name[2])
			{
			case 'b':
				ExecuteDebug(element, readSettings);
				return;
			case 'f':
				ExecuteDefines(element, readSettings);
				return;
			case 'n':
				ExecuteDensity(element, readSettings);
				return;
			}
			break;
		case 'e':
			switch (element.Name[1])
			{
			case 'n':
				ExecuteEndian(element, readSettings);
				return;
			case 'x':
				ExecuteExtractArea(element, readSettings);
				return;
			}
			break;
		case 'f':
			switch (element.Name[1])
			{
			case 'i':
				switch (element.Name[4])
				{
				case 'C':
					ExecuteFillColor(element, readSettings);
					return;
				case 'P':
					ExecuteFillPattern(element, readSettings);
					return;
				case 'R':
					ExecuteFillRule(element, readSettings);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'n':
					if (element.Name.Length == 4)
					{
						ExecuteFont(element, readSettings);
						return;
					}
					switch (element.Name[4])
					{
					case 'F':
						ExecuteFontFamily(element, readSettings);
						return;
					case 'P':
						ExecuteFontPointsize(element, readSettings);
						return;
					case 'S':
						ExecuteFontStyle(element, readSettings);
						return;
					case 'W':
						ExecuteFontWeight(element, readSettings);
						return;
					}
					break;
				case 'r':
					ExecuteFormat(element, readSettings);
					return;
				}
				break;
			case 'r':
				switch (element.Name[5])
				{
				case 'C':
					ExecuteFrameCount(element, readSettings);
					return;
				case 'I':
					ExecuteFrameIndex(element, readSettings);
					return;
				}
				break;
			}
			break;
		case 'h':
			ExecuteHeight(element, readSettings);
			return;
		case 'p':
			switch (element.Name[1])
			{
			case 'a':
				ExecutePage(element, readSettings);
				return;
			case 'i':
				ExecutePixelStorage(element, readSettings);
				return;
			}
			break;
		case 's':
			switch (element.Name[1])
			{
			case 't':
				switch (element.Name[6])
				{
				case 'A':
					ExecuteStrokeAntiAlias(element, readSettings);
					return;
				case 'C':
					ExecuteStrokeColor(element, readSettings);
					return;
				case 'D':
					switch (element.Name[10])
					{
					case 'A':
						ExecuteStrokeDashArray(element, readSettings);
						return;
					case 'O':
						ExecuteStrokeDashOffset(element, readSettings);
						return;
					}
					break;
				case 'L':
					switch (element.Name[10])
					{
					case 'C':
						ExecuteStrokeLineCap(element, readSettings);
						return;
					case 'J':
						ExecuteStrokeLineJoin(element, readSettings);
						return;
					}
					break;
				case 'M':
					ExecuteStrokeMiterLimit(element, readSettings);
					return;
				case 'P':
					ExecuteStrokePattern(element, readSettings);
					return;
				case 'W':
					ExecuteStrokeWidth(element, readSettings);
					return;
				}
				break;
			case 'e':
				if (element.Name.Length == 9)
				{
					ExecuteSetDefine(element, readSettings);
					return;
				}
				if (element.Name.Length == 10)
				{
					ExecuteSetDefines(element, readSettings);
					return;
				}
				break;
			}
			break;
		case 't':
			switch (element.Name[4])
			{
			case 'A':
				ExecuteTextAntiAlias(element, readSettings);
				return;
			case 'D':
				ExecuteTextDirection(element, readSettings);
				return;
			case 'E':
				ExecuteTextEncoding(element, readSettings);
				return;
			case 'G':
				ExecuteTextGravity(element, readSettings);
				return;
			case 'I':
				switch (element.Name[9])
				{
				case 'l':
					ExecuteTextInterlineSpacing(element, readSettings);
					return;
				case 'w':
					ExecuteTextInterwordSpacing(element, readSettings);
					return;
				}
				break;
			case 'K':
				ExecuteTextKerning(element, readSettings);
				return;
			case 'U':
				ExecuteTextUnderColor(element, readSettings);
				return;
			}
			break;
		case 'u':
			ExecuteUseMonochrome(element, readSettings);
			return;
		case 'v':
			ExecuteVerbose(element, readSettings);
			return;
		case 'w':
			ExecuteWidth(element, readSettings);
			return;
		case 'r':
			ExecuteRemoveDefine(element, readSettings);
			return;
		}
		throw new NotSupportedException(element.Name);
	}

	private void ExecuteBackgroundColor(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.BackgroundColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteBorderColor(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.BorderColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteColorSpace(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.ColorSpace = Variables.GetValue<ColorSpace>(element, "value");
	}

	private void ExecuteColorType(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.ColorType = Variables.GetValue<ColorType>(element, "value");
	}

	private void ExecuteCompressionMethod(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.CompressionMethod = Variables.GetValue<CompressionMethod>(element, "value");
	}

	private void ExecuteDebug(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Debug = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteDefines(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Defines = CreateIReadDefines(element);
	}

	private void ExecuteDensity(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Density = Variables.GetValue<Density>(element, "value");
	}

	private void ExecuteEndian(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Endian = Variables.GetValue<Endian>(element, "value");
	}

	private void ExecuteExtractArea(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.ExtractArea = Variables.GetValue<MagickGeometry>(element, "value");
	}

	private void ExecuteFillColor(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FillColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteFillPattern(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FillPattern = CreateMagickImage(element);
	}

	private void ExecuteFillRule(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FillRule = Variables.GetValue<FillRule>(element, "value");
	}

	private void ExecuteFont(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Font = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteFontFamily(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FontFamily = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteFontPointsize(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FontPointsize = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteFontStyle(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FontStyle = Variables.GetValue<FontStyleType>(element, "value");
	}

	private void ExecuteFontWeight(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FontWeight = Variables.GetValue<FontWeight>(element, "value");
	}

	private void ExecuteFormat(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Format = Variables.GetValue<MagickFormat>(element, "value");
	}

	private void ExecuteFrameCount(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FrameCount = Variables.GetValue<int?>(element, "value");
	}

	private void ExecuteFrameIndex(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.FrameIndex = Variables.GetValue<int?>(element, "value");
	}

	private void ExecuteHeight(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Height = Variables.GetValue<int?>(element, "value");
	}

	private void ExecutePage(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Page = Variables.GetValue<MagickGeometry>(element, "value");
	}

	private void ExecutePixelStorage(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.PixelStorage = CreatePixelStorageSettings(element[""]);
	}

	private void ExecuteStrokeAntiAlias(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeAntiAlias = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteStrokeColor(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteStrokeDashArray(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeDashArray = Variables.GetDoubleArray(element);
	}

	private void ExecuteStrokeDashOffset(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeDashOffset = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteStrokeLineCap(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeLineCap = Variables.GetValue<LineCap>(element, "value");
	}

	private void ExecuteStrokeLineJoin(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeLineJoin = Variables.GetValue<LineJoin>(element, "value");
	}

	private void ExecuteStrokeMiterLimit(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeMiterLimit = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteStrokePattern(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokePattern = CreateMagickImage(element);
	}

	private void ExecuteStrokeWidth(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.StrokeWidth = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextAntiAlias(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextAntiAlias = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteTextDirection(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextDirection = Variables.GetValue<TextDirection>(element, "value");
	}

	private void ExecuteTextEncoding(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextEncoding = Variables.GetValue<Encoding>(element, "value");
	}

	private void ExecuteTextGravity(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextGravity = Variables.GetValue<Gravity>(element, "value");
	}

	private void ExecuteTextInterlineSpacing(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextInterlineSpacing = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextInterwordSpacing(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextInterwordSpacing = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextKerning(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextKerning = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextUnderColor(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.TextUnderColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteUseMonochrome(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.UseMonochrome = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteVerbose(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Verbose = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteWidth(XmlElement element, MagickReadSettings readSettings)
	{
		readSettings.Width = Variables.GetValue<int?>(element, "value");
	}

	private void ExecuteRemoveDefine(XmlElement element, MagickReadSettings readSettings)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "format")
			{
				hashtable["format"] = Variables.GetValue<MagickFormat>(attribute);
			}
			else if (attribute.Name == "name")
			{
				hashtable["name"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "format", "name"))
		{
			readSettings.RemoveDefine((MagickFormat)hashtable["format"], (string)hashtable["name"]);
			return;
		}
		if (OnlyContains(hashtable, "name"))
		{
			readSettings.RemoveDefine((string)hashtable["name"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'removeDefine', allowed combinations are: [format, name] [name]");
	}

	private void ExecuteSetDefine(XmlElement element, MagickReadSettings readSettings)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "flag")
			{
				hashtable["flag"] = Variables.GetValue<bool>(attribute);
			}
			else if (attribute.Name == "format")
			{
				hashtable["format"] = Variables.GetValue<MagickFormat>(attribute);
			}
			else if (attribute.Name == "name")
			{
				hashtable["name"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "value")
			{
				hashtable["value"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "format", "name", "flag"))
		{
			readSettings.SetDefine((MagickFormat)hashtable["format"], (string)hashtable["name"], (bool)hashtable["flag"]);
			return;
		}
		if (OnlyContains(hashtable, "format", "name", "value"))
		{
			readSettings.SetDefine((MagickFormat)hashtable["format"], (string)hashtable["name"], (string)hashtable["value"]);
			return;
		}
		if (OnlyContains(hashtable, "name", "value"))
		{
			readSettings.SetDefine((string)hashtable["name"], (string)hashtable["value"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'setDefine', allowed combinations are: [format, name, flag] [format, name, value] [name, value]");
	}

	private void ExecuteSetDefines(XmlElement element, MagickReadSettings readSettings)
	{
		IDefines defines = CreateIDefines(element["defines"]);
		readSettings.SetDefines(defines);
	}

	private void ExecuteMagickSettings(XmlElement element, MagickSettings settings)
	{
		switch (element.Name[0])
		{
		case 'b':
			switch (element.Name[1])
			{
			case 'a':
				ExecuteBackgroundColor(element, settings);
				return;
			case 'o':
				ExecuteBorderColor(element, settings);
				return;
			}
			break;
		case 'c':
			switch (element.Name[2])
			{
			case 'l':
				switch (element.Name[5])
				{
				case 'S':
					ExecuteColorSpace(element, settings);
					return;
				case 'T':
					ExecuteColorType(element, settings);
					return;
				}
				break;
			case 'm':
				ExecuteCompressionMethod(element, settings);
				return;
			}
			break;
		case 'd':
			switch (element.Name[2])
			{
			case 'b':
				ExecuteDebug(element, settings);
				return;
			case 'n':
				ExecuteDensity(element, settings);
				return;
			}
			break;
		case 'e':
			ExecuteEndian(element, settings);
			return;
		case 'f':
			switch (element.Name[1])
			{
			case 'i':
				switch (element.Name[4])
				{
				case 'C':
					ExecuteFillColor(element, settings);
					return;
				case 'P':
					ExecuteFillPattern(element, settings);
					return;
				case 'R':
					ExecuteFillRule(element, settings);
					return;
				}
				break;
			case 'o':
				switch (element.Name[2])
				{
				case 'n':
					if (element.Name.Length == 4)
					{
						ExecuteFont(element, settings);
						return;
					}
					switch (element.Name[4])
					{
					case 'F':
						ExecuteFontFamily(element, settings);
						return;
					case 'P':
						ExecuteFontPointsize(element, settings);
						return;
					case 'S':
						ExecuteFontStyle(element, settings);
						return;
					case 'W':
						ExecuteFontWeight(element, settings);
						return;
					}
					break;
				case 'r':
					ExecuteFormat(element, settings);
					return;
				}
				break;
			}
			break;
		case 'p':
			ExecutePage(element, settings);
			return;
		case 's':
			switch (element.Name[1])
			{
			case 't':
				switch (element.Name[6])
				{
				case 'A':
					ExecuteStrokeAntiAlias(element, settings);
					return;
				case 'C':
					ExecuteStrokeColor(element, settings);
					return;
				case 'D':
					switch (element.Name[10])
					{
					case 'A':
						ExecuteStrokeDashArray(element, settings);
						return;
					case 'O':
						ExecuteStrokeDashOffset(element, settings);
						return;
					}
					break;
				case 'L':
					switch (element.Name[10])
					{
					case 'C':
						ExecuteStrokeLineCap(element, settings);
						return;
					case 'J':
						ExecuteStrokeLineJoin(element, settings);
						return;
					}
					break;
				case 'M':
					ExecuteStrokeMiterLimit(element, settings);
					return;
				case 'P':
					ExecuteStrokePattern(element, settings);
					return;
				case 'W':
					ExecuteStrokeWidth(element, settings);
					return;
				}
				break;
			case 'e':
				if (element.Name.Length == 9)
				{
					ExecuteSetDefine(element, settings);
					return;
				}
				if (element.Name.Length == 10)
				{
					ExecuteSetDefines(element, settings);
					return;
				}
				break;
			}
			break;
		case 't':
			switch (element.Name[4])
			{
			case 'A':
				ExecuteTextAntiAlias(element, settings);
				return;
			case 'D':
				ExecuteTextDirection(element, settings);
				return;
			case 'E':
				ExecuteTextEncoding(element, settings);
				return;
			case 'G':
				ExecuteTextGravity(element, settings);
				return;
			case 'I':
				switch (element.Name[9])
				{
				case 'l':
					ExecuteTextInterlineSpacing(element, settings);
					return;
				case 'w':
					ExecuteTextInterwordSpacing(element, settings);
					return;
				}
				break;
			case 'K':
				ExecuteTextKerning(element, settings);
				return;
			case 'U':
				ExecuteTextUnderColor(element, settings);
				return;
			}
			break;
		case 'v':
			ExecuteVerbose(element, settings);
			return;
		case 'r':
			ExecuteRemoveDefine(element, settings);
			return;
		}
		throw new NotSupportedException(element.Name);
	}

	private void ExecuteBackgroundColor(XmlElement element, MagickSettings settings)
	{
		settings.BackgroundColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteBorderColor(XmlElement element, MagickSettings settings)
	{
		settings.BorderColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteColorSpace(XmlElement element, MagickSettings settings)
	{
		settings.ColorSpace = Variables.GetValue<ColorSpace>(element, "value");
	}

	private void ExecuteColorType(XmlElement element, MagickSettings settings)
	{
		settings.ColorType = Variables.GetValue<ColorType>(element, "value");
	}

	private void ExecuteCompressionMethod(XmlElement element, MagickSettings settings)
	{
		settings.CompressionMethod = Variables.GetValue<CompressionMethod>(element, "value");
	}

	private void ExecuteDebug(XmlElement element, MagickSettings settings)
	{
		settings.Debug = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteDensity(XmlElement element, MagickSettings settings)
	{
		settings.Density = Variables.GetValue<Density>(element, "value");
	}

	private void ExecuteEndian(XmlElement element, MagickSettings settings)
	{
		settings.Endian = Variables.GetValue<Endian>(element, "value");
	}

	private void ExecuteFillColor(XmlElement element, MagickSettings settings)
	{
		settings.FillColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteFillPattern(XmlElement element, MagickSettings settings)
	{
		settings.FillPattern = CreateMagickImage(element);
	}

	private void ExecuteFillRule(XmlElement element, MagickSettings settings)
	{
		settings.FillRule = Variables.GetValue<FillRule>(element, "value");
	}

	private void ExecuteFont(XmlElement element, MagickSettings settings)
	{
		settings.Font = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteFontFamily(XmlElement element, MagickSettings settings)
	{
		settings.FontFamily = Variables.GetValue<string>(element, "value");
	}

	private void ExecuteFontPointsize(XmlElement element, MagickSettings settings)
	{
		settings.FontPointsize = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteFontStyle(XmlElement element, MagickSettings settings)
	{
		settings.FontStyle = Variables.GetValue<FontStyleType>(element, "value");
	}

	private void ExecuteFontWeight(XmlElement element, MagickSettings settings)
	{
		settings.FontWeight = Variables.GetValue<FontWeight>(element, "value");
	}

	private void ExecuteFormat(XmlElement element, MagickSettings settings)
	{
		settings.Format = Variables.GetValue<MagickFormat>(element, "value");
	}

	private void ExecutePage(XmlElement element, MagickSettings settings)
	{
		settings.Page = Variables.GetValue<MagickGeometry>(element, "value");
	}

	private void ExecuteStrokeAntiAlias(XmlElement element, MagickSettings settings)
	{
		settings.StrokeAntiAlias = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteStrokeColor(XmlElement element, MagickSettings settings)
	{
		settings.StrokeColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteStrokeDashArray(XmlElement element, MagickSettings settings)
	{
		settings.StrokeDashArray = Variables.GetDoubleArray(element);
	}

	private void ExecuteStrokeDashOffset(XmlElement element, MagickSettings settings)
	{
		settings.StrokeDashOffset = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteStrokeLineCap(XmlElement element, MagickSettings settings)
	{
		settings.StrokeLineCap = Variables.GetValue<LineCap>(element, "value");
	}

	private void ExecuteStrokeLineJoin(XmlElement element, MagickSettings settings)
	{
		settings.StrokeLineJoin = Variables.GetValue<LineJoin>(element, "value");
	}

	private void ExecuteStrokeMiterLimit(XmlElement element, MagickSettings settings)
	{
		settings.StrokeMiterLimit = Variables.GetValue<int>(element, "value");
	}

	private void ExecuteStrokePattern(XmlElement element, MagickSettings settings)
	{
		settings.StrokePattern = CreateMagickImage(element);
	}

	private void ExecuteStrokeWidth(XmlElement element, MagickSettings settings)
	{
		settings.StrokeWidth = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextAntiAlias(XmlElement element, MagickSettings settings)
	{
		settings.TextAntiAlias = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteTextDirection(XmlElement element, MagickSettings settings)
	{
		settings.TextDirection = Variables.GetValue<TextDirection>(element, "value");
	}

	private void ExecuteTextEncoding(XmlElement element, MagickSettings settings)
	{
		settings.TextEncoding = Variables.GetValue<Encoding>(element, "value");
	}

	private void ExecuteTextGravity(XmlElement element, MagickSettings settings)
	{
		settings.TextGravity = Variables.GetValue<Gravity>(element, "value");
	}

	private void ExecuteTextInterlineSpacing(XmlElement element, MagickSettings settings)
	{
		settings.TextInterlineSpacing = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextInterwordSpacing(XmlElement element, MagickSettings settings)
	{
		settings.TextInterwordSpacing = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextKerning(XmlElement element, MagickSettings settings)
	{
		settings.TextKerning = Variables.GetValue<double>(element, "value");
	}

	private void ExecuteTextUnderColor(XmlElement element, MagickSettings settings)
	{
		settings.TextUnderColor = Variables.GetValue<MagickColor>(element, "value");
	}

	private void ExecuteVerbose(XmlElement element, MagickSettings settings)
	{
		settings.Verbose = Variables.GetValue<bool>(element, "value");
	}

	private void ExecuteRemoveDefine(XmlElement element, MagickSettings settings)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "format")
			{
				hashtable["format"] = Variables.GetValue<MagickFormat>(attribute);
			}
			else if (attribute.Name == "name")
			{
				hashtable["name"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "format", "name"))
		{
			settings.RemoveDefine((MagickFormat)hashtable["format"], (string)hashtable["name"]);
			return;
		}
		if (OnlyContains(hashtable, "name"))
		{
			settings.RemoveDefine((string)hashtable["name"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'removeDefine', allowed combinations are: [format, name] [name]");
	}

	private void ExecuteSetDefine(XmlElement element, MagickSettings settings)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "flag")
			{
				hashtable["flag"] = Variables.GetValue<bool>(attribute);
			}
			else if (attribute.Name == "format")
			{
				hashtable["format"] = Variables.GetValue<MagickFormat>(attribute);
			}
			else if (attribute.Name == "name")
			{
				hashtable["name"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "value")
			{
				hashtable["value"] = Variables.GetValue<string>(attribute);
			}
		}
		if (OnlyContains(hashtable, "format", "name", "flag"))
		{
			settings.SetDefine((MagickFormat)hashtable["format"], (string)hashtable["name"], (bool)hashtable["flag"]);
			return;
		}
		if (OnlyContains(hashtable, "format", "name", "value"))
		{
			settings.SetDefine((MagickFormat)hashtable["format"], (string)hashtable["name"], (string)hashtable["value"]);
			return;
		}
		if (OnlyContains(hashtable, "name", "value"))
		{
			settings.SetDefine((string)hashtable["name"], (string)hashtable["value"]);
			return;
		}
		throw new ArgumentException("Invalid argument combination for 'setDefine', allowed combinations are: [format, name, flag] [format, name, value] [name, value]");
	}

	private void ExecuteSetDefines(XmlElement element, MagickSettings settings)
	{
		IDefines defines = CreateIDefines(element["defines"]);
		settings.SetDefines(defines);
	}

	private MontageSettings CreateMontageSettings(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new MontageSettings
		{
			BackgroundColor = Variables.GetValue<MagickColor>(element, "backgroundColor"),
			BorderColor = Variables.GetValue<MagickColor>(element, "borderColor"),
			BorderWidth = Variables.GetValue<int>(element, "borderWidth"),
			FillColor = Variables.GetValue<MagickColor>(element, "fillColor"),
			Font = Variables.GetValue<string>(element, "font"),
			FontPointsize = Variables.GetValue<int>(element, "fontPointsize"),
			FrameGeometry = Variables.GetValue<MagickGeometry>(element, "frameGeometry"),
			Geometry = Variables.GetValue<MagickGeometry>(element, "geometry"),
			Gravity = Variables.GetValue<Gravity>(element, "gravity"),
			Label = Variables.GetValue<string>(element, "label"),
			Shadow = Variables.GetValue<bool>(element, "shadow"),
			StrokeColor = Variables.GetValue<MagickColor>(element, "strokeColor"),
			TextureFileName = Variables.GetValue<string>(element, "textureFileName"),
			TileGeometry = Variables.GetValue<MagickGeometry>(element, "tileGeometry"),
			Title = Variables.GetValue<string>(element, "title"),
			TransparentColor = Variables.GetValue<MagickColor>(element, "transparentColor")
		};
	}

	private MorphologySettings CreateMorphologySettings(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new MorphologySettings
		{
			Channels = Variables.GetValue<Channels>(element, "channels"),
			ConvolveBias = Variables.GetValue<Percentage?>(element, "convolveBias"),
			ConvolveScale = Variables.GetValue<MagickGeometry>(element, "convolveScale"),
			Iterations = Variables.GetValue<int>(element, "iterations"),
			Kernel = Variables.GetValue<Kernel>(element, "kernel"),
			KernelArguments = Variables.GetValue<string>(element, "kernelArguments"),
			Method = Variables.GetValue<MorphologyMethod>(element, "method"),
			UserKernel = Variables.GetValue<string>(element, "userKernel")
		};
	}

	private PathArc CreatePathArc(XmlElement element)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		double value3 = Variables.GetValue<double>(element, "radiusX");
		double value4 = Variables.GetValue<double>(element, "radiusY");
		double value5 = Variables.GetValue<double>(element, "rotationX");
		bool value6 = Variables.GetValue<bool>(element, "useLargeArc");
		bool value7 = Variables.GetValue<bool>(element, "useSweep");
		return new PathArc(value, value2, value3, value4, value5, value6, value7);
	}

	private Collection<PathArc> CreatePathArcs(XmlElement element)
	{
		Collection<PathArc> collection = new Collection<PathArc>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			collection.Add(CreatePathArc(item));
		}
		return collection;
	}

	private PixelStorageSettings CreatePixelStorageSettings(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new PixelStorageSettings
		{
			Mapping = Variables.GetValue<string>(element, "mapping"),
			StorageType = Variables.GetValue<StorageType>(element, "storageType")
		};
	}

	private PointD CreatePointD(XmlElement element)
	{
		Hashtable hashtable = new Hashtable();
		foreach (XmlAttribute attribute in element.Attributes)
		{
			if (attribute.Name == "value")
			{
				hashtable["value"] = Variables.GetValue<string>(attribute);
			}
			else if (attribute.Name == "x")
			{
				hashtable["x"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "xy")
			{
				hashtable["xy"] = Variables.GetValue<double>(attribute);
			}
			else if (attribute.Name == "y")
			{
				hashtable["y"] = Variables.GetValue<double>(attribute);
			}
		}
		if (OnlyContains(hashtable, "value"))
		{
			return new PointD((string)hashtable["value"]);
		}
		if (OnlyContains(hashtable, "x", "y"))
		{
			return new PointD((double)hashtable["x"], (double)hashtable["y"]);
		}
		if (OnlyContains(hashtable, "xy"))
		{
			return new PointD((double)hashtable["xy"]);
		}
		throw new ArgumentException("Invalid argument combination for 'pointD', allowed combinations are: [value] [x, y] [xy]");
	}

	private Collection<PointD> CreatePointDs(XmlElement element)
	{
		Collection<PointD> collection = new Collection<PointD>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			collection.Add(CreatePointD(item));
		}
		return collection;
	}

	private PrimaryInfo CreatePrimaryInfo(XmlElement element)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		double value3 = Variables.GetValue<double>(element, "z");
		return new PrimaryInfo(value, value2, value3);
	}

	private Collection<PrimaryInfo> CreatePrimaryInfos(XmlElement element)
	{
		Collection<PrimaryInfo> collection = new Collection<PrimaryInfo>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			collection.Add(CreatePrimaryInfo(item));
		}
		return collection;
	}

	private QuantizeSettings CreateQuantizeSettings(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		return new QuantizeSettings
		{
			Colors = Variables.GetValue<int>(element, "colors"),
			ColorSpace = Variables.GetValue<ColorSpace>(element, "colorSpace"),
			DitherMethod = Variables.GetValue<DitherMethod?>(element, "ditherMethod"),
			MeasureErrors = Variables.GetValue<bool>(element, "measureErrors"),
			TreeDepth = Variables.GetValue<int>(element, "treeDepth")
		};
	}

	private SparseColorArg CreateSparseColorArg(XmlElement element)
	{
		double value = Variables.GetValue<double>(element, "x");
		double value2 = Variables.GetValue<double>(element, "y");
		MagickColor value3 = Variables.GetValue<MagickColor>(element, "color");
		return new SparseColorArg(value, value2, value3);
	}

	private Collection<SparseColorArg> CreateSparseColorArgs(XmlElement element)
	{
		Collection<SparseColorArg> collection = new Collection<SparseColorArg>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			collection.Add(CreateSparseColorArg(item));
		}
		return collection;
	}

	public MagickScript(IXPathNavigable xml)
	{
		Throw.IfNull("xml", xml);
		Initialize(xml.CreateNavigator());
	}

	public MagickScript(string fileName)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		using FileStream stream = File.OpenRead(text);
		Initialize(stream);
	}

	public MagickScript(Stream stream)
	{
		Initialize(stream);
	}

	public MagickScript(XElement xml)
	{
		Throw.IfNull("xml", xml);
		Initialize(xml.CreateNavigator());
	}

	public IMagickImage Execute()
	{
		XmlElement xmlElement = (XmlElement)_script.SelectSingleNode("/msl/*");
		if (xmlElement.Name == "read")
		{
			return CreateMagickImage(xmlElement);
		}
		if (xmlElement.Name == "collection")
		{
			return ExecuteCollection(xmlElement);
		}
		throw new NotSupportedException(xmlElement.Name);
	}

	public void Execute(IMagickImage image)
	{
		Throw.IfNull("image", image);
		XmlElement xmlElement = (XmlElement)_script.SelectSingleNode("/msl/read");
		if (xmlElement == null)
		{
			throw new InvalidOperationException("This method only works with a script that contains a single read operation.");
		}
		Execute(xmlElement, image);
	}

	private static bool OnlyContains(Hashtable arguments, params object[] keys)
	{
		if (arguments.Count != keys.Length)
		{
			return false;
		}
		foreach (object key in keys)
		{
			if (!arguments.ContainsKey(key))
			{
				return false;
			}
		}
		return true;
	}

	private MagickImage CreateMagickImage(XmlElement element)
	{
		Throw.IfNull("element", element);
		MagickImage magickImage = null;
		MagickReadSettings magickReadSettings = CreateReadSettings((XmlElement)element.SelectSingleNode("readSettings"));
		string attribute = element.GetAttribute("fileName");
		if (!string.IsNullOrEmpty(attribute))
		{
			magickImage = ((magickReadSettings == null) ? new MagickImage(attribute) : new MagickImage(attribute, magickReadSettings));
		}
		else
		{
			if (Read == null)
			{
				throw new InvalidOperationException("The Read event should be bound when the fileName attribute is not set.");
			}
			ScriptReadEventArgs e = new ScriptReadEventArgs(element.GetAttribute("id"), magickReadSettings);
			Read(this, e);
			if (e.Image == null)
			{
				throw new InvalidOperationException("The Image property should not be null after the Read event has been raised.");
			}
			magickImage = e.Image;
		}
		Execute(element, magickImage);
		return magickImage;
	}

	private Collection<IPath> CreatePaths(XmlElement element)
	{
		Collection<IPath> collection = new Collection<IPath>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			ExecuteIPath(item, collection);
		}
		return collection;
	}

	private ImageProfile CreateProfile(XmlElement element)
	{
		XmlElement xmlElement = (XmlElement)element.SelectSingleNode("*");
		if (xmlElement.Name == "imageProfile")
		{
			return CreateImageProfile(xmlElement);
		}
		if (xmlElement.Name == "colorProfile")
		{
			return CreateColorProfile(xmlElement);
		}
		throw new NotSupportedException(xmlElement.Name);
	}

	private MagickReadSettings CreateReadSettings(XmlElement element)
	{
		MagickReadSettings magickReadSettings = new MagickReadSettings();
		if (element == null)
		{
			return magickReadSettings;
		}
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			ExecuteMagickReadSettings(item, magickReadSettings);
		}
		return magickReadSettings;
	}

	private void Execute(XmlElement element, IMagickImage image)
	{
		foreach (XmlElement item in element.SelectNodes("*[name() != 'readSettings']"))
		{
			ExecuteImage(item, image);
		}
	}

	private IMagickImage Execute(XmlElement element, MagickImageCollection collection)
	{
		if (element.Name == "read")
		{
			collection.Add(CreateMagickImage(element));
			return null;
		}
		if (element.Name == "write")
		{
			string attribute = XmlHelper.GetAttribute<string>(element, "fileName");
			collection.Write(attribute);
			return null;
		}
		return ExecuteCollection(element, collection);
	}

	private void ExecuteClone(XmlElement element, IMagickImage image)
	{
		Execute(element, image.Clone());
	}

	private IMagickImage ExecuteCollection(XmlElement element)
	{
		using MagickImageCollection collection = new MagickImageCollection();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			IMagickImage magickImage = Execute(item, collection);
			if (magickImage != null)
			{
				return magickImage;
			}
		}
		return null;
	}

	private void ExecuteDraw(XmlElement element, IMagickImage image)
	{
		Collection<IDrawable> drawables = new Collection<IDrawable>();
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			ExecuteIDrawable(item, drawables);
		}
		image.Draw(drawables);
	}

	private void ExecuteMagickSettings(XmlElement element, IMagickImage image)
	{
		foreach (XmlElement item in element.SelectNodes("*"))
		{
			ExecuteMagickSettings(item, image.Settings);
		}
	}

	private void ExecuteWrite(XmlElement element, IMagickImage image)
	{
		string attribute = element.GetAttribute("fileName");
		if (!string.IsNullOrEmpty(attribute))
		{
			image.Write(attribute);
			return;
		}
		if (Write == null)
		{
			throw new InvalidOperationException("The Write event should be bound when the fileName attribute is not set.");
		}
		ScriptWriteEventArgs e = new ScriptWriteEventArgs(element.GetAttribute("id"), image);
		Write(this, e);
	}

	private void Initialize(Stream stream)
	{
		Throw.IfNull("stream", stream);
		using (XmlReader reader = XmlReader.Create(stream, _ReaderSettings))
		{
			_script = new XmlDocument();
			_script.Load(reader);
		}
		Variables = new ScriptVariables(_script);
	}

	private void Initialize(XPathNavigator navigator)
	{
		using MemoryStream memoryStream = new MemoryStream();
		using XmlWriter xmlWriter = XmlWriter.Create(memoryStream);
		navigator.WriteSubtree(xmlWriter);
		xmlWriter.Flush();
		memoryStream.Position = 0L;
		Initialize(memoryStream);
	}
}
