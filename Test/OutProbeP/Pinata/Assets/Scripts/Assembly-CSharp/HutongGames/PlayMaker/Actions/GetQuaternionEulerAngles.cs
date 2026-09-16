using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B720", Offset = "0x75B720")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B720", Offset = "0x75B720")]
	[Token(Token = "0x20002ED")]
	public class GetQuaternionEulerAngles : QuaternionBaseAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C12DC", Offset = "0x7C12DC")]
		[Token(Token = "0x40018F6")]
		[FieldOffset(Offset = "0x50")]
		public FsmQuaternion quaternion;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1328", Offset = "0x7C1328")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C1328", Offset = "0x7C1328")]
		[Token(Token = "0x40018F7")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 eulerAngles;

		[Token(Token = "0x6000E9B")]
		[Address(RVA = "0xA329EC", Offset = "0xA329EC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.quaternion = 0;\n\tthis.eulerAngles = 0;\n\tthis.everyFrame = 1;\n\tthis.everyFrameOption = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			quaternion = null;
			eulerAngles = null;
			everyFrame = true;
			everyFrameOption = default(everyFrameOptions);
		}

		[Token(Token = "0x6000E9C")]
		[Address(RVA = "0xA32A00", Offset = "0xA32A00", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetQuaternionEulerAngles::GetQuatEuler(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GetQuatEuler();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E9D")]
		[Address(RVA = "0xA32A94", Offset = "0xA32A94", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.everyFrameOption == 0;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tHutongGames.PlayMaker.Actions.GetQuaternionEulerAngles::GetQuatEuler(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (everyFrameOption == everyFrameOptions.Update)
			{
				GetQuatEuler();
			}
		}

		[Token(Token = "0x6000E9E")]
		[Address(RVA = "0xA32AA4", Offset = "0xA32AA4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 2;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionEulerAngles::GetQuatEuler(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLateUpdate()
		{
			if (everyFrameOption == everyFrameOptions.LateUpdate)
			{
				GetQuatEuler();
			}
		}

		[Token(Token = "0x6000E9F")]
		[Address(RVA = "0xA32AB8", Offset = "0xA32AB8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.everyFrameOption != 1;\n\tif (v11) goto L_000E;\n\tHutongGames.PlayMaker.Actions.GetQuaternionEulerAngles::GetQuatEuler(this);\n\treturn;\nL_000E:\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnFixedUpdate()
		{
			if (everyFrameOption == everyFrameOptions.FixedUpdate)
			{
				GetQuatEuler();
			}
		}

		[Token(Token = "0x6000EA0")]
		[Address(RVA = "0xA32A3C", Offset = "0xA32A3C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.quaternion;\n\tv13 = v10.value;\n\tv14 = this.eulerAngles;\n\tv18 = 0x10CC508(&v13 @ V0_v2 (UnityEngine.Quaternion), 0, v19, v20, v21, v22, v23, v24, v10.value, v25, v26, v27, v28, v29, v30, v31);\n\tv14.value = v10.value;\n\tv14.value.y = v25;\n\tv14.value.z = v26;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetQuatEuler()
		{
			FsmQuaternion fsmQuaternion = quaternion;
			Quaternion value = fsmQuaternion.value;
			FsmVector3 fsmVector = eulerAngles;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			fsmVector.value = (Vector3)fsmQuaternion.value;
			float y = default(float);
			fsmVector.value.y = y;
			float z = default(float);
			fsmVector.value.z = z;
		}

		[Token(Token = "0x6000EA1")]
		[Address(RVA = "0xA32ACC", Offset = "0xA32ACC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.QuaternionBaseAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetQuaternionEulerAngles()
		{
		}
	}
}
