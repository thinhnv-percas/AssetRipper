using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000071")]
	public class ValidationCanvas : MonoBehaviour
	{
		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotManager m_ScreenshotManager;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x28")]
		public Canvas m_Canvas;

		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x30")]
		public RectTransform m_ImageContainer;

		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x38")]
		public RawImage m_Texture;

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x3C4B478", Offset = "0x3C4B478", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_0034:\n\tv70 = UnityEngine.Object::op_Equality(this.m_ScreenshotManager, 0);\n\tv74 = ~v70;\n\tif (v74) goto L_004D;\n\tgoto L_0040;\nL_0040:\n\tv104 = UnityEngine.Object::FindObjectOfType();\n\tthis.m_ScreenshotManager = v104;\nL_004D:\n\tgoto L_0053;\n\tv122 = v120 == 0;\n\tif (v122) goto L_0093;\n\tv134 = *([v120 @ X0_v12 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v134) goto L_009C;\n\tv141.onCaptureEndDelegate = v120;\n\tv153 = *([v120 @ X0_v12 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v153) goto L_009C;\n\tv210 = this.m_ScreenshotManager;\nL_008E:\n\tAlmostEngine.Screenshot.ScreenshotManager::UpdateAll(v210);\n\treturn;\nL_0093:\n\tv136.onCaptureEndDelegate = 0;\n\tv210 = this.m_ScreenshotManager;\n\tv183 = this.m_ScreenshotManager == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_008E;\n\tthrow System.NullReferenceException;\nL_009C:\n\tthrow System.InvalidCastException;\nL_002D:\n\tgoto L_0034;\nL_0053:\n\tv111 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v111, this, Il2CppMethodInfo);\n\tv120 = System.Delegate::Combine(v108.onCaptureEndDelegate, v111);\n")]
		public void Capture()
		{
			if (m_ScreenshotManager == null)
			{
				ScreenshotManager screenshotManager = UnityEngine.Object.FindObjectOfType<ScreenshotManager>();
				m_ScreenshotManager = screenshotManager;
			}
			UnityAction b = OnCaptureEndDelegate;
			Delegate obj = Delegate.Combine(ScreenshotManager.onCaptureEndDelegate, b);
			ScreenshotManager screenshotManager2;
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(UnityAction))
				{
					ScreenshotManager.onCaptureEndDelegate = (UnityAction)obj;
					if ((object)obj.GetType() == typeof(UnityAction))
					{
						screenshotManager2 = m_ScreenshotManager;
						goto IL_00d5;
					}
				}
				throw new InvalidCastException();
			}
			ScreenshotManager.onCaptureEndDelegate = null;
			screenshotManager2 = m_ScreenshotManager;
			if ((object)m_ScreenshotManager == null)
			{
				throw new NullReferenceException();
			}
			goto IL_00d5;
			IL_00d5:
			screenshotManager2.UpdateAll();
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x3C4B62C", Offset = "0x3C4B62C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv82 = v80 == 0;\n\tif (v82) goto L_0062;\n\tv94 = *([v80 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v94) goto L_00B6;\n\tv101.onCaptureEndDelegate = v80;\n\tv113 = *([v80 @ X0_v7 (System.Delegate)]) != UnityEngine.Events.UnityAction;\n\tif (v113) goto L_00B6;\n\tv185 = this.m_ScreenshotManager;\n\tv233 = this.m_ScreenshotManager == 0;\n\tv188 = ~v233;\n\tif (v188) goto L_006A;\n\tgoto L_00B4;\nL_0062:\n\tv96.onCaptureEndDelegate = 0;\n\tv185 = this.m_ScreenshotManager;\nL_006A:\n\tv191 = AlmostEngine.Screenshot.ScreenshotManager::GetLastScreenshotTexture(v185);\n\tUnityEngine.UI.RawImage::set_texture(this.m_Texture, v191);\n\tv277 = UnityEngine.UI.RawImage::SetNativeSize(this.m_Texture);\n\tv199 = UnityEngine.RectTransform::get_rect(this.m_ImageContainer);\n\tv230 = this.m_Texture;\n\tv278 = UnityEngine.Texture::get_height(v230.texture);\n\tv217 = UnityEngine.Component::get_transform(this.m_Texture);\n\tv200 = v199.height / v278;\n\t// 152 MakeStruct v192 @ AGG3C4B7D4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v200 @ V0_v5 (System.Single), v200 @ V0_v5 (System.Single), v200 @ V0_v5 (System.Single)\n\tUnityEngine.Transform::set_localScale(v217, v192);\n\tv218 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v218, 1);\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, 1);\n\treturn;\nL_00B4:\n\tthrow System.NullReferenceException;\nL_00B6:\n\tthrow System.InvalidCastException;\nL_0028:\n\tgoto L_002E;\nL_002E:\n\tv70 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v70, this, Il2CppMethodInfo);\n\tv80 = System.Delegate::Remove(v67.onCaptureEndDelegate, v70);\n")]
		public void OnCaptureEndDelegate()
		{
			UnityAction value = OnCaptureEndDelegate;
			Delegate obj = Delegate.Remove(ScreenshotManager.onCaptureEndDelegate, value);
			ScreenshotManager screenshotManager;
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(UnityAction))
				{
					ScreenshotManager.onCaptureEndDelegate = (UnityAction)obj;
					if ((object)obj.GetType() == typeof(UnityAction))
					{
						screenshotManager = m_ScreenshotManager;
						if ((object)m_ScreenshotManager == null)
						{
							throw new NullReferenceException();
						}
						goto IL_00c5;
					}
				}
				throw new InvalidCastException();
			}
			ScreenshotManager.onCaptureEndDelegate = null;
			screenshotManager = m_ScreenshotManager;
			goto IL_00c5;
			IL_00c5:
			Texture2D lastScreenshotTexture = screenshotManager.GetLastScreenshotTexture();
			m_Texture.texture = lastScreenshotTexture;
			m_Texture.SetNativeSize();
			Rect rect = m_ImageContainer.rect;
			RawImage texture = m_Texture;
			int height = texture.texture.height;
			Transform transform = m_Texture.transform;
			Vector3 localScale = default(Vector3);
			localScale.z = (localScale.y = (localScale.x = rect.height / (float)height));
			transform.localScale = localScale;
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
			m_Canvas.enabled = true;
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x3C4B828", Offset = "0x3C4B828", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v13, 0);\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, 0);\n\treturn;\n")]
		public void OnDiscardCallback()
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			m_Canvas.enabled = false;
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x3C4B870", Offset = "0x3C4B870", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.ScreenshotManager::ExportAllToFiles(this.m_ScreenshotManager);\n\tv26 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v26, 0);\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, 0);\n\treturn;\n")]
		public void OnSaveCallback()
		{
			m_ScreenshotManager.ExportAllToFiles();
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			m_Canvas.enabled = false;
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x3C4B8CC", Offset = "0x3C4B8CC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.ScreenshotManager::ShareAll(this.m_ScreenshotManager);\n\tv26 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v26, 0);\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, 0);\n\treturn;\n")]
		public void OnShareCallback()
		{
			m_ScreenshotManager.ShareAll();
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
			m_Canvas.enabled = false;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x3C4B928", Offset = "0x3C4B928", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ValidationCanvas()
		{
		}
	}
}
