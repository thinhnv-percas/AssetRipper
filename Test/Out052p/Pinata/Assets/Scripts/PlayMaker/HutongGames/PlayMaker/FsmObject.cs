using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200005C")]
	public class FsmObject : NamedVariable
	{
		[SerializeField]
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x38")]
		internal string typeName;

		[SerializeField]
		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x40")]
		private UnityEngine.Object value;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x48")]
		private Type objectType;

		[Token(Token = "0x17000081")]
		public override Type ObjectType
		{
			[Token(Token = "0x600020F")]
			[Address(RVA = "0xCAF5C8", Offset = "0xCAF5C8", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F10248]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202360E]) = v38;\nL_0013:\n\treturnVal1 = this.objectType;\n\tv40 = this.objectType == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_004E;\n\tv44 = System.String::IsNullOrEmpty(this.typeName);\n\tv63 = v44 == 0;\n\tif (v63) goto L_0038;\n\tgoto L_002E;\n\tv87 = *([v81 @ X0_v12+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_002E;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v81, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv94 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv99 = System.Type::get_FullName(v94);\n\tthis.typeName = v99;\n\tgoto L_003F;\nL_0038:\n\tv57 = this.typeName;\nL_003F:\n\tgoto L_0047;\n\tv110 = *([v106 @ X0_v7+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_0047;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v106, v96, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\treturnVal1 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v57);\n\tthis.objectType = returnVal1;\nL_004E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type result = objectType;
				if ((object)objectType == null)
				{
					string text;
					if (string.IsNullOrEmpty(TypeName))
					{
						Type typeFromHandle = typeof(UnityEngine.Object);
						text = (typeName = typeFromHandle.FullName);
					}
					else
					{
						text = TypeName;
					}
					result = (objectType = ReflectionUtils.GetGlobalType(text));
				}
				return result;
			}
			[Token(Token = "0x6000210")]
			[Address(RVA = "0xCAF6B0", Offset = "0xCAF6B0", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED8A60]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202360F]) = v41;\nL_0015:\n\tthis.objectType = value;\n\tv42 = value == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_002D;\n\tgoto L_002A;\n\tv66 = *([v46 @ X0_v15+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002A;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v46, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv58 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tthis.objectType = v58;\nL_002D:\n\tv65 = this.value == 0;\n\tif (v65) goto L_004F;\n\tv73 = System.Object::GetType(this.value);\n\tv85 = System.Type::IsAssignableFrom(v73, this.objectType);\n\tv116 = v85 == 0;\n\tv88 = ~v116;\n\tif (v88) goto L_004F;\n\tv84 = System.Type::IsSubclassOf(v73, this.objectType);\n\tv130 = v84 == 0;\n\tv87 = ~v130;\n\tif (v87) goto L_004F;\n\tthis.value = 0;\nL_004F:\n\tv100 = System.Type::get_FullName(this.objectType);\n\tthis.typeName = v100;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				objectType = value;
				if ((object)value == null)
				{
					Type typeFromHandle = typeof(UnityEngine.Object);
					objectType = typeFromHandle;
				}
				if ((object)this.value != null)
				{
					Type type = this.value.GetType();
					if (!type.IsAssignableFrom(objectType) && !type.IsSubclassOf(objectType))
					{
						Value = null;
					}
				}
				string fullName = objectType.FullName;
				typeName = fullName;
			}
		}

		[Token(Token = "0x17000082")]
		public string TypeName
		{
			[Token(Token = "0x6000211")]
			[Address(RVA = "0xCAF7B4", Offset = "0xCAF7B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.typeName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TypeName;
			}
		}

		[Token(Token = "0x17000083")]
		public UnityEngine.Object Value
		{
			[Token(Token = "0x6000212")]
			[Address(RVA = "0xCAF338", Offset = "0xCAF338", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_0015:\n\tgoto L_001B;\n\tv77 = v22;\n\tv78 = \"il2cpp_codegen_initialize_method\"(v77, v61, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92);\n\t*([2023610]) = v24;\nL_001B:\n\tv96 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(v69);\n\tv97 = v96 == 0;\n\tif (v97) goto L_0069;\n\tv68 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(v69);\n\tgoto L_FFFFFFFF;\n\tv189 = v189_asT == 0;\n\tif (v189) goto L_005F;\n\tgoto L_FFFFFFFF;\n\tv45 = v45_asT != 0;\n\tif (v45) goto L_0015;\nL_005F:\n\tthrow System.InvalidCastException;\nL_0069:\n\treturn *([v69 @ X19_v2 (HutongGames.PlayMaker.FsmObject)+40]);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0098: Expected O, but got I
				FsmObject fsmObject = this;
				while (true)
				{
					NamedVariable castVariable = fsmObject.CastVariable;
					if (castVariable == null)
					{
						break;
					}
					NamedVariable castVariable2 = fsmObject.CastVariable;
					FsmObject fsmObject2 = castVariable2 as FsmObject;
					if (fsmObject2 != null)
					{
						FsmObject fsmObject3 = castVariable2 as FsmObject;
						bool flag = fsmObject3 != null;
						fsmObject = (FsmObject)castVariable2;
						if (flag)
						{
							continue;
						}
					}
					throw new InvalidCastException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X19_v2 (HutongGames.PlayMaker.FsmObject)+40]");
				return (UnityEngine.Object)0;
			}
			[Token(Token = "0x6000213")]
			[Address(RVA = "0xCAF7BC", Offset = "0xCAF7BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = value;\n\treturn;\n")]
			set
			{
				Value = value;
			}
		}

		[Token(Token = "0x17000084")]
		public override object RawValue
		{
			[Token(Token = "0x6000214")]
			[Address(RVA = "0xCAF7C4", Offset = "0xCAF7C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x6000215")]
			[Address(RVA = "0xCAF7CC", Offset = "0xCAF7CC", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC6FF8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023611]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0037;\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_0040;\nL_0037:\n\tthis.value = value;\n\treturn;\nL_0040:\n\tthrow System.InvalidCastException;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					UnityEngine.Object obj = value as UnityEngine.Object;
					if ((object)obj == null)
					{
						throw new InvalidCastException();
					}
				}
				Value = (UnityEngine.Object)value;
			}
		}

		[Token(Token = "0x17000085")]
		public override VariableType VariableType
		{
			[Token(Token = "0x600021B")]
			[Address(RVA = "0xCAF8C4", Offset = "0xCAF8C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0xC;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.Object;
			}
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0xCAF42C", Offset = "0xCAF42C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject()
		{
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0xCAF438", Offset = "0xCAF438", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE0370]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023612]) = v41;\nL_0018:\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\tgoto L_002A;\n\tv54 = *([v48 @ X0_v3+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002A;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v48, v43, v44, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv63 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv68 = System.Type::get_FullName(v63);\n\tthis.typeName = v68;\n\tv71 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tthis.objectType = v71;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject(string name)
			: base(name)
		{
			typeName = typeof(UnityEngine.Object).FullName;
			objectType = typeof(UnityEngine.Object);
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0xCAF4FC", Offset = "0xCAF4FC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tthis.value = source.value;\n\tthis.typeName = source.typeName;\n\tthis.objectType = source.objectType;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmObject(FsmObject source)
			: base(source)
		{
			Value = source.value;
			typeName = source.TypeName;
			objectType = source.objectType;
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0xCAF85C", Offset = "0xCAF85C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDE770]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023613]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v42, this);\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			return new FsmObject(this);
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0xCAF8BC", Offset = "0xCAF8BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.typeName = 0;\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			typeName = null;
			Value = null;
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0xCAF8CC", Offset = "0xCAF8CC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE1BB8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023614]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmObject::get_Value(this);\n\tgoto L_0026;\n\tv48 = *([v44 @ X8_v5+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv58 = UnityEngine.Object::op_Equality(v40, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0034;\n\treturn \"None\";\nL_0034:\n\tv70 = HutongGames.PlayMaker.FsmObject::get_Value(this);\n\tv84 = *([v70 @ X0_v8 (UnityEngine.Object)]);\n\tv74 = *([v84 @ X8_v6 (Il2CppClass<UnityEngine.Object>)+160]);\n\tv76 = *([v84 @ X8_v6 (Il2CppClass<UnityEngine.Object>)+168]);\n\t// 63 IndirectJump v74 @ X2_v2, v70 @ X0_v8 (UnityEngine.Object), v70 @ X0_v8 (UnityEngine.Object), v76 @ X1_v2, v74 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_004d: Expected I, but got O
			//IL_005d: Expected O, but got I
			//IL_006d: Expected O, but got I
			while (true)
			{
				UnityEngine.Object obj = Value;
				if (obj == null)
				{
					break;
				}
				UnityEngine.Object obj2 = Value;
				IntPtr intPtr = (IntPtr)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v6 (Il2CppClass<UnityEngine.Object>)+160]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ X8_v6 (Il2CppClass<UnityEngine.Object>)+168]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X2_v2 (should have been resolved before IL gen)");
			}
			return "None";
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0xCAF980", Offset = "0xCAF980", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA8028]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023615]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42);\n\tv42.value = value;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmObject(UnityEngine.Object value)
		{
			FsmObject fsmObject = (FsmObject)new NamedVariable();
			fsmObject.Value = value;
			return fsmObject;
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0xCAF9F0", Offset = "0xCAF9F0", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF9D98]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, variableType, _objectType, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023616]) = v44;\nL_0017:\n\tv45 = variableType + 1;\n\tv47 = v45 == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv54 = HutongGames.PlayMaker.NamedVariable::TestTypeConstraint(this, variableType, this.objectType);\n\tv105 = v54 == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tv96 = _objectType == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0038;\n\tv169 = *([v164 @ X0_v8+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0038;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v164, v52, v50, v53, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0038:\n\tv93 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv71 = v93 == _objectType;\n\tif (v71) goto L_FFFFFFFF;\n\tv94 = HutongGames.PlayMaker.FsmObject::get_ObjectType(this);\n\tv72 = v94 == _objectType;\n\tif (v72) goto L_FFFFFFFF;\n\tv181 = HutongGames.PlayMaker.FsmObject::get_ObjectType(this);\n\tv157 = _objectType->klass;\n\tv142 = _objectType->klass->vtable[113];\n\tv146 = _objectType->klass->vtable[113];\n\t// 99 IndirectJump v142 @ X3_v4, _objectType @ X2 (System.Type), _objectType @ X2 (System.Type), v181 @ X0_v15 (System.Type), v146 @ X2_v4, v142 @ X3_v4, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tgoto L_006E;\nL_006E:\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool TestTypeConstraint(VariableType variableType, Type _objectType = null)
		{
			//IL_00ba: Expected I, but got O
			//IL_00ca: Expected O, but got I
			//IL_00da: Expected O, but got I
			if (variableType + 1 != VariableType.Float)
			{
				if (!base.TestTypeConstraint(variableType, objectType))
				{
					return false;
				}
				if ((object)_objectType != null)
				{
					Type typeFromHandle = typeof(UnityEngine.Object);
					if ((object)typeFromHandle != _objectType)
					{
						Type type = ObjectType;
						if ((object)type != _objectType)
						{
							Type type2 = ObjectType;
							IntPtr intPtr = (IntPtr)_objectType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v12 (Il2CppClass<System.Type>)+840]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X8_v12 (Il2CppClass<System.Type>)+848]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v142 @ X3_v4 (should have been resolved before IL gen)");
						}
					}
				}
			}
			return true;
		}
	}
}
