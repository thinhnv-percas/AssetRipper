using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B860", Offset = "0x75B860")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B860", Offset = "0x75B860")]
	[Token(Token = "0x20002F1")]
	public class QuaternionAngleAxis : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1670", Offset = "0x7C1670")]
		[Token(Token = "0x4001901")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat angle;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C16BC", Offset = "0x7C16BC")]
		[Token(Token = "0x4001902")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 axis;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1708", Offset = "0x7C1708")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1708", Offset = "0x7C1708")]
		[Token(Token = "0x4001903")]
		[FieldOffset(Offset = "0x60")]
		public FsmQuaternion result;

		[Token(Token = "0x6000EB7")]
		[Address(RVA = "0xB1B80C", Offset = "0xB1B80C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.axis = 0;\n\tthis.result = 0;\n\tthis.angle = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			axis = null;
			result = null;
			angle = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EB8")]
		[Address(RVA = "0xB1B824", Offset = "0xB1B824", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionAngleAxis::DoQuatAngleAxis(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatAngleAxis();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EB9")]
		[Address(RVA = "0xB1B934", Offset = "0xB1B934", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionAngleAxis::DoQuatAngleAxis(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatAngleAxis();
			}
		}

		[Token(Token = "0x6000EBA")]
		[Address(RVA = "0xB1B944", Offset = "0xB1B944", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionAngleAxis::DoQuatAngleAxis(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatAngleAxis();
			}
		}

		[Token(Token = "0x6000EBB")]
		[Address(RVA = "0xB1B958", Offset = "0xB1B958", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionAngleAxis::DoQuatAngleAxis(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatAngleAxis();
			}
		}

		[Token(Token = "0x6000EBC")]
		[Address(RVA = "0xB1B860", Offset = "0xB1B860", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EFB6B8]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202257A]) = v46;\nL_001A:\n\tv49 = this.result;\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.angle);\n\tv91 = HutongGames.PlayMaker.FsmVector3::get_Value(this.axis);\n\tgoto L_003A;\n\tv125 = *([v96 @ X0_v9+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_003A;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v96, v81, v30, v31, v32, v33, v34, v35, v91, v92, v93, v39, v40, v41, v42, v43);\nL_003A:\n\tv79 = UnityEngine.Quaternion::AngleAxis(v51, v91);\n\tv49.value = v79;\n\tv49.value.y = v79.y;\n\tv49.value.z = v79.z;\n\tv49.value.w = v79.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatAngleAxis()
		{
			FsmQuaternion fsmQuaternion = result;
			float value = angle.Value;
			Vector3 value2 = axis.Value;
			Quaternion quaternion = (fsmQuaternion.value = Quaternion.AngleAxis(value, value2));
			fsmQuaternion.value.y = quaternion.y;
			fsmQuaternion.value.z = quaternion.z;
			fsmQuaternion.value.w = quaternion.w;
		}

		[Token(Token = "0x6000EBD")]
		[Address(RVA = "0xB1B96C", Offset = "0xB1B96C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionAngleAxis()
		{
		}
	}
}
