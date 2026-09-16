using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Serializable]
	[Token(Token = "0x200009E")]
	public class Path
	{
		[Token(Token = "0x40001AC")]
		private static CatmullRomDecoder _catmullRomDecoder;

		[Token(Token = "0x40001AD")]
		private static LinearDecoder _linearDecoder;

		[Token(Token = "0x40001AE")]
		private static CubicBezierDecoder _cubicBezierDecoder;

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x10")]
		public float[] wpLengths;

		[SerializeField]
		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x18")]
		public Vector3[] wps;

		[SerializeField]
		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x20")]
		internal PathType type;

		[SerializeField]
		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x24")]
		internal int subdivisionsXSegment;

		[SerializeField]
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x28")]
		internal int subdivisions;

		[SerializeField]
		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x30")]
		internal ControlPoint[] controlPoints;

		[SerializeField]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x38")]
		internal float length;

		[SerializeField]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x3C")]
		internal bool isFinalized;

		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x40")]
		internal float[] timesTable;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x48")]
		internal float[] lengthsTable;

		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x50")]
		internal int linearWPIndex;

		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x54")]
		internal bool addedExtraStartWp;

		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x55")]
		internal bool addedExtraEndWp;

		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x58")]
		internal PathOptions plugOptions;

		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0xC8")]
		private Path _incrementalClone;

		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0xD0")]
		private int _incrementalIndex;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0xD8")]
		internal ABSPathDecoder _decoder;

		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0xE0")]
		private bool _changed;

		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0xE8")]
		internal Vector3[] nonLinearDrawWps;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0xF0")]
		internal Vector3 targetPosition;

		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0xFC")]
		internal Vector3? lookAtPosition;

		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x10C")]
		internal Color gizmoColor;

		[Token(Token = "0x1700000E")]
		internal int minInputWaypoints
		{
			[Token(Token = "0x60003A4")]
			[Address(RVA = "0xC1F7B0", Offset = "0xC1F7B0", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this._decoder;\n\tv5 = *([v2 @ X0_v1 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder)]);\n\tv6 = *([v5 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+198]);\n\tv7 = *([v5 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+1A0]);\n\t// 10 IndirectJump v6 @ X2_v1, v2 @ X0_v1 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v2 @ X0_v1 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v7 @ X1_v1, v6 @ X2_v1, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0017: Expected I, but got O
				//IL_0027: Expected O, but got I
				//IL_0037: Expected O, but got I
				ABSPathDecoder decoder = _decoder;
				nint num = (nint)decoder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+198]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+1A0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
				return 0;
			}
		}

		[Token(Token = "0x60003A5")]
		[Address(RVA = "0xC2A354", Offset = "0xC2A354", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv30 = DG.Tweening.DOTween;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv94 = DG.Tweening.TweenCallback;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv103 = DG.Tweening.Core.TweenManager;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, type, waypoints, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A357AC]) = v46;\nL_002F:\n\tthis.linearWPIndex = 0xFFFFFFFF;\n\tthis.gizmoColor = *([407E80]);\n\tSystem.Object::.ctor(this);\n\tthis.type = type;\n\tthis.subdivisionsXSegment = subdivisionsXSegment;\n\tv59 = *([gizmoColor @ X4 (System.Nullable`1<UnityEngine.Color>)]) == 0;\n\tif (v59) goto L_0049;\n\tv67 = System.Nullable`1<UnityEngine.Color>::get_Value(gizmoColor);\n\tthis.gizmoColor.r = v67;\n\tthis.gizmoColor.g = v67.g;\n\tthis.gizmoColor.b = v67.b;\n\tthis.gizmoColor.a = v67.a;\nL_0049:\n\tDG.Tweening.Plugins.Core.PathCore.Path::AssignWaypoints(this, waypoints, 1);\n\tDG.Tweening.Plugins.Core.PathCore.Path::AssignDecoder(this, type);\n\tgoto L_0056;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v89, v85, v78, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v74, v72, v70, v68, v39, v40, v41, v42);\n\tv98 = DG.Tweening.Core.TweenManager;\nL_0056:\n\tv101 = ~v99.isUnityEditor;\n\tif (v101) goto L_0092;\n\tgoto L_0067;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v108, v85, v78, subdivisionsXSegment, gizmoColor, methodInfo, v33, v34, v74, v72, v70, v68, v39, v40, v41, v42);\n\tv176 = DG.Tweening.DOTween;\nL_0067:\n\tv161 = v177.GizmosDelegates;\n\tv157 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v157, this, Il2CppMethodInfo);\n\tv225 = v161._items;\n\tv226 = v161._version + 1;\n\tv161._version = v226;\n\tv145 = v161._size;\n\tv227 = v161._size < v225.Length;\n\tv139 = ~v227;\n\tif (v139) goto L_00A0;\n\tv148 = v161._size + 1;\n\tv161._size = v148;\n\tv225[v145 @ X10_v5 (System.Int32)] = v157;\nL_0092:\n\treturn;\nL_00A0:\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::AddWithResize(v161, v157);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Path(PathType type, Vector3[] waypoints, int subdivisionsXSegment, Color? gizmoColor = null)
		{
			//IL_0140: Expected O, but got I
			base._002Ector();
			linearWPIndex = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407E80]");
			this.gizmoColor = (Color)0;
			this.type = type;
			this.subdivisionsXSegment = subdivisionsXSegment;
			if ((object)gizmoColor != null)
			{
				Color value = ((Color?*)gizmoColor)->Value;
				this.gizmoColor.r = value.r;
				this.gizmoColor.g = value.g;
				this.gizmoColor.b = value.b;
				this.gizmoColor.a = value.a;
			}
			AssignWaypoints(waypoints, cloneWps: true);
			AssignDecoder(type);
			if (TweenManager.isUnityEditor)
			{
				List<TweenCallback> gizmosDelegates = DOTween.GizmosDelegates;
				TweenCallback tweenCallback = Draw;
				TweenCallback[] items = gizmosDelegates._items;
				int version = gizmosDelegates._version + 1;
				gizmosDelegates._version = version;
				int count = gizmosDelegates.Count;
				if (gizmosDelegates.Count < items.Length)
				{
					int size = gizmosDelegates.Count + 1;
					gizmosDelegates._size = size;
					items[count] = tweenCallback;
				}
				else
				{
					gizmosDelegates.Add(tweenCallback);
				}
			}
		}

		[Token(Token = "0x60003A6")]
		[Address(RVA = "0xC2A764", Offset = "0xC2A764", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.linearWPIndex = 0xFFFFFFFF;\n\tthis.gizmoColor = *([407E80]);\n\tSystem.Object::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Path()
		{
			//IL_0023: Expected O, but got I
			base._002Ector();
			linearWPIndex = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407E80]");
			gizmoColor = (Color)0;
		}

		[Token(Token = "0x60003A7")]
		[Address(RVA = "0xC1F7D0", Offset = "0xC1F7D0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = lockPositionAxes == 0;\n\tif (v9) goto L_005B;\n\tv82 = this.wps;\nL_0017:\n\tv16 = v74 >= v82.Length;\n\tif (v16) goto L_005B;\n\tv167 = v82 + v78;\n\tv94 = *([v167 @ X10_v5+20]);\n\tv93 = *([v167 @ X10_v5+24]);\n\tv92 = *([v167 @ X10_v5+28]);\n\tv171 = lockPositionAxes & 4;\n\tv173 = v171 == 0;\n\tv78 = v78 + 0xC;\n\tv176 = ~v173;\n\tif (v176) goto L_FFFFFFFF;\n\tgoto L_0033;\nL_0033:\n\tv179 = lockPositionAxes & 2;\n\tv181 = v179 == 0;\n\tv184 = ~v181;\n\tif (v184) goto L_FFFFFFFF;\n\tgoto L_003E;\nL_003E:\n\tv187 = lockPositionAxes & 8;\n\tv99 = v187 == 0;\n\tv91 = ~v99;\n\tif (v91) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\t*([v167 @ X10_v5+20]) = v94;\n\t*([v167 @ X10_v5+24]) = v93;\n\t*([v167 @ X10_v5+28]) = v92;\n\tv82 = this.wps;\n\tv74 = v74 + 1;\n\tv190 = this.wps == 0;\n\tv106 = ~v190;\n\tif (v106) goto L_0017;\n\tthrow System.NullReferenceException;\nL_005B:\n\tv121 = DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder::FinalizePath(this._decoder, this, this.wps, isClosedPath);\n\tthis.isFinalized = 1;\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void FinalizePath(bool isClosedPath, AxisConstraint lockPositionAxes, Vector3 currTargetVal)
		{
			//IL_0051: Expected O, but got I
			//IL_0061: Expected O, but got I
			//IL_0071: Expected F4, but got I
			//IL_0081: Expected F4, but got I
			if (lockPositionAxes != AxisConstraint.None)
			{
				Vector3[] array = wps;
				int num = 0;
				int num2 = 0;
				while (num < array.Length)
				{
					object obj = (nint)array + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X10_v5+20]");
					Vector3 vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X10_v5+24]");
					float num3 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X10_v5+28]");
					float num4 = 0f;
					int num5 = (int)(lockPositionAxes & AxisConstraint.Y);
					bool flag = num5 == 0;
					num2 += 12;
					if (!flag)
					{
						num3 = currTargetVal.y;
					}
					if ((lockPositionAxes & AxisConstraint.X) != AxisConstraint.None)
					{
						vector = currTargetVal;
					}
					if ((lockPositionAxes & AxisConstraint.Z) != AxisConstraint.None)
					{
						num4 = currTargetVal.z;
					}
					array = wps;
					num++;
					if (wps == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			_decoder.FinalizePath(this, wps, isClosedPath);
			isFinalized = true;
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0xC20100", Offset = "0xC20100", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = convertToConstantPerc == 0;\n\tif (v8) goto L_0009;\n\treturnVal1 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToConstantPathPerc(this, returnVal1);\nL_0009:\n\tv14 = this._decoder;\n\tv16 = *([v14 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder)]);\n\tv17 = this.controlPoints;\n\tv18 = this.wps;\n\tv20 = *([v16 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+188]);\n\tv21 = *([v16 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+190]);\n\t// 21 IndirectJump v20 @ X5_v1, v14 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v14 @ X0_v2 (DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder), v18 @ X1_v1 (UnityEngine.Vector3[]), this @ X0 (DG.Tweening.Plugins.Core.PathCore.Path), v17 @ X3_v1 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v21 @ X4_v1, v20 @ X5_v1, v24 @ X6, v25 @ X7, returnVal1 @ V0_v1 (System.Single), v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			nint num2 = (nint)decoder;
			ControlPoint[] array = controlPoints;
			Vector3[] array2 = wps;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+188]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X8_v1 (Il2CppClass<DG.Tweening.Plugins.Core.PathCore.ABSPathDecoder>)+190]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v20 @ X5_v1 (should have been resolved before IL gen)");
			return (Vector3)0;
		}

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0xC1FFEC", Offset = "0xC1FFEC", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.type == 0;\n\tif (v4) goto L_FFFFFFFF;\n\tv17 = v93 <= 0;\n\tif (v17) goto L_0086;\n\tv59 = v93 >= 1f;\n\tif (v59) goto L_0086;\n\tv161 = this.length < 0;\n\tv47 = ~v161;\n\tv38 = this.length == 0;\n\tv162 = ~v47;\n\tv23 = v162 | v38;\n\tif (v23) goto L_FFFFFFFF;\n\tv191 = this.lengthsTable;\n\tv243 = this.length * v93;\n\tv254 = v191.Length < 1;\n\tif (v254) goto L_FFFFFFFF;\n\tv272 = this.timesTable;\n\tv268 = v191.Length & 0xFFFFFFFF;\nL_005C:\n\tv410 = v191[v270 @ X10_v10 (System.Int32)] > v243;\n\tif (v410) goto L_0099;\n\tv270 = v270 + 1;\n\tv337 = v268 != v270;\n\tif (v337) goto L_005C;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0074:\n\tv416 = v243 - v61;\n\tv73 = v414 - v61;\n\tv417 = v416 / v73;\n\tv70 = v413 - v99;\n\tv418 = v70 * v417;\n\tv93 = v99 + v418;\nL_0086:\n\tv134 = v93 > 1f;\n\tif (v134) goto L_FFFFFFFF;\n\treturnVal1 = UnityEngine.Mathf::Max(v93, 0f);\n\tgoto L_008E;\nL_008E:\n\treturn returnVal1;\nL_0099:\n\tv318 = v270 < 1;\n\tif (v318) goto L_FFFFFFFF;\n\tv317 = v270 - 1;\n\tgoto L_0074;\n\tv297 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn returnVal2;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal float ConvertToConstantPathPerc(float perc)
		{
			//IL_0117: Expected I4, but got I8
			float num = default(float);
			float num2;
			float[] array2;
			int num4;
			float num5;
			float num6;
			float num7;
			float num9;
			if (type != PathType.Linear)
			{
				if (!(num > 0f) || !(num < 1f))
				{
					goto IL_0284;
				}
				bool flag = length < 0f;
				bool flag2 = !flag;
				bool flag3 = length == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					float[] array = lengthsTable;
					num2 = length * num;
					if (array.Length >= 1)
					{
						array2 = timesTable;
						int num3 = (int)(array.Length & 0xFFFFFFFFL);
						num4 = 0;
						num5 = 0f;
						while (!(array[num4] > num2))
						{
							num4++;
							bool flag5 = num3 != num4;
							num5 = array2[num4];
							if (flag5)
							{
								continue;
							}
							goto IL_0193;
						}
						bool flag6 = num4 < 1;
						num6 = array2[num4];
						num7 = array[num4];
						if (flag6)
						{
							goto IL_02bf;
						}
						int num8 = num4 - 1;
						num9 = array[num8];
						num6 = array2[num4];
						num7 = array[num4];
						goto IL_02cd;
					}
					num7 = 0f;
					num5 = 0f;
					goto IL_02ac;
				}
			}
			float result = num;
			goto IL_01ed;
			IL_02bf:
			num9 = 0f;
			goto IL_02cd;
			IL_02cd:
			float num10 = num2 - num9;
			float num11 = num7 - num9;
			float num12 = num10 / num11;
			float num13 = num6 - num5;
			float num14 = num13 * num12;
			num = num5 + num14;
			goto IL_0284;
			IL_0284:
			bool flag7 = num > 1f;
			result = 1f;
			if (!flag7)
			{
				return Mathf.Max(num, 0f);
			}
			goto IL_01ed;
			IL_0193:
			num7 = 0f;
			num5 = array2[num4];
			goto IL_02ac;
			IL_01ed:
			return result;
			IL_02ac:
			num6 = 0f;
			goto IL_02bf;
		}

		[Token(Token = "0x60003AA")]
		[Address(RVA = "0xC20A7C", Offset = "0xC20A7C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = perc >= 1f;\n\tif (v13) goto L_004F;\n\tv14 = perc < 0;\n\tv15 = ~v14;\n\tv18 = perc == 0;\n\tv23 = ~v15;\n\tv24 = v23 | v18;\n\tif (v24) goto L_FFFFFFFF;\n\tv28 = this.wpLengths;\n\tv48 = v28.Length == 1;\n\tv32 = v28.Length - 1;\n\tv38 = v28.Length < 1;\n\tif (v38) goto L_FFFFFFFF;\n\tif (v48) goto L_004D;\n\tv95 = this.length * perc;\n\tv111 = v28 + 0x24;\nL_0035:\n\tv135 = v141 - v95;\n\tv132 = v135 < 0;\n\tv129 = v135 == 0;\n\tv126 = v141 ^ v95;\n\tv123 = v141 ^ v135;\n\tv120 = v126 & v123;\n\tv117 = v120 < 0;\n\tv190 = v141 >= v95;\n\tif (v190) goto L_0059;\n\tv99 = v99 + 1;\n\tv141 = v141 + *([v111 @ X10_v6+v99 @ X9_v5 (System.Int32)*4]);\n\tv170 = v32 != v99;\n\tif (v170) goto L_0035;\nL_004D:\n\treturnVal1 = v32 - isMovingForward;\n\tgoto L_0058;\nL_004F:\n\tv25 = this.wps;\n\treturnVal1 = v25.Length - 1;\n\tgoto L_0058;\nL_0058:\n\treturn returnVal1;\nL_0059:\n\tv192 = v132 == v117;\n\tv89 = ~v129;\n\tv114 = v192 & v89;\n\tv107 = v114 & isMovingForward;\n\treturnVal1 = v99 - v107;\n\tgoto L_0058;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal int GetWaypointIndexFromPerc(float perc, bool isMovingForward)
		{
			//IL_00f2: Expected O, but got I
			//IL_021d: Expected O, but got F4
			//IL_022a: Expected O, but got F4
			if (perc < 1f)
			{
				bool flag = perc < 0f;
				bool flag2 = !flag;
				bool flag3 = perc == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					float[] array = wpLengths;
					bool flag5 = array.Length == 1;
					int num = array.Length - 1;
					if (array.Length >= 1)
					{
						if (!flag5)
						{
							float num2 = length * perc;
							object obj = (nint)array + 36;
							int num3 = 0;
							float num4 = array[0];
							do
							{
								float num5 = num4 - num2;
								bool flag6 = num5 < 0f;
								bool flag7 = num5 == 0f;
								object obj2 = num4 ^ num2;
								object obj3 = num4 ^ num5;
								int num6 = (int)((nint)obj2 & (nint)obj3);
								bool flag8 = num6 < 0;
								if (num4 < num2)
								{
									num3++;
									float num7 = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X10_v6+v99 @ X9_v5 (System.Int32)*4]");
									num4 = num7 + 0f;
									continue;
								}
								bool flag9 = flag6 == flag8;
								bool flag10 = !flag7;
								bool flag11 = flag9 && flag10;
								bool flag12 = flag11 && isMovingForward;
								return num3 - (flag12 ? 1 : 0);
							}
							while (num != num3);
						}
						return num - (isMovingForward ? 1 : 0);
					}
				}
				return 0;
			}
			Vector3[] array2 = wps;
			return array2.Length - 1;
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0xC2A784", Offset = "0xC2A784", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = UnityEngine.Vector3[];\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, drawSubdivisionsXSegment, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A357AD]) = v42;\nL_0017:\n\tv174 = p.wps;\n\tv102 = p.type == 0;\n\tif (v102) goto L_005D;\n\tv95 = v174.Length * drawSubdivisionsXSegment;\n\tv138 = v95 + 1;\n\t// 35 NewArr v139 @ X0_v9 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v138 @ X1_v4 (System.Int32)\n\tv183 = v95 & 0x80000000;\n\tv184 = v183 == 0;\n\tv170 = ~v184;\n\tif (v170) goto L_005D;\nL_002D:\n\tv217 = v84 / v95;\n\tv47 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(p, v217, 0);\n\tv164 = v84 + 1;\n\tv169 = v84 * 0xC;\n\tv173 = v139 + v169;\n\t*([v173 @ X8_v11+20]) = v47;\n\tv139[v84 @ X22_v6 (System.Int32)].y = v47.y;\n\tv139[v84 @ X22_v6 (System.Int32)].z = v47.z;\n\tv142 = v164 <= v95;\n\tif (v142) goto L_002D;\nL_005D:\n\treturn v174;\n\tv100 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3[] GetDrawPoints(Path p, int drawSubdivisionsXSegment)
		{
			//IL_0075: Expected I4, but got I8
			//IL_00dd: Expected O, but got I
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
						int num5 = num4 + 1;
						int num6 = num4 * 12;
						object obj = (nint)array2 + num6;
						array2[num4].y = point.y;
						array2[num4].z = point.z;
						flag3 = num5 <= num;
						array = array2;
						num4 = num5;
					}
					while (flag3);
				}
			}
			return array;
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0xC2A860", Offset = "0xC2A860", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = UnityEngine.Vector3[];\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A357AE]) = v39;\nL_0015:\n\tv41 = p.wps;\n\tv100 = p.nonLinearDrawWps;\n\tv86 = v41.Length << 2;\n\tv101 = v41.Length + v86;\n\tv102 = v101 << 1;\n\tv103 = p.nonLinearDrawWps == 0;\n\tif (v103) goto L_0030;\n\tv160 = v102 | 1;\n\tv147 = v160 != v100.Length;\n\tif (v147) goto L_0034;\n\tv149 = v102 & 0x80000000;\n\tv150 = v149 == 0;\n\tif (v150) goto L_003C;\n\tgoto L_006B;\nL_0030:\n\tv160 = v102 | 1;\nL_0034:\n\t// 52 NewArr v165 @ X0_v7 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v160 @ X1_v3 (System.Int32)\n\tp.nonLinearDrawWps = v165;\n\tv229 = v102 & 0x80000000;\n\tv230 = v229 == 0;\n\tv225 = ~v230;\n\tif (v225) goto L_006B;\nL_003C:\n\tv83 = v102 | 1;\nL_003F:\n\tv255 = v97 / v102;\n\tv44 = DG.Tweening.Plugins.Core.PathCore.Path::GetPoint(p, v255, 0);\n\tv97 = v97 + 1;\n\tv244 = p.nonLinearDrawWps + v50;\n\tv50 = v50 + 0xC;\n\t*([v244 @ X8_v14]) = v44;\n\t*([v244 @ X8_v14+4]) = v44.y;\n\t*([v244 @ X8_v14+8]) = v44.z;\n\tv234 = v83 != v97;\n\tif (v234) goto L_003F;\nL_006B:\n\treturn;\n\tv98 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RefreshNonLinearDrawWps(Path p)
		{
			//IL_0043: Expected O, but got I4
			//IL_01a6: Expected I4, but got I8
			//IL_00b5: Expected I4, but got I8
			//IL_0130: Expected O, but got I
			Vector3[] array = p.wps;
			Vector3[] array2 = p.nonLinearDrawWps;
			int num = array.Length << 2;
			object obj = array.Length + num;
			int num2 = (int)((nint)obj << 1);
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
			int num4 = num2 | 1;
			int num5 = 32;
			int num6 = 0;
			do
			{
				float perc = (float)num6 / (float)num2;
				Vector3 point = p.GetPoint(perc);
				num6++;
				object obj2 = (nint)p.nonLinearDrawWps + num5;
				num5 += 12;
				obj2 = point;
				_ = point.y;
				_ = point.z;
			}
			while (num4 != num6);
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0xC1F148", Offset = "0xC1F148", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv20 = DG.Tweening.DOTween;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv90 = DG.Tweening.TweenCallback;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv113 = DG.Tweening.Core.TweenManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A357AF]) = v40;\nL_0024:\n\tgoto L_0029;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = DG.Tweening.Core.TweenManager;\nL_0029:\n\tv53 = ~v51.isUnityEditor;\n\tif (v53) goto L_0049;\n\tgoto L_003B;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv94 = DG.Tweening.DOTween;\nL_003B:\n\tv97 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v97, this, Il2CppMethodInfo);\n\tv75 = System.Collections.Generic.List`1<DG.Tweening.TweenCallback>::Remove(v95.GizmosDelegates, v97);\nL_0049:\n\tthis.nonLinearDrawWps = 0;\n\tthis.isFinalized = 0;\n\tthis.wpLengths = 0;\n\tthis.wps = 0;\n\tthis.timesTable = 0;\n\tthis.lengthsTable = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Destroy()
		{
			if (TweenManager.isUnityEditor)
			{
				TweenCallback item = Draw;
				bool flag = DOTween.GizmosDelegates.Remove(item);
			}
			nonLinearDrawWps = null;
			isFinalized = false;
			wpLengths = null;
			wps = null;
			timesTable = null;
			lengthsTable = null;
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0xC1FB7C", Offset = "0xC1FB7C", Length = "0x470")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv30 = DG.Tweening.Plugins.Core.PathCore.ControlPoint[];\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv53 = DG.Tweening.DOTween;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv406 = Il2CppMethodInfo;\n\tv407 = \"il2cpp_codegen_initialize_runtime_metadata\"(v406, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv488 = DG.Tweening.Plugins.Core.PathCore.Path;\n\tv489 = \"il2cpp_codegen_initialize_runtime_metadata\"(v488, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv503 = DG.Tweening.TweenCallback;\n\tv504 = \"il2cpp_codegen_initialize_runtime_metadata\"(v503, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv527 = DG.Tweening.Core.TweenManager;\n\tv528 = \"il2cpp_codegen_initialize_runtime_metadata\"(v527, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv535 = UnityEngine.Vector3[];\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v535, loopIncrement, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A357B0]) = v49;\nL_002D:\n\treturnVal1 = this._incrementalClone;\n\tv51 = this._incrementalClone == 0;\n\tif (v51) goto L_003C;\n\tv60 = this._incrementalIndex == loopIncrement;\n\tif (v60) goto L_01B9;\n\tDG.Tweening.Plugins.Core.PathCore.Path::Destroy(this._incrementalClone);\nL_003C:\n\tv82 = this.wps;\n\tv448 = this.wps + 0x20;\n\tv450 = v82.Length - 1;\n\tv453 = v450 * 0xC;\n\tv454 = v448 + v453;\n\tv247 = *([v454 @ X9_v6]);\n\tv560 = *([v454 @ X9_v6+8]);\n\tv123 = *([v454 @ X9_v6]) - *([v82 @ X8_v5 (UnityEngine.Vector3[])+20]);\n\tv121 = *([v454 @ X9_v6+8]) - *([v82 @ X8_v5 (UnityEngine.Vector3[])+28]);\n\t// 82 NewArr v370 @ X0_v9 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v82.Length\n\tv501 = v82.Length < 1;\n\tif (v501) goto L_0098;\n\tv266 = v82.Length & 0xFFFFFFFF;\n\tv275 = v123 * v508;\n\tv251 = v121 * loopIncrement;\nL_0083:\n\tv509 = this.wps + v257;\n\tv392 = v392 + 1;\n\tv510 = v370 + v257;\n\tv247 = v275 + *([v509 @ X11_v17]);\n\tv560 = v251 + *([v509 @ X11_v17+8]);\n\tv257 = v257 + 0xC;\n\t*([v510 @ X12_v18]) = v247;\n\t*([v510 @ X12_v18+8]) = v560;\n\tv511 = v266 != v392;\n\tif (v511) goto L_0083;\nL_0098:\n\tv393 = this.controlPoints;\n\t// 160 NewArr v371 @ X0_v11 (DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), typeof(DG.Tweening.Plugins.Core.PathCore.ControlPoint[]), v393.Length\n\tv547 = v393.Length < 1;\n\tif (v547) goto L_00EA;\n\tv268 = v393.Length & 0xFFFFFFFF;\n\tv277 = v123 * v508;\n\t// 180 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 181 NotImplemented \"Instruction ZIP1 not yet implemented.\"\nL_00D2:\n\tv555 = this.controlPoints + v259;\n\tv394 = v394 + 1;\n\tv557 = v371 + v259;\n\tv560 = v277 + *([v555 @ X11_v14]);\n\tv102 = loopIncrement + *([v555 @ X11_v14+8]);\n\tv100 = v247 + *([v555 @ X11_v14+10]);\n\tv259 = v259 + 0x18;\n\t*([v557 @ X12_v14]) = v560;\n\t*([v557 @ X12_v14+8]) = v102;\n\t*([v557 @ X12_v14+10]) = v100;\n\tv559 = v268 != v394;\n\tif (v559) goto L_00D2;\nL_00EA:\n\tv586 = this.nonLinearDrawWps;\n\tv587 = this.nonLinearDrawWps == 0;\n\tif (v587) goto L_FFFFFFFF;\n\t// 240 NewArr v372 @ X0_v29 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v586.Length\n\tv607 = v586.Length < 1;\n\tif (v607) goto L_013B;\n\tv269 = v586.Length & 0xFFFFFFFF;\n\tv278 = v123 * v508;\n\tv254 = v121 * loopIncrement;\nL_011F:\n\tv609 = this.nonLinearDrawWps + v260;\n\tv395 = v395 + 1;\n\tv610 = v372 + v260;\n\tv614 = v278 + *([v609 @ X11_v11]);\n\tv613 = v254 + *([v609 @ X11_v11+8]);\n\tv260 = v260 + 0xC;\n\t*([v610 @ X12_v10]) = v614;\n\t*([v610 @ X12_v10+8]) = v613;\n\tv611 = v269 != v395;\n\tif (v611) goto L_011F;\n\tgoto L_013B;\nL_013B:\n\tv634 = new DG.Tweening.Plugins.Core.PathCore.Path();\n\tv634.linearWPIndex = 0xFFFFFFFF;\n\tv634.gizmoColor = *([407E80]);\n\tSystem.Object::.ctor(v634);\n\tthis._incrementalClone = v634;\n\tthis._incrementalIndex = loopIncrement;\n\tv634.type = this.type;\n\tv634.wps = v370;\n\tv634.controlPoints = v371;\n\tv634.subdivisions = this.subdivisions;\n\tgoto L_0156;\n\tv656 = \"il2cpp_codegen_runtime_class_init\"(v647, v642, methodInfo, v33, v34, v35, v36, v37, v279, v131, v129, v127, v102, v100, v44, v45);\n\tv658 = DG.Tweening.Core.TweenManager;\nL_0156:\n\tv661 = ~v659.isUnityEditor;\n\tif (v661) goto L_0192;\n\tgoto L_0165;\n\tv688 = \"il2cpp_codegen_runtime_class_init\"(v664, v642, methodInfo, v33, v34, v35, v36, v37, v279, v131, v129, v127, v102, v100, v44, v45);\n\tv690 = DG.Tweening.DOTween;\nL_0165:\n\tv389 = v692.GizmosDelegates;\n\tv373 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v373, this._incrementalClone, Il2CppMethodInfo);\n\tv397 = v389._items;\n\tv262 = v389._version + 1;\n\tv389._version = v262;\n\tv672 = v389._size;\n\tv705 = v389._size < v397.Length;\n\tv681 = ~v705;\n\tif (v681) goto L_0191;\n\tv673 = v389._size + 1;\n\tv389._size = v673;\n\tv397[v672 @ X10_v12 (System.Int32)] = v373;\n\tgoto L_0192;\nL_0191:\n\tSystem.Collections.Generic.List`1<DG.Tweening.TweenCallback>::AddWithResize(v389, v373);\nL_0192:\n\tv398 = this._incrementalClone;\n\tv398.length = this.length;\n\tv398.wpLengths = this.wpLengths;\n\tv398.timesTable = this.timesTable;\n\tv398.nonLinearDrawWps = v143;\n\tv398._decoder = this._decoder;\n\tv398.targetPosition.z = this.targetPosition.z;\n\tv398.targetPosition = this.targetPosition;\n\tv399 = this._incrementalClone;\n\tv399.lookAtPosition = this.lookAtPosition;\n\treturnVal1 = this._incrementalClone;\n\treturnVal1.isFinalized = 1;\nL_01B9:\n\treturn returnVal1;\n\tv369 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 306 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Path CloneIncremental(int loopIncrement)
		{
			//IL_0053: Expected O, but got I
			//IL_0063: Expected O, but got I4
			//IL_0072: Expected O, but got I
			//IL_0081: Expected O, but got I
			//IL_0089: Expected F4, but got O
			//IL_0099: Expected F4, but got I
			//IL_0113: Expected I4, but got I8
			//IL_0159: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_01b1: Expected O, but got F4
			//IL_0228: Expected I4, but got I8
			//IL_062a: Expected O, but got I
			//IL_0272: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_02b2: Expected O, but got I
			//IL_02df: Expected O, but got F4
			//IL_037d: Expected I4, but got I8
			//IL_03c3: Expected O, but got I
			//IL_03df: Expected O, but got I
			//IL_041b: Expected O, but got F4
			Path incrementalClone = _incrementalClone;
			if (_incrementalClone != null)
			{
				if (_incrementalIndex == loopIncrement)
				{
					goto IL_05f9;
				}
				_incrementalClone.Destroy();
			}
			Vector3[] array = wps;
			object obj = (nint)wps + 32;
			object obj2 = array.Length - 1;
			object obj3 = (nint)obj2 * 12;
			object obj4 = (nint)obj + (nint)obj3;
			float num = (float)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X9_v6+8]");
			float num2 = 0f;
			float num3 = (float)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v5 (UnityEngine.Vector3[])+20]");
			float num4 = num3 - 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X9_v6+8]");
			float num5 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v5 (UnityEngine.Vector3[])+28]");
			float num6 = num5 - 0f;
			Vector3[] array2 = new Vector3[array.Length];
			object obj5 = default(object);
			if (array.Length >= 1)
			{
				int num7 = (int)(array.Length & 0xFFFFFFFFL);
				float num8 = num4 * (float)obj5;
				float num9 = num6 * (float)loopIncrement;
				int num10 = 32;
				int num11 = 0;
				do
				{
					object obj6 = (nint)wps + num10;
					num11++;
					object obj7 = (nint)array2 + num10;
					num = num8 + (float)obj6;
					float num12 = num9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ X11_v17+8]");
					num2 = num12 + 0f;
					num10 += 12;
					obj7 = num;
				}
				while (num7 != num11);
			}
			ControlPoint[] array3 = controlPoints;
			ControlPoint[] array4 = new ControlPoint[array3.Length];
			if (array3.Length >= 1)
			{
				int num13 = (int)(array3.Length & 0xFFFFFFFFL);
				float num14 = num4 * (float)obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction ZIP1 not yet implemented.\"");
				int num15 = 32;
				int num16 = 0;
				do
				{
					object obj8 = (nint)controlPoints + num15;
					num16++;
					object obj9 = (nint)array4 + num15;
					num2 = num14 + (float)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ X11_v14+8]");
					object obj10 = (nint)loopIncrement + (nint)0;
					float num17 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ X11_v14+10]");
					float num18 = num17 + 0f;
					num15 += 24;
					obj9 = num2;
				}
				while (num13 != num16);
			}
			Vector3[] array5 = nonLinearDrawWps;
			Vector3[] array7;
			if (nonLinearDrawWps != null)
			{
				Vector3[] array6 = new Vector3[array5.Length];
				bool flag = array5.Length < 1;
				array7 = array6;
				if (!flag)
				{
					int num19 = (int)(array5.Length & 0xFFFFFFFFL);
					float num20 = num4 * (float)obj5;
					float num21 = num6 * (float)loopIncrement;
					int num22 = 32;
					int num23 = 0;
					do
					{
						object obj11 = (nint)nonLinearDrawWps + num22;
						num23++;
						object obj12 = (nint)array6 + num22;
						float num24 = num20 + (float)obj11;
						float num25 = num21;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X11_v11+8]");
						float num26 = num25 + 0f;
						num22 += 12;
						obj12 = num24;
					}
					while (num19 != num23);
					array7 = array6;
				}
			}
			else
			{
				array7 = null;
			}
			Path path = new Path();
			path.linearWPIndex = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407E80]");
			path.gizmoColor = (Color)0;
			_incrementalClone = path;
			_incrementalIndex = loopIncrement;
			path.type = type;
			path.wps = array2;
			path.controlPoints = array4;
			path.subdivisions = subdivisions;
			if (TweenManager.isUnityEditor)
			{
				List<TweenCallback> gizmosDelegates = DOTween.GizmosDelegates;
				TweenCallback tweenCallback = _incrementalClone.Draw;
				TweenCallback[] items = gizmosDelegates._items;
				int version = gizmosDelegates._version + 1;
				gizmosDelegates._version = version;
				int count = gizmosDelegates.Count;
				if (gizmosDelegates.Count < items.Length)
				{
					int size = gizmosDelegates.Count + 1;
					gizmosDelegates._size = size;
					items[count] = tweenCallback;
				}
				else
				{
					gizmosDelegates.Add(tweenCallback);
				}
			}
			Path incrementalClone2 = _incrementalClone;
			incrementalClone2.length = length;
			incrementalClone2.wpLengths = wpLengths;
			incrementalClone2.timesTable = timesTable;
			incrementalClone2.nonLinearDrawWps = array7;
			incrementalClone2._decoder = _decoder;
			incrementalClone2.targetPosition.z = targetPosition.z;
			incrementalClone2.targetPosition = targetPosition;
			Path incrementalClone3 = _incrementalClone;
			incrementalClone3.lookAtPosition = lookAtPosition;
			incrementalClone = _incrementalClone;
			incrementalClone.isFinalized = true;
			goto IL_05f9;
			IL_05f9:
			return incrementalClone;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0xC2A54C", Offset = "0xC2A54C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = UnityEngine.Vector3[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, newWps, cloneWps, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A357B1]) = v39;\nL_0015:\n\tv41 = cloneWps == 0;\n\tif (v41) goto L_0060;\n\t// 30 NewArr v127 @ X0_v10 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), newWps.Length\n\tthis.wps = v127;\n\tv143 = newWps.Length < 1;\n\tif (v143) goto L_0067;\n\tv205 = newWps.Length & 0xFFFFFFFF;\n\tv106 = v205 - 1;\nL_0040:\n\tv233 = newWps + v132;\n\tv139 = v127 + v132;\n\tv158 = v106 == v104;\n\t*([v139 @ X11_v8+20]) = *([v233 @ X11_v7+20]);\n\t*([v139 @ X11_v8+28]) = *([v233 @ X11_v7+28]);\n\tif (v158) goto L_0067;\n\tv127 = this.wps;\n\tv104 = v104 + 1;\n\tv132 = v132 + 0xC;\n\tv235 = v104 < newWps.Length;\n\tv226 = ~v235;\n\tv211 = ~v226;\n\tif (v211) goto L_0040;\n\tthrow System.IndexOutOfRangeException;\nL_0060:\n\tthis.wps = newWps;\nL_0067:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AssignWaypoints(Vector3[] newWps, bool cloneWps = false)
		{
			//IL_0051: Expected I4, but got I8
			//IL_0084: Expected O, but got I
			//IL_0092: Expected O, but got I
			if (cloneWps)
			{
				Vector3[] array = (wps = new Vector3[newWps.Length]);
				if (newWps.Length < 1)
				{
					return;
				}
				int num = (int)(newWps.Length & 0xFFFFFFFFL);
				int num2 = num - 1;
				int num3 = 0;
				int num4 = 0;
				while (true)
				{
					object obj = (nint)newWps + num4;
					object obj2 = (nint)array + num4;
					bool flag = num2 == num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X11_v7+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X11_v7+28]");
					_ = 0;
					if (!flag)
					{
						array = wps;
						num3++;
						num4 += 12;
						if (num3 >= newWps.Length)
						{
							throw new IndexOutOfRangeException();
						}
						continue;
					}
					break;
				}
			}
			else
			{
				wps = newWps;
			}
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0xC2A62C", Offset = "0xC2A62C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, pathType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv50 = DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, pathType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv60 = DG.Tweening.Plugins.Core.PathCore.LinearDecoder;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, pathType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv97 = DG.Tweening.Plugins.Core.PathCore.Path;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, pathType, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A357B2]) = v37;\nL_001B:\n\tthis.type = pathType;\n\tv44 = pathType == 2;\n\tif (v44) goto L_003E;\n\tv52 = pathType == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0050;\n\tv65 = v63._linearDecoder == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0060;\n\tv82 = new DG.Tweening.Plugins.Core.PathCore.LinearDecoder();\n\tSystem.Object::.ctor(v82);\n\tv90._linearDecoder = v82;\n\tgoto L_0060;\nL_003E:\n\tv84 = v55._cubicBezierDecoder;\n\tv57 = v55._cubicBezierDecoder == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0060;\n\tv75 = new DG.Tweening.Plugins.Core.PathCore.CubicBezierDecoder();\n\tSystem.Object::.ctor(v75);\n\tv91._cubicBezierDecoder = v75;\n\tgoto L_0060;\nL_0050:\n\tv70 = v68._catmullRomDecoder == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0060;\n\tv81 = new DG.Tweening.Plugins.Core.PathCore.CatmullRomDecoder();\n\tSystem.Object::.ctor(v81);\n\tv108._catmullRomDecoder = v81;\nL_0060:\n\tthis._decoder = v84;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AssignDecoder(PathType pathType)
		{
			type = pathType;
			CubicBezierDecoder decoder;
			switch (pathType)
			{
			case PathType.Linear:
			{
				bool flag3 = _linearDecoder == null;
				bool flag4 = !flag3;
				decoder = (CubicBezierDecoder)(object)_linearDecoder;
				if (!flag4)
				{
					decoder = (CubicBezierDecoder)(object)(_linearDecoder = new LinearDecoder());
				}
				break;
			}
			case PathType.CubicBezier:
				decoder = _cubicBezierDecoder;
				if (_cubicBezierDecoder == null)
				{
					decoder = (_cubicBezierDecoder = new CubicBezierDecoder());
				}
				break;
			default:
			{
				bool flag = _catmullRomDecoder == null;
				bool flag2 = !flag;
				decoder = (CubicBezierDecoder)(object)_catmullRomDecoder;
				if (!flag2)
				{
					CatmullRomDecoder catmullRomDecoder = new CatmullRomDecoder();
					_catmullRomDecoder = catmullRomDecoder;
					decoder = (CubicBezierDecoder)(object)_catmullRomDecoder;
				}
				break;
			}
			}
			_decoder = decoder;
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0xC2A958", Offset = "0xC2A958", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.Plugins.Core.PathCore.Path::Draw(this);\n\treturn;\n")]
		internal void Draw()
		{
			Draw(this);
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0xC2A95C", Offset = "0xC2A95C", Length = "0x420")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv67 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv64 = 1;\n\t*([1A357B3]) = v64;\nL_0026:\n\tv69 = p.timesTable == 0;\n\tif (v69) goto L_01AE;\n\t// 49 MakeStruct v226 @ AGGC2E9E4_0_v4 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), p.gizmoColor.b (System.Single), p.gizmoColor.a (System.Single)\n\tUnityEngine.Gizmos::set_color(v226);\n\tv287 = p.wps;\n\tv254 = p.gizmoColor.a * 0.5f;\n\tv214 = v287.Length & 0xFFFFFFFF;\n\tv609 = ~p._changed;\n\tif (v609) goto L_004A;\n\tp._changed = 0;\n\tv610 = p.type == 0;\n\tif (v610) goto L_00B6;\nL_0044:\n\tDG.Tweening.Plugins.Core.PathCore.Path::RefreshNonLinearDrawWps(p);\n\tv621 = p.type == 0;\n\tv618 = ~v621;\n\tif (v618) goto L_004F;\n\tgoto L_00B6;\nL_004A:\n\tv611 = p.type == 0;\n\tif (v611) goto L_00B6;\n\tv613 = p.nonLinearDrawWps == 0;\n\tif (v613) goto L_01AF;\nL_004F:\n\tv288 = p.nonLinearDrawWps;\n\tv295 = p + 0x58;\n\tv639 = 0x1854F10(&v638 @ stack_-1E0, v295, 0x70, v48, v49, v50, v51, v52, 0.5f, p.gizmoColor.g, p.gizmoColor.b, p.gizmoColor.a, v430, v428, v59, v60);\n\t// 98 MakeStruct v181 @ AGGC2EA7C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v288 @ X8_v23 (UnityEngine.Vector3[])+20], [v288 @ X8_v23 (UnityEngine.Vector3[])+24], [v288 @ X8_v23 (UnityEngine.Vector3[])+28]\n\tv501 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToDrawPoint(v181, &v638 @ stack_-1E0);\n\tv499 = v501.y;\n\tv497 = v501.z;\n\tv515 = p.nonLinearDrawWps;\n\tv136 = v515.Length <= 1;\n\tif (v136) goto L_011C;\n\tv123 = v515.Length & 0xFFFFFFFF;\nL_0088:\n\tv785 = v515 + v439;\n\tv824 = 0x1854F10(&v823 @ stack_-250, v295, 0x70, v48, v49, v50, v51, v52, v501, v499, v497, v495, v430, v428, v59, v60);\n\t// 148 MakeStruct v113 @ AGGC2EAE4_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v785 @ X8_v26+2C], [v785 @ X8_v26+30], [v785 @ X8_v26+34]\n\tv501 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToDrawPoint(v113, &v823 @ stack_-250);\n\tv499 = v501.y;\n\tv497 = v501.z;\n\t// 160 MakeStruct v97 @ AGGC2EB04_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v441 @ V14_v12 (UnityEngine.Vector3), v483 @ V11_v16 (System.Single), v503 @ V8_v18 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v501, v97);\n\tv436 = v436 + 1;\n\tv161 = v123 == v436;\n\tif (v161) goto L_011C;\n\tv515 = p.nonLinearDrawWps;\n\tv439 = v439 + 0xC;\n\tv839 = p.nonLinearDrawWps == 0;\n\tv282 = ~v839;\n\tif (v282) goto L_0088;\n\tgoto L_01B1;\nL_00B6:\n\tv291 = p.wps;\n\tv296 = p + 0x58;\n\tv631 = 0x1854F10(&v628 @ stack_-100, v296, 0x70, v48, v49, v50, v51, v52, 0.5f, p.gizmoColor.g, p.gizmoColor.b, p.gizmoColor.a, v430, v428, v59, v60);\n\t// 200 MakeStruct v93 @ AGGC2EB6C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v291 @ X8_v18 (UnityEngine.Vector3[])+20], [v291 @ X8_v18 (UnityEngine.Vector3[])+24], [v291 @ X8_v18 (UnityEngine.Vector3[])+28]\n\tv250 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToDrawPoint(v93, &v628 @ stack_-100);\n\tv243 = v250.y;\n\tv237 = v250.z;\n\tv653 = v287.Length <= 0;\n\tif (v653) goto L_0163;\nL_00ED:\n\tv699 = p.wps + v124;\n\tv791 = 0x1854F10(&v790 @ stack_-170, v296, 0x70, v48, v49, v50, v51, v52, v250, v243, v237, v231, v430, v428, v59, v60);\n\t// 249 MakeStruct v670 @ AGGC2EBD0_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v699 @ X8_v21], [v699 @ X8_v21+4], [v699 @ X8_v21+8]\n\tv250 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToDrawPoint(v670, &v790 @ stack_-170);\n\tv243 = v250.y;\n\tv237 = v250.z;\n\t// 261 MakeStruct v668 @ AGGC2EBF0_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v196 @ V12_v10 (UnityEngine.Vector3), v117 @ V13_v9 (System.Single), v132 @ V14_v9 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v250, v668);\n\tv128 = v128 + 1;\n\tv124 = v124 + 0xC;\n\tv677 = v214 != v128;\n\tif (v677) goto L_00ED;\nL_011C:\n\t// 284 MakeStruct v78 @ AGGC2EC20_0_v5 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), v207 @ stack_-2C8_v5 (System.Single), v254 @ V8_v6 (System.Single)\n\tUnityEngine.Gizmos::set_color(v78);\n\tv704 = v287.Length < 1;\n\tif (v704) goto L_0166;\n\tv297 = p + 0x58;\nL_013C:\n\tv748 = p.wps + v129;\n\tv838 = 0x1854F10(&v837 @ stack_-2C0, v297, 0x70, v48, v49, v50, v51, v52, v251, v244, v238, v232, v110, v106, v59, v60);\n\t// 328 MakeStruct v701 @ AGGC2EC7C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v748 @ X8_v16], [v748 @ X8_v16+4], [v748 @ X8_v16+8]\n\tv251 = DG.Tweening.Plugins.Core.PathCore.Path::ConvertToDrawPoint(v701, &v837 @ stack_-2C0);\n\tv244 = v251.y;\n\tv238 = v251.z;\n\tUnityEngine.Gizmos::DrawSphere(v251, 0.075f);\n\tv224 = v224 + 1;\n\tv129 = v129 + 0xC;\n\tv705 = v214 != v224;\n\tif (v705) goto L_013C;\n\tgoto L_0166;\nL_0163:\n\t// 355 MakeStruct v667 @ AGGC2ECB4_0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), p.gizmoColor (UnityEngine.Color), p.gizmoColor.g (System.Single), p.gizmoColor.b (System.Single), v254 @ V8_v6 (System.Single)\n\tUnityEngine.Gizmos::set_color(v667);\nL_0166:\n\tv391 = p + 0xFC;\n\tv393 = *([v391 @ X0_v10 (System.Nullable`1<UnityEngine.Vector3>)]) == 0;\n\tif (v393) goto L_01AE;\n\tv765 = System.Nullable`1<UnityEngine.Vector3>::get_Value(v391);\n\t// 379 MakeStruct v529 @ AGGC2ECFC_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), p.targetPosition (UnityEngine.Vector3), p.targetPosition.y (System.Single), p.targetPosition.z (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v529, v765);\n\tUnityEngine.Gizmos::DrawWireSphere(v765, 0.075f);\n\treturn;\nL_01AE:\n\treturn;\nL_01AF:\n\tp._changed = 0;\n\tgoto L_0044;\nL_01B1:\n\tv298 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n// 327 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void Draw(Path p)
		{
			//IL_00cc: Expected I4, but got I8
			//IL_04a9: Expected O, but got I
			//IL_04cd: Expected F4, but got I
			//IL_04e2: Expected F4, but got I
			//IL_04f7: Expected F4, but got I
			//IL_0504: Expected O, but got Ref
			//IL_0907: Expected O, but got I
			//IL_058f: Expected O, but got F4
			//IL_01ba: Expected O, but got I
			//IL_01de: Expected F4, but got I
			//IL_01f3: Expected F4, but got I
			//IL_0208: Expected F4, but got I
			//IL_0215: Expected O, but got Ref
			//IL_05a7: Expected O, but got I
			//IL_05c6: Expected F4, but got O
			//IL_05db: Expected F4, but got I
			//IL_05f0: Expected F4, but got I
			//IL_05fd: Expected O, but got Ref
			//IL_02a2: Expected I4, but got I8
			//IL_02db: Expected O, but got F4
			//IL_076f: Expected O, but got I
			//IL_02fb: Expected O, but got I
			//IL_0322: Expected F4, but got I
			//IL_0337: Expected F4, but got I
			//IL_034c: Expected F4, but got I
			//IL_0359: Expected O, but got Ref
			//IL_07c8: Expected O, but got I
			//IL_07e7: Expected F4, but got O
			//IL_07fc: Expected F4, but got I
			//IL_0811: Expected F4, but got I
			//IL_081e: Expected O, but got Ref
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
			float num = p.gizmoColor.a * 0.5f;
			int num2 = (int)(array.Length & 0xFFFFFFFFL);
			if (p._changed)
			{
				p._changed = false;
				if (p.type != PathType.Linear)
				{
					goto IL_011a;
				}
			}
			else if (p.type != PathType.Linear)
			{
				if (p.nonLinearDrawWps != null)
				{
					goto IL_0199;
				}
				p._changed = false;
				goto IL_011a;
			}
			goto IL_0488;
			IL_011a:
			RefreshNonLinearDrawWps(p);
			if (p.type != PathType.Linear)
			{
				goto IL_0199;
			}
			goto IL_0488;
			IL_08f8:
			Vector3? vector = (Vector3?)(object)((nint)p + 252);
			if ((object)vector != null)
			{
				Vector3 value = ((Vector3?*)vector)->Value;
				Vector3 vector2 = default(Vector3);
				vector2.x = p.targetPosition.x;
				vector2.y = p.targetPosition.y;
				vector2.z = p.targetPosition.z;
				Gizmos.DrawLine(vector2, value);
				Gizmos.DrawWireSphere(value, 0.075f);
			}
			return;
			IL_0488:
			Vector3[] array2 = p.wps;
			object obj = (nint)p + 88;
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X8_v18 (UnityEngine.Vector3[])+20]");
			Vector3 wp = default(Vector3);
			wp.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X8_v18 (UnityEngine.Vector3[])+24]");
			wp.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X8_v18 (UnityEngine.Vector3[])+28]");
			wp.z = 0f;
			object obj2 = default(object);
			Vector3 vector3 = ConvertToDrawPoint(wp, (PathOptions)(&obj2));
			float y = vector3.y;
			float z = vector3.z;
			float b;
			float num5;
			float num6;
			float num7 = default(float);
			float num8 = default(float);
			if (array.Length > 0)
			{
				float y2 = vector3.y;
				int num3 = 32;
				int num4 = 0;
				float z2 = vector3.z;
				Vector3 vector4 = vector3;
				object obj3 = p.gizmoColor.a;
				Vector3 wp2 = default(Vector3);
				object obj5 = default(object);
				Vector3 to = default(Vector3);
				bool flag;
				do
				{
					object obj4 = (nint)p.wps + num3;
					Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
					wp2.x = (float)obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ X8_v21+4]");
					wp2.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ X8_v21+8]");
					wp2.z = 0f;
					vector3 = ConvertToDrawPoint(wp2, (PathOptions)(&obj5));
					y = vector3.y;
					z = vector3.z;
					to.x = vector4.x;
					to.y = y2;
					to.z = z2;
					Gizmos.DrawLine(vector3, to);
					num4++;
					num3 += 12;
					flag = num2 != num4;
					num5 = z2;
					num6 = y2;
					b = p.gizmoColor.b;
					num7 = z2;
					num8 = y2;
					y2 = vector3.y;
					z2 = vector3.z;
					vector4 = vector3;
					obj3 = vector3;
				}
				while (flag);
				goto IL_06f0;
			}
			Color color2 = default(Color);
			color2.r = p.gizmoColor.r;
			color2.g = p.gizmoColor.g;
			color2.b = p.gizmoColor.b;
			color2.a = num;
			Gizmos.color = color2;
			goto IL_08f8;
			IL_06f0:
			Color color3 = default(Color);
			color3.r = p.gizmoColor.r;
			color3.g = p.gizmoColor.g;
			color3.b = b;
			color3.a = num;
			Gizmos.color = color3;
			if (array.Length >= 1)
			{
				object obj6 = (nint)p + 88;
				int num9 = 32;
				int num10 = 0;
				float num11 = num;
				float num12 = b;
				float g = p.gizmoColor.g;
				Vector3 vector5 = (Vector3)p.gizmoColor;
				Vector3 wp3 = default(Vector3);
				object obj8 = default(object);
				bool flag2;
				do
				{
					object obj7 = (nint)p.wps + num9;
					Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
					wp3.x = (float)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ X8_v16+4]");
					wp3.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v748 @ X8_v16+8]");
					wp3.z = 0f;
					vector5 = ConvertToDrawPoint(wp3, (PathOptions)(&obj8));
					g = vector5.y;
					num12 = vector5.z;
					Gizmos.DrawSphere(vector5, 0.075f);
					num10++;
					num9 += 12;
					flag2 = num2 != num10;
					num11 = 0.075f;
				}
				while (flag2);
			}
			goto IL_08f8;
			IL_0199:
			Vector3[] array3 = p.nonLinearDrawWps;
			object obj9 = (nint)p + 88;
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ X8_v23 (UnityEngine.Vector3[])+20]");
			Vector3 wp4 = default(Vector3);
			wp4.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ X8_v23 (UnityEngine.Vector3[])+24]");
			wp4.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ X8_v23 (UnityEngine.Vector3[])+28]");
			wp4.z = 0f;
			object obj10 = default(object);
			Vector3 vector6 = ConvertToDrawPoint(wp4, (PathOptions)(&obj10));
			float y3 = vector6.y;
			float z3 = vector6.z;
			Vector3[] array4 = p.nonLinearDrawWps;
			bool flag3 = array4.Length <= 1;
			num5 = num7;
			num6 = num8;
			b = p.gizmoColor.b;
			if (!flag3)
			{
				int num13 = (int)(array4.Length & 0xFFFFFFFFL);
				int num14 = 1;
				int num15 = 0;
				Vector3 vector7 = vector6;
				float y4 = vector6.y;
				object obj11 = p.gizmoColor.a;
				float z4 = vector6.z;
				Vector3 wp5 = default(Vector3);
				object obj13 = default(object);
				Vector3 to2 = default(Vector3);
				while (true)
				{
					object obj12 = (nint)array4 + num15;
					Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v26+2C]");
					wp5.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v26+30]");
					wp5.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X8_v26+34]");
					wp5.z = 0f;
					vector6 = ConvertToDrawPoint(wp5, (PathOptions)(&obj13));
					y3 = vector6.y;
					z3 = vector6.z;
					to2.x = vector7.x;
					to2.y = y4;
					to2.z = z4;
					Gizmos.DrawLine(vector6, to2);
					num14++;
					bool flag4 = num13 == num14;
					num5 = z4;
					num6 = y4;
					b = p.gizmoColor.b;
					if (flag4)
					{
						break;
					}
					array4 = p.nonLinearDrawWps;
					num15 += 12;
					bool flag5 = p.nonLinearDrawWps == null;
					bool flag6 = !flag5;
					num7 = z4;
					num8 = y4;
					vector7 = vector6;
					y4 = vector6.y;
					obj11 = vector6;
					z4 = vector6.z;
					if (!flag6)
					{
						NullReferenceException ex = new NullReferenceException();
						throw new IndexOutOfRangeException();
					}
				}
			}
			goto IL_06f0;
		}

		[Token(Token = "0x60003B3")]
		[Address(RVA = "0xC2AD7C", Offset = "0xC2AD7C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = UnityEngine.Object;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, wp, v0, v2, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A357B4]) = v42;\nL_001A:\n\tv45 = plugOptions.useLocalPosition == 0;\n\tif (v45) goto L_0045;\n\tgoto L_0028;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v29, v30, v31, v32, v33, v34, wp, v0, v2, v35, v36, v37, v38, v39);\nL_0028:\n\tv65 = UnityEngine.Object::op_Equality(plugOptions.parent, 0);\n\tv110 = v65 == 0;\n\tv68 = ~v110;\n\tif (v68) goto L_0045;\n\tv57 = UnityEngine.Transform::TransformPoint(plugOptions.parent, wp);\nL_0045:\n\treturn v69;\n\tthrow System.NullReferenceException;\n\treturn wp;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector3 ConvertToDrawPoint(Vector3 wp, PathOptions plugOptions)
		{
			bool flag = !plugOptions.useLocalPosition;
			Vector3 result = wp;
			if (!flag)
			{
				bool flag2 = plugOptions.parent == null;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				result = wp;
				if (!flag4)
				{
					Vector3 vector = plugOptions.parent.TransformPoint(wp);
					result = vector;
				}
			}
			return result;
		}
	}
}
