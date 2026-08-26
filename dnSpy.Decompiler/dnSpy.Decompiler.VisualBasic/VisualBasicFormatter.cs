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

namespace dnSpy.Decompiler.VisualBasic;

public struct VisualBasicFormatter
{
	private const string Keyword_true = "True";

	private const string Keyword_false = "False";

	private const string Keyword_null = "Nothing";

	private const string Keyword_As = "As";

	private const string Keyword_out = "Out";

	private const string Keyword_in = "In";

	private const string Keyword_get = "Get";

	private const string Keyword_set = "Set";

	private const string Keyword_add = "Add";

	private const string Keyword_remove = "Remove";

	private const string Keyword_module = "Module";

	private const string Keyword_enum = "Enum";

	private const string Keyword_struct = "Structure";

	private const string Keyword_interface = "Interface";

	private const string Keyword_class = "Class";

	private const string Keyword_namespace = "Namespace";

	private const string Keyword_params = "ParamArray";

	private const string Keyword_delegate = "Delegate";

	private const string Keyword_ByRef = "ByRef";

	private const string Keyword_New = "New";

	private const string Keyword_Sub = "Sub";

	private const string Keyword_Function = "Function";

	private const string Keyword_ReadOnly = "ReadOnly";

	private const string Keyword_Property = "Property";

	private const string Keyword_Event = "Event";

	private const string HexPrefix = "&H";

	private const string IdentifierEscapeBegin = "[";

	private const string IdentifierEscapeEnd = "]";

	private const string ModuleNameSeparator = "!";

	private const string CommentBegin = "/*";

	private const string CommentEnd = "*/";

	private const string DeprecatedParenOpen = "(";

	private const string DeprecatedParenClose = ")";

	private const string MemberSpecialParenOpen = "<";

	private const string MemberSpecialParenClose = ">";

	private const string MethodParenOpen = "(";

	private const string MethodParenClose = ")";

	private const string DescriptionParenOpen = "(";

	private const string DescriptionParenClose = ")";

	private const string PropertyParenOpen = "(";

	private const string PropertyParenClose = ")";

	private const string ArrayParenOpen = "(";

	private const string ArrayParenClose = ")";

	private const string TupleParenOpen = "(";

	private const string TupleParenClose = ")";

	private const string GenericParenOpen = "(";

	private const string GenericParenClose = ")";

