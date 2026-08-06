using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Transforms;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.TypeSystem;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// Attaches the pseudo C that Ghidra recovered for a method as a comment above its declaration.
/// </summary>
/// <remarks>
/// The comment is the real logic of the method, which is otherwise only available in a separate
/// directory of C files. It is C rather than C#, so it cannot become a method body; attaching it as
/// leading trivia keeps it next to the signature it belongs to.
/// </remarks>
public sealed class GhidraCommentTransform(GhidraDecompilationIndex index) : IAstTransform
{
	/// <summary>
	/// Long bodies are truncated so that a single method cannot bury the rest of the file.
	/// </summary>
	public int MaximumLines { get; init; } = 200;

	/// <summary>
	/// The number of methods that received a comment during the last run.
	/// </summary>
	public int AttachedCount { get; private set; }

	public void Run(AstNode rootNode, TransformContext context)
	{
		foreach (AstNode node in rootNode.DescendantsAndSelf)
		{
			if (node is not EntityDeclaration declaration)
			{
				continue;
			}

			// Declarations carry their resolved symbol as a resolve result rather than the member itself.
			if (declaration.Annotation<MemberResolveResult>()?.Member is not IMethod method)
			{
				continue;
			}

			string key = GhidraDecompilationIndex.CreateKey(method.DeclaringType?.FullName, method.Name, method.Parameters.Count);
			if (index.TryGetCode(key, out string? code))
			{
				AttachComment(declaration, code);
				AttachedCount++;
			}
		}
	}

	private void AttachComment(EntityDeclaration declaration, string code)
	{
		declaration.AddLeadingTrivia(new Comment(" Ghidra decompilation:"));

		int written = 0;
		foreach (string line in code.Split('\n'))
		{
			if (written >= MaximumLines)
			{
				declaration.AddLeadingTrivia(new Comment(" ... truncated"));
				break;
			}

			declaration.AddLeadingTrivia(new Comment(" " + line.TrimEnd('\r')));
			written++;
		}
	}
}
