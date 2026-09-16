using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755690", Offset = "0x755690")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755690", Offset = "0x755690")]
	[Token(Token = "0x20001C6")]
	public class DeviceShakeEvent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEB0C", Offset = "0x7AEB0C")]
		[Token(Token = "0x400139B")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat shakeThreshold;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AEB58", Offset = "0x7AEB58")]
		[Token(Token = "0x400139C")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sendEvent;

		[Token(Token = "0x600097C")]
		[Address(RVA = "0xB7058C", Offset = "0xB7058C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(3f);\n\tthis.shakeThreshold = v12;\n\tthis.sendEvent = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 3f;
			shakeThreshold = fsmFloat;
			sendEvent = null;
		}

		[Token(Token = "0x600097D")]
		[Address(RVA = "0xB705B8", Offset = "0xB705B8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Input::get_acceleration();\n\tv23 = 0x158AB88(&v15 @ V0_v1 (UnityEngine.Vector3), 0, v24, v25, v26, v27, v28, v29, v15, v15.y, v15.z, v30, v31, v32, v33, v34);\n\tv39 = HutongGames.PlayMaker.FsmFloat::get_Value(this.shakeThreshold);\n\tv80 = HutongGames.PlayMaker.FsmFloat::get_Value(this.shakeThreshold);\n\tv75 = v39 * v80;\n\tv42 = v15 <= v75;\n\tif (v42) goto L_0038;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_0038:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			Vector3 acceleration = Input.acceleration;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158AB88 (inside UnityEngine.Vector3::Angle +0x184)");
			float value = shakeThreshold.Value;
			float value2 = shakeThreshold.Value;
			float num = value * value2;
			if (acceleration.x > num)
			{
				Fsm.Event(sendEvent);
			}
		}

		[Token(Token = "0x600097E")]
		[Address(RVA = "0xB7064C", Offset = "0xB7064C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DeviceShakeEvent()
		{
		}
	}
}
