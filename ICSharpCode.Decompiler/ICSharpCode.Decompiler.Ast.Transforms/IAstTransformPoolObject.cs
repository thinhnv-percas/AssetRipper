namespace ICSharpCode.Decompiler.Ast.Transforms;

public interface IAstTransformPoolObject : IAstTransform
{
	void Reset(DecompilerContext context);
}
