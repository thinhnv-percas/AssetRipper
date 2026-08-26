using ICSharpCode.Decompiler.ILAst;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast
{
	public class NameVariables
	{
		private static readonly Dictionary<string, string> typeNameToVariableNameDict = new Dictionary<string, string>
		{
			{
				"System.Boolean",
				"flag"
			},
			{
				"System.Byte",
				"b"
			},
			{
				"System.SByte",
				"b"
			},
			{
				"System.Int16",
				"num"
			},
			{
				"System.Int32",
				"num"
			},
			{
				"System.Int64",
				"num"
			},
			{
				"System.UInt16",
				"num"
			},
			{
				"System.UInt32",
				"num"
			},
			{
				"System.UInt64",
				"num"
			},
			{
				"System.Single",
				"num"
			},
			{
				"System.Double",
				"num"
			},
			{
				"System.Decimal",
				"num"
			},
			{
				"System.String",
				"text"
			},
			{
				"System.Object",
				"obj"
			},
			{
				"System.Char",
				"c"
			}
		};

		private DecompilerContext context;

		private List<string> fieldNamesInCurrentType;

		private Dictionary<string, int> typeNames = new Dictionary<string, int>();

		private const char maxLoopVariableName = 'n';

		public static void AssignNamesToVariables(DecompilerContext context, IEnumerable<ILVariable> parameters, IEnumerable<ILVariable> variables, ILBlock methodBody)
		{
			NameVariables nameVariables = new NameVariables();
			nameVariables.context = context;
			nameVariables.fieldNamesInCurrentType = (from f in context.CurrentType.Fields
				select f.Name).ToList();
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
				if (variable.IsGenerated)
				{
					nameVariables.AddExistingName(variable.Name);
				}
				else if (variable.OriginalVariable != null && context.Settings.UseDebugSymbols)
				{
					string name = variable.OriginalVariable.Name;
					if (string.IsNullOrEmpty(name) || name.StartsWith("V_", StringComparison.Ordinal) || !IsValidName(name))
					{
						variable.Name = null;
					}
					else
					{
						variable.Name = nameVariables.GetAlternativeName(name);
					}
				}
				else
				{
					variable.Name = null;
				}
			}
			foreach (ILVariable parameter2 in parameters)
			{
				if (string.IsNullOrEmpty(parameter2.Name))
				{
					parameter2.Name = nameVariables.GenerateNameForVariable(parameter2, methodBody);
				}
			}
			foreach (ILVariable variable2 in variables)
			{
				if (string.IsNullOrEmpty(variable2.Name))
				{
					variable2.Name = nameVariables.GenerateNameForVariable(variable2, methodBody);
				}
			}
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
				int number;
				string key = SplitName(name, out number);
				if (typeNames.TryGetValue(key, out int value))
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
			int number;
			string text = SplitName(oldVariableName, out number);
			if (!typeNames.ContainsKey(text))
			{
				typeNames.Add(text, number - 1);
			}
			Dictionary<string, int> dictionary = typeNames;
			string key = text;
			int num = ++dictionary[key];
			if (num != 1)
			{
				return text + num.ToString();
			}
			return text;
		}

		private string GenerateNameForVariable(ILVariable variable, ILBlock methodBody)
		{
			string text = null;
			if (variable.Type == context.CurrentType.Module.TypeSystem.Int32)
			{
				bool flag = false;
				foreach (ILWhileLoop item in methodBody.GetSelfAndChildrenRecursive<ILWhileLoop>())
				{
					ILExpression iLExpression = item.Condition;
					while (iLExpression != null && iLExpression.Code == ILCode.LogicNot)
					{
						iLExpression = iLExpression.Arguments[0];
					}
					if (iLExpression != null)
					{
						switch (iLExpression.Code)
						{
						case ILCode.Cgt:
						case ILCode.Cgt_Un:
						case ILCode.Clt:
						case ILCode.Clt_Un:
						case ILCode.Cge:
						case ILCode.Cge_Un:
						case ILCode.Cle:
						case ILCode.Cle_Un:
							if (iLExpression.Arguments[0].Match(ILCode.Ldloc, out ILVariable operand) && operand == variable)
							{
								flag = true;
							}
							break;
						}
					}
				}
				if (flag)
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
				text = GetNameByType(variable.Type);
			}
			text = SplitName(text, out int _);
			if (!typeNames.ContainsKey(text))
			{
				typeNames.Add(text, 0);
			}
			Dictionary<string, int> dictionary = typeNames;
			string key = text;
			int num = ++dictionary[key];
			if (num > 1)
			{
				return text + num.ToString();
			}
			return text;
		}

		private static string GetNameFromExpression(ILExpression expr)
		{
			switch (expr.Code)
			{
			case ILCode.Ldfld:
			case ILCode.Ldsfld:
				return CleanUpVariableName(((FieldReference)expr.Operand).Name);
			case ILCode.Call:
			case ILCode.Callvirt:
			case ILCode.CallGetter:
			case ILCode.CallvirtGetter:
			{
				MethodReference methodReference = (MethodReference)expr.Operand;
				if (methodReference.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase) && methodReference.Parameters.Count == 0)
				{
					return CleanUpVariableName(methodReference.Name.Substring(4));
				}
				if (methodReference.Name.StartsWith("Get", StringComparison.OrdinalIgnoreCase) && methodReference.Name.Length >= 4 && char.IsUpper(methodReference.Name[3]))
				{
					return CleanUpVariableName(methodReference.Name.Substring(3));
				}
				break;
			}
			}
			return null;
		}

		private static string GetNameForArgument(ILExpression parent, int i)
		{
			switch (parent.Code)
			{
			case ILCode.Stfld:
			case ILCode.Stsfld:
				if (i == parent.Arguments.Count - 1)
				{
					return CleanUpVariableName(((FieldReference)parent.Operand).Name);
				}
				break;
			case ILCode.Call:
			case ILCode.Callvirt:
			case ILCode.Newobj:
			case ILCode.CallGetter:
			case ILCode.CallvirtGetter:
			case ILCode.CallSetter:
			case ILCode.CallvirtSetter:
			{
				MethodReference methodReference = (MethodReference)parent.Operand;
				if (methodReference.Parameters.Count == 1 && i == parent.Arguments.Count - 1)
				{
					if (methodReference.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
					{
						return CleanUpVariableName(methodReference.Name.Substring(4));
					}
					if (methodReference.Name.StartsWith("Set", StringComparison.OrdinalIgnoreCase) && methodReference.Name.Length >= 4 && char.IsUpper(methodReference.Name[3]))
					{
						return CleanUpVariableName(methodReference.Name.Substring(3));
					}
				}
				MethodDefinition methodDefinition = methodReference.Resolve();
				if (methodDefinition != null)
				{
					ParameterDefinition parameterDefinition = methodDefinition.Parameters.ElementAtOrDefault((parent.Code != ILCode.Newobj && methodDefinition.HasThis) ? (i - 1) : i);
					if (parameterDefinition != null && !string.IsNullOrEmpty(parameterDefinition.Name))
					{
						return CleanUpVariableName(parameterDefinition.Name);
					}
				}
				break;
			}
			case ILCode.Ret:
				return "result";
			}
			return null;
		}

		private string GetNameByType(TypeReference type)
		{
			type = TypeAnalysis.UnpackModifiers(type);
			GenericInstanceType genericInstanceType = type as GenericInstanceType;
			if (genericInstanceType != null && genericInstanceType.ElementType.FullName == "System.Nullable`1" && genericInstanceType.GenericArguments.Count == 1)
			{
				type = ((GenericInstanceType)type).GenericArguments[0];
			}
			if (type.IsArray)
			{
				return "array";
			}
			if (type.IsPointer || type.IsByReference)
			{
				return "ptr";
			}
			if (type.Name.EndsWith("Exception", StringComparison.Ordinal))
			{
				return "ex";
			}
			if (!typeNameToVariableNameDict.TryGetValue(type.FullName, out string value))
			{
				value = type.Name;
				if (value.Length >= 3 && value[0] == 'I' && char.IsUpper(value[1]) && char.IsLower(value[2]))
				{
					value = value.Substring(1);
				}
				return CleanUpVariableName(value);
			}
			return value;
		}

		private static string CleanUpVariableName(string name)
		{
			int num = name.IndexOf('`');
			if (num >= 0)
			{
				name = name.Substring(0, num);
			}
			if (name.Length > 2 && name.StartsWith("m_", StringComparison.Ordinal))
			{
				name = name.Substring(2);
			}
			else if (name.Length > 1 && name[0] == '_' && (char.IsLetter(name[1]) || name[1] == '_'))
			{
				name = name.Substring(1);
			}
			if (name.Length == 0)
			{
				return "obj";
			}
			return char.ToLower(name[0]).ToString() + name.Substring(1);
		}
	}
}
