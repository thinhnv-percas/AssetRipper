using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Pdb;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Disassembler;

public static class DisassemblerHelpers
{
	private const int OPERAND_ALIGNMENT = 10;

	private static readonly string[] spaces;

	private static readonly HashSet<string> ilKeywords;

	private const int MAX_CONVERTTYPE_DEPTH = 50;

	private static StringBuilder cachedStringBuilder;

	static DisassemblerHelpers()
	{
		ilKeywords = BuildKeywordList("abstract", "algorithm", "alignment", "ansi", "any", "arglist", "array", "as", "assembly", "assert", "at", "auto", "autochar", "beforefieldinit", "blob", "blob_object", "bool", "brnull", "brnull.s", "brzero", "brzero.s", "bstr", "bytearray", "byvalstr", "callmostderived", "carray", "catch", "cdecl", "cf", "char", "cil", "class", "clsid", "const", "currency", "custom", "date", "decimal", "default", "demand", "deny", "endmac", "enum", "error", "explicit", "extends", "extern", "false", "famandassem", "family", "famorassem", "fastcall", "fault", "field", "filetime", "filter", "final", "finally", "fixed", "float", "float32", "float64", "forwardref", "fromunmanaged", "handler", "hidebysig", "hresult", "idispatch", "il", "illegal", "implements", "implicitcom", "implicitres", "import", "in", "inheritcheck", "init", "initonly", "instance", "int", "int16", "int32", "int64", "int8", "interface", "internalcall", "iunknown", "lasterr", "lcid", "linkcheck", "literal", "localloc", "lpstr", "lpstruct", "lptstr", "lpvoid", "lpwstr", "managed", "marshal", "method", "modopt", "modreq", "native", "nested", "newslot", "noappdomain", "noinlining", "nomachine", "nomangle", "nometadata", "noncasdemand", "noncasinheritance", "noncaslinkdemand", "noprocess", "not", "not_in_gc_heap", "notremotable", "notserialized", "null", "nullref", "object", "objectref", "opt", "optil", "out", "permitonly", "pinned", "pinvokeimpl", "prefix1", "prefix2", "prefix3", "prefix4", "prefix5", "prefix6", "prefix7", "prefixref", "prejitdeny", "prejitgrant", "preservesig", "private", "privatescope", "protected", "public", "record", "refany", "reqmin", "reqopt", "reqrefuse", "reqsecobj", "request", "retval", "rtspecialname", "runtime", "safearray", "sealed", "sequential", "serializable", "special", "specialname", "static", "stdcall", "storage", "stored_object", "stream", "streamed_object", "string", "struct", "synchronized", "syschar", "sysstring", "tbstr", "thiscall", "tls", "to", "true", "typedref", "unicode", "unmanaged", "unmanagedexp", "unsigned", "unused", "userdefined", "value", "valuetype", "vararg", "variant", "vector", "virtual", "void", "wchar", "winapi", "with", "wrapper", "property", "type", "flags", "callconv", "strict");
		cachedStringBuilder = new StringBuilder();
		spaces = new string[10];
		for (int i = 0; i < spaces.Length; i++)
		{
			spaces[i] = new string(' ', i);
		}
	}

	public static void WriteOffsetReference(IDecompilerOutput writer, Instruction instruction, MethodDef method, object data = null)
	{
		if (data == null)
		{
			data = BoxedTextColor.Label;
		}
		object reference = ((instruction == null) ? null : ((method == null) ? ((object)instruction) : ((object)new InstructionReference(method, instruction))));
		writer.Write(DnlibExtensions.OffsetToString(instruction.GetOffset()), reference, DecompilerReferenceFlags.None, data);
	}

