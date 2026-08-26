using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace ImageMagick;

public sealed class ScriptVariables
{
	private static readonly Regex _Names = new Regex("\\{[$](?<name>[0-9a-zA-Z_-]{1,16})\\}", RegexOptions.Compiled);

	private readonly Dictionary<string, object> _variables;

	public IEnumerable<string> Names => _variables.Keys;

	public object this[string name]
	{
		get
		{
			return Get(name);
		}
		set
		{
			Set(name, value);
		}
	}

	internal ScriptVariables(XmlDocument script)
	{
		_variables = new Dictionary<string, object>();
		GetNames(script.DocumentElement);
	}

	public object Get(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		return _variables[name];
	}

	public void Set(string name, object value)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfFalse("name", _variables.ContainsKey(name), "Invalid variable name: {0}", value);
		_variables[name] = value;
	}

	internal double[] GetDoubleArray(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		XmlAttribute xmlAttribute = element.Attributes["variable"];
		if (xmlAttribute != null)
		{
			string[] names = GetNames(xmlAttribute.Value);
			if (names != null)
			{
				return (double[])_variables[names[0]];
			}
		}
		double[] array = new double[element.ChildNodes.Count];
		int num = 0;
		foreach (XmlElement childNode in element.ChildNodes)
		{
			array[num++] = double.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
		}
		return array;
	}

	internal float[] GetSingleArray(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		XmlAttribute xmlAttribute = element.Attributes["variable"];
		if (xmlAttribute != null)
		{
			string[] names = GetNames(xmlAttribute.Value);
			if (names != null)
			{
				return (float[])_variables[names[0]];
			}
		}
		float[] array = new float[element.ChildNodes.Count];
		int num = 0;
		foreach (XmlElement childNode in element.ChildNodes)
		{
			array[num++] = float.Parse(childNode.InnerText, CultureInfo.InvariantCulture);
		}
		return array;
	}

	internal string[] GetStringArray(XmlElement element)
	{
		if (element == null)
		{
			return null;
		}
		XmlAttribute xmlAttribute = element.Attributes["variable"];
		if (xmlAttribute != null)
		{
			string[] names = GetNames(xmlAttribute.Value);
			if (names != null)
			{
				return (string[])_variables[names[0]];
			}
		}
		string[] array = new string[element.ChildNodes.Count];
		int num = 0;
		foreach (XmlElement childNode in element.ChildNodes)
		{
			array[num++] = childNode.InnerText;
		}
		return array;
	}

	internal T GetValue<T>(XmlAttribute attribute)
	{
		if (attribute == null)
		{
			return default(T);
		}
		string[] names = GetNames(attribute.Value);
		if (names == null)
		{
			return XmlHelper.GetValue<T>(attribute);
		}
		if (typeof(T) == typeof(string))
		{
			string text = attribute.Value;
			string[] array = names;
			foreach (string key in array)
			{
				text = text.Replace(text, MagickConverter.Convert<string>(_variables[key]));
			}
			return (T)(object)text;
		}
		string text2 = names[0];
		if (TypeHelper.IsValueType(typeof(T)))
		{
			Throw.IfNull("attribute", _variables[text2], "The variable {0} should be set.", text2);
		}
		return MagickConverter.Convert<T>(_variables[text2]);
	}

	internal T GetValue<T>(XmlElement element, string attribute)
	{
		return GetValue<T>(element.Attributes[attribute]);
	}

	private static string[] GetNames(string value)
	{
		if (value.Length < 3)
		{
			return null;
		}
		MatchCollection matchCollection = _Names.Matches(value);
		if (matchCollection.Count == 0)
		{
			return null;
		}
		string[] array = new string[matchCollection.Count];
		for (int i = 0; i < matchCollection.Count; i++)
		{
			array[i] = matchCollection[i].Groups["name"].Value;
		}
		return array;
	}

	private void GetNames(XmlElement element)
	{
		foreach (XmlAttribute attribute in element.Attributes)
		{
			string[] names = GetNames(attribute.Value);
			if (names != null)
			{
				string[] array = names;
				foreach (string key in array)
				{
					_variables[key] = null;
				}
			}
		}
		foreach (XmlNode childNode in element.ChildNodes)
		{
			if (childNode.GetType() == typeof(XmlElement))
			{
				GetNames((XmlElement)childNode);
			}
		}
	}
}
