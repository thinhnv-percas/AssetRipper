using Mono.CompilerServices.SymbolWriter;
using System;
using System.Reflection.Emit;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal static class SymbolWriter
	{
		public static MonoSymbolWriter symwriter;

		public static bool HasSymbolWriter => symwriter != null;

		private static int GetILOffset(ILGenerator ig)
		{
			return ig.ILOffset;
		}

		public static Guid GetGuid(ModuleBuilder module)
		{
			return module.ModuleVersionId;
		}

		public static void DefineLocalVariable(string name, LocalBuilder builder)
		{
			if (symwriter != null)
			{
				symwriter.DefineLocalVariable(builder.LocalIndex, name);
			}
		}

		public static SourceMethodBuilder OpenMethod(ICompileUnit file, IMethodDef method)
		{
			if (symwriter != null)
			{
				return symwriter.OpenMethod(file, -1, method);
			}
			return null;
		}

		public static void CloseMethod()
		{
			if (symwriter != null)
			{
				symwriter.CloseMethod();
			}
		}

		public static int OpenScope(ILGenerator ig)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ig);
				return symwriter.OpenScope(iLOffset);
			}
			return -1;
		}

		public static void CloseScope(ILGenerator ig)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ig);
				symwriter.CloseScope(iLOffset);
			}
		}

		public static void DefineAnonymousScope(int id)
		{
			if (symwriter != null)
			{
				symwriter.DefineAnonymousScope(id);
			}
		}

		public static void DefineScopeVariable(int scope, LocalBuilder builder)
		{
			if (symwriter != null)
			{
				symwriter.DefineScopeVariable(scope, builder.LocalIndex);
			}
		}

		public static void DefineScopeVariable(int scope)
		{
			if (symwriter != null)
			{
				symwriter.DefineScopeVariable(scope, -1);
			}
		}

		public static void DefineCapturedLocal(int scope_id, string name, string captured_name)
		{
			if (symwriter != null)
			{
				symwriter.DefineCapturedLocal(scope_id, name, captured_name);
			}
		}

		public static void DefineCapturedParameter(int scope_id, string name, string captured_name)
		{
			if (symwriter != null)
			{
				symwriter.DefineCapturedParameter(scope_id, name, captured_name);
			}
		}

		public static void DefineCapturedThis(int scope_id, string captured_name)
		{
			if (symwriter != null)
			{
				symwriter.DefineCapturedThis(scope_id, captured_name);
			}
		}

		public static void DefineCapturedScope(int scope_id, int id, string captured_name)
		{
			if (symwriter != null)
			{
				symwriter.DefineCapturedScope(scope_id, id, captured_name);
			}
		}

		public static void OpenCompilerGeneratedBlock(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.OpenCompilerGeneratedBlock(iLOffset);
			}
		}

		public static void CloseCompilerGeneratedBlock(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.CloseCompilerGeneratedBlock(iLOffset);
			}
		}

		public static void StartIteratorBody(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.StartIteratorBody(iLOffset);
			}
		}

		public static void EndIteratorBody(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.EndIteratorBody(iLOffset);
			}
		}

		public static void StartIteratorDispatcher(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.StartIteratorDispatcher(iLOffset);
			}
		}

		public static void EndIteratorDispatcher(EmitContext ec)
		{
			if (symwriter != null)
			{
				int iLOffset = GetILOffset(ec.ig);
				symwriter.EndIteratorDispatcher(iLOffset);
			}
		}

		public static void MarkSequencePoint(ILGenerator ig, Location loc)
		{
			if (symwriter != null)
			{
				SourceFileEntry sourceFileEntry = loc.SourceFile.SourceFileEntry;
				int iLOffset = GetILOffset(ig);
				symwriter.MarkSequencePoint(iLOffset, sourceFileEntry, loc.Row, loc.Column, is_hidden: false);
			}
		}

		public static void Reset()
		{
			symwriter = null;
		}
	}
}
