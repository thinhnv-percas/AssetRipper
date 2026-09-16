using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B950", Offset = "0x75B950")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B950", Offset = "0x75B950")]
	[Token(Token = "0x20002F5")]
	public class QuaternionInverse : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C19C4", Offset = "0x7C19C4")]
		[Token(Token = "0x400190D")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion rotation;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1A10", Offset = "0x7C1A10")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1A10", Offset = "0x7C1A10")]
		[Token(Token = "0x400190E")]
		[FieldOffset(Offset = "0x58")]
		public FsmQuaternion result;

		[Token(Token = "0x6000ECE")]
		[Address(RVA = "0xB1BD7C", Offset = "0xB1BD7C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotation = 0;\n\tthis.result = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			rotation = null;
			result = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000ECF")]
		[Address(RVA = "0xB1BD90", Offset = "0xB1BD90", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionInverse::DoQuatInverse(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatInverse();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000ED0")]
		[Address(RVA = "0xB1BE7C", Offset = "0xB1BE7C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionInverse::DoQuatInverse(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatInverse();
			}
		}

		[Token(Token = "0x6000ED1")]
		[Address(RVA = "0xB1BE8C", Offset = "0xB1BE8C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionInverse::DoQuatInverse(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatInverse();
			}
		}

		[Token(Token = "0x6000ED2")]
		[Address(RVA = "0xB1BEA0", Offset = "0xB1BEA0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionInverse::DoQuatInverse(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatInverse();
			}
		}

		[Token(Token = "0x6000ED3")]
		[Address(RVA = "0xB1BDCC", Offset = "0xB1BDCC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F04D88]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202257E]) = v46;\nL_0017:\n\tv47 = this.rotation;\n\tv51 = this.result;\n\tgoto L_0030;\n\tv86 = *([v56 @ X0_v5+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0030;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0030:\n\t// 48 MakeStruct v61 @ AGGB1BE50_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v47.value (UnityEngine.Quaternion), v47.value.y (System.Single), v47.value.z (System.Single), v47.value.w (System.Single)\n\tv70 = UnityEngine.Quaternion::Inverse(v61);\n\tv51.value = v70;\n\tv51.value.y = v70.y;\n\tv51.value.z = v70.z;\n\tv51.value.w = v70.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatInverse()
		{
			FsmQuaternion fsmQuaternion = rotation;
			FsmQuaternion fsmQuaternion2 = result;
			Quaternion quaternion = default(Quaternion);
			quaternion.x = fsmQuaternion.value.x;
			quaternion.y = fsmQuaternion.value.y;
			quaternion.z = fsmQuaternion.value.z;
			quaternion.w = fsmQuaternion.value.w;
			Quaternion quaternion2 = (fsmQuaternion2.value = Quaternion.Inverse(quaternion));
			fsmQuaternion2.value.y = quaternion2.y;
			fsmQuaternion2.value.z = quaternion2.z;
			fsmQuaternion2.value.w = quaternion2.w;
		}

		[Token(Token = "0x6000ED4")]
		[Address(RVA = "0xB1BEB4", Offset = "0xB1BEB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionInverse()
		{
		}
	}
}
