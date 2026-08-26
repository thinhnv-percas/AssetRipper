#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dnSpy.Decompiler.Properties;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class MSBuildProjectCreator
{
	private sealed class MyLogger : IMSBuildProjectWriterLogger
	{
		private readonly MSBuildProjectCreator owner;

		private readonly IMSBuildProjectWriterLogger logger;

		public MyLogger(MSBuildProjectCreator owner, IMSBuildProjectWriterLogger logger)
		{
			this.owner = owner;
			this.logger = logger ?? NoMSBuildProjectWriterLogger.Instance;
		}

		public void Error(string message)
		{
			Interlocked.Increment(ref owner.errors);
			logger.Error(message);
		}
	}

	private readonly ProjectCreatorOptions options;

	private readonly List<Project> projects;

	private readonly IMSBuildProjectWriterLogger logger;

	private readonly IMSBuildProgressListener progressListener;

	private int errors;

	private int totalProgress;

	public IEnumerable<string> ProjectFilenames => projects.Select((Project a) => a.Filename);

	public string SolutionFilename => Path.Combine(options.Directory, options.SolutionFilename);

	public MSBuildProjectCreator(ProjectCreatorOptions options)
	{
		this.options = options ?? throw new ArgumentNullException("options");
		logger = new MyLogger(this, options.Logger);
		progressListener = options.ProgressListener ?? NoMSBuildProgressListener.Instance;
		projects = new List<Project>();
	}

	public void Create()
	{
		SatelliteAssemblyFinder satelliteAssemblyFinder = null;
		try
		{
			ParallelOptions parallelOptions = new ParallelOptions
			{
				CancellationToken = options.CancellationToken,
				MaxDegreeOfParallelism = ((options.NumberOfThreads <= 0) ? Environment.ProcessorCount : options.NumberOfThreads)
			};
			FilenameCreator filenameCreator = new FilenameCreator(options.Directory);
			DecompileContext ctx = new DecompileContext(options.CancellationToken, logger);
			satelliteAssemblyFinder = new SatelliteAssemblyFinder();
			Parallel.ForEach(options.ProjectModules, parallelOptions, delegate(ProjectModuleOptions modOpts)
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				string projDir;
				lock (filenameCreator)
				{
					projDir = filenameCreator.Create(modOpts.Module);
				}
				Project project = new Project(modOpts, projDir, satelliteAssemblyFinder, options.CreateDecompilerOutput);
				lock (projects)
				{
					projects.Add(project);
				}
				project.CreateProjectFiles(ctx);
			});
			IJob[] array = GetJobs().ToArray();
			bool flag = !string.IsNullOrEmpty(options.SolutionFilename);
			int num = array.Length + projects.Count;
			if (flag)
			{
				num++;
			}
			progressListener.SetMaxProgress(num);
			Parallel.ForEach(GetJobs(), parallelOptions, delegate(IJob job)
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				try
				{
					job.Create(ctx);
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (Exception ex4)
				{
					if (job is IFileJob fileJob)
					{
						logger.Error(string.Format(dnSpy_Decompiler_Resources.MSBuild_FileCreationFailed3, fileJob.Filename, job.Description, ex4.Message));
					}
					else
					{
						logger.Error(string.Format(dnSpy_Decompiler_Resources.MSBuild_FileCreationFailed2, job.Description, ex4.Message));
					}
				}
				progressListener.SetProgress(Interlocked.Increment(ref totalProgress));
			});
			Parallel.ForEach(projects, parallelOptions, delegate(Project p)
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				try
				{
					ProjectWriter projectWriter = new ProjectWriter(p, p.Options.ProjectVersion ?? options.ProjectVersion, projects, options.UserGACPaths);
					projectWriter.Write();
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (Exception ex4)
				{
					logger.Error(string.Format(dnSpy_Decompiler_Resources.MSBuild_FailedToCreateProjectFile, p.Filename, ex4.Message));
				}
				progressListener.SetProgress(Interlocked.Increment(ref totalProgress));
			});
			if (flag)
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				try
				{
					SolutionWriter solutionWriter = new SolutionWriter(options.ProjectVersion, projects, SolutionFilename);
					solutionWriter.Write();
				}
				catch (OperationCanceledException)
				{
					throw;
				}
				catch (Exception ex2)
				{
					logger.Error(string.Format(dnSpy_Decompiler_Resources.MSBuild_FailedToCreateSolutionFile, SolutionFilename, ex2.Message));
				}
				progressListener.SetProgress(Interlocked.Increment(ref totalProgress));
			}
			Debug.Assert(totalProgress == num);
			progressListener.SetProgress(num);
		}
		finally
		{
			if (satelliteAssemblyFinder != null)
			{
				satelliteAssemblyFinder.Dispose();
			}
		}
	}

	private IEnumerable<IJob> GetJobs()
	{
		foreach (Project p in projects)
		{
			foreach (IJob job in p.GetJobs())
			{
				yield return job;
			}
		}
	}
}
