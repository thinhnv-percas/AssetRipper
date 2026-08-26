using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using Humanizer;

namespace DecompTools.Decompiler.IL.Transforms;

public class AssignVariableNames : IILTransform
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

	private ILTransformContext context;

	private string[] currentFieldNames;

	private Dictionary<string, int> reservedVariableNames;

	private HashSet<ILVariable> loopCounters;

	private const char maxLoopVariableName = 'n';

	public void Run(ILFunction function, ILTransformContext context)
	{
		this.context = context;
		currentFieldNames = Enumerable.ToArray<string>(Enumerable.Select<IField, string>(function.Method.DeclaringTypeDefinition.Fields, (Func<IField, string>)((IField field) => field.Name)));
		reservedVariableNames = new Dictionary<string, int>();
		loopCounters = CollectLoopCounters(function);
		checked
		{
			foreach (ILFunction f in Enumerable.OfType<ILFunction>((IEnumerable)function.Descendants))
			{
				if (f.Method != null)
				{
					if (IsSetOrEventAccessor(f.Method) && f.Method.Parameters.Count > 0)
					{
						for (int num = 0; num < f.Method.Parameters.Count - 1; num++)
						{
							AddExistingName(reservedVariableNames, f.Method.Parameters[num].Name);
						}
						IParameter parameter = Enumerable.Last<IParameter>((IEnumerable<IParameter>)f.Method.Parameters);
						IMember accessorOwner = f.Method.AccessorOwner;
						IMember member = accessorOwner;
						if (member != null)
						{
							if (member is IProperty property)
							{
								IProperty property2 = property;
								if (property2.Setter != f.Method)
								{
									continue;
								}
								if (Enumerable.Any<IParameter>((IEnumerable<IParameter>)property2.Parameters, (Func<IParameter, bool>)((IParameter p) => p.Name == "value")))
								{
									f.Warnings.Add("Parameter named \"value\" already present in property signature!");
									continue;
								}
								ILVariable iLVariable = Enumerable.FirstOrDefault<ILVariable>((IEnumerable<ILVariable>)f.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Function == f && v.Kind == VariableKind.Parameter && v.Index == f.Method.Parameters.Count - 1));
								if (iLVariable == null)
								{
									AddExistingName(reservedVariableNames, parameter.Name);
									continue;
								}
								if (iLVariable.Name != "value")
								{
									iLVariable.Name = "value";
								}
								AddExistingName(reservedVariableNames, iLVariable.Name);
								continue;
							}
							if (member is IEvent obj)
							{
								IEvent obj2 = obj;
								if (f.Method == obj2.InvokeAccessor)
								{
									continue;
								}
								ILVariable iLVariable2 = Enumerable.FirstOrDefault<ILVariable>((IEnumerable<ILVariable>)f.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Function == f && v.Kind == VariableKind.Parameter && v.Index == f.Method.Parameters.Count - 1));
								if (iLVariable2 == null)
								{
									AddExistingName(reservedVariableNames, parameter.Name);
									continue;
								}
								if (iLVariable2.Name != "value")
								{
									iLVariable2.Name = "value";
								}
								AddExistingName(reservedVariableNames, iLVariable2.Name);
								continue;
							}
						}
						AddExistingName(reservedVariableNames, parameter.Name);
						continue;
					}
					foreach (IParameter parameter2 in f.Method.Parameters)
					{
						AddExistingName(reservedVariableNames, parameter2.Name);
					}
					continue;
				}
				foreach (ILVariable item in Enumerable.Where<ILVariable>((IEnumerable<ILVariable>)f.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Kind == VariableKind.Parameter)))
				{
					AddExistingName(reservedVariableNames, item.Name);
				}
			}
			foreach (ILFunction item2 in Enumerable.Reverse<ILFunction>(Enumerable.OfType<ILFunction>((IEnumerable)function.Descendants)))
			{
				PerformAssignment(item2);
			}
		}
	}

	private bool IsSetOrEventAccessor(IMethod method)
	{
		if (method.AccessorOwner is IProperty property)
		{
			return property.Setter == method;
		}
		if (method.AccessorOwner is IEvent obj)
		{
			return obj.InvokeAccessor != method;
		}
		return false;
	}

	private void PerformAssignment(ILFunction function)
	{
		function.Variables.RemoveDead();
		int num = 0;
		foreach (ILVariable variable2 in function.Variables)
		{
			switch (variable2.Kind)
			{
			case VariableKind.InitializerTarget:
				AddExistingName(reservedVariableNames, variable2.Name);
				continue;
			case VariableKind.DisplayClassLocal:
				variable2.Name = "CS$<>8__locals" + checked(num++);
				continue;
			case VariableKind.Parameter:
				continue;
			}
			if (variable2.HasGeneratedName || !IsValidName(variable2.Name) || ConflictWithLocal(variable2))
			{
				variable2.Name = null;
			}
			else
			{
				variable2.Name = GetAlternativeName(variable2.Name);
			}
		}
		Dictionary<ILVariable, string> dictionary = new Dictionary<ILVariable, string>(ILVariableEqualityComparer.Instance);
		foreach (IInstructionWithVariableOperand item in Enumerable.OfType<IInstructionWithVariableOperand>((IEnumerable)function.Descendants))
		{
			ILVariable variable = item.Variable;
			if (!dictionary.TryGetValue(variable, out var value))
			{
				if (string.IsNullOrEmpty(variable.Name))
				{
					variable.Name = GenerateNameForVariable(variable);
				}
				dictionary.Add(variable, variable.Name);
			}
			else
			{
				variable.Name = value;
			}
		}
	}

	internal static bool IsSupportedInstruction(object arg)
	{
		if (arg == null)
		{
			goto IL_0059;
		}
		if (!(arg is LdObj ldObj))
		{
			if (!(arg is LdFlda ldFlda))
			{
				if (!(arg is LdsFlda ldsFlda))
				{
					if (!(arg is CallInstruction callInstruction))
					{
						goto IL_0059;
					}
					CallInstruction callInstruction2 = callInstruction;
				}
				else
				{
					LdsFlda ldsFlda2 = ldsFlda;
				}
			}
			else
			{
				LdFlda ldFlda2 = ldFlda;
			}
		}
		else
		{
			LdObj ldObj2 = ldObj;
		}
		return true;
		IL_0059:
		return false;
	}

	private bool ConflictWithLocal(ILVariable v)
	{
		if ((v.Kind == VariableKind.UsingLocal || v.Kind == VariableKind.ForeachLocal) && reservedVariableNames.ContainsKey(v.Name))
		{
			return true;
		}
		return false;
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
		for (int i = 1; i < varName.Length; i = checked(i + 1))
		{
			if (!char.IsLetterOrDigit(varName[i]) && varName[i] != '_')
			{
				return false;
			}
		}
		return true;
	}

	public string GetAlternativeName(string oldVariableName)
	{
		if (oldVariableName.Length == 1 && oldVariableName[0] >= 'i' && oldVariableName[0] <= 'n')
		{
			for (char c = 'i'; c <= 'n'; c = (char)checked((ushort)(unchecked((uint)c) + 1u)))
			{
				if (!reservedVariableNames.ContainsKey(c.ToString()))
				{
					reservedVariableNames.Add(c.ToString(), 1);
					return c.ToString();
				}
			}
		}
		string text = SplitName(oldVariableName, out var number);
		checked
		{
			if (!reservedVariableNames.ContainsKey(text))
			{
				reservedVariableNames.Add(text, number - 1);
			}
			int num = ++reservedVariableNames[text];
			if (num != 1)
			{
				return text + num;
			}
			return text;
		}
	}

	private HashSet<ILVariable> CollectLoopCounters(ILFunction function)
	{
		HashSet<ILVariable> val = new HashSet<ILVariable>();
		foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)function.Descendants))
		{
			if (item.Kind != ContainerKind.For)
			{
				continue;
			}
			foreach (ILInstruction instruction in item.Blocks.Last().Instructions)
			{
				if (HighLevelLoopTransform.MatchIncrement(instruction, out var variable))
				{
					val.Add(variable);
				}
			}
		}
		return val;
	}

	private string GenerateNameForVariable(ILVariable variable)
	{
		string text = null;
		if (variable.Type.IsKnownType(KnownTypeCode.Int32) && loopCounters.Contains(variable))
		{
			for (char c = 'i'; c <= 'n'; c = (char)checked((ushort)(unchecked((uint)c) + 1u)))
			{
				if (!reservedVariableNames.ContainsKey(c.ToString()))
				{
					text = c.ToString();
					break;
				}
			}
		}
		if (CSharpDecompiler.IsWindowsFormsInitializeComponentMethod(context.Function.Method) && variable.Type.FullName == "System.ComponentModel.ComponentResourceManager")
		{
			text = "resources";
		}
		if (string.IsNullOrEmpty(text))
		{
			List<string> list = Enumerable.ToList<string>(Enumerable.Except<string>(Enumerable.Where<string>(Enumerable.Select<LdLoca, string>(Enumerable.OfType<LdLoca>((IEnumerable)variable.AddressInstructions), (Func<LdLoca, string>)((LdLoca arg) => (!(arg.Parent is CallInstruction callInstruction)) ? null : callInstruction.GetParameter(arg.ChildIndex)?.Name)), (Func<string, bool>)((string arg) => !string.IsNullOrWhiteSpace(arg))), (IEnumerable<string>)currentFieldNames));
			if (list.Count > 0)
			{
				text = list[0];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			List<string> list2 = Enumerable.ToList<string>(Enumerable.Except<string>(Enumerable.Select<StLoc, string>(Enumerable.OfType<StLoc>((IEnumerable)variable.StoreInstructions), (Func<StLoc, string>)((StLoc expr) => GetNameFromInstruction(expr.Value))), (IEnumerable<string>)currentFieldNames));
			if (list2.Count == 1)
			{
				text = list2[0];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			List<string> list3 = Enumerable.ToList<string>(Enumerable.Except<string>(Enumerable.Select<LdLoc, string>((IEnumerable<LdLoc>)variable.LoadInstructions, (Func<LdLoc, string>)((LdLoc arg) => GetNameForArgument(arg.Parent, arg.ChildIndex))), (IEnumerable<string>)currentFieldNames));
			if (list3.Count == 1)
			{
				text = list3[0];
			}
		}
		if (string.IsNullOrEmpty(text) && variable.Kind == VariableKind.StackSlot)
		{
			List<string> list4 = Enumerable.ToList<string>(Enumerable.Except<string>(Enumerable.Select<StLoc, string>(Enumerable.OfType<StLoc>((IEnumerable)variable.StoreInstructions), (Func<StLoc, string>)((StLoc expr) => GetNameByType(GuessType(variable.Type, expr.Value, context)))), (IEnumerable<string>)currentFieldNames));
			if (list4.Count == 1)
			{
				text = list4[0];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			text = GetNameByType(variable.Type);
		}
		text = SplitName(text, out var _);
		if (!reservedVariableNames.ContainsKey(text))
		{
			reservedVariableNames.Add(text, 0);
		}
		int num = checked(++reservedVariableNames[text]);
		if (num > 1)
		{
			return text + num;
		}
		return text;
	}

	private static string GetNameFromInstruction(ILInstruction inst)
	{
		if (inst != null)
		{
			if (inst is LdObj ldObj)
			{
				LdObj ldObj2 = ldObj;
				return GetNameFromInstruction(ldObj2.Target);
			}
			if (inst is LdFlda ldFlda)
			{
				LdFlda ldFlda2 = ldFlda;
				return CleanUpVariableName(ldFlda2.Field.Name);
			}
			if (inst is LdsFlda ldsFlda)
			{
				LdsFlda ldsFlda2 = ldsFlda;
				return CleanUpVariableName(ldsFlda2.Field.Name);
			}
			if (inst is CallInstruction callInstruction)
			{
				CallInstruction callInstruction2 = callInstruction;
				if (!(callInstruction2 is NewObj))
				{
					IMethod method = callInstruction2.Method;
					if (method.Name.StartsWith("get_", StringComparison.OrdinalIgnoreCase) && method.Parameters.Count == 0)
					{
						return CleanUpVariableName(method.Name.Substring(4));
					}
					if (method.Name.StartsWith("Get", StringComparison.OrdinalIgnoreCase) && method.Name.Length >= 4 && char.IsUpper(method.Name[3]))
					{
						return CleanUpVariableName(method.Name.Substring(3));
					}
				}
			}
		}
		return null;
	}

	private static string GetNameForArgument(ILInstruction parent, int i)
	{
		if (parent != null)
		{
			if (parent is StObj stObj)
			{
				StObj stObj2 = stObj;
				IField field;
				if (stObj2.Target is LdFlda ldFlda)
				{
					field = ldFlda.Field;
				}
				else
				{
					if (!(stObj2.Target is LdsFlda ldsFlda))
					{
						goto IL_01a4;
					}
					field = ldsFlda.Field;
				}
				return CleanUpVariableName(field.Name);
			}
			if (!(parent is CallInstruction callInstruction))
			{
				if (parent is Leave leave)
				{
					Leave leave2 = leave;
					return "result";
				}
			}
			else
			{
				CallInstruction callInstruction2 = callInstruction;
				IMethod method = callInstruction2.Method;
				if (method.Parameters.Count == 1 && i == checked(callInstruction2.Arguments.Count - 1))
				{
					if (method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
					{
						return CleanUpVariableName(method.Name.Substring(4));
					}
					if (method.Name.StartsWith("Set", StringComparison.OrdinalIgnoreCase) && method.Name.Length >= 4 && char.IsUpper(method.Name[3]))
					{
						return CleanUpVariableName(method.Name.Substring(3));
					}
				}
				IParameter parameter = callInstruction2.GetParameter(i);
				if (parameter != null && !string.IsNullOrEmpty(parameter.Name))
				{
					return CleanUpVariableName(parameter.Name);
				}
			}
		}
		goto IL_01a4;
		IL_01a4:
		return null;
	}

	private static string GetNameByType(IType type)
	{
		type = NullableType.GetUnderlyingType(type);
		while (type is ModifiedType || type is PinnedType)
		{
			type = NullableType.GetUnderlyingType(((TypeWithElementType)type).ElementType);
		}
		if (type is ArrayType)
		{
			return "array";
		}
		if (type is PointerType)
		{
			return "ptr";
		}
		if (type.Kind == TypeKind.TypeParameter || type.Kind == TypeKind.Unknown || type.Kind == TypeKind.Dynamic)
		{
			return "val";
		}
		if (type.Kind == TypeKind.ByReference)
		{
			return "reference";
		}
		if (type.IsAnonymousType())
		{
			return "anon";
		}
		if (type.Name.EndsWith("Exception", StringComparison.Ordinal))
		{
			return "ex";
		}
		if (!typeNameToVariableNameDict.TryGetValue(type.FullName, out var value))
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

	private static void AddExistingName(Dictionary<string, int> reservedVariableNames, string name)
	{
		if (!string.IsNullOrEmpty(name))
		{
			string key = SplitName(name, out var number);
			if (reservedVariableNames.TryGetValue(key, out var value))
			{
				reservedVariableNames[key] = Math.Max(number, value);
			}
			else
			{
				reservedVariableNames.Add(key, number);
			}
		}
	}

	private static string SplitName(string name, out int number)
	{
		int num = name.Length;
		checked
		{
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
		return char.ToLower(name[0]) + name.Substring(1);
	}

	internal static IType GuessType(IType variableType, ILInstruction inst, ILTransformContext context)
	{
		if (!variableType.IsKnownType(KnownTypeCode.Object))
		{
			return variableType;
		}
		IType type = inst.InferType(context.TypeSystem);
		if (type.Kind != TypeKind.Unknown)
		{
			return type;
		}
		return variableType;
	}

	private static Dictionary<string, int> CollectReservedVariableNames(ILFunction function, ILVariable existingVariable)
	{
		Dictionary<string, int> result = new Dictionary<string, int>();
		ILFunction iLFunction = Enumerable.Single<ILFunction>(Enumerable.OfType<ILFunction>((IEnumerable)function.Ancestors), (Func<ILFunction, bool>)((ILFunction f) => f.Parent == null));
		foreach (ILFunction item in Enumerable.OfType<ILFunction>((IEnumerable)iLFunction.Descendants))
		{
			foreach (IParameter parameter in iLFunction.Parameters)
			{
				AddExistingName(result, parameter.Name);
			}
			foreach (ILVariable item2 in Enumerable.Where<ILVariable>((IEnumerable<ILVariable>)item.Variables, (Func<ILVariable, bool>)((ILVariable v) => v.Kind != VariableKind.Parameter)))
			{
				if (item2 != existingVariable)
				{
					AddExistingName(result, item2.Name);
				}
			}
		}
		foreach (string item3 in Enumerable.Select<IField, string>(iLFunction.Method.DeclaringTypeDefinition.Fields, (Func<IField, string>)((IField f) => f.Name)))
		{
			AddExistingName(result, item3);
		}
		return result;
	}

	internal static string GenerateForeachVariableName(ILFunction function, ILInstruction valueContext, ILVariable existingVariable = null)
	{
		if (function == null)
		{
			throw new ArgumentNullException("function");
		}
		if (existingVariable != null && !existingVariable.HasGeneratedName)
		{
			return existingVariable.Name;
		}
		Dictionary<string, int> dictionary = CollectReservedVariableNames(function, existingVariable);
		string text = GetNameFromInstruction(valueContext);
		if (string.IsNullOrEmpty(text) && valueContext is LdLoc ldLoc && ldLoc.Variable.Kind == VariableKind.Parameter)
		{
			text = ldLoc.Variable.Name;
		}
		string proposedName = "item";
		checked
		{
			if (!string.IsNullOrEmpty(text) && !IsPlural(text, ref proposedName))
			{
				if (text.Length > 4 && text.EndsWith("List", StringComparison.Ordinal))
				{
					proposedName = text.Substring(0, text.Length - 4);
				}
				else if (text.Equals("list", StringComparison.OrdinalIgnoreCase))
				{
					proposedName = "item";
				}
				else if (text.EndsWith("children", StringComparison.OrdinalIgnoreCase))
				{
					proposedName = text.Remove(text.Length - 3);
				}
			}
			proposedName = SplitName(proposedName, out var _);
			if (!dictionary.ContainsKey(proposedName))
			{
				dictionary.Add(proposedName, 0);
			}
			int num = ++dictionary[proposedName];
			if (num > 1)
			{
				return proposedName + num;
			}
			return proposedName;
		}
	}

	internal static string GenerateVariableName(ILFunction function, IType type, ILInstruction valueContext = null, ILVariable existingVariable = null)
	{
		if (function == null)
		{
			throw new ArgumentNullException("function");
		}
		Dictionary<string, int> dictionary = CollectReservedVariableNames(function, existingVariable);
		string text = ((valueContext != null) ? (GetNameFromInstruction(valueContext) ?? GetNameByType(type)) : GetNameByType(type));
		string proposedName = "obj";
		checked
		{
			if (!string.IsNullOrEmpty(text) && !IsPlural(text, ref proposedName))
			{
				proposedName = ((text.Length > 4 && text.EndsWith("List", StringComparison.Ordinal)) ? text.Substring(0, text.Length - 4) : (text.Equals("list", StringComparison.OrdinalIgnoreCase) ? "item" : ((!text.EndsWith("children", StringComparison.OrdinalIgnoreCase)) ? text : text.Remove(text.Length - 3))));
			}
			proposedName = SplitName(proposedName, out var _);
			if (!dictionary.ContainsKey(proposedName))
			{
				dictionary.Add(proposedName, 0);
			}
			int num = ++dictionary[proposedName];
			if (num > 1)
			{
				return proposedName + num;
			}
			return proposedName;
		}
	}

	private static bool IsPlural(string baseName, ref string proposedName)
	{
		string text = baseName.Singularize(inputIsKnownToBePlural: false);
		if (text == baseName)
		{
			return false;
		}
		proposedName = text;
		return true;
	}
}
