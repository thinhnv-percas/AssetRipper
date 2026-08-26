using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using ICSharpCode.Decompiler.ILAst;

namespace ICSharpCode.Decompiler.Ast;

public class NameVariables
{
	private static readonly Dictionary<string, string> typeNameToVariableNameDict = new Dictionary<string, string>
	{
		{ "System.Boolean", "flag" },
		{ "System.Byte", "b" },
		{ "System.SByte", "b" },
		{ "System.Int16", "num" },
		{ "System.Int32", "num" },
		{ "System.Int64", "num" },
		{ "System.UInt16", "num" },
		{ "System.UInt32", "num" },
		{ "System.UInt64", "num" },
		{ "System.Single", "num" },
		{ "System.Double", "num" },
		{ "System.Decimal", "num" },
		{ "System.String", "text" },
		{ "System.Object", "obj" },
		{ "System.Char", "c" }
	};

	private readonly StringBuilder stringBuilder;

	private DecompilerContext context;

	private List<string> fieldNamesInCurrentType;

	private Dictionary<string, int> typeNames = new Dictionary<string, int>();

	private const char maxLoopVariableName = 'n';

	private static readonly UTF8String nameGetCurrent = new UTF8String("get_Current");

	private static readonly UTF8String systemString = new UTF8String("System");

	private static readonly UTF8String nullableString = new UTF8String("Nullable`1");

	public NameVariables(StringBuilder sb)
	{
		stringBuilder = sb;
	}

	public static void AssignNamesToVariables(DecompilerContext context, IEnumerable<ILVariable> parameters, HashSet<ILVariable> variables, ILBlock methodBody, StringBuilder stringBuilder)
	{
		NameVariables nameVariables = new NameVariables(stringBuilder);
		nameVariables.context = context;
		nameVariables.fieldNamesInCurrentType = context.CurrentType.Fields.Select((FieldDef f) => f.Name.String).ToList();
		foreach (string reservedVariableName in context.ReservedVariableNames)
		{
			nameVariables.AddExistingName(reservedVariableName);
		}
		foreach (ILVariable parameter in parameters)
		{
			nameVariables.AddExistingName(parameter.Name);
		}
		foreach (ILVariable variable in variables)
		{
			if (variable.Renamed)
			{
				nameVariables.AddExistingName(variable.Name);
			}
		}
		foreach (ILVariable variable2 in variables)
		{
			if (!variable2.Renamed)
			{
				if (variable2.OriginalVariable != null && context.Settings.UseDebugSymbols)
				{
					string name = variable2.OriginalVariable.Name;
					variable2.Name = GetName(nameVariables, name);
				}
				else
				{
					variable2.Name = GetName(nameVariables, TryGetLocalName(variable2));
				}
			}
		}
		foreach (ILVariable parameter2 in parameters)
		{
			if (!parameter2.Renamed)
			{
				parameter2.Renamed = true;
				if (string.IsNullOrEmpty(parameter2.Name))
				{
					parameter2.Name = nameVariables.GenerateNameForVariable(parameter2, methodBody);
				}
			}
		}
		foreach (ILVariable variable3 in variables)
		{
			if (!variable3.Renamed)
			{
				variable3.Renamed = true;
				if (string.IsNullOrEmpty(variable3.Name))
				{
					variable3.Name = nameVariables.GenerateNameForVariable(variable3, methodBody);
				}
			}
		}
	}

	private static string GetName(NameVariables nv, string name)
	{
		if (string.IsNullOrEmpty(name) || name.StartsWith("V_", StringComparison.Ordinal) || !IsValidName(name))
		{
			return null;
		}
		return nv.GetAlternativeName(name);
	}

