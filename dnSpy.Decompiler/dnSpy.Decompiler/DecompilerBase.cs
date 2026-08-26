using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using dnlib.DotNet;
using dnlib.PE;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using dnSpy.Decompiler.CSharp;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler;

public abstract class DecompilerBase : IDecompiler
{
	protected const FormatterOptions DefaultFormatterOptions = FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues;

	public abstract string ContentTypeString { get; }

	public abstract string GenericNameUI { get; }

	public abstract string UniqueNameUI { get; }

	public abstract double OrderUI { get; }

	public abstract Guid GenericGuid { get; }

	public abstract Guid UniqueGuid { get; }

	public abstract DecompilerSettingsBase Settings { get; }

	public abstract string FileExtension { get; }

	public virtual string ProjectFileExtension => null;

	public virtual MetadataTextColorProvider MetadataTextColorProvider => CSharpMetadataTextColorProvider.Instance;

	public void WriteName(ITextColorWriter output, TypeDef type)
	{
		FormatTypeName(TextColorWriterToDecompilerOutput.Create(output), type);
	}

	public void WriteType(ITextColorWriter output, ITypeDefOrRef type, bool includeNamespace, ParamDef pd = null)
	{
		TypeToString(TextColorWriterToDecompilerOutput.Create(output), type, includeNamespace, pd);
	}

	public void WriteName(ITextColorWriter output, PropertyDef property, bool? isIndexer)
	{
		FormatPropertyName(TextColorWriterToDecompilerOutput.Create(output), property, isIndexer);
	}

