using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BC20", Offset = "0x75BC20")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BC20", Offset = "0x75BC20")]
	[Token(Token = "0x20002FE")]
	public class SetRectFields : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C23F0", Offset = "0x7C23F0")]
		[Token(Token = "0x4001935")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect rectVariable;

		[Token(Token = "0x4001936")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat x;

		[Token(Token = "0x4001937")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat y;

		[Token(Token = "0x4001938")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat width;

		[Token(Token = "0x4001939")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat height;

		[Token(Token = "0x400193A")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000F09")]
		[Address(RVA = "0x998F1C", Offset = "0x998F1C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAE328]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202178E]) = v42;\nL_0015:\n\tthis.rectVariable = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.x = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.y = v52;\n\tv60 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v60);\n\tv60.useVariable = 1;\n\tthis.width = v60;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.height = v61;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			rectVariable = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			width = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			height = fsmFloat4;
			everyFrame = false;
		}

		[Token(Token = "0x6000F0A")]
		[Address(RVA = "0x999004", Offset = "0x999004", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetRectFields::DoSetRectFields(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetRectFields();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F0B")]
		[Address(RVA = "0x999178", Offset = "0x999178", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetRectFields::DoSetRectFields(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetRectFields();
		}

		[Token(Token = "0x6000F0C")]
		[Address(RVA = "0x999040", Offset = "0x999040", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectVariable);\n\tv72 = v15 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0067;\n\tv24 = this.rectVariable;\n\tv119 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv121 = v119 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_002B;\n\tv123 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\n\tv127 = 0x10CCFBC(&v54 @ stack_-30_v6 (UnityEngine.Rect), 0, v58, v59, v60, v61, v62, v63, v123, v64, v65, v66, v67, v68, v69, v70);\nL_002B:\n\tv130 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv133 = v130 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_003C;\n\tv135 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\n\tv139 = 0x10CCFCC(&v54 @ stack_-30_v6 (UnityEngine.Rect), 0, v58, v59, v60, v61, v62, v63, v135, v64, v65, v66, v67, v68, v69, v70);\nL_003C:\n\tv142 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.width);\n\tv145 = v142 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_004D;\n\tv147 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv151 = 0x10CD180(&v54 @ stack_-30_v6 (UnityEngine.Rect), 0, v58, v59, v60, v61, v62, v63, v147, v64, v65, v66, v67, v68, v69, v70);\nL_004D:\n\tv154 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv157 = v154 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_005A;\n\tv159 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv162 = 0x10CD190(&v54 @ stack_-30_v6 (UnityEngine.Rect), 0, v58, v59, v60, v61, v62, v63, v159, v64, v65, v66, v67, v68, v69, v70);\nL_005A:\n\tv77 = this.rectVariable;\n\tv77.value.m_XMin = v24.value;\n\tv77.value.m_YMin = v165;\n\tv77.value.m_Height = v166;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetRectFields()
		{
			//IL_01f8: Expected F4, but got O
			if (!rectVariable.IsNone)
			{
				FsmRect fsmRect = rectVariable;
				bool isNone = x.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				Rect value = fsmRect.value;
				if (!flag2)
				{
					float value2 = x.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
				}
				if (!y.IsNone)
				{
					float value3 = y.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
				}
				if (!width.IsNone)
				{
					float value4 = width.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				}
				if (!height.IsNone)
				{
					float value5 = height.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
				}
				FsmRect fsmRect2 = rectVariable;
				fsmRect2.value.x = fsmRect.value.x;
				object obj = default(object);
				fsmRect2.value.y = (float)obj;
				float num = default(float);
				fsmRect2.value.height = num;
			}
		}

		[Token(Token = "0x6000F0D")]
		[Address(RVA = "0x99917C", Offset = "0x99917C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetRectFields()
		{
		}
	}
}
