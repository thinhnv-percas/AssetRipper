using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace GBG.Pinata.ECS
{
	[Token(Token = "0x2000036")]
	public abstract class UnitySerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x0")]
		private List<TKey> keyData;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x0")]
		private List<TValue> valueData;

		[Token(Token = "0x6000063")]
		[Address(RVA = "0xD94C80", Offset = "0xD94C80", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = System.Collections.Generic.Dictionary`2<TKey, TValue>::Clear(this);\n\tv147 = this.keyData;\nL_001A:\n\tv152 = System.Collections.Generic.List`1<TKey>::get_Count(v147);\n\tv52 = v87 >= v152;\n\tif (v52) goto L_0063;\n\tv170 = System.Collections.Generic.List`1<TValue>::get_Count(this.valueData);\n\tv53 = v87 >= v170;\n\tif (v53) goto L_0063;\n\tv128 = System.Collections.Generic.List`1<TKey>::get_Item(this.keyData, v87);\n\tv212 = System.Collections.Generic.List`1<TValue>::get_Item(this.valueData, v87);\n\tv216 = System.Collections.Generic.Dictionary`2<TKey, TValue>::set_Item(this, v128, v212);\n\tv147 = this.keyData;\n\tv87 = v87 + 1;\n\tv217 = this.keyData == 0;\n\tv133 = ~v217;\n\tif (v133) goto L_001A;\n\tthrow System.NullReferenceException;\nL_0063:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			Clear();
			List<TKey> list = keyData;
			int num = 0;
			while (true)
			{
				int num2 = list.Count;
				if (num < num2)
				{
					int num3 = valueData.Count;
					if (num < num3)
					{
						TKey key = keyData.get_Item(num);
						TValue value = valueData.get_Item(num);
						base.set_Item(key, value);
						list = keyData;
						num++;
						if (keyData == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					break;
				}
				break;
			}
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0xD94D90", Offset = "0xD94D90", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EDFA78]);\n\tv25 = *([v24 @ X8_v38]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20240C4]) = v43;\nL_001B:\n\tv49 = this.keyData == 0;\n\tif (v49) goto L_0058;\n\tv54 = System.Collections.Generic.List`1<TKey>::Clear(this.keyData);\n\tv56 = this.valueData == 0;\n\tif (v56) goto L_0058;\n\tv90 = System.Collections.Generic.List`1<TValue>::Clear(this.valueData);\n\tv96 = System.Collections.Generic.Dictionary`2<TKey, TValue>::GetEnumerator(this);\nL_003B:\n\tv118 = System.Collections.Generic.List`1<TValue>::Add(&v61 @ stack_-60_v5 (TKey), Il2CppMethodInfo);\n\tv129 = v118 & 1;\n\tv130 = v129 == 0;\n\tif (v130) goto L_FFFFFFFF;\n\tv214 = System.Collections.Generic.List`1<TKey>::Add(this.keyData, v99);\n\tv107 = System.Collections.Generic.List`1<TValue>::Add(this.valueData, v210);\n\tgoto L_003B;\n\tgoto L_006E;\n\tv216 = new System.NullReferenceException();\n\tv78 = new System.NullReferenceException();\nL_0058:\n\tv85 = new System.NullReferenceException();\n\tgoto L_0066;\n\tgoto L_0066;\n\tgoto L_0066;\n\tgoto L_0066;\nL_0066:\n\tv128 = v187 != 1;\n\tif (v128) goto L_00CA;\n\tv131 = System.Collections.Generic.List`1<TValue>::Add(v85, v187);\n\tv194 = *([v131 @ X0_v19 (System.Collections.Generic.List`1<TValue>)]);\n\tv207 = System.Collections.Generic.List`1<TValue>::Add(v131, v187);\nL_006E:\n\tv196 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>;\n\tgoto L_007A;\n\tv301 = v196;\n\tv302 = System.Collections.Generic.List`1<TValue>::Add(v301, v243, v235);\nL_007A:\n\tv186 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>;\n\tv313 = *([v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+126]) == 0;\n\tif (v313) goto L_00A4;\n\tv345 = *([v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+B0]) + 8;\nL_008F:\n\tv360 = *([v345 @ X10_v5-8]) == System.IDisposable;\n\tif (v360) goto L_00A7;\n\tv355 = v355 + 1;\n\tv365 = v355 < *([v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+126]);\n\tv338 = ~v365;\n\tv345 = v345 + 0x10;\n\tv322 = ~v338;\n\tif (v322) goto L_008F;\nL_00A4:\n\tv375 = System.Collections.Generic.List`1<TValue>::Add(&v186 @ stack_-98_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>), System.IDisposable);\n\tgoto L_00AD;\nL_00A7:\n\tv367 = *([v345 @ X10_v5]) << 4;\n\tv368 = Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>> + v367;\n\tv375 = v368 + 0x130;\nL_00AD:\n\t*([v375 @ X0_v5])(v286, &v186 @ stack_-98_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>), *([v375 @ X0_v5+8]), v275, v28, v29, v30, v31, v32, v236, 0, v35, v36, v37, v38, v39, v40);\n\tv379 = v200 + 1;\n\tv164 = v379 == 0;\n\tv154 = ~v164;\n\tif (v154) goto L_00C5;\n\tv380 = v194 == 0;\n\tv192 = ~v380;\n\tif (v192) goto L_00C9;\nL_00C5:\n\treturn;\nL_00C9:\n\tv190 = new System.TypeLoadException();\nL_00CA:\n\tv201 = System.Collections.Generic.List`1<TValue>::Add(v189, v187);\n\treturn;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			//IL_0263: Expected O, but got I
			//IL_00ed: Expected O, but got I
			//IL_00f5: Expected I, but got O
			//IL_0102: Expected O, but got I
			//IL_02a6: Expected O, but got I
			//IL_009c: Expected I, but got O
			//IL_01d6: Expected O, but got I
			//IL_01db: Expected I, but got O
			//IL_015e: Expected O, but got I
			//IL_01ee: Expected I4, but got O
			//IL_01f9: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_0244: Expected I, but got O
			//IL_0249: Expected I, but got O
			//IL_01aa: Expected O, but got I
			bool flag = keyData == null;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			TKey val = (TKey)null;
			TKey val2 = (TKey)null;
			IntPtr intPtr3 = (IntPtr)0;
			IntPtr intPtr6;
			int num;
			if (!flag)
			{
				keyData.Clear();
				bool flag2 = valueData == null;
				IntPtr intPtr4 = default(IntPtr);
				intPtr = intPtr4;
				TKey val3 = default(TKey);
				val = val3;
				IntPtr intPtr5 = default(IntPtr);
				intPtr3 = intPtr5;
				if (!flag2)
				{
					valueData.Clear();
					Enumerator enumerator = GetEnumerator();
					object obj = default(object);
					TValue item = default(TValue);
					while (true)
					{
						((List<TValue>)val2).Add((TValue)0);
						if ((int)((long)(IntPtr)obj & 1L) == 0)
						{
							break;
						}
						keyData.Add(val3);
						valueData.Add(item);
						intPtr2 = (IntPtr)0;
					}
					val = val3;
					intPtr6 = (IntPtr)null;
					num = 0;
					goto IL_02d2;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag3 = intPtr3 != (IntPtr)1;
			List<TValue> list = (List<TValue>)(object)ex;
			if (flag3)
			{
				goto IL_0256;
			}
			((List<TValue>)(object)ex).Add((TValue)(long)intPtr3);
			List<TValue> list2 = default(List<TValue>);
			intPtr6 = (IntPtr)list2;
			list2.Add((TValue)(long)intPtr3);
			intPtr2 = intPtr;
			num = -1;
			goto IL_02d2;
			IL_01c3:
			IntPtr intPtr7;
			((List<TValue>)(long)intPtr7).Add((TValue)typeof(IDisposable));
			intPtr2 = (IntPtr)null;
			goto IL_0307;
			IL_0256:
			list.Add((TValue)(long)intPtr3);
			return;
			IL_0307:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v375 @ X0_v5] (should have been resolved before IL gen)");
			if (num + 1 != 0 || intPtr6 == (IntPtr)0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			intPtr = (IntPtr)null;
			intPtr3 = (IntPtr)null;
			list = (List<TValue>)(object)ex2;
			goto IL_0256;
			IL_02d2:
			IntPtr intPtr8 = (IntPtr)0;
			intPtr7 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01c3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+B0]");
			object obj2 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ X10_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>+Enumerator<TKey, TValue>>)+126]");
				bool flag4 = (long)num3 < 0L;
				bool flag5 = !flag4;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_01c3;
			}
			int num4 = obj2 << 4;
			object obj3 = 0L + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0307;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0xD94FC8", Offset = "0xD94FC8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv23 = v18;\n\tv24 = 0x8907BC(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0014:\n\tv41 = new Il2CppClass<System.Collections.Generic.List`1<TKey>>();\n\tv47 = System.Collections.Generic.List`1<TKey>::.ctor(v41);\n\tthis.keyData = v41;\n\tgoto L_0027;\n\tv55 = v50;\n\tv56 = System.Collections.Generic.List`1<TKey>::.ctor(v55, v45);\nL_0027:\n\tv59 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tv65 = System.Collections.Generic.List`1<TValue>::.ctor(v59);\n\tthis.valueData = v59;\n\tv73 = Il2CppMethodInfo;\n\tv74 = *([v73 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 58 IndirectJump v74 @ X2_v1, this @ X0 (GBG.Pinata.ECS.UnitySerializedDictionary`2<TKey, TValue>), this @ X0 (GBG.Pinata.ECS.UnitySerializedDictionary`2<TKey, TValue>), methodof(System.Collections.Generic.Dictionary`2<TKey, TValue>::.ctor), v74 @ X2_v1, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal UnitySerializedDictionary()
		{
			//IL_0040: Expected O, but got I
			List<TKey> list = new List<TKey>();
			keyData = list;
			List<TValue> list2 = new List<TValue>();
			valueData = list2;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X2_v1 (should have been resolved before IL gen)");
		}
	}
}
