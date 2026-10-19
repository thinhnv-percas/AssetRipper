using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x200002C")]
	public class ScreenshotOverlay
	{
		[Token(Token = "0x200002D")]
		public class Settings
		{
			[Token(Token = "0x4000116")]
			[FieldOffset(Offset = "0x10")]
			public bool m_Enabled;

			[Token(Token = "0x4000117")]
			[FieldOffset(Offset = "0x11")]
			public bool m_GameObjectEnabled;

			[Token(Token = "0x60000C2")]
			[Address(RVA = "0x3C3A180", Offset = "0x3C3A180", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Enabled = enabled;\n\tthis.m_GameObjectEnabled = go;\n\treturn;\n")]
			public Settings(bool enabled, bool go)
			{
				m_Enabled = enabled;
				m_GameObjectEnabled = go;
			}
		}

		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x10")]
		public Canvas m_Canvas;

		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x18")]
		public bool m_Active = true;

		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x20")]
		public Stack<Settings> m_SettingStack;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x28")]
		private Canvas m_Instance;

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x3C39E60", Offset = "0x3C39E60", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tthis.m_Active = 1;\n\tv49 = new System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>();\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>::.ctor(v49);\n\tthis.m_SettingStack = v49;\n")]
		public ScreenshotOverlay()
		{
			Stack<Settings> settingStack = new Stack<Settings>();
			m_SettingStack = settingStack;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x3C3955C", Offset = "0x3C3955C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tSystem.Object::.ctor(this);\n\tthis.m_Canvas = canvas;\n\treturn;\nL_001F:\n\tthis.m_Active = 1;\n\tv54 = new System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>();\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>::.ctor(v54);\n\tthis.m_SettingStack = v54;\n")]
		public ScreenshotOverlay(Canvas canvas)
		{
			Stack<Settings> settingStack = new Stack<Settings>();
			m_SettingStack = settingStack;
			m_Canvas = canvas;
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x3C39EF4", Offset = "0x3C39EF4", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_Canvas, 0);\n\tv69 = v59 == 0;\n\tif (v69) goto L_004D;\n\treturn;\nL_004D:\n\tv160 = UnityEngine.Behaviour::get_enabled(this.m_Canvas);\n\tv184 = UnityEngine.Component::get_gameObject(this.m_Canvas);\n\tv219 = UnityEngine.GameObject::get_activeSelf(v184);\n\tv185 = new AlmostEngine.Screenshot.ScreenshotOverlay+Settings();\n\tSystem.Object::.ctor(v185);\n\tv185.m_Enabled = v160;\n\tv185.m_GameObjectEnabled = v219;\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>::Push(this.m_SettingStack, v185);\n\tv187 = UnityEngine.Component::get_transform(this.m_Canvas);\n\tv188 = UnityEngine.Component::get_gameObject(v187);\n\tv224 = UnityEngine.GameObject::get_activeInHierarchy(v188);\n\tv226 = v224 == 0;\n\tif (v226) goto L_0099;\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, this.m_Active);\n\tv133 = UnityEngine.Component::get_gameObject(this.m_Canvas);\n\tUnityEngine.GameObject::SetActive(v133, this.m_Active);\n\treturn;\nL_0099:\n\tgoto L_00A1;\n\tUnityEngine.Object::set_hideFlags(this.m_Instance, 0x34);\n\tUnityEngine.Behaviour::set_enabled(this.m_Instance, 1);\n\tv194 = UnityEngine.Component::get_gameObject(this.m_Instance);\n\tUnityEngine.GameObject::SetActive(v194, 1);\n\tv242 = UnityEngine.Object::get_name(this.m_Instance);\n\tv246 = System.String::Concat(v242, \" - temporary instance, remove if still exists after capture process\");\n\tUnityEngine.Object::set_name(this.m_Instance, v246);\n\treturn;\nL_00A1:\n\tv237 = UnityEngine.Object::Instantiate(this.m_Canvas);\n\tthis.m_Instance = v237;\n")]
		public void ApplySettings()
		{
			if (!(m_Canvas == null))
			{
				bool enabled = m_Canvas.enabled;
				GameObject gameObject = m_Canvas.gameObject;
				bool activeSelf = gameObject.activeSelf;
				Settings settings = (Settings)FormatterServices.GetUninitializedObject(typeof(Settings));
				settings.m_Enabled = enabled;
				settings.m_GameObjectEnabled = activeSelf;
				m_SettingStack.Push(settings);
				Transform transform = m_Canvas.transform;
				GameObject gameObject2 = transform.gameObject;
				if (gameObject2.activeInHierarchy)
				{
					m_Canvas.enabled = m_Active;
					GameObject gameObject3 = m_Canvas.gameObject;
					gameObject3.SetActive(m_Active);
					return;
				}
				Canvas instance = UnityEngine.Object.Instantiate(m_Canvas);
				m_Instance = instance;
				m_Instance.hideFlags = HideFlags.DontSave;
				m_Instance.enabled = true;
				GameObject gameObject4 = m_Instance.gameObject;
				gameObject4.SetActive(value: true);
				string name = m_Instance.name;
				string name2 = name + " - temporary instance, remove if still exists after capture process";
				m_Instance.name = name2;
			}
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x3C3A1BC", Offset = "0x3C3A1BC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_Canvas, 0);\n\tv69 = v59 == 0;\n\tif (v69) goto L_0047;\n\treturn;\nL_0047:\n\tv141 = UnityEngine.Behaviour::get_enabled(this.m_Canvas);\n\tv150 = UnityEngine.Component::get_gameObject(this.m_Canvas);\n\tv158 = UnityEngine.GameObject::get_activeSelf(v150);\n\tv151 = new AlmostEngine.Screenshot.ScreenshotOverlay+Settings();\n\tSystem.Object::.ctor(v151);\n\tv151.m_Enabled = v141;\n\tv151.m_GameObjectEnabled = v158;\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>::Push(this.m_SettingStack, v151);\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, 0);\n\treturn;\n")]
		public void Disable()
		{
			if (!(m_Canvas == null))
			{
				bool enabled = m_Canvas.enabled;
				GameObject gameObject = m_Canvas.gameObject;
				bool activeSelf = gameObject.activeSelf;
				Settings settings = (Settings)FormatterServices.GetUninitializedObject(typeof(Settings));
				settings.m_Enabled = enabled;
				settings.m_GameObjectEnabled = activeSelf;
				m_SettingStack.Push(settings);
				m_Canvas.enabled = false;
			}
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x3C3A314", Offset = "0x3C3A314", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_Canvas, 0);\n\tv69 = v59 == 0;\n\tif (v69) goto L_0039;\n\tgoto L_0082;\nL_0039:\n\tv84 = this.m_SettingStack;\n\tv92 = v84.Count < 1;\n\tif (v92) goto L_0082;\n\tv223 = System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotOverlay+Settings>::Pop(v84);\n\tgoto L_0058;\nL_0058:\n\tv230 = UnityEngine.Object::op_Inequality(this.m_Instance, 0);\n\tv232 = ~v230;\n\tif (v232) goto L_0092;\n\tv243 = UnityEngine.Component::get_gameObject(this.m_Instance);\n\tgoto L_006A;\nL_0082:\n\treturn;\nL_0092:\n\tUnityEngine.Behaviour::set_enabled(this.m_Canvas, v223.m_Enabled);\n\tv161 = UnityEngine.Component::get_gameObject(this.m_Canvas);\n\tUnityEngine.GameObject::SetActive(v161, v223.m_GameObjectEnabled);\n\treturn;\nL_006A:\n\tUnityEngine.Object::DestroyImmediate(v243);\n\tthis.m_Instance = 0;\n\treturn;\n")]
		public void RestoreSettings()
		{
			if (m_Canvas == null)
			{
				return;
			}
			Stack<Settings> settingStack = m_SettingStack;
			if (settingStack.Count >= 1)
			{
				Settings settings = settingStack.Pop();
				if (m_Instance != null)
				{
					GameObject gameObject = m_Instance.gameObject;
					UnityEngine.Object.DestroyImmediate(gameObject);
					m_Instance = null;
				}
				else
				{
					m_Canvas.enabled = settings.m_Enabled;
					GameObject gameObject2 = m_Canvas.gameObject;
					gameObject2.SetActive(settings.m_GameObjectEnabled);
				}
			}
		}
	}
}
