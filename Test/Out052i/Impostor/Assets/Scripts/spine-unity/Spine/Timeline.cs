using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000008")]
	public interface Timeline
	{
		[Token(Token = "0x17000009")]
		int PropertyId
		{
			[Token(Token = "0x600002C")]
			get;
		}

		[Token(Token = "0x600002B")]
		void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction);
	}
}
