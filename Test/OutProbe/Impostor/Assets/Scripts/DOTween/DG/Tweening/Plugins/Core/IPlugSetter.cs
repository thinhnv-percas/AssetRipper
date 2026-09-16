using Cpp2ILInjected;
using DG.Tweening.Core;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x2000095")]
	public interface IPlugSetter<T1, out T2, TPlugin, out TPlugOptions>
	{
		[Token(Token = "0x6000379")]
		DOGetter<T1> Getter();

		[Token(Token = "0x600037A")]
		DOSetter<T1> Setter();

		[Token(Token = "0x600037B")]
		T2 EndValue();

		[Token(Token = "0x600037C")]
		TPlugOptions GetOptions();
	}
}
