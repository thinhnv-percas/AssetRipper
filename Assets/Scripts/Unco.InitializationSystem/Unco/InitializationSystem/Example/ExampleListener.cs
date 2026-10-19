using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.InitializationSystem.Runtime;
using UnityEngine;

namespace Unco.InitializationSystem.Example
{
	[Token(Token = "0x2000013")]
	public class ExampleListener : MonoBehaviour
	{
		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81B1C90", Offset = "0x81B1C90", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tUnco.InitializationSystem.Runtime.InitializationManager::Listen(this);\n\treturn;\n")]
		private void Subscribe()
		{
			InitializationManager.Listen(this);
		}

		[OnInitialize(new Type[] { typeof(ExampleInitializable) })]
		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81B1D10", Offset = "0x81B1D10", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F2000 + 0x388;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::Log(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		private void DebugInitLog()
		{
			//IL_0022: Expected O, but got I4
			int num = 187637760 + 904;
			Debug.Log(num);
		}

		[OnInitialize(new Type[] { typeof(ExampleInitializable) })]
		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81B1DA4", Offset = "0x81B1DA4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0xB799000;\n\tv20 = *([B799FC8]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_002B;\n\tv57 = System.String::Format(\"ExampleAsync is initialized with {0}\", exampleInitializable);\n\tgoto L_0020;\nL_0020:\n\tUnityEngine.Debug::Log(v57);\n\treturn;\nL_002B:\n\t*([v14 @ X20_v1+FC8]) = 1;\n\tv57 = System.String::Format(\"ExampleAsync is initialized with {0}\", exampleInitializable);\n\tgoto L_0020;\n")]
		private void DebugInitLog(ExampleInitializable exampleInitializable)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192516096;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B799FC8]");
			string message;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				message = $"ExampleAsync is initialized with {exampleInitializable}";
			}
			else
			{
				_ = 1;
				message = $"ExampleAsync is initialized with {exampleInitializable}";
			}
			Debug.Log(message);
		}

		[OnInitialize(new Type[]
		{
			typeof(ExampleInitializable),
			typeof(SecondExampleInitializable)
		})]
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81B1E60", Offset = "0x81B1E60", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2ED000 + 0x448;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::Log(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		private void ListenMultiAsync()
		{
			//IL_0022: Expected O, but got I4
			int num = 187617280 + 1096;
			Debug.Log(num);
		}

		[OnInitialize(new Type[] { typeof(ExampleInitializable) })]
		[OnInitialize(new Type[] { typeof(SecondExampleInitializable) })]
		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81B1EF4", Offset = "0x81B1EF4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F9000 + 0x708;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.Debug::Log(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		private void ListenMultiInDependentAsync()
		{
			//IL_0022: Expected O, but got I4
			int num = 187666432 + 1800;
			Debug.Log(num);
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81B1F88", Offset = "0x81B1F88", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tUnco.InitializationSystem.Runtime.Extensions::InitSystem(v40.Instance);\n\treturn;\n")]
		private void InitializeAsync()
		{
			ExampleInitializable.Instance.InitSystem();
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81B1FDC", Offset = "0x81B1FDC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tUnco.InitializationSystem.Runtime.Extensions::InitSystem(v40.Instance);\n\treturn;\n")]
		private void InitializeSecondAsync()
		{
			SecondExampleInitializable.Instance.InitSystem();
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81B2034", Offset = "0x81B2034", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ExampleListener()
		{
		}
	}
}