	private const string Keyword_Of = "Of";

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
			"op_UnaryPlus",
			"Operator +".Split(' ')
		},
		{
			"op_UnaryNegation",
			"Operator -".Split(' ')
		},
		{
			"op_False",
			"Operator IsFalse".Split(' ')
		},
		{
			"op_True",
			"Operator IsTrue".Split(' ')
		},
		{
			"op_OnesComplement",
			"Operator Not".Split(' ')
		},
		{
			"op_Addition",
			"Operator +".Split(' ')
		},
		{
			"op_Subtraction",
			"Operator -".Split(' ')
		},
		{
			"op_Multiply",
			"Operator *".Split(' ')
		},
		{
			"op_Division",
			"Operator /".Split(' ')
		},
		{
			"op_IntegerDivision",
			"Operator \\".Split(' ')
		},
		{
			"op_Concatenate",
			"Operator &".Split(' ')
		},
		{
			"op_Exponent",
			"Operator ^".Split(' ')
		},
		{
			"op_RightShift",
			"Operator >>".Split(' ')
		},
		{
			"op_LeftShift",
			"Operator <<".Split(' ')
		},
		{
			"op_Equality",
			"Operator =".Split(' ')
		},
		{
			"op_Inequality",
			"Operator <>".Split(' ')
		},
		{
			"op_GreaterThan",
			"Operator >".Split(' ')
		},
		{
			"op_GreaterThanOrEqual",
			"Operator >=".Split(' ')
		},
		{
			"op_LessThan",
			"Operator <".Split(' ')
		},
		{
			"op_LessThanOrEqual",
			"Operator <=".Split(' ')
		},
		{
			"op_BitwiseAnd",
			"Operator And".Split(' ')
		},
		{
			"op_Like",
			"Operator Like".Split(' ')
		},
		{
			"op_Modulus",
			"Operator Mod".Split(' ')
		},
		{
			"op_BitwiseOr",
			"Operator Or".Split(' ')
		},
		{
			"op_ExclusiveOr",
			"Operator Xor".Split(' ')
		},
		{
			"op_Implicit",
			"Widening Operator CType".Split(' ')
		},
		{
			"op_Explicit",
			"Narrowing Operator CType".Split(' ')
		}
	};

	private static readonly HashSet<string> isKeyword = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"#Const", "#Else", "#ElseIf", "#End", "#If", "AddHandler", "AddressOf", "Alias", "And", "AndAlso",
		"As", "Boolean", "ByRef", "Byte", "ByVal", "Call", "Case", "Catch", "CBool", "CByte",
		"CChar", "CDate", "CDbl", "CDec", "Char", "CInt", "Class", "CLng", "CObj", "Const",
		"Continue", "CSByte", "CShort", "CSng", "CStr", "CType", "CUInt", "CULng", "CUShort", "Date",
		"Decimal", "Declare", "Default", "Delegate", "Dim", "DirectCast", "Do", "Double", "Each", "Else",
		"ElseIf", "End", "EndIf", "Enum", "Erase", "Error", "Event", "Exit", "False", "Finally",
		"For", "Friend", "Function", "Get", "GetType", "GetXMLNamespace", "Global", "GoSub", "GoTo", "Handles",
		"If", "Implements", "Imports", "In", "Inherits", "Integer", "Interface", "Is", "IsNot", "Let",
		"Lib", "Like", "Long", "Loop", "Me", "Mod", "Module", "MustInherit", "MustOverride", "MyBase",
		"MyClass", "Namespace", "Narrowing", "New", "Next", "Not", "Nothing", "NotInheritable", "NotOverridable", "Object",
		"Of", "On", "Operator", "Option", "Optional", "Or", "OrElse", "Out", "Overloads", "Overridable",
		"Overrides", "ParamArray", "Partial", "Private", "Property", "Protected", "Public", "RaiseEvent", "ReadOnly", "ReDim",
		"REM", "RemoveHandler", "Resume", "Return", "SByte", "Select", "Set", "Shadows", "Shared", "Short",
		"Single", "Static", "Step", "Stop", "String", "Structure", "Sub", "SyncLock", "Then", "Throw",
		"To", "True", "Try", "TryCast", "TypeOf", "UInteger", "ULong", "UShort", "Using", "Variant",
		"Wend", "When", "While", "Widening", "With", "WithEvents", "WriteOnly", "Xor"
	};

	private static readonly UTF8String stringMicrosoftVisualBasicCompilerServices = new UTF8String("Microsoft.VisualBasic.CompilerServices");

	private static readonly UTF8String stringStandardModuleAttribute = new UTF8String("StandardModuleAttribute");

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

	public VisualBasicFormatter(ITextColorWriter output, FormatterOptions options, CultureInfo cultureInfo)
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
			OutputWrite("[" + IdentifierEscaper.Escape(id) + "]", data);
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
		OutputWrite(name, isValueType ? BoxedTextColor.ValueType : BoxedTextColor.Type);
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
			OutputWrite("(", BoxedTextColor.Punctuation);
			OutputWrite(dnSpy_Decompiler_Resources.VisualBasic_Deprecated_Member, BoxedTextColor.Text);
			OutputWrite(")", BoxedTextColor.Punctuation);
			WriteSpace();
		}
	}

	private void Write(MemberSpecialFlags flags)
	{
		if (flags == MemberSpecialFlags.None)
		{
			return;
		}
		OutputWrite("<", BoxedTextColor.Punctuation);
		bool flag = false;
		if ((flags & MemberSpecialFlags.Awaitable) != MemberSpecialFlags.None)
		{
			flag = true;
			OutputWrite(dnSpy_Decompiler_Resources.VisualBasic_Awaitable_Method, BoxedTextColor.Text);
		}
		if ((flags & MemberSpecialFlags.Extension) != MemberSpecialFlags.None)
		{
			if (flag)
			{
				WriteCommaSpace();
			}
			OutputWrite(dnSpy_Decompiler_Resources.VisualBasic_Extension_Method, BoxedTextColor.Text);
		}
		OutputWrite(">", BoxedTextColor.Punctuation);
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
		WriteIdentifier(TypeFormatterUtils.RemoveGenericTick(typeDef.Name), VisualBasicMetadataTextColorProvider.Instance.GetColor(typeDef));
		WriteToken(type);
		GenericParam[] gps = typeDef.GenericParameters.Skip(typeDef.GenericParameters.Count - num).ToArray();
		WriteGenerics(gps, BoxedTextColor.TypeGenericParameter);
	}

	private void WriteAccessor(AccessorKind kind)
	{
		OutputWrite(kind switch
		{
			AccessorKind.Getter => "Get", 
			AccessorKind.Setter => "Set", 
			AccessorKind.Adder => "Add", 
			AccessorKind.Remover => "Remove", 
			_ => throw new InvalidOperationException(), 
		}, BoxedTextColor.Keyword);
		WriteSpace();
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
			Write(tuple.Item1, tuple.Item2);
			return;
		}
		(EventDef, AccessorKind) tuple2 = TypeFormatterUtils.TryGetEvent(method as MethodDef);
		if (tuple2.Item2 != AccessorKind.None)
		{
			Write(tuple2.Item1, tuple2.Item2);
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
		if (array != null)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				WriteOperatorInfoString(array[i]);
				WriteSpace();
			}
		}
		else
		{
			bool flag = IsSub(in info);
			OutputWrite(flag ? "Sub" : "Function", BoxedTextColor.Keyword);
			WriteSpace();
		}
		if (ShowDeclaringTypes)
		{
			Write(method.DeclaringType);
			WritePeriod();
		}
		if (info.MethodDef != null && info.MethodDef.IsConstructor && method.DeclaringType != null)
		{
			OutputWrite("New", BoxedTextColor.Keyword);
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
		WriteToken(method);
		WriteGenericArguments(in info);
		WriteMethodParameterList(in info, "(", ")");
		WriteReturnType(in info);
	}

	private static string[] TryGetOperatorInfo(string name)
	{
		nameToOperatorName.TryGetValue(name, out var value);
		return value;
	}

	private void WriteOperatorInfoString(string s)
	{
		OutputWrite(s, ('A' <= s[0] && s[0] <= 'Z') ? BoxedTextColor.Keyword : BoxedTextColor.Operator);
	}

	private void WriteMethodName(IMethod method, string name, string[] operatorInfo)
	{
		if (operatorInfo != null)
		{
			WriteOperatorInfoString(operatorInfo[operatorInfo.Length - 1]);
		}
		else
		{
			WriteIdentifier(name, VisualBasicMetadataTextColorProvider.Instance.GetColor(method));
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
		if ((!flag || (fieldDef != null && !fieldDef.IsLiteral)) && isToolTip)
		{
			OutputWrite("(", BoxedTextColor.Punctuation);
			OutputWrite(flag2 ? dnSpy_Decompiler_Resources.ToolTip_Constant : dnSpy_Decompiler_Resources.ToolTip_Field, BoxedTextColor.Text);
			OutputWrite(")", BoxedTextColor.Punctuation);
			WriteSpace();
		}
		WriteModuleName(fieldDef?.Module);
		if (ShowDeclaringTypes)
		{
			Write(field.DeclaringType);
			WritePeriod();
		}
		WriteIdentifier(field.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(field));
		WriteToken(field);
		if (!flag)
		{
			WriteSpace();
			OutputWrite("As", BoxedTextColor.Keyword);
			WriteSpace();
			Write(fieldSig.Type, null, null, null);
		}
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
			OutputWrite("Nothing", BoxedTextColor.Keyword);
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
		Write(prop, AccessorKind.None);
	}

	private void Write(PropertyDef prop, AccessorKind accessorKind)
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
		if (methodDef2 == null)
		{
			OutputWrite("ReadOnly", BoxedTextColor.Keyword);
			WriteSpace();
		}
		OutputWrite("Property", BoxedTextColor.Keyword);
		WriteSpace();
		MethodDef methodDef4 = methodDef3;
		if (accessorKind != AccessorKind.None)
		{
			methodDef4 = accessorKind switch
			{
				AccessorKind.Getter => methodDef ?? methodDef3, 
				AccessorKind.Setter => methodDef2 ?? methodDef3, 
				_ => throw new InvalidOperationException(), 
			};
			WriteAccessor(accessorKind);
		}
		FormatterMethodInfo info = new FormatterMethodInfo(methodDef4, methodDef4 == methodDef2, accessorKind == AccessorKind.Setter);
		WriteModuleName(in info);
		if (ShowDeclaringTypes)
		{
			Write(prop.DeclaringType);
			WritePeriod();
		}
		IMethodDefOrRef methodDefOrRef = ((methodDef3 == null || methodDef3.Overrides.Count == 0) ? null : methodDef3.Overrides[0].MethodDeclaration);
		if (methodDefOrRef != null && TypeFormatterUtils.GetPropertyName(methodDefOrRef) != null)
		{
			WriteIdentifier(TypeFormatterUtils.GetPropertyName(methodDefOrRef), VisualBasicMetadataTextColorProvider.Instance.GetColor(prop));
		}
		else
		{
			WriteIdentifier(prop.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(prop));
		}
		WriteToken(prop);
		WriteGenericArguments(in info);
		if (accessorKind != AccessorKind.None || prop.PropertySig.GetParamCount() != 0)
		{
			WriteMethodParameterList(in info, "(", ")");
		}
		WriteReturnType(in info);
	}

	private void WriteToolTip(EventDef evt)
	{
		WriteDeprecated(TypeFormatterUtils.IsDeprecated(evt));
		Write(evt);
	}

	private void Write(EventDef evt)
	{
		Write(evt, AccessorKind.None);
	}

	private void Write(EventDef evt, AccessorKind accessorKind)
	{
		if (evt == null)
		{
			WriteError();
			return;
		}
		OutputWrite("Event", BoxedTextColor.Keyword);
		WriteSpace();
		if (accessorKind != AccessorKind.None)
		{
			WriteAccessor(accessorKind);
		}
		WriteModuleName(evt.Module);
		if (ShowDeclaringTypes)
		{
			Write(evt.DeclaringType);
			WritePeriod();
		}
		WriteIdentifier(evt.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(evt));
		WriteToken(evt);
		WriteSpace();
		OutputWrite("As", BoxedTextColor.Keyword);
		WriteSpace();
		Write(evt.EventType);
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
		WriteIdentifier(gp.Name, VisualBasicMetadataTextColorProvider.Instance.GetColor(gp));
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
			OutputWrite("Delegate", BoxedTextColor.Keyword);
			WriteSpace();
			FormatterMethodInfo info = new FormatterMethodInfo(methodDef);
			WriteModuleName(in info);
			bool flag = IsSub(in info);
			OutputWrite(flag ? "Sub" : "Function", BoxedTextColor.Keyword);
			WriteSpace();
			WriteType(typeDef, useNamespaces: true, ShowIntrinsicTypeKeywords);
			WriteGenericArguments(in info);
			WriteMethodParameterList(in info, "(", ")");
			WriteReturnType(in info);
		}
		else
		{
			WriteModuleName(typeDef?.Module);
			if (typeDef == null)
			{
				Write(type);
				return;
			}
			string s = (IsModule(typeDef) ? "Module" : (typeDef.IsEnum ? "Enum" : (typeDef.IsValueType ? "Structure" : ((!typeDef.IsInterface) ? "Class" : "Interface"))));
			OutputWrite(s, BoxedTextColor.Keyword);
			WriteSpace();
			WriteType(type, useNamespaces: true, useTypeKeywords: false);
		}
	}

	private static bool IsModule(TypeDef type)
	{
		return type != null && type.DeclaringType == null && type.IsSealed && type.IsDefined(stringMicrosoftVisualBasicCompilerServices, stringStandardModuleAttribute);
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
					WriteIdentifier(TypeFormatterUtils.RemoveGenericTick(type.Name), VisualBasicMetadataTextColorProvider.Instance.GetColor(type));
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
			"Boolean" => "Boolean", 
			"Byte" => "Byte", 
			"Char" => "Char", 
			"DateTime" => "Date", 
			"Decimal" => "Decimal", 
			"Double" => "Double", 
			"Int16" => "Short", 
			"Int32" => "Integer", 
			"Int64" => "Long", 
			"Object" => "Object", 
			"SByte" => "SByte", 
			"Single" => "Single", 
			"String" => "String", 
			"UInt16" => "UShort", 
			"UInt32" => "UInteger", 
			"UInt64" => "ULong", 
			_ => null, 
		};
	}

	private void Write(TypeSig type, ParamDef ownerParam, IList<TypeSig> typeGenArgs, IList<TypeSig> methGenArgs)
	{
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
								OutputWrite("(", BoxedTextColor.Punctuation);
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
								OutputWrite(")", BoxedTextColor.Punctuation);
							}
							else
							{
								Debug.Assert(item.ElementType == ElementType.SZArray);
								OutputWrite("(", BoxedTextColor.Punctuation);
								OutputWrite(")", BoxedTextColor.Punctuation);
							}
						}
						return;
					}
				}
				switch (type.ElementType)
				{
				case ElementType.Void:
					WriteSystemType("Void", isValueType: true);
					break;
				case ElementType.Boolean:
					WriteSystemTypeKeyword("Boolean", "Boolean", isValueType: true);
					break;
				case ElementType.Char:
					WriteSystemTypeKeyword("Char", "Char", isValueType: true);
					break;
				case ElementType.I1:
					WriteSystemTypeKeyword("SByte", "SByte", isValueType: true);
					break;
				case ElementType.U1:
					WriteSystemTypeKeyword("Byte", "Byte", isValueType: true);
					break;
				case ElementType.I2:
					WriteSystemTypeKeyword("Int16", "Short", isValueType: true);
					break;
				case ElementType.U2:
					WriteSystemTypeKeyword("UInt16", "UShort", isValueType: true);
					break;
				case ElementType.I4:
					WriteSystemTypeKeyword("Int32", "Integer", isValueType: true);
					break;
				case ElementType.U4:
					WriteSystemTypeKeyword("UInt32", "UInteger", isValueType: true);
					break;
				case ElementType.I8:
					WriteSystemTypeKeyword("Int64", "Long", isValueType: true);
					break;
				case ElementType.U8:
					WriteSystemTypeKeyword("UInt64", "ULong", isValueType: true);
					break;
				case ElementType.R4:
					WriteSystemTypeKeyword("Single", "Single", isValueType: true);
					break;
				case ElementType.R8:
					WriteSystemTypeKeyword("Double", "Double", isValueType: true);
					break;
				case ElementType.String:
					WriteSystemTypeKeyword("String", "String", isValueType: false);
					break;
				case ElementType.Object:
					WriteSystemTypeKeyword("Object", "Object", isValueType: false);
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
					OutputWrite("ByRef", BoxedTextColor.Keyword);
					WriteSpace();
					Write(type.Next, typeGenArgs, methGenArgs);
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
					OutputWrite("(", BoxedTextColor.Punctuation);
					OutputWrite("Of", BoxedTextColor.Keyword);
					WriteSpace();
					for (int n = 0; n < genericInstSig.GenericArguments.Count; n++)
					{
						if (n > 0)
						{
							WriteCommaSpace();
						}
						Write(GenericArgumentResolver.Resolve(genericInstSig.GenericArguments[n], typeGenArgs, methGenArgs), null, null);
					}
					OutputWrite(")", BoxedTextColor.Punctuation);
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
		TypeSig typeSig = variable.Type;
		OutputWrite("(", BoxedTextColor.Punctuation);
		OutputWrite(isLocal ? dnSpy_Decompiler_Resources.ToolTip_Local : dnSpy_Decompiler_Resources.ToolTip_Parameter, BoxedTextColor.Text);
		OutputWrite(")", BoxedTextColor.Punctuation);
		WriteSpace();
		if (typeSig.GetElementType() == ElementType.ByRef)
		{
			typeSig = typeSig.Next;
			OutputWrite("ByRef", BoxedTextColor.Keyword);
			WriteSpace();
		}
		WriteIdentifier(TypeFormatterUtils.GetName(variable), isLocal ? BoxedTextColor.Local : BoxedTextColor.Parameter);
		if (paramDef != null)
		{
			WriteToken(paramDef);
		}
		WriteSpace();
		OutputWrite("As", BoxedTextColor.Keyword);
		WriteSpace();
		Write(typeSig, (!isLocal) ? ((Parameter)variable.Variable).ParamDef : null, null, null);
	}

	public void WriteNamespaceToolTip(string @namespace)
	{
		if (@namespace == null)
		{
			WriteError();
			return;
		}
		OutputWrite("Namespace", BoxedTextColor.Keyword);
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

	private void WriteReturnType(in FormatterMethodInfo info)
	{
		if (ShowReturnTypes && !IsSub(in info) && (info.MethodDef == null || !info.MethodDef.IsConstructor))
		{
			(TypeSig, ParamDef) returnTypeInfo = GetReturnTypeInfo(in info);
			WriteSpace();
			OutputWrite("As", BoxedTextColor.Keyword);
			WriteSpace();
			Write(returnTypeInfo.Item1, returnTypeInfo.Item2, info.TypeGenericParams, info.MethodGenericParams);
		}
	}

	private static bool IsSub(in FormatterMethodInfo info)
	{
		return GetReturnTypeInfo(in info).returnType.RemovePinnedAndModifiers().GetElementType() == ElementType.Void;
	}

	private static (TypeSig returnType, ParamDef paramDef) GetReturnTypeInfo(in FormatterMethodInfo info)
	{
		TypeSig item;
		ParamDef item2;
		if (info.RetTypeIsLastArgType)
		{
			item = info.MethodSig.Params.LastOrDefault();
			item2 = ((info.MethodDef != null) ? info.MethodDef.Parameters.LastOrDefault()?.ParamDef : null);
		}
		else
		{
			item = info.MethodSig.RetType;
			item2 = ((info.MethodDef == null) ? null : info.MethodDef.Parameters.ReturnParameter.ParamDef);
		}
		return (returnType: item, paramDef: item2);
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
		if (info.RetTypeIsLastArgType && !info.IncludeReturnTypeInArgsList)
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
			TypeSig typeSig = info.MethodSig.Params[i];
			if (ShowParameterNames || ShowParameterTypes)
			{
				if (typeSig.GetElementType() == ElementType.ByRef)
				{
					typeSig = typeSig.Next;
					OutputWrite("ByRef", BoxedTextColor.Keyword);
					WriteSpace();
				}
				if (paramDef != null && paramDef.CustomAttributes.IsDefined("System.ParamArrayAttribute"))
				{
					OutputWrite("ParamArray", BoxedTextColor.Keyword);
					flag2 = true;
				}
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
			if (ShowParameterTypes)
			{
				if (ShowParameterNames)
				{
					WriteSpace();
					OutputWrite("As", BoxedTextColor.Keyword);
				}
				if (flag2)
				{
					WriteSpace();
				}
				flag2 = true;
				Write(typeSig, paramDef, info.TypeGenericParams, info.MethodGenericParams);
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
				WriteConstant(constant);
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
		OutputWrite("(", BoxedTextColor.Punctuation);
		OutputWrite("Of", BoxedTextColor.Keyword);
		WriteSpace();
		for (int i = 0; i < gps.Count; i++)
		{
			if (i > 0)
			{
				WriteCommaSpace();
			}
			GenericParam genericParam = gps[i];
			if (genericParam.IsCovariant)
			{
				OutputWrite("Out", BoxedTextColor.Keyword);
				WriteSpace();
			}
			else if (genericParam.IsContravariant)
			{
				OutputWrite("In", BoxedTextColor.Keyword);
				WriteSpace();
			}
			WriteIdentifier(genericParam.Name, gpTokenType);
			WriteToken(genericParam);
		}
		OutputWrite(")", BoxedTextColor.Punctuation);
	}

	private void WriteGenerics(IList<TypeSig> gps, object gpTokenType, GenericParamContext gpContext)
	{
		if (gps == null || gps.Count == 0)
		{
			return;
		}
		OutputWrite("(", BoxedTextColor.Punctuation);
		OutputWrite("Of", BoxedTextColor.Keyword);
		WriteSpace();
		for (int i = 0; i < gps.Count; i++)
		{
			if (i > 0)
			{
				WriteCommaSpace();
			}
			Write(gps[i], null, null, null);
		}
		OutputWrite(")", BoxedTextColor.Punctuation);
	}

	private void FormatBoolean(bool value)
	{
		if (value)
		{
			OutputWrite("True", BoxedTextColor.Keyword);
		}
		else
		{
			OutputWrite("False", BoxedTextColor.Keyword);
		}
	}

	private void FormatChar(char value)
	{
		switch (value)
		{
		case '\r':
			OutputWrite("vbCr", BoxedTextColor.LiteralField);
			return;
		case '\n':
			OutputWrite("vbLf", BoxedTextColor.LiteralField);
			return;
		case '\b':
			OutputWrite("vbBack", BoxedTextColor.LiteralField);
			return;
		case '\f':
			OutputWrite("vbFormFeed", BoxedTextColor.LiteralField);
			return;
		case '\t':
			OutputWrite("vbTab", BoxedTextColor.LiteralField);
			return;
		case '\v':
			OutputWrite("vbVerticalTab", BoxedTextColor.LiteralField);
			return;
		case '\0':
			OutputWrite("vbNullChar", BoxedTextColor.LiteralField);
			return;
		case '"':
			OutputWrite("\"\"\"\"c", BoxedTextColor.Char);
			return;
		}
		if (char.IsControl(value))
		{
			WriteCharW(value);
		}
		else
		{
			OutputWrite("\"" + value + "\"c", BoxedTextColor.Char);
		}
	}

	private void WriteCharW(char value)
	{
		OutputWrite("ChrW", BoxedTextColor.StaticMethod);
		OutputWrite("(", BoxedTextColor.Punctuation);
		FormatUInt16(value);
		OutputWrite(")", BoxedTextColor.Punctuation);
	}

	private void FormatString(string value)
	{
		if (value == string.Empty)
		{
			OutputWrite("\"\"", BoxedTextColor.String);
			return;
		}
		int index = 0;
		bool needSep = false;
		while (index < value.Length)
		{
			string subString = GetSubString(value, ref index);
			if (subString.Length != 0)
			{
				if (needSep)
				{
					WriteStringConcatOperator();
				}
				OutputWrite("\"" + subString + "\"", BoxedTextColor.String);
				needSep = true;
			}
			if (index >= value.Length)
			{
				continue;
			}
			char c = value[index];
			switch (c)
			{
			case '\r':
				if (index + 1 < value.Length && value[index + 1] == '\n')
				{
					WriteSpecialConstantString("vbCrLf", ref needSep);
					index++;
				}
				else
				{
					WriteSpecialConstantString("vbCr", ref needSep);
				}
				break;
			case '\n':
				WriteSpecialConstantString("vbLf", ref needSep);
				break;
			case '\b':
				WriteSpecialConstantString("vbBack", ref needSep);
				break;
			case '\f':
				WriteSpecialConstantString("vbFormFeed", ref needSep);
				break;
			case '\t':
				WriteSpecialConstantString("vbTab", ref needSep);
				break;
			case '\v':
				WriteSpecialConstantString("vbVerticalTab", ref needSep);
				break;
			case '\0':
				WriteSpecialConstantString("vbNullChar", ref needSep);
				break;
			default:
				if (needSep)
				{
					WriteStringConcatOperator();
				}
				WriteCharW(c);
				break;
			}
			index++;
			needSep = true;
		}
	}

	private void WriteStringConcatOperator()
	{
		WriteSpace();
		OutputWrite("&", BoxedTextColor.Operator);
		WriteSpace();
	}

	private void WriteSpecialConstantString(string s, ref bool needSep)
	{
		if (needSep)
		{
			WriteStringConcatOperator();
		}
		OutputWrite(s, BoxedTextColor.LiteralField);
		needSep = true;
	}

	private string GetSubString(string value, ref int index)
	{
		StringBuilder stringBuilder = new StringBuilder();
		while (index < value.Length)
		{
			char c = value[index];
			bool flag;
			switch (c)
			{
			case '"':
				stringBuilder.Append(c);
				flag = false;
				break;
			case '\0':
			case '\b':
			case '\t':
			case '\n':
			case '\v':
			case '\f':
			case '\r':
			case '\u0085':
			case '\u2028':
			case '\u2029':
				flag = true;
				break;
			default:
				flag = char.IsControl(c);
				break;
			}
			if (flag)
			{
				break;
			}
			stringBuilder.Append(c);
			index++;
		}
		return stringBuilder.ToString();
	}

	private string ToFormattedDecimalNumber(string number)
	{
		return ToFormattedNumber(string.Empty, number, 3);
	}

	private string ToFormattedHexNumber(string number)
	{
		return ToFormattedNumber("&H", number, 4);
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
