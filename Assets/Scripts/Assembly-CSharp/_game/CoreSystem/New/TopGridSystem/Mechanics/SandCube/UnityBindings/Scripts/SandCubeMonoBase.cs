using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using HighlightPlus;
using PrimeTween;
using UnityEngine;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts;
using _game.CoreSystem.Pooling;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts
{
	[Token(Token = "0x200018E")]
	public class SandCubeMonoBase : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x40004F3")]
		[FieldOffset(Offset = "0x20")]
		private GameObject m_sandCubeRoot;

		[SerializeField]
		[Token(Token = "0x40004F4")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_hiddenRoot;

		[SerializeField]
		[Token(Token = "0x40004F5")]
		[FieldOffset(Offset = "0x30")]
		private Animator m_hiddenAnimator;

		[SerializeField]
		[Token(Token = "0x40004F6")]
		[FieldOffset(Offset = "0x38")]
		private Renderer m_jellyRenderer;

		[SerializeField]
		[Token(Token = "0x40004F7")]
		[FieldOffset(Offset = "0x40")]
		private Renderer m_bottomRenderer;

		[SerializeField]
		[Token(Token = "0x40004F8")]
		[FieldOffset(Offset = "0x48")]
		private Renderer m_boxRenderer;

		[SerializeField]
		[Token(Token = "0x40004F9")]
		[FieldOffset(Offset = "0x50")]
		private HighlightEffect m_highlightEffect;

		[SerializeField]
		[Token(Token = "0x40004FA")]
		[FieldOffset(Offset = "0x58")]
		private Renderer[] m_highlightRenderers;

		[SerializeField]
		[Token(Token = "0x40004FB")]
		[FieldOffset(Offset = "0x60")]
		private SandCubeJellyIdle m_jellyIdle;

		[SerializeField]
		[Token(Token = "0x40004FC")]
		[FieldOffset(Offset = "0x68")]
		private Transform m_overlayContent;

		[Header("Overlay anchor tappable transition")]
		[SerializeField]
		[Token(Token = "0x40004FD")]
		[FieldOffset(Offset = "0x70")]
		private Vector3 m_overlayContentOpenLocalPos;

		[SerializeField]
		[Token(Token = "0x40004FE")]
		[FieldOffset(Offset = "0x7C")]
		private Vector3 m_overlayContentClosedLocalPos;

		[SerializeField]
		[Token(Token = "0x40004FF")]
		[FieldOffset(Offset = "0x88")]
		private float m_overlayTweenDuration = 0.4f;

		[SerializeField]
		[Token(Token = "0x4000500")]
		[FieldOffset(Offset = "0x90")]
		private AnimationCurve m_overlayTweenCurve;

		[Token(Token = "0x4000501")]
		[FieldOffset(Offset = "0x98")]
		private Tween _overlayPosTween;

		[Token(Token = "0x4000502")]
		[FieldOffset(Offset = "0xA8")]
		internal SandCubeConfig _config;

		[Token(Token = "0x4000503")]
		[FieldOffset(Offset = "0xB0")]
		internal IVfxPool _vfxPool;

		[Token(Token = "0x4000504")]
		[FieldOffset(Offset = "0xB8")]
		private GameColor _lastColor;

		[SerializeField]
		[Token(Token = "0x4000505")]
		[FieldOffset(Offset = "0xC0")]
		private Animator m_animator;

		[SerializeField]
		[Token(Token = "0x4000506")]
		[FieldOffset(Offset = "0xC8")]
		private float m_breakAnimDuration;

		[SerializeField]
		[Token(Token = "0x4000507")]
		[FieldOffset(Offset = "0xD0")]
		private ShakeSettings m_rejectSettings;

		[SerializeField]
		[Token(Token = "0x4000508")]
		[FieldOffset(Offset = "0x110")]
		private float m_explodeVfxDelay;

		[Token(Token = "0x4000509")]
		[FieldOffset(Offset = "0x118")]
		private string _breakAnim;

		[Token(Token = "0x400050A")]
		[FieldOffset(Offset = "0x120")]
		private string _openAnim;

		[Token(Token = "0x400050B")]
		[FieldOffset(Offset = "0x128")]
		private string _hiddenOpenAnim;

		[Token(Token = "0x400050C")]
		[FieldOffset(Offset = "0x130")]
		private Tween _shakeTween;

		[Token(Token = "0x400050D")]
		private static readonly int IdleStateHash;

		[Token(Token = "0x170000A7")]
		public Transform OverlayContent
		{
			[Token(Token = "0x600075E")]
			[Address(RVA = "0x3E681E0", Offset = "0x3E681E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.OverlayContent;\n")]
			get
			{
				return m_overlayContent;
			}
		}

		[Token(Token = "0x170000A8")]
		public float BreakAnimDuration
		{
			[Token(Token = "0x6000760")]
			[Address(RVA = "0x3E682D8", Offset = "0x3E682D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BreakAnimDuration;\n")]
			get
			{
				return m_breakAnimDuration;
			}
		}

		[Token(Token = "0x170000A9")]
		public GameObject HiddenRoot
		{
			[Token(Token = "0x6000761")]
			[Address(RVA = "0x3E682E0", Offset = "0x3E682E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.HiddenRoot;\n")]
			get
			{
				return m_hiddenRoot;
			}
		}

		[Token(Token = "0x170000AA")]
		public GameObject SandCubeRoot
		{
			[Token(Token = "0x6000762")]
			[Address(RVA = "0x3E682E8", Offset = "0x3E682E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SandCubeRoot;\n")]
			get
			{
				return m_sandCubeRoot;
			}
		}

		[Token(Token = "0x600075F")]
		[Address(RVA = "0x3E681E8", Offset = "0x3E681E8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_highlightEffect, 0);\n\tv63 = ~v55;\n\tv64 = ~v63;\n\tif (v64) goto L_0036;\nL_0023:\n\treturn;\nL_0036:\n\tv80 = this.m_highlightRenderers;\n\tv77 = this.m_highlightRenderers == 0;\n\tif (v77) goto L_0023;\n\tv78 = v80.Length == 0;\n\tif (v78) goto L_0023;\n\tv125 = UnityEngine.Component::get_transform(this);\n\tHighlightPlus.HighlightEffect::SetTargets(this.m_highlightEffect, v125, this.m_highlightRenderers);\n\tv114 = this.m_highlightEffect;\n\tv114.outlineQuality = 0;\n\treturn;\n")]
		private void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeMonoBase::Awake");
		}

		[Token(Token = "0x6000763")]
		[Address(RVA = "0x3E682F0", Offset = "0x3E682F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._config = config;\n\treturn;\n")]
		public void InjectColorConfig(SandCubeConfig config)
		{
			_config = config;
		}

		[Token(Token = "0x6000764")]
		[Address(RVA = "0x3E682F8", Offset = "0x3E682F8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._config = config;\n\tthis._vfxPool = vfxPool;\n\treturn;\n")]
		public void InjectColorConfig(SandCubeConfig config, IVfxPool vfxPool)
		{
			_config = config;
			_vfxPool = vfxPool;
		}

		[Token(Token = "0x6000765")]
		[Address(RVA = "0x3E6832C", Offset = "0x3E6832C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this._config, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0039;\n\treturn;\nL_0039:\n\tthis._lastColor = color;\n\tv155 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeConfig::GetJellyMaterials(this._config, color);\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_jellyRenderer, v155.jellyMaterial);\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_boxRenderer, v155.boxMaterial);\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_bottomRenderer, v155.bottomMaterial);\n\treturn;\n")]
		public virtual void ApplyMaterial(GameColor color)
		{
			if (!(_config == null))
			{
				_lastColor = color;
				JellyMaterialPair jellyMaterials = _config.GetJellyMaterials(color);
				m_jellyRenderer.sharedMaterial = jellyMaterials.jellyMaterial;
				m_boxRenderer.sharedMaterial = jellyMaterials.boxMaterial;
				m_bottomRenderer.sharedMaterial = jellyMaterials.bottomMaterial;
			}
		}

		[Token(Token = "0x6000766")]
		[Address(RVA = "0x3E6843C", Offset = "0x3E6843C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.SandCubeRoot, 0);\n\tv64 = ~v56;\n\tv65 = ~v64;\n\tif (v65) goto L_004E;\n\tv99 = this.HiddenRoot;\n\tgoto L_0025;\nL_0025:\n\tv104 = UnityEngine.Object::op_Inequality(v99, 0);\n\tv125 = ~v104;\n\tv126 = ~v125;\n\tif (v126) goto L_0063;\n\tv139 = ~isHidden;\n\tif (v139) goto L_006E;\nL_0036:\n\t// 54 MakeStruct v143 @ AGG3E684CC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentClosedLocalPos (UnityEngine.Vector3), this.m_overlayContentClosedLocalPos.y (System.Single), this.m_overlayContentClosedLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SnapOverlay(this, v143);\n\treturn;\nL_004E:\n\tv92 = isHidden ^ 1;\n\tUnityEngine.GameObject::SetActive(this.SandCubeRoot, v92);\n\tv99 = this.HiddenRoot;\n\tgoto L_0025;\nL_0063:\n\tUnityEngine.GameObject::SetActive(this.HiddenRoot, isHidden);\n\tv190 = ~isHidden;\n\tv187 = ~v190;\n\tif (v187) goto L_0036;\nL_006E:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetHidden(bool isHidden)
		{
			UnityEngine.Object hiddenRoot;
			if (!(SandCubeRoot != null))
			{
				hiddenRoot = HiddenRoot;
			}
			else
			{
				bool active = (byte)((isHidden ? 1u : 0u) ^ 1u) != 0;
				SandCubeRoot.SetActive(active);
				hiddenRoot = HiddenRoot;
			}
			if (!(hiddenRoot != null))
			{
				if (!isHidden)
				{
					return;
				}
			}
			else
			{
				HiddenRoot.SetActive(isHidden);
				if (!isHidden)
				{
					return;
				}
			}
			Vector3 localPos = default(Vector3);
			localPos.x = m_overlayContentClosedLocalPos.x;
			localPos.y = m_overlayContentClosedLocalPos.y;
			localPos.z = m_overlayContentClosedLocalPos.z;
			SnapOverlay(localPos);
		}

		[Token(Token = "0x6000767")]
		[Address(RVA = "0x3E68678", Offset = "0x3E68678", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_hiddenAnimator, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tUnityEngine.Animator::Play(this.m_hiddenAnimator, this._hiddenOpenAnim);\n\treturn;\nL_0043:\n\treturn;\n")]
		public void PlayHiddenOpen()
		{
			if (m_hiddenAnimator != null)
			{
				m_hiddenAnimator.Play(_hiddenOpenAnim);
			}
		}

		[Token(Token = "0x6000768")]
		[Address(RVA = "0x3E68734", Offset = "0x3E68734", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tUnityEngine.GameObject::SetActive(v41, 1);\n\tv54 = UnityEngine.Component::get_gameObject(this.m_bottomRenderer);\n\tUnityEngine.GameObject::SetActive(v54, 1);\n\tv56 = UnityEngine.Component::get_gameObject(this.m_boxRenderer);\n\tUnityEngine.GameObject::SetActive(v56, 0);\n\tgoto L_0037;\nL_0037:\n\tv100 = UnityEngine.Application::get_isPlaying();\n\tv102 = ~v100;\n\tv103 = ~v102;\n\tif (v103) goto L_0046;\n\tgoto L_0049;\nL_0046:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this.m_highlightEffect, 1);\nL_0049:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 1);\n\t// 83 MakeStruct v71 @ AGG3E6882C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentOpenLocalPos (UnityEngine.Vector3), this.m_overlayContentOpenLocalPos.y (System.Single), this.m_overlayContentOpenLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SnapOverlay(this, v71);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SetOpen_Editor()
		{
			GameObject gameObject = m_jellyRenderer.gameObject;
			gameObject.SetActive(value: true);
			GameObject gameObject2 = m_bottomRenderer.gameObject;
			gameObject2.SetActive(value: true);
			GameObject gameObject3 = m_boxRenderer.gameObject;
			gameObject3.SetActive(value: false);
			if (Application.isPlaying)
			{
				m_highlightEffect.SetHighlighted(state: true);
			}
			SetJellyIdle(active: true);
			Vector3 localPos = default(Vector3);
			localPos.x = m_overlayContentOpenLocalPos.x;
			localPos.y = m_overlayContentOpenLocalPos.y;
			localPos.z = m_overlayContentOpenLocalPos.z;
			SnapOverlay(localPos);
		}

		[Token(Token = "0x6000769")]
		[Address(RVA = "0x3E68910", Offset = "0x3E68910", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tUnityEngine.GameObject::SetActive(v41, 0);\n\tv54 = UnityEngine.Component::get_gameObject(this.m_bottomRenderer);\n\tUnityEngine.GameObject::SetActive(v54, 0);\n\tv56 = UnityEngine.Component::get_gameObject(this.m_boxRenderer);\n\tUnityEngine.GameObject::SetActive(v56, 1);\n\tgoto L_0037;\nL_0037:\n\tv100 = UnityEngine.Application::get_isPlaying();\n\tv102 = ~v100;\n\tv103 = ~v102;\n\tif (v103) goto L_0046;\n\tgoto L_0049;\nL_0046:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this.m_highlightEffect, 0);\nL_0049:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 0);\n\t// 83 MakeStruct v71 @ AGG3E68A08_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentClosedLocalPos (UnityEngine.Vector3), this.m_overlayContentClosedLocalPos.y (System.Single), this.m_overlayContentClosedLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SnapOverlay(this, v71);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SetClosed_Editor()
		{
			GameObject gameObject = m_jellyRenderer.gameObject;
			gameObject.SetActive(value: false);
			GameObject gameObject2 = m_bottomRenderer.gameObject;
			gameObject2.SetActive(value: false);
			GameObject gameObject3 = m_boxRenderer.gameObject;
			gameObject3.SetActive(value: true);
			if (Application.isPlaying)
			{
				m_highlightEffect.SetHighlighted(state: false);
			}
			SetJellyIdle(active: false);
			Vector3 localPos = default(Vector3);
			localPos.x = m_overlayContentClosedLocalPos.x;
			localPos.y = m_overlayContentClosedLocalPos.y;
			localPos.z = m_overlayContentClosedLocalPos.z;
			SnapOverlay(localPos);
		}

		[Token(Token = "0x600076A")]
		[Address(RVA = "0x3E68A10", Offset = "0x3E68A10", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tUnityEngine.GameObject::SetActive(v41, 1);\n\tv54 = UnityEngine.Component::get_gameObject(this.m_bottomRenderer);\n\tUnityEngine.GameObject::SetActive(v54, 1);\n\tv56 = UnityEngine.Component::get_gameObject(this.m_boxRenderer);\n\tUnityEngine.GameObject::SetActive(v56, 0);\n\tgoto L_0037;\nL_0037:\n\tv100 = UnityEngine.Application::get_isPlaying();\n\tv102 = ~v100;\n\tv103 = ~v102;\n\tif (v103) goto L_0046;\n\tgoto L_0049;\nL_0046:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this.m_highlightEffect, 1);\nL_0049:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 1);\n\t// 83 MakeStruct v71 @ AGG3E68B08_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentOpenLocalPos (UnityEngine.Vector3), this.m_overlayContentOpenLocalPos.y (System.Single), this.m_overlayContentOpenLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SnapOverlay(this, v71);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SetOpen()
		{
			GameObject gameObject = m_jellyRenderer.gameObject;
			gameObject.SetActive(value: true);
			GameObject gameObject2 = m_bottomRenderer.gameObject;
			gameObject2.SetActive(value: true);
			GameObject gameObject3 = m_boxRenderer.gameObject;
			gameObject3.SetActive(value: false);
			if (Application.isPlaying)
			{
				m_highlightEffect.SetHighlighted(state: true);
			}
			SetJellyIdle(active: true);
			Vector3 localPos = default(Vector3);
			localPos.x = m_overlayContentOpenLocalPos.x;
			localPos.y = m_overlayContentOpenLocalPos.y;
			localPos.z = m_overlayContentOpenLocalPos.z;
			SnapOverlay(localPos);
		}

		[Token(Token = "0x600076B")]
		[Address(RVA = "0x3E68B10", Offset = "0x3E68B10", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tUnityEngine.GameObject::SetActive(v41, 0);\n\tv54 = UnityEngine.Component::get_gameObject(this.m_bottomRenderer);\n\tUnityEngine.GameObject::SetActive(v54, 0);\n\tv56 = UnityEngine.Component::get_gameObject(this.m_boxRenderer);\n\tUnityEngine.GameObject::SetActive(v56, 1);\n\tgoto L_0037;\nL_0037:\n\tv100 = UnityEngine.Application::get_isPlaying();\n\tv102 = ~v100;\n\tv103 = ~v102;\n\tif (v103) goto L_0046;\n\tgoto L_0049;\nL_0046:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this.m_highlightEffect, 0);\nL_0049:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 0);\n\t// 83 MakeStruct v71 @ AGG3E68C08_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentClosedLocalPos (UnityEngine.Vector3), this.m_overlayContentClosedLocalPos.y (System.Single), this.m_overlayContentClosedLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SnapOverlay(this, v71);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SetClosed()
		{
			GameObject gameObject = m_jellyRenderer.gameObject;
			gameObject.SetActive(value: false);
			GameObject gameObject2 = m_bottomRenderer.gameObject;
			gameObject2.SetActive(value: false);
			GameObject gameObject3 = m_boxRenderer.gameObject;
			gameObject3.SetActive(value: true);
			if (Application.isPlaying)
			{
				m_highlightEffect.SetHighlighted(state: false);
			}
			SetJellyIdle(active: false);
			Vector3 localPos = default(Vector3);
			localPos.x = m_overlayContentClosedLocalPos.x;
			localPos.y = m_overlayContentClosedLocalPos.y;
			localPos.z = m_overlayContentClosedLocalPos.z;
			SnapOverlay(localPos);
		}

		[Token(Token = "0x600076C")]
		[Address(RVA = "0x3E68C10", Offset = "0x3E68C10", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetOpen(this);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 0);\n\tUnityEngine.Animator::Play(this.m_animator, this._breakAnim);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SpawnExplodeVfx(this);\n\treturn;\n")]
		public void PlayBreak()
		{
			SetOpen();
			SetJellyIdle(active: false);
			m_animator.Play(_breakAnim);
			SpawnExplodeVfx();
		}

		[Token(Token = "0x600076D")]
		[Address(RVA = "0x3E68C60", Offset = "0x3E68C60", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_0039:\n\tv83 = UnityEngine.Object::op_Equality(this._config, 0);\n\tv88 = v83 == 0;\n\tif (v88) goto L_0047;\n\tgoto L_006D;\nL_0047:\n\tv98 = this._config;\n\tv64.prefab = v98.explodeVfxPrefab;\n\tgoto L_005A;\nL_005A:\n\tv109 = UnityEngine.Object::op_Equality(v64.prefab, 0);\n\tv112 = v109 == 0;\n\tif (v112) goto L_0079;\nL_006D:\n\treturn;\nL_0079:\n\tv146 = UnityEngine.Component::get_transform(this);\n\tv138 = UnityEngine.Transform::get_position(v146);\n\tv64.worldPos.x = v138;\n\tv64.worldPos.y = v138.y;\n\tv64.worldPos.z = v138.z;\n\tv147 = UnityEngine.Component::get_transform(this);\n\tv279 = UnityEngine.Transform::get_parent(v147);\n\tv64.parent = v279;\n\tv284 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeConfig::GetParticleTint(this._config, this._lastColor);\n\tv64.pool = this._vfxPool;\n\tv64.tint.r = v284;\n\tv64.tint.g = v284.g;\n\tv64.tint.b = v284.b;\n\tv64.tint.a = v284.a;\n\tv187 = this.m_explodeVfxDelay == 0;\n\tv290 = this.m_explodeVfxDelay < 0;\n\tv184 = ~v290;\n\tv291 = ~v184;\n\tv175 = v291 | v187;\n\tif (v175) goto L_00DB;\n\tv295 = new System.Action();\n\tSystem.Action::.ctor(v295, v64, Il2CppMethodInfo);\n\tv237 = PrimeTween.Tween::Delay(this.m_explodeVfxDelay, v295, 0, 1);\n\treturn;\nL_00DB:\n\tgoto L_0101;\nL_002D:\n\tv64 = new _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase+<>c__DisplayClass45_0();\n\tSystem.Object::.ctor(v64);\n\tgoto L_0039;\nL_0101:\n\t// 257 MakeStruct v161 @ AGG3E68F30_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v64.worldPos (UnityEngine.Vector3), v64.worldPos.y (System.Single), v64.worldPos.z (System.Single)\n\t// 258 MakeStruct v158 @ AGG3E68F30_4_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v64.tint (UnityEngine.Color), v64.tint.g (System.Single), v64.tint.b (System.Single), v64.tint.a (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SpawnTintedVfx(v64.pool, v64.prefab, v161, v64.parent, v158);\n\treturn;\n")]
		private void SpawnExplodeVfx()
		{
			if (_config == null)
			{
				return;
			}
			SandCubeConfig config = _config;
			GameObject prefab = config.explodeVfxPrefab;
			if (prefab == null)
			{
				return;
			}
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 worldPos = default(Vector3);
			worldPos.x = position.x;
			worldPos.y = position.y;
			worldPos.z = position.z;
			Transform transform2 = base.transform;
			Transform parent = transform2.parent;
			Transform parent2 = parent;
			Color particleTint = _config.GetParticleTint(_lastColor);
			IVfxPool pool = _vfxPool;
			Color tint = default(Color);
			tint.r = particleTint.r;
			tint.g = particleTint.g;
			tint.b = particleTint.b;
			tint.a = particleTint.a;
			bool flag = m_explodeVfxDelay == 0f;
			bool flag2 = m_explodeVfxDelay < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			if (!(flag4 || flag))
			{
				Action onComplete = delegate
				{
					if (!(prefab == null))
					{
						Vector3 pos2 = default(Vector3);
						pos2.x = worldPos.x;
						pos2.y = worldPos.y;
						pos2.z = worldPos.z;
						Color tint3 = default(Color);
						tint3.r = tint.r;
						tint3.g = tint.g;
						tint3.b = tint.b;
						tint3.a = tint.a;
						SpawnTintedVfx(pool, prefab, pos2, parent2, tint3);
					}
				};
				Tween tween = Tween.Delay(m_explodeVfxDelay, onComplete);
			}
			else
			{
				Vector3 pos = default(Vector3);
				pos.x = worldPos.x;
				pos.y = worldPos.y;
				pos.z = worldPos.z;
				Color tint2 = default(Color);
				tint2.r = tint.r;
				tint2.g = tint.g;
				tint2.b = tint.b;
				tint2.a = tint.a;
				SpawnTintedVfx(pool, prefab, pos, parent2, tint2);
			}
		}

		[Token(Token = "0x600076E")]
		[Address(RVA = "0x3E68F40", Offset = "0x3E68F40", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tgoto L_0058;\nL_007A:\n\tgoto L_0091;\nL_00B3:\n\tv285 = UnityEngine.Object::op_Equality(v375, 0);\n\tv337 = v285 == 0;\n\tif (v337) goto L_00C8;\n\tgoto L_011B;\nL_00C8:\n\tv465 = UnityEngine.GameObject::GetComponentsInChildren(v375, 1);\n\tv431 = v465.Length < 1;\n\tif (v431) goto L_011B;\nL_FFFFFFFF:\n\tv562 = 0;\nL_00DF:\n\tv634 = UnityEngine.ParticleSystem::get_main(v465[v562 @ X20_v6 (System.Int32)]);\n\tv418 = v634;\n\tUnityEngine.ParticleSystem+MinMaxGradient::.ctor(&v407 @ stack_-D0_v5 (UnityEngine.ParticleSystem+MinMaxGradient), tint);\n\tv399 = v407;\n\tUnityEngine.ParticleSystem+MainModule::set_startColor(&v418 @ stack_-98_v5 (UnityEngine.ParticleSystem+MainModule), &v399 @ stack_-110_v4 (UnityEngine.ParticleSystem+MinMaxGradient));\n\tv562 = v562 + 1;\n\tv430 = v562 < v465.Length;\n\tif (v430) goto L_00DF;\nL_011B:\n\treturn;\nL_003C:\n\tv81 = pool == 0;\n\tif (v81) goto L_007A;\nL_0058:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Quaternion_arg @ V3_v9 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v108.identity (UnityEngine.Quaternion), v108.identity.y (System.Single), v108.identity.z (System.Single), v108.identity.w (System.Single)\n\tv296 = _game.CoreSystem.Pooling.IVfxPool::Rent(pool, prefab, Vector3_arg, Quaternion_arg, parent);\nL_FFFFFFFF:\n\tv375 = v296;\n\tgoto L_00B3;\nL_0091:\n\t// 145 MakeStruct v140 @ AGG3E690C0_2_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v126.identity (UnityEngine.Quaternion), v126.identity.y (System.Single), v126.identity.z (System.Single), v126.identity.w (System.Single)\n\tv141 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::Instantiate(prefab, Vector3_arg, v140, parent);\nL_FFFFFFFF:\n\tv375 = v141;\n\tgoto L_00B3;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SpawnTintedVfx(IVfxPool pool, GameObject prefab, Vector3 pos, Transform parent, Color tint)
		{
			Vector3 vector = default(Vector3);
			GameObject gameObject2;
			if (pool != null)
			{
				Quaternion worldRot = default(Quaternion);
				worldRot.x = Quaternion.identity.x;
				worldRot.y = Quaternion.identity.y;
				worldRot.z = Quaternion.identity.z;
				worldRot.w = Quaternion.identity.w;
				GameObject gameObject = pool.Rent(prefab, vector, worldRot, parent);
				gameObject2 = gameObject;
			}
			else
			{
				Quaternion rotation = default(Quaternion);
				rotation.x = Quaternion.identity.x;
				rotation.y = Quaternion.identity.y;
				rotation.z = Quaternion.identity.z;
				rotation.w = Quaternion.identity.w;
				GameObject gameObject3 = VisualHandlerUtility.Instantiate(prefab, vector, rotation, parent);
				gameObject2 = gameObject3;
			}
			if (gameObject2 == null)
			{
				return;
			}
			ParticleSystem[] componentsInChildren = gameObject2.GetComponentsInChildren<ParticleSystem>(includeInactive: true);
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				do
				{
					ParticleSystem.MainModule main = componentsInChildren[num].main;
					ParticleSystem.MainModule mainModule = main;
					ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient(tint);
					ParticleSystem.MinMaxGradient startColor = minMaxGradient;
					mainModule.startColor = startColor;
					num++;
				}
				while (num < componentsInChildren.Length);
			}
		}

		[Token(Token = "0x600076F")]
		[Address(RVA = "0x3E6922C", Offset = "0x3E6922C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = PrimeTween.Tween::get_isAlive(&this._shakeTween (PrimeTween.Tween));\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0026;\n\tv20 = UnityEngine.Component::get_transform(this);\n\tv34 = this.m_rejectSettings;\n\tv53 = PrimeTween.Tween::ShakeLocalRotation(v20, &v34 @ stack_-60_v2 (PrimeTween.ShakeSettings));\n\tthis._shakeTween.id = v53;\n\tthis._shakeTween.tween = &v34 @ stack_-60_v2 (PrimeTween.ShakeSettings);\nL_0026:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayRejectShake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeMonoBase::PlayRejectShake");
		}

		[Token(Token = "0x6000770")]
		[Address(RVA = "0x3E69298", Offset = "0x3E69298", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv41 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tUnityEngine.GameObject::SetActive(v41, 1);\n\tv53 = UnityEngine.Component::get_gameObject(this.m_bottomRenderer);\n\tUnityEngine.GameObject::SetActive(v53, 1);\n\tUnityEngine.Animator::Play(this.m_animator, this._openAnim);\n\tgoto L_0033;\nL_0033:\n\tv97 = UnityEngine.Application::get_isPlaying();\n\tv99 = ~v97;\n\tv100 = ~v99;\n\tif (v100) goto L_0042;\n\tgoto L_0045;\nL_0042:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this.m_highlightEffect, 1);\nL_0045:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetJellyIdle(this, 1);\n\t// 79 MakeStruct v68 @ AGG3E69384_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_overlayContentOpenLocalPos (UnityEngine.Vector3), this.m_overlayContentOpenLocalPos.y (System.Single), this.m_overlayContentOpenLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::TweenOverlayTo(this, v68);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PlayOpen()
		{
			GameObject gameObject = m_jellyRenderer.gameObject;
			gameObject.SetActive(value: true);
			GameObject gameObject2 = m_bottomRenderer.gameObject;
			gameObject2.SetActive(value: true);
			m_animator.Play(_openAnim);
			if (Application.isPlaying)
			{
				m_highlightEffect.SetHighlighted(state: true);
			}
			SetJellyIdle(active: true);
			Vector3 targetLocalPos = default(Vector3);
			targetLocalPos.x = m_overlayContentOpenLocalPos.x;
			targetLocalPos.y = m_overlayContentOpenLocalPos.y;
			targetLocalPos.z = m_overlayContentOpenLocalPos.z;
			TweenOverlayTo(targetLocalPos);
		}

		[Token(Token = "0x6000771")]
		[Address(RVA = "0x3E695A0", Offset = "0x3E695A0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetClosed(this);\n\treturn;\n")]
		public void PlayClosed()
		{
			SetClosed();
		}

		[Token(Token = "0x6000772")]
		[Address(RVA = "0x3E695AC", Offset = "0x3E695AC", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Inequality(this.HiddenRoot, 0);\n\tv64 = ~v56;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tgoto L_007F;\nL_0034:\n\tv83 = UnityEngine.GameObject::get_activeSelf(this.HiddenRoot);\n\tv85 = ~v83;\n\tif (v85) goto L_007F;\n\tgoto L_003F;\nL_003F:\n\tv220 = UnityEngine.Object::op_Inequality(hiddenMaterials.jellyMaterial, 0);\n\tv224 = ~v220;\n\tv225 = ~v224;\n\tif (v225) goto L_00AE;\n\tv251 = hiddenMaterials.bottomMaterial;\n\tgoto L_004B;\nL_004B:\n\tv256 = UnityEngine.Object::op_Inequality(v251, 0);\n\tv264 = ~v256;\n\tv265 = ~v264;\n\tif (v265) goto L_00C1;\n\tv295 = hiddenMaterials.boxMaterial;\n\tgoto L_0057;\nL_0057:\n\tv300 = UnityEngine.Object::op_Inequality(v295, 0);\n\tv308 = ~v300;\n\tv309 = ~v308;\n\tif (v309) goto L_00D4;\n\tv334 = this.HiddenRoot;\n\tgoto L_0062;\nL_0062:\n\tv343 = UnityEngine.Object::op_Inequality(v334, 0);\n\tv354 = ~v343;\n\tv355 = ~v354;\n\tif (v355) goto L_00E9;\n\tv381 = this.SandCubeRoot;\n\tgoto L_006D;\nL_006D:\n\tv204 = UnityEngine.Object::op_Inequality(v381, 0);\n\tv393 = ~v204;\n\tv206 = ~v393;\n\tif (v206) goto L_00FE;\nL_0079:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::PlayOpen(this);\n\treturn;\nL_007F:\n\tgoto L_0083;\nL_0083:\n\tv146 = UnityEngine.Object::op_Inequality(this.m_jellyRenderer, 0);\n\tv148 = ~v146;\n\tif (v148) goto L_0079;\n\tgoto L_0092;\nL_0092:\n\tv113 = UnityEngine.Component::get_gameObject(this.m_jellyRenderer);\n\tv170 = UnityEngine.GameObject::get_activeSelf(v113);\n\tv174 = v170 == 0;\n\tif (v174) goto L_0079;\n\treturn;\nL_00AE:\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_jellyRenderer, hiddenMaterials.jellyMaterial);\n\tv251 = hiddenMaterials.bottomMaterial;\n\tgoto L_004B;\nL_00C1:\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_bottomRenderer, hiddenMaterials.bottomMaterial);\n\tv295 = hiddenMaterials.boxMaterial;\n\tgoto L_0057;\nL_00D4:\n\tUnityEngine.Renderer::set_sharedMaterial(this.m_boxRenderer, hiddenMaterials.boxMaterial);\n\tv334 = this.HiddenRoot;\n\tgoto L_0062;\nL_00E9:\n\tUnityEngine.GameObject::SetActive(this.HiddenRoot, 0);\n\tv381 = this.SandCubeRoot;\n\tgoto L_006D;\nL_00FE:\n\tUnityEngine.GameObject::SetActive(this.SandCubeRoot, 1);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::PlayOpen(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ApplyBoosterPreview(JellyMaterialPair hiddenMaterials)
		{
			if (HiddenRoot != null && HiddenRoot.activeSelf)
			{
				UnityEngine.Object bottomMaterial;
				if (!(hiddenMaterials.jellyMaterial != null))
				{
					bottomMaterial = hiddenMaterials.bottomMaterial;
				}
				else
				{
					m_jellyRenderer.sharedMaterial = hiddenMaterials.jellyMaterial;
					bottomMaterial = hiddenMaterials.bottomMaterial;
				}
				UnityEngine.Object boxMaterial;
				if (!(bottomMaterial != null))
				{
					boxMaterial = hiddenMaterials.boxMaterial;
				}
				else
				{
					m_bottomRenderer.sharedMaterial = hiddenMaterials.bottomMaterial;
					boxMaterial = hiddenMaterials.boxMaterial;
				}
				UnityEngine.Object hiddenRoot;
				if (!(boxMaterial != null))
				{
					hiddenRoot = HiddenRoot;
				}
				else
				{
					m_boxRenderer.sharedMaterial = hiddenMaterials.boxMaterial;
					hiddenRoot = HiddenRoot;
				}
				UnityEngine.Object sandCubeRoot;
				if (!(hiddenRoot != null))
				{
					sandCubeRoot = SandCubeRoot;
				}
				else
				{
					HiddenRoot.SetActive(value: false);
					sandCubeRoot = SandCubeRoot;
				}
				if (sandCubeRoot != null)
				{
					SandCubeRoot.SetActive(value: true);
					PlayOpen();
					return;
				}
			}
			else if (m_jellyRenderer != null)
			{
				GameObject gameObject = m_jellyRenderer.gameObject;
				if (gameObject.activeSelf)
				{
					return;
				}
			}
			PlayOpen();
		}

		[Token(Token = "0x6000773")]
		[Address(RVA = "0x3E698C4", Offset = "0x3E698C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::ApplyMaterial(this, color);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetHidden(this, isHidden);\n\tv40 = ~isHidden;\n\tv41 = ~v40;\n\tif (v41) goto L_0026;\n\tv42 = ~isOpen;\n\tif (v42) goto L_0026;\n\tv57 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetOpen(v57);\n\treturn;\nL_0026:\n\tv47 = _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::SetClosed(this);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase::ResetSandCubeAnimatorToIdle(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreFromBoosterPreview(GameColor color, bool isHidden, bool isOpen)
		{
			ApplyMaterial(color);
			SetHidden(isHidden);
			if (!isHidden && isOpen)
			{
				SandCubeMonoBase sandCubeMonoBase = default(SandCubeMonoBase);
				sandCubeMonoBase.SetOpen();
				return;
			}
			SetClosed();
			ResetSandCubeAnimatorToIdle();
		}

		[Token(Token = "0x6000774")]
		[Address(RVA = "0x3E6993C", Offset = "0x3E6993C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_animator, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0042;\n\treturn;\nL_0042:\n\tgoto L_004D;\nL_004D:\n\tUnityEngine.Animator::Play(this.m_animator, v125.IdleStateHash, 0, 0f);\n\tUnityEngine.Animator::Update(this.m_animator, 0f);\n\treturn;\n")]
		private void ResetSandCubeAnimatorToIdle()
		{
			if (!(m_animator == null))
			{
				m_animator.Play(IdleStateHash, 0, 0f);
				m_animator.Update(0f);
			}
		}

		[Token(Token = "0x6000775")]
		[Address(RVA = "0x3E68834", Offset = "0x3E68834", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.m_jellyIdle, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0036;\n\tgoto L_0056;\nL_0036:\n\tv109 = UnityEngine.Behaviour::get_enabled(this.m_jellyIdle);\n\tv95 = v109 == active;\n\tif (v95) goto L_0056;\n\tUnityEngine.Behaviour::set_enabled(this.m_jellyIdle, active);\n\treturn;\nL_0056:\n\treturn;\n")]
		private void SetJellyIdle(bool active)
		{
			if (!(m_jellyIdle == null))
			{
				bool flag = m_jellyIdle.enabled;
				if (flag != active)
				{
					m_jellyIdle.enabled = active;
				}
			}
		}

		[Token(Token = "0x6000776")]
		[Address(RVA = "0x3E68574", Offset = "0x3E68574", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tv66 = UnityEngine.Object::op_Equality(this.OverlayContent, 0);\n\tv75 = v66 == 0;\n\tif (v75) goto L_0045;\n\treturn;\nL_0045:\n\t;\n\tv105 = PrimeTween.Tween::get_isAlive(&this._overlayPosTween (PrimeTween.Tween));\n\tv147 = ~v105;\n\tif (v147) goto L_0060;\n\tPrimeTween.Tween::Stop(&this._overlayPosTween (PrimeTween.Tween));\nL_0060:\n\tUnityEngine.Transform::set_localPosition(this.OverlayContent, localPos);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SnapOverlay(Vector3 localPos)
		{
			if (!(OverlayContent == null))
			{
				if (_overlayPosTween.isAlive)
				{
					_overlayPosTween.Stop();
				}
				OverlayContent.localPosition = localPos;
			}
		}

		[Token(Token = "0x6000777")]
		[Address(RVA = "0x3E6938C", Offset = "0x3E6938C", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\nL_003A:\n\tv78 = UnityEngine.Object::op_Equality(this.OverlayContent, 0);\n\tv83 = v78 == 0;\n\tif (v83) goto L_0053;\n\treturn;\nL_0053:\n\t;\n\tv109 = PrimeTween.Tween::get_isAlive(&this._overlayPosTween (PrimeTween.Tween));\n\tv204 = ~v109;\n\tif (v204) goto L_005E;\n\tPrimeTween.Tween::Stop(&this._overlayPosTween (PrimeTween.Tween));\nL_005E:\n\tv141 = this.m_overlayTweenDuration == 0;\n\tv210 = this.m_overlayTweenDuration < 0;\n\tv138 = ~v210;\n\tv211 = ~v138;\n\tv129 = v211 | v141;\n\tif (v129) goto L_00BA;\n\tv215 = UnityEngine.Transform::get_localPosition(this.OverlayContent);\n\tv59.from.x = v215;\n\tv59.from.y = v215.y;\n\tv59.from.z = v215.z;\n\tv59.to.x = targetLocalPos;\n\tv59.to.y = targetLocalPos.y;\n\tv59.to.z = targetLocalPos.z;\n\tv59.curve = this.m_overlayTweenCurve;\n\tv227 = new System.Action`2<UnityEngine.Transform, System.Single>();\n\tSystem.Action`2<UnityEngine.Transform, System.Single>::.ctor(v227, v59, Il2CppMethodInfo);\n\tv237 = PrimeTween.Tween::Custom(this.OverlayContent, 0f, 1f, this.m_overlayTweenDuration, v227, 0, 1, 0, 0f, 0f, 0);\n\tthis._overlayPosTween.tween = v227;\n\tthis._overlayPosTween.id = v237;\n\treturn;\nL_00BA:\n\tUnityEngine.Transform::set_localPosition(this.OverlayContent, targetLocalPos);\n\treturn;\nL_002E:\n\tv59 = new _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.UnityBindings.Scripts.SandCubeMonoBase+<>c__DisplayClass56_0();\n\tSystem.Object::.ctor(v59);\n\tgoto L_003A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TweenOverlayTo(Vector3 targetLocalPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandCubeMonoBase::TweenOverlayTo");
		}

		[Token(Token = "0x6000778")]
		[Address(RVA = "0x3E69A4C", Offset = "0x3E69A4C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis._openAnim = \"Armature|JellyBox_Open\";\n\tthis._hiddenOpenAnim = \"Armature|Hidden_Reveal\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0024:\n\tthis.m_overlayTweenDuration = 0.4f;\n\tv60 = UnityEngine.AnimationCurve::EaseInOut(0f, 0f, 1f, 1f);\n\tthis.m_overlayTweenCurve = v60;\n\tthis.BreakAnimDuration = 0.5f;\n\tthis.m_explodeVfxDelay = 0.1f;\n\tthis._breakAnim = \"Armature|PopSand\";\n")]
		public SandCubeMonoBase()
		{
			AnimationCurve overlayTweenCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
			m_overlayTweenCurve = overlayTweenCurve;
			m_breakAnimDuration = 0.5f;
			m_explodeVfxDelay = 0.1f;
			_breakAnim = "Armature|PopSand";
			_openAnim = "Armature|JellyBox_Open";
			_hiddenOpenAnim = "Armature|Hidden_Reveal";
		}

		[Token(Token = "0x6000779")]
		[Address(RVA = "0x3E69B48", Offset = "0x3E69B48", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv48 = UnityEngine.Animator::StringToHash(\"New State\");\n\tv52.IdleStateHash = v48;\n\treturn;\n")]
		static SandCubeMonoBase()
		{
			int idleStateHash = Animator.StringToHash("New State");
			IdleStateHash = idleStateHash;
		}
	}
}
