using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753D74", Offset = "0x753D74")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753D74", Offset = "0x753D74")]
	[Token(Token = "0x200017D")]
	public class ArrayShuffle : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA200", Offset = "0x7AA200")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA200", Offset = "0x7AA200")]
		[Token(Token = "0x4001275")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray array;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA260", Offset = "0x7AA260")]
		[Token(Token = "0x4001276")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt startIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA298", Offset = "0x7AA298")]
		[Token(Token = "0x4001277")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt shufflingRange;

		[Token(Token = "0x6000843")]
		[Address(RVA = "0xA89E6C", Offset = "0xA89E6C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDE628]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20221B8]) = v42;\nL_0015:\n\tthis.array = 0;\n\tv46 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.startIndex = v46;\n\tv52 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.shufflingRange = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			array = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			startIndex = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = true;
			shufflingRange = fsmInt2;
		}

		[Token(Token = "0x6000844")]
		[Address(RVA = "0xA89F0C", Offset = "0xA89F0C", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EEE600]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20221B9]) = v50;\nL_001D:\n\tv54 = HutongGames.PlayMaker.FsmArray::get_Values(this.array);\n\tv128 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v128, v54);\n\tv343 = *([v128 @ X0_v10+18]) - 1;\n\tv229 = HutongGames.PlayMaker.FsmInt::get_Value(this.startIndex);\n\tv60 = v229 < 1;\n\tif (v60) goto L_FFFFFFFF;\n\tv234 = HutongGames.PlayMaker.FsmInt::get_Value(this.startIndex);\n\tgoto L_0055;\n\tv251 = *([v243 @ X8_v26+E0]);\n\tv252 = v251 == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_0055;\n\tv259 = v243;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v259, v233, v97, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0055:\n\tv240 = UnityEngine.Mathf::Min(v234, v343);\n\tgoto L_005D;\nL_005D:\n\tv250 = HutongGames.PlayMaker.FsmInt::get_Value(this.shufflingRange);\n\tv61 = v250 < 1;\n\tif (v61) goto L_008E;\n\tv289 = HutongGames.PlayMaker.FsmInt::get_Value(this.shufflingRange);\n\tgoto L_007E;\n\tv352 = *([v275 @ X8_v23+E0]);\n\tv353 = v352 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_007E;\n\tv371 = v275;\n\tv356 = \"il2cpp_codegen_runtime_class_init\"(v371, v288, v98, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_007E:\n\tv357 = *([v128 @ X0_v10+18]) - 1;\n\tv269 = v289 + v101;\n\tv271 = UnityEngine.Mathf::Min(v357, v269);\nL_008E:\n\tv287 = v343 <= v101;\n\tif (v287) goto L_00DB;\nL_0094:\n\tv348 = v343 + 1;\n\tv351 = UnityEngine.Random::Range(v101, v348);\n\tv374 = *([v128 @ X0_v10+18]);\n\tv359 = *([v128 @ X0_v10+18]) < v343;\n\tv360 = ~v359;\n\tv361 = *([v128 @ X0_v10+18]) - v343;\n\tv363 = v361 == 0;\n\tv368 = ~v363;\n\tv369 = v360 & v368;\n\tif (v369) goto L_00A9;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv374 = *([v128 @ X0_v10+18]);\nL_00A9:\n\tv300 = *([v128 @ X0_v10+10]);\n\tv377 = v374 < v351;\n\tv378 = ~v377;\n\tv379 = v374 - v351;\n\tv381 = v379 == 0;\n\tv386 = v343 << 3;\n\tv294 = *([v128 @ X0_v10+10]) + v386;\n\tv387 = ~v381;\n\tv388 = v378 & v387;\n\tif (v388) goto L_00BC;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv300 = *([v128 @ X0_v10+10]);\nL_00BC:\n\tv295 = v351 << 3;\n\tv317 = v300 + v295;\n\tSystem.Collections.Generic.List`1<System.Object>::set_Item(v128, v343, *([v317 @ X8_v19+20]));\n\tSystem.Collections.Generic.List`1<System.Object>::set_Item(v128, v351, *([v294 @ X10_v4+20]));\n\tv343 = v343 - 1;\n\tv301 = v343 > v101;\n\tif (v301) goto L_0094;\nL_00DB:\n\tv177 = System.Collections.Generic.List`1<System.Object>::ToArray(v128);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.array, v177);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 168 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001d: Expected I4, but got O
			//IL_01c1: Expected O, but got I
			//IL_0219: Expected O, but got I
			//IL_02f5: Expected O, but got I
			//IL_030e: Expected O, but got I
			//IL_0327: Expected O, but got I
			object[] values = array.Values;
			object obj = new List<object>((int)values);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+18]");
			int num = (int)(-1);
			int value = startIndex.Value;
			int num3;
			if (value >= 1)
			{
				int value2 = startIndex.Value;
				int num2 = Mathf.Min(value2, num);
				num3 = num2;
			}
			else
			{
				num3 = 0;
			}
			int value3 = shufflingRange.Value;
			if (value3 >= 1)
			{
				int value4 = shufflingRange.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+18]");
				int a = (int)(-1);
				int b = value4 + num3;
				int num4 = Mathf.Min(a, b);
				num = num4;
			}
			if (num > num3)
			{
				do
				{
					int max = num + 1;
					int num5 = UnityEngine.Random.Range(num3, max);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+18]");
					int num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+18]");
					bool flag = 0L < (long)num;
					bool flag2 = !flag;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+18]");
					int num7 = (int)(-num);
					bool flag3 = num7 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+10]");
					object obj2 = 0;
					bool flag5 = num6 < num5;
					bool flag6 = !flag5;
					int num8 = num6 - num5;
					bool flag7 = num8 == 0;
					int num9 = num << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X0_v10+10]");
					object obj3 = 0L + (long)num9;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num10 = num5 << 3;
					object obj4 = (long)(IntPtr)obj2 + (long)num10;
					int index = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v19+20]");
					((List<object>)obj).set_Item(index, (object)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X10_v4+20]");
					((List<object>)obj).set_Item(num5, (object)0);
					num--;
				}
				while (num > num3);
			}
			object[] values2 = ((List<object>)obj).ToArray();
			array.Values = values2;
			Finish();
		}

		[Token(Token = "0x6000845")]
		[Address(RVA = "0xA8A160", Offset = "0xA8A160", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ArrayShuffle()
		{
		}
	}
}
