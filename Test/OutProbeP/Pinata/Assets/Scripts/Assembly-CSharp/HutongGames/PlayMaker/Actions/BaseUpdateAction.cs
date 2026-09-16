using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x2000190")]
	public abstract class BaseUpdateAction : FsmStateAction
	{
		[Token(Token = "0x2000483")]
		public enum UpdateType
		{
			[Token(Token = "0x4002157")]
			OnUpdate = 0,
			[Token(Token = "0x4002158")]
			OnLateUpdate = 1,
			[Token(Token = "0x4002159")]
			OnFixedUpdate = 2
		}

		[Attribute(Type = typeof(ActionSection), RVA = "0x7AB6AC", Offset = "0x7AB6AC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AB6AC", Offset = "0x7AB6AC")]
		[Token(Token = "0x40012BE")]
		[FieldOffset(Offset = "0x49")]
		public bool everyFrame;

		[Token(Token = "0x40012BF")]
		[FieldOffset(Offset = "0x4C")]
		public UpdateType updateType;

		[Token(Token = "0x600088D")]
		public abstract void OnActionUpdate();

		[Token(Token = "0x600088E")]
		[Address(RVA = "0xA8B84C", Offset = "0xA8B84C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.updateType = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			updateType = default(UpdateType);
		}

		[Token(Token = "0x600088F")]
		[Address(RVA = "0xA8B858", Offset = "0xA8B858", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.updateType == 1;\n\tif (v12) goto L_002C;\n\tv26 = this.updateType != 2;\n\tif (v26) goto L_0031;\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(this.fsm, 1);\n\treturn;\nL_002C:\n\tHutongGames.PlayMaker.Fsm::set_HandleLateUpdate(this.fsm, 1);\n\treturn;\nL_0031:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			if (updateType != UpdateType.OnLateUpdate)
			{
				if (updateType == UpdateType.OnFixedUpdate)
				{
					Fsm.HandleFixedUpdate = true;
				}
			}
			else
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x6000890")]
		[Address(RVA = "0xA8B8B0", Offset = "0xA8B8B0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.updateType == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0010;\n\tv17 = HutongGames.PlayMaker.Actions.BaseUpdateAction::OnActionUpdate(this);\nL_0010:\n\tv39 = ~this.everyFrame;\n\tif (v39) goto L_001D;\n\treturn;\nL_001D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (updateType == UpdateType.OnUpdate)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000891")]
		[Address(RVA = "0xA8B904", Offset = "0xA8B904", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.updateType != 1;\n\tif (v20) goto L_0018;\n\tv25 = HutongGames.PlayMaker.Actions.BaseUpdateAction::OnActionUpdate(this);\nL_0018:\n\tv47 = ~this.everyFrame;\n\tif (v47) goto L_0025;\n\treturn;\nL_0025:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (updateType == UpdateType.OnLateUpdate)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000892")]
		[Address(RVA = "0xA8B95C", Offset = "0xA8B95C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.updateType != 2;\n\tif (v20) goto L_0018;\n\tv25 = HutongGames.PlayMaker.Actions.BaseUpdateAction::OnActionUpdate(this);\nL_0018:\n\tv47 = ~this.everyFrame;\n\tif (v47) goto L_0025;\n\treturn;\nL_0025:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (updateType == UpdateType.OnFixedUpdate)
			{
				OnActionUpdate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000893")]
		[Address(RVA = "0xA8B9B4", Offset = "0xA8B9B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseUpdateAction()
		{
		}
	}
}
