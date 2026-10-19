using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine
{
	[Serializable]
	[XmlRoot("dictionary")]
	[Token(Token = "0x200000B")]
	public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable, ISerializationCallbackReceiver
	{
		[XmlIgnore]
		[SerializeField]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x0")]
		public List<TKey> keys;

		[XmlIgnore]
		[SerializeField]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x0")]
		public List<TValue> values;

		[XmlIgnore]
		[SerializeField]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x0")]
		public List<TValue> nulls;

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x624F600", Offset = "0x624F600", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.List`1<TKey>>();\n\tSystem.Collections.Generic.List`1<TKey>::.ctor(v42);\n\tthis.keys = v42;\n\tgoto L_0029;\nL_0029:\n\tv61 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tSystem.Collections.Generic.List`1<TValue>::.ctor(v61);\n\tthis.values = v61;\n\tgoto L_003E;\nL_003E:\n\tv80 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tSystem.Collections.Generic.List`1<TValue>::.ctor(v80);\n\tthis.nulls = v80;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::.ctor(this);\n\treturn;\n")]
		public SerializableDictionary()
		{
			List<TKey> list = new List<TKey>();
			keys = list;
			List<TValue> list2 = new List<TValue>();
			values = list2;
			List<TValue> list3 = new List<TValue>();
			nulls = list3;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x624F704", Offset = "0x624F704", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv43 = new Il2CppClass<System.Collections.Generic.List`1<TKey>>();\n\tSystem.Collections.Generic.List`1<TKey>::.ctor(v43);\n\tthis.keys = v43;\n\tgoto L_002A;\nL_002A:\n\tv62 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tSystem.Collections.Generic.List`1<TValue>::.ctor(v62);\n\tthis.values = v62;\n\tgoto L_003F;\nL_003F:\n\tv81 = new Il2CppClass<System.Collections.Generic.List`1<TValue>>();\n\tSystem.Collections.Generic.List`1<TValue>::.ctor(v81);\n\tthis.nulls = v81;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::.ctor(this, dic);\n\treturn;\n")]
		public SerializableDictionary(SerializableDictionary<TKey, TValue> dic)
		{
			List<TKey> list = new List<TKey>();
			keys = list;
			List<TValue> list2 = new List<TValue>();
			values = list2;
			List<TValue> list3 = new List<TValue>();
			nulls = list3;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x624F810", Offset = "0x624F810", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n")]
		public XmlSchema GetSchema()
		{
			return null;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x624F818", Offset = "0x624F818", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0034:\n\tv75 = System.Type::GetTypeFromHandle(Il2CppClass<TKey>);\n\tv81 = new System.Xml.Serialization.XmlSerializer();\n\tSystem.Xml.Serialization.XmlSerializer::.ctor(v81, v75);\n\tv91 = System.Type::GetTypeFromHandle(Il2CppClass<TValue>);\n\tv94 = new System.Xml.Serialization.XmlSerializer();\n\tSystem.Xml.Serialization.XmlSerializer::.ctor(v94, v91);\n\tv103 = System.Xml.XmlReader::get_IsEmptyElement(reader);\n\tv109 = System.Xml.XmlReader::Read(reader);\n\tv111 = v103 == 0;\n\tif (v111) goto L_006A;\n\treturn;\nL_006A:\n\tv196 = System.Xml.XmlReader::get_NodeType(reader);\n\tv201 = v196 == 0xF;\n\tif (v201) goto L_010E;\n\tv318 = v81 == 0;\n\tif (v318) goto L_011A;\n\tv230 = 0x21C11D0(v389, Il2CppClass<TKey>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv404 = v230 == 0;\n\tv233 = ~v404;\nL_FFFFFFFF:\n\tv159 = v230;\n\tif (v233) goto L_00A9;\n\tgoto L_0112;\nL_FFFFFFFF:\n\tv159 = 0;\n\tv416 = System.Xml.Serialization.XmlSerializer::Deserialize(v94, reader);\n\tgoto L_00C3;\n\tv231 = 0x21C11D0(v416, Il2CppClass<TValue>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv234 = v231 == 0;\n\tif (v234) goto L_0112;\n\tv168 = System.Xml.XmlReader::ReadEndElement(reader);\n\tv440 = this == 0;\n\tv172 = ~v440;\nL_FFFFFFFF:\n\tv330 = v231;\n\tif (v172) goto L_00E2;\n\tgoto L_010F;\nL_00D9:\n\tv169 = System.Xml.XmlReader::ReadEndElement(reader);\nL_FFFFFFFF:\n\tv330 = 0;\nL_00E2:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::Add(this, v159, v330);\n\tv445 = System.Xml.XmlReader::ReadEndElement(reader);\n\tv450 = System.Xml.XmlReader::MoveToContent(reader);\n\tv341 = System.Xml.XmlReader::get_NodeType(reader);\n\tv319 = v341 != 0xF;\n\tif (v319) goto L_0080;\nL_010E:\n\tv300 = System.Xml.XmlReader::ReadEndElement(v300);\nL_010E:\n\treturn;\nL_010F:\n\tthrow System.NullReferenceException;\nL_0112:\n\tthrow System.InvalidCastException;\nL_011A:\n\tv357 = System.Xml.XmlReader::ReadStartElement(reader, \"item\");\n\tv361 = System.Xml.XmlReader::ReadStartElement(reader, \"key\");\n\tthrow System.NullReferenceException;\nL_0030:\n\tgoto L_0034;\nL_009A:\n\tv401 = v389 == 0;\n\tif (v401) goto L_FFFFFFFF;\nL_00A9:\n\tv412 = System.Xml.XmlReader::ReadEndElement(reader);\n\tv170 = System.Xml.XmlReader::ReadStartElement(reader, \"value\");\nL_00C3:\n\tv428 = v416 == 0;\n\tif (v428) goto L_00D9;\nL_0080:\n\tv379 = System.Xml.XmlReader::ReadStartElement(reader, \"item\");\n\tv386 = System.Xml.XmlReader::ReadStartElement(reader, \"key\");\n\tv389 = System.Xml.Serialization.XmlSerializer::Deserialize(v81, reader);\n\tgoto L_009A;\n")]
		public void ReadXml(XmlReader reader)
		{
			Type typeFromHandle = typeof(TKey);
			XmlSerializer xmlSerializer = new XmlSerializer(typeFromHandle);
			Type typeFromHandle2 = typeof(TValue);
			XmlSerializer xmlSerializer2 = new XmlSerializer(typeFromHandle2);
			bool isEmptyElement = reader.IsEmptyElement;
			bool flag = reader.Read();
			if (isEmptyElement)
			{
				return;
			}
			XmlNodeType nodeType = reader.NodeType;
			if (nodeType != XmlNodeType.EndElement)
			{
				if (xmlSerializer == null)
				{
					reader.ReadStartElement("item");
					reader.ReadStartElement("key");
					throw new NullReferenceException();
				}
				object obj2 = default(object);
				object obj4 = default(object);
				XmlNodeType nodeType2;
				do
				{
					reader.ReadStartElement("item");
					reader.ReadStartElement("key");
					object obj = xmlSerializer.Deserialize(reader);
					object key;
					if (obj != null)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
						bool flag2 = obj2 == null;
						bool flag3 = !flag2;
						key = obj2;
						if (!flag3)
						{
							goto IL_01fa;
						}
					}
					else
					{
						key = null;
					}
					reader.ReadEndElement();
					reader.ReadStartElement("value");
					object obj3 = xmlSerializer2.Deserialize(reader);
					object value;
					if (obj3 != null)
					{
						Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
						if (obj4 == null)
						{
							goto IL_01fa;
						}
						reader.ReadEndElement();
						bool flag4 = this == null;
						bool flag5 = !flag4;
						value = obj4;
						if (!flag5)
						{
							throw new NullReferenceException();
						}
					}
					else
					{
						reader.ReadEndElement();
						value = null;
					}
					((Dictionary<object, object>)(object)this).Add(key, value);
					reader.ReadEndElement();
					XmlNodeType xmlNodeType = reader.MoveToContent();
					nodeType2 = reader.NodeType;
					continue;
					IL_01fa:
					throw new InvalidCastException();
				}
				while (nodeType2 != XmlNodeType.EndElement);
			}
			XmlReader xmlReader = default(XmlReader);
			xmlReader.ReadEndElement();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x624FBA8", Offset = "0x624FBA8", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv94 = System.Type::GetTypeFromHandle(Il2CppClass<TValue>);\n\tv97 = new System.Xml.Serialization.XmlSerializer();\n\tSystem.Xml.Serialization.XmlSerializer::.ctor(v97, v94);\n\tv106 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Keys(this);\n\tv157 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>::GetEnumerator(v106);\n\tv276 = *([v157 @ X0_v40]);\n\tv116 = *([v157 @ X0_v40]);\n\tv169 = writer == 0;\n\tif (v169) goto L_00B1;\n\tv174 = v84 == 0;\n\tif (v174) goto L_00BB;\n\tv191 = v97 == 0;\n\tif (v191) goto L_00D1;\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"item\");\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"key\");\n\tSystem.Xml.Serialization.XmlSerializer::Serialize(v84, writer, *([v157 @ X0_v40+10]));\n\tv487 = System.Xml.XmlWriter::WriteEndElement(writer);\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"value\");\n\tv497 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this, *([v157 @ X0_v40+10]));\n\tSystem.Xml.Serialization.XmlSerializer::Serialize(v97, writer, v497);\n\tv504 = System.Xml.XmlWriter::WriteEndElement(writer);\n\tv250 = System.Xml.XmlWriter::WriteEndElement(writer);\n\tgoto L_007A;\nL_00B1:\n\tv180 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v116 @ stack_-70_v7);\n\tv198 = ~v180;\n\tif (v198) goto L_00D7;\n\tv282 = new System.NullReferenceException();\n\tv274 = &v116 @ stack_-70_v7;\n\tv276 = 0;\n\tv279 = Il2CppMethodInfo;\n\tgoto L_0112;\nL_00BB:\n\tv197 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v116 @ stack_-70_v7);\n\tv215 = ~v197;\n\tif (v215) goto L_00D7;\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"item\");\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"key\");\n\tv282 = new System.NullReferenceException();\n\tv274 = &v116 @ stack_-70_v7;\n\tv276 = 0;\n\tv279 = \"key\";\n\tgoto L_0112;\nL_00D1:\n\tv140 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v116 @ stack_-70_v7);\n\tv258 = ~v140;\n\tv142 = ~v258;\n\tif (v142) goto L_00F3;\nL_00D7:\n\t;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v116 @ stack_-70_v7);\n\tv276 = 0;\n\tgoto L_0145;\nL_00EB:\n\treturn;\nL_00F3:\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"item\");\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"key\");\n\tSystem.Xml.Serialization.XmlSerializer::Serialize(v84, writer, 0);\n\tv185 = System.Xml.XmlWriter::WriteEndElement(writer);\n\tSystem.Xml.XmlWriter::WriteStartElement(writer, \"value\");\n\tv205 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::get_Item(this, 0);\n\tv282 = new System.NullReferenceException();\n\tv279 = 0;\nL_0112:\n\t// 274 Interrupt\n\tgoto L_0134;\nL_0134:\n\tv293 = v279 != 1;\n\tv460 = v282;\n\tif (v293) goto L_0148;\n\tv466 = 0x8BF5BC4(v282, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv473 = 0x8BF5BF4(v466, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v274);\n\tv340 = *([v466 @ X0_v22]) == 0;\n\tv276 = *([v466 @ X0_v22]);\n\tif (v340) goto L_00EB;\nL_0145:\n\tv390 = new System.OutOfMemoryException();\n\tv460 = v390;\n\treturn;\nL_0032:\n\tgoto L_0038;\nL_007A:\n\tv229 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v116 @ stack_-70_v7);\n\tv231 = v229 == 0;\n\tif (v231) goto L_00D7;\nL_0148:\n\tv469 = 0x33CEFC0(&v276 @ stack_-88_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv475 = 0x8BF0368(v460, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv450 = 0xA1B8(v475, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0038:\n\tv78 = System.Type::GetTypeFromHandle(Il2CppClass<TKey>);\n\tv84 = new System.Xml.Serialization.XmlSerializer();\n\tSystem.Xml.Serialization.XmlSerializer::.ctor(v84, v78);\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void WriteXml(XmlWriter writer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SerializableDictionary::WriteXml");
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x625000C", Offset = "0x625000C", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.keys;\n\tv14 = this.keys == 0;\n\tif (v14) goto L_00C1;\n\tSystem.Collections.Generic.List`1<TKey>::Clear(v12);\n\tv30 = v12.Count < 1;\n\tif (v30) goto L_0021;\n\tv91 = 0;\nL_0021:\n\tv136 = this.values;\n\tv133 = this.values == 0;\n\tif (v133) goto L_00C1;\n\tSystem.Collections.Generic.List`1<TValue>::Clear(v136);\n\tv96 = v136.Count < 1;\n\tif (v96) goto L_003E;\nL_003E:\n\tv186 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>::GetEnumerator(this);\n\tv84 = *([v186 @ X0_v19]);\n\tv47 = *([v186 @ X0_v19]);\n\tgoto L_005B;\nL_0055:\n\t;\n\tSystem.Collections.Generic.List`1<TValue>::Add(v287, v426);\nL_005B:\n\t;\n\tv322 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v47 @ stack_-50_v5);\n\tv331 = v322 == 0;\n\tif (v331) goto L_00AE;\n\tv333 = this.keys;\n\tv334 = this.keys == 0;\n\tif (v334) goto L_00BD;\n\tv432 = v333._version + 1;\n\tv333._version = v432;\n\tv434 = v333._items == 0;\n\tif (v434) goto L_00BD;\n\tgoto L_0086;\nL_0086:\n\t;\n\tSystem.Collections.Generic.List`1<TKey>::Add(this.keys, *([v186 @ X0_v19+10]));\n\tv287 = this.values;\n\tgoto L_0055;\nL_00AE:\n\t;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v47 @ stack_-50_v5);\n\tv84 = 0;\n\tgoto L_00DF;\nL_00BC:\n\treturn;\nL_00BD:\n\tv440 = new System.NullReferenceException();\n\tgoto L_00C0;\nL_00C0:\n\t// 192 Interrupt\n\tv84 = 0;\n\tv91 = *([v186 @ X0_v19+10]);\nL_00CF:\n\tv175 = v91 != 1;\n\tif (v175) goto L_00E2;\n\tv187 = 0x8BF5BC4(v139, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv273 = 0x8BF5BF4(v187, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v47 @ stack_-50_v5);\n\tv332 = *([v187 @ X0_v3]) == 0;\n\tv84 = *([v187 @ X0_v3]);\n\tif (v332) goto L_00BC;\nL_00DF:\n\tv229 = new System.OutOfMemoryException();\n\tv139 = v229;\nL_00E2:\n\tv264 = 0x33CF008(&v84 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv275 = 0x8BF0368(v139, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv329 = 0xA1B8(v275, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_00C1:\n\tv139 = new System.NullReferenceException();\n\tgoto L_00CF;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnBeforeSerialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SerializableDictionary::OnBeforeSerialize");
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x625025C", Offset = "0x625025C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::Clear(this);\n\tv119 = this.nulls;\n\tSystem.Collections.Generic.List`1<TValue>::Clear(v119);\n\tv56 = v119.Count < 1;\n\tif (v56) goto L_0028;\nL_0028:\n\tv210 = this.keys;\n\tv120 = this.values;\n\tv159 = v210.Count != v120.Count;\n\tif (v159) goto L_00A5;\n\tv41 = 0;\n\tgoto L_0050;\nL_0041:\n\tSystem.Collections.Generic.List`1<TValue>::Add(v38, v53);\nL_0042:\n\tv41 = v41 + 1;\n\tv210 = this.keys;\nL_0050:\n\tv57 = v41 >= v210.Count;\n\tif (v57) goto L_00A2;\n\tv230 = System.Collections.Generic.List`1<TKey>::get_Item(v210, v41);\n\tv240 = v230 == 0;\n\tif (v240) goto L_0075;\n\tv267 = System.Collections.Generic.List`1<TKey>::get_Item(this.keys, v41);\n\tv273 = System.Collections.Generic.List`1<TValue>::get_Item(this.values, v41);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::Add(this, v267, v273);\n\tgoto L_0042;\nL_0075:\n\tv38 = this.nulls;\n\tv53 = System.Collections.Generic.List`1<TValue>::get_Item(this.values, v41);\n\tgoto L_0041;\nL_00A2:\n\treturn;\nL_00A5:\n\tv186 = 0xB2BD000 + 0xF80;\n\tv191 = 0x3191548(v186, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv198 = 0xB311000 + 0xA0;\n\tv202 = System.String::Format(v198, v191);\n\tv206 = 0xB28E000 + 0x98;\n\tv209 = new v206();\n\tSystem.Exception::.ctor(v209, v202);\n\tthrow v209;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SerializableDictionary::OnAfterDeserialize");
		}
	}
}
