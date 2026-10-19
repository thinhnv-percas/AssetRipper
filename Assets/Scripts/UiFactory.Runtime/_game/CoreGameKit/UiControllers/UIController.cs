using System;
using Systems.UiFactory.Scripts.UiAnimations.UiAnimationTweeners;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

namespace _game.CoreGameKit.UiControllers
{
	[RequireComponent(typeof(CanvasGroup), typeof(Canvas), typeof(GraphicRaycaster))]
	[Token(Token = "0x2000008")]
	public class UIController : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x20")]
		private string m_showAnimationTypes;

		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x28")]
		protected UiAnimationTweener m_showTweener;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x30")]
		private string m_hideAnimationTypes;

		[SerializeField]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x38")]
		protected UiAnimationTweener m_hideTweener;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x40")]
		internal UIFactory _baseFactory;

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81A19E4", Offset = "0x81A19E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._baseFactory = factory;\n\treturn;\n")]
		public void SetFactory(UIFactory factory)
		{
			_baseFactory = factory;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81A19EC", Offset = "0x81A19EC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv53 = _game.Scripts.TweenerSystem.Tweener::Play(v38._tweener);\n\t_game.Scripts.TweenerSystem.Tweener::OnComplete(v38._tweener, 0);\nL_0027:\n\t_game.CoreGameKit.UiControllers.UIFactory::Internal_Show(this._baseFactory, this);\n\treturn this;\nL_0012:\n\tv38 = this.m_showTweener;\n\tv39 = this.m_showTweener == 0;\n\tif (v39) goto L_0027;\n")]
		internal UIController Show()
		{
			UiAnimationTweener showTweener = m_showTweener;
			if ((object)m_showTweener != null)
			{
				Sequence sequence = showTweener._tweener.Play();
				showTweener._tweener.OnComplete(null);
			}
			_baseFactory.Internal_Show(this);
			return this;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81A1A78", Offset = "0x81A1A78", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = _game.CoreGameKit.UiControllers.UIController::Hide(this, 0);\n\treturn;\n")]
		public virtual void Hide()
		{
			Hide(null);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81A1A88", Offset = "0x81A1A88", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = _game.CoreGameKit.UiControllers.UIController::Hide(this);\n\treturn;\n")]
		internal void HideInternal()
		{
			Hide();
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81A1A94", Offset = "0x81A1A94", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = _game.CoreGameKit.UiControllers.UIController::Hide(this, onComplete);\n\treturn;\n")]
		internal void HideInternal(Action onComplete)
		{
			Hide(onComplete);
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x81A1AA0", Offset = "0x81A1AA0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Implicit(this.m_hideTweener);\n\tv74 = this._baseFactory;\n\tv66 = ~v55;\n\tif (v66) goto L_006B;\n\t_game.CoreGameKit.UiControllers.UIFactoryDataStore::RemoveFromScene(v74._dataStore, this);\n\tv111 = this.m_hideTweener;\n\tv101 = new System.Action();\n\tSystem.Action::.ctor(v101, this, Il2CppMethodInfo);\n\tv149 = _game.Scripts.TweenerSystem.Tweener::Play(v111._tweener);\n\t_game.Scripts.TweenerSystem.Tweener::OnComplete(v111._tweener, v101);\n\treturn;\nL_006B:\n\t_game.CoreGameKit.UiControllers.UIFactory::Hide(this._baseFactory, this, 1, onComplete);\n\treturn;\n")]
		public virtual void Hide(Action onComplete)
		{
			bool flag = m_hideTweener;
			UIFactory baseFactory = _baseFactory;
			if (flag)
			{
				baseFactory._dataStore.RemoveFromScene(this);
				UiAnimationTweener hideTweener = m_hideTweener;
				Action onComplete2 = delegate
				{
					_baseFactory.Hide(this, shouldRemove: false);
				};
				Sequence sequence = hideTweener._tweener.Play();
				hideTweener._tweener.OnComplete(onComplete2);
			}
			else
			{
				_baseFactory.Hide(this, shouldRemove: true, onComplete);
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x81A1E18", Offset = "0x81A1E18", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.m_showTweener, 0);\n\tv63 = ~v55;\n\tv64 = ~v63;\n\tif (v64) goto L_0049;\n\tv97 = this.m_hideTweener;\n\tgoto L_0024;\nL_0024:\n\tv102 = UnityEngine.Object::op_Inequality(v97, 0);\n\tv127 = ~v102;\n\tif (v127) goto L_0066;\n\tv123 = this.m_hideTweener;\n\t_game.Scripts.TweenerSystem.Tweener::Stop(v123._tweener);\n\treturn;\nL_0049:\n\tv86 = this.m_showTweener;\n\t_game.Scripts.TweenerSystem.Tweener::Stop(v86._tweener);\n\tv97 = this.m_hideTweener;\n\tgoto L_0024;\nL_0066:\n\treturn;\n")]
		public virtual void OnDisable()
		{
			UnityEngine.Object hideTweener;
			if (!(m_showTweener != null))
			{
				hideTweener = m_hideTweener;
			}
			else
			{
				UiAnimationTweener showTweener = m_showTweener;
				showTweener._tweener.Stop();
				hideTweener = m_hideTweener;
			}
			if (hideTweener != null)
			{
				UiAnimationTweener hideTweener2 = m_hideTweener;
				hideTweener2._tweener.Stop();
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x81A1F3C", Offset = "0x81A1F3C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreGameKit.UiControllers.UIFactory::ForceHide(this._baseFactory, this);\n\treturn;\n")]
		public virtual void ForceHide()
		{
			_baseFactory.ForceHide(this);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x81A209C", Offset = "0x81A209C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB799000;\n\tv18 = *([B799F14]) & 1;\n\tv19 = v18 == 0;\n\tif (v19) goto L_0027;\n\tv21 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v21;\n\tgoto L_001E;\nL_001E:\n\tUnityEngine.Object::Destroy(v53, 0f);\n\treturn;\nL_0027:\n\t*([v14 @ X20_v1+F14]) = 1;\n\tv49 = UnityEngine.Component::get_gameObject(this);\n\tv53 = v49;\n\tgoto L_001E;\n")]
		public virtual void Destroy()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799F14]");
			UnityEngine.Object obj2;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				GameObject gameObject = base.gameObject;
				obj2 = gameObject;
			}
			else
			{
				_ = 1;
				GameObject gameObject2 = base.gameObject;
				obj2 = gameObject2;
			}
			UnityEngine.Object.Destroy(obj2, 0f);
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x81A2148", Offset = "0x81A2148", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public UIController()
		{
		}
	}
}
