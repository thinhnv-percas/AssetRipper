using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A52C", Offset = "0x75A52C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A52C", Offset = "0x75A52C")]
	[Token(Token = "0x20002B7")]
	public class AddTorque2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BBAC8", Offset = "0x7BBAC8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBAC8", Offset = "0x7BBAC8")]
		[Token(Token = "0x40017A8")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBB60", Offset = "0x7BBB60")]
		[Token(Token = "0x40017A9")]
		[FieldOffset(Offset = "0x68")]
		public ForceMode2D forceMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBB98", Offset = "0x7BBB98")]
		[Token(Token = "0x40017AA")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat torque;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BBBD0", Offset = "0x7BBBD0")]
		[Token(Token = "0x40017AB")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000D8D")]
		[Address(RVA = "0xA13AB4", Offset = "0xA13AB4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleFixedUpdate(*([this @ X0 (HutongGames.PlayMaker.Actions.AddTorque2d)+30]), 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			//IL_0016: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddTorque2d)+30]");
			((Fsm)0).HandleFixedUpdate = true;
		}

		[Token(Token = "0x6000D8E")]
		[Address(RVA = "0xA13AD4", Offset = "0xA13AD4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.torque = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			torque = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000D8F")]
		[Address(RVA = "0xA13AE4", Offset = "0xA13AE4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddTorque2d::DoAddTorque(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddTorque();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D90")]
		[Address(RVA = "0xA13BE4", Offset = "0xA13BE4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddTorque2d::DoAddTorque(this);\n\treturn;\n")]
		public override void OnFixedUpdate()
		{
			DoAddTorque();
		}

		[Token(Token = "0x6000D91")]
		[Address(RVA = "0xA13B20", Offset = "0xA13B20", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB1F70]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D27]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.AddTorque2d)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v43);\n\tv70 = v50 == 0;\n\tif (v70) goto L_003F;\n\tv58 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.torque);\n\tUnityEngine.Rigidbody2D::AddTorque(v58, v52, this.forceMode);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddTorque()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.AddTorque2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				float value = torque.Value;
				rigidbody2D.AddTorque(value, forceMode);
			}
		}

		[Token(Token = "0x6000D92")]
		[Address(RVA = "0xA13BE8", Offset = "0xA13BE8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED7468]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D28]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddTorque2d()
		{
		}
	}
}
