namespace ICSharpCode.NRefactory.CSharp
{
	public enum PreProcessorDirectiveType : byte
	{
		Invalid,
		Region,
		Endregion,
		If,
		Endif,
		Elif,
		Else,
		Define,
		Undef,
		Error,
		Warning,
		Pragma,
		Line
	}
}
