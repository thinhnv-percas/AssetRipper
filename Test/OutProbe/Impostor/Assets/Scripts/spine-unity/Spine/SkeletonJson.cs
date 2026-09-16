using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200005B")]
	public class SkeletonJson
	{
		[Token(Token = "0x200005C")]
		internal class LinkedMesh
		{
			[Token(Token = "0x4000250")]
			[FieldOffset(Offset = "0x10")]
			internal string parent;

			[Token(Token = "0x4000251")]
			[FieldOffset(Offset = "0x18")]
			internal string skin;

			[Token(Token = "0x4000252")]
			[FieldOffset(Offset = "0x20")]
			internal int slotIndex;

			[Token(Token = "0x4000253")]
			[FieldOffset(Offset = "0x28")]
			internal MeshAttachment mesh;

			[Token(Token = "0x4000254")]
			[FieldOffset(Offset = "0x30")]
			internal bool inheritDeform;

			[Token(Token = "0x60003E7")]
			[Address(RVA = "0x154C34C", Offset = "0x154C34C", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mesh = mesh;\n\tthis.slotIndex = slotIndex;\n\tthis.parent = parent;\n\tthis.skin = skin;\n\tthis.inheritDeform = inheritDeform;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public LinkedMesh(MeshAttachment mesh, string skin, int slotIndex, string parent, bool inheritDeform)
			{
				this.mesh = mesh;
				this.slotIndex = slotIndex;
				this.parent = parent;
				this.skin = skin;
				this.inheritDeform = inheritDeform;
			}
		}

		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x18")]
		private AttachmentLoader attachmentLoader;

		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x20")]
		private List<LinkedMesh> linkedMeshes;

		[Token(Token = "0x17000134")]
		public float Scale
		{
			[CompilerGenerated]
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x154193C", Offset = "0x154193C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Scale>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Scale;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x1541944", Offset = "0x1541944", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Scale>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Scale = value;
			}
		}

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0x154194C", Offset = "0x154194C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.AtlasAttachmentLoader;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, atlasArray, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B9C]) = v40;\nL_0016:\n\tv42 = new Spine.AtlasAttachmentLoader();\n\tSpine.AtlasAttachmentLoader::.ctor(v42, atlasArray);\n\tSpine.SkeletonJson::.ctor(this, v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonJson(params Atlas[] atlasArray)
			: this(new AtlasAttachmentLoader(atlasArray))
		{
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0x15419B8", Offset = "0x15419B8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, attachmentLoader, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, attachmentLoader, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B9D]) = v45;\nL_001C:\n\tv47 = new System.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>();\n\tSystem.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>::.ctor(v47);\n\tthis.linkedMeshes = v47;\n\tSystem.Object::.ctor(this);\n\tv54 = attachmentLoader == 0;\n\tif (v54) goto L_0034;\n\tthis.attachmentLoader = attachmentLoader;\n\tthis.<Scale>k__BackingField = 1f;\n\treturn;\nL_0034:\n\tv82 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v82, \"attachmentLoader\", \"attachmentLoader cannot be null.\");\n\tthrow v82;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonJson(AttachmentLoader attachmentLoader)
		{
			List<LinkedMesh> list = new List<LinkedMesh>();
			linkedMeshes = list;
			if (attachmentLoader != null)
			{
				this.attachmentLoader = attachmentLoader;
				Scale = 1f;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("attachmentLoader", "attachmentLoader cannot be null.");
			throw ex;
		}

		[Token(Token = "0x60003DA")]
		[Address(RVA = "0x1541AA8", Offset = "0x1541AA8", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = System.IO.FileStream;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, path, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv51 = System.IDisposable;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, path, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv60 = System.IO.Path;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, path, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = System.IO.StreamReader;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, path, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B9E]) = v45;\nL_0024:\n\tv49 = new System.IO.FileStream();\n\tSystem.IO.FileStream::.ctor(v49, path, 3, 1, 1);\n\tv63 = new System.IO.StreamReader();\n\tSystem.IO.StreamReader::.ctor(v63, v49);\n\tv71 = Spine.SkeletonJson::ReadSkeletonData(this, v63);\n\tgoto L_0040;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v75, v70, v67, v54, v55, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0040:\n\tv83 = System.IO.Path::GetFileNameWithoutExtension(path);\n\tv84 = v71 == 0;\n\tif (v84) goto L_0080;\n\tv71.name = v83;\n\tv86 = v63 == 0;\n\tif (v86) goto L_0072;\nL_004B:\n\tgoto L_0071;\n\tv198 = *([v174 @ X8_v14+B0]);\n\tv199 = v198 + 8;\n\tv201 = *([v247 @ X10_v15-8]);\n\tv253 = v201 == v175;\n\tif (v253) goto L_006A;\n\tv223 = v248 - 1;\n\tv221 = v247 + 0x10;\n\tv203 = v248 != 1;\n\tif (v203) goto L_FFFFFFFF;\n\tv224 = v68;\n\tv225 = 0;\n\tv226 = 0xB349B4(v224, v175, v225, v54, v55, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0071;\nL_006A:\n\tv304 = *([v247 @ X10_v15]);\n\tv305 = v304 << 4;\n\tv306 = v174 + v305;\n\tv307 = v306 + 0x138;\nL_0071:\n\tSystem.IDisposable::Dispose(v63);\nL_0072:\n\tv197 = v137 == 0;\n\tv133 = ~v197;\n\tif (v133) goto L_007F;\n\treturn v135;\nL_007F:\n\tv131 = new System.OutOfMemoryException();\nL_0080:\n\tv140 = new System.NullReferenceException();\n\tgoto L_008D;\n\tgoto L_008D;\nL_008D:\n\tv144 = v286 != 1;\n\tif (v144) goto L_0099;\n\tv302 = 0x1854E70(v140, v286, v288, 1, 1, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv171 = *([v302 @ X0_v32]);\n\tv166 = 0x1854E80(v302, v286, v288, 1, 1, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv312 = v63 == 0;\n\tv168 = ~v312;\n\tif (v168) goto L_004B;\n\tgoto L_0072;\nL_0099:\n\tgoto L_009B;\n\tX21 = X0;\nL_009B:\n\tv311 = v63 == 0;\n\tif (v311) goto L_00CA;\n\tgoto L_00C7;\n\tv337 = *([v313 @ X8_v9+B0]);\n\tv338 = v337 + 8;\n\tv340 = *([v381 @ X10_v8-8]);\n\tv387 = v340 == v314;\n\tif (v387) goto L_00C0;\n\tv362 = v382 - 1;\n\tv360 = v381 + 0x10;\n\tv342 = v382 != 1;\n\tif (v342) goto L_FFFFFFFF;\n\tv363 = v68;\n\tv364 = 0;\n\tv365 = 0xB349B4(v363, v314, v364, v54, v55, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00C7;\nL_00C0:\n\tv393 = *([v381 @ X10_v8]);\n\tv394 = v393 << 4;\n\tv395 = v313 + v394;\n\tv396 = v395 + 0x138;\nL_00C7:\n\tSystem.IDisposable::Dispose(v63);\nL_00CA:\n\tgoto L_00CE;\n\tv367 = 0xBD3CD0(v140, v286, v288, 1, 1, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00CE:\n\tv370 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v370, v286, v288, 1, 1, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn returnVal2;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonData ReadSkeletonData(string path)
		{
			//IL_0114: Expected I4, but got O
			//IL_0162: Expected I4, but got O
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			StreamReader streamReader = new StreamReader(stream);
			SkeletonData skeletonData = ReadSkeletonData(streamReader);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			bool flag = skeletonData == null;
			int num = 0;
			int num2 = 0;
			if (flag)
			{
				goto IL_00cf;
			}
			skeletonData.Name = fileNameWithoutExtension;
			bool flag2 = streamReader == null;
			SkeletonData skeletonData2 = skeletonData;
			int num3 = 0;
			num = 0;
			num2 = 0;
			SkeletonData result = skeletonData;
			int num4 = 0;
			if (flag2)
			{
				goto IL_01d6;
			}
			goto IL_01fe;
			IL_00cf:
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				object obj = default(object);
				num3 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				bool flag3 = streamReader == null;
				bool flag4 = !flag3;
				skeletonData2 = null;
				if (flag4)
				{
					goto IL_01fe;
				}
				result = null;
				num4 = (int)obj;
				goto IL_01d6;
			}
			if (streamReader != null)
			{
				((IDisposable)streamReader).Dispose();
				num = 0;
				num2 = 0;
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			SkeletonData result2 = default(SkeletonData);
			return result2;
			IL_01fe:
			((IDisposable)streamReader).Dispose();
			num = 0;
			num2 = 0;
			result = skeletonData2;
			num4 = num3;
			goto IL_01d6;
			IL_01d6:
			if (num4 == 0)
			{
				return result;
			}
			OutOfMemoryException ex3 = new OutOfMemoryException();
			goto IL_00cf;
		}

		[Token(Token = "0x60003DB")]
		[Address(RVA = "0x1541CC4", Offset = "0x1541CC4", Length = "0x4248")]
		public unsafe SkeletonData ReadSkeletonData(TextReader reader)
		{
			//IL_3ee1: Expected O, but got I
			//IL_0def: Expected O, but got I
			//IL_0831: Expected I, but got O
			//IL_303c: Expected O, but got I
			//IL_0d78: Expected I, but got O
			//IL_0241: Expected O, but got I
			//IL_3089: Expected I4, but got O
			//IL_01f0: Expected O, but got I
			//IL_2dde: Expected F4, but got O
			//IL_1905: Expected I, but got O
			//IL_1936: Expected I, but got O
			//IL_441d: Expected I, but got O
			//IL_3471: Expected O, but got I
			//IL_4631: Expected O, but got I
			//IL_0711: Expected O, but got F4
			//IL_0fa5: Expected O, but got F4
			//IL_148f: Expected O, but got F4
			//IL_0770: Expected I4, but got O
			//IL_20bf: Expected O, but got F4
			//IL_1a95: Expected O, but got F4
			//IL_228c: Expected O, but got F4
			//IL_07aa: Expected I4, but got O
			//IL_2459: Expected O, but got F4
			//IL_1c73: Expected I4, but got O
			//IL_2626: Expected O, but got F4
			//IL_0ce8: Expected I4, but got O
			//IL_1cb3: Expected I4, but got O
			//IL_0d22: Expected I4, but got O
			//IL_1d05: Expected I4, but got O
			//IL_1d45: Expected I4, but got O
			//IL_2ce3: Expected F4, but got O
			//IL_2ceb: Expected O, but got I
			//IL_2cf9: Expected I, but got O
			//IL_1d97: Expected I4, but got O
			//IL_2d73: Expected F4, but got O
			//IL_1dd1: Expected I4, but got O
			//IL_2b30: Expected F4, but got O
			//IL_2b38: Expected O, but got I
			//IL_2b46: Expected I, but got O
			//IL_2db9: Expected F4, but got O
			//IL_2895: Expected O, but got I
			//IL_2ca0: Expected F4, but got O
			//IL_2cae: Expected I, but got O
			//IL_2cb4: Expected O, but got I
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			SkeletonData skeletonData;
			object obj;
			Dictionary<string, object> dictionary2;
			string text2;
			Exception ex2;
			object obj2;
			if (reader != null)
			{
				skeletonData = new SkeletonData();
				obj = Json.Deserialize(reader);
				if (obj != null)
				{
					Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
					if (dictionary != null)
					{
						bool flag = ((Dictionary<object, object>)obj).ContainsKey((object)"skeleton");
						bool flag2 = !flag;
						float num = 0f;
						obj2 = obj;
						if (flag2)
						{
							goto IL_3d9d;
						}
						dictionary2 = (Dictionary<string, object>)((Dictionary<object, object>)obj)[(object)"skeleton"];
						Dictionary<string, object> dictionary3 = dictionary2 as Dictionary<string, object>;
						if (dictionary3 != null)
						{
							string text = (string)dictionary2["hash"];
							if (text != null)
							{
								bool flag3 = (object)text.GetType() != typeof(string);
								num = 0f;
								if (!flag3)
								{
									skeletonData.Hash = text;
									if ((object)text.GetType() == typeof(string))
									{
										goto IL_3de3;
									}
									num = 0f;
								}
								goto IL_36f3;
							}
							skeletonData.Hash = null;
							goto IL_3de3;
						}
						throw new InvalidCastException();
					}
				}
				Exception ex = new Exception();
				text2 = "Invalid JSON.";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException("reader", "reader cannot be null.");
			}
			goto IL_3912;
			IL_33f8:
			SkeletonData skeletonData2;
			return skeletonData2;
			IL_37fc:
			InvalidCastException ex4 = new InvalidCastException();
			throw new NullReferenceException();
			IL_1a78:
			object obj3;
			object enumerator3 = ((List<object>)obj3).GetEnumerator();
			object obj4 = enumerator2;
			float num2 = default(float);
			obj4 = num2;
			Dictionary<string, object> dictionary4 = default(Dictionary<string, object>);
			PathConstraintData pathConstraintData;
			while (enumerator2.MoveNext())
			{
				if (dictionary4 == null || (object)dictionary4.GetType() == typeof(string))
				{
					if (skeletonData2 != null)
					{
						BoneData boneData = skeletonData2.FindBone((string)(object)dictionary4);
						if (boneData != null)
						{
							if (pathConstraintData.Bones != null)
							{
								pathConstraintData.Bones.Add(boneData);
								continue;
							}
							throw new NullReferenceException();
						}
						string message = "Path bone not found: " + (string)(object)dictionary4;
						Exception ex5 = new Exception(message);
						throw ex5;
					}
					throw new NullReferenceException();
				}
				throw new InvalidCastException();
			}
			enumerator2.Dispose();
			OutOfMemoryException ex6 = new OutOfMemoryException();
			goto IL_381e;
			IL_37ee:
			InvalidCastException ex7 = new InvalidCastException();
			goto IL_37fc;
			IL_205c:
			string text3;
			object obj5 = ((Dictionary<object, object>)(object)text3)[(object)"bones"];
			List<object> list = obj5 as List<object>;
			Skin skin;
			if (list != null)
			{
				object enumerator4 = ((List<object>)obj5).GetEnumerator();
				object obj6 = enumerator2;
				obj6 = num2;
				while (enumerator2.MoveNext())
				{
					if (text3 == null || (object)text3.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							BoneData boneData2 = skeletonData2.FindBone(text3);
							if (boneData2 != null)
							{
								if (skin != null)
								{
									if (skin.Bones != null)
									{
										skin.Bones.Add(boneData2);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							string message2 = "Skin bone not found: " + text3;
							Exception ex8 = new Exception(message2);
							throw ex8;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				throw new OutOfMemoryException();
			}
			goto IL_37e0;
			IL_3537:
			InvalidCastException ex9 = new InvalidCastException();
			goto IL_3545;
			IL_3093:
			bool flag4 = ((Dictionary<object, object>)obj).ContainsKey((object)"events");
			bool flag5 = !flag4;
			object obj7 = obj;
			Dictionary<string, object> dictionary6 = default(Dictionary<string, object>);
			if (!flag5)
			{
				object obj8 = ((Dictionary<object, object>)obj)[(object)"events"];
				Dictionary<string, object> dictionary5 = obj8 as Dictionary<string, object>;
				if (dictionary5 == null)
				{
					goto IL_36f3;
				}
				object enumerator5 = ((Dictionary<object, object>)obj8).GetEnumerator();
				Dictionary<object, object>.Enumerator enumerator6 = default(Dictionary<object, object>.Enumerator);
				while (enumerator6.MoveNext())
				{
					if (dictionary6 != null)
					{
						Dictionary<string, object> dictionary7 = dictionary6 as Dictionary<string, object>;
						if (dictionary7 == null)
						{
							goto IL_3537;
						}
					}
					EventData eventData = new EventData(text3);
					int num3 = GetInt(dictionary6, "int", 0);
					eventData.Int = num3;
					float num4 = GetFloat(dictionary6, "float", 0f);
					eventData.Float = num4;
					string text4 = GetString(dictionary6, "string", string.Empty);
					eventData.String = text4;
					string text5 = (eventData.AudioPath = GetString(dictionary6, "audio", null));
					if (text5 != null)
					{
						float volume = GetFloat(dictionary6, "volume", 1f);
						eventData.Volume = volume;
						num4 = GetFloat(dictionary6, "balance", 0f);
						eventData.Balance = num4;
					}
					skeletonData2.Events.Add(eventData);
				}
				enumerator6.Dispose();
				obj7 = obj;
			}
			SkeletonJson skeletonJson;
			if (((Dictionary<object, object>)obj7).ContainsKey((object)"animations"))
			{
				object obj9 = ((Dictionary<object, object>)obj7)[(object)"animations"];
				Dictionary<string, object> dictionary8 = obj9 as Dictionary<string, object>;
				if (dictionary8 == null)
				{
					goto IL_36f3;
				}
				object enumerator7 = ((Dictionary<object, object>)obj9).GetEnumerator();
				Dictionary<object, object>.Enumerator enumerator8 = default(Dictionary<object, object>.Enumerator);
				while (enumerator8.MoveNext())
				{
					if (dictionary6 != null)
					{
						Dictionary<string, object> dictionary9 = dictionary6 as Dictionary<string, object>;
						if (dictionary9 == null)
						{
							throw new InvalidCastException();
						}
					}
					skeletonJson.ReadAnimation(dictionary6, text3, skeletonData2);
				}
				enumerator8.Dispose();
			}
			skeletonData2.Bones.TrimExcess();
			skeletonData2.Slots.TrimExcess();
			skeletonData2.Skins.TrimExcess();
			skeletonData2.Events.TrimExcess();
			skeletonData2.Animations.TrimExcess();
			skeletonData2.IkConstraints.TrimExcess();
			goto IL_33f8;
			IL_25c3:
			object obj10 = ((Dictionary<object, object>)(object)text3)[(object)"path"];
			List<object> list2 = obj10 as List<object>;
			if (list2 != null)
			{
				object enumerator9 = ((List<object>)obj10).GetEnumerator();
				object obj11 = enumerator2;
				obj11 = num2;
				while (enumerator2.MoveNext())
				{
					if (text3 == null || (object)text3.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							PathConstraintData pathConstraintData2 = skeletonData2.FindPathConstraint(text3);
							if (pathConstraintData2 != null)
							{
								if (skin != null)
								{
									if (skin.Constraints != null)
									{
										skin.Constraints.Add(pathConstraintData2);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							string message3 = "Skin path constraint not found: " + text3;
							Exception ex10 = new Exception(message3);
							throw ex10;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				OutOfMemoryException ex11 = new OutOfMemoryException();
				throw new NullReferenceException();
			}
			goto IL_381e;
			IL_2229:
			object obj12 = ((Dictionary<object, object>)(object)text3)[(object)"ik"];
			List<object> list3 = obj12 as List<object>;
			if (list3 != null)
			{
				object enumerator10 = ((List<object>)obj12).GetEnumerator();
				object obj13 = enumerator2;
				obj13 = num2;
				while (enumerator2.MoveNext())
				{
					if (text3 == null || (object)text3.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							IkConstraintData ikConstraintData = skeletonData2.FindIkConstraint(text3);
							if (ikConstraintData != null)
							{
								if (skin != null)
								{
									if (skin.Constraints != null)
									{
										skin.Constraints.Add(ikConstraintData);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							string message4 = "Skin IK constraint not found: " + text3;
							Exception ex12 = new Exception(message4);
							throw ex12;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				OutOfMemoryException ex13 = new OutOfMemoryException();
				throw new NullReferenceException();
			}
			goto IL_37ee;
			IL_381e:
			InvalidCastException ex14 = new InvalidCastException();
			goto IL_382c;
			IL_36f3:
			throw new InvalidCastException();
			IL_3de3:
			string text7 = (string)dictionary2["spine"];
			object obj14;
			if (text7 != null)
			{
				bool flag6 = (object)text7.GetType() != typeof(string);
				float num = 0f;
				if (!flag6)
				{
					obj14 = (nint)skeletonData + 112;
					skeletonData.Version = text7;
					if ((object)text7.GetType() == typeof(string))
					{
						goto IL_3e12;
					}
					num = 0f;
				}
				goto IL_36f3;
			}
			obj14 = (nint)skeletonData + 112;
			skeletonData.Version = null;
			goto IL_3e12;
			IL_36e5:
			InvalidCastException ex15 = new InvalidCastException();
			goto IL_36f3;
			IL_37e0:
			InvalidCastException ex16 = new InvalidCastException();
			goto IL_37ee;
			IL_3545:
			InvalidCastException ex17 = new InvalidCastException();
			NullReferenceException ex18 = new NullReferenceException();
			NullReferenceException ex19 = new NullReferenceException();
			NullReferenceException ex20 = new NullReferenceException();
			throw new NullReferenceException();
			IL_3e12:
			if (!("3.8.75" == (string)obj14))
			{
				float x = GetFloat(dictionary2, "x", 0f);
				skeletonData.X = x;
				float y = GetFloat(dictionary2, "y", 0f);
				skeletonData.Y = y;
				float width = GetFloat(dictionary2, "width", 0f);
				skeletonData.Width = width;
				float height = GetFloat(dictionary2, "height", 0f);
				skeletonData.Height = height;
				float num = GetFloat(dictionary2, "fps", 30f);
				skeletonData.Fps = num;
				string imagesPath = GetString(dictionary2, "images", null);
				skeletonData.ImagesPath = imagesPath;
				string audioPath = GetString(dictionary2, "audio", null);
				skeletonData.AudioPath = audioPath;
				obj2 = obj;
				goto IL_3d9d;
			}
			Exception ex21 = new Exception();
			text2 = "Unsupported skeleton data, please export with a newer version of Spine.";
			ex2 = ex21;
			goto IL_3912;
			IL_36f9:
			InvalidCastException ex22 = new InvalidCastException();
			NullReferenceException ex23 = new NullReferenceException();
			NullReferenceException ex24 = new NullReferenceException();
			goto IL_3723;
			IL_3912:
			throw new OutOfMemoryException();
			IL_382c:
			InvalidCastException ex25 = new InvalidCastException();
			NullReferenceException ex26 = new NullReferenceException();
			NullReferenceException ex27 = new NullReferenceException();
			throw new NullReferenceException();
			IL_3d9d:
			bool flag7 = ((Dictionary<object, object>)obj2).ContainsKey((object)"bones");
			bool flag8 = !flag7;
			Dictionary<object, object>.Enumerator enumerator11 = default(Dictionary<object, object>.Enumerator);
			skeletonJson = this;
			skeletonData2 = skeletonData;
			string text14 = default(string);
			nint num8 = default(nint);
			BoneData boneData5 = default(BoneData);
			if (!flag8)
			{
				object obj15 = ((Dictionary<object, object>)obj2)[(object)"bones"];
				List<object> list4 = obj15 as List<object>;
				if (list4 == null)
				{
					goto IL_36f3;
				}
				object enumerator12 = ((List<object>)obj15).GetEnumerator();
				object obj16 = enumerator2;
				Dictionary<string, object> dictionary10 = dictionary4;
				float num = num2;
				string text12 = default(string);
				object obj20 = default(object);
				while (enumerator.MoveNext())
				{
					enumerator11 = default(Dictionary<object, object>.Enumerator);
					string text8 = "parent";
					skeletonJson = this;
					skeletonData2 = skeletonData;
					Dictionary<string, object> dictionary11 = dictionary4 as Dictionary<string, object>;
					bool flag9 = dictionary11 == null;
					enumerator11 = default(Dictionary<object, object>.Enumerator);
					text8 = "parent";
					skeletonJson = this;
					skeletonData2 = skeletonData;
					if (!flag9)
					{
						BoneData parent;
						if (dictionary4.ContainsKey("parent"))
						{
							string text9 = (string)dictionary4["parent"];
							if (text9 != null && (object)text9.GetType() != typeof(string))
							{
								throw new InvalidCastException();
							}
							BoneData boneData3 = skeletonData.FindBone(text9);
							bool flag10 = boneData3 == null;
							bool flag11 = !flag10;
							parent = boneData3;
							if (!flag11)
							{
								object obj17 = dictionary4["parent"];
								string text10;
								string text11;
								if (obj17 == null)
								{
									text10 = "Parent bone not found: ";
									text11 = null;
								}
								else
								{
									object obj18 = obj17;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4240 @ X8_v666+168] (should have been resolved before IL gen)");
									text10 = "Parent bone not found: ";
									text11 = text12;
								}
								string message5 = text10 + text11;
								Exception ex28 = new Exception(message5);
								throw ex28;
							}
						}
						else
						{
							parent = null;
						}
						ExposedList<BoneData> bones = skeletonData.Bones;
						string text13 = (string)dictionary4["name"];
						BoneData boneData4 = new BoneData(bones.Count, text13, parent);
						if (text13 == null || (object)text13.GetType() == typeof(string))
						{
							float num5 = GetFloat(dictionary4, "length", 0f);
							float length = Scale * num5;
							boneData4.Length = length;
							float num6 = GetFloat(dictionary4, "x", 0f);
							float x2 = Scale * num6;
							boneData4.X = x2;
							float num7 = GetFloat(dictionary4, "y", 0f);
							float y2 = Scale * num7;
							boneData4.Y = y2;
							float rotation = GetFloat(dictionary4, "rotation", 0f);
							boneData4.Rotation = rotation;
							float scaleX = GetFloat(dictionary4, "scaleX", 1f);
							boneData4.ScaleX = scaleX;
							float scaleY = GetFloat(dictionary4, "scaleY", 1f);
							boneData4.ScaleY = scaleY;
							float shearX = GetFloat(dictionary4, "shearX", 0f);
							boneData4.ShearX = shearX;
							num = GetFloat(dictionary4, "shearY", 0f);
							boneData4.ShearY = num;
							string defaultValue = ((Enum)num2).ToString();
							string value = GetString(dictionary4, "transform", defaultValue);
							Type typeFromHandle = typeof(TransformMode);
							object obj19 = Enum.Parse(typeFromHandle, value, ignoreCase: true);
							if ((int)((obj19 is TransformMode) ? obj19 : null) != 0)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								boneData4.TransformMode = (TransformMode)obj20;
								bool boolean = GetBoolean(dictionary4, "skin", defaultValue: false);
								boneData4.skinRequired = boolean;
								skeletonData.Bones.Add(boneData4);
								dictionary10 = null;
								text14 = null;
								boneData5 = null;
								obj2 = boneData4;
								continue;
							}
							throw new InvalidCastException();
						}
						goto IL_36e5;
					}
					throw new InvalidCastException();
				}
				enumerator.Dispose();
				enumerator11 = default(Dictionary<object, object>.Enumerator);
				dictionary4 = dictionary10;
				num8 = (nint)typeof(TransformMode);
				obj2 = obj;
				skeletonJson = this;
				skeletonData2 = skeletonData;
			}
			if (((Dictionary<object, object>)obj2).ContainsKey((object)"slots"))
			{
				object obj21 = ((Dictionary<object, object>)obj2)[(object)"slots"];
				List<object> list5 = obj21 as List<object>;
				if (list5 == null)
				{
					goto IL_36f3;
				}
				object enumerator13 = ((List<object>)obj21).GetEnumerator();
				object obj22 = enumerator2;
				float num = num2;
				SlotData slotData;
				BlendMode blendMode2;
				object obj24 = default(object);
				for (; enumerator.MoveNext(); slotData.BlendMode = blendMode2, skeletonData2.Slots.Add(slotData), obj2 = slotData)
				{
					Dictionary<string, object> dictionary12 = dictionary4 as Dictionary<string, object>;
					if (dictionary12 != null)
					{
						string text15 = (string)dictionary4["name"];
						if (text15 == null || (object)text15.GetType() == typeof(string))
						{
							string text16 = (string)dictionary4["bone"];
							if (text16 == null || (object)text16.GetType() == typeof(string))
							{
								BoneData boneData6 = skeletonData2.FindBone(text16);
								if (boneData6 != null)
								{
									ExposedList<SlotData> slots = skeletonData2.Slots;
									slotData = new SlotData(slots.Count, text15, boneData6);
									if (dictionary4.ContainsKey("color"))
									{
										string text17 = (string)dictionary4["color"];
										if (text17 != null && (object)text17.GetType() != typeof(string))
										{
											throw new InvalidCastException();
										}
										float r = ToColor(text17, 0);
										slotData.R = r;
										float g = ToColor(text17, 1);
										slotData.G = g;
										float b = ToColor(text17, 2);
										slotData.B = b;
										num = ToColor(text17, 3);
										slotData.A = num;
									}
									if (dictionary4.ContainsKey("dark"))
									{
										string text18 = (string)dictionary4["dark"];
										if (text18 != null && (object)text18.GetType() != typeof(string))
										{
											throw new InvalidCastException();
										}
										float r2 = ToColor(text18, 0, 6);
										slotData.R2 = r2;
										float g2 = ToColor(text18, 1, 6);
										slotData.G2 = g2;
										num = ToColor(text18, 2, 6);
										slotData.B2 = num;
										slotData.hasSecondColor = true;
									}
									string attachmentName = GetString(dictionary4, "attachment", null);
									slotData.AttachmentName = attachmentName;
									if (dictionary4.ContainsKey("blend"))
									{
										Type typeFromHandle2 = typeof(BlendMode);
										string text19 = (string)dictionary4["blend"];
										if (text19 == null || (object)text19.GetType() == typeof(string))
										{
											object obj23 = Enum.Parse(typeFromHandle2, text19, ignoreCase: true);
											BlendMode blendMode = (BlendMode)((obj23 is BlendMode) ? obj23 : null);
											bool flag12 = blendMode == BlendMode.Normal;
											boneData5 = null;
											if (!flag12)
											{
												Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
												blendMode2 = (BlendMode)obj24;
												boneData5 = null;
												continue;
											}
											goto IL_3723;
										}
										throw new InvalidCastException();
									}
									boneData5 = boneData6;
									blendMode2 = default(BlendMode);
									continue;
								}
								string message6 = "Slot bone not found: " + text16;
								Exception ex29 = new Exception(message6);
								throw ex29;
							}
							throw new InvalidCastException();
						}
						throw new InvalidCastException();
					}
					throw new InvalidCastException();
				}
				enumerator.Dispose();
				num8 = unchecked((nint)"blend");
				obj2 = obj;
			}
			bool flag13 = ((Dictionary<object, object>)obj2).ContainsKey((object)"ik");
			bool flag14 = !flag13;
			Skin skin2 = (Skin)num8;
			object obj25 = obj2;
			IkConstraintData ikConstraintData2;
			if (!flag14)
			{
				object obj26 = ((Dictionary<object, object>)obj2)[(object)"ik"];
				List<object> list6 = obj26 as List<object>;
				if (list6 == null)
				{
					goto IL_36f3;
				}
				object enumerator14 = ((List<object>)obj26).GetEnumerator();
				object obj27 = enumerator2;
				string text20 = (string)num8;
				string text8 = "name";
				float num = num2;
				while (enumerator.MoveNext())
				{
					Dictionary<string, object> dictionary10 = dictionary4;
					nint num9 = 0;
					Dictionary<string, object> dictionary13 = dictionary4 as Dictionary<string, object>;
					bool flag15 = dictionary13 == null;
					dictionary10 = dictionary4;
					num9 = 0;
					if (!flag15)
					{
						string text21 = (string)dictionary4[text8];
						ikConstraintData2 = new IkConstraintData(text21);
						if (text21 == null || (object)text21.GetType() == typeof(string))
						{
							int order = GetInt(dictionary4, "order", 0);
							ikConstraintData2.Order = order;
							bool boolean2 = GetBoolean(dictionary4, "skin", defaultValue: false);
							ikConstraintData2.skinRequired = boolean2;
							if (dictionary4.ContainsKey("bones"))
							{
								goto IL_0f42;
							}
							string text22 = (string)dictionary4["target"];
							if (text22 != null && (object)text22.GetType() != typeof(string))
							{
								throw new InvalidCastException();
							}
							BoneData boneData7 = (ikConstraintData2.Target = skeletonData2.FindBone(text22));
							if (boneData7 != null)
							{
								float mix = GetFloat(dictionary4, "mix", 1f);
								ikConstraintData2.Mix = mix;
								float num10 = GetFloat(dictionary4, "softness", 0f);
								num = Scale * num10;
								ikConstraintData2.Softness = num;
								int bendDirection = (GetBoolean(dictionary4, "bendPositive", defaultValue: true) ? 1 : (-1));
								ikConstraintData2.BendDirection = bendDirection;
								bool boolean3 = GetBoolean(dictionary4, "compress", defaultValue: false);
								ikConstraintData2.compress = boolean3;
								bool boolean4 = GetBoolean(dictionary4, "stretch", defaultValue: false);
								ikConstraintData2.stretch = boolean4;
								bool boolean5 = GetBoolean(dictionary4, "uniform", defaultValue: false);
								ikConstraintData2.uniform = boolean5;
								skeletonData2.IkConstraints.Add(ikConstraintData2);
								text20 = text22;
								continue;
							}
							string message7 = "IK target bone not found: " + text22;
							Exception ex30 = new Exception(message7);
							throw ex30;
						}
						goto IL_36f9;
					}
					throw new InvalidCastException();
				}
				enumerator.Dispose();
				skin2 = (Skin)(object)text20;
				obj25 = obj;
			}
			TransformConstraintData transformConstraintData;
			object obj33 = default(object);
			object obj35 = default(object);
			object obj37 = default(object);
			Dictionary<object, object>.Enumerator enumerator19 = default(Dictionary<object, object>.Enumerator);
			Dictionary<object, object>.Enumerator enumerator21 = default(Dictionary<object, object>.Enumerator);
			SkeletonData skeletonData4 = default(SkeletonData);
			Dictionary<object, object>.Enumerator enumerator24 = default(Dictionary<object, object>.Enumerator);
			Dictionary<string, object> dictionary19 = default(Dictionary<string, object>);
			InvalidCastException ex40 = default(InvalidCastException);
			SkeletonData result = default(SkeletonData);
			object obj44 = default(object);
			while (true)
			{
				string text8;
				Dictionary<string, object> dictionary10;
				float num;
				if (((Dictionary<object, object>)obj25).ContainsKey((object)"transform"))
				{
					object obj28 = ((Dictionary<object, object>)obj25)[(object)"transform"];
					List<object> list7 = obj28 as List<object>;
					if (list7 == null)
					{
						break;
					}
					object enumerator15 = ((List<object>)obj28).GetEnumerator();
					object obj29 = enumerator2;
					text8 = "name";
					num = num2;
					while (enumerator.MoveNext())
					{
						dictionary10 = dictionary4;
						nint num9 = 0;
						Dictionary<string, object> dictionary14 = dictionary4 as Dictionary<string, object>;
						bool flag16 = dictionary14 == null;
						dictionary10 = dictionary4;
						num9 = 0;
						if (!flag16)
						{
							string text23 = (string)dictionary4[text8];
							transformConstraintData = new TransformConstraintData(text23);
							if (text23 == null || (object)text23.GetType() == typeof(string))
							{
								int order2 = GetInt(dictionary4, "order", 0);
								transformConstraintData.Order = order2;
								bool boolean6 = GetBoolean(dictionary4, "skin", defaultValue: false);
								transformConstraintData.skinRequired = boolean6;
								if (dictionary4.ContainsKey("bones"))
								{
									goto IL_142c;
								}
								string text24 = (string)dictionary4["target"];
								if (text24 != null && (object)text24.GetType() != typeof(string))
								{
									throw new InvalidCastException();
								}
								BoneData boneData9 = (transformConstraintData.Target = skeletonData2.FindBone(text24));
								if (boneData9 != null)
								{
									bool boolean7 = GetBoolean(dictionary4, "local", defaultValue: false);
									transformConstraintData.local = boolean7;
									bool boolean8 = GetBoolean(dictionary4, "relative", defaultValue: false);
									transformConstraintData.relative = boolean8;
									float offsetRotation = GetFloat(dictionary4, "rotation", 0f);
									transformConstraintData.OffsetRotation = offsetRotation;
									float num11 = GetFloat(dictionary4, "x", 0f);
									float offsetX = Scale * num11;
									transformConstraintData.OffsetX = offsetX;
									float num12 = GetFloat(dictionary4, "y", 0f);
									float offsetY = Scale * num12;
									transformConstraintData.OffsetY = offsetY;
									float offsetScaleX = GetFloat(dictionary4, "scaleX", 0f);
									transformConstraintData.OffsetScaleX = offsetScaleX;
									float offsetScaleY = GetFloat(dictionary4, "scaleY", 0f);
									transformConstraintData.OffsetScaleY = offsetScaleY;
									float offsetShearY = GetFloat(dictionary4, "shearY", 0f);
									transformConstraintData.OffsetShearY = offsetShearY;
									float rotateMix = GetFloat(dictionary4, "rotateMix", 1f);
									transformConstraintData.RotateMix = rotateMix;
									float translateMix = GetFloat(dictionary4, "translateMix", 1f);
									transformConstraintData.TranslateMix = translateMix;
									float scaleMix = GetFloat(dictionary4, "scaleMix", 1f);
									transformConstraintData.ScaleMix = scaleMix;
									num = GetFloat(dictionary4, "shearMix", 1f);
									transformConstraintData.ShearMix = num;
									skeletonData2.TransformConstraints.Add(transformConstraintData);
									skin2 = (Skin)(object)text24;
									continue;
								}
								string message8 = "Transform constraint target bone not found: " + text24;
								Exception ex31 = new Exception(message8);
								throw ex31;
							}
							throw new InvalidCastException();
						}
						goto IL_3440;
					}
					enumerator.Dispose();
					obj25 = obj;
				}
				bool flag17 = ((Dictionary<object, object>)obj25).ContainsKey((object)"path");
				bool flag18 = !flag17;
				text3 = (string)(object)dictionary4;
				nint num13;
				if (!flag18)
				{
					object obj30 = ((Dictionary<object, object>)obj25)[(object)"path"];
					List<object> list8 = obj30 as List<object>;
					if (list8 == null)
					{
						break;
					}
					object enumerator16 = ((List<object>)obj30).GetEnumerator();
					object obj31 = enumerator2;
					num = num2;
					while (enumerator.MoveNext())
					{
						num13 = (nint)typeof(Dictionary<string, object>);
						Dictionary<string, object> dictionary15 = dictionary4 as Dictionary<string, object>;
						bool flag19 = dictionary15 == null;
						num13 = (nint)typeof(Dictionary<string, object>);
						if (!flag19)
						{
							string text25 = (string)dictionary4["name"];
							pathConstraintData = new PathConstraintData(text25);
							if (text25 == null || (object)text25.GetType() == typeof(string))
							{
								int order3 = GetInt(dictionary4, "order", 0);
								pathConstraintData.Order = order3;
								bool boolean9 = GetBoolean(dictionary4, "skin", defaultValue: false);
								pathConstraintData.skinRequired = boolean9;
								if (dictionary4.ContainsKey("bones"))
								{
									goto IL_1a32;
								}
								string text26 = (string)dictionary4["target"];
								if (text26 == null || (object)text26.GetType() == typeof(string))
								{
									SlotData slotData2 = (pathConstraintData.Target = skeletonData2.FindSlot(text26));
									if (slotData2 != null)
									{
										Type typeFromHandle3 = typeof(PositionMode);
										string value2 = GetString(dictionary4, "positionMode", "percent");
										object obj32 = Enum.Parse(typeFromHandle3, value2, ignoreCase: true);
										PositionMode positionMode = (PositionMode)((obj32 is PositionMode) ? obj32 : null);
										bool flag20 = positionMode == PositionMode.Fixed;
										boneData5 = null;
										if (!flag20)
										{
											Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
											pathConstraintData.PositionMode = (PositionMode)obj33;
											Type typeFromHandle4 = typeof(SpacingMode);
											string value3 = GetString(dictionary4, "spacingMode", "length");
											object obj34 = Enum.Parse(typeFromHandle4, value3, ignoreCase: true);
											SpacingMode spacingMode = (SpacingMode)((obj34 is SpacingMode) ? obj34 : null);
											bool flag21 = spacingMode == SpacingMode.Length;
											boneData5 = null;
											if (!flag21)
											{
												Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
												pathConstraintData.SpacingMode = (SpacingMode)obj35;
												Type typeFromHandle5 = typeof(RotateMode);
												string value4 = GetString(dictionary4, "rotateMode", "tangent");
												object obj36 = Enum.Parse(typeFromHandle5, value4, ignoreCase: true);
												if ((int)((obj36 is RotateMode) ? obj36 : null) != 0)
												{
													Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
													pathConstraintData.RotateMode = (RotateMode)obj37;
													float offsetRotation2 = GetFloat(dictionary4, "rotation", 0f);
													pathConstraintData.OffsetRotation = offsetRotation2;
													float num14 = (pathConstraintData.Position = GetFloat(dictionary4, "position", 0f));
													if (pathConstraintData.PositionMode == PositionMode.Fixed)
													{
														float position = Scale * num14;
														pathConstraintData.Position = position;
													}
													float num16 = (pathConstraintData.Spacing = GetFloat(dictionary4, "spacing", 0f));
													if (pathConstraintData.SpacingMode < SpacingMode.Percent)
													{
														float spacing = Scale * num16;
														pathConstraintData.Spacing = spacing;
													}
													float rotateMix2 = GetFloat(dictionary4, "rotateMix", 1f);
													pathConstraintData.RotateMix = rotateMix2;
													num = GetFloat(dictionary4, "translateMix", 1f);
													pathConstraintData.TranslateMix = num;
													skeletonData2.PathConstraints.Add(pathConstraintData);
													boneData5 = null;
													skin2 = (Skin)(object)typeFromHandle5;
													continue;
												}
												goto IL_3661;
											}
										}
										else
										{
											InvalidCastException ex32 = new InvalidCastException();
										}
										throw new InvalidCastException();
									}
									string message9 = "Path target slot not found: " + text26;
									Exception ex33 = new Exception(message9);
									throw ex33;
								}
								throw new InvalidCastException();
							}
							throw new InvalidCastException();
						}
						goto IL_34b9;
					}
					enumerator.Dispose();
					text3 = (string)(object)dictionary4;
					obj25 = obj;
				}
				Dictionary<object, object>.Enumerator enumerator18;
				Attachment attachment;
				nint num18;
				int num19;
				SkeletonData skeletonData3;
				string text30;
				string text31;
				BoneData boneData11;
				Dictionary<object, object>.Enumerator enumerator22;
				string text28;
				if (((Dictionary<object, object>)obj25).ContainsKey((object)"skins"))
				{
					object obj38 = ((Dictionary<object, object>)obj)[(object)"skins"];
					List<object> list9 = obj38 as List<object>;
					if (list9 == null)
					{
						break;
					}
					object enumerator17 = ((List<object>)obj38).GetEnumerator();
					object obj39 = enumerator2;
					enumerator18 = enumerator19;
					while (enumerator.MoveNext())
					{
						Dictionary<string, object> dictionary16 = text3 as Dictionary<string, object>;
						if (dictionary16 != null)
						{
							string text27 = (string)((Dictionary<object, object>)(object)text3)[(object)"name"];
							skin = new Skin(text27);
							if (text27 == null || (object)text27.GetType() == typeof(string))
							{
								if (((Dictionary<object, object>)(object)text3).ContainsKey((object)"bones"))
								{
									goto IL_205c;
								}
								if (((Dictionary<object, object>)(object)text3).ContainsKey((object)"ik"))
								{
									goto IL_2229;
								}
								if (((Dictionary<object, object>)(object)text3).ContainsKey((object)"transform"))
								{
									goto IL_23f6;
								}
								if (((Dictionary<object, object>)(object)text3).ContainsKey((object)"path"))
								{
									goto IL_25c3;
								}
								if (((Dictionary<object, object>)(object)text3).ContainsKey((object)"attachments"))
								{
									object obj40 = ((Dictionary<object, object>)(object)text3)[(object)"attachments"];
									Dictionary<string, object> dictionary17 = obj40 as Dictionary<string, object>;
									if (dictionary17 == null)
									{
										goto IL_382c;
									}
									object enumerator20 = ((Dictionary<object, object>)obj40).GetEnumerator();
									text28 = text3;
									attachment = (Attachment)(object)boneData5;
									enumerator18 = enumerator21;
									num18 = 0;
									if (enumerator21.MoveNext())
									{
										goto IL_2806;
									}
									string text29 = null;
									num19 = 98;
									enumerator21.Dispose();
									if (text29 != null)
									{
										throw new OutOfMemoryException();
									}
									bool flag22 = num19 == 98;
									enumerator11 = enumerator21;
									boneData5 = (BoneData)(object)attachment;
									if (!flag22)
									{
										bool flag23 = num19 == 0;
										bool flag24 = !flag23;
										enumerator11 = enumerator21;
										boneData5 = (BoneData)(object)attachment;
										skeletonData3 = skeletonData4;
										enumerator11 = enumerator21;
										text30 = text28;
										text31 = text14;
										boneData11 = (BoneData)(object)attachment;
										enumerator22 = enumerator18;
										if (flag24)
										{
											goto IL_2d32;
										}
									}
								}
								skeletonData2.Skins.Add(skin);
								if (skin.Name == "default")
								{
									skeletonData2.DefaultSkin = skin;
								}
								continue;
							}
							throw new InvalidCastException();
						}
						goto IL_3629;
					}
					enumerator.Dispose();
					num = (float)enumerator18;
				}
				goto IL_2de3;
				IL_3d2e:
				OutOfMemoryException ex34 = new OutOfMemoryException();
				enumerator.Dispose();
				InvalidCastException ex35 = (InvalidCastException)(object)ex34;
				goto IL_3d50;
				IL_2806:
				Dictionary<string, object> dictionary21;
				InvalidCastException ex39;
				if (skeletonData2 != null)
				{
					int slotIndex = skeletonData2.FindSlotIndex(text3);
					nint num20;
					string text32;
					if (dictionary6 != null)
					{
						Dictionary<string, object> dictionary18 = dictionary6 as Dictionary<string, object>;
						if (dictionary18 != null)
						{
							object enumerator23 = dictionary6.GetEnumerator();
							Skin skin3 = (Skin)num18;
							while (enumerator24.MoveNext())
							{
								if (dictionary19 != null)
								{
									Dictionary<string, object> dictionary20 = dictionary19 as Dictionary<string, object>;
									if (dictionary20 == null)
									{
										throw new InvalidCastException();
									}
								}
								Attachment attachment2 = skeletonJson.ReadAttachment(dictionary19, skin, slotIndex, text3, skeletonData2);
								bool flag25 = attachment2 == null;
								skeletonData4 = skeletonData2;
								text14 = text3;
								attachment = attachment2;
								skin3 = skin;
								if (!flag25)
								{
									if (skin == null)
									{
										throw new NullReferenceException();
									}
									skin.SetAttachment(slotIndex, text3, attachment2);
									skeletonData4 = skeletonData2;
									text14 = text3;
									attachment = attachment2;
									skin3 = (Skin)(object)text3;
								}
							}
							enumerator24.Dispose();
							OutOfMemoryException ex36 = new OutOfMemoryException();
							enumerator11 = enumerator21;
							text28 = text3;
							dictionary21 = null;
							num = (float)enumerator24;
							num20 = (nint)typeof(string);
							text32 = (string)0;
							NullReferenceException ex37 = (NullReferenceException)(object)ex36;
						}
						else
						{
							InvalidCastException ex38 = new InvalidCastException();
							enumerator11 = enumerator21;
							dictionary21 = dictionary6;
							num = (float)enumerator18;
							Skin skin3 = (Skin)num18;
							num20 = (nint)typeof(string);
							text32 = (string)(object)typeof(Dictionary<string, object>);
							NullReferenceException ex37 = (NullReferenceException)(object)ex38;
						}
					}
					else
					{
						NullReferenceException ex37 = new NullReferenceException();
						enumerator11 = enumerator21;
						dictionary21 = dictionary6;
						num = (float)enumerator18;
						Skin skin3 = (Skin)num18;
						num20 = (nint)typeof(string);
						text32 = text3;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
					dictionary10 = (Dictionary<string, object>)(object)text3;
					boneData5 = (BoneData)(object)attachment;
					text8 = text32;
					nint num9 = num20;
					ex39 = ex40;
					goto IL_4570;
				}
				throw new NullReferenceException();
				IL_3d41:
				((List<object>.Enumerator*)ex35)->Dispose();
				goto IL_3d50;
				IL_3440:
				InvalidCastException ex41 = new InvalidCastException();
				dictionary21 = null;
				ex39 = ex41;
				goto IL_4570;
				IL_3d50:
				OutOfMemoryException ex42 = new OutOfMemoryException();
				((List<object>.Enumerator*)ex42)->Dispose();
				return result;
				IL_4570:
				enumerator11.Dispose();
				bool flag26 = dictionary21 == null;
				string text33 = text8;
				InvalidCastException ex43 = ex39;
				if (!flag26)
				{
					throw new OutOfMemoryException();
				}
				goto IL_39b1;
				IL_39b1:
				if ((nint)text33 == 1)
				{
					object obj41 = ((Dictionary<string, object>)(object)ex43)[text33];
					object obj42 = ((Dictionary<string, object>)obj41)[text33];
					enumerator.Dispose();
					bool flag27 = obj41 == null;
					text3 = (string)(object)dictionary10;
					if (flag27)
					{
						goto IL_2de3;
					}
					goto IL_3d2e;
				}
				enumerator.Dispose();
				ex35 = ex43;
				goto IL_3d41;
				IL_2de3:
				List<LinkedMesh> list10 = skeletonJson.linkedMeshes;
				int num21 = ~list10.Count;
				int num22 = list10.Count & num21;
				Skin skin4 = null;
				int num23 = 0;
				while (true)
				{
					bool flag28 = num22 == num23;
					NullReferenceException ex44 = (NullReferenceException)(object)list10;
					if (!flag28)
					{
						LinkedMesh linkedMesh = list10[num23];
						if (linkedMesh.skin != null)
						{
							Skin skin5 = skeletonData2.FindSkin(linkedMesh.skin);
							skin2 = skin5;
						}
						else
						{
							skin2 = skeletonData2.DefaultSkin;
						}
						Skin skin6 = ((skin2 != null) ? skin2 : skin4);
						bool flag29 = skin2 == null;
						nint num9 = (nint)linkedMesh;
						string text34;
						string text35;
						if (!flag29)
						{
							Attachment attachment3 = skin6.GetAttachment(linkedMesh.slotIndex, linkedMesh.parent);
							if (attachment3 != null)
							{
								MeshAttachment mesh = linkedMesh.mesh;
								bool flag30 = !linkedMesh.inheritDeform;
								MeshAttachment deformAttachment = linkedMesh.mesh;
								if (!flag30)
								{
									VertexAttachment vertexAttachment = attachment3 as VertexAttachment;
									if (vertexAttachment == null)
									{
										break;
									}
									deformAttachment = (MeshAttachment)attachment3;
								}
								mesh.DeformAttachment = deformAttachment;
								MeshAttachment meshAttachment = attachment3 as MeshAttachment;
								if (meshAttachment == null)
								{
									break;
								}
								linkedMesh.mesh.ParentMesh = (MeshAttachment)attachment3;
								linkedMesh.mesh.UpdateUVs();
								list10 = skeletonJson.linkedMeshes;
								num23++;
								bool flag31 = skeletonJson.linkedMeshes == null;
								bool flag32 = !flag31;
								skin4 = skin2;
								if (flag32)
								{
									continue;
								}
								ex44 = new NullReferenceException();
								boneData5 = boneData5;
								goto IL_3026;
							}
							text34 = linkedMesh.parent;
							text35 = "Parent mesh not found: ";
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5971 @ X23_v9 (Il2CppMethodInfo)+18]");
							text34 = (string)0;
							text35 = "Slot not found: ";
						}
						string message10 = text35 + text34;
						Exception ex45 = new Exception(message10);
						num13 = 0;
						throw ex45;
					}
					goto IL_3026;
					IL_3026:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ X0_v941 (System.NullReferenceException)+1C]");
					object obj43 = (nint)0 + (nint)1;
					((Exception)ex44)._message = null;
					if ((nint)((Exception)ex44)._message >= 1)
					{
						Array.Clear((Array)(object)((Exception)ex44)._className, 0, (int)((Exception)ex44)._message);
						boneData5 = null;
					}
					goto IL_3093;
				}
				InvalidCastException ex46 = new InvalidCastException();
				enumerator2.Dispose();
				Type type = (Type)(object)ex46;
				obj25 = obj;
				if ((nint)skin2 == 1)
				{
					((List<object>.Enumerator*)type)->Dispose();
					((List<object>.Enumerator*)obj44)->Dispose();
					enumerator.Dispose();
					bool flag33 = obj44 == null;
					dictionary4 = (Dictionary<string, object>)(object)text3;
					if (flag33)
					{
						continue;
					}
					goto IL_3d2e;
				}
				enumerator.Dispose();
				ex35 = (InvalidCastException)(object)type;
				goto IL_3d41;
				IL_3661:
				InvalidCastException ex47 = new InvalidCastException();
				NullReferenceException ex48 = new NullReferenceException();
				NullReferenceException ex49 = new NullReferenceException();
				throw new NullReferenceException();
				IL_1a32:
				obj3 = dictionary4["bones"];
				List<object> list11 = obj3 as List<object>;
				if (list11 != null)
				{
					goto IL_1a78;
				}
				goto IL_3653;
				IL_34b9:
				ex43 = new InvalidCastException();
				enumerator2.Dispose();
				dictionary10 = dictionary4;
				text33 = (string)num13;
				goto IL_39b1;
				IL_3629:
				InvalidCastException ex50 = new InvalidCastException();
				NullReferenceException ex51 = new NullReferenceException();
				NullReferenceException ex52 = new NullReferenceException();
				goto IL_3653;
				IL_3653:
				InvalidCastException ex53 = new InvalidCastException();
				goto IL_3661;
				IL_2d32:
				enumerator.Dispose();
				bool flag34 = num19 == 71;
				skeletonData4 = skeletonData3;
				text28 = text30;
				text14 = text31;
				boneData5 = boneData11;
				num = (float)enumerator22;
				if (!flag34)
				{
					bool flag35 = num19 == 0;
					skeletonData4 = skeletonData3;
					text28 = text30;
					text14 = text31;
					boneData5 = boneData11;
					num = (float)enumerator22;
					if (!flag35)
					{
						goto IL_33f8;
					}
				}
				goto IL_2de3;
			}
			goto IL_36f3;
			IL_0f42:
			object obj45 = dictionary4["bones"];
			List<object> list12 = obj45 as List<object>;
			if (list12 != null)
			{
				object enumerator25 = ((List<object>)obj45).GetEnumerator();
				object obj46 = enumerator2;
				obj46 = num2;
				while (enumerator2.MoveNext())
				{
					if (dictionary4 == null || (object)dictionary4.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							BoneData boneData12 = skeletonData2.FindBone((string)(object)dictionary4);
							if (boneData12 != null)
							{
								if (ikConstraintData2.Bones != null)
								{
									ikConstraintData2.Bones.Add(boneData12);
									continue;
								}
								throw new NullReferenceException();
							}
							string message11 = "IK bone not found: " + (string)(object)dictionary4;
							Exception ex54 = new Exception(message11);
							throw ex54;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				OutOfMemoryException ex55 = new OutOfMemoryException();
				throw new NullReferenceException();
			}
			goto IL_3545;
			IL_142c:
			object obj47 = dictionary4["bones"];
			List<object> list13 = obj47 as List<object>;
			if (list13 != null)
			{
				object enumerator26 = ((List<object>)obj47).GetEnumerator();
				object obj48 = enumerator2;
				obj48 = num2;
				while (enumerator2.MoveNext())
				{
					if (dictionary4 == null || (object)dictionary4.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							BoneData boneData13 = skeletonData2.FindBone((string)(object)dictionary4);
							if (boneData13 != null)
							{
								if (transformConstraintData.Bones != null)
								{
									transformConstraintData.Bones.Add(boneData13);
									continue;
								}
								throw new NullReferenceException();
							}
							string message12 = "Transform constraint bone not found: " + (string)(object)dictionary4;
							Exception ex56 = new Exception(message12);
							throw ex56;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				OutOfMemoryException ex57 = new OutOfMemoryException();
				NullReferenceException ex58 = new NullReferenceException();
				NullReferenceException ex59 = new NullReferenceException();
				goto IL_37e0;
			}
			InvalidCastException ex60 = new InvalidCastException();
			NullReferenceException ex61 = new NullReferenceException();
			NullReferenceException ex62 = new NullReferenceException();
			NullReferenceException ex63 = new NullReferenceException();
			throw new NullReferenceException();
			IL_23f6:
			object obj49 = ((Dictionary<object, object>)(object)text3)[(object)"transform"];
			List<object> list14 = obj49 as List<object>;
			if (list14 != null)
			{
				object enumerator27 = ((List<object>)obj49).GetEnumerator();
				object obj50 = enumerator2;
				obj50 = num2;
				while (enumerator2.MoveNext())
				{
					if (text3 == null || (object)text3.GetType() == typeof(string))
					{
						if (skeletonData2 != null)
						{
							TransformConstraintData transformConstraintData2 = skeletonData2.FindTransformConstraint(text3);
							if (transformConstraintData2 != null)
							{
								if (skin != null)
								{
									if (skin.Constraints != null)
									{
										skin.Constraints.Add(transformConstraintData2);
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							string message13 = "Skin transform constraint not found: " + text3;
							Exception ex64 = new Exception(message13);
							throw ex64;
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator2.Dispose();
				OutOfMemoryException ex65 = new OutOfMemoryException();
				NullReferenceException ex66 = new NullReferenceException();
				throw new NullReferenceException();
			}
			goto IL_37fc;
			IL_3723:
			InvalidCastException ex67 = new InvalidCastException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x60003DC")]
		[Address(RVA = "0x1546700", Offset = "0x1546700", Length = "0xC1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0093;\n\tv56 = Spine.AttachmentLoader;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv80 = Spine.AttachmentType;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv88 = Spine.AttachmentType;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv97 = Il2CppMethodInfo;\n\tv98 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv106 = Il2CppMethodInfo;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv114 = System.Enum;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv125 = Spine.SkeletonJson+LinkedMesh;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv149 = System.String;\n\tv150 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv178 = System.Type;\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv188 = \"x\";\n\tv189 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv205 = \"deform\";\n\tv206 = \"il2cpp_codegen_initialize_runtime_metadata\"(v205, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv219 = \"parent\";\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv277 = \"skin\";\n\tv278 = \"il2cpp_codegen_initialize_runtime_metadata\"(v277, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv281 = \"rotation\";\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv285 = \"scaleX\";\n\tv286 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv291 = \"height\";\n\tv292 = \"il2cpp_codegen_initialize_runtime_metadata\"(v291, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv296 = \"hull\";\n\tv297 = \"il2cpp_codegen_initialize_runtime_metadata\"(v296, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv300 = \"triangles\";\n\tv301 = \"il2cpp_codegen_initialize_runtime_metadata\"(v300, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv303 = \"lengths\";\n\tv304 = \"il2cpp_codegen_initialize_runtime_metadata\"(v303, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv306 = \"constantSpeed\";\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv309 = \"region\";\n\tv310 = \"il2cpp_codegen_initialize_runtime_metadata\"(v309, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv312 = \"y\";\n\tv313 = \"il2cpp_codegen_initialize_runtime_metadata\"(v312, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv315 = \"end\";\n\tv316 = \"il2cpp_codegen_initialize_runtime_metadata\"(v315, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv318 = \"closed\";\n\tv319 = \"il2cpp_codegen_initialize_runtime_metadata\"(v318, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv321 = \"uvs\";\n\tv322 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv324 = \"vertexCount\";\n\tv325 = \"il2cpp_codegen_initialize_runtime_metadata\"(v324, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv327 = \"edges\";\n\tv328 = \"il2cpp_codegen_initialize_runtime_metadata\"(v327, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv330 = \"name\";\n\tv331 = \"il2cpp_codegen_initialize_runtime_metadata\"(v330, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv333 = \"color\";\n\tv334 = \"il2cpp_codegen_initialize_runtime_metadata\"(v333, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv336 = \"scaleY\";\n\tv337 = \"il2cpp_codegen_initialize_runtime_metadata\"(v336, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv339 = \"width\";\n\tv340 = \"il2cpp_codegen_initialize_runtime_metadata\"(v339, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv342 = \"type\";\n\tv343 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv345 = \"path\";\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v345, map, skin, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv71 = 1;\n\t*([1A37BA0]) = v71;\nL_0093:\n\tv78 = Spine.SkeletonJson::GetString(map, \"name\", name);\n\tv86 = Spine.SkeletonJson::GetString(map, \"type\", \"region\");\n\tgoto L_00A4;\n\tv99 = v90;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v99, v82, v83, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_00A4:\n\tv104 = System.Type::GetTypeFromHandle(Spine.AttachmentType);\n\tgoto L_00B1;\n\tv116 = v108;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v116, v103, v83, slotIndex, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_00B1:\n\tv123 = System.Enum::Parse(v104, v86, 1);\n\tv146 = v146_asT == 0;\n\tif (v146) goto L_03D2;\n\tv153 = \"il2cpp_vm_object_unbox\"(v123, Spine.AttachmentType, 1, 0, name, skeletonData, methodInfo, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv181 = *([v153 @ X0_v32]);\n\tv184 = Spine.SkeletonJson::GetString(map, \"path\", v78);\n\tv190 = *([v153 @ X0_v32]) < 6;\n\tv191 = ~v190;\n\tv192 = *([v153 @ X0_v32]) - 6;\n\tv194 = v192 == 0;\n\tv199 = ~v194;\n\tv200 = v191 & v199;\n\tif (v200) goto L_010A;\n\tv208 = 0x44C000 + 0xD3C;\n\tv211 = *([v208 @ X8_v10 (System.Int32)+v181 @ X22_v4]) << 2;\n\tv212 = 0x154A9F8 + v211;\n\t// 224 IndirectJump v212 @ X9_v7 (System.Int32), v184 @ X0_v34 (System.String), v184 @ X0_v34 (System.String), \"path\", v78 @ X0_v3 (System.String), 0, name @ X4 (System.String), skeletonData @ X5 (Spine.SkeletonData), methodInfo @ X6 (Il2CppMethodInfo), v59 @ X7, v60 @ V0, v61 @ V1, v62 @ V2, v63 @ V3, v64 @ V4, v65 @ V5, v66 @ V6, v67 @ V7\n\tX24 = *([X20+18]);\n\tif (TEMP) goto L_03D1;\n\tX8 = *([X24]);\n\tX10 = *([1946F58]);\n\tX9 = *([X8+12E]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_0105;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_00ED:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_01D3;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP\n// ... truncated")]
		private Attachment ReadAttachment(Dictionary<string, object> map, Skin skin, int slotIndex, string name, SkeletonData skeletonData)
		{
			//IL_0040: Expected I4, but got O
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			string defaultValue = GetString(map, "name", name);
			string value = GetString(map, "type", "region");
			Type typeFromHandle = typeof(AttachmentType);
			object obj = Enum.Parse(typeFromHandle, value, ignoreCase: true);
			if ((int)((obj is AttachmentType) ? obj : null) != 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj3 = default(object);
				object obj2 = obj3;
				string text = GetString(map, "path", defaultValue);
				bool flag = (nint)obj3 < 6;
				bool flag2 = !flag;
				object obj4 = obj3 - 6;
				bool flag3 = obj4 == null;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num = 4505600 + 3388;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ X8_v10 (System.Int32)+v181 @ X22_v4]");
					int num2 = (int)((nint)0 << 2);
					int num3 = 22325752 + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v212 @ X9_v7 (System.Int32) (should have been resolved before IL gen)");
				}
				return null;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x60003DD")]
		[Address(RVA = "0x154C00C", Offset = "0x154C00C", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv198 = Il2CppMethodInfo;\n\tv199 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv201 = Il2CppMethodInfo;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv284 = Il2CppMethodInfo;\n\tv285 = \"il2cpp_codegen_initialize_runtime_metadata\"(v284, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv302 = Il2CppMethodInfo;\n\tv303 = \"il2cpp_codegen_initialize_runtime_metadata\"(v302, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv350 = Spine.ExposedList`1<System.Int32>;\n\tv351 = \"il2cpp_codegen_initialize_runtime_metadata\"(v350, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv359 = Spine.ExposedList`1<System.Single>;\n\tv360 = \"il2cpp_codegen_initialize_runtime_metadata\"(v359, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv381 = \"vertices\";\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, map, attachment, verticesLength, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A37BA1]) = v55;\nL_0038:\n\tattachment.worldVerticesLength = verticesLength;\n\tv65 = Spine.SkeletonJson::GetFloatArray(map, \"vertices\", 1f);\n\tv213 = v65.Length != verticesLength;\n\tif (v213) goto L_007C;\n\tv292 = this.<Scale>k__BackingField == 1f;\n\tif (v292) goto L_016B;\n\tv314 = verticesLength < 1;\n\tif (v314) goto L_016B;\n\tv322 = verticesLength << 2;\nL_0067:\n\tv315 = v65 + v372;\n\tv372 = v372 + 4;\n\tv323 = this.<Scale>k__BackingField * *([v315 @ X10_v3+20]);\n\t*([v315 @ X10_v3+20]) = v323;\n\tv324 = v322 != v372;\n\tif (v324) goto L_0067;\n\tgoto L_016B;\nL_007C:\n\tv300 = new Spine.ExposedList`1<System.Single>();\n\tv344 = verticesLength << 3;\n\tv345 = verticesLength + v344;\n\tv346 = verticesLength << 1;\n\tv347 = verticesLength + v346;\n\tSpine.ExposedList`1<System.Single>::.ctor(v300, v345);\n\tv357 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v357, v347);\n\tv393 = v65.Length < 1;\n\tif (v393) goto L_0160;\nL_00B6:\n\tv70 = v65[v524 @ X8_v23 (System.Int32)] != 0x7F800000;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_00C1;\nL_00C1:\n\tSpine.ExposedList`1<System.Int32>::Add(v357, v184);\n\tv534 = v184 << 2;\n\tv181 = v449 + v534;\n\tv544 = v449 >= v181;\n\tif (v544) goto L_FFFFFFFF;\nL_00EA:\n\tv68 = v65[v449 @ X25_v10 (System.Int32)] != 0x7F800000;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_00F1;\nL_00F1:\n\tSpine.ExposedList`1<System.Int32>::Add(v357, v159);\n\tv82 = v449 + 1;\n\tv497 = this.<Scale>k__BackingField * v65[v82 @ X25_v11 (System.Int32)];\n\tSpine.ExposedList`1<System.Single>::Add(v300, v497);\n\tv450 = v82 + 1;\n\tv601 = v449 + 2;\n\tv498 = v65[v601 @ X8_v35 (System.Int32)] * this.<Scale>k__BackingField;\n\tSpine.ExposedList`1<System.Single>::Add(v300, v498);\n\tv451 = v450 + 1;\n\tv605 = v449 + 3;\n\tSpine.ExposedList`1<System.Single>::Add(v300, v65[v605 @ X8_v38 (System.Int32)]);\n\tv449 = v451 + 1;\n\tv547 = v449 < v181;\n\tif (v547) goto L_00EA;\n\tv524 = v449 + 4;\n\tgoto L_014A;\nL_014A:\n\tv412 = v524 >= v442;\n\tif (v412) goto L_0160;\n\tv449 = v524 + 1;\n\tv596 = v524 < v65.Length;\n\tv489 = ~v596;\n\tv460 = ~v489;\n\tif (v460) goto L_00B6;\n\tv433 = new System.IndexOutOfRangeException();\nL_0160:\n\tv170 = Spine.ExposedList`1<System.Int32>::ToArray(v357);\n\tattachment.bones = v170;\n\tv334 = Spine.ExposedList`1<System.Single>::ToArray(v300);\nL_016B:\n\tv337.vertices = v335;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 291 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReadVertices(Dictionary<string, object> map, VertexAttachment attachment, int verticesLength)
		{
			//IL_00ef: Expected O, but got I4
			//IL_0138: Expected O, but got I4
			//IL_01a1: Expected I4, but got F4
			//IL_03e3: Expected O, but got I
			//IL_0237: Expected I4, but got F4
			attachment.WorldVerticesLength = verticesLength;
			float[] floatArray = GetFloatArray(map, "vertices", 1f);
			float[] vertices;
			VertexAttachment vertexAttachment;
			if (floatArray.Length == verticesLength)
			{
				bool flag = Scale == 1f;
				vertices = floatArray;
				vertexAttachment = attachment;
				if (!flag)
				{
					bool flag2 = verticesLength < 1;
					vertices = floatArray;
					vertexAttachment = attachment;
					if (!flag2)
					{
						int num = verticesLength << 2;
						int num2 = 0;
						int num3 = default(int);
						num2 = num3;
						do
						{
							object obj = (nint)floatArray + num2;
							num2 += 4;
							float num4 = Scale;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X10_v3+20]");
							float num5 = num4 * 0f;
						}
						while (num != num2);
						vertices = floatArray;
						vertexAttachment = attachment;
					}
				}
			}
			else
			{
				int num6 = default(int);
				ExposedList<float> exposedList = new ExposedList<float>((IEnumerable<float>)num6);
				int num7 = verticesLength << 3;
				num6 = verticesLength + num7;
				int num8 = verticesLength << 1;
				int num9 = verticesLength + num8;
				ExposedList<int> exposedList2 = new ExposedList<int>((IEnumerable<int>)num9);
				if (floatArray.Length >= 1)
				{
					int num10 = 1;
					int num11 = 0;
					int num12 = floatArray.Length;
					while (true)
					{
						int num13 = ((floatArray[num11] != float.PositiveInfinity) ? ((int)floatArray[num11]) : int.MinValue);
						exposedList2.Add(num13);
						int num14 = num13 << 2;
						int num15 = num10 + num14;
						if (num10 < num15)
						{
							do
							{
								int item = ((floatArray[num10] != float.PositiveInfinity) ? ((int)floatArray[num10]) : int.MinValue);
								exposedList2.Add(item);
								int num16 = num10 + 1;
								float item2 = Scale * floatArray[num16];
								exposedList.Add(item2);
								int num17 = num16 + 1;
								int num18 = num10 + 2;
								float item3 = floatArray[num18] * Scale;
								exposedList.Add(item3);
								int num19 = num17 + 1;
								int num20 = num10 + 3;
								exposedList.Add(floatArray[num20]);
								num10 = num19 + 1;
							}
							while (num10 < num15);
							num11 = num10 + 4;
							num12 = floatArray.Length;
						}
						else
						{
							num11 = num10;
						}
						if (num11 >= num12)
						{
							break;
						}
						num10 = num11 + 1;
						if (num11 >= floatArray.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							break;
						}
					}
				}
				int[] bones = exposedList2.ToArray();
				attachment.Bones = bones;
				float[] array = exposedList.ToArray();
				vertices = array;
				vertexAttachment = attachment;
			}
			vertexAttachment.Vertices = vertices;
		}

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0x1547504", Offset = "0x1547504", Length = "0x4B08")]
		private unsafe void ReadAnimation(Dictionary<string, object> map, string name, SkeletonData skeletonData)
		{
			//IL_4e3f: Expected O, but got I4
			//IL_00f8: Expected F4, but got O
			//IL_1024: Expected F4, but got O
			//IL_1b64: Expected F4, but got O
			//IL_1e9b: Expected F4, but got O
			//IL_21d5: Expected I, but got O
			//IL_21dd: Expected F4, but got O
			//IL_0174: Expected O, but got F4
			//IL_0181: Expected F4, but got O
			//IL_55df: Expected I4, but got O
			//IL_3c08: Expected I, but got O
			//IL_2efb: Expected F4, but got O
			//IL_10ba: Expected O, but got F4
			//IL_10c7: Expected F4, but got O
			//IL_0c9d: Expected O, but got I4
			//IL_3c39: Expected O, but got I
			//IL_17f6: Expected O, but got I4
			//IL_3c9d: Expected O, but got I4
			//IL_2f70: Expected O, but got F4
			//IL_2f7d: Expected F4, but got O
			//IL_2297: Expected O, but got F4
			//IL_22a5: Expected F4, but got O
			//IL_39e2: Expected I, but got O
			//IL_0e63: Expected O, but got I4
			//IL_028a: Expected F4, but got O
			//IL_0450: Expected F4, but got O
			//IL_07b8: Expected F4, but got O
			//IL_1d35: Expected O, but got I4
			//IL_1d45: Expected O, but got I4
			//IL_0f17: Expected O, but got I4
			//IL_3d55: Expected I4, but got I8
			//IL_3ac1: Expected I4, but got O
			//IL_22d7: Expected I, but got O
			//IL_15c2: Expected F4, but got O
			//IL_19a8: Expected O, but got I4
			//IL_2cec: Expected I, but got O
			//IL_2cf5: Expected I4, but got O
			//IL_234f: Expected O, but got I
			//IL_4540: Expected I, but got O
			//IL_3a6c: Expected I4, but got O
			//IL_2caa: Expected I, but got O
			//IL_2cb3: Expected I4, but got O
			//IL_4786: Expected O, but got I
			//IL_3027: Expected F4, but got O
			//IL_1a5c: Expected O, but got I4
			//IL_3e2d: Expected O, but got I
			//IL_271f: Expected I, but got O
			//IL_2d7d: Expected I, but got O
			//IL_2d86: Expected I4, but got O
			//IL_2681: Expected I, but got O
			//IL_2494: Expected F4, but got O
			//IL_277c: Expected F4, but got O
			//IL_4660: Expected O, but got I4
			//IL_3117: Expected O, but got I
			//IL_4717: Expected O, but got F4
			//IL_3172: Expected O, but got I4
			//IL_4041: Expected F4, but got O
			//IL_40b4: Expected F4, but got O
			//IL_3331: Expected F4, but got O
			//IL_36dd: Expected O, but got I
			//IL_3577: Expected O, but got I4
			//IL_34be: Expected O, but got I
			//IL_34cd: Expected O, but got I
			//IL_351d: Expected O, but got F4
			//IL_352c: Expected O, but got I
			//IL_3685: Expected O, but got I4
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			object obj = enumerator;
			_ = 0;
			_ = 0;
			obj = 0;
			_ = 0;
			ExposedList<Timeline> exposedList = new ExposedList<Timeline>();
			bool flag = map.ContainsKey("slots");
			bool flag2 = !flag;
			SkeletonData skeletonData2 = skeletonData;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			string text2 = default(string);
			string text = text2;
			float num = 0f;
			float num2 = 0f;
			SkeletonData skeletonData3 = skeletonData;
			Dictionary<string, object> dictionary = map;
			Dictionary<string, object> dictionary3 = default(Dictionary<string, object>);
			Dictionary<object, object>.Enumerator enumerator4 = default(Dictionary<object, object>.Enumerator);
			int slotIndex;
			string text3 = default(string);
			object obj4 = default(object);
			float num4 = default(float);
			float num3;
			if (!flag2)
			{
				object obj2 = map["slots"];
				Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
				if (dictionary2 == null)
				{
					goto IL_4ad9;
				}
				object enumerator3 = ((Dictionary<object, object>)obj2).GetEnumerator();
				object obj3 = enumerator;
				skeletonData2 = skeletonData;
				enumerator2 = default(List<object>.Enumerator);
				text = text2;
				num3 = (float)dictionary3;
				num = 0f;
				num2 = 0f;
				while (enumerator4.MoveNext())
				{
					slotIndex = skeletonData.FindSlotIndex(text3);
					Dictionary<string, object> dictionary4 = obj4 as Dictionary<string, object>;
					if (dictionary4 != null)
					{
						object enumerator5 = ((Dictionary<object, object>)obj4).GetEnumerator();
						object obj5 = enumerator;
						obj5 = num4;
						num3 = (float)dictionary3;
						float num5 = num;
						if (!enumerator.MoveNext())
						{
							num2 = num5;
							Dictionary<string, object> dictionary5 = (Dictionary<string, object>)3;
							int num6 = 0;
							enumerator.Dispose();
							if (num6 == 0)
							{
								bool flag3 = (nint)dictionary5 == 3;
								num = num5;
								if (flag3)
								{
									continue;
								}
								bool flag4 = dictionary5 == null;
								num = num5;
								if (flag4)
								{
									continue;
								}
								goto IL_3afa;
							}
							throw new OutOfMemoryException();
						}
						goto IL_018e;
					}
					throw new InvalidCastException();
				}
				enumerator4.Dispose();
				skeletonData3 = skeletonData;
				dictionary = map;
			}
			float num7;
			int num8;
			if (dictionary.ContainsKey("bones"))
			{
				object obj6 = dictionary["bones"];
				Dictionary<string, object> dictionary6 = obj6 as Dictionary<string, object>;
				if (dictionary6 == null)
				{
					goto IL_4ad9;
				}
				object enumerator6 = ((Dictionary<object, object>)obj6).GetEnumerator();
				object obj7 = enumerator;
				num7 = num;
				num3 = (float)dictionary3;
				num2 = num4;
				while (enumerator4.MoveNext())
				{
					num8 = skeletonData.FindBoneIndex(text3);
					if (num8 + 1 != 0)
					{
						Dictionary<string, object> dictionary7 = obj4 as Dictionary<string, object>;
						if (dictionary7 != null)
						{
							object enumerator7 = ((Dictionary<object, object>)obj4).GetEnumerator();
							object obj8 = enumerator;
							obj8 = num4;
							num3 = (float)dictionary3;
							float num9 = num7;
							if (!enumerator.MoveNext())
							{
								text = null;
								num2 = num9;
								Dictionary<string, object> dictionary8 = (Dictionary<string, object>)22;
								enumerator.Dispose();
								if (text == null)
								{
									bool flag5 = (nint)dictionary8 == 22;
									num7 = num9;
									if (flag5)
									{
										continue;
									}
									bool flag6 = dictionary8 == null;
									num7 = num9;
									if (flag6)
									{
										continue;
									}
									goto IL_3afa;
								}
								throw new OutOfMemoryException();
							}
							goto IL_10d4;
						}
						throw new InvalidCastException();
					}
					string message = "Bone not found: " + text3;
					Exception ex = new Exception(message);
					throw ex;
				}
				enumerator4.Dispose();
				skeletonData3 = skeletonData;
			}
			else
			{
				num7 = num;
			}
			SkeletonData skeletonData4;
			float num14;
			object obj11 = default(object);
			nint num13 = default(nint);
			float softness = default(float);
			if (map.ContainsKey("ik"))
			{
				object obj9 = map["ik"];
				Dictionary<string, object> dictionary9 = obj9 as Dictionary<string, object>;
				if (dictionary9 == null)
				{
					goto IL_4ad9;
				}
				object enumerator8 = ((Dictionary<object, object>)obj9).GetEnumerator();
				object obj10 = enumerator;
				num3 = (float)dictionary3;
				num2 = num7;
				if (enumerator4.MoveNext())
				{
					IkConstraintData item = skeletonData.FindIkConstraint(text3);
					List<object> list = obj4 as List<object>;
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-B8+18]");
						IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(0);
						int ikConstraintIndex = skeletonData.IkConstraints.IndexOf(item);
						ikConstraintTimeline.ikConstraintIndex = ikConstraintIndex;
						object enumerator9 = ((List<object>)obj4).GetEnumerator();
						int num10 = 0;
						List<object>.Enumerator enumerator10 = default(List<object>.Enumerator);
						while (enumerator10.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary10 = dictionary3 as Dictionary<string, object>;
								if (dictionary10 == null)
								{
									throw new InvalidCastException();
								}
							}
							float time = GetFloat(dictionary3, "time", 0f);
							float mix = GetFloat(dictionary3, "mix", 1f);
							float num11 = GetFloat(dictionary3, "softness", 0f);
							int bendDirection = (GetBoolean(dictionary3, "bendPositive", defaultValue: true) ? 1 : (-1));
							bool boolean = GetBoolean(dictionary3, "compress", defaultValue: false);
							bool boolean2 = GetBoolean(dictionary3, "stretch", defaultValue: false);
							softness = Scale * num11;
							ikConstraintTimeline.SetFrame(num10, time, mix, softness, bendDirection, boolean, boolean2);
							ReadCurve(dictionary3, ikConstraintTimeline, num10);
							int num12 = num10 + 1;
							obj11 = 0;
							num13 = (boolean2 ? 1 : 0);
							skeletonData2 = (SkeletonData)boolean;
							num10 = num12;
						}
						enumerator10.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						NullReferenceException ex3 = new NullReferenceException();
						IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
						NullReferenceException ex5 = new NullReferenceException();
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				enumerator4.Dispose();
				num14 = num2;
				skeletonData4 = skeletonData;
				skeletonData3 = skeletonData;
			}
			else
			{
				num14 = num7;
				skeletonData4 = skeletonData;
			}
			float num22;
			float num20 = default(float);
			float num21 = default(float);
			if (map.ContainsKey("transform"))
			{
				object obj12 = map["transform"];
				Dictionary<string, object> dictionary11 = obj12 as Dictionary<string, object>;
				if (dictionary11 == null)
				{
					goto IL_4ad9;
				}
				object enumerator11 = ((Dictionary<object, object>)obj12).GetEnumerator();
				object obj13 = enumerator;
				num3 = (float)dictionary3;
				num2 = num14;
				if (enumerator4.MoveNext())
				{
					TransformConstraintData item2 = skeletonData4.FindTransformConstraint(text3);
					List<object> list2 = obj4 as List<object>;
					if (list2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2358 @ stack_-B8+18]");
						TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(0);
						int transformConstraintIndex = skeletonData4.TransformConstraints.IndexOf(item2);
						transformConstraintTimeline.transformConstraintIndex = transformConstraintIndex;
						object enumerator12 = ((List<object>)obj4).GetEnumerator();
						int num15 = 0;
						List<object>.Enumerator enumerator13 = default(List<object>.Enumerator);
						while (enumerator13.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary12 = dictionary3 as Dictionary<string, object>;
								if (dictionary12 == null)
								{
									throw new InvalidCastException();
								}
							}
							float time2 = GetFloat(dictionary3, "time", 0f);
							float rotateMix = GetFloat(dictionary3, "rotateMix", 1f);
							float num16 = GetFloat(dictionary3, "translateMix", 1f);
							float num17 = GetFloat(dictionary3, "scaleMix", 1f);
							float num18 = GetFloat(dictionary3, "shearMix", 1f);
							transformConstraintTimeline.SetFrame(num15, time2, rotateMix, num16, num17, num18);
							ReadCurve(dictionary3, transformConstraintTimeline, num15);
							int num19 = num15 + 1;
							num20 = num17;
							softness = num16;
							num21 = num18;
							num15 = num19;
						}
						enumerator13.Dispose();
						OutOfMemoryException ex6 = new OutOfMemoryException();
						IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
						NullReferenceException ex8 = new NullReferenceException();
						NullReferenceException ex9 = new NullReferenceException();
						goto IL_4a58;
					}
					InvalidCastException ex10 = new InvalidCastException();
					NullReferenceException ex11 = new NullReferenceException();
					throw new NullReferenceException();
				}
				enumerator4.Dispose();
				num22 = num2;
				skeletonData3 = skeletonData4;
			}
			else
			{
				num22 = num14;
			}
			float num23;
			string text4 = default(string);
			string text5 = default(string);
			nint num32;
			int num33;
			int num34;
			float num31;
			NullReferenceException ex12;
			if (map.ContainsKey("path"))
			{
				object obj14 = map["path"];
				Dictionary<string, object> dictionary13 = obj14 as Dictionary<string, object>;
				if (dictionary13 == null)
				{
					goto IL_4ad9;
				}
				object enumerator14 = ((Dictionary<object, object>)obj14).GetEnumerator();
				object obj15 = enumerator;
				num23 = num22;
				nint num24 = (nint)typeof(List<object>);
				num3 = (float)dictionary3;
				num2 = num4;
				List<object>.Enumerator enumerator19 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator17 = default(List<object>.Enumerator);
				while (enumerator4.MoveNext())
				{
					int num25 = skeletonData4.FindPathConstraintIndex(text3);
					if (num25 + 1 != 0)
					{
						ExposedList<PathConstraintData> pathConstraints = skeletonData4.PathConstraints;
						PathConstraintData[] items = pathConstraints.Items;
						Dictionary<string, object> dictionary14 = obj4 as Dictionary<string, object>;
						if (dictionary14 != null)
						{
							object enumerator15 = ((Dictionary<object, object>)obj4).GetEnumerator();
							object obj16 = enumerator;
							obj16 = num4;
							num3 = (float)dictionary3;
							float num26 = num23;
							while (enumerator.MoveNext())
							{
								if (text4 != null)
								{
									nint num27 = (nint)text4;
									int num28 = (int)num24;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10861 @ X8_v367 (Il2CppClass<System.String>)+130]");
									nint num29 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7079 @ X1_v193 (System.Int32)+130]");
									if (num29 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7079 @ X1_v193 (System.Int32)+130]");
										int num30 = (int)((nint)0 << 3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10861 @ X8_v367 (Il2CppClass<System.String>)+C8]");
										object obj17 = (nint)0 + (nint)num30;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10992 @ X8_v370-8]");
										if ((nint)0 == num28)
										{
											goto IL_2377;
										}
									}
									throw new InvalidCastException();
								}
								goto IL_2377;
								IL_2377:
								switch (text5)
								{
								case "mix":
									if (text4 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
										PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(0);
										if (pathConstraintMixTimeline == null)
										{
											throw pathConstraintMixTimeline;
										}
										pathConstraintMixTimeline.pathConstraintIndex = num25;
										object enumerator18 = ((List<object>)(object)text4).GetEnumerator();
										num2 = (float)enumerator19;
										int num38 = 0;
										int num40 = 0;
										while (enumerator19.MoveNext())
										{
											if (dictionary3 != null)
											{
												Dictionary<string, object> dictionary16 = dictionary3 as Dictionary<string, object>;
												if (dictionary16 == null)
												{
													throw new InvalidCastException();
												}
											}
											num2 = GetFloat(dictionary3, "time", 0f);
											float num41 = GetFloat(dictionary3, "rotateMix", 1f);
											float num42 = GetFloat(dictionary3, "translateMix", 1f);
											pathConstraintMixTimeline.SetFrame(num40, num2, num41, num42);
											ReadCurve(dictionary3, pathConstraintMixTimeline, num40);
											int num43 = num40 + 1;
											softness = num42;
											num14 = num2;
											num3 = num41;
											num38 = num40;
											num40 = num43;
										}
										enumerator19.Dispose();
										OutOfMemoryException ex14 = new OutOfMemoryException();
										num31 = 1f;
										num23 = num26;
										enumerator2 = enumerator19;
										text = null;
										num32 = num38;
										num33 = 0;
										ex12 = (NullReferenceException)(object)ex14;
										num34 = num25;
									}
									else
									{
										ex12 = new NullReferenceException();
										num31 = 1f;
										num23 = num26;
										num2 = num26;
										num32 = unchecked((nint)null);
										num33 = (int)"mix";
										num34 = num25;
									}
									break;
								case "position":
								case "spacing":
								{
									PathConstraintSpacingTimeline pathConstraintSpacingTimeline;
									PathConstraintPositionTimeline pathConstraintPositionTimeline;
									nint num35;
									bool flag10;
									if (text5 == "spacing")
									{
										if (text4 == null)
										{
											ex12 = new NullReferenceException();
											num31 = 1f;
											num23 = num26;
											num2 = num26;
											num32 = unchecked((nint)null);
											num33 = (int)"spacing";
											num34 = num25;
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
										pathConstraintSpacingTimeline = new PathConstraintSpacingTimeline(0);
										PathConstraintData pathConstraintData = items[num25];
										if (items[num25] == null)
										{
											throw pathConstraintSpacingTimeline;
										}
										bool flag7 = pathConstraintData.SpacingMode < SpacingMode.Percent;
										bool flag8 = !flag7;
										bool flag9 = !flag8;
										pathConstraintPositionTimeline = pathConstraintSpacingTimeline;
										num35 = unchecked((nint)null);
										flag10 = flag9;
									}
									else
									{
										if (text4 == null)
										{
											ex12 = new NullReferenceException();
											num31 = 1f;
											num23 = num26;
											num2 = num26;
											num32 = unchecked((nint)null);
											num33 = (int)"spacing";
											num34 = num25;
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
										PathConstraintPositionTimeline pathConstraintPositionTimeline2 = new PathConstraintPositionTimeline(0);
										PathConstraintData pathConstraintData2 = items[num25];
										if (items[num25] == null)
										{
											throw pathConstraintPositionTimeline2;
										}
										bool flag11 = pathConstraintData2.PositionMode == PositionMode.Fixed;
										pathConstraintPositionTimeline = pathConstraintPositionTimeline2;
										num35 = unchecked((nint)null);
										pathConstraintSpacingTimeline = (PathConstraintSpacingTimeline)pathConstraintPositionTimeline2;
										flag10 = flag11;
									}
									float num36 = ((!flag10) ? 1f : Scale);
									if (pathConstraintPositionTimeline != null)
									{
										pathConstraintPositionTimeline.pathConstraintIndex = num25;
										object enumerator16 = ((List<object>)(object)text4).GetEnumerator();
										int num37 = 0;
										num2 = (float)enumerator17;
										int num38 = (int)num35;
										while (enumerator17.MoveNext())
										{
											if (dictionary3 != null)
											{
												Dictionary<string, object> dictionary15 = dictionary3 as Dictionary<string, object>;
												if (dictionary15 == null)
												{
													throw new InvalidCastException();
												}
											}
											num2 = GetFloat(dictionary3, "time", 0f);
											float num39 = GetFloat(dictionary3, text5, 0f);
											num3 = num36 * num39;
											pathConstraintPositionTimeline.SetFrame(num37, num2, num3);
											ReadCurve(dictionary3, pathConstraintPositionTimeline, num37);
											num37++;
											num14 = num2;
											num38 = num37;
										}
										enumerator17.Dispose();
										OutOfMemoryException ex13 = new OutOfMemoryException();
										num31 = 1f;
										num23 = num26;
										enumerator2 = enumerator17;
										text = null;
										num32 = num38;
										num33 = 0;
										ex12 = (NullReferenceException)(object)ex13;
										num34 = num25;
										break;
									}
									throw pathConstraintSpacingTimeline;
								}
								default:
									continue;
								}
								goto IL_4bd7;
							}
							num2 = num26;
							int num44 = 0;
							int num45 = 58;
							enumerator.Dispose();
							if (num44 == 0)
							{
								bool flag12 = num45 == 58;
								num23 = num26;
								if (flag12)
								{
									continue;
								}
								bool flag13 = num45 == 0;
								num23 = num26;
								if (flag13)
								{
									continue;
								}
								goto IL_3afa;
							}
							OutOfMemoryException ex15 = new OutOfMemoryException();
							NullReferenceException ex16 = new NullReferenceException();
							throw new NullReferenceException();
						}
						InvalidCastException ex17 = new InvalidCastException();
						throw new NullReferenceException();
					}
					string message2 = "Path constraint not found: " + text3;
					Exception ex18 = new Exception(message2);
					throw ex18;
				}
				enumerator4.Dispose();
				skeletonData3 = skeletonData4;
			}
			else
			{
				num23 = num22;
			}
			goto IL_53c4;
			IL_3ace:
			OutOfMemoryException ex19 = new OutOfMemoryException();
			float num46;
			num31 = num46;
			num14 = num46;
			num33 = 0;
			ex12 = (NullReferenceException)(object)ex19;
			goto IL_4bd7;
			IL_53c4:
			Skin skin;
			int num47;
			int slotIndex2;
			if (map.ContainsKey("deform"))
			{
				object obj18 = map["deform"];
				Dictionary<string, object> dictionary17 = obj18 as Dictionary<string, object>;
				if (dictionary17 == null)
				{
					goto IL_4ad9;
				}
				object enumerator20 = ((Dictionary<object, object>)obj18).GetEnumerator();
				object obj19 = enumerator;
				num31 = num23;
				num3 = (float)dictionary3;
				num2 = num4;
				num32 = 0;
				Dictionary<object, object>.Enumerator enumerator23 = default(Dictionary<object, object>.Enumerator);
				while (enumerator4.MoveNext())
				{
					skin = skeletonData3.FindSkin(text3);
					Dictionary<string, object> dictionary18 = obj4 as Dictionary<string, object>;
					nint num49;
					int num50;
					if (dictionary18 != null)
					{
						object enumerator21 = ((Dictionary<object, object>)obj4).GetEnumerator();
						object obj20 = enumerator;
						obj20 = num4;
						num3 = (float)dictionary3;
						num2 = num4;
						while (enumerator.MoveNext())
						{
							num47 = skeletonData3.FindSlotIndex(text5);
							if (num47 + 1 != 0)
							{
								if (text4 == null)
								{
									goto IL_3ab0;
								}
								Dictionary<string, object> dictionary19 = text4 as Dictionary<string, object>;
								if (dictionary19 == null)
								{
									goto IL_3a55;
								}
								object enumerator22 = ((Dictionary<object, object>)(object)text4).GetEnumerator();
								num3 = (float)dictionary3;
								num46 = num31;
								slotIndex2 = num47;
								if (!enumerator23.MoveNext())
								{
									num2 = num46;
									num34 = 79;
									int num48 = 0;
									enumerator23.Dispose();
									if (num48 == 0)
									{
										bool flag14 = num34 == 79;
										num31 = num46;
										num14 = num46;
										if (flag14)
										{
											continue;
										}
										bool flag15 = num34 == 0;
										num31 = num46;
										num14 = num46;
										if (flag15)
										{
											continue;
										}
										goto IL_39f0;
									}
									goto IL_3ace;
								}
								goto IL_303c;
							}
							string message3 = "Slot not found: " + text5;
							Exception ex20 = new Exception(message3);
							throw ex20;
						}
						num49 = (nint)typeof(_0021_00210);
						num50 = 0;
						goto IL_5544;
					}
					InvalidCastException ex21 = new InvalidCastException();
					NullReferenceException ex22 = new NullReferenceException();
					NullReferenceException ex23 = new NullReferenceException();
					NullReferenceException ex24 = new NullReferenceException();
					throw new NullReferenceException();
					IL_5544:
					enumerator.Dispose();
					if (num50 == 0)
					{
						if (num49 == 77 || num49 == 0)
						{
							continue;
						}
						goto IL_3afa;
					}
					goto IL_4acb;
					IL_39f0:
					num31 = num46;
					num14 = num46;
					num49 = num34;
					num50 = 0;
					goto IL_5544;
				}
				enumerator4.Dispose();
			}
			else
			{
				num31 = num23;
			}
			ExposedList<SlotData> slots;
			int num54;
			int count;
			if (map.ContainsKey("drawOrder") || map.ContainsKey("draworder"))
			{
				string key = ((!map.ContainsKey("drawOrder")) ? "draworder" : "drawOrder");
				int num51 = (int)map[key];
				int value = ((int*)num51)->m_value;
				nint num52 = (nint)typeof(List<object>);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7658 @ X1_v54 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+130]");
				int num53 = (int)((nint)0 << 3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7657 @ X8_v85 (System.Int32)+C8]");
				object obj21 = (nint)0 + (nint)num53;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8300 @ X8_v87-8]");
				if (0 != (nint)typeof(List<object>))
				{
					goto IL_4b91;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ X0_v100 (System.Int32)+18]");
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(0);
				slots = skeletonData3.Slots;
				object enumerator24 = ((List<object>)num51).GetEnumerator();
				num54 = slots.Count - 1;
				int num55 = 0;
				DrawOrderTimeline drawOrderTimeline2 = drawOrderTimeline;
				count = slots.Count;
				List<object>.Enumerator enumerator25 = default(List<object>.Enumerator);
				while (enumerator25.MoveNext())
				{
					Dictionary<string, object> dictionary20 = dictionary3 as Dictionary<string, object>;
					if (dictionary20 != null)
					{
						if (dictionary3.ContainsKey("offsets"))
						{
							goto IL_3d36;
						}
						int[] drawOrder = null;
						float time3 = GetFloat(dictionary3, "time", 0f);
						int num56 = num55 + 1;
						drawOrderTimeline2.SetFrame(num55, time3, drawOrder);
						num55 = num56;
						skeletonData2 = null;
						skeletonData3 = skeletonData4;
						continue;
					}
					throw new InvalidCastException();
				}
				enumerator25.Dispose();
				exposedList.Add(drawOrderTimeline2);
				float[] frames = drawOrderTimeline2.Frames;
				int frameCount = drawOrderTimeline2.FrameCount;
				int num57 = frameCount - 1;
				num2 = Math.Max(num31, frames[num57]);
				num31 = num2;
				num3 = frames[num57];
			}
			Event obj23 = default(Event);
			ExposedList<Timeline> exposedList2;
			if (map.ContainsKey("events"))
			{
				object obj22 = map["events"];
				List<object> list3 = obj22 as List<object>;
				if (list3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ X0_v51+18]");
					EventTimeline eventTimeline = new EventTimeline(0);
					object enumerator26 = ((List<object>)obj22).GetEnumerator();
					List<object>.Enumerator enumerator28 = default(List<object>.Enumerator);
					List<object>.Enumerator enumerator27 = enumerator28;
					int num58 = 0;
					string text10 = default(string);
					while (true)
					{
						float num60;
						if (enumerator28.MoveNext())
						{
							Dictionary<string, object> dictionary21 = dictionary3 as Dictionary<string, object>;
							if (dictionary21 == null)
							{
								InvalidCastException ex25 = new InvalidCastException();
								throw new NullReferenceException();
							}
							string text6 = (string)dictionary3["name"];
							if (text6 != null && (object)text6.GetType() != typeof(string))
							{
								throw new InvalidCastException();
							}
							EventData eventData = skeletonData4.FindEvent(text6);
							IntPtr intPtr = ((eventData != null) ? ((IntPtr)129) : ((IntPtr)null));
							Dictionary<string, object> dictionary22;
							if (intPtr == (IntPtr)129)
							{
								float time4 = GetFloat(dictionary3, "time", 0f);
								obj23 = new Event(time4, eventData);
								if (eventData == null)
								{
									break;
								}
								int num59 = GetInt(dictionary3, "int", eventData.Int);
								obj23.Int = num59;
								num60 = (obj23.Float = GetFloat(dictionary3, "float", eventData.Float));
								string text7 = GetString(dictionary3, "string", eventData.String);
								EventData data = obj23.Data;
								obj23.String = text7;
								dictionary22 = ((data.AudioPath != null) ? null : ((Dictionary<string, object>)134));
								if (dictionary22 == null)
								{
									float volume = GetFloat(dictionary3, "volume", eventData.Volume);
									obj23.Volume = volume;
									num60 = (obj23.Balance = GetFloat(dictionary3, "balance", eventData.Balance));
									goto IL_46eb;
								}
								if ((nint)dictionary22 == 134)
								{
									goto IL_46eb;
								}
							}
							else
							{
								bool flag16 = intPtr == (IntPtr)0;
								dictionary22 = (Dictionary<string, object>)(nint)intPtr;
								if (flag16)
								{
									object obj24 = dictionary3["name"];
									string text8;
									string text9;
									if (obj24 == null)
									{
										text8 = null;
										text9 = "Event not found: ";
									}
									else
									{
										object obj25 = obj24;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v6121 @ X8_v433+168] (should have been resolved before IL gen)");
										text8 = text10;
										text9 = "Event not found: ";
									}
									string message4 = text9 + text8;
									Exception ex26 = new Exception(message4);
									throw ex26;
								}
							}
							enumerator28.Dispose();
							bool flag17 = dictionary22 == null;
							bool flag18 = !flag17;
							skeletonData3 = skeletonData4;
							if (flag18)
							{
								return;
							}
						}
						else
						{
							enumerator28.Dispose();
							skeletonData3 = skeletonData4;
						}
						exposedList.Add(eventTimeline);
						float[] frames2 = eventTimeline.Frames;
						int frameCount2 = eventTimeline.FrameCount;
						int num63 = frameCount2 - 1;
						float num64 = Math.Max(num31, frames2[num63]);
						num31 = num64;
						exposedList2 = exposedList;
						goto IL_5787;
						IL_46eb:
						int num65 = num58 + 1;
						eventTimeline.SetFrame(num58, obj23);
						skeletonData2 = null;
						enumerator27 = (List<object>.Enumerator)num60;
						num58 = num65;
					}
					goto IL_4b39;
				}
				goto IL_4b91;
			}
			bool flag19 = exposedList == null;
			bool flag20 = !flag19;
			exposedList2 = exposedList;
			if (!flag20)
			{
				goto IL_4a58;
			}
			goto IL_5787;
			IL_4b39:
			throw obj23;
			IL_10d4:
			if (text4 != null)
			{
				List<object> list4 = text4 as List<object>;
				if (list4 == null)
				{
					throw new InvalidCastException();
				}
			}
			switch (text5)
			{
			case "rotate":
				if (text4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					RotateTimeline rotateTimeline = new RotateTimeline(0);
					if (rotateTimeline != null)
					{
						rotateTimeline.boneIndex = num8;
						object enumerator31 = ((List<object>)(object)text4).GetEnumerator();
						int num71 = 0;
						List<object>.Enumerator enumerator32 = default(List<object>.Enumerator);
						while (enumerator32.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary24 = dictionary3 as Dictionary<string, object>;
								if (dictionary24 == null)
								{
									throw new InvalidCastException();
								}
							}
							float time5 = GetFloat(dictionary3, "time", 0f);
							float degrees = GetFloat(dictionary3, "angle", 0f);
							rotateTimeline.SetFrame(num71, time5, degrees);
							ReadCurve(dictionary3, rotateTimeline, num71);
							int num72 = num71 + 1;
							num71 = num72;
						}
						enumerator32.Dispose();
						throw new OutOfMemoryException();
					}
					throw rotateTimeline;
				}
				throw new NullReferenceException();
			case "translate":
			case "scale":
			case "shear":
			{
				ScaleTimeline scaleTimeline;
				float num66;
				float defaultValue;
				TranslateTimeline translateTimeline;
				if (text5 == "scale")
				{
					if (text4 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					scaleTimeline = new ScaleTimeline(0);
					num66 = 1f;
					defaultValue = 1f;
					translateTimeline = scaleTimeline;
				}
				else if (text5 == "shear")
				{
					if (text4 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					ShearTimeline shearTimeline = new ShearTimeline(0);
					num66 = 1f;
					defaultValue = 0f;
					translateTimeline = shearTimeline;
					scaleTimeline = (ScaleTimeline)(object)shearTimeline;
				}
				else
				{
					if (text4 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					TranslateTimeline translateTimeline2 = new TranslateTimeline(0);
					num66 = Scale;
					defaultValue = 0f;
					translateTimeline = translateTimeline2;
					scaleTimeline = (ScaleTimeline)translateTimeline2;
				}
				if (translateTimeline != null)
				{
					translateTimeline.boneIndex = num8;
					object enumerator29 = ((List<object>)(object)text4).GetEnumerator();
					List<object>.Enumerator enumerator30 = default(List<object>.Enumerator);
					num2 = (float)enumerator30;
					int num67 = 0;
					while (enumerator30.MoveNext())
					{
						if (dictionary3 != null)
						{
							Dictionary<string, object> dictionary23 = dictionary3 as Dictionary<string, object>;
							if (dictionary23 == null)
							{
								throw new InvalidCastException();
							}
						}
						num2 = GetFloat(dictionary3, "time", 0f);
						float num68 = GetFloat(dictionary3, "x", defaultValue);
						float num69 = GetFloat(dictionary3, "y", defaultValue);
						num3 = num66 * num68;
						softness = num66 * num69;
						translateTimeline.SetFrame(num67, num2, num3, softness);
						ReadCurve(dictionary3, translateTimeline, num67);
						int num70 = num67 + 1;
						num67 = num70;
					}
					enumerator30.Dispose();
					throw new OutOfMemoryException();
				}
				throw scaleTimeline;
			}
			default:
			{
				string[] array = new string[5];
				if (array == null)
				{
					throw new NullReferenceException();
				}
				if (array.Length == 0)
				{
					throw new IndexOutOfRangeException();
				}
				array[0] = "Invalid timeline type for a bone: ";
				if (array.Length == 1)
				{
					throw new IndexOutOfRangeException();
				}
				array[1] = text5;
				bool flag21 = array.Length < 2;
				bool flag22 = !flag21;
				object obj26 = array.Length - 2;
				bool flag23 = obj26 == null;
				bool flag24 = !flag22;
				if (!(flag24 || flag23))
				{
					array[2] = " (";
					if (array.Length == 3)
					{
						throw new IndexOutOfRangeException();
					}
					array[3] = text3;
					bool flag25 = array.Length < 4;
					bool flag26 = !flag25;
					object obj27 = array.Length - 4;
					bool flag27 = obj27 == null;
					bool flag28 = !flag26;
					if (!(flag28 || flag27))
					{
						array[4] = ")";
						string message5 = string.Concat(array);
						Exception ex27 = new Exception(message5);
						throw ex27;
					}
					throw new IndexOutOfRangeException();
				}
				throw new IndexOutOfRangeException();
			}
			}
			IL_3224:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11453 @ stack_-138+18]");
			DeformTimeline deformTimeline = new DeformTimeline(0);
			Attachment attachment;
			object obj28 = default(object);
			int num74;
			float[] array3;
			if (deformTimeline != null)
			{
				deformTimeline.slotIndex = slotIndex2;
				deformTimeline.Attachment = (VertexAttachment)attachment;
				object enumerator33 = ((List<object>)obj28).GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+20]");
				bool flag29 = (nint)0 == 0;
				bool flag30 = !flag29;
				int num73 = num74 - 1;
				bool flag31 = num73 < 0;
				int num75 = num74 ^ 1;
				int num76 = num74 ^ num73;
				int num77 = num75 & num76;
				bool flag32 = num77 < 0;
				bool flag33 = flag31 == flag32;
				bool flag34 = !flag33;
				bool flag35 = flag34 || flag30;
				int num78 = 0;
				List<object>.Enumerator enumerator34 = default(List<object>.Enumerator);
				num2 = (float)enumerator34;
				int num79 = 0;
				while (enumerator34.MoveNext())
				{
					if (dictionary3 != null)
					{
						Dictionary<string, object> dictionary25 = dictionary3 as Dictionary<string, object>;
						if (dictionary25 != null)
						{
							float[] vertices;
							if (dictionary3.ContainsKey("vertices"))
							{
								float[] array2 = new float[num74];
								int num80 = GetInt(dictionary3, "offset", 0);
								float[] floatArray = GetFloatArray(dictionary3, "vertices", 1f);
								if (floatArray == null)
								{
									throw new NullReferenceException();
								}
								Array.Copy(floatArray, 0, array2, num80, floatArray.Length);
								if (Scale != 1f)
								{
									int num81 = num80 + floatArray.Length;
									if (num80 < num81)
									{
										if (array2 == null)
										{
											throw new NullReferenceException();
										}
										int num82 = num80 << 2;
										object obj29 = (nint)array2 + num82;
										object obj30 = (nint)obj29 + 32;
										int num83 = num81 - num80;
										int num84 = num80;
										bool flag36;
										do
										{
											if (num84 < array2.Length)
											{
												int num85 = num83 - 1;
												num84++;
												float num86 = Scale * (float)obj30;
												obj30 = num86;
												obj30 = (nint)obj30 + 4;
												flag36 = num83 != 1;
												num83 = num85;
												continue;
											}
											throw new IndexOutOfRangeException();
										}
										while (flag36);
									}
								}
								bool flag37 = !flag35;
								bool flag38 = !flag37;
								obj11 = 0;
								num13 = floatArray.Length;
								vertices = array2;
								skeletonData3 = skeletonData4;
								if (!flag38)
								{
									if (array2 == null)
									{
										throw new NullReferenceException();
									}
									int num87 = 0;
									do
									{
										if (num87 < array2.Length)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+28]");
											if ((nint)0 != 0)
											{
												if (num87 < array3.Length)
												{
													float num88 = array2[num87] + array3[num87];
													array2[num87] = num88;
													num87++;
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										throw new IndexOutOfRangeException();
									}
									while (num74 != num87);
									obj11 = 0;
									num13 = floatArray.Length;
									num3 = array3[num87];
									vertices = array2;
									skeletonData3 = skeletonData4;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+20]");
								bool flag39 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+28]");
								vertices = (float[])0;
								if (!flag39)
								{
									float[] array4 = new float[num74];
									vertices = array4;
								}
							}
							num2 = GetFloat(dictionary3, "time", 0f);
							deformTimeline.SetFrame(num78, num2, vertices);
							ReadCurve(dictionary3, deformTimeline, num78);
							num78++;
							skeletonData2 = null;
							num79 = num78;
							continue;
						}
						throw new InvalidCastException();
					}
					throw new NullReferenceException();
				}
				enumerator34.Dispose();
				throw new OutOfMemoryException();
			}
			throw deformTimeline;
			IL_303c:
			if (skin != null)
			{
				attachment = skin.GetAttachment(slotIndex2, (string)(object)dictionary3);
				if (attachment != null)
				{
					VertexAttachment vertexAttachment = attachment as VertexAttachment;
					if (vertexAttachment != null)
					{
						if (obj28 != null)
						{
							List<object> list5 = obj28 as List<object>;
							if (list5 == null)
							{
								throw new InvalidCastException();
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+28]");
						array3 = (float[])0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+28]");
							if ((nint)0 == 0)
							{
								throw new NullReferenceException();
							}
							object obj31 = array3.Length * 1431655766;
							int num89 = (int)((nint)obj31 >> 63);
							int num90 = (int)((nint)obj31 >> 32);
							int num91 = num90 + num89;
							num74 = num91 << 1;
							if (obj28 != null)
							{
								goto IL_3224;
							}
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11455 @ X0_v229 (Spine.Attachment)+28]");
							if ((nint)0 == 0)
							{
								throw new NullReferenceException();
							}
							num74 = array3.Length;
							if (obj28 != null)
							{
								goto IL_3224;
							}
						}
						throw new NullReferenceException();
					}
					throw new InvalidCastException();
				}
				if (obj28 != null)
				{
					List<object> list6 = obj28 as List<object>;
					if (list6 == null)
					{
						throw new InvalidCastException();
					}
				}
				string message6 = "Deform attachment not found: " + (string)(object)dictionary3;
				Exception ex28 = new Exception(message6);
				throw ex28;
			}
			throw new NullReferenceException();
			IL_5787:
			exposedList2.TrimExcess();
			Animation item3 = new Animation(name, exposedList2, num31);
			skeletonData3.Animations.Add(item3);
			return;
			IL_4a58:
			NullReferenceException ex29 = new NullReferenceException();
			NullReferenceException ex30 = new NullReferenceException();
			throw new NullReferenceException();
			IL_4b91:
			InvalidCastException ex31 = new InvalidCastException();
			throw new IndexOutOfRangeException();
			IL_4acb:
			OutOfMemoryException ex32 = new OutOfMemoryException();
			goto IL_4ad9;
			IL_3afa:
			enumerator4.Dispose();
			return;
			IL_3d36:
			int[] array5 = new int[count];
			if ((int)(num54 & 0x80000000L) == 0)
			{
				int num92 = num54;
				bool flag40;
				do
				{
					int num93 = num92 - 1;
					array5[num92] = -1;
					flag40 = num92 > 0;
					num92 = num93;
				}
				while (flag40);
			}
			Dictionary<string, object> dictionary26 = (Dictionary<string, object>)dictionary3["offsets"];
			List<object> list7 = dictionary26 as List<object>;
			if (list7 != null)
			{
				object obj32 = slots.Count - (nint)dictionary26._entries;
				int[] array6 = new int[obj32];
				object enumerator35 = ((List<object>)(object)dictionary26).GetEnumerator();
				int num94 = 0;
				int num95 = 0;
				List<object>.Enumerator enumerator37 = default(List<object>.Enumerator);
				List<object>.Enumerator enumerator36 = enumerator37;
				object obj34 = default(object);
				string text14 = default(string);
				while (enumerator37.MoveNext())
				{
					if (dictionary3 != null)
					{
						Dictionary<string, object> dictionary27 = dictionary3 as Dictionary<string, object>;
						if (dictionary27 != null)
						{
							string text11 = (string)dictionary3["slot"];
							if (text11 == null || (object)text11.GetType() == typeof(string))
							{
								int num96 = skeletonData4.FindSlotIndex(text11);
								if (num96 + 1 != 0)
								{
									bool flag41 = num95 == num96;
									int num97 = num94;
									int num98 = num95;
									if (!flag41)
									{
										int num99;
										bool flag42;
										do
										{
											if (array6 != null)
											{
												if (num94 < array6.Length)
												{
													num99 = num94 + 1;
													int num100 = num95 + 1;
													array6[num94] = num95;
													flag42 = num96 != num100;
													num94 = num99;
													num95 = num100;
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										while (flag42);
										num97 = num99;
										num98 = num96;
									}
									object obj33 = dictionary3["offset"];
									if (obj33 != null)
									{
										float num101 = (float)((obj33 is float) ? obj33 : null);
										if (num101 != 0f)
										{
											Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
											int num102 = num98 + 1;
											float num103 = (((nint)obj34 != 2139095040) ? ((float)obj34) : -0f);
											if (array5 != null)
											{
												float num104 = num103 + (float)num98;
												if (num104 < (float)array5.Length)
												{
													array5[num104] = num98;
													num94 = num97;
													num95 = num102;
													num3 = float.PositiveInfinity;
													enumerator36 = (List<object>.Enumerator)obj34;
													continue;
												}
												throw new IndexOutOfRangeException();
											}
											throw new NullReferenceException();
										}
										throw new InvalidCastException();
									}
									throw new NullReferenceException();
								}
								object obj35 = dictionary3["slot"];
								string text12;
								string text13;
								if (obj35 == null)
								{
									text12 = "Slot not found: ";
									text13 = null;
								}
								else
								{
									object obj36 = obj35;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v12346 @ X8_v149+168] (should have been resolved before IL gen)");
									text12 = "Slot not found: ";
									text13 = text14;
								}
								string message7 = text12 + text13;
								Exception ex33 = new Exception(message7);
								throw ex33;
							}
							throw new InvalidCastException();
						}
						throw new InvalidCastException();
					}
					throw new NullReferenceException();
				}
				enumerator37.Dispose();
				OutOfMemoryException ex34 = new OutOfMemoryException();
				NullReferenceException ex35 = new NullReferenceException();
				NullReferenceException ex36 = new NullReferenceException();
				NullReferenceException ex37 = new NullReferenceException();
				NullReferenceException ex38 = new NullReferenceException();
				goto IL_4b39;
			}
			InvalidCastException ex39 = new InvalidCastException();
			NullReferenceException ex40 = new NullReferenceException();
			NullReferenceException ex41 = new NullReferenceException();
			IndexOutOfRangeException ex42 = new IndexOutOfRangeException();
			NullReferenceException ex43 = new NullReferenceException();
			NullReferenceException ex44 = new NullReferenceException();
			NullReferenceException ex45 = new NullReferenceException();
			throw new NullReferenceException();
			IL_3a55:
			InvalidCastException ex46 = new InvalidCastException();
			num33 = (int)typeof(Dictionary<string, object>);
			ex12 = (NullReferenceException)(object)ex46;
			num34 = num47;
			goto IL_4bd7;
			IL_3ab0:
			ex12 = new NullReferenceException();
			num33 = (int)text5;
			num34 = num47;
			goto IL_4bd7;
			IL_4bd7:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			DrawOrderTimeline drawOrderTimeline4 = default(DrawOrderTimeline);
			DrawOrderTimeline drawOrderTimeline3 = drawOrderTimeline4;
			enumerator.Dispose();
			if (num34 != 0)
			{
				OutOfMemoryException ex47 = new OutOfMemoryException();
				NullReferenceException ex48 = new NullReferenceException();
				throw new IndexOutOfRangeException();
			}
			if (num33 == 1)
			{
				((Dictionary<string, object>.Enumerator*)drawOrderTimeline3)->Dispose();
				object obj37 = default(object);
				((Dictionary<string, object>.Enumerator*)obj37)->Dispose();
				enumerator4.Dispose();
				bool flag43 = obj37 == null;
				skeletonData3 = skeletonData4;
				if (!flag43)
				{
					throw new OutOfMemoryException();
				}
				goto IL_53c4;
			}
			enumerator4.Dispose();
			nint num105 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			object obj38 = obj11;
			IntPtr intPtr2 = num13;
			float num107 = default(float);
			float num106 = num107;
			float num109 = default(float);
			float num108 = num109;
			float num111 = default(float);
			float num110 = num111;
			float num112 = num20;
			float num113 = softness;
			float num114 = num21;
			SkeletonData skeletonData5 = skeletonData2;
			float num115 = num3;
			float num116 = num2;
			IntPtr intPtr3 = num32;
			IntPtr intPtr4 = num105;
			OutOfMemoryException ex49 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_4ad9:
			throw new InvalidCastException();
			IL_018e:
			if (text4 != null)
			{
				List<object> list8 = text4 as List<object>;
				if (list8 == null)
				{
					throw new InvalidCastException();
				}
			}
			switch (text5)
			{
			case "attachment":
				if (text4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					AttachmentTimeline attachmentTimeline = new AttachmentTimeline(0);
					if (attachmentTimeline != null)
					{
						attachmentTimeline.slotIndex = slotIndex;
						object enumerator40 = ((List<object>)(object)text4).GetEnumerator();
						int num122 = 0;
						List<object>.Enumerator enumerator41 = default(List<object>.Enumerator);
						num2 = (float)enumerator41;
						while (enumerator41.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary29 = dictionary3 as Dictionary<string, object>;
								if (dictionary29 == null)
								{
									throw new InvalidCastException();
								}
							}
							num2 = GetFloat(dictionary3, "time", 0f);
							if (dictionary3 != null)
							{
								string text16 = (string)dictionary3["name"];
								if (text16 == null || (object)text16.GetType() == typeof(string))
								{
									int num123 = num122 + 1;
									attachmentTimeline.SetFrame(num122, num2, text16);
									skeletonData2 = null;
									num122 = num123;
									continue;
								}
								throw new InvalidCastException();
							}
							throw new NullReferenceException();
						}
						enumerator41.Dispose();
						throw new OutOfMemoryException();
					}
					throw attachmentTimeline;
				}
				throw new NullReferenceException();
			case "color":
				if (text4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					ColorTimeline colorTimeline = new ColorTimeline(0);
					if (colorTimeline != null)
					{
						colorTimeline.slotIndex = slotIndex;
						object enumerator38 = ((List<object>)(object)text4).GetEnumerator();
						int num117 = 0;
						List<object>.Enumerator enumerator39 = default(List<object>.Enumerator);
						num2 = (float)enumerator39;
						while (enumerator39.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary28 = dictionary3 as Dictionary<string, object>;
								if (dictionary28 == null)
								{
									throw new InvalidCastException();
								}
							}
							num2 = GetFloat(dictionary3, "time", 0f);
							if (dictionary3 != null)
							{
								string text15 = (string)dictionary3["color"];
								if (text15 == null || (object)text15.GetType() == typeof(string))
								{
									float num118 = ToColor(text15, 0);
									float num119 = ToColor(text15, 1);
									float num120 = ToColor(text15, 2);
									float num121 = ToColor(text15, 3);
									colorTimeline.SetFrame(num117, num2, num118, num119, num120, num121);
									ReadCurve(dictionary3, colorTimeline, num117);
									num117++;
									num20 = num120;
									softness = num119;
									num21 = num121;
									num3 = num118;
									continue;
								}
								throw new InvalidCastException();
							}
							throw new NullReferenceException();
						}
						enumerator39.Dispose();
						throw new OutOfMemoryException();
					}
					throw colorTimeline;
				}
				throw new NullReferenceException();
			case "twoColor":
				if (text4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5340 @ stack_-E8 (System.String)+18]");
					TwoColorTimeline twoColorTimeline = new TwoColorTimeline(0);
					if (twoColorTimeline != null)
					{
						twoColorTimeline.slotIndex = slotIndex;
						object enumerator42 = ((List<object>)(object)text4).GetEnumerator();
						int num124 = 0;
						List<object>.Enumerator enumerator43 = default(List<object>.Enumerator);
						num2 = (float)enumerator43;
						while (enumerator43.MoveNext())
						{
							if (dictionary3 != null)
							{
								Dictionary<string, object> dictionary30 = dictionary3 as Dictionary<string, object>;
								if (dictionary30 == null)
								{
									throw new InvalidCastException();
								}
							}
							num2 = GetFloat(dictionary3, "time", 0f);
							if (dictionary3 != null)
							{
								string text17 = (string)dictionary3["light"];
								if (text17 == null || (object)text17.GetType() == typeof(string))
								{
									string text18 = (string)dictionary3["dark"];
									if (text18 == null || (object)text18.GetType() == typeof(string))
									{
										float num125 = ToColor(text17, 0);
										float num126 = ToColor(text17, 1);
										float num127 = ToColor(text17, 2);
										float num128 = ToColor(text17, 3);
										num109 = ToColor(text18, 0, 6);
										num107 = ToColor(text18, 1, 6);
										num111 = ToColor(text18, 2, 6);
										twoColorTimeline.SetFrame(num124, num2, num125, num126, num127, num128, num109, num107, num111);
										ReadCurve(dictionary3, twoColorTimeline, num124);
										num124++;
										num20 = num127;
										softness = num126;
										num21 = num128;
										num3 = num125;
										continue;
									}
									throw new InvalidCastException();
								}
								throw new InvalidCastException();
							}
							throw new NullReferenceException();
						}
						enumerator43.Dispose();
						throw new OutOfMemoryException();
					}
					throw twoColorTimeline;
				}
				throw new NullReferenceException();
			default:
			{
				string[] array7 = new string[5];
				if (array7 == null)
				{
					throw new NullReferenceException();
				}
				if (array7.Length == 0)
				{
					throw new IndexOutOfRangeException();
				}
				array7[0] = "Invalid timeline type for a slot: ";
				if (array7.Length == 1)
				{
					throw new IndexOutOfRangeException();
				}
				array7[1] = text5;
				bool flag44 = array7.Length < 2;
				bool flag45 = !flag44;
				object obj39 = array7.Length - 2;
				bool flag46 = obj39 == null;
				bool flag47 = !flag45;
				if (!(flag47 || flag46))
				{
					array7[2] = " (";
					if (array7.Length == 3)
					{
						throw new IndexOutOfRangeException();
					}
					array7[3] = text3;
					bool flag48 = array7.Length < 4;
					bool flag49 = !flag48;
					object obj40 = array7.Length - 4;
					bool flag50 = obj40 == null;
					bool flag51 = !flag49;
					if (!(flag51 || flag50))
					{
						array7[4] = ")";
						string message8 = string.Concat(array7);
						Exception ex50 = new Exception(message8);
						throw ex50;
					}
					throw new IndexOutOfRangeException();
				}
				throw new IndexOutOfRangeException();
			}
			}
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0x154C764", Offset = "0x154C764", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv120 = System.Single;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv159 = System.String;\n\tv160 = \"il2cpp_codegen_initialize_runtime_metadata\"(v159, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv173 = \"c2\";\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv230 = \"curve\";\n\tv231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv243 = \"c4\";\n\tv244 = \"il2cpp_codegen_initialize_runtime_metadata\"(v243, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv252 = \"c3\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v252, timeline, frameIndex, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37BA3]) = v46;\nL_0035:\n\tv58 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(valueMap, \"curve\");\n\tv123 = v58 == 0;\n\tif (v123) goto L_0097;\n\tv108 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(valueMap, \"curve\");\n\tv175 = v108 == 0;\n\tif (v175) goto L_0055;\n\tv83 = *([v108 @ X0_v10]) == System.String;\n\tif (v83) goto L_00A6;\nL_0055:\n\tv241 = Spine.SkeletonJson::GetFloat(valueMap, \"c2\", 0f);\n\tv250 = Spine.SkeletonJson::GetFloat(valueMap, \"c3\", 1f);\n\tv64 = Spine.SkeletonJson::GetFloat(valueMap, \"c4\", 1f);\n\tv126 = v126_asT == 0;\n\tif (v126) goto L_00AA;\n\tv261 = \"il2cpp_vm_object_unbox\"(v108, System.Single, Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v64, v36, v37, v38, v39, v40, v41, v42);\n\tSpine.CurveTimeline::SetCurve(timeline, frameIndex, *([v261 @ X0_v15]), v241, v250, v64);\n\treturn;\nL_0097:\n\treturn;\nL_00A6:\n\tSpine.CurveTimeline::SetStepped(timeline, frameIndex);\n\treturn;\n\tthrow System.NullReferenceException;\nL_00AA:\n\tthrow System.InvalidCastException;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ReadCurve(Dictionary<string, object> valueMap, CurveTimeline timeline, int frameIndex)
		{
			//IL_00e1: Expected F4, but got O
			//IL_012c: Expected F4, but got O
			if (!valueMap.ContainsKey("curve"))
			{
				return;
			}
			object obj = valueMap["curve"];
			if (obj == null || obj != typeof(string))
			{
				float cy = GetFloat(valueMap, "c2", 0f);
				float cx = GetFloat(valueMap, "c3", 1f);
				float cy2 = GetFloat(valueMap, "c4", 1f);
				float num = (float)((obj is float) ? obj : null);
				if (num == 0f)
				{
					throw new InvalidCastException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				timeline.SetCurve(frameIndex, (float)obj2, cy, cx, cy2);
			}
			else
			{
				timeline.SetStepped(frameIndex);
			}
		}

		[Token(Token = "0x60003E0")]
		[Address(RVA = "0x154C3A0", Offset = "0x154C3A0", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv146 = Il2CppMethodInfo;\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv199 = System.Collections.Generic.List`1<System.Object>;\n\tv200 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv263 = System.Single[];\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv306 = System.Single;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, name, methodInfo, v33, v34, v35, v36, v37, scale, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37BA4]) = v48;\nL_002E:\n\tv58 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tgoto L_FFFFFFFF;\n\tv277 = v277_asT == 0;\n\tif (v277) goto L_00FD;\n\t// 86 NewArr v311 @ X0_v14 (System.Single[]), typeof(System.Single[]), [v58 @ X0_v12+18]\n\tv322 = scale != 1f;\n\tif (v322) goto L_00B3;\n\tv385 = *([v58 @ X0_v12+18]) < 1;\n\tif (v385) goto L_00F8;\nL_007A:\n\tv126 = System.Collections.Generic.List`1<System.Object>::get_Item(v58, v142);\n\tv155 = v155_asT == 0;\n\tif (v155) goto L_00FA;\n\tv252 = \"il2cpp_vm_object_unbox\"(v126, System.Single, Il2CppMethodInfo, v33, v34, v35, v36, v37, v69, v38, v39, v40, v41, v42, v43, v44);\n\tv69 = *([v252 @ X0_v24]);\n\tv311[v142 @ X21_v12 (System.Int32)] = *([v252 @ X0_v24]);\n\tv142 = v142 + 1;\n\tv406 = *([v58 @ X0_v12+18]) != v142;\n\tif (v406) goto L_007A;\n\tgoto L_00F8;\nL_00B3:\n\tv396 = *([v58 @ X0_v12+18]) < 1;\n\tif (v396) goto L_00F8;\nL_00BE:\n\tv127 = System.Collections.Generic.List`1<System.Object>::get_Item(v58, v143);\n\tv156 = v156_asT == 0;\n\tif (v156) goto L_00FA;\n\tv253 = \"il2cpp_vm_object_unbox\"(v127, System.Single, Il2CppMethodInfo, v33, v34, v35, v36, v37, v70, v38, v39, v40, v41, v42, v43, v44);\n\tv70 = *([v253 @ X0_v20]) * scale;\n\tv311[v143 @ X21_v9 (System.Int32)] = v70;\n\tv143 = v143 + 1;\n\tv405 = *([v58 @ X0_v12+18]) != v143;\n\tif (v405) goto L_00BE;\nL_00F8:\n\treturn v311;\n\tv144 = new System.NullReferenceException();\nL_00FA:\n\tv197 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_00FD:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float[] GetFloatArray(Dictionary<string, object> map, string name, float scale)
		{
			//IL_0199: Expected F4, but got O
			//IL_00ca: Expected F4, but got O
			//IL_0105: Expected F4, but got O
			//IL_0116: Expected F4, but got O
			object obj = map[name];
			List<object> list = obj as List<object>;
			float[] array;
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v12+18]");
				array = new float[0];
				if (scale == 1f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v12+18]");
					if ((nint)0 < (nint)1)
					{
						goto IL_0221;
					}
					float num = 1f;
					int num2 = 0;
					object obj3 = default(object);
					while (true)
					{
						object obj2 = ((List<object>)obj)[num2];
						float num3 = (float)((obj2 is float) ? obj2 : null);
						if (num3 == 0f)
						{
							break;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						num = (float)obj3;
						array[num2] = (float)obj3;
						num2++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v12+18]");
						if ((nint)0 != num2)
						{
							continue;
						}
						goto IL_0221;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v12+18]");
					if ((nint)0 < (nint)1)
					{
						goto IL_0221;
					}
					float num4 = 1f;
					int num5 = 0;
					object obj5 = default(object);
					while (true)
					{
						object obj4 = ((List<object>)obj)[num5];
						float num6 = (float)((obj4 is float) ? obj4 : null);
						if (num6 == 0f)
						{
							break;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						num4 = (float)obj5 * scale;
						array[num5] = num4;
						num5++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X0_v12+18]");
						if ((nint)0 != num5)
						{
							continue;
						}
						goto IL_0221;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new IndexOutOfRangeException();
			}
			return (float[])(object)new InvalidCastException();
			IL_0221:
			return array;
		}

		[Token(Token = "0x60003E1")]
		[Address(RVA = "0x154C5BC", Offset = "0x154C5BC", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv52 = System.Int32[];\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv135 = Il2CppMethodInfo;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv180 = Il2CppMethodInfo;\n\tv181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv238 = System.Collections.Generic.List`1<System.Object>;\n\tv239 = \"il2cpp_codegen_initialize_runtime_metadata\"(v238, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv285 = System.Single;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v285, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A37BA5]) = v49;\nL_002E:\n\tv59 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tgoto L_FFFFFFFF;\n\tv252 = v252_asT == 0;\n\tif (v252) goto L_00C0;\n\t// 86 NewArr v290 @ X0_v14 (System.Int32[]), typeof(System.Int32[]), [v59 @ X0_v12+18]\n\tv301 = *([v59 @ X0_v12+18]) < 1;\n\tif (v301) goto L_00BB;\nL_0070:\n\tv120 = System.Collections.Generic.List`1<System.Object>::get_Item(v59, v132);\n\tv148 = v148_asT == 0;\n\tif (v148) goto L_00BD;\n\tv229 = \"il2cpp_vm_object_unbox\"(v120, System.Single, Il2CppMethodInfo, v33, v34, v35, v36, v37, *([v229 @ X0_v20]), 0x7F800000, v40, v41, v42, v43, v44, v45);\n\tv363 = *([v229 @ X0_v20]) != 0x7F800000;\n\tif (v363) goto L_FFFFFFFF;\n\tgoto L_00A2;\nL_00A2:\n\tv290[v132 @ X21_v9 (System.Int32)] = v381;\n\tv132 = v132 + 1;\n\tv371 = *([v59 @ X0_v12+18]) != v132;\n\tif (v371) goto L_0070;\nL_00BB:\n\treturn v290;\n\tv133 = new System.NullReferenceException();\nL_00BD:\n\tv178 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_00C0:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 155 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int[] GetIntArray(Dictionary<string, object> map, string name)
		{
			//IL_009f: Expected F4, but got O
			//IL_0108: Expected I4, but got O
			object obj = map[name];
			List<object> list = obj as List<object>;
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v12+18]");
				int[] array = new int[0];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v12+18]");
				if ((nint)0 >= (nint)1)
				{
					int num = 0;
					object obj3 = default(object);
					do
					{
						object obj2 = ((List<object>)obj)[num];
						float num2 = (float)((obj2 is float) ? obj2 : null);
						if (num2 != 0f)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							int num3 = (((nint)obj3 != 2139095040) ? ((int)obj3) : int.MinValue);
							array[num] = num3;
							num++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v12+18]");
							continue;
						}
						InvalidCastException ex = new InvalidCastException();
						throw new IndexOutOfRangeException();
					}
					while ((nint)0 != num);
				}
				return array;
			}
			return (int[])(object)new InvalidCastException();
		}

		[Token(Token = "0x60003E2")]
		[Address(RVA = "0x1545F0C", Offset = "0x1545F0C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, methodInfo, v25, v26, v27, v28, v29, defaultValue, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, name, methodInfo, v25, v26, v27, v28, v29, defaultValue, v30, v31, v32, v33, v34, v35, v36);\n\tv63 = System.Single;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, name, methodInfo, v25, v26, v27, v28, v29, defaultValue, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37BA6]) = v40;\nL_0021:\n\tv50 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(map, name);\n\tv65 = v50 == 0;\n\tif (v65) goto L_0047;\n\tv56 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tv68 = v68_asT == 0;\n\tif (v68) goto L_0049;\n\tv119 = \"il2cpp_vm_object_unbox\"(v56, System.Single, Il2CppMethodInfo, v25, v26, v27, v28, v29, defaultValue, v30, v31, v32, v33, v34, v35, v36);\n\tv121 = *([v119 @ X0_v11]);\nL_0047:\n\treturn v121;\n\tv61 = new System.NullReferenceException();\nL_0049:\n\tthrow System.InvalidCastException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float GetFloat(Dictionary<string, object> map, string name, float defaultValue)
		{
			//IL_005e: Expected F4, but got O
			//IL_0094: Expected F4, but got O
			bool flag = map.ContainsKey(name);
			bool flag2 = !flag;
			float result = defaultValue;
			if (!flag2)
			{
				object obj = map[name];
				float num = (float)((obj is float) ? obj : null);
				if (num == 0f)
				{
					throw new InvalidCastException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				result = (float)obj2;
			}
			return result;
		}

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0x15463E8", Offset = "0x15463E8", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv63 = System.Single;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37BA7]) = v40;\nL_0021:\n\tv50 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(map, name);\n\tv65 = v50 == 0;\n\tif (v65) goto L_005A;\n\tv56 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tv68 = v68_asT == 0;\n\tif (v68) goto L_005C;\n\tv135 = \"il2cpp_vm_object_unbox\"(v56, System.Single, Il2CppMethodInfo, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv108 = *([v135 @ X0_v12]) != 0x7F800000;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_005A:\n\treturn v137;\n\tv61 = new System.NullReferenceException();\nL_005C:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetInt(Dictionary<string, object> map, string name, int defaultValue)
		{
			//IL_005e: Expected F4, but got O
			//IL_00d5: Expected I4, but got O
			//IL_00c2: Expected I4, but got O
			bool flag = map.ContainsKey(name);
			bool flag2 = !flag;
			int result = defaultValue;
			if (!flag2)
			{
				object obj = map[name];
				float num = (float)((obj is float) ? obj : null);
				if (num == 0f)
				{
					InvalidCastException ex = new InvalidCastException();
					return (int)ex;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				result = (((nint)obj2 != 2139095040) ? ((int)obj2) : int.MinValue);
			}
			return result;
		}

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0x15460A4", Offset = "0x15460A4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = System.Boolean;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv63 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37BA8]) = v40;\nL_0021:\n\tv50 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(map, name);\n\tv65 = v50 == 0;\n\tif (v65) goto L_0052;\n\tv56 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tv68 = ~v68_asT;\n\tif (v68) goto L_0054;\n\tv128 = \"il2cpp_vm_object_unbox\"(v56, System.Boolean, Il2CppMethodInfo, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv117 = *([v128 @ X0_v12]) == 0;\n\tv107 = ~v117;\nL_0052:\n\treturn v130;\n\tv61 = new System.NullReferenceException();\nL_0054:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool GetBoolean(Dictionary<string, object> map, string name, bool defaultValue)
		{
			//IL_005e: Expected I4, but got O
			//IL_00bb: Expected I4, but got O
			bool flag = map.ContainsKey(name);
			bool flag2 = !flag;
			bool result = defaultValue;
			if (!flag2)
			{
				object obj = map[name];
				if ((int)((obj is bool) ? obj : null) == 0)
				{
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj2 = default(object);
				bool flag3 = obj2 == null;
				bool flag4 = !flag3;
				result = flag4;
			}
			return result;
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0x1545FDC", Offset = "0x1545FDC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv53 = System.String;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, name, defaultValue, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37BA9]) = v40;\nL_0021:\n\tv50 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(map, name);\n\tv55 = v50 == 0;\n\tif (v55) goto L_0044;\n\tv88 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(map, name);\n\tv90 = v88 == 0;\n\tif (v90) goto L_0044;\n\tv58 = *([v88 @ X0_v11 (System.String)]) != System.String;\n\tif (v58) goto L_0047;\nL_0044:\n\treturn v114;\n\tthrow System.NullReferenceException;\nL_0047:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GetString(Dictionary<string, object> map, string name, string defaultValue)
		{
			bool flag = map.ContainsKey(name);
			bool flag2 = !flag;
			string result = defaultValue;
			if (!flag2)
			{
				string text = (string)map[name];
				bool flag3 = text == null;
				result = text;
				if (!flag3)
				{
					bool flag4 = (object)text.GetType() != typeof(string);
					result = text;
					if (flag4)
					{
						return (string)(object)new InvalidCastException();
					}
				}
			}
			return result;
		}

		[Token(Token = "0x60003E6")]
		[Address(RVA = "0x15462A0", Offset = "0x15462A0", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv23 = System.Convert;\n\tv24 = \"il2cpp_codegen_initialize_runtime_metadata\"(v23, colorIndex, expectedLength, methodInfo, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37BAA]) = v40;\nL_0021:\n\tv52 = hexString._stringLength != expectedLength;\n\tif (v52) goto L_0044;\n\tv56 = colorIndex << 1;\n\tv60 = System.String::Substring(hexString, v56, 2);\n\tgoto L_0035;\n\tv93 = v84;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v93, v56, v57, v59, v26, v27, v28, v29, returnVal2, v31, v32, v33, v34, v35, v36, v37);\nL_0035:\n\tv99 = System.Convert::ToInt32(v60, 0x10);\n\treturnVal1 = v99 / 0x437F0000;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0044:\n\tv83 = System.Int32::ToString(&expectedLength @ X2 (System.Int32));\n\tv118 = System.String::Concat(\"Color hexidecimal length must be \", v83, \", recieved: \", hexString);\n\tv153 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v153, v118, \"hexString\");\n\tthrow v153;\n\treturn returnVal2;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float ToColor(string hexString, int colorIndex, int expectedLength = 8)
		{
			if (hexString.Length == expectedLength)
			{
				int startIndex = colorIndex << 1;
				string value = hexString.Substring(startIndex, 2);
				int num = Convert.ToInt32(value, 16);
				return (float)num / 255f;
			}
			int num2 = default(int);
			string text = num2.ToString();
			string message = "Color hexidecimal length must be " + text + ", recieved: " + hexString;
			ArgumentException ex = new ArgumentException(message, "hexString");
			throw ex;
		}
	}
}
