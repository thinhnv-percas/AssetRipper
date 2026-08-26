using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory
{
	public interface IAnnotatable
	{
		IEnumerable<object> Annotations
		{
			get;
		}

		T Annotation<T>() where T : class;

		object Annotation(Type type);

		void AddAnnotation(object annotation);

		void RemoveAnnotations<T>() where T : class;

		void RemoveAnnotations(Type type);
	}
}
