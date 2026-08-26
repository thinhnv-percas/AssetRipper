using System.IO;

internal class GameRecoveryLicManager
{
	private static string LicenseData;

	private static object IsValidLicense;

	private static string ActivationData;

	private static object IsValidActivation;

	[FunAttr(Num = "1C5B48BFA19BD7E829B47A0F8DCAB745")]
	private static string License
	{
		get
		{
			if (LicenseData == null)
			{
				string licensePath = LicensePath;
				if (FileManager.Exists(licensePath))
				{
					LicenseData = File.ReadAllText(licensePath);
				}
			}
			if (!CrackSettings.AllowActivation)
			{
				return LicenseData;
			}
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
	private static bool ValidLicense
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
	private static string Activation
	{
		get
		{
			if (ActivationData == null)
			{
				string activationPath = ActivationPath;
				if (FileManager.Exists(activationPath))
				{
					ActivationData = File.ReadAllText(activationPath);
				}
			}
			if (!CrackSettings.AllowActivation)
			{
				return ActivationData;
			}
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
	private static bool ValidActivation
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

	private static string LicensePath
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

	private static string ActivationPath
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
	private static string FormatLicenseNumber()
	{
		if (!CrackSettings.AllowActivation)
		{
			return HiddenCalls.CallObjectSafe1(null, "819648A8BF080ABC4B7A1305D9168587", License) as string;
		}
		return "Cracked";
	}

	[FunAttr(Num = "16B36A8E1F088A094F437370BE3D4E02")]
	private static string FormatLicense()
	{
		if (!CrackSettings.AllowActivation)
		{
			return HiddenCalls.CallObjectSafe1(null, "9ED6EF3A457AEEC94FE8BD99B21292DE", License) as string;
		}
		return License;
	}

	[FunAttr(Num = "1D33A916EF5CCA849368FD8169AA68F3")]
	private static string FormatActivation()
	{
		if (!CrackSettings.AllowActivation)
		{
			return HiddenCalls.CallObjectSafe1(null, "F801399EB007894F8DF1A5515C12E8BE", Activation) as string;
		}
		return Activation;
	}

	private static bool IsActivated()
	{
		return (bool)HiddenCalls.CallObjectSafe1(null, "81EA6F036044B87F5C5BBE07AA5993FF", License, Activation);
	}

	static GameRecoveryLicManager()
	{
	}
}
