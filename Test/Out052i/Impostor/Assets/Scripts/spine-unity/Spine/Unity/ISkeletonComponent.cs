using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000A3")]
	public interface ISkeletonComponent
	{
		[Token(Token = "0x170001B4")]
		SkeletonDataAsset SkeletonDataAsset
		{
			[Token(Token = "0x6000668")]
			get;
		}

		[Token(Token = "0x170001B5")]
		Skeleton Skeleton
		{
			[Token(Token = "0x6000669")]
			get;
		}
	}
}
