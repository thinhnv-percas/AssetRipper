using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000011")]
	internal class ScreenData : ISerializationCallbackReceiver
	{
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x10")]
		public int width;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x14")]
		public int height;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x18")]
		public int navigationBarHeight;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x1C")]
		public float dpi;

		[SerializeField]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x20")]
		private ScreenOrientation[] orientationKeys;

		[SerializeField]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x28")]
		private OrientationDependentData[] orientationValues;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x30")]
		public Dictionary<ScreenOrientation, OrientationDependentData> orientations;

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x3F45F84", Offset = "0x3F45F84", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv49 = System.Collections.Generic.Dictionary`2<UnityEngine.ScreenOrientation, E7.NotchSolution.OrientationDependentData>::get_Keys(this.orientations);\n\tv58 = System.Linq.Enumerable::ToArray(v49);\n\tthis.orientationKeys = v58;\n\tv88 = System.Collections.Generic.Dictionary`2<UnityEngine.ScreenOrientation, E7.NotchSolution.OrientationDependentData>::get_Values(this.orientations);\n\tv90 = System.Linq.Enumerable::ToArray(v88);\n\tthis.orientationValues = v90;\n\treturn;\nL_0047:\n\treturn;\nL_001C:\n\tv40 = this.orientations == 0;\n\tif (v40) goto L_0047;\n")]
		public void OnBeforeSerialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenData::OnBeforeSerialize");
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x3F46064", Offset = "0x3F46064", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv131 = this.orientationKeys;\n\tv134 = 0;\n\tv116 = this.orientationValues;\n\tv201 = v134 << 2;\n\tv202 = v131 + v201;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.ScreenOrientation, E7.NotchSolution.OrientationDependentData>::Add(this.orientations, *([v202 @ X8_v7+20]), v116[v134 @ X20_v7 (System.Int32)]);\n\tv134 = v134 + 1;\n\tv131 = this.orientationKeys;\n\tv204 = this.orientationKeys == 0;\n\tv125 = ~v204;\n\tif (v125) goto L_0039;\n\tthrow System.NullReferenceException;\nL_0061:\n\treturn;\nL_001F:\n\tv48 = new System.Collections.Generic.Dictionary`2<UnityEngine.ScreenOrientation, E7.NotchSolution.OrientationDependentData>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.ScreenOrientation, E7.NotchSolution.OrientationDependentData>::.ctor(v48);\n\tthis.orientations = v48;\nL_0039:\n\tv67 = v134 >= v131.Length;\n\tif (v67) goto L_0061;\n")]
		public void OnAfterDeserialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenData::OnAfterDeserialize");
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3F46160", Offset = "0x3F46160", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ScreenData()
		{
		}
	}
}