	private static string TryGetLocalName(ILVariable v)
	{
		if (v.GeneratedByDecompiler)
		{
			return null;
		}
		if (v.OriginalParameter != null)
		{
			return null;
		}
		if (v.OriginalVariable != null)
		{
			return null;
		}
		string name = v.Name;
		if (name.Length == 0)
		{
			return null;
		}
		switch (name[0])
		{
		case '<':
		{
			int num2 = name.IndexOf('>', 1);
			if (num2 < 0)
			{
				return null;
			}
			if (num2 + 1 >= name.Length)
			{
				return null;
			}
			char c = name[num2 + 1];
			if (c != '5' && c != '_')
			{
				return null;
			}
			return name.Substring(1, num2 - 1);
		}
		case '$':
		{
			if (name.StartsWith("$VB$Local_"))
			{
				return name.Substring("$VB$Local_".Length);
			}
			if (!name.StartsWith("$VB$ResumableLocal_"))
			{
				break;
			}
			int num = name.IndexOf('$', "$VB$ResumableLocal_".Length);
			if (num >= 0)
			{
				string text = name.Substring("$VB$ResumableLocal_".Length, num - "$VB$ResumableLocal_".Length);
				if (text != "VB")
				{
					return text;
				}
			}
			return null;
		}
		}
		return null;
	}

	private static bool IsValidName(string varName)
	{
		if (string.IsNullOrEmpty(varName))
		{
			return false;
		}
		if (!char.IsLetter(varName[0]) && varName[0] != '_')
		{
			return false;
		}
		for (int i = 1; i < varName.Length; i++)
		{
			if (!char.IsLetterOrDigit(varName[i]) && varName[i] != '_')
			{
				return false;
			}
		}
		return true;
	}

