using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Serializable]
	[Token(Token = "0x2000046")]
	public class Path
	{
		[Token(Token = "0x4000118")]
		private static CatmullRomDecoder _catmullRomDecoder;

		[Token(Token = "0x4000119")]
		private static LinearDecoder _linearDecoder;

		[Token(Token = "0x400011A")]
		private static CubicBezierDecoder _cubicBezierDecoder;

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x10")]
		public float[] wpLengths;

		[SerializeField]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x18")]
		public PathType type;

		[SerializeField]
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x1C")]
		internal int subdivisionsXSegment;

		[SerializeField]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x20")]
		internal int subdivisions;

		[SerializeField]
		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x28")]
		public Vector3[] wps;

		[SerializeField]
		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x30")]
		public ControlPoint[] controlPoints;

		[SerializeField]
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x38")]
		internal float length;

		[SerializeField]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x3C")]
		internal bool isFinalized;

		[SerializeField]
		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x40")]
		internal float[] timesTable;

		[SerializeField]
		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x48")]
		internal float[] lengthsTable;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x50")]
		internal int linearWPIndex;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x54")]
		internal bool addedExtraStartWp;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x55")]
		internal bool addedExtraEndWp;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x58")]
		private Path _incrementalClone;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x60")]
		private int _incrementalIndex;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x68")]
		private ABSPathDecoder _decoder;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x70")]
		private bool _changed;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x78")]
		public Vector3[] nonLinearDrawWps;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x80")]
		internal Vector3 targetPosition;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x8C")]
		internal Vector3? lookAtPosition;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x9C")]
		public Color gizmoColor;

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x1082320", Offset = "0x1082320", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1F07430]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2026A52]) = v50;\nL_001C:\n\tthis.linearWPIndex = 0xFFFFFFFF;\n\tv56 = 0;\n\tv61 = 0x101059C(&v56 @ stack_-50_v1 (System.Single), 0, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v38, v39, 1f, 1f, 1f, 0.7f, v44, v45, v46, v47);\n\tthis.gizmoColor.r = 0f;\n\tthis.gizmoColor.g = v64;\n\tthis.gizmoColor.a = v66;\n\tSystem.Object::.ctor(this);\n\tthis.type = type;\n\tthis.subdivisionsXSegment = subdivisionsXSegment;\n\tv70 = gizmoColor.value == 0;\n\tif (v70) goto L_0041;\n\tv75 = 0x115CEA0(gizmoColor, Il2CppMethodInfo, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v38, v39, 1f, 1f, 1f, 0.7f, v44, v45, v46, v47);\n\tthis.gizmoColor = 1f;\n\tthis.gizmoColor.g = 1f;\n\tthis.gizmoColor.b = 1f;\n\tthis.gizmoColor.a = 0.7f;\nL_0041:\n\tDG.Tweening.Plugins.Core.PathCore.Path::AssignWaypoints(this, waypoints, 1);\n\tDG.Tweening.Plugins.Core.PathCore.Path::AssignDecoder(this, type);\n\tgoto L_0054;\n\tv90 = *([v86 @ X0_v8 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tgoto L_0054;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v86, v83, v79, subdivisionsXSegment, gizmoColor, methodInfo, v38, v39, v54, v57, v58, v53, v44, v45, v46, v47);\n\tv94 = DG.Tweening.Core.TweenManager;\nL_0054:\n\tv99 = ~v97.isUnityEditor;\n\tif (v99) goto L_0081;\n\tgoto L_0068;\n\tv133 = *([v103 @ X0_v11 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0068;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v103, v83, v79, subdivisionsXSegment, gizmoColor, methodInfo, v38, v39, v54, v57, v58, v53, v44, v45, v46, v47);\n\tv137 = DG.Tweening.DOTween;\nL_0068:\n\tv143 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v143, this, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::Add(v141.GizmosDelegates, v143);\nL_0081:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Path(PathType type, Vector3[] waypoints, int subdivisionsXSegment, Color? gizmoColor = null)
		{
			//IL_00b5: Expected F4, but got O
			//IL_0025: Expected O, but got F4
			base._002Ector();
			linearWPIndex = -1;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			this.gizmoColor.r = 0f;
			object obj = default(object);
			this.gizmoColor.g = (float)obj;
			float a = default(float);
			this.gizmoColor.a = a;
			this.type = type;
			this.subdivisionsXSegment = subdivisionsXSegment;
			if (gizmoColor.value.r != 0f)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115CEA0 (inside System.Nullable`1<System.Single>::Unbox +0xC4)");
				this.gizmoColor = (Color)1f;
				this.gizmoColor.g = 1f;
				this.gizmoColor.b = 1f;
				this.gizmoColor.a = 0.7f;
			}
			AssignWaypoints(waypoints, cloneWps: true);
			AssignDecoder(type);
			if (TweenManager.isUnityEditor)
			{
				TweenCallback item = Draw;
				DOTween.GizmosDelegates.Add(item);
			}
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x10826E8", Offset = "0x10826E8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.linearWPIndex = 0xFFFFFFFF;\n\tv16 = 0;\n\tv20 = 0x101059C(&v16 @ stack_-30_v1 (System.Single), 0, v21, v22, v23, v24, v25, v26, 1f, 1f, 1f, 0.7f, v27, v28, v29, v30);\n\tthis.gizmoColor.r = 0f;\n\tthis.gizmoColor.g = v33;\n\tthis.gizmoColor.a = v35;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Path()
		{
			//IL_0048: Expected F4, but got O
			base._002Ector();
			linearWPIndex = -1;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			gizmoColor.r = 0f;
			object obj = default(object);
			gizmoColor.g = (float)obj;
			float a = default(float);
			gizmoColor.a = a;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x108275C", Offset = "0x108275C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv42 = lockPositionAxes == 0;\n\tif (v42) goto L_0087;\n\tv131 = this.wps;\nL_0029:\n\tv48 = v128 >= v131.Length;\n\tif (v48) goto L_0087;\n\tv301 = v128 < v131.Length;\n\tv302 = ~v301;\n\tif (v302) goto L_009A;\n\tv311 = v128 * 0xC;\n\tv312 = v131 + v311;\n\tv166 = v312 + 0x20;\n\tv164 = *([v166 @ X25_v8]);\n\tv314 = lockPositionAxes & 2;\n\tv316 = v314 == 0;\n\tv158 = v166 + 4;\n\tv195 = *([v158 @ X27_v8]);\n\tv156 = v166 + 8;\n\tv193 = *([v156 @ X26_v8]);\n\tv324 = ~v316;\n\tif (v324) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\tv332 = lockPositionAxes & 4;\n\tv334 = v332 == 0;\n\tv337 = ~v334;\n\tif (v337) goto L_FFFFFFFF;\n\tgoto L_0058;\nL_0058:\n\tv328 = lockPositionAxes & 8;\n\tv341 = v328 == 0;\n\tv154 = ~v341;\n\tif (v154) goto L_FFFFFFFF;\n\tgoto L_0065;\nL_0065:\n\tv162 = 0x1586898(&v51 @ stack_-80 (System.Int32), 0, lockPositionAxes, methodInfo, v229, v204, v205, v206, v164, v195, v193, v207, v208, v209, v210, v211);\n\tv346 = v128 < v131.Length;\n\tv184 = ~v346;\n\tif (v184) goto L_009A;\n\tv128 = v128 + 1;\n\t*([v166 @ X25_v8]) = 0;\n\t*([v158 @ X27_v8]) = v347;\n\t*([v156 @ X26_v8]) = 0;\n\tv131 = this.wps;\n\tv348 = this.wps == 0;\n\tv191 = ~v348;\n\tif (v191) goto L_0029;\n\tthrow System.NullReferenceException;\nL_0087:\n\tv203 = DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder::FinalizePath(this._decoder, this, this.wps, isClosedPath);\n\tthis.isFinalized = 1;\n\treturn;\nL_009A:\n\tv329 = new System.IndexOutOfRangeException();\n\tthrow v329;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void FinalizePath(bool isClosedPath, AxisConstraint lockPositionAxes, Vector3 currTargetVal)
		{
			//IL_007f: Expected O, but got I
			//IL_008e: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_00ca: Expected F4, but got O
			//IL_00d9: Expected O, but got I
			//IL_00e1: Expected F4, but got O
			//IL_0151: Expected O, but got I4
			//IL_0162: Expected O, but got I4
			if (lockPositionAxes != AxisConstraint.None)
			{
				Vector3[] array = wps;
				int num = 0;
				object obj5 = default(object);
				while (num < array.Length)
				{
					if (num < array.Length)
					{
						int num2 = num * 12;
						object obj = (long)(IntPtr)array + (long)num2;
						object obj2 = (long)(IntPtr)obj + 32L;
						Vector3 vector = (Vector3)obj2;
						int num3 = (int)(lockPositionAxes & AxisConstraint.X);
						bool flag = num3 == 0;
						object obj3 = (long)(IntPtr)obj2 + 4L;
						float num4 = (float)obj3;
						object obj4 = (long)(IntPtr)obj2 + 8L;
						float num5 = (float)obj4;
						if (!flag)
						{
							vector = currTargetVal;
						}
						if ((lockPositionAxes & AxisConstraint.Y) != AxisConstraint.None)
						{
							num4 = currTargetVal.y;
						}
						if ((lockPositionAxes & AxisConstraint.Z) != AxisConstraint.None)
						{
							num5 = currTargetVal.z;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						if (num < array.Length)
						{
							num++;
							obj2 = 0;
							obj3 = obj5;
							obj4 = 0;
							array = wps;
							bool flag2 = wps == null;
							bool flag3 = !flag2;
							int num6 = 0;
							if (!flag3)
							{
								throw new NullReferenceException();
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			_decoder.FinalizePath(this, wps, isClosedPath);
			isFinalized = true;
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x10828A0", Offset = "0x10828A0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = convertToConstantPerc == 0;\n\tif (v12) goto L_000B;\n\treturnVal1 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(this, returnVal1);\nL_000B:\n\tv18 = this._decoder;\n\tv20 = *([v18 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder)]);\n\tv21 = this.wps;\n\tv22 = this.controlPoints;\n\tv26 = *([v20 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+180]);\n\tv27 = *([v20 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+188]);\n\t// 24 IndirectJump v26 @ X5_v1, v18 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v18 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v21 @ X1_v1 (UnityEngine.Vector3[]), this @ X0 (DG.Tweening.Plugins.Core.PathCore.Path), v22 @ X3_v1 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v27 @ X4_v1, v26 @ X5_v1, v29 @ X6, v30 @ X7, returnVal1 @ V0_v1 (System.Single), v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Vector3 GetPoint(float perc, bool convertToConstantPerc = false)
		{
			//IL_0047: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			//IL_0087: Expected O, but got I4
			if (convertToConstantPerc)
			{
				float num = ConvertToConstantPathPerc(num);
			}
			ABSPathDecoder decoder = _decoder;
			IntPtr intPtr = (IntPtr)decoder;
			Vector3[] array = wps;
			ControlPoint[] array2 = controlPoints;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+180]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+188]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v26 @ X5_v1 (should have been resolved before IL gen)");
			return (Vector3)0;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0x10828E4", Offset = "0x10828E4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.type == 0;\n\tif (v8) goto L_FFFFFFFF;\n\tv21 = v64 <= 0;\n\tif (v21) goto L_008A;\n\tv33 = v64 >= 1f;\n\tif (v33) goto L_008A;\n\tv143 = this.lengthsTable;\n\tv215 = this.length * v64;\n\tv217 = v143.Length < 1;\n\tif (v217) goto L_FFFFFFFF;\n\tv237 = v143.Length & 0xFFFFFFFF;\nL_0036:\n\tv299 = v235 < v237;\n\tv256 = ~v299;\n\tif (v256) goto L_00B2;\n\tv233 = this.timesTable;\n\tv372 = v235 < v233.Length;\n\tv340 = ~v372;\n\tif (v340) goto L_00B2;\n\tv392 = v143[v235 @ X10_v8 (System.Int32)] > v215;\n\tif (v392) goto L_00A1;\n\tv235 = v235 + 1;\n\tv281 = v235 < v237;\n\tif (v281) goto L_0036;\n\tgoto L_FFFFFFFF;\n\tgoto L_0096;\nL_0078:\n\tv378 = v215 - v35;\n\tv44 = v375 - v35;\n\tv379 = v378 / v44;\n\tv41 = v374 - v70;\n\tv380 = v41 * v379;\n\tv64 = v70 + v380;\nL_008A:\n\tv106 = v64 > 1f;\n\tif (v106) goto L_0096;\n\treturnVal2 = UnityEngine.Mathf::Max(v64, 0f);\n\treturn returnVal2;\nL_0096:\n\treturn v119;\nL_00A1:\n\tv325 = v235 < 1;\n\tif (v325) goto L_FFFFFFFF;\n\tv324 = v235 - 1;\n\tv397 = v324 < v143.Length;\n\tv341 = ~v397;\n\tif (v341) goto L_00B2;\n\tv376 = v235 << 2;\n\tv377 = v143 + v376;\n\tv35 = *([v377 @ X8_v6+1C]);\n\tgoto L_0078;\nL_00B2:\n\tv342 = new System.IndexOutOfRangeException();\n\tthrow v342;\n\tthrow System.NullReferenceException;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal float ConvertToConstantPathPerc(float perc)
		{
			//IL_00b6: Expected I4, but got I8
			//IL_0258: Expected O, but got I
			float num = default(float);
			float[] array;
			float num2;
			int num4;
			float num5;
			float[] array2;
			float num6;
			if (type != PathType.Linear)
			{
				if (!(num > 0f) || !(num < 1f))
				{
					goto IL_029d;
				}
				array = lengthsTable;
				num2 = length * num;
				if (array.Length >= 1)
				{
					int num3 = (int)(array.Length & 0xFFFFFFFFL);
					num4 = 0;
					num5 = 0f;
					while (num4 < num3)
					{
						array2 = timesTable;
						if (num4 >= array2.Length)
						{
							break;
						}
						if (!(array[num4] > num2))
						{
							num4++;
							bool flag = num4 < num3;
							num5 = array2[num4];
							if (flag)
							{
								continue;
							}
							goto IL_0167;
						}
						goto IL_01c6;
					}
					goto IL_028f;
				}
				num6 = 0f;
				num5 = 0f;
				goto IL_02ec;
			}
			float result = num;
			goto IL_01c1;
			IL_01c6:
			bool flag2 = num4 < 1;
			float num7 = array2[num4];
			num6 = array[num4];
			if (flag2)
			{
				goto IL_02fa;
			}
			int num8 = num4 - 1;
			if (num8 >= array.Length)
			{
				goto IL_028f;
			}
			int num9 = num4 << 2;
			object obj = (long)(IntPtr)array + (long)num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ X8_v6+1C]");
			int num10 = 0;
			num7 = array2[num4];
			num6 = array[num4];
			goto IL_0308;
			IL_01c1:
			return result;
			IL_02ec:
			num7 = 0f;
			goto IL_02fa;
			IL_028f:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_029d:
			bool flag3 = num > 1f;
			result = 1f;
			if (!flag3)
			{
				return Mathf.Max(num, 0f);
			}
			goto IL_01c1;
			IL_02fa:
			num10 = 0;
			goto IL_0308;
			IL_0167:
			num6 = 0f;
			num5 = array2[num4];
			goto IL_02ec;
			IL_0308:
			float num11 = num2 - (float)num10;
			float num12 = num6 - (float)num10;
			float num13 = num11 / num12;
			float num14 = num7 - num5;
			float num15 = num14 * num13;
			num = num5 + num15;
			goto IL_029d;
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0x1082A14", Offset = "0x1082A14", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = perc >= 1f;\n\tif (v17) goto L_0064;\n\tv18 = perc < 0;\n\tv19 = ~v18;\n\tv22 = perc == 0;\n\tv27 = ~v19;\n\tv28 = v27 | v22;\n\tif (v28) goto L_FFFFFFFF;\n\tv32 = this.wpLengths;\n\tv46 = v32.Length - 1;\n\tv59 = v32.Length < 1;\n\tif (v59) goto L_FFFFFFFF;\n\tv49 = v32.Length & 0xFFFFFFFF;\n\tv38 = this.length * perc;\nL_0034:\n\tv221 = v102 < v49;\n\tv124 = ~v221;\n\tif (v124) goto L_0077;\n\tv172 = v46 == v102;\n\tif (v172) goto L_006E;\n\tv126 = v126 + v32[v102 @ X9_v5 (System.Int32)];\n\tv179 = v126 - v38;\n\tv176 = v179 < 0;\n\tv173 = v179 == 0;\n\tv170 = v126 ^ v38;\n\tv167 = v126 ^ v179;\n\tv164 = v170 & v167;\n\tv161 = v164 < 0;\n\tv225 = v126 >= v38;\n\tif (v225) goto L_0070;\n\tv102 = v102 + 1;\n\tv58 = v102 < v49;\n\tif (v58) goto L_0034;\n\tgoto L_006C;\nL_0064:\n\tv29 = this.wps;\n\treturnVal1 = v29.Length - 1;\nL_006C:\n\treturn returnVal1;\nL_006E:\n\treturnVal1 = v46 - isMovingForward;\n\tgoto L_006C;\nL_0070:\n\tv228 = v176 == v161;\n\tv143 = ~v173;\n\tv158 = v228 & v143;\n\tv153 = v158 & isMovingForward;\n\treturnVal1 = v102 - v153;\n\tgoto L_006C;\nL_0077:\n\tv223 = new System.IndexOutOfRangeException();\n\tthrow v223;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal int GetWaypointIndexFromPerc(float perc, bool isMovingForward)
		{
			//IL_00c7: Expected I4, but got I8
			//IL_0161: Expected O, but got F4
			//IL_016e: Expected O, but got F4
			if (perc < 1f)
			{
				bool flag = perc < 0f;
				bool flag2 = !flag;
				bool flag3 = perc == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					float[] array = wpLengths;
					int num = array.Length - 1;
					if (array.Length >= 1)
					{
						int num2 = (int)(array.Length & 0xFFFFFFFFL);
						float num3 = length * perc;
						int num4 = 0;
						float num5 = 0f;
						do
						{
							if (num4 < num2)
							{
								if (num != num4)
								{
									num5 += array[num4];
									float num6 = num5 - num3;
									bool flag5 = num6 < 0f;
									bool flag6 = num6 == 0f;
									object obj = num5 ^ num3;
									object obj2 = num5 ^ num6;
									int num7 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
									bool flag7 = num7 < 0;
									if (num5 < num3)
									{
										num4++;
										continue;
									}
									bool flag8 = flag5 == flag7;
									bool flag9 = !flag6;
									bool flag10 = flag8 && flag9;
									bool flag11 = flag10 && isMovingForward;
									return num4 - (flag11 ? 1 : 0);
								}
								return num - (isMovingForward ? 1 : 0);
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						while (num4 < num2);
					}
				}
				return 0;
			}
			Vector3[] array2 = wps;
			return array2.Length - 1;
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0x1082AE0", Offset = "0x1082AE0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EF42F8]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, drawSubdivisionsXSegment, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026A53]) = v47;\nL_001A:\n\tv180 = p.wps;\n\tv108 = p.type == 0;\n\tif (v108) goto L_0061;\n\tv100 = v180.Length * drawSubdivisionsXSegment;\n\tv144 = v100 + 1;\n\t// 38 NewArr v145 @ X0_v11 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v144 @ X1_v5 (System.Int32)\n\tv193 = v100 & 0x80000000;\n\tv194 = v193 == 0;\n\tv176 = ~v194;\n\tif (v176) goto L_0061;\nL_0030:\n\tv229 = v89 / v100;\n\tv52 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(p, v229, 0);\n\tv230 = v89 < v145.Length;\n\tv126 = ~v230;\n\tif (v126) goto L_0064;\n\tv170 = v89 + 1;\n\tv175 = v89 * 0xC;\n\tv179 = v145 + v175;\n\t*([v179 @ X8_v11+20]) = v52;\n\tv145[v89 @ X22_v6 (System.Int32)].y = v52.y;\n\tv145[v89 @ X22_v6 (System.Int32)].z = v52.z;\n\tv148 = v170 <= v100;\n\tif (v148) goto L_0030;\nL_0061:\n\treturn v180;\n\tv106 = new System.NullReferenceException();\nL_0064:\n\tv140 = new System.IndexOutOfRangeException();\n\tthrow v140;\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3[] GetDrawPoints(Path p, int drawSubdivisionsXSegment)
		{
			//IL_0075: Expected I4, but got I8
			//IL_0106: Expected O, but got I
			Vector3[] array = p.wps;
			if (p.type != PathType.Linear)
			{
				int num = array.Length * drawSubdivisionsXSegment;
				int num2 = num + 1;
				Vector3[] array2 = new Vector3[num2];
				int num3 = (int)(num & 0x80000000L);
				bool flag = num3 == 0;
				bool flag2 = !flag;
				array = array2;
				if (!flag2)
				{
					int num4 = 0;
					bool flag3;
					do
					{
						float perc = (float)num4 / (float)num;
						Vector3 point = p.GetPoint(perc);
						if (num4 < array2.Length)
						{
							int num5 = num4 + 1;
							int num6 = num4 * 12;
							object obj = (long)(IntPtr)array2 + (long)num6;
							array2[num4].y = point.y;
							array2[num4].z = point.z;
							flag3 = num5 <= num;
							array = array2;
							num4 = num5;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (flag3);
				}
			}
			return array;
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0x1082BDC", Offset = "0x1082BDC", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F00940]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A54]) = v44;\nL_0018:\n\tv46 = p.wps;\n\tv106 = p.nonLinearDrawWps;\n\tv91 = v46.Length << 2;\n\tv107 = v46.Length + v91;\n\tv108 = v107 << 1;\n\tv109 = p.nonLinearDrawWps == 0;\n\tif (v109) goto L_0033;\n\tv169 = v108 | 1;\n\tv153 = v169 != v106.Length;\n\tif (v153) goto L_0037;\n\tv158 = v108 & 0x80000000;\n\tv159 = v158 == 0;\n\tif (v159) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0033:\n\tv169 = v108 | 1;\nL_0037:\n\t// 55 NewArr v174 @ X0_v9 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v169 @ X1_v4 (System.Int32)\n\tp.nonLinearDrawWps = v174;\n\tv191 = v108 & 0x80000000;\n\tv192 = v191 == 0;\n\tv187 = ~v192;\n\tif (v187) goto L_0070;\nL_0042:\n\tv267 = v57 / v108;\n\tv49 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(p, v267, 0);\n\tv100 = p.nonLinearDrawWps;\n\tv268 = v57 < v100.Length;\n\tv131 = ~v268;\n\tif (v131) goto L_0073;\n\tv256 = v100 + v102;\n\tv245 = v57 + 1;\n\tv102 = v102 + 0xC;\n\t*([v256 @ X8_v14+20]) = v49;\n\t*([v256 @ X8_v14+24]) = v49.y;\n\t*([v256 @ X8_v14+28]) = v49.z;\n\tv246 = v57 < v108;\n\tif (v246) goto L_0042;\nL_0070:\n\treturn;\n\tv104 = new System.NullReferenceException();\nL_0073:\n\tv141 = new System.IndexOutOfRangeException();\n\tthrow v141;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RefreshNonLinearDrawWps(Path p)
		{
			//IL_0043: Expected O, but got I4
			//IL_01cc: Expected I4, but got I8
			//IL_00b5: Expected I4, but got I8
			//IL_0138: Expected O, but got I
			Vector3[] array = p.wps;
			Vector3[] array2 = p.nonLinearDrawWps;
			int num = array.Length << 2;
			object obj = array.Length + num;
			int num2 = (int)((long)(IntPtr)obj << 1);
			int num3;
			if (p.nonLinearDrawWps != null)
			{
				num3 = num2 | 1;
				if (num3 == array2.Length)
				{
					if ((int)(num2 & 0x80000000L) != 0)
					{
						return;
					}
					goto IL_00ea;
				}
			}
			else
			{
				num3 = num2 | 1;
			}
			Vector3[] array3 = new Vector3[num3];
			p.nonLinearDrawWps = array3;
			if ((int)(num2 & 0x80000000L) != 0)
			{
				return;
			}
			goto IL_00ea;
			IL_00ea:
			int num4 = 0;
			int num5 = 0;
			while (true)
			{
				float perc = (float)num4 / (float)num2;
				Vector3 point = p.GetPoint(perc);
				Vector3[] array4 = p.nonLinearDrawWps;
				if (num4 >= array4.Length)
				{
					break;
				}
				object obj2 = (long)(IntPtr)array4 + (long)num5;
				int num6 = num4 + 1;
				num5 += 12;
				_ = point.y;
				_ = point.z;
				bool flag = num4 < num2;
				num4 = num6;
				if (!flag)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x1082CEC", Offset = "0x1082CEC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0CE90]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026A55]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.Core.TweenManager;\nL_0023:\n\tv56 = ~v54.isUnityEditor;\n\tif (v56) goto L_0047;\n\tgoto L_0037;\n\tv88 = *([v60 @ X0_v5 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_0037;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv92 = DG.Tweening.DOTween;\nL_0037:\n\tv98 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v98, this, Il2CppMethodInfo);\n\tv76 = System.Collections.Generic.List`1<DG.Tweening.TweenCallback>::Remove(v96.GizmosDelegates, v98);\nL_0047:\n\tthis.wps = 0;\n\tthis.wpLengths = 0;\n\tthis.nonLinearDrawWps = 0;\n\tthis.isFinalized = 0;\n\tthis.timesTable = 0;\n\tthis.lengthsTable = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Destroy()
		{
			if (TweenManager.isUnityEditor)
			{
				TweenCallback item = Draw;
				bool flag = DOTween.GizmosDelegates.Remove(item);
			}
			wps = null;
			wpLengths = null;
			nonLinearDrawWps = null;
			isFinalized = false;
			timesTable = null;
			lengthsTable = null;
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x1082DF4", Offset = "0x1082DF4", Length = "0x588")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv50 = *([1EEDBC8]);\n\tv51 = *([v50 @ X8_v77]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, loopIncrement, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 0 | 1;\n\t*([2026A56]) = v69;\nL_0023:\n\treturnVal1 = this._incrementalClone;\n\tv71 = this._incrementalClone == 0;\n\tif (v71) goto L_0032;\n\tv77 = this._incrementalIndex == loopIncrement;\n\tif (v77) goto L_023D;\n\tDG.Tweening.Plugins.Core.PathCore.Path::Destroy(this._incrementalClone);\nL_0032:\n\tv99 = this.wps;\n\tv269 = v99.Length == 0;\n\tif (v269) goto L_0240;\n\tv727 = v99 + 0x20;\n\tv212 = v99.Length << 0x20;\n\tv730 = 0xFFFFFFFF00000000 + v212;\n\tv732 = v730 >> 0x20;\n\tv733 = v732 * 0xC;\n\tv734 = v727 + v733;\n\tgoto L_0059;\n\tv776 = *([v731 @ X0_v10+E0]);\n\tv777 = v776 == 0;\n\tv778 = ~v777;\n\tif (v778) goto L_0059;\n\tv780 = \"il2cpp_codegen_runtime_class_init\"(v731, loopIncrement, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_0059:\n\t// 89 MakeStruct v184 @ AGG1082ED8_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v734 @ X9_v7], [v734 @ X9_v7+4], [v734 @ X9_v7+8]\n\t// 90 MakeStruct v181 @ AGG1082ED8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v99 @ X8_v5 (UnityEngine.Vector3[])+20], [v99 @ X8_v5 (UnityEngine.Vector3[])+24], [v99 @ X8_v5 (UnityEngine.Vector3[])+28]\n\tv409 = UnityEngine.Vector3::op_Subtraction(v184, v181);\n\tv573 = this.wps;\n\t// 104 NewArr v788 @ X0_v14 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v573.Length\n\tv799 = v99.Length < 1;\n\tif (v799) goto L_00CA;\nL_007A:\n\tv574 = this.wps;\n\tv823 = v342 < v574.Length;\n\tv529 = ~v823;\n\tif (v529) goto L_0240;\n\tv836 = v574 + v347;\n\tgoto L_009C;\n\tv878 = *([v835 @ X0_v51+E0]);\n\tv879 = v878 == 0;\n\tv880 = ~v879;\n\tif (v880) goto L_009C;\n\tv882 = \"il2cpp_codegen_runtime_class_init\"(v835, v357, methodInfo, v54, v55, v56, v57, v58, v410, v401, v392, v383, v376, v369, v65, v66);\nL_009C:\n\tv409 = UnityEngine.Vector3::op_Multiply(v409, loopIncrement);\n\t// 166 MakeStruct v331 @ AGG1082F8C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v836 @ X8_v68+20], [v836 @ X8_v68+24], [v836 @ X8_v68+28]\n\tv409 = UnityEngine.Vector3::op_Addition(v331, v409);\n\tv939 = v342 < v788.Length;\n\tv768 = ~v939;\n\tif (v768) goto L_0240;\n\tv342 = v342 + 1;\n\tv815 = v788 + v347;\n\tv347 = v347 + 0xC;\n\t*([v815 @ X8_v71+20]) = v409;\n\t*([v815 @ X8_v71+24]) = v409.y;\n\t*([v815 @ X8_v71+28]) = v409.z;\n\tv804 = v342 < v99.Length;\n\tif (v804) goto L_007A;\nL_00CA:\n\tv576 = this.controlPoints;\n\t// 210 NewArr v822 @ X0_v17 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v576.Length\n\tv834 = v576.Length < 1;\n\tif (v834) goto L_013C;\nL_00E4:\n\tv577 = this.controlPoints;\n\tv901 = v469 < v577.Length;\n\tv532 = ~v901;\n\tif (v532) goto L_0240;\n\tv931 = v577 + v324;\n\tv409 = *([v931 @ X8_v57]);\n\tgoto L_0107;\n\tv940 = *([v932 @ X0_v44+E0]);\n\tv941 = v940 == 0;\n\tv942 = ~v941;\n\tif (v942) goto L_0107;\n\tv944 = \"il2cpp_codegen_runtime_class_init\"(v932, v358, methodInfo, v54, v55, v56, v57, v58, v933, v404, v395, v386, v378, v371, v65, v66);\nL_0107:\n\tv409 = UnityEngine.Vector3::op_Multiply(v409, loopIncrement);\n\tv541 = DG.Tweening.Plugins.Core.PathCore.ControlPoint::op_Addition(&v409 @ V0_v5 (UnityEngine.Vector3), v409);\n\tv965 = v469 < v822.Length;\n\tv769 = ~v965;\n\tif (v769) goto L_0240;\n\tv853 = v822 + v324;\n\tv469 = v469 + 1;\n\t*([v853 @ X9_v31+10]) = *([v541 @ X0_v48 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]);\n\tv324 = v324 + 0x18;\n\t*([v853 @ X9_v31]) = v541.a;\n\tv845 = v469 < v576.Length;\n\tif (v845) goto L_00E4;\nL_013C:\n\tv876 = this.nonLinearDrawWps;\n\tv877 = this.nonLinearDrawWps == 0;\n\tif (v877) goto L_FFFFFFFF;\n\t// 322 NewArr v894 @ X0_v36 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v876.Length\n\tv912 = v876.Length < 1;\n\tif (v912) goto L_01A9;\nL_0154:\n\tv579 = this.nonLinearDrawWps;\n\tv958 = v325 < v579.Length;\n\tv534 = ~v958;\n\tif (v534) goto L_0240;\n\tv961 = v579 + v364;\n\tgoto L_0176;\n\tv966 = *([v960 @ X0_v38+E0]);\n\tv967 = v966 == 0;\n\tv968 = ~v967;\n\tif (v968) goto L_0176;\n\tv970 = \"il2cpp_codegen_runtime_class_init\"(v960, v359, methodInfo, v54, v55, v56, v57, v58, v415, v406, v397, v388, v379, v372, v65, v66);\nL_0176:\n\tv409 = UnityEngine.Vector3::op_Multiply(v409, loopIncrement);\n\t// 384 MakeStruct v279 @ AGG1083150_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v961 @ X8_v50+20], [v961 @ X8_v50+24], [v961 @ X8_v50+28]\n\tv409 = UnityEngine.Vector3::op_Addition(v279, v409);\n\tv991 = v325 < v894.Length;\n\tv770 = ~v991;\n\tif (v770) goto L_0240;\n\tv325 = v325 + 1;\n\tv928 = v894 + v364;\n\tv364 = v364 + 0xC;\n\t*([v928 @ X8_v53+20]) = v409;\n\t*([v928 @ X8_v53+24]) = v409.y;\n\t*([v928 @ X8_v53+28]) = v409.z;\n\tv914 = v325 < v876.Length;\n\tif (v914) goto L_0154;\n\tgoto L_01A9;\nL_01A9:\n\tv544 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tDG.Tweening.Plugins.Core.PathCore.Path::.ctor(v544);\n\tthis._incrementalClone = v544;\n\tthis._incrementalIndex = loopIncrement;\n\tv544.type = this.type;\n\tv582 = this._incrementalClone;\n\tv582.subdivisionsXSegment = this.subdivisionsXSegment;\n\tv583 = this._incrementalClone;\n\tv583.subdivisions = this.subdivisions;\n\tv584 = this._incrementalClone;\n\tv584.wps = v788;\n\tv585 = this._incrementalClone;\n\tv585.controlPoints = v822;\n\tgoto L_01D3;\n\tv992 = *([v987 @ X0_v22 (Il2CppClass<DG.Tweening.Core.TweenManager>)+E0]);\n\tv993 = v992 == 0;\n\tv994 = ~v993;\n\tif (v994) goto L_01D3;\n\tv1004 = \"il2cpp_codegen_runtime_class_init\"(v987, v360, methodInfo, v54, v55, v56, v57, v58, v197, v195, v193, v191, v189, v187, v65, v66);\n\tv996 = DG.Tweening.Core.TweenManager;\nL_01D3:\n\tv1001 = ~v999.isUnityEditor;\n\tif (v1001) goto L_01F8;\n\tgoto L_01E8;\n\tv1017 = *([v1007 @ X0_v26 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv1018 = v1017 == 0;\n\tv1019 = ~v1018;\n\tif (v1019) goto L_01E8;\n\tv1027 = \"il2cpp_codegen_runtime_class_init\"(v1007, v360, methodInfo, v54, v55, v56, v57, v58, v197, v195, v193, v191, v189, v187, v65, v66);\n\tv1021 = DG.Tweening.DOTween;\nL_01E8:\n\tv545 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v545, this._incrementalClone, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::Add(v1025.GizmosDelegates, v545);\nL_01F8:\n\tv587 = this._incrementalClone;\n\tv587.length = this.length;\n\tv588 = this._incrementalClone;\n\tv588.wpLengths = this.wpLengths;\n\tv589 = this._incrementalClone;\n\tv589.timesTable = this.timesTable;\n\tv590 = this._incrementalClone;\n\tv590.lengthsTable = this.lengthsTable;\n\tv591 = this._incrementalClone;\n\tv591._decoder = this._decoder;\n\tv592 = this._incrementalClone;\n\tv592.nonLinearDrawWps = v172;\n\tv593 = this._incrementalClone;\n\tv593.targetPosition = this.targetPosition;\n\tv593.targetPosition.z = this.targetPosition.z;\n\tv594 = this._incrementalClone;\n\tv594.lookAtPosition = this.lookAtPosition;\n\t*([v594 @ X8_v37 (DG.Tweening.Plugins.Core.PathCore.Path)+94]) = *([this @ X0 (DG.Tweening.Plugins.Core.PathCore.Path)+94]);\n\tv246 = this._incrementalClone;\n\tv246.isFinalized = 1;\n\treturnVal1 = this._incrementalClone;\nL_023D:\n\treturn returnVal1;\n\tv599 = new System.NullReferenceException();\nL_0240:\n\tv775 = new System.IndexOutOfRangeException();\n\tthrow v775;\n\treturn returnVal2;\n// 404 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Path CloneIncremental(int loopIncrement)
		{
			//IL_0070: Expected O, but got I
			//IL_0092: Expected O, but got I8
			//IL_00bd: Expected O, but got I
			//IL_00cf: Expected F4, but got O
			//IL_00e4: Expected F4, but got I
			//IL_00f9: Expected F4, but got I
			//IL_010e: Expected F4, but got I
			//IL_0123: Expected F4, but got I
			//IL_0138: Expected F4, but got I
			//IL_01da: Expected O, but got I
			//IL_0209: Expected F4, but got I
			//IL_021e: Expected F4, but got I
			//IL_0233: Expected F4, but got I
			//IL_036a: Expected O, but got I
			//IL_0398: Expected O, but got Ref
			//IL_04f0: Expected O, but got I
			//IL_0296: Expected O, but got I
			//IL_051f: Expected F4, but got I
			//IL_0534: Expected F4, but got I
			//IL_0549: Expected F4, but got I
			//IL_03df: Expected O, but got I
			//IL_05a5: Expected O, but got I
			Path incrementalClone = _incrementalClone;
			if (_incrementalClone != null)
			{
				if (_incrementalIndex == loopIncrement)
				{
					goto IL_081a;
				}
				_incrementalClone.Destroy();
			}
			Vector3[] array = wps;
			Vector3 vector3;
			Vector3[] array3;
			if (array.Length != 0)
			{
				object obj = (long)(IntPtr)array + 32L;
				int num = array.Length << 32;
				object obj2 = -4294967296L + num;
				int num2 = (int)((long)(IntPtr)obj2 >> 32);
				int num3 = num2 * 12;
				object obj3 = (long)(IntPtr)obj + (long)num3;
				Vector3 vector = default(Vector3);
				vector.x = (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X9_v7+4]");
				vector.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ X9_v7+8]");
				vector.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v5 (UnityEngine.Vector3[])+20]");
				Vector3 vector2 = default(Vector3);
				vector2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v5 (UnityEngine.Vector3[])+24]");
				vector2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v5 (UnityEngine.Vector3[])+28]");
				vector2.z = 0f;
				vector3 = vector - vector2;
				Vector3[] array2 = wps;
				array3 = new Vector3[array2.Length];
				if (array.Length < 1)
				{
					goto IL_02de;
				}
				int num4 = 0;
				int num5 = 0;
				Vector3 vector4 = default(Vector3);
				while (true)
				{
					Vector3[] array4 = wps;
					if (num4 >= array4.Length)
					{
						break;
					}
					object obj4 = (long)(IntPtr)array4 + (long)num5;
					vector3 *= (float)loopIncrement;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v68+20]");
					vector4.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v68+24]");
					vector4.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v68+28]");
					vector4.z = 0f;
					vector3 = vector4 + vector3;
					if (num4 >= array3.Length)
					{
						break;
					}
					num4++;
					object obj5 = (long)(IntPtr)array3 + (long)num5;
					num5 += 12;
					_ = vector3.y;
					_ = vector3.z;
					if (num4 < array.Length)
					{
						continue;
					}
					goto IL_02de;
				}
			}
			goto IL_07e3;
			IL_081a:
			return incrementalClone;
			IL_02de:
			ControlPoint[] array5 = controlPoints;
			ControlPoint[] array6 = new ControlPoint[array5.Length];
			if (array5.Length < 1)
			{
				goto IL_0441;
			}
			int num6 = 32;
			int num7 = 0;
			while (true)
			{
				ControlPoint[] array7 = controlPoints;
				if (num7 >= array7.Length)
				{
					break;
				}
				object obj6 = (long)(IntPtr)array7 + (long)num6;
				vector3 = (Vector3)obj6;
				vector3 *= (float)loopIncrement;
				ControlPoint controlPoint = (ControlPoint)(&vector3) + vector3;
				if (num7 >= array6.Length)
				{
					break;
				}
				object obj7 = (long)(IntPtr)array6 + (long)num6;
				num7++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ X0_v48 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]");
				_ = 0;
				num6 += 24;
				obj7 = controlPoint.a;
				bool flag = num7 < array5.Length;
				vector3 = controlPoint.a;
				if (flag)
				{
					continue;
				}
				goto IL_0441;
			}
			goto IL_07e3;
			IL_05ea:
			Vector3[] array9;
			Vector3[] array8 = array9;
			goto IL_083d;
			IL_083d:
			Path path = (_incrementalClone = new Path());
			_incrementalIndex = loopIncrement;
			path.type = type;
			Path incrementalClone2 = _incrementalClone;
			incrementalClone2.subdivisionsXSegment = subdivisionsXSegment;
			Path incrementalClone3 = _incrementalClone;
			incrementalClone3.subdivisions = subdivisions;
			Path incrementalClone4 = _incrementalClone;
			incrementalClone4.wps = array3;
			Path incrementalClone5 = _incrementalClone;
			incrementalClone5.controlPoints = array6;
			if (TweenManager.isUnityEditor)
			{
				TweenCallback item = _incrementalClone.Draw;
				DOTween.GizmosDelegates.Add(item);
			}
			Path incrementalClone6 = _incrementalClone;
			incrementalClone6.length = length;
			Path incrementalClone7 = _incrementalClone;
			incrementalClone7.wpLengths = wpLengths;
			Path incrementalClone8 = _incrementalClone;
			incrementalClone8.timesTable = timesTable;
			Path incrementalClone9 = _incrementalClone;
			incrementalClone9.lengthsTable = lengthsTable;
			Path incrementalClone10 = _incrementalClone;
			incrementalClone10._decoder = _decoder;
			Path incrementalClone11 = _incrementalClone;
			incrementalClone11.nonLinearDrawWps = array8;
			Path incrementalClone12 = _incrementalClone;
			incrementalClone12.targetPosition = targetPosition;
			incrementalClone12.targetPosition.z = targetPosition.z;
			Path incrementalClone13 = _incrementalClone;
			incrementalClone13.lookAtPosition = lookAtPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Plugins.Core.PathCore.Path)+94]");
			_ = 0;
			Path incrementalClone14 = _incrementalClone;
			incrementalClone14.isFinalized = true;
			incrementalClone = _incrementalClone;
			goto IL_081a;
			IL_0441:
			Vector3[] array10 = nonLinearDrawWps;
			if (nonLinearDrawWps != null)
			{
				array9 = new Vector3[array10.Length];
				bool flag2 = array10.Length < 1;
				array8 = array9;
				if (!flag2)
				{
					int num8 = 0;
					int num9 = 0;
					Vector3 vector5 = default(Vector3);
					while (true)
					{
						Vector3[] array11 = nonLinearDrawWps;
						if (num8 >= array11.Length)
						{
							break;
						}
						object obj8 = (long)(IntPtr)array11 + (long)num9;
						vector3 *= (float)loopIncrement;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X8_v50+20]");
						vector5.x = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X8_v50+24]");
						vector5.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ X8_v50+28]");
						vector5.z = 0f;
						vector3 = vector5 + vector3;
						if (num8 >= array9.Length)
						{
							break;
						}
						num8++;
						object obj9 = (long)(IntPtr)array9 + (long)num9;
						num9 += 12;
						_ = vector3.y;
						_ = vector3.z;
						if (num8 < array10.Length)
						{
							continue;
						}
						goto IL_05ea;
					}
					goto IL_07e3;
				}
			}
			else
			{
				array8 = null;
			}
			goto IL_083d;
			IL_07e3:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x10824C8", Offset = "0x10824C8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ECDDC0]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, newWps, cloneWps, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026A57]) = v44;\nL_0018:\n\tv46 = cloneWps == 0;\n\tif (v46) goto L_0068;\n\t// 33 NewArr v153 @ X0_v12 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), newWps.Length\n\tthis.wps = v153;\n\tv125 = newWps.Length < 1;\n\tif (v125) goto L_0070;\n\tv229 = newWps.Length == 0;\n\tif (v229) goto L_0064;\nL_0038:\n\tv256 = v177 < v153.Length;\n\tv250 = ~v256;\n\tif (v250) goto L_0064;\n\tv257 = newWps + v158;\n\tv177 = v177 + 1;\n\tv113 = v153 + v158;\n\t*([v113 @ X12_v6+20]) = *([v257 @ X11_v7+20]);\n\t*([v113 @ X12_v6+24]) = *([v257 @ X11_v7+24]);\n\t*([v113 @ X12_v6+28]) = *([v257 @ X11_v7+28]);\n\tv126 = v177 >= newWps.Length;\n\tif (v126) goto L_0070;\n\tv153 = this.wps;\n\tv158 = v158 + 0xC;\n\tv259 = v177 < newWps.Length;\n\tv249 = ~v259;\n\tv234 = ~v249;\n\tif (v234) goto L_0038;\nL_0064:\n\tv254 = new System.IndexOutOfRangeException();\n\tthrow v254;\nL_0068:\n\tthis.wps = newWps;\nL_0070:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AssignWaypoints(Vector3[] newWps, bool cloneWps = false)
		{
			//IL_00aa: Expected O, but got I
			//IL_00c6: Expected O, but got I
			if (cloneWps)
			{
				Vector3[] array = (wps = new Vector3[newWps.Length]);
				if (newWps.Length < 1)
				{
					return;
				}
				if (newWps.Length != 0)
				{
					int num = 0;
					int num2 = 0;
					while (num < array.Length)
					{
						object obj = (long)(IntPtr)newWps + (long)num2;
						num++;
						object obj2 = (long)(IntPtr)array + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X11_v7+20]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X11_v7+24]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X11_v7+28]");
						_ = 0;
						if (num < newWps.Length)
						{
							array = wps;
							num2 += 12;
							if (num >= newWps.Length)
							{
								break;
							}
							continue;
						}
						return;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			wps = newWps;
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x10825BC", Offset = "0x10825BC", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC7020]);\n\tv23 = *([v22 @ X8_v29]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pathType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026A58]) = v41;\nL_0015:\n\tthis.type = pathType;\n\tv44 = pathType == 0;\n\tif (v44) goto L_003B;\n\tv56 = pathType != 2;\n\tif (v56) goto L_004C;\n\tv63 = v55._cubicBezierDecoder == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_005C;\n\tv100 = new DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder();\n\tSystem.Object::.ctor(v100);\n\tv74._cubicBezierDecoder = v100;\n\tgoto L_005C;\nL_003B:\n\tv60 = v58._linearDecoder == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_005C;\n\tv71 = new DG.Tweening.Plugins.Core.PathCore.LinearDecoder();\n\tSystem.Object::.ctor(v71);\n\tv75._linearDecoder = v71;\n\tgoto L_005C;\nL_004C:\n\tv66 = v55._catmullRomDecoder == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_005C;\n\tv99 = new DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder();\n\tSystem.Object::.ctor(v99);\n\tv126._catmullRomDecoder = v99;\nL_005C:\n\tthis._decoder = v106;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AssignDecoder(PathType pathType)
		{
			type = pathType;
			ABSPathDecoder decoder;
			switch (pathType)
			{
			case PathType.CubicBezier:
			{
				bool flag3 = _cubicBezierDecoder == null;
				bool flag4 = !flag3;
				decoder = _cubicBezierDecoder;
				if (!flag4)
				{
					CubicBezierDecoder cubicBezierDecoder = new CubicBezierDecoder();
					_cubicBezierDecoder = cubicBezierDecoder;
					decoder = _cubicBezierDecoder;
				}
				break;
			}
			case PathType.Linear:
			{
				bool flag5 = _linearDecoder == null;
				bool flag6 = !flag5;
				decoder = _linearDecoder;
				if (!flag6)
				{
					LinearDecoder linearDecoder = new LinearDecoder();
					_linearDecoder = linearDecoder;
					decoder = _linearDecoder;
				}
				break;
			}
			default:
			{
				bool flag = _catmullRomDecoder == null;
				bool flag2 = !flag;
				decoder = _catmullRomDecoder;
				if (!flag2)
				{
					CatmullRomDecoder catmullRomDecoder = new CatmullRomDecoder();
					_catmullRomDecoder = catmullRomDecoder;
					decoder = _catmullRomDecoder;
				}
				break;
			}
			}
			_decoder = decoder;
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x108337C", Offset = "0x108337C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Plugins.Core.PathCore.Path::Draw(this);\n\treturn;\n")]
		public void Draw()
		{
			Draw(this);
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x1083380", Offset = "0x1083380", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1F00A30]);\n\tv39 = *([v38 @ X8_v34]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2026A59]) = v58;\nL_0020:\n\tv61 = p.timesTable == 0;\n\tif (v61) goto L_014F;\n\t// 43 MakeStruct v168 @ AGG10833F4_0_v4 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), p.gizmoColor.b (System.Single), p.gizmoColor.a (System.Single)\n\tUnityEngine.Gizmos::set_color(v168);\n\tv216 = p.wps;\n\tv193 = p.gizmoColor.a * 0.5f;\n\tv494 = ~p._changed;\n\tif (v494) goto L_0041;\n\tp._changed = 0;\n\tv495 = p.type == 0;\n\tif (v495) goto L_008A;\nL_003B:\n\tDG.Tweening.Plugins.Core.PathCore.Path::RefreshNonLinearDrawWps(p);\n\tv506 = p.type == 0;\n\tv503 = ~v506;\n\tif (v503) goto L_0046;\n\tgoto L_008A;\nL_0041:\n\tv496 = p.type == 0;\n\tif (v496) goto L_008A;\n\tv498 = p.nonLinearDrawWps == 0;\n\tif (v498) goto L_0150;\nL_0046:\n\tv411 = p.nonLinearDrawWps;\n\tv406 = v411.Length == 0;\n\tif (v406) goto L_0154;\n\tv543 = v411.Length <= 1;\n\tif (v543) goto L_00D3;\n\tv387 = *([v411 @ X8_v26 (UnityEngine.Vector3[])+20]);\n\tv344 = *([v411 @ X8_v26 (UnityEngine.Vector3[])+24]);\n\tv341 = *([v411 @ X8_v26 (UnityEngine.Vector3[])+28]);\nL_0060:\n\tv627 = v334 < v411.Length;\n\tv378 = ~v627;\n\tif (v378) goto L_0154;\n\tv612 = v411 + v338;\n\t// 114 MakeStruct v82 @ AGG1083494_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v612 @ X8_v27+2C], [v612 @ X8_v27+30], [v612 @ X8_v27+34]\n\t// 115 MakeStruct v78 @ AGG1083494_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v387 @ V3_v18 (UnityEngine.Vector3), v344 @ V4_v11 (UnityEngine.Vector3), v341 @ V5_v11 (UnityEngine.Vector3)\n\tUnityEngine.Gizmos::DrawLine(v82, v78);\n\tv334 = v334 + 1;\n\tv118 = v334 >= v411.Length;\n\tif (v118) goto L_00D3;\n\tv411 = p.nonLinearDrawWps;\n\tv338 = v338 + 0xC;\n\tv647 = p.nonLinearDrawWps == 0;\n\tv211 = ~v647;\n\tif (v211) goto L_0060;\n\tgoto L_0153;\nL_008A:\n\tv412 = p.wps;\n\tv408 = v412.Length == 0;\n\tif (v408) goto L_0154;\n\tv520 = v216.Length <= 0;\n\tif (v520) goto L_0110;\n\tv388 = *([v412 @ X8_v21 (UnityEngine.Vector3[])+20]);\n\tv345 = *([v412 @ X8_v21 (UnityEngine.Vector3[])+24]);\n\tv342 = *([v412 @ X8_v21 (UnityEngine.Vector3[])+28]);\nL_00A4:\n\tv553 = v336 < v412.Length;\n\tv379 = ~v553;\n\tif (v379) goto L_0154;\n\tv613 = v412 + v339;\n\t// 182 MakeStruct v74 @ AGG1083514_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v613 @ X8_v22+20], [v613 @ X8_v22+24], [v613 @ X8_v22+28]\n\t// 183 MakeStruct v70 @ AGG1083514_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v388 @ V3_v15 (UnityEngine.Vector3), v345 @ V4_v8 (UnityEngine.Vector3), v342 @ V5_v8 (UnityEngine.Vector3)\n\tUnityEngine.Gizmos::DrawLine(v74, v70);\n\tv336 = v336 + 1;\n\tv119 = v336 >= v216.Length;\n\tif (v119) goto L_00D3;\n\tv412 = p.wps;\n\tv339 = v339 + 0xC;\n\tv643 = p.wps == 0;\n\tv213 = ~v643;\n\tif (v213) goto L_00A4;\n\tgoto L_0153;\nL_00D3:\n\t// 211 MakeStruct v67 @ AGG1083554_0_v5 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), p.gizmoColor.b (System.Single), v193 @ V11_v6 (System.Single)\n\tUnityEngine.Gizmos::set_color(v67);\n\tv559 = v216.Length < 1;\n\tif (v559) goto L_0113;\nL_00E6:\n\tv221 = p.wps;\n\tv648 = v103 < v221.Length;\n\tv380 = ~v648;\n\tif (v380) goto L_0154;\n\tv592 = v221 + v107;\n\tv286 = *([v592 @ X8_v18+20]);\n\tv284 = *([v592 @ X8_v18+24]);\n\tv282 = *([v592 @ X8_v18+28]);\n\t// 250 MakeStruct v554 @ AGG108359C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v592 @ X8_v18+20], [v592 @ X8_v18+24], [v592 @ X8_v18+28]\n\tUnityEngine.Gizmos::DrawSphere(v554, 0.075f);\n\tv103 = v103 + 1;\n\tv107 = v107 + 0xC;\n\tv560 = v103 < v216.Length;\n\tif (v560) goto L_00E6;\n\tgoto L_0113;\nL_0110:\n\t// 272 MakeStruct v531 @ AGG10835C8_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), p.gizmoColor.b (System.Single), v193 @ V11_v6 (System.Single)\n\tUnityEngine.Gizmos::set_color(v531);\nL_0113:\n\tv295 = *([p @ X0 (DG.Tweening.Plugins.Core.PathCore.Path)+98]) == 0;\n\tif (v295) goto L_014F;\n\tv616 = p + 0x8C;\n\tv617 = System.Nullable`1<UnityEngine.Vector3>::get_Value(v616);\n\t// 293 MakeStruct v426 @ AGG1083610_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), p.targetPosition (UnityEngine.Vector3), p.targetPosition.y (System.Single), p.targetPosition.z (System.Single)\n\t// 294 MakeStruct v423 @ AGG1083610_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v286 @ V0_v6 (UnityEngine.Color), v284 @ V1_v5 (System.Single), v282 @ V2_v5 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v426, v423);\n\t// 317 MakeStruct v418 @ AGG108364C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v286 @ V0_v6 (UnityEngine.Color), v284 @ V1_v5 (System.Single), v282 @ V2_v5 (System.Single)\n\tUnityEngine.Gizmos::DrawWireSphere(v418, 0.075f);\n\treturn;\nL_014F:\n\treturn;\nL_0150:\n\tp._changed = 0;\n\tgoto L_003B;\nL_0153:\n\tv226 = new System.NullReferenceException();\nL_0154:\n\tv414 = new System.IndexOutOfRangeException();\n\tthrow v414;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void Draw(Path p)
		{
			//IL_03be: Expected O, but got I
			//IL_03ce: Expected O, but got I
			//IL_03de: Expected O, but got I
			//IL_07ab: Expected O, but got I
			//IL_0403: Expected O, but got I
			//IL_0418: Expected F4, but got I
			//IL_042d: Expected F4, but got I
			//IL_0442: Expected F4, but got I
			//IL_01e8: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_04fe: Expected O, but got I
			//IL_050e: Expected O, but got I
			//IL_051e: Expected O, but got I
			//IL_022d: Expected O, but got I
			//IL_0242: Expected F4, but got I
			//IL_0257: Expected F4, but got I
			//IL_026c: Expected F4, but got I
			//IL_062a: Expected O, but got I
			//IL_063a: Expected O, but got I
			//IL_064a: Expected F4, but got I
			//IL_065a: Expected F4, but got I
			//IL_066f: Expected F4, but got I
			//IL_0684: Expected F4, but got I
			//IL_0699: Expected F4, but got I
			//IL_0328: Expected O, but got I
			//IL_0338: Expected O, but got I
			//IL_0348: Expected O, but got I
			if (p.timesTable == null)
			{
				return;
			}
			Color color = default(Color);
			color.r = p.gizmoColor.r;
			color.g = p.gizmoColor.g;
			color.b = p.gizmoColor.b;
			color.a = p.gizmoColor.a;
			Gizmos.color = color;
			Vector3[] array = p.wps;
			float a = p.gizmoColor.a * 0.5f;
			if (p._changed)
			{
				p._changed = false;
				if (p.type != PathType.Linear)
				{
					goto IL_0106;
				}
			}
			else if (p.type != PathType.Linear)
			{
				if (p.nonLinearDrawWps != null)
				{
					goto IL_0185;
				}
				p._changed = false;
				goto IL_0106;
			}
			goto IL_035b;
			IL_035b:
			Vector3[] array2 = p.wps;
			float z;
			float y;
			Color color3;
			if (array2.Length != 0)
			{
				if (array.Length <= 0)
				{
					Color color2 = default(Color);
					color2.r = p.gizmoColor.r;
					color2.g = p.gizmoColor.g;
					color2.b = p.gizmoColor.b;
					color2.a = a;
					Gizmos.color = color2;
					z = p.gizmoColor.b;
					y = p.gizmoColor.g;
					color3 = p.gizmoColor;
					goto IL_0777;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v21 (UnityEngine.Vector3[])+20]");
				Vector3 vector = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v21 (UnityEngine.Vector3[])+24]");
				Vector3 vector2 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ X8_v21 (UnityEngine.Vector3[])+28]");
				Vector3 vector3 = (Vector3)0;
				int num = 0;
				int num2 = 0;
				Vector3 vector4 = default(Vector3);
				Vector3 to = default(Vector3);
				while (num < array2.Length)
				{
					object obj = (long)(IntPtr)array2 + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+20]");
					vector4.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+24]");
					vector4.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+28]");
					vector4.z = 0f;
					to.x = vector.x;
					to.y = vector2.x;
					to.z = vector3.x;
					Gizmos.DrawLine(vector4, to);
					num++;
					if (num >= array.Length)
					{
						goto IL_0531;
					}
					array2 = p.wps;
					num2 += 12;
					bool flag = p.wps == null;
					bool flag2 = !flag;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+28]");
					vector3 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+24]");
					vector2 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v613 @ X8_v22+20]");
					vector = (Vector3)0;
					if (flag2)
					{
						continue;
					}
					goto IL_088a;
				}
			}
			goto IL_0898;
			IL_088a:
			NullReferenceException ex = new NullReferenceException();
			goto IL_0898;
			IL_0898:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_0777:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [p @ X0 (DG.Tweening.Plugins.Core.PathCore.Path)+98]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Vector3? vector5 = (Vector3?)(object)((long)(IntPtr)p + 140L);
				Vector3 value = ((Vector3?*)vector5)->Value;
				Vector3 vector6 = default(Vector3);
				vector6.x = p.targetPosition.x;
				vector6.y = p.targetPosition.y;
				vector6.z = p.targetPosition.z;
				Vector3 to2 = default(Vector3);
				to2.x = color3.r;
				to2.y = y;
				to2.z = z;
				Gizmos.DrawLine(vector6, to2);
				Vector3 center = default(Vector3);
				center.x = color3.r;
				center.y = y;
				center.z = z;
				Gizmos.DrawWireSphere(center, 0.075f);
			}
			return;
			IL_0531:
			Color color4 = default(Color);
			color4.r = p.gizmoColor.r;
			color4.g = p.gizmoColor.g;
			color4.b = p.gizmoColor.b;
			color4.a = a;
			Gizmos.color = color4;
			bool flag3 = array.Length < 1;
			z = p.gizmoColor.b;
			y = p.gizmoColor.g;
			color3 = p.gizmoColor;
			if (flag3)
			{
				goto IL_0777;
			}
			int num3 = 0;
			int num4 = 0;
			Vector3 center2 = default(Vector3);
			while (true)
			{
				Vector3[] array3 = p.wps;
				if (num3 >= array3.Length)
				{
					break;
				}
				object obj2 = (long)(IntPtr)array3 + (long)num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+20]");
				color3 = (Color)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+24]");
				y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+28]");
				z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+20]");
				center2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+24]");
				center2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ X8_v18+28]");
				center2.z = 0f;
				Gizmos.DrawSphere(center2, 0.075f);
				num3++;
				num4 += 12;
				if (num3 < array.Length)
				{
					continue;
				}
				goto IL_0777;
			}
			goto IL_0898;
			IL_0106:
			RefreshNonLinearDrawWps(p);
			if (p.type != PathType.Linear)
			{
				goto IL_0185;
			}
			goto IL_035b;
			IL_0185:
			Vector3[] array4 = p.nonLinearDrawWps;
			if (array4.Length != 0)
			{
				if (array4.Length <= 1)
				{
					goto IL_0531;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v26 (UnityEngine.Vector3[])+20]");
				Vector3 vector7 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v26 (UnityEngine.Vector3[])+24]");
				Vector3 vector8 = (Vector3)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v26 (UnityEngine.Vector3[])+28]");
				Vector3 vector9 = (Vector3)0;
				int num5 = 1;
				int num6 = 0;
				Vector3 vector10 = default(Vector3);
				Vector3 to3 = default(Vector3);
				while (num5 < array4.Length)
				{
					object obj3 = (long)(IntPtr)array4 + (long)num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+2C]");
					vector10.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+30]");
					vector10.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+34]");
					vector10.z = 0f;
					to3.x = vector7.x;
					to3.y = vector8.x;
					to3.z = vector9.x;
					Gizmos.DrawLine(vector10, to3);
					num5++;
					if (num5 >= array4.Length)
					{
						goto IL_0531;
					}
					array4 = p.nonLinearDrawWps;
					num6 += 12;
					bool flag4 = p.nonLinearDrawWps == null;
					bool flag5 = !flag4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+34]");
					vector9 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+30]");
					vector8 = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v27+2C]");
					vector7 = (Vector3)0;
					if (flag5)
					{
						continue;
					}
					goto IL_088a;
				}
			}
			goto IL_0898;
		}
	}
}
