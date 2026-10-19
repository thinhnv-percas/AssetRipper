using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using Unco.Utils;
using UnityEngine;

namespace UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects
{
	[Token(Token = "0x2000007")]
	public static class TypeFinder
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400000A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400000B")]
			public static Func<Assembly, bool> _003C_003E9__3_0;

			[Token(Token = "0x400000C")]
			public static Func<Type, bool> _003C_003E9__3_1;

			[Token(Token = "0x400000D")]
			public static Func<JProperty, string> _003C_003E9__6_0;

			[Token(Token = "0x400000E")]
			public static Func<JProperty, JToken> _003C_003E9__6_1;

			[Token(Token = "0x400000F")]
			public static Func<JProperty, string> _003C_003E9__9_0;

			[Token(Token = "0x6000014")]
			[Address(RVA = "0x81C8F80", Offset = "0x81C8F80", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000015")]
			[Address(RVA = "0x81C8FE4", Offset = "0x81C8FE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CEnsureCache_003Eb__3_0(Assembly a)
			{
				AssemblyName name = a.GetName();
				return name.Name == "Assembly-CSharp";
			}

			internal bool _003CEnsureCache_003Eb__3_1(Type t)
			{
				if (t.IsAbstract || t.IsGenericTypeDefinition)
				{
					return false;
				}
				Type typeFromHandle = typeof(SerializableAttribute);
				return Attribute.IsDefined(t, typeFromHandle);
			}

			internal string _003CTryInferPairType_003Eb__6_0(JProperty p)
			{
				return p.Name;
			}

			internal JToken _003CTryInferPairType_003Eb__6_1(JProperty p)
			{
				return p.Value;
			}

			internal string _003CMatchSerializableType_003Eb__9_0(JProperty p)
			{
				return p.Name;
			}
		}

		[Token(Token = "0x4000007")]
		private static IReadOnlyList<Type> _serializableTypes;

		[Token(Token = "0x4000008")]
		private static readonly Dictionary<Type, string[]> _typeMemberNames;

		[Token(Token = "0x4000009")]
		private static bool _cacheBuilt;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81C6FF0", Offset = "0x81C6FF0", Length = "0x384")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv54 = v51._cacheBuilt == 0;\n\tif (v54) goto L_0052;\n\treturn;\nL_0052:\n\tv80 = System.AppDomain::get_CurrentDomain();\n\tv134 = System.AppDomain::GetAssemblies(v80);\n\tgoto L_0060;\nL_0060:\n\tv160 = v158.<>9__3_0 == 0;\n\tv161 = ~v160;\nL_FFFFFFFF:\n\tv141 = v158.<>9__3_0;\n\tif (v161) goto L_0089;\n\tgoto L_006E;\nL_006E:\n\tgoto L_0076;\nL_0089:\n\tv188 = System.Linq.Enumerable::FirstOrDefault(v134, v141);\n\tv143 = System.Reflection.Assembly::op_Equality(v188, 0);\n\tv209 = ~v143;\n\tif (v209) goto L_00C5;\n\tgoto L_0096;\nL_0096:\n\tv226 = Il2CppClass<System.EmptyArray`1<System.Type>>;\n\tv229 = *([v226 @ X0_v51 (Il2CppClass<System.EmptyArray`1<System.Type>>)+135]) & 1;\n\tv230 = v229 == 0;\nL_FFFFFFFF:\n\tv250 = Il2CppClass<System.EmptyArray`1<System.Type>>;\n\tif (v230) goto L_00DF;\nL_009E:\n\tgoto L_00A6;\nL_00A6:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv359 = v319.Value;\n\tgoto L_00B2;\nL_00C5:\n\tv233 = *([v188 @ X0_v10 (System.Object)]);\n\t*([v233 @ X8_v11 (Il2CppClass<System.Object>)+248])(v237, v188, *([v233 @ X8_v11 (Il2CppClass<System.Object>)+250]), 0, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00D1;\nL_00D1:\n\tv260 = v258.<>9__3_1 == 0;\n\tv261 = ~v260;\nL_FFFFFFFF:\n\tv290 = v258.<>9__3_1;\n\tif (v261) goto L_0112;\n\tgoto L_00F7;\n\tv232 = System.Array::Empty();\n\tv243 = Il2CppClass<System.EmptyArray`1<System.Type>>;\n\tv256 = *([v243 @ X0_v43 (Il2CppClass<System.EmptyArray`1<System.Type>>)+135]) & 1;\n\tv257 = v256 == 0;\n\tv245 = ~v257;\nL_FFFFFFFF:\n\tv250 = Il2CppClass<System.EmptyArray`1<System.Type>>;\n\tif (v245) goto L_009E;\nL_00DF:\n\tv253 = 0x220C238(v250, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv279 = *([v253 @ X0_v40+E4]) == 0;\n\tv265 = ~v279;\n\tif (v265) goto L_00A6;\n\tgoto L_00EC;\nL_00EC:\n\tgoto L_FFFFFFFF;\nL_00F7:\n\tgoto L_00FF;\nL_0112:\n\tv307 = System.Linq.Enumerable::Where(v237, v290);\n\tv336 = System.Linq.Enumerable::ToArray(v307);\nL_FFFFFFFF:\n\tv359 = v336;\n\tgoto L_00B2;\nL_0076:\n\tv208 = new System.Func`2<System.Reflection.Assembly, System.Boolean>();\n\tSystem.Func`2<System.Reflection.Assembly, System.Boolean>::.ctor(v208, v203.<>9, Il2CppMethodInfo);\n\tv224.<>9__3_0 = v208;\nL_FFFFFFFF:\n\tv141 = v208;\nL_00B2:\n\tv360._serializableTypes = v359;\n\tv122._cacheBuilt = 1;\n\treturn;\nL_00FF:\n\tv368 = new System.Func`2<System.Type, System.Boolean>();\n\tSystem.Func`2<System.Type, System.Boolean>::.ctor(v368, v363.<>9, Il2CppMethodInfo);\n\tv375.<>9__3_1 = v368;\nL_FFFFFFFF:\n\tv290 = v368;\n")]
		private static void EnsureCache()
		{
			//IL_0122: Expected I, but got O
			if (_cacheBuilt)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			bool flag = _003C_003Ec._003C_003E9__3_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__3_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__3_0 = delegate(Assembly a)
				{
					AssemblyName name = a.GetName();
					return name.Name == "Assembly-CSharp";
				});
			}
			object obj = assemblies.FirstOrDefault(predicate);
			object[] serializableTypes;
			if ((Assembly)obj == null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ X0_v51 (Il2CppClass<System.EmptyArray`1<System.Type>>)+135]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag3 = num2 == 0;
				nint num3 = 0;
				if (flag3)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X0_v40+E4]");
					if ((nint)0 != 0)
					{
					}
				}
				serializableTypes = Array.Empty<Type>();
			}
			else
			{
				nint num4 = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v233 @ X8_v11 (Il2CppClass<System.Object>)+248] (should have been resolved before IL gen)");
				bool flag4 = _003C_003Ec._003C_003E9__3_1 == null;
				bool flag5 = !flag4;
				Func<object, bool> predicate2 = (Func<object, bool>)_003C_003Ec._003C_003E9__3_1;
				if (!flag5)
				{
					predicate2 = (Func<object, bool>)(_003C_003Ec._003C_003E9__3_1 = delegate(Type t)
					{
						if (t.IsAbstract || t.IsGenericTypeDefinition)
						{
							return false;
						}
						Type typeFromHandle = typeof(SerializableAttribute);
						return Attribute.IsDefined(t, typeFromHandle);
					});
				}
				IEnumerable<object> source2 = default(IEnumerable<object>);
				IEnumerable<object> source = source2.Where(predicate2);
				object[] array = source.ToArray();
				serializableTypes = array;
			}
			_serializableTypes = (IReadOnlyList<Type>)serializableTypes;
			_cacheBuilt = true;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81C7374", Offset = "0x81C7374", Length = "0x52C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_003A:\n\tgoto L_003C;\nL_003C:\n\tUncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::EnsureCache();\n\tv289 = System.String::Trim(json);\n\tgoto L_004D;\nL_004D:\n\tv315 = Newtonsoft.Json.Linq.JToken::Parse(v289);\n\tv372 = Newtonsoft.Json.Linq.JToken::get_Type(v315);\n\tv453 = v372 <= 6;\n\tif (v453) goto L_0092;\n\tv466 = v372 > 8;\n\tif (v466) goto L_00BA;\n\tv480 = v372 == 7;\n\tif (v480) goto L_0173;\n\tv517 = v372 != 8;\n\tif (v517) goto L_016A;\n\tv561 = 0xB7D5000 + 0x538;\n\tv601 = *([v561 @ X8_v68 (System.Int32)+90]);\n\tgoto L_0184;\nL_0092:\n\tv471 = v372 == 1;\n\tif (v471) goto L_00E4;\n\tv498 = v372 == 2;\n\tif (v498) goto L_0193;\n\tv542 = v372 != 6;\n\tif (v542) goto L_016A;\n\tv607 = 0xB7D5000 + 0x538;\n\tv601 = *([v607 @ X8_v59 (System.Int32)+68]);\n\tgoto L_0184;\nL_00BA:\n\tv489 = v372 == 9;\n\tif (v489) goto L_017C;\n\tv168 = v372 != 0xA;\n\tif (v168) goto L_016A;\n\treturn 0;\nL_00E4:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v80_asT @ TEMPCOND_v14 (Newtonsoft.Json.Linq.JObject), typeof(Newtonsoft.Json.Linq.JObject), v315 @ X0_v42 (Newtonsoft.Json.Linq.JToken)\n\tv80 = v80_asT == 0;\n\tif (v80) goto L_01E5;\n\tgoto L_00FD;\nL_00FD:\n\tv629 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::TryInferPairType(v315, &v71 @ stack_-38_v7 (System.Type), &v67 @ stack_-40_v7 (System.Type));\n\tv631 = ~v629;\n\tif (v631) goto L_01C2;\n\tv296 = 0xB7D5000 + 0x538;\n\tgoto L_010D;\nL_010D:\n\tv654 = System.Type::GetTypeFromHandle(Unco.Utils.Pair`2);\n\t// 275 NewArr v662 @ X0_v72 (System.Type[]), typeof(System.Type[]), 2\n\tv669 = v71 == 0;\n\tv670 = ~v669;\nL_FFFFFFFF:\n\tv313 = v71;\n\tif (v670) goto L_0126;\n\tgoto L_0120;\nL_0120:\n\tv690 = *([v296 @ X22_v10 (System.Int32)+10]) + 0x20;\n\tv679 = System.Type::GetTypeFromHandle(v690);\nL_FFFFFFFF:\n\tv313 = v679;\nL_0126:\n\tv691 = v313 == 0;\n\tif (v691) goto L_0133;\n\tv431 = 0x21C11D0(v313, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv434 = v431 == 0;\n\tif (v434) goto L_01E7;\nL_0133:\n\tv662[0] = v313;\n\tv703 = v67 == 0;\n\tv704 = ~v703;\nL_FFFFFFFF:\n\tv429 = v67;\n\tif (v704) goto L_014A;\n\tgoto L_0141;\nL_0141:\n\tv721 = *([v296 @ X22_v10 (System.Int32)+10]) + 0x20;\n\tv714 = System.Type::GetTypeFromHandle(v721);\n\tv716 = v714 == 0;\nL_FFFFFFFF:\n\tv429 = v714;\nL_FFFFFFFF:\n\tv312 = v714;\n\tif (v716) goto L_0156;\nL_014A:\n\tv432 = 0x21C11D0(v429, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv435 = v432 == 0;\nL_FFFFFFFF:\n\tv312 = v429;\n\tif (v435) goto L_01E7;\nL_0156:\n\tv662[1] = v312;\n\treturnVal8 = System.Type::MakeGenericType(v654, v662);\n\treturn returnVal8;\nL_016A:\n\tv578 = 0xB7D5000 + 0x538;\n\tv601 = *([v578 @ X8_v22 (System.Int32)+10]);\n\tgoto L_0184;\nL_0173:\n\tv519 = 0xB7D5000 + 0x538;\n\tv601 = *([v519 @ X8_v65 (System.Int32)+80]);\n\tgoto L_0184;\nL_017C:\n\tv527 = 0xB7D5000 + 0x538;\n\tv601 = *([v527 @ X8_v62 (System.Int32)+28]);\n\tgoto L_0184;\nL_0184:\n\tv604 = v601 + 0x20;\n\treturnVal3 = System.Type::GetTypeFromHandle(v604);\n\treturn returnVal3;\nL_0193:\n\tgoto L_01A5;\nL_01A5:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v170_asT @ TEMPCOND_v16 (Newtonsoft.Json.Linq.JArray), typeof(Newtonsoft.Json.Linq.JArray), v315 @ X0_v42 (Newtonsoft.Json.Linq.JToken)\n\tv170 = v170_asT == 0;\n\tif (v170) goto L_01E5;\n\treturnVal5 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::InferListType(v315);\n\treturn returnVal5;\nL_01C2:\n\tgoto L_01C4;\nL_01C4:\n\treturnVal1 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::MatchSerializableType(v315);\n\tv663 = returnVal1 == 0;\n\tv115 = ~v663;\n\tif (v115) goto L_0033;\n\tgoto L_01D0;\nL_01D0:\n\tv684 = 0xB7D5000 + 0x538;\n\tgoto L_01D8;\nL_01D8:\n\tv694 = *([v684 @ X8_v33 (System.Int32)+10]) + 0x20;\n\treturnVal7 = System.Type::GetTypeFromHandle(v694);\n\treturn returnVal7;\nL_01E5:\n\tv382 = new System.InvalidCastException();\n\tv416 = new System.IndexOutOfRangeException();\nL_01E7:\n\tv440 = new System.ArrayTypeMismatchException();\n\tthrow v440;\nL_0027:\n\tv47 = System.String::IsNullOrWhiteSpace(json);\n\tv52 = v47 == 0;\n\tif (v52) goto L_003A;\nL_0033:\n\treturn returnVal1;\n")]
		public static Type FindType(string json)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::FindType");
			return default;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81C7A54", Offset = "0x81C7A54", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv55 = Newtonsoft.Json.Linq.JContainer::get_Count(arr);\n\tv147 = v55 == 0;\n\tif (v147) goto L_012F;\n\tv120 = Newtonsoft.Json.Linq.JContainer::get_First(arr);\n\tv244 = Newtonsoft.Json.Linq.JToken::get_Type(v120);\n\tv254 = v244 != 1;\n\tif (v254) goto L_0115;\n\tgoto L_005D;\nL_005D:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v79_asT @ TEMPCOND_v8 (Newtonsoft.Json.Linq.JObject), typeof(Newtonsoft.Json.Linq.JObject), v120 @ X0_v20 (Newtonsoft.Json.Linq.JToken)\n\tv79 = v79_asT == 0;\n\tif (v79) goto L_0140;\n\tv331 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::TryInferPairType(v120, &v70 @ stack_-48_v7 (System.Type), &v65 @ stack_-50_v7 (System.Type));\n\tv333 = ~v331;\n\tif (v333) goto L_0115;\n\tv63 = 0xB7D5000 + 0x538;\n\tgoto L_0082;\n\tgoto L_0095;\nL_0095:\n\tv443 = *([v63 @ X22_v8 (System.Int32)+10]) + 0x20;\n\tv439 = System.Type::GetTypeFromHandle(v443);\nL_FFFFFFFF:\n\tv59 = v439;\nL_009B:\n\tv444 = v59 == 0;\n\tif (v444) goto L_00A8;\n\tv292 = 0x21C11D0(v59, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv296 = v292 == 0;\n\tif (v296) goto L_0142;\nL_00A8:\n\tv428[0] = v59;\n\tv453 = v65 == 0;\n\tv454 = ~v453;\nL_FFFFFFFF:\n\tv269 = v65;\n\tif (v454) goto L_00BF;\n\tgoto L_00B6;\nL_00B6:\n\tv471 = *([v63 @ X22_v8 (System.Int32)+10]) + 0x20;\n\tv464 = System.Type::GetTypeFromHandle(v471);\n\tv466 = v464 == 0;\nL_FFFFFFFF:\n\tv269 = v464;\nL_FFFFFFFF:\n\tv57 = v464;\n\tif (v466) goto L_00CB;\nL_00BF:\n\tv293 = 0x21C11D0(v269, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = v293 == 0;\nL_FFFFFFFF:\n\tv57 = v269;\n\tif (v297) goto L_0142;\nL_00CB:\n\tv428[1] = v57;\n\tv479 = System.Type::MakeGenericType(v424, v428);\n\tgoto L_00E2;\nL_00E2:\n\tv490 = System.Type::GetTypeFromHandle(System.Collections.Generic.List`1);\n\t// 230 NewArr v122 @ X0_v54 (System.Type[]), typeof(System.Type[]), 1\n\tv492 = v479 == 0;\n\tif (v492) goto L_00F7;\n\tv294 = 0x21C11D0(v479, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv298 = v294 == 0;\n\tif (v298) goto L_0142;\nL_00F7:\n\tv122[0] = v479;\n\treturnVal4 = System.Type::MakeGenericType(v490, v122);\n\treturn returnVal4;\nL_0115:\n\tgoto L_011B;\nL_012F:\n\tgoto L_013C;\nL_013C:\n\treturnVal1 = System.Type::GetTypeFromHandle(System.Collections.Generic.List`1<System.Object>);\n\treturn returnVal1;\nL_0140:\n\tv189 = new System.InvalidCastException();\n\tv237 = new System.IndexOutOfRangeException();\nL_0142:\n\tv305 = new System.ArrayTypeMismatchException();\n\tthrow v305;\nL_0082:\n\tv424 = System.Type::GetTypeFromHandle(Unco.Utils.Pair`2);\n\t// 136 NewArr v428 @ X0_v37 (System.Type[]), typeof(System.Type[]), 2\n\tv430 = v70 == 0;\n\tv431 = ~v430;\nL_FFFFFFFF:\n\tv59 = v70;\n\tif (v431) goto L_009B;\nL_011B:\n\treturnVal3 = System.Type::GetTypeFromHandle(System.Collections.Generic.List`1<System.Object>);\n\treturn returnVal3;\n")]
		private static Type InferListType(JArray arr)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::InferListType");
			return default;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81C7DFC", Offset = "0x81C7DFC", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv75 = Newtonsoft.Json.Linq.JObject::Properties(obj);\n\tgoto L_004F;\nL_004F:\n\tv325 = v114.<>9__6_0;\n\tv116 = v114.<>9__6_0 == 0;\n\tif (v116) goto L_00B3;\n\tgoto L_0056;\nL_0056:\n\tv318 = 0xB294000 + 0xBE8;\n\tv317 = v199.<>9__6_1;\n\tv201 = v199.<>9__6_1 == 0;\n\tv336 = v318;\n\tv341 = v325;\n\tif (v201) goto L_00DA;\n\tv238 = *([v318 @ X26_v10 (System.Int32)]);\n\tv240 = *([v238 @ X0_v67+E4]) == 0;\n\tv335 = v317;\n\tv336 = v318;\n\tv341 = v325;\n\tif (v240) goto L_00F8;\nL_0061:\n\tv284 = *([B193ADF]) & 1;\n\tv285 = v284 == 0;\n\tv335 = v317;\n\tv336 = v318;\n\tv341 = v325;\n\tif (v285) goto L_0100;\nL_0065:\n\t;\n\tv363 = *([v318 @ X26_v10 (System.Int32)]);\n\tv88 = v317;\n\tv101 = v325;\n\tgoto L_006A;\nL_006A:\n\tv99 = *([v363 @ X0_v44+B8]);\n\tv95 = System.Linq.Enumerable::ToDictionary(v75, v101, v88, *([v99 @ X8_v35+18]));\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::TryGetValue(v95, \"Key\", &v124 @ stack_-58_v2 (Newtonsoft.Json.Linq.JToken));\n\tv393 = ~returnVal2;\n\tif (v393) goto L_00A8;\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::TryGetValue(v95, \"Value\", &v399 @ stack_-60_v3 (Newtonsoft.Json.Linq.JToken));\n\tv405 = ~returnVal2;\n\tif (v405) goto L_00A8;\n\tgoto L_0091;\nL_0091:\n\tv416 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::InferTypeFromToken(v124);\n\t*([keyType @ X1 (System.Type&)]) = v416;\n\tv421 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::InferTypeFromToken(v399);\n\t*([valueType @ X2 (System.Type&)]) = v421;\n\treturnVal2 = 1;\nL_00B3:\n\tgoto L_00BB;\n\tv325 = v219;\n\tgoto L_0056;\nL_00DA:\n\tgoto L_00E2;\n\tv276 = *([v318 @ X26_v10 (System.Int32)]);\n\tv383 = *([v276 @ X0_v28+E4]) == 0;\n\tv278 = ~v383;\n\tv317 = v305;\n\tv318 = v318;\n\tv325 = v325;\n\tv335 = v305;\n\tif (v278) goto L_0061;\nL_00F8:\n\tv345 = *([B193ADF]) & 1;\n\tv346 = v345 == 0;\n\tv322 = ~v346;\n\tv317 = v335;\n\tv318 = v336;\n\tv325 = v341;\n\tif (v322) goto L_0065;\nL_0100:\n\t*([B193ADF]) = 1;\n\tv363 = *([v336 @ X26_v3 (System.Int32)]);\n\tv88 = v335;\n\tv101 = v341;\n\tgoto L_006A;\nL_003A:\n\t*([keyType @ X1 (System.Type&)]) = 0;\n\t*([valueType @ X2 (System.Type&)]) = 0;\nL_00A8:\n\treturn returnVal2;\nL_00BB:\n\tv219 = new System.Func`2<Newtonsoft.Json.Linq.JProperty, System.String>();\n\tSystem.Func`2<Newtonsoft.Json.Linq.JProperty, System.String>::.ctor(v219, v214.<>9, Il2CppMethodInfo);\n\tv307.<>9__6_0 = v219;\nL_00E2:\n\tv305 = new System.Func`2<Newtonsoft.Json.Linq.JProperty, Newtonsoft.Json.Linq.JToken>();\n\tSystem.Func`2<Newtonsoft.Json.Linq.JProperty, Newtonsoft.Json.Linq.JToken>::.ctor(v305, v300.<>9, Il2CppMethodInfo);\n\tv380.<>9__6_1 = v305;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool TryInferPairType(JObject obj, out Type keyType, out Type valueType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::TryInferPairType");
			keyType = default;
			valueType = default;
			return default;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81C8920", Offset = "0x81C8920", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv46 = Newtonsoft.Json.Linq.JToken::get_Type(token);\n\tv58 = v46 <= 6;\n\tif (v58) goto L_0059;\n\tv71 = v46 > 8;\n\tif (v71) goto L_0082;\n\tv141 = v46 == 7;\n\tif (v141) goto L_00E0;\n\tv178 = v46 != 8;\n\tif (v178) goto L_00D0;\n\tv306 = 0xB7D5000 + 0x538;\n\tv327 = *([v306 @ X8_v30 (System.Int32)+90]) + 0x20;\n\tv309 = *([v306 @ X8_v30 (System.Int32)+E0]);\n\tv311 = *([v309 @ X8_v31+E4]) == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_00DD;\nL_FFFFFFFF:\n\tv316 = v327;\n\tgoto L_00F2;\nL_0059:\n\tv76 = v46 == 1;\n\tif (v76) goto L_00A3;\n\tv159 = v46 == 2;\n\tif (v159) goto L_00D0;\n\tv202 = v46 != 6;\n\tif (v202) goto L_00D0;\n\tv333 = 0xB7D5000 + 0x538;\n\tv327 = *([v333 @ X8_v21 (System.Int32)+68]) + 0x20;\n\tv321 = *([v333 @ X8_v21 (System.Int32)+E0]);\n\tv335 = *([v321 @ X8_v22+E4]) == 0;\n\tv319 = ~v335;\n\tif (v319) goto L_00DD;\nL_FFFFFFFF:\n\tv316 = v327;\n\tgoto L_00F2;\nL_0082:\n\tv150 = v46 == 0xA;\n\tif (v150) goto L_00D0;\n\tv196 = v46 != 9;\n\tif (v196) goto L_00D0;\n\tv329 = 0xB7D5000 + 0x538;\n\tv327 = *([v329 @ X8_v24 (System.Int32)+28]) + 0x20;\n\tv322 = *([v329 @ X8_v24 (System.Int32)+E0]);\n\tv331 = *([v322 @ X8_v25+E4]) == 0;\n\tv320 = ~v331;\n\tif (v320) goto L_00DD;\nL_FFFFFFFF:\n\tv316 = v327;\n\tgoto L_00F2;\nL_00A3:\n\tgoto L_00B5;\nL_00B5:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v90_asT @ TEMPCOND_v9 (Newtonsoft.Json.Linq.JObject), typeof(Newtonsoft.Json.Linq.JObject), token @ X0 (Newtonsoft.Json.Linq.JToken)\n\tv90 = v90_asT == 0;\n\tif (v90) goto L_00F6;\n\treturnVal4 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::MatchSerializableType(token);\n\tv224 = returnVal4 == 0;\n\tif (v224) goto L_00D0;\n\treturn returnVal4;\nL_00D0:\n\tv227 = 0xB7D5000 + 0x538;\n\tv327 = *([v227 @ X8_v9 (System.Int32)+10]) + 0x20;\n\tv230 = *([v227 @ X8_v9 (System.Int32)+E0]);\n\tv232 = *([v230 @ X8_v10+E4]) == 0;\nL_FFFFFFFF:\n\tv316 = v327;\n\tif (v232) goto L_00F2;\nL_00DD:\n\treturnVal2 = System.Type::GetTypeFromHandle(v327);\n\treturn returnVal2;\nL_00E0:\n\tv180 = 0xB7D5000 + 0x538;\n\tv327 = *([v180 @ X8_v27 (System.Int32)+80]) + 0x20;\n\tv183 = *([v180 @ X8_v27 (System.Int32)+E0]);\n\tv185 = *([v183 @ X8_v28+E4]) == 0;\n\tv186 = ~v185;\nL_FFFFFFFF:\n\tv316 = v327;\n\tif (v186) goto L_00DD;\nL_00F2:\n\treturnVal3 = System.Type::GetTypeFromHandle(v316);\n\treturn returnVal3;\nL_00F6:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n")]
		private static Type InferTypeFromToken(JToken token)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::InferTypeFromToken");
			return default;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81C78A0", Offset = "0x81C78A0", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = System.Boolean::TryParse(raw, &v43 @ stack_-31_v1 (System.Boolean));\n\tv58 = ~v56;\n\tif (v58) goto L_0039;\nL_0027:\n\tv115 = *([v47 @ X20_v3 (System.Int32)+28]) + 0x20;\n\tgoto L_0084;\nL_0032:\n\tv62 = System.Boolean::TryParse(raw, &v43 @ stack_-31_v1 (System.Boolean));\n\tv82 = ~v62;\n\tv67 = ~v82;\n\tif (v67) goto L_0027;\nL_0039:\n\tv81 = System.Int64::TryParse(raw, &v45 @ stack_-40_v1 (System.Int64));\n\tv124 = ~v81;\n\tif (v124) goto L_0047;\n\tv115 = *([v47 @ X20_v3 (System.Int32)+68]) + 0x20;\n\tgoto L_0084;\nL_0047:\n\tv135 = System.Double::TryParse(raw, &v44 @ stack_-48_v1 (System.Double));\n\tv149 = ~v135;\n\tif (v149) goto L_0059;\n\tv115 = *([v47 @ X20_v3 (System.Int32)+80]) + 0x20;\n\tgoto L_0084;\nL_0059:\n\tv157 = System.String::StartsWith(raw, \"\\\"\");\n\tv158 = ~v157;\n\tif (v158) goto L_0069;\n\tv162 = System.String::EndsWith(raw, \"\\\"\");\n\tv174 = v162 == 0;\n\tv167 = ~v174;\n\tif (v167) goto L_0073;\nL_0069:\n\tv172 = System.String::StartsWith(raw, \"'\");\n\tv175 = ~v172;\n\tif (v175) goto L_007B;\n\tv179 = System.String::EndsWith(raw, \"'\");\n\tv181 = ~v179;\n\tif (v181) goto L_007B;\nL_0073:\n\tv115 = *([v47 @ X20_v3 (System.Int32)+90]) + 0x20;\n\tgoto L_0084;\nL_007B:\n\tv115 = *([v47 @ X20_v3 (System.Int32)+10]) + 0x20;\n\tgoto L_0084;\nL_0084:\n\treturnVal1 = System.Type::GetTypeFromHandle(v115);\n\treturn returnVal1;\nL_0017:\n\tv43 = 0;\n\tv44 = 0;\n\tv45 = 0;\n\tv47 = 0xB7D5000 + 0x538;\n\tv48 = *([v47 @ X20_v3 (System.Int32)+28]);\n\tv50 = *([v48 @ X0_v2+E4]) == 0;\n\tif (v50) goto L_0032;\n")]
		private static Type InferPrimitiveFromRaw(string raw)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::InferPrimitiveFromRaw");
			return default;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81C8170", Offset = "0x81C8170", Length = "0x7B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tv64 = Newtonsoft.Json.Linq.JObject::Properties(obj);\n\tgoto L_005D;\n\tgoto L_006B;\nL_007C:\n\tv304 = System.Linq.Enumerable::Select(v64, v292);\n\tgoto L_0087;\nL_0087:\n\tgoto L_0097;\nL_00B4:\n\tgoto L_00E1;\nL_FFFFFFFF:\n\tv210 = 0;\nL_FFFFFFFF:\n\tv213 = 0;\nL_FFFFFFFF:\n\tv642 = v163;\n\tgoto L_00FB;\nL_00F5:\n\tv269 = v163 == 0;\nL_FFFFFFFF:\n\tv642 = v163;\n\tif (v269) goto L_0293;\nL_00FB:\n\tgoto L_0121;\n\tv405 = v163 == 0;\n\tif (v405) goto L_028C;\n\tgoto L_0152;\n\tv964 = System.Type::get_IsGenericType(v912);\n\tv966 = v964 == 0;\n\tif (v966) goto L_0179;\n\tv973 = System.Type::GetGenericTypeDefinition(v912);\n\tgoto L_016D;\nL_016D:\n\tv997 = System.Type::GetTypeFromHandle(Unco.Utils.Pair`2);\n\tv984 = System.Type::op_Equality(v973, v997);\n\tv1013 = ~v984;\n\tv986 = ~v1013;\nL_FFFFFFFF:\n\t;\n\tif (v986) goto L_00F5;\nL_0179:\n\tgoto L_017C;\nL_017C:\n\tv901 = UncoPackages.UnityCommonPackage.RemoteManagementSystem.ScriptableObjects.TypeFinder::GetMemberNames(v912);\n\tv406 = v901 == 0;\n\tif (v406) goto L_028E;\n\tv1014 = v901.Length == 0;\n\tif (v1014) goto L_00F5;\n\tv891 = v901.Length < 1;\n\tif (v891) goto L_FFFFFFFF;\n\tv902 = v470 == 0;\n\tif (v902) goto L_0296;\nL_FFFFFFFF:\n\tv206 = 0;\nL_FFFFFFFF:\n\tv1103 = 0;\n\tgoto L_01AF;\nL_FFFFFFFF:\n\tv206 = 0;\nL_FFFFFFFF:\n\tv1115 = v206;\n\tgoto L_01C1;\nL_FFFFFFFF:\n\tv1115 = v210;\nL_FFFFFFFF:\n\tv273 = v912;\n\tgoto L_01CF;\nL_FFFFFFFF:\n\tv273 = v213;\n\tgoto L_0293;\nL_01D5:\n\tv727 = &v55 @ stack_-68_v1;\n\tv729 = *([v727 @ X8_v27]) == 0;\n\tif (v729) goto L_0209;\n\tgoto L_0205;\n\tgoto L_021B;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0289;\nL_021B:\n\tgoto L_0220;\nL_0220:\n\tv959 = System.Type::op_Equality(v213, 0);\n\tv968 = v959 == 0;\n\tv949 = ~v968;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tif (v949) goto L_0289;\n\tv922 = v210 < 1;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tif (v922) goto L_0289;\n\tgoto L_023F;\nL_023F:\n\tgoto L_0240;\nL_0240:\n\tgoto L_024F;\n\tv1012 = System.Array::Empty();\n\tgoto L_024F;\nL_024F:\n\tgoto L_0258;\nL_0258:\n\tgoto L_025F;\nL_025F:\n\tv1088 = Newtonsoft.Json.Linq.JToken::ToString(obj, 0, v1084.Value);\n\tgoto L_026C;\nL_026C:\n\tv1121 = Newtonsoft.Json.JsonConvert::DeserializeObject(v1088, v213);\n\tv921 = v1121 != 0;\n\tif (v921) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0289;\nL_FFFFFFFF:\n\treturnVal2 = v213;\nL_028A:\n\tv398 = new System.NullReferenceException();\n\tgoto L_02BC;\nL_028C:\n\tv398 = new System.NullReferenceException();\n\tgoto L_02BC;\nL_028E:\n\tv398 = new System.NullReferenceException();\n\tgoto L_02BC;\nL_0295:\n\tv841 = new System.OutOfMemoryException();\nL_0296:\n\tv398 = new System.NullReferenceException();\n\tgoto L_02BC;\nL_02BC:\n\t// 700 Interrupt\n\tv417 = 0x8BF5BF4(v398, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_02EB;\nL_02EB:\n\tv461 = 0x8BF0368(v398, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v461, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0047:\n\tv55 = 0;\nL_005D:\n\tv181 = v179.<>9__9_0 == 0;\n\tv182 = ~v181;\nL_FFFFFFFF:\n\tv292 = v179.<>9__9_0;\n\tif (v182) goto L_007C;\nL_006B:\n\tv315 = new System.Func`2<Newtonsoft.Json.Linq.JProperty, System.String>();\n\tSystem.Func`2<Newtonsoft.Json.Linq.JProperty, System.String>::.ctor(v315, v310.<>9, Il2CppMethodInfo);\n\tv434.<>9__9_0 = v315;\nL_FFFFFFFF:\n\tv292 = v315;\nL_0097:\n\tgoto L_009D;\nL_00E1:\n\tv163 = System.Collections.Generic.IEnumerable`1<System.Type>::GetEnumerator(v91._serializableTypes);\n\tv165 = v163 == 0;\n\tif (v165) goto L_0293;\nL_0293:\n\tv398 = new System.NullReferenceException();\n\tgoto L_02BC;\nL_0121:\n\tv722 = System.Collections.IEnumerator::MoveNext(v642);\n\tv724 = v722 == 0;\n\tif (v724) goto L_01D5;\nL_0152:\n\tv912 = System.Collections.Generic.IEnumerator`1<System.Type>::get_Current(v163);\n\tv404 = v912 == 0;\n\tif (v404) goto L_028A;\nL_019A:\n\tv1070 = System.Collections.Generic.HashSet`1<System.String>::Contains(v470, v901[v1103 @ X25_v9 (System.Int32)]);\n\tv206 = v206 + v1070;\n\tv1103 = v1103 + 1;\n\tv1051 = v1103 < v901.Length;\n\tif (v1051) goto L_019A;\nL_01AF:\n\tv243 = v206 - v210;\n\tv240 = v243 < 0;\n\tv237 = v243 == 0;\n\tv234 = v206 ^ v210;\n\tv231 = v206 ^ v243;\n\tv228 = v234 & v231;\n\tv225 = v228 < 0;\n\tv1078 = v240 == v225;\n\tv1079 = ~v237;\n\tv1080 = v1078 & v1079;\n\tv1081 = ~v1080;\n\tif (v1081) goto L_FFFFFFFF;\nL_01C1:\n\tv1117 = v240 == v225;\n\tv186 = ~v237;\n\tv222 = v1117 & v186;\n\tv196 = ~v222;\n\tif (v196) goto L_FFFFFFFF;\nL_01CF:\n\tv1126 = v163 == 0;\n\tv270 = ~v1126;\nL_FFFFFFFF:\n\tv210 = v1115;\nL_FFFFFFFF:\n\tv213 = v273;\nL_FFFFFFFF:\n\tv642 = v163;\n\tif (v270) goto L_00FB;\nL_0209:\n\tgoto L_0295;\nL_0205:\n\tSystem.IDisposable::Dispose(*([v727 @ X8_v27]));\nL_0289:\n\treturn returnVal2;\nL_009D:\n\tv470 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v470, v304, v468.s_ordinalIgnoreCase);\n\tgoto L_00B4;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Type MatchSerializableType(JObject obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::MatchSerializableType");
			return default;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81C8AF0", Offset = "0x81C8AF0", Length = "0x3FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001A:\n\tgoto L_001D;\nL_001D:\n\tv66 = v64._typeMemberNames == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_004F;\n\tgoto L_0170;\nL_004F:\n\tv89 = System.Collections.Generic.Dictionary`2<System.Type, System.String[]>::TryGetValue(v64._typeMemberNames, t, &v87 @ stack_-68_v4 (System.String[]));\n\tv253 = ~v89;\n\tif (v253) goto L_0059;\n\tv333 = v87;\n\tgoto L_016F;\nL_0059:\n\tgoto L_005E;\nL_005E:\n\tgoto L_0062;\nL_0062:\n\tgoto L_0068;\nL_0068:\n\tv222 = new System.Collections.Generic.HashSet`1<System.String>();\n\tSystem.Collections.Generic.HashSet`1<System.String>::.ctor(v222, v417.s_ordinalIgnoreCase);\n\tv223 = System.Type::GetFields(t, 0x34);\n\tv445 = v222 == 0;\n\tif (v445) goto L_00CC;\n\tv447 = v223.Length < 1;\n\tif (v447) goto L_00F4;\n\tv111 = 0;\n\tgoto L_00AB;\nL_0094:\n\tv566 = System.Reflection.MemberInfo::get_Name(v223[v111 @ X25_v17 (System.Int32)]);\n\tv570 = System.Collections.Generic.HashSet`1<System.String>::Add(v222, v566);\nL_009A:\n\tv111 = v111 + 1;\n\tv456 = v111 >= v223.Length;\n\tif (v456) goto L_00F4;\nL_00AB:\n\tv506 = System.Reflection.FieldInfo::get_IsPublic(v223[v111 @ X25_v17 (System.Int32)]);\n\tv513 = v506 == 0;\n\tv514 = ~v513;\n\tif (v514) goto L_0094;\n\tv557 = System.Reflection.CustomAttributeExtensions::GetCustomAttribute(v223[v111 @ X25_v17 (System.Int32)]);\n\tv580 = v557 == 0;\n\tv561 = ~v580;\n\tif (v561) goto L_0094;\n\tgoto L_009A;\nL_00CC:\n\tv449 = v223.Length < 1;\n\tif (v449) goto L_00F4;\n\tv112 = 0;\nL_00D6:\n\tv281 = System.Reflection.FieldInfo::get_IsPublic(v223[v112 @ X25_v14 (System.Int32)]);\n\tv554 = v281 == 0;\n\tv286 = ~v554;\n\tv257 = v223[v112 @ X25_v14 (System.Int32)];\n\tif (v286) goto L_0171;\n\tv282 = System.Reflection.CustomAttributeExtensions::GetCustomAttribute(v223[v112 @ X25_v14 (System.Int32)]);\n\tv593 = v282 == 0;\n\tv287 = ~v593;\n\tv257 = v223[v112 @ X25_v14 (System.Int32)];\n\tif (v287) goto L_0171;\n\tv112 = v112 + 1;\n\tv455 = v112 < *([B193018]);\n\tif (v455) goto L_00D6;\nL_00F4:\n\tv226 = System.Type::GetProperties(t, 0x14);\n\tv501 = v222 == 0;\n\tif (v501) goto L_012E;\n\tv508 = v226.Length < 1;\n\tif (v508) goto L_014E;\n\tv114 = 0;\n\tgoto L_0120;\nL_010D:\n\tv114 = v114 + 1;\n\tv520 = v114 >= v226.Length;\n\tif (v520) goto L_014E;\nL_0120:\n\tv587 = System.Reflection.PropertyInfo::get_CanWrite(v226[v114 @ X25_v11 (System.Int32)]);\n\tv544 = ~v587;\n\tif (v544) goto L_010D;\n\tv598 = System.Reflection.MemberInfo::get_Name(v226[v114 @ X25_v11 (System.Int32)]);\n\tv602 = System.Collections.Generic.HashSet`1<System.String>::Add(v222, v598);\n\tgoto L_010D;\nL_012E:\n\tv510 = v226.Length < 1;\n\tif (v510) goto L_014E;\n\tv115 = 0;\nL_0138:\n\tv283 = System.Reflection.PropertyInfo::get_CanWrite(v226[v115 @ X25_v8 (System.Int32)]);\n\tv592 = ~v283;\n\tv288 = ~v592;\n\tv257 = v226[v115 @ X25_v8 (System.Int32)];\n\tif (v288) goto L_0171;\n\tv115 = v115 + 1;\n\tv519 = v115 < v226.Length;\n\tif (v519) goto L_0138;\nL_014E:\n\tv551 = System.Linq.Enumerable::ToArray(v222);\n\tgoto L_0160;\nL_0160:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.String[]>::set_Item(v248._typeMemberNames, t, v551);\n\tv333 = v551;\nL_016F:\n\treturn v333;\nL_0170:\n\tthrow System.NullReferenceException;\nL_0171:\n\t;\n\tv296 = System.Reflection.MemberInfo::get_Name(v257);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string[] GetMemberNames(Type t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TypeFinder::GetMemberNames");
			return default;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81C8EEC", Offset = "0x81C8EEC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.Dictionary`2<System.Type, System.String[]>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.String[]>::.ctor(v49);\n\tv58._typeMemberNames = v49;\n")]
		static TypeFinder()
		{
			Dictionary<Type, string[]> typeMemberNames = new Dictionary<Type, string[]>();
			_typeMemberNames = typeMemberNames;
		}
	}
}
