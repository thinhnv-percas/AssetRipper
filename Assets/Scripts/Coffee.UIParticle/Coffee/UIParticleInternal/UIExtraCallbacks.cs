using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x200001B")]
	internal static class UIExtraCallbacks
	{
		[Token(Token = "0x4000022")]
		private static bool s_IsInitializedAfterCanvasRebuild;

		[Token(Token = "0x4000023")]
		internal static readonly FastAction s_AfterCanvasRebuildAction;

		[Token(Token = "0x4000024")]
		internal static readonly FastAction s_LateAfterCanvasRebuildAction;

		[Token(Token = "0x4000025")]
		private static readonly FastAction s_BeforeCanvasRebuildAction;

		[Token(Token = "0x4000026")]
		private static readonly FastAction s_OnScreenSizeChangedAction;

		[Token(Token = "0x4000027")]
		private static Vector2Int s_LastScreenSize;

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x3F20AEC", Offset = "0x3F20AEC", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_003F:\n\tCoffee.UIParticleInternal.FastAction::.ctor(v49);\n\tv88.s_AfterCanvasRebuildAction = v49;\n\tv93 = new Coffee.UIParticleInternal.FastAction();\n\tgoto L_005A;\nL_005E:\n\tCoffee.UIParticleInternal.FastAction::.ctor(v93);\n\tv117.s_LateAfterCanvasRebuildAction = v93;\n\tv122 = new Coffee.UIParticleInternal.FastAction();\n\tgoto L_0079;\nL_007D:\n\tCoffee.UIParticleInternal.FastAction::.ctor(v122);\n\tv146.s_BeforeCanvasRebuildAction = v122;\n\tv151 = new Coffee.UIParticleInternal.FastAction();\n\tgoto L_009C;\nL_00A0:\n\tCoffee.UIParticleInternal.FastAction::.ctor(v151);\n\tv179.s_OnScreenSizeChangedAction = v151;\n\tv184 = new UnityEngine.Canvas+WillRenderCanvases();\n\tUnityEngine.Canvas+WillRenderCanvases::.ctor(v184, 0, Il2CppMethodInfo);\n\tUnityEngine.Canvas::add_willRenderCanvases(v184);\n\treturn;\nL_0021:\n\tv49 = new Coffee.UIParticleInternal.FastAction();\n\tgoto L_003B;\nL_003B:\n\tgoto L_003F;\nL_005A:\n\tgoto L_005E;\nL_0079:\n\tgoto L_007D;\nL_009C:\n\tgoto L_00A0;\n")]
		static UIExtraCallbacks()
		{
			FastAction fastAction = new FastAction();
			s_AfterCanvasRebuildAction = fastAction;
			FastAction fastAction2 = new FastAction();
			s_LateAfterCanvasRebuildAction = fastAction2;
			FastAction fastAction3 = new FastAction();
			s_BeforeCanvasRebuildAction = fastAction3;
			FastAction fastAction4 = new FastAction();
			s_OnScreenSizeChangedAction = fastAction4;
			Canvas.WillRenderCanvases value = OnBeforeCanvasRebuild;
			Canvas.willRenderCanvases += value;
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x3F1FD68", Offset = "0x3F1FD68", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v49.s_LateAfterCanvasRebuildAction, value);\n\treturn;\n")]
		public static void add_onLateAfterCanvasRebuild(Action value)
		{
			s_LateAfterCanvasRebuildAction.Add(value);
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x3F20D40", Offset = "0x3F20D40", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Remove(v49.s_LateAfterCanvasRebuildAction, value);\n\treturn;\n")]
		public static void remove_onLateAfterCanvasRebuild(Action value)
		{
			s_LateAfterCanvasRebuildAction.Remove(value);
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x3F20DE4", Offset = "0x3F20DE4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v49.s_BeforeCanvasRebuildAction, value);\n\treturn;\n")]
		public static void add_onBeforeCanvasRebuild(Action value)
		{
			s_BeforeCanvasRebuildAction.Add(value);
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x3F20E88", Offset = "0x3F20E88", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Remove(v49.s_BeforeCanvasRebuildAction, value);\n\treturn;\n")]
		public static void remove_onBeforeCanvasRebuild(Action value)
		{
			s_BeforeCanvasRebuildAction.Remove(value);
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x3F20F2C", Offset = "0x3F20F2C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v49.s_AfterCanvasRebuildAction, value);\n\treturn;\n")]
		public static void add_onAfterCanvasRebuild(Action value)
		{
			s_AfterCanvasRebuildAction.Add(value);
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x3F20FD0", Offset = "0x3F20FD0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Remove(v49.s_AfterCanvasRebuildAction, value);\n\treturn;\n")]
		public static void remove_onAfterCanvasRebuild(Action value)
		{
			s_AfterCanvasRebuildAction.Remove(value);
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x3F21074", Offset = "0x3F21074", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Add(v49.s_OnScreenSizeChangedAction, value);\n\treturn;\n")]
		public static void add_onScreenSizeChanged(Action value)
		{
			s_OnScreenSizeChangedAction.Add(value);
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x3F21118", Offset = "0x3F21118", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tCoffee.UIParticleInternal.FastActionBase`1<System.Action>::Remove(v49.s_OnScreenSizeChangedAction, value);\n\treturn;\n")]
		public static void remove_onScreenSizeChanged(Action value)
		{
			s_OnScreenSizeChangedAction.Remove(value);
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x3F211BC", Offset = "0x3F211BC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tgoto L_0016;\nL_0016:\n\tv50 = v47.s_IsInitializedAfterCanvasRebuild == 0;\n\tif (v50) goto L_0040;\n\treturn;\nL_0040:\n\tgoto L_0049;\nL_0051:\n\tv129 = UnityEngine.UI.CanvasUpdateRegistry::IsRebuildingLayout();\n\tv133 = new UnityEngine.Canvas+WillRenderCanvases();\n\tUnityEngine.Canvas+WillRenderCanvases::.ctor(v133, 0, Il2CppMethodInfo);\n\tUnityEngine.Canvas::add_willRenderCanvases(v133);\n\treturn;\nL_0049:\n\tv114.s_IsInitializedAfterCanvasRebuild = 1;\n\tgoto L_0051;\n")]
		private static void InitializeAfterCanvasRebuild()
		{
			if (!s_IsInitializedAfterCanvasRebuild)
			{
				s_IsInitializedAfterCanvasRebuild = true;
				bool flag = CanvasUpdateRegistry.IsRebuildingLayout();
				Canvas.WillRenderCanvases value = OnAfterCanvasRebuild;
				Canvas.willRenderCanvases += value;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		[Token(Token = "0x6000078")]
		[Address(RVA = "0x3F212E0", Offset = "0x3F212E0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_002E;\nL_002E:\n\tv64.s_IsInitializedAfterCanvasRebuild = 0;\n\treturn;\nL_0020:\n\tv49 = new UnityEngine.Canvas+WillRenderCanvases();\n\tUnityEngine.Canvas+WillRenderCanvases::.ctor(v49, 0, Il2CppMethodInfo);\n\tUnityEngine.Canvas::remove_willRenderCanvases(v49);\n")]
		private static void InitializeOnLoad()
		{
			Canvas.WillRenderCanvases value = OnAfterCanvasRebuild;
			Canvas.willRenderCanvases -= value;
			s_IsInitializedAfterCanvasRebuild = false;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x3F213AC", Offset = "0x3F213AC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0022:\n\tv110 = v44 | v47;\n\tv65 = v52.s_LastScreenSize != v110;\n\tif (v65) goto L_0049;\n\tgoto L_0033;\nL_0033:\n\tv139 = v137.s_BeforeCanvasRebuildAction == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_005C;\n\tgoto L_0085;\nL_0049:\n\tgoto L_004A;\nL_004A:\n\tv157 = v52.s_LastScreenSize == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_006F;\n\tgoto L_0051;\nL_0051:\n\tv226.s_LastScreenSize = v110;\n\tgoto L_0033;\nL_005C:\n\tCoffee.UIParticleInternal.FastAction::Invoke(v137.s_BeforeCanvasRebuildAction);\n\tCoffee.UIParticleInternal.UIExtraCallbacks::InitializeAfterCanvasRebuild();\n\treturn;\nL_006F:\n\tgoto L_0076;\nL_0076:\n\tCoffee.UIParticleInternal.FastAction::Invoke(v212.s_OnScreenSizeChangedAction);\n\tgoto L_0051;\nL_0085:\n\tthrow System.NullReferenceException;\nL_0016:\n\tv44 = UnityEngine.Screen::get_width();\n\tv47 = UnityEngine.Screen::get_height();\n\tgoto L_0022;\n")]
		private static void OnBeforeCanvasRebuild()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UIExtraCallbacks::OnBeforeCanvasRebuild");
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x3F21504", Offset = "0x3F21504", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0013;\nL_0013:\n\tv45 = v43.s_AfterCanvasRebuildAction == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0027;\n\tgoto L_0034;\nL_0027:\n\tCoffee.UIParticleInternal.FastAction::Invoke(v43.s_AfterCanvasRebuildAction);\n\tCoffee.UIParticleInternal.FastAction::Invoke(v65.s_LateAfterCanvasRebuildAction);\n\treturn;\nL_0034:\n\tthrow System.NullReferenceException;\n")]
		private static void OnAfterCanvasRebuild()
		{
			if (s_AfterCanvasRebuildAction != null)
			{
				s_AfterCanvasRebuildAction.Invoke();
				s_LateAfterCanvasRebuildAction.Invoke();
				return;
			}
			throw new NullReferenceException();
		}
	}
}
