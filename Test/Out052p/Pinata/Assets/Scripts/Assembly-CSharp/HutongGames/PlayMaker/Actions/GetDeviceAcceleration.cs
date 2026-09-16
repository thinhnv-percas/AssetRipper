using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755730", Offset = "0x755730")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755730", Offset = "0x755730")]
	[Token(Token = "0x20001C8")]
	public class GetDeviceAcceleration : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEBA4", Offset = "0x7AEBA4")]
		[Token(Token = "0x400139D")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 storeVector;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEBB8", Offset = "0x7AEBB8")]
		[Token(Token = "0x400139E")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeX;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEBCC", Offset = "0x7AEBCC")]
		[Token(Token = "0x400139F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeY;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEBE0", Offset = "0x7AEBE0")]
		[Token(Token = "0x40013A0")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeZ;

		[Token(Token = "0x40013A1")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat multiplier;

		[Token(Token = "0x40013A2")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000982")]
		[Address(RVA = "0xA2A86C", Offset = "0xA2A86C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeVector = 0;\n\tthis.storeY = 0;\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.multiplier = v13;\n\tthis.everyFrame = 0;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeVector = null;
			storeY = null;
			FsmFloat fsmFloat = 1f;
			multiplier = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000983")]
		[Address(RVA = "0xA2A8A4", Offset = "0xA2A8A4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDeviceAcceleration::DoGetDeviceAcceleration(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetDeviceAcceleration();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000984")]
		[Address(RVA = "0xA2AA54", Offset = "0xA2AA54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDeviceAcceleration::DoGetDeviceAcceleration(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetDeviceAcceleration();
		}

		[Token(Token = "0x6000985")]
		[Address(RVA = "0xA2A8E0", Offset = "0xA2A8E0", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC6090]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021DAC]) = v48;\nL_001B:\n\tv52 = UnityEngine.Input::get_acceleration();\n\tv57 = UnityEngine.Input::get_acceleration();\n\tv62 = UnityEngine.Input::get_acceleration();\n\tv70 = 0x1586898(&v128 @ stack_-60_v6 (UnityEngine.Vector3), 0, v32, v33, v34, v35, v36, v37, v52, v57.y, v62.z, v41, v42, v43, v44, v45);\n\tv74 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.multiplier);\n\tv126 = v74 == 0;\n\tif (v126) goto L_0041;\n\tv123 = &v128 @ stack_-60_v6 (UnityEngine.Vector3) | 4;\n\tv99 = &v128 @ stack_-60_v6 (UnityEngine.Vector3) + 8;\n\tgoto L_005D;\nL_0041:\n\tv123 = &v128 @ stack_-60_v6 (UnityEngine.Vector3) | 4;\n\tv99 = &v128 @ stack_-60_v6 (UnityEngine.Vector3) + 8;\n\tv193 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplier);\n\tgoto L_0056;\n\tv205 = *([v201 @ X0_v15+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_0056;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v201, v177, v32, v33, v34, v35, v36, v37, v193, v68, v64, v41, v42, v43, v44, v45);\nL_0056:\n\t// 86 MakeStruct v172 @ AGGA2A9E0_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v128 @ stack_-60_v6 (UnityEngine.Vector3), v88 @ stack_-5C, 0\n\tv180 = UnityEngine.Vector3::op_Multiply(v172, v193);\nL_005D:\n\tv190 = this.storeVector;\n\tv190.value = v180;\n\tv190.value.y = v123.m_value;\n\tv190.value.z = *([v99 @ X21_v2]);\n\tv134 = this.storeX;\n\tv134.value = v180;\n\tv138 = this.storeY;\n\tv138.value = v123.m_value;\n\tv136 = this.storeZ;\n\tv136.value = *([v99 @ X21_v2]);\n\treturn;\n\tv115 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoGetDeviceAcceleration()
		{
			//IL_0081: Expected O, but got I
			//IL_00b4: Expected F4, but got O
			//IL_005e: Expected O, but got I
			//IL_00fc: Expected F4, but got I4
			//IL_010e: Expected F4, but got O
			//IL_0150: Expected F4, but got I4
			//IL_016c: Expected F4, but got O
			Vector3 acceleration = Input.acceleration;
			Vector3 acceleration2 = Input.acceleration;
			Vector3 acceleration3 = Input.acceleration;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			int num;
			Vector3 vector = default(Vector3);
			object obj;
			Vector3 value2 = default(Vector3);
			if (multiplier.IsNone)
			{
				num = (int)((long)(IntPtr)vector | 4L);
				obj = (long)(IntPtr)vector + 8L;
			}
			else
			{
				num = (int)((long)(IntPtr)vector | 4L);
				obj = (long)(IntPtr)vector + 8L;
				float value = multiplier.Value;
				Vector3 vector2 = default(Vector3);
				vector2.x = vector.x;
				object obj2 = default(object);
				vector2.y = (float)obj2;
				vector2.z = 0f;
				value2 = vector2 * value;
			}
			FsmVector3 fsmVector = storeVector;
			fsmVector.value = value2;
			fsmVector.value.y = ((int*)num)->m_value;
			fsmVector.value.z = (float)obj;
			FsmFloat fsmFloat = storeX;
			fsmFloat.Value = value2.x;
			FsmFloat fsmFloat2 = storeY;
			fsmFloat2.Value = ((int*)num)->m_value;
			FsmFloat fsmFloat3 = storeZ;
			fsmFloat3.Value = (float)obj;
		}

		[Token(Token = "0x6000986")]
		[Address(RVA = "0xA2AA58", Offset = "0xA2AA58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetDeviceAcceleration()
		{
		}
	}
}
