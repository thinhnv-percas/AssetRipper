using System;
using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Decompiler;
using dnSpy.Decompiler.ILSpy.Core.Properties;
using dnSpy.Decompiler.Settings;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler.ILSpy.Core.Settings;

internal sealed class CSharpVBDecompilerSettings : DecompilerSettingsBase
{
	private readonly DecompilerSettings decompilerSettings;

	private readonly IDecompilerOption[] options;

	public DecompilerSettings Settings => decompilerSettings;

	public override int Version => decompilerSettings.SettingsVersion;

	public override IEnumerable<IDecompilerOption> Options => options;

	public override event EventHandler VersionChanged;

	public CSharpVBDecompilerSettings(DecompilerSettings decompilerSettings = null)
	{
		this.decompilerSettings = decompilerSettings ?? new DecompilerSettings();
		options = CreateOptions().ToArray();
		this.decompilerSettings.SettingsVersionChanged += DecompilerSettings_SettingsVersionChanged;
	}

	private void DecompilerSettings_SettingsVersionChanged(object sender, EventArgs e)
	{
		VersionChanged?.Invoke(this, EventArgs.Empty);
	}

	public override DecompilerSettingsBase Clone()
	{
		return new CSharpVBDecompilerSettings(decompilerSettings.Clone());
	}

