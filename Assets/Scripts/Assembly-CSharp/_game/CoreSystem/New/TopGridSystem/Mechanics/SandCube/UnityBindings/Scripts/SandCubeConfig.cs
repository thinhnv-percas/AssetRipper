using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts
{
	[Token(Token = "0x200018A")]
	public class SandCubeConfig : ScriptableObject
	{
		[Token(Token = "0x40004DF")]
		[FieldOffset(Offset = "0x18")]
		public GameObject sandCubePrefab;

		[SerializeField]
		[Token(Token = "0x40004E0")]
		[FieldOffset(Offset = "0x20")]
		private List<JellyMaterialPair> m_jellyColors;

		[Tooltip("Material set applied to the open sand-cube model when revealing a hidden cube via booster preview.")]
		[Token(Token = "0x40004E1")]
		[FieldOffset(Offset = "0x28")]
		public JellyMaterialPair hiddenMaterials;

		[SerializeField]
		[Token(Token = "0x40004E2")]
		[FieldOffset(Offset = "0x48")]
		private float m_particleSpawnDelay;

		[Tooltip("One-shot VFX prefab spawned at the cube's world position when it breaks. Spawned to the scene root (no parent) so it survives the cube destroy.")]
		[Token(Token = "0x40004E3")]
		[FieldOffset(Offset = "0x50")]
		public GameObject explodeVfxPrefab;

		[Tooltip("GameColor -> tint Color applied to every ParticleSystem (root + children) of the instantiated explodeVfxPrefab so the burst matches the cube's color.")]
		[Token(Token = "0x40004E4")]
		[FieldOffset(Offset = "0x58")]
		public List<Pair<GameColor, Color>> particleTintPairs;

		[Token(Token = "0x170000A6")]
		public float ParticleSpawnDelay
		{
			[Token(Token = "0x6000754")]
			[Address(RVA = "0x3E67B40", Offset = "0x3E67B40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ParticleSpawnDelay;\n")]
			get
			{
				return m_particleSpawnDelay;
			}
		}

		[Token(Token = "0x6000755")]
		[Address(RVA = "0x3E67B48", Offset = "0x3E67B48", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\treturnVal1.gc = gc;\n\tv66 = this.m_jellyColors == 0;\n\tif (v66) goto L_004B;\n\tv75 = new System.Func`2<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.JellyMaterialPair, System.Boolean>();\n\tSystem.Func`2<_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.JellyMaterialPair, System.Boolean>::.ctor(v75, returnVal1, Il2CppMethodInfo);\n\treturnVal3 = System.Linq.Enumerable::FirstOrDefault(this.m_jellyColors, v75);\n\treturn returnVal3;\nL_004B:\n\treturnBuffer.gameColor = 0;\n\treturnBuffer.bottomMaterial = 0;\n\treturn returnBuffer;\nL_0024:\n\treturnVal1 = new _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeConfig+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(returnVal1);\n")]
		public JellyMaterialPair GetJellyMaterials(GameColor gc)
		{
			if (m_jellyColors != null)
			{
				Func<JellyMaterialPair, bool> predicate = delegate(JellyMaterialPair p)
				{
					int num = p.gameColor - gc;
					return num == 0;
				};
				return m_jellyColors.FirstOrDefault(predicate);
			}
			JellyMaterialPair result = default(JellyMaterialPair);
			result.gameColor = default(GameColor);
			result.bottomMaterial = null;
			return result;
		}

		[Token(Token = "0x6000756")]
		[Address(RVA = "0x3E67C58", Offset = "0x3E67C58", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv120 = this.particleTintPairs;\nL_FFFFFFFF:\n\tv129 = 0;\n\tv196 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(v120, v129);\n\tv109 = v109.m_value;\n\tv76 = v109.m_value == gc;\n\tif (v76) goto L_0051;\n\tv129 = v129 + 1;\n\tv198 = this.particleTintPairs == 0;\n\tv143 = ~v198;\nL_FFFFFFFF:\n\tv120 = this.particleTintPairs;\n\tif (v143) goto L_002B;\n\tthrow System.NullReferenceException;\nL_FFFFFFFF:\n\tv148 = 1f;\n\tgoto L_0065;\nL_0051:\n\tv180 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(this.particleTintPairs, v129);\nL_FFFFFFFF:\n\tv148 = v180.Value;\nL_001C:\n\tv50 = this.particleTintPairs == 0;\n\tif (v50) goto L_FFFFFFFF;\nL_002B:\n\tv57 = v129 >= v120.Count;\n\tif (v57) goto L_FFFFFFFF;\nL_0065:\n\treturn v148;\n")]
		public unsafe Color GetParticleTint(GameColor gc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeConfig::GetParticleTint");
			return default;
		}

		[Token(Token = "0x6000757")]
		[Address(RVA = "0x3E67D40", Offset = "0x3E67D40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public SandCubeConfig()
		{
		}
	}
}
