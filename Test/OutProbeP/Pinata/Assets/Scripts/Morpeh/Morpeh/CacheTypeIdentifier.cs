using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections.LowLevel.Unsafe;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D478", Offset = "0x73D478")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D478", Offset = "0x73D478")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D478", Offset = "0x73D478")]
	[Token(Token = "0x2000012")]
	internal static class CacheTypeIdentifier<T> where T : struct, IComponent
	{
		[Token(Token = "0x4000032")]
		internal static CommonCacheTypeIdentifier.TypeInfo info;

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x1092ED4", Offset = "0x1092ED4", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ED8A78]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026A9C]) = v40;\nL_0014:\n\tv41 = Il2CppClass<Morpeh.CacheTypeIdentifier`1>;\n\tgoto L_0022;\n\tv47 = v41;\n\tv48 = 0x8907BC(v47, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv53 = Il2CppClass<Morpeh.CacheTypeIdentifier`1>;\n\tv51 = *([v53 @ X20_v8 (Il2CppClass<Morpeh.CacheTypeIdentifier`1>)+12E]);\nL_0022:\n\tv57 = *([v41 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1>)+12E]) & 1;\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002A;\n\tv61 = 0x8907BC(Il2CppClass<Morpeh.CacheTypeIdentifier`1>, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv65 = Unity.Collections.LowLevel.Unsafe.UnsafeUtility::SizeOf();\n\tv71 = new Morpeh.CommonCacheTypeIdentifier+TypeInfo();\n\tv74 = v65 - 1;\n\tv76 = v74 == 0;\n\tMorpeh.CommonCacheTypeIdentifier+TypeInfo::.ctor(v71, v76);\n\tgoto L_004C;\n\tv89 = v84;\n\tv90 = 0x8907BC(v89, v81, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004C:\n\tgoto L_0051;\n\tv98 = v93;\n\tv99 = 0x8907BC(v98, v81, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv101.info = v71;\n\tv103 = Morpeh.CommonCacheTypeIdentifier::GetID();\n\tgoto L_0062;\n\tv110 = v104;\n\tv111 = 0x8907BC(v110, v81, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0062:\n\tgoto L_006F;\n\tv119 = v114;\n\tv120 = 0x8907BC(v119, v81, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006F:\n\tMorpeh.CommonCacheTypeIdentifier+TypeInfo::SetID(v122.info, v103);\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CacheTypeIdentifier()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1>)+12E]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
			}
			int num = UnsafeUtility.SizeOf<T>();
			bool isMarker = default(bool);
			CommonCacheTypeIdentifier.TypeInfo typeInfo = new CommonCacheTypeIdentifier.TypeInfo(isMarker);
			int num2 = num - 1;
			isMarker = num2 == 0;
			info = typeInfo;
			int iD = CommonCacheTypeIdentifier.GetID();
			info.SetID(iD);
		}
	}
}
