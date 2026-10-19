using System;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unity.Mathematics;

namespace _game.CoreSystem.LevelCreator
{
	[Token(Token = "0x20004B6")]
	public class Float2JsonConverter : JsonConverter<float2>
	{
		[Token(Token = "0x60013D9")]
		[Address(RVA = "0x3CEFB28", Offset = "0x3CEFB28", Length = "0xF4")]
		public override void WriteJson(JsonWriter writer, float2 value, JsonSerializer serializer)
		{
			writer.WriteStartObject();
			writer.WritePropertyName("x");
			writer.WriteValue(value.x);
			writer.WritePropertyName("y");
			writer.WriteValue(value.y);
			JsonWriter jsonWriter = default(JsonWriter);
			jsonWriter.WriteEndObject();
		}

		[Token(Token = "0x60013DA")]
		[Address(RVA = "0x3CEFC1C", Offset = "0x3CEFC1C", Length = "0x260")]
		public override float2 ReadJson(JsonReader reader, Type objectType, float2 existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			JsonToken tokenType = reader.TokenType;
			float2 result;
			float x;
			if (tokenType == JsonToken.Null)
			{
				result = default(float2);
			}
			else
			{
				bool flag = reader.Read();
				bool flag2 = !flag;
				result = default(float2);
				if (!flag2)
				{
					int num = 192761856 + 1336;
					JsonToken tokenType2 = reader.TokenType;
					bool flag3 = tokenType2 != JsonToken.EndObject;
					x = 0f;
					float num2 = 0f;
					if (!flag3)
					{
						goto IL_00bf;
					}
					while (true)
					{
						JsonToken tokenType3 = reader.TokenType;
						if (tokenType3 == JsonToken.PropertyName)
						{
							object value = reader.Value;
							if (value != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X24_v5 (System.Int32)+90]");
								if (value != null)
								{
									InvalidCastException ex = new InvalidCastException();
									throw new NullReferenceException();
								}
							}
							bool flag4 = reader.Read();
							if (!((string)value == "x"))
							{
								if (!((string)value == "y"))
								{
									goto IL_00d1;
								}
								object value2 = reader.Value;
								float num3 = Convert.ToSingle(value2);
								bool flag5 = reader.Read();
								bool flag6 = !flag5;
								result.x = num2;
								if (flag6)
								{
									break;
								}
								JsonToken tokenType4 = reader.TokenType;
								if (tokenType4 != JsonToken.EndObject)
								{
									continue;
								}
								x = num2;
							}
							else
							{
								object value3 = reader.Value;
								float num4 = Convert.ToSingle(value3);
								bool flag7 = reader.Read();
								bool flag8 = !flag7;
								bool flag9 = !flag8;
								num2 = num4;
								if (flag9)
								{
									goto IL_0103;
								}
								x = num4;
							}
							goto IL_00bf;
						}
						goto IL_00d1;
						IL_00d1:
						bool flag10 = reader.Read();
						bool flag11 = !flag10;
						x = num2;
						if (flag11)
						{
							goto IL_00bf;
						}
						goto IL_0103;
						IL_0103:
						JsonToken tokenType5 = reader.TokenType;
						bool flag12 = tokenType5 == JsonToken.EndObject;
						x = num2;
						if (!flag12)
						{
							continue;
						}
						goto IL_00bf;
					}
				}
			}
			goto IL_02a4;
			IL_02a4:
			return result;
			IL_00bf:
			result.x = x;
			goto IL_02a4;
		}

		[Token(Token = "0x60013DB")]
		[Address(RVA = "0x3CEFE7C", Offset = "0x3CEFE7C", Length = "0x58")]
		public Float2JsonConverter()
		{
		}
	}
}