	public virtual void Decompile(MethodDef method, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, TypeToString(method.DeclaringType, includeNamespace: true) + "." + method.Name);
	}

	public virtual void Decompile(PropertyDef property, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, TypeToString(property.DeclaringType, includeNamespace: true) + "." + property.Name);
	}

	public virtual void Decompile(FieldDef field, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, TypeToString(field.DeclaringType, includeNamespace: true) + "." + field.Name);
	}

	public virtual void Decompile(EventDef ev, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, TypeToString(ev.DeclaringType, includeNamespace: true) + "." + ev.Name);
	}

	public virtual void Decompile(TypeDef type, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, TypeToString(type, includeNamespace: true));
	}

	public virtual void DecompileNamespace(string @namespace, IEnumerable<TypeDef> types, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, string.IsNullOrEmpty(@namespace) ? string.Empty : IdentifierEscaper.Escape(@namespace));
		this.WriteCommentLine(output, string.Empty);
		this.WriteCommentLine(output, dnSpy_Decompiler_Resources.Decompile_Namespace_Types);
		this.WriteCommentLine(output, string.Empty);
		foreach (TypeDef type in types)
		{
			WriteCommentBegin(output, addSpace: true);
			output.Write(IdentifierEscaper.Escape(type.Name), type, DecompilerReferenceFlags.None, BoxedTextColor.Comment);
			WriteCommentEnd(output, addSpace: true);
			output.WriteLine();
		}
	}

	private static IPEImage TryGetPEImage(ModuleDef mod)
	{
		return (!(mod is ModuleDefMD moduleDefMD)) ? null : moduleDefMD.Metadata.PEImage;
	}

	protected void WriteAssembly(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		DecompileInternal(asm, output, ctx);
		output.WriteLine();
		PrintEntryPoint(asm.ManifestModule, output);
		IPEImage iPEImage = TryGetPEImage(asm.ManifestModule);
		if (iPEImage != null)
		{
			WriteTimestampComment(output, iPEImage);
		}
		output.WriteLine();
	}

	private void WriteTimestampComment(IDecompilerOutput output, IPEImage peImage)
	{
		WriteCommentBegin(output, addSpace: true);
		output.Write(dnSpy_Decompiler_Resources.Decompile_Timestamp, BoxedTextColor.Comment);
		output.Write(" ", BoxedTextColor.Comment);
		uint timeDateStamp = peImage.ImageNTHeaders.FileHeader.TimeDateStamp;
		if (timeDateStamp < 2147483648u && timeDateStamp != 0)
		{
			string arg = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeDateStamp).ToString(CultureInfo.CurrentUICulture.DateTimeFormat);
			output.Write($"{timeDateStamp:X8} ({arg})", BoxedTextColor.Comment);
		}
		else
		{
			output.Write(dnSpy_Decompiler_Resources.UnknownValue, BoxedTextColor.Comment);
			output.Write($" ({timeDateStamp:X8})", BoxedTextColor.Comment);
		}
		WriteCommentEnd(output, addSpace: true);
		output.WriteLine();
	}

	protected void WriteModule(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		DecompileInternal(mod, output, ctx);
		output.WriteLine();
		if (mod.Types.Count > 0)
		{
			WriteCommentBegin(output, addSpace: true);
			output.Write(dnSpy_Decompiler_Resources.Decompile_GlobalType + " ", BoxedTextColor.Comment);
			output.Write(IdentifierEscaper.Escape(mod.GlobalType.FullName), mod.GlobalType, DecompilerReferenceFlags.None, BoxedTextColor.Comment);
			output.WriteLine();
		}
		PrintEntryPoint(mod, output);
		this.WriteCommentLine(output, dnSpy_Decompiler_Resources.Decompile_Architecture + " " + GetPlatformDisplayName(mod));
		if (!mod.IsILOnly)
		{
			this.WriteCommentLine(output, dnSpy_Decompiler_Resources.Decompile_ThisAssemblyContainsUnmanagedCode);
		}
		string runtimeDisplayName = GetRuntimeDisplayName(mod);
		if (runtimeDisplayName != null)
		{
			this.WriteCommentLine(output, dnSpy_Decompiler_Resources.Decompile_Runtime + " " + runtimeDisplayName);
		}
		IPEImage iPEImage = TryGetPEImage(mod);
		if (iPEImage != null)
		{
			WriteTimestampComment(output, iPEImage);
		}
		output.WriteLine();
	}

	public virtual void Decompile(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		DecompileInternal(asm, output, ctx);
	}

	public virtual void Decompile(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		DecompileInternal(mod, output, ctx);
	}

	private void DecompileInternal(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, asm.ManifestModule.Location);
		if (asm.IsContentTypeWindowsRuntime)
		{
			this.WriteCommentLine(output, string.Concat(asm.Name, " [WinRT]"));
		}
		else
		{
			this.WriteCommentLine(output, asm.FullName);
		}
	}

	private void DecompileInternal(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx)
	{
		this.WriteCommentLine(output, mod.Location);
		this.WriteCommentLine(output, mod.Name);
	}

	protected void PrintEntryPoint(ModuleDef mod, IDecompilerOutput output)
	{
		object entryPoint = GetEntryPoint(mod);
		if (entryPoint is uint)
		{
			this.WriteCommentLine(output, string.Format(dnSpy_Decompiler_Resources.Decompile_NativeEntryPoint, (uint)entryPoint));
		}
		else if (entryPoint is MethodDef methodDef)
		{
			WriteCommentBegin(output, addSpace: true);
			output.Write(dnSpy_Decompiler_Resources.Decompile_EntryPoint + " ", BoxedTextColor.Comment);
			if (methodDef.DeclaringType != null)
			{
				output.Write(IdentifierEscaper.Escape(methodDef.DeclaringType.FullName), methodDef.DeclaringType, DecompilerReferenceFlags.None, BoxedTextColor.Comment);
				output.Write(".", BoxedTextColor.Comment);
			}
			output.Write(IdentifierEscaper.Escape(methodDef.Name), methodDef, DecompilerReferenceFlags.None, BoxedTextColor.Comment);
			WriteCommentEnd(output, addSpace: true);
			output.WriteLine();
		}
	}

	private object GetEntryPoint(ModuleDef module)
	{
		int num = 1;
		int num2 = 0;
		while (module != null && num2 < num)
		{
			RVA nativeEntryPoint = module.NativeEntryPoint;
			if (nativeEntryPoint != 0)
			{
				return (uint)nativeEntryPoint;
			}
			IManagedEntryPoint managedEntryPoint = module.ManagedEntryPoint;
			if (managedEntryPoint is MethodDef result)
			{
				return result;
			}
			FileDef file = managedEntryPoint as FileDef;
			if (file == null)
			{
				return null;
			}
			AssemblyDef assembly = module.Assembly;
			if (assembly == null)
			{
				return null;
			}
			num = assembly.Modules.Count;
			module = assembly.Modules.FirstOrDefault((ModuleDef m) => File.Exists(m.Location) && StringComparer.OrdinalIgnoreCase.Equals(Path.GetFileName(m.Location), file.Name));
			num2++;
		}
		return null;
	}

	protected void WriteCommentLineDeclaringType(IDecompilerOutput output, IMemberDef member)
	{
		WriteCommentBegin(output, addSpace: true);
		output.Write(TypeToString(member.DeclaringType, includeNamespace: true), member.DeclaringType, DecompilerReferenceFlags.None, BoxedTextColor.Comment);
		WriteCommentEnd(output, addSpace: true);
		output.WriteLine();
	}

	public virtual void WriteCommentBegin(IDecompilerOutput output, bool addSpace)
	{
		if (addSpace)
		{
			output.Write("// ", BoxedTextColor.Comment);
		}
		else
		{
			output.Write("//", BoxedTextColor.Comment);
		}
	}

	public virtual void WriteCommentEnd(IDecompilerOutput output, bool addSpace)
	{
	}

	private string TypeToString(ITypeDefOrRef type, bool includeNamespace, IHasCustomAttribute typeAttributes = null)
	{
		StringBuilderDecompilerOutput stringBuilderDecompilerOutput = new StringBuilderDecompilerOutput();
		TypeToString(stringBuilderDecompilerOutput, type, includeNamespace, typeAttributes);
		return stringBuilderDecompilerOutput.ToString();
	}

	protected virtual void TypeToString(IDecompilerOutput output, ITypeDefOrRef type, bool includeNamespace, IHasCustomAttribute typeAttributes = null)
	{
		if (type != null)
		{
			if (includeNamespace)
			{
				output.Write(IdentifierEscaper.Escape(type.FullName), MetadataTextColorProvider.GetColor(type));
			}
			else
			{
				output.Write(IdentifierEscaper.Escape(type.Name), MetadataTextColorProvider.GetColor(type));
			}
		}
	}

	public virtual void WriteToolTip(ITextColorWriter output, IMemberRef member, IHasCustomAttribute typeAttributes)
	{
		new CSharpFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteToolTip(member);
	}

	public virtual void WriteToolTip(ITextColorWriter output, ISourceVariable variable)
	{
		new CSharpFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteToolTip(variable);
	}

	public virtual void WriteNamespaceToolTip(ITextColorWriter output, string @namespace)
	{
		new CSharpFormatter(output, FormatterOptions.Default | FormatterOptions.ShowParameterLiteralValues, null).WriteNamespaceToolTip(@namespace);
	}

	public virtual void Write(ITextColorWriter output, IMemberRef member, FormatterOptions flags)
	{
		new CSharpFormatter(output, flags, null).Write(member);
	}

	protected virtual void FormatPropertyName(IDecompilerOutput output, PropertyDef property, bool? isIndexer = null)
	{
		if (property == null)
		{
			throw new ArgumentNullException("property");
		}
		output.Write(IdentifierEscaper.Escape(property.Name), MetadataTextColorProvider.GetColor(property));
	}

	protected virtual void FormatTypeName(IDecompilerOutput output, TypeDef type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		output.Write(IdentifierEscaper.Escape(type.Name), MetadataTextColorProvider.GetColor(type));
	}

	public virtual bool ShowMember(IMemberRef member)
	{
		return true;
	}

	protected static string GetPlatformDisplayName(ModuleDef module)
	{
		return TargetFrameworkUtils.GetArchString(module);
	}

	protected static string GetRuntimeDisplayName(ModuleDef module)
	{
		return TargetFrameworkInfo.Create(module).ToString();
	}

	public virtual bool CanDecompile(DecompilationType decompilationType)
	{
		return false;
	}

	public virtual void Decompile(DecompilationType decompilationType, object data)
	{
		throw new NotImplementedException();
	}
}
