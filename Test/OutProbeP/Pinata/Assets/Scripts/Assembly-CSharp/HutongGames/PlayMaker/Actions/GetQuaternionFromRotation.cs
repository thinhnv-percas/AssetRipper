using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B770", Offset = "0x75B770")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B770", Offset = "0x75B770")]
	[Token(Token = "0x20002EE")]
	public class GetQuaternionFromRotation : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1388", Offset = "0x7C1388")]
		[Token(Token = "0x40018F8")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 fromDirection;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C13D4", Offset = "0x7C13D4")]
		[Token(Token = "0x40018F9")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 toDirection;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1420", Offset = "0x7C1420")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1420", Offset = "0x7C1420")]
		[Token(Token = "0x40018FA")]
		[FieldOffset(Offset = "0x60")]
		public FsmQuaternion result;

		[Token(Token = "0x6000EA2")]
		[Address(RVA = "0xA32AD4", Offset = "0xA32AD4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionFromRotation)+5C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionFromRotation)+64]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetQuaternionFromRotation)+54]) = 0;\n\tthis.everyFrameOption = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			_ = 0;
			_ = 0;
			_ = 0;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000EA3")]
		[Address(RVA = "0xA32AEC", Offset = "0xA32AEC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetQuaternionFromRotation::DoQuatFromRotation(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoQuatFromRotation();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EA4")]
		[Address(RVA = "0xA32C14", Offset = "0xA32C14", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetQuaternionFromRotation::DoQuatFromRotation(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				DoQuatFromRotation();
			}
		}

		[Token(Token = "0x6000EA5")]
		[Address(RVA = "0xA32C24", Offset = "0xA32C24", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionFromRotation::DoQuatFromRotation(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				DoQuatFromRotation();
			}
		}

		[Token(Token = "0x6000EA6")]
		[Address(RVA = "0xA32C38", Offset = "0xA32C38", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionFromRotation::DoQuatFromRotation(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				DoQuatFromRotation();
			}
		}

		[Token(Token = "0x6000EA7")]
		[Address(RVA = "0xA32B28", Offset = "0xA32B28", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F02358]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021DFD]) = v50;\nL_001C:\n\tv53 = this.result;\n\tv55 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromDirection);\n\tv112 = HutongGames.PlayMaker.FsmVector3::get_Value(this.toDirection);\n\tgoto L_0043;\n\tv153 = *([v117 @ X0_v9+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_0043;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v117, v102, v34, v35, v36, v37, v38, v39, v112, v113, v114, v43, v44, v45, v46, v47);\nL_0043:\n\tv100 = UnityEngine.Quaternion::FromToRotation(v55, v112);\n\tv53.value = v100;\n\tv53.value.y = v100.y;\n\tv53.value.z = v100.z;\n\tv53.value.w = v100.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoQuatFromRotation()
		{
			FsmQuaternion fsmQuaternion = result;
			Vector3 value = fromDirection.Value;
			Vector3 value2 = toDirection.Value;
			Quaternion quaternion = (fsmQuaternion.value = Quaternion.FromToRotation(value, value2));
			fsmQuaternion.value.y = quaternion.y;
			fsmQuaternion.value.z = quaternion.z;
			fsmQuaternion.value.w = quaternion.w;
		}

		[Token(Token = "0x6000EA8")]
		[Address(RVA = "0xA32C4C", Offset = "0xA32C4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionBaseAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetQuaternionFromRotation()
		{
		}
	}
}
