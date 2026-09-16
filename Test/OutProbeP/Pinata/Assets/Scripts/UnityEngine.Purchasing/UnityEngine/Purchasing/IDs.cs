using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000003")]
	public class IDs : IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<string, string> m_Dic;

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x160E238", Offset = "0x160E238", Length = "0x70")]
		public IDs()
		{
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x160E2A8", Offset = "0x160E2A8", Length = "0x90")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x160E338", Offset = "0x160E338", Length = "0xC4")]
		public void Add(string id, params string[] stores)
		{
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x160DE78", Offset = "0x160DE78", Length = "0x98")]
		internal string SpecificIDForStore(string store, string defaultValue)
		{
			return null;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x160E3FC", Offset = "0x160E3FC", Length = "0x90")]
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return null;
		}
	}
}
