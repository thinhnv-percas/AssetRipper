using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x20002F2")]
	public abstract class QuaternionBaseAction : FsmStateAction
	{
		[Token(Token = "0x2000491")]
		public enum everyFrameOptions
		{
			[Token(Token = "0x4002195")]
			Update = 0,
			[Token(Token = "0x4002196")]
			FixedUpdate = 1,
			[Token(Token = "0x4002197")]
			LateUpdate = 2
		}

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1768", Offset = "0x7C1768")]
		[Token(Token = "0x4001904")]
		[FieldOffset(Offset = "0x49")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C17A0", Offset = "0x7C17A0")]
		[Token(Token = "0x4001905")]
		[FieldOffset(Offset = "0x4C")]
		public everyFrameOptions everyFrameOption;

		[Token(Token = "0x6000EBE")]
		[Address(RVA = "0xB1B97C", Offset = "0xB1B97C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~this.everyFrame;\n\tif (v8) goto L_002A;\n\tv14 = this.everyFrameOption == 2;\n\tif (v14) goto L_0033;\n\tv21 = this.everyFrameOption != 1;\n\tif (v21) goto L_002A;\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(this.fsm, 1);\n\treturn;\nL_002A:\n\treturn;\nL_0033:\n\tHutongGames.PlayMaker.Fsm::set_HandleLateUpdate(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Awake()
		{
			if (!everyFrame)
			{
				return;
			}
			if (everyFrameOption != everyFrameOptions.LateUpdate)
			{
				if (everyFrameOption == everyFrameOptions.FixedUpdate)
				{
					Fsm.HandleFixedUpdate = true;
				}
			}
			else
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x6000EBF")]
		[Address(RVA = "0xB1B974", Offset = "0xB1B974", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal QuaternionBaseAction()
		{
		}
	}
}
