using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Morpeh.Globals.ECS
{
	[Token(Token = "0x2000030")]
	internal sealed class ProcessEventsSystem : ILateSystem, ISystem, IInitializer, IDisposable
	{
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x10")]
		private World world;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x18")]
		private FilterProvider filter;

		[Token(Token = "0x17000016")]
		public World World
		{
			[Token(Token = "0x60000C3")]
			[Address(RVA = "0x15F7828", Offset = "0x15F7828", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.world;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return World;
			}
			[Token(Token = "0x60000C4")]
			[Address(RVA = "0x15F7830", Offset = "0x15F7830", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.world = value;\n\treturn;\n")]
			set
			{
				World = value;
			}
		}

		[Token(Token = "0x17000017")]
		public FilterProvider Filter
		{
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0x15F7838", Offset = "0x15F7838", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.filter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Filter;
			}
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0x15F7840", Offset = "0x15F7840", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.filter = value;\n\treturn;\n")]
			set
			{
				Filter = value;
			}
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x15F7848", Offset = "0x15F7848", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnAwake()
		{
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15F784C", Offset = "0x15F784C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void OnStart()
		{
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x15F7850", Offset = "0x15F7850", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EA90B0]);\n\tv15 = *([v14 @ X8_v21]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, deltaTime, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A052]) = v35;\nL_0015:\n\tv40 = 0;\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.Globals.ECS.GlobalEventComponentUpdater>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v18, v19, v20, v21, v22, v23, deltaTime, v25, v26, v27, v28, v29, v30, v31);\n\tv49 = Morpeh.Globals.ECS.GlobalEventComponentUpdater;\nL_0023:\n\tv54 = v52.Updaters == 0;\n\tif (v54) goto L_0041;\n\tv60 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::GetEnumerator(v52.Updaters);\nL_002E:\n\tv84 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::MoveNext(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>));\n\tv96 = v84 == 0;\n\tif (v96) goto L_003E;\n\tv99 = 0;\n\tv82 = *([v99 @ X0_v22 (System.Int32)]);\n\t*([v82 @ X8_v17+170])(v80, 0, *([v82 @ X8_v17+178]), v18, v19, v20, v21, v22, v23, deltaTime, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_002E;\nL_003E:\n\tv104 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>));\n\tgoto L_005E;\n\tv67 = new System.NullReferenceException();\nL_0041:\n\tv74 = new System.NullReferenceException();\n\tgoto L_004D;\n\tgoto L_004D;\nL_004D:\n\tv94 = Il2CppMethodInfo != 1;\n\tif (v94) goto L_005F;\n\tv97 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::MoveNext(v74);\n\tv106 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::MoveNext(v97);\n\tv110 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>));\n\tv149 = ~v97.m_value;\n\tv112 = ~v149;\n\tif (v112) goto L_0063;\nL_005E:\n\treturn;\nL_005F:\n\tv98 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>+Enumerator<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::MoveNext(v74);\nL_0063:\n\tthrow System.TypeLoadException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnUpdate(float deltaTime)
		{
			//IL_002e: Expected O, but got I4
			List<GlobalEventComponentUpdater>.Enumerator enumerator = default(List<GlobalEventComponentUpdater>.Enumerator);
			if (GlobalEventComponentUpdater.Updaters != null)
			{
				List<GlobalEventComponentUpdater>.Enumerator enumerator2 = GlobalEventComponentUpdater.Updaters.GetEnumerator();
				while (enumerator.MoveNext())
				{
					int num = 0;
					object obj = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v82 @ X8_v17+170] (should have been resolved before IL gen)");
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<GlobalEventComponentUpdater>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<GlobalEventComponentUpdater>.Enumerator*)1) : ((List<GlobalEventComponentUpdater>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					return;
				}
			}
			else
			{
				bool flag3 = ((List<GlobalEventComponentUpdater>.Enumerator*)ex)->MoveNext();
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15F7978", Offset = "0x15F7978", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x15F7820", Offset = "0x15F7820", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProcessEventsSystem()
		{
		}
	}
}
