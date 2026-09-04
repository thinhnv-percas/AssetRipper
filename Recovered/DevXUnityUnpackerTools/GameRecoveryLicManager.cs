using System.IO;

internal class GameRecoveryLicManager
{
	internal static string LicenseData;

	internal static object IsValidLicense;

	internal static string ActivationData;

	internal static object IsValidActivation;

	[FunAttr(Num = "1C5B48BFA19BD7E829B47A0F8DCAB745")]
	internal static string License
	{
		get
		{
			return "CrackedLicense";
		}
		set
		{
			if (LicenseData != value)
			{
				IsValidLicense = null;
				LicenseData = value;
				FileManager.Write(LicensePath, value);
			}
		}
	}

	[FunAttr(Num = "13324E821691D7F7B53FFDC3A24875DD")]
	internal static bool ValidLicense
	{
		get
		{
			if (IsValidLicense == null)
			{
				IsValidLicense = (LicChecker.CheckXml(License, "<?xml version=\"1.0\"?><RSAKEY><Exponent>AQAB</Exponent><Modulus>rMPqCkSkquYr/9JRR3zhFxXKCaGWhJ1qCxsj4bchT+4WFbsjOjx4yH1IwgSNtN1RX9naODslq7m7I/WhJDIBYvJlBfnCAvLyfp3JS0vn/649eZdO3UExPcEo1dIWDCn3HAcE2z0Jwpd1jCeAQULOkiEAKwVqzTvEQ9WdtGRcW80=</Modulus></RSAKEY>") && !LicChecker.CheckXml("ff", "<?xml version=\"1.0\"?><RSAKEY><Exponent>AQAB</Exponent><Modulus>rMPqCkSkquYr/9JRR3zhFxXKCaGWhJ1qCxsj4bchT+4WFbsjOjx4yH1IwgSNtN1RX9naODslq7m7I/WhJDIBYvJlBfnCAvLyfp3JS0vn/649eZdO3UExPcEo1dIWDCn3HAcE2z0Jwpd1jCeAQULOkiEAKwVqzTvEQ9WdtGRcW80=</Modulus></RSAKEY>"));
			}
			return (bool)IsValidLicense;
		}
	}

	[FunAttr(Num = "E5C42876EE57E308D82950A652B016D0")]
	internal static string Activation
	{
		get
		{
			return "CrackedActivation";
		}
		set
		{
			if (ActivationData != value)
			{
				IsValidActivation = null;
				ActivationData = value;
				FileManager.Write(ActivationPath, value);
			}
		}
	}

	[FunAttr(Num = "F879CAB3A3DDE56431E043FFCE307AA8")]
	internal static bool ValidActivation
	{
		get
		{
			if (IsValidActivation == null)
			{
				IsValidActivation = (LicChecker.CheckXml(Activation, "<?xml version=\"1.0\"?><RSAKEY><Exponent>AQAB</Exponent><Modulus>rtUTVPogajH+yn/4blt8FZ2aV+0ove/AejkJHDlyOPzB+R215dEzVfYxuytBoaWfuS9nzezkl6I+6bJ1DpDAI59jFyskuH+mY5MY1x7qr9WTmBcRzWAu4KYlkIjCSyeALI10Bo4fyJsNgMBJlPxXHsh9/vTeZ1HpGowNkPW7Fr8=</Modulus></RSAKEY>") && !LicChecker.CheckXml("fsdffwefEWfwefwefwef", "<?xml version=\"1.0\"?><RSAKEY><Exponent>AQAB</Exponent><Modulus>rtUTVPogajH+yn/4blt8FZ2aV+0ove/AejkJHDlyOPzB+R215dEzVfYxuytBoaWfuS9nzezkl6I+6bJ1DpDAI59jFyskuH+mY5MY1x7qr9WTmBcRzWAu4KYlkIjCSyeALI10Bo4fyJsNgMBJlPxXHsh9/vTeZ1HpGowNkPW7Fr8=</Modulus></RSAKEY>") && IsActivated());
			}
			return (bool)IsValidActivation;
		}
	}

	internal static string LicensePath
	{
		get
		{
			string persistentDataPath = DevXSystemInfo.PersistentDataPath;
			if (!Directory.Exists(persistentDataPath))
			{
				Directory.CreateDirectory(persistentDataPath);
			}
			return Path.Combine(persistentDataPath, "DevXUnityUnpackerEditorStudio-License.plic");
		}
	}

	internal static string ActivationPath
	{
		get
		{
			string persistentDataPath = DevXSystemInfo.PersistentDataPath;
			if (!Directory.Exists(persistentDataPath))
			{
				Directory.CreateDirectory(persistentDataPath);
			}
			return Path.Combine(persistentDataPath, "DevXUnityUnpackerEditorStudio-Activation.alic");
		}
	}

	[FunAttr(Num = "185FC627893A32877273958A2F914F75")]
	internal static string FormatLicenseNumber()
	{
		return "Cracked";
	}

	[FunAttr(Num = "16B36A8E1F088A094F437370BE3D4E02")]
	internal static string FormatLicense()
	{
		return License;
	}

	[FunAttr(Num = "1D33A916EF5CCA849368FD8169AA68F3")]
	internal static string FormatActivation()
	{
		return Activation;
	}

	internal static bool IsActivated()
	{
		return (bool)HiddenCalls.CallObjectSafe1(null, "81EA6F036044B87F5C5BBE07AA5993FF", License, Activation);
	}

	static GameRecoveryLicManager()
	{
	}
}