	public static void WriteTo(this ExceptionHandler exceptionHandler, IDecompilerOutput writer, MethodDef method)
	{
		writer.Write("Try", BoxedTextColor.Keyword);
		writer.Write(" ", BoxedTextColor.Text);
		WriteOffsetReference(writer, exceptionHandler.TryStart, method);
		writer.Write("-", BoxedTextColor.Operator);
		WriteOffsetReference(writer, exceptionHandler.TryEnd, method);
		writer.Write(" ", BoxedTextColor.Text);
		writer.Write(exceptionHandler.HandlerType.ToString(), BoxedTextColor.Keyword);
		if (exceptionHandler.FilterStart != null)
		{
			writer.Write(" ", BoxedTextColor.Text);
			WriteOffsetReference(writer, exceptionHandler.FilterStart, method);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("handler", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		if (exceptionHandler.CatchType != null)
		{
			writer.Write(" ", BoxedTextColor.Text);
			exceptionHandler.CatchType.WriteTo(writer);
		}
		writer.Write(" ", BoxedTextColor.Text);
		WriteOffsetReference(writer, exceptionHandler.HandlerStart, method);
		writer.Write("-", BoxedTextColor.Operator);
		WriteOffsetReference(writer, exceptionHandler.HandlerEnd, method);
	}

	internal static void WriteTo(this Instruction instruction, IDecompilerOutput writer, DisassemblerOptions options, uint baseRva, long baseOffs, IInstructionBytesReader byteReader, MethodDef method, InstructionOperandConverter instructionOperandConverter, PdbAsyncMethodCustomDebugInfo pdbAsyncInfo, out int startLocation)
	{
		if (options.ShowPdbInfo)
		{
			SequencePoint sequencePoint = instruction.SequencePoint;
			if (sequencePoint != null)
			{
				writer.Write("/* (", BoxedTextColor.Comment);
				if (sequencePoint.StartLine == 16707566)
				{
					writer.Write("hidden", BoxedTextColor.Comment);
				}
				else
				{
					writer.Write(sequencePoint.StartLine.ToString(), BoxedTextColor.Comment);
					writer.Write(",", BoxedTextColor.Comment);
					writer.Write(sequencePoint.StartColumn.ToString(), BoxedTextColor.Comment);
				}
				writer.Write(")-(", BoxedTextColor.Comment);
				if (sequencePoint.EndLine == 16707566)
				{
					writer.Write("hidden", BoxedTextColor.Comment);
				}
				else
				{
					writer.Write(sequencePoint.EndLine.ToString(), BoxedTextColor.Comment);
					writer.Write(",", BoxedTextColor.Comment);
					writer.Write(sequencePoint.EndColumn.ToString(), BoxedTextColor.Comment);
				}
				writer.Write(") ", BoxedTextColor.Comment);
				writer.Write(sequencePoint.Document.Url, BoxedTextColor.Comment);
				writer.Write(" */", BoxedTextColor.Comment);
				writer.WriteLine();
			}
			if (pdbAsyncInfo != null)
			{
				if (pdbAsyncInfo.CatchHandlerInstruction == instruction)
				{
					writer.WriteLine("/* Catch Handler */", BoxedTextColor.Comment);
				}
				IList<PdbAsyncStepInfo> stepInfos = pdbAsyncInfo.StepInfos;
				for (int i = 0; i < stepInfos.Count; i++)
				{
					PdbAsyncStepInfo pdbAsyncStepInfo = stepInfos[i];
					if (pdbAsyncStepInfo.YieldInstruction == instruction)
					{
						writer.WriteLine("/* Yield Instruction */", BoxedTextColor.Comment);
					}
					if (pdbAsyncStepInfo.BreakpointInstruction == instruction)
					{
						writer.WriteLine("/* Resume Instruction */", BoxedTextColor.Comment);
					}
				}
			}
		}
		if (options != null && (options.ShowTokenAndRvaComments || options.ShowILBytes))
		{
			writer.Write("/* ", BoxedTextColor.Comment);
			bool flag = false;
			if (options.ShowTokenAndRvaComments)
			{
				ulong num = (ulong)(baseOffs + instruction.Offset);
				string text = $"0x{num:X8}";
				if (byteReader != null && byteReader.IsOriginalBytes)
				{
					writer.Write(text, new AddressReference((options.OwnerModule == null) ? null : options.OwnerModule.Location, isRva: false, num, (ulong)instruction.GetSize()), DecompilerReferenceFlags.None, BoxedTextColor.Comment);
				}
				else
				{
					writer.Write(text, BoxedTextColor.Comment);
				}
				flag = true;
			}
			if (options.ShowILBytes)
			{
				if (flag)
				{
					writer.Write(" ", BoxedTextColor.Comment);
				}
				if (byteReader == null)
				{
					writer.Write("??", BoxedTextColor.Comment);
				}
				else
				{
					int size = instruction.GetSize();
					for (int j = 0; j < size; j++)
					{
						int num2 = byteReader.ReadByte();
						if (num2 < 0)
						{
							writer.Write("??", BoxedTextColor.Comment);
						}
						else
						{
							writer.Write($"{num2:X2}", BoxedTextColor.Comment);
						}
					}
					for (int k = size; k < 6; k++)
					{
						writer.Write("  ", BoxedTextColor.Comment);
					}
				}
			}
			writer.Write(" */", BoxedTextColor.Comment);
			writer.Write(" ", BoxedTextColor.Text);
		}
		startLocation = writer.NextPosition;
		writer.Write(DnlibExtensions.OffsetToString(instruction.GetOffset()), new InstructionReference(method, instruction), DecompilerReferenceFlags.Definition, BoxedTextColor.Label);
		writer.Write(":", BoxedTextColor.Punctuation);
		writer.Write(" ", BoxedTextColor.Text);
		writer.Write(instruction.OpCode.Name, instruction.OpCode, DecompilerReferenceFlags.None, BoxedTextColor.OpCode);
		if (ShouldHaveOperand(instruction))
		{
			int num3 = 10 - instruction.OpCode.Name.Length;
			if (num3 <= 0)
			{
				num3 = 1;
			}
			writer.Write(spaces[num3], BoxedTextColor.Text);
			if (instruction.OpCode == OpCodes.Ldtoken)
			{
				IMemberRef memberRef = instruction.Operand as IMemberRef;
				if (memberRef != null && memberRef.IsMethod)
				{
					writer.Write("method", BoxedTextColor.Keyword);
					writer.Write(" ", BoxedTextColor.Text);
				}
				else if (memberRef != null && memberRef.IsField)
				{
					writer.Write("field", BoxedTextColor.Keyword);
					writer.Write(" ", BoxedTextColor.Text);
				}
			}
			WriteOperand(writer, instructionOperandConverter?.Convert(instruction.Operand) ?? instruction.Operand, method);
		}
		if (options != null && options.GetOpCodeDocumentation != null)
		{
			string text2 = options.GetOpCodeDocumentation(instruction.OpCode);
			if (text2 != null)
			{
				writer.Write("\t", BoxedTextColor.Text);
				writer.Write("// " + text2, BoxedTextColor.Comment);
			}
		}
	}

	private static bool ShouldHaveOperand(Instruction instr)
	{
		switch (instr.OpCode.OperandType)
		{
		case OperandType.InlineBrTarget:
		case OperandType.InlineField:
		case OperandType.InlineI:
		case OperandType.InlineI8:
		case OperandType.InlineMethod:
		case OperandType.InlineR:
		case OperandType.InlineSig:
		case OperandType.InlineString:
		case OperandType.InlineSwitch:
		case OperandType.InlineTok:
		case OperandType.InlineType:
		case OperandType.InlineVar:
		case OperandType.ShortInlineBrTarget:
		case OperandType.ShortInlineI:
		case OperandType.ShortInlineR:
		case OperandType.ShortInlineVar:
			return true;
		default:
			return false;
		}
	}

	private static void WriteLabelList(IDecompilerOutput writer, IList<Instruction> instructions, MethodDef method)
	{
		BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		for (int i = 0; i < instructions.Count; i++)
		{
			if (i != 0)
			{
				writer.Write(",", BoxedTextColor.Punctuation);
				writer.Write(" ", BoxedTextColor.Text);
			}
			WriteOffsetReference(writer, instructions[i], method);
		}
		bracePairHelper.Write(")");
	}

	private static string ToInvariantCultureString(object value)
	{
		if (value == null)
		{
			return "<<<NULL>>>";
		}
		if (!(value is IConvertible convertible))
		{
			return value.ToString();
		}
		return convertible.ToString(CultureInfo.InvariantCulture);
	}

	public static void WriteMethodTo(this IMethod method, IDecompilerOutput writer)
	{
		Write(writer, null, method);
	}

	public static void Write(this IDecompilerOutput writer, MethodSig sig, IMethod method = null)
	{
		if (sig == null && method != null)
		{
			sig = method.MethodSig;
		}
		if (sig == null)
		{
			return;
		}
		if (sig.ExplicitThis)
		{
			writer.Write("instance", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("explicit", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		else if (sig.HasThis)
		{
			writer.Write("instance", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		sig.RetType.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
		writer.Write(" ", BoxedTextColor.Text);
		if (method != null)
		{
			if (method.DeclaringType != null)
			{
				method.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName);
				writer.Write("::", BoxedTextColor.Operator);
			}
			if (method is MethodDef { IsCompilerControlled: not false })
			{
				writer.Write(Escape(string.Concat(method.Name, "$PST", method.MDToken.ToInt32().ToString("X8"))), method, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(method));
			}
			else
			{
				writer.Write(Escape(method.Name), method, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(method));
			}
		}
		if (method is MethodSpec { GenericInstMethodSig: not null } methodSpec)
		{
			BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "<", CodeBracesRangeFlags.BraceKind_AngleBrackets);
			for (int i = 0; i < methodSpec.GenericInstMethodSig.GenericArguments.Count; i++)
			{
				if (i > 0)
				{
					writer.Write(",", BoxedTextColor.Punctuation);
					writer.Write(" ", BoxedTextColor.Text);
				}
				methodSpec.GenericInstMethodSig.GenericArguments[i].WriteTo(writer);
			}
			bracePairHelper.Write(">");
		}
		BracePairHelper bracePairHelper2 = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		IList<TypeSig> parameters = sig.GetParameters();
		for (int j = 0; j < parameters.Count; j++)
		{
			if (j > 0)
			{
				writer.Write(",", BoxedTextColor.Punctuation);
				writer.Write(" ", BoxedTextColor.Text);
			}
			parameters[j].WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
		}
		bracePairHelper2.Write(")");
	}

	public static void WriteTo(this MethodSig sig, IDecompilerOutput writer)
	{
		if (sig.ExplicitThis)
		{
			writer.Write("instance", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("explicit", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		else if (sig.HasThis)
		{
			writer.Write("instance", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		sig.RetType.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
		writer.Write(" ", BoxedTextColor.Text);
		BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		IList<TypeSig> parameters = sig.GetParameters();
		for (int i = 0; i < parameters.Count; i++)
		{
			if (i > 0)
			{
				writer.Write(",", BoxedTextColor.Punctuation);
				writer.Write(" ", BoxedTextColor.Text);
			}
			parameters[i].WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
		}
		bracePairHelper.Write(")");
	}

	public static void WriteFieldTo(this IField field, IDecompilerOutput writer)
	{
		if (field != null && field.FieldSig != null)
		{
			field.FieldSig.Type.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
			writer.Write(" ", BoxedTextColor.Text);
			field.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName);
			writer.Write("::", BoxedTextColor.Operator);
			writer.Write(Escape(field.Name), field, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(field));
		}
	}

	private static bool IsValidIdentifierCharacter(char c)
	{
		if (c != '_' && c != '$' && c != '@' && c != '?')
		{
			return c == '`';
		}
		return true;
	}

	private static bool IsValidIdentifier(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return false;
		}
		if (!char.IsLetter(identifier[0]) && !IsValidIdentifierCharacter(identifier[0]))
		{
			if (!(identifier == ".ctor"))
			{
				return identifier == ".cctor";
			}
			return true;
		}
		for (int i = 1; i < identifier.Length; i++)
		{
			if (!char.IsLetterOrDigit(identifier[i]) && !IsValidIdentifierCharacter(identifier[i]) && identifier[i] != '.')
			{
				return false;
			}
		}
		return true;
	}

	private static HashSet<string> BuildKeywordList(params string[] keywords)
	{
		HashSet<string> hashSet = new HashSet<string>(keywords);
		FieldInfo[] fields = typeof(OpCodes).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!(fieldInfo.FieldType != typeof(OpCode)))
			{
				OpCode opCode = (OpCode)fieldInfo.GetValue(null);
				if (opCode.OpCodeType != OpCodeType.Nternal)
				{
					hashSet.Add(opCode.Name);
				}
			}
		}
		return hashSet;
	}

	internal static bool MustEscape(string identifier)
	{
		if (IsValidIdentifier(identifier))
		{
			return ilKeywords.Contains(identifier);
		}
		return true;
	}

	public static string Escape(string identifier)
	{
		if (!MustEscape(identifier))
		{
			return IdentifierEscaper.Truncate(identifier);
		}
		return "'" + IdentifierEscaper.Truncate(TextWriterTokenWriter.ConvertString(identifier).Replace("'", "\\'")) + "'";
	}

	public static void WriteTo(this TypeSig type, IDecompilerOutput writer, ILNameSyntax syntax = ILNameSyntax.Signature)
	{
		type.WriteTo(writer, syntax, 0);
	}

	public static void WriteTo(this TypeSig type, IDecompilerOutput writer, ILNameSyntax syntax, int depth)
	{
		if (depth++ > 50)
		{
			return;
		}
		ILNameSyntax syntax2 = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
		if (type is PinnedSig)
		{
			((PinnedSig)type).Next.WriteTo(writer, syntax2, depth);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("pinned", BoxedTextColor.Keyword);
		}
		else if (type is ArraySig)
		{
			ArraySig arraySig = (ArraySig)type;
			arraySig.Next.WriteTo(writer, syntax2, depth);
			BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
			for (int i = 0; i < arraySig.Rank; i++)
			{
				if (i != 0)
				{
					writer.Write(",", BoxedTextColor.Punctuation);
					writer.Write(" ", BoxedTextColor.Text);
				}
				int? num = ((i < arraySig.LowerBounds.Count) ? new int?(arraySig.LowerBounds[i]) : ((int?)null));
				uint? num2 = ((i < arraySig.Sizes.Count) ? new uint?(arraySig.Sizes[i]) : ((uint?)null));
				if (num.HasValue)
				{
					writer.Write(num.ToString(), BoxedTextColor.Number);
					if (num2.HasValue)
					{
						writer.Write("..", BoxedTextColor.Operator);
						writer.Write((num.Value + (int)num2.Value - 1).ToString(), BoxedTextColor.Number);
					}
					else
					{
						writer.Write("...", BoxedTextColor.Operator);
					}
				}
			}
			bracePairHelper.Write("]");
		}
		else if (type is SZArraySig)
		{
			SZArraySig sZArraySig = (SZArraySig)type;
			sZArraySig.Next.WriteTo(writer, syntax2, depth);
			BracePairHelper.Create(writer, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets).Write("]");
		}
		else if (type is GenericSig)
		{
			if (((GenericSig)type).IsMethodVar)
			{
				writer.Write("!!", BoxedTextColor.Operator);
			}
			else
			{
				writer.Write("!", BoxedTextColor.Operator);
			}
			string typeName = type.TypeName;
			if (string.IsNullOrEmpty(typeName) || typeName[0] == '!' || syntax == ILNameSyntax.SignatureNoNamedTypeParameters)
			{
				writer.Write(((GenericSig)type).Number.ToString(), BoxedTextColor.Number);
			}
			else
			{
				writer.Write(Escape(typeName), CSharpMetadataTextColorProvider.Instance.GetColor(type));
			}
		}
		else if (type is ByRefSig)
		{
			((ByRefSig)type).Next.WriteTo(writer, syntax2, depth);
			writer.Write("&", BoxedTextColor.Operator);
		}
		else if (type is PtrSig)
		{
			((PtrSig)type).Next.WriteTo(writer, syntax2, depth);
			writer.Write("*", BoxedTextColor.Operator);
		}
		else if (type is GenericInstSig)
		{
			((GenericInstSig)type).GenericType.WriteTo(writer, syntax2, depth);
			BracePairHelper bracePairHelper2 = BracePairHelper.Create(writer, "<", CodeBracesRangeFlags.BraceKind_AngleBrackets);
			IList<TypeSig> genericArguments = ((GenericInstSig)type).GenericArguments;
			for (int j = 0; j < genericArguments.Count; j++)
			{
				if (j > 0)
				{
					writer.Write(",", BoxedTextColor.Punctuation);
					writer.Write(" ", BoxedTextColor.Text);
				}
				genericArguments[j].WriteTo(writer, syntax2, depth);
			}
			bracePairHelper2.Write(">");
		}
		else if (type is CModOptSig)
		{
			((ModifierSig)type).Next.WriteTo(writer, syntax, depth);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("modopt", BoxedTextColor.Keyword);
			BracePairHelper bracePairHelper3 = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
			((ModifierSig)type).Modifier.WriteTo(writer, ILNameSyntax.TypeName, depth);
			bracePairHelper3.Write(")");
			writer.Write(" ", BoxedTextColor.Text);
		}
		else if (type is CModReqdSig)
		{
			((ModifierSig)type).Next.WriteTo(writer, syntax, depth);
			writer.Write(" ", BoxedTextColor.Text);
			writer.Write("modreq", BoxedTextColor.Keyword);
			BracePairHelper bracePairHelper4 = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
			((ModifierSig)type).Modifier.WriteTo(writer, ILNameSyntax.TypeName, depth);
			bracePairHelper4.Write(")");
			writer.Write(" ", BoxedTextColor.Text);
		}
		else if (type is TypeDefOrRefSig)
		{
			((TypeDefOrRefSig)type).TypeDefOrRef.WriteTo(writer, syntax, depth);
		}
		else if (type is FnPtrSig)
		{
			type.ToTypeDefOrRef().WriteTo(writer, syntax, depth);
		}
	}

	public static void WriteTo(this ITypeDefOrRef type, IDecompilerOutput writer, ILNameSyntax syntax = ILNameSyntax.Signature)
	{
		type.WriteTo(writer, syntax, 0);
	}

	public static void WriteTo(this ITypeDefOrRef type, IDecompilerOutput writer, ILNameSyntax syntax, int depth)
	{
		if (depth++ > 50 || type == null)
		{
			return;
		}
		TypeSpec typeSpec = type as TypeSpec;
		if (typeSpec != null && !(typeSpec.TypeSig is FnPtrSig))
		{
			((TypeSpec)type).TypeSig.WriteTo(writer, syntax, depth);
			return;
		}
		string text = type.FullName;
		string identifier = type.Name.String;
		if (typeSpec != null)
		{
			FnPtrSig sig = typeSpec.TypeSig as FnPtrSig;
			text = DnlibExtensions.GetFnPtrFullName(sig);
			identifier = DnlibExtensions.GetFnPtrName(sig);
		}
		TypeSig typeSig = null;
		string text2 = (type.DefinitionAssembly.IsCorLib() ? PrimitiveTypeName(text, type.Module, out typeSig) : null);
		switch (syntax)
		{
		case ILNameSyntax.ShortTypeName:
			if (text2 != null)
			{
				WriteKeyword(writer, text2, typeSig.ToTypeDefOrRef());
			}
			else
			{
				writer.Write(Escape(identifier), type, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(type));
			}
			return;
		case ILNameSyntax.Signature:
		case ILNameSyntax.SignatureNoNamedTypeParameters:
			if (text2 != null)
			{
				WriteKeyword(writer, text2, typeSig.ToTypeDefOrRef());
				return;
			}
			break;
		}
		if (syntax == ILNameSyntax.Signature || syntax == ILNameSyntax.SignatureNoNamedTypeParameters)
		{
			writer.Write(DnlibExtensions.IsValueType(type) ? "valuetype" : "class", BoxedTextColor.Keyword);
			writer.Write(" ", BoxedTextColor.Text);
		}
		if (type.DeclaringType != null)
		{
			type.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName, depth);
			writer.Write("/", BoxedTextColor.Operator);
			writer.Write(Escape(identifier), type, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(type));
			return;
		}
		if (!(type is TypeDef) && type.Scope != null && !(type is TypeSpec))
		{
			BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
			writer.Write(Escape(type.Scope.GetScopeName()), type.Scope, DecompilerReferenceFlags.None, BoxedTextColor.ILModule);
			bracePairHelper.Write("]");
		}
		if (typeSpec != null || MustEscape(text))
		{
			writer.Write(Escape(text), type, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(type));
			return;
		}
		WriteNamespace(writer, type.Namespace, type.DefinitionAssembly);
		if (!string.IsNullOrEmpty(type.Namespace))
		{
			writer.Write(".", BoxedTextColor.Operator);
		}
		writer.Write(IdentifierEscaper.Escape(type.Name), type, DecompilerReferenceFlags.None, CSharpMetadataTextColorProvider.Instance.GetColor(type));
	}

	internal static void WriteNamespace(IDecompilerOutput writer, string ns, IAssembly nsAsm)
	{
		StringBuilder stringBuilder = Interlocked.CompareExchange(ref cachedStringBuilder, null, cachedStringBuilder) ?? new StringBuilder();
		stringBuilder.Clear();
		string[] array = ns.Split('.');
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append('.');
				writer.Write(".", BoxedTextColor.Operator);
			}
			string text = array[i];
			stringBuilder.Append(text);
			if (!string.IsNullOrEmpty(text))
			{
				NamespaceReference reference = new NamespaceReference(nsAsm, stringBuilder.ToString());
				writer.Write(IdentifierEscaper.Escape(text), reference, DecompilerReferenceFlags.None, BoxedTextColor.Namespace);
			}
		}
		if (stringBuilder.Capacity <= 1000)
		{
			cachedStringBuilder = stringBuilder;
		}
	}

	internal static void WriteKeyword(IDecompilerOutput writer, string name, ITypeDefOrRef tdr)
	{
		string[] array = name.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0)
			{
				writer.Write(" ", BoxedTextColor.Text);
			}
			if (tdr != null)
			{
				writer.Write(array[i], tdr, DecompilerReferenceFlags.None, BoxedTextColor.Keyword);
			}
			else
			{
				writer.Write(array[i], BoxedTextColor.Keyword);
			}
		}
	}

	public static void WriteOperand(IDecompilerOutput writer, object operand, MethodDef method = null)
	{
		if (operand is Instruction instruction)
		{
			WriteOffsetReference(writer, instruction, method);
		}
		else if (operand is IList<Instruction> instructions)
		{
			WriteLabelList(writer, instructions, method);
		}
		else if (operand is SourceLocal sourceLocal)
		{
			writer.Write(Escape(sourceLocal.Name), sourceLocal, DecompilerReferenceFlags.None, BoxedTextColor.Local);
		}
		else if (operand is Parameter parameter)
		{
			if (string.IsNullOrEmpty(parameter.Name))
			{
				if (parameter.IsHiddenThisParameter)
				{
					writer.Write("<hidden-this>", parameter, DecompilerReferenceFlags.None, BoxedTextColor.Parameter);
				}
				else
				{
					writer.Write(parameter.MethodSigIndex.ToString(), parameter, DecompilerReferenceFlags.None, BoxedTextColor.Parameter);
				}
			}
			else
			{
				writer.Write(Escape(parameter.Name), parameter, DecompilerReferenceFlags.None, BoxedTextColor.Parameter);
			}
		}
		else if (operand is MemberRef memberRef)
		{
			if (memberRef.IsMethodRef)
			{
				memberRef.WriteMethodTo(writer);
			}
			else
			{
				memberRef.WriteFieldTo(writer);
			}
		}
		else if (operand is MethodDef method2)
		{
			method2.WriteMethodTo(writer);
		}
		else if (operand is FieldDef field)
		{
			field.WriteFieldTo(writer);
		}
		else if (operand is ITypeDefOrRef type)
		{
			type.WriteTo(writer, ILNameSyntax.TypeName);
		}
		else if (operand is IMethod method3)
		{
			method3.WriteMethodTo(writer);
		}
		else if (operand is MethodSig sig)
		{
			sig.WriteTo(writer);
		}
		else if (operand is string str)
		{
			int nextPosition = writer.NextPosition;
			writer.Write("\"" + TextWriterTokenWriter.ConvertString(str) + "\"", BoxedTextColor.String);
			int nextPosition2 = writer.NextPosition;
			writer.AddBracePair(new TextSpan(nextPosition, 1), new TextSpan(nextPosition2 - 1, 1), CodeBracesRangeFlags.BraceKind_DoubleQuotes);
		}
		else if (operand is char)
		{
			writer.Write(((int)(char)operand).ToString(), BoxedTextColor.Number);
		}
		else if (operand is float num)
		{
			if (num == 0f)
			{
				if (1f / num == float.NegativeInfinity)
				{
					writer.Write("-0.0", BoxedTextColor.Number);
				}
				else
				{
					writer.Write("0.0", BoxedTextColor.Number);
				}
			}
			else if (float.IsInfinity(num) || float.IsNaN(num))
			{
				byte[] bytes = BitConverter.GetBytes(num);
				BracePairHelper bracePairHelper = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				for (int i = 0; i < bytes.Length; i++)
				{
					if (i > 0)
					{
						writer.Write(" ", BoxedTextColor.Text);
					}
					writer.Write(bytes[i].ToString("X2"), BoxedTextColor.Number);
				}
				bracePairHelper.Write(")");
			}
			else
			{
				writer.Write(num.ToString("R", CultureInfo.InvariantCulture), BoxedTextColor.Number);
			}
		}
		else if (operand is double num2)
		{
			if (num2 == 0.0)
			{
				if (1.0 / num2 == double.NegativeInfinity)
				{
					writer.Write("-0.0", BoxedTextColor.Number);
				}
				else
				{
					writer.Write("0.0", BoxedTextColor.Number);
				}
			}
			else if (double.IsInfinity(num2) || double.IsNaN(num2))
			{
				byte[] bytes2 = BitConverter.GetBytes(num2);
				BracePairHelper bracePairHelper2 = BracePairHelper.Create(writer, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				for (int j = 0; j < bytes2.Length; j++)
				{
					if (j > 0)
					{
						writer.Write(" ", BoxedTextColor.Text);
					}
					writer.Write(bytes2[j].ToString("X2"), BoxedTextColor.Number);
				}
				bracePairHelper2.Write(")");
			}
			else
			{
				writer.Write(num2.ToString("R", CultureInfo.InvariantCulture), BoxedTextColor.Number);
			}
		}
		else if (operand is bool)
		{
			writer.Write(((bool)operand) ? "true" : "false", BoxedTextColor.Keyword);
		}
		else if (operand == null)
		{
			writer.Write("<null>", BoxedTextColor.Error);
		}
		else
		{
			string text = ToInvariantCultureString(operand);
			writer.Write(text, CSharpMetadataTextColorProvider.Instance.GetColor(operand));
		}
	}

	public static string PrimitiveTypeName(string fullName, ModuleDef module, out TypeSig typeSig)
	{
		ICorLibTypes corLibTypes = module?.CorLibTypes;
		typeSig = null;
		switch (fullName)
		{
		case "System.SByte":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.SByte;
			}
			return "int8";
		case "System.Int16":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Int16;
			}
			return "int16";
		case "System.Int32":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Int32;
			}
			return "int32";
		case "System.Int64":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Int64;
			}
			return "int64";
		case "System.Byte":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Byte;
			}
			return "uint8";
		case "System.UInt16":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.UInt16;
			}
			return "uint16";
		case "System.UInt32":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.UInt32;
			}
			return "uint32";
		case "System.UInt64":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.UInt64;
			}
			return "uint64";
		case "System.Single":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Single;
			}
			return "float32";
		case "System.Double":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Double;
			}
			return "float64";
		case "System.Void":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Void;
			}
			return "void";
		case "System.Boolean":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Boolean;
			}
			return "bool";
		case "System.String":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.String;
			}
			return "string";
		case "System.Char":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Char;
			}
			return "char";
		case "System.Object":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.Object;
			}
			return "object";
		case "System.IntPtr":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.IntPtr;
			}
			return "native int";
		case "System.UIntPtr":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.UIntPtr;
			}
			return "native unsigned int";
		case "System.TypedReference":
			if (corLibTypes != null)
			{
				typeSig = corLibTypes.TypedReference;
			}
			return "typedref";
		default:
			return null;
		}
	}
}
