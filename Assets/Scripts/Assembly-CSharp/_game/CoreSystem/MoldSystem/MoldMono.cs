using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using PrimeTween;
using Unco.Extensions;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004A3")]
	public class MoldMono : MoldMonoBase
	{
		[Token(Token = "0x20004A4")]
		private struct TransformSnapshot
		{
			[Token(Token = "0x4000F8D")]
			[FieldOffset(Offset = "0x0")]
			public Vector3 localPosition;

			[Token(Token = "0x4000F8E")]
			[FieldOffset(Offset = "0xC")]
			public Quaternion localRotation;

			[Token(Token = "0x4000F8F")]
			[FieldOffset(Offset = "0x1C")]
			public Vector3 localScale;
		}

		[Token(Token = "0x4000F61")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<Transform, TransformSnapshot> _defaultTransforms;

		[Token(Token = "0x4000F62")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary<SkinnedMeshRenderer, float[]> _defaultBlendShapes;

		[Token(Token = "0x4000F63")]
		[FieldOffset(Offset = "0x30")]
		private bool _isFillPlaying;

		[SerializeField]
		[Token(Token = "0x4000F64")]
		[FieldOffset(Offset = "0x38")]
		private Animator m_animator;

		[SerializeField]
		[Token(Token = "0x4000F65")]
		[FieldOffset(Offset = "0x40")]
		private ParticleSystem m_fillParticle;

		[SerializeField]
		[Token(Token = "0x4000F66")]
		[FieldOffset(Offset = "0x48")]
		private string m_fillAnimationName = "Fill";

		[SerializeField]
		[Token(Token = "0x4000F67")]
		[FieldOffset(Offset = "0x50")]
		private string m_coverOpenAnimationName = "CoverOpen";

		[SerializeField]
		[Token(Token = "0x4000F68")]
		[FieldOffset(Offset = "0x58")]
		private string m_coverCloseAnimationName = "CoverClose";

		[SerializeField]
		[Token(Token = "0x4000F69")]
		[FieldOffset(Offset = "0x60")]
		private string m_onlyCoverCloseAnimationName = "OnlyCoverClose";

		[SerializeField]
		[Token(Token = "0x4000F6A")]
		[FieldOffset(Offset = "0x68")]
		private string m_idleAnimationName = "bottom_box_idle";

		[SerializeField]
		[Token(Token = "0x4000F6B")]
		[FieldOffset(Offset = "0x70")]
		private AnimationClip m_idleOpenClip;

		[SerializeField]
		[Token(Token = "0x4000F6C")]
		[FieldOffset(Offset = "0x78")]
		private AnimationClip m_idleClosedClip;

		[SerializeField]
		[Token(Token = "0x4000F6D")]
		[FieldOffset(Offset = "0x80")]
		private AnimationCurve m_blendshapeCurve0;

		[SerializeField]
		[Token(Token = "0x4000F6E")]
		[FieldOffset(Offset = "0x88")]
		private AnimationCurve m_blendshapeCurve1;

		[SerializeField]
		[Token(Token = "0x4000F6F")]
		[FieldOffset(Offset = "0x90")]
		private Transform m_fillParticleStartPos;

		[SerializeField]
		[Token(Token = "0x4000F70")]
		[FieldOffset(Offset = "0x98")]
		private Transform m_fillParticleEndPos;

		[SerializeField]
		[Token(Token = "0x4000F71")]
		[FieldOffset(Offset = "0xA0")]
		private AnimationCurve m_fillPosCurve;

		[SerializeField]
		[Token(Token = "0x4000F72")]
		[FieldOffset(Offset = "0xA8")]
		private SkinnedMeshRenderer m_sandRenderer;

		[SerializeField]
		[Token(Token = "0x4000F73")]
		[FieldOffset(Offset = "0xB0")]
		private Renderer m_coverRenderer;

		[SerializeField]
		[Token(Token = "0x4000F74")]
		[FieldOffset(Offset = "0xB8")]
		private Renderer m_moldRenderer;

		[SerializeField]
		[Token(Token = "0x4000F75")]
		[FieldOffset(Offset = "0xC0")]
		private Transform m_pourPoint;

		[Header("Complete VFX")]
		[SerializeField]
		[Token(Token = "0x4000F76")]
		[FieldOffset(Offset = "0xC8")]
		private GameObject m_completeVfxPrefab;

		[SerializeField]
		[Token(Token = "0x4000F77")]
		[FieldOffset(Offset = "0xD0")]
		private Transform m_completeVfxAnchor;

		[Token(Token = "0x4000F78")]
		[FieldOffset(Offset = "0xD8")]
		private IVfxPool _vfxPool;

		[Token(Token = "0x4000F79")]
		[FieldOffset(Offset = "0xE0")]
		private Transform _vfxParent;

		[Header("Hidden Reveal")]
		[SerializeField]
		[Token(Token = "0x4000F7A")]
		[FieldOffset(Offset = "0xE8")]
		private GameObject m_normalMoldRoot;

		[SerializeField]
		[Token(Token = "0x4000F7B")]
		[FieldOffset(Offset = "0xF0")]
		private GameObject m_hiddenMold;

		[SerializeField]
		[Token(Token = "0x4000F7C")]
		[FieldOffset(Offset = "0xF8")]
		private Animator m_hiddenAnimator;

		[SerializeField]
		[Token(Token = "0x4000F7D")]
		[FieldOffset(Offset = "0x100")]
		private Renderer m_hiddenRenderer;

		[SerializeField]
		[Token(Token = "0x4000F7E")]
		[FieldOffset(Offset = "0x108")]
		private string m_revealAnimationName = "Reveal";

		[SerializeField]
		[Token(Token = "0x4000F7F")]
		[FieldOffset(Offset = "0x110")]
		private float m_revealLerpDelay;

		[SerializeField]
		[Token(Token = "0x4000F80")]
		[FieldOffset(Offset = "0x114")]
		private float m_revealLerpDuration = 0.5f;

		[Header("Reveal Texture Blend")]
		[SerializeField]
		[Token(Token = "0x4000F81")]
		[FieldOffset(Offset = "0x118")]
		private Shader m_blendShader;

		[SerializeField]
		[Token(Token = "0x4000F82")]
		[FieldOffset(Offset = "0x120")]
		private string m_baseMapProperty = "_BaseMap";

		[Tooltip("0 = match source texture resolution. Lower values save memory.")]
		[SerializeField]
		[Token(Token = "0x4000F83")]
		[FieldOffset(Offset = "0x128")]
		private int m_blendRtMaxSize;

		[Token(Token = "0x4000F84")]
		[FieldOffset(Offset = "0x130")]
		private IMoldMaterialProvider _materialProvider;

		[Token(Token = "0x4000F85")]
		[FieldOffset(Offset = "0x138")]
		private GameColor _cachedRevealColor;

		[Token(Token = "0x4000F86")]
		[FieldOffset(Offset = "0x140")]
		private Material _hiddenInstance;

		[Token(Token = "0x4000F87")]
		[FieldOffset(Offset = "0x148")]
		private Material _blitMaterial;

		[Token(Token = "0x4000F88")]
		[FieldOffset(Offset = "0x150")]
		private RenderTexture _blendRT;

		[Token(Token = "0x4000F89")]
		private static readonly int s_fromTexId;

		[Token(Token = "0x4000F8A")]
		private static readonly int s_toTexId;

		[Token(Token = "0x4000F8B")]
		private static readonly int s_blendId;

		[Token(Token = "0x4000F8C")]
		[FieldOffset(Offset = "0x158")]
		private Transform _fillParticleTransform;

		[Token(Token = "0x170001AE")]
		public override Transform PourPoint
		{
			[Token(Token = "0x6001349")]
			[Address(RVA = "0x3CE8B88", Offset = "0x3CE8B88", Length = "0x8")]
			get
			{
				return m_pourPoint;
			}
		}

		[Token(Token = "0x170001AF")]
		public override Renderer Renderer
		{
			[Token(Token = "0x600134A")]
			[Address(RVA = "0x3CE8B90", Offset = "0x3CE8B90", Length = "0x8")]
			get
			{
				return m_moldRenderer;
			}
		}

		[Token(Token = "0x6001348")]
		[Address(RVA = "0x3CE8B54", Offset = "0x3CE8B54", Length = "0x34")]
		public void Init(IVfxPool vfxPool, Transform vfxParent)
		{
			_vfxPool = vfxPool;
			_vfxParent = vfxParent;
		}

		[Token(Token = "0x600134B")]
		[Address(RVA = "0x3CE8B98", Offset = "0x3CE8B98", Length = "0x3C")]
		public override void Setup(IMoldMaterialProvider materialProvider)
		{
			_materialProvider = materialProvider;
			ApplyFillParticleColor();
			CacheDefaultPose();
			ApplyInitialHiddenState();
		}

		[Token(Token = "0x600134C")]
		[Address(RVA = "0x3CE91DC", Offset = "0x3CE91DC", Length = "0x33C")]
		private void ApplyInitialHiddenState()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::ApplyInitialHiddenState");
		}

		[Token(Token = "0x600134D")]
		[Address(RVA = "0x3CE8DEC", Offset = "0x3CE8DEC", Length = "0x3F0")]
		private unsafe void CacheDefaultPose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::CacheDefaultPose");
		}

		[Token(Token = "0x600134E")]
		[Address(RVA = "0x3CE96A0", Offset = "0x3CE96A0", Length = "0x3E8")]
		private unsafe void RestoreDefaultPose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::RestoreDefaultPose");
		}

		[Token(Token = "0x600134F")]
		[Address(RVA = "0x3CE9A88", Offset = "0x3CE9A88", Length = "0x5C")]
		internal override void SetOpen()
		{
			_isFillPlaying = false;
			m_animator.Play("bottom_box_idle");
		}

		[Token(Token = "0x6001350")]
		[Address(RVA = "0x3CE9AE4", Offset = "0x3CE9AE4", Length = "0x5C")]
		internal override void SetClosed()
		{
			_isFillPlaying = false;
			m_animator.Play("bottom_box_idle_closed");
		}

		[Token(Token = "0x6001351")]
		[Address(RVA = "0x3CE9B40", Offset = "0x3CE9B40", Length = "0x8")]
		internal override void SetOpen_Editor()
		{
			SampleClipForEditor(m_idleOpenClip);
		}

		[Token(Token = "0x6001352")]
		[Address(RVA = "0x3CE9C5C", Offset = "0x3CE9C5C", Length = "0x8")]
		internal override void SetClosed_Editor()
		{
			SampleClipForEditor(m_idleClosedClip);
		}

		[Token(Token = "0x6001353")]
		[Address(RVA = "0x3CE9B48", Offset = "0x3CE9B48", Length = "0x114")]
		private void SampleClipForEditor(AnimationClip clip)
		{
			if (!(clip == null) && !(m_animator == null))
			{
				RestoreDefaultPose();
				GameObject go = m_animator.gameObject;
				clip.SampleAnimation(go, 0f);
			}
		}

		[Token(Token = "0x6001354")]
		[Address(RVA = "0x3CE9C64", Offset = "0x3CE9C64", Length = "0x2C")]
		internal override void PlayCoverOpen()
		{
			_isFillPlaying = false;
			m_animator.Play(m_coverOpenAnimationName, 0);
		}

		[Token(Token = "0x6001355")]
		[Address(RVA = "0x3CE9C90", Offset = "0x3CE9C90", Length = "0x2C")]
		internal override void PlayCoverClose()
		{
			_isFillPlaying = false;
			m_animator.Play(m_coverCloseAnimationName, 0);
		}

		[Token(Token = "0x6001356")]
		[Address(RVA = "0x3CE9CBC", Offset = "0x3CE9CBC", Length = "0x2C")]
		internal override void PlayOnlyCoverClose()
		{
			_isFillPlaying = false;
			m_animator.Play(m_onlyCoverCloseAnimationName, 0);
		}

		[Token(Token = "0x6001357")]
		[Address(RVA = "0x3CE9CE8", Offset = "0x3CE9CE8", Length = "0x4C")]
		internal override void Reveal(GameColor color, Action onComplete)
		{
			ApplyMaterial(color, isHidden: false);
			onComplete?.Invoke();
		}

		[Token(Token = "0x6001358")]
		[Address(RVA = "0x3CE9D34", Offset = "0x3CE9D34", Length = "0x6C0")]
		public override Sequence BuildRevealSequence(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::BuildRevealSequence");
			return default;
		}

		[Token(Token = "0x6001359")]
		[Address(RVA = "0x3CEA3FC", Offset = "0x3CEA3FC", Length = "0x13C")]
		private void EnsureBlitMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::EnsureBlitMaterial");
		}

		[Token(Token = "0x600135A")]
		[Address(RVA = "0x3CEA538", Offset = "0x3CEA538", Length = "0x4D0")]
		private void EnsureBlendRT(Texture reference)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::EnsureBlendRT");
		}

		[Token(Token = "0x600135B")]
		[Address(RVA = "0x3CEAA08", Offset = "0x3CEAA08", Length = "0x19C")]
		public override void SnapToRevealed()
		{
			if (!(m_hiddenMold == null) && (m_hiddenMold.activeSelf || (!(m_normalMoldRoot == null) && !m_normalMoldRoot.activeSelf)))
			{
				m_hiddenMold.SetActive(value: false);
				if (!(m_normalMoldRoot != null))
				{
					ApplyNormalMaterial(_cachedRevealColor);
					return;
				}
				m_normalMoldRoot.SetActive(value: true);
				ApplyNormalMaterial(_cachedRevealColor);
			}
		}

		[Token(Token = "0x600135C")]
		[Address(RVA = "0x3CE9518", Offset = "0x3CE9518", Length = "0x188")]
		private void EnsureHiddenInstance(Material src)
		{
			if (!(src == null) && !(m_hiddenRenderer == null))
			{
				if (_hiddenInstance == null)
				{
					Material hiddenInstance = new Material(src);
					_hiddenInstance = hiddenInstance;
				}
				else
				{
					_hiddenInstance.CopyPropertiesFromMaterial(src);
				}
				m_hiddenRenderer.sharedMaterial = _hiddenInstance;
			}
		}

		[Token(Token = "0x600135D")]
		[Address(RVA = "0x3CEACAC", Offset = "0x3CEACAC", Length = "0x1E0")]
		private void OnDestroy()
		{
			UnityEngine.Object blitMaterial;
			if (!(_hiddenInstance != null))
			{
				blitMaterial = _blitMaterial;
			}
			else
			{
				UnityEngine.Object.Destroy(_hiddenInstance);
				_hiddenInstance = null;
				blitMaterial = _blitMaterial;
			}
			UnityEngine.Object blendRT;
			if (!(blitMaterial != null))
			{
				blendRT = _blendRT;
			}
			else
			{
				UnityEngine.Object.Destroy(_blitMaterial);
				_blitMaterial = null;
				blendRT = _blendRT;
			}
			if (blendRT != null)
			{
				_blendRT.Release();
				UnityEngine.Object.Destroy(_blendRT);
				_blendRT = null;
			}
		}

		[Token(Token = "0x600135E")]
		[Address(RVA = "0x3CEAE8C", Offset = "0x3CEAE8C", Length = "0xB4")]
		public override void UpdateVisualFill(float fillRate)
		{
			float num = fillRate / 100f;
			float num2 = m_blendshapeCurve0.Evaluate(num);
			float num3 = m_blendshapeCurve1.Evaluate(num);
			float value = num2 * 100f;
			m_sandRenderer.SetBlendShapeWeight(0, value);
			float value2 = num3 * 100f;
			m_sandRenderer.SetBlendShapeWeight(1, value2);
			UpdateFillParticlePosition(num);
		}

		[Token(Token = "0x600135F")]
		[Address(RVA = "0x3CEAF40", Offset = "0x3CEAF40", Length = "0x1B8")]
		private void UpdateFillParticlePosition(float t)
		{
			if (!(m_fillParticleStartPos == null) && !(m_fillParticleEndPos == null))
			{
				Vector3 position = m_fillParticleStartPos.position;
				Vector3 position2 = m_fillParticleEndPos.position;
				float num = m_fillPosCurve.Evaluate(t);
				float num2 = position2.z - position.z;
				bool flag = num < 1f;
				bool flag2 = num == 1f;
				bool flag3 = num == num;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				float num3 = ((!(flag7 && flag8)) ? num : 1f);
				float num4 = ((!(num < 0f)) ? num3 : 0f);
				float num5 = num2 * num4;
				float z = position.z + num5;
				float num6 = position2.y - position.y;
				float num7 = num6 * num4;
				float y = position.y + num7;
				float num8 = position2.x - position.x;
				float num9 = num8 * num4;
				float x = position.x + num9;
				Vector3 position3 = default(Vector3);
				position3.x = x;
				position3.y = y;
				position3.z = z;
				_fillParticleTransform.position = position3;
			}
		}

		[Token(Token = "0x6001360")]
		[Address(RVA = "0x3CEB0F8", Offset = "0x3CEB0F8", Length = "0x8C")]
		public override void StartFill()
		{
			if (!_isFillPlaying)
			{
				_isFillPlaying = true;
				m_animator.Play(m_fillAnimationName);
			}
			m_fillParticle.OrNull()?.Play();
		}

		[Token(Token = "0x6001361")]
		[Address(RVA = "0x3CEB184", Offset = "0x3CEB184", Length = "0x7C")]
		public override void StopFill()
		{
			_isFillPlaying = false;
			m_fillParticle.OrNull()?.Stop();
			m_animator.Play(m_idleAnimationName);
		}

		[Token(Token = "0x6001362")]
		[Address(RVA = "0x3CE8BD4", Offset = "0x3CE8BD4", Length = "0x218")]
		private unsafe void ApplyFillParticleColor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::ApplyFillParticleColor");
		}

		[Token(Token = "0x6001363")]
		[Address(RVA = "0x3CEB200", Offset = "0x3CEB200", Length = "0x544")]
		public override void ApplyMaterial(GameColor color, bool isHidden)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::ApplyMaterial");
		}

		[Token(Token = "0x6001364")]
		[Address(RVA = "0x3CEABA4", Offset = "0x3CEABA4", Length = "0x108")]
		private void ApplyNormalMaterial(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldMono::ApplyNormalMaterial");
		}

		[Token(Token = "0x6001365")]
		[Address(RVA = "0x3CEB744", Offset = "0x3CEB744", Length = "0x268")]
		public override void PlayCompleteVfx()
		{
			if (_vfxPool != null && !(m_completeVfxPrefab == null))
			{
				Transform transform;
				UnityEngine.Object vfxParent;
				if (m_completeVfxAnchor != null)
				{
					transform = m_completeVfxAnchor;
					vfxParent = _vfxParent;
				}
				else
				{
					Transform transform2 = base.transform;
					transform = transform2;
					vfxParent = _vfxParent;
				}
				Transform parent;
				if (vfxParent != null)
				{
					parent = _vfxParent;
				}
				else
				{
					Transform parent2 = transform.parent;
					transform = transform;
					parent = parent2;
				}
				Vector3 position = transform.position;
				Quaternion rotation = transform.rotation;
				GameObject gameObject = _vfxPool.Rent(m_completeVfxPrefab, position, rotation, parent);
			}
		}

		[Token(Token = "0x6001366")]
		[Address(RVA = "0x3CEB9AC", Offset = "0x3CEB9AC", Length = "0x15C")]
		public MoldMono()
		{
		}

		[Token(Token = "0x6001367")]
		[Address(RVA = "0x3CEBB10", Offset = "0x3CEBB10", Length = "0xD4")]
		static MoldMono()
		{
			int num = Shader.PropertyToID("_FromTex");
			s_fromTexId = num;
			int num2 = Shader.PropertyToID("_ToTex");
			s_toTexId = num2;
			int num3 = Shader.PropertyToID("_Blend");
			s_blendId = num3;
		}
	}
}
