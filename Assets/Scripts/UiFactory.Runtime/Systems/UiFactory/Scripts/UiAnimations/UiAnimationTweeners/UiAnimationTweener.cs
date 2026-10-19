using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using _game.Scripts.TweenerSystem;
using _game.Scripts.TweenerSystem.TweenElements;
using _game.Scripts.TweenerSystem.TweenElements.Transform;
using _game.Scripts.TweenerSystem.TweenElements.Ui;

namespace Systems.UiFactory.Scripts.UiAnimations.UiAnimationTweeners
{
	[RequireComponent(typeof(Tweener))]
	[Token(Token = "0x2000004")]
	public class UiAnimationTweener : MonoBehaviour
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		internal Tweener _tweener;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81A1138", Offset = "0x81A1138", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis._tweener = v46;\n\treturn;\n")]
		private void Awake()
		{
			Tweener component = GetComponent<Tweener>();
			_tweener = component;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81A119C", Offset = "0x81A119C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = _game.Scripts.TweenerSystem.Tweener::Play(this._tweener);\n\t_game.Scripts.TweenerSystem.Tweener::OnComplete(this._tweener, onComplete);\n\treturn;\n")]
		public void Play(Action onComplete = null)
		{
			Sequence sequence = _tweener.Play();
			_tweener.OnComplete(onComplete);
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81A11E0", Offset = "0x81A11E0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.Scripts.TweenerSystem.Tweener::Stop(this._tweener);\n\treturn;\n")]
		public void Kill(bool complete = false)
		{
			_tweener.Stop();
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81A11FC", Offset = "0x81A11FC", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv92 = UnityEngine.Component::GetComponent(targetTransform);\n\tgoto L_004E;\nL_004E:\n\tv169 = UnityEngine.Object::op_Inequality(v92, 0);\n\tv217 = ~v169;\n\tv218 = ~v217;\n\tif (v218) goto L_0067;\n\tgoto L_0080;\nL_0067:\n\tv228 = v61.Length < 1;\n\tif (v228) goto L_0080;\n\tv269 = 0;\nL_0080:\n\tv258 = UnityEngine.Component::GetComponent(targetTransform);\n\tgoto L_0089;\nL_0089:\n\tv267 = UnityEngine.Object::op_Inequality(v258, 0);\n\tv282 = ~v267;\n\tv283 = ~v282;\n\tv144 = v267;\n\tif (v283) goto L_00A2;\n\tv144 = v267;\n\tgoto L_00C4;\nL_00A2:\n\tv293 = v69.Length < 1;\n\tif (v293) goto L_00C4;\n\tv360 = 0;\nL_00C4:\n\tv330 = v77.Length < 1;\n\tif (v330) goto L_00E4;\n\tv373 = 0;\nL_00E4:\n\treturn;\nL_0031:\n\tv61 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n\tv69 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n\tv77 = UnityEngine.Component::GetComponentsInChildren(this, 1);\nL_006D:\n\tSystems.UiFactory.Scripts.UiAnimations.UiAnimationTweeners.UiAnimationTweener::SetCanvasGroupTarget(v169, v61[v269 @ X25_v5 (System.Int32)], v92);\n\tv269 = v269 + 1;\n\tv227 = v269 < v61.Length;\n\tif (v227) goto L_006D;\nL_00A8:\n\tSystems.UiFactory.Scripts.UiAnimations.UiAnimationTweeners.UiAnimationTweener::SetRectTransformTarget(v144, v69[v360 @ X23_v8 (System.Int32)], v258);\n\tv360 = v360 + 1;\n\tv292 = v360 < v69.Length;\n\tif (v292) goto L_00A8;\nL_00CA:\n\tSystems.UiFactory.Scripts.UiAnimations.UiAnimationTweeners.UiAnimationTweener::SetTransformTarget(v144, v77[v373 @ X21_v7 (System.Int32)], targetTransform);\n\tv373 = v373 + 1;\n\tv334 = v373 < v77.Length;\n\tif (v334) goto L_00CA;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetupTargets(Transform targetTransform)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiAnimationTweener::SetupTargets");
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81A1438", Offset = "0x81A1438", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB799000;\n\tv22 = *([B799F07]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_003A;\n\tv26 = 0xB7D5000 + 0x538;\n\tv27 = *([v26 @ X8_v15 (System.Int32)+E0]);\n\tv29 = *([v27 @ X0_v20+E4]) == 0;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.CanvasGroupAlphaTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.CanvasGroupAlphaTweenElement;\n\tif (v29) goto L_0046;\nL_001A:\n\tv74 = System.Type::GetTypeFromHandle(v52);\nL_0024:\n\tv86 = System.Type::GetField(v74, \"m_canvasGroup\", 0x24);\n\tv87 = v86 == 0;\n\tif (v87) goto L_0052;\n\tSystem.Reflection.FieldInfo::SetValue(v86, element, target);\n\treturn;\nL_003A:\n\t*([v18 @ X21_v1+F07]) = 1;\n\tv71 = 0xB7D5000 + 0x538;\n\tv47 = *([v71 @ X8_v7 (System.Int32)+E0]);\n\tv72 = *([v47 @ X0_v14+E4]) == 0;\n\tv49 = ~v72;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.CanvasGroupAlphaTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.CanvasGroupAlphaTweenElement;\n\tif (v49) goto L_001A;\nL_0046:\n\tv74 = System.Type::GetTypeFromHandle(v60);\n\tv94 = v74 == 0;\n\tv76 = ~v94;\n\tif (v76) goto L_0024;\n\tthrow System.NullReferenceException;\nL_0052:\n\treturn;\n")]
		private void SetCanvasGroupTarget(CanvasGroupAlphaTweenElement element, CanvasGroup target)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiAnimationTweener::SetCanvasGroupTarget");
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81A152C", Offset = "0x81A152C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB799000;\n\tv22 = *([B799F08]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_003A;\n\tv26 = 0xB7D5000 + 0x538;\n\tv27 = *([v26 @ X8_v15 (System.Int32)+E0]);\n\tv29 = *([v27 @ X0_v20+E4]) == 0;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement;\n\tif (v29) goto L_0046;\nL_001A:\n\tv74 = System.Type::GetTypeFromHandle(v52);\nL_0024:\n\tv86 = System.Type::GetField(v74, \"m_target\", 0x24);\n\tv87 = v86 == 0;\n\tif (v87) goto L_0052;\n\tSystem.Reflection.FieldInfo::SetValue(v86, element, target);\n\treturn;\nL_003A:\n\t*([v18 @ X21_v1+F08]) = 1;\n\tv71 = 0xB7D5000 + 0x538;\n\tv47 = *([v71 @ X8_v7 (System.Int32)+E0]);\n\tv72 = *([v47 @ X0_v14+E4]) == 0;\n\tv49 = ~v72;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.Ui.RectTransformAnchoredPositionTweenElement;\n\tif (v49) goto L_001A;\nL_0046:\n\tv74 = System.Type::GetTypeFromHandle(v60);\n\tv94 = v74 == 0;\n\tv76 = ~v94;\n\tif (v76) goto L_0024;\n\tthrow System.NullReferenceException;\nL_0052:\n\treturn;\n")]
		private void SetRectTransformTarget(RectTransformAnchoredPositionTweenElement element, RectTransform target)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiAnimationTweener::SetRectTransformTarget");
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81A1620", Offset = "0x81A1620", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0xB799000;\n\tv22 = *([B799F09]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_003A;\n\tv26 = 0xB7D5000 + 0x538;\n\tv27 = *([v26 @ X8_v15 (System.Int32)+E0]);\n\tv29 = *([v27 @ X0_v20+E4]) == 0;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.Transform.TransformScaleTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.Transform.TransformScaleTweenElement;\n\tif (v29) goto L_0046;\nL_001A:\n\tv74 = System.Type::GetTypeFromHandle(v52);\nL_0024:\n\tv86 = System.Type::GetField(v74, \"m_target\", 0x24);\n\tv87 = v86 == 0;\n\tif (v87) goto L_0052;\n\tSystem.Reflection.FieldInfo::SetValue(v86, element, target);\n\treturn;\nL_003A:\n\t*([v18 @ X21_v1+F09]) = 1;\n\tv71 = 0xB7D5000 + 0x538;\n\tv47 = *([v71 @ X8_v7 (System.Int32)+E0]);\n\tv72 = *([v47 @ X0_v14+E4]) == 0;\n\tv49 = ~v72;\n\tv52 = _game.Scripts.TweenerSystem.TweenElements.Transform.TransformScaleTweenElement;\n\tv60 = _game.Scripts.TweenerSystem.TweenElements.Transform.TransformScaleTweenElement;\n\tif (v49) goto L_001A;\nL_0046:\n\tv74 = System.Type::GetTypeFromHandle(v60);\n\tv94 = v74 == 0;\n\tv76 = ~v94;\n\tif (v76) goto L_0024;\n\tthrow System.NullReferenceException;\nL_0052:\n\treturn;\n")]
		private void SetTransformTarget(TransformScaleTweenElement element, Transform target)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UiAnimationTweener::SetTransformTarget");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81A1714", Offset = "0x81A1714", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UiAnimationTweener()
		{
		}
	}
}
