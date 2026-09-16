using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Token(Token = "0x2000033")]
public class ResourcesUtil : SingletonMonoDontDestroy<ResourcesUtil>
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x2000034")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x40000C7")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x40000C8")]
		public static Action<int, long> _003C_003E9__18_0;

		[Token(Token = "0x600015B")]
		[Address(RVA = "0xC0321C", Offset = "0xC0321C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = ResourcesUtil+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35643]) = v34;\nL_0012:\n\tv36 = new ResourcesUtil+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0xC03278", Offset = "0xC03278", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal void _003CInitResources_003Eb__18_0(int id, long value)
		{
			if (id == 0)
			{
				EventDispatcher instance = SingletonMono<EventDispatcher>.Instance;
				instance.PostEvent(EventID.ChangeGold);
			}
		}
	}

	[Token(Token = "0x40000C6")]
	[FieldOffset(Offset = "0x28")]
	private Dictionary<TypeResources, UserResource> resourceDict;

	[Token(Token = "0x6000148")]
	[Address(RVA = "0xC028B0", Offset = "0xC028B0", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, type, id, value, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A35639]) = v42;\nL_0016:\n\tv43 = type == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv49 = ResourcesUtil::GetResource(this, type);\n\tv97 = UserResource::GetValue(v49, id);\n\tv75 = v97 - value;\n\tv72 = v75 < 0;\n\tv66 = v97 ^ value;\n\tv63 = v97 ^ v75;\n\tv60 = v66 & v63;\n\tv57 = v60 < 0;\n\tv54 = v72 == v57;\n\tgoto L_0039;\nL_0039:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool CheckResource(TypeResources type, int id, long value)
	{
		//IL_005f: Expected I4, but got I8
		if (type != TypeResources.None)
		{
			UserResource resource = GetResource<UserResource>(type);
			long value2 = resource.GetValue(id);
			long num = value2 - value;
			bool flag = num < 0;
			long num2 = value2 ^ value;
			int num3 = (int)(value2 ^ num);
			long num4 = num2 & num3;
			bool flag2 = num4 < 0;
			return flag == flag2;
		}
		return true;
	}

	[Token(Token = "0x6000149")]
	[Address(RVA = "0xC02940", Offset = "0xC02940", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = ResourcesUtil::CheckResource(this, item.type, item.id, item.value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool CheckResource(Item item)
	{
		//IL_0021: Expected I8, but got I4
		return CheckResource(item.type, item.id, item.value);
	}

	[Token(Token = "0x600014A")]
	[Address(RVA = "0xC02960", Offset = "0xC02960", Length = "0x154")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, items, source, isBuy, isSave, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, items, source, isBuy, isSave, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, items, source, isBuy, isSave, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv89 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, items, source, isBuy, isSave, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A3563A]) = v39;\nL_001C:\n\tv40 = 0;\n\tv43 = items == 0;\n\tif (v43) goto L_0046;\n\tv56 = System.Collections.Generic.List`1<Item>::GetEnumerator(items);\nL_002D:\n\tv87 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v40 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv91 = v87 == 0;\n\tif (v91) goto L_003D;\n\tv71 = 0;\n\tResourcesUtil::AddResource(this, *([v71 @ X8_v9 (System.Int32)+10]), *([v71 @ X8_v9 (System.Int32)+14]), *([v71 @ X8_v9 (System.Int32)+18]), 1);\n\tgoto L_002D;\nL_003D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0044:\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_0046:\n\tv73 = new System.NullReferenceException();\n\tgoto L_0053;\n\tgoto L_0053;\nL_0053:\n\tv102 = Il2CppMethodInfo != 1;\n\tif (v102) goto L_0061;\n\tv106 = 0x1854E70(v73, Il2CppMethodInfo, v61, v59, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = 0x1854E80(v106, Il2CppMethodInfo, v61, v59, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv112 = *([v106 @ X0_v13]) == 0;\n\tif (v112) goto L_0044;\n\tthrow System.OutOfMemoryException;\nL_0061:\n\tgoto L_0065;\n\tX19 = X0;\nL_0065:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v40 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_006C;\n\tv179 = 0xBD3CD0(v73, *([v72 @ X21_v2 (Il2CppMethodInfo)]), v61, v59, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_006C:\n\tv182 = new System.OutOfMemoryException();\n\tv170 = 0x9DACB4(v182, *([v72 @ X21_v2 (Il2CppMethodInfo)]), v61, v59, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddResource(List<Item> items, string source = "", bool isBuy = false, bool isSave = true)
	{
		//IL_007e: Expected I8, but got I
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		bool flag = items == null;
		nint num = 0;
		if (!flag)
		{
			List<Item>.Enumerator enumerator2 = items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				int num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v9 (System.Int32)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v9 (System.Int32)+14]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X8_v9 (System.Int32)+18]");
				AddResource((TypeResources)num3, (int)num4, 0L, true);
				bool flag2 = true;
			}
			enumerator.Dispose();
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		if ((nint)0 == 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
			enumerator.Dispose();
			object obj = default(object);
			if (obj != null)
			{
				throw new OutOfMemoryException();
			}
		}
		else
		{
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}
	}

	[Token(Token = "0x600014B")]
	[Address(RVA = "0xC02ABC", Offset = "0xC02ABC", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tResourcesUtil::AddResource(this, item.type, item.id, item.value, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddResource(Item item, string source = "", bool isBuy = false, bool isSave = true)
	{
		//IL_0026: Expected I8, but got I4
		AddResource(item.type, item.id, item.value, true);
	}

	[Token(Token = "0x600014C")]
	[Address(RVA = "0xC02AB4", Offset = "0xC02AB4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tResourcesUtil::AddResource(this, resourcesType, id, value, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AddResource(TypeResources resourcesType, int id, long value, string source = "", bool isBuy = false, bool isSave = true)
	{
		AddResource(resourcesType, id, value, true);
	}

	[Token(Token = "0x600014D")]
	[Address(RVA = "0xC02AE0", Offset = "0xC02AE0", Length = "0x1A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, resourcesType, id, value, save, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, resourcesType, id, value, save, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv69 = SingletonMonoDontDestroy`1<GameManager>;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, resourcesType, id, value, save, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A3563B]) = v46;\nL_001E:\n\tv47 = &v70 @ stack_-90_v2 (System.Int64);\n\tv51 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(id);\n\tv70 = *([v47 @ X8_v3]);\n\tv67 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(value);\n\tv70 = v67.currentCryptoKey;\n\tResourcesUtil::AddResource(this, v172, &v70 @ stack_-90_v2 (System.Int64), &v70 @ stack_-90_v2 (System.Int64));\n\tv101 = save == 0;\n\tif (v101) goto L_0068;\n\tgoto L_005C;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v104, v99, v96, v97, v87, methodInfo, v33, v34, v82, v83, v85, v38, v39, v40, v41, v42);\nL_005C:\n\tv138 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv141 = v138 == 0;\n\tif (v141) goto L_0069;\n\tGameManager::SaveDataCreatePlayer(v138);\nL_0068:\n\treturn;\nL_0069:\n\tv186 = new System.NullReferenceException();\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\n\tgoto L_0078;\nL_0078:\n\tv110 = v172 != 1;\n\tif (v110) goto L_0093;\n\tv190 = 0x1854E70(v186, v172, &v70 @ stack_-90_v2 (System.Int64), &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\tv147 = *([v190 @ X0_v18]);\n\tv202 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v147 @ X8_v15]), &v70 @ stack_-90_v2 (System.Int64), &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\tv203 = v202 & 1;\n\tv142 = v203 == 0;\n\tif (v142) goto L_0089;\n\tv139 = 0x1854E80(v202, *([v147 @ X8_v15]), &v70 @ stack_-90_v2 (System.Int64), &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\tgoto L_0068;\nL_0089:\n\tv205 = 0x1854E90(8, *([v147 @ X8_v15]), &v70 @ stack_-90_v2 (System.Int64), &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\t*([v205 @ X0_v24]) = *([v190 @ X0_v18]);\n\tv172 = 0x185A000 + 0xF88;\n\tv207 = 0x1854EA0(v205, v172, 0, &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\tv194 = 0x1854E80(v207, v172, 0, &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\nL_0093:\n\tv198 = 0xBD3CD0(v182, v172, v170, &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\tv174 = 0x9DACB4(v198, v172, v170, &v70 @ stack_-90_v2 (System.Int64), Il2CppMethodInfo, methodInfo, v33, v34, v70, v67.inited, v70, v38, v39, v40, v41, v42);\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void AddResource(TypeResources resourcesType, int id, long value, bool save = true)
	{
		//IL_0169: Expected O, but got I8
		//IL_017e: Expected I8, but got O
		//IL_01aa: Expected O, but got Ref
		//IL_01aa: Expected O, but got Ref
		//IL_0084: Expected O, but got Ref
		long num = default(long);
		object obj = num;
		ObscuredInt obscuredInt = id;
		num = (long)obj;
		num = ((ObscuredLong)value).currentCryptoKey;
		TypeResources typeResources = default(TypeResources);
		AddResource<UserResource>(typeResources, (ObscuredInt)(&num), (ObscuredLong)(&num));
		if (!save)
		{
			return;
		}
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if ((object)instance != null)
		{
			instance.SaveDataCreatePlayer();
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		bool flag = typeResources != TypeResources.Resources;
		ObscuredInt obscuredInt2 = (ObscuredInt)(&num);
		NullReferenceException ex2 = ex;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
			object obj3 = default(object);
			object obj2 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			object obj4 = default(object);
			if ((int)((nint)obj4 & 1) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
			object obj5 = obj3;
			typeResources = (TypeResources)25538440;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
			obscuredInt2 = default(ObscuredInt);
			NullReferenceException ex3 = default(NullReferenceException);
			ex2 = ex3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
	}

	[Token(Token = "0x600014E")]
	[Address(RVA = "0xC02C88", Offset = "0xC02C88", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tResourcesUtil::SubResource(this, item.type, item.id, item.value, save);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SubResource(Item item, string source = "", string sourceId = "", bool save = true)
	{
		//IL_0025: Expected I8, but got I4
		SubResource(item.type, item.id, item.value, save);
	}

	[Token(Token = "0x600014F")]
	[Address(RVA = "0xC02CAC", Offset = "0xC02CAC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = save & 1;\n\tResourcesUtil::SubResource(this, type, idItemOrIdInventory, value, v0);\n\treturn;\n")]
	public void SubResource(TypeResources type, int idItemOrIdInventory, long value, string source = "", string sourceId = "", bool save = true)
	{
		bool save2 = (byte)((nuint)(save ? 1 : 0) & (nuint)1u) != 0;
		SubResource(type, idItemOrIdInventory, value, save2);
	}

	[Token(Token = "0x6000150")]
	[Address(RVA = "0xC02CB4", Offset = "0xC02CB4", Length = "0x164")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, type, id, value, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, type, id, value, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = SingletonMonoDontDestroy`1<GameManager>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, type, id, value, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A3563C]) = v50;\nL_0024:\n\tv54 = ResourcesUtil::GetResource(this, type);\n\tv66 = UserResource::SubValue(v54, id, v92);\n\tv68 = save == 0;\n\tif (v68) goto L_0048;\n\tgoto L_003B;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v72, v64, v65, v63, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_003B:\n\tv77 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv79 = v77 == 0;\n\tif (v79) goto L_004A;\n\tGameManager::SaveDataCreatePlayer(v77);\nL_0048:\n\treturn;\n\tv69 = new System.NullReferenceException();\nL_004A:\n\tv98 = new System.NullReferenceException();\n\tgoto L_0058;\n\tgoto L_0058;\n\tgoto L_0058;\nL_0058:\n\tv105 = type != 1;\n\tif (v105) goto L_007C;\n\tv166 = 0x1854E70(v98, type, Il2CppMethodInfo, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv157 = *([v166 @ X0_v11]);\n\tv179 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v157 @ X8_v5]), Il2CppMethodInfo, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv180 = v179 & 1;\n\tv143 = v180 == 0;\n\tif (v143) goto L_0072;\n\tv140 = 0x1854E80(v179, *([v157 @ X8_v5]), v133, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\nL_0072:\n\tv182 = 0x1854E90(8, *([v157 @ X8_v5]), Il2CppMethodInfo, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\t*([v182 @ X0_v17]) = *([v166 @ X0_v11]);\n\tv136 = 0x185A000 + 0xF88;\n\tv184 = 0x1854EA0(v182, v136, 0, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv170 = 0x1854E80(v184, v136, 0, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_007C:\n\tv174 = 0xBD3CD0(v155, v136, v133, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv141 = 0x9DACB4(v174, v136, v133, v92, save, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SubResource(TypeResources type, int id, long value, bool save = true)
	{
		//IL_0058: Expected O, but got I
		//IL_014e: Expected O, but got I4
		UserResource resource = GetResource<UserResource>(type);
		long valueSub = default(long);
		resource.SubValue(id, valueSub);
		if (!save)
		{
			return;
		}
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		bool flag = (object)instance == null;
		object obj = 0;
		int num = (int)type;
		if (!flag)
		{
			instance.SaveDataCreatePlayer();
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		bool flag2 = type != TypeResources.Resources;
		NullReferenceException ex2 = ex;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
			object obj3 = default(object);
			object obj2 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
			object obj4 = default(object);
			if ((int)((nint)obj4 & 1) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
			object obj5 = obj3;
			num = 25534464 + 3976;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
			obj = 0;
			NullReferenceException ex3 = default(NullReferenceException);
			ex2 = ex3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
	}

	[Token(Token = "0x6000151")]
	[Address(RVA = "0xC02E18", Offset = "0xC02E18", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, statType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3563D]) = v36;\nL_001E:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<TypeResources, UserResource>::ContainsKey(this.resourceDict, statType);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool ContainStat(TypeResources statType)
	{
		return resourceDict.ContainsKey(statType);
	}

	[Token(Token = "0x6000152")]
	[Address(RVA = "0xC9B064", Offset = "0xC9B064", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = 0xB3490C(methodInfo, resourceType, id, value, methodInfo, v27, v28, v29, v48, v31, v32, v33, v34, v35, v36, v37);\nL_0016:\n\tv45 = ResourcesUtil::GetResource(this, resourceType);\n\tv46 = v45 == 0;\n\tif (v46) goto L_0039;\n\tv48 = id.currentCryptoKey;\n\tv54 = CodeStage.AntiCheat.ObscuredTypes.ObscuredInt::op_Implicit(&v48 @ V0_v2 (System.Int32));\n\tv80 = value.currentCryptoKey;\n\tv97 = CodeStage.AntiCheat.ObscuredTypes.ObscuredLong::op_Implicit(&v80 @ V0_v3 (System.Int64));\n\tv87 = *([v45 @ X0_v3 (T)]);\n\t*([v87 @ X8_v6 (Il2CppClass<T>)+188])(v82, v45, v54, v97, *([v87 @ X8_v6 (Il2CppClass<T>)+190]), methodInfo, v27, v28, v29, v80, value.inited, v32, v33, v34, v35, v36, v37);\nL_0039:\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void AddResource<T>(TypeResources resourceType, ObscuredInt id, ObscuredLong value) where T : UserResource
	{
		//IL_002a: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		//IL_0055: Expected I, but got O
		T resource = GetResource<T>(resourceType);
		if (resource != null)
		{
			int currentCryptoKey = id.currentCryptoKey;
			int num = (ObscuredInt)(&currentCryptoKey);
			long currentCryptoKey2 = value.currentCryptoKey;
			long num2 = (ObscuredLong)(&currentCryptoKey2);
			nint num3 = (nint)resource;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ X8_v6 (Il2CppClass<T>)+188] (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x6000153")]
	[Address(RVA = "0xC9B180", Offset = "0xC9B180", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0017;\n\tv35 = 0xB3490C(methodInfo, resourceType, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0017:\n\tv42 = System.Activator::CreateInstance();\n\tSystem.Collections.Generic.Dictionary`2<TypeResources, UserResource>::Add(this.resourceDict, resourceType, v42);\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private T CreateResource<T>(TypeResources resourceType) where T : UserResource
	{
		object obj = Activator.CreateInstance<object>();
		resourceDict.Add(resourceType, (UserResource)obj);
		return (T)obj;
	}

	[Token(Token = "0x6000154")]
	[Address(RVA = "0xC9B11C", Offset = "0xC9B11C", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = 0xB3490C(methodInfo, resourceType, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0012:\n\treturnVal1 = ResourcesUtil::GetResource(this, resourceType);\n\tv39 = returnVal1 == 0;\n\tif (v39) goto L_0024;\n\treturn returnVal1;\nL_0024:\n\treturnVal2 = ResourcesUtil::CreateResource(this, resourceType);\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private T CreateOrGetResource<T>(TypeResources resourceType) where T : UserResource
	{
		T resource = GetResource<T>(resourceType);
		if (resource != null)
		{
			return resource;
		}
		return CreateResource<T>(resourceType);
	}

	[Token(Token = "0x6000155")]
	[Address(RVA = "0xC9B200", Offset = "0xC9B200", Length = "0xAC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv18 = 0xB3490C(methodInfo, type, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0011:\n\tv36 = ResourcesUtil::GetResource(this, type);\n\tgoto L_001E;\n\tv44 = v39;\n\tv45 = 0xB348B0(v44, v39, v35, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv47 = v45;\nL_001E:\n\t// 30 IsInst v50 @ X0_v6, typeof(T), v36 @ X0_v3 (UserResource)\n\tgoto L_002A;\n\tv58 = v53;\n\tv59 = 0xB348B0(v58, v46, v35, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv62 = v59;\nL_002A:\n\tv63 = v50 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\t// 46 IsInst returnVal1 @ X0_v8 (T), typeof(T), v50 @ X0_v6\n\tv74 = returnVal1 == 0;\n\tv72 = ~v74;\n\tif (v72) goto L_003B;\n\tthrow System.InvalidCastException;\nL_003B:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private T GetResource<T>(TypeResources type) where T : UserResource
	{
		UserResource resource = GetResource(type);
		object obj = resource as T;
		T val;
		if (obj != null)
		{
			val = obj as T;
			if (val == null)
			{
				throw new InvalidCastException();
			}
		}
		else
		{
			val = null;
		}
		return val;
	}

	[Token(Token = "0x6000156")]
	[Address(RVA = "0xC02E70", Offset = "0xC02E70", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, resourceType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3563E]) = v36;\nL_0014:\n\tv39 = ResourcesUtil::ContainStat(this, resourceType);\n\tv41 = v39 == 0;\n\tif (v41) goto L_0035;\n\tv53 = System.Collections.Generic.Dictionary`2<TypeResources, UserResource>::get_Item(this.resourceDict, resourceType);\n\tv53.type = resourceType;\n\treturnVal3 = System.Collections.Generic.Dictionary`2<TypeResources, UserResource>::get_Item(this.resourceDict, resourceType);\n\treturn returnVal3;\nL_0035:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private UserResource GetResource(TypeResources resourceType)
	{
		if (ContainStat(resourceType))
		{
			UserResource userResource = resourceDict[resourceType];
			userResource.type = resourceType;
			return resourceDict[resourceType];
		}
		return null;
	}

	[Token(Token = "0x6000157")]
	[Address(RVA = "0xC02F04", Offset = "0xC02F04", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, type, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3563F]) = v40;\nL_0018:\n\tv44 = ResourcesUtil::GetResource(this, 1);\n\tv46 = *([v44 @ X0_v3 (UserResourceItem`1<ItemResources>)]);\n\tv52 = *([v46 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1A8]);\n\tv53 = *([v46 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1B0]);\n\t// 37 IndirectJump v52 @ X3_v1, v44 @ X0_v3 (UserResourceItem`1<ItemResources>), v44 @ X0_v3 (UserResourceItem`1<ItemResources>), type @ X1 (TypeResourcesValue), v53 @ X2_v2, v52 @ X3_v1, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public long GetResource(TypeResourcesValue type)
	{
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_002d: Expected O, but got I
		while (true)
		{
			UserResourceItem<ItemResources> resource = GetResource<UserResourceItem<ItemResources>>(TypeResources.Resources);
			nint num = (nint)resource;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v52 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x6000158")]
	[Address(RVA = "0xC02F74", Offset = "0xC02F74", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35640]) = v37;\nL_0016:\n\tv41 = ResourcesUtil::GetResource(this, 1);\n\tv43 = *([v41 @ X0_v3 (UserResourceItem`1<ItemResources>)]);\n\tv47 = *([v43 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1A8]);\n\tv48 = *([v43 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1B0]);\n\t// 34 IndirectJump v47 @ X3_v1, v41 @ X0_v3 (UserResourceItem`1<ItemResources>), v41 @ X0_v3 (UserResourceItem`1<ItemResources>), 0, v48 @ X2_v2, v47 @ X3_v1, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public long GetResourceGold()
	{
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_002d: Expected O, but got I
		while (true)
		{
			UserResourceItem<ItemResources> resource = GetResource<UserResourceItem<ItemResources>>(TypeResources.Resources);
			nint num = (nint)resource;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v3 (Il2CppClass<UserResourceItem`1<ItemResources>>)+1B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ X3_v1 (should have been resolved before IL gen)");
		}
	}

	[Token(Token = "0x6000159")]
	[Address(RVA = "0xC02FD8", Offset = "0xC02FD8", Length = "0x190")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv22 = System.Action`2<System.Int32, System.Int64>;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv70 = SingletonMonoDontDestroy`1<GameManager>;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv91 = Il2CppMethodInfo;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv94 = ResourcesUtil+<>c;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35641]) = v42;\nL_002D:\n\tv48 = ResourcesUtil::CreateOrGetResource(this, 1);\n\tgoto L_0037;\n\tv60 = v52;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v60, v46, v43, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0037:\n\tv64 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv72 = v64.dataCreatePlayer;\n\tv87 = v72.inventoryNew;\n\tv123 = UserResourceItem`1::SetValue(v48, v87.resources);\n\tv81 = UserResourceInventory`1<T>::get_CollectionsValue(v48);\n\tgoto L_0059;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v127, v77, v75, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv133 = ResourcesUtil+<>c;\nL_0059:\n\tv147 = v134.<>9__18_0;\n\tv136 = v134.<>9__18_0 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0073;\n\tgoto L_0068;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v132, v77, v75, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv153 = ResourcesUtil+<>c;\nL_0068:\n\tv145 = new System.Action`2<System.Int32, System.Int64>();\n\tSystem.Action`2<System.Int32, System.Int64>::.ctor(v145, v155.<>9, Il2CppMethodInfo);\n\tv146.<>9__18_0 = v145;\nL_0073:\n\tv48.eventChangeValue = v147;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void InitResources()
	{
		UserResourceItem<ItemResources> userResourceItem = CreateOrGetResource<UserResourceItem<ItemResources>>(TypeResources.Resources);
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		DataCreatePlayer dataCreatePlayer = instance.dataCreatePlayer;
		Inventory inventoryNew = dataCreatePlayer.inventoryNew;
		((UserResourceItem<>)(object)userResourceItem).SetValue((object)inventoryNew.resources);
		List<_00210> collectionsValue = ((UserResourceInventory<_00210>)(object)userResourceItem).CollectionsValue;
		Action<int, long> eventChangeValue = _003C_003Ec._003C_003E9__18_0;
		if (_003C_003Ec._003C_003E9__18_0 == null)
		{
			eventChangeValue = (_003C_003Ec._003C_003E9__18_0 = delegate(int id, long value)
			{
				if (id == 0)
				{
					EventDispatcher instance2 = SingletonMono<EventDispatcher>.Instance;
					instance2.PostEvent(EventID.ChangeGold);
				}
			});
		}
		userResourceItem.eventChangeValue = eventChangeValue;
	}

	[Token(Token = "0x600015A")]
	[Address(RVA = "0xC03168", Offset = "0xC03168", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = System.Collections.Generic.Dictionary`2<TypeResources, UserResource>;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv64 = SingletonMonoDontDestroy`1<ResourcesUtil>;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35642]) = v46;\nL_0025:\n\tv50 = new System.Collections.Generic.Dictionary`2<TypeResources, UserResource>();\n\tSystem.Collections.Generic.Dictionary`2<TypeResources, UserResource>::.ctor(v50);\n\tthis.resourceDict = v50;\n\tgoto L_0039;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v59, v54, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0039:\n\tSingletonMonoDontDestroy`1<ResourcesUtil>::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ResourcesUtil()
	{
		Dictionary<TypeResources, UserResource> dictionary = new Dictionary<TypeResources, UserResource>();
		resourceDict = dictionary;
		base._002Ector();
	}
}
