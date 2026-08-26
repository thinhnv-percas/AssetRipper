namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal interface IDynamicBinder
	{
		Expression CreateCallSiteBinder(ResolveContext ec, Arguments args);
	}
}
