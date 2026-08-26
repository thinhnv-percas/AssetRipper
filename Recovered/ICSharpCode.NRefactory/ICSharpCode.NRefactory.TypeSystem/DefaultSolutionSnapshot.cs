using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public class DefaultSolutionSnapshot : ISolutionSnapshot
	{
		private readonly Dictionary<string, IProjectContent> projectDictionary = new Dictionary<string, IProjectContent>(Platform.FileNameComparer);

		private ConcurrentDictionary<IProjectContent, ICompilation> dictionary = new ConcurrentDictionary<IProjectContent, ICompilation>();

		public DefaultSolutionSnapshot(IEnumerable<IProjectContent> projects)
		{
			foreach (IProjectContent project in projects)
			{
				if (project.ProjectFileName != null)
				{
					projectDictionary.Add(project.ProjectFileName, project);
				}
			}
		}

		public DefaultSolutionSnapshot()
		{
		}

		public IProjectContent GetProjectContent(string projectFileName)
		{
			lock (projectDictionary)
			{
				if (projectDictionary.TryGetValue(projectFileName, out IProjectContent value))
				{
					return value;
				}
				return null;
			}
		}

		public ICompilation GetCompilation(IProjectContent project)
		{
			if (project == null)
			{
				throw new ArgumentNullException("project");
			}
			return dictionary.GetOrAdd(project, (IProjectContent p) => p.CreateCompilation(this));
		}

		public void AddCompilation(IProjectContent project, ICompilation compilation)
		{
			if (project == null)
			{
				throw new ArgumentNullException("project");
			}
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			if (!dictionary.TryAdd(project, compilation))
			{
				throw new InvalidOperationException();
			}
			if (project.ProjectFileName != null)
			{
				lock (projectDictionary)
				{
					projectDictionary.Add(project.ProjectFileName, project);
				}
			}
		}
	}
}
