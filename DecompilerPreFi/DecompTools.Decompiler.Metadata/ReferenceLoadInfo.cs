using System;
using System.Collections.Generic;
using System.Linq;

namespace DecompTools.Decompiler.Metadata;

public class ReferenceLoadInfo
{
	private readonly Dictionary<string, UnresolvedAssemblyNameReference> loadedAssemblyReferences = new Dictionary<string, UnresolvedAssemblyNameReference>();

	public bool HasErrors
	{
		get
		{
			lock (loadedAssemblyReferences)
			{
				return Enumerable.Any<KeyValuePair<string, UnresolvedAssemblyNameReference>>((IEnumerable<KeyValuePair<string, UnresolvedAssemblyNameReference>>)loadedAssemblyReferences, (Func<KeyValuePair<string, UnresolvedAssemblyNameReference>, bool>)((KeyValuePair<string, UnresolvedAssemblyNameReference> i) => i.Value.HasErrors));
			}
		}
	}

	public void AddMessage(string fullName, MessageKind kind, string message)
	{
		lock (loadedAssemblyReferences)
		{
			if (!loadedAssemblyReferences.TryGetValue(fullName, out var value))
			{
				value = new UnresolvedAssemblyNameReference(fullName);
				loadedAssemblyReferences.Add(fullName, value);
			}
			value.Messages.Add((kind, message));
		}
	}

	public void AddMessageOnce(string fullName, MessageKind kind, string message)
	{
		lock (loadedAssemblyReferences)
		{
			if (!loadedAssemblyReferences.TryGetValue(fullName, out var value))
			{
				value = new UnresolvedAssemblyNameReference(fullName);
				loadedAssemblyReferences.Add(fullName, value);
				value.Messages.Add((kind, message));
				return;
			}
			(MessageKind, string) tuple = Enumerable.LastOrDefault<(MessageKind, string)>((IEnumerable<(MessageKind, string)>)value.Messages);
			if (kind != tuple.Item1 && message != tuple.Item2)
			{
				value.Messages.Add((kind, message));
			}
		}
	}

	public bool TryGetInfo(string fullName, out UnresolvedAssemblyNameReference info)
	{
		lock (loadedAssemblyReferences)
		{
			return loadedAssemblyReferences.TryGetValue(fullName, out info);
		}
	}
}
