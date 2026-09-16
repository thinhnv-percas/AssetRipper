using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools
{
	[Token(Token = "0x200003D")]
	public abstract class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
	{
		[SerializeField]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x0")]
		private List<K> keys;

		[SerializeField]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x0")]
		private List<V> values;

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x11589B8", Offset = "0x11589B8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>::Clear(this);\nL_001C:\n\tv37 = v72 >= v76._size;\n\tif (v37) goto L_004F;\n\tv87 = this.values;\n\tv35 = v72 >= v87._size;\n\tif (v35) goto L_004F;\n\tv77 = System.Collections.Generic.List`1<System.Int32>::get_Item(v76, v72);\n\tv154 = System.Collections.Generic.List`1<V>::get_Item(this.values, v72);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>::set_Item(this, v77, v154);\n\tv72 = v72 + 1;\n\tv157 = this.keys == 0;\n\tv90 = ~v157;\n\tif (v90) goto L_001C;\n\tthrow System.NullReferenceException;\nL_004F:\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			((Dictionary<int, object>)(object)this).Clear();
			int num = 0;
			List<int> list = (List<int>)(object)keys;
			while (num < list.Count)
			{
				List<V> list2 = values;
				if (num < list2.Count)
				{
					int key = list[num];
					V value = values[num];
					((Dictionary<int, object>)(object)this)[key] = value;
					num++;
					bool flag = keys == null;
					bool flag2 = !flag;
					list = (List<int>)(object)keys;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x1158A80", Offset = "0x1158A80", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.keys;\n\tv17 = v12._version + 1;\n\tv12._size = 0;\n\tv12._version = v17;\n\tv18 = this.values;\n\tv106 = v18._version + 1;\n\tv18._size = 0;\n\tv18._version = v106;\n\tv46 = v18._size < 1;\n\tif (v46) goto L_002F;\n\tSystem.Array::Clear(v18._items, 0, v18._size);\nL_002F:\n\tv185 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>::GetEnumerator(this);\nL_003A:\n\tv245 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v35 @ stack_-78_v4 (System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>));\n\tv250 = v245 == 0;\n\tif (v250) goto L_FFFFFFFF;\n\tv257 = this.keys;\n\tv266 = v257._items;\n\tv267 = v257._version + 1;\n\tv257._version = v267;\n\tv313 = v257._size;\n\tv314 = v257._size < v266.Length;\n\tv294 = ~v314;\n\tif (v294) goto L_0061;\n\tv318 = v257._size + 1;\n\tv257._size = v318;\n\tv266[v313 @ X10_v9 (System.Int32)] = v186;\n\tgoto L_0062;\nL_0061:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(v257, v186);\nL_0062:\n\tv213 = this.values;\n\tv363 = v213._items;\n\tv364 = v213._version + 1;\n\tv213._version = v364;\n\tv208 = v213._size;\n\tv366 = v213._size < v363.Length;\n\tv229 = ~v366;\n\tif (v229) goto L_0084;\n\tv234 = v213._size + 1;\n\tv213._size = v234;\n\tv363[v208 @ X10_v13 (System.Int32)] = v264;\n\tgoto L_003A;\nL_0084:\n\tSystem.Collections.Generic.List`1<V>::AddWithResize(v213, v264);\n\tgoto L_003A;\nL_0089:\n\t;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v168 @ stack_-50_v2 (System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>));\n\tv316 = v122 == 0;\n\tv162 = ~v316;\n\tif (v162) goto L_009B;\n\treturn;\n\tv365 = new System.NullReferenceException();\n\tv278 = new System.NullReferenceException();\n\tv302 = new System.NullReferenceException();\n\tv44 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_009B:\n\tv174 = new System.OutOfMemoryException();\n\tgoto L_00AA;\n\tgoto L_00AA;\n\tgoto L_00AA;\n\tgoto L_00AA;\nL_00AA:\n\tv199 = v131 != 1;\n\tif (v199) goto L_00B2;\n\tv247 = 0x1854E70(v174, v131, v155, v129, v94, v95, v96, v97, v171, v125, v98, v99, v100, v101, v102, v103);\n\tv122 = *([v247 @ X0_v14]);\n\tv252 = 0x1854E80(v247, v131, v155, v129, v94, v95, v96, v97, v171, v125, v98, v99, v100, v101, v102, v103);\n\tgoto L_0089;\nL_00B2:\n\tgoto L_00B5;\n\tX20 = X0;\nL_00B5:\n\tv254 = Il2CppRgctx<Zitga.CsvTools.SerializableDictionary`2>;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v168 @ stack_-50_v2 (System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>));\n\tgoto L_00BF;\n\tv309 = 0xBD3CD0(v174, *([v254 @ X8_v7 (Il2CppRgctx<Zitga.CsvTools.SerializableDictionary`2>)+C0]), v155, v129, v94, v95, v96, v97, v171, v125, v98, v99, v100, v101, v102, v103);\nL_00BF:\n\tv312 = new System.OutOfMemoryException();\n\tv317 = 0x9DACB4(v312, *([v254 @ X8_v7 (Il2CppRgctx<Zitga.CsvTools.SerializableDictionary`2>)+C0]), v155, v129, v94, v95, v96, v97, v171, v125, v98, v99, v100, v101, v102, v103);\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			//IL_02b3: Expected I4, but got O
			List<K> list = keys;
			int version = list._version + 1;
			list._size = 0;
			list._version = version;
			List<V> list2 = values;
			int version2 = list2._version + 1;
			list2._size = 0;
			list2._version = version2;
			if (list2.Count >= 1)
			{
				Array.Clear(list2._items, 0, list2.Count);
			}
			object enumerator = ((Dictionary<int, object>)(object)this).GetEnumerator();
			Dictionary<int, object>.Enumerator enumerator2 = default(Dictionary<int, object>.Enumerator);
			int num = default(int);
			V val = default(V);
			while (enumerator2.MoveNext())
			{
				List<int> list3 = (List<int>)(object)keys;
				int[] items = list3._items;
				int version3 = list3._version + 1;
				list3._version = version3;
				int count = list3.Count;
				if (list3.Count < items.Length)
				{
					int size = list3.Count + 1;
					list3._size = size;
					items[count] = num;
				}
				else
				{
					list3.Add(num);
				}
				List<V> list4 = values;
				V[] items2 = list4._items;
				int version4 = list4._version + 1;
				list4._version = version4;
				int count2 = list4.Count;
				if (list4.Count < items2.Length)
				{
					int size2 = list4.Count + 1;
					list4._size = size2;
					items2[count2] = val;
				}
				else
				{
					list4.Add(val);
				}
			}
			int num2 = 0;
			Dictionary<int, object>.Enumerator enumerator3 = enumerator2;
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				enumerator3.Dispose();
				if (num2 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if ((nint)obj == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num2 = (int)obj2;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					continue;
				}
				break;
			}
			nint num3 = 0;
			enumerator3.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x1158C9C", Offset = "0x1158C9C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv19 = v14;\n\tv20 = 0xB348B0(v19, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = v20;\nL_0013:\n\tv39 = new Il2CppClass<System.Collections.Generic.List`1<K>>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v39);\n\tthis.keys = v39;\n\tgoto L_0023;\n\tv51 = System.Collections.Generic.List`1<K>::.ctor(v46, v43);\nL_0023:\n\tv53 = new Il2CppClass<System.Collections.Generic.List`1<V>>();\n\tSystem.Collections.Generic.List`1<V>::.ctor(v53);\n\tthis.values = v53;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>::.ctor(this);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal SerializableDictionary()
		{
			List<int> list = new List<int>();
			keys = (List<K>)(object)list;
			List<V> list2 = new List<V>();
			values = list2;
		}
	}
}
