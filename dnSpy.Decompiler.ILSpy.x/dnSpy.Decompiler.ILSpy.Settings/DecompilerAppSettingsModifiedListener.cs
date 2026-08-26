using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Documents.Tabs;
using dnSpy.Contracts.Settings.Dialog;
using dnSpy.Decompiler.ILSpy.Core.CSharp;
using dnSpy.Decompiler.ILSpy.Core.IL;
using dnSpy.Decompiler.ILSpy.Core.VisualBasic;

namespace dnSpy.Decompiler.ILSpy.Settings;

[ExportAppSettingsModifiedListener(Order = 1000.0)]
internal sealed class DecompilerAppSettingsModifiedListener : IAppSettingsModifiedListener
{
	private readonly IDocumentTabService documentTabService;

	private IEnumerable<(IDocumentTab tab, IDecompiler decompiler)> DecompilerTabs
	{
		get
		{
			foreach (IDocumentTab visibleFirstTab in documentTabService.VisibleFirstTabs)
			{
				DocumentTabContent content = visibleFirstTab.Content;
				DocumentTabContent obj = ((content is IDecompilerTabContent) ? content : null);
				IDecompiler decompiler = ((obj != null) ? ((IDecompilerTabContent)obj).Decompiler : null);
				if (decompiler != null)
				{
					yield return (tab: visibleFirstTab, decompiler: decompiler);
				}
			}
		}
	}

	[ImportingConstructor]
	private DecompilerAppSettingsModifiedListener(IDocumentTabService documentTabService)
	{
		this.documentTabService = documentTabService;
	}

	public void OnSettingsModified(IAppRefreshSettings appRefreshSettings)
	{
		bool flag = appRefreshSettings.Has(SettingsConstants.REDISASSEMBLE_IL_ILSPY_CODE);
		bool flag2 = appRefreshSettings.Has(SettingsConstants.REDECOMPILE_ILAST_ILSPY_CODE);
		bool flag3 = appRefreshSettings.Has(SettingsConstants.REDECOMPILE_CSHARP_ILSPY_CODE);
		bool flag4 = appRefreshSettings.Has(SettingsConstants.REDECOMPILE_VB_ILSPY_CODE);
		if (flag2)
		{
			flag3 = (flag4 = true);
		}
		if (flag3)
		{
			flag4 = true;
		}
		if (flag)
		{
			RefreshCode<ILDecompiler>();
		}
		if (flag3)
		{
			RefreshCode<CSharpDecompiler>();
		}
		if (flag4)
		{
			RefreshCode<VBDecompiler>();
		}
	}

	private void RefreshCode<T>()
	{
		documentTabService.Refresh((IEnumerable<IDocumentTab>)(from a in DecompilerTabs
			where a.decompiler is T
			select a.tab).ToArray());
	}
}
