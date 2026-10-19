using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot.Extra
{
	[RequireComponent(typeof(Canvas))]
	[Token(Token = "0x2000053")]
	public class GreyboxCanvas : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000054")]
		private sealed class _003CDelayedUpdate_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400020C")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400020D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400020E")]
			[FieldOffset(Offset = "0x20")]
			public GreyboxCanvas _003C_003E4__this;

			[Token(Token = "0x1700002B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000199")]
				[Address(RVA = "0x3C44590", Offset = "0x3C44590", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600019B")]
				[Address(RVA = "0x3C445D8", Offset = "0x3C445D8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000196")]
			[Address(RVA = "0x3C43EEC", Offset = "0x3C43EEC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CDelayedUpdate_003Ed__14(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000197")]
			[Address(RVA = "0x3C444BC", Offset = "0x3C444BC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000198")]
			[Address(RVA = "0x3C444C0", Offset = "0x3C444C0", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv53 = this.<>1__state != 1;\n\tif (v53) goto L_002F;\n\tthis.<>1__state = -1;\n\tv68 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::DoUpdate(this.<>4__this);\nL_003E:\n\tthis.<>1__state = -1;\n\tv58 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v58);\n\tthis.<>2__current = v58;\n\tthis.<>1__state = 1;\n\tv111 = this.<>1__state == 0;\n\treturn v111;\nL_0015:\n\tv43 = this.<>1__state == 0;\n\tif (v43) goto L_003E;\nL_002F:\n\tv76 = this.<>1__state == 0;\n\treturn v76;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						_003C_003E4__this.DoUpdate();
					}
					return _003C_003E1__state == 0;
				}
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600019A")]
			[Address(RVA = "0x3C44598", Offset = "0x3C44598", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x20")]
		public RectTransform m_ImageContainer;

		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x28")]
		public RectTransform m_PreviousButton;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x30")]
		public RectTransform m_NextButton;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x38")]
		public RectTransform m_CloseButton;

		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x40")]
		public RectTransform m_ShareButton;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x48")]
		public Text m_PageText;

		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x50")]
		public Text m_FileName;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x58")]
		private ScreenshotGallery m_Gallery;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x60")]
		private int m_CurrentImageId;

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x3C43C64", Offset = "0x3C43C64", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Gallery = gallery;\n\tthis.m_CurrentImageId = i;\n\tv33 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::UpdateUI(v33);\n\treturn;\n")]
		public void SetImage(ScreenshotGallery gallery, int i)
		{
			m_Gallery = gallery;
			m_CurrentImageId = i;
			GreyboxCanvas greyboxCanvas = default(GreyboxCanvas);
			greyboxCanvas.UpdateUI();
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x3C43C9C", Offset = "0x3C43C9C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv124 = this.m_Gallery;\n\tv92 = v124.m_ImageFiles;\n\tv49 = v92.Count >= this.m_CurrentImageId;\n\tif (v49) goto L_004E;\nL_003A:\n\tgoto L_003E;\nL_003E:\n\tUnityEngine.Debug::LogError(\"Error getting the image, invalid ID\");\n\tv124 = this.m_Gallery;\nL_004E:\n\treturnVal2 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.TextureExporter+ImageFile>::get_Item(v124.m_ImageFiles, this.m_CurrentImageId);\n\treturn returnVal2;\nL_001C:\n\tv40 = this.m_CurrentImageId & 0x80000000;\n\tv41 = v40 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_003A;\n")]
		public TextureExporter.ImageFile GetCurrentImage()
		{
			//IL_009b: Expected I4, but got I8
			ScreenshotGallery gallery;
			if ((int)(m_CurrentImageId & 0x80000000L) == 0)
			{
				gallery = m_Gallery;
				List<TextureExporter.ImageFile> imageFiles = gallery.m_ImageFiles;
				if (imageFiles.Count >= m_CurrentImageId)
				{
					goto IL_006a;
				}
			}
			Debug.LogError("Error getting the image, invalid ID");
			gallery = m_Gallery;
			goto IL_006a;
			IL_006a:
			return gallery.m_ImageFiles[m_CurrentImageId];
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x3C43D70", Offset = "0x3C43D70", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(this);\n\tv9 = v6 == 0;\n\treturnVal1 = v6;\n\tif (v9) goto L_000B;\n\treturnVal1 = v6.m_Texture;\nL_000B:\n\treturn returnVal1;\n")]
		public Texture2D GetCurrentImageTexture()
		{
			TextureExporter.ImageFile currentImage = GetCurrentImage();
			bool flag = currentImage == null;
			Texture2D result = (Texture2D)(object)currentImage;
			if (!flag)
			{
				result = currentImage.m_Texture;
			}
			return result;
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x3C43D8C", Offset = "0x3C43D8C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = 0xB2E5000 + 0x208;\n\tgoto L_0018;\n\tv61 = v17;\n\tgoto L_0031;\nL_0018:\n\tv47 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(v42);\n\tv61 = v47 + 0x20;\n\tv58 = v47 != 0;\n\tif (v58) goto L_0031;\nL_0031:\n\treturn *([v61 @ X8_v4 (System.Int32)]);\n")]
		public string GetCurrentImagePath()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GreyboxCanvas::GetCurrentImagePath");
			return default;
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x3C43DF4", Offset = "0x3C43DF4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.GreyboxCanvas+<DelayedUpdate>d__14();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public virtual void UpdateUI()
		{
			_003CDelayedUpdate_003Ed__14 _003CDelayedUpdate_003Ed__15 = (_003CDelayedUpdate_003Ed__14)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdate_003Ed__14));
			_003CDelayedUpdate_003Ed__15._003C_003E1__state = 0;
			_003CDelayedUpdate_003Ed__15._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CDelayedUpdate_003Ed__15);
		}

		[IteratorStateMachine(typeof(_003CDelayedUpdate_003Ed__14))]
		[Token(Token = "0x600018C")]
		[Address(RVA = "0x3C43E74", Offset = "0x3C43E74", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.Extra.GreyboxCanvas+<DelayedUpdate>d__14();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator DelayedUpdate()
		{
			_003CDelayedUpdate_003Ed__14 _003CDelayedUpdate_003Ed__15 = (_003CDelayedUpdate_003Ed__14)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdate_003Ed__14));
			_003CDelayedUpdate_003Ed__15._003C_003E1__state = 0;
			_003CDelayedUpdate_003Ed__15._003C_003E4__this = this;
			return _003CDelayedUpdate_003Ed__15;
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x3C43F18", Offset = "0x3C43F18", Length = "0x39C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv147 = UnityEngine.Component::GetComponentInChildren(this.m_ImageContainer);\n\tUnityEngine.UI.RawImage::set_texture(v147, v52.m_Texture);\n\tv219 = UnityEngine.RectTransform::get_rect(this.m_ImageContainer);\n\tv220 = UnityEngine.RectTransform::get_rect(this.m_ImageContainer);\n\tv346 = UnityEngine.Texture::get_width(v52.m_Texture);\n\tv348 = v219.width / v220.height;\n\tv349 = UnityEngine.Texture::get_height(v52.m_Texture);\n\tv351 = v346 / v349;\n\tv106 = v351 / v348;\n\tv261 = UnityEngine.Component::GetComponentInChildren(v147);\n\tv191 = v106 < 1f;\n\tv354 = v106 == v106;\n\tv171 = 1f == 1f;\n\tv176 = v354 & v171;\n\tv166 = ~v176;\n\tv161 = v191 == v166;\n\tif (v161) goto L_0073;\n\tv360 = UnityEngine.Component::get_transform(v261);\n\tv112 = 1f;\n\tv114 = v106;\n\tgoto L_007C;\nL_0073:\n\tv360 = UnityEngine.Component::get_transform(v261);\n\tv112 = 1f / v106;\n\tv114 = 1f;\nL_0085:\n\tv369 = UnityEngine.Object::op_Inequality(this.m_PreviousButton, 0);\n\tv373 = ~v369;\n\tv374 = ~v373;\n\tif (v374) goto L_00AD;\n\tv399 = this.m_NextButton;\n\tgoto L_0090;\nL_0090:\n\tv407 = UnityEngine.Object::op_Inequality(v399, 0);\n\tv418 = ~v407;\n\tv419 = ~v418;\n\tif (v419) goto L_00CF;\n\tv232 = this.m_ShareButton;\n\tgoto L_009C;\nL_009C:\n\tv449 = UnityEngine.Object::op_Inequality(v232, 0);\n\tv457 = this.m_FileName == 0;\n\tv285 = ~v457;\n\tif (v285) goto L_0107;\n\tgoto L_0136;\nL_00AD:\n\tv391 = this.m_CurrentImageId == 0;\n\tif (v391) goto L_00BA;\n\tv462 = UnityEngine.Component::get_gameObject(this.m_PreviousButton);\n\tv398 = 1;\n\tgoto L_00BF;\nL_00BA:\n\tv462 = UnityEngine.Component::get_gameObject(this.m_PreviousButton);\n\tv398 = 0;\nL_00CF:\n\tv304 = this.m_Gallery;\n\tv305 = v304.m_ImageFiles;\n\tv306 = v305.Count - 1;\n\tv163 = this.m_CurrentImageId >= v306;\n\tif (v163) goto L_00EF;\n\tv484 = UnityEngine.Component::get_gameObject(this.m_NextButton);\n\tv442 = 1;\n\tgoto L_00F4;\nL_00EF:\n\tv484 = UnityEngine.Component::get_gameObject(this.m_NextButton);\n\tv442 = 0;\nL_0107:\n\tv472 = UnityEngine.UI.Text::set_text(this.m_FileName, v52.m_Name);\n\tv474 = this.m_CurrentImageId + 1;\n\tv151 = v474;\n\tv273 = System.Int32::ToString(&v151 @ stack_-54_v3 (System.Int32));\n\tv308 = this.m_Gallery;\n\tv309 = v308.m_ImageFiles;\n\tv151 = v309.Count;\n\tv480 = System.Int32::ToString(&v151 @ stack_-54_v3 (System.Int32));\n\tv274 = System.String::Concat(v273, \"/\", v480);\n\tv124 = UnityEngine.UI.Text::set_text(this.m_PageText, v274);\nL_0136:\n\tthrow System.NullReferenceException;\nL_0022:\n\tv52 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(this);\n\tv56 = v52 == 0;\n\tif (v56) goto L_0135;\nL_0135:\n\treturn;\nL_007C:\n\t// 124 MakeStruct v64 @ AGG3C4407C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v114 @ V0_v8 (System.Single), v112 @ V1_v6 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v360, v64);\n\tgoto L_0085;\nL_00BF:\n\tUnityEngine.GameObject::SetActive(v462, v398);\n\tv399 = this.m_NextButton;\n\tgoto L_0090;\nL_00F4:\n\tUnityEngine.GameObject::SetActive(v484, v442);\n\tv232 = this.m_ShareButton;\n\tgoto L_009C;\n")]
		public virtual void DoUpdate()
		{
			TextureExporter.ImageFile currentImage = GetCurrentImage();
			if (currentImage == null)
			{
				return;
			}
			RawImage componentInChildren = m_ImageContainer.GetComponentInChildren<RawImage>();
			componentInChildren.texture = currentImage.m_Texture;
			Rect rect = m_ImageContainer.rect;
			Rect rect2 = m_ImageContainer.rect;
			int width = currentImage.m_Texture.width;
			float num = rect.width / rect2.height;
			int height = currentImage.m_Texture.height;
			int num2 = width / height;
			float num3 = (float)num2 / num;
			RawImage componentInChildren2 = componentInChildren.GetComponentInChildren<RawImage>();
			bool flag = num3 < 1f;
			bool flag2 = num3 == num3;
			bool flag3 = 1f == 1f;
			bool flag4 = flag2 && flag3;
			bool flag5 = !flag4;
			Transform transform;
			float y;
			float x;
			if (flag != flag5)
			{
				transform = componentInChildren2.transform;
				y = 1f;
				x = num3;
			}
			else
			{
				transform = componentInChildren2.transform;
				y = 1f / num3;
				x = 1f;
			}
			Vector3 localScale = default(Vector3);
			localScale.x = x;
			localScale.y = y;
			localScale.z = 1f;
			transform.localScale = localScale;
			UnityEngine.Object nextButton;
			if (!(m_PreviousButton != null))
			{
				nextButton = m_NextButton;
			}
			else
			{
				GameObject gameObject;
				bool active;
				if (m_CurrentImageId != 0)
				{
					gameObject = m_PreviousButton.gameObject;
					active = true;
				}
				else
				{
					gameObject = m_PreviousButton.gameObject;
					active = false;
				}
				gameObject.SetActive(active);
				nextButton = m_NextButton;
			}
			UnityEngine.Object shareButton;
			if (!(nextButton != null))
			{
				shareButton = m_ShareButton;
			}
			else
			{
				ScreenshotGallery gallery = m_Gallery;
				List<TextureExporter.ImageFile> imageFiles = gallery.m_ImageFiles;
				int num4 = imageFiles.Count - 1;
				GameObject gameObject2;
				bool active2;
				if (m_CurrentImageId < num4)
				{
					gameObject2 = m_NextButton.gameObject;
					active2 = true;
				}
				else
				{
					gameObject2 = m_NextButton.gameObject;
					active2 = false;
				}
				gameObject2.SetActive(active2);
				shareButton = m_ShareButton;
			}
			bool flag6 = shareButton != null;
			if ((object)m_FileName != null)
			{
				m_FileName.text = currentImage.m_Name;
				int num5 = m_CurrentImageId + 1;
				int num6 = num5;
				string text = num6.ToString();
				ScreenshotGallery gallery2 = m_Gallery;
				List<TextureExporter.ImageFile> imageFiles2 = gallery2.m_ImageFiles;
				string text2 = imageFiles2.Count.ToString();
				string text3 = text + "/" + text2;
				m_PageText.text = text3;
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x3C442B4", Offset = "0x3C442B4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(this);\n\treturn v6.m_Name;\n")]
		public virtual string GetShareTitle()
		{
			TextureExporter.ImageFile currentImage = GetCurrentImage();
			return currentImage.m_Name;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x3C442D4", Offset = "0x3C442D4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv92 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(this);\n\tgoto L_002D;\nL_0018:\n\tv44 = AlmostEngine.Screenshot.Extra.GreyboxCanvas::GetCurrentImage(this);\nL_002D:\n\t;\n\tv96 = System.DateTime::ToString(&v92.m_CreationDate (System.DateTime));\n\treturnVal2 = System.String::Concat(v44.m_Name, \"\\n\", v96);\n\treturn returnVal2;\n")]
		public virtual string GetShareText()
		{
			TextureExporter.ImageFile currentImage = GetCurrentImage();
			TextureExporter.ImageFile currentImage2 = GetCurrentImage();
			string text = currentImage2.m_CreationDate.ToString();
			return currentImage.m_Name + "\n" + text;
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x3C4438C", Offset = "0x3C4438C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_CurrentImageId + 1;\n\tthis.m_CurrentImageId = v2;\n\tthis = AlmostEngine.Screenshot.Extra.GreyboxCanvas::UpdateUI(this);\n\treturn;\n")]
		public virtual void NextPageCallback()
		{
			int currentImageId = m_CurrentImageId + 1;
			m_CurrentImageId = currentImageId;
			UpdateUI();
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x3C443A4", Offset = "0x3C443A4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_CurrentImageId - 1;\n\tthis.m_CurrentImageId = v2;\n\tthis = AlmostEngine.Screenshot.Extra.GreyboxCanvas::UpdateUI(this);\n\treturn;\n")]
		public virtual void PreviousPageCallback()
		{
			int currentImageId = m_CurrentImageId - 1;
			m_CurrentImageId = currentImageId;
			UpdateUI();
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x3C443BC", Offset = "0x3C443BC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v13, 0);\n\tv26 = UnityEngine.Component::get_gameObject(this.m_Gallery);\n\tUnityEngine.GameObject::SetActive(v26, 1);\n\tv27 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(v27);\n\treturn;\n")]
		public virtual void CloseCallback()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			GameObject gameObject2 = m_Gallery.gameObject;
			gameObject2.SetActive(value: true);
			ScreenshotGallery screenshotGallery = default(ScreenshotGallery);
			screenshotGallery.UpdateGallery();
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x3C44424", Offset = "0x3C44424", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v13, 0);\n\tv34 = UnityEngine.Component::get_gameObject(this.m_Gallery);\n\tUnityEngine.GameObject::SetActive(v34, 1);\n\tv73 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::RemoveImage(this.m_Gallery, this.m_CurrentImageId);\n\tv66 = AlmostEngine.Screenshot.Extra.ScreenshotGallery::UpdateGallery(this.m_Gallery);\n\tthis.m_CurrentImageId = -1;\n\treturn;\n")]
		public virtual void RemoveCallback()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			GameObject gameObject2 = m_Gallery.gameObject;
			gameObject2.SetActive(value: true);
			m_Gallery.RemoveImage(m_CurrentImageId);
			m_Gallery.UpdateGallery();
			m_CurrentImageId = -1;
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0x3C444B0", Offset = "0x3C444B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void ShareCallback()
		{
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0x3C444B4", Offset = "0x3C444B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GreyboxCanvas()
		{
		}
	}
}
