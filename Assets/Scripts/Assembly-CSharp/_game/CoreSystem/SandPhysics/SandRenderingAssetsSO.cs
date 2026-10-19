using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000AB")]
	public class SandRenderingAssetsSO : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x18")]
		private Texture2D m_particleTexture;

		[SerializeField]
		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x20")]
		private Material m_particleMaterial;

		[SerializeField]
		[Token(Token = "0x400022F")]
		[FieldOffset(Offset = "0x28")]
		private float m_particleDepthZ;

		[SerializeField]
		[Token(Token = "0x4000230")]
		[FieldOffset(Offset = "0x30")]
		private List<Pair<GameColor, Color>> m_particleColors;

		[Token(Token = "0x1700007F")]
		public Texture2D ParticleTexture
		{
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0x3C7BFE0", Offset = "0x3C7BFE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ParticleTexture;\n")]
			get
			{
				return m_particleTexture;
			}
		}

		[Token(Token = "0x17000080")]
		public Material ParticleMaterial
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0x3C7BFE8", Offset = "0x3C7BFE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ParticleMaterial;\n")]
			get
			{
				return m_particleMaterial;
			}
		}

		[Token(Token = "0x17000081")]
		public float ParticleDepthZ
		{
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0x3C7BFF0", Offset = "0x3C7BFF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ParticleDepthZ;\n")]
			get
			{
				return m_particleDepthZ;
			}
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0x3C7BFF8", Offset = "0x3C7BFF8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv120 = this.m_particleColors;\nL_FFFFFFFF:\n\tv129 = 0;\n\tv196 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(v120, v129);\n\tv109 = v109.m_value;\n\tv76 = v109.m_value == gc;\n\tif (v76) goto L_0051;\n\tv129 = v129 + 1;\n\tv198 = this.m_particleColors == 0;\n\tv143 = ~v198;\nL_FFFFFFFF:\n\tv120 = this.m_particleColors;\n\tif (v143) goto L_002B;\n\tthrow System.NullReferenceException;\nL_FFFFFFFF:\n\tv148 = 1f;\n\tgoto L_0065;\nL_0051:\n\tv180 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(this.m_particleColors, v129);\nL_FFFFFFFF:\n\tv148 = v180.Value;\nL_001C:\n\tv50 = this.m_particleColors == 0;\n\tif (v50) goto L_FFFFFFFF;\nL_002B:\n\tv57 = v129 >= v120.Count;\n\tif (v57) goto L_FFFFFFFF;\nL_0065:\n\treturn v148;\n")]
		public unsafe Color GetParticleColor(GameColor gc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandRenderingAssetsSO::GetParticleColor");
			return default;
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0x3C7C0E0", Offset = "0x3C7C0E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public SandRenderingAssetsSO()
		{
		}
	}
}
