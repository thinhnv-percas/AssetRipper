using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using TMPro;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts
{
	[Token(Token = "0x200021F")]
	public class GarageMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400069A")]
		[FieldOffset(Offset = "0x20")]
		private TextMeshPro m_counterText;

		[SerializeField]
		[Token(Token = "0x400069B")]
		[FieldOffset(Offset = "0x28")]
		internal Animator m_animator;

		[SerializeField]
		[Token(Token = "0x400069C")]
		[FieldOffset(Offset = "0x30")]
		private string m_openAnim;

		[SerializeField]
		[Token(Token = "0x400069D")]
		[FieldOffset(Offset = "0x38")]
		internal string m_closedIdleAnim;

		[SerializeField]
		[Token(Token = "0x400069E")]
		[FieldOffset(Offset = "0x40")]
		private float m_openAnimDuration;

		[SerializeField]
		[Token(Token = "0x400069F")]
		[FieldOffset(Offset = "0x48")]
		private string m_rejectAnim;

		[Header("Hit VFX")]
		[SerializeField]
		[Token(Token = "0x40006A0")]
		[FieldOffset(Offset = "0x50")]
		private GameObject m_hitVfxPrefab;

		[SerializeField]
		[Token(Token = "0x40006A1")]
		[FieldOffset(Offset = "0x58")]
		private GameObject m_lastHitVfxPrefab;

		[Tooltip("Parent transform for hit VFX. Spawned instances inherit the prefab's root local pose. The hit instance is cached and replayed; last-hit spawns fresh (only fires once).")]
		[SerializeField]
		[Token(Token = "0x40006A2")]
		[FieldOffset(Offset = "0x60")]
		private Transform m_vfxParent;

		[Header("Counter Punch")]
		[SerializeField]
		[Token(Token = "0x40006A3")]
		[FieldOffset(Offset = "0x68")]
		private ShakeSettings m_counterPunchSettings;

		[Token(Token = "0x40006A4")]
		[FieldOffset(Offset = "0xA8")]
		private GameObject _hitVfxInstance;

		[Token(Token = "0x40006A5")]
		[FieldOffset(Offset = "0xB0")]
		private ParticleSystem[] _hitVfxSystems;

		[Token(Token = "0x40006A6")]
		[FieldOffset(Offset = "0xB8")]
		internal IVfxPool _vfxPool;

		[Token(Token = "0x40006A7")]
		[FieldOffset(Offset = "0xC0")]
		private int _lastCounter;

		[Token(Token = "0x40006A8")]
		[FieldOffset(Offset = "0xC8")]
		private Tween _counterPunchTween;

		[Token(Token = "0x40006A9")]
		[FieldOffset(Offset = "0xD8")]
		private Quaternion _counterTextBaseRotation;

		[Token(Token = "0x170000BF")]
		public float OpenAnimDuration
		{
			[Token(Token = "0x6000965")]
			[Address(RVA = "0x3E92EC0", Offset = "0x3E92EC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.OpenAnimDuration;\n")]
			get
			{
				return m_openAnimDuration;
			}
		}

		[Token(Token = "0x6000966")]
		[Address(RVA = "0x3E92EC8", Offset = "0x3E92EC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._vfxPool = vfxPool;\n\treturn;\n")]
		public void Init(IVfxPool vfxPool)
		{
			_vfxPool = vfxPool;
		}

		[Token(Token = "0x6000967")]
		[Address(RVA = "0x3E92ED0", Offset = "0x3E92ED0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_animator, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0044;\n\treturn;\nL_0044:\n\tUnityEngine.Animator::Play(this.m_animator, this.m_closedIdleAnim);\n\treturn;\n")]
		public void PlayClosedIdle()
		{
			if (!(m_animator == null))
			{
				m_animator.Play(m_closedIdleAnim);
			}
		}

		[Token(Token = "0x6000968")]
		[Address(RVA = "0x3E92F8C", Offset = "0x3E92F8C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_animator, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0033;\n\tgoto L_003E;\nL_0033:\n\tv78 = System.String::IsNullOrEmpty(this.m_rejectAnim);\n\tv85 = v78 == 0;\n\tif (v85) goto L_004B;\nL_003E:\n\treturn;\nL_004B:\n\tUnityEngine.Animator::Play(this.m_animator, this.m_rejectAnim);\n\treturn;\n")]
		public void PlayRejectAnim()
		{
			if (!(m_animator == null) && !string.IsNullOrEmpty(m_rejectAnim))
			{
				m_animator.Play(m_rejectAnim);
			}
		}

		[Token(Token = "0x6000969")]
		[Address(RVA = "0x3E9305C", Offset = "0x3E9305C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv55.onComplete = onComplete;\n\tgoto L_003E;\nL_003E:\n\tv97 = UnityEngine.Object::op_Inequality(this.m_animator, 0);\n\tv152 = ~v97;\n\tv153 = ~v152;\n\tif (v153) goto L_004D;\n\tgoto L_0055;\nL_004D:\n\t;\n\tUnityEngine.Animator::Play(this.m_animator, this.m_openAnim);\nL_0055:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::ScaleDownCounter(this, 0f, 0.2f);\n\tv133 = v55.onComplete == 0;\n\tif (v133) goto L_0085;\n\tv174 = new System.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono>();\n\tSystem.Action`1<_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono>::.ctor(v174, v55, Il2CppMethodInfo);\n\tv130 = PrimeTween.Tween::Delay(this, this.OpenAnimDuration, v174, 0, 1);\n\treturn;\nL_0085:\n\treturn;\nL_0028:\n\tv55 = new _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v55);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayOpenAnim(Action onComplete = null)
		{
			if (m_animator != null)
			{
				m_animator.Play(m_openAnim);
			}
			ScaleDownCounter(0f, 0.2f);
			if (onComplete != null)
			{
				Action<GarageMono> onComplete2 = delegate
				{
					onComplete();
				};
				Tween tween = Tween.Delay(this, OpenAnimDuration, onComplete2);
			}
		}

		[Token(Token = "0x600096A")]
		[Address(RVA = "0x3E932FC", Offset = "0x3E932FC", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.m_counterText, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_003C;\n\treturn;\nL_003C:\n\tv93 = System.Int32::ToString(&v91 @ stack_-34_v2 (System.Int32));\n\tv194 = TMPro.TMP_Text::set_text(this.m_counterText, v93);\n\tv196 = this._lastCounter & 0x80000000;\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tv179 = v91;\n\tif (v198) goto L_0086;\n\tv203 = v91 >= this._lastCounter;\n\tv179 = v91;\n\tif (v203) goto L_0086;\n\tv235 = PrimeTween.Tween::get_isAlive(&this._counterPunchTween (PrimeTween.Tween));\n\tv236 = ~v235;\n\tif (v236) goto L_0062;\n\tPrimeTween.Tween::Complete(&this._counterPunchTween (PrimeTween.Tween));\nL_0062:\n\tv217 = TMPro.TextMeshPro::get_transform(this.m_counterText);\n\tv202 = UnityEngine.Transform::get_localRotation(v217);\n\tthis._counterTextBaseRotation.x = v202;\n\tthis._counterTextBaseRotation.y = v202.y;\n\tthis._counterTextBaseRotation.z = v202.z;\n\tthis._counterTextBaseRotation.w = v202.w;\n\tv241 = TMPro.TextMeshPro::get_transform(this.m_counterText);\n\tv226 = this.m_counterPunchSettings;\n\tv245 = PrimeTween.Tween::PunchLocalRotation(v241, &v226 @ stack_-80_v2 (PrimeTween.ShakeSettings));\n\tthis._counterPunchTween.tween = &v226 @ stack_-80_v2 (PrimeTween.ShakeSettings);\n\tthis._counterPunchTween.id = v245;\n\tv179 = v91;\nL_0086:\n\tthis._lastCounter = v179;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetCounter(int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageMono::SetCounter");
		}

		[Token(Token = "0x600096B")]
		[Address(RVA = "0x3E93208", Offset = "0x3E93208", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv61 = UnityEngine.Object::op_Equality(this.m_counterText, 0);\n\tv70 = v61 == 0;\n\tif (v70) goto L_0042;\n\treturn;\nL_0042:\n\tv140 = TMPro.TextMeshPro::get_transform(this.m_counterText);\n\tv123 = PrimeTween.Tween::Scale(v140, 0f, duration, 0, 1, 0, delay, 0f, 0);\n\treturn;\n")]
		public void ScaleDownCounter(float delay, float duration)
		{
			if (!(m_counterText == null))
			{
				Transform target = m_counterText.transform;
				Tween tween = Tween.Scale(target, 0f, duration, default(Ease), 1, default(CycleMode), delay);
			}
		}

		[Token(Token = "0x600096C")]
		[Address(RVA = "0x3E9348C", Offset = "0x3E9348C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v13, visible);\n\treturn;\n")]
		public void SetVisible(bool visible)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(visible);
		}

		[Token(Token = "0x600096D")]
		[Address(RVA = "0x3E934C0", Offset = "0x3E934C0", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tv72 = UnityEngine.Object::op_Equality(this.m_vfxParent, 0);\n\tv82 = v72 == 0;\n\tif (v82) goto L_004A;\n\tgoto L_0079;\nL_004A:\n\tv107 = newHp < 1;\n\tif (v107) goto L_0062;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.UnityBindings.Scripts.GarageMono::PlayCachedHitVfx(this);\n\treturn;\nL_0062:\n\tgoto L_0066;\nL_0066:\n\tv137 = UnityEngine.Object::op_Equality(this.m_lastHitVfxPrefab, 0);\n\tv140 = v137 == 0;\n\tif (v140) goto L_0086;\nL_0079:\n\treturn;\nL_0086:\n\tv269 = this._vfxPool == 0;\n\tif (v269) goto L_00D7;\n\tVector3_arg = UnityEngine.Transform::get_position(this.m_vfxParent);\n\tv316 = UnityEngine.Transform::get_rotation(this.m_vfxParent);\n\tgoto L_00F8;\nL_00D7:\n\tv265 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(this.m_lastHitVfxPrefab, this.m_vfxParent);\n\treturn;\nL_00F8:\n\tinterfaceTailCallResult = _game.CoreSystem.Pooling.IVfxPool::Rent(this._vfxPool, this.m_lastHitVfxPrefab, Vector3_arg, v316, this.m_vfxParent);\n\treturn;\n")]
		public void PlayHitVfx(int newHp)
		{
			if (m_vfxParent == null)
			{
				return;
			}
			if (newHp >= 1)
			{
				PlayCachedHitVfx();
			}
			else if (!(m_lastHitVfxPrefab == null))
			{
				if (_vfxPool != null)
				{
					Vector3 position = m_vfxParent.position;
					Quaternion rotation = m_vfxParent.rotation;
					GameObject gameObject = _vfxPool.Rent(m_lastHitVfxPrefab, position, rotation, m_vfxParent);
				}
				else
				{
					GameObject gameObject2 = VisualHandlerUtility.Instantiate(m_lastHitVfxPrefab, m_vfxParent);
				}
			}
		}

		[Token(Token = "0x600096E")]
		[Address(RVA = "0x3E93720", Offset = "0x3E93720", Length = "0x420")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tgoto L_0022;\nL_0022:\n\tv75 = UnityEngine.Object::op_Equality(this.m_hitVfxPrefab, 0);\n\tv85 = v75 == 0;\n\tif (v85) goto L_004D;\n\tgoto L_0170;\nL_004D:\n\tgoto L_0051;\nL_0051:\n\tv289 = UnityEngine.Object::op_Equality(this._hitVfxInstance, 0);\n\tv373 = ~v289;\n\tv374 = ~v373;\n\tif (v374) goto L_0060;\n\tgoto L_00E5;\nL_0060:\n\tv388 = this._vfxPool == 0;\n\tif (v388) goto L_00A2;\n\tVector3_arg = UnityEngine.Transform::get_position(this.m_vfxParent);\n\tv575 = UnityEngine.Transform::get_rotation(this.m_vfxParent);\n\tgoto L_00BE;\nL_00A2:\n\tv466 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(this.m_hitVfxPrefab, this.m_vfxParent);\n\tthis._hitVfxInstance = v466;\nL_FFFFFFFF:\n\tv583 = this._hitVfxInstance;\n\tgoto L_00E1;\nL_00CA:\n\tv712 = UnityEngine.Object::op_Inequality(this._hitVfxInstance, 0);\n\tv717 = ~v712;\n\tv718 = ~v717;\nL_FFFFFFFF:\n\tv522 = 0;\n\tif (v718) goto L_012E;\n\tgoto L_00D6;\nL_00D6:\n\tv749 = UnityEngine.Object::op_Inequality(v522, 0);\n\tv760 = ~v749;\n\tv761 = ~v760;\n\tif (v761) goto L_013E;\nL_FFFFFFFF:\n\tv583 = this._hitVfxInstance;\n\tgoto L_00E1;\nL_00E1:\n\tv453 = UnityEngine.Object::op_Inequality(v583, 0);\n\tv612 = ~v453;\n\tv456 = ~v612;\n\tif (v456) goto L_0155;\nL_00E5:\n\tv267 = this._hitVfxSystems;\n\tv262 = this._hitVfxSystems == 0;\n\tif (v262) goto L_0170;\nL_FFFFFFFF:\n\tv247 = 0;\n\tgoto L_00EE;\nL_00EA:\n\tv247 = v247 + 1;\n\tv267 = this._hitVfxSystems;\nL_00EE:\n\t;\n\tv141 = v247 >= v267.Length;\n\tif (v141) goto L_0170;\n\tgoto L_0104;\nL_0104:\n\tv594 = UnityEngine.Object::op_Equality(v267[v247 @ X21_v7 (System.Int32)], 0);\n\tv614 = v594 == 0;\n\tv615 = ~v614;\n\tif (v615) goto L_00EA;\n\tgoto L_0118;\nL_0118:\n\tUnityEngine.ParticleSystem::Clear(v267[v247 @ X21_v7 (System.Int32)], 1);\n\tUnityEngine.ParticleSystem::Play(v267[v247 @ X21_v7 (System.Int32)], 1);\n\tgoto L_00EA;\nL_012E:\n\tv759 = UnityEngine.GameObject::GetComponent(this._hitVfxInstance);\nL_FFFFFFFF:\n\tv522 = v759;\n\tgoto L_00D6;\nL_013E:\n\t*([v522 @ X21_v15 (UnityEngine.Object)+30]) = 0;\nL_FFFFFFFF:\n\tv583 = this._hitVfxInstance;\n\tgoto L_00E1;\nL_0155:\n\tv683 = UnityEngine.GameObject::GetComponentsInChildren(this._hitVfxInstance, 1);\n\tthis._hitVfxSystems = v683;\n\tv267 = this._hitVfxSystems;\n\tv709 = this._hitVfxSystems == 0;\n\tv261 = ~v709;\n\tif (v261) goto L_FFFFFFFF;\nL_0170:\n\treturn;\nL_00BE:\n\tv698 = _game.CoreSystem.Pooling.IVfxPool::Rent(this._vfxPool, this.m_hitVfxPrefab, Vector3_arg, v575, this.m_vfxParent);\n\tthis._hitVfxInstance = v698;\n\tgoto L_00CA;\n")]
		private void PlayCachedHitVfx()
		{
			if (m_hitVfxPrefab == null)
			{
				return;
			}
			ParticleSystem[] hitVfxSystems;
			if (_hitVfxInstance == null)
			{
				UnityEngine.Object hitVfxInstance2;
				if (_vfxPool != null)
				{
					Vector3 position = m_vfxParent.position;
					Quaternion rotation = m_vfxParent.rotation;
					GameObject hitVfxInstance = _vfxPool.Rent(m_hitVfxPrefab, position, rotation, m_vfxParent);
					_hitVfxInstance = hitVfxInstance;
					bool flag = _hitVfxInstance != null;
					bool flag2 = !flag;
					bool flag3 = !flag2;
					UnityEngine.Object obj = null;
					if (flag3)
					{
						PooledVfxBehaviour component = _hitVfxInstance.GetComponent<PooledVfxBehaviour>();
						obj = component;
					}
					if (!(obj != null))
					{
						hitVfxInstance2 = _hitVfxInstance;
					}
					else
					{
						_ = 0;
						hitVfxInstance2 = _hitVfxInstance;
					}
				}
				else
				{
					GameObject hitVfxInstance3 = VisualHandlerUtility.Instantiate(m_hitVfxPrefab, m_vfxParent);
					_hitVfxInstance = hitVfxInstance3;
					hitVfxInstance2 = _hitVfxInstance;
				}
				if (hitVfxInstance2 != null)
				{
					ParticleSystem[] componentsInChildren = _hitVfxInstance.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
					_hitVfxSystems = componentsInChildren;
					hitVfxSystems = _hitVfxSystems;
					if (_hitVfxSystems == null)
					{
						return;
					}
					goto IL_01c6;
				}
			}
			hitVfxSystems = _hitVfxSystems;
			if (_hitVfxSystems != null)
			{
				goto IL_01c6;
			}
			return;
			IL_01c6:
			int num = 0;
			while (num < hitVfxSystems.Length)
			{
				if (!(hitVfxSystems[num] == null))
				{
					hitVfxSystems[num].Clear(withChildren: true);
					hitVfxSystems[num].Play(withChildren: true);
				}
				num++;
				hitVfxSystems = _hitVfxSystems;
			}
		}

		[Token(Token = "0x600096F")]
		[Address(RVA = "0x3E93B40", Offset = "0x3E93B40", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv85 = this + 0xA8;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Inequality(this._hitVfxInstance, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tgoto L_006A;\nL_0037:\n\tv87 = this._vfxPool == 0;\n\tif (v87) goto L_006A;\n\tgoto L_0069;\nL_006A:\n\tthis._hitVfxInstance = 0;\n\tthis._hitVfxSystems = 0;\n\treturn;\nL_0069:\n\t_game.CoreSystem.Pooling.IVfxPool::Return(this._vfxPool, *([v85 @ X20_v4]), 0f);\n")]
		private void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageMono::OnDestroy");
		}

		[Token(Token = "0x6000970")]
		[Address(RVA = "0x3E93C84", Offset = "0x3E93C84", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastCounter = -1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GarageMono()
		{
			_lastCounter = -1;
		}
	}
}
