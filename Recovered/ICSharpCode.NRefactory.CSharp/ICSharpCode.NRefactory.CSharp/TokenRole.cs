using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp
{
	public sealed class TokenRole : Role<CSharpTokenNode>
	{
		internal static readonly List<string> Tokens;

		internal static readonly List<int> TokenLengths;

		internal readonly uint TokenIndex;

		public string Token
		{
			get;
			private set;
		}

		public int Length
		{
			get;
			private set;
		}

		static TokenRole()
		{
			Tokens = new List<string>();
			TokenLengths = new List<int>();
			Tokens.Add("");
			TokenLengths.Add(0);
		}

		public TokenRole(string token)
			: base(token, CSharpTokenNode.Null)
		{
			Token = token;
			Length = token.Length;
			bool flag = false;
			for (int i = 0; i < Tokens.Count; i++)
			{
				if (Tokens[i] == token)
				{
					TokenIndex = (uint)i;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				TokenIndex = (uint)Tokens.Count;
				Tokens.Add(token);
				TokenLengths.Add(Length);
			}
		}
	}
}
