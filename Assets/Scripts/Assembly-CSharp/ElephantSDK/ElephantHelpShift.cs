using System;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using Helpshift;
using RollicGames.Utils;
using UnityEngine;

namespace ElephantSDK
{
	[Token(Token = "0x200094D")]
	public class ElephantHelpShift : IHelpShiftElephantAdapter, IElephantAdapter
	{
		[Token(Token = "0x4001F58")]
		private static ElephantHelpShift _instance;

		[Token(Token = "0x4001F59")]
		[FieldOffset(Offset = "0x10")]
		private bool _intialized;

		[Token(Token = "0x4001F5A")]
		[FieldOffset(Offset = "0x18")]
		private HelpshiftSdk help;

		[Token(Token = "0x1700045F")]
		public static bool IsActive
		{
			[Token(Token = "0x60027B5")]
			[Address(RVA = "0x3E44C60", Offset = "0x3E44C60", Length = "0x58")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::get_IsActive");
				return default;
			}
		}

		[Token(Token = "0x60027B6")]
		[Address(RVA = "0x3E44CB8", Offset = "0x3E44CB8", Length = "0x1E8")]
		public void Init(string domainName, string appId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::Init");
		}

		[Token(Token = "0x60027B7")]
		[Address(RVA = "0x3E44EA0", Offset = "0x3E44EA0", Length = "0x164")]
		public void ShowConversation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::ShowConversation");
		}

		[Token(Token = "0x60027B8")]
		[Address(RVA = "0x3E45754", Offset = "0x3E45754", Length = "0x164")]
		public void ShowFAQs()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::ShowFAQs");
		}

		[Token(Token = "0x60027B9")]
		[Address(RVA = "0x3E45004", Offset = "0x3E45004", Length = "0x750")]
		private Dictionary<string, object> GetConfigMap()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::GetConfigMap");
			return default;
		}

		[Token(Token = "0x60027BA")]
		[Address(RVA = "0x3E458B8", Offset = "0x3E458B8", Length = "0x54")]
		private Dictionary<string, string> ConvertStringDataSingleLine(string value)
		{
			return ConvertData("singleline", value);
		}

		[Token(Token = "0x60027BB")]
		[Address(RVA = "0x3E45A04", Offset = "0x3E45A04", Length = "0x90")]
		private Dictionary<string, string> ConvertBooleanData(bool value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ElephantHelpShift::ConvertBooleanData");
			return default;
		}

		[Token(Token = "0x60027BC")]
		[Address(RVA = "0x3E4590C", Offset = "0x3E4590C", Length = "0x64")]
		private Dictionary<string, string> ConvertNumberData(int value)
		{
			int num = value;
			string text = num.ToString();
			return ((ElephantHelpShift)(object)text).ConvertData("number", text);
		}

		[Token(Token = "0x60027BD")]
		[Address(RVA = "0x3E45970", Offset = "0x3E45970", Length = "0x94")]
		private Dictionary<string, string> ConvertNumberData(float value)
		{
			float num = value;
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string text = num.ToString(invariantCulture);
			return ((ElephantHelpShift)(object)text).ConvertData("number", text);
		}

		[Token(Token = "0x60027BE")]
		[Address(RVA = "0x3E45A94", Offset = "0x3E45A94", Length = "0xF0")]
		private Dictionary<string, string> ConvertData(string dataType, string value)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("type", dataType);
			dictionary.Add("value", value);
			return dictionary;
		}

		[Token(Token = "0x60027BF")]
		[Address(RVA = "0x3E45B84", Offset = "0x3E45B84", Length = "0x8")]
		public ElephantHelpShift()
		{
		}
	}
}
