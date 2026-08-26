#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.CSharp;

public struct CSharpFormatter
{
	private const string Keyword_true = "true";

	private const string Keyword_false = "false";

	private const string Keyword_null = "null";

	private const string Keyword_out = "out";

	private const string Keyword_in = "in";

	private const string Keyword_ref = "ref";

	private const string Keyword_readonly = "readonly";

	private const string Keyword_this = "this";

	private const string Keyword_get = "get";

	private const string Keyword_set = "set";

	private const string Keyword_add = "add";

	private const string Keyword_remove = "remove";

	private const string Keyword_enum = "enum";

	private const string Keyword_struct = "struct";

	private const string Keyword_interface = "interface";

	private const string Keyword_class = "class";

	private const string Keyword_namespace = "namespace";

	private const string Keyword_params = "params";

	private const string Keyword_default = "default";

	private const string Keyword_delegate = "delegate";

	private const string HexPrefix = "0x";

	private const string VerbatimStringPrefix = "@";

	private const string IdentifierEscapeBegin = "@";

	private const string ModuleNameSeparator = "!";

	private const string CommentBegin = "/*";

	private const string CommentEnd = "*/";

	private const string DeprecatedParenOpen = "[";

	private const string DeprecatedParenClose = "]";

	private const string MemberSpecialParenOpen = "(";

	private const string MemberSpecialParenClose = ")";

	private const string MethodParenOpen = "(";

	private const string MethodParenClose = ")";

	private const string DescriptionParenOpen = "(";

	private const string DescriptionParenClose = ")";

	private const string IndexerParenOpen = "[";

	private const string IndexerParenClose = "]";

	private const string PropertyParenOpen = "[";

	private const string PropertyParenClose = "]";

	private const string ArrayParenOpen = "[";

	private const string ArrayParenClose = "]";

	private const string TupleParenOpen = "(";

	private const string TupleParenClose = ")";

	private const string GenericParenOpen = "<";

	private const string GenericParenClose = ">";

	private const string DefaultParamValueParenOpen = "[";

	private const string DefaultParamValueParenClose = "]";

	private int recursionCounter;

	private int lineLength;

	private bool outputLengthExceeded;

	private bool forceWrite;

	private readonly ITextColorWriter output;

	private FormatterOptions options;

	private readonly CultureInfo cultureInfo;

	private static readonly Dictionary<string, string[]> nameToOperatorName = new Dictionary<string, string[]>(StringComparer.Ordinal)
	{
		{
			"op_Addition",
			"operator +".Split(' ')
		},
		{
			"op_BitwiseAnd",
			"operator &".Split(' ')
		},
		{
			"op_BitwiseOr",
			"operator |".Split(' ')
		},
		{
			"op_Decrement",
			"operator --".Split(' ')
		},
		{
			"op_Division",
			"operator /".Split(' ')
		},
		{
			"op_Equality",
			"operator ==".Split(' ')
		},
		{
			"op_ExclusiveOr",
			"operator ^".Split(' ')
		},
		{
			"op_Explicit",
			"explicit operator".Split(' ')
		},
		{
			"op_False",
			"operator false".Split(' ')
		},
		{
			"op_GreaterThan",
			"operator >".Split(' ')
		},
		{
			"op_GreaterThanOrEqual",
			"operator >=".Split(' ')
		},
		{
			"op_Implicit",
			"implicit operator".Split(' ')
		},
		{
			"op_Increment",
			"operator ++".Split(' ')
		},
		{
			"op_Inequality",
			"operator !=".Split(' ')
		},
		{
			"op_LeftShift",
			"operator <<".Split(' ')
		},
		{
			"op_LessThan",
			"operator <".Split(' ')
		},
		{
			"op_LessThanOrEqual",
			"operator <=".Split(' ')
		},
		{
			"op_LogicalNot",
			"operator !".Split(' ')
		},
		{
			"op_Modulus",
			"operator %".Split(' ')
		},
		{
			"op_Multiply",
			"operator *".Split(' ')
		},
		{
			"op_OnesComplement",
			"operator ~".Split(' ')
		},
		{
			"op_RightShift",
			"operator >>".Split(' ')
		},
		{
			"op_Subtraction",
			"operator -".Split(' ')
		},
		{
			"op_True",
			"operator true".Split(' ')
		},
		{
			"op_UnaryNegation",
			"operator -".Split(' ')
		},
		{
			"op_UnaryPlus",
			"operator +".Split(' ')
		}
	};

	private static readonly HashSet<string> isKeyword = new HashSet<string>(StringComparer.Ordinal)
	{
		"abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked",
		"class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum",
		"event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto",
		"if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace",
		"new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
		"readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
		"struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
		"unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
	};

	private static readonly char[] nsSep = new char[1] { '.' };

	private static readonly char[] namespaceSeparators = new char[1] { '.' };

	private bool ShowModuleNames => (options & FormatterOptions.ShowModuleNames) != 0;

	private bool ShowParameterTypes => (options & FormatterOptions.ShowParameterTypes) != 0;

	private bool ShowParameterNames => (options & FormatterOptions.ShowParameterNames) != 0;

	private bool ShowDeclaringTypes => (options & FormatterOptions.ShowDeclaringTypes) != 0;

	private bool ShowReturnTypes => (options & FormatterOptions.ShowReturnTypes) != 0;

	private bool ShowNamespaces => (options & FormatterOptions.ShowNamespaces) != 0;

	private bool ShowIntrinsicTypeKeywords => (options & FormatterOptions.ShowIntrinsicTypeKeywords) != 0;

	private bool UseDecimal => (options & FormatterOptions.UseDecimal) != 0;

	private bool ShowTokens => (options & FormatterOptions.ShowTokens) != 0;

	private bool ShowArrayValueSizes => (options & FormatterOptions.ShowArrayValueSizes) != 0;

	private bool ShowFieldLiteralValues => (options & FormatterOptions.ShowFieldLiteralValues) != 0;

	private bool ShowParameterLiteralValues => (options & FormatterOptions.ShowParameterLiteralValues) != 0;

	private bool DigitSeparators => (options & FormatterOptions.DigitSeparators) != 0;

	public CSharpFormatter(ITextColorWriter output, FormatterOptions options, CultureInfo cultureInfo)
	{
		this.output = output;
		this.options = options;
		this.cultureInfo = cultureInfo ?? CultureInfo.InvariantCulture;
		recursionCounter = 0;
		lineLength = 0;
		outputLengthExceeded = false;
		forceWrite = false;
	}

	private void WriteIdentifier(string id, object data)
	{
		if (isKeyword.Contains(id))
		{
			OutputWrite("@" + IdentifierEscaper.Escape(id), data);
		}
		else
		{
			OutputWrite(IdentifierEscaper.Escape(id), data);
		}
	}

	private void OutputWrite(string s, object data)
	{
		if (!forceWrite)
		{
			if (outputLengthExceeded)
			{
				return;
			}
			if (lineLength + s.Length > 4096)
			{
				s = s.Substring(0, 4096 - lineLength);
				s += "[...]";
				outputLengthExceeded = true;
			}
		}
		output.Write(data, s);
		lineLength += s.Length;
	}

