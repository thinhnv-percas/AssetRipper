using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000072")]
	internal static class ComponentTypeIndex<T> where T : struct
	{
		[Token(Token = "0x4000114")]
		public static readonly int Id;

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x715D2E0", Offset = "0x715D2E0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001D:\n\tv51 = _game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndexRegistry::Allocate();\n\tv53 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1>;\n\tv56 = *([v53 @ X0_v6 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1>)+135]) & 1;\n\tv57 = v56 == 0;\n\tif (v57) goto L_0036;\n\tv59 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv62 = *([v59 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv78 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v63) goto L_003F;\nL_002D:\n\tv71.Id = v51;\n\treturn;\nL_0036:\n\tv64 = 0x220C238(Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv82 = *([v64 @ X0_v9+C0]);\n\tv78 = *([v82 @ X8_v8+8]);\n\tv84 = *([v78 @ X0_v7 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv85 = v84 == 0;\n\tv68 = ~v85;\n\tif (v68) goto L_002D;\nL_003F:\n\tv81 = 0x220C238(v78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv95 = *([v81 @ X0_v8+B8]);\n\t*([v95 @ X8_v7]) = v51;\n\treturn;\nL_001A:\n\tgoto L_001D;\n")]
		static ComponentTypeIndex()
		{
			//IL_00af: Expected O, but got I
			//IL_011c: Expected O, but got I
			//IL_0124: Expected O, but got I4
			int num = ComponentTypeIndexRegistry.Allocate();
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v6 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1>)+135]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
				int num4 = (int)((nint)0 & (nint)1);
				bool flag = num4 == 0;
				nint num5 = 0;
				if (!flag)
				{
					goto IL_0086;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v9+C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v8+8]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X0_v7 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0086;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X0_v8+B8]");
			object obj2 = 0;
			obj2 = num;
			return;
			IL_0086:
			Id = num;
		}
	}
}
