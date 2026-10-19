using AsmResolver.DotNet;
using AsmResolver.DotNet.Signatures;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Export.UnityProjects.Scripts;
using ICSharpCode.Decompiler.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace AssetRipper.Tests;

/// <summary>
/// Which type to leave out when ILSpy throws out of a whole-project decompilation.
/// </summary>
/// <remarks>
/// A failure inside one method's transforms can escape the parallel loop as "Error decompiling @06000ACA
/// Namespace.Type.Method", naming no file. Only the file form was read, so on SandOut nothing was skipped, the retry
/// stopped at once and every Assembly-CSharp script not yet written was lost. The token is resolved in the module
/// ILSpy read; the printed name could not be, since a nested type prints with dots like a namespace.
/// </remarks>
public sealed class DecompilationFailurePathsTests
{
	private static PEFile Build()
	{
		ModuleDefinition module = new("Game.dll");
		TypeDefinition outer = new("Game.Systems", "Outer`1", TypeAttributes.Public, module.CorLibTypeFactory.Object.Type);
		outer.GenericParameters.Add(new GenericParameter("T"));
		TypeDefinition inner = new(null, "Inner", TypeAttributes.NestedPublic, module.CorLibTypeFactory.Object.Type);
		MethodDefinition method = new("RunWallClosure", MethodAttributes.Public | MethodAttributes.Static, MethodSignature.CreateStatic(module.CorLibTypeFactory.Void));
		method.CilMethodBody = new CilMethodBody();
		method.CilMethodBody.Instructions.Add(CilOpCodes.Ret);
		inner.Methods.Add(method);
		outer.NestedTypes.Add(inner);
		module.TopLevelTypes.Add(outer);

		MemoryStream image = new();
		module.Write(image);
		image.Position = 0;
		return new PEFile("Game.dll", image);
	}

	private static int TokenOf(PEFile file, string name)
	{
		foreach (System.Reflection.Metadata.MethodDefinitionHandle handle in file.Metadata.MethodDefinitions)
		{
			if (file.Metadata.GetString(file.Metadata.GetMethodDefinition(handle).Name) == name)
			{
				return MetadataTokens.GetToken(handle);
			}
		}
		throw new InvalidOperationException(name);
	}

	[Test]
	public void AMethodLevelFailureNamesTheTopLevelTypeOfItsMethod()
	{
		PEFile file = Build();
		int token = TokenOf(file, "RunWallClosure");
		Exception failure = new AggregateException(new Exception($"Error decompiling @{token:X8} Game.Systems.Outer`1.Inner.RunWallClosure"));

		Assert.That(DecompilationFailurePaths.FailingMethodTypePaths(failure, file), Is.EqualTo(new[] { "Game/Systems/Outer" }));
		Assert.That(DecompilationFailurePaths.FailingFilePaths(failure), Is.Empty, "the file form does not read this message - which is the bug");
	}

	[Test]
	public void ATokenThatIsNotAMethodOrNotInTheModuleNamesNothing()
	{
		PEFile file = Build();
		Exception failure = new($"Error decompiling @02000002 Game.Systems.Outer and Error decompiling @0600FFFF Nowhere.M");

		Assert.That(DecompilationFailurePaths.FailingMethodTypePaths(failure, file), Is.Empty);
	}

	[Test]
	public void TheFileLevelFormStillNamesItsFile()
	{
		Exception failure = new(@"Error decompiling for 'Game\Systems\Outer.cs'");

		Assert.That(DecompilationFailurePaths.FailingFilePaths(failure), Is.EqualTo(new[] { "Game/Systems/Outer" }));
	}
}
