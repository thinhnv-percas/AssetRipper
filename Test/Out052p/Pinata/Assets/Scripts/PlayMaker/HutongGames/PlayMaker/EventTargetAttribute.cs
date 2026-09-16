using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73EB28", Offset = "0x73EB28")]
	[Token(Token = "0x2000037")]
	public sealed class EventTargetAttribute : Attribute
	{
		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x10")]
		private readonly FsmEventTarget.EventTarget target;

		[Token(Token = "0x17000046")]
		public FsmEventTarget.EventTarget Target
		{
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x9D830C", Offset = "0x9D830C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Target;
			}
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0x9D8314", Offset = "0x9D8314", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.target = target;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EventTargetAttribute(FsmEventTarget.EventTarget target)
		{
			this.target = target;
		}
	}
}
