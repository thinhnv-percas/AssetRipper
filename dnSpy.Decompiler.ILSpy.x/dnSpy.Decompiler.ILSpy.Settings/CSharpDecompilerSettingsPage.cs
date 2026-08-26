using System;
using System.Linq;
using dnSpy.Contracts.Settings.Dialog;
using dnSpy.Decompiler.ILSpy.Properties;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler.ILSpy.Settings;

internal sealed class CSharpDecompilerSettingsPage : AppSettingsPage, IAppSettingsPage2
{
	[Flags]
	private enum RefreshFlags
	{
		ShowMember = 1,
		ILAst = 2,
		CSharp = 4,
		VB = 8,
		DecompileAll = ILAst | CSharp | VB
	}

	private readonly DecompilerSettings _global_decompilerSettings;

	private readonly DecompilerSettings decompilerSettings;

	private readonly DecompilationObjectVM[] decompilationObjectVMs;

	private readonly DecompilationObjectVM[] decompilationObjectVMs2;

	public override double Order => 10000.0;

	public string Name => dnSpy_Decompiler_ILSpy_Resources.CSharpDecompilerSettingsTabName;

	public DecompilerSettings Settings => decompilerSettings;

	public override Guid ParentGuid => new Guid("E380FC93-BACB-4125-8AF1-ADFAEA4D1307");

	public override Guid Guid => new Guid("8929CE8E-7E2C-4701-A8BA-42F70363872C");

	public override string Title => "C# / Visual Basic (ILSpy)";

	public override object UIObject => this;

	public DecompilationObjectVM[] DecompilationObjectsArray => decompilationObjectVMs2;

	public DecompilationObjectVM DecompilationObject0
	{
		get
		{
			return decompilationObjectVMs[0];
		}
		set
		{
			SetDecompilationObject(0, value);
		}
	}

	public DecompilationObjectVM DecompilationObject1
	{
		get
		{
			return decompilationObjectVMs[1];
		}
		set
		{
			SetDecompilationObject(1, value);
		}
	}

	public DecompilationObjectVM DecompilationObject2
	{
		get
		{
			return decompilationObjectVMs[2];
		}
		set
		{
			SetDecompilationObject(2, value);
		}
	}

	public DecompilationObjectVM DecompilationObject3
	{
		get
		{
			return decompilationObjectVMs[3];
		}
		set
		{
			SetDecompilationObject(3, value);
		}
	}

	public DecompilationObjectVM DecompilationObject4
	{
		get
		{
			return decompilationObjectVMs[4];
		}
		set
		{
			SetDecompilationObject(4, value);
		}
	}

	private void SetDecompilationObject(int index, DecompilationObjectVM newValue)
	{
		if (newValue == null)
		{
			throw new ArgumentNullException("newValue");
		}
		if (decompilationObjectVMs[index] != newValue)
		{
			int num = Array.IndexOf(decompilationObjectVMs, newValue);
			if (num >= 0)
			{
				decompilationObjectVMs[num] = decompilationObjectVMs[index];
				decompilationObjectVMs[index] = newValue;
				((AppSettingsPage)this).OnPropertyChanged($"DecompilationObject{num}");
			}
			((AppSettingsPage)this).OnPropertyChanged($"DecompilationObject{index}");
		}
	}

	public CSharpDecompilerSettingsPage(DecompilerSettings decompilerSettings)
	{
		_global_decompilerSettings = decompilerSettings;
		this.decompilerSettings = decompilerSettings.Clone();
		DecompilationObject[] array = typeof(DecompilationObject).GetEnumValues().Cast<DecompilationObject>().ToArray();
		decompilationObjectVMs = new DecompilationObjectVM[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			decompilationObjectVMs[i] = new DecompilationObjectVM(array[i], ToString(array[i]));
		}
		decompilationObjectVMs2 = decompilationObjectVMs.ToArray();
		DecompilationObject0 = decompilationObjectVMs.First((DecompilationObjectVM a) => a.Object == decompilerSettings.DecompilationObject0);
		DecompilationObject1 = decompilationObjectVMs.First((DecompilationObjectVM a) => a.Object == decompilerSettings.DecompilationObject1);
		DecompilationObject2 = decompilationObjectVMs.First((DecompilationObjectVM a) => a.Object == decompilerSettings.DecompilationObject2);
		DecompilationObject3 = decompilationObjectVMs.First((DecompilationObjectVM a) => a.Object == decompilerSettings.DecompilationObject3);
		DecompilationObject4 = decompilationObjectVMs.First((DecompilationObjectVM a) => a.Object == decompilerSettings.DecompilationObject4);
	}

	private static string ToString(DecompilationObject o)
	{
		return o switch
		{
			DecompilationObject.NestedTypes => dnSpy_Decompiler_ILSpy_Resources.DecompilationOrder_NestedTypes, 
			DecompilationObject.Fields => dnSpy_Decompiler_ILSpy_Resources.DecompilationOrder_Fields, 
			DecompilationObject.Events => dnSpy_Decompiler_ILSpy_Resources.DecompilationOrder_Events, 
			DecompilationObject.Properties => dnSpy_Decompiler_ILSpy_Resources.DecompilationOrder_Properties, 
			DecompilationObject.Methods => dnSpy_Decompiler_ILSpy_Resources.DecompilationOrder_Methods, 
			_ => "???", 
		};
	}

	public override void OnApply()
	{
		throw new InvalidOperationException();
	}

