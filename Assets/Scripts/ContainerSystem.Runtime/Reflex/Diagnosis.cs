using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Extensions;
using Reflex.Logging;
using Reflex.Resolvers;
using UnityEngine;

namespace Reflex
{
	[Token(Token = "0x200000D")]
	internal static class Diagnosis
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000015")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000016")]
			public static Func<StackFrame, bool> _003C_003E9__5_0;

			[Token(Token = "0x600002C")]
			[Address(RVA = "0x3F30B2C", Offset = "0x3F30B2C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Reflex.Diagnosis+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600002D")]
			[Address(RVA = "0x3F30B90", Offset = "0x3F30B90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetCallSite_003Eb__5_0(StackFrame f)
			{
				string fileName = f.GetFileName();
				bool flag = fileName == null;
				return !flag;
			}
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x6000025")]
		[Address(RVA = "0x3F2FC90", Offset = "0x3F2FC90", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv87 = v85._registry == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_004B;\n\tgoto L_0059;\nL_004B:\n\tv108 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::GetOrCreateValue(v85._registry, resolver);\n\tv121 = v108.Resolutions + 1;\n\tv108.Resolutions = v121;\n\treturn;\nL_0059:\n\tthrow System.NullReferenceException;\n")]
		internal static void IncrementResolutions(IResolver resolver)
		{
			if (ResolverExtensions._registry != null)
			{
				ResolverDebugProperties orCreateValue = ResolverExtensions._registry.GetOrCreateValue(resolver);
				int resolutions = orCreateValue.Resolutions + 1;
				orCreateValue.Resolutions = resolutions;
				return;
			}
			throw new NullReferenceException();
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x6000026")]
		[Address(RVA = "0x3F2FE38", Offset = "0x3F2FE38", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0019;\nL_0019:\n\tgoto L_001D;\nL_001D:\n\tgoto L_0020;\nL_0020:\n\tv92 = v90._registry == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_0055;\n\tgoto L_00A3;\nL_0055:\n\tv116 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::GetOrCreateValue(v90._registry, resolver);\n\tv153 = v116.Instances;\n\tv158 = new System.WeakReference();\n\tSystem.WeakReference::.ctor(v158, instance);\n\tv231 = Reflex.Diagnosis::GetCallSite(3);\n\tSystem.ValueTuple`2<System.Object, System.Object>::.ctor(&v134 @ stack_-40_v3 (System.ValueTuple`2<System.Object, System.Object>), v158, v231);\n\tgoto L_009A;\nL_009A:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Object, System.Object>>::Add(v153, v134);\n\treturn;\nL_00A3:\n\tthrow System.NullReferenceException;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RegisterInstance(IResolver resolver, object instance)
		{
			if (ResolverExtensions._registry != null)
			{
				ResolverDebugProperties orCreateValue = ResolverExtensions._registry.GetOrCreateValue(resolver);
				List<(WeakReference, List<CallSite>)> instances = orCreateValue.Instances;
				WeakReference item = new WeakReference(instance);
				List<CallSite> callSite = GetCallSite(3);
				(object, object) item2 = (item, callSite);
				instances.Add(((WeakReference, List<CallSite>))item2);
				return;
			}
			throw new NullReferenceException();
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x6000027")]
		[Address(RVA = "0x3F3062C", Offset = "0x3F3062C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv90 = v88._registry == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_004E;\n\tgoto L_0079;\nL_004E:\n\tv111 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::GetOrCreateValue(v88._registry, resolver);\n\tv122 = v111.Instances;\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.WeakReference, System.Collections.Generic.List`1<CallSite>>>::Clear(v122);\n\tv134 = v122.Count < 1;\n\tif (v134) goto L_0078;\n\treturn;\nL_0078:\n\treturn;\nL_0079:\n\tthrow System.NullReferenceException;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void ClearInstances(IResolver resolver)
		{
			if (ResolverExtensions._registry != null)
			{
				ResolverDebugProperties orCreateValue = ResolverExtensions._registry.GetOrCreateValue(resolver);
				List<(WeakReference, List<CallSite>)> instances = orCreateValue.Instances;
				instances.Clear();
				if (instances.Count < 1)
				{
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x6000028")]
		[Address(RVA = "0x3F30768", Offset = "0x3F30768", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv90 = v88._registry == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_004E;\n\tgoto L_0064;\nL_004E:\n\tv111 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Resolvers.IResolver, Reflex.Resolvers.ResolverDebugProperties>::GetOrCreateValue(v88._registry, resolver);\n\tv118 = Reflex.Diagnosis::GetCallSite(2);\n\tSystem.Collections.Generic.List`1<CallSite>::AddRange(v111.BindingCallsite, v118);\n\treturn;\nL_0064:\n\tthrow System.NullReferenceException;\n")]
		internal static void RegisterCallSite(IResolver resolver)
		{
			if (ResolverExtensions._registry != null)
			{
				ResolverDebugProperties orCreateValue = ResolverExtensions._registry.GetOrCreateValue(resolver);
				List<CallSite> callSite = GetCallSite(2);
				orCreateValue.BindingCallsite.AddRange(callSite);
				return;
			}
			throw new NullReferenceException();
		}

		[Conditional("REFLEX_DEBUG")]
		[Token(Token = "0x6000029")]
		[Address(RVA = "0x3F30890", Offset = "0x3F30890", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_001F;\nL_001F:\n\tv90 = v88._containerDebugProperties == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_004E;\n\tgoto L_0064;\nL_004E:\n\tv111 = System.Runtime.CompilerServices.ConditionalWeakTable`2<Reflex.Core.Container, Reflex.Logging.ContainerDebugProperties>::GetOrCreateValue(v88._containerDebugProperties, container);\n\tv118 = Reflex.Diagnosis::GetCallSite(2);\n\tSystem.Collections.Generic.List`1<CallSite>::AddRange(v111.BuildCallsite, v118);\n\treturn;\nL_0064:\n\tthrow System.NullReferenceException;\n")]
		internal static void RegisterBuildCallSite(Container container)
		{
			if (ContainerExtensions._containerDebugProperties != null)
			{
				ContainerDebugProperties orCreateValue = ContainerExtensions._containerDebugProperties.GetOrCreateValue(container);
				List<CallSite> callSite = GetCallSite(2);
				orCreateValue.BuildCallsite.AddRange(callSite);
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x3F3002C", Offset = "0x3F3002C", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tSystem.Diagnostics.StackTrace::.ctor(v73, skipFrames, 1);\n\tv94 = System.Diagnostics.StackTrace::GetFrames(v73);\n\tgoto L_0060;\nL_0060:\n\tv127 = 0xB2C8000 + 0x8C0;\n\tv139 = v137.<>9__5_0 == 0;\nL_FFFFFFFF:\n\tv179 = v94;\n\tif (v139) goto L_00AA;\n\tv181 = *([v127 @ X23_v19 (System.Int32)]);\n\tv186 = System.Linq.Enumerable::Where(v179, v137.<>9__5_0);\nL_006D:\n\tv192 = *([v186 @ X0_v95 (System.Collections.Generic.IEnumerable`1<System.Object>)]);\n\tv178 = *([v192 @ X8_v42 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+12E]);\n\tv188 = *([v192 @ X8_v42 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+12E]) == 0;\n\tif (v188) goto L_0092;\n\tv174 = *([v192 @ X8_v42 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Object>>)+B0]) + 8;\n\tv174 = v174 + 0x10;\n\tv518 = v178 - 1;\n\tv507 = v178 != 1;\nL_FFFFFFFF:\n\tv178 = v518;\n\tif (v507) goto L_0073;\nL_0092:\n\tv270 = System.Collections.Generic.IEnumerable`1<System.Diagnostics.StackFrame>::GetEnumerator(v186);\n\tv624 = v270 == 0;\n\tv273 = ~v624;\nL_FFFFFFFF:\n\tv237 = v270;\nL_FFFFFFFF:\n\tv667 = &v237 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<System.Diagnostics.StackFrame>);\nL_FFFFFFFF:\n\tv241 = 0;\n\tif (v273) goto L_FFFFFFFF;\n\tgoto L_01F0;\nL_00AA:\n\tgoto L_00B2;\n\tv181 = *([v127 @ X23_v19 (System.Int32)]);\n\tv186 = System.Linq.Enumerable::Where(v94, v355);\n\tv640 = v186 == 0;\n\tv117 = ~v640;\nL_FFFFFFFF:\n\tv179 = v94;\nL_FFFFFFFF:\n\tv192 = Reflex.Diagnosis+<>c;\n\tif (v117) goto L_006D;\n\tv131 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv179 = v94;\nL_FFFFFFFF:\n\tv181 = v181;\nL_FFFFFFFF:\n\tv186 = v131;\nL_00CA:\n\tv199 = *([v174 @ X10_v27]) << 4;\n\tv200 = v192 + v199;\n\tv201 = v200 + 0x138;\n\t*([v201 @ X8_v44])(v270, v186, *([v201 @ X8_v44+8]), v181, v179, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv209 = v270 == 0;\nL_FFFFFFFF:\n\tv237 = v270;\nL_FFFFFFFF:\n\tv667 = &v237 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<System.Diagnostics.StackFrame>);\nL_FFFFFFFF:\n\tv241 = 0;\n\tif (v209) goto L_01F0;\nL_FFFFFFFF:\n\tv378 = v270;\n\tgoto L_00ED;\nL_00E5:\n\tSystem.Collections.Generic.List`1<CallSite>::Add(v63, v948);\n\tv333 = v237 == 0;\nL_FFFFFFFF:\n\tv378 = v237;\n\tif (v333) goto L_01F0;\nL_00ED:\n\tgoto L_0113;\n\tv490 = v237 == 0;\n\tif (v490) goto L_01F2;\n\tgoto L_0144;\n\tv897 = System.Diagnostics.StackFrame::GetMethod(v884);\n\tv898 = v897 == 0;\n\tif (v898) goto L_FFFFFFFF;\n\tv902 = System.Reflection.MemberInfo::get_Name(v897);\nL_FFFFFFFF:\n\tv501 = v902;\n\tgoto L_015A;\nL_FFFFFFFF:\n\tv501 = 0;\n\tv918 = System.Reflection.MemberInfo::get_DeclaringType(v913);\n\tv919 = v918 == 0;\n\tif (v919) goto L_FFFFFFFF;\n\tv929 = System.Type::get_FullName(v918);\nL_FFFFFFFF:\n\tv341 = v929;\n\tgoto L_016E;\nL_FFFFFFFF:\n\tv341 = 0;\n\tv948.ClassName = v341;\n\tv948.FunctionName = v501;\n\tv948.Path = v946;\n\tv948.Line = v940;\n\tv961 = v63 == 0;\n\tif (v961) goto L_01EE;\n\tv964 = v63._version + 1;\n\tv63._version = v964;\n\tv965 = v63._items == 0;\n\tif (v965) goto L_01EE;\n\tgoto L_00E5;\nL_01AB:\n\tv642 = &v237 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<System.Diagnostics.StackFrame>);\n\tv688 = *([v642 @ X8_v20]);\n\tv644 = *([v642 @ X8_v20]) == 0;\nL_FFFFFFFF:\n\tv694 = 0;\nL_FFFFFFFF:\n\tv561 = v667;\nL_FFFFFFFF:\n\tv591 = 0;\nL_FFFFFFFF:\n\tv606 = 0;\n\tif (v644) goto L_01DC;\nL_01B5:\n\tgoto L_01DB;\n\treturn v63;\nL_01EE:\n\tthrow System.NullReferenceException;\nL_01F0:\n\tthrow System.NullReferenceException;\nL_01F2:\n\tthrow System.NullReferenceException;\nL_020F:\n\tv654 = v591 != 1;\n\tif (v654) goto L_021D;\n\tv721 = 0x8BF5BC4(v608, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv694 = *([v721 @ X0_v14]);\n\tv685 = 0x8BF5BF4(v721, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv688 = *([v561 @ stack_-70_v1]);\n\tv875 = *([v561 @ stack_-70_v1]) == 0;\n\tv687 = ~v875;\nL_FFFFFFFF:\n\tv667 = v561;\nL_FFFFFFFF:\n\tv241 = *([v721 @ X0_v14]);\n\tif (v687) goto L_01B5;\nL_FFFFFFFF:\n\tv241 = *([v721 @ X0_v14]);\nL_FFFFFFFF:\n\tv606 = *([v721 @ X0_v14]);\n\tgoto L_01DC;\nL_021D:\n\tv724 = 0x3175484(&v241 @ stack_-78_v7 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv797 = 0x8BF0368(v608, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v797, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0044:\n\tv237 = 0;\n\tv63 = new System.Collections.Generic.List`1<CallSite>();\n\tSystem.Collections.Generic.List`1<CallSite>::.ctor(v63);\n\tv73 = new System.Diagnostics.StackTrace();\nL_0073:\n\t;\n\tv164 = *([v174 @ X10_v27-8]) == System.Collections.Generic.IEnumerable`1<System.Diagnostics.StackFrame>;\n\tif (v164) goto L_00CA;\nL_00B2:\n\tv355 = new System.Func`2<System.Diagnostics.StackFrame, System.Boolean>();\n\tSystem.Func`2<System.Diagnostics.StackFrame, System.Boolean>::.ctor(v355, v350.<>9, Il2CppMethodInfo);\n\tv520.<>9__5_0 = v355;\nL_0113:\n\tv634 = System.Collections.IEnumerator::MoveNext(v378);\n\tv636 = v634 == 0;\n\tif (v636) goto L_01AB;\nL_0144:\n\tv884 = System.Collections.Generic.IEnumerator`1<System.Diagnostics.StackFrame>::get_Current(v237);\nL_015A:\n\tv913 = System.Diagnostics.StackFrame::GetMethod(v884);\n\tv914 = v913 == 0;\n\tif (v914) goto L_FFFFFFFF;\nL_016E:\n\tv940 = System.Diagnostics.StackFrame::GetFileLineNumber(v884);\n\tv945 = System.Diagnostics.StackFrame::GetFileName(v884);\n\tv946 = Reflex.Diagnosis::GetUnityPath(v945);\n\tv948 = new CallSite();\n\tSystem.Object::.ctor(v948);\nL_01DC:\n\tv720 = v606 == 0;\n\tv596 = ~v720;\n\tif (v596) goto L_01F7;\nL_01DB:\n\tSystem.IDisposable::Dispose(v688);\nL_FFFFFFFF:\n\tv561 = v667;\nL_FFFFFFFF:\n\tv591 = 0;\nL_FFFFFFFF:\n\tv606 = v694;\nL_01F7:\n\tv608 = new System.OutOfMemoryException();\n\tgoto L_020F;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static List<CallSite> GetCallSite(int skipFrames)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Diagnosis::GetCallSite");
			return default;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x3F30A5C", Offset = "0x3F30A5C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0028:\n\tv54 = System.String::Replace(v36, \"\\\\\", \"/\");\n\tgoto L_0031;\nL_0031:\n\tv61 = UnityEngine.Application::get_dataPath();\n\treturnVal2 = System.String::Replace(v54, v61, \"Assets\");\n\treturn returnVal2;\n")]
		private static string GetUnityPath(string path)
		{
			string text2 = default(string);
			string text = text2.Replace("\\", "/");
			string dataPath = Application.dataPath;
			return text.Replace(dataPath, "Assets");
		}
	}
}
