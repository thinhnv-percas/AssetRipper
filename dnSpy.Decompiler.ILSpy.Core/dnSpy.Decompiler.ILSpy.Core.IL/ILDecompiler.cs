using System;
using System.Collections.Generic;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Decompiler.XmlDoc;
using dnSpy.Contracts.Text;
using dnSpy.Decompiler.IL;
using dnSpy.Decompiler.ILSpy.Core.Settings;
using dnSpy.Decompiler.ILSpy.Core.XmlDoc;
using ICSharpCode.Decompiler.Disassembler;

namespace dnSpy.Decompiler.ILSpy.Core.IL;

internal sealed class ILDecompiler : DecompilerBase
{
	private readonly bool detectControlStructure;

	private readonly ILDecompilerSettings langSettings;

	public override DecompilerSettingsBase Settings => langSettings;

	public override double OrderUI => DecompilerConstants.IL_ILSPY_ORDERUI;

	public override string ContentTypeString => "IL ILSpy";

	public override string GenericNameUI => DecompilerConstants.GENERIC_NAMEUI_IL;

	public override string UniqueNameUI => "IL";

	public override Guid GenericGuid => DecompilerConstants.LANGUAGE_IL;

	public override Guid UniqueGuid => DecompilerConstants.LANGUAGE_IL_ILSPY;

	public override string FileExtension => ".il";

	public ILDecompiler(ILDecompilerSettings langSettings)
		: this(langSettings, detectControlStructure: true)
	{
	}

	public ILDecompiler(ILDecompilerSettings langSettings, bool detectControlStructure)
	{
		this.langSettings = langSettings;
		this.detectControlStructure = detectControlStructure;
	}

	private ReflectionDisassembler CreateReflectionDisassembler(IDecompilerOutput output, DecompilationContext ctx, IMemberDef member)
	{
		return CreateReflectionDisassembler(output, ctx, member.Module);
	}

	private ReflectionDisassembler CreateReflectionDisassembler(IDecompilerOutput output, DecompilationContext ctx, ModuleDef ownerModule)
	{
		DisassemblerOptions disassemblerOptions = new DisassemblerOptions(langSettings.Settings.SettingsVersion, ctx.CancellationToken, ownerModule);
		if (langSettings.Settings.ShowILComments)
		{
			disassemblerOptions.GetOpCodeDocumentation = ILLanguageHelper.GetOpCodeDocumentation;
		}
		StringBuilder sb = new StringBuilder();
		if (langSettings.Settings.ShowXmlDocumentation)
		{
			disassemblerOptions.GetXmlDocComments = (IMemberRef a) => GetXmlDocComments(a, sb);
		}
		disassemblerOptions.CreateInstructionBytesReader = (MethodDef m) => InstructionBytesReader.Create(m, ctx.IsBodyModified != null && ctx.IsBodyModified(m));
		disassemblerOptions.ShowTokenAndRvaComments = langSettings.Settings.ShowTokenAndRvaComments;
		disassemblerOptions.ShowILBytes = langSettings.Settings.ShowILBytes;
		disassemblerOptions.SortMembers = langSettings.Settings.SortMembers;
		disassemblerOptions.ShowPdbInfo = langSettings.Settings.ShowPdbInfo;
		return new ReflectionDisassembler(output, detectControlStructure, disassemblerOptions);
	}

	private static IEnumerable<string> GetXmlDocComments(IMemberRef mr, StringBuilder sb)
	{
		if (mr == null || mr.Module == null)
		{
			yield break;
		}
		XmlDocumentationProvider xmlDocumentationProvider = XmlDocLoader.LoadDocumentation(mr.Module);
		if (xmlDocumentationProvider == null)
		{
			yield break;
		}
		string documentation = xmlDocumentationProvider.GetDocumentation(XmlDocKeyProvider.GetKey(mr, sb));
		if (string.IsNullOrEmpty(documentation))
		{
			yield break;
		}
		foreach (SubString? item in new XmlDocLine(documentation))
		{
			sb.Clear();
			if (item.HasValue)
			{
				sb.Append(' ');
				item.Value.WriteTo(sb);
			}
			yield return sb.ToString();
		}
	}

	public override void Decompile(MethodDef method, IDecompilerOutput output, DecompilationContext ctx)
	{
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, method);
		reflectionDisassembler.DisassembleMethod(method);
	}

	public override void Decompile(FieldDef field, IDecompilerOutput output, DecompilationContext ctx)
	{
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, field);
		reflectionDisassembler.DisassembleField(field);
	}

	public override void Decompile(PropertyDef property, IDecompilerOutput output, DecompilationContext ctx)
	{
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, property);
		reflectionDisassembler.DisassembleProperty(property);
		if (property.GetMethod != null)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(property.GetMethod);
		}
		if (property.SetMethod != null)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(property.SetMethod);
		}
		foreach (MethodDef otherMethod in property.OtherMethods)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(otherMethod);
		}
	}

	public override void Decompile(EventDef ev, IDecompilerOutput output, DecompilationContext ctx)
	{
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, ev);
		reflectionDisassembler.DisassembleEvent(ev);
		if (ev.AddMethod != null)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(ev.AddMethod);
		}
		if (ev.RemoveMethod != null)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(ev.RemoveMethod);
		}
		foreach (MethodDef otherMethod in ev.OtherMethods)
		{
			output.WriteLine();
			reflectionDisassembler.DisassembleMethod(otherMethod);
		}
	}

	public override void Decompile(TypeDef type, IDecompilerOutput output, DecompilationContext ctx)
	{
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, type);
		reflectionDisassembler.DisassembleType(type);
	}

	public override void Decompile(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		output.WriteLine("// " + asm.ManifestModule.Location, BoxedTextColor.Comment);
		PrintEntryPoint(asm.ManifestModule, output);
		output.WriteLine();
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, asm.ManifestModule);
		reflectionDisassembler.WriteAssemblyHeader(asm);
	}

	public override void Decompile(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		output.WriteLine("// " + mod.Location, BoxedTextColor.Comment);
		PrintEntryPoint(mod, output);
		output.WriteLine();
		ReflectionDisassembler reflectionDisassembler = CreateReflectionDisassembler(output, ctx, mod);
		output.WriteLine();
		reflectionDisassembler.WriteModuleHeader(mod);
	}

	protected override void TypeToString(IDecompilerOutput output, ITypeDefOrRef t, bool includeNamespace, IHasCustomAttribute attributeProvider = null)
	{
		t.WriteTo(output, includeNamespace ? ILNameSyntax.TypeName : ILNameSyntax.ShortTypeName);
	}

	public override void WriteToolTip(ITextColorWriter output, IMemberRef member, IHasCustomAttribute typeAttributes)
	{
		if (member is ITypeDefOrRef || !ILDecompilerUtils.Write(TextColorWriterToDecompilerOutput.Create(output), member))
		{
			base.WriteToolTip(output, member, typeAttributes);
		}
	}
}
