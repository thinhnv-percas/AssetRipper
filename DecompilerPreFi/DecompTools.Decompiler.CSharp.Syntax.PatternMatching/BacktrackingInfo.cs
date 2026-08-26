using System.Collections.Generic;

namespace DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

public class BacktrackingInfo
{
	internal Stack<Pattern.PossibleMatch> backtrackingStack = new Stack<Pattern.PossibleMatch>();
}
