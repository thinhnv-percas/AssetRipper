using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

namespace Unco.TimeTaskSystem.Runtime.UnityBindings
{
	[Token(Token = "0x200000D")]
	public static class TimeTaskPlayerLoopSystem
	{
		[Token(Token = "0x400001D")]
		internal static readonly List<ITimeTaskController> _controllers;

		[Token(Token = "0x400001E")]
		private static bool _isInitialized;

		[Token(Token = "0x17000007")]
		public static int RegisteredCount
		{
			[Token(Token = "0x600004A")]
			[Address(RVA = "0x8195A70", Offset = "0x8195A70", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv57 = v43._controllers;\n\treturn v57.Count;\n")]
			get
			{
				List<ITimeTaskController> controllers = _controllers;
				return controllers.Count;
			}
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x81953A4", Offset = "0x81953A4", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tgoto L_0036;\nL_0036:\n\tv87 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Contains(v65._controllers, controller);\n\tv115 = ~v87;\n\tif (v115) goto L_0066;\n\tgoto L_004C;\nL_004C:\n\tUnityEngine.Debug::LogWarning(\"[TimeTaskPlayerLoopSystem] Controller already registered\");\n\treturn;\nL_0054:\n\tgoto L_0061;\nL_0061:\n\tUnityEngine.Debug::LogWarning(\"[TimeTaskPlayerLoopSystem] Cannot register null controller\");\n\treturn;\nL_0066:\n\tgoto L_006B;\nL_006B:\n\tgoto L_006F;\nL_006F:\n\tgoto L_0073;\nL_0073:\n\tv236 = v233._isInitialized == 0;\n\tif (v236) goto L_0096;\n\tv102 = v108._controllers;\n\tv250 = v108._controllers == 0;\n\tv104 = ~v250;\n\tif (v104) goto L_00A4;\n\tgoto L_00D2;\nL_0096:\n\tgoto L_0098;\nL_0098:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::InsertIntoPlayerLoop();\n\tv109._isInitialized = 1;\n\tv102 = v109._controllers;\nL_00A4:\n\t;\n\tgoto L_00D0;\nL_00D0:\n\tSystem.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Add(v102, controller);\n\treturn;\nL_00D2:\n\tthrow System.NullReferenceException;\nL_0023:\n\tv43 = controller == 0;\n\tif (v43) goto L_0054;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Register(ITimeTaskController controller)
		{
			if (controller != null)
			{
				if (_controllers.Contains(controller))
				{
					Debug.LogWarning("[TimeTaskPlayerLoopSystem] Controller already registered");
					return;
				}
				List<ITimeTaskController> controllers;
				if (_isInitialized)
				{
					controllers = _controllers;
					if (_controllers == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					InsertIntoPlayerLoop();
					_isInitialized = true;
					controllers = _controllers;
				}
				controllers.Add(controller);
			}
			else
			{
				Debug.LogWarning("[TimeTaskPlayerLoopSystem] Cannot register null controller");
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x81956D4", Offset = "0x81956D4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tgoto L_002D;\nL_002D:\n\treturnVal2 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Remove(v56._controllers, controller);\n\treturn returnVal2;\nL_0035:\n\treturn 0;\nL_0015:\n\tv39 = controller == 0;\n\tif (v39) goto L_0035;\n")]
		public static bool Unregister(ITimeTaskController controller)
		{
			if (controller != null)
			{
				return _controllers.Remove(controller);
			}
			return false;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x8195894", Offset = "0x8195894", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\n\tgoto L_0012;\nL_0012:\n\tv53 = v43._controllers;\n\tSystem.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::Clear(v53);\n\tv74 = v53.Count < 1;\n\tif (v74) goto L_0036;\nL_FFFFFFFF:\n\t;\n\tgoto L_003D;\nL_003D:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::RemoveFromPlayerLoop();\n\tv110._isInitialized = 0;\nL_0036:\n\tv102 = v90._isInitialized != 1;\n\tif (v102) goto L_0046;\nL_0046:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Shutdown()
		{
			List<ITimeTaskController> controllers = _controllers;
			controllers.Clear();
			if (controllers.Count >= 1)
			{
			}
			if (_isInitialized)
			{
				RemoveFromPlayerLoop();
				_isInitialized = false;
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81957F0", Offset = "0x81957F0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0014;\nL_0014:\n\tv46 = v43._isInitialized == 0;\n\tif (v46) goto L_0031;\n\treturn;\nL_0031:\n\tgoto L_0033;\nL_0033:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::InsertIntoPlayerLoop();\n\tv83._isInitialized = 1;\n\treturn;\n")]
		private static void EnsureInitialized()
		{
			if (!_isInitialized)
			{
				InsertIntoPlayerLoop();
				_isInitialized = true;
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x8195AFC", Offset = "0x8195AFC", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\nL_004F:\n\tv93 = System.Type::GetTypeFromHandle(Unco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem);\n\tv99 = new UnityEngine.LowLevel.PlayerLoopSystem+UpdateFunction();\n\tUnityEngine.LowLevel.PlayerLoopSystem+UpdateFunction::.ctor(v99, 0, Il2CppMethodInfo);\n\tgoto L_0060;\nL_0060:\n\tv120 = Unco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::InsertSystem(&v117 @ stack_-70_v5 (UnityEngine.LowLevel.PlayerLoopSystem), v93, v99);\n\tv123 = v120 == 0;\n\tif (v123) goto L_0077;\n\tgoto L_007E;\nL_0077:\n\tgoto L_007B;\nL_007B:\n\tUnityEngine.Debug::LogError(\"[TimeTaskPlayerLoopSystem] Failed to insert into PlayerLoop\");\nL_007E:\n\tv159 = v117;\n\tUnityEngine.LowLevel.PlayerLoop::SetPlayerLoop(&v159 @ stack_-A0_v2 (UnityEngine.LowLevel.PlayerLoopSystem));\n\treturn;\nL_0031:\n\tv57 = UnityEngine.LowLevel.PlayerLoop::GetCurrentPlayerLoop();\n\tgoto L_004F;\n")]
		private static void InsertIntoPlayerLoop()
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			Type typeFromHandle = typeof(TimeTaskPlayerLoopSystem);
			PlayerLoopSystem.UpdateFunction updateFunction = UpdateControllers;
			PlayerLoopSystem playerLoop = default(PlayerLoopSystem);
			if (!InsertSystem<Update>(ref playerLoop, typeFromHandle, updateFunction))
			{
				Debug.LogError("[TimeTaskPlayerLoopSystem] Failed to insert into PlayerLoop");
			}
			PlayerLoopSystem playerLoop2 = playerLoop;
			PlayerLoop.SetPlayerLoop(playerLoop2);
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x8195970", Offset = "0x8195970", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_003D:\n\tv84 = System.Type::GetTypeFromHandle(Unco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem);\n\tgoto L_0048;\nL_0048:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::RemoveSystem(&v94 @ stack_-60_v2 (UnityEngine.LowLevel.PlayerLoopSystem), v84);\n\tv98 = v94;\n\tUnityEngine.LowLevel.PlayerLoop::SetPlayerLoop(&v98 @ stack_-B0_v1 (UnityEngine.LowLevel.PlayerLoopSystem));\n\treturn;\nL_001F:\n\tv49 = UnityEngine.LowLevel.PlayerLoop::GetCurrentPlayerLoop();\n\tgoto L_003D;\n")]
		private static void RemoveFromPlayerLoop()
		{
			PlayerLoopSystem currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();
			Type typeFromHandle = typeof(TimeTaskPlayerLoopSystem);
			PlayerLoopSystem playerLoop = default(PlayerLoopSystem);
			RemoveSystem<Update>(ref playerLoop, typeFromHandle);
			PlayerLoopSystem playerLoop2 = playerLoop;
			PlayerLoop.SetPlayerLoop(playerLoop2);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x4D11674", Offset = "0x4D11674", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv53 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv192 = 0x28;\nL_FFFFFFFF:\n\tv195 = 0;\nL_FFFFFFFF:\n\tv237 = playerLoop.subSystemList;\n\tv241 = v237 + v192;\n\tgoto L_003E;\nL_003E:\n\tv334 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv197 = System.Type::op_Inequality(*([v241 @ X8_v21-8]), v334);\n\tv208 = playerLoop.subSystemList;\n\tv240 = v197 == 0;\n\tif (v240) goto L_005A;\n\tv193 = v195 + 1;\n\tv190 = v192 + 0x28;\n\tv442 = v208 == 0;\n\tv203 = ~v442;\nL_FFFFFFFF:\n\tv192 = v190;\nL_FFFFFFFF:\n\tv195 = v193;\nL_FFFFFFFF:\n\tv237 = v208;\n\tif (v203) goto L_0026;\nL_004C:\n\tv217 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv192 = v190;\nL_FFFFFFFF:\n\tv195 = v193;\nL_005A:\n\tv216 = *([v208 @ X8_v19 (UnityEngine.LowLevel.PlayerLoopSystem[])+v192 @ X26_v3 (System.Int32)]);\n\tv395 = *([v208 @ X8_v19 (UnityEngine.LowLevel.PlayerLoopSystem[])+v192 @ X26_v3 (System.Int32)]) == 0;\n\tif (v395) goto L_009A;\n\tv211 = *([v216 @ X22_v6 (System.Array)+18]);\n\tv415 = *([v216 @ X22_v6 (System.Array)+18]) < 1;\n\tif (v415) goto L_008D;\n\tv256 = *([v208 @ X8_v19 (UnityEngine.LowLevel.PlayerLoopSystem[])+v192 @ X26_v3 (System.Int32)]) + 0x20;\nL_FFFFFFFF:\n\tv291 = 0;\nL_0076:\n\tv299 = System.Type::op_Equality(*([v256 @ X20_v9]), systemType);\n\tv468 = v299 == 0;\n\tv301 = ~v468;\n\tif (v301) goto L_00D1;\n\tv291 = v291 + 1;\n\tv211 = *([v216 @ X22_v6 (System.Array)+18]);\n\tv256 = v256 + 0x28;\n\tv422 = v291 < *([v216 @ X22_v6 (System.Array)+18]);\n\tif (v422) goto L_0071;\nL_008D:\n\tv440 = v211 + 1;\n\t// 142 NewArr v441 @ X0_v20 (UnityEngine.LowLevel.PlayerLoopSystem[]), typeof(UnityEngine.LowLevel.PlayerLoopSystem[]), v440 @ X1_v11\n\tSystem.Array::Copy(*([v208 @ X8_v19 (UnityEngine.LowLevel.PlayerLoopSystem[])+v192 @ X26_v3 (System.Int32)]), v441, *([v216 @ X22_v6 (System.Array)+18]));\n\tv465 = v441 == 0;\n\tv205 = ~v465;\nL_FFFFFFFF:\n\tv187 = v441;\n\tif (v205) goto L_00B0;\nL_FFFFFFFF:\n\tv65 = v3;\nL_FFFFFFFF:\n\tv190 = v5;\nL_FFFFFFFF:\n\tv193 = v7;\nL_FFFFFFFF:\n\tv208 = playerLoop.subSystemList;\n\tgoto L_004C;\nL_009A:\n\t;\n\t// 157 NewArr v200 @ X0_v17 (UnityEngine.LowLevel.PlayerLoopSystem[]), typeof(UnityEngine.LowLevel.PlayerLoopSystem[]), 1\nL_FFFFFFFF:\n\tv187 = v200;\nL_00B0:\n\tv471 = *([v187 @ X23_v5 (System.Array)+18]) - 1;\n\tv473 = v471 * 0x28;\n\tv474 = v187 + v473;\n\t*([v474 @ X8_v10+40]) = v475;\n\t*([v474 @ X8_v10+20]) = v78;\n\t*([v474 @ X8_v10+30]) = updateFunction;\n\tv213 = playerLoop.subSystemList;\n\t*([v213 @ X8_v11 (UnityEngine.LowLevel.PlayerLoopSystem[])+v192 @ X26_v3 (System.Int32)]) = v187;\nL_00D1:\n\tv307 = v195 - v65;\n\tv308 = v307 < 0;\n\tv310 = v195 ^ v65;\n\tv311 = v195 ^ v307;\n\tv312 = v310 & v311;\n\tv313 = v312 < 0;\n\tv314 = v308 == v313;\n\tv315 = ~v314;\n\treturn v315;\nL_0026:\n\tv65 = v237.Length;\n\tv99 = v195 >= v237.Length;\n\tif (v99) goto L_00D1;\nL_0071:\n\tgoto L_0076;\n")]
		private static bool InsertSystem<T>(ref PlayerLoopSystem playerLoop, Type systemType, PlayerLoopSystem.UpdateFunction updateFunction)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskPlayerLoopSystem::InsertSystem");
			return default;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x4D11ADC", Offset = "0x4D11ADC", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\tv184 = playerLoop.subSystemList;\n\tv146 = 0x28;\n\tv151 = 0;\n\tgoto L_0035;\nL_0026:\n\tv184 = playerLoop.subSystemList;\n\tv146 = 0x28;\nL_0035:\n\tv97 = v151 >= v184.Length;\n\tif (v97) goto L_00D5;\n\tv231 = v151 * v146;\n\tv232 = v184 + v231;\n\tgoto L_0044;\nL_0044:\n\tv254 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv154 = System.Type::op_Inequality(*([v232 @ X8_v7+20]), v254);\n\tv184 = playerLoop.subSystemList;\n\tv303 = v154 == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_0028;\n\tv93 = v184[v151 @ X25_v4 (System.Int32)].subSystemList;\n\tv333 = v184[v151 @ X25_v4 (System.Int32)].subSystemList == 0;\n\tif (v333) goto L_0028;\n\tv311 = *([v93 @ X22_v7 (System.Array)+18]) < 1;\n\tif (v311) goto L_0028;\n\tv73 = 0x20;\n\tv77 = -1;\n\tv89 = 0;\nL_007A:\n\tv330 = System.Type::op_Inequality(*([v93 @ X22_v7 (System.Array)+v73 @ X26_v7 (System.Int32)]), systemType);\n\tv332 = v330 == 0;\n\tif (v332) goto L_0093;\n\tv89 = v89 + 1;\n\tv77 = v77 - 1;\n\tv73 = v73 + 0x28;\n\tv310 = v89 < *([v93 @ X22_v7 (System.Array)+18]);\n\tif (v310) goto L_0075;\n\tgoto L_0026;\nL_0093:\n\tv363 = *([v93 @ X22_v7 (System.Array)+18]) - 1;\n\t// 148 NewArr v364 @ X0_v20 (UnityEngine.LowLevel.PlayerLoopSystem[]), typeof(UnityEngine.LowLevel.PlayerLoopSystem[]), v363 @ X1_v9\n\tSystem.Array::Copy(v184[v151 @ X25_v4 (System.Int32)].subSystemList, 0, v364, 0, v89);\n\tv85 = 0 - v77;\n\tv67 = *([v93 @ X22_v7 (System.Array)+18]) + v77;\n\tSystem.Array::Copy(v184[v151 @ X25_v4 (System.Int32)].subSystemList, v85, v364, v89, v67);\n\tv163 = playerLoop.subSystemList;\n\tv163[v151 @ X25_v4 (System.Int32)].subSystemList = v364;\n\treturn;\nL_00D5:\n\treturn;\nL_0028:\n\tv151 = v151 + 1;\nL_0075:\n\tgoto L_007A;\n")]
		private static void RemoveSystem<T>(ref PlayerLoopSystem playerLoop, Type systemType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskPlayerLoopSystem::RemoveSystem");
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x8195CAC", Offset = "0x8195CAC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0028:\n\tv229 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::get_Item(v259, Unco.TimeTaskSystem.Runtime.ITimeTaskController);\nL_FFFFFFFF:\n\tv98 = 0;\nL_FFFFFFFF:\n\tv106 = v229;\n\tv134 = v107 >= v158.Count;\n\tif (v134) goto L_0084;\n\tgoto L_0053;\nL_0053:\n\tv259 = System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::get_Item(v158, v107);\n\tv199 = *([v259 @ X0_v10 (Unco.TimeTaskSystem.Runtime.ITimeTaskController)]);\n\tv241 = *([v199 @ X8_v9 (Il2CppClass<Unco.TimeTaskSystem.Runtime.ITimeTaskController>)+12E]);\n\tv104 = *([v199 @ X8_v9 (Il2CppClass<Unco.TimeTaskSystem.Runtime.ITimeTaskController>)+12E]) == 0;\n\tif (v104) goto L_0028;\n\tv231 = *([v199 @ X8_v9 (Il2CppClass<Unco.TimeTaskSystem.Runtime.ITimeTaskController>)+B0]) + 8;\n\tv231 = v231 + 0x10;\n\tv226 = v241 - 1;\n\tv208 = v241 != 1;\nL_FFFFFFFF:\n\tv241 = v226;\n\tif (v208) goto L_0062;\n\tgoto L_0028;\nL_0077:\n\tv255 = *([v231 @ X10_v5]) << 4;\n\tv256 = v199 + v255;\n\tv106 = v256 + 0x138;\nL_FFFFFFFF:\n\tv98 = Il2CppMethodInfo;\n\tgoto L_002D;\nL_0084:\n\treturn;\nL_FFFFFFFF:\n\tv107 = 0;\n\tgoto L_0033;\nL_0037:\n\tv158 = v119._controllers;\nL_0062:\n\tv246 = *([v231 @ X10_v5-8]) == Unco.TimeTaskSystem.Runtime.ITimeTaskController;\n\tif (v246) goto L_0077;\nL_002D:\n\t*([v106 @ X8_v10 (Unco.TimeTaskSystem.Runtime.ITimeTaskController)])(v102, v259, *([v106 @ X8_v10 (Unco.TimeTaskSystem.Runtime.ITimeTaskController)+8]), v98, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv107 = v107 + 1;\nL_0033:\n\tgoto L_0037;\n")]
		private static void UpdateControllers()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskPlayerLoopSystem::UpdateControllers");
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		[Token(Token = "0x6000051")]
		[Address(RVA = "0x8195DFC", Offset = "0x8195DFC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0016;\nL_0016:\n\tUnco.TimeTaskSystem.Runtime.UnityBindings.TimeTaskPlayerLoopSystem::Shutdown();\n\treturn;\n")]
		private static void DomainReload()
		{
			Shutdown();
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x8195E64", Offset = "0x8195E64", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>();\n\tSystem.Collections.Generic.List`1<Unco.TimeTaskSystem.Runtime.ITimeTaskController>::.ctor(v49);\n\tv58._controllers = v49;\n")]
		static TimeTaskPlayerLoopSystem()
		{
			List<ITimeTaskController> controllers = new List<ITimeTaskController>();
			_controllers = controllers;
		}
	}
}
