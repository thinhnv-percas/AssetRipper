using System.Runtime;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms.Integration;

namespace System.Windows.Automation.Peers;

public sealed class WindowsFormsHostAutomationPeer : FrameworkElementAutomationPeer
{
	protected override bool IsHwndHost
	{
		get
		{
			/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
		}
	}

	[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public WindowsFormsHostAutomationPeer(WindowsFormsHost owner)
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override string GetClassNameCore()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}

	[SecurityTreatAsSafe]
	[SecurityCritical]
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	protected override HostedWindowWrapper GetHostRawElementProviderCore()
	{
		/*Error: Empty body found. Decompiled assembly might be a reference assembly.*/;
	}
}
