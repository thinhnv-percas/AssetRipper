using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedFile
{
	string FileName { get; }

	DateTime? LastWriteTime { get; set; }

	IList<IUnresolvedTypeDefinition> TopLevelTypeDefinitions { get; }

	IList<IUnresolvedAttribute> AssemblyAttributes { get; }

	IList<IUnresolvedAttribute> ModuleAttributes { get; }

	IList<Error> Errors { get; }

	IUnresolvedTypeDefinition GetTopLevelTypeDefinition(TextLocation location);

	IUnresolvedTypeDefinition GetInnermostTypeDefinition(TextLocation location);

	IUnresolvedMember GetMember(TextLocation location);
}
