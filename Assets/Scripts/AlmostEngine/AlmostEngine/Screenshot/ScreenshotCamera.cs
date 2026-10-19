using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x200000E")]
	public class ScreenshotCamera
	{
		[Token(Token = "0x200000F")]
		public enum CustomSettings
		{
			[Token(Token = "0x400002C")]
			KEEP_CAMERA_SETTINGS = 0,
			[Token(Token = "0x400002D")]
			CUSTOM = 1
		}

		[Token(Token = "0x2000010")]
		public class Settings
		{
			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x10")]
			public bool m_Enabled;

			[Token(Token = "0x400002F")]
			[FieldOffset(Offset = "0x11")]
			public bool m_GameObjectEnabled;

			[Token(Token = "0x4000030")]
			[FieldOffset(Offset = "0x14")]
			public CameraClearFlags m_ClearFlags;

			[Token(Token = "0x4000031")]
			[FieldOffset(Offset = "0x18")]
			public Color m_BackgroundColor;

			[Token(Token = "0x4000032")]
			[FieldOffset(Offset = "0x28")]
			public int m_CullingMask;

			[Token(Token = "0x4000033")]
			[FieldOffset(Offset = "0x2C")]
			public float m_FOV;

			[Token(Token = "0x4000034")]
			[FieldOffset(Offset = "0x30")]
			public Color m_HDClearColor;

			[Token(Token = "0x600001E")]
			[Address(RVA = "0x3C2F1B4", Offset = "0x3C2F1B4", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv50 = UnityEngine.Behaviour::get_enabled(camera);\n\tthis.m_Enabled = v50;\n\tv54 = UnityEngine.Component::get_gameObject(camera);\n\tgoto L_002D;\n\tthis.m_BackgroundColor.r = v100;\n\tthis.m_BackgroundColor.g = v100.g;\n\tthis.m_BackgroundColor.b = v100.b;\n\tthis.m_BackgroundColor.a = v100.a;\n\tv103 = UnityEngine.Camera::get_cullingMask(camera);\n\tthis.m_CullingMask = v103;\n\tv70 = UnityEngine.Camera::get_fieldOfView(camera);\n\tthis.m_FOV = v70;\n\treturn;\nL_0017:\n\tSystem.Object::.ctor(this);\nL_002D:\n\tv94 = UnityEngine.Object::op_Implicit(v54);\n\tthis.m_GameObjectEnabled = v94;\n\tv97 = UnityEngine.Camera::get_clearFlags(camera);\n\tthis.m_ClearFlags = v97;\n\tv100 = UnityEngine.Camera::get_backgroundColor(camera);\n")]
			public Settings(Camera camera)
			{
				m_Enabled = camera.enabled;
				m_GameObjectEnabled = camera.gameObject;
				CameraClearFlags clearFlags = camera.clearFlags;
				m_ClearFlags = clearFlags;
				Color backgroundColor = camera.backgroundColor;
				m_BackgroundColor.r = backgroundColor.r;
				m_BackgroundColor.g = backgroundColor.g;
				m_BackgroundColor.b = backgroundColor.b;
				m_BackgroundColor.a = backgroundColor.a;
				m_CullingMask = camera.cullingMask;
				m_FOV = camera.fieldOfView;
			}
		}

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x10")]
		public bool m_Active = true;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		public Camera m_Camera;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x20")]
		public CustomSettings m_ClearSettings;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x24")]
		public CameraClearFlags m_ClearFlags = CameraClearFlags.Skybox;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		public Color m_BackgroundColor = default(Color);

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x38")]
		public CustomSettings m_CullingSettings;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x3C")]
		public int m_CullingMask = -1;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x40")]
		public CustomSettings m_FOVSettings;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x44")]
		public float m_FOV = 70f;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x48")]
		public Stack<Settings> m_SettingStack;

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3C2EE44", Offset = "0x3C2EE44", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tthis.m_Active = 1;\n\tthis.m_ClearFlags = 1;\n\tthis.m_BackgroundColor = 0;\n\tthis.m_CullingMask = -1;\n\tthis.m_FOV = 70f;\n\tv52 = new System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>();\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>::.ctor(v52);\n\tthis.m_SettingStack = v52;\n")]
		public ScreenshotCamera()
		{
			Stack<Settings> settingStack = new Stack<Settings>();
			m_SettingStack = settingStack;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3C2EEF4", Offset = "0x3C2EEF4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tSystem.Object::.ctor(this);\n\tthis.m_Camera = cam;\n\treturn;\nL_001F:\n\tthis.m_Active = 1;\n\tthis.m_ClearFlags = 1;\n\tthis.m_BackgroundColor = 0;\n\tthis.m_CullingMask = -1;\n\tthis.m_FOV = 70f;\n\tv57 = new System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>();\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>::.ctor(v57);\n\tthis.m_SettingStack = v57;\n")]
		public ScreenshotCamera(Camera cam)
		{
			Stack<Settings> settingStack = new Stack<Settings>();
			m_SettingStack = settingStack;
			m_Camera = cam;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3C2EFC0", Offset = "0x3C2EFC0", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv60 = UnityEngine.Object::op_Equality(this.m_Camera, 0);\n\tv70 = v60 == 0;\n\tif (v70) goto L_003F;\n\tgoto L_00C1;\nL_003F:\n\tv90 = new AlmostEngine.Screenshot.ScreenshotCamera+Settings();\n\tAlmostEngine.Screenshot.ScreenshotCamera+Settings::.ctor(v90, this.m_Camera);\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>::Push(this.m_SettingStack, v90);\n\tv270 = UnityEngine.Behaviour::get_enabled(this.m_Camera);\n\tv271 = ~v270;\n\tv272 = ~v271;\n\tif (v272) goto L_0062;\n\tv273 = ~isOffscreen;\n\tif (v273) goto L_0062;\n\tv277 = UnityEngine.Component::get_gameObject(this.m_Camera);\n\tv245 = 0;\n\tgoto L_0067;\nL_0062:\n\tv277 = UnityEngine.Component::get_gameObject(this.m_Camera);\n\tv245 = 1;\n\tUnityEngine.Behaviour::set_enabled(this.m_Camera, 1);\n\tv220 = this.m_ClearSettings != 1;\n\tif (v220) goto L_0094;\n\tUnityEngine.Camera::set_clearFlags(this.m_Camera, this.m_ClearFlags);\n\t// 136 MakeStruct v280 @ AGG3C2F148_1_v4 (UnityEngine.Color), typeof(UnityEngine.Color), this.m_BackgroundColor (UnityEngine.Color), this.m_BackgroundColor.g (System.Single), this.m_BackgroundColor.b (System.Single), this.m_BackgroundColor.a (System.Single)\n\tUnityEngine.Camera::set_backgroundColor(this.m_Camera, v280);\nL_0094:\n\tv221 = this.m_CullingSettings != 1;\n\tif (v221) goto L_00A6;\n\tUnityEngine.Camera::set_cullingMask(this.m_Camera, this.m_CullingMask);\nL_00A6:\n\tv108 = this.m_FOVSettings != 1;\n\tif (v108) goto L_00C1;\n\tUnityEngine.Camera::set_fieldOfView(this.m_Camera, this.m_FOV);\n\treturn;\nL_00C1:\n\treturn;\nL_0067:\n\tUnityEngine.GameObject::SetActive(v277, v245);\n")]
		public void ApplySettings(bool isOffscreen = false)
		{
			if (!(m_Camera == null))
			{
				Settings item = new Settings(m_Camera);
				m_SettingStack.Push(item);
				GameObject gameObject;
				bool active;
				if (!m_Camera.enabled && isOffscreen)
				{
					gameObject = m_Camera.gameObject;
					active = false;
				}
				else
				{
					gameObject = m_Camera.gameObject;
					active = true;
				}
				gameObject.SetActive(active);
				m_Camera.enabled = true;
				if (m_ClearSettings == CustomSettings.CUSTOM)
				{
					m_Camera.clearFlags = m_ClearFlags;
					Color backgroundColor = default(Color);
					backgroundColor.r = m_BackgroundColor.r;
					backgroundColor.g = m_BackgroundColor.g;
					backgroundColor.b = m_BackgroundColor.b;
					backgroundColor.a = m_BackgroundColor.a;
					m_Camera.backgroundColor = backgroundColor;
				}
				if (m_CullingSettings == CustomSettings.CUSTOM)
				{
					m_Camera.cullingMask = m_CullingMask;
				}
				if (m_FOVSettings == CustomSettings.CUSTOM)
				{
					m_Camera.fieldOfView = m_FOV;
				}
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3C2F2A0", Offset = "0x3C2F2A0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Camera, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0043;\n\treturn;\nL_0043:\n\tv97 = new AlmostEngine.Screenshot.ScreenshotCamera+Settings();\n\tAlmostEngine.Screenshot.ScreenshotCamera+Settings::.ctor(v97, this.m_Camera);\n\tSystem.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>::Push(this.m_SettingStack, v97);\n\tUnityEngine.Behaviour::set_enabled(this.m_Camera, 0);\n\treturn;\n")]
		public void Disable()
		{
			if (!(m_Camera == null))
			{
				Settings item = new Settings(m_Camera);
				m_SettingStack.Push(item);
				m_Camera.enabled = false;
			}
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3C2F3B4", Offset = "0x3C2F3B4", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_Camera, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0037;\n\tgoto L_0089;\nL_0037:\n\tv80 = this.m_SettingStack;\n\tv88 = v80.Count < 1;\n\tif (v88) goto L_0089;\n\tv162 = System.Collections.Generic.Stack`1<AlmostEngine.Screenshot.ScreenshotCamera+Settings>::Pop(v80);\n\tUnityEngine.Behaviour::set_enabled(this.m_Camera, v162.m_Enabled);\n\tv165 = UnityEngine.Component::get_gameObject(this.m_Camera);\n\tUnityEngine.GameObject::SetActive(v165, v162.m_GameObjectEnabled);\n\tUnityEngine.Camera::set_clearFlags(this.m_Camera, v162.m_ClearFlags);\n\t// 108 MakeStruct v130 @ AGG3C2F4E0_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v162.m_BackgroundColor (UnityEngine.Color), v162.m_BackgroundColor.g (System.Single), v162.m_BackgroundColor.b (System.Single), v162.m_BackgroundColor.a (System.Single)\n\tUnityEngine.Camera::set_backgroundColor(this.m_Camera, v130);\n\tUnityEngine.Camera::set_cullingMask(this.m_Camera, v162.m_CullingMask);\n\tUnityEngine.Camera::set_fieldOfView(this.m_Camera, v162.m_FOV);\n\treturn;\nL_0089:\n\treturn;\n")]
		public void RestoreSettings()
		{
			if (!(m_Camera == null))
			{
				Stack<Settings> settingStack = m_SettingStack;
				if (settingStack.Count >= 1)
				{
					Settings settings = settingStack.Pop();
					m_Camera.enabled = settings.m_Enabled;
					GameObject gameObject = m_Camera.gameObject;
					gameObject.SetActive(settings.m_GameObjectEnabled);
					m_Camera.clearFlags = settings.m_ClearFlags;
					Color backgroundColor = default(Color);
					backgroundColor.r = settings.m_BackgroundColor.r;
					backgroundColor.g = settings.m_BackgroundColor.g;
					backgroundColor.b = settings.m_BackgroundColor.b;
					backgroundColor.a = settings.m_BackgroundColor.a;
					m_Camera.backgroundColor = backgroundColor;
					m_Camera.cullingMask = settings.m_CullingMask;
					m_Camera.fieldOfView = settings.m_FOV;
				}
			}
		}
	}
}
