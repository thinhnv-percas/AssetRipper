using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;
using _game.CoreSystem.SandSystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts
{
	[CreateAssetMenu(menuName = "SandOut/LinkedCubeConfig", fileName = "LinkedCubeConfig")]
	[Token(Token = "0x20001CD")]
	public class LinkedCubeConfig : ScriptableObject
	{
		[Tooltip("Prefab instantiated between two linked cubes. Must have SandCubeBondVisual on the root.")]
		[Token(Token = "0x400058A")]
		[FieldOffset(Offset = "0x18")]
		public SandCubeBondVisual bondPrefab;

		[Tooltip("World-space Z offset applied ONLY when the linked cluster is in closed state.")]
		[Token(Token = "0x400058B")]
		[FieldOffset(Offset = "0x20")]
		public float zOffset;

		[Tooltip("GameColor -> bond tint mapping. Drives _ColorA / _ColorB on the bond's JellyDualColor material.")]
		[Token(Token = "0x400058C")]
		[FieldOffset(Offset = "0x28")]
		public List<Pair<GameColor, Color>> colorPairs;

		[Tooltip("Tint used for a bond endpoint while the corresponding cube has ColorHiddenComponent. Flips back to the cube's real color when the cover opens and ColorHidden is cleared.")]
		[Token(Token = "0x400058D")]
		[FieldOffset(Offset = "0x30")]
		public Color hiddenColor;

		[Token(Token = "0x400058E")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary<GameColor, Color> _lookup;

		[Token(Token = "0x600083F")]
		[Address(RVA = "0x3E778E0", Offset = "0x3E778E0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv54 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.Color>::TryGetValue(this._lookup, gameColor, &v52 @ stack_-40_v2 (UnityEngine.Color));\n\tv60 = ~v54;\n\treturnVal2 = 1f;\n\tif (v60) goto L_0033;\n\treturnVal2 = v52;\nL_0018:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.UnityBindings.Scripts.LinkedCubeConfig::EnsureLookup(this);\nL_0033:\n\treturn returnVal2;\n")]
		public Color GetColor(GameColor gameColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeConfig::GetColor");
			return default;
		}

		[Token(Token = "0x6000840")]
		[Address(RVA = "0x3E7797C", Offset = "0x3E7797C", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_0039:\n\treturn;\nL_003A:\n\tv155 = this.colorPairs;\n\tv156 = this.colorPairs == 0;\n\tif (v156) goto L_FFFFFFFF;\n\tv132 = v155.Count;\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv132 = 0;\n\tv140 = this.colorPairs == 0;\n\tif (v140) goto L_0039;\n\tv243 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::GetEnumerator(this.colorPairs);\n\tv124 = v243;\n\tv257 = this._lookup == 0;\n\tif (v257) goto L_0086;\n\t// 118 MakeStruct v246 @ AGG3E77ADC_2_v2 (UnityEngine.Color), typeof(UnityEngine.Color), [v243 @ X0_v7 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>)+14], [v243 @ X0_v7 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>)+18], [v243 @ X0_v7 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>)+1C], [v243 @ X0_v7 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>)+20]\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.Color>::set_Item(this._lookup, *([v243 @ X0_v7 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>)+10]), v246);\n\tgoto L_0069;\nL_007D:\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::Dispose(&v124 @ stack_-60_v2 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>));\n\treturn;\nL_0086:\n\tv263 = new System.NullReferenceException();\n\tgoto L_0094;\nL_0094:\n\tv56 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv177 = 0;\nL_FFFFFFFF:\n\tv209 = v263;\n\tif (v56) goto L_00A6;\n\tv267 = 0x8BF5BC4(v263, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv273 = 0x8BF5BF4(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::Dispose(&v45 @ stack_-60_v1 (System.Int32));\n\tv141 = *([v267 @ X0_v21]) == 0;\n\tif (v141) goto L_0039;\n\tv269 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv177 = *([v267 @ X0_v21]);\nL_FFFFFFFF:\n\tv209 = v269;\n\treturn;\nL_002B:\n\tv45 = 0;\n\tv50 = this._lookup == 0;\n\tif (v50) goto L_003A;\nL_0043:\n\tv222 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.Color>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, UnityEngine.Color>::.ctor(v222, v132);\n\tthis._lookup = v222;\nL_0069:\n\tv260 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::MoveNext(&v124 @ stack_-60_v2 (System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>+Enumerator<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>));\n\tv202 = v260 == 0;\n\tif (v202) goto L_007D;\nL_00A6:\n\tv272 = 0x318E610(&v177 @ stack_-70_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv275 = 0x8BF0368(v209, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = 0xA1B8(v275, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void EnsureLookup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeConfig::EnsureLookup");
		}

		[Token(Token = "0x6000841")]
		[Address(RVA = "0x3E77B74", Offset = "0x3E77B74", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lookup = 0;\n\treturn;\n")]
		private void OnValidate()
		{
			_lookup = null;
		}

		[Token(Token = "0x6000842")]
		[Address(RVA = "0x3E77B80", Offset = "0x3E77B80", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.zOffset = -0.08f;\n\tthis.hiddenColor = *([93094F0]);\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public LinkedCubeConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeConfig::.ctor");
		}
	}
}
