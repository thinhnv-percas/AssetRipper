using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BB30", Offset = "0x75BB30")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BB30", Offset = "0x75BB30")]
	[Token(Token = "0x20002FB")]
	public class GetRectFields : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C1FE8", Offset = "0x7C1FE8")]
		[Token(Token = "0x4001921")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect rectVariable;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C2024", Offset = "0x7C2024")]
		[Token(Token = "0x4001922")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat storeX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C2038", Offset = "0x7C2038")]
		[Token(Token = "0x4001923")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat storeY;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C204C", Offset = "0x7C204C")]
		[Token(Token = "0x4001924")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeWidth;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C2060", Offset = "0x7C2060")]
		[Token(Token = "0x4001925")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeHeight;

		[Token(Token = "0x4001926")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000EF8")]
		[Address(RVA = "0xA33B2C", Offset = "0xA33B2C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeHeight = 0;\n\tthis.rectVariable = 0;\n\tthis.storeY = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeHeight = null;
			rectVariable = null;
			storeY = null;
		}

		[Token(Token = "0x6000EF9")]
		[Address(RVA = "0xA33B40", Offset = "0xA33B40", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRectFields::DoGetRectFields(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetRectFields();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EFA")]
		[Address(RVA = "0xA33C64", Offset = "0xA33C64", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRectFields::DoGetRectFields(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetRectFields();
		}

		[Token(Token = "0x6000EFB")]
		[Address(RVA = "0xA33B7C", Offset = "0xA33B7C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv52 = v17 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0047;\n\tv54 = this.rectVariable;\n\tv86 = v54.value;\n\tv87 = this.storeX;\n\tv91 = 0x10CCFB4(&v86 @ V0_v4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, v54.value, v44, v45, v46, v47, v48, v49, v50);\n\tv87.value = v54.value;\n\tv95 = this.rectVariable;\n\tv86 = v95.value;\n\tv92 = this.storeY;\n\tv106 = 0x10CCFC4(&v86 @ V0_v4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, v95.value, v44, v45, v46, v47, v48, v49, v50);\n\tv92.value = v95.value;\n\tv96 = this.rectVariable;\n\tv86 = v96.value;\n\tv57 = this.storeWidth;\n\tv107 = 0x10CD178(&v86 @ V0_v4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, v96.value, v44, v45, v46, v47, v48, v49, v50);\n\tv57.value = v96.value;\n\tv61 = this.rectVariable;\n\tv86 = v61.value;\n\tv71 = this.storeHeight;\n\tv67 = 0x10CD188(&v86 @ V0_v4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, v61.value, v44, v45, v46, v47, v48, v49, v50);\n\tv71.value = v61.value;\nL_0047:\n\treturn;\n\tv32 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetRectFields()
		{
			if (!rectVariable.IsNone)
			{
				FsmRect fsmRect = rectVariable;
				Rect value = fsmRect.value;
				FsmFloat fsmFloat = storeX;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				fsmFloat.Value = fsmRect.value.x;
				FsmRect fsmRect2 = rectVariable;
				value = fsmRect2.value;
				FsmFloat fsmFloat2 = storeY;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				fsmFloat2.Value = fsmRect2.value.x;
				FsmRect fsmRect3 = rectVariable;
				value = fsmRect3.value;
				FsmFloat fsmFloat3 = storeWidth;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				fsmFloat3.Value = fsmRect3.value.x;
				FsmRect fsmRect4 = rectVariable;
				value = fsmRect4.value;
				FsmFloat fsmFloat4 = storeHeight;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				fsmFloat4.Value = fsmRect4.value.x;
			}
		}

		[Token(Token = "0x6000EFC")]
		[Address(RVA = "0xA33C68", Offset = "0xA33C68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRectFields()
		{
		}
	}
}
