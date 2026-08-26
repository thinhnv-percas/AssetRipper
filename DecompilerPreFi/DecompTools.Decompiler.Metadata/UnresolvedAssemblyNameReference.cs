using System;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.Metadata;

public sealed class UnresolvedAssemblyNameReference
{
	public string FullName { get; }

	public bool HasErrors => Enumerable.Any<(MessageKind, string)>((IEnumerable<(MessageKind, string)>)Messages, (Func<(MessageKind, string), bool>)(((MessageKind, string) m) => m.Item1 == MessageKind.Error));

	public List<(MessageKind, string)> Messages { get; } = new List<(MessageKind, string)>();

	public UnresolvedAssemblyNameReference(string fullName)
	{
		FullName = fullName;
	}
}
