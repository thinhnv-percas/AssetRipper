using System;
using System.Collections.Generic;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000038")]
public class UserResourceCollectionItem<T> : UserResourceInventory<T> where T : ItemArtifact
{
	[Token(Token = "0x40000CC")]
	[FieldOffset(Offset = "0x0")]
	public int limitStackCount;

	[Token(Token = "0x40000CD")]
	[FieldOffset(Offset = "0x0")]
	private bool isCanStack;

	[Token(Token = "0x1700001E")]
	public override List<T> CollectionsValue
	{
		[Token(Token = "0x6000171")]
		[Address(RVA = "0x11F9F9C", Offset = "0x11F9F9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.itemCollections;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return CollectionsValue;
		}
	}

	[Token(Token = "0x6000172")]
	[Address(RVA = "0x11F9FA4", Offset = "0x11F9FA4", Length = "0x12C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, v16, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = v22;\nL_0013:\n\tv39 = valueSet == 0;\n\tif (v39) goto L_0032;\n\tgoto L_FFFFFFFF;\n\tv57 = v57_asT == 0;\n\tif (v57) goto L_008D;\nL_0032:\n\tthis.itemCollections = valueSet;\n\tgoto L_003E;\n\tv143 = v91;\n\tv144 = 0xB348B0(v143, v91, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv145 = v144;\nL_003E:\n\tv135 = valueSet == 0;\n\tif (v135) goto L_005D;\n\tgoto L_FFFFFFFF;\n\tv103 = v103_asT == 0;\n\tif (v103) goto L_008D;\nL_005D:\n\tv259 = this.itemCollections;\nL_006D:\n\tv209 = v241 >= v259._size;\n\tif (v209) goto L_007D;\n\tv231 = System.Collections.Generic.List`1<T>::get_Item(v259, v241);\n\tv241 = v241 + 1;\n\t*([v231 @ X0_v14 (T)+10]) = this.type;\n\tv259 = this.itemCollections;\n\tv269 = this.itemCollections == 0;\n\tv234 = ~v269;\n\tif (v234) goto L_006D;\n\tthrow System.NullReferenceException;\nL_007D:\n\tv232 = System.Activator::CreateInstance();\n\tv268 = *([v232 @ X0_v9 (System.Object)]);\n\t*([v268 @ X8_v11 (Il2CppClass<System.Object>)+1A8])(v189, v232, *([v268 @ X8_v11 (Il2CppClass<System.Object>)+1B0]), Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv201 = v189 & 1;\n\tthis.isCanStack = v201;\n\treturn;\nL_008D:\n\tthrow System.InvalidCastException;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetValue(object valueSet)
	{
		//IL_010b: Expected I, but got O
		if (valueSet != null)
		{
			List<T> list = valueSet as List<T>;
			if (list == null)
			{
				goto IL_012f;
			}
		}
		this.itemCollections = (List<T>)valueSet;
		if (valueSet != null)
		{
			List<T> list2 = valueSet as List<T>;
			if (list2 == null)
			{
				goto IL_012f;
			}
		}
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		while (num < collectionsValue.Count)
		{
			T val = collectionsValue[num];
			num++;
			_ = this.type;
			collectionsValue = CollectionsValue;
			if (CollectionsValue == null)
			{
				throw new NullReferenceException();
			}
		}
		object obj = Activator.CreateInstance<object>();
		nint num2 = (nint)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v268 @ X8_v11 (Il2CppClass<System.Object>)+1A8] (should have been resolved before IL gen)");
		object obj2 = default(object);
		int num3 = (int)((nint)obj2 & 1);
		isCanStack = (byte)num3 != 0;
		return;
		IL_012f:
		throw new InvalidCastException();
	}

	[Token(Token = "0x6000173")]
	[Address(RVA = "0x11FA0D0", Offset = "0x11FA0D0", Length = "0x278")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = ItemStack;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, idItem, valueAdd, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A362BD]) = v42;\nL_0017:\n\tv44 = ~this.isCanStack;\n\tif (v44) goto L_00EC;\n\tv305 = this.itemCollections;\nL_0027:\n\tv178 = v166 >= v305._size;\n\tif (v178) goto L_004A;\n\tv258 = System.Collections.Generic.List`1<T>::get_Item(v305, v166);\n\tv239 = *([v258 @ X0_v34 (T)+14]);\n\tv332 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v239 @ V0_v8 (System.Int32));\n\tv213 = v332 == idItem;\n\tif (v213) goto L_0091;\n\tv305 = this.itemCollections;\n\tv166 = v166 + 1;\n\tv334 = this.itemCollections == 0;\n\tv265 = ~v334;\n\tif (v265) goto L_0027;\n\tthrow System.NullReferenceException;\nL_004A:\n\tv326 = new ItemStack();\n\tItemStack::.ctor(v326);\n\tv259 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(idItem);\n\tv326.fragment = valueAdd;\n\tv326.idItem.fakeValueActive = v259.fakeValueActive;\n\tv326.idItem = v259.currentCryptoKey;\n\tv155 = this.itemCollections;\n\tgoto L_0071;\n\tv349 = v343;\n\tv350 = 0xB348B0(v349, v343, v142, methodInfo, v28, v29, v30, v31, v138, v33, v34, v35, v36, v37, v38, v39);\n\tv352 = v350;\nL_0071:\n\t// 113 IsInst v355 @ X0_v19 (System.Int32), typeof(T), v326 @ X0_v14 (ItemStack)\n\tgoto L_007E;\n\tv363 = v358;\n\tv364 = 0xB348B0(v363, v351, v142, methodInfo, v28, v29, v30, v31, v138, v33, v34, v35, v36, v37, v38, v39);\n\tv366 = v364;\nL_007E:\n\tv367 = v355 == 0;\n\tif (v367) goto L_FFFFFFFF;\n\t// 130 IsInst v372 @ X0_v24 (T), typeof(T), v355 @ X0_v19 (System.Int32)\n\tv375 = v372 == 0;\n\tv339 = ~v375;\n\tif (v339) goto L_00C8;\n\tthrow System.InvalidCastException;\nL_0091:\n\tv261 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v166);\n\tv286 = *([v261 @ X0_v6 (T)]);\n\t*([v286 @ X8_v8 (Il2CppClass<T>)+188])(v362, v261, valueAdd, *([v286 @ X8_v8 (Il2CppClass<T>)+190]), methodInfo, v28, v29, v30, v31, v239, v33, v34, v35, v36, v37, v38, v39);\n\tv263 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v166);\n\tv150 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v166);\n\tv163 = *([v150 @ X0_v11 (T)+2C]);\n\tv124 = *([v150 @ X0_v11 (T)+2C]) - this.limitStackCount;\n\tv120 = v124 < 0;\n\tv112 = *([v150 @ X0_v11 (T)+2C]) ^ this.limitStackCount;\n\tv108 = *([v150 @ X0_v11 (T)+2C]) ^ v124;\n\tv104 = v112 & v108;\n\tv100 = v104 < 0;\n\tv387 = v120 == v100;\n\tv63 = ~v387;\n\tv59 = ~v63;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_00C2;\nL_00C2:\n\t*([v263 @ X0_v9 (T)+2C]) = v163;\n\tgoto L_00EC;\nL_00C8:\n\tv288 = v155._items;\n\tv176 = v155._version + 1;\n\tv155._version = v176;\n\tv54 = v155._size;\n\tv383 = v155._size < v288.Length;\n\tv126 = ~v383;\n\tif (v126) goto L_00E4;\n\tv66 = v155._size + 1;\n\tv155._size = v66;\n\tv288[v54 @ X10_v6 (System.Int32)] = v145;\n\tgoto L_00EC;\nL_00E4:\n\tSystem.Collections.Generic.List`1<T>::AddWithResize(v155, v145);\nL_00EC:\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void AddValue(int idItem, long valueAdd)
	{
		//IL_00e7: Expected I4, but got I8
		//IL_0110: Expected O, but got I4
		//IL_0051: Expected O, but got Ref
		//IL_0364: Expected I4, but got O
		//IL_0187: Expected I, but got O
		//IL_012d: Expected O, but got I4
		if (!isCanStack)
		{
			return;
		}
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		while (true)
		{
			if (num < collectionsValue.Count)
			{
				T val = collectionsValue[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ X0_v34 (T)+14]");
				int num2 = 0;
				int num3 = (ObscuredInt)(&num2);
				if (num3 == idItem)
				{
					break;
				}
				collectionsValue = CollectionsValue;
				num++;
				if (CollectionsValue == null)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			ItemStack itemStack = new ItemStack();
			ObscuredInt obscuredInt = idItem;
			itemStack.fragment = (int)valueAdd;
			itemStack.idItem.fakeValueActive = obscuredInt.fakeValueActive;
			itemStack.idItem = (ObscuredInt)obscuredInt.currentCryptoKey;
			List<T> collectionsValue2 = CollectionsValue;
			int num4 = (int)(itemStack as T);
			T val3;
			if (num4 != 0)
			{
				T val2 = num4 as T;
				bool flag = val2 == null;
				bool flag2 = !flag;
				val3 = val2;
				if (!flag2)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val3 = null;
			}
			T[] items = collectionsValue2._items;
			int version = collectionsValue2._version + 1;
			collectionsValue2._version = version;
			int count = collectionsValue2.Count;
			if (collectionsValue2.Count < items.Length)
			{
				int size = collectionsValue2.Count + 1;
				collectionsValue2._size = size;
				items[count] = val3;
			}
			else
			{
				collectionsValue2.Add(val3);
			}
			return;
		}
		T val4 = CollectionsValue[num];
		nint num5 = (nint)val4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v286 @ X8_v8 (Il2CppClass<T>)+188] (should have been resolved before IL gen)");
		T val5 = CollectionsValue[num];
		T val6 = CollectionsValue[num];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X0_v11 (T)+2C]");
		int num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X0_v11 (T)+2C]");
		int num7 = (int)(-limitStackCount);
		bool flag3 = num7 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X0_v11 (T)+2C]");
		int num8 = (int)((nint)0 ^ (nint)limitStackCount);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X0_v11 (T)+2C]");
		int num9 = (int)((nint)0 ^ (nint)num7);
		int num10 = num8 & num9;
		bool flag4 = num10 < 0;
		if (flag3 == flag4)
		{
			num6 = limitStackCount;
		}
	}

	[Token(Token = "0x6000174")]
	[Address(RVA = "0x11FA348", Offset = "0x11FA348", Length = "0xFC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv135 = this.itemCollections;\nL_0019:\n\tv25 = v91 >= v135._size;\n\tif (v25) goto L_0060;\n\tv104 = System.Collections.Generic.List`1<T>::get_Item(v135, v91);\n\tv72 = *([v104 @ X0_v6 (T)+14]);\n\tv194 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v72 @ V0_v4);\n\tv48 = v194 == idItem;\n\tif (v48) goto L_0040;\n\tv135 = this.itemCollections;\n\tv91 = v91 + 1;\n\tv196 = this.itemCollections == 0;\n\tv98 = ~v196;\n\tif (v98) goto L_0019;\n\tgoto L_0061;\nL_0040:\n\tv107 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v91);\n\tv88 = *([v107 @ X0_v10 (T)]);\n\t*([v88 @ X8_v10 (Il2CppClass<T>)+1A8])(v162, v107, *([v88 @ X8_v10 (Il2CppClass<T>)+1B0]), Il2CppMethodInfo, methodInfo, v111, v112, v113, v114, v72, v115, v116, v117, v118, v119, v120, v121);\n\tv198 = v162 & 1;\n\tv159 = v198 == 0;\n\tif (v159) goto L_0060;\n\tv109 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v91);\n\tv157 = *([v109 @ X0_v13 (T)]);\n\t*([v157 @ X8_v13 (Il2CppClass<T>)+198])(v161, v109, number, *([v157 @ X8_v13 (Il2CppClass<T>)+1A0]), methodInfo, v111, v112, v113, v114, v72, v115, v116, v117, v118, v119, v120, v121);\nL_0060:\n\treturn;\nL_0061:\n\tthrow System.NullReferenceException;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void SubValue(int idItem, long number)
	{
		//IL_0043: Expected O, but got I
		//IL_004c: Expected O, but got Ref
		//IL_00d3: Expected I, but got O
		//IL_0129: Expected I, but got O
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		object obj2 = default(object);
		while (num < collectionsValue.Count)
		{
			T val = collectionsValue[num];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X0_v6 (T)+14]");
			object obj = 0;
			int num2 = (ObscuredInt)(&obj);
			if (num2 != idItem)
			{
				collectionsValue = CollectionsValue;
				num++;
				if (CollectionsValue == null)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			T val2 = CollectionsValue[num];
			nint num3 = (nint)val2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v88 @ X8_v10 (Il2CppClass<T>)+1A8] (should have been resolved before IL gen)");
			if ((int)((nint)obj2 & 1) != 0)
			{
				T val3 = CollectionsValue[num];
				nint num4 = (nint)val3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v157 @ X8_v13 (Il2CppClass<T>)+198] (should have been resolved before IL gen)");
			}
			break;
		}
	}

	[Token(Token = "0x6000175")]
	[Address(RVA = "0x11FA444", Offset = "0x11FA444", Length = "0xBC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv114 = this.itemCollections;\nL_0017:\n\tv21 = v76 >= v114._size;\n\tif (v21) goto L_FFFFFFFF;\n\tv85 = System.Collections.Generic.List`1<T>::get_Item(v114, v76);\n\tv65 = *([v85 @ X0_v7 (T)+14]);\n\tv167 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v65 @ V0_v4);\n\tv41 = v167 == id;\n\tif (v41) goto L_0040;\n\tv114 = this.itemCollections;\n\tv76 = v76 + 1;\n\tv169 = this.itemCollections == 0;\n\tv82 = ~v169;\n\tif (v82) goto L_0017;\n\tgoto L_0048;\n\tgoto L_0047;\nL_0040:\n\treturnVal2 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v76);\nL_0047:\n\treturn returnVal2;\nL_0048:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe T GetItemById(int id)
	{
		//IL_0043: Expected O, but got I
		//IL_004c: Expected O, but got Ref
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		do
		{
			if (num < collectionsValue.Count)
			{
				T val = collectionsValue[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v7 (T)+14]");
				object obj = 0;
				int num2 = (ObscuredInt)(&obj);
				if (num2 != id)
				{
					collectionsValue = CollectionsValue;
					num++;
					continue;
				}
				return CollectionsValue[num];
			}
			return null;
		}
		while (CollectionsValue != null);
		return (T)(object)new NullReferenceException();
	}

	[Token(Token = "0x6000176")]
	[Address(RVA = "0x11FA500", Offset = "0x11FA500", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv133 = this.itemCollections;\nL_0019:\n\tv29 = v91 >= v133._size;\n\tif (v29) goto L_0055;\n\tv104 = System.Collections.Generic.List`1<T>::get_Item(v133, v91);\n\tv71 = *([v104 @ X0_v7 (T)+14]);\n\tv173 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v71 @ V0_v4);\n\tv27 = v173 != id;\n\tif (v27) goto L_0047;\n\tv106 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v91);\n\tv179 = *([v106 @ X0_v13 (T)]);\n\t*([v179 @ X8_v11 (Il2CppClass<T>)+178])(v163, v106, *([v179 @ X8_v11 (Il2CppClass<T>)+180]), Il2CppMethodInfo, v108, v109, v110, v111, v112, v71, v113, v114, v115, v116, v117, v118, v119);\n\tv92 = v163 + v156;\n\tv180 = ~this.isCanStack;\n\tv161 = ~v180;\n\tif (v161) goto L_0055;\nL_0047:\n\tv133 = this.itemCollections;\n\tv91 = v91 + 1;\n\tv177 = this.itemCollections == 0;\n\tv98 = ~v177;\n\tif (v98) goto L_0019;\n\tthrow System.NullReferenceException;\nL_0055:\n\treturn v156;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override long GetValue(int id)
	{
		//IL_0021: Expected I8, but got I4
		//IL_004c: Expected O, but got I
		//IL_0055: Expected O, but got Ref
		//IL_00a0: Expected I, but got O
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		long num2 = 0L;
		object obj2 = default(object);
		while (num < collectionsValue.Count)
		{
			T val = collectionsValue[num];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X0_v7 (T)+14]");
			object obj = 0;
			int num3 = (ObscuredInt)(&obj);
			bool flag = num3 != id;
			long num4 = num2;
			if (!flag)
			{
				T val2 = CollectionsValue[num];
				nint num5 = (nint)val2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ X8_v11 (Il2CppClass<T>)+178] (should have been resolved before IL gen)");
				num4 = (nint)obj2 + num2;
				bool flag2 = !isCanStack;
				bool flag3 = !flag2;
				num2 = num4;
				if (flag3)
				{
					break;
				}
			}
			collectionsValue = CollectionsValue;
			num++;
			bool flag4 = CollectionsValue == null;
			bool flag5 = !flag4;
			num2 = num4;
			if (!flag5)
			{
				throw new NullReferenceException();
			}
		}
		return num2;
	}

	[Token(Token = "0x6000177")]
	[Address(RVA = "0x11FA5D4", Offset = "0x11FA5D4", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.limitStackCount = 0x7FFFFFFF;\n\tUserResourceInventory`1<T>::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UserResourceCollectionItem()
	{
		limitStackCount = int.MaxValue;
	}
}
