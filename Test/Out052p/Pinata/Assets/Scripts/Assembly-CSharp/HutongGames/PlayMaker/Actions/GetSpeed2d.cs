using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A89C", Offset = "0x75A89C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A89C", Offset = "0x75A89C")]
	[Token(Token = "0x20002C2")]
	public class GetSpeed2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BD7E0", Offset = "0x7BD7E0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD7E0", Offset = "0x7BD7E0")]
		[Token(Token = "0x400181A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BD878", Offset = "0x7BD878")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD878", Offset = "0x7BD878")]
		[Token(Token = "0x400181B")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BD8D8", Offset = "0x7BD8D8")]
		[Token(Token = "0x400181C")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000DD0")]
		[Address(RVA = "0xA35CC0", Offset = "0xA35CC0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000DD1")]
		[Address(RVA = "0xA35CCC", Offset = "0xA35CCC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSpeed2d::DoGetSpeed(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSpeed();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DD2")]
		[Address(RVA = "0xA35DE0", Offset = "0xA35DE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSpeed2d::DoGetSpeed(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSpeed();
		}

		[Token(Token = "0x6000DD3")]
		[Address(RVA = "0xA35D08", Offset = "0xA35D08", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFE688]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E10]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeResult);\n\tv60 = v43 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0044;\n\tv102 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GetSpeed2d)+30]), this.gameObject);\n\tv90 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v102);\n\tv92 = v90 == 0;\n\tif (v92) goto L_0044;\n\tv57 = this.storeResult;\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv70 = UnityEngine.Rigidbody2D::get_velocity(v50);\n\tv75 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(&v70 @ V0_v3 (UnityEngine.Vector2), 0);\n\tv57.value = v70;\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSpeed()
		{
			//IL_0053: Expected O, but got I
			if (!storeResult.IsNone)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetSpeed2d)+30]");
				GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
				if (UpdateCache(ownerDefaultTarget))
				{
					FsmFloat fsmFloat = storeResult;
					Rigidbody2D rigidbody2D = base.rigidbody2d;
					Vector2 velocity = rigidbody2D.velocity;
					bool flag = ((ComponentAction<Rigidbody2D>)velocity).UpdateCache((GameObject)null);
					fsmFloat.Value = velocity.x;
				}
			}
		}

		[Token(Token = "0x6000DD4")]
		[Address(RVA = "0xA35DE4", Offset = "0xA35DE4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFB6F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E11]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSpeed2d()
		{
		}
	}
}
