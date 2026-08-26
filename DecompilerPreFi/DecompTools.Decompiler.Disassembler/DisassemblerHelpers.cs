using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Disassembler;

public static class DisassemblerHelpers
{
	public static string OffsetToString(int offset)
	{
		return $"IL_{offset:x4}";
	}

	public static string OffsetToString(long offset)
	{
		return $"IL_{offset:x4}";
	}

	public static void WriteOffsetReference(ITextOutput writer, int? offset)
	{
		if (!offset.HasValue)
		{
			writer.Write("null");
		}
		else
		{
			writer.WriteLocalReference(OffsetToString(offset.Value), offset);
		}
	}

	public static void WriteTo(this ExceptionRegion exceptionHandler, PEFile module, DecompTools.Decompiler.Metadata.GenericContext context, ITextOutput writer)
	{
		writer.Write(".try ");
		WriteOffsetReference(writer, exceptionHandler.TryOffset);
		writer.Write('-');
		checked
		{
			WriteOffsetReference(writer, exceptionHandler.TryOffset + exceptionHandler.TryLength);
			writer.Write(' ');
			writer.Write(exceptionHandler.Kind.ToString().ToLowerInvariant());
			if (exceptionHandler.FilterOffset != -1)
			{
				writer.Write(' ');
				WriteOffsetReference(writer, exceptionHandler.FilterOffset);
				writer.Write(" handler ");
			}
			if (!exceptionHandler.CatchType.IsNil)
			{
				writer.Write(' ');
				exceptionHandler.CatchType.WriteTo(module, writer, context);
			}
			writer.Write(' ');
			WriteOffsetReference(writer, exceptionHandler.HandlerOffset);
			writer.Write('-');
			WriteOffsetReference(writer, exceptionHandler.HandlerOffset + exceptionHandler.HandlerLength);
		}
	}

	private static string ToInvariantCultureString(object value)
	{
		return (value is IConvertible convertible) ? convertible.ToString(CultureInfo.InvariantCulture) : value.ToString();
	}

	private static bool IsValidIdentifierCharacter(char c)
	{
		return c == '_' || c == '$' || c == '@' || c == '?' || c == '`';
	}

	private static bool IsValidIdentifier(string identifier)
	{
		if (string.IsNullOrEmpty(identifier))
		{
			return false;
		}
		if (!char.IsLetter(identifier[0]) && !IsValidIdentifierCharacter(identifier[0]))
		{
			return identifier == ".ctor" || identifier == ".cctor";
		}
		for (int i = 1; i < identifier.Length; i = checked(i + 1))
		{
			if (!char.IsLetterOrDigit(identifier[i]) && !IsValidIdentifierCharacter(identifier[i]) && identifier[i] != '.')
			{
				return false;
			}
		}
		return true;
	}

	public static string Escape(string identifier)
	{
		if (IsValidIdentifier(identifier) && !DecompTools.Decompiler.Metadata.ILOpCodeExtensions.ILKeywords.Contains(identifier))
		{
			return identifier;
		}
		return "'" + EscapeString(identifier).Replace("'", "\\'") + "'";
	}

	public static void WriteParameterReference(ITextOutput writer, MetadataReader metadata, MethodDefinitionHandle handle, int sequence)
	{
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		MethodSignature<FullTypeName> methodSignature = methodDefinition.DecodeSignature(new FullTypeNameSignatureDecoder(metadata), default(Unit));
		Parameter[] array = Enumerable.ToArray<Parameter>(Enumerable.Select<ParameterHandle, Parameter>((IEnumerable<ParameterHandle>)methodDefinition.GetParameters(), (Func<ParameterHandle, Parameter>)((ParameterHandle p) => metadata.GetParameter(p))));
		SignatureHeader header = methodSignature.Header;
		int num = sequence;
		if (header.IsInstance && methodSignature.ParameterTypes.Length == array.Length)
		{
			num = checked(num - 1);
		}
		if (num < 0 || num >= array.Length)
		{
			writer.Write(sequence.ToString());
			return;
		}
		Parameter parameter = array[num];
		if (parameter.Name.IsNil)
		{
			writer.Write(sequence.ToString());
		}
		else
		{
			writer.Write(Escape(metadata.GetString(parameter.Name)));
		}
	}

