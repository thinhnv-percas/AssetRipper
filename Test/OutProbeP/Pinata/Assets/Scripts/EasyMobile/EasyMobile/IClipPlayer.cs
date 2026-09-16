using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200005B")]
	public interface IClipPlayer
	{
		[Token(Token = "0x1700014B")]
		ClipPlayerScaleMode ScaleMode
		{
			[Token(Token = "0x6000475")]
			get;
			[Token(Token = "0x6000476")]
			set;
		}

		[Token(Token = "0x6000477")]
		void Play(AnimatedClip clip, float startDelay = 0f, bool loop = true);

		[Token(Token = "0x6000478")]
		void Pause();

		[Token(Token = "0x6000479")]
		void Resume();

		[Token(Token = "0x600047A")]
		void Stop();
	}
}
