using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using TMPro;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts
{
	[Token(Token = "0x2000150")]
	public class TunnelVisualMono : MonoBehaviour
	{
		[Token(Token = "0x4000441")]
		private static readonly Vector3 FIRE_VFX_LOCAL_POS;

		[Token(Token = "0x4000442")]
		private static readonly Vector3 FIRE_VFX_LOCAL_EULER;

		[SerializeField]
		[Token(Token = "0x4000443")]
		[FieldOffset(Offset = "0x20")]
		private TMP_Text m_queueCountText;

		[Header("Fire VFX")]
		[Tooltip("VFX played each time a cube is fired from this tunnel. Instance is cached and replayed.")]
		[SerializeField]
		[Token(Token = "0x4000444")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_fireVfxPrefab;

		[Tooltip("Parent transform for the fire VFX. The cached instance lives under here at a fixed local pose.")]
		[SerializeField]
		[Token(Token = "0x4000445")]
		[FieldOffset(Offset = "0x30")]
		private Transform m_particleParent;

		[Tooltip("Delay before the fire VFX plays, in seconds. Lets the cube visibly emerge from the tunnel mouth first.")]
		[SerializeField]
		[Token(Token = "0x4000446")]
		[FieldOffset(Offset = "0x38")]
		private float m_fireVfxDelay;

		[Token(Token = "0x4000447")]
		[FieldOffset(Offset = "0x40")]
		private GameObject _fireVfxInstance;

		[Token(Token = "0x4000448")]
		[FieldOffset(Offset = "0x48")]
		private ParticleSystem[] _fireVfxSystems;

		[Token(Token = "0x4000449")]
		[FieldOffset(Offset = "0x50")]
		internal IVfxPool _vfxPool;

		[Token(Token = "0x600068A")]
		[Address(RVA = "0x3DB841C", Offset = "0x3DB841C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._vfxPool = vfxPool;\n\treturn;\n")]
		public void Init(IVfxPool vfxPool)
		{
			_vfxPool = vfxPool;
		}

		[Token(Token = "0x600068B")]
		[Address(RVA = "0x3DB8424", Offset = "0x3DB8424", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = count;\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv57 = UnityEngine.Object::op_Equality(this.m_queueCountText, 0);\n\tv66 = v57 == 0;\n\tif (v66) goto L_003E;\nL_0025:\n\treturn;\nL_003E:\n\tv181 = UnityEngine.Component::get_gameObject(this.m_queueCountText);\n\tv206 = count < 0;\n\tv207 = count == 0;\n\tv209 = count ^ count;\n\tv210 = count & v209;\n\tv211 = v210 < 0;\n\tv212 = v206 == v211;\n\tv182 = ~v207;\n\tv183 = v212 & v182;\n\tv213 = UnityEngine.GameObject::get_activeSelf(v181);\n\tv188 = v183 == v213;\n\tif (v188) goto L_007A;\n\tv197 = UnityEngine.Component::get_gameObject(this.m_queueCountText);\n\tv229 = count < 0;\n\tv227 = count == 0;\n\tv223 = count ^ count;\n\tv221 = count & v223;\n\tv219 = v221 < 0;\n\tv240 = v229 == v219;\n\tv215 = ~v227;\n\tv217 = v240 & v215;\n\tUnityEngine.GameObject::SetActive(v197, v217);\nL_007A:\n\tv76 = count < 1;\n\tif (v76) goto L_0025;\n\tv198 = System.Int32::ToString(&v18 @ stack_-34_v1 (System.Int32));\n\tv161 = TMPro.TMP_Text::set_text(this.m_queueCountText, v198);\n\treturn;\n")]
		public virtual void UpdateQueueCount(int count)
		{
			int num = count;
			if (!(m_queueCountText == null))
			{
				GameObject gameObject = m_queueCountText.gameObject;
				bool flag = count < 0;
				bool flag2 = count == 0;
				int num2 = count ^ count;
				int num3 = count & num2;
				bool flag3 = num3 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				bool flag6 = flag4 && flag5;
				bool activeSelf = gameObject.activeSelf;
				if (flag6 != activeSelf)
				{
					GameObject gameObject2 = m_queueCountText.gameObject;
					bool flag7 = count < 0;
					bool flag8 = count == 0;
					int num4 = count ^ count;
					int num5 = count & num4;
					bool flag9 = num5 < 0;
					bool flag10 = flag7 == flag9;
					bool flag11 = !flag8;
					bool active = flag10 && flag11;
					gameObject2.SetActive(active);
				}
				if (count >= 1)
				{
					string text = num.ToString();
					m_queueCountText.text = text;
				}
			}
		}

		[Token(Token = "0x600068C")]
		[Address(RVA = "0x3DB8568", Offset = "0x3DB8568", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_fireVfxPrefab, 0);\n\tv69 = v59 == 0;\n\tif (v69) goto L_0040;\n\tgoto L_0051;\nL_0040:\n\tgoto L_0044;\nL_0044:\n\tv100 = UnityEngine.Object::op_Equality(this.m_particleParent, 0);\n\tv103 = v100 == 0;\n\tif (v103) goto L_005D;\nL_0051:\n\treturn;\nL_005D:\n\tv139 = this.m_fireVfxDelay == 0;\n\tv184 = this.m_fireVfxDelay < 0;\n\tv136 = ~v184;\n\tv185 = ~v136;\n\tv127 = v185 | v139;\n\tif (v127) goto L_008D;\n\tv191 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono>::.ctor(v191, this, Il2CppMethodInfo);\n\tv162 = PrimeTween.Tween::Delay(this, this.m_fireVfxDelay, v191, 0, 1);\n\treturn;\nL_008D:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.UnityBindings.Scripts.TunnelVisualMono::PlayFireVfxImmediate(this);\n\treturn;\n")]
		public void PlayFireVfx()
		{
			if (m_fireVfxPrefab == null || m_particleParent == null)
			{
				return;
			}
			bool flag = m_fireVfxDelay == 0f;
			bool flag2 = m_fireVfxDelay < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (!(flag4 || flag))
			{
				Action<TunnelVisualMono> onComplete = delegate
				{
					PlayFireVfx();
				};
				Tween tween = Tween.Delay(this, m_fireVfxDelay, onComplete);
			}
			else
			{
				PlayFireVfx();
			}
		}

		[Token(Token = "0x600068D")]
		[Address(RVA = "0x3DB86F0", Offset = "0x3DB86F0", Length = "0x454")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv107 = this + 0x40;\n\tgoto L_0023;\nL_0023:\n\tv78 = UnityEngine.Object::op_Equality(this._fireVfxInstance, 0);\n\tv90 = ~v78;\n\tv91 = ~v90;\n\tif (v91) goto L_0050;\n\tgoto L_00D6;\nL_0050:\n\tv111 = this._vfxPool == 0;\n\tif (v111) goto L_0092;\n\tVector3_arg = UnityEngine.Transform::get_position(this.m_particleParent);\n\tv589 = UnityEngine.Transform::get_rotation(this.m_particleParent);\n\tgoto L_00AE;\nL_0092:\n\tv241 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(this.m_fireVfxPrefab, this.m_particleParent);\n\t*([v107 @ X20_v9]) = v241;\n\tv213 = this._fireVfxInstance;\n\tgoto L_00D2;\nL_00BA:\n\tv723 = UnityEngine.Object::op_Inequality(*([v107 @ X20_v9]), 0);\n\tv735 = ~v723;\n\tv736 = ~v735;\nL_FFFFFFFF:\n\tv469 = 0;\n\tif (v736) goto L_011F;\n\tgoto L_00C6;\nL_00C6:\n\tv769 = UnityEngine.Object::op_Inequality(v469, 0);\n\tv784 = ~v769;\n\tv785 = ~v784;\n\tif (v785) goto L_012F;\n\tv213 = this._fireVfxInstance;\n\tgoto L_00D2;\nL_00D2:\n\tv225 = UnityEngine.Object::op_Inequality(v213, 0);\n\tv624 = ~v225;\n\tv228 = ~v624;\n\tif (v228) goto L_0141;\nL_00D6:\n\tv379 = this._fireVfxSystems;\n\tv235 = this._fireVfxSystems == 0;\n\tif (v235) goto L_0181;\nL_FFFFFFFF:\n\tv367 = 0;\n\tgoto L_00DF;\nL_00DB:\n\tv367 = v367 + 1;\n\tv379 = this._fireVfxSystems;\nL_00DF:\n\t;\n\tv335 = v367 >= v379.Length;\n\tif (v335) goto L_0181;\n\tgoto L_00F5;\nL_00F5:\n\tv608 = UnityEngine.Object::op_Equality(v379[v367 @ X21_v6 (System.Int32)], 0);\n\tv626 = v608 == 0;\n\tv627 = ~v626;\n\tif (v627) goto L_00DB;\n\tgoto L_0109;\nL_0109:\n\tUnityEngine.ParticleSystem::Clear(v379[v367 @ X21_v6 (System.Int32)], 1);\n\tUnityEngine.ParticleSystem::Play(v379[v367 @ X21_v6 (System.Int32)], 1);\n\tgoto L_00DB;\nL_011F:\n\tv779 = UnityEngine.GameObject::GetComponent(*([v107 @ X20_v9]));\nL_FFFFFFFF:\n\tv469 = v779;\n\tgoto L_00C6;\nL_012F:\n\t*([v469 @ X21_v16 (UnityEngine.Object)+30]) = 0;\n\tv213 = this._fireVfxInstance;\n\tgoto L_00D2;\nL_0141:\n\tv692 = UnityEngine.GameObject::get_transform(*([v107 @ X20_v9]));\n\tgoto L_0154;\nL_0154:\n\t// 340 MakeStruct v260 @ AGG3DB8AC8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v728.FIRE_VFX_LOCAL_POS (UnityEngine.Vector3), v728.FIRE_VFX_LOCAL_POS.y (System.Single), v728.FIRE_VFX_LOCAL_POS.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v692, v260);\n\t// 349 MakeStruct v257 @ AGG3DB8AE4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v512.FIRE_VFX_LOCAL_EULER (UnityEngine.Vector3), v512.FIRE_VFX_LOCAL_EULER.y (System.Single), v512.FIRE_VFX_LOCAL_EULER.z (System.Single)\n\tUnityEngine.Transform::set_localEulerAngles(v692, v257);\n\tv783 = UnityEngine.GameObject::GetComponentsInChildren(*([v107 @ X20_v9]), 1);\n\tthis._fireVfxSystems = v783;\n\tv379 = this._fireVfxSystems;\n\tv799 = this._fireVfxSystems == 0;\n\tv320 = ~v799;\n\tif (v320) goto L_FFFFFFFF;\nL_0181:\n\treturn;\nL_00AE:\n\tv707 = _game.CoreSystem.Pooling.IVfxPool::Rent(this._vfxPool, this.m_fireVfxPrefab, Vector3_arg, v589, this.m_particleParent);\n\t*([v107 @ X20_v9]) = v707;\n\tgoto L_00BA;\n")]
		private void PlayFireVfxImmediate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualMono::PlayFireVfxImmediate");
		}

		[Token(Token = "0x600068E")]
		[Address(RVA = "0x3DB8B44", Offset = "0x3DB8B44", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv85 = this + 0x40;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this._fireVfxInstance, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tgoto L_006A;\nL_0037:\n\tv87 = this._vfxPool == 0;\n\tif (v87) goto L_006A;\n\tgoto L_0069;\nL_006A:\n\tthis._fireVfxInstance = 0;\n\tthis._fireVfxSystems = 0;\n\treturn;\nL_0069:\n\t_game.CoreSystem.Pooling.IVfxPool::Return(this._vfxPool, *([v85 @ X20_v4]), 0f);\n")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualMono::OnDestroy");
		}

		[Token(Token = "0x600068F")]
		[Address(RVA = "0x3DB8C88", Offset = "0x3DB8C88", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_fireVfxDelay = 0.2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TunnelVisualMono()
		{
			m_fireVfxDelay = 0.2f;
		}

		[Token(Token = "0x6000690")]
		[Address(RVA = "0x3DB8C9C", Offset = "0x3DB8C9C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv40.FIRE_VFX_LOCAL_POS = *([9308170]);\n\tv40.FIRE_VFX_LOCAL_EULER.y = 5629500667133952d;\n\treturn;\n")]
		static TunnelVisualMono()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelVisualMono::.cctor");
		}
	}
}
