using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Systems.TutorialSystem.Scripts.TutorialActions;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class TutorialData
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000010")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000029")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400002A")]
			public static Action<TutorialAction> _003C_003E9__11_0;

			[Token(Token = "0x400002B")]
			public static Action<TutorialAction> _003C_003E9__12_0;

			[Token(Token = "0x400002C")]
			public static Action<Tween> _003C_003E9__12_1;

			[Token(Token = "0x600004D")]
			[Address(RVA = "0x81E04DC", Offset = "0x81E04DC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Systems.TutorialSystem.Scripts.TutorialData+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600004E")]
			[Address(RVA = "0x81E0540", Offset = "0x81E0540", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CInitialize_003Eb__11_0(TutorialAction action)
			{
				TutorialAction tutorialAction = default(TutorialAction);
				tutorialAction.Apply();
			}

			internal void _003CDeInitialize_003Eb__12_0(TutorialAction action)
			{
				if (action != null)
				{
					TutorialAction tutorialAction = default(TutorialAction);
					tutorialAction.Reset();
				}
			}

			internal void _003CDeInitialize_003Eb__12_1(Tween tween)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TutorialData._003C_003Ec::_003CDeInitialize_003Eb__12_1");
			}
		}

		[SerializeReference]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x10")]
		private List<TutorialAction> m_EnterActionList;

		[SerializeReference]
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x18")]
		private List<TutorialExitAction> m_ExitActionList;

		[SerializeField]
		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x20")]
		private bool m_ignoreTimeScale;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x28")]
		private List<Tween> _delayedActions;

		[Token(Token = "0x1700000B")]
		public List<TutorialAction> EnterActionList
		{
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x81DFCE8", Offset = "0x81DFCE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.EnterActionList;\n")]
			get
			{
				return m_EnterActionList;
			}
		}

		[Token(Token = "0x1700000C")]
		public List<TutorialExitAction> ExitActionList
		{
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x81DFCF0", Offset = "0x81DFCF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ExitActionList;\n")]
			get
			{
				return m_ExitActionList;
			}
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81DFCF8", Offset = "0x81DFCF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.TutorialSystem.Scripts.TutorialData::Initialize(this);\n\treturn;\n")]
		public void Enter()
		{
			Initialize();
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81E0004", Offset = "0x81E0004", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv64 = System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction>::GetEnumerator(this.ExitActionList);\n\tv68 = v64._list;\n\tv86 = v64.Current == 0;\n\tif (v86) goto L_0039;\n\tv84 = Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction::Apply(v64.Current);\n\tgoto L_0039;\nL_0047:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v68 @ stack_-48_v3 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction>));\nL_004F:\n\treturn;\nL_0050:\n\tv65 = new System.NullReferenceException();\n\tgoto L_005C;\nL_005C:\n\tv101 = methodInfo != 1;\n\tv115 = v65;\n\tif (v101) goto L_006C;\n\tv105 = 0x8BF5BC4(v65, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv122 = 0x8BF5BF4(v105, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v145);\n\tv114 = *([v105 @ X0_v12]) == 0;\n\tif (v114) goto L_004F;\n\tv112 = new System.OutOfMemoryException();\n\tv108 = *([v105 @ X0_v12]);\n\tv115 = v112;\n\treturn;\nL_0021:\n\tSystems.TutorialSystem.Scripts.TutorialData::DeInitialize(this);\n\tv51 = this.ExitActionList == 0;\n\tif (v51) goto L_0050;\nL_0039:\n\tv90 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v68 @ stack_-48_v3 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction>));\n\tv103 = v90 == 0;\n\tif (v103) goto L_0047;\nL_006C:\n\tv118 = 0x3968E10(&v108 @ stack_-58, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv124 = 0x8BF0368(v115, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv170 = 0x7C03E68(v124, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Exit()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialData::Exit");
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x81E0394", Offset = "0x81E0394", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.TutorialSystem.Scripts.TutorialData::DeInitialize(this);\n\treturn;\n")]
		public void ExitWithoutActions_DEV()
		{
			DeInitialize();
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x81DFCFC", Offset = "0x81DFCFC", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv79 = System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>::GetEnumerator(this.EnterActionList);\n\tv148 = v79.Current;\n\tv140 = v79._list;\n\tgoto L_005B;\nL_0058:\n\tv227 = Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction::Apply(v79.Current);\n\tv232 = v79.Current == 0;\n\tif (v232) goto L_005B;\n\tv127 = v148.Delay < 0;\n\tv124 = v148.Delay == 0;\n\tv118 = v148.Delay == v148.Delay;\n\tv115 = ~v118;\n\tv286 = v127 == v115;\n\tv287 = ~v286;\n\tv112 = v287 | v124;\n\tif (v112) goto L_0058;\n\tv175 = this._delayedActions;\n\tgoto L_0073;\nL_0073:\n\tv110 = v399.<>9__11_0;\n\tv401 = v399.<>9__11_0 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_009C;\n\tgoto L_0082;\nL_0082:\n\tgoto L_008A;\nL_009C:\n\tv425 = PrimeTween.Tween::Delay(v79.Current, v148.Delay, v110, this.m_ignoreTimeScale, 1);\n\tgoto L_00C3;\nL_00C3:\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::Add(v175, v425);\n\tgoto L_005B;\nL_00C9:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v140 @ stack_-90_v3 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>));\nL_00D9:\n\treturn;\nL_00EF:\n\tv249 = v110 != 1;\n\tv267 = v176;\n\tif (v249) goto L_0101;\n\tv256 = 0x8BF5BC4(v176, v110, v107, 1, Il2CppMethodInfo, v44, v45, v46, v130, v48, v49, v50, v51, v52, v53, v54);\n\tv279 = 0x8BF5BF4(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v140 @ stack_-90_v3 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>));\n\tv264 = *([v256 @ X0_v12]) == 0;\n\tif (v264) goto L_00D9;\n\tv262 = new System.OutOfMemoryException();\n\tv159 = *([v256 @ X0_v12]);\n\tv267 = v262;\n\treturn;\nL_0035:\n\tv60 = this.EnterActionList == 0;\n\tv159 = 0;\n\tif (v60) goto L_00DC;\nL_005B:\n\tv228 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v140 @ stack_-90_v3 (System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>));\n\tv254 = v228 == 0;\n\tif (v254) goto L_00C9;\nL_008A:\n\tv440 = new System.Action`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>();\n\tSystem.Action`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>::.ctor(v440, v435.<>9, Il2CppMethodInfo);\n\tv447.<>9__11_0 = v440;\n\tv110 = v440;\nL_0101:\n\tv270 = 0x3968E50(&v159 @ stack_-A8_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv281 = 0x8BF0368(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv345 = 0x7C03E68(v281, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00DC:\n\tv176 = new System.NullReferenceException();\n\tgoto L_00EF;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialData::Initialize");
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81E0144", Offset = "0x81E0144", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv108 = this.EnterActionList;\n\tgoto L_0019;\nL_0019:\n\tv58 = v56.<>9__12_0 == 0;\n\tif (v58) goto L_0049;\n\tv76 = v108 == 0;\n\tv77 = ~v76;\n\tv100 = v56.<>9__12_0;\n\tif (v77) goto L_0066;\n\tgoto L_00C8;\nL_0049:\n\tgoto L_0051;\n\tv100 = v121;\n\tv108 = v108;\nL_0066:\n\tSystem.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>::ForEach(v108, v100);\n\tgoto L_006D;\nL_006D:\n\tv143 = v169.<>9__12_1;\n\tv171 = v169.<>9__12_1 == 0;\n\tif (v171) goto L_007E;\n\tv246 = this._delayedActions == 0;\n\tv149 = ~v246;\n\tif (v149) goto L_009B;\n\tgoto L_00C8;\nL_007E:\n\tgoto L_0086;\n\tv143 = v271;\nL_009B:\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::ForEach(this._delayedActions, v143);\n\tv155 = this._delayedActions;\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::Clear(v155);\n\tv188 = v155.Count < 1;\n\tif (v188) goto L_00C7;\n\treturn;\nL_00C7:\n\treturn;\nL_00C8:\n\tthrow System.NullReferenceException;\nL_0051:\n\tv121 = new System.Action`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>();\n\tSystem.Action`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>::.ctor(v121, v116.<>9, Il2CppMethodInfo);\n\tv173.<>9__12_0 = v121;\nL_0086:\n\tv271 = new System.Action`1<PrimeTween.Tween>();\n\tSystem.Action`1<PrimeTween.Tween>::.ctor(v271, v266.<>9, Il2CppMethodInfo);\n\tv284.<>9__12_1 = v271;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DeInitialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialData::DeInitialize");
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81E03A8", Offset = "0x81E03A8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv81 = new System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction>();\n\tSystem.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialExitAction>::.ctor(v81);\n\tthis.ExitActionList = v81;\n\tv94 = new System.Collections.Generic.List`1<PrimeTween.Tween>();\n\tSystem.Collections.Generic.List`1<PrimeTween.Tween>::.ctor(v94);\n\tthis._delayedActions = v94;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0034:\n\tv64 = new System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>();\n\tSystem.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialActions.TutorialAction>::.ctor(v64);\n\tthis.EnterActionList = v64;\n")]
		public TutorialData()
		{
			List<TutorialAction> enterActionList = new List<TutorialAction>();
			m_EnterActionList = enterActionList;
			m_ExitActionList = new List<TutorialExitAction>();
			_delayedActions = new List<Tween>();
		}
	}
}