	private void WriteSpace()
	{
		OutputWrite(" ", BoxedTextColor.Text);
	}

	private void WriteCommaSpace()
	{
		OutputWrite(",", BoxedTextColor.Punctuation);
		WriteSpace();
	}

	private void WritePeriod()
	{
		OutputWrite(".", BoxedTextColor.Operator);
	}

	private void WriteError()
	{
		OutputWrite("???", BoxedTextColor.Error);
	}

	private void WriteSystemTypeKeyword(string name, string keyword, bool isValueType)
	{
		if (ShowIntrinsicTypeKeywords)
		{
			OutputWrite(keyword, BoxedTextColor.Keyword);
		}
		else
		{
			WriteSystemType(name, isValueType);
		}
	}

	private void WriteSystemType(string name, bool isValueType)
	{
		if (ShowNamespaces)
		{
			OutputWrite("System", BoxedTextColor.Namespace);
			WritePeriod();
		}
		OutputWrite(name, BoxedTextColor.Type);
	}

	private void WriteToken(IMDTokenProvider tok)
	{
		if (ShowTokens)
		{
			Debug.Assert(tok != null);
			if (tok != null)
			{
				OutputWrite("/*" + ToFormattedUInt32(tok.MDToken.Raw) + "*/", BoxedTextColor.Comment);
			}
		}
	}

	public void WriteToolTip(IMemberRef member)
	{
		if (member == null)
		{
			WriteError();
		}
		else if (member is IMethod { MethodSig: not null } method)
		{
			WriteToolTip(method);
		}
		else if (member is IField { FieldSig: not null } field)
		{
			WriteToolTip(field);
		}
		else if (member is PropertyDef { PropertySig: not null } propertyDef)
		{
			WriteToolTip(propertyDef);
		}
		else if (member is EventDef { EventType: not null } eventDef)
		{
			WriteToolTip(eventDef);
		}
		else if (member is ITypeDefOrRef type)
		{
			WriteToolTip(type);
		}
		else if (member is GenericParam gp)
		{
			WriteToolTip(gp);
		}
		else
		{
			Debug.Fail("Unknown reference");
		}
	}

	public void Write(IMemberRef member)
	{
		if (member == null)
		{
			WriteError();
		}
		else if (member is IMethod { MethodSig: not null } method)
		{
			Write(method);
		}
		else if (member is IField { FieldSig: not null } field)
		{
			Write(field);
		}
		else if (member is PropertyDef { PropertySig: not null } propertyDef)
		{
			Write(propertyDef);
		}
		else if (member is EventDef { EventType: not null } eventDef)
		{
			Write(eventDef);
		}
		else if (member is ITypeDefOrRef type)
		{
			Write(type, ShowModuleNames);
		}
		else if (member is GenericParam gp)
		{
			Write(gp);
		}
		else
		{
			Debug.Fail("Unknown reference");
		}
	}

	private void WriteDeprecated(bool isDeprecated)
	{
		if (isDeprecated)
		{
			OutputWrite("[", BoxedTextColor.Punctuation);
			OutputWrite(dnSpy_Decompiler_Resources.CSharp_Deprecated_Member, BoxedTextColor.Text);
			OutputWrite("]", BoxedTextColor.Punctuation);
			WriteSpace();
		}
	}

	private void Write(MemberSpecialFlags flags)
	{
		if (flags == MemberSpecialFlags.None)
		{
			return;
		}
		OutputWrite("(", BoxedTextColor.Punctuation);
		bool flag = false;
		if ((flags & MemberSpecialFlags.Awaitable) != MemberSpecialFlags.None)
		{
			flag = true;
			OutputWrite(dnSpy_Decompiler_Resources.CSharp_Awaitable_Method, BoxedTextColor.Text);
		}
		if ((flags & MemberSpecialFlags.Extension) != MemberSpecialFlags.None)
		{
			if (flag)
			{
				WriteCommaSpace();
			}
			OutputWrite(dnSpy_Decompiler_Resources.CSharp_Extension_Method, BoxedTextColor.Text);
		}
		OutputWrite(")", BoxedTextColor.Punctuation);
		WriteSpace();
	}

