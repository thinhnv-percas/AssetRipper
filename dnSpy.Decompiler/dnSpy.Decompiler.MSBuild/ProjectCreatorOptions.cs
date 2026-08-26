using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ProjectCreatorOptions
{
	public IMSBuildProjectWriterLogger Logger { get; set; }

	public IMSBuildProgressListener ProgressListener { get; set; }

	public List<ProjectModuleOptions> ProjectModules { get; }

	public ProjectVersion ProjectVersion { get; set; }

	public int NumberOfThreads { get; set; }

	public string Directory { get; }

	public string SolutionFilename { get; set; }

	public List<string> UserGACPaths { get; }

	public CancellationToken CancellationToken { get; }

	public Func<TextWriter, IDecompilerOutput> CreateDecompilerOutput { get; set; }

	public ProjectCreatorOptions(string directory, CancellationToken cancellationToken)
	{
		Directory = directory ?? throw new ArgumentNullException("directory");
		CancellationToken = cancellationToken;
		ProjectModules = new List<ProjectModuleOptions>();
		UserGACPaths = new List<string>();
		CreateDecompilerOutput = (TextWriter textWriter) => new TextWriterDecompilerOutput(textWriter);
	}
}
