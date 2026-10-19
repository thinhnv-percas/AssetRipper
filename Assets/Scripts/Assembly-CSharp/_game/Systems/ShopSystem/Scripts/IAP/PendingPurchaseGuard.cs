using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.Systems.ShopSystem.Scripts.IAP
{
	[Token(Token = "0x2000719")]
	public static class PendingPurchaseGuard
	{
		[Serializable]
		[Token(Token = "0x200071A")]
		public class PendingPurchaseData
		{
			[Token(Token = "0x40017BF")]
			[FieldOffset(Offset = "0x10")]
			public string bundleId;

			[Token(Token = "0x40017C0")]
			[FieldOffset(Offset = "0x18")]
			public long timestampUtc;

			[Token(Token = "0x40017C1")]
			[FieldOffset(Offset = "0x20")]
			public float localPrice;

			[Token(Token = "0x40017C2")]
			[FieldOffset(Offset = "0x28")]
			public string isoCurrencyCode;

			[Token(Token = "0x40017C3")]
			[FieldOffset(Offset = "0x30")]
			public string receipt;

			[Token(Token = "0x40017C4")]
			[FieldOffset(Offset = "0x38")]
			public string source;

			[Token(Token = "0x6001DF0")]
			[Address(RVA = "0x3D7E298", Offset = "0x3D7E298", Length = "0x8")]
			public PendingPurchaseData()
			{
			}
		}

		[Token(Token = "0x40017BD")]
		private const string KeyPrefix = "pending_iap_";

		[Token(Token = "0x40017BE")]
		private const string IndexKey = "pending_iap_index";

		[Token(Token = "0x6001DE9")]
		[Address(RVA = "0x3D7E12C", Offset = "0x3D7E12C", Length = "0x16C")]
		public static void Save(string bundleId, string receipt, float localPrice, string isoCurrencyCode, string source)
		{
			PendingPurchaseData pendingPurchaseData = new PendingPurchaseData();
			pendingPurchaseData.bundleId = bundleId;
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			DateTimeOffset dateTimeOffset = utcNow;
			long timestampUtc = dateTimeOffset.ToUnixTimeSeconds();
			pendingPurchaseData.timestampUtc = timestampUtc;
			pendingPurchaseData.localPrice = localPrice;
			pendingPurchaseData.isoCurrencyCode = isoCurrencyCode;
			pendingPurchaseData.receipt = receipt;
			pendingPurchaseData.source = source;
			string value = JsonUtility.ToJson(pendingPurchaseData);
			string key = "pending_iap_" + bundleId;
			PlayerPrefs.SetString(key, value);
			AddToIndex(bundleId);
			PlayerPrefs.Save();
		}

		[Token(Token = "0x6001DEA")]
		[Address(RVA = "0x3D7E37C", Offset = "0x3D7E37C", Length = "0x70")]
		public static void Clear(string bundleId)
		{
			string key = "pending_iap_" + bundleId;
			PlayerPrefs.DeleteKey(key);
			RemoveFromIndex(bundleId);
			PlayerPrefs.Save();
		}

		[Token(Token = "0x6001DEB")]
		[Address(RVA = "0x3D7E558", Offset = "0x3D7E558", Length = "0x2E4")]
		public static PendingPurchaseData[] GetAllPending()
		{
			string[] index = GetIndex();
			if (index.Length != 0)
			{
				List<PendingPurchaseData> list = new List<PendingPurchaseData>();
				if (index.Length >= 1)
				{
					int num = 0;
					do
					{
						string key = "pending_iap_" + index[num];
						string text = PlayerPrefs.GetString(key, "");
						if (string.IsNullOrEmpty(text))
						{
							RemoveFromIndex(index[num]);
						}
						else
						{
							PendingPurchaseData pendingPurchaseData = JsonUtility.FromJson<PendingPurchaseData>(text);
							if (pendingPurchaseData != null)
							{
								list.Add(pendingPurchaseData);
							}
							else
							{
								string key2 = "pending_iap_" + index[num];
								PlayerPrefs.DeleteKey(key2);
								RemoveFromIndex(index[num]);
								PlayerPrefs.Save();
							}
						}
						num++;
					}
					while (num < index.Length);
				}
				return list.ToArray();
			}
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X0_v20 (Il2CppClass<System.EmptyArray`1<_game.Systems.ShopSystem.Scripts.IAP.PendingPurchaseGuard+PendingPurchaseData>>)+135]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag = num3 == 0;
			nint num4 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X0_v9+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<PendingPurchaseData>();
		}

		[Token(Token = "0x6001DEC")]
		[Address(RVA = "0x3D7E990", Offset = "0x3D7E990", Length = "0x60")]
		public static bool HasPending(string bundleId)
		{
			string key = "pending_iap_" + bundleId;
			return PlayerPrefs.HasKey(key);
		}

		[Token(Token = "0x6001DED")]
		[Address(RVA = "0x3D7E83C", Offset = "0x3D7E83C", Length = "0x154")]
		private static string[] GetIndex()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PendingPurchaseGuard::GetIndex");
			return default;
		}

		[Token(Token = "0x6001DEE")]
		[Address(RVA = "0x3D7E2A0", Offset = "0x3D7E2A0", Length = "0xDC")]
		private static void AddToIndex(string bundleId)
		{
			//IL_0093: Expected I4, but got I8
			string[] index = GetIndex();
			string text = default(string);
			int num = Array.IndexOf((object[])index, (object)text);
			if ((int)(num & 0x80000000L) != 0)
			{
				bool flag = index.Length == 0;
				string value = text;
				if (!flag)
				{
					string text2 = string.Join(",", index);
					string text3 = text2 + "," + text;
					value = text3;
				}
				PlayerPrefs.SetString("pending_iap_index", value);
			}
		}

		[Token(Token = "0x6001DEF")]
		[Address(RVA = "0x3D7E3EC", Offset = "0x3D7E3EC", Length = "0x16C")]
		internal static void RemoveFromIndex(string bundleId)
		{
			string[] index = GetIndex();
			Func<string, bool> predicate = (string id) => id != bundleId;
			IEnumerable<object> values = index.Where((Func<object, bool>)predicate);
			string value = string.Join(",", (IEnumerable<string>)values);
			if (string.IsNullOrEmpty(value))
			{
				PlayerPrefs.DeleteKey("pending_iap_index");
			}
			else
			{
				PlayerPrefs.SetString("pending_iap_index", value);
			}
		}
	}
}
