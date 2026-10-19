using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.Extensions;
using UnityEngine;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x200000A")]
	public static class InitializationManager
	{
		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec__DisplayClass10_0
		{
			[Token(Token = "0x4000012")]
			[FieldOffset(Offset = "0x10")]
			public Type type;

			[Token(Token = "0x4000013")]
			[FieldOffset(Offset = "0x18")]
			public Predicate<Type> _003C_003E9__0;

			[Token(Token = "0x6000028")]
			[Address(RVA = "0x81B113C", Offset = "0x81B113C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass10_0()
			{
			}

			internal bool _003CTryHandleListenerOnEvent_003Eb__0(Type dependency)
			{
				//IL_001f: Expected O, but got I
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1+E4]");
				if ((nint)0 != 0)
				{
					return dependency == type;
				}
				return dependency == type;
			}
		}

		[Token(Token = "0x400000F")]
		private static readonly InitializableHub _initializedHub;

		[Token(Token = "0x4000010")]
		private static readonly InitializableHub _deInitializedHub;

		[Token(Token = "0x4000011")]
		private static readonly List<InitializationTimeTrack> _initializationTimeTracks;

		[Token(Token = "0x17000001")]
		public static InitializableHub InitializedHub
		{
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x81B0D34", Offset = "0x81B0D34", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0018;\nL_0018:\n\treturn v43._initializedHub;\n")]
			get
			{
				return _initializedHub;
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81AFA90", Offset = "0x81AFA90", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tgoto L_002B;\nL_002B:\n\tUnco.InitializationSystem.Runtime.InitializationManager::ListenInitialization(obj, v59._initializedHub);\n\tUnco.InitializationSystem.Runtime.InitializationManager::ListenInitialization(obj, v66._deInitializedHub);\n\treturn;\n")]
		public static void Listen(object obj)
		{
			ListenInitialization<OnInitializeAttribute>(obj, _initializedHub);
			ListenInitialization<OnDeInitializeAttribute>(obj, _deInitializedHub);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81AFBF8", Offset = "0x81AFBF8", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv50.initializable = initializable;\n\tgoto L_0044;\n\tv225 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::Exists(v110._initializationTimeTracks, v101);\n\tv227 = v225 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_0096;\n\tgoto L_005E;\n\tv244 = System.Object::GetType(v50.initializable);\n\tgoto L_009D;\nL_0096:\n\treturn;\nL_009D:\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::Add(v117, v86);\n\treturn;\nL_0028:\n\tv50 = new Unco.InitializationSystem.Runtime.InitializationManager+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v50);\nL_0044:\n\tv101 = new System.Predicate`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>();\n\tSystem.Predicate`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::.ctor(v101, v50, Il2CppMethodInfo);\nL_005E:\n\tv117 = v111._initializationTimeTracks;\n\tv78 = UnityEngine.Time::get_realtimeSinceStartup();\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void TrackProcess(IInitializable initializable)
		{
			Predicate<InitializationTimeTrack> match = delegate(InitializationTimeTrack track)
			{
				//IL_002e: Expected O, but got I
				Type type2 = initializable.GetType();
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X8_v2 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X0_v4+E4]");
				return ((nint)0 != 0) ? (track.initializable == type2) : (track.initializable == type2);
			};
			if (!_initializationTimeTracks.Exists(match))
			{
				List<InitializationTimeTrack> initializationTimeTracks = _initializationTimeTracks;
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				Type type = initializable.GetType();
				InitializationTimeTrack item = default(InitializationTimeTrack);
				initializationTimeTracks.Add(item);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		[Token(Token = "0x600001D")]
		[Address(RVA = "0x81B0DB8", Offset = "0x81B0DB8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0013;\nL_0013:\n\tv45 = v43._initializedHub == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0027;\n\tgoto L_0034;\nL_0027:\n\tUnco.InitializationSystem.Runtime.InitializableHub::Clear(v43._initializedHub);\n\tUnco.InitializationSystem.Runtime.InitializableHub::Clear(v65._deInitializedHub);\n\treturn;\nL_0034:\n\tthrow System.NullReferenceException;\n")]
		public static void Clear()
		{
			if (_initializedHub != null)
			{
				_initializedHub.Clear();
				_deInitializedHub.Clear();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x81AFFB0", Offset = "0x81AFFB0", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv54.initializable = initializable;\n\tgoto L_0043;\n\tgoto L_0059;\nL_0059:\n\tv100 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Remove(v83.Instances, v54.initializable);\n\tv91 = v117._initializedHub;\n\tgoto L_0074;\n\tSystem.Predicate`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::.ctor(v101, v54, Il2CppMethodInfo);\n\tv173 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::FindIndex(v118._initializationTimeTracks, v101);\n\tv232 = v173 & 0x80000000;\n\tv233 = v232 == 0;\n\tv176 = ~v233;\n\tif (v176) goto L_00CD;\n\tgoto L_00A0;\nL_00A0:\n\tv243 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::get_Item(v122._initializationTimeTracks, v173);\n\tv75 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv247 = v75 & 0xFFFFFFFF;\n\tv175 = v247 << 0x20;\n\tv248 = v243 & 0xFFFFFFFF;\n\tv249 = v248 | v175;\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::set_Item(v119._initializationTimeTracks, v173, v249);\n\treturn;\nL_00CD:\n\treturn;\nL_002D:\n\tv54 = new Unco.InitializationSystem.Runtime.InitializationManager+<>c__DisplayClass8_0();\n\tSystem.Object::.ctor(v54);\nL_0043:\n\tv83 = v120._deInitializedHub;\nL_0074:\n\tUnco.InitializationSystem.Runtime.Extensions::AddIfNotContains(v91.Instances, v54.initializable);\n\tUnco.InitializationSystem.Runtime.InitializationManager::TryHandleListenerOnEvent(v54.initializable, v226._initializedHub);\n\tv101 = new System.Predicate`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>();\n")]
		internal static void Initialize(IInitializable initializable)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::Initialize");
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x81B02B4", Offset = "0x81B02B4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv69 = v53._initializedHub;\n\tv55 = v53._initializedHub == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0031;\n\tgoto L_0064;\nL_0031:\n\tgoto L_003E;\nL_003E:\n\tv82 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Remove(v69.Instances, initializable);\n\tv91 = v88._deInitializedHub;\n\tgoto L_0054;\nL_0064:\n\tthrow System.NullReferenceException;\nL_0054:\n\tUnco.InitializationSystem.Runtime.Extensions::AddIfNotContains(v91.Instances, initializable);\n\tUnco.InitializationSystem.Runtime.InitializationManager::TryHandleListenerOnEvent(initializable, v119._deInitializedHub);\n\treturn;\n")]
		internal static void DeInitialize(IInitializable initializable)
		{
			InitializableHub initializedHub = _initializedHub;
			if (_initializedHub != null)
			{
				bool flag = initializedHub.Instances.Remove(initializable);
				InitializableHub deInitializedHub = _deInitializedHub;
				deInitializedHub.Instances.AddIfNotContains(initializable);
				TryHandleListenerOnEvent(initializable, _deInitializedHub);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81B0E54", Offset = "0x81B0E54", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv75 = System.Object::GetType(initializable);\n\tv173 = v60 == 0;\n\tif (v173) goto L_00E4;\n\tv60.type = v75;\n\tv174 = hub == 0;\n\tif (v174) goto L_00E4;\n\tv237 = hub.Listeners;\n\tv175 = hub.Listeners == 0;\n\tif (v175) goto L_00E4;\n\tv334 = 0;\n\tgoto L_0069;\nL_0056:\n\tv326 = v170.dependencies;\n\tUnco.InitializationSystem.Runtime.InitializationManager::HandleListener(&v326 @ stack_-B0_v3 (System.Type[]), hub);\nL_005B:\n\tv334 = v334 + 1;\n\tv237 = hub.Listeners;\n\tv176 = hub.Listeners == 0;\n\tif (v176) goto L_00E4;\nL_0069:\n\tv116 = v334 >= v237.Count;\n\tif (v116) goto L_00E3;\n\tv170 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::get_Item(v237, v334);\n\tv177 = v170.owner == 0;\n\tif (v177) goto L_00E4;\n\tv294 = System.Object::Equals(v170.owner, 0);\n\tv295 = ~v294;\n\tif (v295) goto L_008A;\n\tv178 = hub.Listeners == 0;\n\tif (v178) goto L_00E4;\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::RemoveAt(hub.Listeners, v334);\n\tv334 = v334 - 1;\n\tgoto L_005B;\nL_008A:\n\tv307 = v60.<>9__0;\n\tv297 = v60.<>9__0 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_009F;\n\tv304 = new System.Predicate`1<System.Type>();\n\tSystem.Predicate`1<System.Type>::.ctor(v304, v60, Il2CppMethodInfo);\n\tv60.<>9__0 = v304;\n\tv307 = v304;\nL_009F:\n\tv320 = System.Array::Exists(v170.dependencies, v307);\n\tv324 = v320 == 0;\n\tif (v324) goto L_005B;\n\tgoto L_0056;\nL_00E3:\n\treturn;\nL_00E4:\n\tthrow System.NullReferenceException;\nL_0034:\n\tv60 = new Unco.InitializationSystem.Runtime.InitializationManager+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v60);\n\tv69 = initializable == 0;\n\tif (v69) goto L_00E4;\n")]
		private unsafe static void TryHandleListenerOnEvent(IInitializable initializable, InitializableHub hub)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::TryHandleListenerOnEvent");
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81B1144", Offset = "0x81B1144", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv63 = new System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>();\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::.ctor(v63, v53.Length);\n\tv133 = listener.dependencies;\n\tv150 = hub == 0;\n\tif (v150) goto L_009A;\n\tv239 = v63 == 0;\n\tif (v239) goto L_00B6;\n\tv243 = v133.Length < 1;\n\tif (v243) goto L_00A0;\n\tv86 = 0;\n\tgoto L_0066;\nL_0055:\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Add(v63, v52);\nL_0056:\n\tv86 = v86 + 1;\n\tv260 = v86 >= v133.Length;\n\tif (v260) goto L_00A0;\nL_0066:\n\tv310 = Unco.InitializationSystem.Runtime.InitializableHub::TryGetInstance(hub, v133[v86 @ X24_v6 (System.Int32)], &v52 @ stack_-58_v1 (Unco.InitializationSystem.Runtime.IInitializable));\n\tv329 = v310 == 0;\n\tif (v329) goto L_00CB;\n\tv145 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Contains(v63, v52);\n\tv336 = v145 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_0056;\n\tgoto L_0055;\nL_009A:\n\tv90 = v133.Length > 0;\n\tif (v90) goto L_00CC;\nL_00A0:\n\tv292 = Unco.Extensions.CollectionExtensions::IsNullOrEmpty(v63);\n\tv298 = v292 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_00CB;\n\tv314 = listener.dependencies;\n\tgoto L_00B3;\nL_00B3:\n\tUnco.InitializationSystem.Runtime.InitializationManager::InvokeListenerMethod(&v314 @ stack_-70_v2 (System.Type[]), v63);\n\tgoto L_00CB;\nL_00B6:\n\tv91 = v133.Length < 1;\n\tif (v91) goto L_00A0;\n\tv146 = Unco.InitializationSystem.Runtime.InitializableHub::TryGetInstance(hub, v133[0], &v52 @ stack_-58_v1 (Unco.InitializationSystem.Runtime.IInitializable));\nL_00CB:\n\treturn;\nL_00CC:\n\tthrow System.NullReferenceException;\nL_0028:\n\tv52 = 0;\n\tv53 = listener.dependencies;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void HandleListener(ListenerMethod listener, InitializableHub hub)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::HandleListener");
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x81B1354", Offset = "0x81B1354", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tv67 = System.Reflection.MethodBase::GetParameters(listener.methodInfo);\n\tv212 = v67.Length == 0;\n\tif (v212) goto L_0107;\n\t// 59 NewArr v260 @ X0_v18 (System.Object[]), typeof(System.Object[]), v67.Length\n\tv132 = v67.Length < 1;\n\tif (v132) goto L_00E5;\n\tv359 = instances == 0;\n\tif (v359) goto L_010A;\n\tv384 = v260 + 0x20;\n\tv126 = 0;\nL_005A:\n\tv449 = System.Reflection.ParameterInfo::get_ParameterType(v67[v126 @ X27_v8 (System.Int32)]);\n\tv455 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::GetEnumerator(instances);\n\tv273 = v455._list;\n\tv326 = v455.Current == 0;\n\tif (v326) goto L_00B7;\n\tv489 = System.Object::GetType(v455.Current);\n\tgoto L_0085;\nL_0085:\n\tv463 = System.Type::op_Inequality(v489, v449);\n\tv499 = v463 == 0;\n\tv465 = ~v499;\n\tif (v465) goto L_0071;\n\tv327 = v260 == 0;\n\tif (v327) goto L_00B9;\n\tv501 = 0x21C11D0(v455.Current, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv328 = v501 == 0;\n\tif (v328) goto L_00BB;\n\tv502 = v126 < v260.Length;\n\tv310 = ~v502;\n\tif (v310) goto L_00BF;\n\tv470 = v126 << 3;\n\tv504 = v384 + v470;\n\t*([v504 @ X0_v46]) = v455.Current;\nL_00A7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v273 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\n\tv126 = v126 + 1;\n\tv365 = v126 < v67.Length;\n\tif (v365) goto L_005A;\n\tgoto L_00E5;\nL_00B7:\n\tv253 = new System.NullReferenceException();\n\tv112 = 0;\n\tgoto L_0113;\nL_00B9:\n\tv253 = new System.NullReferenceException();\n\tv112 = 0;\n\tgoto L_0113;\nL_00BB:\n\tv503 = new System.ArrayTypeMismatchException();\n\tthrow v503;\nL_00BF:\n\tv324 = new System.IndexOutOfRangeException();\n\tv112 = 0;\n\tv253 = v324;\n\tgoto L_0113;\nL_00E5:\n\tv391 = System.Reflection.MethodBase::Invoke(listener.methodInfo, listener.owner, v260);\n\treturn;\nL_0107:\n\tv355 = System.Reflection.MethodBase::Invoke(listener.methodInfo, listener.owner, 0);\n\treturn;\nL_010A:\n\tv387 = v67[0] == 0;\n\tv195 = ~v387;\n\tv214 = v73;\n\tv244 = v67[0];\n\tif (v195) goto L_0111;\n\tv244 = new System.NullReferenceException();\n\tv214 = v73;\nL_0111:\n\tv252 = System.Exception::GetObjectData(v244, Il2CppMethodInfo, v214);\n\tv253 = new System.NullReferenceException();\nL_0113:\n\t// 275 Interrupt\n\treturn;\nL_0071:\n\tv467 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v273 @ stack_-80_v7 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\n\tv469 = v467 == 0;\n\tif (v469) goto L_00A7;\n\tv358 = 0x39670E8(&v112 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv382 = 0x8BF0368(v253, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv434 = 0x7C03E68(v382, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void InvokeListenerMethod(ListenerMethod listener, List<IInitializable> instances)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::InvokeListenerMethod");
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x499F0F0", Offset = "0x499F0F0", Length = "0x38C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tgoto L_0031;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0031:\n\tv67 = System.Object::GetType(obj);\n\tv233 = System.Type::GetMethods(v67, 0x3C);\n\tv333 = v233.Length < 1;\n\tif (v333) goto L_013B;\n\tv481 = 0;\n\tv228 = 0;\n\tgoto L_0063;\nL_0051:\n\tv481 = v481 + 1;\n\tv379 = v481 >= v233.Length;\n\tif (v379) goto L_013B;\nL_0063:\n\t;\n\tgoto L_0071;\n\tv510 = System.Reflection.MemberInfo::GetCustomAttributes(v233[v481 @ X9_v6 (System.Int32)], v234, 0);\n\tgoto L_0088;\n\tv150 = *([v232 @ X0_v18+18]) < 1;\n\tif (v150) goto L_0051;\n\tv557 = v232 + 0x20;\n\tv558 = hub == 0;\n\tif (v558) goto L_013D;\n\tv266 = 0;\n\tgoto L_00C3;\nL_00A8:\n\tgoto L_00AA;\nL_00AA:\n\tv517 = v228;\n\tv228.owner = 0;\n\tUnco.InitializationSystem.Runtime.InitializationManager::HandleListener(&v517 @ stack_-B0_v6 (Unco.InitializationSystem.Runtime.ListenerMethod), hub);\n\tv266 = v266 + 1;\n\tv524 = v266 >= *([v232 @ X0_v18+18]);\n\tif (v524) goto L_0051;\nL_00C3:\n\tv252 = *([v557 @ X8_v17+v266 @ X22_v8 (System.Int32)*8]);\n\tv87 = *([v252 @ X8_v22+10]);\n\tUnco.InitializationSystem.Runtime.ListenerMethod::.ctor(&v228 @ stack_-78_v5 (Unco.InitializationSystem.Runtime.ListenerMethod), obj, v233[v481 @ X9_v6 (System.Int32)], *([v252 @ X8_v22+10]));\n\tv105 = v228;\n\tUnco.InitializationSystem.Runtime.InitializableHub::AddListener(hub, &v105 @ stack_-90_v6 (Unco.InitializationSystem.Runtime.ListenerMethod));\n\tv579 = v87.Length < 1;\n\tif (v579) goto L_00A8;\n\tv127 = 0;\nL_00F5:\n\tv237 = System.Type::GetTypeFromHandle(Unco.InitializationSystem.Runtime.IInitializable);\n\tv238 = System.Type::IsAssignableFrom(v237, v87[v127 @ X20_v10 (System.Int32)]);\n\tv605 = v238 == 0;\n\tif (v605) goto L_0117;\n\tv127 = v127 + 1;\n\tv584 = v127 < v87.Length;\n\tif (v584) goto L_00F1;\n\tgoto L_00A8;\nL_0117:\n\tv642 = System.Reflection.MemberInfo::get_Name(v87[v127 @ X20_v10 (System.Int32)]);\n\tv408 = System.String::Concat(\"The \", v642, \" must inherit from IInitializable interface!\");\n\tgoto L_012D;\nL_013B:\n\treturn;\nL_013D:\n\tv248 = *([v557 @ X8_v17]);\n\tv561 = *([v557 @ X8_v17]) == 0;\n\tv240 = ~v561;\n\tif (v240) goto L_0147;\n\tthrow System.NullReferenceException;\nL_0147:\n\tUnco.InitializationSystem.Runtime.ListenerMethod::.ctor(&v228 @ stack_-78_v5 (Unco.InitializationSystem.Runtime.ListenerMethod), obj, v233[v481 @ X9_v6 (System.Int32)], *([v248 @ X8_v4+10]));\n\tthrow System.NullReferenceException;\nL_0071:\n\tv234 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\nL_0088:\n\tv232 = 0x21C11D0(v510, Il2CppClass<T[]>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv512 = v232 == 0;\n\tif (v512) goto L_0051;\nL_00F1:\n\tgoto L_00F5;\nL_012D:\n\tUnityEngine.Debug::LogError(v408);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ListenInitialization<T>(object obj, InitializableHub hub) where T : InitializationAttribute
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::ListenInitialization");
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x81AFE88", Offset = "0x81AFE88", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49._initializedHub == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_002B;\n\tgoto L_003B;\nL_002B:\n\tUnco.InitializationSystem.Runtime.InitializableHub::KillListeners(v49._initializedHub, o);\n\tUnco.InitializationSystem.Runtime.InitializableHub::KillListeners(v73._deInitializedHub, o);\n\treturn;\nL_003B:\n\tthrow System.NullReferenceException;\n")]
		internal static void KillListener(object o)
		{
			if (_initializedHub != null)
			{
				_initializedHub.KillListeners(o);
				_deInitializedHub.KillListeners(o);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81B1654", Offset = "0x81B1654", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv54 = v52._initializedHub == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002E;\n\tgoto L_0042;\nL_002E:\n\treturnVal2 = Unco.InitializationSystem.Runtime.InitializableHub::TryGetInstance(v52._initializedHub, type, &v71 @ stack_-38_v3 (Unco.InitializationSystem.Runtime.IInitializable));\n\tv84 = ~returnVal2;\n\tif (v84) goto L_0041;\n\tv96 = *([v71 @ stack_-38_v3 (Unco.InitializationSystem.Runtime.IInitializable)]);\n\t*([v96 @ X8_v5 (Il2CppClass<Unco.InitializationSystem.Runtime.IInitializable>)+138])(v116, v71, 0, *([v96 @ X8_v5 (Il2CppClass<Unco.InitializationSystem.Runtime.IInitializable>)+140]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv93 = v116 ^ 1;\n\treturnVal2 = v93;\nL_0042:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0041:\n\treturn returnVal2;\n")]
		public static bool IsInitialized(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::IsInitialized");
			return default;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x81B171C", Offset = "0x81B171C", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\n\tgoto L_0027;\nL_0027:\n\t;\n\tv99 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::GetEnumerator(v64._initializationTimeTracks);\n\tv112 = v99;\n\tv123 = 0xB7D5000 + 0x538;\n\tgoto L_003E;\nL_003B:\n\tUnityEngine.Debug::Log(v358);\nL_003E:\n\tv207 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>+Enumerator<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::MoveNext(&v112 @ stack_-70_v7 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>+Enumerator<Unco.InitializationSystem.Runtime.InitializationTimeTrack>));\n\tv211 = v207 == 0;\n\tif (v211) goto L_0067;\n\tv147 = v99.Current == 0;\n\tif (v147) goto L_003E;\n\tv182 = v99._current.initializable == 0;\nL_FFFFFFFF:\n\t;\n\tif (v182) goto L_009B;\n\tv312 = System.Reflection.MemberInfo::get_Name(v99._current.initializable);\n\tv208 = v99._current.processEndTime - v99.Current;\n\tv194 = v208;\n\tv316 = \"il2cpp_vm_object_box\"(*([v123 @ X24_v5 (System.Int32)+78]), &v194 @ stack_-84_v4 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v208, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv358 = System.String::Format(\"{0} | Process duration: {1}\", v312, v316);\n\tgoto L_003B;\nL_0067:\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>+Enumerator<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::Dispose(&v112 @ stack_-70_v7 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>+Enumerator<Unco.InitializationSystem.Runtime.InitializationTimeTrack>));\nL_0073:\n\treturn;\nL_009B:\n\tv188 = new System.NullReferenceException();\n\tgoto L_00AB;\nL_00AB:\n\tv229 = v170 != 1;\nL_FFFFFFFF:\n\tv246 = v188;\n\tif (v229) goto L_00BB;\n\tv237 = 0x8BF5BC4(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv305 = 0x8BF5BF4(v237, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>+Enumerator<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::Dispose(v154);\n\tv245 = *([v237 @ X0_v10]) == 0;\n\tif (v245) goto L_0073;\n\tv243 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv157 = *([v237 @ X0_v10]);\nL_FFFFFFFF:\n\tv246 = v243;\n\treturn;\nL_00BB:\n\tv249 = 0x3967250(&v157 @ stack_-80 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv307 = 0x8BF0368(v246, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv347 = 0x7C03E68(v307, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static void DebugInitializationTimes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializationManager::DebugInitializationTimes");
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x81B1950", Offset = "0x81B1950", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv70 = new Unco.InitializationSystem.Runtime.InitializableHub();\n\tUnco.InitializationSystem.Runtime.InitializableHub::.ctor(v70);\n\tv73._deInitializedHub = v70;\n\tv78 = new System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>();\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.InitializationTimeTrack>::.ctor(v78);\n\tv82._initializationTimeTracks = v78;\n\treturn;\nL_0027:\n\tv55 = new Unco.InitializationSystem.Runtime.InitializableHub();\n\tUnco.InitializationSystem.Runtime.InitializableHub::.ctor(v55);\n\tv64._initializedHub = v55;\n")]
		static InitializationManager()
		{
			InitializableHub initializedHub = new InitializableHub();
			_initializedHub = initializedHub;
			InitializableHub deInitializedHub = new InitializableHub();
			_deInitializedHub = deInitializedHub;
			List<InitializationTimeTrack> initializationTimeTracks = new List<InitializationTimeTrack>();
			_initializationTimeTracks = initializationTimeTracks;
		}
	}
}