	public void OnApply(IAppRefreshSettings appRefreshSettings)
	{
		RefreshFlags refreshFlags = (RefreshFlags)0;
		DecompilerSettings global_decompilerSettings = _global_decompilerSettings;
		DecompilerSettings decompilerSettings = this.decompilerSettings;
		decompilerSettings.DecompilationObject0 = DecompilationObject0.Object;
		decompilerSettings.DecompilationObject1 = DecompilationObject1.Object;
		decompilerSettings.DecompilationObject2 = DecompilationObject2.Object;
		decompilerSettings.DecompilationObject3 = DecompilationObject3.Object;
		decompilerSettings.DecompilationObject4 = DecompilationObject4.Object;
		if (global_decompilerSettings.AnonymousMethods != decompilerSettings.AnonymousMethods)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.ExpressionTrees != decompilerSettings.ExpressionTrees)
		{
			refreshFlags |= RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.YieldReturn != decompilerSettings.YieldReturn)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.AsyncAwait != decompilerSettings.AsyncAwait)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.AutomaticProperties != decompilerSettings.AutomaticProperties)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.AutomaticEvents != decompilerSettings.AutomaticEvents)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.UsingStatement != decompilerSettings.UsingStatement)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.ForEachStatement != decompilerSettings.ForEachStatement)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.LockStatement != decompilerSettings.LockStatement)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.SwitchStatementOnString != decompilerSettings.SwitchStatementOnString)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.UsingDeclarations != decompilerSettings.UsingDeclarations)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.QueryExpressions != decompilerSettings.QueryExpressions)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.FullyQualifyAmbiguousTypeNames != decompilerSettings.FullyQualifyAmbiguousTypeNames)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.FullyQualifyAllTypes != decompilerSettings.FullyQualifyAllTypes)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.UseDebugSymbols != decompilerSettings.UseDebugSymbols)
		{
			refreshFlags |= RefreshFlags.DecompileAll;
		}
		if (global_decompilerSettings.ObjectOrCollectionInitializers != decompilerSettings.ObjectOrCollectionInitializers)
		{
			refreshFlags |= RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.ShowXmlDocumentation != decompilerSettings.ShowXmlDocumentation)
		{
			refreshFlags |= RefreshFlags.DecompileAll;
		}
		if (global_decompilerSettings.RemoveEmptyDefaultConstructors != decompilerSettings.RemoveEmptyDefaultConstructors)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.IntroduceIncrementAndDecrement != decompilerSettings.IntroduceIncrementAndDecrement)
		{
			refreshFlags |= RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.MakeAssignmentExpressions != decompilerSettings.MakeAssignmentExpressions)
		{
			refreshFlags |= RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject != decompilerSettings.AlwaysGenerateExceptionVariableForCatchBlocksUnlessTypeIsObject)
		{
			refreshFlags |= RefreshFlags.ILAst;
		}
		if (global_decompilerSettings.ShowTokenAndRvaComments != decompilerSettings.ShowTokenAndRvaComments)
		{
			refreshFlags |= RefreshFlags.DecompileAll;
		}
		if (global_decompilerSettings.DecompilationObject0 != decompilerSettings.DecompilationObject0)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.DecompilationObject1 != decompilerSettings.DecompilationObject1)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.DecompilationObject2 != decompilerSettings.DecompilationObject2)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.DecompilationObject3 != decompilerSettings.DecompilationObject3)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.DecompilationObject4 != decompilerSettings.DecompilationObject4)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.SortMembers != decompilerSettings.SortMembers)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.ForceShowAllMembers != decompilerSettings.ForceShowAllMembers)
		{
			refreshFlags |= RefreshFlags.ShowMember | RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.SortSystemUsingStatementsFirst != decompilerSettings.SortSystemUsingStatementsFirst)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.MaxArrayElements != decompilerSettings.MaxArrayElements)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.SortCustomAttributes != decompilerSettings.SortCustomAttributes)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.UseSourceCodeOrder != decompilerSettings.UseSourceCodeOrder)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.AllowFieldInitializers != decompilerSettings.AllowFieldInitializers)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.OneCustomAttributePerLine != decompilerSettings.OneCustomAttributePerLine)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.TypeAddInternalModifier != decompilerSettings.TypeAddInternalModifier)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if (global_decompilerSettings.MemberAddPrivateModifier != decompilerSettings.MemberAddPrivateModifier)
		{
			refreshFlags |= RefreshFlags.CSharp;
		}
		if ((refreshFlags & RefreshFlags.ShowMember) != 0)
		{
			appRefreshSettings.Add(AppSettingsConstants.REFRESH_LANGUAGE_SHOWMEMBER, (object)null);
		}
		if ((refreshFlags & RefreshFlags.ILAst) != 0)
		{
			appRefreshSettings.Add(SettingsConstants.REDECOMPILE_ILAST_ILSPY_CODE, (object)null);
		}
		if ((refreshFlags & RefreshFlags.CSharp) != 0)
		{
			appRefreshSettings.Add(SettingsConstants.REDECOMPILE_CSHARP_ILSPY_CODE, (object)null);
		}
		if ((refreshFlags & RefreshFlags.VB) != 0)
		{
			appRefreshSettings.Add(SettingsConstants.REDECOMPILE_VB_ILSPY_CODE, (object)null);
		}
		this.decompilerSettings.CopyTo(_global_decompilerSettings);
	}

	public override string[] GetSearchStrings()
	{
		return DecompilationObjectsArray.Select((DecompilationObjectVM a) => a.Text).ToArray();
	}
}