	public static void WriteVariableReference(ITextOutput writer, MetadataReader metadata, MethodDefinitionHandle handle, int index)
	{
		writer.Write(index.ToString());
	}

	public static void WriteOperand(ITextOutput writer, object operand)
	{
		if (operand == null)
		{
			throw new ArgumentNullException("operand");
		}
		if (operand is string operand2)
		{
			WriteOperand(writer, operand2);
			return;
		}
		if (operand is char)
		{
			writer.Write(((int)(char)operand).ToString());
			return;
		}
		if (operand is float)
		{
			WriteOperand(writer, (float)operand);
			return;
		}
		if (operand is double)
		{
			WriteOperand(writer, (double)operand);
			return;
		}
		if (operand is bool)
		{
			writer.Write(((bool)operand) ? "true" : "false");
			return;
		}
		string text = ToInvariantCultureString(operand);
		writer.Write(text);
	}

	public static void WriteOperand(ITextOutput writer, long val)
	{
		writer.Write(ToInvariantCultureString(val));
	}

	public static void WriteOperand(ITextOutput writer, float val)
	{
		if (val == 0f)
		{
			if (1f / val == float.NegativeInfinity)
			{
				writer.Write('-');
			}
			writer.Write("0.0");
		}
		else if (float.IsInfinity(val) || float.IsNaN(val))
		{
			byte[] bytes = BitConverter.GetBytes(val);
			writer.Write('(');
			for (int i = 0; i < bytes.Length; i = checked(i + 1))
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
			writer.Write(val.ToString("R", CultureInfo.InvariantCulture));
		}
	}

	public static void WriteOperand(ITextOutput writer, double val)
	{
		if (val == 0.0)
		{
			if (1.0 / val == double.NegativeInfinity)
			{
				writer.Write('-');
			}
			writer.Write("0.0");
		}
		else if (double.IsInfinity(val) || double.IsNaN(val))
		{
			byte[] bytes = BitConverter.GetBytes(val);
			writer.Write('(');
			for (int i = 0; i < bytes.Length; i = checked(i + 1))
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
			writer.Write(val.ToString("R", CultureInfo.InvariantCulture));
		}
	}

	public static void WriteOperand(ITextOutput writer, string operand)
	{
		writer.Write('"');
		writer.Write(EscapeString(operand));
		writer.Write('"');
	}

	public static string EscapeString(string str)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in str)
		{
			switch (c)
			{
			case '"':
				stringBuilder.Append("\\\"");
				continue;
			case '\\':
				stringBuilder.Append("\\\\");
				continue;
			case '\0':
				stringBuilder.Append("\\0");
				continue;
			case '\a':
				stringBuilder.Append("\\a");
				continue;
			case '\b':
				stringBuilder.Append("\\b");
				continue;
			case '\f':
				stringBuilder.Append("\\f");
				continue;
			case '\n':
				stringBuilder.Append("\\n");
				continue;
			case '\r':
				stringBuilder.Append("\\r");
				continue;
			case '\t':
				stringBuilder.Append("\\t");
				continue;
			case '\v':
				stringBuilder.Append("\\v");
				continue;
			}
			if (char.IsControl(c) || char.IsSurrogate(c) || (char.IsWhiteSpace(c) && c != ' '))
			{
				int num = c;
				stringBuilder.Append("\\u" + num.ToString("x4"));
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static string PrimitiveTypeName(string fullName)
	{
		return fullName switch
		{
			"System.SByte" => "int8", 
			"System.Int16" => "int16", 
			"System.Int32" => "int32", 
			"System.Int64" => "int64", 
			"System.Byte" => "uint8", 
			"System.UInt16" => "uint16", 
			"System.UInt32" => "uint32", 
			"System.UInt64" => "uint64", 
			"System.Single" => "float32", 
			"System.Double" => "float64", 
			"System.Void" => "void", 
			"System.Boolean" => "bool", 
			"System.String" => "string", 
			"System.Char" => "char", 
			"System.Object" => "object", 
			"System.IntPtr" => "native int", 
			_ => null, 
		};
	}
}
