using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x2000134")]
	public abstract class FsmStateActionAnimatorBase : FsmStateAction
	{
		[Token(Token = "0x200047E")]
		public enum AnimatorFrameUpdateSelector
		{
			[Token(Token = "0x4002144")]
			OnUpdate = 0,
			[Token(Token = "0x4002145")]
			OnAnimatorMove = 1,
			[Token(Token = "0x4002146")]
			OnAnimatorIK = 2
		}

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3D80", Offset = "0x7A3D80")]
		[Token(Token = "0x4001115")]
		[FieldOffset(Offset = "0x49")]
		public bool everyFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3DB8", Offset = "0x7A3DB8")]
		[Token(Token = "0x4001116")]
		[FieldOffset(Offset = "0x4C")]
		public AnimatorFrameUpdateSelector everyFrameOption;

		[Token(Token = "0x4001117")]
		[FieldOffset(Offset = "0x50")]
		protected int IklayerIndex;

		[Token(Token = "0x60006EE")]
		public abstract void OnActionUpdate();

		[Token(Token = "0x60006EF")]
		[Address(RVA = "0xB77630", Offset = "0xB77630", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
		}

		[Token(Token = "0x60006F0")]
		[Address(RVA = "0xB7763C", Offset = "0xB7763C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = this.everyFrameOption;\n\tv20 = this.everyFrameOption != 1;\n\tif (v20) goto L_0022;\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorMove(this.fsm, 1);\n\tv32 = this.everyFrameOption;\nL_0022:\n\tv43 = v32 != 2;\n\tif (v43) goto L_0033;\n\tHutongGames.PlayMaker.Fsm::set_HandleAnimatorIK(this.fsm, 1);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			AnimatorFrameUpdateSelector animatorFrameUpdateSelector = everyFrameOption;
			if (everyFrameOption == AnimatorFrameUpdateSelector.OnAnimatorMove)
			{
				Fsm.HandleAnimatorMove = true;
				animatorFrameUpdateSelector = everyFrameOption;
			}
			if (animatorFrameUpdateSelector == AnimatorFrameUpdateSelector.OnAnimatorIK)
			{
				Fsm.HandleAnimatorIK = true;
			}
		}

		[Token(Token = "0x60006F1")]
		[Address(RVA = "0xB776A4", Offset = "0xB776A4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0010;\n\tv17 = HutongGames.PlayMaker.Actions.FsmStateActionAnimatorBase::OnActionUpdate(this);\nL_0010:\n\tv39 = ~this.everyFrame;\n\tif (v39) goto L_001D;\n\treturn;\nL_001D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == AnimatorFrameUpdateSelector.OnUpdate)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006F2")]
		[Address(RVA = "0xB776F8", Offset = "0xB776F8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.everyFrameOption != 1;\n\tif (v20) goto L_0018;\n\tv25 = HutongGames.PlayMaker.Actions.FsmStateActionAnimatorBase::OnActionUpdate(this);\nL_0018:\n\tv47 = ~this.everyFrame;\n\tif (v47) goto L_0025;\n\treturn;\nL_0025:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorMove()
		{
			if (everyFrameOption == AnimatorFrameUpdateSelector.OnAnimatorMove)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006F3")]
		[Address(RVA = "0xB77750", Offset = "0xB77750", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IklayerIndex = layerIndex;\n\tv21 = this.everyFrameOption != 2;\n\tif (v21) goto L_0019;\n\tv26 = HutongGames.PlayMaker.Actions.FsmStateActionAnimatorBase::OnActionUpdate(this);\nL_0019:\n\tv47 = ~this.everyFrame;\n\tif (v47) goto L_0026;\n\treturn;\nL_0026:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DoAnimatorIK(int layerIndex)
		{
			IklayerIndex = layerIndex;
			if (everyFrameOption == AnimatorFrameUpdateSelector.OnAnimatorIK)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60006F4")]
		[Address(RVA = "0xB777AC", Offset = "0xB777AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal FsmStateActionAnimatorBase()
		{
		}
	}
}
