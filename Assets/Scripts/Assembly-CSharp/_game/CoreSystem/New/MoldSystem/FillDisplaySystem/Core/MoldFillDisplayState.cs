using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core
{
	[Token(Token = "0x20002D4")]
	public class MoldFillDisplayState
	{
		[Token(Token = "0x40008B2")]
		[FieldOffset(Offset = "0x10")]
		public readonly Dictionary<int, TextMeshPro> MoldTexts;

		[Token(Token = "0x40008B3")]
		[FieldOffset(Offset = "0x18")]
		public readonly Dictionary<int, EntityId> EntityIds;

		[Token(Token = "0x40008B4")]
		[FieldOffset(Offset = "0x20")]
		public readonly Dictionary<int, int> LastPercent;

		[Token(Token = "0x40008B5")]
		[FieldOffset(Offset = "0x28")]
		public readonly Dictionary<int, int> FramesSinceLastChange;

		[Token(Token = "0x40008B6")]
		[FieldOffset(Offset = "0x30")]
		public readonly HashSet<int> Filling;

		[Token(Token = "0x40008B7")]
		[FieldOffset(Offset = "0x38")]
		public readonly List<int> TempKeys;

		[Token(Token = "0x6000C7F")]
		[Address(RVA = "0x3ED5870", Offset = "0x3ED5870", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0046;\n\tv89 = new System.Collections.Generic.Dictionary`2<System.Int32, _game.BaseLayerSystems.EntitySystem.Core.EntityId>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.BaseLayerSystems.EntitySystem.Core.EntityId>::.ctor(v89);\n\tthis.EntityIds = v89;\n\tv106 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::.ctor(v106);\n\tthis.LastPercent = v106;\n\tv122 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::.ctor(v122);\n\tthis.FramesSinceLastChange = v122;\n\tv130 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v130);\n\tthis.Filling = v130;\n\tv140 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v140);\n\tthis.TempKeys = v140;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0046:\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, TMPro.TextMeshPro>::.ctor(v72);\n\tthis.MoldTexts = v72;\n")]
		public MoldFillDisplayState()
		{
			Dictionary<int, TextMeshPro> moldTexts = new Dictionary<int, TextMeshPro>();
			MoldTexts = moldTexts;
			Dictionary<int, EntityId> entityIds = new Dictionary<int, EntityId>();
			EntityIds = entityIds;
			Dictionary<int, int> lastPercent = new Dictionary<int, int>();
			LastPercent = lastPercent;
			Dictionary<int, int> framesSinceLastChange = new Dictionary<int, int>();
			FramesSinceLastChange = framesSinceLastChange;
			HashSet<int> filling = new HashSet<int>();
			Filling = filling;
			List<int> tempKeys = new List<int>();
			TempKeys = tempKeys;
		}
	}
}
