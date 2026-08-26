#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ResourceNameCreator
{
	private readonly ModuleDef module;

	private readonly FilenameCreator filenameCreator;

	private Dictionary<string, TypeDef> resXNameToType;

	private HashSet<string> namespaces;

	private Dictionary<string, string> lowerCaseNsToReal;

	private Dictionary<string, string> partialNamespaceMap;

	private Dictionary<string, string> partialTypeToFullNameMap;

	private Dictionary<string, string> typeToFullNameMap;

	public ResourceNameCreator(ModuleDef module, FilenameCreator filenameCreator)
	{
		this.module = module;
		this.filenameCreator = filenameCreator;
	}

	public string GetResxFilename(string resourceName, out string typeFullName)
	{
		string text = resourceName;
		if (text.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
		{
			text = text.Substring(0, text.Length - ".resources".Length);
		}
		TypeDef typeDef = module.Find(text, isReflectionName: true);
		if (typeDef != null && DotNetUtils.IsWinForm(typeDef))
		{
			typeFullName = typeDef.ReflectionFullName;
			return filenameCreator.CreateFromNamespaceName(".resx", typeDef.Namespace, typeDef.Name);
		}
		TypeDef resXType = GetResXType(typeDef, text);
		if (resXType != null)
		{
			typeFullName = resXType.ReflectionFullName;
			return filenameCreator.CreateFromNamespaceName(".resx", resXType.ReflectionNamespace, GetResxDesignerFilename(resXType.ReflectionNamespace, text));
		}
		typeFullName = text;
		return filenameCreator.Create(".resx", text);
	}

	private string GetResxDesignerFilename(string ns, string name)
	{
		if (name.StartsWith(ns + ".", StringComparison.Ordinal))
		{
			return name.Substring(ns.Length + 1);
		}
		Debug.Fail("Weird name");
		return name;
	}

	private TypeDef GetResXType(TypeDef type, string name)
	{
		if (type != null && IsResXType(type, name))
		{
			return type;
		}
		return FindResXType(name);
	}

	private TypeDef FindResXType(string name)
	{
		if (resXNameToType == null)
		{
			Dictionary<string, TypeDef> dictionary = new Dictionary<string, TypeDef>(StringComparer.Ordinal);
			foreach (TypeDef type in module.Types)
			{
				string resXString = GetResXString(type);
				if (resXString != null)
				{
					dictionary[resXString] = type;
				}
			}
			resXNameToType = dictionary;
		}
		resXNameToType.TryGetValue(name, out var value);
		return value;
	}

	private static string GetResXString(TypeDef type)
	{
		if (!type.Fields.Any((FieldDef a) => a.IsStatic && a.FieldType != null && a.FieldType.ToString() == "System.Globalization.CultureInfo"))
		{
			return null;
		}
		if (!type.Fields.Any((FieldDef a) => a.IsStatic && a.FieldType != null && a.FieldType.ToString() == "System.Resources.ResourceManager"))
		{
			return null;
		}
		foreach (MethodDef method2 in type.Methods)
		{
			CilBody body = method2.Body;
			if (body == null)
			{
				continue;
			}
			IList<Instruction> instructions = body.Instructions;
			for (int num = 0; num + 2 < instructions.Count; num++)
			{
				if (instructions[num].OpCode.Code == Code.Ldstr && instructions[num + 1].OpCode.Code == Code.Ldtoken && instructions[num + 2].OpCode.Code == Code.Call && instructions[num].Operand is string result && instructions[num + 2].Operand is IMethod method && !(method.FullName != "System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)"))
				{
					return result;
				}
			}
		}
		return null;
	}

	private bool IsResXType(TypeDef type, string name)
	{
		foreach (MethodDef method in type.Methods)
		{
			CilBody body = method.Body;
			if (body == null || !body.Instructions.Any((Instruction a) => a.Operand is string && name.Equals((string)a.Operand)))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public string GetXamlResourceFilename(string resourceName)
	{
		return GetBamlResourceName(resourceName);
	}

	private string GetBamlResourceName(string resourceName)
	{
		if (namespaces == null)
		{
			Initialize();
		}
		string extension = FileUtils.GetExtension(resourceName);
		string text = resourceName.Substring(0, resourceName.Length - extension.Length);
		string text2 = GetNamespace(resourceName);
		if (partialNamespaceMap.TryGetValue(text2, out var value))
		{
			text = value.Replace('.', '/') + "/" + text.Substring(text2.Length + 1);
		}
		return filenameCreator.CreateFromRelativePath(text, extension);
	}

	private static string GetNamespace(string name)
	{
		int num = name.LastIndexOf('/');
		if (num < 0)
		{
			return string.Empty;
		}
		return name.Substring(0, num).Replace('/', '.');
	}

	public string GetBamlResourceName(string resourceName, out string typeFullName)
	{
		if (namespaces == null)
		{
			Initialize();
		}
		Debug.Assert(resourceName.EndsWith(".baml", StringComparison.OrdinalIgnoreCase));
		string text = resourceName.Substring(0, resourceName.Length - ".baml".Length);
		string text2 = text;
		text = text.Replace('/', '.');
		typeFullName = GetFullName(text);
		if (!string.IsNullOrEmpty(typeFullName))
		{
			return filenameCreator.Create(".xaml", typeFullName);
		}
		return GetBamlResourceName(text2 + ".xaml");
	}

	private string GetFullName(string partialName)
	{
		string text = partialName;
		if (!string.IsNullOrEmpty(filenameCreator.DefaultNamespace))
		{
			text = filenameCreator.DefaultNamespace + "." + text;
		}
		if (typeToFullNameMap.TryGetValue(text, out var value))
		{
			return value;
		}
		partialTypeToFullNameMap.TryGetValue(partialName, out value);
		return value;
	}

	public string GetResourceFilename(string resourceName)
	{
		if (namespaces == null)
		{
			Initialize();
		}
		string[] array = resourceName.Split('.');
		List<string> list = new List<string>(array.Length);
		StringBuilder stringBuilder = new StringBuilder(resourceName.Length);
		for (int i = 0; i < array.Length - 1; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(".");
			}
			stringBuilder.Append(array[i]);
			string text = stringBuilder.ToString();
			lowerCaseNsToReal.TryGetValue(text, out var value);
			list.Add(value ?? text);
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			string text2 = list[num];
			if (namespaces.Contains(text2))
			{
				string filename = resourceName.Substring(text2.Length + 1);
				return filenameCreator.CreateFromNamespaceFilename(text2, filename);
			}
		}
		return filenameCreator.CreateName(resourceName);
	}

	private void Initialize()
	{
		if (namespaces != null)
		{
			return;
		}
		HashSet<string> hashSet = new HashSet<string>(module.Types.Select((TypeDef a) => UTF8String.ToSystemStringOrEmpty(a.Namespace)));
		hashSet.Remove(string.Empty);
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
		foreach (string item in hashSet)
		{
			stringBuilder.Clear();
			string[] array = item.Split('.');
			foreach (string value in array)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('.');
				}
				stringBuilder.Append(value);
				string text = stringBuilder.ToString();
				dictionary[text] = text;
			}
		}
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
		Dictionary<string, string> dictionary4 = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
		Dictionary<string, string> dictionary5 = new Dictionary<string, string>(StringComparer.Ordinal);
		foreach (TypeDef type in module.Types)
		{
			UTF8String uTF8String = type.Namespace;
			string text2 = ((!UTF8String.IsNullOrEmpty(uTF8String)) ? (uTF8String.String + "." + (type.Name ?? UTF8String.Empty).String) : (type.Name ?? UTF8String.Empty).String);
			dictionary3[text2] = text2;
			string text3 = text2;
			while (text3.Length > 0)
			{
				dictionary2[text3] = text2;
				int num2 = text3.IndexOf('.');
				if (num2 < 0)
				{
					break;
				}
				text3 = text3.Substring(num2 + 1);
			}
			string text4 = (type.Namespace ?? UTF8String.Empty).String;
			while (text4.Length > 0)
			{
				if (dictionary5.TryGetValue(text4, out var value2))
				{
					text4 = value2;
				}
				else
				{
					dictionary5[text4] = text4;
				}
				dictionary4[text4] = text4;
				int num3 = text4.IndexOf('.');
				if (num3 < 0)
				{
					break;
				}
				text4 = text4.Substring(num3 + 1);
			}
		}
		partialNamespaceMap = dictionary4;
		partialTypeToFullNameMap = dictionary2;
		typeToFullNameMap = dictionary3;
		lowerCaseNsToReal = dictionary;
		namespaces = hashSet;
	}
}
