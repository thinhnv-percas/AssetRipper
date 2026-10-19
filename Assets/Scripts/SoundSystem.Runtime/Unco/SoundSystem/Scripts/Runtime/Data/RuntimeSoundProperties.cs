using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[Token(Token = "0x200001B")]
	public class RuntimeSoundProperties : SoundProperties
	{
		[Token(Token = "0x17000008")]
		[field: Token(Token = "0x4000064")]
		[field: FieldOffset(Offset = "0x2C")]
		public float LastPlayedTime
		{
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x7B9E434", Offset = "0x7B9E434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LastPlayedTime;\n")]
			get;
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x7B9E43C", Offset = "0x7B9E43C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.LastPlayedTime = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x7B9E3AC", Offset = "0x7B9E3AC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Volume = 0f;\n\tSystem.Object::.ctor(this);\n\tthis.Type = soundProperties.Type;\n\tthis.Volume = soundProperties.Volume;\n\tthis.IsLoop = soundProperties.IsLoop;\n\tthis.IsMusic = soundProperties.IsMusic;\n\tthis.CoolDown = soundProperties.CoolDown;\n\treturn;\n")]
		public RuntimeSoundProperties(SoundProperties soundProperties)
		{
			Volume = 0f;
			Type = soundProperties.Type;
			Volume = soundProperties.Volume;
			IsLoop = soundProperties.IsLoop;
			IsMusic = ((soundProperties.IsMusic ? 1u : 0u) & 0xFFu) != 0;
			IsMultiple = (((soundProperties.IsMusic ? 1u : 0u) >> 8) & 0xFF) != 0;
			CoolDown = soundProperties.CoolDown;
		}
	}
}
