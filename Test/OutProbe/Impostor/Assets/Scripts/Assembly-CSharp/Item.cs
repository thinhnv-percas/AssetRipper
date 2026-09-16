using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000032")]
public class Item : ItemBase
{
	[Token(Token = "0x40000C5")]
	[FieldOffset(Offset = "0x18")]
	public int value;

	[Token(Token = "0x6000144")]
	[Address(RVA = "0xC02558", Offset = "0xC02558", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.type = 0xFFFFFFFF00000000;\n\tthis.value = 0;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Item()
	{
		//IL_0015: Expected I4, but got I8
		base._002Ector();
		type = TypeResources.None;
		value = 0;
	}

	[Token(Token = "0x6000145")]
	[Address(RVA = "0xC0257C", Offset = "0xC0257C", Length = "0x2BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv24 = System.Enum;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv47 = TypeResourcesValue;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = TypeResourcesValue;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv121 = TypeResources;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv167 = TypeResources;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv215 = System.Type;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v215, itemData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35638]) = v43;\nL_0026:\n\tSystem.Object::.ctor(this);\n\tv57 = System.String::Split(itemData, 0x3A, 0);\n\tgoto L_0044;\n\tv265 = \"il2cpp_codegen_runtime_class_init\"(v219, v53, v55, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0044:\n\tv269 = System.Type::GetTypeFromHandle(TypeResources);\n\tgoto L_0050;\n\tv283 = v114;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v283, v268, v55, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0050:\n\tv105 = System.Enum::Parse(v269, v57[0]);\n\tv170 = v170_asT == 0;\n\tif (v170) goto L_00E3;\n\tv154 = \"il2cpp_vm_object_unbox\"(v105, TypeResources, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tthis.type = *([v154 @ X0_v37]);\n\tv377 = *([v154 @ X0_v37]) != 1;\n\tif (v377) goto L_00C5;\n\tv118 = this + 0x14;\n\tv382 = System.Int32::TryParse(v57[1], v118);\n\tv393 = v382 == 0;\n\tv394 = ~v393;\n\tif (v394) goto L_00C8;\n\tgoto L_0093;\n\tv413 = \"il2cpp_codegen_runtime_class_init\"(v396, v381, v149, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0093:\n\tv155 = System.Type::GetTypeFromHandle(TypeResourcesValue);\n\tgoto L_00AC;\n\tv422 = \"il2cpp_codegen_runtime_class_init\"(v419, v152, v149, v56, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00AC:\n\tv106 = System.Enum::Parse(v155, v57[1]);\n\tv171 = v171_asT == 0;\n\tif (v171) goto L_00E3;\n\tv408 = \"il2cpp_vm_object_unbox\"(v106, TypeResourcesValue, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v118 @ X21_v10 (System.Int32&)]) = *([v408 @ X0_v52]);\n\tgoto L_00C8;\nL_00C5:\n\tv384 = System.Int32::Parse(v57[1]);\n\tthis.id = v384;\nL_00C8:\n\tv411 = v57.Length < 2;\n\tv242 = ~v411;\n\tv240 = v57.Length - 2;\n\tv236 = v240 == 0;\n\tv412 = ~v242;\n\tv226 = v412 | v236;\n\tif (v226) goto L_00E4;\n\tv351 = System.Int32::Parse(v57[2]);\nL_00D7:\n\tthis.value = v351;\n\treturn;\n\tv119 = new System.NullReferenceException();\n\tv165 = new System.IndexOutOfRangeException();\nL_00E3:\n\tv213 = new System.InvalidCastException();\nL_00E4:\n\tv264 = new System.IndexOutOfRangeException();\n\tgoto L_00F0;\nL_00F0:\n\tv282 = v291 != 1;\n\tif (v282) goto L_010C;\n\tv288 = 0x1854E70(v264, v291, v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv312 = *([v288 @ X0_v10]);\n\tv314 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v312 @ X8_v5]), v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv315 = v314 & 1;\n\tv296 = v315 == 0;\n\tif (v296) goto L_0102;\n\tv364 = 0x1854E80(v314, *([v312 @ X8_v5]), v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00D7;\nL_0102:\n\tv366 = 0x1854E90(8, *([v312 @ X8_v5]), v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\t*([v366 @ X0_v16]) = *([v288 @ X0_v10]);\n\tv291 = 0x185A000 + 0xF88;\n\tv380 = 0x1854EA0(v366, v291, 0, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv294 = 0x1854E80(v380, v291, 0, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_010C:\n\tv302 = 0xBD3CD0(v297, v291, v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv307 = 0x9DACB4(v302, v291, v289, v250, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 190 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe Item(string itemData)
	{
		//IL_006f: Expected I4, but got O
		//IL_00a5: Expected I4, but got O
		//IL_020e: Expected O, but got I4
		//IL_03b5: Expected O, but got I4
		//IL_03e5: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		//IL_034d: Expected O, but got I4
		//IL_0174: Expected I4, but got O
		//IL_018c: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_01a3: Expected I4, but got O
		//IL_01d1: Expected O, but got I4
		//IL_01df: Expected I4, but got O
		base._002Ector();
		string[] array = itemData.Split(':');
		object obj = Enum.Parse(typeof(TypeResources), array[0]);
		if ((int)((obj is TypeResources) ? obj : null) == 0)
		{
			goto IL_0243;
		}
		Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
		object obj2 = default(object);
		type = (TypeResources)obj2;
		object obj5;
		int num = default(int);
		if ((nint)obj2 == 1)
		{
			ref int reference = ref *(int*)((nint)this + 20);
			bool flag = int.TryParse(array[1], out reference);
			object obj3 = 0;
			num = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
			if (!flag)
			{
				object obj4 = Enum.Parse(typeof(TypeResourcesValue), array[1]);
				bool flag2 = (int)((obj4 is TypeResourcesValue) ? obj4 : null) == 0;
				obj5 = 0;
				obj3 = 0;
				num = (int)typeof(TypeResources);
				if (flag2)
				{
					goto IL_0243;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj6 = default(object);
				reference = ref *(int*)obj6;
				obj3 = 0;
				num = (int)typeof(TypeResourcesValue);
			}
		}
		else
		{
			id = int.Parse(array[1]);
			object obj3 = 0;
			num = 0;
		}
		bool flag3 = array.Length < 2;
		bool flag4 = !flag3;
		object obj7 = array.Length - 2;
		bool flag5 = obj7 == null;
		bool flag6 = !flag4;
		bool flag7 = flag6 || flag5;
		obj5 = 0;
		int num2;
		if (!flag7)
		{
			num2 = int.Parse(array[2]);
			goto IL_0238;
		}
		goto IL_0251;
		IL_0251:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		bool flag8 = num != 1;
		IndexOutOfRangeException ex2 = ex;
		if (!flag8)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
			object obj9 = default(object);
			object obj8 = obj9;
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			object obj10 = default(object);
			if ((int)((nint)obj10 & 1) != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				num2 = 0;
				goto IL_0238;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
			object obj11 = obj9;
			num = 25534464 + 3976;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
			object obj3 = 0;
			IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
			ex2 = ex3;
		}
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		return;
		IL_0243:
		InvalidCastException ex4 = new InvalidCastException();
		goto IL_0251;
		IL_0238:
		value = num2;
	}

	[Token(Token = "0x6000146")]
	[Address(RVA = "0xC02838", Offset = "0xC02838", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.type = item.type;\n\tthis.value = item.value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Item(Item item)
	{
		type = item.type;
		value = item.value;
	}

	[Token(Token = "0x6000147")]
	[Address(RVA = "0xC02874", Offset = "0xC02874", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.type = type;\n\tthis.id = id;\n\tthis.value = value;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Item(TypeResources type, int id, int value)
	{
		base.type = type;
		base.id = id;
		this.value = value;
	}
}
