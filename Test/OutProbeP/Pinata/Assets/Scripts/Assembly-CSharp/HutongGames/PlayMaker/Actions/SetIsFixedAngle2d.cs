using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Obsolete]
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75ADEC", Offset = "0x75ADEC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75ADEC", Offset = "0x75ADEC")]
	[Token(Token = "0x20002D3")]
	public class SetIsFixedAngle2d : ComponentAction<Rigidbody2D>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BFA30", Offset = "0x7BFA30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFA30", Offset = "0x7BFA30")]
		[Token(Token = "0x4001899")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFAC8", Offset = "0x7BFAC8")]
		[Token(Token = "0x400189A")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isFixedAngle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFB14", Offset = "0x7BFB14")]
		[Token(Token = "0x400189B")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000E23")]
		[Address(RVA = "0x995960", Offset = "0x995960", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.isFixedAngle = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			isFixedAngle = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x6000E24")]
		[Address(RVA = "0x995994", Offset = "0x995994", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetIsFixedAngle2d::DoSetIsFixedAngle(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetIsFixedAngle();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E25")]
		[Address(RVA = "0x995AC4", Offset = "0x995AC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetIsFixedAngle2d::DoSetIsFixedAngle(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetIsFixedAngle();
		}

		[Token(Token = "0x6000E26")]
		[Address(RVA = "0x9959D0", Offset = "0x9959D0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EAC5C0]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202175A]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetIsFixedAngle2d)+30]), this.gameObject);\n\tv66 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::UpdateCache(this, v45);\n\tv80 = v66 == 0;\n\tif (v80) goto L_0043;\n\tv106 = HutongGames.PlayMaker.FsmBool::get_Value(this.isFixedAngle);\n\tv111 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv55 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::get_rigidbody2d(this);\n\tv72 = UnityEngine.Rigidbody2D::get_constraints(v55);\n\tv97 = v106 == 0;\n\tif (v97) goto L_0044;\n\tv114 = v72 | 4;\n\tgoto L_004D;\nL_0043:\n\treturn;\nL_0044:\n\tv115 = v72 & 0xFFFFFFFB;\nL_004D:\n\tUnityEngine.Rigidbody2D::set_constraints(v111, v93);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetIsFixedAngle()
		{
			//IL_001c: Expected O, but got I
			//IL_00da: Expected I4, but got I8
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetIsFixedAngle2d)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				bool value = isFixedAngle.Value;
				Rigidbody2D rigidbody2D = base.rigidbody2d;
				Rigidbody2D rigidbody2D2 = base.rigidbody2d;
				RigidbodyConstraints2D constraints = rigidbody2D2.constraints;
				RigidbodyConstraints2D constraints2;
				if (value)
				{
					int num = (int)(constraints | RigidbodyConstraints2D.FreezeRotation);
					constraints2 = (RigidbodyConstraints2D)num;
				}
				else
				{
					int num2 = (int)((long)constraints & 0xFFFFFFFBL);
					constraints2 = (RigidbodyConstraints2D)num2;
				}
				rigidbody2D.constraints = constraints2;
			}
		}

		[Token(Token = "0x6000E27")]
		[Address(RVA = "0x995AC8", Offset = "0x995AC8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED5368]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202175B]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody2D>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetIsFixedAngle2d()
		{
		}
	}
}
