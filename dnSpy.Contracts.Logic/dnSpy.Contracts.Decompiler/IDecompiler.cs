using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnSpy.Contracts.Text;

namespace dnSpy.Contracts.Decompiler;

public interface IDecompiler
{
	DecompilerSettingsBase Settings { get; }

	MetadataTextColorProvider MetadataTextColorProvider { get; }

	string ContentTypeString { get; }

	string GenericNameUI { get; }

	string UniqueNameUI { get; }

	double OrderUI { get; }

	Guid GenericGuid { get; }

	Guid UniqueGuid { get; }

	string FileExtension { get; }

	string ProjectFileExtension { get; }

	void WriteName(ITextColorWriter output, TypeDef type);

	void WriteName(ITextColorWriter output, PropertyDef property, bool? isIndexer);

	void WriteType(ITextColorWriter output, ITypeDefOrRef type, bool includeNamespace, ParamDef pd = null);

	void Decompile(MethodDef method, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(PropertyDef property, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(FieldDef field, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(EventDef ev, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(TypeDef type, IDecompilerOutput output, DecompilationContext ctx);

	void DecompileNamespace(string @namespace, IEnumerable<TypeDef> types, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(AssemblyDef asm, IDecompilerOutput output, DecompilationContext ctx);

	void Decompile(ModuleDef mod, IDecompilerOutput output, DecompilationContext ctx);

	void WriteToolTip(ITextColorWriter output, IMemberRef member, IHasCustomAttribute typeAttributes);

	void WriteToolTip(ITextColorWriter output, ISourceVariable variable);

	void WriteNamespaceToolTip(ITextColorWriter output, string @namespace);

	void Write(ITextColorWriter output, IMemberRef member, FormatterOptions flags);

	void WriteCommentBegin(IDecompilerOutput output, bool addSpace);

	void WriteCommentEnd(IDecompilerOutput output, bool addSpace);

	bool ShowMember(IMemberRef member);

	bool CanDecompile(DecompilationType decompilationType);

	void Decompile(DecompilationType decompilationType, object data);
}
