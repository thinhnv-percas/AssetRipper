using System;

namespace Mon3.Cecil;

[Flags]
public enum ManifestResourceAttributes : uint
{
	VisibilityMask = 7u,
	Public = 1u,
	Private = 2u
}
