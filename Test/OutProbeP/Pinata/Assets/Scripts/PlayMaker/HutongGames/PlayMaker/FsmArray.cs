using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000053")]
	public class FsmArray : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x38")]
		internal VariableType type;

		[SerializeField]
		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x40")]
		private string objectTypeName;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x48")]
		private Type objectType;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x50")]
		public float[] floatValues;

		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x58")]
		public int[] intValues;

		[Token(Token = "0x4000158")]
		[FieldOffset(Offset = "0x60")]
		public bool[] boolValues;

		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x68")]
		public string[] stringValues;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x70")]
		public Vector4[] vector4Values;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x78")]
		public UnityEngine.Object[] objectReferences;

		[NonSerialized]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x80")]
		private Array sourceArray;

		[NonSerialized]
		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x88")]
		internal object[] values;

		[Token(Token = "0x17000060")]
		public override object RawValue
		{
			[Token(Token = "0x6000187")]
			[Address(RVA = "0xCA1B04", Offset = "0xCA1B04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.values;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return values;
			}
			[Token(Token = "0x6000188")]
			[Address(RVA = "0xCA1B0C", Offset = "0xCA1B0C", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F074E0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023522]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\t// 28 IsInst v60 @ X0_v2 (System.Object[]), typeof(System.Object[]), value @ X1 (System.Object)\n\tv58 = v60 == 0;\n\tv54 = ~v58;\n\tif (v54) goto L_0024;\n\tthrow System.InvalidCastException;\nL_0024:\n\tthis.values = v60;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				object[] array;
				if (value != null)
				{
					array = value as object[];
					if (array == null)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					array = null;
				}
				values = array;
			}
		}

		[Token(Token = "0x17000061")]
		public override Type ObjectType
		{
			[Token(Token = "0x6000189")]
			[Address(RVA = "0xCA1B8C", Offset = "0xCA1B8C", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.objectType;\n\tv11 = this.objectType == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tHutongGames.PlayMaker.FsmArray::InitObjectType(this);\n\treturnVal1 = this.objectType;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type result = objectType;
				if ((object)objectType == null)
				{
					Init();
					result = objectType;
				}
				return result;
			}
			[Token(Token = "0x600018A")]
			[Address(RVA = "0xCA1D28", Offset = "0xCA1D28", Length = "0x1A8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F01430]);\n\tv27 = *([v26 @ X8_v35]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023523]) = v45;\nL_0017:\n\tv51 = this.objectType;\n\tv47 = this.objectType == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0022;\n\tHutongGames.PlayMaker.FsmArray::InitObjectType(this);\n\tv51 = this.objectType;\nL_0022:\n\tv57 = v51 == value;\n\tif (v57) goto L_00A1;\n\tthis.objectTypeName = 0;\n\tthis.boolValues = 0;\n\tthis.vector4Values = 0;\n\tthis.floatValues = 0;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv123 = this.type != 0xE;\n\tif (v123) goto L_0061;\n\tv165 = value == 0;\n\tif (v165) goto L_FFFFFFFF;\n\tv180 = System.Type::get_IsEnum(value);\n\tv182 = v180 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_0086;\nL_004E:\n\tv275 = *([v292 @ X8_v7]);\n\tgoto L_008E;\n\tv327 = *([v323 @ X0_v24+E0]);\n\tv332 = v327 == 0;\n\tv326 = ~v332;\n\tgoto L_008E;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v323, v311, v308, v30, v31, v32, v33, v34, v62, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_008E;\nL_0061:\n\tv175 = this.type != 0xC;\n\tif (v175) goto L_0084;\n\tv199 = value == 0;\n\tif (v199) goto L_FFFFFFFF;\n\tgoto L_0076;\n\tv298 = *([v195 @ X0_v17+E0]);\n\tv299 = v298 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_0076;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v195, value, methodInfo, v30, v31, v32, v33, v34, v62, v36, v37, v38, v39, v40, v41, v42);\nL_0076:\n\tv307 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv218 = System.Type::IsAssignableFrom(v307, value);\n\tv335 = v218 == 0;\n\tv220 = ~v335;\n\tif (v220) goto L_0086;\n\tgoto L_FFFFFFFF;\nL_0084:\n\tv200 = value == 0;\n\tif (v200) goto L_FFFFFFFF;\nL_0086:\n\tthis.objectType = value;\n\tgoto L_0097;\n\tgoto L_008E;\nL_008E:\n\tv270 = System.Type::GetTypeFromHandle(v275);\n\tthis.objectType = v270;\nL_0097:\n\tv97 = System.Type::get_FullName(v101);\n\tthis.objectTypeName = v97;\nL_00A1:\n\treturn;\n\tgoto L_004E;\n\tthrow System.NullReferenceException;\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_022f: Expected I, but got O
				//IL_0187: Expected I, but got O
				//IL_0195: Expected O, but got I
				Type type = objectType;
				if ((object)objectType == null)
				{
					Init();
					type = objectType;
				}
				if ((object)type == value)
				{
					return;
				}
				objectTypeName = null;
				boolValues = null;
				vector4Values = null;
				floatValues = null;
				Init();
				IntPtr intPtr;
				object typeFromHandle2;
				if (TypeConstraint == VariableType.Enum)
				{
					if ((object)value == null || !value.IsEnum)
					{
						goto IL_0214;
					}
				}
				else if (TypeConstraint == VariableType.Object)
				{
					if ((object)value == null)
					{
						intPtr = (IntPtr)typeof(UnityEngine.Object);
						goto IL_018c;
					}
					Type typeFromHandle = typeof(UnityEngine.Object);
					if (!typeFromHandle.IsAssignableFrom(value))
					{
						goto IL_0214;
					}
				}
				else if ((object)value == null)
				{
					typeFromHandle2 = typeof(UnityEngine.Object);
					goto IL_0227;
				}
				objectType = value;
				Type type2 = value;
				goto IL_01b0;
				IL_01b0:
				string fullName = type2.FullName;
				objectTypeName = fullName;
				return;
				IL_0214:
				typeFromHandle2 = typeof(None);
				goto IL_0227;
				IL_018c:
				type2 = (objectType = Type.GetTypeFromHandle((RuntimeTypeHandle)(long)intPtr));
				goto IL_01b0;
				IL_0227:
				intPtr = (IntPtr)typeFromHandle2;
				goto IL_018c;
			}
		}

		[Token(Token = "0x17000062")]
		public string ObjectTypeName
		{
			[Token(Token = "0x600018C")]
			[Address(RVA = "0xCA1EE0", Offset = "0xCA1EE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.objectTypeName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ObjectTypeName;
			}
		}

		[Token(Token = "0x17000063")]
		public object[] Values
		{
			[Token(Token = "0x600018D")]
			[Address(RVA = "0xCA1EE8", Offset = "0xCA1EE8", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.values;\n\tv11 = this.values == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\treturnVal1 = this.values;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				object[] result = values;
				if (values == null)
				{
					Init();
					result = values;
				}
				return result;
			}
			[Token(Token = "0x600018E")]
			[Address(RVA = "0xCA202C", Offset = "0xCA202C", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.values = value;\n\tv12 = UnityEngine.Application::get_isEditor();\n\tv14 = v12 == 0;\n\tif (v14) goto L_0017;\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this);\n\treturn;\nL_0017:\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				values = value;
				if (Application.isEditor)
				{
					SaveChanges();
				}
			}
		}

		[Token(Token = "0x17000064")]
		public int Length
		{
			[Token(Token = "0x600018F")]
			[Address(RVA = "0xCA2140", Offset = "0xCA2140", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.values;\n\tv11 = this.values == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0014;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv18 = this.values;\nL_0014:\n\treturn v18.Length;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				object[] array = values;
				if (values == null)
				{
					Init();
					array = values;
				}
				return array.Length;
			}
		}

		[Token(Token = "0x17000065")]
		public override VariableType TypeConstraint
		{
			[Token(Token = "0x6000190")]
			[Address(RVA = "0xCA2180", Offset = "0xCA2180", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TypeConstraint;
			}
		}

		[Token(Token = "0x17000066")]
		public VariableType ElementType
		{
			[Token(Token = "0x6000191")]
			[Address(RVA = "0xCA2188", Offset = "0xCA2188", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TypeConstraint;
			}
			[Token(Token = "0x6000192")]
			[Address(RVA = "0xCA2190", Offset = "0xCA2190", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmArray::SetType(this, value);\n\treturn;\n")]
			set
			{
				SetType(value);
			}
		}

		[Token(Token = "0x17000067")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0xCA353C", Offset = "0xCA353C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xD;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Array;
			}
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0xCA1BBC", Offset = "0xCA1BBC", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F03588]);\n\tv19 = *([v18 @ X8_v36]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023524]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(this.objectTypeName);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0042;\n\tv56 = this.type > 9;\n\tif (v56) goto L_0048;\n\tv62 = this.type == 3;\n\tif (v62) goto L_FFFFFFFF;\n\tv133 = this.type != 9;\n\tif (v133) goto L_FFFFFFFF;\n\tgoto L_0074;\nL_0042:\n\tv116 = this.objectTypeName;\n\tgoto L_008B;\nL_0048:\n\tv71 = this.type == 0xA;\n\tif (v71) goto L_FFFFFFFF;\n\tv148 = this.type != 0xE;\n\tif (v148) goto L_FFFFFFFF;\n\tgoto L_0074;\n\tgoto L_0074;\n\tgoto L_0074;\nL_0074:\n\tgoto L_007C;\n\tv198 = *([v183 @ X0_v10+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_007C;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v183, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007C:\n\tv207 = System.Type::GetTypeFromHandle(*([v185 @ X8_v10]));\n\tv111 = System.Type::get_FullName(v207);\n\tthis.objectTypeName = v111;\nL_008B:\n\tgoto L_0093;\n\tv154 = *([v120 @ X0_v5+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tgoto L_0093;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v120, v79, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0093:\n\tv163 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v116);\n\tthis.objectType = v163;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitObjectType()
		{
			object typeFromHandle;
			if (string.IsNullOrEmpty(ObjectTypeName))
			{
				if (TypeConstraint <= VariableType.Material)
				{
					if (TypeConstraint != VariableType.GameObject)
					{
						if (TypeConstraint != VariableType.Material)
						{
							goto IL_0101;
						}
						typeFromHandle = typeof(Material);
					}
					else
					{
						typeFromHandle = typeof(GameObject);
					}
				}
				else if (TypeConstraint != VariableType.Texture)
				{
					if (TypeConstraint != VariableType.Enum)
					{
						goto IL_0101;
					}
					typeFromHandle = typeof(None);
				}
				else
				{
					typeFromHandle = typeof(Texture);
				}
				goto IL_0114;
			}
			string typeName = ObjectTypeName;
			goto IL_014a;
			IL_0101:
			typeFromHandle = typeof(UnityEngine.Object);
			goto IL_0114;
			IL_0114:
			Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeFromHandle);
			typeName = (objectTypeName = typeFromHandle2.FullName);
			goto IL_014a;
			IL_014a:
			Type globalType = ReflectionUtils.GetGlobalType(typeName);
			objectType = globalType;
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xCA1F18", Offset = "0xCA1F18", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ED6BB0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023525]) = v42;\nL_0016:\n\tv44 = HutongGames.PlayMaker.FsmArray::GetSourceArray(this);\n\tthis.sourceArray = v44;\n\tv45 = v44 == 0;\n\tif (v45) goto L_0058;\n\tv47 = System.Array::get_Length(v44);\n\t// 33 NewArr v102 @ X0_v10 (System.Object[]), typeof(System.Object[]), v47 @ X0_v8 (System.Int32)\n\tthis.values = v102;\nL_0031:\n\tv106 = v128 >= v138.Length;\n\tif (v106) goto L_0061;\n\tv211 = HutongGames.PlayMaker.FsmArray::Load(this, v128);\n\tv212 = v211 == 0;\n\tif (v212) goto L_0040;\n\t// 60 IsInst v216 @ X0_v22, typeof(System.Object), v211 @ X0_v16 (System.Object)\nL_0040:\n\tv221 = v128 < v138.Length;\n\tv154 = ~v221;\n\tif (v154) goto L_0062;\n\tv138[v128 @ X21_v6 (System.Int32)] = v211;\n\tv138 = this.values;\n\tv128 = v128 + 1;\n\tv222 = this.values == 0;\n\tv160 = ~v222;\n\tif (v160) goto L_0031;\n\tthrow System.NullReferenceException;\nL_0058:\n\t// 88 NewArr v96 @ X0_v7 (System.Object[]), typeof(System.Object[]), 0\n\tthis.values = v96;\nL_0061:\n\treturn;\nL_0062:\n\tv223 = new System.IndexOutOfRangeException();\n\tgoto L_0067;\n\tv224 = new System.ArrayTypeMismatchException();\nL_0067:\n\tthrow v226;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitArray()
		{
			Array array = (sourceArray = GetSourceArray());
			if (array != null)
			{
				int length = array.Length;
				object[] array2 = (values = new object[length]);
				int num = 0;
				object[] array3 = array2;
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				while (num < array3.Length)
				{
					object obj = Load(num);
					if (obj != null)
					{
						object obj2 = obj as object;
					}
					if (num < array3.Length)
					{
						array3[num] = obj;
						array3 = values;
						num++;
						if (values == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
			}
			else
			{
				object[] array4 = new object[0];
				values = array4;
			}
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xCA2838", Offset = "0xCA2838", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\treturn;\n")]
		public override void Init()
		{
			Init();
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xCA283C", Offset = "0xCA283C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.values;\n\tv15 = this.values == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0012;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv21 = this.values;\nL_0012:\n\tv24 = v21.Length < index;\n\tv25 = ~v24;\n\tv26 = v21.Length - index;\n\tv28 = v26 == 0;\n\tv33 = ~v25;\n\tv34 = v33 | v28;\n\tif (v34) goto L_0027;\n\treturn v21[index @ X1 (System.Int32)];\nL_0027:\n\tv42 = new System.IndexOutOfRangeException();\n\tthrow v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object Get(int index)
		{
			object[] array = values;
			if (values == null)
			{
				Init();
				array = values;
			}
			bool flag = array.Length < index;
			bool flag2 = !flag;
			int num = array.Length - index;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				return array[index];
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xCA28A0", Offset = "0xCA28A0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = this.values;\n\tv21 = this.values == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_0014;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv27 = this.values;\nL_0014:\n\tv29 = value == 0;\n\tif (v29) goto L_001D;\n\t// 25 IsInst v33 @ X0_v13, typeof(System.Object), value @ X2 (System.Object)\nL_001D:\n\tv54 = v27.Length < index;\n\tv55 = ~v54;\n\tv56 = v27.Length - index;\n\tv58 = v56 == 0;\n\tv63 = ~v55;\n\tv64 = v63 | v58;\n\tif (v64) goto L_0045;\n\tv27[index @ X1 (System.Int32)] = value;\n\tv108 = UnityEngine.Application::get_isEditor();\n\tv112 = v108 == 0;\n\tif (v112) goto L_0044;\n\tHutongGames.PlayMaker.FsmArray::Save(this, index, value);\n\treturn;\nL_0044:\n\treturn;\nL_0045:\n\tv109 = new System.IndexOutOfRangeException();\n\tgoto L_004A;\n\tv110 = new System.ArrayTypeMismatchException();\nL_004A:\n\tthrow v151;\n\tthrow System.NullReferenceException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(int index, object value)
		{
			object[] array = values;
			if (values == null)
			{
				Init();
				array = values;
			}
			if (value != null)
			{
				object obj = value as object;
			}
			bool flag = array.Length < index;
			bool flag2 = !flag;
			int num = array.Length - index;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[index] = value;
				if (Application.isEditor)
				{
					Save(index, value);
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0xCA23C0", Offset = "0xCA23C0", Length = "0x478")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv21 = *([1EC5508]);\n\tv22 = *([v21 @ X8_v13]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, index, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023526]) = v40;\nL_0016:\n\tv42 = this.type + 1;\n\tv43 = v42 < 0xF;\n\tv44 = ~v43;\n\tv45 = v42 - 0xF;\n\tv47 = v45 == 0;\n\tv52 = ~v47;\n\tv53 = v44 & v52;\n\tif (v53) goto L_01E9;\n\tv55 = 0x181A000 + 0x790;\n\tv58 = *([v55 @ X9_v2 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]) + v55;\n\t// 40 IndirectJump v58 @ X8_v10, 0, 0, index @ X1 (System.Int32), methodInfo @ X2 (Il2CppMethodInfo), v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX8 = *([X20+50]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tX9 = *([1EE1A60]);\n\tgoto L_0054;\n\tX8 = *([X20+58]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tX9 = *([1ED0418]);\nL_0054:\n\tX0 = *([X9]);\n\tstack[10] = X8;\n\tgoto L_006D;\n\tX8 = *([X20+60]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX8 = X8 + X19;\n\tX8 = *([X8+20]);\n\tX9 = *([1EC5410]);\n\tstack[10] = X8;\n\tX0 = *([X9]);\nL_006D:\n\tX1 = &stack[10];\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_01DF;\n\tX8 = *([X20+78]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_01AC;\n\tX9 = *([1EE3A20]);\n\tX10 = *([X8]);\n\tX9 = *([X9]);\n\tgoto L_0153;\n\tX8 = *([X20+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018A;\n\tgoto L_01F3;\n\tX8 = *([X20+70]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX9 = X19;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tV1 = *([X8+24]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[10] = 0;\n\tX0 = 0x1588A6C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = stack[10];\n\tX9 = *([1EFD6E0]);\n\tstack[0] = X8;\n\tX0 = *([X9]);\n\tgoto L_0184;\n\tX8 = *([X20+70]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX9 = X19;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tV1 = *([X8+24]);\n\tV2 = *([X8+28]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[18] = 0;\n\tstack[10] = 0;\n\tX0 = 0x1586898(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = stack[18];\n\tX9 = stack[10];\n\tX10 = *([1EE1550]);\n\tstack[8] = X8;\n\tstack[0] = X9;\n\tX0 = *([X10]);\n\tgoto L_0184;\n\tX8 = *([X20+70]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX9 = X19;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tV1 = *([X8+24]);\n\tV2 = *([X8+28]);\n\tV3 = *([X8+2C]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[10] = 0;\n\tstack[18] = 0;\n\tX0 = 0x101059C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = stack[10];\n\tX8 = *([1EEBF30]);\n\tgoto L_0182;\n\tX8 = *([X20+70]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX9 = X19;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tV1 = *([X8+24]);\n\tV2 = *([X8+28]);\n\tV3 = *([X8+2C]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[10] = 0;\n\tstack[18] = 0;\n\tX0 = 0x10CCF64(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = stack[10];\n\tX8 = *([1ED0550]);\n\tgoto L_0182;\n\tX8 = *([X20+78]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_01AC;\n\tX9 = *([1ECA9D0]);\n\tgoto L_0140;\n\tX8 = *([X20+78]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tif (TEMP) goto L_01AC;\n\tX9 = *([1ED2388]);\nL_0140:\n\tX10 = *([X8]);\n\tX9 = *([X9]);\n\tX12 = *([X10+128]);\n\tX11 = *([X9+128]);\n\tC = X12 < X11;\n\tC = ~C;\n\tTEMP1 = X12 - X11;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X11;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_01AC;\n\tX10 = *([X10+C8]);\n\tTEMPSHIFT = X11 << 3;\n\tX10 = X10 + TEMPSHIFT;\n\tX10 = *([X10-8]);\nL_0153:\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0160;\n\tX0 = X8;\n\tgoto L_0161;\nL_0160:\n\tX0 = 0;\nL_0161:\n\t;\n\tgoto L_01DF;\n\tX8 = *([X20+70]);\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tX9 = X19;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tV0 = *([X8+20]);\n\tV1 = *([X8+24]);\n\tV2 = *([X8+28]);\n\tV3 = *([X8+2C]);\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[10] = 0;\n\tstack[18] = 0;\n\tX0 = 0x10CB640(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = stack[10];\n\tX8 = *([1EC5B90]);\nL_0182:\n\tX0 = *([X8]);\n\tstack[0] = V0;\nL_0184:\n\tX1 = &stack[0];\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_01DF;\n\tX8 = *([X20+78]);\n\tif (TEMP) goto L_01F3;\nL_018A:\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 3;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = *([X8+20]);\n\tgoto L_01DF;\n\tX8 = *([1EBC820]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01A7;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A7;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A7:\n\tX8 = 0x1F04000;\n\tX8 = *([1F042B8]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tUnityEngine.Debug::LogError(X0, X1);\nL_01AC:\n\tX0 = 0;\n\tgoto L_01DF;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+2A0]);\n\tX1 = *([X8+2A8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20+58]);\n\tX20 = X0;\n\tif (TEMP) goto L_01F3;\n\tX9 = *([X8+18]);\n\tC = X9 < X19;\n\tC = ~C;\n\tTEMP1 = X9 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X19;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01F5;\n\tTEMPSHIFT = X19 << 2;\n\tX\n// ... truncated")]
		private object Load(int index)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(TypeConstraint + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 1936;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X9_v2 (System.Int32)+v42 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X8_v10 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0xCA2958", Offset = "0xCA2958", Length = "0x6E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv31 = *([1EE7DA0]);\n\tv32 = *([v31 @ X8_v12]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, index, value, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023527]) = v49;\nL_001F:\n\tv55 = v47.type + 1;\n\tv56 = v55 < 0xF;\n\tv57 = ~v56;\n\tv58 = v55 - 0xF;\n\tv60 = v58 == 0;\n\tv65 = ~v60;\n\tv66 = v57 & v65;\n\tif (v66) goto L_02F8;\n\tv68 = 0x181A000 + 0x7D0;\n\tv70 = *([v68 @ X9_v2 (System.Int32)+v55 @ X8_v4 (System.Int32)*4]) + v68;\n\t// 48 IndirectJump v70 @ X8_v10, v47 @ X0_v1 (HutongGames.PlayMaker.FsmArray), v47 @ X0_v1 (HutongGames.PlayMaker.FsmArray), index @ X1 (System.Int32), value @ X2 (System.Object), methodInfo @ X3 (Il2CppMethodInfo), v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\tX21 = *([X21+50]);\n\tif (TEMP) goto L_01EF;\n\tX8 = *([1EE1A60]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0308;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01F2;\n\tgoto L_0302;\n\tX21 = *([X21+58]);\n\tif (TEMP) goto L_0203;\n\tX8 = *([1ED0418]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0308;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0206;\n\tgoto L_0302;\n\tX21 = *([X21+60]);\n\tif (TEMP) goto L_0217;\n\tX8 = *([1EC5410]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0308;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_021A;\n\tgoto L_0302;\n\tX21 = *([X21+78]);\n\tif (TEMP) goto L_0302;\n\tif (TEMP) goto L_01DD;\n\tX22 = *([1EE3A20]);\n\tgoto L_0091;\n\tX21 = *([X21+68]);\n\tif (TEMP) goto L_0302;\n\tif (TEMP) goto L_01DD;\n\tX22 = *([1EB3EF8]);\nL_0091:\n\tX8 = *([X22]);\n\tX9 = *([X20]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00A4;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_030D;\nL_00A4:\n\tX8 = *([X22]);\n\tX9 = *([X20]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_00B3;\n\tX8 = X20;\n\tgoto L_00B4;\nL_00B3:\n\tX8 = 0;\nL_00B4:\n\t;\n\tgoto L_01DE;\n\tX21 = *([X21+70]);\n\tX8 = *([1EFD6E0]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_022A;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_030C;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV8 = *([X0]);\n\tV9 = *([X0+4]);\n\tgoto L_0239;\n\tX21 = *([X21+70]);\n\tX8 = *([1EE1550]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_0251;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_030C;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV8 = *([X0]);\n\tV9 = *([X0+4]);\n\tV10 = *([X0+8]);\n\tgoto L_0262;\n\tX21 = *([X21+70]);\n\tif (TEMP) goto L_027B;\n\tX8 = *([1EEBF30]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0308;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tV2 = *([X0+8]);\n\tV3 = *([X0+C]);\n\tgoto L_0280;\n\tif (TEMP) goto L_029D;\n\tX8 = *([1ED0550]);\n\tX9 = *([X20]);\n\tX1 = *([X8]);\n\tX8 = *([X9+40]);\n\tX9 = *([X1+40]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0308;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tgoto L_02A7;\n\tX21 = *([X21+78]);\n\tif (TEMP) goto L_0302;\n\tif (TEMP) goto L_0181;\n\tX22 = *([1ECA9D0]);\n\tgoto L_014C;\n\tX21 = *([X21+78]);\n\tif (TEMP) goto L_0302;\n\tif (TEMP) goto L_0181;\n\tX22 = *([1ED2388]);\n\tgoto L_014C;\n\tX8 = *([1EC5B90]);\n\tX8 = *([X8]);\n\tif (TEMP) goto L_02C2;\n\tX9 = *([X20]);\n\tX10 = *([X8+40]);\n\tX9 = *([X9+40]);\n\tC = X9 < X10;\n\tC = ~C;\n\tTEMP1 = X9 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X10;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_030C;\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X0]);\n\tV1 = *([X0+4]);\n\tV2 = *([X0+8]);\n\tV3 = *([X0+C]);\n\tgoto L_02D1;\n\tX21 = *([X21+78]);\n\tif (TEMP) goto L_0302;\n\tif (TEMP) goto L_0181;\n\tX22 = *([1EAB010]);\nL_014C:\n\tX9 = *([X20]);\n\tX8 = *([X22]);\n\tX11 = *([X9+128]);\n\tX10 = *([X8+128]);\n\tC = X11 < X10;\n\tC = ~C;\n\tTEMP1 = X11 - X10;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X10;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_0171;\n\tX9 = *([X9+C8]);\n\tTEMPSHIFT = X10 << 3;\n\tX9 = X9 + TEMPSHIFT;\n\tX9 = *([X9-8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0171;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_030D;\n\tX8 = *([X22]);\nL_0171:\n\tX10 = *([X20]);\n\tX11 = *([X8+128]);\n\tX9 = *([X10+128]);\n\tC = X9 < X11;\n\tC = ~C;\n\tTEMP1 = X9 - X11;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X11;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X19;\n\tif (C) goto L_01B9;\n\tX8 = 0;\n\tgoto L_01CC;\nL_0181:\n\tX8 = 0;\n\tX9 = X19;\n\tgoto L_01CC;\n\tX8 = *([1EBC820]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0190;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0190;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0190:\n\tX8 = 0x1F04000;\n\tX8 = *([1F042B8]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tUnityEngine.Debug::LogError(X0, X1);\n\tgoto L_02EA;\n\tX8 = *([1F0DC70]);\n\tX21 = *([X21+58]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01A3;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A3;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A3:\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = System.Convert::ToInt32(X0, X1);\n\tif (TEMP) goto L_0302;\n\tX8 = *([X21+18]);\n\tC = X8 < X19;\n\tC = ~C;\n\tTEMP1 = X8 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X19;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_0304;\n\tTEMPSHIFT = X19 << 2;\n\tX8 = X21 + TEMPSHIFT;\n\t*([X8+20]) = X0;\n\tgoto L_02EA;\nL_01B9:\n\tX10 = *([X10+C8]);\n\tTEMPSHIFT = X11 << 3;\n\tX10 = X10 + TEMPSHIFT;\n\tX10 = *([X10-8]);\n\tC = X10 < X8;\n\tC = ~C;\n\tTEMP1 = X10 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X8;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01CA;\n\tX8 = X20;\n\tgoto L_01CB;\nL_01CA:\n\tX8 = 0;\nL_01CB:\n\t;\nL_01CC:\n\tX10 = *([X21+18]);\n\tC = X10 < X19;\n\tC = ~C;\n\tTEMP1 = X10 - X19;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X19;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 =\n// ... truncated")]
		private void Save(int index, object value)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(TypeConstraint + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2000;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X9_v2 (System.Int32)+v55 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v70 @ X8_v10 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0xCA2194", Offset = "0xCA2194", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.type != newType;\n\tif (v21) goto L_0018;\n\treturn;\nL_0018:\n\tthis.type = newType;\n\tv30 = HutongGames.PlayMaker.FsmArray::set_ObjectType(this, 0);\n\tthis.boolValues = 0;\n\tthis.vector4Values = 0;\n\tthis.objectTypeName = 0;\n\tthis.floatValues = 0;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tHutongGames.PlayMaker.FsmArray::ConformSourceArraySize(this);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetType(VariableType newType)
		{
			if (TypeConstraint != newType)
			{
				type = newType;
				ObjectType = null;
				boolValues = null;
				vector4Values = null;
				objectTypeName = null;
				floatValues = null;
				Init();
				ConformSourceArraySize();
			}
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0xCA2068", Offset = "0xCA2068", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmArray::ConformSourceArraySize(this);\n\tv121 = this.values;\nL_0019:\n\tv23 = v81 >= v121.Length;\n\tif (v23) goto L_0058;\n\tv158 = v81 < v121.Length;\n\tv78 = ~v158;\n\tif (v78) goto L_0059;\n\tHutongGames.PlayMaker.FsmArray::Save(this, v81, v121[v81 @ X20_v5 (System.Int32)]);\n\tv31 = this.values;\n\tv37 = HutongGames.PlayMaker.FsmArray::Load(this, v81);\n\tv229 = v37 == 0;\n\tif (v229) goto L_003C;\n\t// 56 IsInst v231 @ X0_v15, typeof(System.Object), v37 @ X0_v12 (System.Object)\nL_003C:\n\tv233 = v81 < v31.Length;\n\tv76 = ~v233;\n\tif (v76) goto L_0059;\n\tv31[v81 @ X20_v5 (System.Int32)] = v37;\n\tv121 = this.values;\n\tv81 = v81 + 1;\n\tv235 = this.values == 0;\n\tv83 = ~v235;\n\tif (v83) goto L_0019;\n\tthrow System.NullReferenceException;\nL_0058:\n\treturn;\nL_0059:\n\tv220 = new System.IndexOutOfRangeException();\n\tgoto L_005E;\n\tv225 = new System.ArrayTypeMismatchException();\nL_005E:\n\tthrow v224;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveChanges()
		{
			ConformSourceArraySize();
			object[] array = values;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (num >= array.Length)
					{
						break;
					}
					Save(num, array[num]);
					object[] array2 = values;
					object obj = Load(num);
					if (obj != null)
					{
						object obj2 = obj as object;
					}
					if (num >= array2.Length)
					{
						break;
					}
					array2[num] = obj;
					array = values;
					num++;
					if (values == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0xCA3214", Offset = "0xCA3214", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = source == 0;\n\tif (v16) goto L_0054;\n\tv18 = HutongGames.PlayMaker.FsmArray::get_Length(source);\n\tHutongGames.PlayMaker.FsmArray::Resize(this, v18);\n\tv99 = source.values;\n\tv96 = source.values == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0019;\n\tHutongGames.PlayMaker.FsmArray::InitArray(source);\n\tv99 = source.values;\nL_0019:\n\tv144 = v99.Length;\n\tv114 = v99.Length < 1;\n\tif (v114) goto L_004C;\nL_0027:\n\tv174 = v148 < v144;\n\tv143 = ~v174;\n\tif (v143) goto L_0055;\n\tHutongGames.PlayMaker.FsmArray::Set(this, v148, v99[v148 @ X20_v7 (System.Int32)]);\n\tv144 = v99.Length;\n\tv132 = v148 + 1;\n\tv118 = v132 < v99.Length;\n\tif (v118) goto L_0027;\nL_004C:\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this);\n\treturn;\nL_0054:\n\treturn;\nL_0055:\n\tv176 = new System.IndexOutOfRangeException();\n\tthrow v176;\n\tthrow System.NullReferenceException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyValues(FsmArray source)
		{
			if (source == null)
			{
				return;
			}
			int length = source.Length;
			Resize(length);
			object[] array = source.values;
			if (source.values == null)
			{
				source.Init();
				array = source.values;
			}
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				bool flag;
				do
				{
					if (num2 < num)
					{
						Set(num2, array[num2]);
						num = array.Length;
						int num3 = num2 + 1;
						flag = num3 < array.Length;
						num2 = num3;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag);
			}
			SaveChanges();
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0xCA3040", Offset = "0xCA3040", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv17 = *([1F09E60]);\n\tv18 = *([v17 @ X8_v13]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([2023528]) = v37;\nL_0014:\n\tv39 = v35.type + 1;\n\tv40 = v39 < 0xF;\n\tv41 = ~v40;\n\tv42 = v39 - 0xF;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_008E;\n\tv52 = 0x181A000 + 0x810;\n\tv54 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]) + v52;\n\t// 37 IndirectJump v54 @ X8_v10, v35 @ X0_v1 (HutongGames.PlayMaker.FsmArray), v35 @ X0_v1 (HutongGames.PlayMaker.FsmArray), methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_002F:\n\tX9 = 0x1EF4000;\n\tX9 = *([1EF4CE8]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+70]) = X0;\n\tgoto L_0085;\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_003F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_003F:\n\tX9 = 0x1EF8000;\n\tX9 = *([1EF8570]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+78]) = X0;\n\tgoto L_0085;\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_004F:\n\tX9 = 0x1EF1000;\n\tX9 = *([1EF1CB0]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+58]) = X0;\n\tgoto L_0085;\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_005F:\n\tX9 = 0x1EAD000;\n\tX9 = *([1EAD540]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+50]) = X0;\n\tgoto L_0085;\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_006F:\n\tX9 = 0x1F0A000;\n\tX9 = *([1F0A6A0]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+60]) = X0;\n\tgoto L_0085;\n\tX8 = *([X19+88]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007F;\n\tX0 = X19;\n\tHutongGames.PlayMaker.FsmArray::InitArray(X0, X1);\n\tX8 = *([X19+88]);\n\tif (TEMP) goto L_0098;\nL_007F:\n\tX9 = 0x1ED7000;\n\tX9 = *([1ED7A60]);\n\tX1 = *([X8+18]);\n\tX0 = *([X9]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+68]) = X0;\nL_0085:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 137 ShiftStack 32\n\treturn;\nL_008E:\n\tv58 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v58);\n\tthrow v58;\nL_0098:\n\t;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ConformSourceArraySize()
		{
			//IL_0029: Expected O, but got I
			int num = (int)(TypeConstraint + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2064;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v10 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0xCA21FC", Offset = "0xCA21FC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv17 = *([1EA79D8]);\n\tv18 = *([v17 @ X8_v16]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([2023529]) = v37;\nL_0013:\n\tv38 = this.type;\n\tv39 = this.type + 1;\n\tv40 = v39 < 0xF;\n\tv41 = ~v40;\n\tv42 = v39 - 0xF;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_0073;\n\tv52 = 0x181A000 + 0x750;\n\tv38 = *([v52 @ X8_v12 (System.Int32)+v39 @ X9_v1 (System.Int32)*4]) + v52;\n\t// 38 IndirectJump v38 @ X8_v3 (HutongGames.PlayMaker.VariableType), 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX0 = *([X19+70]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1EF4CE8]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+70]) = X0;\n\tgoto L_0068;\n\tX0 = *([X19+78]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1EF8570]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+78]) = X0;\n\tgoto L_0068;\n\tX0 = *([X19+58]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1EF1CB0]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+58]) = X0;\n\tgoto L_0068;\n\tX0 = *([X19+50]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1EAD540]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+50]) = X0;\n\tgoto L_0068;\n\tX0 = *([X19+60]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1F0A6A0]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+60]) = X0;\n\tgoto L_0068;\n\tX0 = *([X19+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX8 = *([1ED7A60]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+68]) = X0;\nL_0068:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\t// 108 ShiftStack 48\n\treturn X0;\nL_0073:\n\t// 115 Box v61 @ X0_v3 (System.Object), typeof(HutongGames.PlayMaker.VariableType), &v38 @ X8_v3 (HutongGames.PlayMaker.VariableType)\n\tgoto L_0084;\n\tv85 = *([v81 @ X8_v6+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0084;\n\tv92 = v81;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v92, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0084:\n\tUnityEngine.Debug::LogError(v61);\n\tv96 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v96);\n\tthrow v96;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Array GetSourceArray()
		{
			VariableType variableType = TypeConstraint;
			int num = (int)(TypeConstraint + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 1872;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v12 (System.Int32)+v39 @ X9_v1 (System.Int32)*4]");
				variableType = (VariableType)(0L + (long)num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v38 @ X8_v3 (HutongGames.PlayMaker.VariableType) (should have been resolved before IL gen)");
			}
			object message = variableType;
			Debug.LogError(message);
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0xCA32D4", Offset = "0xCA32D4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED0098]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, newLength, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202352A]) = v43;\nL_0017:\n\tv45 = this.values == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0029;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\nL_0029:\n\tv62 = *([v48 @ X0_v8 (System.Object)+18]) != newLength;\n\tif (v62) goto L_0034;\n\treturn;\nL_0034:\n\tv70 = System.Object::GetType(v48);\n\tv159 = ~newLength;\n\tv157 = newLength & v159;\n\tv161 = System.Type::GetElementType(v70);\n\tv153 = System.Array::CreateInstance(v161, v157);\n\tv151 = this.values;\n\tgoto L_0053;\n\tv168 = *([v164 @ X0_v12+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0053;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v164, v150, v149, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0053:\n\tv178 = System.Math::Min(*([v151 @ X22_v2 (System.Array)+18]), v157);\n\tSystem.Array::Copy(v151, v153, v178);\n\tv181 = v153 == 0;\n\tif (v181) goto L_FFFFFFFF;\n\t// 96 IsInst v198 @ X0_v17 (System.Object[]), typeof(System.Object[]), v153 @ X0_v11 (System.Array)\n\tv197 = v198 == 0;\n\tv193 = ~v197;\n\tif (v193) goto L_0068;\n\tthrow System.InvalidCastException;\nL_0068:\n\tthis.values = v198;\n\tv202 = UnityEngine.Application::get_isEditor();\n\tv134 = v202 == 0;\n\tif (v134) goto L_0078;\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this);\nL_0078:\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Resize(int newLength)
		{
			bool flag = values == null;
			bool flag2 = !flag;
			object obj = values;
			if (!flag2)
			{
				Init();
				obj = values;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v8 (System.Object)+18]");
			if ((IntPtr)0 == (IntPtr)newLength)
			{
				return;
			}
			Type type = obj.GetType();
			int num = ~newLength;
			int num2 = newLength & num;
			Type elementType = type.GetElementType();
			Array array = Array.CreateInstance(elementType, num2);
			Array array2 = values;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X22_v2 (System.Array)+18]");
			int length = Math.Min(0, num2);
			Array.Copy(array2, array, length);
			object[] array3;
			if (array != null)
			{
				array3 = array as object[];
				if (array3 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				array3 = null;
			}
			values = array3;
			if (Application.isEditor)
			{
				SaveChanges();
			}
			SaveChanges();
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xCA1ED0", Offset = "0xCA1ED0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolValues = 0;\n\tthis.vector4Values = 0;\n\tthis.objectTypeName = 0;\n\tthis.floatValues = 0;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			boolValues = null;
			vector4Values = null;
			objectTypeName = null;
			floatValues = null;
			Init();
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0xCA3428", Offset = "0xCA3428", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray()
		{
			//IL_0015: Expected I4, but got I8
			base._002Ector();
			type = VariableType.Unknown;
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0xCA3438", Offset = "0xCA3438", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray(string name)
		{
			//IL_000f: Expected I4, but got I8
			type = VariableType.Unknown;
			base._002Ector(name);
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0xCA3448", Offset = "0xCA3448", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.type = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv16 = source == 0;\n\tif (v16) goto L_002B;\n\tthis.type = source.type;\n\tv22 = HutongGames.PlayMaker.FsmArray::get_ObjectType(source);\n\tv41 = HutongGames.PlayMaker.FsmArray::set_ObjectType(this, v22);\n\tHutongGames.PlayMaker.FsmArray::CopyValues(this, source);\n\tHutongGames.PlayMaker.FsmArray::SaveChanges(this);\n\treturn;\nL_002B:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArray(FsmArray source)
		{
			//IL_000f: Expected I4, but got I8
			this.type = VariableType.Unknown;
			base._002Ector(source);
			if (source != null)
			{
				this.type = source.TypeConstraint;
				Type type = source.ObjectType;
				ObjectType = type;
				CopyValues(source);
				SaveChanges();
			}
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0xCA34CC", Offset = "0xCA34CC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F0DB28]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202352B]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmArray(this);
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0xCA352C", Offset = "0xCA352C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolValues = 0;\n\tthis.vector4Values = 0;\n\tthis.objectTypeName = 0;\n\tthis.floatValues = 0;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Clear()
		{
			boolValues = null;
			vector4Values = null;
			objectTypeName = null;
			floatValues = null;
			Init();
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xCA3544", Offset = "0xCA3544", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv32 = *([1EB6928]);\n\tv33 = *([v32 @ X8_v34]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202352C]) = v52;\nL_0022:\n\tv120 = v60.Empty;\n\tgoto L_008E;\nL_0027:\n\tif (v133) goto L_00C6;\n\tv227 = v129[v65 @ X24_v2 (System.Int32)] == 0;\n\tif (v227) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0055;\n\tgoto L_0070;\n\tv290 = v290_asT == 0;\n\tif (v290) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tgoto L_005E;\n\tv311 = *([v232 @ X0_v22 (Il2CppClass<UnityEngine.Object>)+E0]);\n\tv312 = v311 == 0;\n\tv313 = ~v312;\n\tgoto L_005E;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v232, v75, v70, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005E:\n\tv195 = UnityEngine.Object::op_Inequality(v161, 0);\n\tv323 = v195 == 0;\n\tif (v323) goto L_006C;\n\tv295 = UnityEngine.Object::get_name(v161);\n\tgoto L_FFFFFFFF;\nL_006C:\n\tv295 = System.Object::ToString(v129[v65 @ X24_v2 (System.Int32)]);\nL_0070:\n\tv301 = System.String::Concat(v120, v76);\n\tv319 = this.values;\n\tv309 = this.values == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_007B;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv319 = this.values;\nL_007B:\n\t;\n\tv119 = v319.Length - 1;\n\tv68 = v65 >= v119;\n\tif (v68) goto L_008D;\n\tv327 = System.String::Concat(v301, \", \");\nL_008D:\n\tv65 = v65 + 1;\nL_008E:\n\tv129 = this.values;\n\tv123 = this.values == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0097;\n\tHutongGames.PlayMaker.FsmArray::InitArray(this);\n\tv129 = this.values;\nL_0097:\n\t;\n\tv132 = v65 < v129.Length;\n\tv133 = ~v132;\n\tv142 = v65 < v129.Length;\n\tif (v142) goto L_0027;\n\tv148 = System.String::op_Equality(v120, v146.Empty);\n\tv211 = v148 == 0;\n\tv223 = ~v211;\n\tv224 = ~v223;\n\tif (v224) goto L_FFFFFFFF;\n\tgoto L_00C5;\nL_00C5:\n\treturn returnVal2;\nL_00C6:\n\tv228 = new System.IndexOutOfRangeException();\n\tthrow v228;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			string text = string.Empty;
			int num = 0;
			while (true)
			{
				object[] array = values;
				if (values == null)
				{
					Init();
					array = values;
				}
				bool flag = num < array.Length;
				bool flag2 = !flag;
				if (num < array.Length)
				{
					if (flag2)
					{
						break;
					}
					string text2;
					if (array[num] == null)
					{
						text2 = "null";
					}
					else
					{
						UnityEngine.Object obj = array[num] as UnityEngine.Object;
						UnityEngine.Object obj2 = (UnityEngine.Object)(((object)obj == null) ? null : array[num]);
						string text3 = ((!(obj2 != null)) ? array[num].ToString() : obj2.name);
						text2 = text3;
					}
					string text4 = text + text2;
					object[] array2 = values;
					if (values == null)
					{
						Init();
						array2 = values;
					}
					int num2 = array2.Length - 1;
					bool flag3 = num >= num2;
					text = text4;
					if (!flag3)
					{
						string text5 = text4 + ", ";
						text2 = ", ";
						text = text5;
					}
					num++;
					continue;
				}
				if (text == string.Empty)
				{
					return "Empty";
				}
				return text;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0xCA372C", Offset = "0xCA372C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = variableType + 1;\n\tv18 = v16 == 0;\n\tif (v18) goto L_FFFFFFFF;\n\tv27 = HutongGames.PlayMaker.NamedVariable::TestTypeConstraint(this, variableType, this.objectType);\n\tv30 = v27 == 0;\n\tif (v30) goto L_FFFFFFFF;\n\tv84 = variableType | 2;\n\tv35 = v84 != 0xE;\n\tif (v35) goto L_0046;\n\tv97 = HutongGames.PlayMaker.FsmArray::get_ObjectType(this);\n\tv112 = v97 - _objectType;\n\tv114 = v112 == 0;\n\tv74 = _objectType == 0;\n\treturnVal1 = v74 | v114;\n\tgoto L_0054;\n\tgoto L_0054;\n\tgoto L_0054;\nL_0046:\n\tv50 = this.type - variableType;\n\tv73 = v50 == 0;\nL_0054:\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool TestTypeConstraint(VariableType variableType, Type _objectType = null)
		{
			//IL_00a3: Expected O, but got I
			if (variableType + 1 != VariableType.Float)
			{
				if (base.TestTypeConstraint(variableType, objectType))
				{
					int num = (int)(variableType | VariableType.Bool);
					if (num == 14)
					{
						Type type = ObjectType;
						object obj = (long)(IntPtr)type - (long)(IntPtr)_objectType;
						bool flag = obj == null;
						bool flag2 = (object)_objectType == null;
						return flag2 || flag;
					}
					int num2 = TypeConstraint - variableType;
					return num2 == 0;
				}
				return false;
			}
			return true;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0xCA37CC", Offset = "0xCA37CC", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv17 = *([1EA4C20]);\n\tv18 = *([v17 @ X8_v13]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([202352D]) = v37;\nL_0014:\n\tv39 = v35.type + 1;\n\tv40 = v39 < 0xF;\n\tv41 = ~v40;\n\tv42 = v39 - 0xF;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_00AB;\n\tv52 = 0x181A000 + 0x850;\n\tv54 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]) + v52;\n\t// 37 IndirectJump v54 @ X8_v10, v35 @ X0_v1 (HutongGames.PlayMaker.FsmArray), v35 @ X0_v1 (HutongGames.PlayMaker.FsmArray), methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+2A0]);\n\tX1 = *([X8+2A8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00B5;\n\tX8 = *([X0]);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX2 = *([X8+260]);\n\tX1 = *([X8+268]);\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 52 ShiftStack 32\n\t// 53 IndirectJump X2, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EB7B88]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC6EA0]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EFC4E8]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ED6B30]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ECB320]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1ED3998]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EB5540]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1F0A100]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EF7A48]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EE5E68]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EC4460]);\n\tgoto L_007D;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([1EBBA78]);\nL_007D:\n\tX9 = *([X0+12F]);\n\tX19 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0087;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0087;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0087:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 141 ShiftStack 32\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\treturn X0;\n\tX8 = *([1EBC820]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009C:\n\tX8 = 0x1F04000;\n\tX8 = *([1F042B8]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 166 ShiftStack 32\n\treturn X0;\nL_00AB:\n\tv58 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v58);\n\tthrow v58;\nL_00B5:\n\t;\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Type RealType()
		{
			//IL_0029: Expected O, but got I
			int num = (int)(TypeConstraint + 1);
			bool flag = num < 15;
			bool flag2 = !flag;
			int num2 = num - 15;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25272320 + 2128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v4 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v10 (should have been resolved before IL gen)");
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}
	}
}
