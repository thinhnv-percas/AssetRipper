using System;
using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ConversionResolveResult : ResolveResult
{
	public readonly ResolveResult Input;

	public readonly Conversion Conversion;

	public readonly bool CheckForOverflow;

	public override bool IsError => !Conversion.IsValid;

	public ConversionResolveResult(IType targetType, ResolveResult input, Conversion conversion)
		: base(targetType)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		if (conversion == null)
		{
			throw new ArgumentNullException("conversion");
		}
		Input = input;
		Conversion = conversion;
	}

	public ConversionResolveResult(IType targetType, ResolveResult input, Conversion conversion, bool checkForOverflow)
		: this(targetType, input, conversion)
	{
		CheckForOverflow = checkForOverflow;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return new ResolveResult[1] { Input };
	}
}
