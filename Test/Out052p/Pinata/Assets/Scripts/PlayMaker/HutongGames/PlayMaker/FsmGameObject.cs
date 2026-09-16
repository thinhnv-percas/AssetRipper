using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000059")]
	public class FsmGameObject : NamedVariable
	{
		[CompilerGenerated]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x38")]
		internal Action OnChange;

		[SerializeField]
		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x40")]
		internal GameObject value;

		[Token(Token = "0x17000077")]
		public GameObject Value
		{
			[Token(Token = "0x60001E9")]
			[Address(RVA = "0xCAC9FC", Offset = "0xCAC9FC", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE7580]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235E4]) = v38;\nL_0015:\n\tv41 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv42 = v41 == 0;\n\tif (v42) goto L_0037;\n\tv45 = HutongGames.PlayMaker.NamedVariable::get_CastVariable(this);\n\tv83 = HutongGames.PlayMaker.NamedVariable::get_RawValue(v45);\n\tv85 = v83 == 0;\n\tif (v85) goto L_003D;\n\tv50 = *([v83 @ X0_v10 (System.Object)]) != UnityEngine.GameObject;\n\tif (v50) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003D;\nL_0037:\n\treturnVal1 = this.value;\nL_003D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NamedVariable castVariable = base.CastVariable;
				GameObject result;
				if (castVariable != null)
				{
					NamedVariable castVariable2 = base.CastVariable;
					object obj = castVariable2.RawValue;
					bool flag = obj == null;
					result = (GameObject)obj;
					if (!flag)
					{
						if ((object)obj.GetType() != typeof(GameObject))
						{
							obj = null;
						}
						result = (GameObject)obj;
					}
				}
				else
				{
					result = value;
				}
				return result;
			}
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0xCACA94", Offset = "0xCACA94", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.value == value;\n\tif (v7) goto L_0013;\n\tthis.value = value;\n\tv13 = this.OnChange == 0;\n\tif (v13) goto L_0013;\n\tSystem.Action::Invoke(this.OnChange);\n\treturn;\nL_0013:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if ((object)this.value != value)
				{
					this.value = value;
					if (this.OnChange != null)
					{
						this.OnChange();
					}
				}
			}
		}

		[Token(Token = "0x17000078")]
		public override Type ObjectType
		{
			[Token(Token = "0x60001EB")]
			[Address(RVA = "0xCACABC", Offset = "0xCACABC", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EDE140]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235E5]) = v35;\nL_001A:\n\tgoto L_0026;\n\tv45 = *([v38 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0026:\n\treturnVal1 = System.Type::GetTypeFromHandle(UnityEngine.GameObject);\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return typeof(GameObject);
			}
		}

		[Token(Token = "0x17000079")]
		public override object RawValue
		{
			[Token(Token = "0x60001EC")]
			[Address(RVA = "0xCACB2C", Offset = "0xCACB2C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.value;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return value;
			}
			[Token(Token = "0x60001ED")]
			[Address(RVA = "0xCACB34", Offset = "0xCACB34", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF0468]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235E6]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv56 = *([value @ X1 (System.Object)]) != UnityEngine.GameObject;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tgoto L_002C;\nL_002C:\n\tthis.value = v80;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				object obj = ((value == null) ? null : (((object)value.GetType() != typeof(GameObject)) ? null : value));
				this.value = (GameObject)obj;
			}
		}

		[Token(Token = "0x1700007A")]
		public override VariableType VariableType
		{
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0xCACCD8", Offset = "0xCACCD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 3;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return VariableType.GameObject;
			}
		}

		[Token(Token = "0x14000007")]
		public event Action OnChange
		{
			[CompilerGenerated]
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0xCAC8B4", Offset = "0xCAC8B4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFA508]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20235E2]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.OnChange;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0xCAC958", Offset = "0xCAC958", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED3928]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20235E3]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.OnChange;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xCACBA8", Offset = "0xCACBA8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEFEC8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, val, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20235E7]) = v41;\nL_0015:\n\tv42 = val == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv56 = *([val @ X1 (System.Object)]) != UnityEngine.GameObject;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tgoto L_002C;\nL_002C:\n\tthis.value = v80;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void SafeAssign(object val)
		{
			object obj = ((val == null) ? null : (((object)val.GetType() != typeof(GameObject)) ? null : val));
			value = (GameObject)obj;
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xCACC1C", Offset = "0xCACC1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject()
		{
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xCACC24", Offset = "0xCACC24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, name);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject(string name)
			: base(name)
		{
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xCACC2C", Offset = "0xCACC2C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.NamedVariable::.ctor(this, source);\n\tv15 = source == 0;\n\tif (v15) goto L_0013;\n\tthis.value = source.value;\nL_0013:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmGameObject(FsmGameObject source)
			: base(source)
		{
			if (source != null)
			{
				value = source.value;
			}
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xCACC60", Offset = "0xCACC60", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA4248]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235E8]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v42, this);\n\tv46 = this == 0;\n\tif (v46) goto L_0025;\n\tv42.value = this.value;\nL_0025:\n\treturn v42;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override NamedVariable Clone()
		{
			FsmGameObject fsmGameObject = (FsmGameObject)new NamedVariable(this);
			if (this != null)
			{
				fsmGameObject.value = value;
			}
			return fsmGameObject;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0xCACCD0", Offset = "0xCACCD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = 0;\n\treturn;\n")]
		public override void Clear()
		{
			value = null;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0xCACCE0", Offset = "0xCACCE0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC69C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235E9]) = v38;\nL_0014:\n\tv40 = HutongGames.PlayMaker.FsmGameObject::get_Value(this);\n\tgoto L_0026;\n\tv48 = *([v44 @ X8_v5+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv59 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv58 = UnityEngine.Object::op_Equality(v40, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0034;\n\treturn \"None\";\nL_0034:\n\tv70 = HutongGames.PlayMaker.FsmGameObject::get_Value(this);\n\treturnVal2 = UnityEngine.Object::get_name(v70);\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			GameObject gameObject = Value;
			if (gameObject == null)
			{
				return "None";
			}
			GameObject gameObject2 = Value;
			return gameObject2.name;
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0xCACD90", Offset = "0xCACD90", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = *([1F0FAB0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20235EA]) = v40;\nL_001C:\n\tv49 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.NamedVariable::.ctor(v49, v45.Empty);\n\tv49.value = value;\n\treturn v49;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator FsmGameObject(GameObject value)
		{
			FsmGameObject fsmGameObject = (FsmGameObject)new NamedVariable(string.Empty);
			fsmGameObject.value = value;
			return fsmGameObject;
		}
	}
}
