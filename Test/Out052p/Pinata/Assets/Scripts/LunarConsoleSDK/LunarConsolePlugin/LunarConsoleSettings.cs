using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePlugin
{
	[Serializable]
	[Token(Token = "0x2000014")]
	public class LunarConsoleSettings
	{
		[SerializeField]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x10")]
		public ExceptionWarningSettings exceptionWarning;

		[SerializeField]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x18")]
		public LogOverlaySettings logOverlay;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x73CA2C", Offset = "0x73CA2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73CA2C", Offset = "0x73CA2C")]
		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x20")]
		public int capacity;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x73CA98", Offset = "0x73CA98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73CA98", Offset = "0x73CA98")]
		[SerializeField]
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x24")]
		public int trim;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73CB04", Offset = "0x73CB04")]
		[SerializeField]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x28")]
		public Gesture gesture;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73CB50", Offset = "0x73CB50")]
		[SerializeField]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x2C")]
		public bool removeRichTextTags;

		[SerializeField]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x2D")]
		public bool sortActions;

		[SerializeField]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x2E")]
		public bool sortVariables;

		[SerializeField]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x30")]
		public string[] emails;

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x13DC12C", Offset = "0x13DC12C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE4198]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AA0]) = v38;\nL_0016:\n\tv42 = new LunarConsolePlugin.ExceptionWarningSettings();\n\tv42.displayMode = 3;\n\tSystem.Object::.ctor(v42);\n\tthis.exceptionWarning = v42;\n\tv49 = new LunarConsolePlugin.LogOverlaySettings();\n\tLunarConsolePlugin.LogOverlaySettings::.ctor(v49);\n\tthis.logOverlay = v49;\n\tthis.capacity = 0x20000001200;\n\tthis.gesture = 1;\n\tthis.sortActions = 0x101;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsoleSettings()
		{
			//IL_0024: Expected I4, but got I8
			base._002Ector();
			exceptionWarning = new ExceptionWarningSettings
			{
				displayMode = ExceptionWarningDisplayMode.All
			};
			LogOverlaySettings logOverlaySettings = new LogOverlaySettings();
			logOverlay = logOverlaySettings;
			capacity = 4608;
			gesture = Gesture.SwipeDown;
			sortActions = true;
			sortVariables = true;
		}
	}
}
