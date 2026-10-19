using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000043")]
	internal static class ContainerInitializationManager
	{
		[Token(Token = "0x2000044")]
		private class ListenerInfo
		{
			[Token(Token = "0x4000071")]
			[FieldOffset(Offset = "0x10")]
			public object Owner;

			[Token(Token = "0x4000072")]
			[FieldOffset(Offset = "0x18")]
			public MethodInfo Method;

			[Token(Token = "0x4000073")]
			[FieldOffset(Offset = "0x20")]
			public Type[] Dependencies;

			[Token(Token = "0x4000074")]
			[FieldOffset(Offset = "0x28")]
			public HashSet<Type> ResolvedDependencies;

			[Token(Token = "0x4000075")]
			[FieldOffset(Offset = "0x30")]
			public bool IsResolved;

			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x3F39920", Offset = "0x3F39920", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.HashSet`1<System.Type>();\n\tSystem.Collections.Generic.HashSet`1<System.Type>::.ctor(v48);\n\tthis.ResolvedDependencies = v48;\n")]
			public ListenerInfo()
			{
				HashSet<Type> resolvedDependencies = new HashSet<Type>();
				ResolvedDependencies = resolvedDependencies;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000046")]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			[Token(Token = "0x4000078")]
			[FieldOffset(Offset = "0x10")]
			public Type paramType;

			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x3F3A61C", Offset = "0x3F3A61C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass6_0()
			{
			}

			internal bool _003CInvokeListener_003Eb__0(object inst)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ContainerInitializationManager._003C_003Ec__DisplayClass6_0::_003CInvokeListener_003Eb__0");
				return default;
			}
		}

		[Token(Token = "0x400006F")]
		private static readonly List<ListenerInfo> _listeners;

		[Token(Token = "0x4000070")]
		private static readonly Dictionary<Type, object> _initializedInstances;

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x3F39470", Offset = "0x3F39470", Length = "0x4B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv61 = System.Object::GetType(instance);\n\tv146 = System.Type::GetMethods(v61, 0x3C);\n\tv97 = v146.Length < 1;\n\tif (v97) goto L_01C0;\nL_FFFFFFFF:\n\tv469 = 0;\n\tgoto L_0075;\nL_005B:\n\tv469 = v469 + 1;\n\tv98 = v469 >= v146.Length;\n\tif (v98) goto L_01C0;\nL_0075:\n\tgoto L_007B;\n\tv346 = System.Reflection.MemberInfo::GetCustomAttributes(v146[v469 @ X9_v7 (System.Int32)], v345, 0);\n\tv507 = v346.Length < 1;\n\tif (v507) goto L_005B;\nL_FFFFFFFF:\n\tv324 = 0;\n\tgoto L_00A7;\nL_0099:\n\tUnityEngine.Debug::LogWarning(v548);\n\tv324 = v324 + 1;\n\tv514 = v324 >= v346.Length;\n\tif (v514) goto L_005B;\nL_00A7:\n\tv263 = v346[v324 @ X22_v9 (System.Int32)];\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v280_asT @ TEMPCOND_v12 (OnContainerInitializeAttribute), typeof(OnContainerInitializeAttribute), v346[v324 @ X22_v9 (System.Int32)]\n\tv280 = v280_asT == 0;\n\tif (v280) goto L_01C4;\n\tv562 = *([v263 @ X26_v8 (System.Object)+10]);\n\tv563 = *([v263 @ X26_v8 (System.Object)+10]) == 0;\n\tif (v563) goto L_0142;\n\tv565 = *([v562 @ X8_v24+18]) == 0;\n\tif (v565) goto L_0142;\n\tv573 = new Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo();\n\tgoto L_00E5;\n\tSystem.Object::.ctor(v573);\n\tv573.Owner = instance;\n\tv573.Method = v146[v469 @ X9_v7 (System.Int32)];\n\tv573.Dependencies = *([v263 @ X26_v8 (System.Object)+10]);\n\tgoto L_010A;\n\tgoto L_01A1;\nL_0142:\n\tv426 = System.Reflection.MemberInfo::get_Name(v146[v469 @ X9_v7 (System.Int32)]);\n\tv350 = System.Object::GetType(instance);\n\tv428 = System.Reflection.MemberInfo::get_Name(v350);\n\t// 303 NewArr v349 @ X0_v21 (System.String[]), typeof(System.String[]), 5\n\tv349[0] = \"[ContainerInitialization] Method \";\n\tv349[1] = v426;\n\tv349[2] = \" in \";\n\tv349[3] = v428;\n\tv349[4] = \" has OnContainerInitialize attribute but no target types specified.\";\n\tv548 = System.String::Concat(v349);\n\tgoto L_0099;\nL_01A1:\n\tSystem.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>::Add(v348, v573);\nL_FFFFFFFF:\n\t;\n\tUnco.ContainerSystem.Runtime.ContainerInitializationManager::TryResolveListener(v573);\n\tv324 = v324 + 1;\n\tv515 = v324 < v346.Length;\n\tif (v515) goto L_00A7;\n\tgoto L_005B;\nL_01C0:\n\treturn;\nL_01C4:\n\tthrow System.InvalidCastException;\nL_0035:\n\tv55 = instance == 0;\n\tif (v55) goto L_01C0;\nL_007B:\n\tv345 = System.Type::GetTypeFromHandle(OnContainerInitializeAttribute);\nL_00E5:\n\tv590 = new System.Collections.Generic.HashSet`1<System.Type>();\n\tSystem.Collections.Generic.HashSet`1<System.Type>::.ctor(v590);\n\tv573.ResolvedDependencies = v590;\nL_010A:\n\tv348 = v366._listeners;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterListener(object instance)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInitializationManager::RegisterListener");
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x3F39C24", Offset = "0x3F39C24", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv73 = System.Object::GetType(instance);\n\tv58.instanceType = v73;\n\tgoto L_005D;\nL_005D:\n\tv308 = System.Collections.Generic.Dictionary`2<System.Type, System.Object>::ContainsKey(v286._initializedInstances, v58.instanceType);\n\tv313 = v308 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_0077;\n\tgoto L_0072;\nL_0072:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Object>::set_Item(v287._initializedInstances, v58.instanceType, instance);\nL_0077:\n\tgoto L_007B;\n\tv289 = v151.Count;\n\tv120 = v151.Count < 1;\n\tif (v120) goto L_012D;\n\tgoto L_00A5;\nL_0093:\n\tUnco.ContainerSystem.Runtime.ContainerInitializationManager::TryResolveListener(v274);\nL_009F:\n\tv89 = v289 <= 0;\n\tif (v89) goto L_012D;\nL_00A5:\n\tgoto L_00AC;\nL_00AC:\n\tv289 = v289 - 1;\n\tv274 = System.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>::get_Item(v285._listeners, v289);\n\tv354 = v274.Owner == 0;\n\tif (v354) goto L_00E1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v370_asT @ TEMPCOND_v7 (UnityEngine.Object), typeof(UnityEngine.Object), v274.Owner (System.Object)\n\tv370 = v370_asT == 0;\n\tif (v370) goto L_00F6;\n\tgoto L_00DA;\nL_00DA:\n\tv384 = UnityEngine.Object::op_Equality(v274.Owner, 0);\n\tv387 = ~v384;\n\tif (v387) goto L_00F6;\nL_00E1:\n\tgoto L_00EA;\nL_00EA:\n\tSystem.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>::RemoveAt(v288._listeners, v289);\n\tgoto L_009F;\nL_00F6:\n\tv416 = v274.IsResolved == 0;\n\tv417 = ~v416;\n\tif (v417) goto L_009F;\n\tv424 = v58.<>9__0 == 0;\n\tif (v424) goto L_0107;\n\tv447 = System.Array::Exists(v274.Dependencies, v58.<>9__0);\n\tv450 = ~v447;\n\tif (v450) goto L_009F;\nL_FFFFFFFF:\n\t;\n\tgoto L_011D;\nL_0107:\n\tv463 = new System.Predicate`1<System.Type>();\n\tSystem.Predicate`1<System.Type>::.ctor(v463, v58, Il2CppMethodInfo);\n\tv58.<>9__0 = v463;\n\tv448 = System.Array::Exists(v274.Dependencies, v463);\n\tv451 = ~v448;\nL_FFFFFFFF:\n\t;\n\tif (v451) goto L_009F;\nL_011D:\n\tgoto L_0093;\nL_012D:\n\treturn;\nL_003B:\n\tv58 = new Unco.ContainerSystem.Runtime.ContainerInitializationManager+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v58);\n\tv67 = instance == 0;\n\tif (v67) goto L_012D;\nL_007B:\n\tv151 = v337._listeners;\n")]
		public static void NotifyInstanceAdded(object instance)
		{
			if (instance == null)
			{
				return;
			}
			Type type = instance.GetType();
			Type instanceType = type;
			if (!_initializedInstances.ContainsKey(instanceType))
			{
				_initializedInstances[instanceType] = instance;
			}
			List<ListenerInfo> listeners = _listeners;
			int num = listeners.Count;
			if (listeners.Count < 1)
			{
				return;
			}
			Predicate<Type> predicate = default(Predicate<Type>);
			do
			{
				num--;
				ListenerInfo listenerInfo = _listeners[num];
				if (listenerInfo.Owner == null || (listenerInfo.Owner is UnityEngine.Object && (UnityEngine.Object)listenerInfo.Owner == null))
				{
					_listeners.RemoveAt(num);
				}
				else
				{
					if (listenerInfo.IsResolved)
					{
						continue;
					}
					if (predicate != null)
					{
						if (Array.Exists(listenerInfo.Dependencies, predicate))
						{
							goto IL_00c2;
						}
					}
					else if (Array.Exists(match: predicate = delegate(Type dep)
					{
						//IL_001f: Expected O, but got I
						int num2 = 192761856 + 1336;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v2 (System.Int32)+E0]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1+E4]");
						return ((nint)0 != 0) ? (dep == instanceType) : (dep == instanceType);
					}, array: listenerInfo.Dependencies))
					{
						goto IL_00c2;
					}
				}
				continue;
				IL_00c2:
				TryResolveListener(listenerInfo);
			}
			while (num > 0);
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x3F399AC", Offset = "0x3F399AC", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv62 = listener.IsResolved == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_00E3;\n\tv150 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v150);\n\tv141 = listener.Dependencies;\n\tv282 = v150 == 0;\n\tif (v282) goto L_00AC;\n\tv258 = v141.Length < 1;\n\tv239 = v150;\n\tif (v258) goto L_00CA;\n\tv101 = 0;\n\tgoto L_006E;\nL_005B:\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v150, v78);\n\tv101 = v101 + 1;\n\tv259 = v101 >= v141.Length;\n\tv239 = v150;\n\tif (v259) goto L_00CA;\nL_006E:\n\tgoto L_0078;\nL_0078:\n\tv230 = System.Collections.Generic.Dictionary`2<System.Type, System.Object>::TryGetValue(v165._initializedInstances, v141[v101 @ X24_v6 (System.Int32)], &v78 @ stack_-68_v6 (System.Object));\n\tv234 = ~v230;\n\tif (v234) goto L_00E3;\n\tv152 = System.Collections.Generic.HashSet`1<System.Type>::Add(listener.ResolvedDependencies, v141[v101 @ X24_v6 (System.Int32)]);\n\tgoto L_005B;\nL_00AC:\n\tv103 = v141.Length < 1;\n\tv239 = v150;\n\tif (v103) goto L_00CA;\n\tgoto L_00C1;\nL_00C1:\n\tv231 = System.Collections.Generic.Dictionary`2<System.Type, System.Object>::TryGetValue(v167._initializedInstances, v141[0], &v78 @ stack_-68_v6 (System.Object));\n\tv235 = ~v231;\n\tif (v235) goto L_00E3;\n\tv367 = listener.ResolvedDependencies == 0;\n\tv156 = ~v367;\n\tif (v156) goto L_00E8;\n\tthrow System.NullReferenceException;\nL_00CA:\n\tlistener.IsResolved = 1;\n\tgoto L_00D5;\nL_00D5:\n\tUnco.ContainerSystem.Runtime.ContainerInitializationManager::InvokeListener(listener, v239);\nL_00E3:\n\treturn;\nL_00E8:\n\tv369 = System.Collections.Generic.HashSet`1<System.Type>::Add(listener.ResolvedDependencies, v141[0]);\n\tthrow System.NullReferenceException;\nL_0029:\n\tv78 = 0;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void TryResolveListener(ListenerInfo listener)
		{
			object value = null;
			if (listener.IsResolved)
			{
				return;
			}
			List<object> list = new List<object>();
			Type[] dependencies = listener.Dependencies;
			List<object> instances;
			if (list != null)
			{
				bool flag = dependencies.Length < 1;
				instances = list;
				if (!flag)
				{
					int num = 0;
					bool flag3;
					do
					{
						if (_initializedInstances.TryGetValue(dependencies[num], out value))
						{
							bool flag2 = listener.ResolvedDependencies.Add(dependencies[num]);
							list.Add(value);
							num++;
							flag3 = num >= dependencies.Length;
							instances = list;
							continue;
						}
						return;
					}
					while (!flag3);
				}
			}
			else
			{
				bool flag4 = dependencies.Length < 1;
				instances = list;
				if (!flag4)
				{
					if (_initializedInstances.TryGetValue(dependencies[0], out value))
					{
						if (listener.ResolvedDependencies == null)
						{
							throw new NullReferenceException();
						}
						bool flag5 = listener.ResolvedDependencies.Add(dependencies[0]);
						throw new NullReferenceException();
					}
					return;
				}
			}
			listener.IsResolved = true;
			InvokeListener(listener, instances);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x3F39F80", Offset = "0x3F39F80", Length = "0x69C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv61 = listener.Method == 0;\n\tif (v61) goto L_018C;\n\tv69 = System.Reflection.MethodBase::GetParameters(listener.Method);\n\tv71 = v69 == 0;\n\tif (v71) goto L_018E;\n\tv77 = v69.Length == 0;\n\tif (v77) goto L_0158;\n\t// 73 NewArr v358 @ X0_v17 (System.Object[]), typeof(System.Object[]), v69.Length\n\tv131 = v69.Length < 1;\n\tif (v131) goto L_0150;\n\tv376 = instances == 0;\n\tif (v376) goto L_0195;\n\tv340 = v358 + 0x20;\n\tv113 = 0;\n\tgoto L_0074;\nL_0062:\n\tUnityEngine.Debug::LogWarning(v622);\nL_0064:\n\tv113 = v113 + 1;\n\tv340 = v340 + 8;\n\tv379 = v113 >= v69.Length;\n\tif (v379) goto L_0150;\nL_0074:\n\tv513 = new Unco.ContainerSystem.Runtime.ContainerInitializationManager+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v513);\n\tv512 = v113 < v69.Length;\n\tv230 = ~v512;\n\tif (v230) goto L_019D;\n\tv518 = v69[v113 @ X28_v9 (System.Int32)] == 0;\n\tif (v518) goto L_01A5;\n\tv527 = System.Reflection.ParameterInfo::get_ParameterType(v69[v113 @ X28_v9 (System.Int32)]);\n\tv529 = v513 == 0;\n\tif (v529) goto L_01AF;\n\tv513.paramType = v527;\n\tv544 = new System.Predicate`1<System.Object>();\n\tSystem.Predicate`1<System.Object>::.ctor(v544, v513, Il2CppMethodInfo);\n\tv550 = System.Collections.Generic.List`1<System.Object>::Find(instances, v544);\n\tv551 = v550 == 0;\n\tif (v551) goto L_00C0;\n\tv300 = v358 == 0;\n\tif (v300) goto L_0172;\n\tv556 = 0x21C11D0(v550, System.Object, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = v556 == 0;\n\tif (v299) goto L_016C;\n\tv557 = v113 < v358.Length;\n\tv231 = ~v557;\n\tif (v231) goto L_0170;\n\t*([v340 @ X23_v11]) = v550;\n\tgoto L_0064;\nL_00C0:\n\t// 192 NewArr v554 @ X0_v50 (System.String[]), typeof(System.String[]), 6\n\tv306 = v554 == 0;\n\tif (v306) goto L_0180;\n\tv304 = v554.Length == 0;\n\tif (v304) goto L_017C;\n\tv554[0] = \"[ContainerInitialization] Could not find matching instance for parameter \";\n\tv567 = v113 < v69.Length;\n\tv237 = ~v567;\n\tif (v237) goto L_0188;\n\tv307 = v69[v113 @ X28_v9 (System.Int32)] == 0;\n\tif (v307) goto L_0182;\n\tv587 = System.Reflection.ParameterInfo::get_Name(v69[v113 @ X28_v9 (System.Int32)]);\n\tv302 = v554.Length & -2;\n\tv191 = v302 == 0;\n\tif (v191) goto L_0178;\n\tv554[1] = v587;\n\tv591 = v554.Length < 2;\n\tv235 = ~v591;\n\tv222 = v554.Length - 2;\n\tv192 = v222 == 0;\n\tv592 = ~v235;\n\tv125 = v592 | v192;\n\tif (v125) goto L_0184;\n\tv554[2] = \" of type \";\n\tv303 = v513.paramType == 0;\n\tif (v303) goto L_017A;\n\tv600 = System.Reflection.MemberInfo::get_Name(v513.paramType);\n\tv305 = v554.Length & -4;\n\tv193 = v305 == 0;\n\tif (v193) goto L_017E;\n\tv554[3] = v600;\n\tv604 = v554.Length < 4;\n\tv233 = ~v604;\n\tv220 = v554.Length - 4;\n\tv190 = v220 == 0;\n\tv605 = ~v233;\n\tv124 = v605 | v190;\n\tif (v124) goto L_0186;\n\tv554[4] = \" in method \";\n\tv301 = listener.Method == 0;\n\tif (v301) goto L_0176;\n\tv614 = System.Reflection.MemberInfo::get_Name(listener.Method);\n\tv615 = v554.Length < 5;\n\tv232 = ~v615;\n\tv219 = v554.Length - 5;\n\tv189 = v219 == 0;\n\tv616 = ~v232;\n\tv123 = v616 | v189;\n\tif (v123) goto L_0174;\n\tv554[5] = v614;\n\tv622 = System.String::Concat(v554);\n\tgoto L_0062;\nL_0150:\n\tv308 = listener.Method == 0;\n\tif (v308) goto L_0190;\n\tv422 = System.Reflection.MethodBase::Invoke(listener.Method, listener.Owner, v358);\n\tgoto L_016B;\nL_0158:\n\tv310 = listener.Method == 0;\n\tif (v310) goto L_019F;\n\tv371 = System.Reflection.MethodBase::Invoke(listener.Method, listener.Owner, 0);\nL_016B:\n\treturn;\nL_016C:\n\tv558 = new System.ArrayTypeMismatchException();\n\tthrow v558;\nL_0170:\n\tv279 = new System.IndexOutOfRangeException();\n\tv62 = v279;\n\tgoto L_0240;\nL_0172:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0174:\n\tv281 = new System.IndexOutOfRangeException();\n\tv62 = v281;\n\tgoto L_0240;\nL_0176:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0178:\n\tv283 = new System.IndexOutOfRangeException();\n\tv62 = v283;\n\tgoto L_0240;\nL_017A:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_017C:\n\tv285 = new System.IndexOutOfRangeException();\n\tv62 = v285;\n\tgoto L_0240;\nL_017E:\n\tv286 = new System.IndexOutOfRangeException();\n\tv62 = v286;\n\tgoto L_0240;\nL_0180:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0182:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0184:\n\tv289 = new System.IndexOutOfRangeException();\n\tv62 = v289;\n\tgoto L_0240;\nL_0186:\n\tv290 = new System.IndexOutOfRangeException();\n\tv62 = v290;\n\tgoto L_0240;\nL_0188:\n\tv291 = new System.IndexOutOfRangeException();\n\tv62 = v291;\n\tgoto L_0240;\nL_018A:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_018C:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_018E:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0190:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_0195:\n\tv513 = new Unco.ContainerSystem.Runtime.ContainerInitializationManager+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v513);\n\tv509 = v69.Length == 0;\n\tv510 = ~v509;\n\tif (v510) goto L_01A2;\nL_019D:\n\tthrow v513;\nL_019F:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_01A2:\n\tv515 = v69[0] == 0;\n\tv516 = ~v515;\n\tif (v516) goto L_01AA;\nL_01A5:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_01AA:\n\tv522 = System.Reflection.ParameterInfo::get_ParameterType(v69[0]);\n\tv524 = v513 == 0;\n\tv313 = ~v524;\n\tif (v313) goto L_01B3;\nL_01AF:\n\tv62 = new System.NullReferenceException();\n\tgoto L_0240;\nL_01B3:\n\tv513.paramType = v522;\n\tv540 = new System.Predicate`1<System.Object>();\n\tSystem.Predicate`1<System.Object>::.ctor(v540, v513, Il2CppMethodInfo);\n\tthrow v540;\nL_0240:\n\t// 576 Interrupt\n\tv351 = 0x8BF5BF4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv361 = 0x8BF0368(v62, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv372 = 0xA1B8(v361, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0036:\n\tv56 = listener == 0;\n\tif (v56) goto L_018A;\n")]
		private static void InvokeListener(ListenerInfo listener, List<object> instances)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInitializationManager::InvokeListener");
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x3F3A624", Offset = "0x3F3A624", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv54 = v43._listeners;\n\tv45 = v43._listeners == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_002F;\n\tgoto L_0051;\nL_002F:\n\t;\n\tSystem.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>::Clear(v54);\n\tv75 = v54.Count < 1;\n\tif (v75) goto L_004F;\nL_004F:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Object>::Clear(v110._initializedInstances);\n\treturn;\nL_0051:\n\tthrow System.NullReferenceException;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Clear()
		{
			List<ListenerInfo> listeners = _listeners;
			if (_listeners != null)
			{
				listeners.Clear();
				if (listeners.Count >= 1)
				{
				}
				_initializedInstances.Clear();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x3F3A6FC", Offset = "0x3F3A6FC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv74 = new System.Collections.Generic.Dictionary`2<System.Type, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Object>::.ctor(v74);\n\tv80._initializedInstances = v74;\n\treturn;\nL_002C:\n\tv57 = new System.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>();\n\tSystem.Collections.Generic.List`1<Unco.ContainerSystem.Runtime.ContainerInitializationManager+ListenerInfo>::.ctor(v57);\n\tv67._listeners = v57;\n")]
		static ContainerInitializationManager()
		{
			List<ListenerInfo> listeners = new List<ListenerInfo>();
			_listeners = listeners;
			Dictionary<Type, object> initializedInstances = new Dictionary<Type, object>();
			_initializedInstances = initializedInstances;
		}
	}
}
