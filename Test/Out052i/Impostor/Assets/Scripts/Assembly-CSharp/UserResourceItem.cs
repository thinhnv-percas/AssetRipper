using System;
using System.Collections.Generic;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000037")]
public class UserResourceItem<T> : UserResourceInventory<T> where T : ItemResources
{
	[Token(Token = "0x600016A")]
	[Address(RVA = "0x11FA728", Offset = "0x11FA728", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv21 = v16;\n\tv22 = 0xB348B0(v21, v16, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = v22;\nL_0013:\n\tv39 = valueSet == 0;\n\tif (v39) goto L_0032;\n\tgoto L_FFFFFFFF;\n\tv57 = v57_asT == 0;\n\tif (v57) goto L_0064;\nL_0032:\n\tthis.itemCollections = valueSet;\n\tgoto L_003E;\n\tv143 = v91;\n\tv144 = 0xB348B0(v143, v91, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv145 = v144;\nL_003E:\n\tv135 = valueSet == 0;\n\tif (v135) goto L_0062;\n\tgoto L_FFFFFFFF;\n\tv103 = v103_asT == 0;\n\tif (v103) goto L_0064;\nL_0062:\n\treturn;\nL_0064:\n\tthrow System.InvalidCastException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetValue(object valueSet)
	{
		if (valueSet != null)
		{
			List<T> list = valueSet as List<T>;
			if (list == null)
			{
				goto IL_0073;
			}
		}
		this.itemCollections = (List<T>)valueSet;
		if (valueSet != null)
		{
			List<T> list2 = valueSet as List<T>;
			if (list2 != null)
			{
				return;
			}
			goto IL_0073;
		}
		return;
		IL_0073:
		throw new InvalidCastException();
	}

	[Token(Token = "0x600016B")]
	[Address(RVA = "0x11FA7EC", Offset = "0x11FA7EC", Length = "0x25C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv30 = ItemResources;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, idItem, valueAdd, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A362BE]) = v46;\nL_0018:\n\tv285 = this.itemCollections;\nL_0028:\n\tv53 = v272 >= v285._size;\n\tif (v53) goto L_0049;\n\tv245 = System.Collections.Generic.List`1<T>::get_Item(v285, v272);\n\tv221 = *([v245 @ X0_v33 (T)+14]);\n\tv310 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v221 @ V0_v9 (System.Boolean));\n\tv185 = v310 == idItem;\n\tif (v185) goto L_00A6;\n\tv285 = this.itemCollections;\n\tv272 = v272 + 1;\n\tv316 = this.itemCollections == 0;\n\tv252 = ~v316;\n\tif (v252) goto L_0028;\n\tthrow System.NullReferenceException;\nL_0049:\n\tv304 = new *([v299 @ X24_v4 (Il2CppClass<ItemResources>)])();\n\tItemResources::.ctor(v304);\n\tv307 = &v156 @ stack_-B0 (System.Int64);\n\tv246 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(idItem);\n\tv304.idItem.fakeValueActive = *([v307 @ X8_v9+10]);\n\tv304.idItem = *([v307 @ X8_v9]);\n\tv247 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(valueAdd);\n\tv304.value.fakeValueActive = v247.fakeValueActive;\n\tv304.value.inited = v247.inited;\n\tv304.value = v247.currentCryptoKey;\n\tv271 = this.itemCollections;\n\tgoto L_0086;\n\tv331 = v326;\n\tv332 = 0xB348B0(v331, v326, v228, methodInfo, v32, v33, v34, v35, v224, v78, v38, v39, v40, v41, v42, v43);\n\tv334 = v332;\nL_0086:\n\t// 134 IsInst v337 @ X0_v18, typeof(T), v304 @ X0_v11 (ItemResources)\n\tgoto L_0093;\n\tv414 = v345;\n\tv415 = 0xB348B0(v414, v333, v228, methodInfo, v32, v33, v34, v35, v224, v78, v38, v39, v40, v41, v42, v43);\n\tv416 = v415;\nL_0093:\n\tv418 = v337 == 0;\n\tif (v418) goto L_FFFFFFFF;\n\t// 151 IsInst v429 @ X0_v23 (T), typeof(T), v337 @ X0_v18\n\tv432 = v429 == 0;\n\tv321 = ~v432;\n\tif (v321) goto L_00B3;\n\tthrow System.InvalidCastException;\nL_00A6:\n\tv249 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v272);\n\tv338 = *([v249 @ X0_v7 (T)]);\n\t*([v338 @ X8_v7 (Il2CppClass<T>)+188])(v342, v249, valueAdd, *([v338 @ X8_v7 (Il2CppClass<T>)+190]), methodInfo, v32, v33, v34, v35, v221, v79, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D4;\nL_00B3:\n\tv266 = v271._items;\n\tv61 = v271._version + 1;\n\tv271._version = v61;\n\tv357 = v271._size;\n\tv438 = v271._size < v266.Length;\n\tv395 = ~v438;\n\tif (v395) goto L_00CF;\n\tv359 = v271._size + 1;\n\tv271._size = v359;\n\tv266[v357 @ X10_v6 (System.Int32)] = v238;\n\tgoto L_00D4;\nL_00CF:\n\tSystem.Collections.Generic.List`1<T>::AddWithResize(v271, v238);\nL_00D4:\n\tUserResource::InvokeEventChange(this, idItem, valueAdd);\n\treturn;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void AddValue(int idItem, long valueAdd)
	{
		//IL_02aa: Expected I, but got O
		//IL_00cf: Expected O, but got I8
		//IL_0155: Expected O, but got I8
		//IL_0042: Expected O, but got Ref
		//IL_01cc: Expected I, but got O
		//IL_00a4: Expected I, but got O
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		long num5 = default(long);
		while (true)
		{
			bool flag = num >= collectionsValue.Count;
			nint num2 = (nint)typeof(ItemResources);
			if (!flag)
			{
				T val = collectionsValue[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X0_v33 (T)+14]");
				bool flag2 = false;
				int num3 = (ObscuredInt)(&flag2);
				if (num3 != idItem)
				{
					collectionsValue = CollectionsValue;
					num++;
					bool flag3 = CollectionsValue == null;
					bool flag4 = !flag3;
					num2 = (nint)typeof(ItemResources);
					if (!flag4)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				T val2 = CollectionsValue[num];
				nint num4 = (nint)val2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v338 @ X8_v7 (Il2CppClass<T>)+188] (should have been resolved before IL gen)");
				break;
			}
			ItemResources itemResources = new ItemResources();
			object idItem2 = num5;
			ObscuredInt obscuredInt = idItem;
			ref ObscuredInt idItem3 = ref itemResources.idItem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v9+10]");
			idItem3.fakeValueActive = false;
			itemResources.idItem = (ObscuredInt)idItem2;
			ObscuredLong obscuredLong = valueAdd;
			itemResources.value.fakeValueActive = obscuredLong.fakeValueActive;
			itemResources.value.inited = obscuredLong.inited;
			itemResources.value = (ObscuredLong)obscuredLong.currentCryptoKey;
			List<T> collectionsValue2 = CollectionsValue;
			object obj = itemResources as T;
			T val4;
			if (obj != null)
			{
				T val3 = obj as T;
				bool flag5 = val3 == null;
				bool flag6 = !flag5;
				val4 = val3;
				if (!flag6)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val4 = null;
			}
			T[] items = collectionsValue2._items;
			int version = collectionsValue2._version + 1;
			collectionsValue2._version = version;
			int count = collectionsValue2.Count;
			if (collectionsValue2.Count < items.Length)
			{
				int size = collectionsValue2.Count + 1;
				collectionsValue2._size = size;
				items[count] = val4;
			}
			else
			{
				collectionsValue2.Add(val4);
			}
			break;
		}
		InvokeEventChange(idItem, valueAdd);
	}

	[Token(Token = "0x600016C")]
	[Address(RVA = "0x11FAA48", Offset = "0x11FAA48", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv123 = this.itemCollections;\nL_0019:\n\tv25 = v83 >= v123._size;\n\tif (v25) goto L_0054;\n\tv94 = System.Collections.Generic.List`1<T>::get_Item(v123, v83);\n\tv69 = *([v94 @ X0_v6 (T)+14]);\n\tv184 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v69 @ V0_v4);\n\tv45 = v184 == id;\n\tif (v45) goto L_0040;\n\tv123 = this.itemCollections;\n\tv83 = v83 + 1;\n\tv186 = this.itemCollections == 0;\n\tv90 = ~v186;\n\tif (v90) goto L_0019;\n\tgoto L_0055;\nL_0040:\n\tv97 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v83);\n\tv148 = *([v97 @ X0_v10 (T)]);\n\t*([v148 @ X8_v10 (Il2CppClass<T>)+198])(v190, v97, value, *([v148 @ X8_v10 (Il2CppClass<T>)+1A0]), methodInfo, v99, v100, v101, v102, v69, v103, v104, v105, v106, v107, v108, v109);\n\tv144 = 0 - value;\n\tUserResource::InvokeEventChange(this, id, v144);\nL_0054:\n\treturn;\nL_0055:\n\tthrow System.NullReferenceException;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override void SubValue(int id, long value)
	{
		//IL_0043: Expected O, but got I
		//IL_004c: Expected O, but got Ref
		//IL_00d3: Expected I, but got O
		List<T> collectionsValue = CollectionsValue;
		int num = 0;
		do
		{
			if (num < collectionsValue.Count)
			{
				T val = collectionsValue[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v6 (T)+14]");
				object obj = 0;
				int num2 = (ObscuredInt)(&obj);
				if (num2 != id)
				{
					collectionsValue = CollectionsValue;
					num++;
					continue;
				}
				T val2 = CollectionsValue[num];
				nint num3 = (nint)val2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v148 @ X8_v10 (Il2CppClass<T>)+198] (should have been resolved before IL gen)");
				long value2 = -value;
				InvokeEventChange(id, value2);
				return;
			}
			return;
		}
		while (CollectionsValue != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x600016D")]
	[Address(RVA = "0x11FAB28", Offset = "0x11FAB28", Length = "0xBC")]
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

	[Token(Token = "0x600016E")]
	[Address(RVA = "0x11FABE4", Offset = "0x11FABE4", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = UserResourceItem`1<T>::GetItemById(this, id);\n\tv9 = v6 == 0;\n\tif (v9) goto L_0013;\n\tv12 = *([v6 @ X0_v1 (T)+28]);\n\treturnVal1 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(&v12 @ V1_v2);\nL_0013:\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override long GetValue(int id)
	{
		//IL_0025: Expected I8, but got O
		//IL_0043: Expected O, but got I
		//IL_004c: Expected O, but got Ref
		T itemById = GetItemById(id);
		bool flag = itemById == null;
		long result = (long)itemById;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ X0_v1 (T)+28]");
			object obj = 0;
			result = (ObscuredLong)(&obj);
		}
		return result;
	}

	[Token(Token = "0x600016F")]
	[Address(RVA = "0x11FAC2C", Offset = "0x11FAC2C", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv166 = this.itemCollections;\nL_0019:\n\tv25 = v126 >= v166._size;\n\tif (v25) goto L_003F;\n\tv138 = System.Collections.Generic.List`1<T>::get_Item(v166, v126);\n\tv111 = *([v138 @ X0_v8 (T)+14]);\n\tv264 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v111 @ V0_v4);\n\tv87 = v264 == id;\n\tif (v87) goto L_0048;\n\tv166 = this.itemCollections;\n\tv126 = v126 + 1;\n\tv266 = this.itemCollections == 0;\n\tv134 = ~v266;\n\tif (v134) goto L_0019;\n\tgoto L_0073;\nL_003F:\n\tv176 = UserResourceItem`1::AddValue(this, id, value);\n\tgoto L_0072;\nL_0048:\n\tv270 = System.Collections.Generic.List`1<T>::get_Item(this.itemCollections, v126);\n\tv141 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(value);\n\t*([v270 @ X0_v12 (T)+48]) = v141.fakeValueActive;\n\t*([v270 @ X0_v12 (T)+38]) = v141.inited;\n\t*([v270 @ X0_v12 (T)+28]) = v141.currentCryptoKey;\n\tUserResource::InvokeEventChange(this, id, value);\nL_0072:\n\treturn;\nL_0073:\n\tthrow System.NullReferenceException;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void AddOrOverrideValue(int id, long value)
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X0_v8 (T)+14]");
				object obj = 0;
				int num2 = (ObscuredInt)(&obj);
				if (num2 != id)
				{
					collectionsValue = CollectionsValue;
					num++;
					continue;
				}
				T val2 = CollectionsValue[num];
				ObscuredLong obscuredLong = value;
				_ = obscuredLong.fakeValueActive;
				_ = obscuredLong.inited;
				_ = obscuredLong.currentCryptoKey;
				InvokeEventChange(id, value);
				return;
			}
			((UserResourceItem<>)(object)this).AddValue(id, value);
			return;
		}
		while (CollectionsValue != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000170")]
	[Address(RVA = "0x11FAD54", Offset = "0x11FAD54", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUserResourceInventory`1<T>::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UserResourceItem()
	{
	}
}
