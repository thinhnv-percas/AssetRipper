using System;
using System.ComponentModel.Composition;
using dnSpy.Contracts.Settings;
using ICSharpCode.Decompiler;

namespace dnSpy.Decompiler.ILSpy.Settings;

[Export]
internal sealed class DecompilerSettingsImpl : DecompilerSettings
{
	private static readonly Guid SETTINGS_GUID = new Guid("6745457F-254B-4B7B-90F1-F948F0721C3B");

	private readonly ISettingsService settingsService;

	private readonly bool disableSave;

	[ImportingConstructor]
	private DecompilerSettingsImpl(ISettingsService settingsService)
	{
		this.settingsService = settingsService;
		disableSave = true;
		ISettingsSection orCreateSection = settingsService.GetOrCreateSection(SETTINGS_GUID);
		base.DecompilationObject0 = orCreateSection.Attribute<DecompilationObject?>("DecompilationObject0") ?? base.DecompilationObject0;
		base.DecompilationObject1 = orCreateSection.Attribute<DecompilationObject?>("DecompilationObject1") ?? base.DecompilationObject1;
		base.DecompilationObject2 = orCreateSection.Attribute<DecompilationObject?>("DecompilationObject2") ?? base.DecompilationObject2;
		base.DecompilationObject3 = orCreateSection.Attribute<DecompilationObject?>("DecompilationObject3") ?? base.DecompilationObject3;
		base.DecompilationObject4 = orCreateSection.Attribute<DecompilationObject?>("DecompilationObject4") ?? base.DecompilationObject4;
		base.AnonymousMethods = orCreateSection.Attribute<bool?>("AnonymousMethods") ?? base.AnonymousMethods;
		base.ExpressionTrees = orCreateSection.Attribute<bool?>("ExpressionTrees") ?? base.ExpressionTrees;
		base.YieldReturn = orCreateSection.Attribute<bool?>("YieldReturn") ?? base.YieldReturn;
		base.AsyncAwait = orCreateSection.Attribute<bool?>("AsyncAwait") ?? base.AsyncAwait;
		base.QueryExpressions = orCreateSection.Attribute<bool?>("QueryExpressions") ?? base.QueryExpressions;
		base.UseDebugSymbols = orCreateSection.Attribute<bool?>("UseDebugSymbols") ?? base.UseDebugSymbols;
		base.ShowXmlDocumentation = orCreateSection.Attribute<bool?>("ShowXmlDocumentation") ?? base.ShowXmlDocumentation;
		base.RemoveEmptyDefaultConstructors = orCreateSection.Attribute<bool?>("RemoveEmptyDefaultConstructors") ?? base.RemoveEmptyDefaultConstructors;
		base.ShowTokenAndRvaComments = orCreateSection.Attribute<bool?>("ShowTokenAndRvaComments") ?? base.ShowTokenAndRvaComments;
		base.SortMembers = orCreateSection.Attribute<bool?>("SortMembers") ?? base.SortMembers;
		base.ForceShowAllMembers = orCreateSection.Attribute<bool?>("ForceShowAllMembers") ?? base.ForceShowAllMembers;
		base.SortSystemUsingStatementsFirst = orCreateSection.Attribute<bool?>("SortSystemUsingStatementsFirst") ?? base.SortSystemUsingStatementsFirst;
		base.SortCustomAttributes = orCreateSection.Attribute<bool?>("SortCustomAttributes") ?? base.SortCustomAttributes;
		base.UseSourceCodeOrder = orCreateSection.Attribute<bool?>("UseSourceCodeOrder") ?? base.UseSourceCodeOrder;
		base.OneCustomAttributePerLine = orCreateSection.Attribute<bool?>("OneCustomAttributePerLine") ?? base.OneCustomAttributePerLine;
		base.TypeAddInternalModifier = orCreateSection.Attribute<bool?>("TypeAddInternalModifier") ?? base.TypeAddInternalModifier;
		base.MemberAddPrivateModifier = orCreateSection.Attribute<bool?>("MemberAddPrivateModifier") ?? base.MemberAddPrivateModifier;
		disableSave = false;
	}

	protected override void OnModified()
	{
		if (!disableSave)
		{
			ISettingsSection val = settingsService.RecreateSection(SETTINGS_GUID);
			val.Attribute<DecompilationObject>("DecompilationObject0", base.DecompilationObject0);
			val.Attribute<DecompilationObject>("DecompilationObject1", base.DecompilationObject1);
			val.Attribute<DecompilationObject>("DecompilationObject2", base.DecompilationObject2);
			val.Attribute<DecompilationObject>("DecompilationObject3", base.DecompilationObject3);
			val.Attribute<DecompilationObject>("DecompilationObject4", base.DecompilationObject4);
			val.Attribute<bool>("AnonymousMethods", base.AnonymousMethods);
			val.Attribute<bool>("ExpressionTrees", base.ExpressionTrees);
			val.Attribute<bool>("YieldReturn", base.YieldReturn);
			val.Attribute<bool>("AsyncAwait", base.AsyncAwait);
			val.Attribute<bool>("QueryExpressions", base.QueryExpressions);
			val.Attribute<bool>("UseDebugSymbols", base.UseDebugSymbols);
			val.Attribute<bool>("ShowXmlDocumentation", base.ShowXmlDocumentation);
			val.Attribute<bool>("RemoveEmptyDefaultConstructors", base.RemoveEmptyDefaultConstructors);
			val.Attribute<bool>("ShowTokenAndRvaComments", base.ShowTokenAndRvaComments);
			val.Attribute<bool>("SortMembers", base.SortMembers);
			val.Attribute<bool>("ForceShowAllMembers", base.ForceShowAllMembers);
			val.Attribute<bool>("SortSystemUsingStatementsFirst", base.SortSystemUsingStatementsFirst);
			val.Attribute<bool>("SortCustomAttributes", base.SortCustomAttributes);
			val.Attribute<bool>("UseSourceCodeOrder", base.UseSourceCodeOrder);
			val.Attribute<bool>("OneCustomAttributePerLine", base.OneCustomAttributePerLine);
			val.Attribute<bool>("TypeAddInternalModifier", base.TypeAddInternalModifier);
			val.Attribute<bool>("MemberAddPrivateModifier", base.MemberAddPrivateModifier);
		}
	}
}
