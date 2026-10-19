using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x200006D")]
	public class ShowScreenshotThumbnail : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200006F")]
		private sealed class _003CShowCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400025B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400025C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400025D")]
			[FieldOffset(Offset = "0x20")]
			public ShowScreenshotThumbnail _003C_003E4__this;

			[Token(Token = "0x17000031")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000204")]
				[Address(RVA = "0x3C4B250", Offset = "0x3C4B250", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000032")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000206")]
				[Address(RVA = "0x3C4B298", Offset = "0x3C4B298", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000201")]
			[Address(RVA = "0x3C4ADD4", Offset = "0x3C4ADD4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CShowCoroutine_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000202")]
			[Address(RVA = "0x3C4AFB0", Offset = "0x3C4AFB0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000203")]
			[Address(RVA = "0x3C4AFB4", Offset = "0x3C4AFB4", Length = "0x29C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_00E1;\n\tthis.<>1__state = -1;\n\tgoto L_003B;\nL_003B:\n\tv139 = UnityEngine.Object::FindObjectOfType();\n\tv48.m_ScreenshotManager = v139;\n\tv86 = UnityEngine.Object::op_Equality(v48.m_ScreenshotManager, 0);\n\tv233 = v86 == 0;\n\tv89 = ~v233;\n\tif (v89) goto L_00E1;\n\tv141 = UnityEngine.Component::get_gameObject(v48.m_Canvas);\n\tUnityEngine.GameObject::SetActive(v141, 1);\n\tUnityEngine.Behaviour::set_enabled(v48.m_Canvas, 1);\n\tgoto L_0066;\n\tUnityEngine.Events.UnityAction::Invoke(v241.onThumbnailStartDelegate);\n\tv144 = AlmostEngine.Screenshot.ScreenshotManager::GetLastScreenshotTexture(v48.m_ScreenshotManager);\n\tUnityEngine.UI.RawImage::set_texture(v48.m_Texture, v144);\n\tv245 = UnityEngine.UI.RawImage::SetNativeSize(v48.m_Texture);\n\tv117 = UnityEngine.RectTransform::get_rect(v48.m_ImageContainer);\n\tv169 = v48.m_Texture;\n\tv246 = UnityEngine.Texture::get_height(v169.texture);\n\tv149 = UnityEngine.Component::get_transform(v48.m_Texture);\n\tv248 = v117.height / v246;\n\t// 160 MakeStruct v192 @ AGG3C4B188_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v248 @ V0_v4 (System.Single), v248 @ V0_v4 (System.Single), v248 @ V0_v4 (System.Single)\n\tUnityEngine.Transform::set_localScale(v149, v192);\n\tv253 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v253, v48.m_DisplayDuration);\n\tthis.<>2__current = v253;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_00BD:\n\tthis.<>1__state = -1;\n\tUnityEngine.Behaviour::set_enabled(v48.m_Canvas, 0);\n\tgoto L_00D0;\n\tUnityEngine.Events.UnityAction::Invoke(v229.onThumbnailEndDelegate);\nL_0020:\n\tv48 = this.<>4__this;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_00BD;\nL_00E1:\n\treturn 0;\nL_0066:\n\t;\nL_00D0:\n\t;\n")]
			private bool MoveNext()
			{
				ShowScreenshotThumbnail showScreenshotThumbnail = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						ScreenshotManager screenshotManager = UnityEngine.Object.FindObjectOfType<ScreenshotManager>();
						showScreenshotThumbnail.m_ScreenshotManager = screenshotManager;
						if (!(showScreenshotThumbnail.m_ScreenshotManager == null))
						{
							GameObject gameObject = showScreenshotThumbnail.m_Canvas.gameObject;
							gameObject.SetActive(value: true);
							showScreenshotThumbnail.m_Canvas.enabled = true;
							onThumbnailStartDelegate();
							Texture2D lastScreenshotTexture = showScreenshotThumbnail.m_ScreenshotManager.GetLastScreenshotTexture();
							showScreenshotThumbnail.m_Texture.texture = lastScreenshotTexture;
							showScreenshotThumbnail.m_Texture.SetNativeSize();
							Rect rect = showScreenshotThumbnail.m_ImageContainer.rect;
							RawImage texture = showScreenshotThumbnail.m_Texture;
							int height = texture.texture.height;
							Transform transform = showScreenshotThumbnail.m_Texture.transform;
							Vector3 localScale = default(Vector3);
							localScale.z = (localScale.y = (localScale.x = rect.height / (float)height));
							transform.localScale = localScale;
							WaitForSeconds waitForSeconds = new WaitForSeconds(showScreenshotThumbnail.m_DisplayDuration);
							_003C_003E2__current = waitForSeconds;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					showScreenshotThumbnail.m_Canvas.enabled = false;
					onThumbnailEndDelegate();
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000205")]
			[Address(RVA = "0x3C4B258", Offset = "0x3C4B258", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x20")]
		private ScreenshotManager m_ScreenshotManager;

		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x28")]
		public Canvas m_Canvas;

		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x30")]
		public RectTransform m_ImageContainer;

		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x38")]
		public RawImage m_Texture;

		[Token(Token = "0x4000257")]
		public static UnityAction onThumbnailStartDelegate;

		[Token(Token = "0x4000258")]
		public static UnityAction onThumbnailEndDelegate;

		[Token(Token = "0x4000259")]
		[FieldOffset(Offset = "0x40")]
		public float m_DisplayDuration;

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x3C4AA94", Offset = "0x3C4AA94", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv78 = v76 == 0;\n\tif (v78) goto L_0065;\n\tv90 = *([v76 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v90) goto L_0073;\n\tv105.onCaptureEndDelegate = v76;\n\tv117 = *([v76 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v117) goto L_0073;\n\treturn;\nL_0065:\n\tv92.onCaptureEndDelegate = 0;\n\treturn;\nL_0073:\n\tthrow System.InvalidCastException;\nL_0026:\n\tgoto L_002C;\nL_002C:\n\tv66 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v66, this, Il2CppMethodInfo);\n\tv76 = System.Delegate::Combine(v63.onCaptureEndDelegate, v66);\n")]
		private void OnEnable()
		{
			UnityAction b = OnCaptureEndDelegate;
			Delegate obj = Delegate.Combine(ScreenshotManager.onCaptureEndDelegate, b);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(UnityAction))
				{
					ScreenshotManager.onCaptureEndDelegate = (UnityAction)obj;
					if ((object)obj.GetType() == typeof(UnityAction))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			ScreenshotManager.onCaptureEndDelegate = null;
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x3C4ABB8", Offset = "0x3C4ABB8", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv78 = v76 == 0;\n\tif (v78) goto L_0065;\n\tv90 = *([v76 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v90) goto L_0073;\n\tv105.onCaptureEndDelegate = v76;\n\tv117 = *([v76 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v117) goto L_0073;\n\treturn;\nL_0065:\n\tv92.onCaptureEndDelegate = 0;\n\treturn;\nL_0073:\n\tthrow System.InvalidCastException;\nL_0026:\n\tgoto L_002C;\nL_002C:\n\tv66 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v66, this, Il2CppMethodInfo);\n\tv76 = System.Delegate::Remove(v63.onCaptureEndDelegate, v66);\n")]
		private void OnDisable()
		{
			UnityAction value = OnCaptureEndDelegate;
			Delegate obj = Delegate.Remove(ScreenshotManager.onCaptureEndDelegate, value);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(UnityAction))
				{
					ScreenshotManager.onCaptureEndDelegate = (UnityAction)obj;
					if ((object)obj.GetType() == typeof(UnityAction))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			ScreenshotManager.onCaptureEndDelegate = null;
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x3C4ACDC", Offset = "0x3C4ACDC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.ShowScreenshotThumbnail+<ShowCoroutine>d__10();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public void OnCaptureEndDelegate()
		{
			_003CShowCoroutine_003Ed__10 _003CShowCoroutine_003Ed__11 = (_003CShowCoroutine_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CShowCoroutine_003Ed__10));
			_003CShowCoroutine_003Ed__11._003C_003E1__state = 0;
			_003CShowCoroutine_003Ed__11._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CShowCoroutine_003Ed__11);
		}

		[IteratorStateMachine(typeof(_003CShowCoroutine_003Ed__10))]
		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x3C4AD5C", Offset = "0x3C4AD5C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.ShowScreenshotThumbnail+<ShowCoroutine>d__10();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator ShowCoroutine()
		{
			_003CShowCoroutine_003Ed__10 _003CShowCoroutine_003Ed__11 = (_003CShowCoroutine_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CShowCoroutine_003Ed__10));
			_003CShowCoroutine_003Ed__11._003C_003E1__state = 0;
			_003CShowCoroutine_003Ed__11._003C_003E4__this = this;
			return _003CShowCoroutine_003Ed__11;
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x3C4AE00", Offset = "0x3C4AE00", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_DisplayDuration = 2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ShowScreenshotThumbnail()
		{
			m_DisplayDuration = 2f;
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x3C4AE10", Offset = "0x3C4AE10", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv94 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v94, v91.<>9, Il2CppMethodInfo);\n\tv100.onThumbnailEndDelegate = v94;\n\treturn;\nL_0031:\n\tgoto L_0037;\nL_0037:\n\tv73 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v73, v70.<>9, Il2CppMethodInfo);\n\tv85.onThumbnailStartDelegate = v73;\n")]
		static ShowScreenshotThumbnail()
		{
			UnityAction unityAction = delegate
			{
			};
			onThumbnailStartDelegate = unityAction;
			UnityAction unityAction2 = delegate
			{
			};
			onThumbnailEndDelegate = unityAction2;
		}
	}
}
