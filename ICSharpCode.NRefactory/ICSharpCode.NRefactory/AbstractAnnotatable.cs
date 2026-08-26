using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory;

[Serializable]
public abstract class AbstractAnnotatable : IAnnotatable
{
	private sealed class AnnotationList : List<object>, ICloneable
	{
		public AnnotationList(int initialCapacity)
			: base(initialCapacity)
		{
		}

		public object Clone()
		{
			lock (this)
			{
				AnnotationList annotationList = new AnnotationList(base.Count);
				for (int i = 0; i < base.Count; i++)
				{
					object obj = base[i];
					ICloneable cloneable = obj as ICloneable;
					annotationList.Add((cloneable != null) ? cloneable.Clone() : obj);
				}
				return annotationList;
			}
		}
	}

	private object annotations;

	public IEnumerable<object> Annotations
	{
		get
		{
			object obj = annotations;
			if (obj is AnnotationList annotationList)
			{
				lock (annotationList)
				{
					return annotationList.ToArray();
				}
			}
			if (obj != null)
			{
				return new object[1] { obj };
			}
			return Enumerable.Empty<object>();
		}
	}

	protected void CloneAnnotations()
	{
		if (annotations is ICloneable cloneable)
		{
			annotations = cloneable.Clone();
		}
	}

	public void AddAnnotationsFrom(AbstractAnnotatable other)
	{
		if (other == null)
		{
			return;
		}
		foreach (object annotation in other.Annotations)
		{
			AddAnnotation(annotation);
		}
	}

	public virtual void AddAnnotation(object annotation)
	{
		if (annotation == null)
		{
			throw new ArgumentNullException("annotation");
		}
		object obj;
		AnnotationList annotationList2;
		do
		{
			obj = Interlocked.CompareExchange(ref annotations, annotation, null);
			if (obj == null)
			{
				break;
			}
			if (!(obj is AnnotationList annotationList))
			{
				annotationList2 = new AnnotationList(4);
				annotationList2.Add(obj);
				annotationList2.Add(annotation);
				continue;
			}
			lock (annotationList)
			{
				annotationList.Add(annotation);
				break;
			}
		}
		while (Interlocked.CompareExchange(ref annotations, annotationList2, obj) != obj);
	}

	public virtual void RemoveAnnotations<T>() where T : class
	{
		object obj;
		do
		{
			obj = annotations;
			if (!(obj is AnnotationList annotationList))
			{
				continue;
			}
			lock (annotationList)
			{
				annotationList.RemoveAll((object obj2) => obj2 is T);
				break;
			}
		}
		while (obj is T && Interlocked.CompareExchange(ref annotations, null, obj) != obj);
	}

	public virtual void RemoveAnnotations(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		object obj;
		do
		{
			obj = annotations;
			if (obj is AnnotationList annotationList)
			{
				lock (annotationList)
				{
					annotationList.RemoveAll(type.IsInstanceOfType);
					break;
				}
			}
		}
		while (type.IsInstanceOfType(obj) && Interlocked.CompareExchange(ref annotations, null, obj) != obj);
	}

	public T Annotation<T>() where T : class
	{
		object obj = annotations;
		if (obj is AnnotationList annotationList)
		{
			lock (annotationList)
			{
				foreach (object item in annotationList)
				{
					if (item is T result)
					{
						return result;
					}
				}
				return null;
			}
		}
		return obj as T;
	}

	public T? AnnotationVT<T>() where T : struct
	{
		object obj = annotations;
		if (obj is AnnotationList annotationList)
		{
			lock (annotationList)
			{
				foreach (object item in annotationList)
				{
					if (item is T)
					{
						return (T)item;
					}
				}
				return null;
			}
		}
		if (obj is T)
		{
			return (T)obj;
		}
		return null;
	}

	public object Annotation(Type type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		object obj = annotations;
		if (obj is AnnotationList annotationList)
		{
			lock (annotationList)
			{
				foreach (object item in annotationList)
				{
					if (type.IsInstanceOfType(item))
					{
						return item;
					}
				}
			}
		}
		else if (type.IsInstanceOfType(obj))
		{
			return obj;
		}
		return null;
	}
}
