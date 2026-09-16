using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B9F0", Offset = "0x75B9F0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B9F0", Offset = "0x75B9F0")]
	[Token(Token = "0x20002F7")]
	public class QuaternionLookRotation : QuaternionBaseAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C1BCC", Offset = "0x7C1BCC")]
		[Token(Token = "0x4001913")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C1C18", Offset = "0x7C1C18")]
		[Token(Token = "0x4001914")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 upVector;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C1C50", Offset = "0x7C1C50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C1C50", Offset = "0x7C1C50")]
		[Token(Token = "0x4001915")]
		[FieldOffset(Offset = "0x60")]
		public FsmQuaternion result;

		[Token(Token = "0x6000EDC")]
		[Address(RVA = "0xB1C0F4", Offset = "0xB1C0F4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0CA20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022581]) = v38;\nL_0013:\n\tthis.direction = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.upVector = v42;\n\tthis.result = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			direction = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			upVector = fsmVector;
			result = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EDD")]
		[Address(RVA = "0xB1C174", Offset = "0xB1C174", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionLookRotation::DoQuatLookRotation(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatLookRotation();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EDE")]
		[Address(RVA = "0xB1C2F8", Offset = "0xB1C2F8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.QuaternionLookRotation::DoQuatLookRotation(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatLookRotation();
			}
		}

		[Token(Token = "0x6000EDF")]
		[Address(RVA = "0xB1C308", Offset = "0xB1C308", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionLookRotation::DoQuatLookRotation(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatLookRotation();
			}
		}

		[Token(Token = "0x6000EE0")]
		[Address(RVA = "0xB1C31C", Offset = "0xB1C31C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.QuaternionLookRotation::DoQuatLookRotation(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatLookRotation();
			}
		}

		[Token(Token = "0x6000EE1")]
		[Address(RVA = "0xB1C1B0", Offset = "0xB1C1B0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1ECAF10]);\n\tv33 = *([v32 @ X8_v19]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022582]) = v52;\nL_001E:\n\tv56 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.upVector);\n\tv98 = this.result;\n\tv95 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tv190 = v56 == 0;\n\tif (v190) goto L_005B;\n\tgoto L_0040;\n\tv197 = *([v193 @ X0_v16+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_0040;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v193, v101, v36, v37, v38, v39, v40, v41, v95, v92, v89, v45, v46, v47, v48, v49);\nL_0040:\n\tv172 = UnityEngine.Quaternion::LookRotation(v95);\n\tv170 = v172.y;\n\tv168 = v172.z;\n\tv158 = v172.w;\nL_0046:\n\tv98.value = v172;\n\tv98.value.y = v170;\n\tv98.value.z = v168;\n\tv98.value.w = v158;\n\treturn;\nL_005B:\n\tv206 = HutongGames.PlayMaker.FsmVector3::get_Value(this.upVector);\n\tgoto L_0076;\n\tv218 = *([v211 @ X0_v11+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_0076;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v211, v132, v36, v37, v38, v39, v40, v41, v206, v207, v208, v45, v46, v47, v48, v49);\nL_0076:\n\tv172 = UnityEngine.Quaternion::LookRotation(v95, v206);\n\tv170 = v172.y;\n\tv168 = v172.z;\n\tv158 = v172.w;\n\tv228 = this.result == 0;\n\tv136 = ~v228;\n\tif (v136) goto L_0046;\n\tv103 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatLookRotation()
		{
			bool isNone = upVector.IsNone;
			FsmQuaternion fsmQuaternion = result;
			Vector3 value = direction.Value;
			Quaternion value2;
			float y;
			float z;
			float w;
			if (isNone)
			{
				value2 = Quaternion.LookRotation(value);
				y = value2.y;
				z = value2.z;
				w = value2.w;
			}
			else
			{
				Vector3 value3 = upVector.Value;
				value2 = Quaternion.LookRotation(value, value3);
				y = value2.y;
				z = value2.z;
				w = value2.w;
				if (result == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			fsmQuaternion.value = value2;
			fsmQuaternion.value.y = y;
			fsmQuaternion.value.z = z;
			fsmQuaternion.value.w = w;
		}

		[Token(Token = "0x6000EE2")]
		[Address(RVA = "0xB1C330", Offset = "0xB1C330", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public QuaternionLookRotation()
		{
		}
	}
}
