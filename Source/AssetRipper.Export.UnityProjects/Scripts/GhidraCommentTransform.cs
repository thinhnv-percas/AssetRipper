using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Transforms;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.TypeSystem;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// Puts the pseudo C that Ghidra recovered for a method inside the method it belongs to.
/// </summary>
/// <remarks>
/// The recovered code is the real logic of the method, which is otherwise only available in a separate
/// directory of C files. It is C rather than C#, so it can only be a comment; putting it inside the
/// body rather than above the signature keeps the reading order of the file intact, so that scanning a
/// class shows its members rather than pages of C between them.
/// <para>
/// A method with no body, such as an abstract or extern one, has nowhere to put it, so those fall back
/// to sitting above the declaration.
/// </para>
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
				Attach(declaration, code);
				AttachedCount++;
			}
		}
	}

	private void Attach(EntityDeclaration declaration, string code)
	{
		// A comment in this syntax tree is trivia belonging to a node rather than a node of its own, so
		// it has to hang off the first statement of the body. A body with no statements offers nothing
		// to hang it on, and neither does a method that has no body at all.
		if (FindFirstStatement(declaration) is Statement first)
		{
			foreach (Comment comment in BuildComments(code))
			{
				first.AddLeadingTrivia(comment);
			}
		}
		else
		{
			AttachAbove(declaration, code);
		}
	}

	private static Statement? FindFirstStatement(EntityDeclaration declaration)
	{
		BlockStatement? body = FindBody(declaration);

		try
		{
			return body?.Statements.FirstOrDefault();
		}
		catch (Exception)
		{
			// A declaration with no body answers with a null object rather than null in some shapes,
			// and asking it for its statements is not always allowed.
			return null;
		}
	}

	/// <summary>
	/// The block a method's statements live in, or null when it has none.
	/// </summary>
	/// <remarks>
	/// A constructor and an operator are declarations in their own right rather than methods with a
	/// body property in common, so each kind is asked for its own.
	/// </remarks>
	private static BlockStatement? FindBody(EntityDeclaration declaration) => declaration switch
	{
		MethodDeclaration method => method.Body,
		ConstructorDeclaration constructor => constructor.Body,
		DestructorDeclaration destructor => destructor.Body,
		OperatorDeclaration @operator => @operator.Body,
		Accessor accessor => accessor.Body,
		_ => null,
	};

	private void AttachAbove(EntityDeclaration declaration, string code)
	{
		foreach (Comment comment in BuildComments(code))
		{
			declaration.AddLeadingTrivia(comment);
		}
	}

	private IEnumerable<Comment> BuildComments(string code)
	{
		yield return new Comment(" Ghidra decompilation:");

		int written = 0;
		foreach (string line in code.Split('\n'))
		{
			if (written >= MaximumLines)
			{
				yield return new Comment(" ... truncated");
				break;
			}

			yield return new Comment(" " + line.TrimEnd('\r'));
			written++;
		}
	}
}
