using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000070")]
	public class ComponentPoolWithInterface<T> : ComponentPool<T>, IComponentPool where T : struct
	{
		[Token(Token = "0x17000041")]
		public Type ComponentType
		{
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0x70B919C", Offset = "0x70B919C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0xB7D5000 + 0x538;\n\tv16 = *([v15 @ X8_v4 (System.Int32)+E0]);\n\tv18 = *([v16 @ X0_v1+E4]) == 0;\n\tif (v18) goto L_0020;\n\treturnVal1 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\treturn returnVal1;\nL_0020:\n\treturnVal2 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\treturn returnVal2;\n")]
			get
			{
				//IL_001f: Expected O, but got I
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ X8_v4 (System.Int32)+E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1+E4]");
				if ((nint)0 != 0)
				{
					return typeof(T);
				}
				return typeof(T);
			}
		}

		[Token(Token = "0x17000042")]
		public int TypeIndex
		{
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0x70B91F4", Offset = "0x70B91F4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv17 = *([v14 @ X0_v1 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv18 = v17 == 0;\n\tif (v18) goto L_0022;\n\tgoto L_0014;\nL_0014:\n\tv43 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv46 = *([v43 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv47 = v46 == 0;\n\tv66 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v47) goto L_0031;\nL_0021:\n\treturn v59.Id;\nL_0022:\n\tv21 = 0x220C238(Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv52 = *([v21 @ X0_v8+E4]) == 0;\n\tv37 = ~v52;\n\tif (v37) goto L_0014;\n\tv56 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tv72 = *([v56 @ X0_v7 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]) & 1;\n\tv73 = v72 == 0;\n\tv54 = ~v73;\n\tv66 = Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>;\n\tif (v54) goto L_0021;\nL_0031:\n\tv68 = 0x220C238(v66, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv82 = *([v68 @ X0_v3+B8]);\n\treturn *([v82 @ X8_v6]);\n")]
			get
			{
				//IL_012b: Expected O, but got I
				//IL_0130: Expected I4, but got O
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X0_v1 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
				nint num4;
				if ((int)((nint)0 & (nint)1) == 0)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X0_v8+E4]");
					if ((nint)0 == 0)
					{
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X0_v7 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
						int num3 = (int)((nint)0 & (nint)1);
						bool flag = num3 == 0;
						bool flag2 = !flag;
						num4 = 0;
						if (flag2)
						{
							goto IL_007d;
						}
						goto IL_010c;
					}
				}
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X0_v12 (Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentTypeIndex`1<T>>)+135]");
				int num6 = (int)((nint)0 & (nint)1);
				bool flag3 = num6 == 0;
				num4 = 0;
				if (!flag3)
				{
					goto IL_007d;
				}
				goto IL_010c;
				IL_010c:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X0_v3+B8]");
				object obj = 0;
				return (int)obj;
				IL_007d:
				return ComponentTypeIndex<T>.Id;
			}
		}

		[Token(Token = "0x17000043")]
		int IComponentPool.Version
		{
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0x70B9290", Offset = "0x70B9290", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Version;\n")]
			get
			{
				return Version;
			}
		}

		[Token(Token = "0x17000044")]
		int IComponentPool.Count
		{
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0x70B92A8", Offset = "0x70B92A8", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Count;\n")]
			get
			{
				return Count;
			}
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x70B92C0", Offset = "0x70B92C0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v14 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), index, 0);\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1::Remove /* +1 sharing this address */(this, v14, 0);\n\treturn;\n")]
		public void RemoveByIndex(int index)
		{
			EntityId entityId = new EntityId(index, 0);
			Il2CppRuntime.Boundary("MANAGED", "Method not found @70D18E8 (_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1::Remove, and 1 more at this address)");
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x70B930C", Offset = "0x70B930C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v14 @ stack_-28_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), index, 0);\n\tv20 = v14 & 0x80000000;\n\tv21 = v20 == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_005D;\n\tv58 = this._sparse;\n\tv80 = v14 >= v58.Length;\n\tif (v80) goto L_005D;\n\tv99 = v14 & 0x7FFFFFFF;\n\tv173 = v58[v99 @ X10_v5 (System.Int32)] & 0x80000000;\n\tv174 = v173 == 0;\n\tv103 = ~v174;\n\tif (v103) goto L_005D;\n\tv28 = v58[v99 @ X10_v5 (System.Int32)] >= this.Count;\n\tif (v28) goto L_005D;\n\tv55 = this._denseToEntity;\n\tv158 = v55[v58[v99 @ X10_v5 (System.Int32)]] - v14;\n\tv154 = v158 == 0;\n\treturn v154;\nL_005D:\n\treturn 0;\n")]
		public bool HasByIndex(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPoolWithInterface::HasByIndex");
			return default;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x70B93C0", Offset = "0x70B93C0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityId::.ctor(&v17 @ stack_-30_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityId), index, 0);\n\tv26 = _game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1::TryGet /* +1 sharing this address */(this, v17, &v24 @ stack_-21_v2, 0);\n\tv40 = v26 == 0;\n\tif (v40) goto L_0029;\n\tv42 = v24;\n\t// 28 Box returnVal3 @ X0_v7 (System.Object), typeof(Il2CppClass<T>), &v42 @ stack_-31_v1\n\treturn returnVal3;\nL_0029:\n\treturn 0;\n")]
		public object GetComponentByIndex(int index)
		{
			//IL_0054: Expected I, but got O
			EntityId entityId = new EntityId(index, 0);
			Il2CppRuntime.Boundary("MANAGED", "Method not found @70D1A8C (_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1::TryGet, and 1 more at this address)");
			object obj = default(object);
			if (obj != null)
			{
				object obj3 = default(object);
				object obj2 = obj3;
				return (IntPtr)obj2;
			}
			return null;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x70B944C", Offset = "0x70B944C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv37 = new Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>>();\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>::.ctor(v37, -2);\n\t*([v37 @ X0_v5 (_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>+<GetEntityIndices>d__18<T>)+20]) = this;\n\treturn v37;\n")]
		IEnumerable<int> IComponentPool.GetEntityIndices()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPoolWithInterface::GetEntityIndices");
			return default;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x70B94D4", Offset = "0x70B94D4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<_game.BaseLayerSystems.EntitySystem.Core.ComponentPoolWithInterface`1<T>>();\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::.ctor(v42);\n\tv50 = this == 0;\n\tif (v50) goto L_002E;\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::CopyTo(this, v42);\n\treturn v42;\nL_002E:\n\tthrow v42;\n")]
		public IComponentPool Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentPoolWithInterface::Clone");
			return default;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x70B9560", Offset = "0x70B9560", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.BaseLayerSystems.EntitySystem.Core.ComponentPool`1<T>::.ctor(this);\n\treturn;\n")]
		public ComponentPoolWithInterface()
		{
		}
	}
}
