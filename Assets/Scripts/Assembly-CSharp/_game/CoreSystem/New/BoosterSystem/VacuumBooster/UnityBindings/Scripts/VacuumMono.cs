using System;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using _game.CoreSystem.MoldSystem;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts
{
	[Token(Token = "0x2000443")]
	public class VacuumMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000D4B")]
		[FieldOffset(Offset = "0x20")]
		private Renderer m_bodyRenderer;

		[SerializeField]
		[Token(Token = "0x4000D4C")]
		[FieldOffset(Offset = "0x28")]
		internal Animator m_animator;

		[SerializeField]
		[Token(Token = "0x4000D4D")]
		[FieldOffset(Offset = "0x30")]
		private string m_spawnAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D4E")]
		[FieldOffset(Offset = "0x38")]
		private string m_vacuumAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D4F")]
		[FieldOffset(Offset = "0x40")]
		internal string m_spitAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D50")]
		[FieldOffset(Offset = "0x48")]
		private string m_despawnAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D51")]
		[FieldOffset(Offset = "0x50")]
		private string m_idleAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D52")]
		[FieldOffset(Offset = "0x58")]
		private float m_spawnAnimDuration;

		[SerializeField]
		[Token(Token = "0x4000D53")]
		[FieldOffset(Offset = "0x60")]
		private string m_onlyFillAnimTriggerName;

		[SerializeField]
		[Token(Token = "0x4000D54")]
		[FieldOffset(Offset = "0x68")]
		private TweenSettings m_scaleUpTweenSettings;

		[SerializeField]
		[Token(Token = "0x4000D55")]
		[FieldOffset(Offset = "0x98")]
		private Transform m_mouthTransform;

		[Header("Tube Path")]
		[SerializeField]
		[Token(Token = "0x4000D56")]
		[FieldOffset(Offset = "0xA0")]
		private Transform[] m_tubePathPoints;

		[SerializeField]
		[Token(Token = "0x4000D57")]
		[FieldOffset(Offset = "0xA8")]
		private AnimationCurve m_tubeSpeedCurve;

		[SerializeField]
		[Token(Token = "0x4000D58")]
		[FieldOffset(Offset = "0xB0")]
		private Vector2 m_tubeSpeedRange;

		[SerializeField]
		[Token(Token = "0x4000D59")]
		[FieldOffset(Offset = "0xB8")]
		private float m_tubeRadius;

		[Header("Mouth Scale")]
		[SerializeField]
		[Token(Token = "0x4000D5A")]
		[FieldOffset(Offset = "0xBC")]
		internal Vector2 m_mouthScaleRange;

		[SerializeField]
		[Token(Token = "0x4000D5B")]
		[FieldOffset(Offset = "0xC4")]
		private float m_mouth3DAxisMultiplier;

		[SerializeField]
		[Token(Token = "0x4000D5C")]
		[FieldOffset(Offset = "0xC8")]
		private AnimationCurve m_mouthScaleCurve;

		[Header("Suction Field")]
		[SerializeField]
		[Token(Token = "0x4000D5D")]
		[FieldOffset(Offset = "0xD0")]
		private float m_suctionMinRadius;

		[SerializeField]
		[Token(Token = "0x4000D5E")]
		[FieldOffset(Offset = "0xD4")]
		private float m_suctionMaxRadius;

		[SerializeField]
		[Token(Token = "0x4000D5F")]
		[FieldOffset(Offset = "0xD8")]
		private AnimationCurve m_suctionRadiusCurve;

		[SerializeField]
		[Token(Token = "0x4000D60")]
		[FieldOffset(Offset = "0xE0")]
		private float m_suctionRadiusDuration;

		[SerializeField]
		[Token(Token = "0x4000D61")]
		[FieldOffset(Offset = "0xE8")]
		private AnimationCurve m_xyAttractionCurve;

		[SerializeField]
		[Token(Token = "0x4000D62")]
		[FieldOffset(Offset = "0xF0")]
		private AnimationCurve m_zRiseCurve;

		[Header("Bulb")]
		[SerializeField]
		[Token(Token = "0x4000D63")]
		[FieldOffset(Offset = "0xF8")]
		private Transform m_bulbCenter;

		[SerializeField]
		[Token(Token = "0x4000D64")]
		[FieldOffset(Offset = "0x100")]
		private float m_bulbRadius;

		[SerializeField]
		[Token(Token = "0x4000D65")]
		[FieldOffset(Offset = "0x104")]
		private float m_bulbSettleSpeed;

		[Header("Dispatch")]
		[SerializeField]
		[Token(Token = "0x4000D66")]
		[FieldOffset(Offset = "0x108")]
		private Transform m_dispatchMouthTransform;

		[SerializeField]
		[Token(Token = "0x4000D67")]
		[FieldOffset(Offset = "0x110")]
		private float m_dispatchRadius;

		[SerializeField]
		[Token(Token = "0x4000D68")]
		[FieldOffset(Offset = "0x114")]
		internal AbsorptionProfile m_dispatchAbsorptionProfile;

		[SerializeField]
		[Token(Token = "0x4000D69")]
		[FieldOffset(Offset = "0x130")]
		private float m_dispatchStaggerDuration;

		[SerializeField]
		[Token(Token = "0x4000D6A")]
		[FieldOffset(Offset = "0x134")]
		private float m_moldTransitionDelay;

		[SerializeField]
		[Token(Token = "0x4000D6B")]
		[FieldOffset(Offset = "0x138")]
		private Vector2 m_dispatchTubeSpeedRange;

		[SerializeField]
		[Token(Token = "0x4000D6C")]
		[FieldOffset(Offset = "0x140")]
		private AnimationCurve m_dispatchScaleDownCurve;

		[SerializeField]
		[Token(Token = "0x4000D6D")]
		[FieldOffset(Offset = "0x148")]
		private float m_mouthToDispatchDelay;

		[SerializeField]
		[Token(Token = "0x4000D6E")]
		[FieldOffset(Offset = "0x14C")]
		private float m_despawnAnimDuration;

		[SerializeField]
		[Token(Token = "0x4000D6F")]
		[FieldOffset(Offset = "0x150")]
		internal TweenSettings m_vacuumRotateSettings;

		[Header("Attraction Tuning")]
		[SerializeField]
		[Token(Token = "0x4000D70")]
		[FieldOffset(Offset = "0x180")]
		private float m_vacuumMaxSpeed;

		[SerializeField]
		[Token(Token = "0x4000D71")]
		[FieldOffset(Offset = "0x184")]
		private float m_arrivalRadius;

		[Header("VFX")]
		[Tooltip("Looping VFX played during the entire suck phase. Spawned once on suck start, destroyed on suck end. Parented under m_particleParent with SUCK_LOCAL_EULER.")]
		[SerializeField]
		[Token(Token = "0x4000D72")]
		[FieldOffset(Offset = "0x188")]
		private GameObject m_suckLoopVfxPrefab;

		[Tooltip("One-shot VFX spawned per spit event (per mold). Parented under m_particleParent with RELEASE_LOCAL_EULER. Fire-and-forget; assumes ParticleSystem stopAction=Destroy.")]
		[SerializeField]
		[Token(Token = "0x4000D73")]
		[FieldOffset(Offset = "0x190")]
		private GameObject m_releaseVfxPrefab;

		[Tooltip("Parent transform for both suck-loop and release VFX. Spawned instances inherit this transform's world pose and apply the hardcoded local pos/rot below.")]
		[SerializeField]
		[Token(Token = "0x4000D74")]
		[FieldOffset(Offset = "0x198")]
		private Transform m_particleParent;

		[Tooltip("Optional fade-out delay before the looping suck VFX is destroyed. 0 = instant destroy.")]
		[SerializeField]
		[Token(Token = "0x4000D75")]
		[FieldOffset(Offset = "0x1A0")]
		private float m_suckLoopVfxDestroyDelay;

		[Token(Token = "0x4000D76")]
		private static readonly Vector3 SUCK_LOCAL_POS;

		[Token(Token = "0x4000D77")]
		private static readonly Vector3 SUCK_LOCAL_EULER;

		[Token(Token = "0x4000D78")]
		private static readonly Vector3 RELEASE_LOCAL_POS;

		[Token(Token = "0x4000D79")]
		private static readonly Vector3 RELEASE_LOCAL_EULER;

		[Token(Token = "0x4000D7A")]
		[FieldOffset(Offset = "0x1A8")]
		private GameObject _activeSuckVfxInstance;

		[Token(Token = "0x4000D7B")]
		[FieldOffset(Offset = "0x1B0")]
		internal IVfxPool _vfxPool;

		[Token(Token = "0x1700016A")]
		public Vector3 MouthWorldPosition
		{
			[Token(Token = "0x60011B8")]
			[Address(RVA = "0x3CC3BB8", Offset = "0x3CC3BB8", Length = "0xB8")]
			get
			{
				Transform mouthTransform;
				if (m_mouthTransform != null)
				{
					mouthTransform = m_mouthTransform;
				}
				else
				{
					mouthTransform = base.transform;
					if ((object)mouthTransform == null)
					{
						throw new NullReferenceException();
					}
				}
				return mouthTransform.position;
			}
		}

		[Token(Token = "0x1700016B")]
		public Transform[] TubePathPoints
		{
			[Token(Token = "0x60011B9")]
			[Address(RVA = "0x3CC3C70", Offset = "0x3CC3C70", Length = "0x8")]
			get
			{
				return m_tubePathPoints;
			}
		}

		[Token(Token = "0x1700016C")]
		public AnimationCurve TubeSpeedCurve
		{
			[Token(Token = "0x60011BA")]
			[Address(RVA = "0x3CC3C78", Offset = "0x3CC3C78", Length = "0x8")]
			get
			{
				return m_tubeSpeedCurve;
			}
		}

		[Token(Token = "0x1700016D")]
		public Vector2 TubeSpeedRange
		{
			[Token(Token = "0x60011BB")]
			[Address(RVA = "0x3CC3C80", Offset = "0x3CC3C80", Length = "0x8")]
			get
			{
				return m_tubeSpeedRange;
			}
		}

		[Token(Token = "0x1700016E")]
		public float TubeRadius
		{
			[Token(Token = "0x60011BC")]
			[Address(RVA = "0x3CC3C88", Offset = "0x3CC3C88", Length = "0x8")]
			get
			{
				return m_tubeRadius;
			}
		}

		[Token(Token = "0x1700016F")]
		public Vector2 MouthScaleRange
		{
			[Token(Token = "0x60011BD")]
			[Address(RVA = "0x3CC3C90", Offset = "0x3CC3C90", Length = "0x8")]
			get
			{
				return m_mouthScaleRange;
			}
		}

		[Token(Token = "0x17000170")]
		public float Mouth3DAxisMultiplier
		{
			[Token(Token = "0x60011BE")]
			[Address(RVA = "0x3CC3C98", Offset = "0x3CC3C98", Length = "0x8")]
			get
			{
				return m_mouth3DAxisMultiplier;
			}
		}

		[Token(Token = "0x17000171")]
		public AnimationCurve MouthScaleCurve
		{
			[Token(Token = "0x60011BF")]
			[Address(RVA = "0x3CC3CA0", Offset = "0x3CC3CA0", Length = "0x8")]
			get
			{
				return m_mouthScaleCurve;
			}
		}

		[Token(Token = "0x17000172")]
		public float SuctionMinRadius
		{
			[Token(Token = "0x60011C0")]
			[Address(RVA = "0x3CC3CA8", Offset = "0x3CC3CA8", Length = "0x8")]
			get
			{
				return m_suctionMinRadius;
			}
		}

		[Token(Token = "0x17000173")]
		public float SuctionMaxRadius
		{
			[Token(Token = "0x60011C1")]
			[Address(RVA = "0x3CC3CB0", Offset = "0x3CC3CB0", Length = "0x8")]
			get
			{
				return m_suctionMaxRadius;
			}
		}

		[Token(Token = "0x17000174")]
		public AnimationCurve SuctionRadiusCurve
		{
			[Token(Token = "0x60011C2")]
			[Address(RVA = "0x3CC3CB8", Offset = "0x3CC3CB8", Length = "0x8")]
			get
			{
				return m_suctionRadiusCurve;
			}
		}

		[Token(Token = "0x17000175")]
		public float SuctionRadiusDuration
		{
			[Token(Token = "0x60011C3")]
			[Address(RVA = "0x3CC3CC0", Offset = "0x3CC3CC0", Length = "0x8")]
			get
			{
				return m_suctionRadiusDuration;
			}
		}

		[Token(Token = "0x17000176")]
		public AnimationCurve XYAttractionCurve
		{
			[Token(Token = "0x60011C4")]
			[Address(RVA = "0x3CC3CC8", Offset = "0x3CC3CC8", Length = "0x8")]
			get
			{
				return m_xyAttractionCurve;
			}
		}

		[Token(Token = "0x17000177")]
		public AnimationCurve ZRiseCurve
		{
			[Token(Token = "0x60011C5")]
			[Address(RVA = "0x3CC3CD0", Offset = "0x3CC3CD0", Length = "0x8")]
			get
			{
				return m_zRiseCurve;
			}
		}

		[Token(Token = "0x17000178")]
		public Vector3 BulbWorldCenter
		{
			[Token(Token = "0x60011C6")]
			[Address(RVA = "0x3CC3CD8", Offset = "0x3CC3CD8", Length = "0xB8")]
			get
			{
				Transform bulbTransform;
				if (BulbTransform != null)
				{
					bulbTransform = BulbTransform;
				}
				else
				{
					bulbTransform = base.transform;
					if ((object)bulbTransform == null)
					{
						throw new NullReferenceException();
					}
				}
				return bulbTransform.position;
			}
		}

		[Token(Token = "0x17000179")]
		public float BulbRadius
		{
			[Token(Token = "0x60011C7")]
			[Address(RVA = "0x3CC3D90", Offset = "0x3CC3D90", Length = "0x8")]
			get
			{
				return m_bulbRadius;
			}
		}

		[Token(Token = "0x1700017A")]
		public float BulbSettleSpeed
		{
			[Token(Token = "0x60011C8")]
			[Address(RVA = "0x3CC3D98", Offset = "0x3CC3D98", Length = "0x8")]
			get
			{
				return m_bulbSettleSpeed;
			}
		}

		[Token(Token = "0x1700017B")]
		public Transform BulbTransform
		{
			[Token(Token = "0x60011C9")]
			[Address(RVA = "0x3CC3DA0", Offset = "0x3CC3DA0", Length = "0x8")]
			get
			{
				return m_bulbCenter;
			}
		}

		[Token(Token = "0x1700017C")]
		public Vector3 DispatchMouthWorldPosition
		{
			[Token(Token = "0x60011CA")]
			[Address(RVA = "0x3CC3DA8", Offset = "0x3CC3DA8", Length = "0xBC")]
			get
			{
				if (DispatchMouthTransform != null)
				{
					return DispatchMouthTransform.position;
				}
				return MouthWorldPosition;
			}
		}

		[Token(Token = "0x1700017D")]
		public float DispatchRadius
		{
			[Token(Token = "0x60011CB")]
			[Address(RVA = "0x3CC3E64", Offset = "0x3CC3E64", Length = "0x8")]
			get
			{
				return m_dispatchRadius;
			}
		}

		[Token(Token = "0x1700017E")]
		public Transform DispatchMouthTransform
		{
			[Token(Token = "0x60011CC")]
			[Address(RVA = "0x3CC3E6C", Offset = "0x3CC3E6C", Length = "0x8")]
			get
			{
				return m_dispatchMouthTransform;
			}
		}

		[Token(Token = "0x1700017F")]
		public AbsorptionProfile DispatchAbsorptionProfile
		{
			[Token(Token = "0x60011CD")]
			[Address(RVA = "0x3CC3E74", Offset = "0x3CC3E74", Length = "0x18")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumMono::get_DispatchAbsorptionProfile");
				return default;
			}
		}

		[Token(Token = "0x17000180")]
		public float DispatchStaggerDuration
		{
			[Token(Token = "0x60011CE")]
			[Address(RVA = "0x3CC3E8C", Offset = "0x3CC3E8C", Length = "0x8")]
			get
			{
				return m_dispatchStaggerDuration;
			}
		}

		[Token(Token = "0x17000181")]
		public float MoldTransitionDelay
		{
			[Token(Token = "0x60011CF")]
			[Address(RVA = "0x3CC3E94", Offset = "0x3CC3E94", Length = "0x8")]
			get
			{
				return m_moldTransitionDelay;
			}
		}

		[Token(Token = "0x17000182")]
		public Vector2 DispatchTubeSpeedRange
		{
			[Token(Token = "0x60011D0")]
			[Address(RVA = "0x3CC3E9C", Offset = "0x3CC3E9C", Length = "0xC")]
			get
			{
				return m_dispatchTubeSpeedRange;
			}
		}

		[Token(Token = "0x17000183")]
		public float MouthToDispatchDelay
		{
			[Token(Token = "0x60011D1")]
			[Address(RVA = "0x3CC3EA8", Offset = "0x3CC3EA8", Length = "0x8")]
			get
			{
				return m_mouthToDispatchDelay;
			}
		}

		[Token(Token = "0x17000184")]
		public AnimationCurve DispatchScaleDownCurve
		{
			[Token(Token = "0x60011D2")]
			[Address(RVA = "0x3CC3EB0", Offset = "0x3CC3EB0", Length = "0x8")]
			get
			{
				return m_dispatchScaleDownCurve;
			}
		}

		[Token(Token = "0x17000185")]
		public float DespawnAnimDuration
		{
			[Token(Token = "0x60011D3")]
			[Address(RVA = "0x3CC3EB8", Offset = "0x3CC3EB8", Length = "0x8")]
			get
			{
				return m_despawnAnimDuration;
			}
		}

		[Token(Token = "0x17000186")]
		public TweenSettings VacuumRotateSettings
		{
			[Token(Token = "0x60011D4")]
			[Address(RVA = "0x3CC3EC0", Offset = "0x3CC3EC0", Length = "0x14")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumMono::get_VacuumRotateSettings");
				return default;
			}
		}

		[Token(Token = "0x17000187")]
		public float VacuumMaxSpeed
		{
			[Token(Token = "0x60011D5")]
			[Address(RVA = "0x3CC3ED4", Offset = "0x3CC3ED4", Length = "0x8")]
			get
			{
				return m_vacuumMaxSpeed;
			}
		}

		[Token(Token = "0x17000188")]
		public float ArrivalRadius
		{
			[Token(Token = "0x60011D6")]
			[Address(RVA = "0x3CC3EDC", Offset = "0x3CC3EDC", Length = "0x8")]
			get
			{
				return m_arrivalRadius;
			}
		}

		[Token(Token = "0x60011B6")]
		[Address(RVA = "0x3CC3A5C", Offset = "0x3CC3A5C", Length = "0xC")]
		public void Init(IVfxPool vfxPool)
		{
			_vfxPool = vfxPool;
		}

		[Token(Token = "0x60011B7")]
		[Address(RVA = "0x3CC3A68", Offset = "0x3CC3A68", Length = "0x150")]
		public void SetOverrideMaterial(Material mat)
		{
			if (mat == null || m_bodyRenderer == null)
			{
				return;
			}
			Material[] materials = m_bodyRenderer.materials;
			if ((object)mat != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			materials[0] = mat;
			m_bodyRenderer.materials = materials;
		}

		[Token(Token = "0x60011D7")]
		[Address(RVA = "0x3CC3EE4", Offset = "0x3CC3EE4", Length = "0x1D4")]
		public Sequence PlaySpawnAnim()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumMono::PlaySpawnAnim");
			return default;
		}

		[Token(Token = "0x60011D8")]
		[Address(RVA = "0x3CC40B8", Offset = "0x3CC40B8", Length = "0x30")]
		public void PlayIdleAnimation()
		{
			m_animator.CrossFade(m_idleAnimTriggerName, 0.2f);
		}

		[Token(Token = "0x60011D9")]
		[Address(RVA = "0x3CC40E8", Offset = "0x3CC40E8", Length = "0x30")]
		public void PlayOnlyFillAnimation()
		{
			m_animator.CrossFade(m_onlyFillAnimTriggerName, 0.2f);
		}

		[Token(Token = "0x60011DA")]
		[Address(RVA = "0x3CC4118", Offset = "0x3CC4118", Length = "0x30")]
		public void PlaySpitAnimation()
		{
			m_animator.CrossFade(m_spitAnimTriggerName, 0.2f);
		}

		[Token(Token = "0x60011DB")]
		[Address(RVA = "0x3CC4148", Offset = "0x3CC4148", Length = "0x3F4")]
		public void StartSuckLoopVfx()
		{
			if (m_suckLoopVfxPrefab == null || m_particleParent == null)
			{
				return;
			}
			StopSuckLoopVfx();
			UnityEngine.Object activeSuckVfxInstance2;
			if (_vfxPool != null)
			{
				Vector3 position = m_particleParent.position;
				Quaternion rotation = m_particleParent.rotation;
				GameObject activeSuckVfxInstance = _vfxPool.Rent(m_suckLoopVfxPrefab, position, rotation, m_particleParent);
				_activeSuckVfxInstance = activeSuckVfxInstance;
				bool flag = _activeSuckVfxInstance != null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				UnityEngine.Object obj = null;
				if (flag3)
				{
					PooledVfxBehaviour component = _activeSuckVfxInstance.GetComponent<PooledVfxBehaviour>();
					obj = component;
				}
				if (!(obj != null))
				{
					activeSuckVfxInstance2 = _activeSuckVfxInstance;
				}
				else
				{
					_ = 0;
					activeSuckVfxInstance2 = _activeSuckVfxInstance;
				}
			}
			else
			{
				GameObject activeSuckVfxInstance3 = UnityEngine.Object.Instantiate(m_suckLoopVfxPrefab, m_particleParent);
				_activeSuckVfxInstance = activeSuckVfxInstance3;
				activeSuckVfxInstance2 = _activeSuckVfxInstance;
			}
			if (!(activeSuckVfxInstance2 == null))
			{
				Transform transform = _activeSuckVfxInstance.transform;
				Vector3 localPosition = default(Vector3);
				localPosition.x = SUCK_LOCAL_POS.x;
				localPosition.y = SUCK_LOCAL_POS.y;
				localPosition.z = SUCK_LOCAL_POS.z;
				transform.localPosition = localPosition;
				Vector3 localEulerAngles = default(Vector3);
				localEulerAngles.x = SUCK_LOCAL_EULER.x;
				localEulerAngles.y = SUCK_LOCAL_EULER.y;
				localEulerAngles.z = SUCK_LOCAL_EULER.z;
				transform.localEulerAngles = localEulerAngles;
			}
		}

		[Token(Token = "0x60011DC")]
		[Address(RVA = "0x3CC453C", Offset = "0x3CC453C", Length = "0x27C")]
		public void StopSuckLoopVfx()
		{
			if (_activeSuckVfxInstance == null)
			{
				return;
			}
			ParticleSystem[] componentsInChildren = _activeSuckVfxInstance.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				do
				{
					if (componentsInChildren[num] != null)
					{
						componentsInChildren[num].Stop(withChildren: true, default(ParticleSystemStopBehavior));
					}
					num++;
				}
				while (num < componentsInChildren.Length);
			}
			if (_vfxPool == null)
			{
				bool flag = m_suckLoopVfxDestroyDelay < 0f;
				bool flag2 = m_suckLoopVfxDestroyDelay == 0f;
				bool flag3 = m_suckLoopVfxDestroyDelay == m_suckLoopVfxDestroyDelay;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag5;
				if (!(flag6 || flag2))
				{
					UnityEngine.Object.Destroy(_activeSuckVfxInstance, m_suckLoopVfxDestroyDelay);
				}
				else
				{
					UnityEngine.Object.Destroy(_activeSuckVfxInstance);
				}
			}
			else
			{
				_vfxPool.Return(_activeSuckVfxInstance, m_suckLoopVfxDestroyDelay);
			}
			_activeSuckVfxInstance = null;
		}

		[Token(Token = "0x60011DD")]
		[Address(RVA = "0x3CC47B8", Offset = "0x3CC47B8", Length = "0x2FC")]
		public void PlayReleaseVfx()
		{
			if (!(m_releaseVfxPrefab == null) && !(m_particleParent == null))
			{
				GameObject gameObject2;
				if (_vfxPool != null)
				{
					Vector3 position = m_particleParent.position;
					Quaternion rotation = m_particleParent.rotation;
					GameObject gameObject = _vfxPool.Rent(m_releaseVfxPrefab, position, rotation, m_particleParent);
					gameObject2 = gameObject;
				}
				else
				{
					GameObject gameObject3 = UnityEngine.Object.Instantiate(m_releaseVfxPrefab, m_particleParent);
					gameObject2 = gameObject3;
				}
				if (!(gameObject2 == null))
				{
					Transform transform = gameObject2.transform;
					Vector3 localPosition = default(Vector3);
					localPosition.x = RELEASE_LOCAL_POS.x;
					localPosition.y = RELEASE_LOCAL_POS.y;
					localPosition.z = RELEASE_LOCAL_POS.z;
					transform.localPosition = localPosition;
					Vector3 localEulerAngles = default(Vector3);
					localEulerAngles.x = RELEASE_LOCAL_EULER.x;
					localEulerAngles.y = RELEASE_LOCAL_EULER.y;
					localEulerAngles.z = RELEASE_LOCAL_EULER.z;
					transform.localEulerAngles = localEulerAngles;
				}
			}
		}

		[Token(Token = "0x60011DE")]
		[Address(RVA = "0x3CC4AB4", Offset = "0x3CC4AB4", Length = "0x4")]
		private void OnDestroy()
		{
			StopSuckLoopVfx();
		}

		[Token(Token = "0x60011DF")]
		[Address(RVA = "0x3CC4AB8", Offset = "0x3CC4AB8", Length = "0xCC")]
		public Sequence PlayDespawnAnimation()
		{
			Sequence sequence = Sequence.Create();
			Action callback = delegate
			{
				m_animator.CrossFade(m_despawnAnimTriggerName, 0.2f);
			};
			Sequence result = default(Sequence);
			Sequence sequence2 = result.ChainCallback(callback);
			Sequence sequence3 = result.ChainDelay(DespawnAnimDuration);
			return result;
		}

		[Token(Token = "0x60011E0")]
		[Address(RVA = "0x3CC4B84", Offset = "0x3CC4B84", Length = "0x174")]
		public Sequence PlayVacuumAnimation(Action onVacuumAnimStarted = null)
		{
			Sequence sequence = Sequence.Create();
			Action callback = delegate
			{
				VacuumMono vacuumMono = this;
				vacuumMono.m_animator.CrossFade(vacuumMono.m_vacuumAnimTriggerName, 0.1f);
			};
			Sequence result = default(Sequence);
			Sequence sequence2 = result.ChainCallback(callback);
			Sequence sequence3 = result.ChainDelay(0.1f);
			Action callback2 = delegate
			{
				if (onVacuumAnimStarted != null)
				{
					onVacuumAnimStarted();
				}
			};
			Sequence sequence4 = result.ChainCallback(callback2);
			return result;
		}

		[Token(Token = "0x60011E1")]
		[Address(RVA = "0x3CC4D00", Offset = "0x3CC4D00", Length = "0x98")]
		public Sequence PlaySpawnAndVacuumAnimation(Action onVacuumAnimStarted = null)
		{
			Sequence sequence = Sequence.Create();
			Sequence sequence2 = PlaySpawnAnim();
			Sequence result = default(Sequence);
			Sequence sequence3 = result.Chain(sequence2);
			Sequence sequence4 = PlayVacuumAnimation(onVacuumAnimStarted);
			Sequence sequence5 = result.Chain(sequence4);
			return result;
		}

		[Token(Token = "0x60011E2")]
		[Address(RVA = "0x3CC4D98", Offset = "0x3CC4D98", Length = "0x4C0")]
		private void OnDrawGizmosSelected()
		{
			Transform[] tubePathPoints = TubePathPoints;
			if (TubePathPoints != null && tubePathPoints.Length >= 2)
			{
				Color color = default(Color);
				color.r = 1f;
				color.g = 47f / 51f;
				color.b = 0.015686275f;
				color.a = 1f;
				Gizmos.color = color;
				Transform[] tubePathPoints2 = TubePathPoints;
				if (tubePathPoints2.Length >= 1)
				{
					int num = 0;
					do
					{
						if (tubePathPoints2[num] != null)
						{
							Vector3 position = tubePathPoints2[num].position;
							Gizmos.DrawWireSphere(position, 0.05f);
						}
						num++;
					}
					while (num < tubePathPoints2.Length);
				}
				Color color2 = default(Color);
				color2.r = 0f;
				color2.g = 1f;
				color2.b = 1f;
				color2.a = 1f;
				Gizmos.color = color2;
				Vector3 vector = VacuumPathSampler.EvaluateCatmullRom(TubePathPoints, 0f);
				float z = vector.z;
				float y = vector.y;
				Vector3 vector2 = vector;
				int num2 = 1;
				Vector3 vector4 = default(Vector3);
				bool flag;
				do
				{
					float t = (float)num2 / 50f;
					Vector3 vector3 = VacuumPathSampler.EvaluateCatmullRom(TubePathPoints, t);
					vector4.x = vector2.x;
					vector4.y = y;
					vector4.z = z;
					Gizmos.DrawLine(vector4, vector3);
					num2++;
					flag = num2 != 51;
					z = vector3.z;
					y = vector3.y;
					vector2 = vector3;
				}
				while (flag);
				Color color3 = default(Color);
				color3.r = 0f;
				color3.g = 1f;
				color3.b = 1f;
				color3.a = 0.3f;
				Gizmos.color = color3;
				Transform[] tubePathPoints3 = TubePathPoints;
				if (tubePathPoints3.Length >= 1)
				{
					int num3 = 0;
					do
					{
						if (tubePathPoints3[num3] != null)
						{
							if ((object)tubePathPoints3[num3] == null)
							{
								throw new NullReferenceException();
							}
							Vector3 position2 = tubePathPoints3[num3].position;
							Gizmos.DrawWireSphere(position2, TubeRadius);
						}
						num3++;
					}
					while (num3 < tubePathPoints3.Length);
				}
			}
			UnityEngine.Object bulbTransform;
			if (!(DispatchMouthTransform != null))
			{
				bulbTransform = BulbTransform;
			}
			else
			{
				Color color4 = default(Color);
				color4.r = 1f;
				color4.g = 0f;
				color4.b = 0f;
				color4.a = 1f;
				Gizmos.color = color4;
				Vector3 position3 = DispatchMouthTransform.position;
				Gizmos.DrawWireSphere(position3, 0.05f);
				bulbTransform = BulbTransform;
			}
			if (bulbTransform != null)
			{
				Color color5 = default(Color);
				color5.r = 0f;
				color5.g = 1f;
				color5.b = 0f;
				color5.a = 1f;
				Gizmos.color = color5;
				Vector3 position4 = BulbTransform.position;
				Gizmos.DrawWireSphere(position4, BulbRadius);
				Color color6 = default(Color);
				color6.r = 1f;
				color6.g = 47f / 51f;
				color6.b = 0.015686275f;
				color6.a = 1f;
				Gizmos.color = color6;
				Vector3 position5 = BulbTransform.position;
				Vector3 up = BulbTransform.up;
				Vector3 position6 = BulbTransform.position;
				float num4 = up.x * BulbRadius;
				float num5 = up.y * BulbRadius;
				float num6 = up.z * BulbRadius;
				float x = position5.x - num4;
				float y2 = position5.y - num5;
				float z2 = position5.z - num6;
				Vector3 up2 = BulbTransform.up;
				float num7 = up2.x * BulbRadius;
				float num8 = up2.y * BulbRadius;
				float num9 = up2.z * BulbRadius;
				float x2 = position6.x + num7;
				float y3 = position6.y + num8;
				float z3 = position6.z + num9;
				Vector3 vector5 = default(Vector3);
				vector5.x = x;
				vector5.y = y2;
				vector5.z = z2;
				Vector3 to = default(Vector3);
				to.x = x2;
				to.y = y3;
				to.z = z3;
				Gizmos.DrawLine(vector5, to);
				Vector3 center = default(Vector3);
				center.x = x2;
				center.y = y3;
				center.z = z3;
				Gizmos.DrawSphere(center, 0.03f);
			}
		}

		[Token(Token = "0x60011E3")]
		[Address(RVA = "0x3CC54E0", Offset = "0x3CC54E0", Length = "0x1A8")]
		public VacuumMono()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumMono::.ctor");
		}

		[Token(Token = "0x60011E4")]
		[Address(RVA = "0x3CC5688", Offset = "0x3CC5688", Length = "0xE4")]
		static VacuumMono()
		{
			SUCK_LOCAL_POS.x = Vector3.zero.x;
			SUCK_LOCAL_POS.z = Vector3.zero.z;
			SUCK_LOCAL_EULER.x = 0f;
			SUCK_LOCAL_EULER.z = 0f;
			RELEASE_LOCAL_POS.x = Vector3.zero.x;
			RELEASE_LOCAL_POS.z = Vector3.zero.z;
			RELEASE_LOCAL_EULER.x = 0f;
			RELEASE_LOCAL_EULER.z = 0f;
		}
	}
}
