using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.Privacy;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x200008A")]
	public static class EEARegionValidator
	{
		[Token(Token = "0x4000356")]
		public static readonly List<EEARegionValidationMethods> DefaultMethods;

		[Token(Token = "0x4000357")]
		private static IPlatformEEARegionValidator validator;

		[Token(Token = "0x60005E7")]
		[Address(RVA = "0xA55C48", Offset = "0xA55C48", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EDFB20]);\n\tv17 = *([v16 @ X8_v15]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021FAB]) = v37;\nL_0015:\n\tv41 = new System.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>();\n\tSystem.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>::.ctor(v41);\n\tSystem.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>::Add(v41, 0);\n\tSystem.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>::Add(v41, 1);\n\tSystem.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>::Add(v41, 2);\n\tSystem.Collections.Generic.List`1<EasyMobile.EEARegionValidationMethods>::Add(v41, 3);\n\tv81.DefaultMethods = v41;\n\tv69 = new EasyMobile.Internal.Privacy.AndroidEEARegionValidator();\n\tEasyMobile.Internal.Privacy.AndroidEEARegionValidator::.ctor(v69);\n\tv71.validator = v69;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static EEARegionValidator()
		{
			DefaultMethods = new List<EEARegionValidationMethods>
			{
				default(EEARegionValidationMethods),
				EEARegionValidationMethods.Telephony,
				EEARegionValidationMethods.Timezone,
				EEARegionValidationMethods.Locale
			};
			AndroidEEARegionValidator androidEEARegionValidator = new AndroidEEARegionValidator();
			validator = androidEEARegionValidator;
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0xA55D38", Offset = "0xA55D38", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFD710]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methods, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021FAC]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.EEARegionValidator>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, methods, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = EasyMobile.EEARegionValidator;\nL_0025:\n\tv59 = v57.validator == 0;\n\tif (v59) goto L_0061;\n\tgoto L_003B;\n\tv70 = *([v53 @ X0_v3 (Il2CppClass<EasyMobile.EEARegionValidator>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003B;\n\tv145 = EasyMobile.EEARegionValidator;\n\tv78 = *([v145 @ X8_v19 (Il2CppClass<EasyMobile.EEARegionValidator>)+B8]);\n\tv80 = v78.validator;\nL_003B:\n\tgoto L_0084;\n\tv104 = *([v82 @ X8_v15+B0]);\n\tv105 = 0;\n\tv106 = v104 + 8;\n\tv108 = *([v156 @ X11_v5-8]);\n\tv162 = v108 == v85;\n\tif (v162) goto L_0074;\n\tv141 = v157 + 1;\n\tv225 = v141 < v84;\n\tv135 = ~v225;\n\tv138 = v156 + 0x10;\n\tv111 = ~v135;\n\tif (v111) goto L_FFFFFFFF;\n\tv142 = v79;\n\tv143 = 0;\n\tv144 = 0x8909C4(v142, v85, v143, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0084;\nL_0061:\n\tgoto L_0072;\n\tv87 = *([v66 @ X0_v4+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0072;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v66, methods, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0072:\n\tUnityEngine.Debug::LogError(\"[ValidateEEARegionStatus]. Error: the validator hasn't been initialized.\");\n\treturn;\nL_0074:\n\tv226 = *([v156 @ X11_v5]);\n\tv227 = v226 << 4;\n\tv228 = v82 + v227;\n\tv229 = v228 + 0x130;\nL_0084:\n\tEasyMobile.Internal.Privacy.IPlatformEEARegionValidator::ValidateEEARegionStatus(v57.validator, methods, callback);\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ValidateEEARegionStatus(Action<EEARegionStatus> callback, List<EEARegionValidationMethods> methods)
		{
			if (validator == null)
			{
				Debug.LogError("[ValidateEEARegionStatus]. Error: the validator hasn't been initialized.");
			}
			else
			{
				validator.ValidateEEARegionStatus(methods, callback);
			}
		}

		[Token(Token = "0x60005E9")]
		[Address(RVA = "0xA55E8C", Offset = "0xA55E8C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAE0E8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021FAD]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.EEARegionValidator>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.EEARegionValidator;\nL_0028:\n\tEasyMobile.EEARegionValidator::ValidateEEARegionStatus(callback, v52.DefaultMethods);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ValidateEEARegionStatus(Action<EEARegionStatus> callback)
		{
			ValidateEEARegionStatus(callback, DefaultMethods);
		}
	}
}
