using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using EM_Moments;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x731230", Offset = "0x731230")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x731230", Offset = "0x731230")]
	[DisallowMultipleComponent]
	[Token(Token = "0x200005C")]
	public sealed class Recorder : MonoBehaviour
	{
		[Token(Token = "0x200012C")]
		public enum RecorderState
		{
			[Token(Token = "0x400051B")]
			Stopped = 1,
			[Token(Token = "0x400051C")]
			Recording = 2
		}

		[SerializeField]
		[Token(Token = "0x4000223")]
		[FieldOffset(Offset = "0x18")]
		private bool _autoHeight;

		[SerializeField]
		[AttributeAttribute(Type = typeof(MinAttribute), RVA = "0x7329D4", Offset = "0x7329D4")]
		[Token(Token = "0x4000224")]
		[FieldOffset(Offset = "0x1C")]
		private int _width;

		[SerializeField]
		[AttributeAttribute(Type = typeof(MinAttribute), RVA = "0x732A10", Offset = "0x732A10")]
		[Token(Token = "0x4000225")]
		[FieldOffset(Offset = "0x20")]
		private int _height;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x732A4C", Offset = "0x732A4C")]
		[Token(Token = "0x4000226")]
		[FieldOffset(Offset = "0x24")]
		private int _framePerSecond;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x732A8C", Offset = "0x732A8C")]
		[Token(Token = "0x4000227")]
		[FieldOffset(Offset = "0x28")]
		private float _length;

		[SerializeField]
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0x2C")]
		private RecorderState _state;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0x30")]
		private Camera _targetCamera;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0x38")]
		private int maxFrameCount;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0x3C")]
		private float pastTime;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0x40")]
		private float timePerFrame;

		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x48")]
		private Queue<RenderTexture> recordedFrames;

		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x50")]
		private ReflectionUtils<Recorder> reflectionUtils;

		[Token(Token = "0x1700014C")]
		public bool AutoHeight
		{
			[Token(Token = "0x600047B")]
			[Address(RVA = "0xFD2B9C", Offset = "0xFD2B9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._autoHeight;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoHeight;
			}
		}

		[Token(Token = "0x1700014D")]
		public int Width
		{
			[Token(Token = "0x600047C")]
			[Address(RVA = "0xFD2BA4", Offset = "0xFD2BA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._width;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Width;
			}
		}

		[Token(Token = "0x1700014E")]
		public int Height
		{
			[Token(Token = "0x600047D")]
			[Address(RVA = "0xFD2BAC", Offset = "0xFD2BAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._height;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Height;
			}
		}

		[Token(Token = "0x1700014F")]
		public int FramePerSecond
		{
			[Token(Token = "0x600047E")]
			[Address(RVA = "0xFD2BB4", Offset = "0xFD2BB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._framePerSecond;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FramePerSecond;
			}
		}

		[Token(Token = "0x17000150")]
		public float Length
		{
			[Token(Token = "0x600047F")]
			[Address(RVA = "0xFD2BBC", Offset = "0xFD2BBC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._length;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Length;
			}
		}

		[Token(Token = "0x17000151")]
		public RecorderState State
		{
			[Token(Token = "0x6000480")]
			[Address(RVA = "0xFD2BC4", Offset = "0xFD2BC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._state;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return State;
			}
		}

		[Token(Token = "0x17000152")]
		public Camera TargetCamera
		{
			[Token(Token = "0x6000481")]
			[Address(RVA = "0xFD2BCC", Offset = "0xFD2BCC", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF1940]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256AE]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._targetCamera, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_002E;\n\treturnVal1 = UnityEngine.Component::GetComponent(this);\n\tthis._targetCamera = returnVal1;\n\tgoto L_0034;\nL_002E:\n\treturnVal1 = this._targetCamera;\nL_0034:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (!(_targetCamera == null)) ? _targetCamera : (_targetCamera = GetComponent<Camera>());
			}
		}

		[Token(Token = "0x6000482")]
		[Address(RVA = "0xFD2C64", Offset = "0xFD2C64", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EB9928]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, targetCam, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20256AF]) = v43;\nL_001A:\n\tv47 = UnityEngine.Camera::get_aspect(targetCam);\n\tgoto L_002E;\n\tv57 = *([v53 @ X0_v5+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002E;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, v46, methodInfo, v28, v29, v30, v31, v32, v47, v34, v35, v36, v37, v38, v39, v40);\nL_002E:\n\tv70 = width / v47;\n\treturnVal2 = UnityEngine.Mathf::RoundToInt(v70);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int CalculateAutoHeight(int width, Camera targetCam)
		{
			float aspect = targetCam.aspect;
			float f = (float)width / aspect;
			return Mathf.RoundToInt(f);
		}

		[Token(Token = "0x6000483")]
		[Address(RVA = "0xFD2D00", Offset = "0xFD2D00", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = width * height;\n\tv6 = fps * length;\n\tv9 = v3 << 2;\n\tv11 = v6 * v9;\n\treturnVal1 = v11 * 9.536743E-07f;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EstimateMemoryUse(int width, int height, int fps, float length)
		{
			int num = width * height;
			float num2 = (float)fps * length;
			int num3 = num << 2;
			float num4 = num2 * (float)num3;
			return num4 * 9.536743E-07f;
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0xFD2D28", Offset = "0xFD2D28", Length = "0x528")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv46 = *([1F00908]);\n\tv47 = *([v46 @ X8_v81]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, autoHeight, width, height, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([20256B0]) = v61;\nL_002B:\n\tv72 = this._state != 2;\n\tif (v72) goto L_004E;\n\tgoto L_004B;\n\tv80 = *([v75 @ X0_v97+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_004B;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v75, autoHeight, width, height, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_004B:\n\tUnityEngine.Debug::LogWarning(\"Attempting to init the recorder while a recording is in process.\");\n\treturn;\nL_004E:\n\tEasyMobile.Recorder::FlushMemory(this);\n\tthis._autoHeight = autoHeight;\n\tgoto L_0063;\n\tv115 = *([v109 @ X0_v3+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0063;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v109, autoHeight, width, height, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_0063:\n\tv124 = System.Type::GetTypeFromHandle(EasyMobile.Recorder);\n\tgoto L_0077;\n\tv191 = *([v187 @ X8_v9+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0077;\n\tv204 = v187;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v204, v123, width, height, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_0077:\n\tv203 = System.Linq.Expressions.Expression::Parameter(v124, \"x\");\n\tv211 = System.Reflection.FieldInfo::GetFieldFromHandle(Il2CppFieldInfo);\n\tv215 = System.Linq.Expressions.Expression::Field(v203, v211);\n\t// 137 NewArr v222 @ X0_v15 (System.Linq.Expressions.ParameterExpression[]), typeof(System.Linq.Expressions.ParameterExpression[]), 1\n\tv225 = v203 == 0;\n\tif (v225) goto L_0096;\n\t// 146 IsInst v281 @ X0_v93, typeof(System.Linq.Expressions.ParameterExpression), v203 @ X0_v9 (System.Linq.Expressions.ParameterExpression)\nL_0096:\n\tv288 = v222.Length == 0;\n\tif (v288) goto L_0197;\n\tv222[0] = v203;\n\tv322 = System.Linq.Expressions.Expression::Lambda(v215, v222);\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::ConstrainMin(this.reflectionUtils, v322, width);\n\tv389 = ~this._autoHeight;\n\tv390 = ~v389;\n\tif (v390) goto L_0107;\n\tgoto L_00BE;\n\tv421 = *([v394 @ X0_v70+E0]);\n\tv422 = v421 == 0;\n\tv423 = ~v422;\n\tif (v423) goto L_00BE;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v394, v367, v374, v227, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_00BE:\n\tv430 = System.Type::GetTypeFromHandle(EasyMobile.Recorder);\n\tgoto L_00D0;\n\tv452 = *([v441 @ X8_v57+E0]);\n\tv453 = v452 == 0;\n\tv454 = ~v453;\n\tif (v454) goto L_00D0;\n\tv474 = v441;\n\tv456 = \"il2cpp_codegen_runtime_class_init\"(v474, v429, v374, v227, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_00D0:\n\tv463 = System.Linq.Expressions.Expression::Parameter(v430, \"x\");\n\tv480 = System.Reflection.FieldInfo::GetFieldFromHandle(Il2CppFieldInfo);\n\tv490 = System.Linq.Expressions.Expression::Field(v463, v480);\n\t// 226 NewArr v250 @ X0_v82 (System.Linq.Expressions.ParameterExpression[]), typeof(System.Linq.Expressions.ParameterExpression[]), 1\n\tv499 = v463 == 0;\n\tif (v499) goto L_00EF;\n\t// 235 IsInst v343 @ X0_v88, typeof(System.Linq.Expressions.ParameterExpression), v463 @ X0_v76 (System.Linq.Expressions.ParameterExpression)\nL_00EF:\n\tv305 = v250.Length == 0;\n\tif (v305) goto L_0197;\n\tv250[0] = v463;\n\tv381 = System.Linq.Expressions.Expression::Lambda(v490, v250);\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::ConstrainMin(this.reflectionUtils, v381, height);\nL_0107:\n\tgoto L_010F;\n\tv431 = *([v416 @ X0_v32+E0]);\n\tv432 = v431 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_010F;\n\tv435 = \"il2cpp_codegen_runtime_class_init\"(v416, v404, v401, v228, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_010F:\n\tv440 = System.Type::GetTypeFromHandle(EasyMobile.Recorder);\n\tgoto L_0121;\n\tv464 = *([v446 @ X8_v31+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_0121;\n\tv481 = v446;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v481, v439, v401, v228, fps, methodInfo, v50, v51, length, v52, v53, v54, v55, v56, v57, v58);\nL_0121:\n\tv473 = System.Linq.Expressions.Expression::Parameter(v440, \"x\");\n\tv487 = System.Reflection.FieldInfo::GetFieldFromHandle(Il2CppFieldInfo);\n\tv493 = System.Linq.Expressions.Expression::Field(v473, v487);\n\t// 307 NewArr v251 @ X0_v44 (System.Linq.Expressions.ParameterExpression[]), typeof(System.Linq.Expressions.ParameterExpression[]), 1\n\tv500 = v473 == 0;\n\tif (v500) goto L_0140;\n\t// 316 IsInst v344 @ X0_v66, typeof(System.Linq.Expressions.ParameterExpression), v473 @ X0_v38 (System.Linq.Expressions.ParameterExpression)\nL_0140:\n\tv306 = v251.Length == 0;\n\tif (v306) goto L_0197;\n\tv251[0] = v473;\n\tv382 = System.Linq.Expressions.Expression::Lambda(v493, v251);\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::ConstrainRange(this.reflectionUtils, v382, fps);\n\tv517 = System.Type::GetTypeFromHandle(EasyMobile.Recorder);\n\tv520 = System.Linq.Expressions.Expression::Parameter(v517, \"x\");\n\tv526 = System.Reflection.FieldInfo::GetFieldFromHandle(Il2CppFieldInfo);\n\tv529 = System.Linq.Expressions.Expression::Field(v520, v526);\n\t// 358 NewArr v252 @ X0_v57 (System.Linq.Expressions.ParameterExpression[]), typeof(System.Linq.Expressions.ParameterExpression[]), 1\n\tv531 = v520 == 0;\n\tif (v531) goto L_0173;\n\t// 367 IsInst v345 @ X0_v64, typeof(System.Linq.Expressions.ParameterExpression), v520 @ X0_v51 (System.Linq.Expressions.ParameterExpression)\nL_0173:\n\tv307 = v252.Length == 0;\n\tif (v307) goto L_0197;\n\tv252[0] = v520;\n\tv383 = System.Linq.Expressions.Expression::Lambda(v529, v252);\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::ConstrainRange(this.reflectionUtils, v383, length);\n\tEasyMobile.Recorder::Init(this);\n\treturn;\n\tv277 = new System.NullReferenceException();\nL_0197:\n\tv317 = new System.IndexOutOfRangeException();\n\tgoto L_019E;\n\tv342 = new System.NullReferenceException();\n\tv366 = new System.ArrayTypeMismatchException();\nL_019E:\n\tthrow v371;\n// 296 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Setup(bool autoHeight, int width, int height, int fps, float length)
		{
			if (State == RecorderState.Recording)
			{
				Debug.LogWarning("Attempting to init the recorder while a recording is in process.");
				return;
			}
			FlushMemory();
			_autoHeight = autoHeight;
			Type typeFromHandle = typeof(Recorder);
			ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "x");
			FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
			MemberExpression body = Expression.Field(parameterExpression, fieldFromHandle);
			ParameterExpression[] array = new ParameterExpression[1];
			if (parameterExpression != null)
			{
				object obj = parameterExpression as ParameterExpression;
			}
			if (array.Length != 0)
			{
				array[0] = parameterExpression;
				Expression<Func<Recorder, int>> fieldAccess = Expression.Lambda<Func<Recorder, int>>(body, array);
				reflectionUtils.ConstrainMin(fieldAccess, width);
				if (!AutoHeight)
				{
					Type typeFromHandle2 = typeof(Recorder);
					ParameterExpression parameterExpression2 = Expression.Parameter(typeFromHandle2, "x");
					FieldInfo fieldFromHandle2 = FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
					MemberExpression body2 = Expression.Field(parameterExpression2, fieldFromHandle2);
					ParameterExpression[] array2 = new ParameterExpression[1];
					if (parameterExpression2 != null)
					{
						object obj2 = parameterExpression2 as ParameterExpression;
					}
					if (array2.Length == 0)
					{
						goto IL_0401;
					}
					array2[0] = parameterExpression2;
					Expression<Func<Recorder, int>> fieldAccess2 = Expression.Lambda<Func<Recorder, int>>(body2, array2);
					reflectionUtils.ConstrainMin(fieldAccess2, height);
				}
				Type typeFromHandle3 = typeof(Recorder);
				ParameterExpression parameterExpression3 = Expression.Parameter(typeFromHandle3, "x");
				FieldInfo fieldFromHandle3 = FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
				MemberExpression body3 = Expression.Field(parameterExpression3, fieldFromHandle3);
				ParameterExpression[] array3 = new ParameterExpression[1];
				if (parameterExpression3 != null)
				{
					object obj3 = parameterExpression3 as ParameterExpression;
				}
				if (array3.Length != 0)
				{
					array3[0] = parameterExpression3;
					Expression<Func<Recorder, int>> fieldAccess3 = Expression.Lambda<Func<Recorder, int>>(body3, array3);
					reflectionUtils.ConstrainRange(fieldAccess3, fps);
					Type typeFromHandle4 = typeof(Recorder);
					ParameterExpression parameterExpression4 = Expression.Parameter(typeFromHandle4, "x");
					FieldInfo fieldFromHandle4 = FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
					MemberExpression body4 = Expression.Field(parameterExpression4, fieldFromHandle4);
					ParameterExpression[] array4 = new ParameterExpression[1];
					if (parameterExpression4 != null)
					{
						object obj4 = parameterExpression4 as ParameterExpression;
					}
					if (array4.Length != 0)
					{
						array4[0] = parameterExpression4;
						Expression<Func<Recorder, float>> fieldAccess4 = Expression.Lambda<Func<Recorder, float>>(body4, array4);
						reflectionUtils.ConstrainRange(fieldAccess4, length);
						Init();
						return;
					}
				}
			}
			goto IL_0401;
			IL_0401:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0xFD35C4", Offset = "0xFD35C4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._state = 2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Record()
		{
			_state = RecorderState.Recording;
		}

		[Token(Token = "0x6000486")]
		[Address(RVA = "0xFD35D0", Offset = "0xFD35D0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F04BD8]);\n\tv27 = *([v26 @ X8_v23]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20256B1]) = v46;\nL_0017:\n\tv91 = this.recordedFrames;\n\tthis._state = 1;\n\tv51 = v91._size == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_003A;\n\tgoto L_0030;\n\tv98 = *([v86 @ X0_v11+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0030;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0030:\n\tUnityEngine.Debug::LogWarning(\"Nothing recorded, an empty clip will be returned.\");\n\tv91 = this.recordedFrames;\nL_003A:\n\tv97 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::ToArray(v91);\n\tv110 = new EasyMobile.AnimatedClip();\n\tEasyMobile.AnimatedClip::.ctor(v110, this._width, this._height, this._framePerSecond, v97);\n\tSystem.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::Clear(this.recordedFrames);\n\treturn v110;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatedClip Stop()
		{
			Queue<RenderTexture> queue = recordedFrames;
			_state = RecorderState.Stopped;
			if (queue.Count == 0)
			{
				Debug.LogWarning("Nothing recorded, an empty clip will be returned.");
				queue = recordedFrames;
			}
			RenderTexture[] frames = queue.ToArray();
			AnimatedClip result = new AnimatedClip(Width, Height, FramePerSecond, frames);
			recordedFrames.Clear();
			return result;
		}

		[Token(Token = "0x6000487")]
		[Address(RVA = "0xFD36E0", Offset = "0xFD36E0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this._state - 2;\n\tv6 = v4 == 0;\n\treturn v6;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsRecording()
		{
			int num = (int)(State - 2);
			return num == 0;
		}

		[Token(Token = "0x6000488")]
		[Address(RVA = "0xFD36F0", Offset = "0xFD36F0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB7EF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256B2]) = v38;\nL_0016:\n\tv42 = new EM_Moments.ReflectionUtils`1<EasyMobile.Recorder>();\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::.ctor(v42, this);\n\tthis.reflectionUtils = v42;\n\tv51 = new System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>();\n\tSystem.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::.ctor(v51);\n\tthis.recordedFrames = v51;\n\tEasyMobile.Recorder::Init(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ReflectionUtils<Recorder> reflectionUtils = new ReflectionUtils<Recorder>(this);
			this.reflectionUtils = reflectionUtils;
			Queue<RenderTexture> queue = new Queue<RenderTexture>();
			recordedFrames = queue;
			Init();
		}

		[Token(Token = "0x6000489")]
		[Address(RVA = "0xFD3788", Offset = "0xFD3788", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._state = 1;\n\tEasyMobile.Recorder::FlushMemory(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			_state = RecorderState.Stopped;
			FlushMemory();
		}

		[Token(Token = "0x600048A")]
		[Address(RVA = "0xFD3794", Offset = "0xFD3794", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv32 = *([1EAC5B8]);\n\tv33 = *([v32 @ X8_v33]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, source, destination, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20256B3]) = v50;\nL_0024:\n\tv61 = this._state != 2;\n\tif (v61) goto L_00A3;\n\tv64 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv113 = this.pastTime + v64;\n\tthis.pastTime = v113;\n\tv84 = v113 < this.timePerFrame;\n\tif (v84) goto L_00A3;\n\tv150 = this.recordedFrames;\n\tv112 = v113 - this.timePerFrame;\n\tthis.pastTime = v112;\n\tv83 = v150._size >= this.maxFrameCount;\n\tif (v83) goto L_004F;\n\tgoto L_0057;\nL_004F:\n\tv233 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::Dequeue(v150);\nL_0057:\n\tgoto L_0060;\n\tv263 = *([v259 @ X0_v15+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tgoto L_0060;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v259, v253, destination, methodInfo, v36, v37, v38, v39, v112, v110, v42, v43, v44, v45, v46, v47);\nL_0060:\n\tv245 = UnityEngine.Object::op_Equality(v122, 0);\n\tv271 = v245 == 0;\n\tif (v271) goto L_0084;\n\tv244 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v244, this._width, this._height, 0, 0);\n\tUnityEngine.Texture::set_wrapMode(v244, 1);\n\tUnityEngine.Texture::set_filterMode(v244, 1);\n\tUnityEngine.Texture::set_anisoLevel(v244, 0);\n\tgoto L_008B;\nL_0084:\n\tUnityEngine.RenderTexture::DiscardContents(v122);\nL_008B:\n\tgoto L_0094;\n\tv293 = *([v286 @ X0_v20+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0094;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v286, v278, v276, v70, v68, v66, v38, v39, v112, v110, v42, v43, v44, v45, v46, v47);\nL_0094:\n\tUnityEngine.Graphics::Blit(source, v122);\n\tSystem.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::Enqueue(this.recordedFrames, v122);\nL_00A3:\n\tgoto L_00B6;\n\tv131 = *([v125 @ X0_v3+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tif (v133) goto L_00B6;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v125, v77, v75, v69, v67, v65, v38, v39, v111, v109, v42, v43, v44, v45, v46, v47);\nL_00B6:\n\tUnityEngine.Graphics::Blit(source, destination);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (State == RecorderState.Recording)
			{
				float unscaledDeltaTime = Time.unscaledDeltaTime;
				float num = (pastTime += unscaledDeltaTime);
				if (!(num < timePerFrame))
				{
					Queue<RenderTexture> queue = recordedFrames;
					float num2 = num - timePerFrame;
					pastTime = num2;
					RenderTexture renderTexture;
					if (queue.Count < maxFrameCount)
					{
						renderTexture = null;
					}
					else
					{
						RenderTexture renderTexture2 = queue.Dequeue();
						renderTexture = renderTexture2;
					}
					if (renderTexture == null)
					{
						RenderTexture renderTexture3 = new RenderTexture(Width, Height, 0, default(RenderTextureFormat));
						renderTexture3.wrapMode = TextureWrapMode.Clamp;
						renderTexture3.filterMode = FilterMode.Bilinear;
						renderTexture3.anisoLevel = 0;
						renderTexture = renderTexture3;
					}
					else
					{
						renderTexture.DiscardContents();
					}
					Graphics.Blit(source, renderTexture);
					recordedFrames.Enqueue(renderTexture);
				}
			}
			Graphics.Blit(source, destination);
		}

		[Token(Token = "0x600048B")]
		[Address(RVA = "0xFD3398", Offset = "0xFD3398", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EACCA8]);\n\tv27 = *([v26 @ X8_v38]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20256B4]) = v46;\nL_001F:\n\tgoto L_0026;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0026;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0026:\n\tv63 = this._length * this._framePerSecond;\n\tv65 = UnityEngine.Mathf::RoundToInt(v63);\n\tthis.maxFrameCount = v65;\n\tthis.pastTime = 0f;\n\tv70 = 1f / this._framePerSecond;\n\tthis.timePerFrame = v70;\n\tv71 = ~this._autoHeight;\n\tif (v71) goto L_00A4;\n\tgoto L_0045;\n\tv90 = *([v75 @ X0_v6+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0045;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v30, v31, v32, v33, v34, v35, v70, v68, v38, v39, v40, v41, v42, v43);\nL_0045:\n\tv99 = System.Type::GetTypeFromHandle(EasyMobile.Recorder);\n\tgoto L_0059;\n\tv146 = *([v142 @ X8_v15+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_0059;\n\tv158 = v142;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v158, v98, v30, v31, v32, v33, v34, v35, v70, v68, v38, v39, v40, v41, v42, v43);\nL_0059:\n\tv157 = System.Linq.Expressions.Expression::Parameter(v99, \"x\");\n\tv165 = System.Reflection.FieldInfo::GetFieldFromHandle(Il2CppFieldInfo);\n\tv169 = System.Linq.Expressions.Expression::Field(v157, v165);\n\t// 107 NewArr v176 @ X0_v18 (System.Linq.Expressions.ParameterExpression[]), typeof(System.Linq.Expressions.ParameterExpression[]), 1\n\tv178 = v157 == 0;\n\tif (v178) goto L_0078;\n\t// 116 IsInst v183 @ X0_v37, typeof(System.Linq.Expressions.ParameterExpression), v157 @ X0_v12 (System.Linq.Expressions.ParameterExpression)\nL_0078:\n\tv190 = v176.Length == 0;\n\tif (v190) goto L_00A6;\n\tv176[0] = v157;\n\tv201 = System.Linq.Expressions.Expression::Lambda(v169, v176);\n\tv215 = EasyMobile.Recorder::get_TargetCamera(this);\n\tv220 = EasyMobile.Recorder::CalculateAutoHeight(this._width, v215);\n\tEM_Moments.ReflectionUtils`1<EasyMobile.Recorder>::ConstrainMin(this.reflectionUtils, v201, v220);\n\treturn;\nL_00A4:\n\treturn;\n\tv179 = new System.NullReferenceException();\nL_00A6:\n\tv195 = new System.IndexOutOfRangeException();\n\tgoto L_00AD;\n\tv210 = new System.NullReferenceException();\n\tv213 = new System.ArrayTypeMismatchException();\nL_00AD:\n\tthrow v218;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			float f = Length * (float)FramePerSecond;
			int num = Mathf.RoundToInt(f);
			maxFrameCount = num;
			pastTime = 0f;
			float num2 = 1f / (float)FramePerSecond;
			timePerFrame = num2;
			if (AutoHeight)
			{
				Type typeFromHandle = typeof(Recorder);
				ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle, "x");
				FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
				MemberExpression body = Expression.Field(parameterExpression, fieldFromHandle);
				ParameterExpression[] array = new ParameterExpression[1];
				if (parameterExpression != null)
				{
					object obj = parameterExpression as ParameterExpression;
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				array[0] = parameterExpression;
				Expression<Func<Recorder, int>> fieldAccess = Expression.Lambda<Func<Recorder, int>>(body, array);
				Camera targetCamera = TargetCamera;
				int value = CalculateAutoHeight(Width, targetCamera);
				reflectionUtils.ConstrainMin(fieldAccess, value);
			}
		}

		[Token(Token = "0x600048C")]
		[Address(RVA = "0xFD3250", Offset = "0xFD3250", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F0C8E0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20256B5]) = v42;\nL_0017:\n\tv45 = 0;\n\tv47 = this.recordedFrames == 0;\n\tif (v47) goto L_0065;\n\tv52 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::GetEnumerator(this.recordedFrames);\nL_0026:\n\tv147 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::MoveNext(&v45 @ stack_-48_v1 (System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>));\n\tv149 = v147 == 0;\n\tif (v149) goto L_003A;\n\tv152 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::get_Current(&v45 @ stack_-48_v1 (System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>));\n\tv142 = v152 == 0;\n\tif (v142) goto L_003D;\n\tUnityEngine.RenderTexture::Release(v152);\n\tEasyMobile.Recorder::Flush(v152, v152);\n\tgoto L_0026;\nL_003A:\n\tv157 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>));\n\tgoto L_005D;\nL_003D:\n\tv160 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv161 = Il2CppMethodInfo != 1;\n\tif (v161) goto L_0067;\n\tv197 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::get_Current(v160);\n\tv201 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::get_Current(v197);\n\tv173 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>));\n\tv204 = *([v197 @ X0_v22 (UnityEngine.RenderTexture)]) == 0;\n\tv175 = ~v204;\n\tif (v175) goto L_006B;\nL_005D:\n\tSystem.Collections.Generic.Queue`1<UnityEngine.RenderTexture>::Clear(this.recordedFrames);\nL_0065:\n\treturn;\n\tv180 = new System.NullReferenceException();\nL_0067:\n\tv196 = System.Collections.Generic.Queue`1<UnityEngine.RenderTexture>+Enumerator<UnityEngine.RenderTexture>::Dispose(v192);\nL_006B:\n\tthrow System.TypeLoadException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void FlushMemory()
		{
			Queue<RenderTexture>.Enumerator enumerator = default(Queue<RenderTexture>.Enumerator);
			if (recordedFrames == null)
			{
				return;
			}
			Queue<RenderTexture>.Enumerator enumerator2 = recordedFrames.GetEnumerator();
			NullReferenceException ex2 = default(NullReferenceException);
			while (true)
			{
				if (enumerator.MoveNext())
				{
					RenderTexture current = enumerator.Current;
					if ((object)current != null)
					{
						current.Release();
						((Recorder)(object)current).Flush((UnityEngine.Object)current);
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)0 != (IntPtr)1)
					{
						((Queue<RenderTexture>.Enumerator*)ex2)->Dispose();
						break;
					}
					RenderTexture current2 = ((Queue<RenderTexture>.Enumerator*)ex)->Current;
					RenderTexture current3 = ((Queue<RenderTexture>.Enumerator*)current2)->Current;
					enumerator.Dispose();
					if ((object)current2 != null)
					{
						break;
					}
				}
				else
				{
					enumerator.Dispose();
				}
				recordedFrames.Clear();
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x600048D")]
		[Address(RVA = "0xFD398C", Offset = "0xFD398C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED4B40]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, obj, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20256B6]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, obj, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tUnityEngine.Object::Destroy(obj);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Flush(UnityEngine.Object obj)
		{
			UnityEngine.Object.Destroy(obj);
		}

		[Token(Token = "0x600048E")]
		[Address(RVA = "0xFD39F4", Offset = "0xFD39F4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._autoHeight = 1;\n\tthis._width = 0x1E0000001E0;\n\tthis._framePerSecond = 0x404000000000000F;\n\tthis._state = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Recorder()
		{
			//IL_0036: Expected I4, but got I8
			base._002Ector();
			_autoHeight = true;
			_width = 480;
			_height = 480;
			_framePerSecond = 15;
			_state = RecorderState.Stopped;
		}
	}
}
