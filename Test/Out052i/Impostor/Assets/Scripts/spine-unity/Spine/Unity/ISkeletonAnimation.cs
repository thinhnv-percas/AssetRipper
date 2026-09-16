using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000A1")]
	public interface ISkeletonAnimation
	{
		[Token(Token = "0x170001B2")]
		Skeleton Skeleton
		{
			[Token(Token = "0x6000666")]
			get;
		}

		[Token(Token = "0x1400002F")]
		event UpdateBonesDelegate UpdateLocal;

		[Token(Token = "0x14000030")]
		event UpdateBonesDelegate UpdateWorld;

		[Token(Token = "0x14000031")]
		event UpdateBonesDelegate UpdateComplete;
	}
}
