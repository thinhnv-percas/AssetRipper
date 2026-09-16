using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B900", Offset = "0x75B900")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B900", Offset = "0x75B900")]
	[Token(Token = "0x20002F4")]
	public class QuaternionEuler : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1918", Offset = "0x7C1918")]
		[Token(Token = "0x400190B")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 eulerAngles;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1964", Offset = "0x7C1964")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1964", Offset = "0x7C1964")]
		[Token(Token = "0x400190C")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion result;

		[Token(Token = "0x6000EC7")]
		[Address(RVA = "0xB1BC30", Offset = "0xB1BC30", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.eulerAngles = 0;\n\tthis.result = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			eulerAngles = null;
			result = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EC8")]
		[Address(RVA = "0xB1BC44", Offset = "0xB1BC44", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionEuler::DoQuatEuler(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatEuler();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EC9")]
		[Address(RVA = "0xB1BD3C", Offset = "0xB1BD3C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionEuler::DoQuatEuler(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatEuler();
			}
		}

		[Token(Token = "0x6000ECA")]
		[Address(RVA = "0xB1BD4C", Offset = "0xB1BD4C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionEuler::DoQuatEuler(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatEuler();
			}
		}

		[Token(Token = "0x6000ECB")]
		[Address(RVA = "0xB1BD60", Offset = "0xB1BD60", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionEuler::DoQuatEuler(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatEuler();
			}
		}

		[Token(Token = "0x6000ECC")]
		[Address(RVA = "0xB1BC80", Offset = "0xB1BC80", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB2B48]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202257D]) = v44;\nL_0019:\n\tv47 = this.result;\n\tv49 = HutongGames.PlayMaker.FsmVector3::get_Value(this.eulerAngles);\n\tgoto L_0032;\n\tv86 = *([v58 @ X0_v7+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0032;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v58, v48, v28, v29, v30, v31, v32, v33, v49, v51, v52, v37, v38, v39, v40, v41);\nL_0032:\n\tv75 = UnityEngine.Quaternion::Euler(v49);\n\tv47.value = v75;\n\tv47.value.y = v75.y;\n\tv47.value.z = v75.z;\n\tv47.value.w = v75.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatEuler()
		{
			FsmQuaternion fsmQuaternion = result;
			Vector3 value = eulerAngles.Value;
			Quaternion quaternion = (fsmQuaternion.value = Quaternion.Euler(value));
			fsmQuaternion.value.y = quaternion.y;
			fsmQuaternion.value.z = quaternion.z;
			fsmQuaternion.value.w = quaternion.w;
		}

		[Token(Token = "0x6000ECD")]
		[Address(RVA = "0xB1BD74", Offset = "0xB1BD74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionEuler()
		{
		}
	}
}
