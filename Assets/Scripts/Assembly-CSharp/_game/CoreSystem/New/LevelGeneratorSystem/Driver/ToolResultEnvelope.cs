using Cpp2ILInjected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000389")]
	public sealed class ToolResultEnvelope
	{
		[Token(Token = "0x17000128")]
		[field: Token(Token = "0x4000ADA")]
		[field: FieldOffset(Offset = "0x10")]
		public int Seq
		{
			[Token(Token = "0x6000ED6")]
			[Address(RVA = "0x3F1D834", Offset = "0x3F1D834", Length = "0x8")]
			get;
			[Token(Token = "0x6000ED7")]
			[Address(RVA = "0x3F1D83C", Offset = "0x3F1D83C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000129")]
		[field: Token(Token = "0x4000ADB")]
		[field: FieldOffset(Offset = "0x14")]
		public bool Ok
		{
			[Token(Token = "0x6000ED8")]
			[Address(RVA = "0x3F1D844", Offset = "0x3F1D844", Length = "0x8")]
			get;
			[Token(Token = "0x6000ED9")]
			[Address(RVA = "0x3F1D84C", Offset = "0x3F1D84C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700012A")]
		[field: Token(Token = "0x4000ADC")]
		[field: FieldOffset(Offset = "0x18")]
		public JToken Value
		{
			[Token(Token = "0x6000EDA")]
			[Address(RVA = "0x3F1D854", Offset = "0x3F1D854", Length = "0x8")]
			get;
			[Token(Token = "0x6000EDB")]
			[Address(RVA = "0x3F1D85C", Offset = "0x3F1D85C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700012B")]
		[field: Token(Token = "0x4000ADD")]
		[field: FieldOffset(Offset = "0x20")]
		public ResultError Error
		{
			[Token(Token = "0x6000EDC")]
			[Address(RVA = "0x3F1D864", Offset = "0x3F1D864", Length = "0x8")]
			get;
			[Token(Token = "0x6000EDD")]
			[Address(RVA = "0x3F1D86C", Offset = "0x3F1D86C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x6000EDE")]
		[Address(RVA = "0x3F1BF3C", Offset = "0x3F1BF3C", Length = "0x8C")]
		public static ToolResultEnvelope Success(int seq, JToken value = null)
		{
			ToolResultEnvelope toolResultEnvelope = new ToolResultEnvelope();
			toolResultEnvelope.Seq = seq;
			toolResultEnvelope.Ok = true;
			toolResultEnvelope.Value = value;
			return toolResultEnvelope;
		}

		[Token(Token = "0x6000EDF")]
		[Address(RVA = "0x3F1B440", Offset = "0x3F1B440", Length = "0x10C")]
		public static ToolResultEnvelope Failure(int seq, string code, string message, string hint = "")
		{
			//IL_0099: Expected O, but got I
			//IL_00a9: Expected O, but got I
			ToolResultEnvelope toolResultEnvelope = new ToolResultEnvelope();
			toolResultEnvelope.Seq = seq;
			toolResultEnvelope.Ok = false;
			ResultError resultError = new ResultError();
			resultError.Code = code;
			resultError.Message = message;
			bool flag = hint == null;
			bool flag2 = !flag;
			string _003CHint_003Ek__BackingField = hint;
			if (!flag2)
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v8 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X8_v9+B8]");
				object obj2 = 0;
				_003CHint_003Ek__BackingField = (string)obj2;
			}
			resultError.Hint = _003CHint_003Ek__BackingField;
			toolResultEnvelope.Error = resultError;
			return toolResultEnvelope;
		}

		[Token(Token = "0x6000EE0")]
		[Address(RVA = "0x3F1D884", Offset = "0x3F1D884", Length = "0xE0")]
		public string ToJson()
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
			jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			CamelCasePropertyNamesContractResolver _003CContractResolver_003Ek__BackingField = new CamelCasePropertyNamesContractResolver();
			jsonSerializerSettings.ContractResolver = _003CContractResolver_003Ek__BackingField;
			return JsonConvert.SerializeObject(this, jsonSerializerSettings);
		}

		[Token(Token = "0x6000EE1")]
		[Address(RVA = "0x3F1D874", Offset = "0x3F1D874", Length = "0x8")]
		public ToolResultEnvelope()
		{
		}
	}
}
