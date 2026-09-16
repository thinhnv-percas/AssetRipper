using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000069")]
	public class ActionData
	{
		[Token(Token = "0x2000096")]
		public class Context
		{
			[Token(Token = "0x400037A")]
			[FieldOffset(Offset = "0x10")]
			public Fsm currentFsm;

			[Token(Token = "0x400037B")]
			[FieldOffset(Offset = "0x18")]
			public FsmState currentState;

			[Token(Token = "0x400037C")]
			[FieldOffset(Offset = "0x20")]
			public FsmStateAction currentAction;

			[Token(Token = "0x400037D")]
			[FieldOffset(Offset = "0x28")]
			public int currentActionIndex;

			[Token(Token = "0x400037E")]
			[FieldOffset(Offset = "0x30")]
			public string currentParameter;

			[Token(Token = "0x60006B0")]
			[Address(RVA = "0x9CAE58", Offset = "0x9CAE58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Context()
			{
			}
		}

		[Token(Token = "0x4000191")]
		private const string autoNameString = "~AutoName";

		[Token(Token = "0x4000192")]
		private static readonly Dictionary<string, Type> ActionTypeLookup;

		[Token(Token = "0x4000193")]
		public static readonly Dictionary<Type, FieldInfo[]> ActionFieldsLookup;

		[Token(Token = "0x4000194")]
		public static readonly Dictionary<Type, int> ActionHashCodeLookup;

		[Token(Token = "0x4000195")]
		private static bool resaveActionData;

		[Token(Token = "0x4000196")]
		private static readonly List<int> UsedIndices;

		[Token(Token = "0x4000197")]
		private static readonly List<FieldInfo> InitFields;

		[SerializeField]
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x10")]
		private List<string> actionNames;

		[SerializeField]
		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x18")]
		private List<string> customNames;

		[SerializeField]
		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x20")]
		private List<bool> actionEnabled;

		[SerializeField]
		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x28")]
		private List<bool> actionIsOpen;

		[SerializeField]
		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x30")]
		private List<int> actionStartIndex;

		[SerializeField]
		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x38")]
		private List<int> actionHashCodes;

		[SerializeField]
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x40")]
		private List<UnityEngine.Object> unityObjectParams;

		[SerializeField]
		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x48")]
		private List<FsmGameObject> fsmGameObjectParams;

		[SerializeField]
		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x50")]
		private List<FsmOwnerDefault> fsmOwnerDefaultParams;

		[SerializeField]
		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x58")]
		private List<FsmAnimationCurve> animationCurveParams;

		[SerializeField]
		[Token(Token = "0x40001A2")]
		[FieldOffset(Offset = "0x60")]
		private List<FunctionCall> functionCallParams;

		[SerializeField]
		[Token(Token = "0x40001A3")]
		[FieldOffset(Offset = "0x68")]
		private List<FsmTemplateControl> fsmTemplateControlParams;

		[SerializeField]
		[Token(Token = "0x40001A4")]
		[FieldOffset(Offset = "0x70")]
		private List<FsmEventTarget> fsmEventTargetParams;

		[SerializeField]
		[Token(Token = "0x40001A5")]
		[FieldOffset(Offset = "0x78")]
		private List<FsmProperty> fsmPropertyParams;

		[SerializeField]
		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x80")]
		private List<LayoutOption> layoutOptionParams;

		[SerializeField]
		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x88")]
		private List<FsmString> fsmStringParams;

		[SerializeField]
		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x90")]
		private List<FsmObject> fsmObjectParams;

		[SerializeField]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x98")]
		private List<FsmVar> fsmVarParams;

		[SerializeField]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0xA0")]
		private List<FsmArray> fsmArrayParams;

		[SerializeField]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0xA8")]
		private List<FsmEnum> fsmEnumParams;

		[SerializeField]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0xB0")]
		private List<FsmFloat> fsmFloatParams;

		[SerializeField]
		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0xB8")]
		private List<FsmInt> fsmIntParams;

		[SerializeField]
		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0xC0")]
		private List<FsmBool> fsmBoolParams;

		[SerializeField]
		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0xC8")]
		private List<FsmVector2> fsmVector2Params;

		[SerializeField]
		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0xD0")]
		private List<FsmVector3> fsmVector3Params;

		[SerializeField]
		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0xD8")]
		private List<FsmColor> fsmColorParams;

		[SerializeField]
		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0xE0")]
		private List<FsmRect> fsmRectParams;

		[SerializeField]
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0xE8")]
		private List<FsmQuaternion> fsmQuaternionParams;

		[SerializeField]
		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0xF0")]
		private List<string> stringParams;

		[SerializeField]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0xF8")]
		private List<byte> byteData;

		[NonSerialized]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x100")]
		private byte[] byteDataAsArray;

		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x108")]
		private List<int> arrayParamSizes;

		[SerializeField]
		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x110")]
		private List<string> arrayParamTypes;

		[SerializeField]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x118")]
		private List<int> customTypeSizes;

		[SerializeField]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x120")]
		private List<string> customTypeNames;

		[SerializeField]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x128")]
		private List<ParamDataType> paramDataType;

		[SerializeField]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x130")]
		private List<string> paramName;

		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x138")]
		private List<int> paramDataPos;

		[SerializeField]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x140")]
		private List<int> paramByteDataSize;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x148")]
		private int nextParamIndex;

		[Token(Token = "0x40001C0")]
		private const int MUST_BE_LESS_THAN = 100000000;

		[Token(Token = "0x170000C0")]
		public int ActionCount
		{
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0x9C7ED0", Offset = "0x9C7ED0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED4D00]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219C1]) = v38;\nL_0013:\n\tv39 = this.actionNames;\n\treturn v39._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<string> list = ActionNames;
				return list.Count;
			}
		}

		[Token(Token = "0x170000C1")]
		public List<string> ActionNames
		{
			[Token(Token = "0x60002CE")]
			[Address(RVA = "0x9C7F24", Offset = "0x9C7F24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.actionNames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActionNames;
			}
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0x9C7F2C", Offset = "0x9C7F2C", Length = "0x424")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EE1910]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20219C2]) = v50;\nL_001C:\n\tv54 = new HutongGames.PlayMaker.ActionData();\n\tHutongGames.PlayMaker.ActionData::.ctor(v54);\n\tv60 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v60, this.actionNames);\n\tv54.actionNames = v60;\n\tv69 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v69, this.customNames);\n\tv54.customNames = v69;\n\tv79 = new System.Collections.Generic.List`1<System.Boolean>();\n\tSystem.Collections.Generic.List`1<System.Boolean>::.ctor(v79, this.actionEnabled);\n\tv54.actionEnabled = v79;\n\tv117 = new System.Collections.Generic.List`1<System.Boolean>();\n\tSystem.Collections.Generic.List`1<System.Boolean>::.ctor(v117, this.actionIsOpen);\n\tv54.actionIsOpen = v117;\n\tv125 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v125, this.actionStartIndex);\n\tv54.actionStartIndex = v125;\n\tv133 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v133, this.actionHashCodes);\n\tv54.actionHashCodes = v133;\n\tv138 = HutongGames.PlayMaker.ActionData::CopyFsmFloatParams(this);\n\tv54.fsmFloatParams = v138;\n\tv140 = HutongGames.PlayMaker.ActionData::CopyFsmIntParams(this);\n\tv54.fsmIntParams = v140;\n\tv142 = HutongGames.PlayMaker.ActionData::CopyFsmBoolParams(this);\n\tv54.fsmBoolParams = v142;\n\tv144 = HutongGames.PlayMaker.ActionData::CopyFsmColorParams(this);\n\tv54.fsmColorParams = v144;\n\tv146 = HutongGames.PlayMaker.ActionData::CopyFsmVector2Params(this);\n\tv54.fsmVector2Params = v146;\n\tv148 = HutongGames.PlayMaker.ActionData::CopyFsmVector3Params(this);\n\tv54.fsmVector3Params = v148;\n\tv150 = HutongGames.PlayMaker.ActionData::CopyFsmRectParams(this);\n\tv54.fsmRectParams = v150;\n\tv152 = HutongGames.PlayMaker.ActionData::CopyFsmQuaternionParams(this);\n\tv54.fsmQuaternionParams = v152;\n\tv154 = HutongGames.PlayMaker.ActionData::CopyStringParams(this);\n\tv54.stringParams = v154;\n\tv159 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v159, this.byteData);\n\tv54.byteData = v159;\n\tv166 = this.unityObjectParams == 0;\n\tif (v166) goto L_FFFFFFFF;\n\tv170 = new System.Collections.Generic.List`1<UnityEngine.Object>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Object>::.ctor(v170, this.unityObjectParams);\n\tgoto L_0094;\nL_0094:\n\tv54.unityObjectParams = v179;\n\tv183 = HutongGames.PlayMaker.ActionData::CopyFsmStringParams(this);\n\tv54.fsmStringParams = v183;\n\tv185 = HutongGames.PlayMaker.ActionData::CopyFsmObjectParams(this);\n\tv54.fsmObjectParams = v185;\n\tv187 = HutongGames.PlayMaker.ActionData::CopyFsmGameObjectParams(this);\n\tv54.fsmGameObjectParams = v187;\n\tv189 = HutongGames.PlayMaker.ActionData::CopyFsmOwnerDefaultParams(this);\n\tv54.fsmOwnerDefaultParams = v189;\n\tv191 = HutongGames.PlayMaker.ActionData::CopyAnimationCurveParams(this);\n\tv54.animationCurveParams = v191;\n\tv193 = HutongGames.PlayMaker.ActionData::CopyFunctionCallParams(this);\n\tv54.functionCallParams = v193;\n\tv195 = HutongGames.PlayMaker.ActionData::CopyFsmTemplateControlParams(this);\n\tv54.fsmTemplateControlParams = v195;\n\tv197 = HutongGames.PlayMaker.ActionData::CopyFsmVarParams(this);\n\tv54.fsmVarParams = v197;\n\tv199 = HutongGames.PlayMaker.ActionData::CopyFsmArrayParams(this);\n\tv54.fsmArrayParams = v199;\n\tv201 = HutongGames.PlayMaker.ActionData::CopyFsmEnumParams(this);\n\tv54.fsmEnumParams = v201;\n\tv203 = HutongGames.PlayMaker.ActionData::CopyFsmPropertyParams(this);\n\tv54.fsmPropertyParams = v203;\n\tv205 = HutongGames.PlayMaker.ActionData::CopyFsmEventTargetParams(this);\n\tv54.fsmEventTargetParams = v205;\n\tv207 = HutongGames.PlayMaker.ActionData::CopyLayoutOptionParams(this);\n\tv54.layoutOptionParams = v207;\n\tv209 = this.arrayParamSizes == 0;\n\tif (v209) goto L_FFFFFFFF;\n\tv211 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v211, this.arrayParamSizes);\n\tgoto L_00C6;\nL_00C6:\n\tv54.arrayParamSizes = v218;\n\tv221 = this.arrayParamTypes == 0;\n\tif (v221) goto L_FFFFFFFF;\n\tv223 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v223, this.arrayParamTypes);\n\tgoto L_00D2;\nL_00D2:\n\tv54.arrayParamTypes = v230;\n\tv233 = this.customTypeSizes == 0;\n\tif (v233) goto L_FFFFFFFF;\n\tv235 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v235, this.customTypeSizes);\n\tgoto L_00DE;\nL_00DE:\n\tv54.customTypeSizes = v242;\n\tv101 = this.customTypeNames == 0;\n\tif (v101) goto L_FFFFFFFF;\n\tv246 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v246, this.customTypeNames);\n\tgoto L_00EA;\nL_00EA:\n\tv54.customTypeNames = v253;\n\tv257 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v257, this.paramName);\n\tv54.paramName = v257;\n\tv263 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v263, this.paramDataPos);\n\tv54.paramDataPos = v263;\n\tv269 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v269, this.paramByteDataSize);\n\tv54.paramByteDataSize = v269;\n\tv277 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.ParamDataType>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ParamDataType>::.ctor(v277, this.paramDataType);\n\tv54.paramDataType = v277;\n\treturn v54;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionData Copy()
		{
			//IL_0459: Expected I4, but got O
			//IL_0022: Expected I4, but got O
			//IL_0044: Expected I4, but got O
			//IL_0066: Expected I4, but got O
			//IL_0088: Expected I4, but got O
			//IL_00aa: Expected I4, but got O
			//IL_01af: Expected I4, but got O
			//IL_01f0: Expected I4, but got O
			//IL_0349: Expected I4, but got O
			//IL_0375: Expected I4, but got O
			//IL_03a1: Expected I4, but got O
			//IL_0548: Expected I4, but got O
			//IL_0565: Expected I4, but got O
			//IL_03cd: Expected I4, but got O
			//IL_0406: Expected I4, but got O
			//IL_0428: Expected I4, but got O
			ActionData actionData = new ActionData();
			List<string> list = new List<string>((int)ActionNames);
			actionData.actionNames = list;
			List<string> list2 = new List<string>((int)customNames);
			actionData.customNames = list2;
			List<bool> list3 = new List<bool>((int)actionEnabled);
			actionData.actionEnabled = list3;
			List<bool> list4 = new List<bool>((int)actionIsOpen);
			actionData.actionIsOpen = list4;
			List<int> list5 = new List<int>((int)actionStartIndex);
			actionData.actionStartIndex = list5;
			List<int> list6 = new List<int>((int)actionHashCodes);
			actionData.actionHashCodes = list6;
			List<FsmFloat> list7 = CopyFsmFloatParams();
			actionData.fsmFloatParams = list7;
			List<FsmInt> list8 = CopyFsmIntParams();
			actionData.fsmIntParams = list8;
			List<FsmBool> list9 = CopyFsmBoolParams();
			actionData.fsmBoolParams = list9;
			List<FsmColor> list10 = CopyFsmColorParams();
			actionData.fsmColorParams = list10;
			List<FsmVector2> list11 = CopyFsmVector2Params();
			actionData.fsmVector2Params = list11;
			List<FsmVector3> list12 = CopyFsmVector3Params();
			actionData.fsmVector3Params = list12;
			List<FsmRect> list13 = CopyFsmRectParams();
			actionData.fsmRectParams = list13;
			List<FsmQuaternion> list14 = CopyFsmQuaternionParams();
			actionData.fsmQuaternionParams = list14;
			List<string> list15 = CopyStringParams();
			actionData.stringParams = list15;
			List<byte> list16 = new List<byte>((int)byteData);
			actionData.byteData = list16;
			List<UnityEngine.Object> list18;
			if (unityObjectParams != null)
			{
				List<UnityEngine.Object> list17 = new List<UnityEngine.Object>((int)unityObjectParams);
				list18 = list17;
			}
			else
			{
				list18 = null;
			}
			actionData.unityObjectParams = list18;
			List<FsmString> list19 = CopyFsmStringParams();
			actionData.fsmStringParams = list19;
			List<FsmObject> list20 = CopyFsmObjectParams();
			actionData.fsmObjectParams = list20;
			List<FsmGameObject> list21 = CopyFsmGameObjectParams();
			actionData.fsmGameObjectParams = list21;
			List<FsmOwnerDefault> list22 = CopyFsmOwnerDefaultParams();
			actionData.fsmOwnerDefaultParams = list22;
			List<FsmAnimationCurve> list23 = CopyAnimationCurveParams();
			actionData.animationCurveParams = list23;
			List<FunctionCall> list24 = CopyFunctionCallParams();
			actionData.functionCallParams = list24;
			List<FsmTemplateControl> list25 = CopyFsmTemplateControlParams();
			actionData.fsmTemplateControlParams = list25;
			List<FsmVar> list26 = CopyFsmVarParams();
			actionData.fsmVarParams = list26;
			List<FsmArray> list27 = CopyFsmArrayParams();
			actionData.fsmArrayParams = list27;
			List<FsmEnum> list28 = CopyFsmEnumParams();
			actionData.fsmEnumParams = list28;
			List<FsmProperty> list29 = CopyFsmPropertyParams();
			actionData.fsmPropertyParams = list29;
			List<FsmEventTarget> list30 = CopyFsmEventTargetParams();
			actionData.fsmEventTargetParams = list30;
			List<LayoutOption> list31 = CopyLayoutOptionParams();
			actionData.layoutOptionParams = list31;
			List<int> list33;
			if (arrayParamSizes != null)
			{
				List<int> list32 = new List<int>((int)arrayParamSizes);
				list33 = list32;
			}
			else
			{
				list33 = null;
			}
			actionData.arrayParamSizes = list33;
			List<string> list35;
			if (arrayParamTypes != null)
			{
				List<string> list34 = new List<string>((int)arrayParamTypes);
				list35 = list34;
			}
			else
			{
				list35 = null;
			}
			actionData.arrayParamTypes = list35;
			List<int> list37;
			if (customTypeSizes != null)
			{
				List<int> list36 = new List<int>((int)customTypeSizes);
				list37 = list36;
			}
			else
			{
				list37 = null;
			}
			actionData.customTypeSizes = list37;
			List<string> list39;
			if (customTypeNames != null)
			{
				List<string> list38 = new List<string>((int)customTypeNames);
				list39 = list38;
			}
			else
			{
				list39 = null;
			}
			actionData.customTypeNames = list39;
			List<string> list40 = new List<string>((int)paramName);
			actionData.paramName = list40;
			List<int> list41 = new List<int>((int)paramDataPos);
			actionData.paramDataPos = list41;
			List<int> list42 = new List<int>((int)paramByteDataSize);
			actionData.paramByteDataSize = list42;
			List<ParamDataType> list43 = new List<ParamDataType>((int)paramDataType);
			actionData.paramDataType = list43;
			return actionData;
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0x9C9120", Offset = "0x9C9120", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB6418]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219C3]) = v38;\nL_0014:\n\tv40 = this.stringParams == 0;\n\tif (v40) goto L_FFFFFFFF;\n\tv44 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v44, this.stringParams);\n\tgoto L_0028;\nL_0028:\n\treturn v55;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<string> CopyStringParams()
		{
			//IL_0010: Expected I4, but got O
			if (stringParams != null)
			{
				return new List<string>((int)stringParams);
			}
			return null;
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0x9C8500", Offset = "0x9C8500", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F08888]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C4]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmFloatParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::.ctor(v55);\n\tv129 = this.fsmFloatParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::GetEnumerator(this.fsmFloatParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>+Enumerator<HutongGames.PlayMaker.FsmFloat>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmFloat>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmFloat> CopyFsmFloatParams()
		{
			List<FsmFloat>.Enumerator enumerator = default(List<FsmFloat>.Enumerator);
			List<FsmFloat> result;
			if (fsmFloatParams != null)
			{
				List<FsmFloat> list = new List<FsmFloat>();
				if (fsmFloatParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmFloat>)(object)ex).Add((FsmFloat)null);
						List<FsmFloat> list2 = default(List<FsmFloat>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmFloat>)(object)ex).Add((FsmFloat)null);
					}
					return (List<FsmFloat>)(object)new TypeLoadException();
				}
				List<FsmFloat>.Enumerator enumerator2 = fsmFloatParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmFloat item = new FsmFloat((FsmFloat)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0x9C8684", Offset = "0x9C8684", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0DAC0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C5]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmIntParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::.ctor(v55);\n\tv129 = this.fsmIntParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::GetEnumerator(this.fsmIntParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>+Enumerator<HutongGames.PlayMaker.FsmInt>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmInt>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmInt> CopyFsmIntParams()
		{
			List<FsmInt>.Enumerator enumerator = default(List<FsmInt>.Enumerator);
			List<FsmInt> result;
			if (fsmIntParams != null)
			{
				List<FsmInt> list = new List<FsmInt>();
				if (fsmIntParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmInt>)(object)ex).Add((FsmInt)null);
						List<FsmInt> list2 = default(List<FsmInt>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmInt>)(object)ex).Add((FsmInt)null);
					}
					return (List<FsmInt>)(object)new TypeLoadException();
				}
				List<FsmInt>.Enumerator enumerator2 = fsmIntParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmInt item = new FsmInt((FsmInt)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x9C8808", Offset = "0x9C8808", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F08F70]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C6]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmBoolParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::.ctor(v55);\n\tv129 = this.fsmBoolParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::GetEnumerator(this.fsmBoolParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>+Enumerator<HutongGames.PlayMaker.FsmBool>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmBool>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmBool> CopyFsmBoolParams()
		{
			List<FsmBool>.Enumerator enumerator = default(List<FsmBool>.Enumerator);
			List<FsmBool> result;
			if (fsmBoolParams != null)
			{
				List<FsmBool> list = new List<FsmBool>();
				if (fsmBoolParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmBool>)(object)ex).Add((FsmBool)null);
						List<FsmBool> list2 = default(List<FsmBool>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmBool>)(object)ex).Add((FsmBool)null);
					}
					return (List<FsmBool>)(object)new TypeLoadException();
				}
				List<FsmBool>.Enumerator enumerator2 = fsmBoolParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmBool item = new FsmBool((FsmBool)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x9C8B10", Offset = "0x9C8B10", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED8998]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C7]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmVector2Params == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::.ctor(v55);\n\tv129 = this.fsmVector2Params == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::GetEnumerator(this.fsmVector2Params);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>+Enumerator<HutongGames.PlayMaker.FsmVector2>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector2>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmVector2> CopyFsmVector2Params()
		{
			List<FsmVector2>.Enumerator enumerator = default(List<FsmVector2>.Enumerator);
			List<FsmVector2> result;
			if (fsmVector2Params != null)
			{
				List<FsmVector2> list = new List<FsmVector2>();
				if (fsmVector2Params == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmVector2>)(object)ex).Add((FsmVector2)null);
						List<FsmVector2> list2 = default(List<FsmVector2>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmVector2>)(object)ex).Add((FsmVector2)null);
					}
					return (List<FsmVector2>)(object)new TypeLoadException();
				}
				List<FsmVector2>.Enumerator enumerator2 = fsmVector2Params.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmVector2 item = new FsmVector2((FsmVector2)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x9C8C94", Offset = "0x9C8C94", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EEF728]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C8]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmVector3Params == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::.ctor(v55);\n\tv129 = this.fsmVector3Params == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::GetEnumerator(this.fsmVector3Params);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>+Enumerator<HutongGames.PlayMaker.FsmVector3>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVector3>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmVector3> CopyFsmVector3Params()
		{
			List<FsmVector3>.Enumerator enumerator = default(List<FsmVector3>.Enumerator);
			List<FsmVector3> result;
			if (fsmVector3Params != null)
			{
				List<FsmVector3> list = new List<FsmVector3>();
				if (fsmVector3Params == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmVector3>)(object)ex).Add((FsmVector3)null);
						List<FsmVector3> list2 = default(List<FsmVector3>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmVector3>)(object)ex).Add((FsmVector3)null);
					}
					return (List<FsmVector3>)(object)new TypeLoadException();
				}
				List<FsmVector3>.Enumerator enumerator2 = fsmVector3Params.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmVector3 item = new FsmVector3((FsmVector3)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x9C898C", Offset = "0x9C898C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EABDB0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219C9]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmColorParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::.ctor(v55);\n\tv129 = this.fsmColorParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::GetEnumerator(this.fsmColorParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>+Enumerator<HutongGames.PlayMaker.FsmColor>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmColor>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmColor> CopyFsmColorParams()
		{
			List<FsmColor>.Enumerator enumerator = default(List<FsmColor>.Enumerator);
			List<FsmColor> result;
			if (fsmColorParams != null)
			{
				List<FsmColor> list = new List<FsmColor>();
				if (fsmColorParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmColor>)(object)ex).Add((FsmColor)null);
						List<FsmColor> list2 = default(List<FsmColor>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmColor>)(object)ex).Add((FsmColor)null);
					}
					return (List<FsmColor>)(object)new TypeLoadException();
				}
				List<FsmColor>.Enumerator enumerator2 = fsmColorParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmColor item = new FsmColor((FsmColor)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x9C8E18", Offset = "0x9C8E18", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F063C0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CA]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmRectParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::.ctor(v55);\n\tv129 = this.fsmRectParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::GetEnumerator(this.fsmRectParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>+Enumerator<HutongGames.PlayMaker.FsmRect>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmRect>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmRect> CopyFsmRectParams()
		{
			List<FsmRect>.Enumerator enumerator = default(List<FsmRect>.Enumerator);
			List<FsmRect> result;
			if (fsmRectParams != null)
			{
				List<FsmRect> list = new List<FsmRect>();
				if (fsmRectParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmRect>)(object)ex).Add((FsmRect)null);
						List<FsmRect> list2 = default(List<FsmRect>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmRect>)(object)ex).Add((FsmRect)null);
					}
					return (List<FsmRect>)(object)new TypeLoadException();
				}
				List<FsmRect>.Enumerator enumerator2 = fsmRectParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmRect item = new FsmRect((FsmRect)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x9C8F9C", Offset = "0x9C8F9C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EACBA8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CB]) = v46;\nL_001B:\n\tv51 = this.fsmQuaternionParams == 0;\n\tif (v51) goto L_004B;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmQuaternion>();\n\treturnVal2 = 0x9E2A78(v55, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n\tSystem.Collections.Generic.List`1::.ctor /* +161 sharing this address */(X0, X1);\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_0054;\n\tX8 = *([1EA5720]);\n\tX1 = *([X8]);\n\tX8 = &stack[8];\n\tX0 = System.Collections.Generic.List`1::GetEnumerator /* +104 sharing this address */(X0, X1);\n\tX22 = *([1EAD970]);\n\tX23 = *([1EECE08]);\n\tX24 = *([1EF6FD0]);\nL_0035:\n\tX1 = *([X22]);\n\tX0 = &stack[8];\n\tX0 = 0xEF9AB0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_004C;\n\tX21 = stack[18];\n\tX0 = *([X23]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = 0;\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(X0, X1, X2);\n\tif (TEMP) goto L_0052;\n\tX2 = *([X24]);\n\tX0 = X19;\n\tX1 = X20;\n\tSystem.Collections.Generic.List`1::Add /* +161 sharing this address */(X0, X1, X2);\n\tgoto L_0035;\nL_004B:\n\tgoto L_0078;\nL_004C:\n\tX8 = 0x1F10000;\n\tX8 = *([1F10508]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0078;\nL_0052:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0058;\n\tgoto L_0058;\n\tgoto L_0058;\nL_0058:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0079;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F10508]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007A;\nL_0078:\n\treturn 0;\nL_0079:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmQuaternion> CopyFsmQuaternionParams()
		{
			if (fsmQuaternionParams != null)
			{
				List<FsmQuaternion> list = null;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9E2A78 (inside HutongGames.PlayMaker.Fsm::.cctor +0x2C4)");
				List<FsmQuaternion> result = default(List<FsmQuaternion>);
				return result;
			}
			return null;
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x9C919C", Offset = "0x9C919C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F026E0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CC]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmStringParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::.ctor(v55);\n\tv129 = this.fsmStringParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::GetEnumerator(this.fsmStringParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>+Enumerator<HutongGames.PlayMaker.FsmString>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmString>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmString> CopyFsmStringParams()
		{
			List<FsmString>.Enumerator enumerator = default(List<FsmString>.Enumerator);
			List<FsmString> result;
			if (fsmStringParams != null)
			{
				List<FsmString> list = new List<FsmString>();
				if (fsmStringParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmString>)(object)ex).Add((FsmString)null);
						List<FsmString> list2 = default(List<FsmString>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmString>)(object)ex).Add((FsmString)null);
					}
					return (List<FsmString>)(object)new TypeLoadException();
				}
				List<FsmString>.Enumerator enumerator2 = fsmStringParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmString item = new FsmString((FsmString)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0x9C9320", Offset = "0x9C9320", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F10CC0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CD]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmObjectParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::.ctor(v55);\n\tv129 = this.fsmObjectParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::GetEnumerator(this.fsmObjectParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>+Enumerator<HutongGames.PlayMaker.FsmObject>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmObject>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmObject> CopyFsmObjectParams()
		{
			List<FsmObject>.Enumerator enumerator = default(List<FsmObject>.Enumerator);
			List<FsmObject> result;
			if (fsmObjectParams != null)
			{
				List<FsmObject> list = new List<FsmObject>();
				if (fsmObjectParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmObject>)(object)ex).Add((FsmObject)null);
						List<FsmObject> list2 = default(List<FsmObject>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmObject>)(object)ex).Add((FsmObject)null);
					}
					return (List<FsmObject>)(object)new TypeLoadException();
				}
				List<FsmObject>.Enumerator enumerator2 = fsmObjectParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmObject item = new FsmObject((FsmObject)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0x9C94A4", Offset = "0x9C94A4", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EDAD90]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CE]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmGameObjectParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::.ctor(v55);\n\tv129 = this.fsmGameObjectParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::GetEnumerator(this.fsmGameObjectParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>+Enumerator<HutongGames.PlayMaker.FsmGameObject>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmGameObject>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmGameObject> CopyFsmGameObjectParams()
		{
			List<FsmGameObject>.Enumerator enumerator = default(List<FsmGameObject>.Enumerator);
			List<FsmGameObject> result;
			if (fsmGameObjectParams != null)
			{
				List<FsmGameObject> list = new List<FsmGameObject>();
				if (fsmGameObjectParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmGameObject>)(object)ex).Add((FsmGameObject)null);
						List<FsmGameObject> list2 = default(List<FsmGameObject>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmGameObject>)(object)ex).Add((FsmGameObject)null);
					}
					return (List<FsmGameObject>)(object)new TypeLoadException();
				}
				List<FsmGameObject>.Enumerator enumerator2 = fsmGameObjectParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmGameObject item = new FsmGameObject((FsmGameObject)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0x9C9628", Offset = "0x9C9628", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED8B70]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219CF]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmOwnerDefaultParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::.ctor(v55);\n\tv129 = this.fsmOwnerDefaultParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::GetEnumerator(this.fsmOwnerDefaultParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>+Enumerator<HutongGames.PlayMaker.FsmOwnerDefault>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmOwnerDefault>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmOwnerDefault> CopyFsmOwnerDefaultParams()
		{
			List<FsmOwnerDefault>.Enumerator enumerator = default(List<FsmOwnerDefault>.Enumerator);
			List<FsmOwnerDefault> result;
			if (fsmOwnerDefaultParams != null)
			{
				List<FsmOwnerDefault> list = new List<FsmOwnerDefault>();
				if (fsmOwnerDefaultParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmOwnerDefault>)(object)ex).Add((FsmOwnerDefault)null);
						List<FsmOwnerDefault> list2 = default(List<FsmOwnerDefault>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmOwnerDefault>)(object)ex).Add((FsmOwnerDefault)null);
					}
					return (List<FsmOwnerDefault>)(object)new TypeLoadException();
				}
				List<FsmOwnerDefault>.Enumerator enumerator2 = fsmOwnerDefaultParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmOwnerDefault item = new FsmOwnerDefault(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0x9C97AC", Offset = "0x9C97AC", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ECE238]);\n\tv29 = *([v28 @ X8_v21]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20219D0]) = v48;\nL_001C:\n\tv53 = this.animationCurveParams == 0;\n\tif (v53) goto L_FFFFFFFF;\n\tv57 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::.ctor(v57);\n\tv148 = this.animationCurveParams == 0;\n\tif (v148) goto L_008C;\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::GetEnumerator(this.animationCurveParams);\nL_003B:\n\tv215 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>::MoveNext(&v120 @ stack_-88_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>));\n\tv129 = v215 == 0;\n\tif (v129) goto L_007B;\n\tv221 = new HutongGames.PlayMaker.FsmAnimationCurve();\n\tHutongGames.PlayMaker.FsmAnimationCurve::.ctor(v221);\n\tv245 = UnityEngine.AnimationCurve::get_keys(*([v201 @ stack_-78+10]));\n\tUnityEngine.AnimationCurve::set_keys(v221.curve, v245);\n\tv273 = UnityEngine.AnimationCurve::get_preWrapMode(*([v201 @ stack_-78+10]));\n\tUnityEngine.AnimationCurve::set_preWrapMode(v221.curve, v273);\n\tv293 = UnityEngine.AnimationCurve::get_postWrapMode(*([v201 @ stack_-78+10]));\n\tUnityEngine.AnimationCurve::set_postWrapMode(v221.curve, v293);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::Add(v57, v221);\n\tgoto L_003B;\n\tgoto L_00C0;\nL_007B:\n\tv126 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>::Dispose(&v120 @ stack_-88_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>));\n\tgoto L_00C0;\n\tthrow System.NullReferenceException;\n\tv242 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv256 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv277 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv193 = new System.NullReferenceException();\nL_008C:\n\tv200 = new System.NullReferenceException();\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\n\tgoto L_00A8;\nL_00A8:\n\tv64 = v190 != 1;\n\tif (v64) goto L_00C1;\n\tv218 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::.ctor(v200);\n\tv224 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::.ctor(v218);\n\tv125 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>::Dispose(&v103 @ stack_-70_v3 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>+Enumerator<HutongGames.PlayMaker.FsmAnimationCurve>));\n\tv233 = *([v218 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>)]) == 0;\n\tv128 = ~v233;\n\tif (v128) goto L_00C5;\nL_00C0:\n\treturn v136;\nL_00C1:\n\tv219 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmAnimationCurve>::.ctor(v200);\nL_00C5:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmAnimationCurve> CopyAnimationCurveParams()
		{
			//IL_0075: Expected O, but got I
			//IL_00a7: Expected O, but got I
			//IL_00d9: Expected O, but got I
			List<FsmAnimationCurve> result;
			if (animationCurveParams != null)
			{
				List<FsmAnimationCurve> list = new List<FsmAnimationCurve>();
				bool flag = animationCurveParams == null;
				List<FsmAnimationCurve>.Enumerator enumerator2 = default(List<FsmAnimationCurve>.Enumerator);
				List<FsmAnimationCurve>.Enumerator enumerator = enumerator2;
				if (flag)
				{
					NullReferenceException ex = (NullReferenceException)(object)new List<FsmAnimationCurve>();
					IntPtr intPtr = default(IntPtr);
					if (intPtr == (IntPtr)1)
					{
						enumerator.Dispose();
						List<FsmAnimationCurve> list2 = default(List<FsmAnimationCurve>);
						bool flag2 = list2 == null;
						bool flag3 = !flag2;
						result = list;
						if (!flag3)
						{
							goto IL_0198;
						}
					}
					return (List<FsmAnimationCurve>)(object)new TypeLoadException();
				}
				List<FsmAnimationCurve>.Enumerator enumerator3 = animationCurveParams.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					FsmAnimationCurve fsmAnimationCurve = new FsmAnimationCurve();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-78+10]");
					Keyframe[] keys = ((AnimationCurve)0).keys;
					fsmAnimationCurve.curve.keys = keys;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-78+10]");
					WrapMode preWrapMode = ((AnimationCurve)0).preWrapMode;
					fsmAnimationCurve.curve.preWrapMode = preWrapMode;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ stack_-78+10]");
					WrapMode postWrapMode = ((AnimationCurve)0).postWrapMode;
					fsmAnimationCurve.curve.postWrapMode = postWrapMode;
					list.Add(fsmAnimationCurve);
				}
				enumerator2.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_0198;
			IL_0198:
			return result;
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0x9C9A34", Offset = "0x9C9A34", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE43A8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D1]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.functionCallParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::.ctor(v55);\n\tv129 = this.functionCallParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::GetEnumerator(this.functionCallParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FunctionCall();\n\tHutongGames.PlayMaker.FunctionCall::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>+Enumerator<HutongGames.PlayMaker.FunctionCall>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FunctionCall>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FunctionCall> CopyFunctionCallParams()
		{
			List<FunctionCall>.Enumerator enumerator = default(List<FunctionCall>.Enumerator);
			List<FunctionCall> result;
			if (functionCallParams != null)
			{
				List<FunctionCall> list = new List<FunctionCall>();
				if (functionCallParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FunctionCall>)(object)ex).Add((FunctionCall)null);
						List<FunctionCall> list2 = default(List<FunctionCall>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FunctionCall>)(object)ex).Add((FunctionCall)null);
					}
					return (List<FunctionCall>)(object)new TypeLoadException();
				}
				List<FunctionCall>.Enumerator enumerator2 = functionCallParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FunctionCall item = new FunctionCall(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0x9C9BB8", Offset = "0x9C9BB8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE2EA0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D2]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmTemplateControlParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::.ctor(v55);\n\tv129 = this.fsmTemplateControlParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::GetEnumerator(this.fsmTemplateControlParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmTemplateControl();\n\tHutongGames.PlayMaker.FsmTemplateControl::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>+Enumerator<HutongGames.PlayMaker.FsmTemplateControl>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmTemplateControl>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmTemplateControl> CopyFsmTemplateControlParams()
		{
			List<FsmTemplateControl>.Enumerator enumerator = default(List<FsmTemplateControl>.Enumerator);
			List<FsmTemplateControl> result;
			if (fsmTemplateControlParams != null)
			{
				List<FsmTemplateControl> list = new List<FsmTemplateControl>();
				if (fsmTemplateControlParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmTemplateControl>)(object)ex).Add((FsmTemplateControl)null);
						List<FsmTemplateControl> list2 = default(List<FsmTemplateControl>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmTemplateControl>)(object)ex).Add((FsmTemplateControl)null);
					}
					return (List<FsmTemplateControl>)(object)new TypeLoadException();
				}
				List<FsmTemplateControl>.Enumerator enumerator2 = fsmTemplateControlParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmTemplateControl item = new FsmTemplateControl(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0x9C9D3C", Offset = "0x9C9D3C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EBB2E0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D3]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmVarParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::.ctor(v55);\n\tv129 = this.fsmVarParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::GetEnumerator(this.fsmVarParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>+Enumerator<HutongGames.PlayMaker.FsmVar>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmVar>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmVar> CopyFsmVarParams()
		{
			List<FsmVar>.Enumerator enumerator = default(List<FsmVar>.Enumerator);
			List<FsmVar> result;
			if (fsmVarParams != null)
			{
				List<FsmVar> list = new List<FsmVar>();
				if (fsmVarParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmVar>)(object)ex).Add((FsmVar)null);
						List<FsmVar> list2 = default(List<FsmVar>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmVar>)(object)ex).Add((FsmVar)null);
					}
					return (List<FsmVar>)(object)new TypeLoadException();
				}
				List<FsmVar>.Enumerator enumerator2 = fsmVarParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmVar item = new FsmVar((FsmVar)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0x9C9EC0", Offset = "0x9C9EC0", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED8BD0]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D4]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmArrayParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::.ctor(v55);\n\tv92 = this.fsmArrayParams == 0;\n\tif (v92) goto L_0053;\n\tv152 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::GetEnumerator(this.fsmArrayParams);\nL_0036:\n\tv172 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>+Enumerator<HutongGames.PlayMaker.FsmArray>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>+Enumerator<HutongGames.PlayMaker.FsmArray>));\n\tv76 = v172 == 0;\n\tif (v76) goto L_004F;\n\tv178 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v178, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::Add(v55, v178);\n\tgoto L_0036;\n\tgoto L_0078;\nL_004F:\n\tv74 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>+Enumerator<HutongGames.PlayMaker.FsmArray>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>+Enumerator<HutongGames.PlayMaker.FsmArray>));\n\tgoto L_0078;\n\tv157 = new System.NullReferenceException();\nL_0053:\n\tv160 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv95 = 0 != 1;\n\tif (v95) goto L_0079;\n\tv175 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::Add(v160, 0);\n\tv181 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::Add(v175, 0);\n\treturnVal3 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::Add(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>+Enumerator<HutongGames.PlayMaker.FsmArray>), 0);\n\treturn returnVal3;\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_007A;\nL_0078:\n\treturn v81;\nL_0079:\n\tv176 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmArray>::Add(v160, 0);\nL_007A:\n\t;\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmArray> CopyFsmArrayParams()
		{
			List<FsmArray>.Enumerator enumerator = default(List<FsmArray>.Enumerator);
			if (fsmArrayParams != null)
			{
				List<FsmArray> list = new List<FsmArray>();
				if (fsmArrayParams != null)
				{
					List<FsmArray>.Enumerator enumerator2 = fsmArrayParams.GetEnumerator();
					while (enumerator.MoveNext())
					{
						FsmArray item = new FsmArray((FsmArray)null);
						list.Add(item);
					}
					enumerator.Dispose();
					return list;
				}
				NullReferenceException ex = new NullReferenceException();
				if (0 == 1)
				{
					((List<FsmArray>)(object)ex).Add((FsmArray)null);
					List<FsmArray> list2 = default(List<FsmArray>);
					list2.Add(null);
					((List<FsmArray>)enumerator).Add((FsmArray)null);
					List<FsmArray> result = default(List<FsmArray>);
					return result;
				}
				((List<FsmArray>)(object)ex).Add((FsmArray)null);
				return (List<FsmArray>)(object)new TypeLoadException();
			}
			return null;
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0x9CA044", Offset = "0x9CA044", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF77D8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D5]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmEnumParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::.ctor(v55);\n\tv129 = this.fsmEnumParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::GetEnumerator(this.fsmEnumParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>+Enumerator<HutongGames.PlayMaker.FsmEnum>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEnum>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmEnum> CopyFsmEnumParams()
		{
			List<FsmEnum>.Enumerator enumerator = default(List<FsmEnum>.Enumerator);
			List<FsmEnum> result;
			if (fsmEnumParams != null)
			{
				List<FsmEnum> list = new List<FsmEnum>();
				if (fsmEnumParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmEnum>)(object)ex).Add((FsmEnum)null);
						List<FsmEnum> list2 = default(List<FsmEnum>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmEnum>)(object)ex).Add((FsmEnum)null);
					}
					return (List<FsmEnum>)(object)new TypeLoadException();
				}
				List<FsmEnum>.Enumerator enumerator2 = fsmEnumParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmEnum item = new FsmEnum((FsmEnum)null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0x9CA1C8", Offset = "0x9CA1C8", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1ED4DD8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D6]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmPropertyParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::.ctor(v55);\n\tv129 = this.fsmPropertyParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::GetEnumerator(this.fsmPropertyParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmProperty();\n\tHutongGames.PlayMaker.FsmProperty::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>+Enumerator<HutongGames.PlayMaker.FsmProperty>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmProperty>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmProperty> CopyFsmPropertyParams()
		{
			List<FsmProperty>.Enumerator enumerator = default(List<FsmProperty>.Enumerator);
			List<FsmProperty> result;
			if (fsmPropertyParams != null)
			{
				List<FsmProperty> list = new List<FsmProperty>();
				if (fsmPropertyParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmProperty>)(object)ex).Add((FsmProperty)null);
						List<FsmProperty> list2 = default(List<FsmProperty>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmProperty>)(object)ex).Add((FsmProperty)null);
					}
					return (List<FsmProperty>)(object)new TypeLoadException();
				}
				List<FsmProperty>.Enumerator enumerator2 = fsmPropertyParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmProperty item = new FsmProperty(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0x9CA34C", Offset = "0x9CA34C", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EC58C8]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D7]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.fsmEventTargetParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::.ctor(v55);\n\tv129 = this.fsmEventTargetParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::GetEnumerator(this.fsmEventTargetParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>+Enumerator<HutongGames.PlayMaker.FsmEventTarget>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmEventTarget>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<FsmEventTarget> CopyFsmEventTargetParams()
		{
			List<FsmEventTarget>.Enumerator enumerator = default(List<FsmEventTarget>.Enumerator);
			List<FsmEventTarget> result;
			if (fsmEventTargetParams != null)
			{
				List<FsmEventTarget> list = new List<FsmEventTarget>();
				if (fsmEventTargetParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<FsmEventTarget>)(object)ex).Add((FsmEventTarget)null);
						List<FsmEventTarget> list2 = default(List<FsmEventTarget>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<FsmEventTarget>)(object)ex).Add((FsmEventTarget)null);
					}
					return (List<FsmEventTarget>)(object)new TypeLoadException();
				}
				List<FsmEventTarget>.Enumerator enumerator2 = fsmEventTargetParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FsmEventTarget item = new FsmEventTarget(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x9CA4D0", Offset = "0x9CA4D0", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EDD218]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219D8]) = v46;\nL_0019:\n\tv49 = 0;\n\tv51 = this.layoutOptionParams == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv55 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::.ctor(v55);\n\tv129 = this.layoutOptionParams == 0;\n\tif (v129) goto L_0053;\n\tv162 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::GetEnumerator(this.layoutOptionParams);\nL_0036:\n\tv186 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>::MoveNext(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>));\n\tv111 = v186 == 0;\n\tif (v111) goto L_004F;\n\tv192 = new HutongGames.PlayMaker.LayoutOption();\n\tHutongGames.PlayMaker.LayoutOption::.ctor(v192, 0);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::Add(v55, v192);\n\tgoto L_0036;\n\tgoto L_0077;\nL_004F:\n\tv108 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>));\n\tgoto L_0077;\n\tv168 = new System.NullReferenceException();\nL_0053:\n\tv174 = new System.NullReferenceException();\n\tgoto L_0060;\n\tgoto L_0060;\n\tgoto L_0060;\nL_0060:\n\tv62 = 0 != 1;\n\tif (v62) goto L_0078;\n\tv189 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::Add(v174, 0);\n\tv195 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::Add(v189, 0);\n\tv107 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>::Dispose(&v49 @ stack_-58_v1 (System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>+Enumerator<HutongGames.PlayMaker.LayoutOption>));\n\tv202 = *([v189 @ X0_v13 (System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>)]) == 0;\n\tv110 = ~v202;\n\tif (v110) goto L_007C;\nL_0077:\n\treturn v118;\nL_0078:\n\tv190 = System.Collections.Generic.List`1<HutongGames.PlayMaker.LayoutOption>::Add(v174, 0);\nL_007C:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private List<LayoutOption> CopyLayoutOptionParams()
		{
			List<LayoutOption>.Enumerator enumerator = default(List<LayoutOption>.Enumerator);
			List<LayoutOption> result;
			if (layoutOptionParams != null)
			{
				List<LayoutOption> list = new List<LayoutOption>();
				if (layoutOptionParams == null)
				{
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						((List<LayoutOption>)(object)ex).Add((LayoutOption)null);
						List<LayoutOption> list2 = default(List<LayoutOption>);
						list2.Add(null);
						enumerator.Dispose();
						bool flag = list2 == null;
						bool flag2 = !flag;
						result = list;
						if (!flag2)
						{
							goto IL_010a;
						}
					}
					else
					{
						((List<LayoutOption>)(object)ex).Add((LayoutOption)null);
					}
					return (List<LayoutOption>)(object)new TypeLoadException();
				}
				List<LayoutOption>.Enumerator enumerator2 = layoutOptionParams.GetEnumerator();
				while (enumerator.MoveNext())
				{
					LayoutOption item = new LayoutOption(null);
					list.Add(item);
				}
				enumerator.Dispose();
				result = list;
			}
			else
			{
				result = null;
			}
			goto IL_010a;
			IL_010a:
			return result;
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x9CA654", Offset = "0x9CA654", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F01B48]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20219D9]) = v40;\nL_001A:\n\tSystem.Collections.Generic.List`1<System.String>::Clear(this.actionNames);\n\tSystem.Collections.Generic.List`1<System.String>::Clear(this.customNames);\n\tSystem.Collections.Generic.List`1<System.Boolean>::Clear(this.actionEnabled);\n\tSystem.Collections.Generic.List`1<System.Boolean>::Clear(this.actionIsOpen);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.actionStartIndex);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.actionHashCodes);\n\tSystem.Collections.Generic.List`1<System.Byte>::Clear(this.byteData);\n\tv108 = this + 0x40;\n\tv109 = 0x6D26F0(v108, 0, 0xB8, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tthis.arrayParamSizes = 0;\n\tthis.arrayParamTypes = 0;\n\tthis.customTypeSizes = 0;\n\tthis.customTypeNames = 0;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.paramDataPos);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.paramByteDataSize);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ParamDataType>::Clear(this.paramDataType);\n\tSystem.Collections.Generic.List`1<System.String>::Clear(this.paramName);\n\tthis.nextParamIndex = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearActionData()
		{
			//IL_007c: Expected O, but got I
			ActionNames.Clear();
			customNames.Clear();
			actionEnabled.Clear();
			actionIsOpen.Clear();
			actionStartIndex.Clear();
			actionHashCodes.Clear();
			byteData.Clear();
			object obj = (long)(IntPtr)this + 64L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			arrayParamSizes = null;
			arrayParamTypes = null;
			customTypeSizes = null;
			customTypeNames = null;
			paramDataPos.Clear();
			paramByteDataSize.Clear();
			paramDataType.Clear();
			paramName.Clear();
			nextParamIndex = 0;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x9CA794", Offset = "0x9CA794", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA8EA8]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219DA]) = v38;\nL_001A:\n\tgoto L_002A;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\t// 30 Jump @b24\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = HutongGames.PlayMaker.ActionData;\nL_002A:\n\tv63 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v53.ActionTypeLookup, actionName, &v60 @ stack_-28_v3 (System.Type));\n\tv78 = v63 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_FFFFFFFF;\n\tgoto L_003D;\n\tv120 = *([v82 @ X0_v11+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_003D;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v82, v61, v59, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\treturnVal2 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(actionName);\n\tv129 = returnVal2 == 0;\n\tif (v129) goto L_005C;\n\tgoto L_0055;\n\tv134 = *([v130 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\t// 73 ConditionalJump @b26, v136 @ TEMP_v23\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v130, v66, v59, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv138 = HutongGames.PlayMaker.ActionData;\nL_0055:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::set_Item(v75.ActionTypeLookup, actionName, returnVal2);\nL_005C:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type GetActionType(string actionName)
		{
			Type type = default(Type);
			if (!ActionTypeLookup.TryGetValue(actionName, out var _))
			{
				type = ReflectionUtils.GetGlobalType(actionName);
				if ((object)type == null)
				{
					goto IL_00a0;
				}
				ActionTypeLookup.set_Item(actionName, type);
			}
			type = type;
			goto IL_00a0;
			IL_00a0:
			return type;
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x9CA8A8", Offset = "0x9CA8A8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA9060]);\n\tv19 = *([v18 @ X8_v24]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219DB]) = v38;\nL_001A:\n\tgoto L_002A;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\t// 30 Jump @b23\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = HutongGames.PlayMaker.ActionData;\nL_002A:\n\tv63 = System.Collections.Generic.Dictionary`2<System.Type, System.Reflection.FieldInfo[]>::TryGetValue(v53.ActionFieldsLookup, actionType, &v60 @ stack_-28_v3 (System.Reflection.FieldInfo[]));\n\tv81 = v63 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_005B;\n\tgoto L_003D;\n\tv118 = *([v85 @ X0_v10+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003D;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v85, v61, v59, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003D:\n\tv126 = HutongGames.PlayMaker.ReflectionUtils::GetPublicFields(actionType);\n\tgoto L_0054;\n\tv131 = *([v127 @ X8_v14 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\t// 71 ConditionalJump @b24, v133 @ TEMP_v21\n\tv139 = v127;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v139, v69, v59, v62, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv138 = HutongGames.PlayMaker.ActionData;\nL_0054:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Reflection.FieldInfo[]>::set_Item(v78.ActionFieldsLookup, actionType, v126);\nL_005B:\n\treturn v126;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FieldInfo[] GetFields(Type actionType)
		{
			FieldInfo[] publicFields = default(FieldInfo[]);
			if (!ActionFieldsLookup.TryGetValue(actionType, out var _))
			{
				publicFields = actionType.GetPublicFields();
				ActionFieldsLookup.set_Item(actionType, publicFields);
			}
			return publicFields;
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x9CA9BC", Offset = "0x9CA9BC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EECE18]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219DC]) = v46;\nL_001E:\n\tgoto L_002E;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\t// 34 Jump @b32\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = HutongGames.PlayMaker.ActionData;\nL_002E:\n\tv71 = System.Collections.Generic.Dictionary`2<System.Type, System.Int32>::TryGetValue(v61.ActionHashCodeLookup, actionType, &v68 @ stack_-44_v4 (System.Int32));\n\tv154 = v71 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_009F;\n\tgoto L_0041;\n\tv226 = *([v184 @ X0_v13+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_0041;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v184, v69, v67, v70, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0041:\n\tv137 = HutongGames.PlayMaker.ActionData::GetFields(actionType);\n\tv180 = v137.Length;\n\tv270 = v137.Length < 1;\n\tif (v270) goto L_0080;\nL_0055:\n\tv306 = v77 < v180;\n\tv116 = ~v306;\n\tif (v116) goto L_00A1;\n\tv319 = System.Reflection.FieldInfo::get_FieldType(v137[v77 @ X23_v7 (System.Int32)]);\n\tv289 = System.String::Concat(v150, v319, \"|\");\n\tv180 = v137.Length;\n\tv77 = v77 + 1;\n\tv274 = v77 < v137.Length;\n\tif (v274) goto L_0055;\nL_0080:\n\tgoto L_0087;\n\tv307 = *([v294 @ X0_v18+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_0087;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v294, v130, v135, v127, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0087:\n\tv315 = HutongGames.PlayMaker.ActionData::GetStableHash(v151);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Int32>::set_Item(v123.ActionHashCodeLookup, actionType, v315);\nL_009F:\n\treturn v315;\n\tv152 = new System.NullReferenceException();\nL_00A1:\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow v182;\n\treturn returnVal2;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetActionTypeHashCode(Type actionType)
		{
			int stableHash = default(int);
			if (!ActionHashCodeLookup.TryGetValue(actionType, out var _))
			{
				FieldInfo[] fields = GetFields(actionType);
				int num = fields.Length;
				bool flag = fields.Length < 1;
				string s = "";
				if (!flag)
				{
					int num2 = 0;
					string text = "";
					bool flag2;
					do
					{
						if (num2 < num)
						{
							Type fieldType = fields[num2].FieldType;
							string text2 = string.Concat(text, fieldType, "|");
							num = fields.Length;
							num2++;
							flag2 = num2 < fields.Length;
							s = text2;
							text = text2;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (flag2);
				}
				stableHash = GetStableHash(s);
				ActionHashCodeLookup.set_Item(actionType, stableHash);
			}
			return stableHash;
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x9CAB64", Offset = "0x9CAB64", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.Text.Encoding::get_Unicode();\n\tv17 = System.Text.Encoding::GetBytes(v11, s);\n\tv90 = v17.Length << 0x20;\n\tv101 = v90 < 1;\n\tif (v101) goto L_FFFFFFFF;\nL_0023:\n\tv170 = v78 < v17.Length;\n\tv72 = ~v170;\n\tif (v72) goto L_0053;\n\tv169 = v78 + 1;\n\tv183 = v45 + v17[v78 @ X9_v10 (System.Int32)];\n\tv149 = v183 << 0xA;\n\tv184 = v183 + v149;\n\tv45 = v184 ^ v184;\n\tv152 = v169 < v17.Length;\n\tif (v152) goto L_0023;\n\tv172 = v45 << 3;\n\tv175 = v45 + v172;\n\tgoto L_0043;\nL_0043:\n\tv177 = v175 ^ v175;\n\tv108 = v177 << 0xF;\n\tv140 = v177 + v108;\n\tv180 = v140 * 0x55E63B89;\n\tv137 = v180 >> 0x39;\n\tv142 = v137 * 0x5F5E100;\n\treturnVal2 = v140 - v142;\n\treturn returnVal2;\nL_0053:\n\tv186 = new System.IndexOutOfRangeException();\n\tthrow v186;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetStableHash(string s)
		{
			Encoding unicode = Encoding.Unicode;
			byte[] bytes = unicode.GetBytes(s);
			int num = bytes.Length << 32;
			int num9;
			if (num >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				bool flag;
				do
				{
					if (num3 < bytes.Length)
					{
						int num4 = num3 + 1;
						int num5 = num2 + bytes[num3];
						int num6 = num5 << 10;
						int num7 = num5 + num6;
						num2 = num7 ^ num7;
						flag = num4 < bytes.Length;
						num3 = num4;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag);
				int num8 = num2 << 3;
				num9 = num2 + num8;
			}
			else
			{
				num9 = 0;
			}
			int num10 = num9 ^ num9;
			int num11 = num10 << 15;
			int num12 = num10 + num11;
			int num13 = num12 * 1441151881;
			int num14 = num13 >> 57;
			int num15 = num14 * 100000000;
			return num12 - num15;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x9CAC2C", Offset = "0x9CAC2C", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EEA6A0]);\n\tv35 = *([v34 @ X8_v41]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, state, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20219DD]) = v53;\nL_001E:\n\tv57 = new HutongGames.PlayMaker.ActionData+Context();\n\tSystem.Object::.ctor(v57);\n\tv57.currentState = state;\n\tv110 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv57.currentFsm = v110;\n\tv118 = this.actionNames;\n\t// 51 NewArr v111 @ X0_v15 (HutongGames.PlayMaker.FsmStateAction[]), typeof(HutongGames.PlayMaker.FsmStateAction[]), v118._size (System.Int32)\n\tv235 = System.Collections.Generic.List`1<System.Byte>::ToArray(this.byteData);\n\tthis.byteDataAsArray = v235;\n\tgoto L_0056;\n\tv283 = *([v237 @ X0_v18 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_0056;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v237, v234, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv287 = HutongGames.PlayMaker.ActionData;\nL_0056:\n\tv290.resaveActionData = 0;\n\tv301 = v118._size < 1;\n\tif (v301) goto L_0088;\nL_005F:\n\tv112 = HutongGames.PlayMaker.ActionData::CreateAction(this, v57, v104);\n\tv343 = v112 == 0;\n\tif (v343) goto L_0077;\n\t// 104 IsInst v187 @ X0_v40, typeof(HutongGames.PlayMaker.FsmStateAction), v112 @ X0_v36 (HutongGames.PlayMaker.FsmStateAction)\n\tv189 = v187 == 0;\n\tif (v189) goto L_00C5;\n\tv111[v104 @ X23_v9 (System.Int32)] = v112;\nL_0077:\n\tv104 = v104 + 1;\n\tv304 = v104 < v118._size;\n\tif (v304) goto L_005F;\nL_0088:\n\tgoto L_0091;\n\tv333 = *([v317 @ X0_v20 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv334 = v333 == 0;\n\tv335 = ~v334;\n\tgoto L_0091;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v317, v315, v305, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv337 = HutongGames.PlayMaker.ActionData;\nL_0091:\n\tv342 = ~v340.resaveActionData;\n\tif (v342) goto L_00C2;\n\tgoto L_00A3;\n\tv365 = *([1EB5CF0]);\n\tv366 = *([v365 @ X8_v31]);\n\tv367 = \"il2cpp_codegen_initialize_method\"(v366, v315, v305, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv369 = 0 | 1;\n\t*([2021A8E]) = v369;\nL_00A3:\n\tv374 = ~v373.<IsBuilding>k__BackingField;\n\tv351 = ~v374;\n\tif (v351) goto L_00C2;\n\tHutongGames.PlayMaker.ActionData::SaveActions(this, state, v111);\n\tv380 = HutongGames.PlayMaker.ActionData::LoadActions(this, state);\n\tv159 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv159.setDirty = 1;\nL_00C2:\n\treturn v353;\n\tv166 = new System.NullReferenceException();\nL_00C5:\n\tv193 = new System.ArrayTypeMismatchException();\n\tgoto L_00CA;\n\tv224 = new System.IndexOutOfRangeException();\nL_00CA:\n\tthrow v223;\n// 141 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmStateAction[] LoadActions(FsmState state)
		{
			Context context = new Context();
			context.currentState = state;
			Fsm fsm = state.Fsm;
			context.currentFsm = fsm;
			List<string> list = ActionNames;
			FsmStateAction[] array = new FsmStateAction[list.Count];
			byte[] array2 = byteData.ToArray();
			byteDataAsArray = array2;
			resaveActionData = false;
			if (list.Count >= 1)
			{
				int num = 0;
				ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
				do
				{
					FsmStateAction fsmStateAction = CreateAction(context, num);
					if (fsmStateAction != null)
					{
						object obj = fsmStateAction as FsmStateAction;
						if (obj == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex2;
						}
						array[num] = fsmStateAction;
					}
					num++;
				}
				while (num < list.Count);
			}
			bool flag = !resaveActionData;
			FsmStateAction[] result = array;
			if (!flag)
			{
				bool flag2 = !PlayMakerGlobals.IsBuilding;
				bool flag3 = !flag2;
				result = array;
				if (!flag3)
				{
					SaveActions(state, array);
					FsmStateAction[] array3 = LoadActions(state);
					Fsm fsm2 = state.Fsm;
					fsm2.setDirty = true;
					result = array3;
				}
			}
			return result;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x9CBA68", Offset = "0x9CBA68", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EDD7B8]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, state, actionIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219DE]) = v44;\nL_001A:\n\tv48 = new HutongGames.PlayMaker.ActionData+Context();\n\tSystem.Object::.ctor(v48);\n\tv48.currentState = state;\n\tv58 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv48.currentFsm = v58;\n\treturnVal2 = HutongGames.PlayMaker.ActionData::CreateAction(this, v48, actionIndex);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmStateAction CreateAction(FsmState state, int actionIndex)
		{
			Context context = new Context();
			context.currentState = state;
			Fsm fsm = state.Fsm;
			context.currentFsm = fsm;
			return CreateAction(context, actionIndex);
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x9CAE60", Offset = "0x9CAE60", Length = "0xB64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1EA59B8]);\n\tv39 = *([v38 @ X8_v149]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, context, actionIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20219DF]) = v56;\nL_0020:\n\tcontext.currentActionIndex = actionIndex;\n\tv310 = HutongGames.PlayMaker.FsmState::get_Fsm(context.currentState);\n\tv359 = v310 == 0;\n\tv360 = ~v359;\n\tif (v360) goto L_003A;\n\tgoto L_0039;\n\tv400 = *([v391 @ X0_v153+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_0039;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v391, v309, actionIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0039:\n\tUnityEngine.Debug::LogError(\"state.Fsm == null\");\nL_003A:\n\tv303 = this.actionNames;\n\tv408 = v303._size < actionIndex;\n\tv345 = ~v408;\n\tv343 = v303._size - actionIndex;\n\tv339 = v343 == 0;\n\tv409 = ~v339;\n\tv329 = v345 & v409;\n\tif (v329) goto L_004D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004D:\n\tv413 = v303._items;\n\tgoto L_005D;\n\tv419 = *([v415 @ X0_v13+E0]);\n\tv420 = v419 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_005D;\n\tv423 = \"il2cpp_codegen_runtime_class_init\"(v415, v243, actionIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_005D:\n\tv427 = HutongGames.PlayMaker.ActionData::GetActionType(v413[actionIndex @ X2 (System.Int32)]);\n\tv429 = v427 == 0;\n\tif (v429) goto L_0067;\n\tgoto L_0093;\nL_0067:\n\tgoto L_006E;\n\tv451 = *([v431 @ X0_v131+E0]);\n\tv452 = v451 == 0;\n\tv453 = ~v452;\n\tif (v453) goto L_006E;\n\tv455 = \"il2cpp_codegen_runtime_class_init\"(v431, v243, actionIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_006E:\n\tv459 = HutongGames.PlayMaker.ActionData::TryFixActionName(v413[actionIndex @ X2 (System.Int32)]);\n\tv461 = HutongGames.PlayMaker.ActionData::GetActionType(v459);\n\tv498 = v461 == 0;\n\tif (v498) goto L_013E;\n\tv518 = System.String::Concat(\"Action : \", v413[actionIndex @ X2 (System.Int32)], \" Updated To: \", v459);\n\tgoto L_008C;\n\tv544 = *([v529 @ X8_v135+E0]);\n\tv545 = v544 == 0;\n\tv546 = ~v545;\n\tif (v546) goto L_008C;\n\tv590 = v529;\n\tv549 = \"il2cpp_codegen_runtime_class_init\"(v590, v516, v436, v437, v435, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_008C:\n\tHutongGames.PlayMaker.ActionData::LogInfo(context, v518);\n\tv447.resaveActionData = 1;\nL_0093:\n\tv254 = System.Activator::CreateInstance(v99);\n\tv460 = v254 == 0;\n\tif (v460) goto L_00BF;\n\tgoto L_FFFFFFFF;\n\tv196 = v196_asT != 0;\n\tif (v196) goto L_016E;\nL_00BF:\n\tgoto L_00C7;\n\tv502 = *([v491 @ X0_v38+E0]);\n\tv503 = v502 == 0;\n\tv504 = ~v503;\n\tif (v504) goto L_00C7;\n\tv506 = \"il2cpp_codegen_runtime_class_init\"(v491, v244, v85, v91, v80, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00C7:\n\tv511 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.Actions.MissingAction);\n\tv528 = System.Activator::CreateInstance(v511);\n\tv543 = v528 == 0;\n\tif (v543) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv630 = v630_asT == 0;\n\tif (v630) goto L_026A;\nL_00EF:\n\tv762 = HutongGames.PlayMaker.FsmUtility::StripNamespace(v756);\n\t*([v1012 @ X20_v18 (System.Object)+50]) = v762;\n\tcontext.currentAction = v1012;\n\tv784 = System.String::Concat(\"Could Not Create Action: \", v762, \" (Maybe the script was removed?)\");\n\tgoto L_010A;\n\tv855 = *([v836 @ X8_v12+E0]);\n\tv856 = v855 == 0;\n\tv857 = ~v856;\n\tgoto L_010A;\n\tv865 = v836;\n\tv860 = \"il2cpp_codegen_runtime_class_init\"(v865, v780, v783, v781, v739, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_010A:\n\tHutongGames.PlayMaker.ActionData::LogError(context, v784);\n\tv868 = HutongGames.PlayMaker.FsmUtility::GetPath(context.currentState);\n\tv905 = System.String::Concat(\"Could Not Create Action: \", v868, v762, \" (Maybe the script was removed?)\");\n\tgoto L_0125;\n\tv932 = *([v919 @ X8_v16+E0]);\n\tv933 = v932 == 0;\n\tv934 = ~v933;\n\tif (v934) goto L_0125;\n\tv978 = v919;\n\tv937 = \"il2cpp_codegen_runtime_class_init\"(v978, v901, v902, v900, v904, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0125:\n\tUnityEngine.Debug::LogError(v905);\nL_0134:\n\treturn v1012;\nL_013E:\n\tgoto L_0146;\n\tv533 = *([v521 @ X0_v136+E0]);\n\tv534 = v533 == 0;\n\tv535 = ~v534;\n\tif (v535) goto L_0146;\n\tv537 = \"il2cpp_codegen_runtime_class_init\"(v521, v243, actionIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0146:\n\tv541 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.Actions.MissingAction);\n\tv350 = System.Activator::CreateInstance(v541);\n\tv352 = v350 == 0;\n\tif (v352) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv645 = v645_asT == 0;\n\tif (v645) goto L_026A;\n\tgoto L_00EF;\nL_016E:\n\tcontext.currentAction = v254;\n\tv289 = this.paramDataType;\n\tv105 = this.paramDataPos;\n\tv134 = v289._size != v105._size;\n\tif (v134) goto L_0197;\n\tv106 = this.paramName;\n\tv595 = v106._size != v289._size;\n\tif (v595) goto L_0197;\n\tgoto L_01A2;\nL_0197:\n\tgoto L_01A1;\n\tv684 = *([v613 @ X0_v111 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv685 = v684 == 0;\n\tv686 = ~v685;\n\tif (v686) goto L_01A1;\n\tv735 = \"il2cpp_codegen_runtime_class_init\"(v613, v244, v85, v91, v80, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv688 = HutongGames.PlayMaker.ActionData;\nL_01A1:\n\tv691.resaveActionData = 1;\nL_01A2:\n\tv68 = this.actionHashCodes;\n\tv764 = v68._size < actionIndex;\n\tv765 = ~v764;\n\tv766 = v68._size - actionIndex;\n\tv768 = v766 == 0;\n\tv774 = ~v768;\n\tv135 = v765 & v774;\n\tif (v135) goto L_01B6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01B6:\n\tv829 = v68._items;\n\tgoto L_01C6;\n\tv846 = *([v831 @ X0_v47+E0]);\n\tv847 = v846 == 0;\n\tv848 = ~v847;\n\tif (v848) goto L_01C6;\n\tv850 = \"il2cpp_codegen_runtime_class_init\"(v831, v244, v85, v91, v80, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_01C6:\n\tv854 = HutongGames.PlayMaker.ActionData::GetActionTypeHashCode(v99);\n\tv198 = v829[actionIndex @ X2 (System.Int32)] == v854;\n\tif (v198) goto L_0231;\n\tv871 = *([v254 @ X0_v35 (System.Object)]);\n\t*([v871 @ X8_v92 (Il2CppClass<System.Object>)+2F0])(v874, v254, *([v871 @ X8_v92 (Il2CppClass<System.Object>)+2F8]), v85, v93, v81, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_01E3;\n\tv906 = *([v875 @ X0_v89 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv907 = v906 == 0;\n\tv908 = ~v907;\n\tif (v908) goto L_01E3;\n\tv925 = \"il2cpp_codegen_runtime_class_init\"(v875, v245, v85, v91, v80, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv909 = HutongGames.PlayMaker.ActionData;\nL_01E3:\n\tv912.resaveActionData = 1;\n\tv291 = this.paramDataType;\n\tv107 = this.paramDataPos;\n\tv884 = v291._size != v107._size;\n\tif (v884) goto L_0202;\n\tv1031 = HutongGames.PlayMaker.ActionData::TryRecoverAction(this, context, v99, v254, actionIndex);\n\tgoto L_FFFFFFFF;\nL_0202:\n\tgoto L_020C;\n\tv1080 = *([v255 @ X0_v90 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv1081 = v1080 == 0;\n\tv1082 = ~v1081;\n\tif (v1082) goto L_020C;\n\tv1084 = \"il2cpp_codegen_runtime_class_init\"(v255, v245, v85, v91, v80, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_020C:\n\tHutongGames.PlayMaker.ActionData::LogError(context, \"Action has changed since FSM was saved. Could not recover parameters. Parameters reset to default values.\");\n\tv1124 = HutongGames.PlayMaker.FsmUtility::GetPath(context.currentState);\n\tv1135 = HutongGames.PlayMaker.FsmUtility::StripNamespace(v96);\n\tv1153 = System.String::Concat(\"Action script has changed since Fsm was saved: \", v1124, v1135, \". Parameters reset to default values...\");\n\tgoto L_022F;\n\tv1193 = *([v1121 @ X8_v108+E0]);\n\tv1194 = v1193 == 0;\n\tv1195 = ~v1194;\n\tif (v1195) goto L_022F;\n\tv1214 = v1121;\n\tv1197 = \"il2cpp_codegen_runtime_class_init\"(v1214, v1151, v1113, v1114, v1112, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_022F:\n\tUnityEngine.Debug::LogError(v1153);\nL_0231:\n\tv69 = this.actionStartIndex;\n\tv914 = v69._size < actionIndex;\n\tv816 = ~v914;\n\tv814 = v69._size - actionIndex;\n\tv810 = v814 == 0;\n\tv915 = ~v810;\n\tv800 = v816 & v915;\n\tif (v800) goto L_0243;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0243:\n\tv928 = v69._items;\n\tthis.nextParamIndex = v928[actionIndex @ X2 (System.Int32)];\n\tv931 = v573 == 0;\n\tif (v931) goto L_039B;\n\tgoto L_0256;\n\t\n// ... truncated")]
		public FsmStateAction CreateAction(Context context, int actionIndex)
		{
			//IL_01ed: Expected I4, but got O
			//IL_01f5: Expected I, but got O
			//IL_050d: Expected I, but got O
			//IL_06c6: Expected O, but got I
			//IL_070e: Expected O, but got I
			//IL_057e: Expected I, but got O
			//IL_0603: Expected I, but got O
			//IL_092e: Expected O, but got I
			//IL_0829: Expected I4, but got O
			//IL_0957: Expected I, but got O
			context.currentActionIndex = actionIndex;
			Fsm fsm = context.currentState.Fsm;
			if (fsm == null)
			{
				Debug.LogError("state.Fsm == null");
			}
			List<string> list = ActionNames;
			bool flag = list.Count < actionIndex;
			bool flag2 = !flag;
			int num = list.Count - actionIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			string[] items = list._items;
			Type actionType = GetActionType(items[actionIndex]);
			string text;
			Type type;
			string name;
			object obj2;
			string name2;
			IntPtr intPtr = default(IntPtr);
			if ((object)actionType != null)
			{
				int num2 = actionIndex;
				text = items[actionIndex];
				type = actionType;
			}
			else
			{
				string text2 = TryFixActionName(items[actionIndex]);
				Type actionType2 = GetActionType(text2);
				if ((object)actionType2 == null)
				{
					Type typeFromHandle = typeof(MissingAction);
					object obj = Activator.CreateInstance(typeFromHandle);
					if (obj != null)
					{
						MissingAction missingAction = obj as MissingAction;
						if (missingAction == null)
						{
							goto IL_072a;
						}
						name = items[actionIndex];
						obj2 = obj;
						goto IL_0b7d;
					}
					name2 = items[actionIndex];
					goto IL_0c6f;
				}
				string info = "Action : " + items[actionIndex] + " Updated To: " + text2;
				LogInfo(context, info);
				resaveActionData = true;
				int num3 = 0;
				int num2 = (int)" Updated To: ";
				intPtr = (IntPtr)text2;
				text = text2;
				type = actionType2;
			}
			object obj3 = Activator.CreateInstance(type);
			int num4;
			if (obj3 != null)
			{
				FsmStateAction fsmStateAction = obj3 as FsmStateAction;
				if (fsmStateAction != null)
				{
					context.currentAction = (FsmStateAction)obj3;
					List<ParamDataType> list2 = paramDataType;
					List<int> list3 = paramDataPos;
					if (list2.Count == list3.Count)
					{
						List<string> list4 = paramName;
						if (list4.Count == list2.Count)
						{
							num4 = 1;
							goto IL_0bb8;
						}
					}
					resaveActionData = true;
					num4 = 0;
					goto IL_0bb8;
				}
			}
			Type typeFromHandle2 = typeof(MissingAction);
			object obj4 = Activator.CreateInstance(typeFromHandle2);
			if (obj4 != null)
			{
				MissingAction missingAction2 = obj4 as MissingAction;
				if (missingAction2 == null)
				{
					goto IL_072a;
				}
				name = text;
				obj2 = obj4;
				goto IL_0b7d;
			}
			name2 = text;
			goto IL_0c6f;
			IL_072a:
			throw new InvalidCastException();
			IL_0b37:
			throw new NullReferenceException();
			IL_0315:
			return (FsmStateAction)obj2;
			IL_0b7d:
			string text3 = FsmUtility.StripNamespace(name);
			context.currentAction = (FsmStateAction)obj2;
			string error = "Could Not Create Action: " + text3 + " (Maybe the script was removed?)";
			LogError(context, error);
			string path = FsmUtility.GetPath(context.currentState);
			string message = "Could Not Create Action: " + path + text3 + " (Maybe the script was removed?)";
			Debug.LogError(message);
			goto IL_0315;
			IL_0c6f:
			string text4 = FsmUtility.StripNamespace(name2);
			goto IL_0b37;
			IL_0bb8:
			List<int> list5 = actionHashCodes;
			bool flag5 = list5.Count < actionIndex;
			bool flag6 = !flag5;
			int num5 = list5.Count - actionIndex;
			bool flag7 = num5 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items2 = list5._items;
			int actionTypeHashCode = GetActionTypeHashCode(type);
			bool flag9 = items2[actionIndex] == actionTypeHashCode;
			obj2 = obj3;
			if (!flag9)
			{
				IntPtr intPtr2 = (IntPtr)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v871 @ X8_v92 (Il2CppClass<System.Object>)+2F0] (should have been resolved before IL gen)");
				resaveActionData = true;
				List<ParamDataType> list6 = paramDataType;
				List<int> list7 = paramDataPos;
				if (list6.Count == list7.Count)
				{
					FsmStateAction fsmStateAction2 = TryRecoverAction(context, type, (FsmStateAction)obj3, actionIndex);
					int num3 = actionIndex;
					intPtr = (IntPtr)obj3;
					obj2 = fsmStateAction2;
				}
				else
				{
					LogError(context, "Action has changed since FSM was saved. Could not recover parameters. Parameters reset to default values.");
					string path2 = FsmUtility.GetPath(context.currentState);
					string text5 = FsmUtility.StripNamespace(text);
					string message2 = "Action script has changed since Fsm was saved: " + path2 + text5 + ". Parameters reset to default values...";
					Debug.LogError(message2);
					int num3 = 0;
					intPtr = (IntPtr)". Parameters reset to default values...";
					obj2 = obj3;
				}
				num4 = 0;
			}
			List<int> list8 = actionStartIndex;
			bool flag10 = list8.Count < actionIndex;
			bool flag11 = !flag10;
			int num6 = list8.Count - actionIndex;
			bool flag12 = num6 == 0;
			bool flag13 = !flag12;
			if (!(flag11 && flag13))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items3 = list8._items;
			nextParamIndex = items3[actionIndex];
			bool flag14 = num4 == 0;
			FieldInfo fieldInfo = (FieldInfo)(long)intPtr;
			if (!flag14)
			{
				FieldInfo[] fields = GetFields(type);
				int num7 = fields.Length;
				bool flag15 = fields.Length < 1;
				fieldInfo = (FieldInfo)(long)intPtr;
				if (!flag15)
				{
					int num8 = 0;
					bool flag16;
					do
					{
						if (num8 < num7)
						{
							if ((object)fields[num8] == null)
							{
								throw new NullReferenceException();
							}
							string name3 = fields[num8].Name;
							context.currentParameter = name3;
							int num3 = nextParamIndex;
							LoadActionField(context.currentFsm, obj2, fields[num8], nextParamIndex);
							int num9 = num8 + 1;
							int num10 = nextParamIndex + 1;
							nextParamIndex = num10;
							num7 = fields.Length;
							flag16 = num9 < fields.Length;
							num4 = (int)fields[num8];
							num8 = num9;
							fieldInfo = fields[num8];
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (flag16);
				}
			}
			List<string> list9 = customNames;
			bool flag17 = list9.Count < actionIndex;
			bool flag18 = !flag17;
			int num11 = list9.Count - actionIndex;
			bool flag19 = num11 == 0;
			if (list9.Count > actionIndex)
			{
				bool flag20 = !flag19;
				if (!(flag18 && flag20))
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items4 = list9._items;
				_ = items4[actionIndex];
				if (!PlayMakerGlobals.IsBuilding && !PlayMakerFSM.NotMainThread)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ X20_v18 (System.Object)+10]");
					if ((string)0 == "~AutoName")
					{
						IntPtr intPtr3 = (IntPtr)obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1223 @ X8_v76 (Il2CppClass<System.Object>)+3B0] (should have been resolved before IL gen)");
						_ = 1;
					}
				}
			}
			List<bool> list10 = actionEnabled;
			bool flag21 = list10.Count < actionIndex;
			bool flag22 = !flag21;
			int num12 = list10.Count - actionIndex;
			bool flag23 = num12 == 0;
			if (list10.Count > actionIndex)
			{
				bool flag24 = !flag23;
				if (!(flag22 && flag24))
				{
					throw new ArgumentOutOfRangeException();
				}
				bool[] items5 = list10._items;
				_ = items5[actionIndex];
			}
			List<bool> list11 = actionIsOpen;
			bool flag25 = list11.Count < actionIndex;
			bool flag26 = !flag25;
			int num13 = list11.Count - actionIndex;
			bool flag27 = num13 == 0;
			if (list11.Count > actionIndex)
			{
				bool flag28 = !flag27;
				if (!(flag26 && flag28))
				{
					throw new ArgumentOutOfRangeException();
				}
				bool[] items6 = list11._items;
				bool flag29 = obj2 == null;
				bool flag30 = !flag29;
				int num14 = (items6[actionIndex] ? 1 : 0);
				if (!flag30)
				{
					goto IL_0b37;
				}
			}
			else
			{
				int num14 = 1;
			}
			goto IL_0315;
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x9CC21C", Offset = "0x9CC21C", Length = "0x1400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1F05EF0]);\n\tv43 = *([v42 @ X8_v297]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, fsm, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([20219E0]) = v58;\nL_0025:\n\tv64 = System.Reflection.FieldInfo::get_FieldType(field);\n\tgoto L_0039;\n\tv552 = *([v69 @ X8_v13+E0]);\n\tv553 = v552 == 0;\n\tv554 = ~v553;\n\tif (v554) goto L_0039;\n\tv598 = v69;\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v598, v63, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0039:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmGameObject);\n\tv603 = v64 == v64;\n\tif (v603) goto L_03C5;\n\tgoto L_0053;\n\tv658 = *([v643 @ X0_v26+E0]);\n\tv659 = v658 == 0;\n\tv660 = ~v659;\n\tif (v660) goto L_0053;\n\tv662 = \"il2cpp_codegen_runtime_class_init\"(v643, v560, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0053:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEvent);\n\tv236 = v64 == v64;\n\tif (v236) goto L_03D4;\n\tgoto L_006D;\n\tv1318 = *([v1129 @ X0_v47+E0]);\n\tv1319 = v1318 == 0;\n\tv1320 = ~v1319;\n\tif (v1320) goto L_006D;\n\tv1322 = \"il2cpp_codegen_runtime_class_init\"(v1129, v384, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_006D:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmFloat);\n\tv851 = v64 == v64;\n\tif (v851) goto L_045D;\n\tgoto L_0087;\n\tv1436 = *([v1427 @ X0_v53+E0]);\n\tv1437 = v1436 == 0;\n\tv1438 = ~v1437;\n\tif (v1438) goto L_0087;\n\tv1440 = \"il2cpp_codegen_runtime_class_init\"(v1427, v1324, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0087:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmInt);\n\tv852 = v64 == v64;\n\tif (v852) goto L_0462;\n\tgoto L_00A1;\n\tv1482 = *([v1464 @ X0_v59+E0]);\n\tv1483 = v1482 == 0;\n\tv1484 = ~v1483;\n\tif (v1484) goto L_00A1;\n\tv1486 = \"il2cpp_codegen_runtime_class_init\"(v1464, v1442, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00A1:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmBool);\n\tv853 = v64 == v64;\n\tif (v853) goto L_0467;\n\tgoto L_00BB;\n\tv1509 = *([v1498 @ X0_v65+E0]);\n\tv1510 = v1509 == 0;\n\tv1511 = ~v1510;\n\tif (v1511) goto L_00BB;\n\tv1513 = \"il2cpp_codegen_runtime_class_init\"(v1498, v1488, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00BB:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector2);\n\tv854 = v64 == v64;\n\tif (v854) goto L_046C;\n\tgoto L_00D5;\n\tv1530 = *([v1525 @ X0_v71+E0]);\n\tv1531 = v1530 == 0;\n\tv1532 = ~v1531;\n\tif (v1532) goto L_00D5;\n\tv1534 = \"il2cpp_codegen_runtime_class_init\"(v1525, v1515, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00D5:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector3);\n\tv855 = v64 == v64;\n\tif (v855) goto L_0471;\n\tgoto L_00EF;\n\tv1545 = *([v1540 @ X0_v77+E0]);\n\tv1546 = v1545 == 0;\n\tv1547 = ~v1546;\n\tif (v1547) goto L_00EF;\n\tv1549 = \"il2cpp_codegen_runtime_class_init\"(v1540, v1536, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00EF:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmRect);\n\tv856 = v64 == v64;\n\tif (v856) goto L_0476;\n\tgoto L_0109;\n\tv1560 = *([v1555 @ X0_v83+E0]);\n\tv1561 = v1560 == 0;\n\tv1562 = ~v1561;\n\tif (v1562) goto L_0109;\n\tv1564 = \"il2cpp_codegen_runtime_class_init\"(v1555, v1551, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0109:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmQuaternion);\n\tv857 = v64 == v64;\n\tif (v857) goto L_047B;\n\tgoto L_0123;\n\tv1575 = *([v1570 @ X0_v89+E0]);\n\tv1576 = v1575 == 0;\n\tv1577 = ~v1576;\n\tif (v1577) goto L_0123;\n\tv1579 = \"il2cpp_codegen_runtime_class_init\"(v1570, v1566, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0123:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmColor);\n\tv858 = v64 == v64;\n\tif (v858) goto L_0480;\n\tgoto L_013D;\n\tv1590 = *([v1585 @ X0_v95+E0]);\n\tv1591 = v1590 == 0;\n\tv1592 = ~v1591;\n\tif (v1592) goto L_013D;\n\tv1594 = \"il2cpp_codegen_runtime_class_init\"(v1585, v1581, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_013D:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmObject);\n\tv859 = v64 == v64;\n\tif (v859) goto L_0485;\n\tgoto L_0157;\n\tv1605 = *([v1600 @ X0_v101+E0]);\n\tv1606 = v1605 == 0;\n\tv1607 = ~v1606;\n\tif (v1607) goto L_0157;\n\tv1609 = \"il2cpp_codegen_runtime_class_init\"(v1600, v1596, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0157:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmMaterial);\n\tv860 = v64 == v64;\n\tif (v860) goto L_048A;\n\tgoto L_0171;\n\tv1620 = *([v1615 @ X0_v107+E0]);\n\tv1621 = v1620 == 0;\n\tv1622 = ~v1621;\n\tif (v1622) goto L_0171;\n\tv1624 = \"il2cpp_codegen_runtime_class_init\"(v1615, v1611, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0171:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTexture);\n\tv861 = v64 == v64;\n\tif (v861) goto L_048F;\n\tgoto L_018B;\n\tv1635 = *([v1630 @ X0_v113+E0]);\n\tv1636 = v1635 == 0;\n\tv1637 = ~v1636;\n\tif (v1637) goto L_018B;\n\tv1639 = \"il2cpp_codegen_runtime_class_init\"(v1630, v1626, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_018B:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FunctionCall);\n\tv862 = v64 == v64;\n\tif (v862) goto L_0494;\n\tgoto L_01A5;\n\tv1650 = *([v1645 @ X0_v119+E0]);\n\tv1651 = v1650 == 0;\n\tv1652 = ~v1651;\n\tif (v1652) goto L_01A5;\n\tv1654 = \"il2cpp_codegen_runtime_class_init\"(v1645, v1641, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01A5:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTemplateControl);\n\tv863 = v64 == v64;\n\tif (v863) goto L_0499;\n\tgoto L_01BF;\n\tv1665 = *([v1660 @ X0_v125+E0]);\n\tv1666 = v1665 == 0;\n\tv1667 = ~v1666;\n\tif (v1667) goto L_01BF;\n\tv1669 = \"il2cpp_codegen_runtime_class_init\"(v1660, v1656, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01BF:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVar);\n\tv864 = v64 == v64;\n\tif (v864) goto L_049E;\n\tgoto L_01D9;\n\tv1680 = *([v1675 @ X0_v131+E0]);\n\tv1681 = v1680 == 0;\n\tv1682 = ~v1681;\n\tif (v1682) goto L_01D9;\n\tv1684 = \"il2cpp_codegen_runtime_class_init\"(v1675, v1671, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01D9:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEnum);\n\tv865 = v64 == v64;\n\tif (v865) goto L_04A3;\n\tgoto L_01F3;\n\tv1695 = *([v1690 @ X0_v137+E0]);\n\tv1696 = v1695 == 0;\n\tv1697 = ~v1696;\n\tif (v1697) goto L_01F3;\n\tv1699 = \"il2cpp_codegen_runtime_class_init\"(v1690, v1686, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01F3:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmArray);\n\tv866 = v64 == v64;\n\tif (v866) goto L_04A8;\n\tgoto L_020D;\n\tv1710 = *([v1705 @ X0_v143+E0]);\n\tv1711 = v1710 == 0;\n\tv1712 = ~v1711;\n\tif (v1712) goto L_020D;\n\tv1714 = \"il2cpp_codegen_runtime_class_init\"(v1705, v1701, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_020D:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmProperty);\n\tv867 = v64 == v64;\n\tif (v867) goto L_04AD;\n\tgoto L_0227;\n\tv1725 = *([v1720 @ X0_v149+E0]);\n\tv1726 = v1725 == 0;\n\tv1727 = ~v1726;\n\tif (v1727) goto L_0227;\n\tv1729 = \"il2cpp_codegen_runtime_class_init\"(v1720, v1716, obj, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0227:\n\tv64 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEventTarget);\n\tv868 = v64 == v64;\n\tif (v868) goto L_04B2;\n\tgoto L_0241;\n\tv1740 = *([v1735 @ X0_v155+E0]);\n\tv1741 = v1740 == 0;\n\tv1742 = ~v1741;\n\tif (v1742) goto L_0241;\n\tv1744 = \"il2cpp_codegen_runtime_class_init\"(v1735, v1731, obj, field, paramIndex, me\n// ... truncated")]
		private void LoadActionField(Fsm fsm, object obj, FieldInfo field, int paramIndex)
		{
			//IL_0f09: Expected O, but got I4
			//IL_241d: Expected O, but got F4
			//IL_0fd5: Expected O, but got I4
			//IL_242a: Expected O, but got I4
			//IL_10a1: Expected O, but got I4
			//IL_1194: Expected O, but got I4
			//IL_128d: Expected O, but got I4
			//IL_1385: Expected O, but got I4
			//IL_1480: Expected O, but got I4
			//IL_157b: Expected O, but got I4
			Type fieldType = field.FieldType;
			fieldType = typeof(FsmGameObject);
			FsmAnimationCurve value;
			FsmObject value2;
			object obj2;
			FieldInfo fieldInfo;
			FsmAnimationCurve fsmAnimationCurve2 = default(FsmAnimationCurve);
			Color color;
			Color color2;
			object typeFromHandle;
			float num28;
			object typeFromHandle2;
			float x;
			object obj6;
			if ((object)fieldType != fieldType)
			{
				fieldType = typeof(FsmEvent);
				if ((object)fieldType != fieldType)
				{
					fieldType = typeof(FsmFloat);
					if ((object)fieldType != fieldType)
					{
						fieldType = typeof(FsmInt);
						if ((object)fieldType != fieldType)
						{
							fieldType = typeof(FsmBool);
							if ((object)fieldType != fieldType)
							{
								fieldType = typeof(FsmVector2);
								if ((object)fieldType != fieldType)
								{
									fieldType = typeof(FsmVector3);
									if ((object)fieldType != fieldType)
									{
										fieldType = typeof(FsmRect);
										if ((object)fieldType != fieldType)
										{
											fieldType = typeof(FsmQuaternion);
											if ((object)fieldType != fieldType)
											{
												fieldType = typeof(FsmColor);
												if ((object)fieldType != fieldType)
												{
													fieldType = typeof(FsmObject);
													if ((object)fieldType != fieldType)
													{
														fieldType = typeof(FsmMaterial);
														if ((object)fieldType != fieldType)
														{
															fieldType = typeof(FsmTexture);
															if ((object)fieldType != fieldType)
															{
																fieldType = typeof(FunctionCall);
																if ((object)fieldType != fieldType)
																{
																	fieldType = typeof(FsmTemplateControl);
																	if ((object)fieldType != fieldType)
																	{
																		fieldType = typeof(FsmVar);
																		if ((object)fieldType != fieldType)
																		{
																			fieldType = typeof(FsmEnum);
																			if ((object)fieldType != fieldType)
																			{
																				fieldType = typeof(FsmArray);
																				if ((object)fieldType != fieldType)
																				{
																					fieldType = typeof(FsmProperty);
																					if ((object)fieldType != fieldType)
																					{
																						fieldType = typeof(FsmEventTarget);
																						if ((object)fieldType != fieldType)
																						{
																							fieldType = typeof(LayoutOption);
																							if ((object)fieldType != fieldType)
																							{
																								fieldType = typeof(FsmOwnerDefault);
																								if ((object)fieldType != fieldType)
																								{
																									fieldType = typeof(FsmAnimationCurve);
																									if ((object)fieldType == fieldType)
																									{
																										List<int> list = paramDataPos;
																										List<FsmAnimationCurve> list2 = animationCurveParams;
																										bool flag = list.Count < paramIndex;
																										bool flag2 = !flag;
																										int num = list.Count - paramIndex;
																										bool flag3 = num == 0;
																										bool flag4 = !flag3;
																										if (!(flag2 && flag4))
																										{
																											throw new ArgumentOutOfRangeException();
																										}
																										int[] items = list._items;
																										bool flag5 = list2.Count < items[paramIndex];
																										bool flag6 = !flag5;
																										int num2 = list2.Count - items[paramIndex];
																										bool flag7 = num2 == 0;
																										bool flag8 = !flag7;
																										if (!(flag6 && flag8))
																										{
																											throw new ArgumentOutOfRangeException();
																										}
																										FsmAnimationCurve[] items2 = list2._items;
																										bool flag9 = items2[items[paramIndex]] == null;
																										bool flag10 = !flag9;
																										value = items2[items[paramIndex]];
																										if (!flag10)
																										{
																											FsmAnimationCurve fsmAnimationCurve = new FsmAnimationCurve();
																											value = fsmAnimationCurve;
																										}
																										goto IL_23ff;
																									}
																									fieldType = typeof(FsmString);
																									if ((object)fieldType != fieldType)
																									{
																										fieldType = typeof(float);
																										object obj5;
																										if ((object)fieldType != fieldType)
																										{
																											fieldType = typeof(int);
																											int num32;
																											object typeFromHandle3;
																											if ((object)fieldType != fieldType)
																											{
																												fieldType = typeof(bool);
																												if ((object)fieldType != fieldType)
																												{
																													fieldType = typeof(Color);
																													float y;
																													float width;
																													float height;
																													if ((object)fieldType != fieldType)
																													{
																														fieldType = typeof(Vector2);
																														if ((object)fieldType != fieldType)
																														{
																															fieldType = typeof(Vector3);
																															if ((object)fieldType != fieldType)
																															{
																																fieldType = typeof(Vector4);
																																if ((object)fieldType != fieldType)
																																{
																																	fieldType = typeof(Rect);
																																	if ((object)fieldType != fieldType)
																																	{
																																		fieldType = typeof(string);
																																		if ((object)fieldType != fieldType)
																																		{
																																			if (!fieldType.IsEnum)
																																			{
																																				fieldType = typeof(FsmObject);
																																				if (fieldType.IsAssignableFrom(fieldType))
																																				{
																																					List<int> list3 = paramDataPos;
																																					List<FsmObject> list4 = fsmObjectParams;
																																					bool flag11 = list3.Count < paramIndex;
																																					bool flag12 = !flag11;
																																					int num3 = list3.Count - paramIndex;
																																					bool flag13 = num3 == 0;
																																					bool flag14 = !flag13;
																																					if (!(flag12 && flag14))
																																					{
																																						throw new ArgumentOutOfRangeException();
																																					}
																																					int[] items3 = list3._items;
																																					bool flag15 = list4.Count < items3[paramIndex];
																																					bool flag16 = !flag15;
																																					int num4 = list4.Count - items3[paramIndex];
																																					bool flag17 = num4 == 0;
																																					bool flag18 = !flag17;
																																					if (!(flag16 && flag18))
																																					{
																																						throw new ArgumentOutOfRangeException();
																																					}
																																					FsmObject[] items4 = list4._items;
																																					if (items4[items3[paramIndex]] == null)
																																					{
																																						value = null;
																																						goto IL_23ff;
																																					}
																																					value2 = items4[items3[paramIndex]];
																																					obj2 = obj;
																																					fieldInfo = field;
																																				}
																																				else
																																				{
																																					fieldType = typeof(UnityEngine.Object);
																																					if (fieldType.IsAssignableFrom(fieldType))
																																					{
																																						List<int> list5 = paramDataPos;
																																						List<UnityEngine.Object> list6 = unityObjectParams;
																																						bool flag19 = list5.Count < paramIndex;
																																						bool flag20 = !flag19;
																																						int num5 = list5.Count - paramIndex;
																																						bool flag21 = num5 == 0;
																																						bool flag22 = !flag21;
																																						if (!(flag20 && flag22))
																																						{
																																							throw new ArgumentOutOfRangeException();
																																						}
																																						int[] items5 = list5._items;
																																						bool flag23 = list6.Count < items5[paramIndex];
																																						bool flag24 = !flag23;
																																						int num6 = list6.Count - items5[paramIndex];
																																						bool flag25 = num6 == 0;
																																						bool flag26 = !flag25;
																																						if (!(flag24 && flag26))
																																						{
																																							throw new ArgumentOutOfRangeException();
																																						}
																																						UnityEngine.Object[] items6 = list6._items;
																																						bool flag27 = (object)items6[items5[paramIndex]] == null;
																																						value = (FsmAnimationCurve)(object)items6[items5[paramIndex]];
																																						if (flag27)
																																						{
																																							goto IL_23ff;
																																						}
																																						fieldType = items6[items5[paramIndex]].GetType();
																																						fieldType = typeof(UnityEngine.Object);
																																						if ((object)fieldType == fieldType)
																																						{
																																							return;
																																						}
																																						value2 = items6[items5[paramIndex]];
																																						obj2 = obj;
																																						fieldInfo = field;
																																					}
																																					else
																																					{
																																						FsmObject fsmObject;
																																						if (fieldType.IsArray)
																																						{
																																							List<int> list7 = paramDataPos;
																																							List<string> list8 = arrayParamTypes;
																																							bool flag28 = list7.Count < paramIndex;
																																							bool flag29 = !flag28;
																																							int num7 = list7.Count - paramIndex;
																																							bool flag30 = num7 == 0;
																																							bool flag31 = !flag30;
																																							if (!(flag29 && flag31))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items7 = list7._items;
																																							bool flag32 = list8.Count < items7[paramIndex];
																																							bool flag33 = !flag32;
																																							int num8 = list8.Count - items7[paramIndex];
																																							bool flag34 = num8 == 0;
																																							bool flag35 = !flag34;
																																							if (!(flag33 && flag35))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							string[] items8 = list8._items;
																																							fieldType = ReflectionUtils.GetGlobalType(items8[items7[paramIndex]]);
																																							List<int> list9 = paramDataPos;
																																							List<int> list10 = arrayParamSizes;
																																							bool flag36 = list9.Count < paramIndex;
																																							bool flag37 = !flag36;
																																							int num9 = list9.Count - paramIndex;
																																							bool flag38 = num9 == 0;
																																							bool flag39 = !flag38;
																																							if (!(flag37 && flag39))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items9 = list9._items;
																																							bool flag40 = list10.Count < items9[paramIndex];
																																							bool flag41 = !flag40;
																																							int num10 = list10.Count - items9[paramIndex];
																																							bool flag42 = num10 == 0;
																																							bool flag43 = !flag42;
																																							if (!(flag41 && flag43))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items10 = list10._items;
																																							Array array = Array.CreateInstance(fieldType, items10[items9[paramIndex]]);
																																							bool flag44 = items10[items9[paramIndex]] < 1;
																																							fsmObject = (FsmObject)(object)array;
																																							if (!flag44)
																																							{
																																								int num11 = 0;
																																								do
																																								{
																																									LoadArrayElement(fsm, array, fieldType, num11, ++nextParamIndex);
																																									num11++;
																																								}
																																								while (items10[items9[paramIndex]] != num11);
																																								fsmObject = (FsmObject)(object)array;
																																							}
																																						}
																																						else
																																						{
																																							if (!fieldType.IsClass)
																																							{
																																								Type type = default(Type);
																																								string message = "ActionData: Missing LoadActionField for type: " + type;
																																								Debug.LogError(message);
																																								value2 = null;
																																								obj2 = obj;
																																								fieldInfo = field;
																																								goto IL_24e5;
																																							}
																																							List<int> list11 = paramDataPos;
																																							List<string> list12 = customTypeNames;
																																							bool flag45 = list11.Count < paramIndex;
																																							bool flag46 = !flag45;
																																							int num12 = list11.Count - paramIndex;
																																							bool flag47 = num12 == 0;
																																							bool flag48 = !flag47;
																																							if (!(flag46 && flag48))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items11 = list11._items;
																																							bool flag49 = list12.Count < items11[paramIndex];
																																							bool flag50 = !flag49;
																																							int num13 = list12.Count - items11[paramIndex];
																																							bool flag51 = num13 == 0;
																																							bool flag52 = !flag51;
																																							if (!(flag50 && flag52))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							string[] items12 = list12._items;
																																							fieldType = ReflectionUtils.GetGlobalType(items12[items11[paramIndex]]);
																																							object obj3 = Activator.CreateInstance(fieldType);
																																							List<int> list13 = paramDataPos;
																																							List<int> list14 = customTypeSizes;
																																							bool flag53 = list13.Count < paramIndex;
																																							bool flag54 = !flag53;
																																							int num14 = list13.Count - paramIndex;
																																							bool flag55 = num14 == 0;
																																							bool flag56 = !flag55;
																																							if (!(flag54 && flag56))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items13 = list13._items;
																																							bool flag57 = list14.Count < items13[paramIndex];
																																							bool flag58 = !flag57;
																																							int num15 = list14.Count - items13[paramIndex];
																																							bool flag59 = num15 == 0;
																																							bool flag60 = !flag59;
																																							if (!(flag58 && flag60))
																																							{
																																								throw new ArgumentOutOfRangeException();
																																							}
																																							int[] items14 = list14._items;
																																							bool flag61 = items14[items13[paramIndex]] < 1;
																																							fsmObject = (FsmObject)obj3;
																																							if (!flag61)
																																							{
																																								int num16 = 0;
																																								bool flag66;
																																								do
																																								{
																																									List<string> list15 = paramName;
																																									int num17 = ++nextParamIndex;
																																									bool flag62 = list15.Count < num17;
																																									bool flag63 = !flag62;
																																									int num18 = list15.Count - num17;
																																									bool flag64 = num18 == 0;
																																									bool flag65 = !flag64;
																																									if (!(flag63 && flag65))
																																									{
																																										throw new ArgumentOutOfRangeException();
																																									}
																																									string[] items15 = list15._items;
																																									FieldInfo field2 = fieldType.GetField(items15[num17]);
																																									if ((object)field2 != null)
																																									{
																																										LoadActionField(fsm, obj3, field2, nextParamIndex);
																																									}
																																									num16++;
																																									flag66 = num16 < items14[items13[paramIndex]];
																																									fsmObject = (FsmObject)obj3;
																																								}
																																								while (flag66);
																																							}
																																						}
																																						value2 = fsmObject;
																																						obj2 = obj;
																																						fieldInfo = field;
																																					}
																																				}
																																				goto IL_24e5;
																																			}
																																			List<int> list16 = paramDataPos;
																																			bool flag67 = list16.Count < paramIndex;
																																			bool flag68 = !flag67;
																																			int num19 = list16.Count - paramIndex;
																																			bool flag69 = num19 == 0;
																																			bool flag70 = !flag69;
																																			if (!(flag68 && flag70))
																																			{
																																				throw new ArgumentOutOfRangeException();
																																			}
																																			int[] items16 = list16._items;
																																			int num20 = FsmUtility.BitConverter.ToInt32(byteDataAsArray, items16[paramIndex]);
																																			object value3 = num20;
																																			object obj4 = Enum.ToObject(fieldType, value3);
																																			fsmAnimationCurve2 = (FsmAnimationCurve)obj4;
																																		}
																																		else
																																		{
																																			if (fsm.DataVersion >= 2)
																																			{
																																				List<string> list17 = stringParams;
																																				if (stringParams != null)
																																				{
																																					int count = list17.Count;
																																					if (list17.Count >= 1)
																																					{
																																						List<int> list18 = paramDataPos;
																																						bool flag71 = list18.Count < paramIndex;
																																						bool flag72 = !flag71;
																																						int num21 = list18.Count - paramIndex;
																																						bool flag73 = num21 == 0;
																																						bool flag74 = !flag73;
																																						if (!(flag72 && flag74))
																																						{
																																							throw new ArgumentOutOfRangeException();
																																						}
																																						int[] items17 = list18._items;
																																						bool flag75 = count < items17[paramIndex];
																																						bool flag76 = !flag75;
																																						int num22 = count - items17[paramIndex];
																																						bool flag77 = num22 == 0;
																																						bool flag78 = !flag77;
																																						if (!(flag76 && flag78))
																																						{
																																							throw new ArgumentOutOfRangeException();
																																						}
																																						string[] items18 = list17._items;
																																						value = (FsmAnimationCurve)(object)items18[items17[paramIndex]];
																																						goto IL_23ff;
																																					}
																																				}
																																			}
																																			List<int> list19 = paramDataPos;
																																			bool flag79 = list19.Count < paramIndex;
																																			bool flag80 = !flag79;
																																			int num23 = list19.Count - paramIndex;
																																			bool flag81 = num23 == 0;
																																			bool flag82 = !flag81;
																																			if (!(flag80 && flag82))
																																			{
																																				throw new ArgumentOutOfRangeException();
																																			}
																																			List<int> list20 = paramByteDataSize;
																																			int[] items19 = list19._items;
																																			bool flag83 = list20.Count < paramIndex;
																																			bool flag84 = !flag83;
																																			int num24 = list20.Count - paramIndex;
																																			bool flag85 = num24 == 0;
																																			bool flag86 = !flag85;
																																			if (!(flag84 && flag86))
																																			{
																																				throw new ArgumentOutOfRangeException();
																																			}
																																			int[] items20 = list20._items;
																																			string text = FsmUtility.ByteArrayToString(byteDataAsArray, items19[paramIndex], items20[paramIndex]);
																																			fsmAnimationCurve2 = (FsmAnimationCurve)(object)text;
																																		}
																																		goto IL_11a7;
																																	}
																																	List<int> list21 = paramDataPos;
																																	bool flag87 = list21.Count < paramIndex;
																																	bool flag88 = !flag87;
																																	int num25 = list21.Count - paramIndex;
																																	bool flag89 = num25 == 0;
																																	bool flag90 = !flag89;
																																	if (!(flag88 && flag90))
																																	{
																																		throw new ArgumentOutOfRangeException();
																																	}
																																	int[] items21 = list21._items;
																																	Rect rect = FsmUtility.ByteArrayToRect(byteDataAsArray, items21[paramIndex]);
																																	y = rect.y;
																																	width = rect.width;
																																	height = rect.height;
																																	color = (Color)rect;
																																	color2 = (Color)rect;
																																	obj5 = 0;
																																	typeFromHandle = typeof(Rect);
																																}
																																else
																																{
																																	List<int> list22 = paramDataPos;
																																	bool flag91 = list22.Count < paramIndex;
																																	bool flag92 = !flag91;
																																	int num26 = list22.Count - paramIndex;
																																	bool flag93 = num26 == 0;
																																	bool flag94 = !flag93;
																																	if (!(flag92 && flag94))
																																	{
																																		throw new ArgumentOutOfRangeException();
																																	}
																																	int[] items22 = list22._items;
																																	Vector4 vector = FsmUtility.ByteArrayToVector4(byteDataAsArray, items22[paramIndex]);
																																	y = vector.y;
																																	width = vector.z;
																																	height = vector.w;
																																	color = vector;
																																	color2 = vector;
																																	obj5 = 0;
																																	typeFromHandle = typeof(Vector4);
																																}
																																goto IL_2444;
																															}
																															List<int> list23 = paramDataPos;
																															bool flag95 = list23.Count < paramIndex;
																															bool flag96 = !flag95;
																															int num27 = list23.Count - paramIndex;
																															bool flag97 = num27 == 0;
																															bool flag98 = !flag97;
																															if (!(flag96 && flag98))
																															{
																																throw new ArgumentOutOfRangeException();
																															}
																															int[] items23 = list23._items;
																															Vector3 vector2 = FsmUtility.ByteArrayToVector3(byteDataAsArray, items23[paramIndex]);
																															y = vector2.y;
																															width = vector2.z;
																															x = vector2.x;
																															num28 = vector2.x;
																															obj5 = 0;
																															typeFromHandle2 = typeof(Vector3);
																														}
																														else
																														{
																															List<int> list24 = paramDataPos;
																															bool flag99 = list24.Count < paramIndex;
																															bool flag100 = !flag99;
																															int num29 = list24.Count - paramIndex;
																															bool flag101 = num29 == 0;
																															bool flag102 = !flag101;
																															if (!(flag100 && flag102))
																															{
																																throw new ArgumentOutOfRangeException();
																															}
																															int[] items24 = list24._items;
																															Vector2 vector3 = FsmUtility.ByteArrayToVector2(byteDataAsArray, items24[paramIndex]);
																															y = vector3.y;
																															x = vector3.x;
																															num28 = vector3.x;
																															obj5 = 0;
																															typeFromHandle2 = typeof(Vector2);
																														}
																														goto IL_2437;
																													}
																													List<int> list25 = paramDataPos;
																													bool flag103 = list25.Count < paramIndex;
																													bool flag104 = !flag103;
																													int num30 = list25.Count - paramIndex;
																													bool flag105 = num30 == 0;
																													bool flag106 = !flag105;
																													if (!(flag104 && flag106))
																													{
																														throw new ArgumentOutOfRangeException();
																													}
																													int[] items25 = list25._items;
																													color = FsmUtility.ByteArrayToColor(byteDataAsArray, items25[paramIndex]);
																													y = color.g;
																													width = color.b;
																													height = color.a;
																													color2 = color;
																													obj5 = 0;
																													typeFromHandle = typeof(Color);
																													goto IL_2444;
																												}
																												List<int> list26 = paramDataPos;
																												bool flag107 = list26.Count < paramIndex;
																												bool flag108 = !flag107;
																												int num31 = list26.Count - paramIndex;
																												bool flag109 = num31 == 0;
																												bool flag110 = !flag109;
																												if (!(flag108 && flag110))
																												{
																													throw new ArgumentOutOfRangeException();
																												}
																												int[] items26 = list26._items;
																												bool flag111 = FsmUtility.BitConverter.ToBoolean(byteDataAsArray, items26[paramIndex]);
																												num32 = (flag111 ? 1 : 0);
																												obj5 = 0;
																												typeFromHandle3 = typeof(bool);
																											}
																											else
																											{
																												List<int> list27 = paramDataPos;
																												bool flag112 = list27.Count < paramIndex;
																												bool flag113 = !flag112;
																												int num33 = list27.Count - paramIndex;
																												bool flag114 = num33 == 0;
																												bool flag115 = !flag114;
																												if (!(flag113 && flag115))
																												{
																													throw new ArgumentOutOfRangeException();
																												}
																												int[] items27 = list27._items;
																												int num34 = FsmUtility.BitConverter.ToInt32(byteDataAsArray, items27[paramIndex]);
																												num32 = num34;
																												obj5 = 0;
																												typeFromHandle3 = typeof(int);
																											}
																											obj6 = num32;
																											fieldType = (Type)typeFromHandle3;
																											goto IL_2593;
																										}
																										List<int> list28 = paramDataPos;
																										bool flag116 = list28.Count < paramIndex;
																										bool flag117 = !flag116;
																										int num35 = list28.Count - paramIndex;
																										bool flag118 = num35 == 0;
																										bool flag119 = !flag118;
																										if (!(flag117 && flag119))
																										{
																											throw new ArgumentOutOfRangeException();
																										}
																										int[] items28 = list28._items;
																										x = FsmUtility.BitConverter.ToSingle(byteDataAsArray, items28[paramIndex]);
																										num28 = x;
																										obj5 = 0;
																										typeFromHandle2 = typeof(float);
																										goto IL_2437;
																									}
																									FsmString fsmString = GetFsmString(fsm, paramIndex);
																									fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmString;
																								}
																								else
																								{
																									FsmOwnerDefault fsmOwnerDefault = GetFsmOwnerDefault(fsm, paramIndex);
																									fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmOwnerDefault;
																								}
																							}
																							else
																							{
																								LayoutOption layoutOption = GetLayoutOption(fsm, paramIndex);
																								fsmAnimationCurve2 = (FsmAnimationCurve)(object)layoutOption;
																							}
																						}
																						else
																						{
																							FsmEventTarget fsmEventTarget = GetFsmEventTarget(fsm, paramIndex);
																							fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmEventTarget;
																						}
																					}
																					else
																					{
																						FsmProperty fsmProperty = GetFsmProperty(fsm, paramIndex);
																						fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmProperty;
																					}
																				}
																				else
																				{
																					FsmArray fsmArray = GetFsmArray(fsm, paramIndex);
																					fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmArray;
																				}
																			}
																			else
																			{
																				FsmEnum fsmEnum = GetFsmEnum(fsm, paramIndex);
																				fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmEnum;
																			}
																		}
																		else
																		{
																			FsmVar fsmVar = GetFsmVar(fsm, paramIndex);
																			fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmVar;
																		}
																	}
																	else
																	{
																		FsmTemplateControl fsmTemplateControl = GetFsmTemplateControl(fsm, paramIndex);
																		fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmTemplateControl;
																	}
																}
																else
																{
																	FunctionCall functionCall = GetFunctionCall(fsm, paramIndex);
																	fsmAnimationCurve2 = (FsmAnimationCurve)(object)functionCall;
																}
															}
															else
															{
																FsmTexture fsmTexture = GetFsmTexture(fsm, paramIndex);
																fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmTexture;
															}
														}
														else
														{
															FsmMaterial fsmMaterial = GetFsmMaterial(fsm, paramIndex);
															fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmMaterial;
														}
													}
													else
													{
														FsmObject fsmObject2 = GetFsmObject(fsm, paramIndex);
														fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmObject2;
													}
												}
												else
												{
													FsmColor fsmColor = GetFsmColor(fsm, paramIndex);
													fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmColor;
												}
											}
											else
											{
												FsmQuaternion fsmQuaternion = GetFsmQuaternion(fsm, paramIndex);
												fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmQuaternion;
											}
										}
										else
										{
											FsmRect fsmRect = GetFsmRect(fsm, paramIndex);
											fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmRect;
										}
									}
									else
									{
										FsmVector3 fsmVector = GetFsmVector3(fsm, paramIndex);
										fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmVector;
									}
								}
								else
								{
									FsmVector2 fsmVector2 = GetFsmVector2(fsm, paramIndex);
									fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmVector2;
								}
							}
							else
							{
								FsmBool fsmBool = GetFsmBool(fsm, paramIndex);
								fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmBool;
							}
						}
						else
						{
							FsmInt fsmInt = GetFsmInt(fsm, paramIndex);
							fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmInt;
						}
					}
					else
					{
						FsmFloat fsmFloat = GetFsmFloat(fsm, paramIndex);
						fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmFloat;
					}
				}
				else
				{
					if (fsm.DataVersion >= 2)
					{
						List<string> list29 = stringParams;
						if (stringParams != null)
						{
							int count2 = list29.Count;
							if (list29.Count >= 1)
							{
								List<int> list30 = paramDataPos;
								bool flag120 = list30.Count < paramIndex;
								bool flag121 = !flag120;
								int num36 = list30.Count - paramIndex;
								bool flag122 = num36 == 0;
								bool flag123 = !flag122;
								if (!(flag121 && flag123))
								{
									throw new ArgumentOutOfRangeException();
								}
								int[] items29 = list30._items;
								bool flag124 = count2 < items29[paramIndex];
								bool flag125 = !flag124;
								int num37 = count2 - items29[paramIndex];
								bool flag126 = num37 == 0;
								bool flag127 = !flag126;
								if (!(flag125 && flag127))
								{
									throw new ArgumentOutOfRangeException();
								}
								string[] items30 = list29._items;
								bool flag128 = string.IsNullOrEmpty(items30[items29[paramIndex]]);
								bool flag129 = !flag128;
								bool flag130 = !flag129;
								value = null;
								if (!flag130)
								{
									FsmEvent fsmEvent = FsmEvent.GetFsmEvent(items30[items29[paramIndex]]);
									fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmEvent;
									goto IL_11a7;
								}
								goto IL_23ff;
							}
						}
					}
					List<int> list31 = paramDataPos;
					bool flag131 = list31.Count < paramIndex;
					bool flag132 = !flag131;
					int num38 = list31.Count - paramIndex;
					bool flag133 = num38 == 0;
					bool flag134 = !flag133;
					if (!(flag132 && flag134))
					{
						throw new ArgumentOutOfRangeException();
					}
					List<int> list32 = paramByteDataSize;
					int[] items31 = list31._items;
					bool flag135 = list32.Count < paramIndex;
					bool flag136 = !flag135;
					int num39 = list32.Count - paramIndex;
					bool flag137 = num39 == 0;
					bool flag138 = !flag137;
					if (!(flag136 && flag138))
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items32 = list32._items;
					FsmEvent fsmEvent2 = FsmUtility.ByteArrayToFsmEvent(byteDataAsArray, items31[paramIndex], items32[paramIndex]);
					fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmEvent2;
				}
			}
			else
			{
				FsmGameObject fsmGameObject = GetFsmGameObject(fsm, paramIndex);
				fsmAnimationCurve2 = (FsmAnimationCurve)(object)fsmGameObject;
			}
			goto IL_11a7;
			IL_11a7:
			value = fsmAnimationCurve2;
			goto IL_23ff;
			IL_2437:
			fieldType = (Type)typeFromHandle2;
			goto IL_2415;
			IL_23ff:
			field.SetValue(obj, value);
			return;
			IL_2593:
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			goto IL_11a7;
			IL_24e5:
			fieldInfo.SetValue(obj2, value2);
			return;
			IL_2444:
			fieldType = (Type)typeFromHandle;
			x = color.r;
			num28 = color2.r;
			goto IL_2415;
			IL_2415:
			obj6 = num28;
			goto IL_2593;
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x9CF78C", Offset = "0x9CF78C", Length = "0x1244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv44 = *([1EE3B70]);\n\tv45 = *([v44 @ X8_v281]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, fsm, field, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20219E1]) = v59;\nL_0025:\n\tv64 = System.Array::GetLength(field, 0);\n\tv104 = v64 <= elementIndex;\n\tif (v104) goto L_05A8;\n\tv468 = this.paramDataPos;\n\tv105 = v468._size <= paramIndex;\n\tif (v105) goto L_05A8;\n\tgoto L_0055;\n\tv884 = *([v878 @ X0_v12+E0]);\n\tv885 = v884 == 0;\n\tv886 = ~v885;\n\tif (v886) goto L_0055;\n\tv888 = \"il2cpp_codegen_runtime_class_init\"(v878, v62, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0055:\n\tv893 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmGameObject);\n\tv898 = v893 == fieldType;\n\tif (v898) goto L_01C2;\n\tgoto L_006F;\n\tv914 = *([v904 @ X0_v21+E0]);\n\tv915 = v914 == 0;\n\tv916 = ~v915;\n\tif (v916) goto L_006F;\n\tv918 = \"il2cpp_codegen_runtime_class_init\"(v904, v892, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_006F:\n\tv923 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FunctionCall);\n\tv928 = v923 == fieldType;\n\tif (v928) goto L_01C7;\n\tgoto L_0089;\n\tv1296 = *([v1271 @ X0_v27+E0]);\n\tv1297 = v1296 == 0;\n\tv1298 = ~v1297;\n\tif (v1298) goto L_0089;\n\tv1300 = \"il2cpp_codegen_runtime_class_init\"(v1271, v922, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0089:\n\tv1303 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmProperty);\n\tv1051 = v1303 == fieldType;\n\tif (v1051) goto L_01CC;\n\tgoto L_00A3;\n\tv1311 = *([v1306 @ X0_v33+E0]);\n\tv1312 = v1311 == 0;\n\tv1313 = ~v1312;\n\tif (v1313) goto L_00A3;\n\tv1315 = \"il2cpp_codegen_runtime_class_init\"(v1306, v1302, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_00A3:\n\tv1318 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.LayoutOption);\n\tv1052 = v1318 == fieldType;\n\tif (v1052) goto L_01D1;\n\tgoto L_00BD;\n\tv1326 = *([v1321 @ X0_v39+E0]);\n\tv1327 = v1326 == 0;\n\tv1328 = ~v1327;\n\tif (v1328) goto L_00BD;\n\tv1330 = \"il2cpp_codegen_runtime_class_init\"(v1321, v1317, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_00BD:\n\tv1333 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmOwnerDefault);\n\tv1053 = v1333 == fieldType;\n\tif (v1053) goto L_01D6;\n\tgoto L_00D7;\n\tv1341 = *([v1336 @ X0_v45+E0]);\n\tv1342 = v1341 == 0;\n\tv1343 = ~v1342;\n\tif (v1343) goto L_00D7;\n\tv1345 = \"il2cpp_codegen_runtime_class_init\"(v1336, v1332, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_00D7:\n\tv378 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmAnimationCurve);\n\tv240 = v378 == fieldType;\n\tif (v240) goto L_01D8;\n\tgoto L_00F1;\n\tv1354 = *([v1350 @ X0_v57+E0]);\n\tv1355 = v1354 == 0;\n\tv1356 = ~v1355;\n\tif (v1356) goto L_00F1;\n\tv1358 = \"il2cpp_codegen_runtime_class_init\"(v1350, v359, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_00F1:\n\tv1361 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVar);\n\tv1054 = v1361 == fieldType;\n\tif (v1054) goto L_0214;\n\tgoto L_010B;\n\tv1388 = *([v1367 @ X0_v63+E0]);\n\tv1389 = v1388 == 0;\n\tv1390 = ~v1389;\n\tif (v1390) goto L_010B;\n\tv1392 = \"il2cpp_codegen_runtime_class_init\"(v1367, v1360, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_010B:\n\tv1395 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmArray);\n\tv1055 = v1395 == fieldType;\n\tif (v1055) goto L_0219;\n\tgoto L_0125;\n\tv1419 = *([v1414 @ X0_v69+E0]);\n\tv1420 = v1419 == 0;\n\tv1421 = ~v1420;\n\tif (v1421) goto L_0125;\n\tv1423 = \"il2cpp_codegen_runtime_class_init\"(v1414, v1394, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0125:\n\tv1426 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmString);\n\tv1056 = v1426 == fieldType;\n\tif (v1056) goto L_021E;\n\tgoto L_013F;\n\tv1434 = *([v1429 @ X0_v75+E0]);\n\tv1435 = v1434 == 0;\n\tv1436 = ~v1435;\n\tif (v1436) goto L_013F;\n\tv1438 = \"il2cpp_codegen_runtime_class_init\"(v1429, v1425, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_013F:\n\tv1441 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmObject);\n\tv1057 = v1441 == fieldType;\n\tif (v1057) goto L_0223;\n\tgoto L_0159;\n\tv1449 = *([v1444 @ X0_v81+E0]);\n\tv1450 = v1449 == 0;\n\tv1451 = ~v1450;\n\tif (v1451) goto L_0159;\n\tv1453 = \"il2cpp_codegen_runtime_class_init\"(v1444, v1440, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0159:\n\tv1456 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmMaterial);\n\tv1058 = v1456 == fieldType;\n\tif (v1058) goto L_0228;\n\tgoto L_0173;\n\tv1464 = *([v1459 @ X0_v87+E0]);\n\tv1465 = v1464 == 0;\n\tv1466 = ~v1465;\n\tif (v1466) goto L_0173;\n\tv1468 = \"il2cpp_codegen_runtime_class_init\"(v1459, v1455, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0173:\n\tv1471 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTexture);\n\tv1059 = v1471 == fieldType;\n\tif (v1059) goto L_022D;\n\tgoto L_018D;\n\tv1479 = *([v1474 @ X0_v93+E0]);\n\tv1480 = v1479 == 0;\n\tv1481 = ~v1480;\n\tif (v1481) goto L_018D;\n\tv1483 = \"il2cpp_codegen_runtime_class_init\"(v1474, v1470, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_018D:\n\tv377 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEnum);\n\tv239 = v377 == fieldType;\n\tif (v239) goto L_0232;\n\tv1489 = System.Type::get_IsArray(fieldType);\n\tv1491 = v1489 == 0;\n\tif (v1491) goto L_023B;\n\tgoto L_01BD;\n\tv1503 = *([v1494 @ X0_v336+E0]);\n\tv1504 = v1503 == 0;\n\tv1505 = ~v1504;\n\tif (v1505) goto L_01BD;\n\tv1507 = \"il2cpp_codegen_runtime_class_init\"(v1494, v1488, v63, fieldType, elementIndex, paramIndex, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_01BD:\n\tUnityEngine.Debug::LogError(\"Nested arrays are not supported!\");\n\treturn;\nL_01C2:\n\tv913 = HutongGames.PlayMaker.ActionData::GetFsmGameObject(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_01C7:\n\tv1180 = HutongGames.PlayMaker.ActionData::GetFunctionCall(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_01CC:\n\tv1181 = HutongGames.PlayMaker.ActionData::GetFsmProperty(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_01D1:\n\tv1182 = HutongGames.PlayMaker.ActionData::GetLayoutOption(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_01D6:\n\tv1183 = HutongGames.PlayMaker.ActionData::GetFsmOwnerDefault(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_01D8:\n\tv442 = this.paramDataPos;\n\tv436 = this.animationCurveParams;\n\tv1362 = v442._size < paramIndex;\n\tv328 = ~v1362;\n\tv299 = v442._size - paramIndex;\n\tv241 = v299 == 0;\n\tv1363 = ~v241;\n\tv106 = v328 & v1363;\n\tif (v106) goto L_01ED;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01ED:\n\tv1372 = v442._items;\n\tv1377 = v436._size < v1372[paramIndex @ X5 (System.Int32)];\n\tv1378 = ~v1377;\n\tv1379 = v436._size - v1372[paramIndex @ X5 (System.Int32)];\n\tv1381 = v1379 == 0;\n\tv1386 = ~v1381;\n\tv1387 = v1378 & v1386;\n\tif (v1387) goto L_0200;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0200:\n\tv1398 = v436._items;\n\tv1402 = v1398[v1372[paramIndex @ X5 (System.Int32)]] == 0;\n\tv1403 = ~v1402;\n\tif (v1403) goto L_FFFFFFFF;\n\tv1408 = new HutongGames.PlayMaker.FsmAnimationCurve();\n\tHutongGames.PlayMaker.FsmAnimationCurve::.ctor(v1408);\n\tgoto L_050F;\nL_0214:\n\tv1184 = HutongGames.PlayMaker.ActionData::GetFsmVar(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_0219:\n\tv1185 = HutongGames.PlayMaker.ActionData::GetFsmArray(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_021E:\n\tv1186 = HutongGames.PlayMaker.ActionData::GetFsmString(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_0223:\n\tv1187 = HutongGames.PlayMaker.ActionData::GetFsmObject(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_0228:\n\tv1188 = HutongGames.PlayMaker.ActionData::GetFsmMaterial(this, fsm, paramIndex);\n\tgoto L_FFFFFFFF;\nL_022D:\n\tv1189 = HutongGames.PlayMaker.\n// ... truncated")]
		private void LoadArrayElement(Fsm fsm, Array field, Type fieldType, int elementIndex, int paramIndex)
		{
			//IL_0f13: Expected O, but got I4
			//IL_20d8: Expected I4, but got O
			//IL_20b6: Expected O, but got F4
			//IL_0fdf: Expected O, but got I4
			//IL_20c3: Expected O, but got I4
			//IL_20cb: Expected I4, but got O
			//IL_10ab: Expected O, but got I4
			//IL_119e: Expected O, but got I4
			//IL_20e5: Expected I4, but got O
			//IL_12a0: Expected O, but got I4
			//IL_1398: Expected O, but got I4
			//IL_1493: Expected O, but got I4
			//IL_158e: Expected O, but got I4
			int length = field.GetLength(0);
			if (length <= elementIndex)
			{
				return;
			}
			List<int> list = paramDataPos;
			if (list.Count <= paramIndex)
			{
				return;
			}
			Type typeFromHandle = typeof(FsmGameObject);
			FsmAnimationCurve fsmAnimationCurve;
			object value2 = default(object);
			object value3;
			Array array;
			object obj2;
			Color color;
			Color color2;
			object typeFromHandle35;
			float num22;
			object typeFromHandle36;
			object obj4;
			float x;
			if ((object)typeFromHandle != fieldType)
			{
				Type typeFromHandle2 = typeof(FunctionCall);
				if ((object)typeFromHandle2 != fieldType)
				{
					Type typeFromHandle3 = typeof(FsmProperty);
					if ((object)typeFromHandle3 != fieldType)
					{
						Type typeFromHandle4 = typeof(LayoutOption);
						if ((object)typeFromHandle4 != fieldType)
						{
							Type typeFromHandle5 = typeof(FsmOwnerDefault);
							if ((object)typeFromHandle5 != fieldType)
							{
								Type typeFromHandle6 = typeof(FsmAnimationCurve);
								if ((object)typeFromHandle6 == fieldType)
								{
									List<int> list2 = paramDataPos;
									List<FsmAnimationCurve> list3 = animationCurveParams;
									bool flag = list2.Count < paramIndex;
									bool flag2 = !flag;
									int num = list2.Count - paramIndex;
									bool flag3 = num == 0;
									bool flag4 = !flag3;
									if (!(flag2 && flag4))
									{
										throw new ArgumentOutOfRangeException();
									}
									int[] items = list2._items;
									bool flag5 = list3.Count < items[paramIndex];
									bool flag6 = !flag5;
									int num2 = list3.Count - items[paramIndex];
									bool flag7 = num2 == 0;
									bool flag8 = !flag7;
									if (!(flag6 && flag8))
									{
										throw new ArgumentOutOfRangeException();
									}
									FsmAnimationCurve[] items2 = list3._items;
									bool flag9 = items2[items[paramIndex]] == null;
									bool flag10 = !flag9;
									fsmAnimationCurve = items2[items[paramIndex]];
									if (!flag10)
									{
										FsmAnimationCurve fsmAnimationCurve2 = new FsmAnimationCurve();
										fsmAnimationCurve = fsmAnimationCurve2;
									}
									goto IL_0531;
								}
								Type typeFromHandle7 = typeof(FsmVar);
								if ((object)typeFromHandle7 != fieldType)
								{
									Type typeFromHandle8 = typeof(FsmArray);
									if ((object)typeFromHandle8 != fieldType)
									{
										Type typeFromHandle9 = typeof(FsmString);
										if ((object)typeFromHandle9 != fieldType)
										{
											Type typeFromHandle10 = typeof(FsmObject);
											if ((object)typeFromHandle10 != fieldType)
											{
												Type typeFromHandle11 = typeof(FsmMaterial);
												if ((object)typeFromHandle11 != fieldType)
												{
													Type typeFromHandle12 = typeof(FsmTexture);
													if ((object)typeFromHandle12 != fieldType)
													{
														Type typeFromHandle13 = typeof(FsmEnum);
														if ((object)typeFromHandle13 != fieldType)
														{
															if (fieldType.IsArray)
															{
																Debug.LogError("Nested arrays are not supported!");
																return;
															}
															Type typeFromHandle14 = typeof(FsmEvent);
															if ((object)typeFromHandle14 != fieldType)
															{
																Type typeFromHandle15 = typeof(FsmFloat);
																if ((object)typeFromHandle15 != fieldType)
																{
																	Type typeFromHandle16 = typeof(FsmInt);
																	if ((object)typeFromHandle16 != fieldType)
																	{
																		Type typeFromHandle17 = typeof(FsmBool);
																		if ((object)typeFromHandle17 != fieldType)
																		{
																			Type typeFromHandle18 = typeof(FsmVector2);
																			if ((object)typeFromHandle18 != fieldType)
																			{
																				Type typeFromHandle19 = typeof(FsmVector3);
																				if ((object)typeFromHandle19 != fieldType)
																				{
																					Type typeFromHandle20 = typeof(FsmRect);
																					if ((object)typeFromHandle20 != fieldType)
																					{
																						Type typeFromHandle21 = typeof(FsmQuaternion);
																						if ((object)typeFromHandle21 != fieldType)
																						{
																							Type typeFromHandle22 = typeof(FsmColor);
																							if ((object)typeFromHandle22 != fieldType)
																							{
																								Type typeFromHandle23 = typeof(float);
																								object obj3;
																								if ((object)typeFromHandle23 != fieldType)
																								{
																									Type typeFromHandle24 = typeof(int);
																									int num26;
																									object typeFromHandle37;
																									if ((object)typeFromHandle24 != fieldType)
																									{
																										Type typeFromHandle25 = typeof(bool);
																										if ((object)typeFromHandle25 != fieldType)
																										{
																											Type typeFromHandle26 = typeof(Color);
																											float y;
																											float width;
																											float height;
																											if ((object)typeFromHandle26 != fieldType)
																											{
																												Type typeFromHandle27 = typeof(Vector2);
																												if ((object)typeFromHandle27 != fieldType)
																												{
																													Type typeFromHandle28 = typeof(Vector3);
																													if ((object)typeFromHandle28 != fieldType)
																													{
																														Type typeFromHandle29 = typeof(Vector4);
																														if ((object)typeFromHandle29 != fieldType)
																														{
																															Type typeFromHandle30 = typeof(Rect);
																															if ((object)typeFromHandle30 != fieldType)
																															{
																																Type typeFromHandle31 = typeof(string);
																																if ((object)typeFromHandle31 != fieldType)
																																{
																																	if (fieldType.IsEnum)
																																	{
																																		List<int> list4 = paramDataPos;
																																		bool flag11 = list4.Count < paramIndex;
																																		bool flag12 = !flag11;
																																		int num3 = list4.Count - paramIndex;
																																		bool flag13 = num3 == 0;
																																		bool flag14 = !flag13;
																																		if (!(flag12 && flag14))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items3 = list4._items;
																																		length = FsmUtility.BitConverter.ToInt32(byteDataAsArray, items3[paramIndex]);
																																		object value = length;
																																		value2 = Enum.ToObject(fieldType, value);
																																		goto IL_11b1;
																																	}
																																	Type typeFromHandle32 = typeof(FsmObject);
																																	if (typeFromHandle32.IsAssignableFrom(fieldType))
																																	{
																																		List<int> list5 = paramDataPos;
																																		List<FsmObject> list6 = fsmObjectParams;
																																		bool flag15 = list5.Count < paramIndex;
																																		bool flag16 = !flag15;
																																		int num4 = list5.Count - paramIndex;
																																		bool flag17 = num4 == 0;
																																		bool flag18 = !flag17;
																																		if (!(flag16 && flag18))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items4 = list5._items;
																																		bool flag19 = list6.Count < items4[paramIndex];
																																		bool flag20 = !flag19;
																																		int num5 = list6.Count - items4[paramIndex];
																																		bool flag21 = num5 == 0;
																																		bool flag22 = !flag21;
																																		if (!(flag20 && flag22))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		FsmObject[] items5 = list6._items;
																																		bool flag23 = items5[items4[paramIndex]] == null;
																																		bool flag24 = !flag23;
																																		value3 = items5[items4[paramIndex]];
																																		if (!flag24)
																																		{
																																			return;
																																		}
																																		goto IL_20a1;
																																	}
																																	Type typeFromHandle33 = typeof(UnityEngine.Object);
																																	if (typeFromHandle33.IsAssignableFrom(fieldType))
																																	{
																																		List<int> list7 = paramDataPos;
																																		List<UnityEngine.Object> list8 = unityObjectParams;
																																		bool flag25 = list7.Count < paramIndex;
																																		bool flag26 = !flag25;
																																		int num6 = list7.Count - paramIndex;
																																		bool flag27 = num6 == 0;
																																		bool flag28 = !flag27;
																																		if (!(flag26 && flag28))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items6 = list7._items;
																																		bool flag29 = list8.Count < items6[paramIndex];
																																		bool flag30 = !flag29;
																																		int num7 = list8.Count - items6[paramIndex];
																																		bool flag31 = num7 == 0;
																																		bool flag32 = !flag31;
																																		if (!(flag30 && flag32))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		UnityEngine.Object[] items7 = list8._items;
																																		if ((object)items7[items6[paramIndex]] == null)
																																		{
																																			return;
																																		}
																																		Type type = items7[items6[paramIndex]].GetType();
																																		Type typeFromHandle34 = typeof(UnityEngine.Object);
																																		bool flag33 = (object)type != typeFromHandle34;
																																		fsmAnimationCurve = (FsmAnimationCurve)(object)items7[items6[paramIndex]];
																																		if (!flag33)
																																		{
																																			return;
																																		}
																																		goto IL_0531;
																																	}
																																	if (fieldType.IsClass)
																																	{
																																		List<int> list9 = paramDataPos;
																																		List<string> list10 = customTypeNames;
																																		bool flag34 = list9.Count < paramIndex;
																																		bool flag35 = !flag34;
																																		int num8 = list9.Count - paramIndex;
																																		bool flag36 = num8 == 0;
																																		bool flag37 = !flag36;
																																		if (!(flag35 && flag37))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items8 = list9._items;
																																		bool flag38 = list10.Count < items8[paramIndex];
																																		bool flag39 = !flag38;
																																		int num9 = list10.Count - items8[paramIndex];
																																		bool flag40 = num9 == 0;
																																		bool flag41 = !flag40;
																																		if (!(flag39 && flag41))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		string[] items9 = list10._items;
																																		Type globalType = ReflectionUtils.GetGlobalType(items9[items8[paramIndex]]);
																																		object obj = Activator.CreateInstance(globalType);
																																		List<int> list11 = paramDataPos;
																																		List<int> list12 = customTypeSizes;
																																		bool flag42 = list11.Count < paramIndex;
																																		bool flag43 = !flag42;
																																		int num10 = list11.Count - paramIndex;
																																		bool flag44 = num10 == 0;
																																		bool flag45 = !flag44;
																																		if (!(flag43 && flag45))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items10 = list11._items;
																																		bool flag46 = list12.Count < items10[paramIndex];
																																		bool flag47 = !flag46;
																																		int num11 = list12.Count - items10[paramIndex];
																																		bool flag48 = num11 == 0;
																																		bool flag49 = !flag48;
																																		if (!(flag47 && flag49))
																																		{
																																			throw new ArgumentOutOfRangeException();
																																		}
																																		int[] items11 = list12._items;
																																		if (items11[items10[paramIndex]] >= 1)
																																		{
																																			int num12 = 0;
																																			do
																																			{
																																				List<string> list13 = paramName;
																																				int num13 = ++nextParamIndex;
																																				bool flag50 = list13.Count < num13;
																																				bool flag51 = !flag50;
																																				int num14 = list13.Count - num13;
																																				bool flag52 = num14 == 0;
																																				bool flag53 = !flag52;
																																				if (!(flag51 && flag53))
																																				{
																																					throw new ArgumentOutOfRangeException();
																																				}
																																				string[] items12 = list13._items;
																																				FieldInfo field2 = globalType.GetField(items12[num13]);
																																				if ((object)field2 != null)
																																				{
																																					LoadActionField(fsm, obj, field2, nextParamIndex);
																																				}
																																				num12++;
																																			}
																																			while (num12 < items11[items10[paramIndex]]);
																																		}
																																		value3 = obj;
																																		array = field;
																																	}
																																	else
																																	{
																																		value3 = null;
																																		array = field;
																																	}
																																	goto IL_2015;
																																}
																																if (fsm.DataVersion >= 2)
																																{
																																	List<string> list14 = stringParams;
																																	if (stringParams != null)
																																	{
																																		int count = list14.Count;
																																		if (list14.Count >= 1)
																																		{
																																			List<int> list15 = paramDataPos;
																																			bool flag54 = list15.Count < paramIndex;
																																			bool flag55 = !flag54;
																																			int num15 = list15.Count - paramIndex;
																																			bool flag56 = num15 == 0;
																																			bool flag57 = !flag56;
																																			if (!(flag55 && flag57))
																																			{
																																				throw new ArgumentOutOfRangeException();
																																			}
																																			int[] items13 = list15._items;
																																			bool flag58 = count < items13[paramIndex];
																																			bool flag59 = !flag58;
																																			int num16 = count - items13[paramIndex];
																																			bool flag60 = num16 == 0;
																																			bool flag61 = !flag60;
																																			if (!(flag59 && flag61))
																																			{
																																				throw new ArgumentOutOfRangeException();
																																			}
																																			string[] items14 = list14._items;
																																			value3 = items14[items13[paramIndex]];
																																			goto IL_20a1;
																																		}
																																	}
																																}
																																List<int> list16 = paramDataPos;
																																bool flag62 = list16.Count < paramIndex;
																																bool flag63 = !flag62;
																																int num17 = list16.Count - paramIndex;
																																bool flag64 = num17 == 0;
																																bool flag65 = !flag64;
																																if (!(flag63 && flag65))
																																{
																																	throw new ArgumentOutOfRangeException();
																																}
																																List<int> list17 = paramByteDataSize;
																																int[] items15 = list16._items;
																																bool flag66 = list17.Count < paramIndex;
																																bool flag67 = !flag66;
																																int num18 = list17.Count - paramIndex;
																																bool flag68 = num18 == 0;
																																bool flag69 = !flag68;
																																if (!(flag67 && flag69))
																																{
																																	throw new ArgumentOutOfRangeException();
																																}
																																int[] items16 = list17._items;
																																string text = FsmUtility.ByteArrayToString(byteDataAsArray, items15[paramIndex], items16[paramIndex]);
																																obj2 = text;
																																goto IL_0e4d;
																															}
																															List<int> list18 = paramDataPos;
																															bool flag70 = list18.Count < paramIndex;
																															bool flag71 = !flag70;
																															int num19 = list18.Count - paramIndex;
																															bool flag72 = num19 == 0;
																															bool flag73 = !flag72;
																															if (!(flag71 && flag73))
																															{
																																throw new ArgumentOutOfRangeException();
																															}
																															int[] items17 = list18._items;
																															Rect rect = FsmUtility.ByteArrayToRect(byteDataAsArray, items17[paramIndex]);
																															y = rect.y;
																															width = rect.width;
																															height = rect.height;
																															color = (Color)rect;
																															color2 = (Color)rect;
																															obj3 = 0;
																															typeFromHandle35 = typeof(Rect);
																														}
																														else
																														{
																															List<int> list19 = paramDataPos;
																															bool flag74 = list19.Count < paramIndex;
																															bool flag75 = !flag74;
																															int num20 = list19.Count - paramIndex;
																															bool flag76 = num20 == 0;
																															bool flag77 = !flag76;
																															if (!(flag75 && flag77))
																															{
																																throw new ArgumentOutOfRangeException();
																															}
																															int[] items18 = list19._items;
																															Vector4 vector = FsmUtility.ByteArrayToVector4(byteDataAsArray, items18[paramIndex]);
																															y = vector.y;
																															width = vector.z;
																															height = vector.w;
																															color = vector;
																															color2 = vector;
																															obj3 = 0;
																															typeFromHandle35 = typeof(Vector4);
																														}
																														goto IL_20dd;
																													}
																													List<int> list20 = paramDataPos;
																													bool flag78 = list20.Count < paramIndex;
																													bool flag79 = !flag78;
																													int num21 = list20.Count - paramIndex;
																													bool flag80 = num21 == 0;
																													bool flag81 = !flag80;
																													if (!(flag79 && flag81))
																													{
																														throw new ArgumentOutOfRangeException();
																													}
																													int[] items19 = list20._items;
																													Vector3 vector2 = FsmUtility.ByteArrayToVector3(byteDataAsArray, items19[paramIndex]);
																													y = vector2.y;
																													width = vector2.z;
																													x = vector2.x;
																													num22 = vector2.x;
																													obj3 = 0;
																													typeFromHandle36 = typeof(Vector3);
																												}
																												else
																												{
																													List<int> list21 = paramDataPos;
																													bool flag82 = list21.Count < paramIndex;
																													bool flag83 = !flag82;
																													int num23 = list21.Count - paramIndex;
																													bool flag84 = num23 == 0;
																													bool flag85 = !flag84;
																													if (!(flag83 && flag85))
																													{
																														throw new ArgumentOutOfRangeException();
																													}
																													int[] items20 = list21._items;
																													Vector2 vector3 = FsmUtility.ByteArrayToVector2(byteDataAsArray, items20[paramIndex]);
																													y = vector3.y;
																													x = vector3.x;
																													num22 = vector3.x;
																													obj3 = 0;
																													typeFromHandle36 = typeof(Vector2);
																												}
																												goto IL_20d0;
																											}
																											List<int> list22 = paramDataPos;
																											bool flag86 = list22.Count < paramIndex;
																											bool flag87 = !flag86;
																											int num24 = list22.Count - paramIndex;
																											bool flag88 = num24 == 0;
																											bool flag89 = !flag88;
																											if (!(flag87 && flag89))
																											{
																												throw new ArgumentOutOfRangeException();
																											}
																											int[] items21 = list22._items;
																											color = FsmUtility.ByteArrayToColor(byteDataAsArray, items21[paramIndex]);
																											y = color.g;
																											width = color.b;
																											height = color.a;
																											color2 = color;
																											obj3 = 0;
																											typeFromHandle35 = typeof(Color);
																											goto IL_20dd;
																										}
																										List<int> list23 = paramDataPos;
																										bool flag90 = list23.Count < paramIndex;
																										bool flag91 = !flag90;
																										int num25 = list23.Count - paramIndex;
																										bool flag92 = num25 == 0;
																										bool flag93 = !flag92;
																										if (!(flag91 && flag93))
																										{
																											throw new ArgumentOutOfRangeException();
																										}
																										int[] items22 = list23._items;
																										bool flag94 = FsmUtility.BitConverter.ToBoolean(byteDataAsArray, items22[paramIndex]);
																										num26 = (flag94 ? 1 : 0);
																										obj3 = 0;
																										typeFromHandle37 = typeof(bool);
																									}
																									else
																									{
																										List<int> list24 = paramDataPos;
																										bool flag95 = list24.Count < paramIndex;
																										bool flag96 = !flag95;
																										int num27 = list24.Count - paramIndex;
																										bool flag97 = num27 == 0;
																										bool flag98 = !flag97;
																										if (!(flag96 && flag98))
																										{
																											throw new ArgumentOutOfRangeException();
																										}
																										int[] items23 = list24._items;
																										length = FsmUtility.BitConverter.ToInt32(byteDataAsArray, items23[paramIndex]);
																										num26 = length;
																										obj3 = 0;
																										typeFromHandle37 = typeof(int);
																									}
																									obj4 = num26;
																									length = (int)typeFromHandle37;
																									goto IL_21a7;
																								}
																								List<int> list25 = paramDataPos;
																								bool flag99 = list25.Count < paramIndex;
																								bool flag100 = !flag99;
																								int num28 = list25.Count - paramIndex;
																								bool flag101 = num28 == 0;
																								bool flag102 = !flag101;
																								if (!(flag100 && flag102))
																								{
																									throw new ArgumentOutOfRangeException();
																								}
																								int[] items24 = list25._items;
																								x = FsmUtility.BitConverter.ToSingle(byteDataAsArray, items24[paramIndex]);
																								num22 = x;
																								obj3 = 0;
																								typeFromHandle36 = typeof(float);
																								goto IL_20d0;
																							}
																							FsmColor fsmColor = GetFsmColor(fsm, paramIndex);
																							obj2 = fsmColor;
																						}
																						else
																						{
																							FsmQuaternion fsmQuaternion = GetFsmQuaternion(fsm, paramIndex);
																							obj2 = fsmQuaternion;
																						}
																					}
																					else
																					{
																						FsmRect fsmRect = GetFsmRect(fsm, paramIndex);
																						obj2 = fsmRect;
																					}
																				}
																				else
																				{
																					FsmVector3 fsmVector = GetFsmVector3(fsm, paramIndex);
																					obj2 = fsmVector;
																				}
																			}
																			else
																			{
																				FsmVector2 fsmVector2 = GetFsmVector2(fsm, paramIndex);
																				obj2 = fsmVector2;
																			}
																		}
																		else
																		{
																			FsmBool fsmBool = GetFsmBool(fsm, paramIndex);
																			obj2 = fsmBool;
																		}
																	}
																	else
																	{
																		FsmInt fsmInt = GetFsmInt(fsm, paramIndex);
																		obj2 = fsmInt;
																	}
																}
																else
																{
																	FsmFloat fsmFloat = GetFsmFloat(fsm, paramIndex);
																	obj2 = fsmFloat;
																}
															}
															else
															{
																if (fsm.DataVersion >= 2)
																{
																	List<string> list26 = stringParams;
																	if (stringParams != null)
																	{
																		int count2 = list26.Count;
																		if (list26.Count >= 1)
																		{
																			List<int> list27 = paramDataPos;
																			bool flag103 = list27.Count < paramIndex;
																			bool flag104 = !flag103;
																			int num29 = list27.Count - paramIndex;
																			bool flag105 = num29 == 0;
																			bool flag106 = !flag105;
																			if (!(flag104 && flag106))
																			{
																				throw new ArgumentOutOfRangeException();
																			}
																			int[] items25 = list27._items;
																			bool flag107 = count2 < items25[paramIndex];
																			bool flag108 = !flag107;
																			int num30 = count2 - items25[paramIndex];
																			bool flag109 = num30 == 0;
																			bool flag110 = !flag109;
																			if (!(flag108 && flag110))
																			{
																				throw new ArgumentOutOfRangeException();
																			}
																			string[] items26 = list26._items;
																			bool flag111 = string.IsNullOrEmpty(items26[items25[paramIndex]]);
																			bool flag112 = !flag111;
																			bool flag113 = !flag112;
																			value3 = null;
																			if (!flag113)
																			{
																				FsmEvent fsmEvent = FsmEvent.GetFsmEvent(items26[items25[paramIndex]]);
																				obj2 = fsmEvent;
																				goto IL_0e4d;
																			}
																			goto IL_20a1;
																		}
																	}
																}
																List<int> list28 = paramDataPos;
																bool flag114 = list28.Count < paramIndex;
																bool flag115 = !flag114;
																int num31 = list28.Count - paramIndex;
																bool flag116 = num31 == 0;
																bool flag117 = !flag116;
																if (!(flag115 && flag117))
																{
																	throw new ArgumentOutOfRangeException();
																}
																List<int> list29 = paramByteDataSize;
																int[] items27 = list28._items;
																bool flag118 = list29.Count < paramIndex;
																bool flag119 = !flag118;
																int num32 = list29.Count - paramIndex;
																bool flag120 = num32 == 0;
																bool flag121 = !flag120;
																if (!(flag119 && flag121))
																{
																	throw new ArgumentOutOfRangeException();
																}
																int[] items28 = list29._items;
																FsmEvent fsmEvent2 = FsmUtility.ByteArrayToFsmEvent(byteDataAsArray, items27[paramIndex], items28[paramIndex]);
																obj2 = fsmEvent2;
															}
														}
														else
														{
															FsmEnum fsmEnum = GetFsmEnum(fsm, paramIndex);
															obj2 = fsmEnum;
														}
													}
													else
													{
														FsmTexture fsmTexture = GetFsmTexture(fsm, paramIndex);
														obj2 = fsmTexture;
													}
												}
												else
												{
													FsmMaterial fsmMaterial = GetFsmMaterial(fsm, paramIndex);
													obj2 = fsmMaterial;
												}
											}
											else
											{
												FsmObject fsmObject = GetFsmObject(fsm, paramIndex);
												obj2 = fsmObject;
											}
										}
										else
										{
											FsmString fsmString = GetFsmString(fsm, paramIndex);
											obj2 = fsmString;
										}
									}
									else
									{
										FsmArray fsmArray = GetFsmArray(fsm, paramIndex);
										obj2 = fsmArray;
									}
								}
								else
								{
									FsmVar fsmVar = GetFsmVar(fsm, paramIndex);
									obj2 = fsmVar;
								}
							}
							else
							{
								FsmOwnerDefault fsmOwnerDefault = GetFsmOwnerDefault(fsm, paramIndex);
								obj2 = fsmOwnerDefault;
							}
						}
						else
						{
							LayoutOption layoutOption = GetLayoutOption(fsm, paramIndex);
							obj2 = layoutOption;
						}
					}
					else
					{
						FsmProperty fsmProperty = GetFsmProperty(fsm, paramIndex);
						obj2 = fsmProperty;
					}
				}
				else
				{
					FunctionCall functionCall = GetFunctionCall(fsm, paramIndex);
					obj2 = functionCall;
				}
			}
			else
			{
				FsmGameObject fsmGameObject = GetFsmGameObject(fsm, paramIndex);
				obj2 = fsmGameObject;
			}
			goto IL_0e4d;
			IL_20a1:
			array = field;
			goto IL_2015;
			IL_20ae:
			obj4 = num22;
			goto IL_21a7;
			IL_0e4d:
			value3 = obj2;
			goto IL_20a1;
			IL_20dd:
			length = (int)typeFromHandle35;
			x = color.r;
			num22 = color2.r;
			goto IL_20ae;
			IL_21a7:
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			goto IL_11b1;
			IL_2015:
			array.SetValue(value3, elementIndex);
			return;
			IL_0531:
			value3 = fsmAnimationCurve;
			array = field;
			goto IL_2015;
			IL_20d0:
			length = (int)typeFromHandle36;
			goto IL_20ae;
			IL_11b1:
			field.SetValue(value2, elementIndex);
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0x9CBB8C", Offset = "0x9CBB8C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EA3EA8]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, error, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20219E2]) = v47;\nL_001B:\n\tv50 = context.currentState == 0;\n\tif (v50) goto L_004F;\n\tv54 = context.currentAction == 0;\n\tif (v54) goto L_004F;\n\tv62 = context.currentFsm;\n\tv59 = context.currentFsm == 0;\n\tif (v59) goto L_004F;\n\tv60 = v62.owner == 0;\n\tif (v60) goto L_004F;\n\tgoto L_0043;\n\tv150 = *([v146 @ X0_v4+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0043;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v146, error, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0043:\n\tgoto L_FFFFFFFF;\n\tgoto L_0071;\nL_004F:\n\treturn;\n\tv182 = v182_asT == 0;\n\tif (v182) goto L_FFFFFFFF;\n\tgoto L_0071;\nL_0071:\n\tHutongGames.PlayMaker.ActionReport::LogError(v129, context.currentState, context.currentAction, context.currentActionIndex, context.currentParameter, error);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void LogError(Context context, string error)
		{
			if (context.currentState != null && context.currentAction != null)
			{
				Fsm currentFsm = context.currentFsm;
				if (context.currentFsm != null && (object)currentFsm.Owner != null)
				{
					PlayMakerFSM playMakerFSM = currentFsm.Owner as PlayMakerFSM;
					PlayMakerFSM fsm = (PlayMakerFSM)(((object)playMakerFSM == null) ? null : currentFsm.Owner);
					ActionReport.LogError(fsm, context.currentState, context.currentAction, context.currentActionIndex, context.currentParameter, error);
				}
			}
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0x9CBC98", Offset = "0x9CBC98", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EB6B40]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, info, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20219E3]) = v47;\nL_001B:\n\tv50 = context.currentState == 0;\n\tif (v50) goto L_004D;\n\tv60 = context.currentAction == 0;\n\tif (v60) goto L_004D;\n\tv56 = context.currentFsm;\n\tv149 = HutongGames.PlayMaker.ActionReport;\n\tv151 = *([v149 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+12F]) & 2;\n\tv152 = v151 == 0;\n\tif (v152) goto L_0030;\n\tv154 = *([v149 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]) == 0;\n\tif (v154) goto L_0073;\nL_0030:\n\tv157 = v56.owner == 0;\n\tif (v157) goto L_FFFFFFFF;\nL_0041:\n\tgoto L_FFFFFFFF;\n\tgoto L_0070;\nL_004D:\n\treturn;\n\tv207 = v207_asT == 0;\n\tif (v207) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tv131 = HutongGames.PlayMaker.ActionReport::Log(v208, context.currentState, context.currentAction, context.currentActionIndex, context.currentParameter, info, 0);\n\treturn;\nL_0073:\n\tv193 = v56.owner == 0;\n\tv161 = ~v193;\n\tif (v161) goto L_0041;\n\tgoto L_FFFFFFFF;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void LogInfo(Context context, string info)
		{
			//IL_0069: Expected I, but got O
			if (context.currentState == null || context.currentAction == null)
			{
				return;
			}
			Fsm currentFsm = context.currentFsm;
			IntPtr intPtr = (IntPtr)typeof(ActionReport);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.ActionReport>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if ((object)currentFsm.Owner != null)
					{
						goto IL_00f3;
					}
					goto IL_00e8;
				}
			}
			if ((object)currentFsm.Owner == null)
			{
				goto IL_00e8;
			}
			goto IL_00f3;
			IL_0170:
			PlayMakerFSM fsm;
			ActionReport actionReport = ActionReport.Log(fsm, context.currentState, context.currentAction, context.currentActionIndex, context.currentParameter, info);
			return;
			IL_00e8:
			fsm = null;
			goto IL_0170;
			IL_00f3:
			PlayMakerFSM playMakerFSM = currentFsm.Owner as PlayMakerFSM;
			fsm = (PlayMakerFSM)(((object)playMakerFSM == null) ? null : currentFsm.Owner);
			goto IL_0170;
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x9CD714", Offset = "0x9CD714", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F0AEE0]);\n\tv29 = *([v28 @ X8_v31]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E4]) = v46;\nL_0018:\n\tv47 = fsm == 0;\n\tif (v47) goto L_0068;\n\tv48 = this.paramDataPos;\n\tv56 = v48._size;\n\tv57 = v48._size < paramIndex;\n\tv58 = ~v57;\n\tv59 = v48._size - paramIndex;\n\tv61 = v59 == 0;\n\tv66 = ~v61;\n\tv67 = v58 & v66;\n\tif (v67) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv82 = v48._items;\n\tv56 = fsm.dataVersion;\n\tv96 = fsm.dataVersion >= 2;\n\tif (v96) goto L_0072;\n\tv105 = this.paramByteDataSize;\n\tv139 = this.paramByteDataSize == 0;\n\tif (v139) goto L_00AF;\n\tv276 = v105._size < paramIndex;\n\tv202 = ~v276;\n\tv198 = v105._size - paramIndex;\n\tv190 = v198 == 0;\n\tv278 = ~v190;\n\tv170 = v202 & v278;\n\tif (v170) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv291 = v105._items;\n\treturnVal3 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmFloat(fsm, this.byteDataAsArray, v82[paramIndex @ X2 (System.Int32)], v291[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal3;\nL_0068:\n\tgoto L_FFFFFFFF;\n\tv70 = *([v52 @ X0_v8+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v52, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00C7;\nL_0072:\n\tv140 = this.fsmFloatParams;\n\tv141 = this.fsmFloatParams == 0;\n\tif (v141) goto L_00CB;\n\tv243 = v140._size <= v82[paramIndex @ X2 (System.Int32)];\n\tif (v243) goto L_00CB;\n\tv298 = v140._size < v82[paramIndex @ X2 (System.Int32)];\n\tv203 = ~v298;\n\tv199 = v140._size - v82[paramIndex @ X2 (System.Int32)];\n\tv191 = v199 == 0;\n\tv299 = ~v191;\n\tv171 = v203 & v299;\n\tif (v171) goto L_0091;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0091:\n\tv313 = v140._items;\n\tv269 = v313[v82[paramIndex @ X2 (System.Int32)]];\n\tv263 = v313[v82[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v263) goto L_00CB;\n\tv303 = System.String::IsNullOrEmpty(v269.name);\n\tv322 = v303 == 0;\n\tv210 = ~v322;\n\tif (v210) goto L_00D8;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmFloat(fsm, v269.name);\n\treturn returnVal4;\nL_00AF:\n\t// 175 Box v283 @ X0_v22 (System.Object), typeof(System.Int32), &v56 @ X8_v15 (System.Int32)\n\tv129 = System.String::Concat(\"paramByteDataSize == null! Data Version: \", v283);\n\tgoto L_00C7;\n\tv314 = *([v136 @ X8_v25+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\t// 194 ConditionalJump @b32, v316 @ TEMP_v24\n\tv320 = v136;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v320, v103, v101, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00C7:\n\tUnityEngine.Debug::LogError(v129);\nL_00CB:\n\tv273 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v273);\nL_00D8:\n\treturn v306;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmFloat GetFsmFloat(Fsm fsm, int paramIndex)
		{
			FsmFloat result;
			string message;
			if (fsm != null)
			{
				List<int> list = paramDataPos;
				int count = list.Count;
				bool flag = list.Count < paramIndex;
				bool flag2 = !flag;
				int num = list.Count - paramIndex;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items = list._items;
				count = fsm.DataVersion;
				if (fsm.DataVersion >= 2)
				{
					List<FsmFloat> list2 = fsmFloatParams;
					if (fsmFloatParams != null && list2.Count > items[paramIndex])
					{
						bool flag5 = list2.Count < items[paramIndex];
						bool flag6 = !flag5;
						int num2 = list2.Count - items[paramIndex];
						bool flag7 = num2 == 0;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							throw new ArgumentOutOfRangeException();
						}
						FsmFloat[] items2 = list2._items;
						FsmFloat fsmFloat = items2[items[paramIndex]];
						if (items2[items[paramIndex]] != null)
						{
							bool flag9 = string.IsNullOrEmpty(fsmFloat.Name);
							bool flag10 = !flag9;
							bool flag11 = !flag10;
							result = items2[items[paramIndex]];
							if (!flag11)
							{
								return fsm.GetFsmFloat(fsmFloat.Name);
							}
							goto IL_0398;
						}
					}
					goto IL_0381;
				}
				List<int> list3 = paramByteDataSize;
				if (paramByteDataSize != null)
				{
					bool flag12 = list3.Count < paramIndex;
					bool flag13 = !flag12;
					int num3 = list3.Count - paramIndex;
					bool flag14 = num3 == 0;
					bool flag15 = !flag14;
					if (!(flag13 && flag15))
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items3 = list3._items;
					return FsmUtility.ByteArrayToFsmFloat(fsm, byteDataAsArray, items[paramIndex], items3[paramIndex]);
				}
				object obj = count;
				message = "paramByteDataSize == null! Data Version: " + obj;
			}
			else
			{
				message = "fsm == null!";
			}
			Debug.LogError(message);
			goto IL_0381;
			IL_0381:
			FsmFloat fsmFloat2 = new FsmFloat();
			result = fsmFloat2;
			goto IL_0398;
			IL_0398:
			return result;
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x9CD918", Offset = "0x9CD918", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1ECDAD0]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E5]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmInt(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmIntParams;\n\tv201 = this.fsmIntParams == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmInt(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmInt GetFsmInt(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmInt(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmInt> list3 = fsmIntParams;
			FsmInt result;
			if (fsmIntParams != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmInt[] items3 = list3._items;
				FsmInt fsmInt = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmInt.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmInt(fsmInt.Name);
					}
					goto IL_0319;
				}
			}
			FsmInt fsmInt2 = new FsmInt();
			result = fsmInt2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0x9CDA84", Offset = "0x9CDA84", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EE2420]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E6]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmBool(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmBoolParams;\n\tv201 = this.fsmBoolParams == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmBool GetFsmBool(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmBool(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmBool> list3 = fsmBoolParams;
			FsmBool result;
			if (fsmBoolParams != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmBool[] items3 = list3._items;
				FsmBool fsmBool = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmBool.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmBool(fsmBool.Name);
					}
					goto IL_0319;
				}
			}
			FsmBool fsmBool2 = new FsmBool();
			result = fsmBool2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0x9CDBF0", Offset = "0x9CDBF0", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB1C10]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E7]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmVector2(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmVector2Params;\n\tv201 = this.fsmVector2Params == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmVector2(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmVector2 GetFsmVector2(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmVector2(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmVector2> list3 = fsmVector2Params;
			FsmVector2 result;
			if (fsmVector2Params != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmVector2[] items3 = list3._items;
				FsmVector2 fsmVector = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmVector.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmVector2(fsmVector.Name);
					}
					goto IL_0319;
				}
			}
			FsmVector2 fsmVector2 = new FsmVector2();
			result = fsmVector2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0x9CDD5C", Offset = "0x9CDD5C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F02518]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E8]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmVector3(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmVector3Params;\n\tv201 = this.fsmVector3Params == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmVector3(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmVector3 GetFsmVector3(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmVector3(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmVector3> list3 = fsmVector3Params;
			FsmVector3 result;
			if (fsmVector3Params != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmVector3[] items3 = list3._items;
				FsmVector3 fsmVector = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmVector.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmVector3(fsmVector.Name);
					}
					goto IL_0319;
				}
			}
			FsmVector3 fsmVector2 = new FsmVector3();
			result = fsmVector2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0x9CE1A0", Offset = "0x9CE1A0", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F0BAE0]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219E9]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmColor(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmColorParams;\n\tv201 = this.fsmColorParams == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmColor(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmColor GetFsmColor(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmColor(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmColor> list3 = fsmColorParams;
			FsmColor result;
			if (fsmColorParams != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmColor[] items3 = list3._items;
				FsmColor fsmColor = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmColor.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmColor(fsmColor.Name);
					}
					goto IL_0319;
				}
			}
			FsmColor fsmColor2 = new FsmColor();
			result = fsmColor2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0x9CDEC8", Offset = "0x9CDEC8", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EDDDC8]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219EA]) = v46;\nL_0018:\n\tv47 = v44.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = v44.paramByteDataSize;\n\tv206 = v62._size < paramIndex;\n\tv166 = ~v206;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv208 = ~v154;\n\tv134 = v166 & v208;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv230 = v62._items;\n\treturnVal3 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmRect(fsm, v44.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v230[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal3;\nL_0062:\n\tv188 = v44.fsmRectParams;\n\tv203 = v44.fsmRectParams == 0;\n\tif (v203) goto L_009C;\n\tv221 = v188._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v221) goto L_009C;\n\tv232 = v188._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v232;\n\tv163 = v188._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv233 = ~v155;\n\tv135 = v167 & v233;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv235 = v188._items;\n\tv226 = v235[v108[paramIndex @ X2 (System.Int32)]];\n\tv224 = v235[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v224) goto L_009C;\n\tv237 = System.String::IsNullOrEmpty(v226.name);\n\tv239 = v237 == 0;\n\tv175 = ~v239;\n\tif (v175) goto L_00AB;\n\treturnVal5 = HutongGames.PlayMaker.Fsm::GetFsmRect(fsm, v226.name);\n\treturn returnVal5;\nL_009C:\n\treturnVal2 = 0x9E2A80(v223, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmRect::.ctor(X0, X1);\nL_00AB:\n\treturn v235[v108[paramIndex @ X2 (System.Int32)]];\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmRect GetFsmRect(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmRect(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmRect> list3 = fsmRectParams;
			if (fsmRectParams != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmRect[] items3 = list3._items;
				FsmRect fsmRect = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					if (!string.IsNullOrEmpty(fsmRect.Name))
					{
						return fsm.GetFsmRect(fsmRect.Name);
					}
					return items3[items[paramIndex]];
				}
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9E2A80 (inside HutongGames.PlayMaker.Fsm::.cctor +0x2CC)");
			FsmRect result = default(FsmRect);
			return result;
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0x9CE034", Offset = "0x9CE034", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EF3400]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219EB]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = v47._size < paramIndex;\n\tv51 = ~v50;\n\tv52 = v47._size - paramIndex;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv108 = v47._items;\n\tv70 = fsm.dataVersion >= 2;\n\tif (v70) goto L_0062;\n\tv62 = this.paramByteDataSize;\n\tv204 = v62._size < paramIndex;\n\tv166 = ~v204;\n\tv162 = v62._size - paramIndex;\n\tv154 = v162 == 0;\n\tv206 = ~v154;\n\tv134 = v166 & v206;\n\tif (v134) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv243 = v62._items;\n\treturnVal2 = HutongGames.PlayMaker.FsmUtility::ByteArrayToFsmQuaternion(fsm, this.byteDataAsArray, v108[paramIndex @ X2 (System.Int32)], v243[paramIndex @ X2 (System.Int32)]);\n\treturn returnVal2;\nL_0062:\n\tv200 = this.fsmQuaternionParams;\n\tv201 = this.fsmQuaternionParams == 0;\n\tif (v201) goto L_009D;\n\tv219 = v200._size <= v108[paramIndex @ X2 (System.Int32)];\n\tif (v219) goto L_009D;\n\tv245 = v200._size < v108[paramIndex @ X2 (System.Int32)];\n\tv167 = ~v245;\n\tv163 = v200._size - v108[paramIndex @ X2 (System.Int32)];\n\tv155 = v163 == 0;\n\tv246 = ~v155;\n\tv135 = v167 & v246;\n\tif (v135) goto L_0081;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0081:\n\tv250 = v200._items;\n\tv236 = v250[v108[paramIndex @ X2 (System.Int32)]];\n\tv233 = v250[v108[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v233) goto L_009D;\n\tv253 = System.String::IsNullOrEmpty(v236.name);\n\tv257 = v253 == 0;\n\tv174 = ~v257;\n\tif (v174) goto L_00AA;\n\treturnVal4 = HutongGames.PlayMaker.Fsm::GetFsmQuaternion(fsm, v236.name);\n\treturn returnVal4;\nL_009D:\n\tv240 = new HutongGames.PlayMaker.FsmQuaternion();\n\tHutongGames.PlayMaker.FsmQuaternion::.ctor(v240);\nL_00AA:\n\treturn v254;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmQuaternion GetFsmQuaternion(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			if (fsm.DataVersion < 2)
			{
				List<int> list2 = paramByteDataSize;
				bool flag5 = list2.Count < paramIndex;
				bool flag6 = !flag5;
				int num2 = list2.Count - paramIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items2 = list2._items;
				return FsmUtility.ByteArrayToFsmQuaternion(fsm, byteDataAsArray, items[paramIndex], items2[paramIndex]);
			}
			List<FsmQuaternion> list3 = fsmQuaternionParams;
			FsmQuaternion result;
			if (fsmQuaternionParams != null && list3.Count > items[paramIndex])
			{
				bool flag9 = list3.Count < items[paramIndex];
				bool flag10 = !flag9;
				int num3 = list3.Count - items[paramIndex];
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmQuaternion[] items3 = list3._items;
				FsmQuaternion fsmQuaternion = items3[items[paramIndex]];
				if (items3[items[paramIndex]] != null)
				{
					bool flag13 = string.IsNullOrEmpty(fsmQuaternion.Name);
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					result = items3[items[paramIndex]];
					if (!flag15)
					{
						return fsm.GetFsmQuaternion(fsmQuaternion.Name);
					}
					goto IL_0319;
				}
			}
			FsmQuaternion fsmQuaternion2 = new FsmQuaternion();
			result = fsmQuaternion2;
			goto IL_0319;
			IL_0319:
			return result;
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0x9CD61C", Offset = "0x9CD61C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF34A8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219EC]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmGameObjectParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv106 = v45._items;\n\tv111 = v48._size < v106[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v111;\n\tv87 = v48._size - v106[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv112 = ~v81;\n\tv66 = v90 & v112;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv153 = v48._items;\n\tv100 = v153[v106[paramIndex @ X2 (System.Int32)]];\n\tv154 = v153[v106[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v154) goto L_005C;\n\tv94 = System.String::IsNullOrEmpty(v100.name);\n\tv161 = v94 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0068;\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmGameObject(fsm, v100.name);\n\treturn returnVal3;\nL_005C:\n\tv159 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v159);\nL_0068:\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmGameObject GetFsmGameObject(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmGameObject> list2 = fsmGameObjectParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmGameObject[] items2 = list2._items;
			FsmGameObject fsmGameObject = items2[items[paramIndex]];
			FsmGameObject result;
			if (items2[items[paramIndex]] != null)
			{
				bool flag9 = string.IsNullOrEmpty(fsmGameObject.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					return fsm.GetFsmGameObject(fsmGameObject.Name);
				}
			}
			else
			{
				FsmGameObject fsmGameObject2 = new FsmGameObject();
				result = fsmGameObject2;
			}
			return result;
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0x9CE9E4", Offset = "0x9CE9E4", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F0A338]);\n\tv29 = *([v28 @ X8_v24]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, fsm, paramIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20219ED]) = v46;\nL_0018:\n\tv47 = this.paramDataPos;\n\tv50 = this.fsmTemplateControlParams;\n\tv51 = v47._size < paramIndex;\n\tv52 = ~v51;\n\tv53 = v47._size - paramIndex;\n\tv55 = v53 == 0;\n\tv60 = ~v55;\n\tv61 = v52 & v60;\n\tif (v61) goto L_002D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002D:\n\tv182 = v47._items;\n\tv187 = v50._size < v182[paramIndex @ X2 (System.Int32)];\n\tv117 = ~v187;\n\tv113 = v50._size - v182[paramIndex @ X2 (System.Int32)];\n\tv105 = v113 == 0;\n\tv188 = ~v105;\n\tv85 = v117 & v188;\n\tif (v85) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv193 = v50._items;\n\tv142 = v193[v182[paramIndex @ X2 (System.Int32)]];\n\tv152 = v142.fsmVarOverrides;\n\tv194 = v142.fsmVarOverrides == 0;\n\tif (v194) goto L_00B9;\n\tv179 = v152.Length;\n\tv252 = v152.Length < 1;\n\tif (v252) goto L_00B9;\nL_0057:\n\tv281 = v78 < v179;\n\tv116 = ~v281;\n\tif (v116) goto L_00BD;\n\tv282 = v142.fsmTemplate;\n\tv139 = v152[v78 @ X23_v6 (System.Int32)];\n\tv283 = v142.fsmTemplate == 0;\n\tif (v283) goto L_008B;\n\tv284 = v282.fsm == 0;\n\tif (v284) goto L_008B;\n\tv124 = HutongGames.PlayMaker.NamedVariable::get_UsesVariable(v139.variable);\n\tv292 = v124 == 0;\n\tif (v292) goto L_008B;\n\tv147 = v142.fsmTemplate;\n\tv75 = v147.fsm;\n\tv148 = v139.variable;\n\tv290 = HutongGames.PlayMaker.FsmVariables::GetVariable(v75.variables, v148.name);\n\tv139.variable = v290;\n\tgoto L_008B;\nL_008B:\n\tv299 = HutongGames.PlayMaker.FsmVar::get_NamedVar(v139.fsmVar);\n\tv125 = HutongGames.PlayMaker.NamedVariable::get_UsesVariable(v299);\n\tv307 = v125 == 0;\n\tif (v307) goto L_00A2;\n\tv140 = v139.fsmVar;\n\tv315 = HutongGames.PlayMaker.FsmVariables::GetVariable(fsm.variables, v140.variableName);\n\tHutongGames.PlayMaker.FsmVar::set_NamedVar(v140, v315);\nL_00A2:\n\tv179 = v152.Length;\n\tv78 = v78 + 1;\n\tv257 = v78 < v152.Length;\n\tif (v257) goto L_0057;\nL_00B9:\n\treturn v193[v182[paramIndex @ X2 (System.Int32)]];\n\tthrow System.NullReferenceException;\n\tv154 = new System.NullReferenceException();\nL_00BD:\n\tv181 = new System.IndexOutOfRangeException();\n\tthrow v181;\n\treturn returnVal1;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmTemplateControl GetFsmTemplateControl(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmTemplateControl> list2 = fsmTemplateControlParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmTemplateControl[] items2 = list2._items;
			FsmTemplateControl fsmTemplateControl = items2[items[paramIndex]];
			FsmVarOverride[] fsmVarOverrides = fsmTemplateControl.fsmVarOverrides;
			if (fsmTemplateControl.fsmVarOverrides != null)
			{
				int num3 = fsmVarOverrides.Length;
				if (fsmVarOverrides.Length >= 1)
				{
					int num4 = 0;
					do
					{
						if (num4 < num3)
						{
							FsmTemplate fsmTemplate = fsmTemplateControl.fsmTemplate;
							FsmVarOverride fsmVarOverride = fsmVarOverrides[num4];
							if ((object)fsmTemplateControl.fsmTemplate != null && fsmTemplate.fsm != null && fsmVarOverride.variable.UsesVariable)
							{
								FsmTemplate fsmTemplate2 = fsmTemplateControl.fsmTemplate;
								Fsm fsm2 = fsmTemplate2.fsm;
								NamedVariable variable = fsmVarOverride.variable;
								NamedVariable variable2 = fsm2.Variables.GetVariable(variable.Name);
								fsmVarOverride.variable = variable2;
							}
							NamedVariable namedVar = fsmVarOverride.fsmVar.NamedVar;
							if (namedVar.UsesVariable)
							{
								FsmVar fsmVar = fsmVarOverride.fsmVar;
								NamedVariable variable3 = fsm.Variables.GetVariable(fsmVar.variableName);
								fsmVar.NamedVar = variable3;
							}
							num3 = fsmVarOverrides.Length;
							num4++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num4 < fsmVarOverrides.Length);
				}
			}
			return items2[items[paramIndex]];
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0x9CEB98", Offset = "0x9CEB98", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EED8C8]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219EE]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmVarParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv129 = v45._items;\n\tv134 = v48._size < v129[paramIndex @ X2 (System.Int32)];\n\tv91 = ~v134;\n\tv88 = v48._size - v129[paramIndex @ X2 (System.Int32)];\n\tv82 = v88 == 0;\n\tv135 = ~v82;\n\tv67 = v91 & v135;\n\tif (v67) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv138 = v48._items;\n\tv141 = v138[v129[paramIndex @ X2 (System.Int32)]] == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0051;\n\tv95 = new HutongGames.PlayMaker.FsmVar();\n\tHutongGames.PlayMaker.FsmVar::.ctor(v95);\nL_0051:\n\tv96 = System.String::IsNullOrEmpty(v104.variableName);\n\tv181 = v96 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_006A;\n\tv189 = HutongGames.PlayMaker.FsmVariables::GetVariable(fsm.variables, v104.variableName);\n\tHutongGames.PlayMaker.FsmVar::set_NamedVar(v104, v189);\nL_006A:\n\treturn v104;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmVar GetFsmVar(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmVar> list2 = fsmVarParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmVar[] items2 = list2._items;
			bool flag9 = items2[items[paramIndex]] == null;
			bool flag10 = !flag9;
			FsmVar fsmVar = items2[items[paramIndex]];
			if (!flag10)
			{
				FsmVar fsmVar2 = new FsmVar();
				fsmVar = fsmVar2;
			}
			if (!string.IsNullOrEmpty(fsmVar.variableName))
			{
				NamedVariable variable = fsm.Variables.GetVariable(fsmVar.variableName);
				fsmVar.NamedVar = variable;
			}
			return fsmVar;
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0x9CED9C", Offset = "0x9CED9C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFA260]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219EF]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmArrayParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv111 = v45._items;\n\tv116 = v48._size < v111[paramIndex @ X2 (System.Int32)];\n\tv91 = ~v116;\n\tv88 = v48._size - v111[paramIndex @ X2 (System.Int32)];\n\tv82 = v88 == 0;\n\tv117 = ~v82;\n\tv67 = v91 & v117;\n\tif (v67) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv156 = v48._items;\n\tv159 = v156[v111[paramIndex @ X2 (System.Int32)]] == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0051;\n\tv95 = new HutongGames.PlayMaker.FsmArray();\n\tHutongGames.PlayMaker.FsmArray::.ctor(v95);\nL_0051:\n\tv96 = System.String::IsNullOrEmpty(v104.name);\n\tv137 = v96 == 0;\n\tif (v137) goto L_0069;\n\treturn v104;\nL_0069:\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmArray(fsm, v104.name);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmArray GetFsmArray(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmArray> list2 = fsmArrayParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmArray[] items2 = list2._items;
			bool flag9 = items2[items[paramIndex]] == null;
			bool flag10 = !flag9;
			FsmArray fsmArray = items2[items[paramIndex]];
			if (!flag10)
			{
				FsmArray fsmArray2 = new FsmArray();
				fsmArray = fsmArray2;
			}
			if (string.IsNullOrEmpty(fsmArray.Name))
			{
				return fsmArray;
			}
			return fsm.GetFsmArray(fsmArray.Name);
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0x9CECA0", Offset = "0x9CECA0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EAD9A0]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F0]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmEnumParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv111 = v45._items;\n\tv116 = v48._size < v111[paramIndex @ X2 (System.Int32)];\n\tv91 = ~v116;\n\tv88 = v48._size - v111[paramIndex @ X2 (System.Int32)];\n\tv82 = v88 == 0;\n\tv117 = ~v82;\n\tv67 = v91 & v117;\n\tif (v67) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv156 = v48._items;\n\tv159 = v156[v111[paramIndex @ X2 (System.Int32)]] == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0051;\n\tv95 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v95);\nL_0051:\n\tv96 = System.String::IsNullOrEmpty(v104.name);\n\tv137 = v96 == 0;\n\tif (v137) goto L_0069;\n\treturn v104;\nL_0069:\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmEnum(fsm, v104.name);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmEnum GetFsmEnum(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmEnum> list2 = fsmEnumParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmEnum[] items2 = list2._items;
			bool flag9 = items2[items[paramIndex]] == null;
			bool flag10 = !flag9;
			FsmEnum fsmEnum = items2[items[paramIndex]];
			if (!flag10)
			{
				FsmEnum fsmEnum2 = new FsmEnum();
				fsmEnum = fsmEnum2;
			}
			if (string.IsNullOrEmpty(fsmEnum.Name))
			{
				return fsmEnum;
			}
			return fsm.GetFsmEnum(fsmEnum.Name);
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0x9CE63C", Offset = "0x9CE63C", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC9228]);\n\tv27 = *([v26 @ X8_v56]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F1]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.functionCallParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv227 = v45._items;\n\tv232 = v48._size < v227[paramIndex @ X2 (System.Int32)];\n\tv116 = ~v232;\n\tv113 = v48._size - v227[paramIndex @ X2 (System.Int32)];\n\tv107 = v113 == 0;\n\tv233 = ~v107;\n\tv92 = v116 & v233;\n\tif (v92) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv265 = v48._items;\n\tv194 = v265[v227[paramIndex @ X2 (System.Int32)]];\n\tv267 = v265[v227[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v267) goto L_0153;\n\tv196 = v194.BoolParameter;\n\tv121 = System.String::IsNullOrEmpty(v196.name);\n\tv276 = v121 == 0;\n\tv277 = ~v276;\n\tif (v277) goto L_0058;\n\tv197 = v194.BoolParameter;\n\tv284 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v197.name);\n\tv194.BoolParameter = v284;\nL_0058:\n\tv211 = v194.FloatParameter;\n\tv122 = System.String::IsNullOrEmpty(v211.name);\n\tv290 = v122 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_006B;\n\tv198 = v194.FloatParameter;\n\tv293 = HutongGames.PlayMaker.Fsm::GetFsmFloat(fsm, v198.name);\n\tv194.FloatParameter = v293;\nL_006B:\n\tv212 = v194.GameObjectParameter;\n\tv123 = System.String::IsNullOrEmpty(v212.name);\n\tv299 = v123 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_007E;\n\tv199 = v194.GameObjectParameter;\n\tv302 = HutongGames.PlayMaker.Fsm::GetFsmGameObject(fsm, v199.name);\n\tv194.GameObjectParameter = v302;\nL_007E:\n\tv213 = v194.IntParameter;\n\tv124 = System.String::IsNullOrEmpty(v213.name);\n\tv308 = v124 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_0091;\n\tv200 = v194.IntParameter;\n\tv311 = HutongGames.PlayMaker.Fsm::GetFsmInt(fsm, v200.name);\n\tv194.IntParameter = v311;\nL_0091:\n\tv214 = v194.MaterialParameter;\n\tv125 = System.String::IsNullOrEmpty(v214.name);\n\tv317 = v125 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_00A4;\n\tv201 = v194.MaterialParameter;\n\tv320 = HutongGames.PlayMaker.Fsm::GetFsmMaterial(fsm, v201.name);\n\tv194.MaterialParameter = v320;\nL_00A4:\n\tv215 = v194.ObjectParameter;\n\tv126 = System.String::IsNullOrEmpty(v215.name);\n\tv326 = v126 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_00B7;\n\tv202 = v194.ObjectParameter;\n\tv329 = HutongGames.PlayMaker.Fsm::GetFsmObject(fsm, v202.name);\n\tv194.ObjectParameter = v329;\nL_00B7:\n\tv216 = v194.QuaternionParameter;\n\tv127 = System.String::IsNullOrEmpty(v216.name);\n\tv335 = v127 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_00CA;\n\tv203 = v194.QuaternionParameter;\n\tv338 = HutongGames.PlayMaker.Fsm::GetFsmQuaternion(fsm, v203.name);\n\tv194.QuaternionParameter = v338;\nL_00CA:\n\tv217 = v194.RectParamater;\n\tv128 = System.String::IsNullOrEmpty(v217.name);\n\tv344 = v128 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_00DD;\n\tv204 = v194.RectParamater;\n\tv347 = HutongGames.PlayMaker.Fsm::GetFsmRect(fsm, v204.name);\n\tv194.RectParamater = v347;\nL_00DD:\n\tv218 = v194.StringParameter;\n\tv129 = System.String::IsNullOrEmpty(v218.name);\n\tv353 = v129 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00F0;\n\tv205 = v194.StringParameter;\n\tv356 = HutongGames.PlayMaker.Fsm::GetFsmString(fsm, v205.name);\n\tv194.StringParameter = v356;\nL_00F0:\n\tv219 = v194.TextureParameter;\n\tv130 = System.String::IsNullOrEmpty(v219.name);\n\tv362 = v130 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_0103;\n\tv206 = v194.TextureParameter;\n\tv365 = HutongGames.PlayMaker.Fsm::GetFsmTexture(fsm, v206.name);\n\tv194.TextureParameter = v365;\nL_0103:\n\tv220 = v194.Vector2Parameter;\n\tv131 = System.String::IsNullOrEmpty(v220.name);\n\tv371 = v131 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0116;\n\tv207 = v194.Vector2Parameter;\n\tv374 = HutongGames.PlayMaker.Fsm::GetFsmVector2(fsm, v207.name);\n\tv194.Vector2Parameter = v374;\nL_0116:\n\tv221 = v194.Vector3Parameter;\n\tv132 = System.String::IsNullOrEmpty(v221.name);\n\tv380 = v132 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_0129;\n\tv208 = v194.Vector3Parameter;\n\tv383 = HutongGames.PlayMaker.Fsm::GetFsmVector3(fsm, v208.name);\n\tv194.Vector3Parameter = v383;\nL_0129:\n\tv222 = v194.EnumParameter;\n\tv133 = System.String::IsNullOrEmpty(v222.name);\n\tv389 = v133 == 0;\n\tv390 = ~v389;\n\tif (v390) goto L_013C;\n\tv209 = v194.EnumParameter;\n\tv392 = HutongGames.PlayMaker.Fsm::GetFsmEnum(fsm, v209.name);\n\tv194.EnumParameter = v392;\nL_013C:\n\tv223 = v194.ArrayParameter;\n\tv134 = System.String::IsNullOrEmpty(v223.name);\n\tv398 = v134 == 0;\n\tv281 = ~v398;\n\tif (v281) goto L_015F;\n\tv210 = v194.ArrayParameter;\n\tv280 = HutongGames.PlayMaker.Fsm::GetFsmArray(fsm, v210.name);\n\tv194.ArrayParameter = v280;\n\tgoto L_015F;\nL_0153:\n\tv271 = new HutongGames.PlayMaker.FunctionCall();\n\tHutongGames.PlayMaker.FunctionCall::.ctor(v271);\nL_015F:\n\treturn v282;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 208 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FunctionCall GetFunctionCall(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FunctionCall> list2 = functionCallParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FunctionCall[] items2 = list2._items;
			FunctionCall functionCall = items2[items[paramIndex]];
			FunctionCall result;
			if (items2[items[paramIndex]] != null)
			{
				FsmBool boolParameter = functionCall.BoolParameter;
				if (!string.IsNullOrEmpty(boolParameter.Name))
				{
					FsmBool boolParameter2 = functionCall.BoolParameter;
					FsmBool fsmBool = fsm.GetFsmBool(boolParameter2.Name);
					functionCall.BoolParameter = fsmBool;
				}
				FsmFloat floatParameter = functionCall.FloatParameter;
				if (!string.IsNullOrEmpty(floatParameter.Name))
				{
					FsmFloat floatParameter2 = functionCall.FloatParameter;
					FsmFloat fsmFloat = fsm.GetFsmFloat(floatParameter2.Name);
					functionCall.FloatParameter = fsmFloat;
				}
				FsmGameObject gameObjectParameter = functionCall.GameObjectParameter;
				if (!string.IsNullOrEmpty(gameObjectParameter.Name))
				{
					FsmGameObject gameObjectParameter2 = functionCall.GameObjectParameter;
					FsmGameObject fsmGameObject = fsm.GetFsmGameObject(gameObjectParameter2.Name);
					functionCall.GameObjectParameter = fsmGameObject;
				}
				FsmInt intParameter = functionCall.IntParameter;
				if (!string.IsNullOrEmpty(intParameter.Name))
				{
					FsmInt intParameter2 = functionCall.IntParameter;
					FsmInt fsmInt = fsm.GetFsmInt(intParameter2.Name);
					functionCall.IntParameter = fsmInt;
				}
				FsmMaterial materialParameter = functionCall.MaterialParameter;
				if (!string.IsNullOrEmpty(materialParameter.Name))
				{
					FsmMaterial materialParameter2 = functionCall.MaterialParameter;
					FsmMaterial fsmMaterial = fsm.GetFsmMaterial(materialParameter2.Name);
					functionCall.MaterialParameter = fsmMaterial;
				}
				FsmObject objectParameter = functionCall.ObjectParameter;
				if (!string.IsNullOrEmpty(objectParameter.Name))
				{
					FsmObject objectParameter2 = functionCall.ObjectParameter;
					FsmObject fsmObject = fsm.GetFsmObject(objectParameter2.Name);
					functionCall.ObjectParameter = fsmObject;
				}
				FsmQuaternion quaternionParameter = functionCall.QuaternionParameter;
				if (!string.IsNullOrEmpty(quaternionParameter.Name))
				{
					FsmQuaternion quaternionParameter2 = functionCall.QuaternionParameter;
					FsmQuaternion fsmQuaternion = fsm.GetFsmQuaternion(quaternionParameter2.Name);
					functionCall.QuaternionParameter = fsmQuaternion;
				}
				FsmRect rectParamater = functionCall.RectParamater;
				if (!string.IsNullOrEmpty(rectParamater.Name))
				{
					FsmRect rectParamater2 = functionCall.RectParamater;
					FsmRect fsmRect = fsm.GetFsmRect(rectParamater2.Name);
					functionCall.RectParamater = fsmRect;
				}
				FsmString stringParameter = functionCall.StringParameter;
				if (!string.IsNullOrEmpty(stringParameter.Name))
				{
					FsmString stringParameter2 = functionCall.StringParameter;
					FsmString fsmString = fsm.GetFsmString(stringParameter2.Name);
					functionCall.StringParameter = fsmString;
				}
				FsmTexture textureParameter = functionCall.TextureParameter;
				if (!string.IsNullOrEmpty(textureParameter.Name))
				{
					FsmTexture textureParameter2 = functionCall.TextureParameter;
					FsmTexture fsmTexture = fsm.GetFsmTexture(textureParameter2.Name);
					functionCall.TextureParameter = fsmTexture;
				}
				FsmVector2 vector2Parameter = functionCall.Vector2Parameter;
				if (!string.IsNullOrEmpty(vector2Parameter.Name))
				{
					FsmVector2 vector2Parameter2 = functionCall.Vector2Parameter;
					FsmVector2 fsmVector = fsm.GetFsmVector2(vector2Parameter2.Name);
					functionCall.Vector2Parameter = fsmVector;
				}
				FsmVector3 vector3Parameter = functionCall.Vector3Parameter;
				if (!string.IsNullOrEmpty(vector3Parameter.Name))
				{
					FsmVector3 vector3Parameter2 = functionCall.Vector3Parameter;
					FsmVector3 fsmVector2 = fsm.GetFsmVector3(vector3Parameter2.Name);
					functionCall.Vector3Parameter = fsmVector2;
				}
				FsmEnum enumParameter = functionCall.EnumParameter;
				if (!string.IsNullOrEmpty(enumParameter.Name))
				{
					FsmEnum enumParameter2 = functionCall.EnumParameter;
					FsmEnum fsmEnum = fsm.GetFsmEnum(enumParameter2.Name);
					functionCall.EnumParameter = fsmEnum;
				}
				FsmArray arrayParameter = functionCall.ArrayParameter;
				bool flag9 = string.IsNullOrEmpty(arrayParameter.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					FsmArray arrayParameter2 = functionCall.ArrayParameter;
					FsmArray fsmArray = fsm.GetFsmArray(arrayParameter2.Name);
					functionCall.ArrayParameter = fsmArray;
					result = items2[items[paramIndex]];
				}
			}
			else
			{
				FunctionCall functionCall2 = new FunctionCall();
				result = functionCall2;
			}
			return result;
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0x9CEE98", Offset = "0x9CEE98", Length = "0x410")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC23C8]);\n\tv27 = *([v26 @ X8_v62]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F2]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmPropertyParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv245 = v45._items;\n\tv250 = v48._size < v245[paramIndex @ X2 (System.Int32)];\n\tv120 = ~v250;\n\tv117 = v48._size - v245[paramIndex @ X2 (System.Int32)];\n\tv111 = v117 == 0;\n\tv251 = ~v111;\n\tv96 = v120 & v251;\n\tif (v96) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv283 = v48._items;\n\tv208 = v283[v245[paramIndex @ X2 (System.Int32)]];\n\tv285 = v283[v245[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v285) goto L_0179;\n\tv210 = v208.TargetObject;\n\tv125 = System.String::IsNullOrEmpty(v210.name);\n\tv294 = v125 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0058;\n\tv211 = v208.TargetObject;\n\tv302 = HutongGames.PlayMaker.Fsm::GetFsmObject(fsm, v211.name);\n\tv208.TargetObject = v302;\nL_0058:\n\tv227 = v208.BoolParameter;\n\tv126 = System.String::IsNullOrEmpty(v227.name);\n\tv308 = v126 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_006B;\n\tv212 = v208.BoolParameter;\n\tv311 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v212.name);\n\tv208.BoolParameter = v311;\nL_006B:\n\tv228 = v208.FloatParameter;\n\tv127 = System.String::IsNullOrEmpty(v228.name);\n\tv317 = v127 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_007E;\n\tv213 = v208.FloatParameter;\n\tv320 = HutongGames.PlayMaker.Fsm::GetFsmFloat(fsm, v213.name);\n\tv208.FloatParameter = v320;\nL_007E:\n\tv229 = v208.GameObjectParameter;\n\tv128 = System.String::IsNullOrEmpty(v229.name);\n\tv326 = v128 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_0091;\n\tv214 = v208.GameObjectParameter;\n\tv329 = HutongGames.PlayMaker.Fsm::GetFsmGameObject(fsm, v214.name);\n\tv208.GameObjectParameter = v329;\nL_0091:\n\tv230 = v208.IntParameter;\n\tv129 = System.String::IsNullOrEmpty(v230.name);\n\tv335 = v129 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_00A4;\n\tv215 = v208.IntParameter;\n\tv338 = HutongGames.PlayMaker.Fsm::GetFsmInt(fsm, v215.name);\n\tv208.IntParameter = v338;\nL_00A4:\n\tv231 = v208.MaterialParameter;\n\tv130 = System.String::IsNullOrEmpty(v231.name);\n\tv344 = v130 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_00B7;\n\tv216 = v208.MaterialParameter;\n\tv347 = HutongGames.PlayMaker.Fsm::GetFsmMaterial(fsm, v216.name);\n\tv208.MaterialParameter = v347;\nL_00B7:\n\tv232 = v208.ObjectParameter;\n\tv131 = System.String::IsNullOrEmpty(v232.name);\n\tv353 = v131 == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00CA;\n\tv217 = v208.ObjectParameter;\n\tv356 = HutongGames.PlayMaker.Fsm::GetFsmObject(fsm, v217.name);\n\tv208.ObjectParameter = v356;\nL_00CA:\n\tv233 = v208.QuaternionParameter;\n\tv132 = System.String::IsNullOrEmpty(v233.name);\n\tv362 = v132 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_00DD;\n\tv218 = v208.QuaternionParameter;\n\tv365 = HutongGames.PlayMaker.Fsm::GetFsmQuaternion(fsm, v218.name);\n\tv208.QuaternionParameter = v365;\nL_00DD:\n\tv234 = v208.RectParamater;\n\tv133 = System.String::IsNullOrEmpty(v234.name);\n\tv371 = v133 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_00F0;\n\tv219 = v208.RectParamater;\n\tv374 = HutongGames.PlayMaker.Fsm::GetFsmRect(fsm, v219.name);\n\tv208.RectParamater = v374;\nL_00F0:\n\tv235 = v208.StringParameter;\n\tv134 = System.String::IsNullOrEmpty(v235.name);\n\tv380 = v134 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_0103;\n\tv220 = v208.StringParameter;\n\tv383 = HutongGames.PlayMaker.Fsm::GetFsmString(fsm, v220.name);\n\tv208.StringParameter = v383;\nL_0103:\n\tv236 = v208.TextureParameter;\n\tv135 = System.String::IsNullOrEmpty(v236.name);\n\tv389 = v135 == 0;\n\tv390 = ~v389;\n\tif (v390) goto L_0116;\n\tv221 = v208.TextureParameter;\n\tv392 = HutongGames.PlayMaker.Fsm::GetFsmTexture(fsm, v221.name);\n\tv208.TextureParameter = v392;\nL_0116:\n\tv237 = v208.ColorParameter;\n\tv136 = System.String::IsNullOrEmpty(v237.name);\n\tv398 = v136 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_0129;\n\tv222 = v208.ColorParameter;\n\tv401 = HutongGames.PlayMaker.Fsm::GetFsmColor(fsm, v222.name);\n\tv208.ColorParameter = v401;\nL_0129:\n\tv238 = v208.Vector2Parameter;\n\tv137 = System.String::IsNullOrEmpty(v238.name);\n\tv407 = v137 == 0;\n\tv408 = ~v407;\n\tif (v408) goto L_013C;\n\tv223 = v208.Vector2Parameter;\n\tv410 = HutongGames.PlayMaker.Fsm::GetFsmVector2(fsm, v223.name);\n\tv208.Vector2Parameter = v410;\nL_013C:\n\tv239 = v208.Vector3Parameter;\n\tv138 = System.String::IsNullOrEmpty(v239.name);\n\tv416 = v138 == 0;\n\tv417 = ~v416;\n\tif (v417) goto L_014F;\n\tv224 = v208.Vector3Parameter;\n\tv419 = HutongGames.PlayMaker.Fsm::GetFsmVector3(fsm, v224.name);\n\tv208.Vector3Parameter = v419;\nL_014F:\n\tv240 = v208.EnumParameter;\n\tv139 = System.String::IsNullOrEmpty(v240.name);\n\tv425 = v139 == 0;\n\tv426 = ~v425;\n\tif (v426) goto L_0162;\n\tv225 = v208.EnumParameter;\n\tv428 = HutongGames.PlayMaker.Fsm::GetFsmEnum(fsm, v225.name);\n\tv208.EnumParameter = v428;\nL_0162:\n\tv241 = v208.ArrayParameter;\n\tv140 = System.String::IsNullOrEmpty(v241.name);\n\tv434 = v140 == 0;\n\tv299 = ~v434;\n\tif (v299) goto L_0185;\n\tv226 = v208.ArrayParameter;\n\tv298 = HutongGames.PlayMaker.Fsm::GetFsmArray(fsm, v226.name);\n\tv208.ArrayParameter = v298;\n\tgoto L_0185;\nL_0179:\n\tv289 = new HutongGames.PlayMaker.FsmProperty();\n\tHutongGames.PlayMaker.FsmProperty::.ctor(v289);\nL_0185:\n\treturn v300;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 230 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmProperty GetFsmProperty(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmProperty> list2 = fsmPropertyParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmProperty[] items2 = list2._items;
			FsmProperty fsmProperty = items2[items[paramIndex]];
			FsmProperty result;
			if (items2[items[paramIndex]] != null)
			{
				FsmObject targetObject = fsmProperty.TargetObject;
				if (!string.IsNullOrEmpty(targetObject.Name))
				{
					FsmObject targetObject2 = fsmProperty.TargetObject;
					FsmObject fsmObject = fsm.GetFsmObject(targetObject2.Name);
					fsmProperty.TargetObject = fsmObject;
				}
				FsmBool boolParameter = fsmProperty.BoolParameter;
				if (!string.IsNullOrEmpty(boolParameter.Name))
				{
					FsmBool boolParameter2 = fsmProperty.BoolParameter;
					FsmBool fsmBool = fsm.GetFsmBool(boolParameter2.Name);
					fsmProperty.BoolParameter = fsmBool;
				}
				FsmFloat floatParameter = fsmProperty.FloatParameter;
				if (!string.IsNullOrEmpty(floatParameter.Name))
				{
					FsmFloat floatParameter2 = fsmProperty.FloatParameter;
					FsmFloat fsmFloat = fsm.GetFsmFloat(floatParameter2.Name);
					fsmProperty.FloatParameter = fsmFloat;
				}
				FsmGameObject gameObjectParameter = fsmProperty.GameObjectParameter;
				if (!string.IsNullOrEmpty(gameObjectParameter.Name))
				{
					FsmGameObject gameObjectParameter2 = fsmProperty.GameObjectParameter;
					FsmGameObject fsmGameObject = fsm.GetFsmGameObject(gameObjectParameter2.Name);
					fsmProperty.GameObjectParameter = fsmGameObject;
				}
				FsmInt intParameter = fsmProperty.IntParameter;
				if (!string.IsNullOrEmpty(intParameter.Name))
				{
					FsmInt intParameter2 = fsmProperty.IntParameter;
					FsmInt fsmInt = fsm.GetFsmInt(intParameter2.Name);
					fsmProperty.IntParameter = fsmInt;
				}
				FsmMaterial materialParameter = fsmProperty.MaterialParameter;
				if (!string.IsNullOrEmpty(materialParameter.Name))
				{
					FsmMaterial materialParameter2 = fsmProperty.MaterialParameter;
					FsmMaterial fsmMaterial = fsm.GetFsmMaterial(materialParameter2.Name);
					fsmProperty.MaterialParameter = fsmMaterial;
				}
				FsmObject objectParameter = fsmProperty.ObjectParameter;
				if (!string.IsNullOrEmpty(objectParameter.Name))
				{
					FsmObject objectParameter2 = fsmProperty.ObjectParameter;
					FsmObject fsmObject2 = fsm.GetFsmObject(objectParameter2.Name);
					fsmProperty.ObjectParameter = fsmObject2;
				}
				FsmQuaternion quaternionParameter = fsmProperty.QuaternionParameter;
				if (!string.IsNullOrEmpty(quaternionParameter.Name))
				{
					FsmQuaternion quaternionParameter2 = fsmProperty.QuaternionParameter;
					FsmQuaternion fsmQuaternion = fsm.GetFsmQuaternion(quaternionParameter2.Name);
					fsmProperty.QuaternionParameter = fsmQuaternion;
				}
				FsmRect rectParamater = fsmProperty.RectParamater;
				if (!string.IsNullOrEmpty(rectParamater.Name))
				{
					FsmRect rectParamater2 = fsmProperty.RectParamater;
					FsmRect fsmRect = fsm.GetFsmRect(rectParamater2.Name);
					fsmProperty.RectParamater = fsmRect;
				}
				FsmString stringParameter = fsmProperty.StringParameter;
				if (!string.IsNullOrEmpty(stringParameter.Name))
				{
					FsmString stringParameter2 = fsmProperty.StringParameter;
					FsmString fsmString = fsm.GetFsmString(stringParameter2.Name);
					fsmProperty.StringParameter = fsmString;
				}
				FsmTexture textureParameter = fsmProperty.TextureParameter;
				if (!string.IsNullOrEmpty(textureParameter.Name))
				{
					FsmTexture textureParameter2 = fsmProperty.TextureParameter;
					FsmTexture fsmTexture = fsm.GetFsmTexture(textureParameter2.Name);
					fsmProperty.TextureParameter = fsmTexture;
				}
				FsmColor colorParameter = fsmProperty.ColorParameter;
				if (!string.IsNullOrEmpty(colorParameter.Name))
				{
					FsmColor colorParameter2 = fsmProperty.ColorParameter;
					FsmColor fsmColor = fsm.GetFsmColor(colorParameter2.Name);
					fsmProperty.ColorParameter = fsmColor;
				}
				FsmVector2 vector2Parameter = fsmProperty.Vector2Parameter;
				if (!string.IsNullOrEmpty(vector2Parameter.Name))
				{
					FsmVector2 vector2Parameter2 = fsmProperty.Vector2Parameter;
					FsmVector2 fsmVector = fsm.GetFsmVector2(vector2Parameter2.Name);
					fsmProperty.Vector2Parameter = fsmVector;
				}
				FsmVector3 vector3Parameter = fsmProperty.Vector3Parameter;
				if (!string.IsNullOrEmpty(vector3Parameter.Name))
				{
					FsmVector3 vector3Parameter2 = fsmProperty.Vector3Parameter;
					FsmVector3 fsmVector2 = fsm.GetFsmVector3(vector3Parameter2.Name);
					fsmProperty.Vector3Parameter = fsmVector2;
				}
				FsmEnum enumParameter = fsmProperty.EnumParameter;
				if (!string.IsNullOrEmpty(enumParameter.Name))
				{
					FsmEnum enumParameter2 = fsmProperty.EnumParameter;
					FsmEnum fsmEnum = fsm.GetFsmEnum(enumParameter2.Name);
					fsmProperty.EnumParameter = fsmEnum;
				}
				FsmArray arrayParameter = fsmProperty.ArrayParameter;
				bool flag9 = string.IsNullOrEmpty(arrayParameter.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					FsmArray arrayParameter2 = fsmProperty.ArrayParameter;
					FsmArray fsmArray = fsm.GetFsmArray(arrayParameter2.Name);
					fsmProperty.ArrayParameter = fsmArray;
					result = items2[items[paramIndex]];
				}
			}
			else
			{
				FsmProperty fsmProperty2 = new FsmProperty();
				result = fsmProperty2;
			}
			return result;
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0x9CF2A8", Offset = "0x9CF2A8", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F0AED8]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F3]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmEventTargetParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv144 = v45._items;\n\tv149 = v48._size < v144[paramIndex @ X2 (System.Int32)];\n\tv97 = ~v149;\n\tv94 = v48._size - v144[paramIndex @ X2 (System.Int32)];\n\tv88 = v94 == 0;\n\tv150 = ~v88;\n\tv73 = v97 & v150;\n\tif (v73) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv182 = v48._items;\n\tv128 = v182[v144[paramIndex @ X2 (System.Int32)]];\n\tv184 = v182[v144[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v184) goto L_0099;\n\tv130 = v128.excludeSelf;\n\tv102 = System.String::IsNullOrEmpty(v130.name);\n\tv193 = v102 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0058;\n\tv131 = v128.excludeSelf;\n\tv203 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v131.name);\n\tv128.excludeSelf = v203;\nL_0058:\n\tv135 = v128.gameObject;\n\tv132 = v135.gameObject;\n\tv104 = System.String::IsNullOrEmpty(v132.name);\n\tv209 = v104 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_006F;\n\tv139 = v128.gameObject;\n\tv105 = HutongGames.PlayMaker.Fsm::GetFsmGameObject(fsm, v132.name);\n\tv139.gameObject = v105;\nL_006F:\n\tv136 = v128.fsmName;\n\tv106 = System.String::IsNullOrEmpty(v136.name);\n\tv215 = v106 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0082;\n\tv133 = v128.fsmName;\n\tv218 = HutongGames.PlayMaker.Fsm::GetFsmString(fsm, v133.name);\n\tv128.fsmName = v218;\nL_0082:\n\tv137 = v128.sendToChildren;\n\tv107 = System.String::IsNullOrEmpty(v137.name);\n\tv224 = v107 == 0;\n\tv198 = ~v224;\n\tif (v198) goto L_00A5;\n\tv134 = v128.sendToChildren;\n\tv197 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v134.name);\n\tv128.sendToChildren = v197;\n\tgoto L_00A5;\nL_0099:\n\tv188 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v188);\nL_00A5:\n\treturn v200;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmEventTarget GetFsmEventTarget(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmEventTarget> list2 = fsmEventTargetParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmEventTarget[] items2 = list2._items;
			FsmEventTarget fsmEventTarget = items2[items[paramIndex]];
			FsmEventTarget result;
			if (items2[items[paramIndex]] != null)
			{
				FsmBool excludeSelf = fsmEventTarget.excludeSelf;
				if (!string.IsNullOrEmpty(excludeSelf.Name))
				{
					FsmBool excludeSelf2 = fsmEventTarget.excludeSelf;
					FsmBool fsmBool = fsm.GetFsmBool(excludeSelf2.Name);
					fsmEventTarget.excludeSelf = fsmBool;
				}
				FsmOwnerDefault gameObject = fsmEventTarget.gameObject;
				FsmGameObject gameObject2 = gameObject.GameObject;
				if (!string.IsNullOrEmpty(gameObject2.Name))
				{
					FsmOwnerDefault gameObject3 = fsmEventTarget.gameObject;
					FsmGameObject fsmGameObject = fsm.GetFsmGameObject(gameObject2.Name);
					gameObject3.GameObject = fsmGameObject;
				}
				FsmString fsmName = fsmEventTarget.fsmName;
				if (!string.IsNullOrEmpty(fsmName.Name))
				{
					FsmString fsmName2 = fsmEventTarget.fsmName;
					FsmString fsmString = fsm.GetFsmString(fsmName2.Name);
					fsmEventTarget.fsmName = fsmString;
				}
				FsmBool sendToChildren = fsmEventTarget.sendToChildren;
				bool flag9 = string.IsNullOrEmpty(sendToChildren.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					FsmBool sendToChildren2 = fsmEventTarget.sendToChildren;
					FsmBool fsmBool2 = fsm.GetFsmBool(sendToChildren2.Name);
					fsmEventTarget.sendToChildren = fsmBool2;
					result = items2[items[paramIndex]];
				}
			}
			else
			{
				FsmEventTarget fsmEventTarget2 = new FsmEventTarget();
				result = fsmEventTarget2;
			}
			return result;
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0x9CF454", Offset = "0x9CF454", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC7D00]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F4]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.layoutOptionParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv119 = v45._items;\n\tv124 = v48._size < v119[paramIndex @ X2 (System.Int32)];\n\tv92 = ~v124;\n\tv89 = v48._size - v119[paramIndex @ X2 (System.Int32)];\n\tv83 = v89 == 0;\n\tv125 = ~v83;\n\tv68 = v92 & v125;\n\tif (v68) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv157 = v48._items;\n\tv110 = v157[v119[paramIndex @ X2 (System.Int32)]];\n\tv159 = v157[v119[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v159) goto L_006F;\n\tv112 = v110.boolParam;\n\tv97 = System.String::IsNullOrEmpty(v112.name);\n\tv168 = v97 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_0058;\n\tv113 = v110.boolParam;\n\tv176 = HutongGames.PlayMaker.Fsm::GetFsmBool(fsm, v113.name);\n\tv110.boolParam = v176;\nL_0058:\n\tv115 = v110.floatParam;\n\tv98 = System.String::IsNullOrEmpty(v115.name);\n\tv182 = v98 == 0;\n\tv173 = ~v182;\n\tif (v173) goto L_007B;\n\tv114 = v110.floatParam;\n\tv172 = HutongGames.PlayMaker.Fsm::GetFsmFloat(fsm, v114.name);\n\tv110.floatParam = v172;\n\tgoto L_007B;\nL_006F:\n\tv163 = new HutongGames.PlayMaker.LayoutOption();\n\tHutongGames.PlayMaker.LayoutOption::.ctor(v163);\nL_007B:\n\treturn v174;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private LayoutOption GetLayoutOption(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<LayoutOption> list2 = layoutOptionParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			LayoutOption[] items2 = list2._items;
			LayoutOption layoutOption = items2[items[paramIndex]];
			LayoutOption result;
			if (items2[items[paramIndex]] != null)
			{
				FsmBool boolParam = layoutOption.boolParam;
				if (!string.IsNullOrEmpty(boolParam.Name))
				{
					FsmBool boolParam2 = layoutOption.boolParam;
					FsmBool fsmBool = fsm.GetFsmBool(boolParam2.Name);
					layoutOption.boolParam = fsmBool;
				}
				FsmFloat floatParam = layoutOption.floatParam;
				bool flag9 = string.IsNullOrEmpty(floatParam.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					FsmFloat floatParam2 = layoutOption.floatParam;
					FsmFloat fsmFloat = fsm.GetFsmFloat(floatParam2.Name);
					layoutOption.floatParam = fsmFloat;
					result = items2[items[paramIndex]];
				}
			}
			else
			{
				LayoutOption layoutOption2 = new LayoutOption();
				result = layoutOption2;
			}
			return result;
		}

		[Token(Token = "0x6000303")]
		[Address(RVA = "0x9CF58C", Offset = "0x9CF58C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED7F20]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F5]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmOwnerDefaultParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv109 = v45._items;\n\tv114 = v48._size < v109[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v114;\n\tv87 = v48._size - v109[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv115 = ~v81;\n\tv66 = v90 & v115;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv147 = v48._items;\n\tv103 = v147[v109[paramIndex @ X2 (System.Int32)]];\n\tv149 = v147[v109[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v149) goto L_005D;\n\tv151 = v103.ownerOption == 0;\n\tif (v151) goto L_0069;\n\tv105 = v103.gameObject;\n\tv95 = System.String::IsNullOrEmpty(v105.name);\n\tv166 = v95 == 0;\n\tv160 = ~v166;\n\tif (v160) goto L_0069;\n\tv159 = HutongGames.PlayMaker.Fsm::GetFsmGameObject(fsm, v105.name);\n\tv103.gameObject = v159;\n\tgoto L_0069;\nL_005D:\n\tv155 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v155);\nL_0069:\n\treturn v162;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmOwnerDefault GetFsmOwnerDefault(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmOwnerDefault> list2 = fsmOwnerDefaultParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmOwnerDefault[] items2 = list2._items;
			FsmOwnerDefault fsmOwnerDefault = items2[items[paramIndex]];
			FsmOwnerDefault result;
			if (items2[items[paramIndex]] != null)
			{
				bool flag9 = fsmOwnerDefault.OwnerOption == OwnerDefaultOption.UseOwner;
				result = items2[items[paramIndex]];
				if (!flag9)
				{
					FsmGameObject gameObject = fsmOwnerDefault.GameObject;
					bool flag10 = string.IsNullOrEmpty(gameObject.Name);
					bool flag11 = !flag10;
					bool flag12 = !flag11;
					result = items2[items[paramIndex]];
					if (!flag12)
					{
						FsmGameObject fsmGameObject = fsm.GetFsmGameObject(gameObject.Name);
						fsmOwnerDefault.GameObject = fsmGameObject;
						result = items2[items[paramIndex]];
					}
				}
			}
			else
			{
				FsmOwnerDefault fsmOwnerDefault2 = new FsmOwnerDefault();
				result = fsmOwnerDefault2;
			}
			return result;
		}

		[Token(Token = "0x6000304")]
		[Address(RVA = "0x9CF694", Offset = "0x9CF694", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EEF2C8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F6]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmStringParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv106 = v45._items;\n\tv111 = v48._size < v106[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v111;\n\tv87 = v48._size - v106[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv112 = ~v81;\n\tv66 = v90 & v112;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv153 = v48._items;\n\tv100 = v153[v106[paramIndex @ X2 (System.Int32)]];\n\tv154 = v153[v106[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v154) goto L_005C;\n\tv94 = System.String::IsNullOrEmpty(v100.name);\n\tv161 = v94 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0068;\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmString(fsm, v100.name);\n\treturn returnVal3;\nL_005C:\n\tv159 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v159);\nL_0068:\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmString GetFsmString(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmString> list2 = fsmStringParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmString[] items2 = list2._items;
			FsmString fsmString = items2[items[paramIndex]];
			FsmString result;
			if (items2[items[paramIndex]] != null)
			{
				bool flag9 = string.IsNullOrEmpty(fsmString.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					return fsm.GetFsmString(fsmString.Name);
				}
			}
			else
			{
				FsmString fsmString2 = new FsmString();
				result = fsmString2;
			}
			return result;
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0x9CE30C", Offset = "0x9CE30C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EACA68]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F7]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmObjectParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv106 = v45._items;\n\tv111 = v48._size < v106[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v111;\n\tv87 = v48._size - v106[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv112 = ~v81;\n\tv66 = v90 & v112;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv153 = v48._items;\n\tv100 = v153[v106[paramIndex @ X2 (System.Int32)]];\n\tv154 = v153[v106[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v154) goto L_005C;\n\tv94 = System.String::IsNullOrEmpty(v100.name);\n\tv161 = v94 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0068;\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmObject(fsm, v100.name);\n\treturn returnVal3;\nL_005C:\n\tv159 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v159);\nL_0068:\n\treturn v166;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmObject GetFsmObject(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmObject> list2 = fsmObjectParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmObject[] items2 = list2._items;
			FsmObject fsmObject = items2[items[paramIndex]];
			FsmObject result;
			if (items2[items[paramIndex]] != null)
			{
				bool flag9 = string.IsNullOrEmpty(fsmObject.Name);
				bool flag10 = !flag9;
				bool flag11 = !flag10;
				result = items2[items[paramIndex]];
				if (!flag11)
				{
					return fsm.GetFsmObject(fsmObject.Name);
				}
			}
			else
			{
				FsmObject fsmObject2 = new FsmObject();
				result = fsmObject2;
			}
			return result;
		}

		[Token(Token = "0x6000306")]
		[Address(RVA = "0x9CE404", Offset = "0x9CE404", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F02E38]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F8]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmObjectParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv106 = v45._items;\n\tv111 = v48._size < v106[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v111;\n\tv87 = v48._size - v106[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv112 = ~v81;\n\tv66 = v90 & v112;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv155 = v48._items;\n\tv100 = v155[v106[paramIndex @ X2 (System.Int32)]];\n\tv156 = v155[v106[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v156) goto L_0057;\n\tv94 = System.String::IsNullOrEmpty(v100.name);\n\tv163 = v94 == 0;\n\tif (v163) goto L_006F;\n\tv169 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmMaterial::.ctor(v169, v155[v106[paramIndex @ X2 (System.Int32)]]);\n\tgoto L_0063;\nL_0057:\n\tv161 = new HutongGames.PlayMaker.FsmMaterial();\n\tHutongGames.PlayMaker.FsmMaterial::.ctor(v161);\nL_0063:\n\treturn v173;\nL_006F:\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmMaterial(fsm, v100.name);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmMaterial GetFsmMaterial(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmObject> list2 = fsmObjectParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmObject[] items2 = list2._items;
			FsmObject fsmObject = items2[items[paramIndex]];
			if (items2[items[paramIndex]] != null)
			{
				if (string.IsNullOrEmpty(fsmObject.Name))
				{
					return new FsmMaterial(items2[items[paramIndex]]);
				}
				return fsm.GetFsmMaterial(fsmObject.Name);
			}
			return new FsmMaterial();
		}

		[Token(Token = "0x6000307")]
		[Address(RVA = "0x9CE520", Offset = "0x9CE520", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE0BD8]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fsm, paramIndex, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20219F9]) = v44;\nL_0017:\n\tv45 = this.paramDataPos;\n\tv48 = this.fsmObjectParams;\n\tv49 = v45._size < paramIndex;\n\tv50 = ~v49;\n\tv51 = v45._size - paramIndex;\n\tv53 = v51 == 0;\n\tv58 = ~v53;\n\tv59 = v50 & v58;\n\tif (v59) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv106 = v45._items;\n\tv111 = v48._size < v106[paramIndex @ X2 (System.Int32)];\n\tv90 = ~v111;\n\tv87 = v48._size - v106[paramIndex @ X2 (System.Int32)];\n\tv81 = v87 == 0;\n\tv112 = ~v81;\n\tv66 = v90 & v112;\n\tif (v66) goto L_003F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003F:\n\tv155 = v48._items;\n\tv100 = v155[v106[paramIndex @ X2 (System.Int32)]];\n\tv156 = v155[v106[paramIndex @ X2 (System.Int32)]] == 0;\n\tif (v156) goto L_0057;\n\tv94 = System.String::IsNullOrEmpty(v100.name);\n\tv163 = v94 == 0;\n\tif (v163) goto L_006F;\n\tv169 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmTexture::.ctor(v169, v155[v106[paramIndex @ X2 (System.Int32)]]);\n\tgoto L_0063;\nL_0057:\n\tv161 = new HutongGames.PlayMaker.FsmTexture();\n\tHutongGames.PlayMaker.FsmTexture::.ctor(v161);\nL_0063:\n\treturn v173;\nL_006F:\n\treturnVal3 = HutongGames.PlayMaker.Fsm::GetFsmTexture(fsm, v100.name);\n\treturn returnVal3;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmTexture GetFsmTexture(Fsm fsm, int paramIndex)
		{
			List<int> list = paramDataPos;
			List<FsmObject> list2 = fsmObjectParams;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int[] items = list._items;
			bool flag5 = list2.Count < items[paramIndex];
			bool flag6 = !flag5;
			int num2 = list2.Count - items[paramIndex];
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			FsmObject[] items2 = list2._items;
			FsmObject fsmObject = items2[items[paramIndex]];
			if (items2[items[paramIndex]] != null)
			{
				if (string.IsNullOrEmpty(fsmObject.Name))
				{
					return new FsmTexture(items2[items[paramIndex]]);
				}
				return fsm.GetFsmTexture(fsmObject.Name);
			}
			return new FsmTexture();
		}

		[Token(Token = "0x6000308")]
		[Address(RVA = "0x9D0E00", Offset = "0x9D0E00", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB9308]);\n\tv19 = *([v18 @ X8_v38]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219FA]) = v38;\nL_0013:\n\tv39 = this.fsmArrayParams;\n\tv40 = this.fsmArrayParams == 0;\n\tif (v40) goto L_0024;\n\tv53 = v39._size > 0;\n\tif (v53) goto L_FFFFFFFF;\nL_0024:\n\tv75 = this.fsmEnumParams;\n\tv76 = this.fsmEnumParams == 0;\n\tif (v76) goto L_0035;\n\tv89 = v75._size > 0;\n\tif (v89) goto L_FFFFFFFF;\nL_0035:\n\tv210 = this.fsmFloatParams;\n\tv179 = this.fsmFloatParams == 0;\n\tif (v179) goto L_0046;\n\tv90 = v210._size > 0;\n\tif (v90) goto L_FFFFFFFF;\nL_0046:\n\tv265 = this.fsmIntParams;\n\tv180 = this.fsmIntParams == 0;\n\tif (v180) goto L_0057;\n\tv91 = v265._size > 0;\n\tif (v91) goto L_FFFFFFFF;\nL_0057:\n\tv279 = this.fsmBoolParams;\n\tv181 = this.fsmBoolParams == 0;\n\tif (v181) goto L_0068;\n\tv92 = v279._size > 0;\n\tif (v92) goto L_FFFFFFFF;\nL_0068:\n\tv293 = this.fsmVector2Params;\n\tv182 = this.fsmVector2Params == 0;\n\tif (v182) goto L_0079;\n\tv93 = v293._size > 0;\n\tif (v93) goto L_FFFFFFFF;\nL_0079:\n\tv307 = this.fsmVector3Params;\n\tv183 = this.fsmVector3Params == 0;\n\tif (v183) goto L_008A;\n\tv94 = v307._size > 0;\n\tif (v94) goto L_FFFFFFFF;\nL_008A:\n\tv321 = this.fsmColorParams;\n\tv184 = this.fsmColorParams == 0;\n\tif (v184) goto L_009B;\n\tv95 = v321._size > 0;\n\tif (v95) goto L_FFFFFFFF;\nL_009B:\n\tv335 = this.fsmRectParams;\n\tv185 = this.fsmRectParams == 0;\n\tif (v185) goto L_00AC;\n\tv96 = v335._size > 0;\n\tif (v96) goto L_FFFFFFFF;\nL_00AC:\n\tv348 = this.fsmQuaternionParams;\n\tv178 = this.fsmQuaternionParams == 0;\n\tif (v178) goto L_00C4;\n\tv88 = v348._size <= 0;\n\tif (v88) goto L_00C4;\nL_00C3:\n\treturn returnVal1;\nL_00C4:\n\tv247 = this.stringParams;\n\tv244 = this.stringParams == 0;\n\tif (v244) goto L_FFFFFFFF;\n\tv232 = v247._size < 0;\n\tv229 = v247._size == 0;\n\tv223 = v247._size ^ v247._size;\n\tv220 = v247._size & v223;\n\tv217 = v220 < 0;\n\tv354 = v232 == v217;\n\tv212 = ~v229;\n\tv214 = v354 & v212;\n\tgoto L_00C3;\n\tgoto L_00C3;\n\treturn X0;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool UsesDataVersion2()
		{
			List<FsmArray> list = fsmArrayParams;
			if (fsmArrayParams == null || list.Count <= 0)
			{
				List<FsmEnum> list2 = fsmEnumParams;
				if (fsmEnumParams == null || list2.Count <= 0)
				{
					List<FsmFloat> list3 = fsmFloatParams;
					if (fsmFloatParams == null || list3.Count <= 0)
					{
						List<FsmInt> list4 = fsmIntParams;
						if (fsmIntParams == null || list4.Count <= 0)
						{
							List<FsmBool> list5 = fsmBoolParams;
							if (fsmBoolParams == null || list5.Count <= 0)
							{
								List<FsmVector2> list6 = fsmVector2Params;
								if (fsmVector2Params == null || list6.Count <= 0)
								{
									List<FsmVector3> list7 = fsmVector3Params;
									if (fsmVector3Params == null || list7.Count <= 0)
									{
										List<FsmColor> list8 = fsmColorParams;
										if (fsmColorParams == null || list8.Count <= 0)
										{
											List<FsmRect> list9 = fsmRectParams;
											if (fsmRectParams == null || list9.Count <= 0)
											{
												List<FsmQuaternion> list10 = fsmQuaternionParams;
												if (fsmQuaternionParams == null || list10.Count <= 0)
												{
													List<string> list11 = stringParams;
													if (stringParams != null)
													{
														bool flag = list11.Count < 0;
														bool flag2 = list11.Count == 0;
														int num = list11.Count ^ list11.Count;
														int num2 = list11.Count & num;
														bool flag3 = num2 < 0;
														bool flag4 = flag == flag3;
														bool flag5 = !flag2;
														return flag4 && flag5;
													}
													return false;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}

		[Token(Token = "0x6000309")]
		[Address(RVA = "0x9CBB04", Offset = "0x9CBB04", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAC698]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20219FB]) = v38;\nL_0018:\n\tv44 = System.String::op_Equality(actionName, \"HutongGames.PlayMaker.Actions.FloatAddMutiple\");\n\tv46 = v44 == 0;\n\tif (v46) goto L_002F;\n\treturn \"HutongGames.PlayMaker.Actions.FloatAddMultiple\";\nL_002F:\n\treturnVal2 = System.String::Concat(\"HutongGames.PlayMaker.Actions.\", actionName);\n\treturn returnVal2;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string TryFixActionName(string actionName)
		{
			if (actionName == "HutongGames.PlayMaker.Actions.FloatAddMutiple")
			{
				return "HutongGames.PlayMaker.Actions.FloatAddMultiple";
			}
			return "HutongGames.PlayMaker.Actions." + actionName;
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0x9CBDB0", Offset = "0x9CBDB0", Length = "0x46C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv42 = *([1ED0A28]);\n\tv43 = *([v42 @ X8_v78]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, context, actionType, action, actionIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([20219FC]) = v58;\nL_0025:\n\tgoto L_0033;\n\tv65 = *([v61 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\t// 41 Jump @b89\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v61, context, actionType, action, actionIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv69 = HutongGames.PlayMaker.ActionData;\nL_0033:\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(v72.UsedIndices);\n\tSystem.Collections.Generic.List`1<System.Reflection.FieldInfo>::Clear(v225.InitFields);\n\tv280 = this.actionStartIndex;\n\tv372 = v280._size < actionIndex;\n\tv333 = ~v372;\n\tv329 = v280._size - actionIndex;\n\tv321 = v329 == 0;\n\tv373 = ~v321;\n\tv301 = v333 & v373;\n\tif (v301) goto L_004F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004F:\n\tv360 = this.actionNames;\n\tv435 = v280._items;\n\tv361 = v360._size - 1;\n\tv302 = v361 <= actionIndex;\n\tif (v302) goto L_0080;\n\tv366 = this.actionStartIndex;\n\tv441 = actionIndex + 1;\n\tv442 = v366._size < v441;\n\tv443 = ~v442;\n\tv444 = v366._size - v441;\n\tv446 = v444 == 0;\n\tv451 = ~v446;\n\tv452 = v443 & v451;\n\tif (v452) goto L_0079;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0079:\n\tv457 = v441 << 2;\n\tv458 = v366._items + v457;\n\tv363 = v458 + 0x20;\n\tgoto L_0081;\nL_0080:\n\tv363 = this.paramDataPos + 0x18;\nL_0081:\n\tv299 = this.paramName;\n\tv293 = this.paramDataPos;\n\tv470 = v299._size != v293._size;\n\tif (v470) goto L_015F;\n\tv480 = v435[actionIndex @ X4 (System.Int32)] >= *([v363 @ X8_v19]);\n\tif (v480) goto L_015F;\nL_00A5:\n\tv343 = HutongGames.PlayMaker.ActionData::FindField(this, actionType, v234);\n\tv548 = v343 == 0;\n\tif (v548) goto L_00D0;\n\tthis.nextParamIndex = v234;\n\tHutongGames.PlayMaker.ActionData::LoadActionField(this, context.currentFsm, action, v343, v234);\n\tgoto L_00C5;\n\tv614 = *([v605 @ X0_v68 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv615 = v614 == 0;\n\tv616 = ~v615;\n\t// 186 ConditionalJump @b91, v616 @ TEMP_v79\n\tv635 = \"il2cpp_codegen_runtime_class_init\"(v605, v193, v94, v85, v80, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv618 = HutongGames.PlayMaker.ActionData;\nL_00C5:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v229.UsedIndices, v234);\n\tSystem.Collections.Generic.List`1<System.Reflection.FieldInfo>::Add(v226.InitFields, v343);\nL_00D0:\n\tv234 = v234 + 1;\n\tv535 = v234 < *([v363 @ X8_v19]);\n\tif (v535) goto L_00A5;\n\tv490 = v435[actionIndex @ X4 (System.Int32)] >= *([v363 @ X8_v19]);\n\tif (v490) goto L_015F;\nL_00EE:\n\tgoto L_00FB;\n\tv638 = *([v624 @ X0_v45 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv639 = v638 == 0;\n\tv640 = ~v639;\n\t// 242 Jump @b93\n\tv647 = \"il2cpp_codegen_runtime_class_init\"(v624, v194, v95, v88, v83, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv642 = HutongGames.PlayMaker.ActionData;\nL_00FB:\n\tv344 = System.Collections.Generic.List`1<System.Int32>::Contains(v230.UsedIndices, v221);\n\tv653 = v344 == 0;\n\tv654 = ~v653;\n\tif (v654) goto L_014E;\n\tv368 = this.paramName;\n\tv696 = v368._size < v221;\n\tv185 = ~v696;\n\tv178 = v368._size - v221;\n\tv164 = v178 == 0;\n\tv697 = ~v164;\n\tv129 = v185 & v697;\n\tif (v129) goto L_0112;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0112:\n\tv703 = v368._items;\n\tgoto L_0122;\n\tv714 = *([v704 @ X0_v51+E0]);\n\tv715 = v714 == 0;\n\tv716 = ~v715;\n\tif (v716) goto L_0122;\n\tv718 = \"il2cpp_codegen_runtime_class_init\"(v704, v338, v288, v88, v83, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0122:\n\tv678 = HutongGames.PlayMaker.ActionData::FindField(actionType, v703[v221 @ X23_v13 (System.Int32)]);\n\tv680 = v678 == 0;\n\tif (v680) goto L_014E;\n\tthis.nextParamIndex = v221;\n\tv679 = HutongGames.PlayMaker.ActionData::TryConvertParameter(this, context, action, v678, v221);\n\tv681 = v679 == 0;\n\tif (v681) goto L_014E;\n\tgoto L_0143;\n\tv728 = *([v724 @ X0_v57 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv729 = v728 == 0;\n\tv730 = ~v729;\n\t// 312 ConditionalJump @b94, v730 @ TEMP_v67\n\tv735 = \"il2cpp_codegen_runtime_class_init\"(v724, v195, v96, v86, v81, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv732 = HutongGames.PlayMaker.ActionData;\nL_0143:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v231.UsedIndices, v221);\n\tSystem.Collections.Generic.List`1<System.Reflection.FieldInfo>::Add(v227.InitFields, v678);\nL_014E:\n\tv221 = v221 + 1;\n\tv489 = v221 < *([v363 @ X8_v19]);\n\tif (v489) goto L_00EE;\nL_015F:\n\tgoto L_0166;\n\tv526 = *([v521 @ X0_v17+E0]);\n\tv527 = v526 == 0;\n\tv528 = ~v527;\n\tif (v528) goto L_0166;\n\tv530 = \"il2cpp_codegen_runtime_class_init\"(v521, v192, v93, v87, v82, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0166:\n\tv201 = HutongGames.PlayMaker.ActionData::GetFields(actionType);\n\tv271 = v201.Length;\n\tv560 = v201.Length < 1;\n\tif (v560) goto L_01D9;\nL_017E:\n\tv604 = v223 < v271;\n\tv188 = ~v604;\n\tif (v188) goto L_01DB;\n\tgoto L_019C;\n\tv628 = *([v610 @ X0_v24 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv629 = v628 == 0;\n\tv630 = ~v629;\n\t// 403 ConditionalJump @b96, v630 @ TEMP_v39\n\tv645 = \"il2cpp_codegen_runtime_class_init\"(v610, v196, v97, v89, v82, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv632 = HutongGames.PlayMaker.ActionData;\nL_019C:\n\tv345 = System.Collections.Generic.List`1<System.Reflection.FieldInfo>::Contains(v232.InitFields, v201[v223 @ X23_v10 (System.Int32)]);\n\tv649 = v345 == 0;\n\tv650 = ~v649;\n\tif (v650) goto L_01BD;\n\tv690 = System.Reflection.MemberInfo::get_Name(v201[v223 @ X23_v10 (System.Int32)]);\n\tv694 = System.String::Concat(\"New parameter: \", v690, \" (set to default value).\");\n\tgoto L_01BC;\n\tv709 = *([v663 @ X8_v33+E0]);\n\tv710 = v709 == 0;\n\tv711 = ~v710;\n\tif (v711) goto L_01BC;\n\tv721 = v663;\n\tv713 = \"il2cpp_codegen_runtime_class_init\"(v721, v692, v656, v655, v82, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01BC:\n\tHutongGames.PlayMaker.ActionData::LogInfo(context, v694);\nL_01BD:\n\tv271 = v201.Length;\n\tv223 = v223 + 1;\n\tv575 = v223 < v201.Length;\n\tif (v575) goto L_017E;\nL_01D9:\n\treturn action;\n\tv239 = new System.NullReferenceException();\nL_01DB:\n\tv273 = new System.IndexOutOfRangeException();\n\tthrow v273;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 323 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FsmStateAction TryRecoverAction(Context context, Type actionType, FsmStateAction action, int actionIndex)
		{
			//IL_01be: Expected O, but got I
			//IL_0199: Expected O, but got I
			//IL_01a8: Expected O, but got I
			UsedIndices.Clear();
			InitFields.Clear();
			List<int> list = actionStartIndex;
			bool flag = list.Count < actionIndex;
			bool flag2 = !flag;
			int num = list.Count - actionIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			List<string> list2 = ActionNames;
			int[] items = list._items;
			int num2 = list2.Count - 1;
			object obj2;
			if (num2 > actionIndex)
			{
				List<int> list3 = actionStartIndex;
				int num3 = actionIndex + 1;
				bool flag5 = list3.Count < num3;
				bool flag6 = !flag5;
				int num4 = list3.Count - num3;
				bool flag7 = num4 == 0;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					throw new ArgumentOutOfRangeException();
				}
				int num5 = num3 << 2;
				object obj = (long)(IntPtr)list3._items + (long)num5;
				obj2 = (long)(IntPtr)obj + 32L;
			}
			else
			{
				obj2 = (long)(IntPtr)paramDataPos + 24L;
			}
			List<string> list4 = paramName;
			List<int> list5 = paramDataPos;
			if (list4.Count == list5.Count && (long)items[actionIndex] < (long)(IntPtr)obj2)
			{
				int num6 = items[actionIndex];
				do
				{
					FieldInfo fieldInfo = FindField(actionType, num6);
					if ((object)fieldInfo != null)
					{
						nextParamIndex = num6;
						LoadActionField(context.currentFsm, action, fieldInfo, num6);
						UsedIndices.Add(num6);
						InitFields.Add(fieldInfo);
					}
					num6++;
				}
				while ((long)num6 < (long)(IntPtr)obj2);
				if ((long)items[actionIndex] < (long)(IntPtr)obj2)
				{
					int num7 = items[actionIndex];
					do
					{
						if (!UsedIndices.Contains(num7))
						{
							List<string> list6 = paramName;
							bool flag9 = list6.Count < num7;
							bool flag10 = !flag9;
							int num8 = list6.Count - num7;
							bool flag11 = num8 == 0;
							bool flag12 = !flag11;
							if (!(flag10 && flag12))
							{
								throw new ArgumentOutOfRangeException();
							}
							string[] items2 = list6._items;
							FieldInfo fieldInfo2 = FindField(actionType, items2[num7]);
							if ((object)fieldInfo2 != null)
							{
								nextParamIndex = num7;
								if (TryConvertParameter(context, action, fieldInfo2, num7))
								{
									UsedIndices.Add(num7);
									InitFields.Add(fieldInfo2);
								}
							}
						}
						num7++;
					}
					while ((long)num7 < (long)(IntPtr)obj2);
				}
			}
			FieldInfo[] fields = GetFields(actionType);
			int num9 = fields.Length;
			if (fields.Length >= 1)
			{
				int num10 = 0;
				do
				{
					if (num10 < num9)
					{
						if (!InitFields.Contains(fields[num10]))
						{
							string name = fields[num10].Name;
							string info = "New parameter: " + name + " (set to default value).";
							LogInfo(context, info);
						}
						num9 = fields.Length;
						num10++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num10 < fields.Length);
			}
			return action;
		}

		[Token(Token = "0x600030B")]
		[Address(RVA = "0x9D0F2C", Offset = "0x9D0F2C", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1F0AB70]);\n\tv39 = *([v38 @ X8_v33]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, actionType, paramIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20219FD]) = v56;\nL_001D:\n\tv57 = this.paramName;\n\tv60 = v57._size < paramIndex;\n\tv61 = ~v60;\n\tv62 = v57._size - paramIndex;\n\tv64 = v62 == 0;\n\tv69 = ~v64;\n\tv70 = v61 & v69;\n\tif (v70) goto L_002F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002F:\n\tv99 = this.paramDataType;\n\tv190 = v57._items;\n\tv195 = v99._size < paramIndex;\n\tv196 = ~v195;\n\tv197 = v99._size - paramIndex;\n\tv199 = v197 == 0;\n\tv204 = ~v199;\n\tv205 = v196 & v204;\n\tif (v205) goto L_0049;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0049:\n\tv213 = paramIndex << 2;\n\tv214 = v99._items + v213;\n\tgoto L_0057;\n\tv267 = *([v215 @ X0_v12+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_0057;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v215, actionType, paramIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0057:\n\tv253 = HutongGames.PlayMaker.ActionData::GetFields(actionType);\n\tv187 = v253.Length;\n\tv346 = v253.Length < 1;\n\tif (v346) goto L_FFFFFFFF;\nL_006C:\n\tv397 = v78 < v187;\n\tv135 = ~v397;\n\tif (v135) goto L_0112;\n\tv431 = System.Reflection.FieldInfo::get_FieldType(v253[v78 @ X28_v8 (System.Int32)]);\n\tgoto L_008D;\n\tv437 = *([v432 @ X8_v18+E0]);\n\tv438 = v437 == 0;\n\tv439 = ~v438;\n\tif (v439) goto L_008D;\n\tv446 = v432;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v446, v430, v72, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_008D:\n\tv445 = HutongGames.PlayMaker.ActionData::GetParamDataType(v431);\n\tv450 = System.Reflection.MemberInfo::get_Name(v253[v78 @ X28_v8 (System.Int32)]);\n\tv451 = System.String::op_Equality(v450, v190[paramIndex @ X2 (System.Int32)]);\n\tv235 = v445 != *([v214 @ X8_v10+20]);\n\tif (v235) goto L_00BA;\n\tv454 = v451 == 0;\n\tif (v454) goto L_00BA;\n\tgoto L_00B6;\n\tv462 = *([v458 @ X0_v29 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv463 = v462 == 0;\n\tv464 = ~v463;\n\t// 173 ConditionalJump @b48, v464 @ TEMP_v33\n\tv469 = \"il2cpp_codegen_runtime_class_init\"(v458, v223, v220, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv466 = HutongGames.PlayMaker.ActionData;\nL_00B6:\n\tv418 = System.Collections.Generic.List`1<System.Reflection.FieldInfo>::Contains(v264.InitFields, v253[v78 @ X28_v8 (System.Int32)]);\n\tv420 = v418 == 0;\n\tif (v420) goto L_00E1;\nL_00BA:\n\tv187 = v253.Length;\n\tv78 = v78 + 1;\n\tv362 = v78 < v253.Length;\n\tif (v362) goto L_006C;\nL_00D7:\n\treturn v422;\nL_00E1:\n\tv104 = *([v214 @ X8_v10+20]) != 0xC;\n\tif (v104) goto L_00D7;\n\tv254 = System.Object::GetType(v253[v78 @ X28_v8 (System.Int32)]);\n\tv141 = System.Type::GetElementType(v254);\n\tv383 = v141 == 0;\n\tif (v383) goto L_FFFFFFFF;\n\tv147 = this.arrayParamTypes;\n\tv474 = v147._size < paramIndex;\n\tv416 = ~v474;\n\tv415 = v147._size - paramIndex;\n\tv413 = v415 == 0;\n\tv475 = ~v413;\n\tv408 = v416 & v475;\n\tif (v408) goto L_0102;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0102:\n\tv478 = v147._items;\n\tv481 = System.Type::get_FullName(v141);\n\tv419 = System.String::op_Equality(v478[paramIndex @ X2 (System.Int32)], v481);\n\tgoto L_00D7;\n\tv157 = new System.NullReferenceException();\nL_0112:\n\tv189 = new System.IndexOutOfRangeException();\n\tthrow v189;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe FieldInfo FindField(Type actionType, int paramIndex)
		{
			//IL_0122: Expected O, but got I
			List<string> list = paramName;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			List<ParamDataType> list2 = this.paramDataType;
			string[] items = list._items;
			bool flag5 = list2.Count < paramIndex;
			bool flag6 = !flag5;
			int num2 = list2.Count - paramIndex;
			bool flag7 = num2 == 0;
			bool flag8 = !flag7;
			if (!(flag6 && flag8))
			{
				throw new ArgumentOutOfRangeException();
			}
			int num3 = paramIndex << 2;
			object obj = (long)(IntPtr)list2._items + (long)num3;
			FieldInfo[] fields = GetFields(actionType);
			int num4 = fields.Length;
			if (fields.Length < 1)
			{
				goto IL_028b;
			}
			int num5 = 0;
			while (true)
			{
				if (num5 < num4)
				{
					Type fieldType = fields[num5].FieldType;
					ParamDataType paramDataType = GetParamDataType(fieldType);
					string name = fields[num5].Name;
					bool flag9 = name == items[paramIndex];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X8_v10+20]");
					if ((IntPtr)(void*)(int)paramDataType == (IntPtr)(void*)null && flag9 && !InitFields.Contains(fields[num5]))
					{
						break;
					}
					num4 = fields.Length;
					num5++;
					if (num5 < fields.Length)
					{
						continue;
					}
					goto IL_028b;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X8_v10+20]");
			bool flag10 = (IntPtr)0 != (IntPtr)12;
			FieldInfo result = fields[num5];
			if (!flag10)
			{
				Type type = fields[num5].GetType();
				Type elementType = type.GetElementType();
				if ((object)elementType == null)
				{
					goto IL_028b;
				}
				List<string> list3 = arrayParamTypes;
				bool flag11 = list3.Count < paramIndex;
				bool flag12 = !flag11;
				int num6 = list3.Count - paramIndex;
				bool flag13 = num6 == 0;
				bool flag14 = !flag13;
				if (!(flag12 && flag14))
				{
					throw new ArgumentOutOfRangeException();
				}
				string[] items2 = list3._items;
				string fullName = elementType.FullName;
				bool flag15 = items2[paramIndex] == fullName;
				result = fields[num5];
			}
			goto IL_0420;
			IL_0420:
			return result;
			IL_028b:
			result = null;
			goto IL_0420;
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0x9D11A8", Offset = "0x9D11A8", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EE17A8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, name, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20219FE]) = v47;\nL_001E:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, name, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0025:\n\tv62 = HutongGames.PlayMaker.ActionData::GetFields(actionType);\n\tv185 = v62.Length;\n\tv76 = v62.Length < 1;\n\tif (v76) goto L_FFFFFFFF;\nL_0039:\n\tv187 = v92 < v185;\n\tv120 = ~v187;\n\tif (v120) goto L_0082;\n\tv250 = System.Reflection.MemberInfo::get_Name(v62[v92 @ X23_v6 (System.Int32)]);\n\tv251 = System.String::op_Equality(v250, name);\n\tv257 = v251 == 0;\n\tif (v257) goto L_0068;\n\tgoto L_0064;\n\tv265 = *([v258 @ X0_v20 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\t// 91 ConditionalJump @b28, v267 @ TEMP_v24\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v258, v82, v79, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv269 = HutongGames.PlayMaker.ActionData;\nL_0064:\n\tv206 = System.Collections.Generic.List`1<System.Reflection.FieldInfo>::Contains(v130.InitFields, v62[v92 @ X23_v6 (System.Int32)]);\n\tv208 = v206 == 0;\n\tif (v208) goto L_0081;\nL_0068:\n\tv185 = v62.Length;\n\tv92 = v92 + 1;\n\tv147 = v92 < v62.Length;\n\tif (v147) goto L_0039;\nL_0081:\n\treturn v210;\nL_0082:\n\tv246 = new System.IndexOutOfRangeException();\n\tthrow v246;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static FieldInfo FindField(Type actionType, string name)
		{
			FieldInfo[] fields = GetFields(actionType);
			int num = fields.Length;
			if (fields.Length < 1)
			{
				goto IL_0116;
			}
			int num2 = 0;
			FieldInfo result;
			while (true)
			{
				if (num2 < num)
				{
					string name2 = fields[num2].Name;
					if (name2 == name)
					{
						bool flag = InitFields.Contains(fields[num2]);
						bool flag2 = !flag;
						result = fields[num2];
						if (flag2)
						{
							break;
						}
					}
					num = fields.Length;
					num2++;
					if (num2 < fields.Length)
					{
						continue;
					}
					goto IL_0116;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			goto IL_0133;
			IL_0116:
			result = null;
			goto IL_0133;
			IL_0133:
			return result;
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0x9D12E0", Offset = "0x9D12E0", Length = "0x16A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv42 = *([1EDFD28]);\n\tv43 = *([v42 @ X8_v328]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, context, action, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([20219FF]) = v58;\nL_0021:\n\t;\n\tv64 = System.Reflection.FieldInfo::get_FieldType(field);\n\tv65 = this.paramDataType;\n\tv1035 = v65._size < paramIndex;\n\tv1036 = ~v1035;\n\tv1037 = v65._size - paramIndex;\n\tv1039 = v1037 == 0;\n\tv1044 = ~v1039;\n\tv1045 = v1036 & v1044;\n\tif (v1045) goto L_003C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003C:\n\tv196 = paramIndex << 2;\n\tv956 = v65._items + v196;\n\tgoto L_004B;\n\tv1107 = *([v1102 @ X0_v55+E0]);\n\tv1108 = v1107 == 0;\n\tv1109 = ~v1108;\n\tif (v1109) goto L_004B;\n\tv1111 = \"il2cpp_codegen_runtime_class_init\"(v1102, v63, action, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_004B:\n\tv795 = HutongGames.PlayMaker.ActionData::GetParamDataType(v64);\n\tv225 = *([v956 @ X8_v46 (System.String)+20]) != v795;\n\tif (v225) goto L_0074;\n\tv495 = v795 == 0xC;\n\tif (v495) goto L_0074;\n\tHutongGames.PlayMaker.ActionData::LoadActionField(this, context.currentFsm, action, field, paramIndex);\n\tgoto L_0137;\nL_0074:\n\tv1156 = *([v956 @ X8_v46 (System.String)+20]) != 7;\n\tif (v1156) goto L_0137;\n\tv226 = v795 != 0x2A;\n\tif (v226) goto L_0137;\n\tv1689 = System.Reflection.MemberInfo::get_Name(field);\n\tv1694 = System.String::Concat(v1689, \": Upgraded from Enum to FsmEnum\");\n\tgoto L_009B;\n\tv1776 = *([v1739 @ X8_v311+E0]);\n\tv1777 = v1776 == 0;\n\tv1778 = ~v1777;\n\tif (v1778) goto L_009B;\n\tv1824 = v1739;\n\tv1781 = \"il2cpp_codegen_runtime_class_init\"(v1824, v1693, v1692, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_009B:\n\tHutongGames.PlayMaker.ActionData::LogInfo(context, v1694);\n\tv1829 = System.Reflection.MemberInfo::GetCustomAttributes(field, 1);\n\tgoto L_00B6;\n\tv1877 = *([v957 @ X8_v315 (Il2CppClass<System.Type>)+E0]);\n\tv1878 = v1877 == 0;\n\tv1879 = ~v1878;\n\tif (v1879) goto L_00B6;\n\tv1930 = v957;\n\tv1881 = \"il2cpp_codegen_runtime_class_init\"(v1930, v1826, v152, field, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00B6:\n\tv64 = System.Type::GetTypeFromHandle(System.Enum);\n\tv1978 = v1829.Length << 0x20;\n\tv1989 = v1978 < 1;\n\tif (v1989) goto L_FFFFFFFF;\nL_00D9:\n\tv2113 = v1829[v1309 @ X9_v125 (System.Int32)];\n\tv2132 = v1829[v1309 @ X9_v125 (System.Int32)] == 0;\n\tif (v2132) goto L_00E7;\n\tv2139 = *([v2113 @ X13_v13 (System.Object)]) == HutongGames.PlayMaker.ObjectTypeAttribute;\n\tif (v2139) goto L_00F7;\nL_00E7:\n\tv1309 = v1309 + 1;\n\tv2114 = v1309 < v1829.Length;\n\tif (v2114) goto L_00D9;\n\tgoto L_00FA;\n\tgoto L_00FA;\nL_00F7:\n\tv946 = *([v2113 @ X13_v13 (System.Object)+10]);\nL_00FA:\n\tv193 = v118.paramDataPos;\n\tv2198 = v193._size < paramIndex;\n\tv1478 = ~v2198;\n\tv1476 = v193._size - paramIndex;\n\tv1472 = v1476 == 0;\n\tv2199 = ~v1472;\n\tv1462 = v1478 & v2199;\n\tif (v1462) goto L_010D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_010D:\n\tv2272 = v193._items;\n\tv2277 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToInt32(v118.byteDataAsArray, v2272[paramIndex @ X4 (System.Int32)]);\n\tv2339 = new HutongGames.PlayMaker.FsmEnum();\n\tHutongGames.PlayMaker.FsmEnum::.ctor(v2339, \"\", v946, v2277);\n\tSystem.Reflection.FieldInfo::SetValue(field, action, v2339);\nL_0137:\n\tv1498 = *([v956 @ X8_v46 (System.String)+20]) != 3;\n\tif (v1498) goto L_01B6;\n\tv227 = v795 != 0x12;\n\tif (v227) goto L_01B6;\n\tv1748 = System.Reflection.MemberInfo::get_Name(v949);\n\tv1752 = System.String::Concat(v1748, \": Upgraded from string to FsmString\");\n\tgoto L_015C;\n\tv1837 = *([v958 @ X8_v286 (Il2CppClass<System.Object[]>)+E0]);\n\tv1838 = v1837 == 0;\n\tv1839 = ~v1838;\n\tif (v1839) goto L_015C;\n\tv1884 = v958;\n\tv1841 = \"il2cpp_codegen_runtime_class_init\"(v1884, v1751, v153, v146, v141, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_015C:\n\tHutongGames.PlayMaker.ActionData::LogInfo(v1087, v1752);\n\tv959 = v1087.currentFsm;\n\tv2001 = v959.dataVersion < 2;\n\tif (v2001) goto L_0205;\n\tv2054 = v905.stringParams;\n\tv2055 = v905.stringParams == 0;\n\tif (v2055) goto L_0205;\n\tv228 = v2054._size < 1;\n\tif (v228) goto L_0205;\n\tv798 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v798);\n\tv711 = v905.paramDataPos;\n\tv1013 = v905.stringParams;\n\tv2457 = v711._size < paramIndex;\n\tv661 = ~v2457;\n\tv607 = v711._size - paramIndex;\n\tv499 = v607 == 0;\n\tv2458 = ~v499;\n\tv229 = v661 & v2458;\n\tif (v229) goto L_019B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_019B:\n\tv2740 = v711._items;\n\tv2742 = v1013._size < v2740[v190 @ X28_v12 (System.Int32)];\n\tv662 = ~v2742;\n\tv608 = v1013._size - v2740[v190 @ X28_v12 (System.Int32)];\n\tv500 = v608 == 0;\n\tv2743 = ~v500;\n\tv230 = v662 & v2743;\n\tif (v230) goto L_01B0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01B0:\n\tv2975 = v1013._items;\n\tv798.value = v2975[v2740[v190 @ X28_v12 (System.Int32)]];\n\tgoto L_FFFFFFFF;\nL_01B6:\n\tv1705 = *([v956 @ X8_v46 (System.String)+20]) == 0;\n\tv1706 = ~v1705;\n\tif (v1706) goto L_0247;\n\tv231 = v795 != 0x10;\n\tif (v231) goto L_0247;\n\tv1792 = System.Reflection.MemberInfo::get_Name(v949);\n\tv1796 = System.String::Concat(v1792, \": Upgraded from int to FsmInt\");\n\tgoto L_01DC;\n\tv1885 = *([v1843 @ X8_v277+E0]);\n\tv1886 = v1885 == 0;\n\tv1887 = ~v1886;\n\tif (v1887) goto L_01DC;\n\tv1931 = v1843;\n\tv1889 = \"il2cpp_codegen_runtime_class_init\"(v1931, v1795, v154, v146, v141, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_01DC:\n\tHutongGames.PlayMaker.ActionData::LogInfo(v1087, v1796);\n\tv801 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v801);\n\tv1014 = v905.paramDataPos;\n\tv2148 = v1014._size < paramIndex;\n\tv664 = ~v2148;\n\tv610 = v1014._size - paramIndex;\n\tv502 = v610 == 0;\n\tv2149 = ~v502;\n\tv232 = v664 & v2149;\n\tif (v232) goto L_01F7;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01F7:\n\tv2204 = v1014._items;\n\tv802 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToInt32(v905.byteDataAsArray, v2204[v190 @ X28_v12 (System.Int32)]);\n\tv801.value = v802;\n\tgoto L_FFFFFFFF;\nL_0205:\n\tv803 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v803);\n\tv1015 = v905.paramDataPos;\n\tv2278 = v1015._size < paramIndex;\n\tv666 = ~v2278;\n\tv612 = v1015._size - paramIndex;\n\tv504 = v612 == 0;\n\tv2279 = ~v504;\n\tv234 = v666 & v2279;\n\tif (v234) goto L_021C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_021C:\n\tv184 = v905.paramByteDataSize;\n\tv2459 = v1015._items;\n\tv2462 = v184._size < paramIndex;\n\tv667 = ~v2462;\n\tv613 = v184._size - paramIndex;\n\tv505 = v613 == 0;\n\tv2463 = ~v505;\n\tv235 = v667 & v2463;\n\tif (v235) goto L_0232;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0232:\n\tv2588 = v184._items;\n\tv805 = HutongGames.PlayMaker.FsmUtility::ByteArrayToString(v905.byteDataAsArray, v2459[v190 @ X28_v12 (System.Int32)], v2588[v190 @ X28_v12 (System.Int32)]);\n\tv803.value = v805;\n\tgoto L_FFFFFFFF;\nL_0247:\n\tv1772 = *([v956 @ X8_v46 (System.String)+20]) != 2;\n\tif (v1772) goto L_029B;\n\tv236 = v795 != 0xF;\n\tif (v236) goto L_029B;\n\tv1851 = System.Reflection.MemberInfo::get_Name(v949);\n\tv1855 = System.String::Concat(v1851, \": Upgraded from float to FsmFloat\");\n\tgoto L_026C;\n\tv1934 = *([v1893 @ X8_v268+E0]);\n\tv1935 = v1934 == 0;\n\tv1936 = ~v1935;\n\tif (v1936) goto L_026C;\n\tv2002 = v1893;\n\tv1938 = \"il2cpp_codegen_runtime_class_init\"(v2002, v1854, v157, v146, v141, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_026C:\n\tHutongGames.PlayMaker.ActionData::LogInfo(v1087, v1855);\n\tv806 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v806);\n\tv1016 = v905.paramDataPos;\n\tv2207 = v1016._size < paramIndex;\n\tv669 = ~v2207;\n\tv615 = v1016._size - paramIndex;\n\tv507 = v615 == 0;\n\tv2208 = ~v507;\n\tv237 = v669 & v2208;\n\tif (v237) goto L_0287;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0287:\n\tv2282 = v1016._items;\n\tv93 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(v905.byteDataAsArray, v2282[v190 @ X28_v12 (System.Int32)]);\n\tv806.value = v93;\n\tgoto L_FFFFFFFF;\nL_029B:\n\tv1816 = *([v956 @ \n// ... truncated")]
		private unsafe bool TryConvertParameter(Context context, FsmStateAction action, FieldInfo field, int paramIndex)
		{
			//IL_00b3: Expected O, but got I
			//IL_0334: Expected O, but got I
			//IL_1a7c: Expected O, but got F4
			//IL_245e: Expected O, but got I4
			//IL_2976: Expected I4, but got O
			Type fieldType = field.FieldType;
			List<ParamDataType> list = this.paramDataType;
			bool flag = list.Count < paramIndex;
			bool flag2 = !flag;
			int num = list.Count - paramIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			int num2 = paramIndex << 2;
			string text = (string)((long)(IntPtr)list._items + (long)num2);
			ParamDataType paramDataType = GetParamDataType(fieldType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
			int num3;
			ActionData actionData;
			Context context2;
			FsmStateAction fsmStateAction;
			FieldInfo fieldInfo;
			if ((IntPtr)(void*)null == (IntPtr)(void*)(int)paramDataType && paramDataType != ParamDataType.Array)
			{
				LoadActionField(context.currentFsm, action, field, paramIndex);
				num3 = paramIndex;
				actionData = this;
				context2 = context;
				fsmStateAction = action;
				fieldInfo = field;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
				bool flag5 = (IntPtr)0 != (IntPtr)7;
				num3 = paramIndex;
				actionData = this;
				context2 = context;
				fsmStateAction = action;
				fieldInfo = field;
				if (!flag5)
				{
					bool flag6 = paramDataType != ParamDataType.FsmEnum;
					num3 = paramIndex;
					actionData = this;
					context2 = context;
					fsmStateAction = action;
					fieldInfo = field;
					if (!flag6)
					{
						string name = field.Name;
						string info = name + ": Upgraded from Enum to FsmEnum";
						LogInfo(context, info);
						object[] customAttributes = field.GetCustomAttributes(inherit: true);
						fieldType = typeof(Enum);
						int num4 = customAttributes.Length << 32;
						ActionData actionData2;
						Type enumType;
						if (num4 >= 1)
						{
							int num5 = 0;
							while (true)
							{
								object obj = customAttributes[num5];
								if (customAttributes[num5] == null || (object)obj.GetType() != typeof(ObjectTypeAttribute))
								{
									num5++;
									if (num5 >= customAttributes.Length)
									{
										actionData2 = this;
										enumType = fieldType;
										break;
									}
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2113 @ X13_v13 (System.Object)+10]");
								enumType = (Type)0;
								actionData2 = this;
								break;
							}
						}
						else
						{
							actionData2 = this;
							enumType = fieldType;
						}
						List<int> list2 = actionData2.paramDataPos;
						bool flag7 = list2.Count < paramIndex;
						bool flag8 = !flag7;
						int num6 = list2.Count - paramIndex;
						bool flag9 = num6 == 0;
						bool flag10 = !flag9;
						if (!(flag8 && flag10))
						{
							throw new ArgumentOutOfRangeException();
						}
						int[] items = list2._items;
						int intValue = FsmUtility.BitConverter.ToInt32(actionData2.byteDataAsArray, items[paramIndex]);
						FsmEnum value = new FsmEnum("", enumType, intValue);
						field.SetValue(action, value);
						num3 = paramIndex;
						actionData = this;
						context2 = context;
						fsmStateAction = action;
						fieldInfo = field;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
			FsmMaterial fsmMaterial;
			FieldInfo fieldInfo2;
			Array array;
			string error;
			FsmStateAction obj2;
			if ((IntPtr)0 == (IntPtr)3 && paramDataType == ParamDataType.FsmString)
			{
				string name2 = fieldInfo.Name;
				string info2 = name2 + ": Upgraded from string to FsmString";
				LogInfo(context2, info2);
				Fsm currentFsm = context2.currentFsm;
				if (currentFsm.DataVersion >= 2)
				{
					List<string> list3 = actionData.stringParams;
					if (actionData.stringParams != null && list3.Count >= 1)
					{
						FsmString fsmString = new FsmString();
						List<int> list4 = actionData.paramDataPos;
						List<string> list5 = actionData.stringParams;
						bool flag11 = list4.Count < paramIndex;
						bool flag12 = !flag11;
						int num7 = list4.Count - paramIndex;
						bool flag13 = num7 == 0;
						bool flag14 = !flag13;
						if (!(flag12 && flag14))
						{
							throw new ArgumentOutOfRangeException();
						}
						int[] items2 = list4._items;
						bool flag15 = list5.Count < items2[num3];
						bool flag16 = !flag15;
						int num8 = list5.Count - items2[num3];
						bool flag17 = num8 == 0;
						bool flag18 = !flag17;
						if (!(flag16 && flag18))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items3 = list5._items;
						fsmString.Value = items3[items2[num3]];
						fsmMaterial = (FsmMaterial)(object)fsmString;
						goto IL_2b28;
					}
				}
				FsmString fsmString2 = new FsmString();
				List<int> list6 = actionData.paramDataPos;
				bool flag19 = list6.Count < paramIndex;
				bool flag20 = !flag19;
				int num9 = list6.Count - paramIndex;
				bool flag21 = num9 == 0;
				bool flag22 = !flag21;
				if (!(flag20 && flag22))
				{
					throw new ArgumentOutOfRangeException();
				}
				List<int> list7 = actionData.paramByteDataSize;
				int[] items4 = list6._items;
				bool flag23 = list7.Count < paramIndex;
				bool flag24 = !flag23;
				int num10 = list7.Count - paramIndex;
				bool flag25 = num10 == 0;
				bool flag26 = !flag25;
				if (!(flag24 && flag26))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items5 = list7._items;
				string value2 = FsmUtility.ByteArrayToString(actionData.byteDataAsArray, items4[num3], items5[num3]);
				fsmString2.Value = value2;
				fsmMaterial = (FsmMaterial)(object)fsmString2;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
				if ((IntPtr)0 == (IntPtr)0 && paramDataType == ParamDataType.FsmInt)
				{
					string name3 = fieldInfo.Name;
					string info3 = name3 + ": Upgraded from int to FsmInt";
					LogInfo(context2, info3);
					FsmInt fsmInt = new FsmInt();
					List<int> list8 = actionData.paramDataPos;
					bool flag27 = list8.Count < paramIndex;
					bool flag28 = !flag27;
					int num11 = list8.Count - paramIndex;
					bool flag29 = num11 == 0;
					bool flag30 = !flag29;
					if (!(flag28 && flag30))
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items6 = list8._items;
					int value3 = FsmUtility.BitConverter.ToInt32(actionData.byteDataAsArray, items6[num3]);
					fsmInt.Value = value3;
					fsmMaterial = (FsmMaterial)(object)fsmInt;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
					if ((IntPtr)0 == (IntPtr)2 && paramDataType == ParamDataType.FsmFloat)
					{
						string name4 = fieldInfo.Name;
						string info4 = name4 + ": Upgraded from float to FsmFloat";
						LogInfo(context2, info4);
						FsmFloat fsmFloat = new FsmFloat();
						List<int> list9 = actionData.paramDataPos;
						bool flag31 = list9.Count < paramIndex;
						bool flag32 = !flag31;
						int num12 = list9.Count - paramIndex;
						bool flag33 = num12 == 0;
						bool flag34 = !flag33;
						if (!(flag32 && flag34))
						{
							throw new ArgumentOutOfRangeException();
						}
						int[] items7 = list9._items;
						float value4 = FsmUtility.BitConverter.ToSingle(actionData.byteDataAsArray, items7[num3]);
						fsmFloat.Value = value4;
						fsmMaterial = (FsmMaterial)(object)fsmFloat;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
						if ((IntPtr)0 == (IntPtr)1 && paramDataType == ParamDataType.FsmBool)
						{
							string name5 = fieldInfo.Name;
							string info5 = name5 + ": Upgraded from bool to FsmBool";
							LogInfo(context2, info5);
							FsmBool fsmBool = new FsmBool();
							List<int> list10 = actionData.paramDataPos;
							bool flag35 = list10.Count < paramIndex;
							bool flag36 = !flag35;
							int num13 = list10.Count - paramIndex;
							bool flag37 = num13 == 0;
							bool flag38 = !flag37;
							if (!(flag36 && flag38))
							{
								throw new ArgumentOutOfRangeException();
							}
							int[] items8 = list10._items;
							bool value5 = FsmUtility.BitConverter.ToBoolean(actionData.byteDataAsArray, items8[num3]);
							fsmBool.value = value5;
							fsmMaterial = (FsmMaterial)(object)fsmBool;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
							if ((IntPtr)0 == (IntPtr)27 && paramDataType == ParamDataType.FsmGameObject)
							{
								string name6 = fieldInfo.Name;
								string info6 = name6 + ": Upgraded from from GameObject to FsmGameObject";
								LogInfo(context2, info6);
								FsmGameObject fsmGameObject = new FsmGameObject();
								List<int> list11 = actionData.paramDataPos;
								List<UnityEngine.Object> list12 = actionData.unityObjectParams;
								bool flag39 = list11.Count < paramIndex;
								bool flag40 = !flag39;
								int num14 = list11.Count - paramIndex;
								bool flag41 = num14 == 0;
								bool flag42 = !flag41;
								if (!(flag40 && flag42))
								{
									throw new ArgumentOutOfRangeException();
								}
								int[] items9 = list11._items;
								bool flag43 = list12.Count < items9[num3];
								bool flag44 = !flag43;
								int num15 = list12.Count - items9[num3];
								bool flag45 = num15 == 0;
								bool flag46 = !flag45;
								if (!(flag44 && flag46))
								{
									throw new ArgumentOutOfRangeException();
								}
								UnityEngine.Object[] items10 = list12._items;
								GameObject gameObject = (GameObject)items10[items9[num3]];
								if ((object)items10[items9[num3]] != null && (object)gameObject.GetType() != typeof(GameObject))
								{
									goto IL_2ad2;
								}
								fsmGameObject.Value = (GameObject)items10[items9[num3]];
								fsmMaterial = (FsmMaterial)(object)fsmGameObject;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
								if ((IntPtr)0 == (IntPtr)27 && paramDataType == ParamDataType.FsmOwnerDefault)
								{
									string name7 = fieldInfo.Name;
									string info7 = name7 + ": Upgraded from GameObject to FsmOwnerDefault";
									LogInfo(context2, info7);
									FsmOwnerDefault fsmOwnerDefault = new FsmOwnerDefault();
									FsmGameObject fsmGameObject2 = new FsmGameObject();
									List<int> list13 = actionData.paramDataPos;
									List<UnityEngine.Object> list14 = actionData.unityObjectParams;
									bool flag47 = list13.Count < paramIndex;
									bool flag48 = !flag47;
									int num16 = list13.Count - paramIndex;
									bool flag49 = num16 == 0;
									bool flag50 = !flag49;
									if (!(flag48 && flag50))
									{
										throw new ArgumentOutOfRangeException();
									}
									int[] items11 = list13._items;
									bool flag51 = list14.Count < items11[num3];
									bool flag52 = !flag51;
									int num17 = list14.Count - items11[num3];
									bool flag53 = num17 == 0;
									bool flag54 = !flag53;
									if (!(flag52 && flag54))
									{
										throw new ArgumentOutOfRangeException();
									}
									UnityEngine.Object[] items12 = list14._items;
									GameObject gameObject2 = (GameObject)items12[items11[num3]];
									if ((object)items12[items11[num3]] != null && (object)gameObject2.GetType() != typeof(GameObject))
									{
										goto IL_2ad2;
									}
									fsmGameObject2.Value = (GameObject)items12[items11[num3]];
									fsmOwnerDefault.GameObject = fsmGameObject2;
									fsmMaterial = (FsmMaterial)(object)fsmOwnerDefault;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
									if ((IntPtr)0 == (IntPtr)19 && paramDataType == ParamDataType.FsmOwnerDefault)
									{
										string name8 = fieldInfo.Name;
										string info8 = name8 + ": Converted from FsmGameObject to FsmOwnerDefault";
										LogInfo(context2, info8);
										FsmOwnerDefault fsmOwnerDefault2 = new FsmOwnerDefault();
										List<int> list15 = actionData.paramDataPos;
										List<FsmGameObject> list16 = actionData.fsmGameObjectParams;
										bool flag55 = list15.Count < paramIndex;
										bool flag56 = !flag55;
										int num18 = list15.Count - paramIndex;
										bool flag57 = num18 == 0;
										bool flag58 = !flag57;
										if (!(flag56 && flag58))
										{
											throw new ArgumentOutOfRangeException();
										}
										int[] items13 = list15._items;
										bool flag59 = list16.Count < items13[num3];
										bool flag60 = !flag59;
										int num19 = list16.Count - items13[num3];
										bool flag61 = num19 == 0;
										bool flag62 = !flag61;
										if (!(flag60 && flag62))
										{
											throw new ArgumentOutOfRangeException();
										}
										FsmGameObject[] items14 = list16._items;
										fsmOwnerDefault2.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
										fsmOwnerDefault2.GameObject = items14[items13[num3]];
										fieldInfo.SetValue(fsmStateAction, fsmOwnerDefault2);
										return true;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
									if ((IntPtr)0 == (IntPtr)9 && paramDataType == ParamDataType.FsmVector3)
									{
										string name9 = fieldInfo.Name;
										string info9 = name9 + ": Upgraded from Vector3 to FsmVector3";
										LogInfo(context2, info9);
										FsmVector3 fsmVector = new FsmVector3();
										List<int> list17 = actionData.paramDataPos;
										bool flag63 = list17.Count < paramIndex;
										bool flag64 = !flag63;
										int num20 = list17.Count - paramIndex;
										bool flag65 = num20 == 0;
										bool flag66 = !flag65;
										if (!(flag64 && flag66))
										{
											throw new ArgumentOutOfRangeException();
										}
										int[] items15 = list17._items;
										Vector3 vector = (fsmVector.value = FsmUtility.ByteArrayToVector3(actionData.byteDataAsArray, items15[num3]));
										fsmVector.value.y = vector.y;
										fsmVector.value.z = vector.z;
										fsmMaterial = (FsmMaterial)(object)fsmVector;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
										if ((IntPtr)0 == (IntPtr)8 && paramDataType == ParamDataType.FsmVector2)
										{
											string name10 = fieldInfo.Name;
											string info10 = name10 + ": Upgraded from Vector2 to FsmVector2";
											LogInfo(context2, info10);
											FsmVector2 fsmVector2 = new FsmVector2();
											List<int> list18 = actionData.paramDataPos;
											bool flag67 = list18.Count < paramIndex;
											bool flag68 = !flag67;
											int num21 = list18.Count - paramIndex;
											bool flag69 = num21 == 0;
											bool flag70 = !flag69;
											if (!(flag68 && flag70))
											{
												throw new ArgumentOutOfRangeException();
											}
											int[] items16 = list18._items;
											Vector2 vector2 = (fsmVector2.value = FsmUtility.ByteArrayToVector2(actionData.byteDataAsArray, items16[num3]));
											fsmVector2.value.y = vector2.y;
											fsmMaterial = (FsmMaterial)(object)fsmVector2;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
											float num23;
											string typeName;
											if ((IntPtr)0 == (IntPtr)11 && paramDataType == ParamDataType.FsmRect)
											{
												string name11 = fieldInfo.Name;
												string info11 = name11 + ": Upgraded from Rect to FsmRect";
												LogInfo(context2, info11);
												FsmRect fsmRect = new FsmRect();
												List<int> list19 = actionData.paramDataPos;
												bool flag71 = list19.Count < paramIndex;
												bool flag72 = !flag71;
												int num22 = list19.Count - paramIndex;
												bool flag73 = num22 == 0;
												bool flag74 = !flag73;
												if (!(flag72 && flag74))
												{
													throw new ArgumentOutOfRangeException();
												}
												int[] items17 = list19._items;
												Rect rect = FsmUtility.ByteArrayToRect(actionData.byteDataAsArray, items17[num3]);
												float y = rect.y;
												num23 = rect.width;
												float height = rect.height;
												bool flag75 = fsmRect == null;
												bool flag76 = !flag75;
												typeName = (string)rect;
												fsmMaterial = (FsmMaterial)(object)fsmRect;
												if (!flag76)
												{
													goto IL_2836;
												}
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
												if ((IntPtr)0 == (IntPtr)34 && paramDataType == ParamDataType.Quaternion)
												{
													string name12 = fieldInfo.Name;
													string info12 = name12 + ": Upgraded from Quaternion to FsmQuaternion";
													LogInfo(context2, info12);
													FsmQuaternion fsmQuaternion = new FsmQuaternion();
													List<int> list20 = actionData.paramDataPos;
													bool flag77 = list20.Count < paramIndex;
													bool flag78 = !flag77;
													int num24 = list20.Count - paramIndex;
													bool flag79 = num24 == 0;
													bool flag80 = !flag79;
													if (!(flag78 && flag80))
													{
														throw new ArgumentOutOfRangeException();
													}
													int[] items18 = list20._items;
													Quaternion quaternion = FsmUtility.ByteArrayToQuaternion(actionData.byteDataAsArray, items18[num3]);
													float y = quaternion.y;
													num23 = quaternion.z;
													float height = quaternion.w;
													bool flag81 = fsmQuaternion == null;
													bool flag82 = !flag81;
													typeName = (string)quaternion;
													fsmMaterial = (FsmMaterial)(object)fsmQuaternion;
													if (!flag82)
													{
														FieldInfo typeFromHandle = (FieldInfo)(object)typeof(ActionData);
														goto IL_2836;
													}
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
													if ((IntPtr)0 != (IntPtr)4 || paramDataType != ParamDataType.FsmColor)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
														if ((IntPtr)0 == (IntPtr)5 && paramDataType == ParamDataType.FsmMaterial)
														{
															string name13 = fieldInfo.Name;
															string info13 = name13 + ": Upgraded from Material to FsmMaterial";
															LogInfo(context2, info13);
															FsmMaterial fsmMaterial2 = new FsmMaterial();
															List<int> list21 = actionData.paramDataPos;
															List<UnityEngine.Object> list22 = actionData.unityObjectParams;
															bool flag83 = list21.Count < paramIndex;
															bool flag84 = !flag83;
															int num25 = list21.Count - paramIndex;
															bool flag85 = num25 == 0;
															bool flag86 = !flag85;
															if (!(flag84 && flag86))
															{
																throw new ArgumentOutOfRangeException();
															}
															int[] items19 = list21._items;
															bool flag87 = list22.Count < items19[num3];
															bool flag88 = !flag87;
															int num26 = list22.Count - items19[num3];
															bool flag89 = num26 == 0;
															bool flag90 = !flag89;
															if (!(flag88 && flag90))
															{
																throw new ArgumentOutOfRangeException();
															}
															UnityEngine.Object[] items20 = list22._items;
															Material value6;
															if ((object)items20[items19[num3]] == null)
															{
																value6 = null;
															}
															else
															{
																Material material = items20[items19[num3]] as Material;
																value6 = (Material)(((object)material == null) ? null : items20[items19[num3]]);
															}
															fsmMaterial2.Value = value6;
															fieldInfo2 = fieldInfo;
															fsmMaterial = fsmMaterial2;
															goto IL_2b7e;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
														FieldInfo fieldInfo3;
														if ((IntPtr)0 == (IntPtr)5 && paramDataType == ParamDataType.FsmTexture)
														{
															string name14 = fieldInfo.Name;
															string info14 = name14 + ": Upgraded from Texture to FsmTexture";
															LogInfo(context2, info14);
															FsmTexture fsmTexture = new FsmTexture();
															List<int> list23 = actionData.paramDataPos;
															List<UnityEngine.Object> list24 = actionData.unityObjectParams;
															bool flag91 = list23.Count < paramIndex;
															bool flag92 = !flag91;
															int num27 = list23.Count - paramIndex;
															bool flag93 = num27 == 0;
															bool flag94 = !flag93;
															if (!(flag92 && flag94))
															{
																throw new ArgumentOutOfRangeException();
															}
															int[] items21 = list23._items;
															bool flag95 = list24.Count < items21[num3];
															bool flag96 = !flag95;
															int num28 = list24.Count - items21[num3];
															bool flag97 = num28 == 0;
															bool flag98 = !flag97;
															if (!(flag96 && flag98))
															{
																throw new ArgumentOutOfRangeException();
															}
															UnityEngine.Object[] items22 = list24._items;
															Texture value7;
															if ((object)items22[items21[num3]] == null)
															{
																value7 = null;
															}
															else
															{
																Texture texture = items22[items21[num3]] as Texture;
																value7 = (Texture)(((object)texture == null) ? null : items22[items21[num3]]);
															}
															fsmTexture.Value = value7;
															fieldInfo3 = fieldInfo;
															fsmMaterial = (FsmMaterial)(object)fsmTexture;
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ X8_v46 (System.String)+20]");
															if ((IntPtr)0 != (IntPtr)5 || paramDataType != ParamDataType.FsmObject)
															{
																if (paramDataType == ParamDataType.Array)
																{
																	List<int> list25 = actionData.paramDataPos;
																	List<string> list26 = actionData.arrayParamTypes;
																	bool flag99 = list25.Count < paramIndex;
																	bool flag100 = !flag99;
																	int num29 = list25.Count - paramIndex;
																	bool flag101 = num29 == 0;
																	bool flag102 = !flag101;
																	if (!(flag100 && flag102))
																	{
																		throw new ArgumentOutOfRangeException();
																	}
																	int[] items23 = list25._items;
																	bool flag103 = list26.Count < items23[num3];
																	bool flag104 = !flag103;
																	int num30 = list26.Count - items23[num3];
																	bool flag105 = num30 == 0;
																	bool flag106 = !flag105;
																	if (!(flag104 && flag106))
																	{
																		throw new ArgumentOutOfRangeException();
																	}
																	string[] items24 = list26._items;
																	fieldType = ReflectionUtils.GetGlobalType(items24[items23[num3]]);
																	fieldType = fieldType.GetElementType();
																	if ((object)fieldType != null)
																	{
																		List<int> list27 = actionData.paramDataPos;
																		List<int> list28 = actionData.arrayParamSizes;
																		bool flag107 = list27.Count < paramIndex;
																		bool flag108 = !flag107;
																		int num31 = list27.Count - paramIndex;
																		bool flag109 = num31 == 0;
																		bool flag110 = !flag109;
																		if (!(flag108 && flag110))
																		{
																			throw new ArgumentOutOfRangeException();
																		}
																		int[] items25 = list27._items;
																		bool flag111 = list28.Count < items25[num3];
																		bool flag112 = !flag111;
																		int num32 = list28.Count - items25[num3];
																		bool flag113 = num32 == 0;
																		bool flag114 = !flag113;
																		if (!(flag112 && flag114))
																		{
																			throw new ArgumentOutOfRangeException();
																		}
																		int[] items26 = list28._items;
																		array = Array.CreateInstance(fieldType, items26[items25[num3]]);
																		if ((object)fieldType != fieldType)
																		{
																			ParamDataType paramDataType2 = GetParamDataType(fieldType);
																			ParamDataType paramDataType3 = GetParamDataType(fieldType);
																			if (items26[items25[num3]] >= 1)
																			{
																				int num33 = 0;
																				ActionData actionData3;
																				FieldInfo typeFromHandle;
																				int num34;
																				while (true)
																				{
																					bool flag115 = actionData.TryConvertArrayElement(paramIndex: ++actionData.nextParamIndex, fsm: context2.currentFsm, field: array, originalParamType: paramDataType2, currentParamType: paramDataType3, elementIndex: num33);
																					bool flag116 = !flag115;
																					actionData3 = (ActionData)paramDataType2;
																					typeFromHandle = fieldInfo;
																					num34 = (int)paramDataType3;
																					if (flag116)
																					{
																						break;
																					}
																					object[] array2 = new object[5];
																					string name15 = fieldInfo.Name;
																					if (name15 != null)
																					{
																						fieldType = (Type)(name15 as object);
																						if ((object)fieldType == null)
																						{
																							goto IL_2ae0;
																						}
																					}
																					array2[0] = name15;
																					if (": Upgraded Array from " != null)
																					{
																						fieldType = (Type)(": Upgraded Array from " as object);
																						if ((object)fieldType == null)
																						{
																							goto IL_2ae0;
																						}
																					}
																					array2[1] = ": Upgraded Array from ";
																					string fullName = fieldType.FullName;
																					if (fullName != null)
																					{
																						fieldType = (Type)(fullName as object);
																						if ((object)fieldType == null)
																						{
																							goto IL_2ae0;
																						}
																					}
																					array2[2] = fullName;
																					if (" to " != null)
																					{
																						fieldType = (Type)(" to " as object);
																						if ((object)fieldType == null)
																						{
																							goto IL_2ae0;
																						}
																					}
																					array2[3] = " to ";
																					fieldType = (Type)(object)paramDataType3;
																					if ((object)fieldType != null)
																					{
																						fieldType = (Type)(fieldType as object);
																						if ((object)fieldType == null)
																						{
																							goto IL_2ae0;
																						}
																					}
																					array2[4] = fieldType;
																					string info15 = string.Concat(array2);
																					LogInfo(context2, info15);
																					num33++;
																					if (num33 < items26[items25[num3]])
																					{
																						continue;
																					}
																					goto IL_2819;
																				}
																				object[] array3 = new object[6];
																				if ("Failed to convert Array: " != null)
																				{
																					fieldType = (Type)("Failed to convert Array: " as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[0] = "Failed to convert Array: ";
																				string name16 = typeFromHandle.Name;
																				if (name16 != null)
																				{
																					fieldType = (Type)(name16 as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[1] = name16;
																				if (" From: " != null)
																				{
																					fieldType = (Type)(" From: " as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[2] = " From: ";
																				fieldType = (Type)(object)(ParamDataType)actionData3;
																				if ((object)fieldType != null)
																				{
																					fieldType = (Type)(fieldType as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[3] = fieldType;
																				if (" To: " != null)
																				{
																					fieldType = (Type)(" To: " as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[4] = " To: ";
																				fieldType = (Type)(object)(ParamDataType)num34;
																				if ((object)fieldType != null)
																				{
																					fieldType = (Type)(fieldType as object);
																					if ((object)fieldType == null)
																					{
																						goto IL_2ae0;
																					}
																				}
																				array3[5] = fieldType;
																				error = string.Concat(array3);
																				goto IL_2aac;
																			}
																		}
																		else if (items26[items25[num3]] >= 1)
																		{
																			int num34 = 0;
																			do
																			{
																				actionData.LoadArrayElement(paramIndex: ++actionData.nextParamIndex, fsm: context2.currentFsm, field: array, fieldType: fieldType, elementIndex: num34);
																				num34++;
																			}
																			while (num34 < items26[items25[num3]]);
																		}
																		goto IL_2819;
																	}
																	string name17 = fieldInfo.Name;
																	error = "Could not make array: " + name17;
																	goto IL_2aac;
																}
																goto IL_2abe;
															}
															string name18 = fieldInfo.Name;
															string info16 = name18 + ": Upgraded from Object to FsmObject";
															LogInfo(context2, info16);
															FsmObject fsmObject = new FsmObject();
															List<int> list29 = actionData.paramDataPos;
															List<UnityEngine.Object> list30 = actionData.unityObjectParams;
															bool flag117 = list29.Count < paramIndex;
															bool flag118 = !flag117;
															int num35 = list29.Count - paramIndex;
															bool flag119 = num35 == 0;
															bool flag120 = !flag119;
															if (!(flag118 && flag120))
															{
																throw new ArgumentOutOfRangeException();
															}
															int[] items27 = list29._items;
															bool flag121 = list30.Count < items27[num3];
															bool flag122 = !flag121;
															int num36 = list30.Count - items27[num3];
															bool flag123 = num36 == 0;
															bool flag124 = !flag123;
															if (!(flag122 && flag124))
															{
																throw new ArgumentOutOfRangeException();
															}
															UnityEngine.Object[] items28 = list30._items;
															fsmObject.Value = items28[items27[num3]];
															fieldInfo3 = fieldInfo;
															fsmMaterial = (FsmMaterial)fsmObject;
														}
														obj2 = fsmStateAction;
														fieldInfo2 = fieldInfo3;
														goto IL_2bb0;
													}
													string name19 = fieldInfo.Name;
													string info17 = name19 + ": Upgraded from Color to FsmColor";
													LogInfo(context2, info17);
													FsmColor fsmColor = new FsmColor();
													List<int> list31 = actionData.paramDataPos;
													bool flag125 = list31.Count < paramIndex;
													bool flag126 = !flag125;
													int num37 = list31.Count - paramIndex;
													bool flag127 = num37 == 0;
													bool flag128 = !flag127;
													if (!(flag126 && flag128))
													{
														throw new ArgumentOutOfRangeException();
													}
													int[] items29 = list31._items;
													Color color = FsmUtility.ByteArrayToColor(actionData.byteDataAsArray, items29[num3]);
													float y = color.g;
													num23 = color.b;
													float height = color.a;
													typeName = (string)color;
													fsmMaterial = (FsmMaterial)(object)fsmColor;
												}
											}
											fsmMaterial.typeName = typeName;
											((FsmObject)fsmMaterial).Value = (UnityEngine.Object)num23;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_2b28;
			IL_2ae0:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw new TypeLoadException();
			IL_2abe:
			return false;
			IL_2bb0:
			object value8 = fsmMaterial;
			goto IL_2be2;
			IL_2b7e:
			obj2 = fsmStateAction;
			goto IL_2bb0;
			IL_2ad2:
			InvalidCastException ex2 = new InvalidCastException();
			goto IL_2ae0;
			IL_2819:
			value8 = array;
			obj2 = fsmStateAction;
			fieldInfo2 = fieldInfo;
			goto IL_2be2;
			IL_2aac:
			LogError(context2, error);
			goto IL_2abe;
			IL_2b28:
			fieldInfo2 = fieldInfo;
			goto IL_2b7e;
			IL_2be2:
			fieldInfo2.SetValue(obj2, value8);
			return true;
			IL_2836:
			throw new NullReferenceException();
		}

		[Token(Token = "0x600030E")]
		[Address(RVA = "0x9D33CC", Offset = "0x9D33CC", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv42 = *([1EE3C60]);\n\tv43 = *([v42 @ X8_v23]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, fsm, field, originalParamType, currentParamType, elementIndex, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021A00]) = v56;\nL_0024:\n\tv61 = System.Array::GetLength(field, 0);\n\tv63 = v61 <= elementIndex;\n\tif (v63) goto L_0058;\n\tv95 = this.paramDataPos;\n\tv180 = v95._size <= paramIndex;\n\tif (v180) goto L_0061;\n\tv188 = HutongGames.PlayMaker.ActionData::ConvertType(this, fsm, originalParamType, currentParamType, paramIndex);\n\tv217 = v188 == 0;\n\tif (v217) goto L_0086;\n\tSystem.Array::SetValue(field, v188, elementIndex);\n\tgoto L_0086;\nL_0058:\n\t// 88 Box v207 @ X0_v7 (System.Object), typeof(System.Int32), &elementIndex @ X5 (System.Int32)\n\tgoto L_0068;\nL_0061:\n\t// 97 Box v207 @ X0_v7 (System.Object), typeof(System.Int32), &paramIndex @ X6 (System.Int32)\nL_0068:\n\tv215 = System.String::Concat(*([v209 @ X8_v4 (System.String)]), v207);\n\tgoto L_0079;\n\tv236 = *([v222 @ X8_v8+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tgoto L_0079;\n\tv242 = v222;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v242, v212, v213, originalParamType, currentParamType, elementIndex, paramIndex, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0079:\n\tUnityEngine.Debug::LogError(v215);\nL_0086:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool TryConvertArrayElement(Fsm fsm, Array field, ParamDataType originalParamType, ParamDataType currentParamType, int elementIndex, int paramIndex)
		{
			//IL_009a: Expected I4, but got O
			int length = field.GetLength(0);
			bool result;
			object obj2;
			string text;
			if (length > elementIndex)
			{
				List<int> list = paramDataPos;
				if (list.Count > paramIndex)
				{
					object obj = ConvertType(fsm, originalParamType, currentParamType, paramIndex);
					bool flag = obj == null;
					result = (byte)(int)obj != 0;
					if (!flag)
					{
						field.SetValue(obj, elementIndex);
						result = true;
					}
					goto IL_0114;
				}
				obj2 = paramIndex;
				text = "Bad param index: ";
			}
			else
			{
				obj2 = elementIndex;
				text = "Bad array index: ";
			}
			string message = text + obj2;
			Debug.LogError(message);
			result = false;
			goto IL_0114;
			IL_0114:
			return result;
		}

		[Token(Token = "0x600030F")]
		[Address(RVA = "0x9D3548", Offset = "0x9D3548", Length = "0x94C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1EB1168]);\n\tv35 = *([v34 @ X8_v129]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, fsm, originalParamType, currentParamType, paramIndex, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021A01]) = v50;\nL_0024:\n\tv60 = originalParamType != 3;\n\tif (v60) goto L_007A;\n\tv70 = currentParamType != 0x12;\n\tif (v70) goto L_007A;\n\tv123 = fsm.dataVersion < 2;\n\tif (v123) goto L_00AD;\n\tv674 = this.stringParams;\n\tv764 = this.stringParams == 0;\n\tif (v764) goto L_00AD;\n\tv1027 = v674._size;\n\tv207 = v674._size < 1;\n\tif (v207) goto L_00AD;\n\tv636 = this.paramDataPos;\n\tv966 = v636._size < paramIndex;\n\tv967 = ~v966;\n\tv968 = v636._size - paramIndex;\n\tv970 = v968 == 0;\n\tv975 = ~v970;\n\tv976 = v967 & v975;\n\tif (v976) goto L_0063;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv1027 = v674._size;\nL_0063:\n\tv1029 = v636._items;\n\tv1033 = v1027 < v1029[paramIndex @ X4 (System.Int32)];\n\tv1034 = ~v1033;\n\tv1035 = v1027 - v1029[paramIndex @ X4 (System.Int32)];\n\tv1037 = v1035 == 0;\n\tv1042 = ~v1037;\n\tv1043 = v1034 & v1042;\n\tif (v1043) goto L_0075;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0075:\n\tv1085 = v674._items;\n\tgoto L_00E3;\nL_007A:\n\tv80 = originalParamType == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_00F4;\n\tv92 = currentParamType != 0x10;\n\tif (v92) goto L_00F4;\n\tv558 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v558);\n\tv657 = this.paramDataPos;\n\tv941 = v657._size < paramIndex;\n\tv520 = ~v941;\n\tv481 = v657._size - paramIndex;\n\tv403 = v481 == 0;\n\tv942 = ~v403;\n\tv208 = v520 & v942;\n\tif (v208) goto L_00A2;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00A2:\n\tv996 = v657._items;\n\tv559 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToInt32(this.byteDataAsArray, v996[paramIndex @ X4 (System.Int32)]);\n\tv558.value = v559;\n\tgoto L_03BF;\nL_00AD:\n\tv653 = this.paramDataPos;\n\tv845 = v653._size < paramIndex;\n\tv522 = ~v845;\n\tv483 = v653._size - paramIndex;\n\tv405 = v483 == 0;\n\tv846 = ~v405;\n\tv210 = v522 & v846;\n\tif (v210) goto L_00C0;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C0:\n\tv658 = this.paramByteDataSize;\n\tv977 = v653._items;\n\tv982 = v658._size < paramIndex;\n\tv983 = ~v982;\n\tv984 = v658._size - paramIndex;\n\tv986 = v984 == 0;\n\tv992 = ~v986;\n\tv993 = v983 & v992;\n\tif (v993) goto L_00D7;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00D7:\n\tv1046 = v658._items;\n\tv1053 = HutongGames.PlayMaker.FsmUtility::ByteArrayToString(this.byteDataAsArray, v977[paramIndex @ X4 (System.Int32)], v1046[paramIndex @ X4 (System.Int32)]);\nL_00E3:\n\tv561 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v561);\n\tv561.value = v693;\n\tgoto L_03BF;\nL_00F4:\n\tv111 = originalParamType != 2;\n\tif (v111) goto L_012F;\n\tv212 = currentParamType != 0xF;\n\tif (v212) goto L_012F;\n\tv562 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v562);\n\tv660 = this.paramDataPos;\n\tv999 = v660._size < paramIndex;\n\tv525 = ~v999;\n\tv486 = v660._size - paramIndex;\n\tv408 = v486 == 0;\n\tv1000 = ~v408;\n\tv213 = v525 & v1000;\n\tif (v213) goto L_011B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_011B:\n\tv1056 = v660._items;\n\tv140 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToSingle(this.byteDataAsArray, v1056[paramIndex @ X4 (System.Int32)]);\n\tv562.value = v140;\n\tgoto L_03BF;\nL_012F:\n\tv763 = originalParamType != 1;\n\tif (v763) goto L_016B;\n\tv214 = currentParamType != 0x11;\n\tif (v214) goto L_016B;\n\tv564 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v564);\n\tv661 = this.paramDataPos;\n\tv1058 = v661._size < paramIndex;\n\tv527 = ~v1058;\n\tv488 = v661._size - paramIndex;\n\tv410 = v488 == 0;\n\tv1059 = ~v410;\n\tv215 = v527 & v1059;\n\tif (v215) goto L_0156;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0156:\n\tv1092 = v661._items;\n\tv565 = HutongGames.PlayMaker.FsmUtility+BitConverter::ToBoolean(this.byteDataAsArray, v1092[paramIndex @ X4 (System.Int32)]);\n\tv564.value = v565;\n\tgoto L_03BF;\nL_016B:\n\tv842 = originalParamType != 0x1B;\n\tif (v842) goto L_01CB;\n\tv216 = currentParamType != 0x13;\n\tif (v216) goto L_01CB;\n\tv566 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v566);\n\tv662 = this.paramDataPos;\n\tv641 = this.unityObjectParams;\n\tv1094 = v662._size < paramIndex;\n\tv529 = ~v1094;\n\tv490 = v662._size - paramIndex;\n\tv412 = v490 == 0;\n\tv1095 = ~v412;\n\tv217 = v529 & v1095;\n\tif (v217) goto L_0194;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0194:\n\tv1247 = v662._items;\n\tv1249 = v641._size < v1247[paramIndex @ X4 (System.Int32)];\n\tv530 = ~v1249;\n\tv491 = v641._size - v1247[paramIndex @ X4 (System.Int32)];\n\tv413 = v491 == 0;\n\tv1250 = ~v413;\n\tv218 = v530 & v1250;\n\tif (v218) goto L_01A9;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01A9:\n\tv1304 = v641._items;\n\tv773 = v1304[v1247[paramIndex @ X4 (System.Int32)]];\n\tv808 = v1304[v1247[paramIndex @ X4 (System.Int32)]] == 0;\n\tif (v808) goto L_01C0;\n\tv780 = *([v773 @ X1_v32 (UnityEngine.GameObject)]) != UnityEngine.GameObject;\n\tif (v780) goto L_04FF;\nL_01C0:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v566, v1304[v1247[paramIndex @ X4 (System.Int32)]]);\n\tgoto L_03BF;\nL_01CB:\n\tv868 = originalParamType != 0x1B;\n\tif (v868) goto L_0237;\n\tv219 = currentParamType != 0x14;\n\tif (v219) goto L_0237;\n\tv1004 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v1004);\n\tv569 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v569);\n\tv655 = this.paramDataPos;\n\tv642 = this.unityObjectParams;\n\tv1276 = v655._size < paramIndex;\n\tv532 = ~v1276;\n\tv493 = v655._size - paramIndex;\n\tv415 = v493 == 0;\n\tv1277 = ~v415;\n\tv220 = v532 & v1277;\n\tif (v220) goto L_01FB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01FB:\n\tv1342 = v655._items;\n\tv1344 = v642._size < v1342[paramIndex @ X4 (System.Int32)];\n\tv533 = ~v1344;\n\tv494 = v642._size - v1342[paramIndex @ X4 (System.Int32)];\n\tv416 = v494 == 0;\n\tv1345 = ~v416;\n\tv221 = v533 & v1345;\n\tif (v221) goto L_0210;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0210:\n\tv1378 = v642._items;\n\tv169 = v1378[v1342[paramIndex @ X4 (System.Int32)]];\n\tv809 = v1378[v1342[paramIndex @ X4 (System.Int32)]] == 0;\n\tif (v809) goto L_0227;\n\tv781 = *([v169 @ X1_v30 (UnityEngine.GameObject)]) != UnityEngine.GameObject;\n\tif (v781) goto L_04FF;\nL_0227:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v569, v1378[v1342[paramIndex @ X4 (System.Int32)]]);\n\tv1004.gameObject = v569;\n\tv1004.ownerOption = 1;\n\tgoto L_03BF;\nL_0237:\n\tv964 = originalParamType != 0x13;\n\tif (v964) goto L_0286;\n\tv223 = currentParamType != 0x14;\n\tif (v223) goto L_0286;\n\tv573 = new HutongGames.PlayMaker.FsmOwnerDefault();\n\tHutongGames.PlayMaker.FsmOwnerDefault::.ctor(v573);\n\tv664 = this.paramDataPos;\n\tv643 = this.fsmGameObjectParams;\n\tv1251 = v664._size < paramIndex;\n\tv536 = ~v1251;\n\tv497 = v664._size - paramIndex;\n\tv419 = v497 == 0;\n\tv1252 = ~v419;\n\tv224 = v536 & v1252;\n\tif (v224) goto L_0260;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0260:\n\tv1307 = v664._items;\n\tv1309 = v643._size < v1307[paramIndex @ X4 (System.Int32)];\n\tv537 = ~v1309;\n\tv498 = v643._size - v1307[paramIndex @ X4 (System.Int32)];\n\tv420 = v498 == 0;\n\tv1310 = ~v420;\n\tv225 = v537 & v1310;\n\tif (v225) goto L_0275;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0275:\n\tv1367 = v643._items;\n\tv573.ownerOption = 1;\n\tv573.gameObject = v1367[v1307[paramIndex @ X4 (System.Int32)]];\n\tgoto L_03BF;\nL_0286:\n\tv1024 = originalParamType != 8;\n\tif (v1024) goto L_02C3;\n\tv226 = currentParamType != 0x25;\n\tif (v226) goto L_02C3;\n\tv576 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v576);\n\tv665 = this.paramDataPos;\n\tv1280 = v665._size < paramIndex;\n\tv539 = ~v1280;\n\tv500 = v665._size - paramIndex;\n\tv422 = v500 == 0;\n\tv1281 = ~v422;\n\tv227 = v539 & v1281;\n\tif (v227) goto L_02AD;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_02AD:\n\tv1313 = v665._items;\n\tv141 = HutongGames.PlayMaker.FsmUtility::ByteArrayToVector2(this.byteDataAsArray, v1313[param\n// ... truncated")]
		private object ConvertType(Fsm fsm, ParamDataType originalParamType, ParamDataType currentParamType, int paramIndex)
		{
			string value;
			if (originalParamType == ParamDataType.String && currentParamType == ParamDataType.FsmString)
			{
				if (fsm.DataVersion >= 2)
				{
					List<string> list = stringParams;
					if (stringParams != null)
					{
						int count = list.Count;
						if (list.Count >= 1)
						{
							List<int> list2 = paramDataPos;
							bool flag = list2.Count < paramIndex;
							bool flag2 = !flag;
							int num = list2.Count - paramIndex;
							bool flag3 = num == 0;
							bool flag4 = !flag3;
							if (!(flag2 && flag4))
							{
								throw new ArgumentOutOfRangeException();
							}
							int[] items = list2._items;
							bool flag5 = count < items[paramIndex];
							bool flag6 = !flag5;
							int num2 = count - items[paramIndex];
							bool flag7 = num2 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							string[] items2 = list._items;
							value = items2[items[paramIndex]];
							goto IL_1908;
						}
					}
				}
				List<int> list3 = paramDataPos;
				bool flag9 = list3.Count < paramIndex;
				bool flag10 = !flag9;
				int num3 = list3.Count - paramIndex;
				bool flag11 = num3 == 0;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					throw new ArgumentOutOfRangeException();
				}
				List<int> list4 = paramByteDataSize;
				int[] items3 = list3._items;
				bool flag13 = list4.Count < paramIndex;
				bool flag14 = !flag13;
				int num4 = list4.Count - paramIndex;
				bool flag15 = num4 == 0;
				bool flag16 = !flag15;
				if (!(flag14 && flag16))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items4 = list4._items;
				string text = FsmUtility.ByteArrayToString(byteDataAsArray, items3[paramIndex], items4[paramIndex]);
				value = text;
				goto IL_1908;
			}
			object result;
			if (originalParamType == ParamDataType.Integer && currentParamType == ParamDataType.FsmInt)
			{
				FsmInt fsmInt = new FsmInt();
				List<int> list5 = paramDataPos;
				bool flag17 = list5.Count < paramIndex;
				bool flag18 = !flag17;
				int num5 = list5.Count - paramIndex;
				bool flag19 = num5 == 0;
				bool flag20 = !flag19;
				if (!(flag18 && flag20))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items5 = list5._items;
				int value2 = FsmUtility.BitConverter.ToInt32(byteDataAsArray, items5[paramIndex]);
				fsmInt.Value = value2;
				result = fsmInt;
			}
			else if (originalParamType == ParamDataType.Float && currentParamType == ParamDataType.FsmFloat)
			{
				FsmFloat fsmFloat = new FsmFloat();
				List<int> list6 = paramDataPos;
				bool flag21 = list6.Count < paramIndex;
				bool flag22 = !flag21;
				int num6 = list6.Count - paramIndex;
				bool flag23 = num6 == 0;
				bool flag24 = !flag23;
				if (!(flag22 && flag24))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items6 = list6._items;
				float value3 = FsmUtility.BitConverter.ToSingle(byteDataAsArray, items6[paramIndex]);
				fsmFloat.Value = value3;
				result = fsmFloat;
			}
			else if (originalParamType == ParamDataType.Boolean && currentParamType == ParamDataType.FsmBool)
			{
				FsmBool fsmBool = new FsmBool();
				List<int> list7 = paramDataPos;
				bool flag25 = list7.Count < paramIndex;
				bool flag26 = !flag25;
				int num7 = list7.Count - paramIndex;
				bool flag27 = num7 == 0;
				bool flag28 = !flag27;
				if (!(flag26 && flag28))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items7 = list7._items;
				bool value4 = FsmUtility.BitConverter.ToBoolean(byteDataAsArray, items7[paramIndex]);
				fsmBool.value = value4;
				result = fsmBool;
			}
			else if (originalParamType == ParamDataType.GameObject && currentParamType == ParamDataType.FsmGameObject)
			{
				FsmGameObject fsmGameObject = new FsmGameObject();
				List<int> list8 = paramDataPos;
				List<UnityEngine.Object> list9 = unityObjectParams;
				bool flag29 = list8.Count < paramIndex;
				bool flag30 = !flag29;
				int num8 = list8.Count - paramIndex;
				bool flag31 = num8 == 0;
				bool flag32 = !flag31;
				if (!(flag30 && flag32))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items8 = list8._items;
				bool flag33 = list9.Count < items8[paramIndex];
				bool flag34 = !flag33;
				int num9 = list9.Count - items8[paramIndex];
				bool flag35 = num9 == 0;
				bool flag36 = !flag35;
				if (!(flag34 && flag36))
				{
					throw new ArgumentOutOfRangeException();
				}
				UnityEngine.Object[] items9 = list9._items;
				GameObject gameObject = (GameObject)items9[items8[paramIndex]];
				if ((object)items9[items8[paramIndex]] != null && (object)gameObject.GetType() != typeof(GameObject))
				{
					goto IL_1860;
				}
				fsmGameObject.Value = (GameObject)items9[items8[paramIndex]];
				result = fsmGameObject;
			}
			else if (originalParamType == ParamDataType.GameObject && currentParamType == ParamDataType.FsmOwnerDefault)
			{
				FsmOwnerDefault fsmOwnerDefault = new FsmOwnerDefault();
				FsmGameObject fsmGameObject2 = new FsmGameObject();
				List<int> list10 = paramDataPos;
				List<UnityEngine.Object> list11 = unityObjectParams;
				bool flag37 = list10.Count < paramIndex;
				bool flag38 = !flag37;
				int num10 = list10.Count - paramIndex;
				bool flag39 = num10 == 0;
				bool flag40 = !flag39;
				if (!(flag38 && flag40))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items10 = list10._items;
				bool flag41 = list11.Count < items10[paramIndex];
				bool flag42 = !flag41;
				int num11 = list11.Count - items10[paramIndex];
				bool flag43 = num11 == 0;
				bool flag44 = !flag43;
				if (!(flag42 && flag44))
				{
					throw new ArgumentOutOfRangeException();
				}
				UnityEngine.Object[] items11 = list11._items;
				GameObject gameObject2 = (GameObject)items11[items10[paramIndex]];
				if ((object)items11[items10[paramIndex]] != null && (object)gameObject2.GetType() != typeof(GameObject))
				{
					goto IL_1860;
				}
				fsmGameObject2.Value = (GameObject)items11[items10[paramIndex]];
				fsmOwnerDefault.GameObject = fsmGameObject2;
				fsmOwnerDefault.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
				result = fsmOwnerDefault;
			}
			else if (originalParamType == ParamDataType.FsmGameObject && currentParamType == ParamDataType.FsmOwnerDefault)
			{
				FsmOwnerDefault fsmOwnerDefault2 = new FsmOwnerDefault();
				List<int> list12 = paramDataPos;
				List<FsmGameObject> list13 = fsmGameObjectParams;
				bool flag45 = list12.Count < paramIndex;
				bool flag46 = !flag45;
				int num12 = list12.Count - paramIndex;
				bool flag47 = num12 == 0;
				bool flag48 = !flag47;
				if (!(flag46 && flag48))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items12 = list12._items;
				bool flag49 = list13.Count < items12[paramIndex];
				bool flag50 = !flag49;
				int num13 = list13.Count - items12[paramIndex];
				bool flag51 = num13 == 0;
				bool flag52 = !flag51;
				if (!(flag50 && flag52))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmGameObject[] items13 = list13._items;
				fsmOwnerDefault2.OwnerOption = OwnerDefaultOption.SpecifyGameObject;
				fsmOwnerDefault2.GameObject = items13[items12[paramIndex]];
				result = fsmOwnerDefault2;
			}
			else if (originalParamType == ParamDataType.Vector2 && currentParamType == ParamDataType.FsmVector2)
			{
				FsmVector2 fsmVector = new FsmVector2();
				List<int> list14 = paramDataPos;
				bool flag53 = list14.Count < paramIndex;
				bool flag54 = !flag53;
				int num14 = list14.Count - paramIndex;
				bool flag55 = num14 == 0;
				bool flag56 = !flag55;
				if (!(flag54 && flag56))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items14 = list14._items;
				Vector2 vector = (fsmVector.value = FsmUtility.ByteArrayToVector2(byteDataAsArray, items14[paramIndex]));
				fsmVector.value.y = vector.y;
				result = fsmVector;
			}
			else if (originalParamType == ParamDataType.Vector3 && currentParamType == ParamDataType.FsmVector3)
			{
				FsmVector3 fsmVector2 = new FsmVector3();
				List<int> list15 = paramDataPos;
				bool flag57 = list15.Count < paramIndex;
				bool flag58 = !flag57;
				int num15 = list15.Count - paramIndex;
				bool flag59 = num15 == 0;
				bool flag60 = !flag59;
				if (!(flag58 && flag60))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items15 = list15._items;
				Vector3 vector2 = (fsmVector2.value = FsmUtility.ByteArrayToVector3(byteDataAsArray, items15[paramIndex]));
				fsmVector2.value.y = vector2.y;
				fsmVector2.value.z = vector2.z;
				result = fsmVector2;
			}
			else if (originalParamType == ParamDataType.Rect && currentParamType == ParamDataType.FsmRect)
			{
				FsmRect fsmRect = new FsmRect();
				List<int> list16 = paramDataPos;
				bool flag61 = list16.Count < paramIndex;
				bool flag62 = !flag61;
				int num16 = list16.Count - paramIndex;
				bool flag63 = num16 == 0;
				bool flag64 = !flag63;
				if (!(flag62 && flag64))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items16 = list16._items;
				Rect rect = FsmUtility.ByteArrayToRect(byteDataAsArray, items16[paramIndex]);
				float y = rect.y;
				float width = rect.width;
				float height = rect.height;
				bool flag65 = fsmRect == null;
				bool flag66 = !flag65;
				result = fsmRect;
				if (!flag66)
				{
					goto IL_185a;
				}
			}
			else if (originalParamType == ParamDataType.Quaternion && currentParamType == ParamDataType.Quaternion)
			{
				FsmQuaternion fsmQuaternion = new FsmQuaternion();
				List<int> list17 = paramDataPos;
				bool flag67 = list17.Count < paramIndex;
				bool flag68 = !flag67;
				int num17 = list17.Count - paramIndex;
				bool flag69 = num17 == 0;
				bool flag70 = !flag69;
				if (!(flag68 && flag70))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items17 = list17._items;
				Quaternion quaternion = FsmUtility.ByteArrayToQuaternion(byteDataAsArray, items17[paramIndex]);
				float y = quaternion.y;
				float width = quaternion.z;
				float height = quaternion.w;
				bool flag71 = fsmQuaternion == null;
				bool flag72 = !flag71;
				Rect rect = (Rect)quaternion;
				result = fsmQuaternion;
				if (!flag72)
				{
					goto IL_185a;
				}
			}
			else if (originalParamType == ParamDataType.Color && currentParamType == ParamDataType.FsmColor)
			{
				FsmColor fsmColor = new FsmColor();
				List<int> list18 = paramDataPos;
				bool flag73 = list18.Count < paramIndex;
				bool flag74 = !flag73;
				int num18 = list18.Count - paramIndex;
				bool flag75 = num18 == 0;
				bool flag76 = !flag75;
				if (!(flag74 && flag76))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items18 = list18._items;
				Color color = FsmUtility.ByteArrayToColor(byteDataAsArray, items18[paramIndex]);
				float y = color.g;
				float width = color.b;
				float height = color.a;
				Rect rect = (Rect)color;
				result = fsmColor;
			}
			else if (originalParamType == ParamDataType.ObjectReference && currentParamType == ParamDataType.FsmMaterial)
			{
				FsmMaterial fsmMaterial = new FsmMaterial();
				List<int> list19 = paramDataPos;
				List<UnityEngine.Object> list20 = unityObjectParams;
				bool flag77 = list19.Count < paramIndex;
				bool flag78 = !flag77;
				int num19 = list19.Count - paramIndex;
				bool flag79 = num19 == 0;
				bool flag80 = !flag79;
				if (!(flag78 && flag80))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items19 = list19._items;
				bool flag81 = list20.Count < items19[paramIndex];
				bool flag82 = !flag81;
				int num20 = list20.Count - items19[paramIndex];
				bool flag83 = num20 == 0;
				bool flag84 = !flag83;
				if (!(flag82 && flag84))
				{
					throw new ArgumentOutOfRangeException();
				}
				UnityEngine.Object[] items20 = list20._items;
				Material value5;
				if ((object)items20[items19[paramIndex]] == null)
				{
					value5 = null;
				}
				else
				{
					Material material = items20[items19[paramIndex]] as Material;
					value5 = (Material)(((object)material == null) ? null : items20[items19[paramIndex]]);
				}
				fsmMaterial.Value = value5;
				result = fsmMaterial;
			}
			else if (originalParamType == ParamDataType.ObjectReference && currentParamType == ParamDataType.FsmTexture)
			{
				FsmTexture fsmTexture = new FsmTexture();
				List<int> list21 = paramDataPos;
				List<UnityEngine.Object> list22 = unityObjectParams;
				bool flag85 = list21.Count < paramIndex;
				bool flag86 = !flag85;
				int num21 = list21.Count - paramIndex;
				bool flag87 = num21 == 0;
				bool flag88 = !flag87;
				if (!(flag86 && flag88))
				{
					throw new ArgumentOutOfRangeException();
				}
				int[] items21 = list21._items;
				bool flag89 = list22.Count < items21[paramIndex];
				bool flag90 = !flag89;
				int num22 = list22.Count - items21[paramIndex];
				bool flag91 = num22 == 0;
				bool flag92 = !flag91;
				if (!(flag90 && flag92))
				{
					throw new ArgumentOutOfRangeException();
				}
				UnityEngine.Object[] items22 = list22._items;
				Texture value6;
				if ((object)items22[items21[paramIndex]] == null)
				{
					value6 = null;
				}
				else
				{
					Texture texture = items22[items21[paramIndex]] as Texture;
					value6 = (Texture)(((object)texture == null) ? null : items22[items21[paramIndex]]);
				}
				fsmTexture.Value = value6;
				result = fsmTexture;
			}
			else
			{
				bool flag93 = currentParamType != ParamDataType.FsmObject;
				result = null;
				if (!flag93)
				{
					bool flag94 = originalParamType != ParamDataType.ObjectReference;
					result = null;
					if (!flag94)
					{
						FsmObject fsmObject = new FsmObject();
						List<int> list23 = paramDataPos;
						List<UnityEngine.Object> list24 = unityObjectParams;
						bool flag95 = list23.Count < paramIndex;
						bool flag96 = !flag95;
						int num23 = list23.Count - paramIndex;
						bool flag97 = num23 == 0;
						bool flag98 = !flag97;
						if (!(flag96 && flag98))
						{
							throw new ArgumentOutOfRangeException();
						}
						int[] items23 = list23._items;
						bool flag99 = list24.Count < items23[paramIndex];
						bool flag100 = !flag99;
						int num24 = list24.Count - items23[paramIndex];
						bool flag101 = num24 == 0;
						bool flag102 = !flag101;
						if (!(flag100 && flag102))
						{
							throw new ArgumentOutOfRangeException();
						}
						UnityEngine.Object[] items24 = list24._items;
						fsmObject.Value = items24[items23[paramIndex]];
						result = fsmObject;
					}
				}
			}
			goto IL_1917;
			IL_1908:
			FsmString fsmString = new FsmString();
			fsmString.Value = value;
			result = fsmString;
			goto IL_1917;
			IL_1917:
			return result;
			IL_1860:
			return new InvalidCastException();
			IL_185a:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000310")]
		[Address(RVA = "0x9CB9C4", Offset = "0x9CB9C4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.ActionData::ClearActionData(this);\n\tv79 = actions.Length;\n\tv34 = actions.Length < 1;\n\tif (v34) goto L_0049;\nL_001D:\n\tv148 = v50 < v79;\n\tv76 = ~v148;\n\tif (v76) goto L_004A;\n\tv175 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tHutongGames.PlayMaker.ActionData::SaveAction(this, v175, actions[v50 @ X23_v5 (System.Int32)]);\n\tv79 = actions.Length;\n\tv50 = v50 + 1;\n\tv113 = v50 < actions.Length;\n\tif (v113) goto L_001D;\nL_0049:\n\treturn;\nL_004A:\n\tv171 = new System.IndexOutOfRangeException();\n\tthrow v171;\n\tthrow System.NullReferenceException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveActions(FsmState state, FsmStateAction[] actions)
		{
			ClearActionData();
			int num = actions.Length;
			if (actions.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				Fsm fsm = state.Fsm;
				SaveAction(fsm, actions[num2]);
				num = actions.Length;
				num2++;
				if (num2 >= actions.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000311")]
		[Address(RVA = "0x9D3E94", Offset = "0x9D3E94", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1EB73A0]);\n\tv39 = *([v38 @ X8_v32]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, fsm, action, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021A02]) = v56;\nL_001D:\n\tv57 = action == 0;\n\tif (v57) goto L_00EB;\n\tv60 = System.Object::GetType(action);\n\tgoto L_0039;\n\tv219 = *([v158 @ X8_v4 (Il2CppClass<HutongGames.PlayMaker.ActionData>)+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\t// 45 ConditionalJump @b46, v221 @ TEMP_v30\n\tv231 = v158;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v231, v59, action, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv227 = HutongGames.PlayMaker.ActionData;\nL_0039:\n\tv236 = System.Collections.Generic.Dictionary`2<System.Type, System.Int32>::Remove(v228.ActionHashCodeLookup, v60);\n\tv298 = System.Type::ToString(v60);\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.actionNames, v298);\n\tv125 = action + 0x10;\n\tv254 = action.autoName == 0;\n\tv244 = ~v254;\n\tv74 = ~v244;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0063;\nL_0063:\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.customNames, *([v292 @ X8_v14 (System.String)]));\n\tSystem.Collections.Generic.List`1<System.Boolean>::Add(this.actionEnabled, action.enabled);\n\tSystem.Collections.Generic.List`1<System.Boolean>::Add(this.actionIsOpen, action.isOpen);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.actionStartIndex, this.nextParamIndex);\n\tgoto L_0086;\n\tv377 = *([v373 @ X0_v23+E0]);\n\tv378 = v377 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_0086;\n\tv381 = \"il2cpp_codegen_runtime_class_init\"(v373, v372, v333, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0086:\n\tv343 = HutongGames.PlayMaker.ActionData::GetActionTypeHashCode(v60);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.actionHashCodes, v343);\n\tv135 = HutongGames.PlayMaker.ActionData::GetFields(v60);\n\tv363 = v135.Length;\n\tv78 = v135.Length < 1;\n\tif (v78) goto L_00EB;\nL_00A0:\n\tv397 = v306 < v363;\n\tv327 = ~v397;\n\tif (v327) goto L_00EE;\n\tv402 = System.Reflection.FieldInfo::get_FieldType(v135[v306 @ X28_v7 (System.Int32)]);\n\tv407 = System.Reflection.FieldInfo::GetValue(v135[v306 @ X28_v7 (System.Int32)], action);\n\tv345 = System.Reflection.MemberInfo::get_Name(v135[v306 @ X28_v7 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.paramName, v345);\n\tHutongGames.PlayMaker.ActionData::SaveActionField(this, fsm, v402, v407);\n\tv306 = v306 + 1;\n\tv413 = this.nextParamIndex + 1;\n\tthis.nextParamIndex = v413;\n\tv363 = v135.Length;\n\tv77 = v306 < v135.Length;\n\tif (v77) goto L_00A0;\nL_00EB:\n\treturn;\n\tv354 = new System.NullReferenceException();\nL_00EE:\n\tv364 = new System.IndexOutOfRangeException();\n\tthrow v364;\n\tthrow System.NullReferenceException;\n// 183 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SaveAction(Fsm fsm, FsmStateAction action)
		{
			//IL_0063: Expected O, but got I
			if (action == null)
			{
				return;
			}
			Type type = action.GetType();
			bool flag = ActionHashCodeLookup.Remove(type);
			string item = type.ToString();
			ActionNames.Add(item);
			string text = (string)((long)(IntPtr)action + 16L);
			string item2 = ((!action.IsAutoNamed) ? text : "~AutoName");
			customNames.Add(item2);
			actionEnabled.Add(action.Enabled);
			actionIsOpen.Add(action.IsOpen);
			actionStartIndex.Add(nextParamIndex);
			int actionTypeHashCode = GetActionTypeHashCode(type);
			actionHashCodes.Add(actionTypeHashCode);
			FieldInfo[] fields = GetFields(type);
			int num = fields.Length;
			if (fields.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				Type fieldType = fields[num2].FieldType;
				object value = fields[num2].GetValue(action);
				string name = fields[num2].Name;
				paramName.Add(name);
				SaveActionField(fsm, fieldType, value);
				num2++;
				int num3 = nextParamIndex + 1;
				nextParamIndex = num3;
				num = fields.Length;
				if (num2 >= fields.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000312")]
		[Address(RVA = "0x9D4118", Offset = "0x9D4118", Length = "0x2948")]
		private void SaveActionField(Fsm fsm, Type fieldType, object obj)
		{
			//IL_004f: Expected I, but got O
			//IL_1682: Expected F4, but got O
			//IL_16cd: Expected F4, but got O
			//IL_1714: Expected I4, but got O
			//IL_1759: Expected I, but got O
			//IL_32c2: Expected I4, but got O
			//IL_1788: Expected I4, but got O
			//IL_17cd: Expected I4, but got O
			//IL_185f: Expected F4, but got O
			//IL_1874: Expected F4, but got I
			//IL_1889: Expected F4, but got I
			//IL_189e: Expected F4, but got I
			//IL_1142: Expected I4, but got O
			//IL_1931: Expected F4, but got O
			//IL_1946: Expected F4, but got I
			//IL_0f95: Expected I, but got O
			//IL_19d9: Expected F4, but got O
			//IL_19ee: Expected F4, but got I
			//IL_1a03: Expected F4, but got I
			//IL_0fd0: Expected O, but got I
			//IL_105b: Unknown result type (might be due to invalid IL or missing references)
			//IL_1060: Expected O, but got Unknown
			//IL_107d: Expected O, but got I
			//IL_108c: Expected O, but got I
			//IL_1a96: Expected F4, but got O
			//IL_1aab: Expected F4, but got I
			//IL_1ac0: Expected F4, but got I
			//IL_1ad5: Expected F4, but got I
			//IL_101c: Expected O, but got I
			//IL_1b68: Expected F4, but got O
			//IL_1b7d: Expected F4, but got I
			//IL_1b92: Expected F4, but got I
			//IL_1ba7: Expected F4, but got I
			//IL_22da: Expected O, but got I
			//IL_161f: Expected I4, but got O
			//IL_1645: Expected I, but got O
			Type typeFromHandle = typeof(FsmAnimationCurve);
			object item2;
			List<FsmAnimationCurve> list3;
			List<ParamDataType> list12;
			int item3;
			ICollection<byte> bytes;
			InvalidCastException ex2;
			if ((object)typeFromHandle != fieldType)
			{
				Type typeFromHandle2 = typeof(UnityEngine.Object);
				IntPtr intPtr = (IntPtr)typeFromHandle2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v802 @ X8_v46 (Il2CppClass<System.Type>)+848]");
				IntPtr intPtr2 = (IntPtr)0;
				if (typeFromHandle2.IsAssignableFrom(fieldType))
				{
					if (unityObjectParams == null)
					{
						List<UnityEngine.Object> list = new List<UnityEngine.Object>();
						unityObjectParams = list;
					}
					Type typeFromHandle3 = typeof(GameObject);
					ParamDataType item = (((object)typeFromHandle3 != fieldType) ? ParamDataType.ObjectReference : ParamDataType.GameObject);
					paramDataType.Add(item);
					List<UnityEngine.Object> list2 = unityObjectParams;
					paramDataPos.Add(list2.Count);
					paramByteDataSize.Add(0);
					if (obj == null)
					{
						item2 = null;
					}
					else
					{
						UnityEngine.Object obj2 = obj as UnityEngine.Object;
						item2 = (((object)obj2 == null) ? null : obj);
					}
					list3 = (List<FsmAnimationCurve>)(object)unityObjectParams;
				}
				else
				{
					Type typeFromHandle4 = typeof(FunctionCall);
					if ((object)typeFromHandle4 != fieldType)
					{
						Type typeFromHandle5 = typeof(FsmTemplateControl);
						if ((object)typeFromHandle5 != fieldType)
						{
							Type typeFromHandle6 = typeof(FsmVar);
							if ((object)typeFromHandle6 != fieldType)
							{
								Type typeFromHandle7 = typeof(FsmProperty);
								if ((object)typeFromHandle7 != fieldType)
								{
									Type typeFromHandle8 = typeof(FsmEventTarget);
									if ((object)typeFromHandle8 != fieldType)
									{
										Type typeFromHandle9 = typeof(LayoutOption);
										if ((object)typeFromHandle9 != fieldType)
										{
											Type typeFromHandle10 = typeof(FsmGameObject);
											if ((object)typeFromHandle10 != fieldType)
											{
												Type typeFromHandle11 = typeof(FsmOwnerDefault);
												if ((object)typeFromHandle11 != fieldType)
												{
													Type typeFromHandle12 = typeof(FsmString);
													if ((object)typeFromHandle12 != fieldType)
													{
														bool isArray = fieldType.IsArray;
														bool flag = !isArray;
														object obj3 = obj;
														if (!flag)
														{
															Type elementType = fieldType.GetElementType();
															if ((object)elementType == null)
															{
																return;
															}
															Array array2;
															if (obj != null)
															{
																obj3 = obj;
																object typeFromHandle13 = typeof(Array);
																Array array = obj as Array;
																bool flag2 = array == null;
																obj3 = obj;
																typeFromHandle13 = typeof(Array);
																if (flag2)
																{
																	goto IL_3097;
																}
																array2 = (Array)obj;
															}
															else
															{
																Array array3 = Array.CreateInstance(elementType, 0);
																array2 = array3;
															}
															if (arrayParamSizes == null)
															{
																List<int> list4 = new List<int>();
																arrayParamSizes = list4;
																List<string> list5 = new List<string>();
																arrayParamTypes = list5;
															}
															paramDataType.Add(ParamDataType.Array);
															List<int> list6 = arrayParamSizes;
															paramDataPos.Add(list6.Count);
															paramByteDataSize.Add(0);
															int length = array2.Length;
															arrayParamSizes.Add(length);
															string fullName = elementType.FullName;
															arrayParamTypes.Add(fullName);
															IEnumerator enumerator = array2.GetEnumerator();
															bool flag3 = enumerator == null;
															int num = default(int);
															intPtr2 = (IntPtr)num;
															object obj4 = default(object);
															int num6;
															int num7;
															if (!flag3)
															{
																int num5;
																object obj9 = default(object);
																for (obj4 = obj; enumerator.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4038 @ X0_v522] (should have been resolved before IL gen)"), num5 = nextParamIndex + 1, nextParamIndex = num5, paramName.Add(""), SaveActionField(fsm, elementType, obj9), obj4 = obj9)
																{
																	IntPtr intPtr3 = (IntPtr)enumerator;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3928 @ X8_v651 (Il2CppClass<System.Collections.IEnumerator>)+126]");
																	if ((IntPtr)0 != (IntPtr)0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3928 @ X8_v651 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
																		object obj5 = 0L + 8L;
																		int num2 = 0;
																		while (true)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4004 @ X11_v119-8]");
																			if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
																			{
																				break;
																			}
																			num2++;
																			int num3 = num2;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3928 @ X8_v651 (Il2CppClass<System.Collections.IEnumerator>)+126]");
																			bool flag4 = (long)num3 < 0L;
																			bool flag5 = !flag4;
																			obj5 = (long)(IntPtr)obj5 + 16L;
																			if (!flag5)
																			{
																				continue;
																			}
																			goto IL_1035;
																		}
																		object obj6 = obj5 + 1;
																		int num4 = (int)((long)(IntPtr)obj6 << 4);
																		object obj7 = (long)intPtr3 + (long)num4;
																		object obj8 = (long)(IntPtr)obj7 + 304L;
																		num = 0;
																		continue;
																	}
																	goto IL_1035;
																	IL_1035:
																	Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
																	num = 1;
																}
																num6 = 0;
																num7 = 0;
															}
															else
															{
																NullReferenceException ex = new NullReferenceException();
																object obj10 = default(object);
																bool flag6 = (IntPtr)obj10 != (IntPtr)1;
																obj3 = obj4;
																object typeFromHandle13 = obj10;
																ex2 = (InvalidCastException)(object)ex;
																if (flag6)
																{
																	goto IL_30a5;
																}
																Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
																object obj11 = default(object);
																num7 = (int)obj11;
																Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
																num6 = -1;
															}
															(enumerator as IDisposable)?.Dispose();
															if (num6 + 1 != 0)
															{
																return;
															}
															bool flag7 = num7 == 0;
															bool flag8 = !flag7;
															obj3 = obj4;
															if (flag8)
															{
																goto IL_30b9;
															}
														}
														Type typeFromHandle14 = typeof(float);
														if ((object)typeFromHandle14 != fieldType)
														{
															Type typeFromHandle15 = typeof(int);
															if ((object)typeFromHandle15 != fieldType)
															{
																Type typeFromHandle16 = typeof(bool);
																if ((object)typeFromHandle16 != fieldType)
																{
																	Type typeFromHandle17 = typeof(Color);
																	if ((object)typeFromHandle17 != fieldType)
																	{
																		Type typeFromHandle18 = typeof(Vector2);
																		if ((object)typeFromHandle18 != fieldType)
																		{
																			Type typeFromHandle19 = typeof(Vector3);
																			if ((object)typeFromHandle19 != fieldType)
																			{
																				Type typeFromHandle20 = typeof(Vector4);
																				if ((object)typeFromHandle20 != fieldType)
																				{
																					Type typeFromHandle21 = typeof(Rect);
																					if ((object)typeFromHandle21 != fieldType)
																					{
																						Type typeFromHandle22 = typeof(FsmFloat);
																						if ((object)typeFromHandle22 != fieldType)
																						{
																							Type typeFromHandle23 = typeof(FsmInt);
																							if ((object)typeFromHandle23 != fieldType)
																							{
																								Type typeFromHandle24 = typeof(FsmBool);
																								if ((object)typeFromHandle24 != fieldType)
																								{
																									Type typeFromHandle25 = typeof(FsmVector2);
																									if ((object)typeFromHandle25 != fieldType)
																									{
																										Type typeFromHandle26 = typeof(FsmVector3);
																										if ((object)typeFromHandle26 != fieldType)
																										{
																											Type typeFromHandle27 = typeof(FsmRect);
																											if ((object)typeFromHandle27 != fieldType)
																											{
																												Type typeFromHandle28 = typeof(FsmQuaternion);
																												if ((object)typeFromHandle28 != fieldType)
																												{
																													Type typeFromHandle29 = typeof(FsmColor);
																													if ((object)typeFromHandle29 != fieldType)
																													{
																														Type typeFromHandle30 = typeof(FsmEvent);
																														string str;
																														if ((object)typeFromHandle30 != fieldType)
																														{
																															Type typeFromHandle31 = typeof(string);
																															if ((object)typeFromHandle31 != fieldType)
																															{
																																Type typeFromHandle32 = typeof(FsmObject);
																																if ((object)typeFromHandle32 != fieldType)
																																{
																																	Type typeFromHandle33 = typeof(FsmArray);
																																	if ((object)typeFromHandle33 != fieldType)
																																	{
																																		Type typeFromHandle34 = typeof(FsmEnum);
																																		if ((object)typeFromHandle34 != fieldType)
																																		{
																																			Type typeFromHandle35 = typeof(FsmMaterial);
																																			if ((object)typeFromHandle35 != fieldType)
																																			{
																																				Type typeFromHandle36 = typeof(FsmTexture);
																																				if ((object)typeFromHandle36 != fieldType)
																																				{
																																					if (fieldType.IsEnum)
																																					{
																																						paramDataType.Add(ParamDataType.Enum);
																																						int num8 = (int)((obj is int) ? obj : null);
																																						bool flag9 = num8 != 0;
																																						IntPtr intPtr4 = (IntPtr)0;
																																						IntPtr intPtr5 = (IntPtr)typeof(int);
																																						object obj12 = obj;
																																						if (flag9)
																																						{
																																							goto IL_32aa;
																																						}
																																						goto IL_32d3;
																																					}
																																					if (fieldType.IsClass)
																																					{
																																						if (customTypeSizes == null)
																																						{
																																							List<int> list7 = new List<int>();
																																							customTypeSizes = list7;
																																							List<string> list8 = new List<string>();
																																							customTypeNames = list8;
																																						}
																																						bool flag10 = obj == null;
																																						bool flag11 = !flag10;
																																						object obj13 = obj;
																																						if (!flag11)
																																						{
																																							object obj14 = Activator.CreateInstance(fieldType);
																																							obj13 = obj14;
																																						}
																																						paramDataType.Add(ParamDataType.CustomClass);
																																						List<int> list9 = customTypeSizes;
																																						paramDataPos.Add(list9.Count);
																																						string fullName2 = fieldType.FullName;
																																						customTypeNames.Add(fullName2);
																																						paramByteDataSize.Add(0);
																																						FieldInfo[] fields = GetFields(fieldType);
																																						customTypeSizes.Add(fields.Length);
																																						int num9 = fields.Length;
																																						if (fields.Length < 1)
																																						{
																																							return;
																																						}
																																						int num10 = 0;
																																						while (num10 < num9)
																																						{
																																							int num11 = nextParamIndex + 1;
																																							nextParamIndex = num11;
																																							string name = fields[num10].Name;
																																							paramName.Add(name);
																																							Type fieldType2 = fields[num10].FieldType;
																																							object value = fields[num10].GetValue(obj13);
																																							SaveActionField(fsm, fieldType2, value);
																																							num9 = fields.Length;
																																							num10++;
																																							if (num10 >= fields.Length)
																																							{
																																								return;
																																							}
																																						}
																																						goto IL_30bf;
																																					}
																																					if (obj != null)
																																					{
																																						string message = "Save Action: Unsupported parameter type: " + fieldType;
																																						Debug.LogError(message);
																																					}
																																					paramDataType.Add(ParamDataType.Unsupported);
																																					List<byte> list10 = byteData;
																																					paramDataPos.Add(list10.Count);
																																					paramByteDataSize.Add(0);
																																					return;
																																				}
																																				if (fsmObjectParams == null)
																																				{
																																					List<FsmObject> list11 = new List<FsmObject>();
																																					fsmObjectParams = list11;
																																				}
																																				list12 = paramDataType;
																																				item3 = 33;
																																			}
																																			else
																																			{
																																				if (fsmObjectParams == null)
																																				{
																																					List<FsmObject> list13 = new List<FsmObject>();
																																					fsmObjectParams = list13;
																																				}
																																				list12 = paramDataType;
																																				item3 = 32;
																																			}
																																			goto IL_34ad;
																																		}
																																		if (fsmEnumParams == null)
																																		{
																																			List<FsmEnum> list14 = new List<FsmEnum>();
																																			fsmEnumParams = list14;
																																		}
																																		paramDataType.Add(ParamDataType.FsmEnum);
																																		List<FsmEnum> list15 = fsmEnumParams;
																																		paramDataPos.Add(list15.Count);
																																		paramByteDataSize.Add(0);
																																		if (obj == null)
																																		{
																																			item2 = null;
																																		}
																																		else
																																		{
																																			FsmEnum fsmEnum = obj as FsmEnum;
																																			item2 = ((fsmEnum == null) ? null : obj);
																																		}
																																		list3 = (List<FsmAnimationCurve>)(object)fsmEnumParams;
																																	}
																																	else
																																	{
																																		if (fsmArrayParams == null)
																																		{
																																			List<FsmArray> list16 = new List<FsmArray>();
																																			fsmArrayParams = list16;
																																		}
																																		paramDataType.Add(ParamDataType.FsmArray);
																																		List<FsmArray> list17 = fsmArrayParams;
																																		paramDataPos.Add(list17.Count);
																																		paramByteDataSize.Add(0);
																																		if (obj == null)
																																		{
																																			item2 = null;
																																		}
																																		else
																																		{
																																			FsmArray fsmArray = obj as FsmArray;
																																			item2 = ((fsmArray == null) ? null : obj);
																																		}
																																		list3 = (List<FsmAnimationCurve>)(object)fsmArrayParams;
																																	}
																																	goto IL_352f;
																																}
																																if (fsmObjectParams == null)
																																{
																																	List<FsmObject> list18 = new List<FsmObject>();
																																	fsmObjectParams = list18;
																																}
																																list12 = paramDataType;
																																item3 = 24;
																																goto IL_34ad;
																															}
																															paramDataType.Add(ParamDataType.String);
																															if (obj != null)
																															{
																																object obj15 = (((object)obj.GetType() != typeof(string)) ? null : obj);
																																str = (string)obj15;
																															}
																															else
																															{
																																str = null;
																															}
																															if (fsm.DataVersion < 2)
																															{
																																byte[] array4 = FsmUtility.StringToByteArray(str);
																																IntPtr intPtr4 = (IntPtr)0;
																																bytes = array4;
																																goto IL_2bd8;
																															}
																														}
																														else
																														{
																															paramDataType.Add(ParamDataType.FsmEvent);
																															if (fsm.DataVersion < 2)
																															{
																																FsmEvent fsmEvent;
																																if (obj == null)
																																{
																																	fsmEvent = null;
																																}
																																else
																																{
																																	FsmEvent fsmEvent2 = obj as FsmEvent;
																																	fsmEvent = (FsmEvent)((fsmEvent2 == null) ? null : obj);
																																}
																																bytes = FsmUtility.FsmEventToByteArray(fsmEvent);
																																IntPtr intPtr4 = (IntPtr)0;
																																goto IL_2bd8;
																															}
																															if (obj != null)
																															{
																																FsmEvent fsmEvent3 = obj as FsmEvent;
																																if (fsmEvent3 == null)
																																{
																																	goto IL_32d3;
																																}
																															}
																															str = string.Empty;
																														}
																														SaveString(str);
																														return;
																													}
																													paramDataType.Add(ParamDataType.FsmColor);
																													if (fsm.DataVersion < 2)
																													{
																														FsmColor fsmColor;
																														if (obj == null)
																														{
																															fsmColor = null;
																														}
																														else
																														{
																															FsmColor fsmColor2 = obj as FsmColor;
																															fsmColor = (FsmColor)((fsmColor2 == null) ? null : obj);
																														}
																														bytes = FsmUtility.FsmColorToByteArray(fsmColor);
																														IntPtr intPtr4 = (IntPtr)0;
																														goto IL_2bd8;
																													}
																													List<FsmColor> list19 = fsmColorParams;
																													if (fsmColorParams == null)
																													{
																														list19 = (fsmColorParams = new List<FsmColor>());
																													}
																													paramDataPos.Add(list19.Count);
																													paramByteDataSize.Add(0);
																													if (obj == null)
																													{
																														item2 = null;
																													}
																													else
																													{
																														FsmColor fsmColor3 = obj as FsmColor;
																														item2 = ((fsmColor3 == null) ? null : obj);
																													}
																													list3 = (List<FsmAnimationCurve>)(object)fsmColorParams;
																												}
																												else
																												{
																													paramDataType.Add(ParamDataType.FsmQuaternion);
																													if (fsm.DataVersion < 2)
																													{
																														FsmQuaternion fsmQuaternion;
																														if (obj == null)
																														{
																															fsmQuaternion = null;
																														}
																														else
																														{
																															FsmQuaternion fsmQuaternion2 = obj as FsmQuaternion;
																															fsmQuaternion = (FsmQuaternion)((fsmQuaternion2 == null) ? null : obj);
																														}
																														bytes = FsmUtility.FsmQuaternionToByteArray(fsmQuaternion);
																														IntPtr intPtr4 = (IntPtr)0;
																														goto IL_2bd8;
																													}
																													List<FsmQuaternion> list20 = fsmQuaternionParams;
																													if (fsmQuaternionParams == null)
																													{
																														list20 = (fsmQuaternionParams = new List<FsmQuaternion>());
																													}
																													paramDataPos.Add(list20.Count);
																													paramByteDataSize.Add(0);
																													if (obj == null)
																													{
																														item2 = null;
																													}
																													else
																													{
																														FsmQuaternion fsmQuaternion3 = obj as FsmQuaternion;
																														item2 = ((fsmQuaternion3 == null) ? null : obj);
																													}
																													list3 = (List<FsmAnimationCurve>)(object)fsmQuaternionParams;
																												}
																											}
																											else
																											{
																												paramDataType.Add(ParamDataType.FsmRect);
																												if (fsm.DataVersion < 2)
																												{
																													FsmRect fsmRect;
																													if (obj == null)
																													{
																														fsmRect = null;
																													}
																													else
																													{
																														FsmRect fsmRect2 = obj as FsmRect;
																														fsmRect = (FsmRect)((fsmRect2 == null) ? null : obj);
																													}
																													bytes = FsmUtility.FsmRectToByteArray(fsmRect);
																													IntPtr intPtr4 = (IntPtr)0;
																													goto IL_2bd8;
																												}
																												List<FsmRect> list21 = fsmRectParams;
																												if (fsmRectParams == null)
																												{
																													list21 = (fsmRectParams = new List<FsmRect>());
																												}
																												paramDataPos.Add(list21.Count);
																												paramByteDataSize.Add(0);
																												if (obj != null)
																												{
																													Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9E2A88 (inside HutongGames.PlayMaker.Fsm::.cctor +0x2D4)");
																													return;
																												}
																												item2 = null;
																												list3 = (List<FsmAnimationCurve>)(object)fsmRectParams;
																											}
																										}
																										else
																										{
																											paramDataType.Add(ParamDataType.FsmVector3);
																											if (fsm.DataVersion < 2)
																											{
																												FsmVector3 fsmVector;
																												if (obj == null)
																												{
																													fsmVector = null;
																												}
																												else
																												{
																													FsmVector3 fsmVector2 = obj as FsmVector3;
																													fsmVector = (FsmVector3)((fsmVector2 == null) ? null : obj);
																												}
																												bytes = FsmUtility.FsmVector3ToByteArray(fsmVector);
																												IntPtr intPtr4 = (IntPtr)0;
																												goto IL_2bd8;
																											}
																											List<FsmVector3> list22 = fsmVector3Params;
																											if (fsmVector3Params == null)
																											{
																												list22 = (fsmVector3Params = new List<FsmVector3>());
																											}
																											paramDataPos.Add(list22.Count);
																											paramByteDataSize.Add(0);
																											if (obj == null)
																											{
																												item2 = null;
																											}
																											else
																											{
																												FsmVector3 fsmVector3 = obj as FsmVector3;
																												item2 = ((fsmVector3 == null) ? null : obj);
																											}
																											list3 = (List<FsmAnimationCurve>)(object)fsmVector3Params;
																										}
																									}
																									else
																									{
																										paramDataType.Add(ParamDataType.FsmVector2);
																										if (fsm.DataVersion < 2)
																										{
																											FsmVector2 fsmVector4;
																											if (obj == null)
																											{
																												fsmVector4 = null;
																											}
																											else
																											{
																												FsmVector2 fsmVector5 = obj as FsmVector2;
																												fsmVector4 = (FsmVector2)((fsmVector5 == null) ? null : obj);
																											}
																											bytes = FsmUtility.FsmVector2ToByteArray(fsmVector4);
																											IntPtr intPtr4 = (IntPtr)0;
																											goto IL_2bd8;
																										}
																										List<FsmVector2> list23 = fsmVector2Params;
																										if (fsmVector2Params == null)
																										{
																											list23 = (fsmVector2Params = new List<FsmVector2>());
																										}
																										paramDataPos.Add(list23.Count);
																										paramByteDataSize.Add(0);
																										if (obj == null)
																										{
																											item2 = null;
																										}
																										else
																										{
																											FsmVector2 fsmVector6 = obj as FsmVector2;
																											item2 = ((fsmVector6 == null) ? null : obj);
																										}
																										list3 = (List<FsmAnimationCurve>)(object)fsmVector2Params;
																									}
																								}
																								else
																								{
																									paramDataType.Add(ParamDataType.FsmBool);
																									if (fsm.DataVersion < 2)
																									{
																										FsmBool fsmBool;
																										if (obj == null)
																										{
																											IntPtr intPtr4 = (IntPtr)0;
																											fsmBool = null;
																										}
																										else
																										{
																											object obj16 = default(object);
																											int num12 = (int)((long)(IntPtr)obj16 << 3);
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v823 @ X9_v13 (Il2CppClass<System.Object>)+C8]");
																											object obj17 = 0L + (long)num12;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v852 @ X9_v15-8]");
																											IntPtr intPtr6 = default(IntPtr);
																											fsmBool = (FsmBool)(((IntPtr)0 != intPtr6) ? null : obj);
																										}
																										bytes = FsmUtility.FsmBoolToByteArray(fsmBool);
																										goto IL_2bd8;
																									}
																									List<FsmBool> list24 = fsmBoolParams;
																									if (fsmBoolParams == null)
																									{
																										list24 = (fsmBoolParams = new List<FsmBool>());
																									}
																									paramDataPos.Add(list24.Count);
																									paramByteDataSize.Add(0);
																									if (obj == null)
																									{
																										item2 = null;
																									}
																									else
																									{
																										FsmBool fsmBool2 = obj as FsmBool;
																										item2 = ((fsmBool2 == null) ? null : obj);
																									}
																									list3 = (List<FsmAnimationCurve>)(object)fsmBoolParams;
																								}
																							}
																							else
																							{
																								paramDataType.Add(ParamDataType.FsmInt);
																								if (fsm.DataVersion < 2)
																								{
																									FsmInt fsmInt;
																									if (obj == null)
																									{
																										fsmInt = null;
																									}
																									else
																									{
																										FsmInt fsmInt2 = obj as FsmInt;
																										fsmInt = (FsmInt)((fsmInt2 == null) ? null : obj);
																									}
																									bytes = FsmUtility.FsmIntToByteArray(fsmInt);
																									IntPtr intPtr4 = (IntPtr)0;
																									goto IL_2bd8;
																								}
																								List<FsmInt> list25 = fsmIntParams;
																								if (fsmIntParams == null)
																								{
																									list25 = (fsmIntParams = new List<FsmInt>());
																								}
																								paramDataPos.Add(list25.Count);
																								paramByteDataSize.Add(0);
																								if (obj == null)
																								{
																									item2 = null;
																								}
																								else
																								{
																									FsmInt fsmInt3 = obj as FsmInt;
																									item2 = ((fsmInt3 == null) ? null : obj);
																								}
																								list3 = (List<FsmAnimationCurve>)(object)fsmIntParams;
																							}
																						}
																						else
																						{
																							paramDataType.Add(ParamDataType.FsmFloat);
																							if (fsm.DataVersion < 2)
																							{
																								FsmFloat fsmFloat;
																								if (obj == null)
																								{
																									fsmFloat = null;
																								}
																								else
																								{
																									FsmFloat fsmFloat2 = obj as FsmFloat;
																									fsmFloat = (FsmFloat)((fsmFloat2 == null) ? null : obj);
																								}
																								bytes = FsmUtility.FsmFloatToByteArray(fsmFloat);
																								IntPtr intPtr4 = (IntPtr)0;
																								goto IL_2bd8;
																							}
																							List<FsmFloat> list26 = fsmFloatParams;
																							if (fsmFloatParams == null)
																							{
																								list26 = (fsmFloatParams = new List<FsmFloat>());
																							}
																							paramDataPos.Add(list26.Count);
																							paramByteDataSize.Add(0);
																							if (obj == null)
																							{
																								item2 = null;
																							}
																							else
																							{
																								FsmFloat fsmFloat3 = obj as FsmFloat;
																								item2 = ((fsmFloat3 == null) ? null : obj);
																							}
																							list3 = (List<FsmAnimationCurve>)(object)fsmFloatParams;
																						}
																						goto IL_352f;
																					}
																					paramDataType.Add(ParamDataType.Rect);
																					bool flag12 = ((Rect)((obj is Rect) ? obj : null)).x == 0f;
																					intPtr2 = (IntPtr)0;
																					object typeFromHandle13 = typeof(Rect);
																					if (!flag12)
																					{
																						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																						Rect rect = default(Rect);
																						object obj18 = default(object);
																						rect.x = (float)obj18;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4082 @ X0_v230+4]");
																						rect.y = 0f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4082 @ X0_v230+8]");
																						rect.width = 0f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4082 @ X0_v230+C]");
																						rect.height = 0f;
																						bytes = FsmUtility.RectToByteArray(rect);
																						IntPtr intPtr4 = (IntPtr)0;
																						goto IL_2bd8;
																					}
																				}
																				else
																				{
																					paramDataType.Add(ParamDataType.Vector4);
																					bool flag13 = ((Vector4)((obj is Vector4) ? obj : null)).x == 0f;
																					intPtr2 = (IntPtr)0;
																					object typeFromHandle13 = typeof(Vector4);
																					if (!flag13)
																					{
																						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																						Vector4 vector = default(Vector4);
																						object obj19 = default(object);
																						vector.x = (float)obj19;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3945 @ X0_v221+4]");
																						vector.y = 0f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3945 @ X0_v221+8]");
																						vector.z = 0f;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3945 @ X0_v221+C]");
																						vector.w = 0f;
																						bytes = FsmUtility.Vector4ToByteArray(vector);
																						IntPtr intPtr4 = (IntPtr)0;
																						goto IL_2bd8;
																					}
																				}
																			}
																			else
																			{
																				paramDataType.Add(ParamDataType.Vector3);
																				bool flag14 = ((Vector3)((obj is Vector3) ? obj : null)).x == 0f;
																				intPtr2 = (IntPtr)0;
																				object typeFromHandle13 = typeof(Vector3);
																				if (!flag14)
																				{
																					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																					Vector3 vector2 = default(Vector3);
																					object obj20 = default(object);
																					vector2.x = (float)obj20;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3864 @ X0_v212+4]");
																					vector2.y = 0f;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3864 @ X0_v212+8]");
																					vector2.z = 0f;
																					bytes = FsmUtility.Vector3ToByteArray(vector2);
																					IntPtr intPtr4 = (IntPtr)0;
																					goto IL_2bd8;
																				}
																			}
																		}
																		else
																		{
																			paramDataType.Add(ParamDataType.Vector2);
																			bool flag15 = ((Vector2)((obj is Vector2) ? obj : null)).x == 0f;
																			intPtr2 = (IntPtr)0;
																			object typeFromHandle13 = typeof(Vector2);
																			if (!flag15)
																			{
																				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																				Vector2 vector3 = default(Vector2);
																				object obj21 = default(object);
																				vector3.x = (float)obj21;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3749 @ X0_v203+4]");
																				vector3.y = 0f;
																				bytes = FsmUtility.Vector2ToByteArray(vector3);
																				IntPtr intPtr4 = (IntPtr)0;
																				goto IL_2bd8;
																			}
																		}
																	}
																	else
																	{
																		paramDataType.Add(ParamDataType.Color);
																		bool flag16 = ((Color)((obj is Color) ? obj : null)).r == 0f;
																		intPtr2 = (IntPtr)0;
																		object typeFromHandle13 = typeof(Color);
																		if (!flag16)
																		{
																			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																			Color color = default(Color);
																			object obj22 = default(object);
																			color.r = (float)obj22;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3720 @ X0_v194+4]");
																			color.g = 0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3720 @ X0_v194+8]");
																			color.b = 0f;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3720 @ X0_v194+C]");
																			color.a = 0f;
																			bytes = FsmUtility.ColorToByteArray(color);
																			IntPtr intPtr4 = (IntPtr)0;
																			goto IL_2bd8;
																		}
																	}
																}
																else
																{
																	paramDataType.Add(ParamDataType.Boolean);
																	bool flag17 = (byte)(int)((obj is bool) ? obj : null) != 0;
																	bool flag18 = !flag17;
																	intPtr2 = (IntPtr)0;
																	object typeFromHandle13 = typeof(bool);
																	if (!flag18)
																	{
																		Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																		object obj23 = default(object);
																		byte[] bytes2 = FsmUtility.BitConverter.GetBytes((byte)(int)obj23 != 0);
																		IntPtr intPtr4 = (IntPtr)0;
																		bytes = bytes2;
																		goto IL_2bd8;
																	}
																}
															}
															else
															{
																paramDataType.Add(default(ParamDataType));
																int num13 = (int)((obj is int) ? obj : null);
																bool flag19 = num13 == 0;
																intPtr2 = (IntPtr)0;
																object typeFromHandle13 = typeof(int);
																if (!flag19)
																{
																	IntPtr intPtr4 = (IntPtr)0;
																	IntPtr intPtr5 = (IntPtr)typeof(int);
																	object obj12 = obj;
																	goto IL_32aa;
																}
															}
														}
														else
														{
															paramDataType.Add(ParamDataType.Float);
															float num14 = (float)((obj is float) ? obj : null);
															bool flag20 = num14 == 0f;
															intPtr2 = (IntPtr)0;
															object typeFromHandle13 = typeof(float);
															if (!flag20)
															{
																Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
																object obj24 = default(object);
																byte[] bytes3 = FsmUtility.BitConverter.GetBytes((float)obj24);
																IntPtr intPtr4 = (IntPtr)0;
																bytes = bytes3;
																goto IL_2bd8;
															}
														}
														goto IL_3097;
													}
													if (fsmStringParams == null)
													{
														List<FsmString> list27 = new List<FsmString>();
														fsmStringParams = list27;
													}
													paramDataType.Add(ParamDataType.FsmString);
													List<FsmString> list28 = fsmStringParams;
													paramDataPos.Add(list28.Count);
													paramByteDataSize.Add(0);
													if (obj == null)
													{
														item2 = null;
													}
													else
													{
														FsmString fsmString = obj as FsmString;
														item2 = ((fsmString == null) ? null : obj);
													}
													list3 = (List<FsmAnimationCurve>)(object)fsmStringParams;
												}
												else
												{
													if (fsmOwnerDefaultParams == null)
													{
														List<FsmOwnerDefault> list29 = new List<FsmOwnerDefault>();
														fsmOwnerDefaultParams = list29;
													}
													paramDataType.Add(ParamDataType.FsmOwnerDefault);
													List<FsmOwnerDefault> list30 = fsmOwnerDefaultParams;
													paramDataPos.Add(list30.Count);
													paramByteDataSize.Add(0);
													if (obj == null)
													{
														item2 = null;
													}
													else
													{
														FsmOwnerDefault fsmOwnerDefault = obj as FsmOwnerDefault;
														item2 = ((fsmOwnerDefault == null) ? null : obj);
													}
													list3 = (List<FsmAnimationCurve>)(object)fsmOwnerDefaultParams;
												}
											}
											else
											{
												if (fsmGameObjectParams == null)
												{
													List<FsmGameObject> list31 = new List<FsmGameObject>();
													fsmGameObjectParams = list31;
												}
												paramDataType.Add(ParamDataType.FsmGameObject);
												List<FsmGameObject> list32 = fsmGameObjectParams;
												paramDataPos.Add(list32.Count);
												paramByteDataSize.Add(0);
												if (obj == null)
												{
													item2 = null;
												}
												else
												{
													FsmGameObject fsmGameObject = obj as FsmGameObject;
													item2 = ((fsmGameObject == null) ? null : obj);
												}
												list3 = (List<FsmAnimationCurve>)(object)fsmGameObjectParams;
											}
										}
										else
										{
											if (layoutOptionParams == null)
											{
												List<LayoutOption> list33 = new List<LayoutOption>();
												layoutOptionParams = list33;
											}
											paramDataType.Add(ParamDataType.LayoutOption);
											List<LayoutOption> list34 = layoutOptionParams;
											paramDataPos.Add(list34.Count);
											paramByteDataSize.Add(0);
											if (obj == null)
											{
												item2 = null;
											}
											else
											{
												LayoutOption layoutOption = obj as LayoutOption;
												item2 = ((layoutOption == null) ? null : obj);
											}
											list3 = (List<FsmAnimationCurve>)(object)layoutOptionParams;
										}
									}
									else
									{
										if (fsmEventTargetParams == null)
										{
											List<FsmEventTarget> list35 = new List<FsmEventTarget>();
											fsmEventTargetParams = list35;
										}
										paramDataType.Add(ParamDataType.FsmEventTarget);
										List<FsmEventTarget> list36 = fsmEventTargetParams;
										paramDataPos.Add(list36.Count);
										paramByteDataSize.Add(0);
										if (obj == null)
										{
											item2 = null;
										}
										else
										{
											FsmEventTarget fsmEventTarget = obj as FsmEventTarget;
											item2 = ((fsmEventTarget == null) ? null : obj);
										}
										list3 = (List<FsmAnimationCurve>)(object)fsmEventTargetParams;
									}
								}
								else
								{
									if (fsmPropertyParams == null)
									{
										List<FsmProperty> list37 = new List<FsmProperty>();
										fsmPropertyParams = list37;
									}
									paramDataType.Add(ParamDataType.FsmProperty);
									List<FsmProperty> list38 = fsmPropertyParams;
									paramDataPos.Add(list38.Count);
									paramByteDataSize.Add(0);
									if (obj == null)
									{
										item2 = null;
									}
									else
									{
										FsmProperty fsmProperty = obj as FsmProperty;
										item2 = ((fsmProperty == null) ? null : obj);
									}
									list3 = (List<FsmAnimationCurve>)(object)fsmPropertyParams;
								}
							}
							else
							{
								if (fsmVarParams == null)
								{
									List<FsmVar> list39 = new List<FsmVar>();
									fsmVarParams = list39;
								}
								paramDataType.Add(ParamDataType.FsmVar);
								List<FsmVar> list40 = fsmVarParams;
								paramDataPos.Add(list40.Count);
								paramByteDataSize.Add(0);
								if (obj == null)
								{
									item2 = null;
								}
								else
								{
									FsmVar fsmVar = obj as FsmVar;
									item2 = ((fsmVar == null) ? null : obj);
								}
								list3 = (List<FsmAnimationCurve>)(object)fsmVarParams;
							}
						}
						else
						{
							if (fsmTemplateControlParams == null)
							{
								List<FsmTemplateControl> list41 = new List<FsmTemplateControl>();
								fsmTemplateControlParams = list41;
							}
							paramDataType.Add(ParamDataType.FsmTemplateControl);
							List<FsmTemplateControl> list42 = fsmTemplateControlParams;
							paramDataPos.Add(list42.Count);
							paramByteDataSize.Add(0);
							if (obj == null)
							{
								item2 = null;
							}
							else
							{
								FsmTemplateControl fsmTemplateControl = obj as FsmTemplateControl;
								item2 = ((fsmTemplateControl == null) ? null : obj);
							}
							list3 = (List<FsmAnimationCurve>)(object)fsmTemplateControlParams;
						}
					}
					else
					{
						if (functionCallParams == null)
						{
							List<FunctionCall> list43 = new List<FunctionCall>();
							functionCallParams = list43;
						}
						paramDataType.Add(ParamDataType.FunctionCall);
						List<FunctionCall> list44 = functionCallParams;
						paramDataPos.Add(list44.Count);
						paramByteDataSize.Add(0);
						if (obj == null)
						{
							item2 = null;
						}
						else
						{
							FunctionCall functionCall = obj as FunctionCall;
							item2 = ((functionCall == null) ? null : obj);
						}
						list3 = (List<FsmAnimationCurve>)(object)functionCallParams;
					}
				}
			}
			else
			{
				if (animationCurveParams == null)
				{
					List<FsmAnimationCurve> list45 = new List<FsmAnimationCurve>();
					animationCurveParams = list45;
				}
				paramDataType.Add(ParamDataType.FsmAnimationCurve);
				List<FsmAnimationCurve> list46 = animationCurveParams;
				paramDataPos.Add(list46.Count);
				paramByteDataSize.Add(0);
				list3 = animationCurveParams;
				if (obj == null)
				{
					item2 = null;
				}
				else
				{
					FsmAnimationCurve fsmAnimationCurve = obj as FsmAnimationCurve;
					item2 = ((fsmAnimationCurve == null) ? null : obj);
				}
			}
			goto IL_352f;
			IL_30bf:
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
			IL_34ad:
			list12.Add((ParamDataType)item3);
			List<FsmObject> list47 = fsmObjectParams;
			paramDataPos.Add(list47.Count);
			paramByteDataSize.Add(0);
			if (obj == null)
			{
				item2 = null;
			}
			else
			{
				FsmObject fsmObject = obj as FsmObject;
				item2 = ((fsmObject == null) ? null : obj);
			}
			list3 = (List<FsmAnimationCurve>)(object)fsmObjectParams;
			goto IL_352f;
			IL_30a5:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			goto IL_30b9;
			IL_30b9:
			throw new TypeLoadException();
			IL_32d3:
			InvalidCastException ex4 = new InvalidCastException();
			goto IL_30bf;
			IL_2bd8:
			AddByteData(bytes);
			return;
			IL_352f:
			list3.Add((FsmAnimationCurve)item2);
			return;
			IL_32aa:
			Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			object obj25 = default(object);
			byte[] bytes4 = FsmUtility.BitConverter.GetBytes((int)obj25);
			bytes = bytes4;
			goto IL_2bd8;
			IL_3097:
			ex2 = new InvalidCastException();
			goto IL_30a5;
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0x9D6A60", Offset = "0x9D6A60", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EF5410]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, bytes, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021A04]) = v43;\nL_0016:\n\tv44 = this.byteData;\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.paramDataPos, v44._size);\n\tv134 = bytes == 0;\n\tif (v134) goto L_0056;\n\tgoto L_005F;\n\tv184 = *([v136 @ X8_v6+B0]);\n\tv185 = 0;\n\tv186 = v184 + 8;\n\tv188 = *([v224 @ X11_v7-8]);\n\tv230 = v188 == v139;\n\tif (v230) goto L_0058;\n\tv210 = v225 + 1;\n\tv235 = v210 < v138;\n\tv206 = ~v235;\n\tv208 = v224 + 0x10;\n\tv190 = ~v206;\n\tif (v190) goto L_FFFFFFFF;\n\tv211 = v16;\n\tv212 = 0;\n\tv213 = 0x8909C4(v211, v139, v212, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_005F;\nL_0056:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.paramByteDataSize, 0);\n\treturn;\nL_0058:\n\tv236 = *([v224 @ X11_v7]);\n\tv237 = v236 << 4;\n\tv238 = v136 + v237;\n\tv239 = v238 + 0x130;\nL_005F:\n\tv99 = System.Collections.Generic.ICollection`1<System.Byte>::get_Count(bytes);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.paramByteDataSize, v99);\n\tSystem.Collections.Generic.List`1<System.Byte>::AddRange(this.byteData, bytes);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddByteData(ICollection<byte> bytes)
		{
			List<byte> list = byteData;
			paramDataPos.Add(list.Count);
			if (bytes == null)
			{
				paramByteDataSize.Add(0);
				return;
			}
			int count = bytes.Count;
			paramByteDataSize.Add(count);
			byteData.AddRange(bytes);
		}

		[Token(Token = "0x6000314")]
		[Address(RVA = "0x9D6B94", Offset = "0x9D6B94", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB0FE0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, str, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021A05]) = v41;\nL_0015:\n\tv56 = this.stringParams;\n\tv43 = this.stringParams == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002C;\n\tv48 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v48);\n\tthis.stringParams = v48;\nL_002C:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.paramDataPos, v56._size);\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.paramByteDataSize, 0);\n\tv100 = str == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0048;\n\tv77 = v105.Empty;\nL_0048:\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.stringParams, v77);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SaveString(string str)
		{
			List<string> list = stringParams;
			if (stringParams == null)
			{
				list = (stringParams = new List<string>());
			}
			paramDataPos.Add(list.Count);
			paramByteDataSize.Add(0);
			bool flag = str == null;
			bool flag2 = !flag;
			string item = str;
			if (!flag2)
			{
				item = string.Empty;
			}
			stringParams.Add(item);
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0x9D2988", Offset = "0x9D2988", Length = "0xA44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = *([1F07B80]);\n\tv21 = *([v20 @ X8_v161]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021A06]) = v40;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmOwnerDefault);\n\tv64 = v59 == type;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_003F;\n\tv77 = *([v70 @ X0_v8+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_003F;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v70, v58, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003F:\n\tv86 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEventTarget);\n\tv285 = v86 == type;\n\tif (v285) goto L_FFFFFFFF;\n\tgoto L_0059;\n\tv666 = *([v662 @ X0_v13+E0]);\n\tv667 = v666 == 0;\n\tv668 = ~v667;\n\tif (v668) goto L_0059;\n\tv670 = \"il2cpp_codegen_runtime_class_init\"(v662, v85, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0059:\n\tv672 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmEvent);\n\tv286 = v672 == type;\n\tif (v286) goto L_FFFFFFFF;\n\tgoto L_0073;\n\tv679 = *([v675 @ X0_v18+E0]);\n\tv680 = v679 == 0;\n\tv681 = ~v680;\n\tif (v681) goto L_0073;\n\tv683 = \"il2cpp_codegen_runtime_class_init\"(v675, v436, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0073:\n\tv685 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmFloat);\n\tv287 = v685 == type;\n\tif (v287) goto L_FFFFFFFF;\n\tgoto L_008D;\n\tv692 = *([v688 @ X0_v23+E0]);\n\tv693 = v692 == 0;\n\tv694 = ~v693;\n\tif (v694) goto L_008D;\n\tv696 = \"il2cpp_codegen_runtime_class_init\"(v688, v437, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008D:\n\tv698 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmInt);\n\tv288 = v698 == type;\n\tif (v288) goto L_FFFFFFFF;\n\tgoto L_00A7;\n\tv705 = *([v701 @ X0_v28+E0]);\n\tv706 = v705 == 0;\n\tv707 = ~v706;\n\tif (v707) goto L_00A7;\n\tv709 = \"il2cpp_codegen_runtime_class_init\"(v701, v438, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A7:\n\tv711 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmBool);\n\tv289 = v711 == type;\n\tif (v289) goto L_FFFFFFFF;\n\tgoto L_00C1;\n\tv718 = *([v714 @ X0_v33+E0]);\n\tv719 = v718 == 0;\n\tv720 = ~v719;\n\tif (v720) goto L_00C1;\n\tv722 = \"il2cpp_codegen_runtime_class_init\"(v714, v439, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00C1:\n\tv724 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmString);\n\tv290 = v724 == type;\n\tif (v290) goto L_FFFFFFFF;\n\tgoto L_00DB;\n\tv731 = *([v727 @ X0_v38+E0]);\n\tv732 = v731 == 0;\n\tv733 = ~v732;\n\tif (v733) goto L_00DB;\n\tv735 = \"il2cpp_codegen_runtime_class_init\"(v727, v440, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DB:\n\tv737 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmGameObject);\n\tv291 = v737 == type;\n\tif (v291) goto L_FFFFFFFF;\n\tgoto L_00F5;\n\tv744 = *([v740 @ X0_v43+E0]);\n\tv745 = v744 == 0;\n\tv746 = ~v745;\n\tif (v746) goto L_00F5;\n\tv748 = \"il2cpp_codegen_runtime_class_init\"(v740, v441, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00F5:\n\tv750 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FunctionCall);\n\tv292 = v750 == type;\n\tif (v292) goto L_FFFFFFFF;\n\tgoto L_010F;\n\tv757 = *([v753 @ X0_v48+E0]);\n\tv758 = v757 == 0;\n\tv759 = ~v758;\n\tif (v759) goto L_010F;\n\tv761 = \"il2cpp_codegen_runtime_class_init\"(v753, v442, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_010F:\n\tv763 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmProperty);\n\tv293 = v763 == type;\n\tif (v293) goto L_FFFFFFFF;\n\tgoto L_0129;\n\tv770 = *([v766 @ X0_v53+E0]);\n\tv771 = v770 == 0;\n\tv772 = ~v771;\n\tif (v772) goto L_0129;\n\tv774 = \"il2cpp_codegen_runtime_class_init\"(v766, v443, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0129:\n\tv776 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector2);\n\tv294 = v776 == type;\n\tif (v294) goto L_FFFFFFFF;\n\tgoto L_0143;\n\tv783 = *([v779 @ X0_v58+E0]);\n\tv784 = v783 == 0;\n\tv785 = ~v784;\n\tif (v785) goto L_0143;\n\tv787 = \"il2cpp_codegen_runtime_class_init\"(v779, v444, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0143:\n\tv789 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmVector3);\n\tv295 = v789 == type;\n\tif (v295) goto L_FFFFFFFF;\n\tgoto L_015D;\n\tv796 = *([v792 @ X0_v63+E0]);\n\tv797 = v796 == 0;\n\tv798 = ~v797;\n\tif (v798) goto L_015D;\n\tv800 = \"il2cpp_codegen_runtime_class_init\"(v792, v445, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_015D:\n\tv802 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmRect);\n\tv296 = v802 == type;\n\tif (v296) goto L_FFFFFFFF;\n\tgoto L_0177;\n\tv809 = *([v805 @ X0_v68+E0]);\n\tv810 = v809 == 0;\n\tv811 = ~v810;\n\tif (v811) goto L_0177;\n\tv813 = \"il2cpp_codegen_runtime_class_init\"(v805, v446, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0177:\n\tv815 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmQuaternion);\n\tv297 = v815 == type;\n\tif (v297) goto L_FFFFFFFF;\n\tgoto L_0191;\n\tv822 = *([v818 @ X0_v73+E0]);\n\tv823 = v822 == 0;\n\tv824 = ~v823;\n\tif (v824) goto L_0191;\n\tv826 = \"il2cpp_codegen_runtime_class_init\"(v818, v447, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0191:\n\tv828 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmObject);\n\tv298 = v828 == type;\n\tif (v298) goto L_FFFFFFFF;\n\tgoto L_01AB;\n\tv835 = *([v831 @ X0_v78+E0]);\n\tv836 = v835 == 0;\n\tv837 = ~v836;\n\tif (v837) goto L_01AB;\n\tv839 = \"il2cpp_codegen_runtime_class_init\"(v831, v448, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01AB:\n\tv841 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmMaterial);\n\tv299 = v841 == type;\n\tif (v299) goto L_FFFFFFFF;\n\tgoto L_01C5;\n\tv848 = *([v844 @ X0_v83+E0]);\n\tv849 = v848 == 0;\n\tv850 = ~v849;\n\tif (v850) goto L_01C5;\n\tv852 = \"il2cpp_codegen_runtime_class_init\"(v844, v449, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01C5:\n\tv854 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmTexture);\n\tv300 = v854 == type;\n\tif (v300) goto L_FFFFFFFF;\n\tgoto L_01DF;\n\tv861 = *([v857 @ X0_v88+E0]);\n\tv862 = v861 == 0;\n\tv863 = ~v862;\n\tif (v863) goto L_01DF;\n\tv865 = \"il2cpp_codegen_runtime_class_init\"(v857, v450, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01DF:\n\tv867 = System.Type::GetTypeFromHandle(HutongGames.PlayMaker.FsmColor);\n\tv301 = v867 == type;\n\tif (v301) goto L_FFFFFFFF;\n\tgoto L_01F9;\n\tv874 = *([v870 @ X0_v93+E0]);\n\tv875 = v874 == 0;\n\tv876 = ~v875;\n\tif (v876) goto L_01F9;\n\tv878 = \"il2cpp_codegen_runtime_class_init\"(v870, v451, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_01F9:\n\tv880 = System.Type::GetTypeFromHandle(System.Int32);\n\tv302 = v880 == type;\n\tif (v302) goto L_FFFFFFFF;\n\tgoto L_0213;\n\tv887 = *([v883 @ X0_v98+E0]);\n\tv888 = v887 == 0;\n\tv889 = ~v888;\n\tif (v889) goto L_0213;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v883, v452, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0213:\n\tv893 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv303 = v893 == type;\n\tif (v303) goto L_FFFFFFFF;\n\tgoto L_022D;\n\tv900 = *([v896 @ X0_v103+E0]);\n\tv901 = v900 == 0;\n\tv902 = ~v901;\n\tif (v902) goto L_022D;\n\tv904 = \"il2cpp_codegen_runtime_class_init\"(v896, v453, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_022D:\n\tv906 = System.Type::GetTypeFromHandle(System.Single);\n\tv304 = v906 == type;\n\tif (v304) goto L_FFFFFFFF;\n\tgoto L_0247;\n\tv913 = *([v909 @ X0_v108+E0]);\n\tv914 = v913 == 0;\n\tv915 = ~v914;\n\tif (v915) goto L_0247;\n\tv917 = \"il2cpp_codegen_runtime_class_init\"(v909, v454, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0247:\n\tv919 = System.Type::GetTypeFromHandle(System.String);\n\tv305 = v919 == type;\n\tif (v305) goto L_FFFFFFFF;\n\tgoto L_0261;\n\tv92\n// ... truncated")]
		private static ParamDataType GetParamDataType(Type type)
		{
			Type typeFromHandle = typeof(FsmOwnerDefault);
			if ((object)typeFromHandle != type)
			{
				Type typeFromHandle2 = typeof(FsmEventTarget);
				if ((object)typeFromHandle2 != type)
				{
					Type typeFromHandle3 = typeof(FsmEvent);
					if ((object)typeFromHandle3 != type)
					{
						Type typeFromHandle4 = typeof(FsmFloat);
						if ((object)typeFromHandle4 != type)
						{
							Type typeFromHandle5 = typeof(FsmInt);
							if ((object)typeFromHandle5 != type)
							{
								Type typeFromHandle6 = typeof(FsmBool);
								if ((object)typeFromHandle6 != type)
								{
									Type typeFromHandle7 = typeof(FsmString);
									if ((object)typeFromHandle7 != type)
									{
										Type typeFromHandle8 = typeof(FsmGameObject);
										if ((object)typeFromHandle8 != type)
										{
											Type typeFromHandle9 = typeof(FunctionCall);
											if ((object)typeFromHandle9 != type)
											{
												Type typeFromHandle10 = typeof(FsmProperty);
												if ((object)typeFromHandle10 != type)
												{
													Type typeFromHandle11 = typeof(FsmVector2);
													if ((object)typeFromHandle11 != type)
													{
														Type typeFromHandle12 = typeof(FsmVector3);
														if ((object)typeFromHandle12 != type)
														{
															Type typeFromHandle13 = typeof(FsmRect);
															if ((object)typeFromHandle13 != type)
															{
																Type typeFromHandle14 = typeof(FsmQuaternion);
																if ((object)typeFromHandle14 != type)
																{
																	Type typeFromHandle15 = typeof(FsmObject);
																	if ((object)typeFromHandle15 != type)
																	{
																		Type typeFromHandle16 = typeof(FsmMaterial);
																		if ((object)typeFromHandle16 != type)
																		{
																			Type typeFromHandle17 = typeof(FsmTexture);
																			if ((object)typeFromHandle17 != type)
																			{
																				Type typeFromHandle18 = typeof(FsmColor);
																				if ((object)typeFromHandle18 != type)
																				{
																					Type typeFromHandle19 = typeof(int);
																					if ((object)typeFromHandle19 != type)
																					{
																						Type typeFromHandle20 = typeof(bool);
																						if ((object)typeFromHandle20 != type)
																						{
																							Type typeFromHandle21 = typeof(float);
																							if ((object)typeFromHandle21 != type)
																							{
																								Type typeFromHandle22 = typeof(string);
																								if ((object)typeFromHandle22 != type)
																								{
																									Type typeFromHandle23 = typeof(Color);
																									if ((object)typeFromHandle23 != type)
																									{
																										Type typeFromHandle24 = typeof(LayerMask);
																										if ((object)typeFromHandle24 != type)
																										{
																											Type typeFromHandle25 = typeof(Vector2);
																											if ((object)typeFromHandle25 != type)
																											{
																												Type typeFromHandle26 = typeof(Vector3);
																												if ((object)typeFromHandle26 != type)
																												{
																													Type typeFromHandle27 = typeof(Vector4);
																													if ((object)typeFromHandle27 != type)
																													{
																														Type typeFromHandle28 = typeof(Quaternion);
																														if ((object)typeFromHandle28 != type)
																														{
																															Type typeFromHandle29 = typeof(Rect);
																															if ((object)typeFromHandle29 != type)
																															{
																																Type typeFromHandle30 = typeof(AnimationCurve);
																																if ((object)typeFromHandle30 != type)
																																{
																																	Type typeFromHandle31 = typeof(GameObject);
																																	if ((object)typeFromHandle31 != type)
																																	{
																																		Type typeFromHandle32 = typeof(LayoutOption);
																																		if ((object)typeFromHandle32 != type)
																																		{
																																			Type typeFromHandle33 = typeof(FsmVar);
																																			if ((object)typeFromHandle33 != type)
																																			{
																																				Type typeFromHandle34 = typeof(FsmEnum);
																																				if ((object)typeFromHandle34 != type)
																																				{
																																					Type typeFromHandle35 = typeof(FsmArray);
																																					if ((object)typeFromHandle35 != type)
																																					{
																																						Type typeFromHandle36 = typeof(FsmTemplateControl);
																																						if ((object)typeFromHandle36 != type)
																																						{
																																							Type typeFromHandle37 = typeof(FsmAnimationCurve);
																																							if ((object)typeFromHandle37 != type)
																																							{
																																								if (type.IsArray)
																																								{
																																									return ParamDataType.Array;
																																								}
																																								Type typeFromHandle38 = typeof(UnityEngine.Object);
																																								if (type.IsSubclassOf(typeFromHandle38))
																																								{
																																									return ParamDataType.ObjectReference;
																																								}
																																								if (type.IsEnum)
																																								{
																																									return ParamDataType.Enum;
																																								}
																																								if (type.IsClass)
																																								{
																																									return ParamDataType.CustomClass;
																																								}
																																								return ParamDataType.Unsupported;
																																							}
																																							return ParamDataType.FsmAnimationCurve;
																																						}
																																						return ParamDataType.FsmTemplateControl;
																																					}
																																					return ParamDataType.FsmArray;
																																				}
																																				return ParamDataType.FsmEnum;
																																			}
																																			return ParamDataType.FsmVar;
																																		}
																																		return ParamDataType.LayoutOption;
																																	}
																																	return ParamDataType.GameObject;
																																}
																																return ParamDataType.AnimationCurve;
																															}
																															return ParamDataType.Rect;
																														}
																														return ParamDataType.Quaternion;
																													}
																													return ParamDataType.Vector4;
																												}
																												return ParamDataType.Vector3;
																											}
																											return ParamDataType.Vector2;
																										}
																										return ParamDataType.LayerMask;
																									}
																									return ParamDataType.Color;
																								}
																								return ParamDataType.String;
																							}
																							return ParamDataType.Float;
																						}
																						return ParamDataType.Boolean;
																					}
																					return default(ParamDataType);
																				}
																				return ParamDataType.FsmColor;
																			}
																			return ParamDataType.FsmTexture;
																		}
																		return ParamDataType.FsmMaterial;
																	}
																	return ParamDataType.FsmObject;
																}
																return ParamDataType.FsmQuaternion;
															}
															return ParamDataType.FsmRect;
														}
														return ParamDataType.FsmVector3;
													}
													return ParamDataType.FsmVector2;
												}
												return ParamDataType.FsmProperty;
											}
											return ParamDataType.FunctionCall;
										}
										return ParamDataType.FsmGameObject;
									}
									return ParamDataType.FsmString;
								}
								return ParamDataType.FsmBool;
							}
							return ParamDataType.FsmInt;
						}
						return ParamDataType.FsmFloat;
					}
					return ParamDataType.FsmEvent;
				}
				return ParamDataType.FsmEventTarget;
			}
			return ParamDataType.FsmOwnerDefault;
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0x9C8350", Offset = "0x9C8350", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE80B8]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021A07]) = v46;\nL_001A:\n\tv50 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v50);\n\tthis.actionNames = v50;\n\tv56 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v56);\n\tthis.customNames = v56;\n\tv62 = new System.Collections.Generic.List`1<System.Boolean>();\n\tSystem.Collections.Generic.List`1<System.Boolean>::.ctor(v62);\n\tthis.actionEnabled = v62;\n\tv68 = new System.Collections.Generic.List`1<System.Boolean>();\n\tSystem.Collections.Generic.List`1<System.Boolean>::.ctor(v68);\n\tthis.actionIsOpen = v68;\n\tv74 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v74);\n\tthis.actionStartIndex = v74;\n\tv80 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v80);\n\tthis.actionHashCodes = v80;\n\tv86 = new System.Collections.Generic.List`1<System.Byte>();\n\tSystem.Collections.Generic.List`1<System.Byte>::.ctor(v86);\n\tthis.byteData = v86;\n\tv94 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.ParamDataType>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.ParamDataType>::.ctor(v94);\n\tthis.paramDataType = v94;\n\tv100 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v100);\n\tthis.paramName = v100;\n\tv104 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v104);\n\tthis.paramDataPos = v104;\n\tv108 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v108);\n\tthis.paramByteDataSize = v108;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActionData()
		{
			List<string> list = new List<string>();
			actionNames = list;
			List<string> list2 = new List<string>();
			customNames = list2;
			List<bool> list3 = new List<bool>();
			actionEnabled = list3;
			List<bool> list4 = new List<bool>();
			actionIsOpen = list4;
			List<int> list5 = new List<int>();
			actionStartIndex = list5;
			List<int> list6 = new List<int>();
			actionHashCodes = list6;
			List<byte> list7 = new List<byte>();
			byteData = list7;
			List<ParamDataType> list8 = new List<ParamDataType>();
			paramDataType = list8;
			List<string> list9 = new List<string>();
			paramName = list9;
			List<int> list10 = new List<int>();
			paramDataPos = list10;
			List<int> list11 = new List<int>();
			paramByteDataSize = list11;
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0x9D6C7C", Offset = "0x9D6C7C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EDB150]);\n\tv17 = *([v16 @ X8_v34]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021A08]) = v37;\nL_0015:\n\tv41 = new System.Collections.Generic.Dictionary`2<System.String, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::.ctor(v41);\n\tv49.ActionTypeLookup = v41;\n\tv53 = new System.Collections.Generic.Dictionary`2<System.Type, System.Reflection.FieldInfo[]>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Reflection.FieldInfo[]>::.ctor(v53);\n\tv59.ActionFieldsLookup = v53;\n\tv63 = new System.Collections.Generic.Dictionary`2<System.Type, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Int32>::.ctor(v63);\n\tv69.ActionHashCodeLookup = v63;\n\tv73 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v73);\n\tv79.UsedIndices = v73;\n\tv83 = new System.Collections.Generic.List`1<System.Reflection.FieldInfo>();\n\tSystem.Collections.Generic.List`1<System.Reflection.FieldInfo>::.ctor(v83);\n\tv89.InitFields = v83;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ActionData()
		{
			Dictionary<string, Type> actionTypeLookup = new Dictionary<string, Type>();
			ActionTypeLookup = actionTypeLookup;
			Dictionary<Type, FieldInfo[]> actionFieldsLookup = new Dictionary<Type, FieldInfo[]>();
			ActionFieldsLookup = actionFieldsLookup;
			Dictionary<Type, int> actionHashCodeLookup = new Dictionary<Type, int>();
			ActionHashCodeLookup = actionHashCodeLookup;
			List<int> usedIndices = new List<int>();
			UsedIndices = usedIndices;
			List<FieldInfo> initFields = new List<FieldInfo>();
			InitFields = initFields;
		}
	}
}
