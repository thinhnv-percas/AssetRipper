using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class IndentState : ICloneable
	{
		public CSharpIndentEngine Engine;

		public IndentState Parent;

		public Indent ThisLineIndent;

		public Indent NextLineIndent;

		protected IndentState()
		{
		}

		protected IndentState(IndentState prototype, CSharpIndentEngine engine)
		{
			Engine = engine;
			Parent = ((prototype.Parent != null) ? prototype.Parent.Clone(engine) : null);
			ThisLineIndent = prototype.ThisLineIndent.Clone();
			NextLineIndent = prototype.NextLineIndent.Clone();
		}

		object ICloneable.Clone()
		{
			return Clone(Engine);
		}

		public abstract IndentState Clone(CSharpIndentEngine engine);

		internal void Initialize(CSharpIndentEngine engine, IndentState parent = null)
		{
			Parent = parent;
			Engine = engine;
			InitializeState();
		}

		public virtual void InitializeState()
		{
			ThisLineIndent = new Indent(Engine.textEditorOptions);
			NextLineIndent = ThisLineIndent.Clone();
		}

		public virtual void OnExit()
		{
			if (Parent != null)
			{
				if (Engine.currentChar == Engine.newLineChar)
				{
					Parent.Push(Engine.newLineChar);
				}
				Parent.ThisLineIndent = ThisLineIndent.Clone();
			}
		}

		public void ChangeState<T>() where T : IndentState, new()
		{
			T val = new T();
			val.Initialize(Engine, Engine.currentState);
			Engine.currentState = val;
		}

		public void ExitState()
		{
			OnExit();
			Engine.currentState = (Engine.currentState.Parent ?? new GlobalBodyState(Engine));
		}

		public virtual void Push(char ch)
		{
			if (ch == Engine.newLineChar)
			{
				int continuationIndent = Engine.textEditorOptions.ContinuationIndent;
				while (NextLineIndent.CurIndent - ThisLineIndent.CurIndent > continuationIndent && NextLineIndent.PopIf(IndentType.Continuation))
				{
				}
				ThisLineIndent = NextLineIndent.Clone();
			}
		}

		public virtual void CheckKeyword(string keyword)
		{
		}

		public virtual void CheckKeywordOnPush(string keyword)
		{
		}
	}
}
