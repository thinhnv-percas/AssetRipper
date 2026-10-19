using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001E6")]
	public class KeyMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400060E")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_keyModel;

		[SerializeField]
		[Token(Token = "0x400060F")]
		[FieldOffset(Offset = "0x28")]
		private List<Pair<GameColor, Color>> m_keyParticleColors;

		[SerializeField]
		[Token(Token = "0x4000610")]
		[FieldOffset(Offset = "0x30")]
		private ParticleSystem m_particle;

		[Token(Token = "0x170000B9")]
		public Transform KeyModel
		{
			[Token(Token = "0x60008A0")]
			[Address(RVA = "0x3E8293C", Offset = "0x3E8293C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.KeyModel;\n")]
			get
			{
				return m_keyModel;
			}
		}

		[Token(Token = "0x60008A1")]
		[Address(RVA = "0x3E82944", Offset = "0x3E82944", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Awake()
		{
		}

		[Token(Token = "0x60008A2")]
		[Address(RVA = "0x3E82948", Offset = "0x3E82948", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_003B;\nL_003B:\n\tv174 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(v154._entityManager, v47.Entity);\n\tv198 = this.m_keyParticleColors;\n\tv157 = 0;\n\tv169 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(v198, v157);\n\tv120 = v169.Key;\n\tv88 = v169.Key == v174;\n\tif (v88) goto L_006D;\n\tv155 = v157 + 1;\n\tv311 = this.m_keyParticleColors == 0;\n\tv142 = ~v311;\n\tv198 = this.m_keyParticleColors;\n\tv157 = v155;\n\tif (v142) goto L_004D;\n\tthrow System.NullReferenceException;\nL_006D:\n\tv175 = UnityEngine.ParticleSystem::get_main(this.m_particle);\n\tv70 = v175;\n\tv179 = &v120 @ stack_-70_v7 (System.Int32Enum);\n\tv181 = System.Collections.Generic.List`1<Unco.Utils.Pair`2<System.Int32Enum, UnityEngine.Color>>::get_Item(this.m_keyParticleColors, v157);\n\t// 129 MakeStruct v221 @ AGG3E82A98_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), [v179 @ X8_v5+4], [v179 @ X8_v5+8], [v179 @ X8_v5+C], [v179 @ X8_v5+10]\n\tv222 = UnityEngine.ParticleSystem+MinMaxGradient::op_Implicit(v221);\n\tv235 = v222.m_Mode;\n\tUnityEngine.ParticleSystem+MainModule::set_startColor(&v70 @ stack_-38_v3 (UnityEngine.ParticleSystem+MainModule), &v235 @ stack_-B0_v2 (UnityEngine.ParticleSystemGradientMode));\nL_00A4:\n\treturn;\nL_0021:\n\tv47 = UnityEngine.Component::GetComponent(this);\nL_004D:\n\tv64 = v157 >= v198.Count;\n\tif (v64) goto L_00A4;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Start()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("KeyMono::Start");
		}

		[Token(Token = "0x60008A3")]
		[Address(RVA = "0x3E82AD8", Offset = "0x3E82AD8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnAnimationStart()
		{
		}

		[Token(Token = "0x60008A4")]
		[Address(RVA = "0x3E82ADC", Offset = "0x3E82ADC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnAnimationEnd()
		{
		}

		[Token(Token = "0x60008A5")]
		[Address(RVA = "0x3E82AE0", Offset = "0x3E82AE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public KeyMono()
		{
		}
	}
}
