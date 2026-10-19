using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000387")]
	public sealed class ToolCallDispatcher
	{
		[Token(Token = "0x4000AD3")]
		[FieldOffset(Offset = "0x10")]
		private readonly IGeneratorActions _actions;

		[Token(Token = "0x4000AD4")]
		[FieldOffset(Offset = "0x18")]
		private readonly VisualIndexMap _map;

		[Token(Token = "0x4000AD6")]
		private static readonly HashSet<string> WallPhaseForbiddenTools;

		[Token(Token = "0x17000124")]
		[field: Token(Token = "0x4000AD5")]
		[field: FieldOffset(Offset = "0x20")]
		public bool WallOnlyMode
		{
			[Token(Token = "0x6000EBE")]
			[Address(RVA = "0x3F19020", Offset = "0x3F19020", Length = "0x8")]
			get;
			[Token(Token = "0x6000EBF")]
			[Address(RVA = "0x3F19028", Offset = "0x3F19028", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6000EC0")]
		[Address(RVA = "0x3F19030", Offset = "0x3F19030", Length = "0xC8")]
		public ToolCallDispatcher(IGeneratorActions actions, VisualIndexMap map)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::.ctor");
		}

		[Token(Token = "0x6000EC1")]
		[Address(RVA = "0x3F190F8", Offset = "0x3F190F8", Length = "0x2348")]
		public unsafe ToolResultEnvelope Dispatch(ToolCallEnvelope envelope)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::Dispatch");
			return default;
		}

		[Token(Token = "0x6000EC2")]
		[Address(RVA = "0x3F1CEF8", Offset = "0x3F1CEF8", Length = "0x70")]
		private string Translate(string text)
		{
			return VisualIndexText.TranslateCoords(text, _map);
		}

		[Token(Token = "0x6000EC3")]
		[Address(RVA = "0x3F1B54C", Offset = "0x3F1B54C", Length = "0xA4")]
		private static bool IsWallPhaseForbidden(string tool)
		{
			return WallPhaseForbiddenTools.Contains(tool);
		}

		[Token(Token = "0x6000EC4")]
		[Address(RVA = "0x3F1CF68", Offset = "0x3F1CF68", Length = "0x448")]
		private JObject WallDrainageJson(WallDrainageReport r)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::WallDrainageJson");
			return default;
		}

		[Token(Token = "0x6000EC5")]
		[Address(RVA = "0x3F1CCBC", Offset = "0x3F1CCBC", Length = "0x23C")]
		private JObject NeighborsJson(JObject args)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::NeighborsJson");
			return default;
		}

		[Token(Token = "0x6000EC6")]
		[Address(RVA = "0x3F1B70C", Offset = "0x3F1B70C", Length = "0x168")]
		private ToolResultEnvelope Wrap(int seq, ActionResult r)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::Wrap");
			return default;
		}

		[Token(Token = "0x6000EC7")]
		[Address(RVA = "0x4D1485C", Offset = "0x4D1485C", Length = "0xC0")]
		private ToolResultEnvelope Wrap<T>(int seq, ActionResult<T> r)
		{
			if (r.IsSuccess)
			{
				return ToolResultEnvelope.Success(seq);
			}
			ActionError error = r.Error;
			string message = Translate(error.Message);
			ActionError error2 = r.Error;
			string hint = Translate(error2.FixHint);
			return ToolResultEnvelope.Failure(seq, error.Code, message, hint);
		}

		[Token(Token = "0x6000EC8")]
		[Address(RVA = "0x3F1B5F0", Offset = "0x3F1B5F0", Length = "0x11C")]
		private GridCoord ReadCell(JObject args, string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::ReadCell");
			return default;
		}

		[Token(Token = "0x6000EC9")]
		[Address(RVA = "0x3F1B874", Offset = "0x3F1B874", Length = "0x4F4")]
		private IReadOnlyList<GridCoord> ReadCellList(JObject args, string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::ReadCellList");
			return default;
		}

		[Token(Token = "0x6000ECA")]
		[Address(RVA = "0x3F1BD68", Offset = "0x3F1BD68", Length = "0x1D4")]
		private static GridCoord ReadMoldCoord(JObject args, string key)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::ReadMoldCoord");
			return default;
		}

		[Token(Token = "0x6000ECB")]
		[Address(RVA = "0x4D13988", Offset = "0x4D13988", Length = "0x1A8")]
		private static T ReadEnum<T>(JObject args, string key) where T : struct, Enum
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::ReadEnum");
			return default;
		}

		[Token(Token = "0x6000ECC")]
		[Address(RVA = "0x4D13D48", Offset = "0x4D13D48", Length = "0x55C")]
		private unsafe static IReadOnlyList<T> ReadEnumList<T>(JObject args, string key) where T : struct, Enum
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolCallDispatcher::ReadEnumList");
			return default;
		}

		[Token(Token = "0x6000ECD")]
		[Address(RVA = "0x3F1D464", Offset = "0x3F1D464", Length = "0x398")]
		static ToolCallDispatcher()
		{
			HashSet<string> hashSet = new HashSet<string>();
			bool flag = hashSet.Add("PlaceCube");
			bool flag2 = hashSet.Add("PlaceTunnel");
			bool flag3 = hashSet.Add("PlaceLock");
			bool flag4 = hashSet.Add("PlaceKey");
			bool flag5 = hashSet.Add("PlaceHidden");
			bool flag6 = hashSet.Add("ApplyHidden");
			bool flag7 = hashSet.Add("PlaceGarage");
			bool flag8 = hashSet.Add("PlaceHammerArea");
			bool flag9 = hashSet.Add("PlaceSnake");
			bool flag10 = hashSet.Add("BuildSnakeAt");
			bool flag11 = hashSet.Add("PlacePin");
			bool flag12 = hashSet.Add("BuildPinAt");
			bool flag13 = hashSet.Add("LinkCubes");
			bool flag14 = hashSet.Add("LinkCubesAt");
			bool flag15 = hashSet.Add("PlaceMold");
			bool flag16 = hashSet.Add("SetMoldGridRows");
			bool flag17 = hashSet.Add("LinkMolds");
			bool flag18 = hashSet.Add("SetMoldHidden");
			bool flag19 = hashSet.Add("RemoveCell");
			bool flag20 = hashSet.Add("RemoveMold");
			WallPhaseForbiddenTools = hashSet;
		}
	}
}
