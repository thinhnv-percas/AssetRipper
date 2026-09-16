using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000071")]
	public class FsmState : INameable
	{
		[CompilerGenerated]
		[Token(Token = "0x40002CF")]
		[FieldOffset(Offset = "0x10")]
		private float _003CStateTime_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002D0")]
		[FieldOffset(Offset = "0x14")]
		private float _003CRealStartTime_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x18")]
		private int _003CloopCount_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x1C")]
		private int _003CmaxLoopCount_003Ek__BackingField;

		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x20")]
		private bool active;

		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x21")]
		private bool finished;

		[Token(Token = "0x40002D5")]
		[FieldOffset(Offset = "0x28")]
		private FsmStateAction activeAction;

		[Token(Token = "0x40002D6")]
		[FieldOffset(Offset = "0x30")]
		private int activeActionIndex;

		[NonSerialized]
		[Token(Token = "0x40002D7")]
		[FieldOffset(Offset = "0x38")]
		private Fsm fsm;

		[SerializeField]
		[Token(Token = "0x40002D8")]
		[FieldOffset(Offset = "0x40")]
		private string name;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TextAreaAttribute), RVA = "0x73FED4", Offset = "0x73FED4")]
		[Token(Token = "0x40002D9")]
		[FieldOffset(Offset = "0x48")]
		private string description;

		[SerializeField]
		[Token(Token = "0x40002DA")]
		[FieldOffset(Offset = "0x50")]
		internal byte colorIndex;

		[SerializeField]
		[Token(Token = "0x40002DB")]
		[FieldOffset(Offset = "0x54")]
		private Rect position;

		[SerializeField]
		[Token(Token = "0x40002DC")]
		[FieldOffset(Offset = "0x64")]
		private bool isBreakpoint;

		[SerializeField]
		[Token(Token = "0x40002DD")]
		[FieldOffset(Offset = "0x65")]
		private bool isSequence;

		[SerializeField]
		[Token(Token = "0x40002DE")]
		[FieldOffset(Offset = "0x66")]
		private bool hideUnused;

		[SerializeField]
		[Token(Token = "0x40002DF")]
		[FieldOffset(Offset = "0x68")]
		private FsmTransition[] transitions;

		[NonSerialized]
		[Token(Token = "0x40002E0")]
		[FieldOffset(Offset = "0x70")]
		private FsmStateAction[] actions;

		[SerializeField]
		[Token(Token = "0x40002E1")]
		[FieldOffset(Offset = "0x78")]
		private ActionData actionData;

		[NonSerialized]
		[Token(Token = "0x40002E2")]
		[FieldOffset(Offset = "0x80")]
		private List<FsmStateAction> activeActions;

		[NonSerialized]
		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0x88")]
		private List<FsmStateAction> _finishedActions;

		[Token(Token = "0x1700018F")]
		public float StateTime
		{
			[CompilerGenerated]
			[Token(Token = "0x6000528")]
			[Address(RVA = "0xCB30A4", Offset = "0xCB30A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StateTime>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StateTime;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000529")]
			[Address(RVA = "0xCB30AC", Offset = "0xCB30AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StateTime>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CStateTime_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000190")]
		public float RealStartTime
		{
			[CompilerGenerated]
			[Token(Token = "0x600052A")]
			[Address(RVA = "0xCB30B4", Offset = "0xCB30B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RealStartTime>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RealStartTime;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052B")]
			[Address(RVA = "0xCB30BC", Offset = "0xCB30BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RealStartTime>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRealStartTime_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000191")]
		public int loopCount
		{
			[CompilerGenerated]
			[Token(Token = "0x600052C")]
			[Address(RVA = "0xCB30C4", Offset = "0xCB30C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<loopCount>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return loopCount;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052D")]
			[Address(RVA = "0xCB30CC", Offset = "0xCB30CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<loopCount>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CloopCount_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000192")]
		public int maxLoopCount
		{
			[CompilerGenerated]
			[Token(Token = "0x600052E")]
			[Address(RVA = "0xCB30D4", Offset = "0xCB30D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<maxLoopCount>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return maxLoopCount;
			}
			[CompilerGenerated]
			[Token(Token = "0x600052F")]
			[Address(RVA = "0xCB30DC", Offset = "0xCB30DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<maxLoopCount>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CmaxLoopCount_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000193")]
		public List<FsmStateAction> ActiveActions
		{
			[Token(Token = "0x6000536")]
			[Address(RVA = "0xCB3510", Offset = "0xCB3510", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0FEC0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202362F]) = v38;\nL_0013:\n\tv51 = this.activeActions;\n\tv40 = this.activeActions == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0027;\n\tv45 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::.ctor(v45);\n\tthis.activeActions = v45;\nL_0027:\n\treturn v51;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<FsmStateAction> result = activeActions;
				if (activeActions == null)
				{
					result = (activeActions = new List<FsmStateAction>());
				}
				return result;
			}
		}

		[Token(Token = "0x17000194")]
		private List<FsmStateAction> finishedActions
		{
			[Token(Token = "0x6000537")]
			[Address(RVA = "0xCB3584", Offset = "0xCB3584", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE0050]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023630]) = v38;\nL_0013:\n\tv51 = this._finishedActions;\n\tv40 = this._finishedActions == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0027;\n\tv45 = new System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>();\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::.ctor(v45);\n\tthis._finishedActions = v45;\nL_0027:\n\treturn v51;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<FsmStateAction> result = _finishedActions;
				if (_finishedActions == null)
				{
					result = (_finishedActions = new List<FsmStateAction>());
				}
				return result;
			}
		}

		[Token(Token = "0x17000195")]
		public bool Active
		{
			[Token(Token = "0x6000558")]
			[Address(RVA = "0xCB5378", Offset = "0xCB5378", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.active;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Active;
			}
		}

		[Token(Token = "0x17000196")]
		public FsmStateAction ActiveAction
		{
			[Token(Token = "0x6000559")]
			[Address(RVA = "0xCB5380", Offset = "0xCB5380", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.activeAction;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActiveAction;
			}
		}

		[Token(Token = "0x17000197")]
		public bool IsInitialized
		{
			[Token(Token = "0x600055A")]
			[Address(RVA = "0xCB5388", Offset = "0xCB5388", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.fsm == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = fsm == null;
				return !flag;
			}
		}

		[Token(Token = "0x17000198")]
		public Fsm Fsm
		{
			[Token(Token = "0x600055B")]
			[Address(RVA = "0xCAE668", Offset = "0xCAE668", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC5080]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202364D]) = v38;\nL_0013:\n\treturnVal1 = this.fsm;\n\tv40 = this.fsm == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0034;\n\tv47 = System.String::Concat(\"get_fsm: Fsm not initialized: \", this.name);\n\tgoto L_002D;\n\tv71 = *([v59 @ X8_v8+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_002D;\n\tv77 = v59;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogError(v47);\n\treturnVal1 = this.fsm;\nL_0034:\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Fsm result = fsm;
				if (fsm == null)
				{
					string message = "get_fsm: Fsm not initialized: " + Name;
					Debug.LogError(message);
					result = fsm;
				}
				return result;
			}
			[Token(Token = "0x600055C")]
			[Address(RVA = "0xCB5398", Offset = "0xCB5398", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED35B0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202364E]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_002F;\n\tv49 = System.String::Concat(\"set_fsm: value == null: \", this.name);\n\tgoto L_002E;\n\tv74 = *([v61 @ X8_v8+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_002E;\n\tv79 = v61;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v79, v45, v47, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\tUnityEngine.Debug::LogWarning(v49);\nL_002F:\n\tthis.fsm = value;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value == null)
				{
					string message = "set_fsm: value == null: " + Name;
					Debug.LogWarning(message);
				}
				fsm = value;
			}
		}

		[Token(Token = "0x17000199")]
		public string Name
		{
			[Token(Token = "0x600055D")]
			[Address(RVA = "0xCB5438", Offset = "0xCB5438", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[Token(Token = "0x600055E")]
			[Address(RVA = "0xCB5440", Offset = "0xCB5440", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.name = value;\n\treturn;\n")]
			set
			{
				Name = value;
			}
		}

		[Token(Token = "0x1700019A")]
		public bool IsSequence
		{
			[Token(Token = "0x600055F")]
			[Address(RVA = "0xCB5448", Offset = "0xCB5448", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isSequence;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsSequence;
			}
			[Token(Token = "0x6000560")]
			[Address(RVA = "0xCB5450", Offset = "0xCB5450", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isSequence = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				isSequence = value;
			}
		}

		[Token(Token = "0x1700019B")]
		public int ActiveActionIndex
		{
			[Token(Token = "0x6000561")]
			[Address(RVA = "0xCB545C", Offset = "0xCB545C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.activeActionIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActiveActionIndex;
			}
		}

		[Token(Token = "0x1700019C")]
		public Rect Position
		{
			[Token(Token = "0x6000562")]
			[Address(RVA = "0xCB5464", Offset = "0xCB5464", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.position;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return position;
			}
			[Token(Token = "0x6000563")]
			[Address(RVA = "0xCB5470", Offset = "0xCB5470", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0x10CCFB4(&value @ V0 (UnityEngine.Rect), 0, v21, v22, v23, v24, v25, v26, value, value.m_YMin, value.m_Width, value.m_Height, v27, v28, v29, v30);\n\tv32 = System.Single::IsNaN(value);\n\tv34 = v32 == 0;\n\tv35 = ~v34;\n\tif (v35) goto L_0029;\n\tv39 = 0x10CCFC4(&v37 @ stack_-30_v3 (System.Single), 0, v21, v22, v23, v24, v25, v26, value, value.m_YMin, value.m_Width, value.m_Height, v27, v28, v29, v30);\n\tv54 = System.Single::IsNaN(value);\n\tv60 = v54 == 0;\n\tv50 = ~v60;\n\tif (v50) goto L_0029;\n\tthis.position.m_XMin = v37;\n\tthis.position.m_YMin = value.m_YMin;\n\tthis.position.m_Height = value.m_Height;\nL_0029:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Rect rect = default(Rect);
				if (!float.IsNaN(rect.x))
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
					if (!float.IsNaN(rect.x))
					{
						float x = default(float);
						position.x = x;
						position.y = value.y;
						position.height = value.height;
					}
				}
			}
		}

		[Token(Token = "0x1700019D")]
		public bool IsBreakpoint
		{
			[Token(Token = "0x6000564")]
			[Address(RVA = "0xCB54E4", Offset = "0xCB54E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isBreakpoint;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsBreakpoint;
			}
			[Token(Token = "0x6000565")]
			[Address(RVA = "0xCB54EC", Offset = "0xCB54EC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isBreakpoint = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				isBreakpoint = value;
			}
		}

		[Token(Token = "0x1700019E")]
		public bool HideUnused
		{
			[Token(Token = "0x6000566")]
			[Address(RVA = "0xCB54F8", Offset = "0xCB54F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.hideUnused;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return HideUnused;
			}
			[Token(Token = "0x6000567")]
			[Address(RVA = "0xCB5500", Offset = "0xCB5500", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.hideUnused = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				hideUnused = value;
			}
		}

		[Token(Token = "0x1700019F")]
		public FsmStateAction[] Actions
		{
			[Token(Token = "0x6000568")]
			[Address(RVA = "0xCB397C", Offset = "0xCB397C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED5E10]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202364F]) = v38;\nL_0014:\n\tv40 = this.fsm == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_002E;\n\tv47 = System.String::Concat(\"get_actions: Fsm not initialized: \", this.name);\n\tgoto L_002D;\n\tv83 = *([v59 @ X8_v9+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002D;\n\tv97 = v59;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tUnityEngine.Debug::LogError(v47);\nL_002E:\n\treturnVal1 = this.actions;\n\tv63 = this.actions == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_003E;\n\treturnVal1 = HutongGames.PlayMaker.ActionData::LoadActions(this.actionData, this);\n\tthis.actions = returnVal1;\nL_003E:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (fsm == null)
				{
					string message = "get_actions: Fsm not initialized: " + Name;
					Debug.LogError(message);
				}
				FsmStateAction[] result = actions;
				if (actions == null)
				{
					result = (Actions = ActionData.LoadActions(this));
				}
				return result;
			}
			[Token(Token = "0x6000569")]
			[Address(RVA = "0xCB550C", Offset = "0xCB550C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.actions = value;\n\treturn;\n")]
			set
			{
				Actions = value;
			}
		}

		[Token(Token = "0x170001A0")]
		public bool ActionsLoaded
		{
			[Token(Token = "0x600056A")]
			[Address(RVA = "0xCB5514", Offset = "0xCB5514", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.actions == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = actions == null;
				return !flag;
			}
		}

		[Token(Token = "0x170001A1")]
		public ActionData ActionData
		{
			[Token(Token = "0x600056B")]
			[Address(RVA = "0xCB5524", Offset = "0xCB5524", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.actionData;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ActionData;
			}
		}

		[Token(Token = "0x170001A2")]
		public FsmTransition[] Transitions
		{
			[Token(Token = "0x600056C")]
			[Address(RVA = "0xCB552C", Offset = "0xCB552C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.transitions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Transitions;
			}
			[Token(Token = "0x600056D")]
			[Address(RVA = "0xCB5534", Offset = "0xCB5534", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.transitions = value;\n\treturn;\n")]
			set
			{
				Transitions = value;
			}
		}

		[Token(Token = "0x170001A3")]
		public string Description
		{
			[Token(Token = "0x600056E")]
			[Address(RVA = "0xCB553C", Offset = "0xCB553C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F10060]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023650]) = v38;\nL_0013:\n\treturnVal1 = this.description;\n\tv40 = this.description == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_0020;\n\tthis.description = \"\";\nL_0020:\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string result = description;
				if (description == null)
				{
					Description = "";
					result = "";
				}
				return result;
			}
			[Token(Token = "0x600056F")]
			[Address(RVA = "0xCB5594", Offset = "0xCB5594", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.description = value;\n\treturn;\n")]
			set
			{
				Description = value;
			}
		}

		[Token(Token = "0x170001A4")]
		public int ColorIndex
		{
			[Token(Token = "0x6000570")]
			[Address(RVA = "0xCB559C", Offset = "0xCB559C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.colorIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return colorIndex;
			}
			[Token(Token = "0x6000571")]
			[Address(RVA = "0xCB55A4", Offset = "0xCB55A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.colorIndex = value;\n\treturn;\n")]
			set
			{
				colorIndex = (byte)value;
			}
		}

		[Token(Token = "0x6000530")]
		[Address(RVA = "0xCB30E4", Offset = "0xCB30E4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED5828]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202362C]) = v38;\nL_0013:\n\tv39 = state == 0;\n\tif (v39) goto L_003C;\n\tv41 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tgoto L_0027;\n\tv79 = *([v52 @ X8_v7+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0027;\n\tv87 = v52;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv86 = HutongGames.PlayMaker.Fsm::GetFullFsmLabel(v41);\n\treturnVal2 = System.String::Concat(v86, \" : \", state.name);\n\treturn returnVal2;\nL_003C:\n\treturn \"None (State)\";\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetFullStateLabel(FsmState state)
		{
			if (state != null)
			{
				Fsm fsm = state.Fsm;
				string fullFsmLabel = Fsm.GetFullFsmLabel(fsm);
				return fullFsmLabel + " : " + state.Name;
			}
			return "None (State)";
		}

		[Token(Token = "0x6000531")]
		[Address(RVA = "0xCB3190", Offset = "0xCB3190", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE25B8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, fsm, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202362D]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.transitions = v46;\n\tv50 = new HutongGames.PlayMaker.ActionData();\n\tHutongGames.PlayMaker.ActionData::.ctor(v50);\n\tthis.actionData = v50;\n\tSystem.Object::.ctor(this);\n\tthis.fsm = fsm;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmState(Fsm fsm)
		{
			FsmTransition[] array = new FsmTransition[0];
			Transitions = array;
			ActionData actionData = new ActionData();
			this.actionData = actionData;
			this.fsm = fsm;
		}

		[Token(Token = "0x6000532")]
		[Address(RVA = "0xCB3224", Offset = "0xCB3224", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1F0B0C8]);\n\tv33 = *([v32 @ X8_v28]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, source, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202362E]) = v51;\nL_001E:\n\t// 30 NewArr v56 @ X0_v3 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), 0\n\tthis.transitions = v56;\n\tv60 = new HutongGames.PlayMaker.ActionData();\n\tHutongGames.PlayMaker.ActionData::.ctor(v60);\n\tthis.actionData = v60;\n\tSystem.Object::.ctor(this);\n\tv67 = HutongGames.PlayMaker.FsmState::get_Fsm(source);\n\tthis.fsm = v67;\n\tthis.name = source.name;\n\tthis.description = source.description;\n\tthis.colorIndex = source.colorIndex;\n\tv129 = 0;\n\tv146 = 0x10CCF7C(&v129 @ stack_-60_v4 (System.Single), 0, methodInfo, v36, v37, v38, v39, v40, source.position, source.position.m_YMin, source.position.m_Width, source.position.m_Height, v45, v46, v47, v48);\n\tthis.position.m_XMin = 0f;\n\tthis.position.m_YMin = v224;\n\tthis.position.m_Height = v225;\n\tthis.hideUnused = source.hideUnused;\n\tthis.isBreakpoint = source.isBreakpoint;\n\tthis.isSequence = source.isSequence;\n\tv156 = source.transitions;\n\t// 80 NewArr v147 @ X0_v19 (HutongGames.PlayMaker.FsmTransition[]), typeof(HutongGames.PlayMaker.FsmTransition[]), v156.Length\n\tthis.transitions = v147;\n\tv246 = source.transitions;\nL_0062:\n\tv69 = v115 >= v246.Length;\n\tif (v69) goto L_009B;\n\tv325 = v115 < v246.Length;\n\tv112 = ~v325;\n\tif (v112) goto L_00A9;\n\tv74 = this.transitions;\n\tv148 = new HutongGames.PlayMaker.FsmTransition();\n\tHutongGames.PlayMaker.FsmTransition::.ctor(v148, v246[v115 @ X23_v6 (System.Int32)]);\n\tv353 = v148 == 0;\n\tif (v353) goto L_0083;\n\t// 127 IsInst v355 @ X0_v29, typeof(HutongGames.PlayMaker.FsmTransition), v148 @ X0_v26 (HutongGames.PlayMaker.FsmTransition)\nL_0083:\n\tv357 = v115 < v74.Length;\n\tv110 = ~v357;\n\tif (v110) goto L_00A9;\n\tv74[v115 @ X23_v6 (System.Int32)] = v148;\n\tv246 = source.transitions;\n\tv115 = v115 + 1;\n\tv359 = source.transitions == 0;\n\tv150 = ~v359;\n\tif (v150) goto L_0062;\n\tthrow System.NullReferenceException;\nL_009B:\n\tv250 = HutongGames.PlayMaker.ActionData::Copy(source.actionData);\n\tthis.actionData = v250;\n\treturn;\nL_00A9:\n\tv346 = new System.IndexOutOfRangeException();\n\tgoto L_00AE;\n\tv350 = new System.ArrayTypeMismatchException();\nL_00AE:\n\tthrow v349;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmState(FsmState source)
		{
			//IL_009a: Expected F4, but got O
			base._002Ector();
			FsmTransition[] array = new FsmTransition[0];
			Transitions = array;
			ActionData actionData = new ActionData();
			this.actionData = actionData;
			Fsm fsm = source.Fsm;
			this.fsm = fsm;
			Name = source.Name;
			Description = source.description;
			colorIndex = source.colorIndex;
			float num = 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF7C (inside UnityEngine.RangeAttribute::.ctor +0x2A8)");
			position.x = 0f;
			object obj = default(object);
			position.y = (float)obj;
			float height = default(float);
			position.height = height;
			hideUnused = source.HideUnused;
			isBreakpoint = source.IsBreakpoint;
			isSequence = source.IsSequence;
			FsmTransition[] array2 = source.Transitions;
			FsmTransition[] array3 = new FsmTransition[array2.Length];
			Transitions = array3;
			FsmTransition[] array4 = source.Transitions;
			int num2 = 0;
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			while (true)
			{
				if (num2 < array4.Length)
				{
					if (num2 < array4.Length)
					{
						FsmTransition[] array5 = Transitions;
						FsmTransition fsmTransition = new FsmTransition(array4[num2]);
						if (fsmTransition != null)
						{
							object obj2 = fsmTransition as FsmTransition;
						}
						if (num2 < array5.Length)
						{
							array5[num2] = fsmTransition;
							array4 = source.Transitions;
							num2++;
							if (source.Transitions == null)
							{
								break;
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
				ActionData actionData2 = source.ActionData.Copy();
				this.actionData = actionData2;
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000533")]
		[Address(RVA = "0xCB346C", Offset = "0xCB346C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.ActionData::Copy(state.actionData);\n\tthis.actionData = v16;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyActionData(FsmState state)
		{
			ActionData actionData = state.ActionData.Copy();
			this.actionData = actionData;
		}

		[Token(Token = "0x6000534")]
		[Address(RVA = "0xCB34A8", Offset = "0xCB34A8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.ActionData::LoadActions(this.actionData, this);\n\tthis.actions = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadActions()
		{
			FsmStateAction[] array = ActionData.LoadActions(this);
			Actions = array;
		}

		[Token(Token = "0x6000535")]
		[Address(RVA = "0xCB34E0", Offset = "0xCB34E0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.actions == 0;\n\tif (v3) goto L_000B;\n\tHutongGames.PlayMaker.ActionData::SaveActions(this.actionData, this, this.actions);\n\treturn;\nL_000B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveActions()
		{
			if (actions != null)
			{
				ActionData.SaveActions(this, actions);
			}
		}

		[Token(Token = "0x6000538")]
		[Address(RVA = "0xCB35F8", Offset = "0xCB35F8", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDD698]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023631]) = v38;\nL_0015:\n\tv41 = this.<loopCount>k__BackingField + 1;\n\tthis.<loopCount>k__BackingField = v41;\n\tv53 = v41 <= this.<maxLoopCount>k__BackingField;\n\tif (v53) goto L_0027;\n\tthis.<maxLoopCount>k__BackingField = v41;\nL_0027:\n\tthis.active = 1;\n\tv56 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Clear(v56);\n\tv62 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tthis.<RealStartTime>k__BackingField = v62;\n\tthis.<StateTime>k__BackingField = 0f;\n\tv65 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Clear(v65);\n\tv79 = HutongGames.PlayMaker.FsmState::ActivateActions(this, 0);\n\tv81 = v79 == 0;\n\tif (v81) goto L_004B;\n\tHutongGames.PlayMaker.FsmState::CheckAllActionsFinished(this);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnter()
		{
			int num = ++loopCount;
			if (num > maxLoopCount)
			{
				maxLoopCount = num;
			}
			active = true;
			finished = false;
			List<FsmStateAction> list = finishedActions;
			list.Clear();
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			RealStartTime = realtimeSinceStartup;
			StateTime = 0f;
			List<FsmStateAction> list2 = ActiveActions;
			list2.Clear();
			if (ActivateActions(0))
			{
				CheckAllActionsFinished();
			}
		}

		[Token(Token = "0x6000539")]
		[Address(RVA = "0xCB36B8", Offset = "0xCB36B8", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1ECAE90]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, startIndex, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023632]) = v47;\nL_0019:\n\tv124 = HutongGames.PlayMaker.FsmState::get_Actions(this);\nL_002A:\n\tv56 = v106 >= v124.Length;\n\tif (v56) goto L_FFFFFFFF;\n\tthis.activeActionIndex = v106;\n\tv100 = HutongGames.PlayMaker.FsmState::get_Actions(this);\n\tv238 = v106 < v100.Length;\n\tv93 = ~v238;\n\tif (v93) goto L_0086;\n\tv111 = v100[v106 @ X19_v6 (System.Int32)];\n\tv269 = ~v111.enabled;\n\tif (v269) goto L_006F;\n\tthis.activeAction = v100[v106 @ X19_v6 (System.Int32)];\n\tv111.active = 1;\n\tv274 = HutongGames.PlayMaker.FsmStateAction::Init(v100[v106 @ X19_v6 (System.Int32)], this);\n\tv111.<Entered>k__BackingField = 1;\n\tv277 = HutongGames.PlayMaker.FsmStateAction::OnEnter(v100[v106 @ X19_v6 (System.Int32)]);\n\tv278 = ~v111.finished;\n\tv279 = ~v278;\n\tif (v279) goto L_005E;\n\tv255 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Add(v255, v100[v106 @ X19_v6 (System.Int32)]);\nL_005E:\n\tv256 = HutongGames.PlayMaker.FsmState::get_Fsm(this);\n\tv287 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(v256);\n\tv296 = v287 == 0;\n\tv297 = ~v296;\n\tif (v297) goto L_FFFFFFFF;\n\tv298 = ~v111.finished;\n\tv289 = ~v298;\n\tif (v289) goto L_0071;\n\tv290 = ~this.isSequence;\n\tif (v290) goto L_0071;\n\tgoto L_FFFFFFFF;\nL_006F:\n\tv111.active = 0x100;\nL_0071:\n\tv106 = v106 + 1;\n\tv124 = HutongGames.PlayMaker.FsmState::get_Actions(this);\n\tv294 = v124 == 0;\n\tv102 = ~v294;\n\tif (v102) goto L_002A;\n\tthrow System.NullReferenceException;\n\tgoto L_0084;\nL_0084:\n\treturn returnVal1;\n\tv263 = new System.NullReferenceException();\nL_0086:\n\tv267 = new System.IndexOutOfRangeException();\n\tthrow v267;\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ActivateActions(int startIndex)
		{
			FsmStateAction[] array = Actions;
			int num2 = default(int);
			int num = num2;
			while (true)
			{
				if (num < array.Length)
				{
					activeActionIndex = num;
					FsmStateAction[] array2 = Actions;
					if (num >= array2.Length)
					{
						break;
					}
					FsmStateAction fsmStateAction = array2[num];
					if (fsmStateAction.Enabled)
					{
						activeAction = array2[num];
						fsmStateAction.active = true;
						fsmStateAction.finished = false;
						array2[num].Init(this);
						fsmStateAction.Entered = true;
						array2[num].OnEnter();
						if (!fsmStateAction.Finished)
						{
							List<FsmStateAction> list = ActiveActions;
							list.Add(array2[num]);
						}
						Fsm fsm = Fsm;
						if (fsm.IsSwitchingState)
						{
							goto IL_0214;
						}
						bool flag = !fsmStateAction.Finished;
						bool flag2 = !flag;
						num2 = 0;
						if (!flag2)
						{
							bool flag3 = !IsSequence;
							num2 = 0;
							if (!flag3)
							{
								goto IL_0214;
							}
						}
					}
					else
					{
						fsmStateAction.active = false;
						fsmStateAction.finished = true;
					}
					num++;
					array = Actions;
					if (array == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return true;
				IL_0214:
				return false;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600053A")]
		[Address(RVA = "0xCB3A48", Offset = "0xCB3A48", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F06830]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, fsmEvent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023633]) = v43;\nL_0017:\n\tv116 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv130 = v91 >= v116._size;\n\tif (v130) goto L_005B;\n\tv152 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv196 = v152._size < v91;\n\tv87 = ~v196;\n\tv84 = v152._size - v91;\n\tv78 = v84 == 0;\n\tv197 = ~v78;\n\tv63 = v87 & v197;\n\tif (v63) goto L_003C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003C:\n\tv221 = v152._items;\n\tv227 = HutongGames.PlayMaker.FsmStateAction::Init(v221[v91 @ X22_v6 (System.Int32)], this);\n\tv229 = HutongGames.PlayMaker.FsmStateAction::Event(v221[v91 @ X22_v6 (System.Int32)], v58);\n\tv91 = v91 + 1;\n\tv116 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv231 = v116 == 0;\n\tv96 = ~v231;\n\tif (v96) goto L_0026;\n\tthrow System.NullReferenceException;\nL_005B:\n\tv154 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\tv181 = v148 | v154;\n\tv186 = v181 == 0;\n\tv191 = ~v186;\n\treturn v191;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnEvent(FsmEvent fsmEvent)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			int num2 = 0;
			FsmEvent fsmEvent2 = default(FsmEvent);
			while (num < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				bool flag = list2.Count < num;
				bool flag2 = !flag;
				int num3 = list2.Count - num;
				bool flag3 = num3 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				bool flag5 = items[num].Event(fsmEvent2);
				num++;
				list = ActiveActions;
				bool flag6 = list == null;
				bool flag7 = !flag6;
				num2 = (flag5 ? 1 : 0);
				if (!flag7)
				{
					throw new NullReferenceException();
				}
			}
			bool isSwitchingState = fsm.IsSwitchingState;
			int num4 = num2 | (isSwitchingState ? 1 : 0);
			bool flag8 = num4 == 0;
			return !flag8;
		}

		[Token(Token = "0x600053B")]
		[Address(RVA = "0xCB3B58", Offset = "0xCB3B58", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EEB320]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023634]) = v40;\nL_0015:\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0023:\n\tv125 = v87 >= v111._size;\n\tif (v125) goto L_0059;\n\tv151 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv177 = v151._size < v87;\n\tv83 = ~v177;\n\tv80 = v151._size - v87;\n\tv74 = v80 == 0;\n\tv178 = ~v74;\n\tv59 = v83 & v178;\n\tif (v59) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\tv180 = v151._items;\n\tv185 = HutongGames.PlayMaker.FsmStateAction::Init(v180[v87 @ X21_v5 (System.Int32)], this);\n\tv187 = HutongGames.PlayMaker.FsmStateAction::OnFixedUpdate(v180[v87 @ X21_v5 (System.Int32)]);\n\tv87 = v87 + 1;\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv189 = v111 == 0;\n\tv92 = ~v189;\n\tif (v92) goto L_0023;\n\tthrow System.NullReferenceException;\nL_0059:\n\tHutongGames.PlayMaker.FsmState::CheckAllActionsFinished(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnFixedUpdate()
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			while (num < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				bool flag = list2.Count < num;
				bool flag2 = !flag;
				int num2 = list2.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].OnFixedUpdate();
				num++;
				list = ActiveActions;
				if (list == null)
				{
					throw new NullReferenceException();
				}
			}
			CheckAllActionsFinished();
		}

		[Token(Token = "0x600053C")]
		[Address(RVA = "0xCB3C3C", Offset = "0xCB3C3C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EB6750]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023635]) = v42;\nL_0016:\n\tv44 = ~this.finished;\n\tif (v44) goto L_0022;\n\treturn;\nL_0022:\n\tv53 = UnityEngine.Time::get_deltaTime();\n\tv105 = this.<StateTime>k__BackingField + v53;\n\tthis.<StateTime>k__BackingField = v105;\n\tv183 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0034:\n\tv71 = v110 >= v183._size;\n\tif (v71) goto L_006B;\n\tv192 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv194 = v192._size < v110;\n\tv158 = ~v194;\n\tv156 = v192._size - v110;\n\tv152 = v156 == 0;\n\tv195 = ~v152;\n\tv142 = v158 & v195;\n\tif (v142) goto L_004A;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004A:\n\tv197 = v192._items;\n\tv202 = HutongGames.PlayMaker.FsmStateAction::Init(v197[v110 @ X21_v5 (System.Int32)], this);\n\tv204 = HutongGames.PlayMaker.FsmStateAction::OnUpdate(v197[v110 @ X21_v5 (System.Int32)]);\n\tv110 = v110 + 1;\n\tv183 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv206 = v183 == 0;\n\tv165 = ~v206;\n\tif (v165) goto L_0034;\n\tthrow System.NullReferenceException;\nL_006B:\n\tHutongGames.PlayMaker.FsmState::CheckAllActionsFinished(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnUpdate()
		{
			if (finished)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			float num = StateTime + deltaTime;
			StateTime = num;
			List<FsmStateAction> list = ActiveActions;
			int num2 = 0;
			while (num2 < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				bool flag = list2.Count < num2;
				bool flag2 = !flag;
				int num3 = list2.Count - num2;
				bool flag3 = num3 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num2].Init(this);
				items[num2].OnUpdate();
				num2++;
				list = ActiveActions;
				if (list == null)
				{
					throw new NullReferenceException();
				}
			}
			CheckAllActionsFinished();
		}

		[Token(Token = "0x600053D")]
		[Address(RVA = "0xCB3D58", Offset = "0xCB3D58", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC1140]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023636]) = v40;\nL_0015:\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0023:\n\tv125 = v87 >= v111._size;\n\tif (v125) goto L_0059;\n\tv151 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv177 = v151._size < v87;\n\tv83 = ~v177;\n\tv80 = v151._size - v87;\n\tv74 = v80 == 0;\n\tv178 = ~v74;\n\tv59 = v83 & v178;\n\tif (v59) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\tv180 = v151._items;\n\tv185 = HutongGames.PlayMaker.FsmStateAction::Init(v180[v87 @ X21_v5 (System.Int32)], this);\n\tv187 = HutongGames.PlayMaker.FsmStateAction::OnLateUpdate(v180[v87 @ X21_v5 (System.Int32)]);\n\tv87 = v87 + 1;\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv189 = v111 == 0;\n\tv92 = ~v189;\n\tif (v92) goto L_0023;\n\tthrow System.NullReferenceException;\nL_0059:\n\tHutongGames.PlayMaker.FsmState::CheckAllActionsFinished(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnLateUpdate()
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			while (num < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				bool flag = list2.Count < num;
				bool flag2 = !flag;
				int num2 = list2.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].OnLateUpdate();
				num++;
				list = ActiveActions;
				if (list == null)
				{
					throw new NullReferenceException();
				}
			}
			CheckAllActionsFinished();
		}

		[Token(Token = "0x600053E")]
		[Address(RVA = "0xCB3E3C", Offset = "0xCB3E3C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF42A8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023637]) = v40;\nL_0015:\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0024:\n\tv126 = v87 >= v111._size;\n\tif (v126) goto L_0052;\n\tv145 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv177 = v145._size < v87;\n\tv83 = ~v177;\n\tv80 = v145._size - v87;\n\tv74 = v80 == 0;\n\tv178 = ~v74;\n\tv59 = v83 & v178;\n\tif (v59) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\tv180 = v145._items;\n\tv206 = HutongGames.PlayMaker.FsmStateAction::Init(v180[v87 @ X21_v6 (System.Int32)], this);\n\tv208 = HutongGames.PlayMaker.FsmStateAction::DoAnimatorMove(v180[v87 @ X21_v6 (System.Int32)]);\n\tv87 = v87 + 1;\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv210 = v111 == 0;\n\tv92 = ~v210;\n\tif (v92) goto L_0024;\n\tv100 = new System.NullReferenceException();\nL_0052:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v141);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnAnimatorMove()
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoAnimatorMove();
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600053F")]
		[Address(RVA = "0xCB4020", Offset = "0xCB4020", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED4C58]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, layerIndex, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023638]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoAnimatorIK(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnAnimatorIK(int layerIndex)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			int layerIndex2 = default(int);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoAnimatorIK(layerIndex2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000540")]
		[Address(RVA = "0xCB4118", Offset = "0xCB4118", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBC858]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023639]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionEnter(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionEnter(Collision collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision collisionInfo2 = default(Collision);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionEnter(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000541")]
		[Address(RVA = "0xCB4210", Offset = "0xCB4210", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE1718]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363A]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionStay(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionStay(Collision collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision collisionInfo2 = default(Collision);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionStay(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000542")]
		[Address(RVA = "0xCB4308", Offset = "0xCB4308", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAA860]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363B]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionExit(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionExit(Collision collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision collisionInfo2 = default(Collision);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionExit(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000543")]
		[Address(RVA = "0xCB4400", Offset = "0xCB4400", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F00C28]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363C]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerEnter(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerEnter(Collider other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider other2 = default(Collider);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerEnter(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000544")]
		[Address(RVA = "0xCB44F8", Offset = "0xCB44F8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED0038]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363D]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerStay(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerStay(Collider other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider other2 = default(Collider);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerStay(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000545")]
		[Address(RVA = "0xCB45F0", Offset = "0xCB45F0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0FEF0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363E]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerExit(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerExit(Collider other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider other2 = default(Collider);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerExit(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000546")]
		[Address(RVA = "0xCB46E8", Offset = "0xCB46E8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC1798]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202363F]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoParticleCollision(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnParticleCollision(GameObject other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			GameObject other2 = default(GameObject);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoParticleCollision(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000547")]
		[Address(RVA = "0xCB47E0", Offset = "0xCB47E0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBAB38]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023640]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionEnter2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionEnter2D(Collision2D collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision2D collisionInfo2 = default(Collision2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionEnter2D(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000548")]
		[Address(RVA = "0xCB48D8", Offset = "0xCB48D8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFAB00]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023641]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionStay2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionStay2D(Collision2D collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision2D collisionInfo2 = default(Collision2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionStay2D(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000549")]
		[Address(RVA = "0xCB49D0", Offset = "0xCB49D0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBB1C0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collisionInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023642]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoCollisionExit2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnCollisionExit2D(Collision2D collisionInfo)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collision2D collisionInfo2 = default(Collision2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoCollisionExit2D(collisionInfo2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054A")]
		[Address(RVA = "0xCB4AC8", Offset = "0xCB4AC8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC34E0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023643]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerEnter2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerEnter2D(Collider2D other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider2D other2 = default(Collider2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerEnter2D(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054B")]
		[Address(RVA = "0xCB4BC0", Offset = "0xCB4BC0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA3928]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023644]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerStay2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerStay2D(Collider2D other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider2D other2 = default(Collider2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerStay2D(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0xCB4CB8", Offset = "0xCB4CB8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFD250]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, other, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023645]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoTriggerExit2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnTriggerExit2D(Collider2D other)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Collider2D other2 = default(Collider2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoTriggerExit2D(other2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0xCB4DB0", Offset = "0xCB4DB0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFDC18]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, collider, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023646]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoControllerColliderHit(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnControllerColliderHit(ControllerColliderHit collider)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			ControllerColliderHit collider2 = default(ControllerColliderHit);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoControllerColliderHit(collider2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054E")]
		[Address(RVA = "0xCB4EA8", Offset = "0xCB4EA8", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFFA70]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, force, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023647]) = v43;\nL_0017:\n\tv117 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv132 = v93 >= v117._size;\n\tif (v132) goto L_0055;\n\tv152 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv186 = v152._size < v93;\n\tv89 = ~v186;\n\tv86 = v152._size - v93;\n\tv80 = v86 == 0;\n\tv187 = ~v80;\n\tv65 = v89 & v187;\n\tif (v65) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv189 = v152._items;\n\tv217 = HutongGames.PlayMaker.FsmStateAction::Init(v189[v93 @ X21_v6 (System.Int32)], this);\n\tv219 = HutongGames.PlayMaker.FsmStateAction::DoJointBreak(v189[v93 @ X21_v6 (System.Int32)], force);\n\tv93 = v93 + 1;\n\tv117 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv221 = v117 == 0;\n\tv98 = ~v221;\n\tif (v98) goto L_0026;\n\tv106 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v148);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnJointBreak(float force)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoJointBreak(force);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x600054F")]
		[Address(RVA = "0xCB4FA8", Offset = "0xCB4FA8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFF530]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, joint, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023648]) = v43;\nL_0017:\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0026:\n\tv129 = v90 >= v114._size;\n\tif (v129) goto L_0055;\n\tv148 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv181 = v148._size < v90;\n\tv86 = ~v181;\n\tv83 = v148._size - v90;\n\tv77 = v83 == 0;\n\tv182 = ~v77;\n\tv62 = v86 & v182;\n\tif (v62) goto L_003B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003B:\n\tv184 = v148._items;\n\tv212 = HutongGames.PlayMaker.FsmStateAction::Init(v184[v90 @ X22_v6 (System.Int32)], this);\n\tv214 = HutongGames.PlayMaker.FsmStateAction::DoJointBreak2D(v184[v90 @ X22_v6 (System.Int32)], v57);\n\tv90 = v90 + 1;\n\tv114 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv216 = v114 == 0;\n\tv95 = ~v216;\n\tif (v95) goto L_0026;\n\tv103 = new System.NullReferenceException();\nL_0055:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(v144);\n\treturnVal1 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool OnJointBreak2D(Joint2D joint)
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			FsmState fsmState;
			Joint2D joint2 = default(Joint2D);
			while (true)
			{
				bool flag = num >= list.Count;
				fsmState = this;
				if (flag)
				{
					break;
				}
				List<FsmStateAction> list2 = ActiveActions;
				bool flag2 = list2.Count < num;
				bool flag3 = !flag2;
				int num2 = list2.Count - num;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].DoJointBreak2D(joint2);
				num++;
				list = ActiveActions;
				if (list == null)
				{
					NullReferenceException ex = new NullReferenceException();
					fsmState = (FsmState)(object)ex;
					break;
				}
			}
			fsmState.RemoveFinishedActions();
			return fsm.IsSwitchingState;
		}

		[Token(Token = "0x6000550")]
		[Address(RVA = "0xCB50A0", Offset = "0xCB50A0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EB5DD8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023649]) = v40;\nL_0015:\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\nL_0023:\n\tv125 = v87 >= v111._size;\n\tif (v125) goto L_0059;\n\tv151 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv177 = v151._size < v87;\n\tv83 = ~v177;\n\tv80 = v151._size - v87;\n\tv74 = v80 == 0;\n\tv178 = ~v74;\n\tv59 = v83 & v178;\n\tif (v59) goto L_0039;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0039:\n\tv180 = v151._items;\n\tv185 = HutongGames.PlayMaker.FsmStateAction::Init(v180[v87 @ X21_v5 (System.Int32)], this);\n\tv187 = HutongGames.PlayMaker.FsmStateAction::OnGUI(v180[v87 @ X21_v5 (System.Int32)]);\n\tv87 = v87 + 1;\n\tv111 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv189 = v111 == 0;\n\tv92 = ~v189;\n\tif (v92) goto L_0023;\n\tthrow System.NullReferenceException;\nL_0059:\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnGUI()
		{
			List<FsmStateAction> list = ActiveActions;
			int num = 0;
			while (num < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				bool flag = list2.Count < num;
				bool flag2 = !flag;
				int num2 = list2.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list2._items;
				items[num].Init(this);
				items[num].OnGUI();
				num++;
				list = ActiveActions;
				if (list == null)
				{
					throw new NullReferenceException();
				}
			}
			RemoveFinishedActions();
		}

		[Token(Token = "0x6000551")]
		[Address(RVA = "0xCB5184", Offset = "0xCB5184", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F04058]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202364A]) = v41;\nL_0016:\n\tv43 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Add(v43, action);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishAction(FsmStateAction action)
		{
			List<FsmStateAction> list = finishedActions;
			list.Add(action);
		}

		[Token(Token = "0x6000552")]
		[Address(RVA = "0xCB3F2C", Offset = "0xCB3F2C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF56F0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202364B]) = v44;\nL_0017:\n\tv117 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\nL_0027:\n\tv131 = v92 >= v117._size;\n\tif (v131) goto L_0052;\n\tv154 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv157 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\n\tv189 = v157._size < v92;\n\tv86 = ~v189;\n\tv83 = v157._size - v92;\n\tv77 = v83 == 0;\n\tv190 = ~v77;\n\tv62 = v86 & v190;\n\tif (v62) goto L_0042;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0042:\n\tv214 = v157._items;\n\tv216 = System.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Remove(v154, v214[v92 @ X22_v6 (System.Int32)]);\n\tv91 = v92 + 1;\n\tv117 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\n\tv218 = v117 == 0;\n\tv98 = ~v218;\n\tif (v98) goto L_0027;\n\tthrow System.NullReferenceException;\nL_0052:\n\tv152 = HutongGames.PlayMaker.FsmState::get_finishedActions(this);\n\tSystem.Collections.Generic.List`1<HutongGames.PlayMaker.FsmStateAction>::Clear(v152);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveFinishedActions()
		{
			List<FsmStateAction> list = finishedActions;
			int num = 0;
			while (num < list.Count)
			{
				List<FsmStateAction> list2 = ActiveActions;
				List<FsmStateAction> list3 = finishedActions;
				bool flag = list3.Count < num;
				bool flag2 = !flag;
				int num2 = list3.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				FsmStateAction[] items = list3._items;
				bool flag5 = list2.Remove(items[num]);
				int num3 = num + 1;
				list = finishedActions;
				bool flag6 = list == null;
				bool flag7 = !flag6;
				num = num3;
				if (!flag7)
				{
					throw new NullReferenceException();
				}
			}
			List<FsmStateAction> list4 = finishedActions;
			list4.Clear();
		}

		[Token(Token = "0x6000553")]
		[Address(RVA = "0xCB3824", Offset = "0xCB3824", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EDB820]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202364C]) = v40;\nL_0015:\n\tv42 = ~this.finished;\n\tif (v42) goto L_001F;\nL_001D:\n\treturn;\nL_001F:\n\tv81 = ~this.active;\n\tif (v81) goto L_001D;\n\tv77 = HutongGames.PlayMaker.Fsm::get_IsSwitchingState(this.fsm);\n\tv159 = v77 == 0;\n\tv82 = ~v159;\n\tif (v82) goto L_001D;\n\tHutongGames.PlayMaker.FsmState::RemoveFinishedActions(this);\n\tv78 = HutongGames.PlayMaker.FsmState::get_ActiveActions(this);\n\tv172 = v78._size == 0;\n\tv83 = ~v172;\n\tif (v83) goto L_001D;\n\tv174 = ~this.isSequence;\n\tif (v174) goto L_004F;\n\tv166 = this.actions;\n\tv75 = this.activeActionIndex + 1;\n\tthis.activeActionIndex = v75;\n\tv45 = v75 >= v166.Length;\n\tif (v45) goto L_004F;\n\tv79 = HutongGames.PlayMaker.FsmState::ActivateActions(this, v75);\n\tv84 = v79 == 0;\n\tif (v84) goto L_001D;\nL_004F:\n\tthis.finished = 1;\n\tgoto L_0061;\n\tv185 = *([v180 @ X0_v13+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0061;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v180, v160, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0061:\n\tgoto L_006C;\n\tv197 = *([1EE7760]);\n\tv198 = *([v197 @ X8_v19]);\n\tv199 = \"il2cpp_codegen_initialize_method\"(v198, v160, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv202 = 0 | 1;\n\t*([20229DD]) = v202;\nL_006C:\n\tgoto L_007F;\n\tv208 = *([v203 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\t// 112 Jump @b35\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v203, v160, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv211 = HutongGames.PlayMaker.FsmEvent;\nL_007F:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v144.<Finished>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckAllActionsFinished()
		{
			if (finished || !Active || fsm.IsSwitchingState)
			{
				return;
			}
			RemoveFinishedActions();
			List<FsmStateAction> list = ActiveActions;
			if (list.Count != 0)
			{
				return;
			}
			if (IsSequence)
			{
				FsmStateAction[] array = actions;
				int num = (activeActionIndex = ActiveActionIndex + 1);
				if (num < array.Length && !ActivateActions(num))
				{
					return;
				}
			}
			finished = true;
			fsm.Event(FsmEvent.Finished);
		}

		[Token(Token = "0x6000554")]
		[Address(RVA = "0xCB51F0", Offset = "0xCB51F0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.active = 0;\n\tv16 = HutongGames.PlayMaker.FsmState::get_Actions(this);\n\tv150 = v16.Length;\n\tv31 = v16.Length < 1;\n\tif (v31) goto L_004F;\nL_001C:\n\tv153 = v46 < v150;\n\tv72 = ~v153;\n\tif (v72) goto L_0050;\n\tv103 = v16[v46 @ X22_v5 (System.Int32)];\n\tv129 = ~v103.<Entered>k__BackingField;\n\tif (v129) goto L_003A;\n\tthis.activeAction = v16[v46 @ X22_v5 (System.Int32)];\n\tv189 = HutongGames.PlayMaker.FsmStateAction::Init(v16[v46 @ X22_v5 (System.Int32)], this);\n\tv194 = HutongGames.PlayMaker.FsmStateAction::OnExit(v16[v46 @ X22_v5 (System.Int32)]);\nL_003A:\n\tv150 = v16.Length;\n\tv46 = v46 + 1;\n\tv109 = v46 < v16.Length;\n\tif (v109) goto L_001C;\nL_004F:\n\treturn;\nL_0050:\n\tv178 = new System.IndexOutOfRangeException();\n\tthrow v178;\n\tthrow System.NullReferenceException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnExit()
		{
			active = false;
			finished = false;
			FsmStateAction[] array = Actions;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				FsmStateAction fsmStateAction = array[num2];
				if (fsmStateAction.Entered)
				{
					activeAction = array[num2];
					array[num2].Init(this);
					array[num2].OnExit();
				}
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000555")]
		[Address(RVA = "0xCB52A8", Offset = "0xCB52A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<loopCount>k__BackingField = 0;\n\treturn;\n")]
		public void ResetLoopCount()
		{
			loopCount = 0;
		}

		[Token(Token = "0x6000556")]
		[Address(RVA = "0xCB52B0", Offset = "0xCB52B0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = transitionIndex & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_FFFFFFFF;\n\tv10 = this.transitions;\n\tv41 = v10.Length - 1;\n\tv14 = v41 >= transitionIndex;\n\tif (v14) goto L_001A;\n\tgoto L_002C;\nL_001A:\n\tv97 = v10.Length < transitionIndex;\n\tv89 = ~v97;\n\tv87 = v10.Length - transitionIndex;\n\tv83 = v87 == 0;\n\tv98 = ~v89;\n\tv73 = v98 | v83;\n\tif (v73) goto L_002F;\nL_002C:\n\treturn returnVal1;\n\tv52 = new System.NullReferenceException();\nL_002F:\n\tv111 = new System.IndexOutOfRangeException();\n\tthrow v111;\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmTransition GetTransition(int transitionIndex)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(transitionIndex & 0x80000000L) == 0)
			{
				FsmTransition[] array = Transitions;
				int num = array.Length - 1;
				if (num >= transitionIndex)
				{
					bool flag = array.Length < transitionIndex;
					bool flag2 = !flag;
					int num2 = array.Length - transitionIndex;
					bool flag3 = num2 == 0;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						return array[transitionIndex];
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			return null;
		}

		[Token(Token = "0x6000557")]
		[Address(RVA = "0xCB530C", Offset = "0xCB530C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = transition == 0;\n\tif (v6) goto L_FFFFFFFF;\n\tv8 = this.transitions;\n\tv22 = v8.Length < 1;\n\tif (v22) goto L_FFFFFFFF;\nL_0017:\n\tv163 = returnVal1 < v8.Length;\n\tv92 = ~v163;\n\tif (v92) goto L_0040;\n\tv123 = v8[returnVal1 @ X0_v1 (System.Int32)] == transition;\n\tif (v123) goto L_003F;\n\treturnVal1 = returnVal1 + 1;\n\tv20 = returnVal1 < v8.Length;\n\tif (v20) goto L_0017;\nL_003F:\n\treturn returnVal1;\nL_0040:\n\tv166 = new System.IndexOutOfRangeException();\n\tthrow v166;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetTransitionIndex(FsmTransition transition)
		{
			int num;
			if (transition != null)
			{
				FsmTransition[] array = Transitions;
				if (array.Length >= 1)
				{
					num = 0;
					while (true)
					{
						if (num < array.Length)
						{
							if (array[num] == transition)
							{
								break;
							}
							num++;
							if (num < array.Length)
							{
								continue;
							}
							goto IL_00aa;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					goto IL_00c6;
				}
			}
			goto IL_00aa;
			IL_00c6:
			return num;
			IL_00aa:
			num = -1;
			goto IL_00c6;
		}

		[Token(Token = "0x6000572")]
		[Address(RVA = "0xCB55AC", Offset = "0xCB55AC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB60B0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023651]) = v38;\nL_0016:\n\tv41 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv112 = v41 == 0;\n\tif (v112) goto L_FFFFFFFF;\n\tv97 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\nL_001E:\n\tv106 = v97.states;\n\tv51 = v189 >= v106.Length;\n\tif (v51) goto L_005A;\n\tv98 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv107 = v98.states;\n\tv238 = v189 < v107.Length;\n\tv226 = ~v238;\n\tif (v226) goto L_006D;\n\tv75 = v107[v189 @ X20_v2 (System.Int32)] == state;\n\tif (v75) goto L_006C;\n\tv189 = v189 + 1;\n\tv97 = HutongGames.PlayMaker.FsmState::get_Fsm(state);\n\tv243 = v97 == 0;\n\tv100 = ~v243;\n\tif (v100) goto L_001E;\n\tthrow System.NullReferenceException;\nL_005A:\n\tgoto L_0064;\n\tv195 = *([v170 @ X0_v8+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0064;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v170, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\tUnityEngine.Debug::LogError(\"State not in FSM!\");\nL_006C:\n\treturn v189;\nL_006D:\n\tv241 = new System.IndexOutOfRangeException();\n\tthrow v241;\n\treturn returnVal2;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetStateIndex(FsmState state)
		{
			Fsm fsm = state.Fsm;
			int num;
			if (fsm != null)
			{
				Fsm fsm2 = state.Fsm;
				num = 0;
				while (true)
				{
					FsmState[] states = fsm2.States;
					if (num >= states.Length)
					{
						break;
					}
					Fsm fsm3 = state.Fsm;
					FsmState[] states2 = fsm3.States;
					if (num < states2.Length)
					{
						if (states2[num] != state)
						{
							num++;
							fsm2 = state.Fsm;
							if (fsm2 == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						goto IL_015b;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				Debug.LogError("State not in FSM!");
			}
			num = -1;
			goto IL_015b;
			IL_015b:
			return num;
		}

		[Token(Token = "0x6000573")]
		[Address(RVA = "0xCB56B4", Offset = "0xCB56B4", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EBDEA8]);\n\tv29 = *([v28 @ X8_v23]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023652]) = v48;\nL_0018:\n\tv49 = this.transitions;\n\tv192 = v49.Length;\n\tv62 = v49.Length < 1;\n\tif (v62) goto L_FFFFFFFF;\nL_0030:\n\tv203 = v75 < v192;\n\tv107 = ~v203;\n\tif (v107) goto L_0089;\n\tv119 = v49[v75 @ X22_v7 (System.Int32)];\n\tv120 = v119.fsmEvent;\n\tgoto L_0050;\n\tv268 = *([v265 @ X0_v12+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0050;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v265, v66, v64, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0050:\n\tgoto L_0058;\n\tv278 = v117;\n\tv279 = \"il2cpp_codegen_initialize_method\"(v278, v66, v64, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([20229DD]) = v71;\nL_0058:\n\tgoto L_0060;\n\tv285 = *([v281 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tgoto L_0060;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v281, v66, v64, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv288 = HutongGames.PlayMaker.FsmEvent;\nL_0060:\n\tv121 = v291.<Finished>k__BackingField;\n\tv161 = System.String::op_Equality(v120.name, v121.name);\n\tv295 = v161 == 0;\n\tv163 = ~v295;\n\tif (v163) goto L_FFFFFFFF;\n\tv192 = v49.Length;\n\tv75 = v75 + 1;\n\tv143 = v75 < v49.Length;\n\tif (v143) goto L_0030;\n\tgoto L_0086;\nL_0086:\n\treturn returnVal1;\n\tv126 = new System.NullReferenceException();\nL_0089:\n\tv194 = new System.IndexOutOfRangeException();\n\tthrow v194;\n\treturn returnVal2;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasFinishedTransition()
		{
			FsmTransition[] array = Transitions;
			int num = array.Length;
			if (array.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						FsmTransition fsmTransition = array[num2];
						FsmEvent fsmEvent = fsmTransition.FsmEvent;
						FsmEvent _003CFinished_003Ek__BackingField = FsmEvent.Finished;
						if (!(fsmEvent.Name == _003CFinished_003Ek__BackingField.Name))
						{
							num = array.Length;
							num2++;
							continue;
						}
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < array.Length);
			}
			return false;
		}
	}
}
