using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public class ButtonBehaviour : MonoBehaviour
{
	[CompilerGenerated]
	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x20")]
	private EventHandler<EventArgs> m_OnAdOpening;

	[CompilerGenerated]
	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x28")]
	private EventHandler<EventArgs> m_OnLeavingApplication;

	[Token(Token = "0x14000001")]
	public event EventHandler<EventArgs> OnAdOpening
	{
		[CompilerGenerated]
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x133C1EC", Offset = "0x133C1EC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3671F]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0068: Expected O, but got I
			//IL_0012: Expected I4, but got O
			object obj = (nint)this + 32;
			Delegate obj2 = this.m_OnAdOpening;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if ((object)obj3 != null)
				{
					int num = (int)(obj3 as EventHandler<EventArgs>);
					bool flag = num == 0;
					bool flag2 = !flag;
					int num2 = num;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					int num2 = 0;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
				bool flag3 = (object)obj2 != obj4;
				obj2 = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x133C29C", Offset = "0x133C29C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36720]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0068: Expected O, but got I
			//IL_0012: Expected I4, but got O
			object obj = (nint)this + 32;
			Delegate obj2 = this.m_OnAdOpening;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if ((object)obj3 != null)
				{
					int num = (int)(obj3 as EventHandler<EventArgs>);
					bool flag = num == 0;
					bool flag2 = !flag;
					int num2 = num;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					int num2 = 0;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
				bool flag3 = (object)obj2 != obj4;
				obj2 = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000002")]
	public event EventHandler<EventArgs> OnLeavingApplication
	{
		[CompilerGenerated]
		[Token(Token = "0x6000007")]
		[Address(RVA = "0x133C34C", Offset = "0x133C34C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36721]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_0068: Expected O, but got I
			//IL_0012: Expected I4, but got O
			object obj = (nint)this + 40;
			Delegate obj2 = this.m_OnLeavingApplication;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				if ((object)obj3 != null)
				{
					int num = (int)(obj3 as EventHandler<EventArgs>);
					bool flag = num == 0;
					bool flag2 = !flag;
					int num2 = num;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					int num2 = 0;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
				bool flag3 = (object)obj2 != obj4;
				obj2 = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000008")]
		[Address(RVA = "0x133C3FC", Offset = "0x133C3FC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36722]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_0068: Expected O, but got I
			//IL_0012: Expected I4, but got O
			object obj = (nint)this + 40;
			Delegate obj2 = this.m_OnLeavingApplication;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				if ((object)obj3 != null)
				{
					int num = (int)(obj3 as EventHandler<EventArgs>);
					bool flag = num == 0;
					bool flag2 = !flag;
					int num2 = num;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					int num2 = 0;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
				bool flag3 = (object)obj2 != obj4;
				obj2 = obj4;
				if (!flag3)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x133C4AC", Offset = "0x133C4AC", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.Application;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv50 = UnityEngine.Debug;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv59 = System.EventArgs;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv66 = \"http://google.com\";\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = \"Opened URL\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A36723]) = v40;\nL_0028:\n\tgoto L_002E;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002E:\n\tUnityEngine.Debug::Log(\"Opened URL\");\n\tgoto L_0039;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v61, v57, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0039:\n\tUnityEngine.Application::OpenURL(\"http://google.com\");\n\tv77 = this.OnAdOpening == 0;\n\tif (v77) goto L_0048;\n\tv79 = new System.EventArgs();\n\tSystem.EventArgs::.ctor(v79);\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnAdOpening, this, v79);\nL_0048:\n\t;\n\tv93 = this.OnLeavingApplication == 0;\n\tif (v93) goto L_0062;\n\tv96 = new System.EventArgs();\n\tSystem.EventArgs::.ctor(v96);\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.OnLeavingApplication, this, v96);\nL_0062:\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OpenURL()
	{
		Debug.Log("Opened URL");
		Application.OpenURL("http://google.com");
		if (this.OnAdOpening != null)
		{
			EventArgs e = new EventArgs();
			this.OnAdOpening(this, e);
		}
		if (this.OnLeavingApplication != null)
		{
			EventArgs e2 = new EventArgs();
			this.OnLeavingApplication(this, e2);
		}
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x133C5F0", Offset = "0x133C5F0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ButtonBehaviour()
	{
	}
}
