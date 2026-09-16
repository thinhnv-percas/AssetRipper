using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[CreateAssetMenu]
	[ExecuteInEditMode]
	[Token(Token = "0x200002A")]
	public class ObiDistanceField : ScriptableObject
	{
		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x745C6C", Offset = "0x745C6C")]
		[SerializeField]
		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x18")]
		private Mesh input;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x20")]
		private float minNodeSize;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x24")]
		internal Bounds bounds;

		[HideInInspector]
		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x40")]
		public Oni.DFNode[] nodes;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x745D38", Offset = "0x745D38")]
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x48")]
		public float maxError;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x745D58", Offset = "0x745D58")]
		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x4C")]
		public int maxDepth;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x50")]
		private IntPtr oniDistanceField;

		[Token(Token = "0x17000038")]
		public bool Initialized
		{
			[Token(Token = "0x600023E")]
			[Address(RVA = "0xE43D20", Offset = "0xE43D20", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.nodes == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = nodes == null;
				return !flag;
			}
		}

		[Token(Token = "0x17000039")]
		public IntPtr OniDistanceField
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0xE43D30", Offset = "0xE43D30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.oniDistanceField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OniDistanceField;
			}
		}

		[Token(Token = "0x1700003A")]
		public unsafe Bounds FieldBounds
		{
			[Token(Token = "0x6000240")]
			[Address(RVA = "0xE43D38", Offset = "0xE43D38", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = this.bounds.m_Extents.y;\n\treturnBuffer.m_Center = this.bounds;\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001b: Expected native int or pointer, but got O
				_ = this.bounds.m_Extents.y;
				Bounds bounds = default(Bounds);
				((Bounds*)(IntPtr)bounds)->m_Center = (Vector3)this.bounds;
				return (Bounds)this;
			}
		}

		[Token(Token = "0x1700003B")]
		public float EffectiveSampleSize
		{
			[Token(Token = "0x6000241")]
			[Address(RVA = "0xE43D4C", Offset = "0xE43D4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.minNodeSize;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EffectiveSampleSize;
			}
		}

		[Token(Token = "0x1700003C")]
		public Mesh InputMesh
		{
			[Token(Token = "0x6000243")]
			[Address(RVA = "0xE43E90", Offset = "0xE43E90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.input;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return InputMesh;
			}
			[Token(Token = "0x6000242")]
			[Address(RVA = "0xE43D54", Offset = "0xE43D54", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EDBC10]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202473F]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(value, this.input);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0032;\n\tObi.ObiDistanceField::Reset(this);\n\tthis.input = value;\nL_0032:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != InputMesh)
				{
					Reset();
					input = value;
				}
			}
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0xE43E98", Offset = "0xE43E98", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Oni::CreateDistanceField();\n\tv12 = this.nodes;\n\tthis.oniDistanceField = v11;\n\tv13 = this.nodes == 0;\n\tif (v13) goto L_0018;\n\tOni::SetDistanceFieldNodes(v11, this.nodes, v12.Length);\n\treturn;\nL_0018:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			IntPtr df = Oni.CreateDistanceField();
			Oni.DFNode[] array = nodes;
			oniDistanceField = df;
			if (nodes != null)
			{
				Oni.SetDistanceFieldNodes(df, nodes, array.Length);
			}
		}

		[Token(Token = "0x6000245")]
		[Address(RVA = "0xE43EDC", Offset = "0xE43EDC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tOni::DestroyDistanceField(this.oniDistanceField);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			Oni.DestroyDistanceField(OniDistanceField);
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0xE43DE4", Offset = "0xE43DE4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDC728]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024740]) = v38;\nL_0013:\n\tthis.nodes = 0;\n\tgoto L_0024;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0024;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv56 = UnityEngine.Object::op_Inequality(this.input, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003D;\n\tv84 = UnityEngine.Mesh::get_bounds(this.input);\n\tthis.bounds.m_Extents.y = *([v84 @ X0_v9 (UnityEngine.Bounds)+10]);\n\tthis.bounds = v84.m_Center;\nL_003D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			//IL_005d: Expected F4, but got I
			nodes = null;
			if (InputMesh != null)
			{
				Bounds bounds = InputMesh.bounds;
				ref Vector3 extents = ref this.bounds.m_Extents;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X0_v9 (UnityEngine.Bounds)+10]");
				extents.y = 0f;
				this.bounds = (Bounds)bounds.m_Center;
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74715C", Offset = "0x74715C")]
		[Token(Token = "0x6000247")]
		[Address(RVA = "0xE43EE8", Offset = "0xE43EE8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB19B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024741]) = v38;\nL_0016:\n\tv42 = new Obi.ObiDistanceField+<Generate>d__21();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator Generate()
		{
			_003CGenerate_003Ed__21 _003CGenerate_003Ed__22 = null;
			_003CGenerate_003Ed__22._003C_003E1__state = 0;
			_003CGenerate_003Ed__22._003C_003E4__this = this;
			return _003CGenerate_003Ed__22;
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0xE43F88", Offset = "0xE43F88", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv52 = *([1ECCCA8]);\n\tv53 = *([v52 @ X8_v41]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, size, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([2024742]) = v71;\nL_0025:\n\tv73 = this.nodes == 0;\n\tif (v73) goto L_FFFFFFFF;\n\t// 43 NewArr v78 @ X0_v5 (System.Single[]), typeof(System.Single[]), 3\n\tv80 = this + 0x24;\n\tv84 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v680, v67, v68);\n\tv357 = v78.Length == 0;\n\tif (v357) goto L_0178;\n\tv78[0] = v61;\n\tv463 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v680, v67, v68);\n\tv500 = v78.Length < 1;\n\tv489 = ~v500;\n\tv486 = v78.Length - 1;\n\tv480 = v486 == 0;\n\tv501 = ~v489;\n\tv466 = v501 | v480;\n\tif (v466) goto L_0178;\n\tv78[1] = v62;\n\tv495 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v680, v67, v68);\n\tv503 = v78.Length < 2;\n\tv490 = ~v503;\n\tv487 = v78.Length - 2;\n\tv481 = v487 == 0;\n\tv504 = ~v490;\n\tv467 = v504 | v481;\n\tif (v467) goto L_0178;\n\tv78[2] = v63;\n\tgoto L_0067;\n\tv511 = *([v507 @ X0_v18+E0]);\n\tv512 = v511 == 0;\n\tv513 = ~v512;\n\tif (v513) goto L_0067;\n\tv515 = \"il2cpp_codegen_runtime_class_init\"(v507, v493, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_0067:\n\tv520 = UnityEngine.Mathf::Max(v78);\n\tv524 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v520, v62, v63, v64, v65, v680, v67, v68);\n\tv528 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v520, v62, v63, v64, v65, v680, v67, v68);\n\tv532 = 0x100E390(v80, 0, methodInfo, v56, v57, v58, v59, v60, v520, v62, v63, v64, v65, v680, v67, v68);\n\tv537 = new UnityEngine.Texture3D();\n\tUnityEngine.Texture3D::.ctor(v537, size, size, size, 1, 0);\n\tv542 = size * size;\n\tv543 = v542 * size;\n\t// 134 NewArr v544 @ X0_v30 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v543 @ X1_v14 (System.Int32)\n\tv546 = UnityEngine.Color::get_black();\n\tv560 = size < 1;\n\tif (v560) goto L_015B;\n\tv569 = v62 / size;\n\tv393 = v520 / size;\n\tv570 = v63 / size;\n\tv571 = v569 * 0.5f;\n\tv572 = v570 * 0.5f;\n\tv573 = v520 * -0.1f;\n\tv574 = v520 * 0.1f;\n\tv377 = v393 * 0.5f;\nL_00B9:\n\tv630 = v570 * v379;\n\tv420 = v572 + v630;\nL_00BF:\n\tv676 = v569 * v359;\n\tv422 = v571 + v676;\nL_00C4:\n\tv715 = 0x100E4C4(v80, 0, size, size, 1, 0, 0, v60, v690, v687, v686, v685, v684, v680, v67, v68);\n\tv718 = v393 * v448;\n\tv719 = v377 + v718;\n\tv369 = 0;\n\tv724 = 0x1586898(&v369 @ stack_-B0_v8, 0, size, size, 1, 0, 0, v60, v719, v422, v420, v685, v684, v680, v67, v68);\n\tgoto L_00E3;\n\tv729 = *([v725 @ X0_v42+E0]);\n\tv730 = v729 == 0;\n\tv731 = ~v730;\n\tgoto L_00E3;\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v725, v723, v417, v165, v169, v163, v161, v60, v719, v721, v722, v685, v684, v680, v67, v68);\nL_00E3:\n\t// 227 MakeStruct v365 @ AGGE44224_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v690 @ V0_v18 (System.Single), v687 @ V1_v13 (System.Single), v686 @ V2_v9 (System.Single)\n\t// 228 MakeStruct v363 @ AGGE44224_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v738 @ stack_-AC, 0\n\tv743 = UnityEngine.Vector3::op_Addition(v365, v363);\n\tv779 = Oni::SampleDistanceField(this.oniDistanceField, v743, v743.y, v743.z);\n\tv430 = v779 >= 0;\n\tif (v430) goto L_0109;\n\tgoto L_FFFFFFFF;\n\tv755 = *([v748 @ X0_v46+E0]);\n\tv756 = v755 == 0;\n\tv757 = ~v756;\n\tif (v757) goto L_FFFFFFFF;\n\tv759 = \"il2cpp_codegen_runtime_class_init\"(v748, v450, v417, v165, v169, v163, v161, v60, v747, v744, v745, v736, v737, v367, v67, v68);\n\tgoto L_0115;\nL_0109:\n\tgoto L_FFFFFFFF;\n\tv767 = *([v748 @ X0_v46+E0]);\n\tv768 = v767 == 0;\n\tv769 = ~v768;\n\tif (v769) goto L_FFFFFFFF;\n\tv771 = \"il2cpp_codegen_runtime_class_init\"(v748, v450, v417, v165, v169, v163, v161, v60, v747, v744, v745, v736, v737, v367, v67, v68);\nL_0115:\n\tv690 = Obi.ObiUtils::Remap(v779, v410, v686, v685, v684);\n\tv498 = v381 + v448;\n\tv782 = v498 < v544.Length;\n\tv491 = ~v782;\n\tif (v491) goto L_0178;\n\tv578 = v498 << 4;\n\tv593 = v544 + v578;\n\tv448 = v448 + 1;\n\t*([v593 @ X8_v32+20]) = v546;\n\tv544[v498 @ X8_v30 (System.Int32)].a = v690;\n\tv544[v498 @ X8_v30 (System.Int32)].g = v546.g;\n\tv544[v498 @ X8_v30 (System.Int32)].b = v546.b;\n\tv692 = v448 < size;\n\tif (v692) goto L_00C4;\n\tv359 = v359 + 1;\n\tv381 = v381 + v448;\n\tv651 = v359 < size;\n\tif (v651) goto L_00BF;\n\tv379 = v379 + 1;\n\tv582 = v379 < size;\n\tif (v582) goto L_00B9;\nL_015B:\n\tUnityEngine.Texture3D::SetPixels(v537, v544);\n\tUnityEngine.Texture3D::Apply(v537);\n\tgoto L_0177;\nL_0177:\n\treturn v215;\nL_0178:\n\tv499 = new System.IndexOutOfRangeException();\n\tthrow v499;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 262 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Texture3D GetVolumeTexture(int size)
		{
			//IL_001f: Expected O, but got I
			//IL_0064: Expected F4, but got O
			//IL_009f: Expected O, but got I4
			//IL_00e6: Expected F4, but got O
			//IL_0121: Expected O, but got I4
			//IL_0168: Expected F4, but got O
			//IL_05f1: Expected O, but got I4
			//IL_0319: Expected F4, but got O
			//IL_0435: Expected O, but got I
			Texture3D texture3D;
			Color[] array2;
			if (nodes != null)
			{
				float[] array = new float[3];
				object obj = (long)(IntPtr)this + 36L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
				if (array.Length != 0)
				{
					object obj2 = default(object);
					array[0] = (float)obj2;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj3 = array.Length - 1;
					bool flag3 = obj3 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						object obj4 = default(object);
						array[1] = (float)obj4;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
						bool flag5 = array.Length < 2;
						bool flag6 = !flag5;
						object obj5 = array.Length - 2;
						bool flag7 = obj5 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							object obj6 = default(object);
							array[2] = (float)obj6;
							float num = Mathf.Max(array);
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E390 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x2C8)");
							texture3D = new Texture3D(size, size, size, TextureFormat.Alpha8, mipChain: false);
							int num2 = size * size;
							int num3 = num2 * size;
							array2 = new Color[num3];
							Color black = Color.black;
							if (size < 1)
							{
								goto IL_0539;
							}
							int num4 = (int)((long)(IntPtr)obj4 / (long)size);
							float num5 = num / (float)size;
							int num6 = (int)((long)(IntPtr)obj6 / (long)size);
							float num7 = (float)num4 * 0.5f;
							float num8 = (float)num6 * 0.5f;
							float num9 = num * -0.1f;
							float num10 = num * 0.1f;
							float num11 = num5 * 0.5f;
							int num12 = 0;
							int num13 = 0;
							float num14 = num7;
							float num15 = 0.5f;
							float num16 = 0.1f;
							Vector3 vector = default(Vector3);
							Vector3 vector2 = default(Vector3);
							object obj8 = default(object);
							while (true)
							{
								int num17 = num6 * num12;
								float num18 = num8 + (float)num17;
								int num19 = 0;
								int num29;
								while (true)
								{
									int num20 = num4 * num19;
									float num21 = num7 + (float)num20;
									float y = num7;
									float num22 = num20;
									int num23 = 0;
									while (true)
									{
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
										float num24 = num5 * (float)num23;
										float num25 = num11 + num24;
										object obj7 = 0;
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
										vector.x = num22;
										vector.y = y;
										vector.z = num16;
										vector2.x = 0f;
										vector2.y = (float)obj8;
										vector2.z = 0f;
										Vector3 vector3 = vector + vector2;
										float num26 = Oni.SampleDistanceField(OniDistanceField, vector3.x, vector3.y, vector3.z);
										float from;
										if (num26 < 0f)
										{
											num14 = 0.5f;
											num15 = 0f;
											num16 = 0f;
											from = num9;
										}
										else
										{
											num14 = 1f;
											num15 = 0.5f;
											num16 = num10;
											from = 0f;
										}
										num22 = num26.Remap(from, num16, num15, num14);
										int num27 = num13 + num23;
										if (num27 >= array2.Length)
										{
											break;
										}
										int num28 = num27 << 4;
										object obj9 = (long)(IntPtr)array2 + (long)num28;
										num23++;
										array2[num27].a = num22;
										array2[num27].g = black.g;
										array2[num27].b = black.b;
										bool flag9 = num23 < size;
										num29 = 0;
										y = black.g;
										if (flag9)
										{
											continue;
										}
										goto IL_04c6;
									}
									break;
									IL_04c6:
									num19++;
									num13 += num23;
									bool flag10 = num19 < size;
									num29 = 0;
									if (flag10)
									{
										continue;
									}
									goto IL_0506;
								}
								break;
								IL_0506:
								num12++;
								bool flag11 = num12 < size;
								num29 = 0;
								if (flag11)
								{
									continue;
								}
								goto IL_0539;
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return null;
			IL_0539:
			texture3D.SetPixels(array2);
			texture3D.Apply();
			return texture3D;
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xE4436C", Offset = "0xE4436C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxError = 0.01f;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiDistanceField()
		{
			maxError = 0.01f;
		}
	}
}
