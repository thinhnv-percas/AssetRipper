using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;

namespace ElephantSocial
{
	[Token(Token = "0x200081E")]
	public class SocialDataStore : GenericResponseOps
	{
		[Token(Token = "0x4001B8E")]
		private const string MainKey = "SocialDataStore";

		[Token(Token = "0x60022EE")]
		[Address(RVA = "0x3DDB400", Offset = "0x3DDB400", Length = "0x58")]
		private string GenerateKey(string val)
		{
			string text = default(string);
			return "SocialDataStore" + text;
		}

		[Token(Token = "0x60022EF")]
		[Address(RVA = "0x4CADA20", Offset = "0x4CADA20", Length = "0x94")]
		protected internal void Save<T>(string key, T data)
		{
			string value = JsonConvert.SerializeObject(data);
			string key2 = GenerateKey(key);
			PlayerPrefs.SetString(key2, value);
		}

		[Token(Token = "0x60022F0")]
		[Address(RVA = "0x4CAD578", Offset = "0x4CAD578", Length = "0x1C8")]
		protected internal T Load<T>(string key)
		{
			string val = default(string);
			string key2 = GenerateKey(val);
			string value = PlayerPrefs.GetString(key2, "");
			bool flag = string.IsNullOrEmpty(value);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			T result = default(T);
			if (!flag3)
			{
				return JsonConvert.DeserializeObject<T>(value);
			}
			return result;
		}

		[Token(Token = "0x60022F1")]
		[Address(RVA = "0x3DDB458", Offset = "0x3DDB458", Length = "0x8")]
		public SocialDataStore()
		{
		}
	}
}
