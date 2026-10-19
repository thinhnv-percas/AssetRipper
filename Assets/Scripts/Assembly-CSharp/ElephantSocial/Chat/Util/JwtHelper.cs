using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Cpp2ILInjected;

namespace ElephantSocial.Chat.Util
{
	[Token(Token = "0x20008FC")]
	public static class JwtHelper
	{
		[Token(Token = "0x60025C4")]
		[Address(RVA = "0x3E09408", Offset = "0x3E09408", Length = "0x47C")]
		public static string GenerateJwtToken(string elephantId, string gameId, string gameSecret)
		{
			//IL_00d9: Expected F8, but got I4
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("alg", "HS256");
			dictionary.Add("typ", "JWT");
			DateTime utcNow = DateTime.UtcNow;
			DateTime dateTime = utcNow;
			DateTime value = new DateTime(1970, 1, 1);
			TimeSpan timeSpan = dateTime.Subtract(value);
			TimeSpan timeSpan2 = timeSpan;
			double totalSeconds = timeSpan2.TotalSeconds;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			double num = ((totalSeconds != 9.218868437227405E+18) ? totalSeconds : (-2147483648.0));
			double num2 = num + 1.5367418E-316;
			dictionary2.Add("sub", elephantId);
			dictionary2.Add("iss", gameId);
			double num3 = num;
			int num4 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			dictionary2.Add("iat", value2);
			double num5 = num2;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value3 = default(object);
			dictionary2.Add("exp", value3);
			string s = SerializeJson(dictionary);
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(s);
			string text = Base64UrlEncode(bytes);
			string s2 = SerializeJson(dictionary2);
			Encoding uTF2 = Encoding.UTF8;
			byte[] bytes2 = uTF2.GetBytes(s2);
			string text2 = Base64UrlEncode(bytes2);
			string input = text + "." + text2;
			string text3 = CreateSignature(input, gameSecret);
			return text + "." + text2 + "." + text3;
		}

		[Token(Token = "0x60025C5")]
		[Address(RVA = "0x3E09C84", Offset = "0x3E09C84", Length = "0x3B8")]
		private unsafe static string SerializeJson(Dictionary<string, object> dict)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("JwtHelper::SerializeJson");
			return default;
		}

		[Token(Token = "0x60025C6")]
		[Address(RVA = "0x3E09884", Offset = "0x3E09884", Length = "0x3C0")]
		private unsafe static string SerializeJson(Dictionary<string, string> dict)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("JwtHelper::SerializeJson");
			return default;
		}

		[Token(Token = "0x60025C7")]
		[Address(RVA = "0x3E09C44", Offset = "0x3E09C44", Length = "0x40")]
		private static string Base64UrlEncode(string input)
		{
			Encoding uTF = Encoding.UTF8;
			byte[] bytes = uTF.GetBytes(input);
			return Base64UrlEncode(bytes);
		}

		[Token(Token = "0x60025C8")]
		[Address(RVA = "0x3E0A21C", Offset = "0x3E0A21C", Length = "0xC0")]
		private static string Base64UrlEncode(byte[] bytes)
		{
			string text = Convert.ToBase64String(bytes);
			if (text != null)
			{
				string text2 = text.Replace('+', '-');
				string text3 = text2.Replace('/', '_');
				return text3.TrimEnd('=');
			}
			return (string)(object)new NullReferenceException();
		}

		[Token(Token = "0x60025C9")]
		[Address(RVA = "0x3E0A03C", Offset = "0x3E0A03C", Length = "0x1E0")]
		private static string CreateSignature(string input, string secret)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("JwtHelper::CreateSignature");
			return default;
		}
	}
}
