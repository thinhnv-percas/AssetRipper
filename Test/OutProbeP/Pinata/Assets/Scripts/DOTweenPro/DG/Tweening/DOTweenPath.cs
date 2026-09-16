using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x742B28", Offset = "0x742B28")]
	[Token(Token = "0x2000006")]
	public class DOTweenPath : ABSAnimationComponent
	{
		[CompilerGenerated]
		[Token(Token = "0x4000011")]
		private static Action<DOTweenPath> m_OnReset;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x68")]
		public float delay;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x6C")]
		public float duration;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x70")]
		public Ease easeType;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x78")]
		public AnimationCurve easeCurve;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x80")]
		public int loops;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x88")]
		public string id;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x90")]
		public LoopType loopType;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x94")]
		public OrientType orientType;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x98")]
		public Transform lookAtTransform;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0xA0")]
		public Vector3 lookAtPosition;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0xAC")]
		public float lookAhead;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0xB0")]
		public bool autoPlay;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0xB1")]
		public bool autoKill;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0xB2")]
		public bool relative;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0xB3")]
		public bool isLocal;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0xB4")]
		public bool isClosedPath;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0xB8")]
		public int pathResolution;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0xBC")]
		public PathMode pathMode;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0xC0")]
		public AxisConstraint lockRotation;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0xC4")]
		public bool assignForwardAndUp;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0xC8")]
		public Vector3 forwardDirection;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0xD4")]
		public Vector3 upDirection;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0xE0")]
		public bool tweenRigidbody;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0xE8")]
		public List<Vector3> wps;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0xF0")]
		public List<Vector3> fullWps;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0xF8")]
		public Path path;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x100")]
		public DOTweenInspectorMode inspectorMode;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x104")]
		public PathType pathType;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x108")]
		public HandlesType handlesType;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x10C")]
		public bool livePreview;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x110")]
		public HandlesDrawMode handlesDrawMode;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x114")]
		public float perspectiveHandleSize;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x118")]
		public bool showIndexes;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x119")]
		public bool showWpLength;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x11C")]
		public Color pathColor;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x12C")]
		public Vector3 lastSrcPosition;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x138")]
		public Quaternion lastSrcRotation;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x148")]
		public bool wpsDropdown;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x14C")]
		public float dropToFloorOffset;

		[Token(Token = "0x4000039")]
		private static MethodInfo _miCreateTween;

		[Token(Token = "0x14000001")]
		public static event Action<DOTweenPath> OnReset
		{
			[CompilerGenerated]
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x163B448", Offset = "0x163B448", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB6B70]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A887]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<DG.Tweening.DOTweenPath>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.OnReset, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Delegate obj = DOTweenPath.m_OnReset;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<DOTweenPath>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x163B4FC", Offset = "0x163B4FC", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE5240]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A888]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<DG.Tweening.DOTweenPath>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81.OnReset, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				Delegate obj = DOTweenPath.m_OnReset;
				Delegate obj3 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<DOTweenPath>))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj != obj3;
					obj = obj3;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x163B5B0", Offset = "0x163B5B0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE35A8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A889]) = v38;\nL_0018:\n\tv44 = v42.OnReset == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<DG.Tweening.DOTweenPath>::Invoke(v42.OnReset, path);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Dispatch_OnReset(DOTweenPath path)
		{
			if (DOTweenPath.OnReset != null)
			{
				DOTweenPath.OnReset(path);
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x163B624", Offset = "0x163B624", Length = "0xBFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv46 = *([1EEE348]);\n\tv47 = *([v46 @ X8_v182]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([202A88A]) = v66;\nL_0021:\n\tv717 = this.path;\n\tv68 = this.path == 0;\n\tif (v68) goto L_0459;\n\tv69 = this.wps;\n\tv189 = v69._size < 1;\n\tif (v189) goto L_0459;\n\tv214 = this.inspectorMode == 3;\n\tif (v214) goto L_0459;\n\tv690 = v688._miCreateTween == 0;\n\tv691 = ~v690;\n\tif (v691) goto L_0068;\n\tgoto L_0057;\n\tv751 = *([v707 @ X0_v183+E0]);\n\tv752 = v751 == 0;\n\tv753 = ~v752;\n\tif (v753) goto L_0057;\n\tv755 = \"il2cpp_codegen_runtime_class_init\"(v707, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_0057:\n\tv762 = DG.Tweening.Core.Utils::GetLooseScriptType(\"DG.Tweening.DOTweenModuleUtils+Physics\");\n\tv858 = System.Type::GetMethod(v762, \"CreateDOTweenPathTween\", 0x18);\n\tv722._miCreateTween = v858;\n\tv717 = this.path;\nL_0068:\n\tDG.Tweening.Plugins.Core.PathCore.Path::AssignDecoder(v717, v717.type);\n\tgoto L_0078;\n\tv776 = *([v765 @ X0_v149 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv777 = v776 == 0;\n\tv778 = ~v777;\n\tif (v778) goto L_0078;\n\tv859 = \"il2cpp_codegen_runtime_class_init\"(v765, v723, v724, v711, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv780 = DG.Tweening.Core.TweenManager;\nL_0078:\n\tv785 = ~v783.isUnityEditor;\n\tif (v785) goto L_00A7;\n\tgoto L_008D;\n\tv905 = *([v862 @ X0_v174 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv906 = v905 == 0;\n\tv907 = ~v906;\n\tif (v907) goto L_008D;\n\tv1086 = \"il2cpp_codegen_runtime_class_init\"(v862, v723, v724, v711, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv909 = DG.Tweening.DOTween;\nL_008D:\n\tv491 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v491, this.path, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::Add(v913.GizmosDelegates, v491);\n\tv515 = this.path;\n\tv515.gizmoColor.r = this.pathColor;\n\tv515.gizmoColor.g = this.pathColor.g;\n\tv515.gizmoColor.a = this.pathColor.a;\nL_00A7:\n\tv676 = ~this.isLocal;\n\tif (v676) goto L_01A5;\n\tv849 = UnityEngine.Component::get_transform(this);\n\tv1186 = UnityEngine.Transform::get_parent(v849);\n\tgoto L_00C3;\n\tv1202 = *([v680 @ X8_v141+E0]);\n\tv1203 = v1202 == 0;\n\tv1204 = ~v1203;\n\tif (v1204) goto L_00C3;\n\tv1213 = v680;\n\tv1206 = \"il2cpp_codegen_runtime_class_init\"(v1213, v1185, v658, v403, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\nL_00C3:\n\tv674 = UnityEngine.Object::op_Inequality(v1186, 0);\n\tv677 = v674 == 0;\n\tif (v677) goto L_01A5;\n\tv493 = UnityEngine.Transform::get_parent(v849);\n\tv374 = UnityEngine.Transform::get_position(v493);\n\tv1282 = this.path;\n\tv388 = v1282.wps;\nL_00E7:\n\tv421 = v345 >= v388.Length;\n\tif (v421) goto L_0126;\n\tv337 = v1282.wps + v398;\n\tgoto L_010C;\n\tv1267 = *([v1263 @ X0_v168+E0]);\n\tv1268 = v1267 == 0;\n\tv1269 = ~v1268;\n\tif (v1269) goto L_010C;\n\tv1271 = \"il2cpp_codegen_runtime_class_init\"(v1263, v412, v407, v403, v52, v53, v54, v55, v375, v368, v361, v311, v316, v306, v62, v63);\nL_010C:\n\t// 268 MakeStruct v303 @ AGG163B8F0_0_v10 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v337 @ X25_v11+20], [v337 @ X25_v11+24], [v337 @ X25_v11+28]\n\tv375 = UnityEngine.Vector3::op_Subtraction(v303, v374);\n\t*([v337 @ X25_v11+20]) = v375;\n\t*([v337 @ X25_v11+24]) = v375.y;\n\t*([v337 @ X25_v11+28]) = v375.z;\n\tv1282 = this.path;\n\tv345 = v345 + 1;\n\tv398 = v398 + 0xC;\n\tv1283 = this.path == 0;\n\tv505 = ~v1283;\n\tif (v505) goto L_00E7;\n\tgoto L_01A3;\nL_0126:\n\tv389 = v1282.controlPoints;\n\tv422 = v389.Length < 1;\n\tif (v422) goto L_01A5;\nL_014D:\n\tv69 = v1282.controlPoints + v351;\n\tgoto L_0165;\n\tv1326 = *([v1305 @ X0_v163+E0]);\n\tv1327 = v1326 == 0;\n\tv1328 = ~v1327;\n\tif (v1328) goto L_0165;\n\tv1330 = \"il2cpp_codegen_runtime_class_init\"(v1305, v412, v407, v403, v52, v53, v54, v55, v1310, v370, v363, v313, v318, v308, v62, v63);\nL_0165:\n\t// 357 MakeStruct v279 @ AGG163B9A4_0_v10 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)], [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+4], [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+8]\n\tv1340 = UnityEngine.Vector3::op_Subtraction(v279, v374);\n\t// 372 MakeStruct v273 @ AGG163B9D0_0_v10 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+C], [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10], [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+14]\n\tv372 = UnityEngine.Vector3::op_Subtraction(v273, v374);\n\tv520 = this.path;\n\tv400 = v400 + 1;\n\tv69 = v520.controlPoints + v351;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)]) = v1340;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+4]) = v1340.y;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+8]) = v1340.z;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+C]) = v372;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]) = v372.y;\n\t*([v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+14]) = v372.z;\n\tv420 = v400 >= v389.Length;\n\tif (v420) goto L_01A5;\n\tv1282 = this.path;\n\tv351 = v351 + 0x18;\n\tv1563 = this.path == 0;\n\tv499 = ~v1563;\n\tif (v499) goto L_014D;\nL_01A3:\n\tthrow System.NullReferenceException;\nL_01A5:\n\tv685 = ~this.relative;\n\tif (v685) goto L_01B3;\n\tDG.Tweening.DOTweenPath::ReEvaluateRelativeTween(this);\nL_01B3:\n\tv704 = this.pathMode != 1;\n\tif (v704) goto L_01D8;\n\tv729 = UnityEngine.Component::GetComponent(this);\n\tgoto L_01CB;\n\tv786 = *([v741 @ X8_v124+E0]);\n\tv787 = v786 == 0;\n\tv788 = ~v787;\n\tif (v788) goto L_01CB;\n\tv871 = v741;\n\tv790 = \"il2cpp_codegen_runtime_class_init\"(v871, v728, v657, v405, v52, v53, v54, v55, v378, v371, v364, v135, v137, v133, v62, v63);\nL_01CB:\n\tv736 = UnityEngine.Object::op_Inequality(v729, 0);\n\tv738 = v736 == 0;\n\tif (v738) goto L_01D8;\n\tthis.pathMode = 2;\nL_01D8:\n\t// 472 NewArr v750 @ X0_v19 (System.Object[]), typeof(System.Object[]), 6\n\t// 479 IsInst v796 @ X0_v21, typeof(System.Object), this @ X0 (DG.Tweening.DOTweenPath)\n\tv873 = v796 == 0;\n\tif (v873) goto L_045E;\n\tv750[0] = this;\n\tv1089 = this.tweenRigidbody;\n\t// 492 Box v1092 @ X0_v23, typeof(System.Boolean), &v1089 @ X8_v18 (System.Boolean)\n\tv1187 = v1092 == 0;\n\tif (v1187) goto L_0203;\n\t// 499 IsInst v1064 @ X0_v136, typeof(System.Object), v1092 @ X0_v23\n\tv1071 = v1064 == 0;\n\tif (v1071) goto L_045E;\nL_0203:\n\tv750[1] = v1092;\n\tv1209 = this.isLocal;\n\t// 520 Box v1212 @ X0_v26, typeof(System.Boolean), &v1209 @ X8_v21 (System.Boolean)\n\tv1215 = v1212 == 0;\n\tif (v1215) goto L_021F;\n\t// 527 IsInst v1065 @ X0_v134, typeof(System.Object), v1212 @ X0_v26\n\tv1072 = v1065 == 0;\n\tif (v1072) goto L_045E;\nL_021F:\n\tv750[2] = v1212;\n\tv1221 = this.path == 0;\n\tif (v1221) goto L_0236;\n\t// 550 IsInst v1066 @ X0_v132, typeof(System.Object), this.path (DG.Tweening.Plugins.Core.PathCore.Path)\n\tv1073 = v1066 == 0;\n\tif (v1073) goto L_045E;\nL_0236:\n\tv750[3] = this.path;\n\tv1227 = this.duration;\n\t// 573 Box v1230 @ X0_v30, typeof(System.Single), &v1227 @ X8_v25 (System.Single)\n\tv1231 = v1230 == 0;\n\tif (v1231) goto L_0254;\n\t// 580 IsInst v1067 @ X0_v130, typeof(System.Object), v1230 @ X0_v30\n\tv1074 = v1067 == 0;\n\tif (v1074) goto L_045E;\nL_0254:\n\tv750[4] = v1230;\n\tv1251 = this.pathMode;\n\t// 603 Box v1254 @ X0_v33, typeof(DG.Tweening.PathMode), &v1251 @ X8_v28 (DG.Tweening.PathMode)\n\tv1255 = v1254 == 0;\n\tif (v1255) goto L_0272;\n\t// 610 IsInst v1068 @ X0_v128, typeof(System.Object), v1254 @ X0_v33\n\tv1075 = v1068 == 0;\n\tif (v1075) goto L_045E;\nL_0272:\n\tv750[5] = v1254;\n\tv899 = System.Reflection.MethodBase::Invoke(v747._miCreateTween, 0, v750);\n\tv900 = v899 == 0;\n\tif (v900) goto L_02A2;\n\tgoto L_FFFFFFFF;\n\tv881 = v881_asT == 0;\n\tif (v881) goto L_0462;\nL_02A2:\n\tv1304 = DG.Tweening.TweenSettingsExtensions::SetOptions(v899, this.isClosedPath, 0, this.lockRotation);\n\tv1321 = this.orientType == 1;\n\tif (v1321) goto L_02E6;\n\tv1345 = this.orientType == 2;\n\tif (v1345) goto L_0308;\n// ... truncated")]
		private void Awake()
		{
			//IL_022d: Expected O, but got I
			//IL_024a: Expected F4, but got I
			//IL_025f: Expected F4, but got I
			//IL_0274: Expected F4, but got I
			//IL_039b: Expected O, but got I
			//IL_03b3: Expected F4, but got O
			//IL_03c8: Expected F4, but got I
			//IL_03dd: Expected F4, but got I
			//IL_0403: Expected F4, but got I
			//IL_0418: Expected F4, but got I
			//IL_042d: Expected F4, but got I
			//IL_0475: Expected O, but got I
			Path path = this.path;
			if (this.path == null)
			{
				return;
			}
			List<Vector3> list = wps;
			if (list.Count < 1 || inspectorMode == DOTweenInspectorMode.OnlyPath)
			{
				return;
			}
			if ((object)_miCreateTween == null)
			{
				Type looseScriptType = Utils.GetLooseScriptType("DG.Tweening.DOTweenModuleUtils+Physics");
				MethodInfo method = looseScriptType.GetMethod("CreateDOTweenPathTween", BindingFlags.Static | BindingFlags.Public);
				_miCreateTween = method;
				path = this.path;
			}
			path.AssignDecoder(path.type);
			if (TweenManager.isUnityEditor)
			{
				TweenCallback item = this.path.Draw;
				DOTween.GizmosDelegates.Add(item);
				Path path2 = this.path;
				path2.gizmoColor.r = pathColor.r;
				path2.gizmoColor.g = pathColor.g;
				path2.gizmoColor.a = pathColor.a;
			}
			if (isLocal)
			{
				Transform transform = base.transform;
				Transform parent = transform.parent;
				if (parent != null)
				{
					Transform parent2 = transform.parent;
					Vector3 position = parent2.position;
					Path path3 = this.path;
					Vector3[] array = path3.wps;
					float num2 = default(float);
					float num = num2;
					Vector3 vector2 = default(Vector3);
					Vector3 vector = vector2;
					float num4 = default(float);
					float num3 = num4;
					int num5 = 0;
					Vector3 vector3 = position;
					int num6 = 0;
					Vector3 vector4 = default(Vector3);
					Vector3 vector6 = default(Vector3);
					Vector3 vector8 = default(Vector3);
					while (true)
					{
						if (num5 < array.Length)
						{
							object obj = (long)(IntPtr)path3.wps + (long)num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X25_v11+20]");
							vector4.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X25_v11+24]");
							vector4.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X25_v11+28]");
							vector4.z = 0f;
							vector3 = vector4 - position;
							_ = vector3.y;
							_ = vector3.z;
							path3 = this.path;
							num5++;
							num6 += 12;
							bool flag = this.path == null;
							bool flag2 = !flag;
							num = position.z;
							vector = position;
							num3 = position.y;
							if (flag2)
							{
								continue;
							}
							goto IL_0555;
						}
						ControlPoint[] controlPoints = path3.controlPoints;
						bool flag3 = controlPoints.Length < 1;
						num2 = num;
						vector2 = vector;
						num4 = num3;
						Vector3 vector5 = vector3;
						if (flag3)
						{
							break;
						}
						int num7 = 32;
						int num8 = 0;
						while (true)
						{
							list = (List<Vector3>)((long)(IntPtr)path3.controlPoints + (long)num7);
							vector6.x = (float)list;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+4]");
							vector6.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+8]");
							vector6.z = 0f;
							Vector3 vector7 = vector6 - position;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+C]");
							vector8.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							vector8.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v4 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+14]");
							vector8.z = 0f;
							vector5 = vector8 - position;
							Path path4 = this.path;
							num8++;
							list = (List<Vector3>)((long)(IntPtr)path4.controlPoints + (long)num7);
							list = (List<Vector3>)vector7;
							_ = vector7.y;
							_ = vector7.z;
							_ = vector5.y;
							_ = vector5.z;
							bool flag4 = num8 >= controlPoints.Length;
							num2 = position.z;
							vector2 = position;
							num4 = position.y;
							if (flag4)
							{
								break;
							}
							path3 = this.path;
							num7 += 24;
							bool flag5 = this.path == null;
							bool flag6 = !flag5;
							num2 = position.z;
							vector2 = position;
							num4 = position.y;
							if (flag6)
							{
								continue;
							}
							goto IL_0555;
						}
						break;
						IL_0555:
						throw new NullReferenceException();
					}
				}
			}
			if (relative)
			{
				ReEvaluateRelativeTween();
			}
			if (this.pathMode == PathMode.Full3D)
			{
				SpriteRenderer component = GetComponent<SpriteRenderer>();
				if (component != null)
				{
					this.pathMode = PathMode.TopDown2D;
				}
			}
			object[] array2 = new object[6];
			object obj2 = this as object;
			if (obj2 != null)
			{
				array2[0] = this;
				bool flag7 = tweenRigidbody;
				object obj3 = flag7;
				if (obj3 != null)
				{
					object obj4 = obj3 as object;
					if (obj4 == null)
					{
						goto IL_0fb3;
					}
				}
				array2[1] = obj3;
				bool flag8 = isLocal;
				object obj5 = flag8;
				if (obj5 != null)
				{
					object obj6 = obj5 as object;
					if (obj6 == null)
					{
						goto IL_0fb3;
					}
				}
				array2[2] = obj5;
				if (this.path != null)
				{
					object obj7 = this.path as object;
					if (obj7 == null)
					{
						goto IL_0fb3;
					}
				}
				array2[3] = this.path;
				float num9 = duration;
				object obj8 = num9;
				if (obj8 != null)
				{
					object obj9 = obj8 as object;
					if (obj9 == null)
					{
						goto IL_0fb3;
					}
				}
				array2[4] = obj8;
				PathMode pathMode = this.pathMode;
				object obj10 = pathMode;
				if (obj10 != null)
				{
					object obj11 = obj10 as object;
					if (obj11 == null)
					{
						goto IL_0fb3;
					}
				}
				array2[5] = obj10;
				object obj12 = _miCreateTween.Invoke(null, array2);
				if (obj12 != null)
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore = obj12 as TweenerCore<Vector3, Path, PathOptions>;
					if (tweenerCore == null)
					{
						throw new InvalidCastException();
					}
				}
				TweenerCore<Vector3, Path, PathOptions> tweenerCore2 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetOptions(isClosedPath, default(AxisConstraint), lockRotation);
				if (orientType != OrientType.ToPath)
				{
					if (orientType != OrientType.LookAtTransform)
					{
						if (orientType == OrientType.LookAtPosition)
						{
							float z;
							float y;
							Vector3 vector10;
							Vector3? up;
							Vector3? vector11;
							TweenerCore<Vector3, Path, PathOptions> t;
							if (assignForwardAndUp)
							{
								Vector3? vector9 = null;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
								int num10 = 0;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
								z = lookAtPosition.z;
								y = lookAtPosition.y;
								vector10 = lookAtPosition;
								up = null;
								vector11 = null;
								t = (TweenerCore<Vector3, Path, PathOptions>)obj12;
							}
							else
							{
								z = lookAtPosition.z;
								y = lookAtPosition.y;
								vector10 = lookAtPosition;
								up = null;
								vector11 = null;
								t = (TweenerCore<Vector3, Path, PathOptions>)obj12;
							}
							Vector3 vector12 = default(Vector3);
							vector12.x = vector10.x;
							vector12.y = y;
							vector12.z = z;
							TweenerCore<Vector3, Path, PathOptions> tweenerCore3 = t.SetLookAt(vector12, vector11, up);
						}
					}
					else if (lookAtTransform != null)
					{
						Vector3? up2;
						Vector3? vector13;
						Transform transform2;
						TweenerCore<Vector3, Path, PathOptions> t2;
						if (assignForwardAndUp)
						{
							Vector3? vector9 = null;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
							int num10 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
							up2 = null;
							vector13 = null;
							transform2 = lookAtTransform;
							t2 = (TweenerCore<Vector3, Path, PathOptions>)obj12;
						}
						else
						{
							up2 = null;
							vector13 = null;
							transform2 = lookAtTransform;
							t2 = (TweenerCore<Vector3, Path, PathOptions>)obj12;
						}
						TweenerCore<Vector3, Path, PathOptions> tweenerCore4 = t2.SetLookAt(transform2, vector13, up2);
					}
				}
				else
				{
					float num11;
					Vector3? up3;
					Vector3? vector14;
					TweenerCore<Vector3, Path, PathOptions> t3;
					if (assignForwardAndUp)
					{
						Vector3? vector9 = null;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
						int num10 = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
						num11 = lookAhead;
						up3 = null;
						vector14 = null;
						t3 = (TweenerCore<Vector3, Path, PathOptions>)obj12;
					}
					else
					{
						num11 = lookAhead;
						up3 = null;
						vector14 = null;
						t3 = (TweenerCore<Vector3, Path, PathOptions>)obj12;
					}
					TweenerCore<Vector3, Path, PathOptions> tweenerCore5 = t3.SetLookAt(num11, vector14, up3);
				}
				TweenerCore<Vector3, Path, PathOptions> t4 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetDelay(delay);
				TweenerCore<Vector3, Path, PathOptions> t5 = t4.SetLoops(loops, loopType);
				TweenerCore<Vector3, Path, PathOptions> t6 = t5.SetAutoKill(autoKill);
				TweenerCore<Vector3, Path, PathOptions> t7 = t6.SetUpdate(updateType);
				TweenCallback action = delegate
				{
					tween = null;
				};
				TweenerCore<Vector3, Path, PathOptions> tweenerCore6 = t7.OnKill(action);
				if (isSpeedBased)
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore7 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetSpeedBased();
				}
				if (easeType == Ease.INTERNAL_Custom)
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore8 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetEase(easeCurve);
				}
				else
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore9 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetEase(easeType);
				}
				if (!string.IsNullOrEmpty(id))
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore10 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).SetId(id);
				}
				if (hasOnStart)
				{
					if (onStart != null)
					{
						TweenCallback action2 = onStart.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore11 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnStart(action2);
					}
				}
				else
				{
					onStart = null;
				}
				if (hasOnPlay)
				{
					if (onPlay != null)
					{
						TweenCallback action3 = onPlay.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore12 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnPlay(action3);
					}
				}
				else
				{
					onPlay = null;
				}
				if (hasOnUpdate)
				{
					if (onUpdate != null)
					{
						TweenCallback action4 = onUpdate.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore13 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnUpdate(action4);
					}
				}
				else
				{
					onUpdate = null;
				}
				if (hasOnStepComplete)
				{
					if (onStepComplete != null)
					{
						TweenCallback action5 = onStepComplete.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore14 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnStepComplete(action5);
					}
				}
				else
				{
					onStepComplete = null;
				}
				if (hasOnComplete)
				{
					if (onComplete != null)
					{
						TweenCallback action6 = onComplete.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore15 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnComplete(action6);
					}
				}
				else
				{
					onComplete = null;
				}
				if (hasOnRewind)
				{
					if (onRewind != null)
					{
						TweenCallback action7 = onRewind.Invoke;
						TweenerCore<Vector3, Path, PathOptions> tweenerCore16 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).OnRewind(action7);
					}
				}
				else
				{
					onRewind = null;
				}
				if (autoPlay)
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore17 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).Play();
				}
				else
				{
					TweenerCore<Vector3, Path, PathOptions> tweenerCore18 = ((TweenerCore<Vector3, Path, PathOptions>)obj12).Pause();
				}
				tween = (Tween)obj12;
				if (hasOnTweenCreated && onTweenCreated != null)
				{
					onTweenCreated.Invoke();
				}
				return;
			}
			goto IL_0fb3;
			IL_0fb3:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x163C538", Offset = "0x163C538", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB5288]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A88B]) = v42;\nL_001C:\n\tv49 = System.Collections.Generic.List`1<UnityEngine.Vector3>::ToArray(this.wps);\n\tv59 = 0;\n\tv63 = 0x115CE84(&v59 @ stack_-48_v1, Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, this.pathColor, this.pathColor.g, this.pathColor.b, this.pathColor.a, v36, v37, v38, v39);\n\tv67 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tv71 = 0;\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v67, this.pathType, v49, 0xA, &v71 @ stack_-60_v1);\n\tthis.path = v67;\n\tDG.Tweening.DOTweenPath::Dispatch_OnReset(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Reset()
		{
			//IL_001d: Expected O, but got I4
			//IL_0049: Expected O, but got Ref
			//IL_0056: Expected O, but got I4
			Vector3[] waypoints = wps.ToArray();
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115CE84 (inside System.Nullable`1<System.Single>::Unbox +0xA8)");
			object obj2 = default(object);
			Path path = new Path(pathType, waypoints, 10, (Color?)(object)(&obj2));
			obj2 = 0;
			this.path = path;
			Dispatch_OnReset(this);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x163C620", Offset = "0x163C620", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.tween;\n\tv11 = this.tween == 0;\n\tif (v11) goto L_000F;\n\tv13 = ~v10.<active>k__BackingField;\n\tif (v13) goto L_000F;\n\tDG.Tweening.TweenExtensions::Kill(this.tween, 0);\nL_000F:\n\tthis.tween = 0;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			Tween tween = base.tween;
			if (base.tween != null && tween.active)
			{
				base.tween.Kill();
			}
			base.tween = null;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x163C65C", Offset = "0x163C65C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFC148]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A88C]) = v38;\nL_001C:\n\tv47 = DG.Tweening.TweenExtensions::Play(this.tween);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlay()
		{
			Tween tween = base.tween.Play();
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x163C6AC", Offset = "0x163C6AC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::PlayBackwards(this.tween);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlayBackwards()
		{
			tween.PlayBackwards();
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x163C6B8", Offset = "0x163C6B8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::PlayForward(this.tween);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPlayForward()
		{
			tween.PlayForward();
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x163C6C4", Offset = "0x163C6C4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC1670]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A88D]) = v38;\nL_001C:\n\tv47 = DG.Tweening.TweenExtensions::Pause(this.tween);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOPause()
		{
			Tween tween = base.tween.Pause();
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x163C714", Offset = "0x163C714", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::TogglePause(this.tween);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOTogglePause()
		{
			tween.TogglePause();
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x163C720", Offset = "0x163C720", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Rewind(this.tween, 1);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORewind()
		{
			tween.Rewind();
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x163C730", Offset = "0x163C730", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv3 = this->klass->vtable[11];\n\tv4 = this->klass->vtable[11];\n\t// 4 IndirectJump v3 @ X3_v1, this @ X0 (DG.Tweening.DOTweenPath), this @ X0 (DG.Tweening.DOTweenPath), 0, v4 @ X2_v1, v3 @ X3_v1, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORestart()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<DG.Tweening.DOTweenPath>)+1E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<DG.Tweening.DOTweenPath>)+1E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x163C740", Offset = "0x163C740", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this.tween;\n\tv13 = this.tween == 0;\n\tif (v13) goto L_0025;\n\tv16 = fromHere == 0;\n\tif (v16) goto L_001F;\n\tv22 = ~this.relative;\n\tif (v22) goto L_001F;\n\tv74 = ~this.isLocal;\n\tv27 = ~v74;\n\tif (v27) goto L_001F;\n\tDG.Tweening.DOTweenPath::ReEvaluateRelativeTween(this);\n\tv28 = this.tween;\nL_001F:\n\tDG.Tweening.TweenExtensions::Restart(v28, 1, -1f);\n\treturn;\nL_0025:\n\tgoto L_003B;\n\tv38 = *([1EA3C20]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, fromHere, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv56 = 0 | 1;\n\t*([2022B9B]) = v56;\nL_003B:\n\tv73 = v61._logPriority < 2;\n\tif (v73) goto L_004B;\n\tDG.Tweening.Core.Debugger::LogNullTween(this.tween);\n\treturn;\nL_004B:\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DORestart(bool fromHere)
		{
			Tween t = tween;
			if (tween != null)
			{
				if (fromHere && relative && !isLocal)
				{
					ReEvaluateRelativeTween();
					t = tween;
				}
				t.Restart();
			}
			else if (Debugger._logPriority >= 2)
			{
				Debugger.LogNullTween(tween);
			}
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x163C7F0", Offset = "0x163C7F0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Complete(this.tween);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOComplete()
		{
			tween.Complete();
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x163C7FC", Offset = "0x163C7FC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Kill(this.tween, 0);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void DOKill()
		{
			tween.Kill();
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x163C80C", Offset = "0x163C80C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.tween;\n\tv13 = this.tween == 0;\n\tif (v13) goto L_0012;\n\tv15 = ~returnVal1.<active>k__BackingField;\n\tv16 = ~v15;\n\tif (v16) goto L_0038;\nL_0012:\n\tgoto L_0028;\n\tv66 = *([1EA3C20]);\n\tv67 = *([v66 @ X8_v11]);\n\tv68 = \"il2cpp_codegen_initialize_method\"(v67, methodInfo, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82);\n\tv84 = 0 | 1;\n\t*([2022B9B]) = v84;\nL_0028:\n\tv25 = v89._logPriority < 2;\n\tif (v25) goto L_FFFFFFFF;\n\tv93 = this.tween == 0;\n\tif (v93) goto L_0031;\n\tDG.Tweening.Core.Debugger::LogInvalidTween(this.tween);\n\tgoto L_FFFFFFFF;\nL_0031:\n\tDG.Tweening.Core.Debugger::LogNullTween(this.tween);\nL_0038:\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Tween GetTween()
		{
			Tween tween = base.tween;
			if (base.tween == null || !tween.active)
			{
				if (Debugger._logPriority >= 2)
				{
					if (base.tween != null)
					{
						Debugger.LogInvalidTween(base.tween);
					}
					else
					{
						Debugger.LogNullTween(base.tween);
					}
				}
				tween = null;
			}
			return tween;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x163C898", Offset = "0x163C898", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEDC50]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A88E]) = v38;\nL_0013:\n\tv39 = this.path;\n\tv42 = v39.wps == 0;\n\tif (v42) goto L_0031;\n\tv46 = v39.nonLinearDrawWps == 0;\n\tif (v46) goto L_0031;\n\tv63 = this.pathType != 0;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_002C;\nL_002C:\n\tgoto L_0038;\nL_0031:\n\tDG.Tweening.Core.Debugger::LogWarning(\"Draw points not ready yet. Returning NULL\");\nL_0038:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3[] GetDrawPoints()
		{
			Path path = this.path;
			if (path.wps != null && path.nonLinearDrawWps != null)
			{
				if (pathType == PathType.Linear)
				{
					return path.wps;
				}
				return path.nonLinearDrawWps;
			}
			Debugger.LogWarning("Draw points not ready yet. Returning NULL");
			return null;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x163C920", Offset = "0x163C920", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF5A88]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A88F]) = v50;\nL_0019:\n\tv51 = this.wps;\n\tv61 = this.isClosedPath == 0;\n\tv68 = ~v61;\n\tv69 = ~v68;\n\tif (v69) goto L_FFFFFFFF;\n\tv131 = 1 + 1;\n\tgoto L_0032;\nL_0032:\n\tv73 = v131 + v51._size;\n\t// 52 NewArr v168 @ X0_v10 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v73 @ X21_v4 (System.Int32)\n\tv125 = UnityEngine.Component::get_transform(this);\n\tv88 = UnityEngine.Transform::get_position(v125);\n\tv228 = v168.Length == 0;\n\tif (v228) goto L_00B2;\n\t*([v168 @ X0_v10 (UnityEngine.Vector3[])+20]) = v88;\n\t*([v168 @ X0_v10 (UnityEngine.Vector3[])+24]) = v88.y;\n\t*([v168 @ X0_v10 (UnityEngine.Vector3[])+28]) = v88.z;\n\tv310 = v51._size < 1;\n\tif (v310) goto L_0088;\n\tv78 = v168 + 0x2C;\nL_0056:\n\tv71 = this.wps;\n\tv339 = v80 < v71._size;\n\tv340 = ~v339;\n\tv187 = ~v340;\n\tif (v187) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv80 = v80 + 1;\n\tv350 = v80 < v168.Length;\n\tv218 = ~v350;\n\tif (v218) goto L_00B2;\n\tv313 = v78 + v82;\n\tv355 = v71._items + v82;\n\tv82 = v82 + 0xC;\n\t*([v313 @ X10_v8]) = *([v355 @ X8_v22+20]);\n\t*([v313 @ X10_v8+8]) = *([v355 @ X8_v22+28]);\n\tv315 = v80 < v51._size;\n\tif (v315) goto L_0056;\nL_0088:\n\tv329 = ~this.isClosedPath;\n\tif (v329) goto L_00AF;\n\tv229 = v168.Length == 0;\n\tif (v229) goto L_00B2;\n\tv234 = v73 - 1;\n\tv348 = v234 < v168.Length;\n\tv220 = ~v348;\n\tif (v220) goto L_00B2;\n\tv335 = v168 + 0x20;\n\tv336 = v234 * 0xC;\n\tv337 = v335 + v336;\n\t*([v337 @ X8_v17]) = *([v168 @ X0_v10 (UnityEngine.Vector3[])+20]);\n\t*([v337 @ X8_v17+8]) = *([v168 @ X0_v10 (UnityEngine.Vector3[])+28]);\nL_00AF:\n\treturn v168;\n\tv166 = new System.NullReferenceException();\nL_00B2:\n\tv236 = new System.IndexOutOfRangeException();\n\tthrow v236;\n\treturn returnVal1;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Vector3[] GetFullWps()
		{
			//IL_00d7: Expected O, but got I
			//IL_0254: Expected O, but got I
			//IL_0270: Expected O, but got I
			//IL_0280: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_01a6: Expected O, but got I
			List<Vector3> list = wps;
			int num = ((!isClosedPath) ? 1 : (1 + 1));
			int num2 = num + list.Count;
			Vector3[] array = new Vector3[num2];
			Transform transform = base.transform;
			Vector3 position = transform.position;
			if (array.Length != 0)
			{
				_ = position.y;
				_ = position.z;
				if (list.Count < 1)
				{
					goto IL_01d4;
				}
				object obj = (long)(IntPtr)array + 44L;
				int num3 = 0;
				int num4 = 0;
				while (true)
				{
					List<Vector3> list2 = wps;
					if (num3 >= list2.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					num3++;
					if (num3 >= array.Length)
					{
						break;
					}
					object obj2 = (long)(IntPtr)obj + (long)num4;
					object obj3 = (long)(IntPtr)list2._items + (long)num4;
					num4 += 12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ X8_v22+20]");
					obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ X8_v22+28]");
					_ = 0;
					if (num3 < list.Count)
					{
						continue;
					}
					goto IL_01d4;
				}
			}
			goto IL_0292;
			IL_01d4:
			if (isClosedPath)
			{
				if (array.Length != 0)
				{
					int num5 = num2 - 1;
					if (num5 < array.Length)
					{
						object obj4 = (long)(IntPtr)array + 32L;
						int num6 = num5 * 12;
						object obj5 = (long)(IntPtr)obj4 + (long)num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X0_v10 (UnityEngine.Vector3[])+20]");
						obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X0_v10 (UnityEngine.Vector3[])+28]");
						_ = 0;
						goto IL_02ec;
					}
				}
				goto IL_0292;
			}
			goto IL_02ec;
			IL_0292:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_02ec:
			return array;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x163C220", Offset = "0x163C220", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0022;\n\tv44 = *([1F0BCA8]);\n\tv45 = *([v44 @ X8_v33]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([202A890]) = v64;\nL_0022:\n\tv67 = UnityEngine.Component::get_transform(this);\n\tv70 = UnityEngine.Transform::get_position(v67);\n\tgoto L_0043;\n\tv210 = *([v203 @ X0_v6+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_0043;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v203, v69, v48, v49, v50, v51, v52, v53, v70, v197, v198, v57, v58, v59, v60, v61);\nL_0043:\n\t// 67 MakeStruct v157 @ AGG163C2E0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.lastSrcPosition (UnityEngine.Vector3), this.lastSrcPosition.y (System.Single), this.lastSrcPosition.z (System.Single)\n\tv224 = UnityEngine.Vector3::op_Equality(v70, v157);\n\tv328 = v224 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_014F;\n\tgoto L_0061;\n\tv389 = *([v330 @ X0_v11+E0]);\n\tv390 = v389 == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_0061;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v330, v69, v48, v49, v50, v51, v52, v53, v217, v218, v219, v220, v221, v222, v60, v61);\nL_0061:\n\t// 97 MakeStruct v142 @ AGG163C330_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.lastSrcPosition (UnityEngine.Vector3), this.lastSrcPosition.y (System.Single), this.lastSrcPosition.z (System.Single)\n\tv403 = UnityEngine.Vector3::op_Subtraction(v70, v142);\n\t*([v34 @ X29_v1-38]) = v403.y;\n\t*([v34 @ X29_v1-34]) = v403;\n\tv656 = this.path;\n\tv408 = v656.wps;\nL_007A:\n\tv433 = v506 >= v408.Length;\n\tif (v433) goto L_00B9;\n\tv503 = v656.wps;\n\tv615 = v506 < v503.Length;\n\tv616 = ~v615;\n\tif (v616) goto L_0150;\n\tv444 = v503 + v511;\n\tgoto L_0098;\n\tv643 = *([v626 @ X0_v28+E0]);\n\tv644 = v643 == 0;\n\tv645 = ~v644;\n\tif (v645) goto L_0098;\n\tv647 = \"il2cpp_codegen_runtime_class_init\"(v626, v69, v48, v49, v50, v51, v52, v53, v571, v566, v561, v535, v530, v525, v60, v61);\nL_0098:\n\t;\n\t// 159 MakeStruct v441 @ AGG163C3B0_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v444 @ X24_v8+20], [v444 @ X24_v8+24], [v444 @ X24_v8+28]\n\t// 160 MakeStruct v438 @ AGG163C3B0_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-34], [v34 @ X29_v1-38], v403.z (System.Single)\n\tv572 = UnityEngine.Vector3::op_Addition(v441, v438);\n\tv654 = v506 < v503.Length;\n\tv497 = ~v654;\n\tif (v497) goto L_0150;\n\t*([v444 @ X24_v8+20]) = v572;\n\t*([v444 @ X24_v8+24]) = v572.y;\n\t*([v444 @ X24_v8+28]) = v572.z;\n\tv656 = this.path;\n\tv506 = v506 + 1;\n\tv511 = v511 + 0xC;\n\tv657 = this.path == 0;\n\tv582 = ~v657;\n\tif (v582) goto L_007A;\n\tgoto L_0136;\nL_00B9:\n\tv519 = v656.controlPoints;\n\tv434 = v519.Length < 1;\n\tif (v434) goto L_0138;\nL_00D1:\n\tv592 = v656.controlPoints;\n\tv658 = v513 < v592.Length;\n\tv500 = ~v658;\n\tif (v500) goto L_0150;\n\tv660 = v592 + v508;\n\tgoto L_00F8;\n\tv667 = *([v659 @ X0_v23+E0]);\n\tv668 = v667 == 0;\n\tv669 = ~v668;\n\tif (v669) goto L_00F8;\n\tv671 = \"il2cpp_codegen_runtime_class_init\"(v659, v69, v48, v49, v50, v51, v52, v53, v664, v568, v563, v537, v532, v527, v60, v61);\nL_00F8:\n\t// 248 MakeStruct v420 @ AGG163C464_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v660 @ X8_v16], [v660 @ X8_v16+4], [v660 @ X8_v16+8]\n\t// 249 MakeStruct v417 @ AGG163C464_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-34], [v34 @ X29_v1-38], v403.z (System.Single)\n\tv681 = UnityEngine.Vector3::op_Addition(v420, v417);\n\t// 263 MakeStruct v414 @ AGG163C490_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v660 @ X8_v16+C], [v660 @ X8_v16+10], [v660 @ X8_v16+14]\n\t// 264 MakeStruct v411 @ AGG163C490_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-34], [v34 @ X29_v1-38], v403.z (System.Single)\n\tv570 = UnityEngine.Vector3::op_Addition(v414, v411);\n\tv593 = this.path;\n\tv594 = v593.controlPoints;\n\tv687 = v513 < v594.Length;\n\tv637 = ~v687;\n\tif (v637) goto L_0150;\n\tv513 = v513 + 1;\n\tv600 = v594 + v508;\n\t*([v600 @ X8_v20]) = v681;\n\t*([v600 @ X8_v20+4]) = v681.y;\n\t*([v600 @ X8_v20+8]) = v681.z;\n\t*([v600 @ X8_v20+C]) = v570;\n\t*([v600 @ X8_v20+10]) = v570.y;\n\t*([v600 @ X8_v20+14]) = v570.z;\n\tv432 = v513 >= v519.Length;\n\tif (v432) goto L_0138;\n\tv656 = this.path;\n\tv508 = v508 + 0x18;\n\tv689 = this.path == 0;\n\tv580 = ~v689;\n\tif (v580) goto L_00D1;\nL_0136:\n\tthrow System.NullReferenceException;\nL_0138:\n\tthis.lastSrcPosition.x = v70;\n\tthis.lastSrcPosition.y = v70.y;\n\tthis.lastSrcPosition.z = v70.z;\nL_014F:\n\treturn;\nL_0150:\n\tv642 = new System.IndexOutOfRangeException();\n\tthrow v642;\n\tthrow System.NullReferenceException;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReEvaluateRelativeTween()
		{
			//IL_0177: Expected O, but got I
			//IL_0196: Expected F4, but got I
			//IL_01ab: Expected F4, but got I
			//IL_01c0: Expected F4, but got I
			//IL_01d5: Expected F4, but got I
			//IL_01ea: Expected F4, but got I
			//IL_0325: Expected O, but got I
			//IL_033d: Expected F4, but got O
			//IL_0352: Expected F4, but got I
			//IL_0367: Expected F4, but got I
			//IL_037c: Expected F4, but got I
			//IL_0391: Expected F4, but got I
			//IL_03c9: Expected F4, but got I
			//IL_03de: Expected F4, but got I
			//IL_03f3: Expected F4, but got I
			//IL_0408: Expected F4, but got I
			//IL_041d: Expected F4, but got I
			//IL_04ac: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 vector = default(Vector3);
			vector.x = lastSrcPosition.x;
			vector.y = lastSrcPosition.y;
			vector.z = lastSrcPosition.z;
			if (position == vector)
			{
				return;
			}
			Vector3 vector2 = default(Vector3);
			vector2.x = lastSrcPosition.x;
			vector2.y = lastSrcPosition.y;
			vector2.z = lastSrcPosition.z;
			Vector3 vector3 = position - vector2;
			_ = vector3.y;
			Path path = this.path;
			Vector3[] array = path.wps;
			int num = 0;
			int num2 = 0;
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			Vector3 vector7 = default(Vector3);
			Vector3 vector8 = default(Vector3);
			Vector3 vector10 = default(Vector3);
			Vector3 vector11 = default(Vector3);
			while (true)
			{
				if (num < array.Length)
				{
					Vector3[] array2 = path.wps;
					if (num >= array2.Length)
					{
						break;
					}
					object obj3 = (long)(IntPtr)array2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ X24_v8+20]");
					vector4.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ X24_v8+24]");
					vector4.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ X24_v8+28]");
					vector4.z = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
					vector5.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
					vector5.y = 0f;
					vector5.z = vector3.z;
					Vector3 vector6 = vector4 + vector5;
					if (num >= array2.Length)
					{
						break;
					}
					_ = vector6.y;
					_ = vector6.z;
					path = this.path;
					num++;
					num2 += 12;
					if (this.path != null)
					{
						continue;
					}
					goto IL_0544;
				}
				ControlPoint[] controlPoints = path.controlPoints;
				if (controlPoints.Length >= 1)
				{
					int num3 = 32;
					int num4 = 0;
					while (true)
					{
						ControlPoint[] controlPoints2 = path.controlPoints;
						if (num4 >= controlPoints2.Length)
						{
							break;
						}
						object obj4 = (long)(IntPtr)controlPoints2 + (long)num3;
						vector7.x = (float)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X8_v16+4]");
						vector7.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X8_v16+8]");
						vector7.z = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						vector8.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
						vector8.y = 0f;
						vector8.z = vector3.z;
						Vector3 vector9 = vector7 + vector8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X8_v16+C]");
						vector10.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X8_v16+10]");
						vector10.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v660 @ X8_v16+14]");
						vector10.z = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						vector11.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
						vector11.y = 0f;
						vector11.z = vector3.z;
						Vector3 vector12 = vector10 + vector11;
						Path path2 = this.path;
						ControlPoint[] controlPoints3 = path2.controlPoints;
						if (num4 >= controlPoints3.Length)
						{
							break;
						}
						num4++;
						object obj5 = (long)(IntPtr)controlPoints3 + (long)num3;
						obj5 = vector9;
						_ = vector9.y;
						_ = vector9.z;
						_ = vector12.y;
						_ = vector12.z;
						if (num4 < controlPoints.Length)
						{
							path = this.path;
							num3 += 24;
							if (this.path != null)
							{
								continue;
							}
							goto IL_0544;
						}
						goto IL_054a;
					}
					break;
				}
				goto IL_054a;
				IL_054a:
				lastSrcPosition.x = position.x;
				lastSrcPosition.y = position.y;
				lastSrcPosition.z = position.z;
				return;
				IL_0544:
				throw new NullReferenceException();
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x163CAA0", Offset = "0x163CAA0", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0018;\n\tv24 = *([1EADCA0]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A891]) = v44;\nL_0018:\n\tthis.duration = 1f;\n\t// 29 NewArr v51 @ X0_v3 (UnityEngine.Keyframe[]), typeof(UnityEngine.Keyframe[]), 2\n\tv53 = &v15 @ stack_-10_v2 - 0x50;\n\t*([v14 @ X29_v1-38]) = 0;\n\t*([v14 @ X29_v1-48]) = 0;\n\t*([v14 @ X29_v1-40]) = 0;\n\t*([v14 @ X29_v1-50]) = 0;\n\tv57 = 0x100AEC0(v53, 0, v28, v29, v30, v31, v32, v33, 0, 0, v36, v37, v38, v39, v40, v41);\n\tv64 = v51.Length == 0;\n\tif (v64) goto L_00B3;\n\t*([v51 @ X0_v3 (UnityEngine.Keyframe[])+2C]) = *([v14 @ X29_v1-44]);\n\t*([v51 @ X0_v3 (UnityEngine.Keyframe[])+20]) = *([v14 @ X29_v1-50]);\n\tv131 = 0;\n\tv139 = 0x100AEC0(&v131 @ stack_-A0_v3, 0, v28, v29, v30, v31, v32, v33, 1f, 1f, v36, v37, v38, v39, v40, v41);\n\tv158 = v51.Length < 1;\n\tv148 = ~v158;\n\tv147 = v51.Length - 1;\n\tv145 = v147 == 0;\n\tv159 = ~v148;\n\tv140 = v159 | v145;\n\tif (v140) goto L_00B3;\n\t*([v51 @ X0_v3 (UnityEngine.Keyframe[])+48]) = v157;\n\t*([v51 @ X0_v3 (UnityEngine.Keyframe[])+3C]) = 0;\n\tv226 = new UnityEngine.AnimationCurve();\n\tUnityEngine.AnimationCurve::.ctor(v226, v51);\n\tthis.easeCurve = v226;\n\tthis.loops = 1;\n\tthis.lookAhead = 0.01f;\n\tthis.autoPlay = 0x101;\n\tthis.pathResolution = 0xA;\n\tthis.pathMode = 1;\n\tthis.id = \"\";\n\tgoto L_0077;\n\tv243 = *([v239 @ X0_v16+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0077;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v239, v227, v185, v29, v30, v31, v32, v33, v223, v152, v36, v37, v38, v39, v40, v41);\nL_0077:\n\tv250 = UnityEngine.Vector3::get_forward();\n\tthis.forwardDirection = v250;\n\tthis.forwardDirection.y = v250.y;\n\tthis.forwardDirection.z = v250.z;\n\tv254 = UnityEngine.Vector3::get_up();\n\tthis.upDirection = v254;\n\tthis.upDirection.y = v254.y;\n\tthis.upDirection.z = v254.z;\n\tv260 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v260);\n\tthis.wps = v260;\n\tv266 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v266);\n\tthis.fullWps = v266;\n\tthis.livePreview = 1;\n\tthis.showIndexes = 1;\n\tthis.perspectiveHandleSize = 0.5f;\n\tv169 = 0;\n\tv272 = 0x101059C(&v169 @ stack_-D0_v1 (System.Single), 0, 0, v29, v30, v31, v32, v33, 1f, 1f, 1f, 0.5f, v38, v39, v40, v41);\n\tthis.pathColor.r = 0f;\n\tthis.pathColor.g = v273;\n\tthis.pathColor.a = v274;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_00B3:\n\tv156 = new System.IndexOutOfRangeException();\n\tthrow v156;\n\tthrow System.NullReferenceException;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenPath()
		{
			//IL_028f: Expected O, but got I
			//IL_0055: Expected O, but got I4
			//IL_0090: Expected O, but got I4
			//IL_0244: Expected F4, but got O
			base._002Ector();
			object obj2 = default(object);
			object obj = obj2;
			duration = 1f;
			Keyframe[] array = new Keyframe[2];
			object obj3 = (long)(IntPtr)obj2 - 80L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100AEC0 (inside UnityEngine.AnimationCurve::Linear +0x14C)");
			if (array.Length != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-44]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-50]");
				_ = 0;
				object obj4 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100AEC0 (inside UnityEngine.AnimationCurve::Linear +0x14C)");
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj5 = array.Length - 1;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					_ = 0;
					AnimationCurve animationCurve = new AnimationCurve(array);
					easeCurve = animationCurve;
					loops = 1;
					lookAhead = 0.01f;
					autoPlay = true;
					autoKill = true;
					pathResolution = 10;
					pathMode = PathMode.Full3D;
					id = "";
					Vector3 vector = (forwardDirection = Vector3.forward);
					forwardDirection.y = vector.y;
					forwardDirection.z = vector.z;
					Vector3 vector2 = (upDirection = Vector3.up);
					upDirection.y = vector2.y;
					upDirection.z = vector2.z;
					List<Vector3> list = new List<Vector3>();
					wps = list;
					List<Vector3> list2 = new List<Vector3>();
					fullWps = list2;
					livePreview = true;
					showIndexes = true;
					perspectiveHandleSize = 0.5f;
					float num = 0f;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
					pathColor.r = 0f;
					object obj6 = default(object);
					pathColor.g = (float)obj6;
					float a = default(float);
					pathColor.a = a;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
