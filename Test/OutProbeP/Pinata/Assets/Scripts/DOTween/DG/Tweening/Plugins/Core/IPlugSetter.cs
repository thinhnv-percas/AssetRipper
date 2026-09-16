using Cpp2ILInjected;
using DG.Tweening.Core;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x200003D")]
	public interface IPlugSetter<T1, out T2, TPlugin, out TPlugOptions>
	{
		[Token(Token = "0x6000230")]
		DOGetter<T1> Getter();

		[Token(Token = "0x6000231")]
		DOSetter<T1> Setter();

		[Token(Token = "0x6000232")]
		T2 EndValue();

		[Token(Token = "0x6000233")]
		TPlugOptions GetOptions();
	}
}
