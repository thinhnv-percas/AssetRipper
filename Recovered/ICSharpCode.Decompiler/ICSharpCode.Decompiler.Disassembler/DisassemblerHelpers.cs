using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ICSharpCode.Decompiler.Disassembler
{
	public static class DisassemblerHelpers
	{
		private static readonly HashSet<string> ilKeywords = BuildKeywordList("abstract", "algorithm", "alignment", "ansi", "any", "arglist", "array", "as", "assembly", "assert", "at", "auto", "autochar", "beforefieldinit", "blob", "blob_object", "bool", "brnull", "brnull.s", "brzero", "brzero.s", "bstr", "bytearray", "byvalstr", "callmostderived", "carray", "catch", "cdecl", "cf", "char", "cil", "class", "clsid", "const", "currency", "custom", "date", "decimal", "default", "demand", "deny", "endmac", "enum", "error", "explicit", "extends", "extern", "false", "famandassem", "family", "famorassem", "fastcall", "fault", "field", "filetime", "filter", "final", "finally", "fixed", "float", "float32", "float64", "forwardref", "fromunmanaged", "handler", "hidebysig", "hresult", "idispatch", "il", "illegal", "implements", "implicitcom", "implicitres", "import", "in", "inheritcheck", "init", "initonly", "instance", "int", "int16", "int32", "int64", "int8", "interface", "internalcall", "iunknown", "lasterr", "lcid", "linkcheck", "literal", "localloc", "lpstr", "lpstruct", "lptstr", "lpvoid", "lpwstr", "managed", "marshal", "method", "modopt", "modreq", "native", "nested", "newslot", "noappdomain", "noinlining", "nomachine", "nomangle", "nometadata", "noncasdemand", "noncasinheritance", "noncaslinkdemand", "noprocess", "not", "not_in_gc_heap", "notremotable", "notserialized", "null", "nullref", "object", "objectref", "opt", "optil", "out", "permitonly", "pinned", "pinvokeimpl", "prefix1", "prefix2", "prefix3", "prefix4", "prefix5", "prefix6", "prefix7", "prefixref", "prejitdeny", "prejitgrant", "preservesig", "private", "privatescope", "protected", "public", "record", "refany", "reqmin", "reqopt", "reqrefuse", "reqsecobj", "request", "retval", "rtspecialname", "runtime", "safearray", "sealed", "sequential", "serializable", "special", "specialname", "static", "stdcall", "storage", "stored_object", "stream", "streamed_object", "string", "struct", "synchronized", "syschar", "sysstring", "tbstr", "thiscall", "tls", "to", "true", "typedref", "unicode", "unmanaged", "unmanagedexp", "unsigned", "unused", "userdefined", "value", "valuetype", "vararg", "variant", "vector", "virtual", "void", "wchar", "winapi", "with", "wrapper", "property", "type", "flags", "callconv", "strict");

		public static void WriteOffsetReference(ITextOutput writer, Instruction instruction)
		{
			writer.WriteReference(CecilExtensions.OffsetToString(instruction.Offset), instruction);
		}

		public static void WriteTo(this ExceptionHandler exceptionHandler, ITextOutput writer)
		{
			writer.Write("Try ");
			WriteOffsetReference(writer, exceptionHandler.TryStart);
			writer.Write('-');
			WriteOffsetReference(writer, exceptionHandler.TryEnd);
			writer.Write(' ');
			writer.Write(exceptionHandler.HandlerType.ToString());
			if (exceptionHandler.FilterStart != null)
			{
				writer.Write(' ');
				WriteOffsetReference(writer, exceptionHandler.FilterStart);
				writer.Write(" handler ");
			}
			if (exceptionHandler.CatchType != null)
			{
				writer.Write(' ');
				exceptionHandler.CatchType.WriteTo(writer);
			}
			writer.Write(' ');
			WriteOffsetReference(writer, exceptionHandler.HandlerStart);
			writer.Write('-');
			WriteOffsetReference(writer, exceptionHandler.HandlerEnd);
		}

		public static void WriteTo(this Instruction instruction, ITextOutput writer)
		{
			writer.WriteDefinition(CecilExtensions.OffsetToString(instruction.Offset), instruction);
			writer.Write(": ");
			writer.WriteReference(instruction.OpCode.Name, instruction.OpCode);
			if (instruction.Operand == null)
			{
				return;
			}
			writer.Write(' ');
			if (instruction.OpCode == OpCodes.Ldtoken)
			{
				if (instruction.Operand is MethodReference)
				{
					writer.Write("method ");
				}
				else if (instruction.Operand is FieldReference)
				{
					writer.Write("field ");
				}
			}
			WriteOperand(writer, instruction.Operand);
		}

		private static void WriteLabelList(ITextOutput writer, Instruction[] instructions)
		{
			writer.Write("(");
			for (int i = 0; i < instructions.Length; i++)
			{
				if (i != 0)
				{
					writer.Write(", ");
				}
				WriteOffsetReference(writer, instructions[i]);
			}
			writer.Write(")");
		}

		private static string ToInvariantCultureString(object value)
		{
			IConvertible convertible = value as IConvertible;
			if (convertible == null)
			{
				return value.ToString();
			}
			return convertible.ToString(CultureInfo.InvariantCulture);
		}

		public static void WriteTo(this MethodReference method, ITextOutput writer)
		{
			if (method.ExplicitThis)
			{
				writer.Write("instance explicit ");
			}
			else if (method.HasThis)
			{
				writer.Write("instance ");
			}
			method.ReturnType.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
			writer.Write(' ');
			if (method.DeclaringType != null)
			{
				method.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName);
				writer.Write("::");
			}
			MethodDefinition methodDefinition = method as MethodDefinition;
			if (methodDefinition != null && methodDefinition.IsCompilerControlled)
			{
				writer.WriteReference(Escape(method.Name + "$PST" + method.MetadataToken.ToInt32().ToString("X8")), method);
			}
			else
			{
				writer.WriteReference(Escape(method.Name), method);
			}
			GenericInstanceMethod genericInstanceMethod = method as GenericInstanceMethod;
			if (genericInstanceMethod != null)
			{
				writer.Write('<');
				for (int i = 0; i < genericInstanceMethod.GenericArguments.Count; i++)
				{
					if (i > 0)
					{
						writer.Write(", ");
					}
					genericInstanceMethod.GenericArguments[i].WriteTo(writer);
				}
				writer.Write('>');
			}
			writer.Write("(");
			Collection<ParameterDefinition> parameters = method.Parameters;
			for (int j = 0; j < parameters.Count; j++)
			{
				if (j > 0)
				{
					writer.Write(", ");
				}
				parameters[j].ParameterType.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
			}
			writer.Write(")");
		}

		private static void WriteTo(this FieldReference field, ITextOutput writer)
		{
			field.FieldType.WriteTo(writer, ILNameSyntax.SignatureNoNamedTypeParameters);
			writer.Write(' ');
			field.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName);
			writer.Write("::");
			writer.WriteReference(Escape(field.Name), field);
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
				hashSet.Add(((OpCode)fieldInfo.GetValue(null)).Name);
			}
			return hashSet;
		}

		public static string Escape(string identifier)
		{
			if (IsValidIdentifier(identifier) && !ilKeywords.Contains(identifier))
			{
				return identifier;
			}
			return "'" + TextWriterTokenWriter.ConvertString(identifier).Replace("'", "\\'") + "'";
		}

		public static void WriteTo(this TypeReference type, ITextOutput writer, ILNameSyntax syntax = ILNameSyntax.Signature)
		{
			ILNameSyntax syntax2 = (syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature;
			if (type is PinnedType)
			{
				((PinnedType)type).ElementType.WriteTo(writer, syntax2);
				writer.Write(" pinned");
				return;
			}
			if (type is ArrayType)
			{
				ArrayType arrayType = (ArrayType)type;
				arrayType.ElementType.WriteTo(writer, syntax2);
				writer.Write('[');
				writer.Write(string.Join(", ", arrayType.Dimensions));
				writer.Write(']');
				return;
			}
			if (type is GenericParameter)
			{
				writer.Write('!');
				if (((GenericParameter)type).Owner.GenericParameterType == GenericParameterType.Method)
				{
					writer.Write('!');
				}
				if (string.IsNullOrEmpty(type.Name) || type.Name[0] == '!' || syntax == ILNameSyntax.SignatureNoNamedTypeParameters)
				{
					writer.Write(((GenericParameter)type).Position.ToString());
				}
				else
				{
					writer.Write(Escape(type.Name));
				}
				return;
			}
			if (type is ByReferenceType)
			{
				((ByReferenceType)type).ElementType.WriteTo(writer, syntax2);
				writer.Write('&');
				return;
			}
			if (type is PointerType)
			{
				((PointerType)type).ElementType.WriteTo(writer, syntax2);
				writer.Write('*');
				return;
			}
			if (type is GenericInstanceType)
			{
				type.GetElementType().WriteTo(writer, syntax2);
				writer.Write('<');
				Collection<TypeReference> genericArguments = ((GenericInstanceType)type).GenericArguments;
				for (int i = 0; i < genericArguments.Count; i++)
				{
					if (i > 0)
					{
						writer.Write(", ");
					}
					genericArguments[i].WriteTo(writer, syntax2);
				}
				writer.Write('>');
				return;
			}
			if (type is OptionalModifierType)
			{
				((OptionalModifierType)type).ElementType.WriteTo(writer, syntax);
				writer.Write(" modopt(");
				((OptionalModifierType)type).ModifierType.WriteTo(writer, ILNameSyntax.TypeName);
				writer.Write(") ");
				return;
			}
			if (type is RequiredModifierType)
			{
				((RequiredModifierType)type).ElementType.WriteTo(writer, syntax);
				writer.Write(" modreq(");
				((RequiredModifierType)type).ModifierType.WriteTo(writer, ILNameSyntax.TypeName);
				writer.Write(") ");
				return;
			}
			string text = PrimitiveTypeName(type.FullName);
			switch (syntax)
			{
			case ILNameSyntax.ShortTypeName:
				if (text != null)
				{
					writer.Write(text);
				}
				else
				{
					writer.WriteReference(Escape(type.Name), type);
				}
				return;
			case ILNameSyntax.Signature:
			case ILNameSyntax.SignatureNoNamedTypeParameters:
				if (text != null)
				{
					writer.Write(text);
					return;
				}
				break;
			}
			if (syntax == ILNameSyntax.Signature || syntax == ILNameSyntax.SignatureNoNamedTypeParameters)
			{
				writer.Write(type.IsValueType ? "valuetype " : "class ");
			}
			if (type.DeclaringType != null)
			{
				type.DeclaringType.WriteTo(writer, ILNameSyntax.TypeName);
				writer.Write('/');
				writer.WriteReference(Escape(type.Name), type);
				return;
			}
			if (!type.IsDefinition && type.Scope != null && !(type is TypeSpecification))
			{
				writer.Write("[{0}]", Escape(type.Scope.Name));
			}
			writer.WriteReference(Escape(type.FullName), type);
		}

		public static void WriteOperand(ITextOutput writer, object operand)
		{
			if (operand == null)
			{
				throw new ArgumentNullException("operand");
			}
			Instruction instruction = operand as Instruction;
			if (instruction != null)
			{
				WriteOffsetReference(writer, instruction);
				return;
			}
			Instruction[] array = operand as Instruction[];
			if (array != null)
			{
				WriteLabelList(writer, array);
				return;
			}
			VariableReference variableReference = operand as VariableReference;
			if (variableReference != null)
			{
				if (string.IsNullOrEmpty(variableReference.Name))
				{
					writer.WriteReference(variableReference.Index.ToString(), variableReference);
				}
				else
				{
					writer.WriteReference(Escape(variableReference.Name), variableReference);
				}
				return;
			}
			ParameterReference parameterReference = operand as ParameterReference;
			if (parameterReference != null)
			{
				if (string.IsNullOrEmpty(parameterReference.Name))
				{
					writer.WriteReference(parameterReference.Index.ToString(), parameterReference);
				}
				else
				{
					writer.WriteReference(Escape(parameterReference.Name), parameterReference);
				}
				return;
			}
			MethodReference methodReference = operand as MethodReference;
			if (methodReference != null)
			{
				methodReference.WriteTo(writer);
				return;
			}
			TypeReference typeReference = operand as TypeReference;
			if (typeReference != null)
			{
				typeReference.WriteTo(writer, ILNameSyntax.TypeName);
				return;
			}
			FieldReference fieldReference = operand as FieldReference;
			if (fieldReference != null)
			{
				fieldReference.WriteTo(writer);
				return;
			}
			string text = operand as string;
			if (text != null)
			{
				writer.Write("\"" + TextWriterTokenWriter.ConvertString(text) + "\"");
			}
			else if (operand is char)
			{
				writer.Write(((int)(char)operand).ToString());
			}
			else if (operand is float)
			{
				float num = (float)operand;
				if (num == 0f)
				{
					if (1f / num == float.NegativeInfinity)
					{
						writer.Write('-');
					}
					writer.Write("0.0");
				}
				else if (float.IsInfinity(num) || float.IsNaN(num))
				{
					byte[] bytes = BitConverter.GetBytes(num);
					writer.Write('(');
					for (int i = 0; i < bytes.Length; i++)
					{
						if (i > 0)
						{
							writer.Write(' ');
						}
						writer.Write(bytes[i].ToString("X2"));
					}
					writer.Write(')');
				}
				else
				{
					writer.Write(num.ToString("R", CultureInfo.InvariantCulture));
				}
			}
			else if (operand is double)
			{
				double num2 = (double)operand;
				if (num2 == 0.0)
				{
					if (1.0 / num2 == double.NegativeInfinity)
					{
						writer.Write('-');
					}
					writer.Write("0.0");
				}
				else if (double.IsInfinity(num2) || double.IsNaN(num2))
				{
					byte[] bytes2 = BitConverter.GetBytes(num2);
					writer.Write('(');
					for (int j = 0; j < bytes2.Length; j++)
					{
						if (j > 0)
						{
							writer.Write(' ');
						}
						writer.Write(bytes2[j].ToString("X2"));
					}
					writer.Write(')');
				}
				else
				{
					writer.Write(num2.ToString("R", CultureInfo.InvariantCulture));
				}
			}
			else if (operand is bool)
			{
				writer.Write(((bool)operand) ? "true" : "false");
			}
			else
			{
				text = ToInvariantCultureString(operand);
				writer.Write(text);
			}
		}

		public static string PrimitiveTypeName(string fullName)
		{
			switch (fullName)
			{
			case "System.SByte":
				return "int8";
			case "System.Int16":
				return "int16";
			case "System.Int32":
				return "int32";
			case "System.Int64":
				return "int64";
			case "System.Byte":
				return "uint8";
			case "System.UInt16":
				return "uint16";
			case "System.UInt32":
				return "uint32";
			case "System.UInt64":
				return "uint64";
			case "System.Single":
				return "float32";
			case "System.Double":
				return "float64";
			case "System.Void":
				return "void";
			case "System.Boolean":
				return "bool";
			case "System.String":
				return "string";
			case "System.Char":
				return "char";
			case "System.Object":
				return "object";
			case "System.IntPtr":
				return "native int";
			default:
				return null;
			}
		}
	}
}
