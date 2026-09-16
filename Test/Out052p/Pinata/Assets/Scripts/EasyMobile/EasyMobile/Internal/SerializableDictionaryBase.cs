using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000BB")]
	public abstract class SerializableDictionaryBase<T, U, V> : Dictionary<T, U>, ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x40003A4")]
		[FieldOffset(Offset = "0x0")]
		protected T[] keys;

		[SerializeField]
		[Token(Token = "0x40003A5")]
		[FieldOffset(Offset = "0x0")]
		protected V[] values;

		[Token(Token = "0x60006F2")]
		[Address(RVA = "0xD8E878", Offset = "0xD8E878", Length = "0x360")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EC4EE8]);\n\tv29 = *([v28 @ X8_v45]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, dict, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240B0]) = v46;\nL_0018:\n\tv47 = dict == 0;\n\tif (v47) goto L_010D;\n\tgoto L_0024;\n\tv138 = v50;\n\tv139 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v138, dict, methodInfo, v31);\nL_0024:\n\tv141 = dict->klass;\n\tv143 = *([v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]) == 0;\n\tif (v143) goto L_0046;\n\tv196 = *([v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]) + 8;\nL_0030:\n\tv201 = *([v196 @ X11_v34-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<T, U>>>;\n\tif (v201) goto L_0049;\n\tv195 = v195 + 1;\n\tv260 = v195 < *([v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]);\n\tv166 = ~v260;\n\tv196 = v196 + 0x10;\n\tv150 = ~v166;\n\tif (v150) goto L_0030;\nL_0046:\n\tv266 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(dict, Il2CppClass<System.Collections.Generic.ICollection`1<System.Collections.Generic.KeyValuePair`2<T, U>>>, 0);\n\tgoto L_004F;\nL_0049:\n\tv262 = *([v196 @ X11_v34]) << 4;\n\tv263 = v141 + v262;\n\tv266 = v263 + 0x130;\nL_004F:\n\t*([v266 @ X0_v20])(v125, dict, *([v266 @ X0_v20+8]), v71, v31, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv128 = this == 0;\n\tif (v128) goto L_010D;\n\tv277 = System.Collections.Generic.Dictionary`2<T, U>::.ctor(this, v125);\n\tgoto L_0063;\n\tv326 = v280;\n\tv327 = System.Collections.Generic.Dictionary`2<T, U>::.ctor(v326, v74, v275);\nL_0063:\n\tv329 = dict->klass;\n\tv331 = *([v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]) == 0;\n\tif (v331) goto L_0085;\n\tv483 = *([v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]) + 8;\nL_006F:\n\tv488 = *([v483 @ X11_v29-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<T, U>>>;\n\tif (v488) goto L_0088;\n\tv482 = v482 + 1;\n\tv515 = v482 < *([v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]);\n\tv432 = ~v515;\n\tv483 = v483 + 0x10;\n\tv416 = ~v432;\n\tif (v416) goto L_006F;\nL_0085:\n\tv536 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(dict, Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<T, U>>>, 0);\n\tgoto L_008E;\nL_0088:\n\tv517 = *([v483 @ X11_v29]) << 4;\n\tv518 = v329 + v517;\n\tv536 = v518 + 0x130;\nL_008E:\n\t*([v536 @ X0_v26])(v541, dict, *([v536 @ X0_v26+8]), v217, v31, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0098:\n\tgoto L_00BF;\n\tv580 = *([v575 @ X8_v27+B0]);\n\tv581 = 0;\n\tv582 = v580 + 8;\n\tv584 = *([v621 @ X11_v24-8]);\n\tv626 = v584 == v576;\n\tif (v626) goto L_00B8;\n\tv604 = v620 + 1;\n\tv631 = v604 < v577;\n\tv602 = ~v631;\n\tv606 = v621 + 0x10;\n\tv586 = ~v602;\n\tif (v586) goto L_FFFFFFFF;\n\tv607 = v130;\n\tv608 = 0;\n\tv609 = 0x8909C4(v607, v576, v608, v56, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00BF;\nL_00B8:\n\tv632 = *([v621 @ X11_v24]);\n\tv633 = v632 << 4;\n\tv634 = v575 + v633;\n\tv635 = v634 + 0x130;\nL_00BF:\n\tv368 = System.Collections.IEnumerator::MoveNext(v541);\n\tv640 = v368 == 0;\n\tif (v640) goto L_0106;\n\tgoto L_00CD;\n\tv648 = v574;\n\tv649 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v648, v342, v340, v56);\nL_00CD:\n\tv651 = *([v541 @ X0_v28 (System.Collections.IEnumerator)]);\n\tv572 = *([v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v572) goto L_00EF;\n\tv695 = *([v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00D4:\n\t;\n\tv700 = *([v695 @ X11_v19-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<T, U>>>;\n\tif (v700) goto L_00F1;\n\tv694 = v694 + 1;\n\tv705 = v694 < *([v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv675 = ~v705;\n\tv695 = v695 + 0x10;\n\tv659 = ~v675;\n\tif (v659) goto L_00D4;\nL_00EF:\n\tv712 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v541, Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<T, U>>>, 0);\n\tgoto L_00F8;\nL_00F1:\n\t;\n\tv707 = *([v695 @ X11_v19]) << 4;\n\tv708 = v651 + v707;\n\tv712 = v708 + 0x130;\nL_00F8:\n\t*([v712 @ X0_v36])(v717, v541, *([v712 @ X0_v36+8]), v710, v332, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv570 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(this, v717, *([v712 @ X0_v36+8]));\n\tgoto L_0098;\nL_0106:\n\tv647 = v541 == 0;\n\tv370 = ~v647;\n\tif (v370) goto L_0128;\n\tgoto L_0150;\n\tthrow System.NullReferenceException;\nL_010D:\n\tv137 = new System.NullReferenceException();\n\tgoto L_011A;\n\tgoto L_011A;\n\tgoto L_011A;\nL_011A:\n\tv184 = v219 != 1;\n\tif (v184) goto L_0167;\n\tv206 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v137, v219, v217);\n\tv374 = *([v206 @ X0_v17 (System.Collections.Generic.Dictionary`2<T, U>)]);\n\tv271 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v206, v219, v217);\n\tv286 = v373 == 0;\n\tif (v286) goto L_0150;\nL_0128:\n\tgoto L_014F;\n\tv441 = *([v380 @ X8_v6+B0]);\n\tv442 = 0;\n\tv443 = v441 + 8;\n\tv445 = *([v504 @ X11_v8-8]);\n\tv509 = v445 == v383;\n\tif (v509) goto L_0148;\n\tv465 = v503 + 1;\n\tv543 = v465 < v382;\n\tv463 = ~v543;\n\tv467 = v504 + 0x10;\n\tv447 = ~v463;\n\tif (v447) goto L_FFFFFFFF;\n\tv468 = v373;\n\tv469 = 0;\n\tv470 = 0x8909C4(v468, v383, v469, v332, v333, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_014F;\nL_0148:\n\tv544 = *([v504 @ X11_v8]);\n\tv545 = v544 << 4;\n\tv546 = v380 + v545;\n\tv547 = v546 + 0x130;\nL_014F:\n\tSystem.IDisposable::Dispose(v373);\nL_0150:\n\tv409 = v250 + 1;\n\tv232 = v409 == 0;\n\tv222 = ~v232;\n\tif (v222) goto L_0162;\n\tv471 = v254 == 0;\n\tv248 = ~v471;\n\tif (v248) goto L_0166;\nL_0162:\n\treturn;\nL_0166:\n\tv246 = new System.TypeLoadException();\nL_0167:\n\tv259 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v245, v219, v217);\n\treturn;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionaryBase(IDictionary<T, U> dict)
		{
			//IL_0467: Expected O, but got I
			//IL_0012: Expected I, but got O
			//IL_03a3: Expected O, but got I
			//IL_03ab: Expected I, but got O
			//IL_03bc: Expected O, but got I
			//IL_00be: Expected O, but got I
			//IL_00c3: Expected I, but got O
			//IL_03f2: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_00d6: Expected I4, but got O
			//IL_00e4: Expected O, but got I
			//IL_00f3: Expected O, but got I
			//IL_0117: Expected I, but got O
			//IL_0099: Expected O, but got I
			//IL_0444: Expected I, but got O
			//IL_01c3: Expected O, but got I
			//IL_01c8: Expected I, but got O
			//IL_0152: Expected O, but got I
			//IL_01db: Expected I4, but got O
			//IL_01e9: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0333: Expected I, but got O
			//IL_019e: Expected O, but got I
			//IL_0357: Expected I, but got O
			//IL_0215: Expected I, but got O
			//IL_02c3: Expected O, but got I
			//IL_05a1: Expected O, but got I
			//IL_05b7: Expected O, but got I
			//IL_0252: Expected O, but got I
			//IL_02dc: Expected I4, but got O
			//IL_02ea: Expected O, but got I
			//IL_02f9: Expected O, but got I
			//IL_029e: Expected O, but got I
			bool flag = dict == null;
			T val = default(T);
			IDictionary<T, U> dictionary = (IDictionary<T, U>)val;
			IEnumerator enumerator = default(IEnumerator);
			IDictionary<T, U> dictionary2 = (IDictionary<T, U>)enumerator;
			if (flag)
			{
				goto IL_035c;
			}
			IntPtr intPtr = (IntPtr)dict;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X11_v34-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
				bool flag2 = (long)num2 < 0L;
				bool flag3 = !flag2;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = (long)(IntPtr)(object)((long)intPtr + (long)(obj << 4)) + 304L;
			IntPtr intPtr3 = default(IntPtr);
			IntPtr intPtr2 = intPtr3;
			goto IL_04b7;
			IL_0602:
			((IDisposable)dictionary2).Dispose();
			IntPtr intPtr5 = default(IntPtr);
			IntPtr intPtr4 = intPtr5;
			int num4;
			int num3 = num4;
			IntPtr intPtr7;
			IntPtr intPtr6 = intPtr7;
			goto IL_05cc;
			IL_051d:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v536 @ X0_v26] (should have been resolved before IL gen)");
			IntPtr intPtr8 = default(IntPtr);
			T key = default(T);
			U val3;
			IntPtr intPtr10 = default(IntPtr);
			for (intPtr5 = intPtr8; enumerator.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v712 @ X0_v36] (should have been resolved before IL gen)"), Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v36+8]"), base.set_Item(key, (U)0), intPtr5 = (IntPtr)0, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v36+8]"), val3 = (U)0, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v712 @ X0_v36+8]"), intPtr10 = (IntPtr)0)
			{
				IntPtr intPtr9 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				U val2;
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj3 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v695 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v651 @ X8_v33 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag4 = (long)num6 < 0L;
						bool flag5 = !flag4;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_02b7;
					}
					int num7 = obj3 << 4;
					object obj4 = (long)intPtr9 + (long)num7;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					val2 = (U)null;
					continue;
				}
				goto IL_02b7;
				IL_02b7:
				((Dictionary<T, U>)enumerator).set_Item((T)0, (U)null);
				val2 = (U)null;
			}
			bool flag6 = enumerator == null;
			bool flag7 = !flag6;
			num4 = 0;
			dictionary2 = (IDictionary<T, U>)enumerator;
			intPtr7 = (IntPtr)null;
			if (!flag7)
			{
				intPtr4 = intPtr5;
				num3 = 0;
				intPtr6 = (IntPtr)null;
				goto IL_05cc;
			}
			goto IL_0602;
			IL_0456:
			Dictionary<T, U> dictionary3;
			dictionary3.set_Item((T)dictionary, (U)(long)intPtr10);
			return;
			IL_01b7:
			((Dictionary<T, U>)dict).set_Item((T)0, (U)null);
			intPtr10 = (IntPtr)null;
			goto IL_051d;
			IL_05cc:
			if (num3 + 1 != 0 || intPtr6 == (IntPtr)0)
			{
				return;
			}
			TypeLoadException ex = new TypeLoadException();
			intPtr5 = intPtr4;
			intPtr10 = (IntPtr)null;
			dictionary = null;
			dictionary3 = (Dictionary<T, U>)(object)ex;
			goto IL_0456;
			IL_00b2:
			((Dictionary<T, U>)dict).set_Item((T)0, (U)null);
			intPtr2 = (IntPtr)null;
			goto IL_04b7;
			IL_04b7:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v266 @ X0_v20] (should have been resolved before IL gen)");
			bool flag8 = this == null;
			intPtr5 = intPtr8;
			intPtr10 = intPtr3;
			dictionary = dict;
			dictionary2 = dict;
			if (flag8)
			{
				goto IL_035c;
			}
			int capacity = default(int);
			base._002Ector(capacity);
			IntPtr intPtr11 = (IntPtr)dict;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01b7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]");
			object obj6 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ X11_v29-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ X8_v23 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
				bool flag9 = (long)num9 < 0L;
				bool flag10 = !flag9;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag10)
				{
					continue;
				}
				goto IL_01b7;
			}
			int num10 = obj6 << 4;
			object obj7 = (long)intPtr11 + (long)num10;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			intPtr10 = (IntPtr)0;
			goto IL_051d;
			IL_035c:
			NullReferenceException ex2 = new NullReferenceException();
			bool flag11 = (IntPtr)dictionary != (IntPtr)1;
			dictionary3 = (Dictionary<T, U>)(object)ex2;
			if (flag11)
			{
				goto IL_0456;
			}
			((Dictionary<T, U>)(object)ex2).set_Item((T)dictionary, (U)(long)intPtr10);
			Dictionary<T, U> dictionary4 = default(Dictionary<T, U>);
			intPtr7 = (IntPtr)dictionary4;
			dictionary4.set_Item((T)dictionary, (U)(long)intPtr10);
			bool flag12 = dictionary2 == null;
			num4 = -1;
			intPtr4 = intPtr5;
			num3 = -1;
			intPtr6 = (IntPtr)dictionary4;
			if (flag12)
			{
				goto IL_05cc;
			}
			goto IL_0602;
		}

		[Token(Token = "0x60006F3")]
		[Address(RVA = "0xD8EBD8", Offset = "0xD8EBD8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>), this @ X0 (EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>), methodof(System.Collections.Generic.Dictionary`2<T, U>::.ctor), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SerializableDictionaryBase()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006F4")]
		[Address(RVA = "0xD8EBFC", Offset = "0xD8EBFC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = *([v3 @ X4+18]);\n\tv4 = *([v2 @ X8_v1+C0]);\n\tv5 = *([v4 @ X8_v2+48]);\n\tv6 = *([v5 @ X4_v1]);\n\t// 6 IndirectJump v6 @ X5_v1, this @ X0 (EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>), this @ X0 (EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>), info @ X1 (System.Runtime.Serialization.SerializationInfo), context @ X2 (System.Runtime.Serialization.StreamingContext), methodInfo @ X3 (Il2CppMethodInfo), v5 @ X4_v1, v6 @ X5_v1, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected SerializableDictionaryBase(SerializationInfo info, StreamingContext context)
		{
			//IL_0010: Expected O, but got I
			//IL_0020: Expected O, but got I
			//IL_0030: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X4+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1+C0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v2+48]");
			object obj3 = 0;
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60006F5")]
		protected abstract void SetValue(V[] storage, int i, U value);

		[Token(Token = "0x60006F6")]
		protected abstract U GetValue(V[] storage, int i);

		[Token(Token = "0x60006F7")]
		[Address(RVA = "0xD8EC20", Offset = "0xD8EC20", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ED6440]);\n\tv29 = *([v28 @ X8_v38]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, dict, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240B1]) = v46;\nL_0018:\n\tv47 = this == 0;\n\tif (v47) goto L_00D6;\n\tv53 = System.Collections.Generic.Dictionary`2<T, U>::Clear(this);\n\tv54 = dict == 0;\n\tif (v54) goto L_00D6;\n\tgoto L_002C;\n\tv126 = v121;\n\tv127 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v126, v51, methodInfo, v31);\nL_002C:\n\tv129 = dict->klass;\n\tv131 = *([v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]) == 0;\n\tif (v131) goto L_004E;\n\tv238 = *([v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]) + 8;\nL_0038:\n\tv243 = *([v238 @ X11_v28-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<T, U>>>;\n\tif (v243) goto L_0051;\n\tv237 = v237 + 1;\n\tv250 = v237 < *([v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]);\n\tv164 = ~v250;\n\tv238 = v238 + 0x10;\n\tv148 = ~v164;\n\tif (v148) goto L_0038;\nL_004E:\n\tv271 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(dict, Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<T, U>>>, 0);\n\tgoto L_0057;\nL_0051:\n\tv252 = *([v238 @ X11_v28]) << 4;\n\tv253 = v129 + v252;\n\tv271 = v253 + 0x130;\nL_0057:\n\t*([v271 @ X0_v22])(v276, dict, *([v271 @ X0_v22+8]), 0, v175, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0061:\n\tgoto L_0088;\n\tv457 = *([v421 @ X8_v21+B0]);\n\tv458 = 0;\n\tv459 = v457 + 8;\n\tv461 = *([v520 @ X11_v23-8]);\n\tv525 = v461 == v422;\n\tif (v525) goto L_0081;\n\tv481 = v519 + 1;\n\tv538 = v481 < v423;\n\tv479 = ~v538;\n\tv483 = v520 + 0x10;\n\tv463 = ~v479;\n\tif (v463) goto L_FFFFFFFF;\n\tv484 = v112;\n\tv485 = 0;\n\tv486 = 0x8909C4(v484, v422, v485, v56, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0088;\nL_0081:\n\tv539 = *([v520 @ X11_v23]);\n\tv540 = v539 << 4;\n\tv541 = v421 + v540;\n\tv542 = v541 + 0x130;\nL_0088:\n\tv379 = System.Collections.IEnumerator::MoveNext(v276);\n\tv547 = v379 == 0;\n\tif (v547) goto L_00CF;\n\tgoto L_0096;\n\tv555 = v342;\n\tv556 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v555, v377, v351, v56);\nL_0096:\n\tv558 = *([v276 @ X0_v24 (System.Collections.IEnumerator)]);\n\tv340 = *([v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v340) goto L_00B8;\n\tv602 = *([v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_009D:\n\t;\n\tv607 = *([v602 @ X11_v18-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<T, U>>>;\n\tif (v607) goto L_00BA;\n\tv601 = v601 + 1;\n\tv612 = v601 < *([v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv582 = ~v612;\n\tv602 = v602 + 0x10;\n\tv566 = ~v582;\n\tif (v566) goto L_009D;\nL_00B8:\n\tv619 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v276, Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<T, U>>>, 0);\n\tgoto L_00C1;\nL_00BA:\n\t;\n\tv614 = *([v602 @ X11_v18]) << 4;\n\tv615 = v558 + v614;\n\tv619 = v615 + 0x130;\nL_00C1:\n\t*([v619 @ X0_v32])(v624, v276, *([v619 @ X0_v32+8]), v617, v175, v58, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv338 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(this, v624, *([v619 @ X0_v32+8]));\n\tgoto L_0061;\nL_00CF:\n\tv554 = v276 == 0;\n\tv381 = ~v554;\n\tif (v381) goto L_00F1;\n\tgoto L_0119;\n\tthrow System.NullReferenceException;\nL_00D6:\n\tv118 = new System.NullReferenceException();\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tv141 = v210 != 1;\n\tif (v141) goto L_0130;\n\tv173 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v118, v210, v184);\n\tv385 = *([v173 @ X0_v17 (System.Collections.Generic.Dictionary`2<T, U>)]);\n\tv249 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v173, v210, v184);\n\tv279 = v384 == 0;\n\tif (v279) goto L_0119;\nL_00F1:\n\tgoto L_0118;\n\tv426 = *([v391 @ X8_v6+B0]);\n\tv427 = 0;\n\tv428 = v426 + 8;\n\tv430 = *([v498 @ X11_v8-8]);\n\tv503 = v430 == v394;\n\tif (v503) goto L_0111;\n\tv450 = v497 + 1;\n\tv530 = v450 < v393;\n\tv448 = ~v530;\n\tv452 = v498 + 0x10;\n\tv432 = ~v448;\n\tif (v432) goto L_FFFFFFFF;\n\tv453 = v384;\n\tv454 = 0;\n\tv455 = 0x8909C4(v453, v394, v454, v343, v344, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0118;\nL_0111:\n\tv531 = *([v498 @ X11_v8]);\n\tv532 = v531 << 4;\n\tv533 = v391 + v532;\n\tv534 = v533 + 0x130;\nL_0118:\n\tSystem.IDisposable::Dispose(v384);\nL_0119:\n\tv420 = v217 + 1;\n\tv197 = v420 == 0;\n\tv187 = ~v197;\n\tif (v187) goto L_012B;\n\tv456 = v221 == 0;\n\tv215 = ~v456;\n\tif (v215) goto L_012F;\nL_012B:\n\treturn;\nL_012F:\n\tv213 = new System.TypeLoadException();\nL_0130:\n\tv226 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(v212, v210, v184);\n\treturn;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyFrom(IDictionary<T, U> dict)
		{
			//IL_03bd: Expected O, but got I
			//IL_039a: Expected O, but got I
			//IL_02d6: Expected O, but got I
			//IL_02de: Expected I, but got O
			//IL_02ef: Expected O, but got I
			//IL_0325: Expected I, but got O
			//IL_0055: Expected I, but got O
			//IL_0101: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_0377: Expected I, but got O
			//IL_0114: Expected I4, but got O
			//IL_0122: Expected O, but got I
			//IL_0131: Expected O, but got I
			//IL_026e: Expected I, but got O
			//IL_00dc: Expected O, but got I
			//IL_028a: Expected I, but got O
			//IL_0148: Expected I, but got O
			//IL_01f6: Expected O, but got I
			//IL_0471: Expected O, but got I
			//IL_0487: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_020f: Expected I4, but got O
			//IL_021d: Expected O, but got I
			//IL_022c: Expected O, but got I
			//IL_01d1: Expected O, but got I
			bool flag = this == null;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			IntPtr intPtr4 = default(IntPtr);
			IntPtr intPtr3 = intPtr4;
			IDictionary<T, U> dictionary = (IDictionary<T, U>)0;
			IDictionary<T, U> dictionary2 = dict;
			IEnumerator enumerator = default(IEnumerator);
			if (!flag)
			{
				Clear();
				bool flag2 = dict == null;
				intPtr = intPtr2;
				intPtr3 = intPtr4;
				T val = default(T);
				dictionary = (IDictionary<T, U>)val;
				dictionary2 = (IDictionary<T, U>)enumerator;
				if (!flag2)
				{
					IntPtr intPtr5 = (IntPtr)dict;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f5;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X11_v28-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v17 (Il2CppClass<System.Collections.Generic.IDictionary`2<T, U>>)+126]");
						bool flag3 = (long)num2 < 0L;
						bool flag4 = !flag3;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_00f5;
					}
					int num3 = obj << 4;
					object obj2 = (long)intPtr5 + (long)num3;
					object obj3 = (long)(IntPtr)obj2 + 304L;
					goto IL_03f5;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag5 = (IntPtr)dictionary != (IntPtr)1;
			Dictionary<T, U> dictionary3 = (Dictionary<T, U>)(object)ex;
			if (flag5)
			{
				goto IL_0389;
			}
			((Dictionary<T, U>)(object)ex).set_Item((T)dictionary, (U)(long)intPtr3);
			Dictionary<T, U> dictionary4 = default(Dictionary<T, U>);
			IntPtr intPtr6 = (IntPtr)dictionary4;
			dictionary4.set_Item((T)dictionary, (U)(long)intPtr3);
			bool flag6 = dictionary2 == null;
			int num4 = -1;
			intPtr2 = intPtr;
			int num5 = -1;
			IntPtr intPtr7 = (IntPtr)dictionary4;
			if (flag6)
			{
				goto IL_048c;
			}
			goto IL_04c2;
			IL_04c2:
			((IDisposable)dictionary2).Dispose();
			intPtr2 = intPtr;
			num5 = num4;
			intPtr7 = intPtr6;
			goto IL_048c;
			IL_03f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v271 @ X0_v22] (should have been resolved before IL gen)");
			T key = default(T);
			U val3;
			for (; enumerator.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v619 @ X0_v32] (should have been resolved before IL gen)"), Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X0_v32+8]"), base.set_Item(key, (U)0), intPtr2 = (IntPtr)0, Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X0_v32+8]"), val3 = (U)0)
			{
				IntPtr intPtr8 = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				U val2;
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj4 = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag7 = (long)num7 < 0L;
						bool flag8 = !flag7;
						obj4 = (long)(IntPtr)obj4 + 16L;
						if (!flag8)
						{
							continue;
						}
						goto IL_01ea;
					}
					int num8 = obj4 << 4;
					object obj5 = (long)intPtr8 + (long)num8;
					object obj6 = (long)(IntPtr)obj5 + 304L;
					val2 = (U)null;
					continue;
				}
				goto IL_01ea;
				IL_01ea:
				((Dictionary<T, U>)enumerator).set_Item((T)0, (U)null);
				val2 = (U)null;
			}
			bool flag9 = enumerator == null;
			bool flag10 = !flag9;
			intPtr = intPtr2;
			num4 = 0;
			dictionary2 = (IDictionary<T, U>)enumerator;
			intPtr6 = (IntPtr)null;
			if (!flag10)
			{
				num5 = 0;
				intPtr7 = (IntPtr)null;
				goto IL_048c;
			}
			goto IL_04c2;
			IL_048c:
			if (num5 + 1 != 0 || intPtr7 == (IntPtr)0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			intPtr = intPtr2;
			intPtr3 = (IntPtr)null;
			dictionary = null;
			dictionary3 = (Dictionary<T, U>)(object)ex2;
			goto IL_0389;
			IL_0389:
			dictionary3.set_Item((T)dictionary, (U)(long)intPtr3);
			return;
			IL_00f5:
			((Dictionary<T, U>)dict).set_Item((T)0, (U)null);
			goto IL_03f5;
		}

		[Token(Token = "0x60006F8")]
		[Address(RVA = "0xD8EF00", Offset = "0xD8EF00", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.keys;\n\tv23 = this.keys == 0;\n\tif (v23) goto L_005A;\n\tv24 = this.values;\n\tv25 = this.values == 0;\n\tif (v25) goto L_005A;\n\tv46 = v20.Length != v24.Length;\n\tif (v46) goto L_005A;\n\tv144 = System.Collections.Generic.Dictionary`2<T, U>::Clear(this);\n\tv135 = this.keys;\nL_002B:\n\tv204 = v106 < v135.Length;\n\tv128 = ~v204;\n\tv112 = v106 >= v135.Length;\n\tif (v112) goto L_0050;\n\tif (v128) goto L_005B;\n\tv184 = this->klass;\n\t*([v184 @ X9_v8 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+360])(v211, this, this.values, v106, *([v184 @ X9_v8 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+368]), v145, v146, v147, v148, v149, v150, v151, v152, v153, v154, v155, v156);\n\tv173 = System.Collections.Generic.Dictionary`2<T, U>::set_Item(this, v135[v106 @ X21_v6 (System.Int32)], v211);\n\tv135 = this.keys;\n\tv106 = v106 + 1;\n\tv216 = this.keys == 0;\n\tv186 = ~v216;\n\tif (v186) goto L_002B;\n\tthrow System.NullReferenceException;\nL_0050:\n\tthis.keys = 0;\n\tthis.values = 0;\nL_005A:\n\treturn;\nL_005B:\n\tv217 = new System.IndexOutOfRangeException();\n\tthrow v217;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			//IL_00ab: Expected I, but got O
			T[] array = keys;
			if (keys == null)
			{
				return;
			}
			V[] array2 = values;
			if (values == null || array.Length != array2.Length)
			{
				return;
			}
			Clear();
			T[] array3 = keys;
			int num = 0;
			U value = default(U);
			while (true)
			{
				bool flag = num < array3.Length;
				bool flag2 = !flag;
				if (num < array3.Length)
				{
					if (flag2)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v184 @ X9_v8 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+360] (should have been resolved before IL gen)");
					base.set_Item(array3[num], value);
					array3 = keys;
					num++;
					if (keys == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				keys = null;
				values = null;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60006F9")]
		[Address(RVA = "0xD8EFF4", Offset = "0xD8EFF4", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EFB3C8]);\n\tv25 = *([v24 @ X8_v40]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20240B2]) = v43;\nL_001A:\n\tv48 = this == 0;\n\tif (v48) goto L_0083;\n\tv54 = System.Collections.Generic.Dictionary`2<T, U>::get_Count(this);\n\tgoto L_002F;\n\tv126 = v58;\n\tv127 = System.Collections.Generic.Dictionary`2<T, U>::get_Count(v126, v52);\nL_002F:\n\t// 47 NewArr v131 @ X0_v25 (T[]), typeof(Il2CppClass<T[]>), v54 @ X0_v22 (System.Int32)\n\tthis.keys = v131;\n\tv137 = System.Collections.Generic.Dictionary`2<T, U>::get_Count(this);\n\tgoto L_0044;\n\tv155 = v140;\n\tv156 = System.Collections.Generic.Dictionary`2<T, U>::get_Count(v155, v135);\nL_0044:\n\t// 68 NewArr v160 @ X0_v30 (V[]), typeof(Il2CppClass<V[]>), v137 @ X0_v27 (System.Int32)\n\tthis.values = v160;\n\tv243 = System.Collections.Generic.Dictionary`2<T, U>::GetEnumerator(this);\n\tgoto L_0074;\nL_0055:\n\tv121 = this.keys;\n\tv382 = v123 < v121.Length;\n\tv269 = ~v382;\n\tif (v269) goto L_007E;\n\tv121[v123 @ X21_v10 (System.Int32)] = v170;\n\tv279 = this->klass;\n\t*([v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+350])(v276, this, this.values, v123, v416, *([v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+358]), v30, v31, v32, v170, v219, v35, v36, v37, v38, v39, v40);\n\tv280 = v123 + 1;\nL_0074:\n\tv285 = System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>::MoveNext(&v98 @ stack_-60_v5 (System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>));\n\tv334 = v285 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_0055;\n\tgoto L_0097;\n\tv384 = new System.NullReferenceException();\nL_007E:\n\tv420 = new System.IndexOutOfRangeException();\n\tthrow v420;\nL_0083:\n\tv125 = new System.NullReferenceException();\n\tgoto L_008F;\n\tgoto L_008F;\nL_008F:\n\tv154 = v222 != 1;\n\tif (v154) goto L_00F3;\n\tv161 = 0x6D2BC0(v125, v222, v297, v189, v185, v30, v31, v32, 0, v212, v35, v36, v37, v38, v39, v40);\n\tv229 = *([v161 @ X0_v19]);\n\tv248 = 0x6D2490(v161, v222, v297, v189, v185, v30, v31, v32, 0, v212, v35, v36, v37, v38, v39, v40);\nL_0097:\n\tv231 = Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>;\n\tgoto L_00A3;\n\tv368 = v231;\n\tv369 = 0x8907BC(v368, v356, v338, v189, v185, v30, v31, v32, v352, v351, v35, v36, v37, v38, v39, v40);\nL_00A3:\n\tv219 = Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>;\n\tv221 = &v219 @ stack_-98_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>) + 0x10;\n\tv380 = *([v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+126]) == 0;\n\tif (v380) goto L_00CD;\n\tv422 = *([v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+B0]) + 8;\nL_00B3:\n\t;\n\tv437 = *([v422 @ X10_v5-8]) == System.IDisposable;\n\tif (v437) goto L_00D0;\n\tv432 = v432 + 1;\n\tv442 = v432 < *([v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+126]);\n\tv409 = ~v442;\n\tv422 = v422 + 0x10;\n\tv393 = ~v409;\n\tif (v393) goto L_00B3;\nL_00CD:\n\tv452 = 0x8909C4(&v219 @ stack_-98_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>), System.IDisposable, 0, v416, *([v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+358]), v30, v31, v32, v348, 0, v35, v36, v37, v38, v39, v40);\n\tgoto L_00D6;\nL_00D0:\n\tv444 = *([v422 @ X10_v5]) << 4;\n\tv445 = Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>> + v444;\n\tv452 = v445 + 0x130;\nL_00D6:\n\t*([v452 @ X0_v4])(v321, &v219 @ stack_-98_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>), *([v452 @ X0_v4+8]), v297, v416, *([v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+358]), v30, v31, v32, v348, 0, v35, v36, v37, v38, v39, v40);\n\tv214 = *([v221 @ X22_v2+10]);\n\tv456 = v235 + 1;\n\tv199 = v456 == 0;\n\tv181 = ~v199;\n\tif (v181) goto L_00EE;\n\tv457 = v229 == 0;\n\tv227 = ~v457;\n\tif (v227) goto L_00F2;\nL_00EE:\n\treturn;\nL_00F2:\n\tv225 = new System.TypeLoadException();\nL_00F3:\n\tv236 = 0x6D2380(v125, v222, v297, v416, *([v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+358]), v30, v31, v32, v214, *([v221 @ X22_v2]), v35, v36, v37, v38, v39, v40);\n\treturn;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeforeSerialize()
		{
			//IL_0150: Expected I4, but got O
			//IL_0182: Expected O, but got I
			//IL_010b: Expected I, but got O
			//IL_037c: Expected O, but got I
			//IL_01bd: Expected O, but got I
			//IL_00a8: Expected I, but got O
			//IL_0248: Expected I4, but got O
			//IL_0253: Expected O, but got I
			//IL_0262: Expected O, but got I
			//IL_02a7: Expected I, but got O
			//IL_0209: Expected O, but got I
			bool flag = this == null;
			Enumerator enumerator = default(Enumerator);
			Enumerator enumerator2 = default(Enumerator);
			Enumerator enumerator3 = default(Enumerator);
			int num6;
			int num7;
			IntPtr intPtr2 = default(IntPtr);
			NullReferenceException ex2;
			int num5;
			if (!flag)
			{
				int num = base.Count;
				T[] array = null;
				keys = array;
				int num2 = base.Count;
				V[] array2 = null;
				values = array2;
				Enumerator enumerator4 = GetEnumerator();
				int num3 = 0;
				Enumerator enumerator5 = default(Enumerator);
				while (enumerator2.MoveNext())
				{
					T[] array3 = keys;
					if (num3 < array3.Length)
					{
						array3[num3] = (T)enumerator5;
						IntPtr intPtr = (IntPtr)this;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v279 @ X8_v37 (Il2CppClass<EasyMobile.Internal.SerializableDictionaryBase`3<T, U, V>>)+350] (should have been resolved before IL gen)");
						int num4 = num3 + 1;
						num5 = num3;
						num3 = num4;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					num5 = 0;
					intPtr2 = (IntPtr)null;
					throw ex;
				}
				enumerator = enumerator5;
				num6 = 0;
				num7 = 0;
			}
			else
			{
				ex2 = new NullReferenceException();
				if (intPtr2 != (IntPtr)1)
				{
					goto IL_02b4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num6 = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				num7 = -1;
			}
			IntPtr intPtr3 = (IntPtr)0;
			IntPtr intPtr4 = (IntPtr)0;
			object obj2 = (long)intPtr4 + 16L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0222;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+B0]");
			object obj3 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ X10_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDisposable))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X19_v2 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, U>+Enumerator<T, U>>)+126]");
				bool flag2 = (long)num9 < 0L;
				bool flag3 = !flag2;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_0222;
			}
			int num10 = obj3 << 4;
			object obj4 = 0L + (long)num10;
			object obj5 = (long)(IntPtr)obj4 + 304L;
			goto IL_0362;
			IL_0362:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v452 @ X0_v4] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X22_v2+10]");
			enumerator3 = (Enumerator)0;
			if (num7 + 1 != 0 || num6 == 0)
			{
				return;
			}
			TypeLoadException ex3 = new TypeLoadException();
			num5 = 0;
			intPtr2 = (IntPtr)null;
			ex2 = (NullReferenceException)(object)ex3;
			goto IL_02b4;
			IL_02b4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0222:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num5 = 0;
			goto IL_0362;
		}
	}
}
