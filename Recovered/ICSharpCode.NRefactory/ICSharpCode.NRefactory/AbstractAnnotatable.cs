using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ICSharpCode.NRefactory
{
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
				AnnotationList annotationList = obj as AnnotationList;
				if (annotationList != null)
				{
					lock (annotationList)
					{
						return annotationList.ToArray();
					}
				}
				if (obj != null)
				{
					return new object[1]
					{
						obj
					};
				}
				return Enumerable.Empty<object>();
			}
		}

		protected void CloneAnnotations()
		{
			ICloneable cloneable = annotations as ICloneable;
			if (cloneable != null)
			{
				annotations = cloneable.Clone();
			}
		}

		public virtual void AddAnnotation(object annotation)
		{
			if (annotation == null)
			{
				throw new ArgumentNullException("annotation");
			}
			AnnotationList annotationList;
			while (true)
			{
				object obj = Interlocked.CompareExchange(ref annotations, annotation, null);
				if (obj == null)
				{
					return;
				}
				annotationList = (obj as AnnotationList);
				if (annotationList != null)
				{
					break;
				}
				annotationList = new AnnotationList(4);
				annotationList.Add(obj);
				annotationList.Add(annotation);
				if (Interlocked.CompareExchange(ref annotations, annotationList, obj) != obj)
				{
					continue;
				}
				return;
			}
			lock (annotationList)
			{
				annotationList.Add(annotation);
			}
		}

		public virtual void RemoveAnnotations<T>() where T : class
		{
			AnnotationList annotationList;
			while (true)
			{
				object obj2 = annotations;
				annotationList = (obj2 as AnnotationList);
				if (annotationList != null)
				{
					break;
				}
				if (!(obj2 is T) || Interlocked.CompareExchange(ref annotations, null, obj2) == obj2)
				{
					return;
				}
			}
			lock (annotationList)
			{
				annotationList.RemoveAll((object obj) => obj is T);
			}
		}

		public virtual void RemoveAnnotations(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			AnnotationList annotationList;
			while (true)
			{
				object obj = annotations;
				annotationList = (obj as AnnotationList);
				if (annotationList != null)
				{
					break;
				}
				if (!type.IsInstanceOfType(obj) || Interlocked.CompareExchange(ref annotations, null, obj) == obj)
				{
					return;
				}
			}
			lock (annotationList)
			{
				annotationList.RemoveAll(type.IsInstanceOfType);
			}
		}

		public T Annotation<T>() where T : class
		{
			object obj = annotations;
			AnnotationList annotationList = obj as AnnotationList;
			if (annotationList != null)
			{
				lock (annotationList)
				{
					foreach (object item in annotationList)
					{
						T val = item as T;
						if (val != null)
						{
							return val;
						}
					}
					return null;
				}
			}
			return obj as T;
		}

		public object Annotation(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			object obj = annotations;
			AnnotationList annotationList = obj as AnnotationList;
			if (annotationList != null)
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
}