	private IEnumerable<IDecompilerOption> CreateOptions()
	{
		yield return new DecompilerOption<string>(DecompilerOptionConstants.MemberOrder_GUID, () => GetMemberOrder(), delegate(string a)
		{
			SetMemberOrder(a);
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompilationOrder,
			Name = DecompilerOptionConstants.MemberOrder_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AnonymousMethods_GUID, () => decompilerSettings.AnonymousMethods, delegate(bool a)
		{
			decompilerSettings.AnonymousMethods = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAnonMethods,
			Name = DecompilerOptionConstants.AnonymousMethods_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ExpressionTrees_GUID, () => decompilerSettings.ExpressionTrees, delegate(bool a)
		{
			decompilerSettings.ExpressionTrees = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileExprTrees,
			Name = DecompilerOptionConstants.ExpressionTrees_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.YieldReturn_GUID, () => decompilerSettings.YieldReturn, delegate(bool a)
		{
			decompilerSettings.YieldReturn = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileEnumerators,
			Name = DecompilerOptionConstants.YieldReturn_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AsyncAwait_GUID, () => decompilerSettings.AsyncAwait, delegate(bool a)
		{
			decompilerSettings.AsyncAwait = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAsyncMethods,
			Name = DecompilerOptionConstants.AsyncAwait_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AutomaticProperties_GUID, () => decompilerSettings.AutomaticProperties, delegate(bool a)
		{
			decompilerSettings.AutomaticProperties = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAutoProps,
			Name = DecompilerOptionConstants.AutomaticProperties_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AutomaticEvents_GUID, () => decompilerSettings.AutomaticEvents, delegate(bool a)
		{
			decompilerSettings.AutomaticEvents = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileAutoEvents,
			Name = DecompilerOptionConstants.AutomaticEvents_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.UsingStatement_GUID, () => decompilerSettings.UsingStatement, delegate(bool a)
		{
			decompilerSettings.UsingStatement = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileUsingStatements,
			Name = DecompilerOptionConstants.UsingStatement_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ForEachStatement_GUID, () => decompilerSettings.ForEachStatement, delegate(bool a)
		{
			decompilerSettings.ForEachStatement = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileForeachStatements,
			Name = DecompilerOptionConstants.ForEachStatement_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.LockStatement_GUID, () => decompilerSettings.LockStatement, delegate(bool a)
		{
			decompilerSettings.LockStatement = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileLockStatements,
			Name = DecompilerOptionConstants.LockStatement_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.SwitchStatementOnString_GUID, () => decompilerSettings.SwitchStatementOnString, delegate(bool a)
		{
			decompilerSettings.SwitchStatementOnString = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileSwitchOnString,
			Name = DecompilerOptionConstants.SwitchStatementOnString_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.UsingDeclarations_GUID, () => decompilerSettings.UsingDeclarations, delegate(bool a)
		{
			decompilerSettings.UsingDeclarations = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AddUsingDeclarations,
			Name = DecompilerOptionConstants.UsingDeclarations_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.QueryExpressions_GUID, () => decompilerSettings.QueryExpressions, delegate(bool a)
		{
			decompilerSettings.QueryExpressions = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_DecompileQueryExpr,
			Name = DecompilerOptionConstants.QueryExpressions_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.FullyQualifyAmbiguousTypeNames_GUID, () => decompilerSettings.FullyQualifyAmbiguousTypeNames, delegate(bool a)
		{
			decompilerSettings.FullyQualifyAmbiguousTypeNames = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_FullyQualifyAmbiguousTypeNames,
			Name = DecompilerOptionConstants.FullyQualifyAmbiguousTypeNames_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.FullyQualifyAllTypes_GUID, () => decompilerSettings.FullyQualifyAllTypes, delegate(bool a)
		{
			decompilerSettings.FullyQualifyAllTypes = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_FullyQualifyAllTypes,
			Name = DecompilerOptionConstants.FullyQualifyAllTypes_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.UseDebugSymbols_GUID, () => decompilerSettings.UseDebugSymbols, delegate(bool a)
		{
			decompilerSettings.UseDebugSymbols = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_UseLocalNameFromSyms,
			Name = DecompilerOptionConstants.UseDebugSymbols_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ObjectOrCollectionInitializers_GUID, () => decompilerSettings.ObjectOrCollectionInitializers, delegate(bool a)
		{
			decompilerSettings.ObjectOrCollectionInitializers = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ObjectOrCollectionInitializers,
			Name = DecompilerOptionConstants.ObjectOrCollectionInitializers_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowXmlDocumentation_GUID, () => decompilerSettings.ShowXmlDocumentation, delegate(bool a)
		{
			decompilerSettings.ShowXmlDocumentation = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowXMLDocComments,
			Name = DecompilerOptionConstants.ShowXmlDocumentation_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.RemoveEmptyDefaultConstructors_GUID, () => decompilerSettings.RemoveEmptyDefaultConstructors, delegate(bool a)
		{
			decompilerSettings.RemoveEmptyDefaultConstructors = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_RemoveEmptyDefaultCtors,
			Name = DecompilerOptionConstants.RemoveEmptyDefaultConstructors_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.IntroduceIncrementAndDecrement_GUID, () => decompilerSettings.IntroduceIncrementAndDecrement, delegate(bool a)
		{
			decompilerSettings.IntroduceIncrementAndDecrement = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_IntroduceIncrementAndDecrement,
			Name = DecompilerOptionConstants.IntroduceIncrementAndDecrement_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.MakeAssignmentExpressions_GUID, () => decompilerSettings.MakeAssignmentExpressions, delegate(bool a)
		{
			decompilerSettings.MakeAssignmentExpressions = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MakeAssignmentExpressions,
			Name = DecompilerOptionConstants.MakeAssignmentExpressions_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject_GUID, () => decompilerSettings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject, delegate(bool a)
		{
			decompilerSettings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject,
			Name = DecompilerOptionConstants.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ShowTokenAndRvaComments_GUID, () => decompilerSettings.ShowTokenAndRvaComments, delegate(bool a)
		{
			decompilerSettings.ShowTokenAndRvaComments = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowTokensRvasOffsets,
			Name = DecompilerOptionConstants.ShowTokenAndRvaComments_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.SortMembers_GUID, () => decompilerSettings.SortMembers, delegate(bool a)
		{
			decompilerSettings.SortMembers = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortMethods,
			Name = DecompilerOptionConstants.SortMembers_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.ForceShowAllMembers_GUID, () => decompilerSettings.ForceShowAllMembers, delegate(bool a)
		{
			decompilerSettings.ForceShowAllMembers = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_ShowCompilerGeneratedTypes,
			Name = DecompilerOptionConstants.ForceShowAllMembers_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.SortSystemUsingStatementsFirst_GUID, () => decompilerSettings.SortSystemUsingStatementsFirst, delegate(bool a)
		{
			decompilerSettings.SortSystemUsingStatementsFirst = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortSystemFirst,
			Name = DecompilerOptionConstants.SortSystemUsingStatementsFirst_NAME
		};
		yield return new DecompilerOption<int>(DecompilerOptionConstants.MaxArrayElements_GUID, () => decompilerSettings.MaxArrayElements, delegate(int a)
		{
			decompilerSettings.MaxArrayElements = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MaxArrayElements,
			Name = DecompilerOptionConstants.MaxArrayElements_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.SortCustomAttributes_GUID, () => decompilerSettings.SortCustomAttributes, delegate(bool a)
		{
			decompilerSettings.SortCustomAttributes = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_SortCustomAttributes,
			Name = DecompilerOptionConstants.SortCustomAttributes_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.UseSourceCodeOrder_GUID, () => decompilerSettings.UseSourceCodeOrder, delegate(bool a)
		{
			decompilerSettings.UseSourceCodeOrder = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_UseSourceCodeOrder,
			Name = DecompilerOptionConstants.UseSourceCodeOrder_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.AllowFieldInitializers_GUID, () => decompilerSettings.AllowFieldInitializers, delegate(bool a)
		{
			decompilerSettings.AllowFieldInitializers = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_AllowFieldInitializers,
			Name = DecompilerOptionConstants.AllowFieldInitializers_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.OneCustomAttributePerLine_GUID, () => decompilerSettings.OneCustomAttributePerLine, delegate(bool a)
		{
			decompilerSettings.OneCustomAttributePerLine = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_OneCustomAttributePerLine,
			Name = DecompilerOptionConstants.OneCustomAttributePerLine_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.TypeAddInternalModifier_GUID, () => decompilerSettings.TypeAddInternalModifier, delegate(bool a)
		{
			decompilerSettings.TypeAddInternalModifier = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_TypeAddInternalModifier,
			Name = DecompilerOptionConstants.TypeAddInternalModifier_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.MemberAddPrivateModifier_GUID, () => decompilerSettings.MemberAddPrivateModifier, delegate(bool a)
		{
			decompilerSettings.MemberAddPrivateModifier = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_MemberAddPrivateModifier,
			Name = DecompilerOptionConstants.MemberAddPrivateModifier_NAME
		};
		yield return new DecompilerOption<bool>(DecompilerOptionConstants.RemoveNewDelegateClass_GUID, () => decompilerSettings.RemoveNewDelegateClass, delegate(bool a)
		{
			decompilerSettings.RemoveNewDelegateClass = a;
		})
		{
			Description = dnSpy_Decompiler_ILSpy_Core_Resources.DecompilerSettings_RemoveNewDelegateClass,
			Name = DecompilerOptionConstants.RemoveNewDelegateClass_NAME
		};
	}

	private string GetMemberOrder()
	{
		return GetMemberOrderString(decompilerSettings.DecompilationObject0) + GetMemberOrderString(decompilerSettings.DecompilationObject1) + GetMemberOrderString(decompilerSettings.DecompilationObject2) + GetMemberOrderString(decompilerSettings.DecompilationObject3) + GetMemberOrderString(decompilerSettings.DecompilationObject4);
	}

	private static string GetMemberOrderString(DecompilationObject d)
	{
		return d switch
		{
			DecompilationObject.NestedTypes => "t", 
			DecompilationObject.Fields => "f", 
			DecompilationObject.Events => "e", 
			DecompilationObject.Properties => "p", 
			DecompilationObject.Methods => "m", 
			_ => "?", 
		};
	}

	private void SetMemberOrder(string s)
	{
		if (s != null && s.Length == 5)
		{
			decompilerSettings.DecompilationObject0 = GetDecompilationObject(s[0]) ?? decompilerSettings.DecompilationObject0;
			decompilerSettings.DecompilationObject1 = GetDecompilationObject(s[1]) ?? decompilerSettings.DecompilationObject1;
			decompilerSettings.DecompilationObject2 = GetDecompilationObject(s[2]) ?? decompilerSettings.DecompilationObject2;
			decompilerSettings.DecompilationObject3 = GetDecompilationObject(s[3]) ?? decompilerSettings.DecompilationObject3;
			decompilerSettings.DecompilationObject4 = GetDecompilationObject(s[4]) ?? decompilerSettings.DecompilationObject4;
		}
	}

	private static DecompilationObject? GetDecompilationObject(char c)
	{
		return c switch
		{
			't' => DecompilationObject.NestedTypes, 
			'f' => DecompilationObject.Fields, 
			'e' => DecompilationObject.Events, 
			'p' => DecompilationObject.Properties, 
			'm' => DecompilationObject.Methods, 
			_ => null, 
		};
	}

	public override bool Equals(object obj)
	{
		if (obj is CSharpVBDecompilerSettings cSharpVBDecompilerSettings)
		{
			return decompilerSettings.Equals(cSharpVBDecompilerSettings.decompilerSettings);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return decompilerSettings.GetHashCode();
	}
}
