using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coffee.UIExtensions;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using Unco.ResourceSystem;
using UnityEngine;
using UnityEngine.Pool;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.Animations
{
	[Token(Token = "0x200056B")]
	public class CurrencyAnimationController : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200056C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001296")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001297")]
			public static Action<CurrencyParticle> _003C_003E9__13_1;

			[Token(Token = "0x4001298")]
			public static Action<CurrencyParticle> _003C_003E9__13_2;

			[Token(Token = "0x4001299")]
			public static Action<CurrencyParticle> _003C_003E9__13_3;

			[Token(Token = "0x60016C3")]
			[Address(RVA = "0x3D225D0", Offset = "0x3D225D0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60016C4")]
			[Address(RVA = "0x3D22634", Offset = "0x3D22634", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CCreatePool_003Eb__13_1(CurrencyParticle particle)
			{
				particle.OnGet();
			}

			internal void _003CCreatePool_003Eb__13_2(CurrencyParticle particle)
			{
				particle.OnRelease();
			}

			internal void _003CCreatePool_003Eb__13_3(CurrencyParticle particle)
			{
				if (particle != null)
				{
					GameObject gameObject = particle.gameObject;
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}

		[SerializeField]
		[Token(Token = "0x4001287")]
		[FieldOffset(Offset = "0x20")]
		private Transform m_particleContainer;

		[SerializeField]
		[Token(Token = "0x4001288")]
		[FieldOffset(Offset = "0x28")]
		private List<ResourceParticleEntry> m_resourceParticles;

		[SerializeField]
		[Token(Token = "0x4001289")]
		[FieldOffset(Offset = "0x30")]
		private List<StringParticleEntry> m_stringParticles;

		[SerializeField]
		[Token(Token = "0x400128A")]
		[FieldOffset(Offset = "0x38")]
		private CurrencyParticle m_genericParticlePrefab;

		[SerializeField]
		[Token(Token = "0x400128B")]
		[FieldOffset(Offset = "0x40")]
		private List<GenericParticleConfig> m_genericConfigs;

		[Token(Token = "0x400128C")]
		[FieldOffset(Offset = "0x48")]
		private Dictionary<ResourceType, ObjectPool<CurrencyParticle>> _particlePools;

		[Token(Token = "0x400128D")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary<string, ObjectPool<CurrencyParticle>> _stringParticlePools;

		[Token(Token = "0x400128E")]
		[FieldOffset(Offset = "0x58")]
		private ObjectPool<CurrencyParticle> _genericPool;

		[Token(Token = "0x400128F")]
		[FieldOffset(Offset = "0x60")]
		private Dictionary<string, GenericParticleConfig> _genericConfigMap;

		[Token(Token = "0x4001290")]
		[FieldOffset(Offset = "0x68")]
		private ParticleAnimationRegistry _registry;

		[Token(Token = "0x4001291")]
		private const float kTargetResolveDelay = 0.1f;

		[Token(Token = "0x4001292")]
		private const float kShowAnimDuration = 0.2f;

		[Token(Token = "0x4001293")]
		private const float kGoldCountUpDelay = 0.4f;

		[Token(Token = "0x4001294")]
		private const float AttractorDelay = 0.3f;

		[Token(Token = "0x4001295")]
		private const float ParticleDuration = 1.65f;

		[Inject(false)]
		[Token(Token = "0x60016AD")]
		[Address(RVA = "0x3D1FA40", Offset = "0x3D1FA40", Length = "0x28")]
		private void Init(ParticleAnimationRegistry registry)
		{
			_registry = registry;
			InitializePools();
		}

		[Inject(true)]
		[Token(Token = "0x60016AE")]
		[Address(RVA = "0x3D1FF78", Offset = "0x3D1FF78", Length = "0x104")]
		private void TryBindExistingFactory(OverlayUiFactory uiFactory)
		{
			if (uiFactory != null && m_particleContainer == null)
			{
				Transform particleContainer = uiFactory.transform;
				m_particleContainer = particleContainer;
			}
		}

		[Token(Token = "0x60016AF")]
		[Address(RVA = "0x3D1FA68", Offset = "0x3D1FA68", Length = "0x510")]
		private unsafe void InitializePools()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::InitializePools");
		}

		[Token(Token = "0x60016B0")]
		[Address(RVA = "0x3D2007C", Offset = "0x3D2007C", Length = "0x320")]
		private ObjectPool<CurrencyParticle> CreatePool(CurrencyParticle prefab)
		{
			Func<CurrencyParticle> createFunc = () => CreateParticle(prefab);
			Action<CurrencyParticle> action = _003C_003Ec._003C_003E9__13_1;
			if (_003C_003Ec._003C_003E9__13_1 == null)
			{
				action = (_003C_003Ec._003C_003E9__13_1 = delegate(CurrencyParticle particle)
				{
					particle.OnGet();
				});
			}
			Action<CurrencyParticle> actionOnRelease = _003C_003Ec._003C_003E9__13_2;
			if (_003C_003Ec._003C_003E9__13_2 == null)
			{
				actionOnRelease = (_003C_003Ec._003C_003E9__13_2 = delegate(CurrencyParticle particle)
				{
					particle.OnRelease();
				});
				action = action;
			}
			Action<CurrencyParticle> actionOnDestroy = _003C_003Ec._003C_003E9__13_3;
			if (_003C_003Ec._003C_003E9__13_3 == null)
			{
				actionOnDestroy = (_003C_003Ec._003C_003E9__13_3 = delegate(CurrencyParticle particle)
				{
					if (particle != null)
					{
						GameObject obj = particle.gameObject;
						UnityEngine.Object.Destroy(obj);
					}
				});
			}
			return new ObjectPool<CurrencyParticle>(createFunc, action, actionOnRelease, actionOnDestroy, collectionCheck: true, 10, 20);
		}

		[Token(Token = "0x60016B1")]
		[Address(RVA = "0x3D203A4", Offset = "0x3D203A4", Length = "0xE0")]
		private CurrencyParticle CreateParticle(CurrencyParticle prefab)
		{
			int num = 187502592 + 416;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4B014AC (UnityEngine.Object::Instantiate, and 1 more at this address)");
			Component component = default(Component);
			if ((object)component != null)
			{
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				return (CurrencyParticle)component;
			}
			return (CurrencyParticle)(object)new NullReferenceException();
		}

		[Token(Token = "0x60016B2")]
		[Address(RVA = "0x3D20484", Offset = "0x3D20484", Length = "0x304")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::OnDestroy");
		}

		[Token(Token = "0x60016B3")]
		[Address(RVA = "0x3D15B38", Offset = "0x3D15B38", Length = "0x190")]
		public void Play(ResourceType resourceType, Vector3 sourcePosition, Action onComplete, int particleAmount = 10, int amount = 0, int currentAmount = 0)
		{
			int num = (((uint)particleAmount >= 10u) ? 10 : particleAmount);
			bool flag = particleAmount < 0;
			int num2 = particleAmount ^ particleAmount;
			int num3 = particleAmount & num2;
			bool flag2 = num3 < 0;
			int particleAmount2 = ((flag == flag2) ? num : 0);
			if (_particlePools.TryGetValue(resourceType, out var value))
			{
				PlayResourceParticleWithDeferredTarget(value, sourcePosition, resourceType, particleAmount2, amount, currentAmount, onComplete);
				return;
			}
			object arg = resourceType;
			string message = $"[CurrencyAnimationController] No pool found for resource type: {arg}";
			Debug.LogError(message);
			onComplete?.Invoke();
		}

		[Token(Token = "0x60016B4")]
		[Address(RVA = "0x3D20788", Offset = "0x3D20788", Length = "0x524")]
		private unsafe void PlayResourceParticleWithDeferredTarget(ObjectPool<CurrencyParticle> pool, Vector3 sourcePosition, ResourceType resourceType, int particleAmount, int amount, int currentAmount, Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::PlayResourceParticleWithDeferredTarget");
		}

		[Token(Token = "0x60016B5")]
		[Address(RVA = "0x3D20DA4", Offset = "0x3D20DA4", Length = "0x6C")]
		public void Play(ResourceType resourceType, RectTransform sourceRect, Action onComplete, int particleAmount = 10, int amount = 0, int currentAmount = 0)
		{
			Vector3 position = sourceRect.position;
			Play(resourceType, position, onComplete, particleAmount, amount, currentAmount);
		}

		[Token(Token = "0x60016B6")]
		[Address(RVA = "0x3D20E10", Offset = "0x3D20E10", Length = "0x80")]
		public void Play(ResourceType resourceType, Action onComplete, int particleAmount = 10, int amount = 0, int currentAmount = 0)
		{
			int width = Screen.width;
			int height = Screen.height;
			Vector3 sourcePosition = default(Vector3);
			sourcePosition.x = width;
			sourcePosition.y = height;
			sourcePosition.z = 0f;
			Play(resourceType, sourcePosition, onComplete, particleAmount, amount, currentAmount);
		}

		[Token(Token = "0x60016B7")]
		[Address(RVA = "0x3D154CC", Offset = "0x3D154CC", Length = "0x1AC")]
		public unsafe void SetUpVisualizersForAnimation(ResourceType type, int amount, int currentAmount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::SetUpVisualizersForAnimation");
		}

		[Token(Token = "0x60016B8")]
		[Address(RVA = "0x3D20FB0", Offset = "0x3D20FB0", Length = "0x194")]
		public unsafe void RefreshVisualizers(ResourceType type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::RefreshVisualizers");
		}

		[Token(Token = "0x60016B9")]
		[Address(RVA = "0x3D15CC8", Offset = "0x3D15CC8", Length = "0x14C")]
		public void Play(string key, Vector3 sourcePosition, Action onComplete, int particleAmount = 10)
		{
			if (!TryGetStringPool(key, out var pool, out var genericConfig))
			{
				string message = "[CurrencyAnimationController] No pool or generic config found for key: " + key;
				Debug.LogError(message);
				onComplete?.Invoke();
				return;
			}
			int num = (((uint)particleAmount >= 10u) ? 10 : particleAmount);
			bool flag = particleAmount < 0;
			int num2 = particleAmount ^ particleAmount;
			int num3 = particleAmount & num2;
			bool flag2 = num3 < 0;
			int particleAmount2 = ((flag == flag2) ? num : 0);
			GenericParticleConfig? genericConfig2 = genericConfig;
			PlayParticleWithDeferredTarget(pool, sourcePosition, key, particleAmount2, onComplete, genericConfig2);
		}

		[Token(Token = "0x60016BA")]
		[Address(RVA = "0x3D21938", Offset = "0x3D21938", Length = "0x1EC")]
		public void Play(string key, Vector3 sourcePosition, UIParticleAttractor target, Action onComplete, int particleAmount = 10)
		{
			if (!TryGetStringPool(key, out var pool, out var genericConfig))
			{
				string message = "[CurrencyAnimationController] No pool or generic config found for key: " + key;
				Debug.LogError(message);
				if (onComplete != null)
				{
					onComplete();
				}
				return;
			}
			int num = (((uint)particleAmount >= 10u) ? 10 : particleAmount);
			bool flag = particleAmount < 0;
			int num2 = particleAmount ^ particleAmount;
			int num3 = particleAmount & num2;
			bool flag2 = num3 < 0;
			int particleAmount2 = ((flag == flag2) ? num : 0);
			Action action = delegate
			{
				if (onComplete != null)
				{
					onComplete();
				}
			};
			GenericParticleConfig? genericConfig2 = genericConfig;
			((CurrencyAnimationController)(object)action).PlayParticle(pool, sourcePosition, target, particleAmount2, action, genericConfig2);
		}

		[Token(Token = "0x60016BB")]
		[Address(RVA = "0x3D1810C", Offset = "0x3D1810C", Length = "0x54")]
		public void Play(string key, RectTransform sourceRect, Action onComplete, int particleAmount = 10)
		{
			Vector3 position = sourceRect.position;
			Play(key, position, onComplete, particleAmount);
		}

		[Token(Token = "0x60016BC")]
		[Address(RVA = "0x3D220B8", Offset = "0x3D220B8", Length = "0x64")]
		public void Play(string key, RectTransform sourceRect, UIParticleAttractor target, Action onComplete, int particleAmount = 10)
		{
			Vector3 position = sourceRect.position;
			Play(key, position, target, onComplete, particleAmount);
		}

		[Token(Token = "0x60016BD")]
		[Address(RVA = "0x3D20CB4", Offset = "0x3D20CB4", Length = "0x38")]
		private static Vector3 GetScreenCenter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::GetScreenCenter");
			return default;
		}

		[Token(Token = "0x60016BE")]
		[Address(RVA = "0x3D21274", Offset = "0x3D21274", Length = "0x160")]
		private bool TryGetStringPool(string key, out ObjectPool<CurrencyParticle> pool, out GenericParticleConfig? genericConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::TryGetStringPool");
			pool = default;
			genericConfig = default;
			return default;
		}

		[Token(Token = "0x60016BF")]
		[Address(RVA = "0x3D21B2C", Offset = "0x3D21B2C", Length = "0x58C")]
		private unsafe void PlayParticle(ObjectPool<CurrencyParticle> pool, Vector3 sourcePosition, UIParticleAttractor attractor, int particleAmount, Action onComplete, GenericParticleConfig? genericConfig = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::PlayParticle");
		}

		[Token(Token = "0x60016C0")]
		[Address(RVA = "0x3D213D4", Offset = "0x3D213D4", Length = "0x564")]
		private unsafe void PlayParticleWithDeferredTarget(ObjectPool<CurrencyParticle> pool, Vector3 sourcePosition, string key, int particleAmount, Action onComplete, GenericParticleConfig? genericConfig)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurrencyAnimationController::PlayParticleWithDeferredTarget");
		}

		[Token(Token = "0x60016C1")]
		[Address(RVA = "0x3D22124", Offset = "0x3D22124", Length = "0x284")]
		private static void ApplyGenericConfig(CurrencyParticle particle, GenericParticleConfig config)
		{
			ParticleSystemRenderer component = particle.ParticleSystem.GetComponent<ParticleSystemRenderer>();
			Material material = component.material;
			Texture2D texture = config.m_sprite.texture;
			material.mainTexture = texture;
			ParticleSystem.TrailModule trails = particle.ParticleSystem.trails;
			ParticleSystem.TrailModule trailModule = trails;
			if (trailModule.enabled)
			{
				Gradient gradient = new Gradient();
				GradientColorKey[] colorKeys = new GradientColorKey[2];
				int num = 0;
				Color col = default(Color);
				col.r = config.m_color.r;
				col.g = config.m_color.g;
				col.b = config.m_color.b;
				col.a = config.m_color.a;
				GradientColorKey gradientColorKey = new GradientColorKey(col, 0f);
				_ = 0;
				int num2 = 0;
				Color col2 = default(Color);
				col2.r = config.m_color.r;
				col2.g = config.m_color.g;
				col2.b = config.m_color.b;
				col2.a = config.m_color.a;
				GradientColorKey gradientColorKey2 = new GradientColorKey(col2, 1f);
				_ = 0;
				GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
				GradientAlphaKey gradientAlphaKey = new GradientAlphaKey(config.m_color.a, 0f);
				GradientAlphaKey gradientAlphaKey2 = new GradientAlphaKey(0f, 1f);
				gradient.SetKeys(colorKeys, alphaKeys);
				ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient(gradient);
				ParticleSystem.MinMaxGradient colorOverTrail = minMaxGradient;
				trailModule.colorOverTrail = colorOverTrail;
			}
			particle.UIParticle.RefreshParticles();
		}

		[Token(Token = "0x60016C2")]
		[Address(RVA = "0x3D223B0", Offset = "0x3D223B0", Length = "0x220")]
		public CurrencyAnimationController()
		{
			List<ResourceParticleEntry> resourceParticles = new List<ResourceParticleEntry>();
			m_resourceParticles = resourceParticles;
			List<StringParticleEntry> stringParticles = new List<StringParticleEntry>();
			m_stringParticles = stringParticles;
			List<GenericParticleConfig> genericConfigs = new List<GenericParticleConfig>();
			m_genericConfigs = genericConfigs;
			Dictionary<ResourceType, ObjectPool<CurrencyParticle>> particlePools = new Dictionary<ResourceType, ObjectPool<CurrencyParticle>>();
			_particlePools = particlePools;
			Dictionary<string, ObjectPool<CurrencyParticle>> stringParticlePools = new Dictionary<string, ObjectPool<CurrencyParticle>>();
			_stringParticlePools = stringParticlePools;
			Dictionary<string, GenericParticleConfig> genericConfigMap = new Dictionary<string, GenericParticleConfig>();
			_genericConfigMap = genericConfigMap;
		}
	}
}
