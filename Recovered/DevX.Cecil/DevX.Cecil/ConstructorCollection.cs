using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ConstructorCollection : CollectionBase, IReflectionVisitable
	{
		private TypeDefinition m_container;

		public MethodDefinition this[int index]
		{
			get
			{
				return base.List[index] as MethodDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public TypeDefinition Container => m_container;

		public ConstructorCollection(TypeDefinition container)
		{
			m_container = container;
		}

		public void Add(MethodDefinition value)
		{
			Attach(value);
			base.List.Add(value);
		}

		public new void Clear()
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					MethodDefinition member = (MethodDefinition)enumerator.Current;
					Detach(member);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			base.Clear();
		}

		public bool Contains(MethodDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(MethodDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, MethodDefinition value)
		{
			Attach(value);
			base.List.Insert(index, value);
		}

		public void Remove(MethodDefinition value)
		{
			base.List.Remove(value);
			Detach(value);
		}

		public new void RemoveAt(int index)
		{
			MethodDefinition value = this[index];
			Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is MethodDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(MethodDefinition).FullName);
			}
		}

		internal MethodDefinition GetConstructorInternal(bool isStatic, IList parameters)
		{
			if (parameters == null)
			{
				parameters = Type.EmptyTypes;
			}
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					MethodDefinition methodDefinition = (MethodDefinition)enumerator.Current;
					if (methodDefinition.IsStatic == isStatic && methodDefinition.Parameters.Count == parameters.Count)
					{
						bool flag = true;
						for (int i = 0; i < parameters.Count; i++)
						{
							object obj = parameters[i];
							string b;
							if (obj is Type)
							{
								b = ReflectionHelper.GetTypeSignature(obj as Type);
							}
							else if (obj is TypeReference)
							{
								b = (obj as TypeReference).FullName;
							}
							else
							{
								if (!(obj is ParameterDefinition))
								{
									throw new NotSupportedException();
								}
								b = (obj as ParameterDefinition).ParameterType.FullName;
							}
							if (methodDefinition.Parameters[i].ParameterType.FullName != b)
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							return methodDefinition;
						}
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		public MethodDefinition GetConstructor(bool isStatic, Type[] parameters)
		{
			return GetConstructorInternal(isStatic, parameters);
		}

		public MethodDefinition GetConstructor(bool isStatic, TypeReference[] parameters)
		{
			return GetConstructorInternal(isStatic, parameters);
		}

		public MethodDefinition GetConstructor(bool isStatic, ParameterDefinitionCollection parameters)
		{
			return GetConstructorInternal(isStatic, parameters);
		}

		private void Attach(MemberReference member)
		{
			if (member.DeclaringType != null)
			{
				throw new ReflectionException("Member already attached, clone it instead");
			}
			member.DeclaringType = m_container;
		}

		private void Detach(MemberReference member)
		{
			member.DeclaringType = null;
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitConstructorCollection(this);
		}
	}
}
