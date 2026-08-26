using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Utilities;

namespace dnSpy.Decompiler.ILSpy;

internal static class ContentTypeDefinitions
{
	[Export]
	[Name("Decompiler ILSpy")]
	[BaseDefinition("Decompiled Code")]
	private static readonly ContentTypeDefinition DecompilerILSpyContentTypeDefinition;

	[Export]
	[Name("C# ILSpy")]
	[BaseDefinition("Decompiler ILSpy")]
	[BaseDefinition("C#-code")]
	private static readonly ContentTypeDefinition CSharpILSpyContentTypeDefinition;

	[Export]
	[Name("VB ILSpy")]
	[BaseDefinition("Decompiler ILSpy")]
	[BaseDefinition("VB-code")]
	private static readonly ContentTypeDefinition VisualBasicILSpyContentTypeDefinition;

	[Export]
	[Name("IL ILSpy")]
	[BaseDefinition("Decompiler ILSpy")]
	[BaseDefinition("MSIL")]
	private static readonly ContentTypeDefinition ILILSpyContentTypeDefinition;

	[Export]
	[Name("ILAst ILSpy")]
	[BaseDefinition("Decompiler ILSpy")]
	private static readonly ContentTypeDefinition ILAstILSpyContentTypeDefinition;
}