	public void AddExistingName(string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			string key = SplitName(name, out var number);
			if (typeNames.TryGetValue(key, out var value))
			{
				typeNames[key] = Math.Max(number, value);
			}
			else
			{
				typeNames.Add(key, number);
			}
		}
	}

	private string SplitName(string name, out int number)
	{
		int num = name.Length;
		while (num > 0 && name[num - 1] >= '0' && name[num - 1] <= '9')
		{
			num--;
		}
		if (num < name.Length && int.TryParse(name.Substring(num), out number))
		{
			return name.Substring(0, num);
		}
		number = 1;
		return name;
	}

	public string GetAlternativeName(string oldVariableName)
	{
		if (oldVariableName.Length == 1 && oldVariableName[0] >= 'i' && oldVariableName[0] <= 'n')
		{
			for (char c = 'i'; c <= 'n'; c = (char)(c + 1))
			{
				if (!typeNames.ContainsKey(c.ToString()))
				{
					typeNames.Add(c.ToString(), 1);
					return c.ToString();
				}
			}
		}
		string text = SplitName(oldVariableName, out var number);
		if (!typeNames.ContainsKey(text))
		{
			typeNames.Add(text, number - 1);
		}
		int num = ++typeNames[text];
		if (num != 1)
		{
			return text + num;
		}
		return text;
	}

	private string TryGetDisplayClassVariableName(ILVariable variable)
	{
		TypeDef typeDef = variable.Type.RemovePinnedAndModifiers().ToTypeDefOrRef().ResolveTypeDef();
		if (typeDef == null)
		{
			return null;
		}
		if (!typeDef.IsNested)
		{
			return null;
		}
		if (!typeDef.CustomAttributes.IsDefined("System.Runtime.CompilerServices.CompilerGeneratedAttribute"))
		{
			return null;
		}
		string text = typeDef.Name.String;
		bool flag = false;
		if (text.StartsWith("<>c__DisplayClass") || text.StartsWith("_Closure$__"))
		{
			if (flag)
			{
				return "$VB$Closure_";
			}
			return "CS$<>8__locals";
		}
		return null;
	}

	private string GenerateNameForVariable(ILVariable variable, ILBlock methodBody)
	{
		string text = null;
		bool flag = false;
		if (string.IsNullOrEmpty(text))
		{
			text = TryGetDisplayClassVariableName(variable);
			flag = text != null;
		}
		if (string.IsNullOrEmpty(text) && default(SigComparer).Equals(variable.GetVariableType(), context.CurrentType.Module.CorLibTypes.Int32))
		{
			bool flag2 = false;
			foreach (ILWhileLoop item in methodBody.GetSelfAndChildrenRecursive<ILWhileLoop>())
			{
				ILExpression iLExpression = item.Condition;
				while (iLExpression != null && iLExpression.Code == ILCode.LogicNot)
				{
					iLExpression = iLExpression.Arguments[0];
				}
				if (iLExpression != null)
				{
					ILCode code = iLExpression.Code;
					if (((uint)(code - 193) <= 3u || (uint)(code - 220) <= 3u) && ((ILNode)iLExpression.Arguments[0]).Match(ILCode.Ldloc, out ILVariable operand) && operand == variable)
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				for (char c = 'i'; c <= 'n'; c = (char)(c + 1))
				{
					if (!typeNames.ContainsKey(c.ToString()))
					{
						text = c.ToString();
						break;
					}
				}
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			List<string> list = (from expr in methodBody.GetSelfAndChildrenRecursive<ILExpression>()
				where expr.Code == ILCode.Stloc && expr.Operand == variable
				select GetNameFromExpression(expr.Arguments.Single())).Except(fieldNamesInCurrentType).ToList();
			if (list.Count == 1)
			{
				text = list[0];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			List<string> list2 = (from expr in methodBody.GetSelfAndChildrenRecursive<ILExpression>()
				from i in Enumerable.Range(0, expr.Arguments.Count)
				let arg = expr.Arguments[i]
				where arg.Code == ILCode.Ldloc && arg.Operand == variable
				select GetNameForArgument(expr, i)).Except(fieldNamesInCurrentType).ToList();
			if (list2.Count == 1)
			{
				text = list2[0];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			text = GetNameByType(variable.GetVariableType());
		}
		text = SplitName(text, out var _);
		if (!typeNames.ContainsKey(text))
		{
			typeNames.Add(text, 0);
		}
		int num = ++typeNames[text];
		if ((num > 1) | flag)
		{
			return text + num;
		}
		return text;
	}

	private string GetNameFromExpression(ILExpression expr)
	{
		switch (expr.Code)
		{
		case ILCode.Ldfld:
		case ILCode.Ldsfld:
			return CleanUpVariableName(((IField)expr.Operand).Name);
		case ILCode.Call:
		case ILCode.Callvirt:
		case ILCode.CallGetter:
		case ILCode.CallvirtGetter:
		{
			IMethod method = (IMethod)expr.Operand;
			if (method.MethodSig.GetParameters().Count == 0 && method.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase) && method.Name != nameGetCurrent)
			{
				return CleanUpVariableName(method.Name.Substring(4));
			}
			if (method.Name.StartsWith("Get", StringComparison.OrdinalIgnoreCase) && method.Name.String.Length >= 4 && char.IsUpper(method.Name.String[3]))
			{
				return CleanUpVariableName(method.Name.Substring(3));
			}
			break;
		}
		}
		return null;
	}

	private string GetNameForArgument(ILExpression parent, int i)
	{
		switch (parent.Code)
		{
		case ILCode.Stfld:
		case ILCode.Stsfld:
			if (i == parent.Arguments.Count - 1)
			{
				return CleanUpVariableName(((IField)parent.Operand).Name);
			}
			break;
		case ILCode.Call:
		case ILCode.Callvirt:
		case ILCode.Newobj:
		case ILCode.CallGetter:
		case ILCode.CallvirtGetter:
		case ILCode.CallSetter:
		case ILCode.CallvirtSetter:
		case ILCode.CallReadOnlySetter:
		{
			IMethod method = (IMethod)parent.Operand;
			if (method.MethodSig.GetParameters().Count == 1 && i == parent.Arguments.Count - 1)
			{
				if (method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase) || (parent.Code == ILCode.CallReadOnlySetter && method.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase)))
				{
					UTF8String uTF8String = method.Name.Substring(4);
					if (uTF8String != "Current")
					{
						return CleanUpVariableName(uTF8String);
					}
				}
				else if (method.Name.StartsWith("Set", StringComparison.OrdinalIgnoreCase) && method.Name.String.Length >= 4 && char.IsUpper(method.Name.String[3]))
				{
					return CleanUpVariableName(method.Name.Substring(3));
				}
			}
			MethodDef methodDef = method.Resolve();
			if (methodDef != null)
			{
				Parameter parameter = methodDef.Parameters.ElementAtOrDefault(i + ((parent.Code == ILCode.Newobj) ? 1 : 0));
				if (parameter != null && !string.IsNullOrEmpty(parameter.Name))
				{
					return CleanUpVariableName(parameter.Name);
				}
			}
			break;
		}
		case ILCode.Ret:
			return "result";
		}
		return null;
	}

	private string GetNameByType(TypeSig type)
	{
		type = type.RemoveModifiers();
		if (type is GenericInstSig { GenericType: not null } genericInstSig && genericInstSig.GenericArguments.Count == 1 && genericInstSig.GenericType.TypeDefOrRef.Compare(systemString, nullableString))
		{
			type = ((GenericInstSig)type).GenericArguments[0];
		}
		if (type == null)
		{
			return string.Empty;
		}
		if (type.IsSingleOrMultiDimensionalArray)
		{
			return "array";
		}
		if (type.IsPointer || type.IsByRef)
		{
			return "ptr";
		}
		stringBuilder.Clear();
		if (FullNameFactory.NameSB(type, isReflection: false, stringBuilder).EndsWith("Exception"))
		{
			return "ex";
		}
		stringBuilder.Clear();
		if (!typeNameToVariableNameDict.TryGetValue(FullNameFactory.FullName(type, isReflection: false, null, null, null, stringBuilder), out var value))
		{
			stringBuilder.Clear();
			value = FullNameFactory.Name(type, isReflection: false, stringBuilder);
			if (value.Length >= 3 && value[0] == 'I' && char.IsUpper(value[1]) && char.IsLower(value[2]))
			{
				value = value.Substring(1);
			}
			return CleanUpVariableName(value);
		}
		return value;
	}

	private string CleanUpVariableName(string name)
	{
		StringBuilder stringBuilder = this.stringBuilder;
		stringBuilder.Clear();
		int num = name.LastIndexOf('`');
		if (num < 0)
		{
			num = name.Length;
		}
		for (int i = 0; i < num; i++)
		{
			char c = name[i];
			if (IsValidChar(c))
			{
				stringBuilder.Append(c);
				continue;
			}
			stringBuilder.Append("_u");
			ushort num2 = c;
			stringBuilder.Append(num2.ToString("X4"));
		}
		if (stringBuilder.Length > 2 && stringBuilder[0] == 'm' && stringBuilder[1] == '_')
		{
			stringBuilder.Remove(0, 2);
		}
		else if (stringBuilder.Length > 1 && stringBuilder[0] == '_')
		{
			stringBuilder.Remove(0, 1);
		}
		if (stringBuilder.Length == 0)
		{
			return "obj";
		}
		for (int j = 0; j < stringBuilder.Length; j++)
		{
			char c2 = stringBuilder[j];
			char c3 = char.ToLowerInvariant(c2);
			if (c2 == c3)
			{
				break;
			}
			stringBuilder[j] = c3;
		}
		return stringBuilder.ToString();
	}

	private static bool IsValidChar(char c)
	{
		if ('!' <= c && c <= '~')
		{
			return true;
		}
		if (c <= ' ')
		{
			return false;
		}
		switch (char.GetUnicodeCategory(c))
		{
		case UnicodeCategory.UppercaseLetter:
		case UnicodeCategory.LowercaseLetter:
		case UnicodeCategory.OtherLetter:
		case UnicodeCategory.DecimalDigitNumber:
			return true;
		default:
			return false;
		}
	}
}
