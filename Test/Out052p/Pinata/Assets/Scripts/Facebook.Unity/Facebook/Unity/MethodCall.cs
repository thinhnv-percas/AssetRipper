using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200001F")]
	internal abstract class MethodCall<T> where T : IResult
	{
		[Token(Token = "0x17000030")]
		public string MethodName
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0xD935B8", Offset = "0xD935B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MethodName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MethodName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000DC")]
			[Address(RVA = "0xD935C0", Offset = "0xD935C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MethodName>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CMethodName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000031")]
		public FacebookDelegate<T> Callback
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DD")]
			[Address(RVA = "0xD935C8", Offset = "0xD935C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Callback>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected internal get
			{
				return _003CCallback_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000DE")]
			[Address(RVA = "0xD935D0", Offset = "0xD935D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Callback>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Callback = value;
			}
		}

		[Token(Token = "0x17000032")]
		protected FacebookBase FacebookImpl
		{
			[CompilerGenerated]
			[Token(Token = "0x60000DF")]
			[Address(RVA = "0xD935D8", Offset = "0xD935D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<FacebookImpl>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CFacebookImpl_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000033")]
		protected MethodArguments Parameters
		{
			[CompilerGenerated]
			[Token(Token = "0x60000E0")]
			[Address(RVA = "0xD935E0", Offset = "0xD935E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Parameters>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CParameters_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xD934D8", Offset = "0xD934D8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EA8C88]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, facebookImpl, methodName, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20240BA]) = v47;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tv56 = new Facebook.Unity.MethodArguments();\n\tFacebook.Unity.MethodArguments::.ctor(v56);\n\tv89 = Facebook.Unity.MethodCall`1<T>::set_Parameters(this, v56);\n\tv96 = Facebook.Unity.MethodCall`1<T>::set_FacebookImpl(this, facebookImpl);\n\tv64 = Il2CppMethodInfo;\n\tv60 = *([v64 @ X2_v3 (Il2CppMethodInfo)]);\n\t// 65 IndirectJump v60 @ X3_v1, this @ X0 (Facebook.Unity.MethodCall`1<T>), this @ X0 (Facebook.Unity.MethodCall`1<T>), methodName @ X2 (System.String), methodof(Facebook.Unity.MethodCall`1<T>::set_MethodName), v60 @ X3_v1, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MethodCall(FacebookBase facebookImpl, string methodName)
		{
			//IL_003c: Expected O, but got I
			base._002Ector();
			MethodArguments parameters = new MethodArguments();
			Parameters = parameters;
			FacebookImpl = facebookImpl;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60000E1")]
		public abstract void Call(MethodArguments args = null);
	}
}
