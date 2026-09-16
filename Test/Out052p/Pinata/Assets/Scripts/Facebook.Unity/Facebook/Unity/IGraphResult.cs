using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000029")]
	public interface IGraphResult : IResult
	{
		[Token(Token = "0x1700003D")]
		Texture2D Texture
		{
			[Token(Token = "0x60000FB")]
			get;
		}
	}
}
