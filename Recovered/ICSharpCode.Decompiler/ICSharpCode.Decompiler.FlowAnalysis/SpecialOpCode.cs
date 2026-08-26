namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public enum SpecialOpCode
	{
		None,
		Phi,
		PrepareByRefCall,
		PrepareByOutCall,
		PrepareForFieldAccess,
		WriteAfterByRefOrOutCall,
		Uninitialized,
		Parameter,
		Exception,
		InitObj
	}
}
