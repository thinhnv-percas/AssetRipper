#define DEBUG
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using dnlib.DotNet;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class SettingsProjectFile : ProjectFile
{
	private sealed class Setting
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string Provider { get; set; }

		public bool Roaming { get; set; }

		public bool GenerateDefaultValueInCode { get; set; }

		public string Type { get; set; }

		public string Scope { get; set; }

		public Value Value { get; set; }

		public Value DesignTimeValue { get; set; }

		public Setting()
		{
			GenerateDefaultValueInCode = true;
		}
	}

	private sealed class Value
	{
		public string Profile { get; set; }

		public string Text { get; set; }
	}

	private sealed class ConnectionStringInfo
	{
		public string String { get; set; }

		public string ProviderName { get; set; }
	}

	private readonly string filename;

	private readonly TypeDef type;

	private const string DEFAULT_PROFILE = "(Default)";

	private Dictionary<string, ConnectionStringInfo> toConnectionStringInfo;

	private static readonly string connectionIdStringFormat = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<SerializableConnectionString xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <ConnectionString>{0}</ConnectionString>\r\n  <ProviderName>{1}</ProviderName>\r\n</SerializableConnectionString>";

	public override string Description => string.Format(dnSpy_Decompiler_Resources.MSBuild_CreateSettingsFile, Path.GetFileName(filename));

	public override BuildAction BuildAction => BuildAction.None;

	public override string Filename => filename;

	public SettingsProjectFile(TypeDef type, string filename)
	{
		this.filename = filename;
		this.type = type;
	}

	public override void Create(DecompileContext ctx)
	{
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = Encoding.UTF8,
			Indent = true
		};
		using XmlWriter xmlWriter = XmlWriter.Create(filename, settings);
		xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='utf-8'");
		xmlWriter.WriteStartElement("SettingsFile", "http://schemas.microsoft.com/VisualStudio/2004/01/settings");
		xmlWriter.WriteAttributeString("CurrentProfile", "(Default)");
		xmlWriter.WriteAttributeString("GeneratedClassNamespace", type.ReflectionNamespace);
		xmlWriter.WriteAttributeString("GeneratedClassName", type.ReflectionName);
		xmlWriter.WriteStartElement("Profiles");
		xmlWriter.WriteEndElement();
		xmlWriter.WriteStartElement("Settings");
		foreach (Setting item in FindSettings())
		{
			xmlWriter.WriteStartElement("Setting");
			xmlWriter.WriteAttributeString("Name", item.Name);
			if (!string.IsNullOrEmpty(item.Description))
			{
				xmlWriter.WriteAttributeString("Description", item.Description);
			}
			if (!string.IsNullOrEmpty(item.Provider))
			{
				xmlWriter.WriteAttributeString("Provider", item.Provider);
			}
			if (item.Roaming)
			{
				xmlWriter.WriteAttributeString("Roaming", "true");
			}
			if (!item.GenerateDefaultValueInCode)
			{
				xmlWriter.WriteAttributeString("GenerateDefaultValueInCode", "false");
			}
			xmlWriter.WriteAttributeString("Type", item.Type);
			xmlWriter.WriteAttributeString("Scope", item.Scope);
			if (item.DesignTimeValue != null)
			{
				xmlWriter.WriteStartElement("DesignTimeValue");
				xmlWriter.WriteAttributeString("Profile", item.DesignTimeValue.Profile);
				xmlWriter.WriteString(item.DesignTimeValue.Text);
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteStartElement("Value");
			xmlWriter.WriteAttributeString("Profile", item.Value.Profile);
			xmlWriter.WriteString(item.Value.Text);
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndElement();
		}
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndDocument();
	}

	private IEnumerable<Setting> FindSettings()
	{
		foreach (PropertyDef prop in type.Properties)
		{
			TypeSig propType = prop.PropertySig.GetRetType().RemovePinnedAndModifiers();
			if (propType == null)
			{
				continue;
			}
			string settingsType = propType.ReflectionFullName;
			CustomAttribute ca = prop.CustomAttributes.Find("System.Configuration.DefaultSettingValueAttribute");
			if (ca == null || ca.ConstructorArguments.Count != 1)
			{
				continue;
			}
			CAArgument arg = ca.ConstructorArguments[0];
			if (arg.Type.RemovePinnedAndModifiers().GetElementType() != ElementType.String)
			{
				continue;
			}
			string defaultValue = arg.Value as UTF8String;
			if (defaultValue == null)
			{
				continue;
			}
			bool generateDefaultValueInCode = true;
			bool hasUserScopedAttr = prop.CustomAttributes.IsDefined("System.Configuration.UserScopedSettingAttribute");
			bool hasAppScopedAttr = prop.CustomAttributes.IsDefined("System.Configuration.ApplicationScopedSettingAttribute");
			if (!hasUserScopedAttr && !hasAppScopedAttr)
			{
				continue;
			}
			bool roaming = false;
			ca = prop.CustomAttributes.Find("System.Configuration.SettingsManageabilityAttribute");
			if (ca != null && ca.ConstructorArguments.Count == 1)
			{
				arg = ca.ConstructorArguments[0];
				TypeSig argType = arg.Type.RemovePinnedAndModifiers();
				if (argType != null && argType.ReflectionFullName == "System.Configuration.SettingsManageability")
				{
					int? v = arg.Value as int?;
					if (v.HasValue && v.Value == 0)
					{
						roaming = true;
					}
				}
			}
			Setting setting = new Setting();
			ca = prop.CustomAttributes.Find("System.Configuration.SpecialSettingAttribute");
			if (ca != null && ca.ConstructorArguments.Count == 1)
			{
				arg = ca.ConstructorArguments[0];
				TypeSig argType2 = arg.Type.RemovePinnedAndModifiers();
				if (argType2 != null && argType2.ReflectionFullName == "System.Configuration.SpecialSetting")
				{
					int? v2 = arg.Value as int?;
					if (v2.HasValue)
					{
						switch ((SpecialSetting)v2.Value)
						{
						case SpecialSetting.ConnectionString:
						{
							settingsType = "(Connection string)";
							string designTimeValue = GetConnectionStringDesignTimeValue(prop);
							if (designTimeValue != null)
							{
								setting.DesignTimeValue = new Value
								{
									Profile = "(Default)",
									Text = designTimeValue
								};
							}
							break;
						}
						case SpecialSetting.WebServiceUrl:
							settingsType = "(Web Service URL)";
							break;
						}
					}
				}
			}
			string provider = null;
			ca = prop.CustomAttributes.Find("System.Configuration.SettingsProviderAttribute");
			if (ca != null && ca.ConstructorArguments.Count == 1)
			{
				arg = ca.ConstructorArguments[0];
				TypeSig argType3 = arg.Type.RemovePinnedAndModifiers();
				if (argType3.GetElementType() == ElementType.String)
				{
					provider = arg.Value as UTF8String;
				}
				else if (argType3 != null && argType3.FullName == "System.Type")
				{
					TypeDefOrRefSig typeDefOrRefSig;
					TypeDefOrRefSig t = (typeDefOrRefSig = arg.Value as TypeDefOrRefSig);
					if (typeDefOrRefSig != null && t.TypeDefOrRef != null)
					{
						provider = t.TypeDefOrRef.ReflectionFullName;
					}
				}
			}
			string description = null;
			ca = prop.CustomAttributes.Find("System.Configuration.SettingsDescriptionAttribute");
			if (ca != null && ca.ConstructorArguments.Count == 1)
			{
				arg = ca.ConstructorArguments[0];
				TypeSig argType4 = arg.Type.RemovePinnedAndModifiers();
				if (argType4.GetElementType() == ElementType.String)
				{
					description = arg.Value as UTF8String;
				}
			}
			setting.Name = prop.Name;
			setting.Description = description;
			setting.Provider = provider;
			setting.Roaming = roaming;
			setting.GenerateDefaultValueInCode = generateDefaultValueInCode;
			setting.Type = settingsType;
			setting.Scope = (hasUserScopedAttr ? "User" : "Application");
			setting.Value = new Value
			{
				Profile = "(Default)",
				Text = defaultValue
			};
			yield return setting;
		}
	}

	private string GetConnectionStringDesignTimeValue(PropertyDef prop)
	{
		if (toConnectionStringInfo == null)
		{
			InitializeConnectionStringDesignTimeValues();
		}
		if (!toConnectionStringInfo.TryGetValue(prop.Name, out var value))
		{
			return null;
		}
		return string.Format(connectionIdStringFormat, EscapeXmlString(value.String), EscapeXmlString(value.ProviderName));
	}

	private static string EscapeXmlString(string s)
	{
		XmlElement xmlElement = new XmlDocument().CreateElement("a");
		xmlElement.InnerText = s;
		return xmlElement.InnerXml;
	}

	private void InitializeConnectionStringDesignTimeValues()
	{
		Debug.Assert(toConnectionStringInfo == null);
		if (toConnectionStringInfo != null)
		{
			return;
		}
		toConnectionStringInfo = new Dictionary<string, ConnectionStringInfo>(StringComparer.Ordinal);
		string text = type.Module.Location + ".config";
		if (!File.Exists(text))
		{
			return;
		}
		try
		{
			XDocument node = XDocument.Load(text, LoadOptions.None);
			string text2 = type.ReflectionFullName + ".";
			foreach (XElement item in node.XPathSelectElements("/configuration/connectionStrings/add"))
			{
				string text3 = (string)item.Attribute("name");
				if (text3 == null || !text3.StartsWith(text2, StringComparison.Ordinal))
				{
					continue;
				}
				string text4 = (string)item.Attribute("connectionString");
				string text5 = (string)item.Attribute("providerName");
				if (text4 != null && text5 != null)
				{
					ConnectionStringInfo value = new ConnectionStringInfo
					{
						String = text4,
						ProviderName = text5
					};
					string key = text3.Substring(text2.Length);
					if (!toConnectionStringInfo.ContainsKey(key))
					{
						toConnectionStringInfo[key] = value;
					}
				}
			}
		}
		catch
		{
		}
	}
}
