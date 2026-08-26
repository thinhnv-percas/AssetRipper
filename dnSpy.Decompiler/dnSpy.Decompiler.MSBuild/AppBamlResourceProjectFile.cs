#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class AppBamlResourceProjectFile : ProjectFile
{
	private readonly TypeDef type;

	private readonly IDecompiler decompiler;

	public override string Description => dnSpy_Decompiler_Resources.MSBuild_CreateAppXaml;

	public override BuildAction BuildAction { get; }

	public override string Filename { get; }

	public AppBamlResourceProjectFile(string filename, TypeDef type, IDecompiler decompiler)
	{
		Filename = filename;
		this.type = type;
		base.SubType = "Designer";
		base.Generator = "MSBuild:Compile";
		BuildAction = (DotNetUtils.IsStartUpClass(type) ? BuildAction.ApplicationDefinition : BuildAction.Page);
		this.decompiler = decompiler;
	}

	private CilBody GetInitializeComponentBody()
	{
		return type.FindMethods("InitializeComponent").FirstOrDefault((MethodDef a) => a.Parameters.Count == 1 && !a.IsStatic)?.Body;
	}

	private string GetStartupUri(CilBody body)
	{
		return body?.Instructions.Where((Instruction a) => a.Operand is string && ((string)a.Operand).EndsWith(".xaml", StringComparison.OrdinalIgnoreCase)).Select((Instruction a) => (string)a.Operand).FirstOrDefault();
	}

	public override void Create(DecompileContext ctx)
	{
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Encoding = Encoding.UTF8,
			Indent = true,
			OmitXmlDeclaration = true
		};
		using XmlWriter xmlWriter = XmlWriter.Create(Filename, settings);
		xmlWriter.WriteStartDocument();
		xmlWriter.WriteStartElement("Application", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
		xmlWriter.WriteAttributeString("x", "Class", "http://schemas.microsoft.com/winfx/2006/xaml", type.ReflectionFullName);
		if (type.IsNotPublic)
		{
			BamlDecompilerOptions bamlDecompilerOptions = BamlDecompilerOptions.Create(decompiler);
			xmlWriter.WriteAttributeString("x", "ClassModifier", "http://schemas.microsoft.com/winfx/2006/xaml", bamlDecompilerOptions.InternalClassModifier);
		}
		CilBody initializeComponentBody = GetInitializeComponentBody();
		Debug.Assert(initializeComponentBody != null);
		if (initializeComponentBody != null)
		{
			string startupUri = GetStartupUri(initializeComponentBody);
			if (startupUri != null)
			{
				xmlWriter.WriteAttributeString("StartupUri", startupUri);
			}
			foreach (var @event in GetEvents(initializeComponentBody))
			{
				xmlWriter.WriteAttributeString(@event.Item1, @event.Item2);
			}
		}
		xmlWriter.WriteElementString("Application.Resources", "\r\n");
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndDocument();
	}

	private IEnumerable<(string, string)> GetEvents(CilBody body)
	{
		IList<Instruction> instrs = body.Instructions;
		for (int i = 0; i + 2 < instrs.Count; i++)
		{
			if ((instrs[i].OpCode.Code == Code.Ldftn || instrs[i].OpCode.Code == Code.Ldvirtftn) && instrs[i].Operand is MethodDef m && instrs[i + 1].OpCode.Code == Code.Newobj && instrs[i + 2].OpCode.Code == Code.Call)
			{
				IMethod addMethod = instrs[i + 2].Operand as IMethod;
				if (addMethod != null && addMethod.MethodSig.GetParamCount() == 1 && addMethod.Name.StartsWith("add_"))
				{
					yield return (addMethod.Name.String.Substring(4), m.Name.String);
				}
			}
		}
	}
}