	private void WriteToolTip(IMethod method)
	{
		if (method == null)
		{
			WriteError();
			return;
		}
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(method));
		Write(TypeFormatterUtils.GetMemberSpecialFlags(method));
		Write(method);
		TypeDef typeDef = method.DeclaringType.ResolveTypeDef();
		if (typeDef != null)
		{
			string numberOfOverloadsString = TypeFormatterUtils.GetNumberOfOverloadsString(typeDef, method.Name);
			if (numberOfOverloadsString != null)
			{
				OutputWrite(numberOfOverloadsString, BoxedTextColor.Text);
			}
		}
	}

	private void WriteType(ITypeDefOrRef type, bool useNamespaces, bool useTypeKeywords)
	{
		TypeDef typeDef = type as TypeDef;
		if (typeDef == null && type is TypeRef)
		{
			typeDef = ((TypeRef)type).Resolve();
		}
		if (typeDef == null || typeDef.GenericParameters.Count == 0 || (typeDef.DeclaringType != null && typeDef.DeclaringType.GenericParameters.Count >= typeDef.GenericParameters.Count))
		{
			FormatterOptions formatterOptions = options;
			options &= ~(FormatterOptions.ShowNamespaces | FormatterOptions.ShowIntrinsicTypeKeywords);
			if (useNamespaces)
			{
				options |= FormatterOptions.ShowNamespaces;
			}
			if (useTypeKeywords)
			{
				options |= FormatterOptions.ShowIntrinsicTypeKeywords;
			}
			Write(type);
			options = formatterOptions;
			return;
		}
		int num = typeDef.GenericParameters.Count;
		if (type.DeclaringType != null)
		{
			FormatterOptions formatterOptions2 = options;
			options &= ~(FormatterOptions.ShowNamespaces | FormatterOptions.ShowIntrinsicTypeKeywords);
			if (useNamespaces)
			{
				options |= FormatterOptions.ShowNamespaces;
			}
			Write(type.DeclaringType);
			options = formatterOptions2;
			WritePeriod();
			num -= typeDef.DeclaringType.GenericParameters.Count;
			if (num < 0)
			{
				num = 0;
			}
		}
		else if (useNamespaces && !UTF8String.IsNullOrEmpty(typeDef.Namespace))
		{
			string[] array = typeDef.Namespace.String.Split('.');
			foreach (string id in array)
			{
				WriteIdentifier(id, BoxedTextColor.Namespace);
				WritePeriod();
			}
		}
		WriteIdentifier(TypeFormatterUtils.RemoveGenericTick(typeDef.Name), CSharpMetadataTextColorProvider.Instance.GetColor(typeDef));
		WriteToken(type);
		GenericParam[] gps = typeDef.GenericParameters.Skip(typeDef.GenericParameters.Count - num).ToArray();
		WriteGenerics(gps, BoxedTextColor.TypeGenericParameter);
	}

	private bool WriteRefIfByRef(TypeSig typeSig, ParamDef pd, bool forceReadOnly)
	{
		if (typeSig.RemovePinnedAndModifiers() is ByRefSig)
		{
			if (pd != null && !pd.IsIn && pd.IsOut)
			{
				OutputWrite("out", BoxedTextColor.Keyword);
				WriteSpace();
			}
			else if (pd != null && !pd.IsIn && !pd.IsOut && TypeFormatterUtils.IsReadOnlyParameter(pd))
			{
				OutputWrite("in", BoxedTextColor.Keyword);
				WriteSpace();
			}
			else
			{
				OutputWrite("ref", BoxedTextColor.Keyword);
				WriteSpace();
				if (forceReadOnly)
				{
					OutputWrite("readonly", BoxedTextColor.Keyword);
					WriteSpace();
				}
			}
			return true;
		}
		return false;
	}

	private void WriteAccessor(AccessorKind kind)
	{
		string s = kind switch
		{
			AccessorKind.Getter => "get", 
			AccessorKind.Setter => "set", 
			AccessorKind.Adder => "add", 
			AccessorKind.Remover => "remove", 
			_ => throw new InvalidOperationException(), 
		};
		OutputWrite(".", BoxedTextColor.Operator);
		OutputWrite(s, BoxedTextColor.Keyword);
	}

	private void Write(IMethod method)
	{
		if (method == null)
		{
			WriteError();
			return;
		}
		(PropertyDef, AccessorKind) tuple = TypeFormatterUtils.TryGetProperty(method as MethodDef);
		if (tuple.Item2 != AccessorKind.None)
		{
			Write(tuple.Item1, writeAccessors: false);
			WriteAccessor(tuple.Item2);
			return;
		}
		(EventDef, AccessorKind) tuple2 = TypeFormatterUtils.TryGetEvent(method as MethodDef);
		if (tuple2.Item2 != AccessorKind.None)
		{
			Write(tuple2.Item1, writeAccessors: false);
			WriteAccessor(tuple2.Item2);
			return;
		}
		FormatterMethodInfo info = new FormatterMethodInfo(method);
		WriteModuleName(in info);
		string[] array;
		if (info.MethodDef != null && info.MethodDef.IsConstructor && method.DeclaringType != null)
		{
			array = null;
		}
		else if (info.MethodDef != null && info.MethodDef.Overrides.Count > 0)
		{
			IMemberRef methodDeclaration = info.MethodDef.Overrides[0].MethodDeclaration;
			array = TryGetOperatorInfo(methodDeclaration.Name);
		}
		else
		{
			array = TryGetOperatorInfo(method.Name);
		}
		bool flag = array != null && (array[0] == "explicit" || array[0] == "implicit");
		if (!flag)
		{
			WriteReturnType(in info, writeSpace: true, TypeFormatterUtils.IsReadOnlyMethod(info.MethodDef));
		}
		if (ShowDeclaringTypes)
		{
			Write(method.DeclaringType);
			WritePeriod();
		}
		if (info.MethodDef != null && info.MethodDef.IsConstructor && method.DeclaringType != null)
		{
			WriteIdentifier(TypeFormatterUtils.RemoveGenericTick(method.DeclaringType.Name), CSharpMetadataTextColorProvider.Instance.GetColor(method));
		}
		else if (info.MethodDef != null && info.MethodDef.Overrides.Count > 0)
		{
			IMemberRef methodDeclaration2 = info.MethodDef.Overrides[0].MethodDeclaration;
			WriteMethodName(method, methodDeclaration2.Name, array);
		}
		else
		{
			WriteMethodName(method, method.Name, array);
		}
		if (flag)
		{
			WriteToken(method);
			WriteSpace();
			ForceWriteReturnType(in info, writeSpace: false, TypeFormatterUtils.IsReadOnlyMethod(info.MethodDef));
		}
		else
		{
			WriteToken(method);
		}
		WriteGenericArguments(in info);
		WriteMethodParameterList(in info, "(", ")");
	}

	private static string[] TryGetOperatorInfo(string name)
	{
		nameToOperatorName.TryGetValue(name, out var value);
		return value;
	}

	private void WriteOperatorInfoString(string s)
	{
		OutputWrite(s, ('a' <= s[0] && s[0] <= 'z') ? BoxedTextColor.Keyword : BoxedTextColor.Operator);
	}

	private void WriteMethodName(IMethod method, string name, string[] operatorInfo)
	{
		if (operatorInfo != null)
		{
			for (int i = 0; i < operatorInfo.Length; i++)
			{
				if (i > 0)
				{
					WriteSpace();
				}
				string s = operatorInfo[i];
				WriteOperatorInfoString(s);
			}
		}
		else
		{
			WriteIdentifier(name, CSharpMetadataTextColorProvider.Instance.GetColor(method));
		}
	}

	private void WriteToolTip(IField field)
	{
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(field));
		Write(field, isToolTip: true);
	}

	private void Write(IField field)
	{
		Write(field, isToolTip: false);
	}

	private void Write(IField field, bool isToolTip)
	{
		if (field == null)
		{
			WriteError();
			return;
		}
		FieldSig fieldSig = field.FieldSig;
		bool flag = field.DeclaringType.ResolveTypeDef()?.IsEnum ?? false;
		FieldDef fieldDef = field.ResolveFieldDef();
		object constant = null;
		bool flag2 = fieldDef != null && (fieldDef.IsLiteral || (fieldDef.IsStatic && fieldDef.IsInitOnly)) && TypeFormatterUtils.HasConstant(fieldDef, out var constantAttribute) && TypeFormatterUtils.TryGetConstant(fieldDef, constantAttribute, out constant);
		if (!flag || (fieldDef != null && !fieldDef.IsLiteral))
		{
			if (isToolTip)
			{
				OutputWrite("(", BoxedTextColor.Punctuation);
				OutputWrite(flag2 ? dnSpy_Decompiler_Resources.ToolTip_Constant : dnSpy_Decompiler_Resources.ToolTip_Field, BoxedTextColor.Text);
				OutputWrite(")", BoxedTextColor.Punctuation);
				WriteSpace();
			}
			WriteModuleName(fieldDef?.Module);
			Write(fieldSig.Type, null, null, null);
			WriteSpace();
		}
		else
		{
			WriteModuleName(fieldDef?.Module);
		}
		if (ShowDeclaringTypes)
		{
			Write(field.DeclaringType);
			WritePeriod();
		}
		WriteIdentifier(field.Name, CSharpMetadataTextColorProvider.Instance.GetColor(field));
		WriteToken(field);
		if (ShowFieldLiteralValues & flag2)
		{
			WriteSpace();
			OutputWrite("=", BoxedTextColor.Operator);
			WriteSpace();
			WriteConstant(constant);
		}
	}

	private void WriteConstant(object obj)
	{
		if (obj == null)
		{
			OutputWrite("null", BoxedTextColor.Keyword);
			return;
		}
		switch (Type.GetTypeCode(obj.GetType()))
		{
		case TypeCode.Boolean:
			FormatBoolean((bool)obj);
			break;
		case TypeCode.Char:
			FormatChar((char)obj);
			break;
		case TypeCode.SByte:
			FormatSByte((sbyte)obj);
			break;
		case TypeCode.Byte:
			FormatByte((byte)obj);
			break;
		case TypeCode.Int16:
			FormatInt16((short)obj);
			break;
		case TypeCode.UInt16:
			FormatUInt16((ushort)obj);
			break;
		case TypeCode.Int32:
			FormatInt32((int)obj);
			break;
		case TypeCode.UInt32:
			FormatUInt32((uint)obj);
			break;
		case TypeCode.Int64:
			FormatInt64((long)obj);
			break;
		case TypeCode.UInt64:
			FormatUInt64((ulong)obj);
			break;
		case TypeCode.Single:
			FormatSingle((float)obj);
			break;
		case TypeCode.Double:
			FormatDouble((double)obj);
			break;
		case TypeCode.Decimal:
			FormatDecimal((decimal)obj);
			break;
		case TypeCode.String:
			FormatString((string)obj);
			break;
		default:
			Debug.Fail($"Unknown constant: '{obj}'");
			OutputWrite(obj.ToString(), BoxedTextColor.Text);
			break;
		}
	}

	private void WriteToolTip(PropertyDef prop)
	{
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(prop));
		Write(prop);
	}

	private void Write(PropertyDef prop)
	{
		Write(prop, writeAccessors: true);
	}

	private void Write(PropertyDef prop, bool writeAccessors)
	{
		if (prop == null)
		{
			WriteError();
			return;
		}
		MethodDef methodDef = prop.GetMethods.FirstOrDefault();
		MethodDef methodDef2 = prop.SetMethods.FirstOrDefault();
		MethodDef methodDef3 = methodDef ?? methodDef2;
		if (methodDef3 == null)
		{
			WriteError();
			return;
		}
		FormatterMethodInfo info = new FormatterMethodInfo(methodDef3, methodDef3 == methodDef2);
		WriteModuleName(in info);
		WriteReturnType(in info, writeSpace: true, TypeFormatterUtils.IsReadOnlyProperty(prop));
		if (ShowDeclaringTypes)
		{
			Write(prop.DeclaringType);
			WritePeriod();
		}
		IMethodDefOrRef methodDefOrRef = ((methodDef3 == null || methodDef3.Overrides.Count == 0) ? null : methodDef3.Overrides[0].MethodDeclaration);
		if (prop.IsIndexer())
		{
			OutputWrite("this", BoxedTextColor.Keyword);
			WriteGenericArguments(in info);
			WriteMethodParameterList(in info, "[", "]");
		}
		else if (methodDefOrRef != null && TypeFormatterUtils.GetPropertyName(methodDefOrRef) != null)
		{
			WriteIdentifier(TypeFormatterUtils.GetPropertyName(methodDefOrRef), CSharpMetadataTextColorProvider.Instance.GetColor(prop));
		}
		else
		{
			WriteIdentifier(prop.Name, CSharpMetadataTextColorProvider.Instance.GetColor(prop));
		}
		WriteToken(prop);
		if (writeAccessors)
		{
			WriteSpace();
			OutputWrite("{", BoxedTextColor.Punctuation);
			if (prop.GetMethods.Count > 0)
			{
				WriteSpace();
				OutputWrite("get", BoxedTextColor.Keyword);
				OutputWrite(";", BoxedTextColor.Punctuation);
			}
			if (prop.SetMethods.Count > 0)
			{
				WriteSpace();
				OutputWrite("set", BoxedTextColor.Keyword);
				OutputWrite(";", BoxedTextColor.Punctuation);
			}
			WriteSpace();
			OutputWrite("}", BoxedTextColor.Punctuation);
		}
	}

	private void WriteToolTip(EventDef evt)
	{
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(evt));
		Write(evt);
	}

	private void Write(EventDef evt)
	{
		Write(evt, writeAccessors: true);
	}

	private void Write(EventDef evt, bool writeAccessors)
	{
		if (evt == null)
		{
			WriteError();
			return;
		}
		WriteModuleName(evt.Module);
		Write(evt.EventType);
		WriteSpace();
		if (ShowDeclaringTypes)
		{
			Write(evt.DeclaringType);
			WritePeriod();
		}
		WriteIdentifier(evt.Name, CSharpMetadataTextColorProvider.Instance.GetColor(evt));
		WriteToken(evt);
	}

	private void WriteToolTip(GenericParam gp)
	{
		if (gp == null)
		{
			WriteError();
			return;
		}
		Write(gp);
		WriteSpace();
		OutputWrite(dnSpy_Decompiler_Resources.ToolTip_GenericParameterInTypeOrMethod, BoxedTextColor.Text);
		WriteSpace();
		if (gp.Owner is TypeDef type)
		{
			WriteType(type, ShowNamespaces, ShowIntrinsicTypeKeywords);
		}
		else
		{
			Write(gp.Owner as MethodDef);
		}
	}

	private void Write(GenericParam gp)
	{
		if (gp == null)
		{
			WriteError();
			return;
		}
		WriteIdentifier(gp.Name, CSharpMetadataTextColorProvider.Instance.GetColor(gp));
		WriteToken(gp);
	}

	private void WriteToolTip(ITypeDefOrRef type)
	{
		TypeDef typeDef = type.ResolveTypeDef();
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(type));
		Write(TypeFormatterUtils.GetMemberSpecialFlags(type));
		MethodDef methodDef;
		if (TypeFormatterUtils.IsDelegate(typeDef) && (methodDef = typeDef.FindMethod("Invoke")) != null && methodDef.MethodSig != null)
		{
			OutputWrite("delegate", BoxedTextColor.Keyword);
			WriteSpace();
			FormatterMethodInfo info = new FormatterMethodInfo(methodDef);
			WriteModuleName(in info);
			WriteReturnType(in info, writeSpace: true, TypeFormatterUtils.IsReadOnlyMethod(info.MethodDef));
			WriteType(typeDef, useNamespaces: true, ShowIntrinsicTypeKeywords);
			WriteGenericArguments(in info);
			WriteMethodParameterList(in info, "(", ")");
			return;
		}
		WriteModuleName(typeDef?.Module);
		if (typeDef == null)
		{
			Write(type);
			return;
		}
		string s;
		if (typeDef.IsEnum)
		{
			s = "enum";
		}
		else if (!typeDef.IsValueType)
		{
			s = ((!typeDef.IsInterface) ? "class" : "interface");
		}
		else
		{
			if (TypeFormatterUtils.IsReadOnlyType(typeDef))
			{
				OutputWrite("readonly", BoxedTextColor.Keyword);
				WriteSpace();
			}
			if (TypeFormatterUtils.IsByRefLike(typeDef))
			{
				OutputWrite("ref", BoxedTextColor.Keyword);
				WriteSpace();
			}
			s = "struct";
		}
		OutputWrite(s, BoxedTextColor.Keyword);
		WriteSpace();
		WriteType(type, useNamespaces: true, useTypeKeywords: false);
	}

	private void Write(ITypeDefOrRef type, bool showModuleNames = false)
	{
		if (type == null)
		{
			WriteError();
		}
		else
		{
			if (recursionCounter >= 200)
			{
				return;
			}
			recursionCounter++;
			try
			{
				if (type is TypeSpec typeSpec)
				{
					Write(typeSpec.TypeSig, null, null, null);
					return;
				}
				if (type.DeclaringType != null)
				{
					Write(type.DeclaringType);
					WritePeriod();
				}
				string typeKeyword = GetTypeKeyword(type);
				if (typeKeyword != null)
				{
					OutputWrite(typeKeyword, BoxedTextColor.Keyword);
				}
				else
				{
					if (showModuleNames)
					{
						WriteModuleName(type.ResolveTypeDef()?.Module);
					}
					WriteNamespace(type.Namespace);
					WriteIdentifier(TypeFormatterUtils.RemoveGenericTick(type.Name), CSharpMetadataTextColorProvider.Instance.GetColor(type));
				}
				WriteToken(type);
			}
			finally
			{
				recursionCounter--;
			}
		}
	}

	private void WriteNamespace(string ns)
	{
		if (ShowNamespaces && !string.IsNullOrEmpty(ns))
		{
			string[] array = ns.Split(nsSep);
			for (int i = 0; i < array.Length; i++)
			{
				OutputWrite(array[i], BoxedTextColor.Namespace);
				WritePeriod();
			}
		}
	}

	private string GetTypeKeyword(ITypeDefOrRef type)
	{
		if (!ShowIntrinsicTypeKeywords)
		{
			return null;
		}
		if (type == null || type.DeclaringType != null || type.Namespace != "System" || !type.DefinitionAssembly.IsCorLib())
		{
			return null;
		}
		return type.TypeName switch
		{
			"Void" => "void", 
			"Boolean" => "bool", 
			"Byte" => "byte", 
			"Char" => "char", 
			"Decimal" => "decimal", 
			"Double" => "double", 
			"Int16" => "short", 
			"Int32" => "int", 
			"Int64" => "long", 
			"Object" => "object", 
			"SByte" => "sbyte", 
			"Single" => "float", 
			"String" => "string", 
			"UInt16" => "ushort", 
			"UInt32" => "uint", 
			"UInt64" => "ulong", 
			_ => null, 
		};
	}

	private void Write(TypeSig type, ParamDef ownerParam, IList<TypeSig> typeGenArgs, IList<TypeSig> methGenArgs, bool forceReadOnly = false)
	{
		WriteRefIfByRef(type, ownerParam, forceReadOnly);
		if (type.RemovePinnedAndModifiers() is ByRefSig byRefSig)
		{
			type = byRefSig.Next;
		}
		Write(type, typeGenArgs, methGenArgs);
	}

	private void Write(TypeSig type, IList<TypeSig> typeGenArgs, IList<TypeSig> methGenArgs)
	{
		if (type == null)
		{
			WriteError();
		}
		else
		{
			if (recursionCounter >= 200)
			{
				return;
			}
			recursionCounter++;
			try
			{
				if (typeGenArgs == null)
				{
					typeGenArgs = Array.Empty<TypeSig>();
				}
				if (methGenArgs == null)
				{
					methGenArgs = Array.Empty<TypeSig>();
				}
				List<ArraySigBase> list = null;
				while (type != null && (type.ElementType == ElementType.SZArray || type.ElementType == ElementType.Array))
				{
					if (list == null)
					{
						list = new List<ArraySigBase>();
					}
					list.Add((ArraySigBase)type);
					type = type.Next;
				}
				if (list != null)
				{
					Write(list[list.Count - 1].Next, typeGenArgs, methGenArgs);
					{
						foreach (ArraySigBase item in list)
						{
							if (item.ElementType == ElementType.Array)
							{
								OutputWrite("[", BoxedTextColor.Punctuation);
								uint rank = item.Rank;
								if (rank == 0)
								{
									OutputWrite("<RANK0>", BoxedTextColor.Error);
								}
								else
								{
									IList<int> lowerBounds = item.GetLowerBounds();
									IList<uint> sizes = item.GetSizes();
									if (ShowArrayValueSizes && lowerBounds.Count == (int)rank && sizes.Count == (int)rank)
									{
										for (int i = 0; (uint)i < rank; i++)
										{
											if (i > 0)
											{
												WriteCommaSpace();
											}
											if (i < lowerBounds.Count && lowerBounds[i] == 0)
											{
												FormatInt32((int)sizes[i]);
											}
											else if (i < lowerBounds.Count && i < sizes.Count)
											{
												FormatInt32(lowerBounds[i]);
												OutputWrite("..", BoxedTextColor.Operator);
												FormatInt32((int)(lowerBounds[i] + sizes[i] - 1));
											}
										}
									}
									else
									{
										if (rank == 1)
										{
											OutputWrite("*", BoxedTextColor.Operator);
										}
										for (uint num = 1u; num < rank; num++)
										{
											OutputWrite(",", BoxedTextColor.Punctuation);
										}
									}
								}
								OutputWrite("]", BoxedTextColor.Punctuation);
							}
							else
							{
								Debug.Assert(item.ElementType == ElementType.SZArray);
								OutputWrite("[", BoxedTextColor.Punctuation);
								OutputWrite("]", BoxedTextColor.Punctuation);
							}
						}
						return;
					}
				}
				switch (type.ElementType)
				{
				case ElementType.Void:
					WriteSystemTypeKeyword("Void", "void", isValueType: true);
					break;
				case ElementType.Boolean:
					WriteSystemTypeKeyword("Boolean", "bool", isValueType: true);
					break;
				case ElementType.Char:
					WriteSystemTypeKeyword("Char", "char", isValueType: true);
					break;
				case ElementType.I1:
					WriteSystemTypeKeyword("SByte", "sbyte", isValueType: true);
					break;
				case ElementType.U1:
					WriteSystemTypeKeyword("Byte", "byte", isValueType: true);
					break;
				case ElementType.I2:
					WriteSystemTypeKeyword("Int16", "short", isValueType: true);
					break;
				case ElementType.U2:
					WriteSystemTypeKeyword("UInt16", "ushort", isValueType: true);
					break;
				case ElementType.I4:
					WriteSystemTypeKeyword("Int32", "int", isValueType: true);
					break;
				case ElementType.U4:
					WriteSystemTypeKeyword("UInt32", "uint", isValueType: true);
					break;
				case ElementType.I8:
					WriteSystemTypeKeyword("Int64", "long", isValueType: true);
					break;
				case ElementType.U8:
					WriteSystemTypeKeyword("UInt64", "ulong", isValueType: true);
					break;
				case ElementType.R4:
					WriteSystemTypeKeyword("Single", "float", isValueType: true);
					break;
				case ElementType.R8:
					WriteSystemTypeKeyword("Double", "double", isValueType: true);
					break;
				case ElementType.String:
					WriteSystemTypeKeyword("String", "string", isValueType: false);
					break;
				case ElementType.Object:
					WriteSystemTypeKeyword("Object", "object", isValueType: false);
					break;
				case ElementType.TypedByRef:
					WriteSystemType("TypedReference", isValueType: true);
					break;
				case ElementType.I:
					WriteSystemType("IntPtr", isValueType: true);
					break;
				case ElementType.U:
					WriteSystemType("UIntPtr", isValueType: true);
					break;
				case ElementType.Ptr:
					Write(type.Next, typeGenArgs, methGenArgs);
					OutputWrite("*", BoxedTextColor.Operator);
					break;
				case ElementType.ByRef:
					Write(type.Next, typeGenArgs, methGenArgs);
					OutputWrite("&", BoxedTextColor.Operator);
					break;
				case ElementType.ValueType:
				case ElementType.Class:
				{
					TypeDefOrRefSig typeDefOrRefSig = (TypeDefOrRefSig)type;
					Write(typeDefOrRefSig.TypeDefOrRef);
					break;
				}
				case ElementType.Var:
				case ElementType.MVar:
				{
					TypeSig typeSig = Read((type.ElementType == ElementType.Var) ? typeGenArgs : methGenArgs, (int)((GenericSig)type).Number);
					if (typeSig != null)
					{
						Write(typeSig, typeGenArgs, methGenArgs);
						break;
					}
					GenericParam genericParam = ((GenericSig)type).GenericParam;
					Write(genericParam);
					break;
				}
				case ElementType.GenericInst:
				{
					GenericInstSig genericInstSig = (GenericInstSig)type;
					if (TypeFormatterUtils.IsSystemNullable(genericInstSig))
					{
						Write(GenericArgumentResolver.Resolve(genericInstSig.GenericArguments[0], typeGenArgs, methGenArgs), null, null);
						OutputWrite("?", BoxedTextColor.Operator);
						break;
					}
					if (TypeFormatterUtils.IsSystemValueTuple(genericInstSig))
					{
						OutputWrite("(", BoxedTextColor.Punctuation);
						bool flag = false;
						for (int l = 0; l < 1000; l++)
						{
							for (int m = 0; m < genericInstSig.GenericArguments.Count && m < 7; m++)
							{
								if (flag)
								{
									WriteCommaSpace();
								}
								flag = true;
								Write(GenericArgumentResolver.Resolve(genericInstSig.GenericArguments[m], typeGenArgs, methGenArgs), null, null);
							}
							if (genericInstSig.GenericArguments.Count != 8)
							{
								break;
							}
							genericInstSig = genericInstSig.GenericArguments[genericInstSig.GenericArguments.Count - 1] as GenericInstSig;
							if (genericInstSig == null)
							{
								WriteError();
								break;
							}
						}
						OutputWrite(")", BoxedTextColor.Punctuation);
						break;
					}
					Write(genericInstSig.GenericType, null, null);
					OutputWrite("<", BoxedTextColor.Punctuation);
					for (int n = 0; n < genericInstSig.GenericArguments.Count; n++)
					{
						if (n > 0)
						{
							WriteCommaSpace();
						}
						Write(GenericArgumentResolver.Resolve(genericInstSig.GenericArguments[n], typeGenArgs, methGenArgs), null, null);
					}
					OutputWrite(">", BoxedTextColor.Punctuation);
					break;
				}
				case ElementType.FnPtr:
				{
					MethodSig methodSig = ((FnPtrSig)type).MethodSig;
					Write(methodSig.RetType, typeGenArgs, methGenArgs);
					WriteSpace();
					OutputWrite("(", BoxedTextColor.Punctuation);
					for (int j = 0; j < methodSig.Params.Count; j++)
					{
						if (j > 0)
						{
							WriteCommaSpace();
						}
						Write(methodSig.Params[j], typeGenArgs, methGenArgs);
					}
					if (methodSig.ParamsAfterSentinel != null)
					{
						if (methodSig.Params.Count > 0)
						{
							WriteCommaSpace();
						}
						OutputWrite("...", BoxedTextColor.Punctuation);
						for (int k = 0; k < methodSig.ParamsAfterSentinel.Count; k++)
						{
							WriteCommaSpace();
							Write(methodSig.ParamsAfterSentinel[k], typeGenArgs, methGenArgs);
						}
					}
					OutputWrite(")", BoxedTextColor.Punctuation);
					break;
				}
				case ElementType.CModReqd:
				case ElementType.CModOpt:
				case ElementType.Pinned:
					Write(type.Next, typeGenArgs, methGenArgs);
					break;
				case ElementType.End:
				case ElementType.Array:
				case ElementType.ValueArray:
				case ElementType.R:
				case ElementType.SZArray:
				case ElementType.Internal:
				case (ElementType)34:
				case (ElementType)35:
				case (ElementType)36:
				case (ElementType)37:
				case (ElementType)38:
				case (ElementType)39:
				case (ElementType)40:
				case (ElementType)41:
				case (ElementType)42:
				case (ElementType)43:
				case (ElementType)44:
				case (ElementType)45:
				case (ElementType)46:
				case (ElementType)47:
				case (ElementType)48:
				case (ElementType)49:
				case (ElementType)50:
				case (ElementType)51:
				case (ElementType)52:
				case (ElementType)53:
				case (ElementType)54:
				case (ElementType)55:
				case (ElementType)56:
				case (ElementType)57:
				case (ElementType)58:
				case (ElementType)59:
				case (ElementType)60:
				case (ElementType)61:
				case (ElementType)62:
				case ElementType.Module:
				case (ElementType)64:
				case ElementType.Sentinel:
				case (ElementType)66:
				case (ElementType)67:
				case (ElementType)68:
					break;
				}
			}
			finally
			{
				recursionCounter--;
			}
		}
	}

	private TypeSig Read(IList<TypeSig> list, int index)
	{
		if ((uint)index < (uint)list.Count)
		{
			return list[index];
		}
		return null;
	}

	public void WriteToolTip(ISourceVariable variable)
	{
		if (variable == null)
		{
			WriteError();
			return;
		}
		bool isLocal = variable.IsLocal;
		ParamDef paramDef = (variable.Variable as Parameter)?.ParamDef;
		OutputWrite("(", BoxedTextColor.Punctuation);
		OutputWrite(isLocal ? dnSpy_Decompiler_Resources.ToolTip_Local : dnSpy_Decompiler_Resources.ToolTip_Parameter, BoxedTextColor.Text);
		OutputWrite(")", BoxedTextColor.Punctuation);
		WriteSpace();
		Write(variable.Type, (!isLocal) ? ((Parameter)variable.Variable).ParamDef : null, null, null, (variable.Flags & SourceVariableFlags.ReadOnlyReference) != 0);
		WriteSpace();
		WriteIdentifier(TypeFormatterUtils.GetName(variable), isLocal ? BoxedTextColor.Local : BoxedTextColor.Parameter);
		if (paramDef != null)
		{
			WriteToken(paramDef);
		}
	}

	public void WriteNamespaceToolTip(string @namespace)
	{
		if (@namespace == null)
		{
			WriteError();
			return;
		}
		OutputWrite("namespace", BoxedTextColor.Keyword);
		WriteSpace();
		string[] array = @namespace.Split(namespaceSeparators);
		for (int i = 0; i < array.Length; i++)
		{
			if (i > 0)
			{
				OutputWrite(".", BoxedTextColor.Operator);
			}
			OutputWrite(array[i], BoxedTextColor.Namespace);
		}
	}

	private void Write(ModuleDef module)
	{
		try
		{
			if (recursionCounter++ < 200)
			{
				if (module == null)
				{
					OutputWrite("null module", BoxedTextColor.Error);
					return;
				}
				string fileName = TypeFormatterUtils.GetFileName(module.Location);
				OutputWrite(TypeFormatterUtils.FilterName(fileName), BoxedTextColor.AssemblyModule);
			}
		}
		finally
		{
			recursionCounter--;
		}
	}

	private void WriteModuleName(in FormatterMethodInfo info)
	{
		if (ShowModuleNames)
		{
			Write(info.ModuleDef);
			OutputWrite("!", BoxedTextColor.Operator);
		}
	}

	private void WriteModuleName(ModuleDef module)
	{
		if (module != null && ShowModuleNames)
		{
			Write(module);
			OutputWrite("!", BoxedTextColor.Operator);
		}
	}

	private void WriteReturnType(in FormatterMethodInfo info, bool writeSpace, bool isReadOnly)
	{
		if (ShowReturnTypes)
		{
			MethodDef methodDef = info.MethodDef;
			if (methodDef == null || !methodDef.IsConstructor)
			{
				ForceWriteReturnType(in info, writeSpace, isReadOnly);
			}
		}
	}

	private void ForceWriteReturnType(in FormatterMethodInfo info, bool writeSpace, bool isReadOnly)
	{
		if (info.MethodDef == null || !info.MethodDef.IsConstructor)
		{
			TypeSig typeSig;
			ParamDef ownerParam;
			if (info.RetTypeIsLastArgType)
			{
				typeSig = info.MethodSig.Params.LastOrDefault();
				ownerParam = ((info.MethodDef != null) ? info.MethodDef.Parameters.LastOrDefault()?.ParamDef : null);
			}
			else
			{
				typeSig = info.MethodSig.RetType;
				ownerParam = ((info.MethodDef == null) ? null : info.MethodDef.Parameters.ReturnParameter.ParamDef);
			}
			if ((typeSig.RemovePinnedAndModifiers() is ByRefSig) & isReadOnly)
			{
				typeSig = typeSig.RemovePinnedAndModifiers().Next;
				OutputWrite("ref", BoxedTextColor.Keyword);
				WriteSpace();
				OutputWrite("readonly", BoxedTextColor.Keyword);
				WriteSpace();
			}
			Write(typeSig, ownerParam, info.TypeGenericParams, info.MethodGenericParams);
			if (writeSpace)
			{
				WriteSpace();
			}
		}
	}

	private void WriteGenericArguments(in FormatterMethodInfo info)
	{
		if (info.MethodSig.GenParamCount != 0)
		{
			if (info.MethodGenericParams != null)
			{
				WriteGenerics(info.MethodGenericParams, BoxedTextColor.MethodGenericParameter, GenericParamContext.Create(info.MethodDef));
			}
			else if (info.MethodDef != null)
			{
				WriteGenerics(info.MethodDef.GenericParameters, BoxedTextColor.MethodGenericParameter);
			}
		}
	}

	private void WriteMethodParameterList(in FormatterMethodInfo info, string lparen, string rparen)
	{
		if (!ShowParameterTypes && !ShowParameterNames)
		{
			return;
		}
		OutputWrite(lparen, BoxedTextColor.Punctuation);
		int num = (info.MethodSig.HasThis ? 1 : 0);
		int num2 = info.MethodSig.Params.Count;
		if (info.RetTypeIsLastArgType)
		{
			num2--;
		}
		for (int i = 0; i < num2; i++)
		{
			if (i > 0)
			{
				WriteCommaSpace();
			}
			ParamDef paramDef = ((info.MethodDef == null || num + i >= info.MethodDef.Parameters.Count) ? null : info.MethodDef.Parameters[num + i].ParamDef);
			bool flag = TypeFormatterUtils.HasConstant(paramDef, out var constantAttribute);
			if (flag)
			{
				OutputWrite("[", BoxedTextColor.Punctuation);
			}
			bool flag2 = false;
			if (ShowParameterTypes)
			{
				flag2 = true;
				if (paramDef != null && paramDef.CustomAttributes.IsDefined("System.ParamArrayAttribute"))
				{
					OutputWrite("params", BoxedTextColor.Keyword);
					WriteSpace();
				}
				TypeSig type = info.MethodSig.Params[i];
				Write(type, paramDef, info.TypeGenericParams, info.MethodGenericParams);
			}
			if (ShowParameterNames)
			{
				if (flag2)
				{
					WriteSpace();
				}
				flag2 = true;
				if (paramDef != null)
				{
					WriteIdentifier(paramDef.Name, BoxedTextColor.Parameter);
					WriteToken(paramDef);
				}
				else
				{
					WriteIdentifier("A_" + (num + i), BoxedTextColor.Parameter);
				}
			}
			if ((ShowParameterLiteralValues & flag) && TypeFormatterUtils.TryGetConstant(paramDef, constantAttribute, out var constant))
			{
				if (flag2)
				{
					WriteSpace();
				}
				flag2 = true;
				WriteSpace();
				OutputWrite("=", BoxedTextColor.Operator);
				WriteSpace();
				TypeSig typeSig = info.MethodSig.Params[i].RemovePinnedAndModifiers();
				if (typeSig.GetElementType() == ElementType.ByRef)
				{
					typeSig = typeSig.Next;
				}
				if (constant == null && typeSig != null && typeSig.IsValueType)
				{
					OutputWrite("default", BoxedTextColor.Keyword);
				}
				else
				{
					WriteConstant(constant);
				}
			}
			if (flag)
			{
				OutputWrite("]", BoxedTextColor.Punctuation);
			}
		}
		OutputWrite(rparen, BoxedTextColor.Punctuation);
	}

	private void WriteGenerics(IList<GenericParam> gps, object gpTokenType)
	{
		if (gps == null || gps.Count == 0)
		{
			return;
		}
		OutputWrite("<", BoxedTextColor.Punctuation);
		for (int i = 0; i < gps.Count; i++)
		{
			if (i > 0)
			{
				WriteCommaSpace();
			}
			GenericParam genericParam = gps[i];
			if (genericParam.IsCovariant)
			{
				OutputWrite("out", BoxedTextColor.Keyword);
				WriteSpace();
			}
			else if (genericParam.IsContravariant)
			{
				OutputWrite("in", BoxedTextColor.Keyword);
				WriteSpace();
			}
			WriteIdentifier(genericParam.Name, gpTokenType);
			WriteToken(genericParam);
		}
		OutputWrite(">", BoxedTextColor.Punctuation);
	}

	private void WriteGenerics(IList<TypeSig> gps, object gpTokenType, GenericParamContext gpContext)
	{
		if (gps == null || gps.Count == 0)
		{
			return;
		}
		OutputWrite("<", BoxedTextColor.Punctuation);
		for (int i = 0; i < gps.Count; i++)
		{
			if (i > 0)
			{
				WriteCommaSpace();
			}
			Write(gps[i], null, null, null);
		}
		OutputWrite(">", BoxedTextColor.Punctuation);
	}

	private void FormatBoolean(bool value)
	{
		if (value)
		{
			OutputWrite("true", BoxedTextColor.Keyword);
		}
		else
		{
			OutputWrite("false", BoxedTextColor.Keyword);
		}
	}

	private void FormatChar(char value)
	{
		OutputWrite(ToFormattedChar(value), BoxedTextColor.Char);
	}

	private string ToFormattedChar(char value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('\'');
		switch (value)
		{
		case '\a':
			stringBuilder.Append("\\a");
			break;
		case '\b':
			stringBuilder.Append("\\b");
			break;
		case '\f':
			stringBuilder.Append("\\f");
			break;
		case '\n':
			stringBuilder.Append("\\n");
			break;
		case '\r':
			stringBuilder.Append("\\r");
			break;
		case '\t':
			stringBuilder.Append("\\t");
			break;
		case '\v':
			stringBuilder.Append("\\v");
			break;
		case '\\':
			stringBuilder.Append("\\\\");
			break;
		case '\0':
			stringBuilder.Append("\\0");
			break;
		case '\'':
			stringBuilder.Append("\\'");
			break;
		default:
			if (char.IsControl(value))
			{
				stringBuilder.Append("\\u");
				ushort num = value;
				stringBuilder.Append(num.ToString("X4"));
			}
			else
			{
				stringBuilder.Append(value);
			}
			break;
		}
		stringBuilder.Append('\'');
		return stringBuilder.ToString();
	}

	private static bool CanUseVerbatimString(string s)
	{
		bool result = false;
		foreach (char c in s)
		{
			switch (c)
			{
			case '\\':
				result = true;
				continue;
			case '\0':
			case '\a':
			case '\b':
			case '\t':
			case '\n':
			case '\v':
			case '\f':
			case '\r':
			case '\u0085':
			case '\u2028':
			case '\u2029':
				return false;
			case '"':
				continue;
			}
			if (char.IsControl(c))
			{
				return false;
			}
		}
		return result;
	}

	private void FormatString(string value)
	{
		string s = ToFormattedString(value, out var isVerbatim);
		OutputWrite(s, isVerbatim ? BoxedTextColor.VerbatimString : BoxedTextColor.String);
	}

	private string ToFormattedString(string value, out bool isVerbatim)
	{
		if (CanUseVerbatimString(value))
		{
			isVerbatim = true;
			return GetFormattedVerbatimString(value);
		}
		isVerbatim = false;
		return GetFormattedString(value);
	}

	private string GetFormattedString(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('"');
		foreach (char c in value)
		{
			switch (c)
			{
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
			case '\\':
				stringBuilder.Append("\\\\");
				continue;
			case '\0':
				stringBuilder.Append("\\0");
				continue;
			case '"':
				stringBuilder.Append("\\\"");
				continue;
			}
			if (char.IsControl(c))
			{
				stringBuilder.Append("\\u");
				ushort num = c;
				stringBuilder.Append(num.ToString("X4"));
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		stringBuilder.Append('"');
		return stringBuilder.ToString();
	}

	private string GetFormattedVerbatimString(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("@\"");
		foreach (char c in value)
		{
			if (c == '"')
			{
				stringBuilder.Append("\"\"");
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		stringBuilder.Append('"');
		return stringBuilder.ToString();
	}

	private string ToFormattedDecimalNumber(string number)
	{
		return ToFormattedNumber(string.Empty, number, 3);
	}

	private string ToFormattedHexNumber(string number)
	{
		return ToFormattedNumber("0x", number, 4);
	}

	private string ToFormattedNumber(string prefix, string number, int digitGroupSize)
	{
		return TypeFormatterUtils.ToFormattedNumber(DigitSeparators, prefix, number, digitGroupSize);
	}

	private void WriteNumber(string number)
	{
		OutputWrite(number, BoxedTextColor.Number);
	}

	private string ToFormattedSByte(sbyte value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X2"));
	}

	private string ToFormattedByte(byte value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X2"));
	}

	private string ToFormattedInt16(short value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X4"));
	}

	private string ToFormattedUInt16(ushort value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X4"));
	}

	private string ToFormattedInt32(int value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X8"));
	}

	private string ToFormattedUInt32(uint value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X8"));
	}

	private string ToFormattedInt64(long value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X16"));
	}

	private string ToFormattedUInt64(ulong value)
	{
		if (UseDecimal)
		{
			return ToFormattedDecimalNumber(value.ToString(cultureInfo));
		}
		return ToFormattedHexNumber(value.ToString("X16"));
	}

	private void FormatSingle(float value)
	{
		if (float.IsNaN(value))
		{
			OutputWrite("NaN", BoxedTextColor.Number);
		}
		else if (float.IsNegativeInfinity(value))
		{
			OutputWrite("-Infinity", BoxedTextColor.Number);
		}
		else if (float.IsPositiveInfinity(value))
		{
			OutputWrite("Infinity", BoxedTextColor.Number);
		}
		else
		{
			OutputWrite(value.ToString(cultureInfo), BoxedTextColor.Number);
		}
	}

	private void FormatDouble(double value)
	{
		if (double.IsNaN(value))
		{
			OutputWrite("NaN", BoxedTextColor.Number);
		}
		else if (double.IsNegativeInfinity(value))
		{
			OutputWrite("-Infinity", BoxedTextColor.Number);
		}
		else if (double.IsPositiveInfinity(value))
		{
			OutputWrite("Infinity", BoxedTextColor.Number);
		}
		else
		{
			OutputWrite(value.ToString(cultureInfo), BoxedTextColor.Number);
		}
	}

	private void FormatSByte(sbyte value)
	{
		WriteNumber(ToFormattedSByte(value));
	}

	private void FormatByte(byte value)
	{
		WriteNumber(ToFormattedByte(value));
	}

	private void FormatInt16(short value)
	{
		WriteNumber(ToFormattedInt16(value));
	}

	private void FormatUInt16(ushort value)
	{
		WriteNumber(ToFormattedUInt16(value));
	}

	private void FormatInt32(int value)
	{
		WriteNumber(ToFormattedInt32(value));
	}

	private void FormatUInt32(uint value)
	{
		WriteNumber(ToFormattedUInt32(value));
	}

	private void FormatInt64(long value)
	{
		WriteNumber(ToFormattedInt64(value));
	}

	private void FormatUInt64(ulong value)
	{
		WriteNumber(ToFormattedUInt64(value));
	}

	private void FormatDecimal(decimal value)
	{
		OutputWrite(value.ToString(cultureInfo), BoxedTextColor.Number);
	}
}
