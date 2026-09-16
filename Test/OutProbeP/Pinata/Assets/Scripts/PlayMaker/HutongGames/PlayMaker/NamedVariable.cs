using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000068")]
	public class NamedVariable : INameable, INamedVariable, IComparable
	{
		[SerializeField]
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x10")]
		public bool useVariable;

		[SerializeField]
		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x18")]
		private string name;

		[SerializeField]
		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x20")]
		private string tooltip;

		[SerializeField]
		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x28")]
		private bool showInInspector;

		[SerializeField]
		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x29")]
		private bool networkSync;

		[NonSerialized]
		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x30")]
		protected internal object obj;

		[Token(Token = "0x170000B4")]
		public NamedVariable CastVariable
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0xE510A0", Offset = "0xE510A0", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFB750]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247AE]) = v38;\nL_0014:\n\tv40 = this.obj == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0040;\n\tv94 = v94_asT == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0040;\nL_0040:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (obj == null)
				{
					return null;
				}
				NamedVariable namedVariable = obj as NamedVariable;
				if (namedVariable != null)
				{
					return (NamedVariable)obj;
				}
				return null;
			}
			[Token(Token = "0x60002AD")]
			[Address(RVA = "0xE51C18", Offset = "0xE51C18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.obj = value;\n\treturn;\n")]
			set
			{
				obj = value;
			}
		}

		[Token(Token = "0x170000B5")]
		public string Name
		{
			[Token(Token = "0x60002AE")]
			[Address(RVA = "0xE51C20", Offset = "0xE51C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x60002AF")]
			[Address(RVA = "0xE51C28", Offset = "0xE51C28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x170000B6")]
		public virtual VariableType VariableType
		{
			[Token(Token = "0x60002B0")]
			[Address(RVA = "0xE51C30", Offset = "0xE51C30", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv17 = *([1EB4FC8]);\n\tv18 = *([v17 @ X8_v13]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([20247AF]) = v37;\nL_0015:\n\tv40 = System.Object::GetType(this);\n\tv43 = 0x846A20(v40, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = System.Type::get_FullName(v40);\n\tv55 = System.String::Concat(\"VariableType not implemented: \", v48);\n\tv61 = new System.Exception();\n\tSystem.Exception::.ctor(v61, v55);\n\tthrow v61;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Type type = GetType();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846A20 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8)");
				string fullName = type.FullName;
				string message = "VariableType not implemented: " + fullName;
				Exception ex = new Exception(message);
				throw ex;
			}
		}

		[Token(Token = "0x170000B7")]
		public virtual Type ObjectType
		{
			[Token(Token = "0x60002B1")]
			[Address(RVA = "0xE51CEC", Offset = "0xE51CEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B2")]
			[Address(RVA = "0xE51CF4", Offset = "0xE51CF4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			set
			{
			}
		}

		[Token(Token = "0x170000B8")]
		public virtual VariableType TypeConstraint
		{
			[Token(Token = "0x60002B3")]
			[Address(RVA = "0xE51CF8", Offset = "0xE51CF8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[22];\n\tv3 = this->klass->vtable[22];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (HutongGames.PlayMaker.NamedVariable), this @ X0 (HutongGames.PlayMaker.NamedVariable), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn X0;\n")]
			get
			{
				//IL_0005: Expected I, but got O
				//IL_0015: Expected O, but got I
				//IL_0025: Expected O, but got I
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+290]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.NamedVariable>)+298]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
				return VariableType.Float;
			}
		}

		[Token(Token = "0x170000B9")]
		public virtual object RawValue
		{
			[Token(Token = "0x60002B5")]
			[Address(RVA = "0xE51D6C", Offset = "0xE51D6C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EBF878]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20247B1]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NotImplementedException ex = new NotImplementedException();
				return new TypeLoadException();
			}
			[Token(Token = "0x60002B4")]
			[Address(RVA = "0xE51D08", Offset = "0xE51D08", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EA4670]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20247B0]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				NotImplementedException ex = new NotImplementedException();
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x170000BA")]
		public string Tooltip
		{
			[Token(Token = "0x60002B6")]
			[Address(RVA = "0xE51DD0", Offset = "0xE51DD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.tooltip;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tooltip;
			}
			[Token(Token = "0x60002B7")]
			[Address(RVA = "0xE51DD8", Offset = "0xE51DD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.tooltip = value;\n\treturn;\n")]
			set
			{
				Tooltip = value;
			}
		}

		[Token(Token = "0x170000BB")]
		public bool UseVariable
		{
			[Token(Token = "0x60002B8")]
			[Address(RVA = "0xE51DE0", Offset = "0xE51DE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.useVariable;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UseVariable;
			}
			[Token(Token = "0x60002B9")]
			[Address(RVA = "0xE51DE8", Offset = "0xE51DE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.useVariable = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				useVariable = value;
			}
		}

		[Token(Token = "0x170000BC")]
		public bool ShowInInspector
		{
			[Token(Token = "0x60002BA")]
			[Address(RVA = "0xE51DF4", Offset = "0xE51DF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.showInInspector;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShowInInspector;
			}
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0xE51DFC", Offset = "0xE51DFC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.showInInspector = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				showInInspector = value;
			}
		}

		[Token(Token = "0x170000BD")]
		public bool NetworkSync
		{
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0xE51E08", Offset = "0xE51E08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.networkSync;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return NetworkSync;
			}
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0xE51E10", Offset = "0xE51E10", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.networkSync = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				networkSync = value;
			}
		}

		[Token(Token = "0x170000BE")]
		public bool IsNone
		{
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0xE51E44", Offset = "0xE51E44", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.useVariable;\n\tif (v2) goto L_0008;\n\treturnVal2 = System.String::IsNullOrEmpty(this.name);\n\treturn returnVal2;\nL_0008:\n\treturn 0;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (UseVariable)
				{
					return string.IsNullOrEmpty(Name);
				}
				return false;
			}
		}

		[Token(Token = "0x170000BF")]
		public bool UsesVariable
		{
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0xE51E60", Offset = "0xE51E60", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.useVariable;\n\tv2 = ~this.useVariable;\n\tif (v2) goto L_000E;\n\tv11 = System.String::IsNullOrEmpty(this.name);\n\tv24 = v11 ^ 1;\nL_000E:\n\treturnVal1 = v0 & 1;\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = UseVariable;
				if (UseVariable)
				{
					bool flag2 = string.IsNullOrEmpty(Name);
					int num = (flag2 ? 1 : 0) ^ 1;
					flag = (byte)num != 0;
				}
				return (byte)((flag ? 1u : 0u) & 1u) != 0;
			}
		}

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0xE51E1C", Offset = "0xE51E1C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = variable == 0;\n\tif (v0) goto L_000A;\n\tv3 = ~variable.useVariable;\n\tif (v3) goto L_000C;\n\treturnVal3 = System.String::IsNullOrEmpty(variable.name);\n\treturn returnVal3;\nL_000A:\n\treturn 1;\nL_000C:\n\treturn 0;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsNullOrNone(NamedVariable variable)
		{
			if (variable != null)
			{
				if (variable.UseVariable)
				{
					return string.IsNullOrEmpty(variable.Name);
				}
				return false;
			}
			return true;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xE50E90", Offset = "0xE50E90", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF3CC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247B2]) = v38;\nL_0018:\n\tthis.tooltip = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.name = \"\";\n\tthis.tooltip = \"\";\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable()
		{
			Tooltip = "";
			Name = "";
			Tooltip = "";
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xE49458", Offset = "0xE49458", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED62A0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247B3]) = v41;\nL_001A:\n\tthis.tooltip = \"\";\n\tSystem.Object::.ctor(this);\n\tthis.name = name;\n\tv49 = System.String::IsNullOrEmpty(name);\n\tv51 = v49 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_002C;\n\tthis.useVariable = 1;\nL_002C:\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable(string name)
		{
			Tooltip = "";
			Name = name;
			if (!string.IsNullOrEmpty(name))
			{
				useVariable = true;
			}
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0xE50EF4", Offset = "0xE50EF4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EDBD38]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, source, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247B4]) = v41;\nL_001A:\n\tthis.tooltip = \"\";\n\tSystem.Object::.ctor(this);\n\tv47 = source == 0;\n\tif (v47) goto L_002E;\n\tthis.useVariable = source.useVariable;\n\tthis.name = source.name;\n\tthis.showInInspector = source.showInInspector;\n\tthis.tooltip = source.tooltip;\n\tthis.networkSync = source.networkSync;\nL_002E:\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public NamedVariable(NamedVariable source)
		{
			Tooltip = "";
			if (source != null)
			{
				useVariable = source.UseVariable;
				Name = source.Name;
				showInInspector = source.ShowInInspector;
				Tooltip = source.Tooltip;
				networkSync = source.NetworkSync;
			}
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0xE51E8C", Offset = "0xE51E8C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Init()
		{
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0xE51E90", Offset = "0xE51E90", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = variableType + 1;\n\tv12 = v10 == 0;\n\tif (v12) goto L_FFFFFFFF;\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_TypeConstraint(this);\n\tv36 = v19 - variableType;\n\tv38 = v36 == 0;\n\tgoto L_0020;\nL_0020:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool TestTypeConstraint(VariableType variableType, Type objectType = null)
		{
			if (variableType + 1 != VariableType.Float)
			{
				VariableType typeConstraint = TypeConstraint;
				int num = typeConstraint - variableType;
				return num == 0;
			}
			return true;
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0xE51ED4", Offset = "0xE51ED4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB7680]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, val, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20247B5]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SafeAssign(object val)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0xE51F38", Offset = "0xE51F38", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0A508]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20247B6]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual NamedVariable Clone()
		{
			NotImplementedException ex = new NotImplementedException();
			return (NamedVariable)(object)new TypeLoadException();
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0xE51F9C", Offset = "0xE51F9C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDDE68]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247B7]) = v38;\nL_0013:\n\tv39 = this + 0x18;\n\tv42 = System.String::IsNullOrEmpty(this.name);\n\tv47 = v42 == 0;\n\tv52 = ~v47;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_002B;\nL_002B:\n\treturn *([v56 @ X8_v5 (System.String)]);\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetDisplayName()
		{
			//IL_002c: Expected O, but got I
			string result = (string)((long)(IntPtr)this + 24L);
			if (string.IsNullOrEmpty(Name))
			{
				return "None";
			}
			return result;
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0xE51FFC", Offset = "0xE51FFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual float ToFloat()
		{
			return 0f;
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0xE52004", Offset = "0xE52004", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual int ToInt()
		{
			return 0;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0xE5200C", Offset = "0xE5200C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB70A0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20247B8]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Clear()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xE52070", Offset = "0xE52070", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED9A18]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247B9]) = v41;\nL_0015:\n\tv42 = obj == 0;\n\tif (v42) goto L_0043;\n\tgoto L_FFFFFFFF;\n\tv80 = v80_asT != 0;\n\tv60 = v60_asT == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tif (v80) goto L_004F;\nL_0043:\n\treturn 0;\nL_004F:\n\treturnVal2 = System.String::CompareOrdinal(this.name, *([v99 @ X8_v7 (System.Object)+18]));\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int CompareTo(object obj)
		{
			//IL_0087: Expected O, but got I
			if (obj != null)
			{
				NamedVariable namedVariable = obj as NamedVariable;
				bool flag = namedVariable != null;
				NamedVariable namedVariable2 = obj as NamedVariable;
				if (namedVariable2 != null)
				{
					object obj2 = obj;
				}
				else
				{
					object obj2 = null;
				}
				if (flag)
				{
					string strA = Name;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v7 (System.Object)+18]");
					return string.CompareOrdinal(strA, (string)0);
				}
			}
			return 0;
		}
	}
}
