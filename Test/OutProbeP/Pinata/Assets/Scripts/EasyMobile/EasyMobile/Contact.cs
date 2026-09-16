using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000063")]
	public class Contact
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000132")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000524")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000525")]
			public static Func<SerializableKeyValuePair<string, string>, StringStringKeyValuePair> _003C_003E9__29_0;

			[Token(Token = "0x4000526")]
			public static Func<SerializableKeyValuePair<string, string>, StringStringKeyValuePair> _003C_003E9__32_0;

			[Token(Token = "0x4000527")]
			public static Func<KeyValuePair<string, string>, string> _003C_003E9__47_0;

			[Token(Token = "0x60009A8")]
			[Address(RVA = "0xA54A9C", Offset = "0xA54A9C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ED66C0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021F9A]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Contact+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60009A9")]
			[Address(RVA = "0xA54B00", Offset = "0xA54B00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal StringStringKeyValuePair _003Cset_PhoneNumbers_003Eb__29_0(SerializableKeyValuePair<string, string> pair)
			{
				return new StringStringKeyValuePair(pair.Key, pair.Value);
			}

			internal StringStringKeyValuePair _003Cset_Emails_003Eb__32_0(SerializableKeyValuePair<string, string> pair)
			{
				return new StringStringKeyValuePair(pair.Key, pair.Value);
			}

			internal string _003CDictionaryToString_003Eb__47_0(KeyValuePair<string, string> x)
			{
				//IL_0036: Expected O, but got I
				object arg = (((object)x != null) ? ((object)x) : ((object)"null"));
				IntPtr intPtr = default(IntPtr);
				object arg2 = ((intPtr != (IntPtr)0) ? ((object)(long)intPtr) : "null");
				return $"[{arg}, {arg2}]";
			}
		}

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x10")]
		private string id;

		[SerializeField]
		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x18")]
		private string firstName;

		[SerializeField]
		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x20")]
		private string middleName;

		[SerializeField]
		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x28")]
		private string lastName;

		[SerializeField]
		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x30")]
		private string company;

		[SerializeField]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x38")]
		private DateTime birthday;

		[SerializeField]
		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x40")]
		private StringStringKeyValuePair[] phoneNumbers;

		[SerializeField]
		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x48")]
		private StringStringKeyValuePair[] emails;

		[SerializeField]
		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x50")]
		private Texture2D photo;

		[CompilerGenerated]
		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x58")]
		private bool _003CIsPhotoLoaded_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x59")]
		private bool _003CIsLoadingPhoto_003Ek__BackingField;

		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x60")]
		internal Func<Texture2D> loadPhotoFunc;

		[Token(Token = "0x17000169")]
		public string Id
		{
			[Token(Token = "0x60004E3")]
			[Address(RVA = "0xA54024", Offset = "0xA54024", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
			[Token(Token = "0x60004E4")]
			[Address(RVA = "0xA5402C", Offset = "0xA5402C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = value;\n\treturn;\n")]
			internal set
			{
				id = value;
			}
		}

		[Token(Token = "0x1700016A")]
		public string FirstName
		{
			[Token(Token = "0x60004E5")]
			[Address(RVA = "0xA54034", Offset = "0xA54034", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.firstName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FirstName;
			}
			[Token(Token = "0x60004E6")]
			[Address(RVA = "0xA5403C", Offset = "0xA5403C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.firstName = value;\n\treturn;\n")]
			internal set
			{
				firstName = value;
			}
		}

		[Token(Token = "0x1700016B")]
		public string MiddleName
		{
			[Token(Token = "0x60004E7")]
			[Address(RVA = "0xA54044", Offset = "0xA54044", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.middleName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MiddleName;
			}
			[Token(Token = "0x60004E8")]
			[Address(RVA = "0xA5404C", Offset = "0xA5404C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.middleName = value;\n\treturn;\n")]
			internal set
			{
				middleName = value;
			}
		}

		[Token(Token = "0x1700016C")]
		public string LastName
		{
			[Token(Token = "0x60004E9")]
			[Address(RVA = "0xA54054", Offset = "0xA54054", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lastName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastName;
			}
			[Token(Token = "0x60004EA")]
			[Address(RVA = "0xA5405C", Offset = "0xA5405C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lastName = value;\n\treturn;\n")]
			internal set
			{
				lastName = value;
			}
		}

		[Token(Token = "0x1700016D")]
		public string Company
		{
			[Token(Token = "0x60004EB")]
			[Address(RVA = "0xA54064", Offset = "0xA54064", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.company;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Company;
			}
			[Token(Token = "0x60004EC")]
			[Address(RVA = "0xA5406C", Offset = "0xA5406C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.company = value;\n\treturn;\n")]
			internal set
			{
				company = value;
			}
		}

		[Token(Token = "0x1700016E")]
		public DateTime? Birthday
		{
			[Token(Token = "0x60004ED")]
			[Address(RVA = "0xA54074", Offset = "0xA54074", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEB8F8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F90]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = System.DateTime::op_Equality(this.birthday, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_002E;\n\tgoto L_0039;\nL_002E:\n\tv70 = 0;\n\tv68 = System.Nullable`1<System.DateTime>::.ctor(&v70 @ stack_-30_v1 (System.Nullable`1<System.DateTime>), this.birthday);\nL_0039:\n\treturn v70;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				DateTime? result;
				if (birthday == default(DateTime))
				{
					result = null;
				}
				else
				{
					result = null;
					result = birthday;
					result = null;
				}
				return result;
			}
			[Token(Token = "0x60004EE")]
			[Address(RVA = "0xA5411C", Offset = "0xA5411C", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv25 = *([1ECC508]);\n\tv26 = *([v25 @ X8_v10]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021F91]) = v43;\nL_0017:\n\tv44 = methodInfo & 0xFF;\n\tv45 = v44 == 0;\n\tif (v45) goto L_002A;\n\tv62 = 0x115B5D8(&value @ X1 (System.Nullable`1<System.DateTime>), Il2CppMethodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0021:\n\tthis.birthday = v62;\n\treturn;\nL_002A:\n\tv52 = this == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0021;\n\tthrow System.NullReferenceException;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				IntPtr intPtr = default(IntPtr);
				DateTime dateTime = default(DateTime);
				if ((uint)((ulong)(long)intPtr & 0xFFuL) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115B5D8 (inside System.Nullable`1::Unbox +0xC0)");
				}
				else
				{
					bool flag = this == null;
					bool flag2 = !flag;
					dateTime = default(DateTime);
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				birthday = dateTime;
			}
		}

		[Token(Token = "0x1700016F")]
		public KeyValuePair<string, string>[] PhoneNumbers
		{
			[Token(Token = "0x60004EF")]
			[Address(RVA = "0xA541A8", Offset = "0xA541A8", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEFBA0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F92]) = v38;\nL_0014:\n\tv40 = this.phoneNumbers == 0;\n\tif (v40) goto L_0025;\n\tv44 = EasyMobile.Internal.SerializableKeyValuePairExtension::ToKeyValuePairs(this.phoneNumbers);\n\tv50 = v44 == 0;\n\tif (v50) goto L_0025;\n\treturnVal1 = System.Linq.Enumerable::ToArray(v44);\nL_0025:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = phoneNumbers == null;
				KeyValuePair<string, string>[] result = (KeyValuePair<string, string>[])(object)phoneNumbers;
				if (!flag)
				{
					IEnumerable<KeyValuePair<string, string>> enumerable = phoneNumbers.ToKeyValuePairs();
					bool flag2 = enumerable == null;
					result = (KeyValuePair<string, string>[])enumerable;
					if (!flag2)
					{
						result = enumerable.ToArray();
					}
				}
				return result;
			}
			[Token(Token = "0x60004F0")]
			[Address(RVA = "0xA54214", Offset = "0xA54214", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB7420]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021F93]) = v45;\nL_0017:\n\tv46 = value == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tv51 = EasyMobile.Internal.SerializableKeyValuePairExtension::ToSerializableKeyValuePairs(value);\n\tv76 = v51 == 0;\n\tif (v76) goto L_005F;\n\tgoto L_002F;\n\tv101 = *([v97 @ X0_v7 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_002F;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v97, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv105 = EasyMobile.Contact+<>c;\nL_002F:\n\tv74 = v108.<>9__29_0;\n\tv110 = v108.<>9__29_0 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0054;\n\tgoto L_0042;\n\tv135 = *([v104 @ X0_v8 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0042;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v104, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv151 = EasyMobile.Contact+<>c;\n\tv142 = *([v151 @ X8_v22+B8]);\nL_0042:\n\tv124 = new System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<System.String, System.String>, EasyMobile.Internal.StringStringKeyValuePair>();\n\tSystem.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<System.String, System.String>, EasyMobile.Internal.StringStringKeyValuePair>::.ctor(v124, v141.<>9, Il2CppMethodInfo);\n\tv128.<>9__29_0 = v124;\nL_0054:\n\tv134 = System.Linq.Enumerable::Select(v51, v74);\n\tv83 = System.Linq.Enumerable::ToArray(v134);\n\tv150 = this == 0;\n\tv68 = ~v150;\n\tif (v68) goto L_005F;\n\tthrow System.NullReferenceException;\nL_005F:\n\tthis.phoneNumbers = v83;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				StringStringKeyValuePair[] array;
				if (value != null)
				{
					IEnumerable<SerializableKeyValuePair<string, string>> enumerable = value.ToSerializableKeyValuePairs();
					bool flag = enumerable == null;
					array = (StringStringKeyValuePair[])enumerable;
					if (!flag)
					{
						Func<SerializableKeyValuePair<string, string>, StringStringKeyValuePair> selector = _003C_003Ec._003C_003E9__29_0;
						if (_003C_003Ec._003C_003E9__29_0 == null)
						{
							selector = (_003C_003Ec._003C_003E9__29_0 = (SerializableKeyValuePair<string, string> pair) => new StringStringKeyValuePair(pair.Key, pair.Value));
						}
						IEnumerable<StringStringKeyValuePair> source = enumerable.Select(selector);
						array = source.ToArray();
						if (this == null)
						{
							throw new NullReferenceException();
						}
					}
				}
				else
				{
					array = null;
				}
				phoneNumbers = array;
			}
		}

		[Token(Token = "0x17000170")]
		public KeyValuePair<string, string>[] Emails
		{
			[Token(Token = "0x60004F1")]
			[Address(RVA = "0xA54354", Offset = "0xA54354", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EFCA58]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F94]) = v38;\nL_0014:\n\tv40 = this.emails == 0;\n\tif (v40) goto L_0025;\n\tv44 = EasyMobile.Internal.SerializableKeyValuePairExtension::ToKeyValuePairs(this.emails);\n\tv50 = v44 == 0;\n\tif (v50) goto L_0025;\n\treturnVal1 = System.Linq.Enumerable::ToArray(v44);\nL_0025:\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = emails == null;
				KeyValuePair<string, string>[] result = (KeyValuePair<string, string>[])(object)emails;
				if (!flag)
				{
					IEnumerable<KeyValuePair<string, string>> enumerable = emails.ToKeyValuePairs();
					bool flag2 = enumerable == null;
					result = (KeyValuePair<string, string>[])enumerable;
					if (!flag2)
					{
						result = enumerable.ToArray();
					}
				}
				return result;
			}
			[Token(Token = "0x60004F2")]
			[Address(RVA = "0xA543C0", Offset = "0xA543C0", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFCD70]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021F95]) = v45;\nL_0017:\n\tv46 = value == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tv51 = EasyMobile.Internal.SerializableKeyValuePairExtension::ToSerializableKeyValuePairs(value);\n\tv76 = v51 == 0;\n\tif (v76) goto L_005F;\n\tgoto L_002F;\n\tv101 = *([v97 @ X0_v7 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_002F;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v97, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv105 = EasyMobile.Contact+<>c;\nL_002F:\n\tv74 = v108.<>9__32_0;\n\tv110 = v108.<>9__32_0 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0054;\n\tgoto L_0042;\n\tv135 = *([v104 @ X0_v8 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0042;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v104, v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv151 = EasyMobile.Contact+<>c;\n\tv142 = *([v151 @ X8_v22+B8]);\nL_0042:\n\tv124 = new System.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<System.String, System.String>, EasyMobile.Internal.StringStringKeyValuePair>();\n\tSystem.Func`2<EasyMobile.Internal.SerializableKeyValuePair`2<System.String, System.String>, EasyMobile.Internal.StringStringKeyValuePair>::.ctor(v124, v141.<>9, Il2CppMethodInfo);\n\tv128.<>9__32_0 = v124;\nL_0054:\n\tv134 = System.Linq.Enumerable::Select(v51, v74);\n\tv83 = System.Linq.Enumerable::ToArray(v134);\n\tv150 = this == 0;\n\tv68 = ~v150;\n\tif (v68) goto L_005F;\n\tthrow System.NullReferenceException;\nL_005F:\n\tthis.emails = v83;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				StringStringKeyValuePair[] array;
				if (value != null)
				{
					IEnumerable<SerializableKeyValuePair<string, string>> enumerable = value.ToSerializableKeyValuePairs();
					bool flag = enumerable == null;
					array = (StringStringKeyValuePair[])enumerable;
					if (!flag)
					{
						Func<SerializableKeyValuePair<string, string>, StringStringKeyValuePair> selector = _003C_003Ec._003C_003E9__32_0;
						if (_003C_003Ec._003C_003E9__32_0 == null)
						{
							selector = (_003C_003Ec._003C_003E9__32_0 = (SerializableKeyValuePair<string, string> pair) => new StringStringKeyValuePair(pair.Key, pair.Value));
						}
						IEnumerable<StringStringKeyValuePair> source = enumerable.Select(selector);
						array = source.ToArray();
						if (this == null)
						{
							throw new NullReferenceException();
						}
					}
				}
				else
				{
					array = null;
				}
				emails = array;
			}
		}

		[Token(Token = "0x17000171")]
		public Texture2D Photo
		{
			[Token(Token = "0x60004F3")]
			[Address(RVA = "0xA54500", Offset = "0xA54500", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.<IsPhotoLoaded>k__BackingField;\n\tv12 = ~v11;\n\tif (v12) goto L_0011;\n\tEasyMobile.Contact::LoadPhoto(this);\nL_0011:\n\treturn this.photo;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!IsPhotoLoaded)
				{
					LoadPhoto();
				}
				return photo;
			}
			[Token(Token = "0x60004F4")]
			[Address(RVA = "0xA545DC", Offset = "0xA545DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.photo = value;\n\treturn;\n")]
			internal set
			{
				photo = value;
			}
		}

		[Token(Token = "0x17000172")]
		public bool IsPhotoLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x60004F5")]
			[Address(RVA = "0xA545E4", Offset = "0xA545E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsPhotoLoaded>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsPhotoLoaded;
			}
			[CompilerGenerated]
			[Token(Token = "0x60004F6")]
			[Address(RVA = "0xA545EC", Offset = "0xA545EC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsPhotoLoaded>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsPhotoLoaded_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000173")]
		public bool IsLoadingPhoto
		{
			[CompilerGenerated]
			[Token(Token = "0x60004F7")]
			[Address(RVA = "0xA545F8", Offset = "0xA545F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsLoadingPhoto>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsLoadingPhoto;
			}
			[CompilerGenerated]
			[Token(Token = "0x60004F8")]
			[Address(RVA = "0xA54600", Offset = "0xA54600", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsLoadingPhoto>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsLoadingPhoto_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60004F9")]
		[Address(RVA = "0xA54530", Offset = "0xA54530", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDC4E8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F96]) = v38;\nL_0014:\n\tv40 = ~this.<IsLoadingPhoto>k__BackingField;\n\tv41 = ~v40;\n\tif (v41) goto L_003A;\n\tv43 = this.loadPhotoFunc == 0;\n\tif (v43) goto L_003A;\n\tthis.<IsLoadingPhoto>k__BackingField = 1;\n\tv64 = System.Func`1<UnityEngine.Texture2D>::Invoke(this.loadPhotoFunc);\n\tthis.photo = v64;\n\tthis.<IsLoadingPhoto>k__BackingField = 0;\n\tgoto L_0032;\n\tv71 = *([v67 @ X0_v5+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0032;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, v63, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv49 = UnityEngine.Object::op_Inequality(v64, 0);\n\tthis.<IsPhotoLoaded>k__BackingField = v49;\nL_003A:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadPhoto()
		{
			if (!IsLoadingPhoto && loadPhotoFunc != null)
			{
				IsLoadingPhoto = true;
				Texture2D texture2D = (photo = loadPhotoFunc());
				IsLoadingPhoto = false;
				bool flag = texture2D != null;
				IsPhotoLoaded = flag;
			}
		}

		[Token(Token = "0x60004FA")]
		[Address(RVA = "0xA5460C", Offset = "0xA5460C", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EAD0A0]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021F97]) = v48;\nL_001C:\n\tv53 = EasyMobile.Contact::get_PhoneNumbers(this);\n\tv55 = EasyMobile.Contact::DictionaryToString(v53, v53);\n\tv58 = EasyMobile.Contact::get_Emails(this);\n\tv60 = EasyMobile.Contact::DictionaryToString(v58, v58);\n\t// 42 NewArr v67 @ X0_v9 (System.Object[]), typeof(System.Object[]), 8\n\tv82 = this.id != 0;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tv90 = v85 == 0;\n\tif (v90) goto L_004C;\n\t// 73 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v85 @ X24_v1 (System.String)\nL_004C:\n\tv287 = v67.Length;\n\tv149 = v67.Length == 0;\n\tif (v149) goto L_0158;\n\tv67[0] = v85;\n\tv161 = this.firstName != 0;\n\tif (v161) goto L_FFFFFFFF;\n\tgoto L_0061;\nL_0061:\n\tv415 = v181 == 0;\n\tif (v415) goto L_006A;\n\t// 102 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v181 @ X24_v6 (System.String)\n\tv287 = v67.Length;\nL_006A:\n\tv418 = v287 < 1;\n\tv250 = ~v418;\n\tv242 = v287 - 1;\n\tv226 = v242 == 0;\n\tv419 = ~v250;\n\tv163 = v419 | v226;\n\tif (v163) goto L_0158;\n\tv67[1] = v181;\n\tv186 = this.middleName != 0;\n\tif (v186) goto L_FFFFFFFF;\n\tgoto L_0088;\nL_0088:\n\tv423 = v182 == 0;\n\tif (v423) goto L_0091;\n\t// 141 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v182 @ X24_v7 (System.String)\n\tv287 = v67.Length;\nL_0091:\n\tv426 = v287 < 2;\n\tv251 = ~v426;\n\tv243 = v287 - 2;\n\tv227 = v243 == 0;\n\tv427 = ~v251;\n\tv164 = v427 | v227;\n\tif (v164) goto L_0158;\n\tv67[2] = v182;\n\tv187 = this.lastName != 0;\n\tif (v187) goto L_FFFFFFFF;\n\tgoto L_00AF;\nL_00AF:\n\tv431 = v183 == 0;\n\tif (v431) goto L_00B8;\n\t// 180 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v183 @ X24_v8 (System.String)\n\tv287 = v67.Length;\nL_00B8:\n\tv434 = v287 < 3;\n\tv252 = ~v434;\n\tv244 = v287 - 3;\n\tv228 = v244 == 0;\n\tv435 = ~v252;\n\tv165 = v435 | v228;\n\tif (v165) goto L_0158;\n\tv67[3] = v183;\n\tv188 = this.company != 0;\n\tif (v188) goto L_FFFFFFFF;\n\tgoto L_00D6;\nL_00D6:\n\tv439 = v184 == 0;\n\tif (v439) goto L_00DF;\n\t// 219 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v184 @ X24_v9 (System.String)\n\tv287 = v67.Length;\nL_00DF:\n\tv442 = v287 < 4;\n\tv253 = ~v442;\n\tv245 = v287 - 4;\n\tv229 = v245 == 0;\n\tv443 = ~v253;\n\tv166 = v443 | v229;\n\tif (v166) goto L_0158;\n\tv67[4] = v184;\n\tv445 = EasyMobile.Contact::get_Birthday(this);\n\tv446 = v261 & 0xFF;\n\tv449 = v446 == 0;\n\tif (v449) goto L_0107;\n\tv451 = EasyMobile.Contact::get_Birthday(this);\n\tv461 = System.Nullable`1<System.DateTime>::get_Value(&v451 @ X0_v38 (System.Nullable`1<System.DateTime>));\n\tv466 = 0xE96044(&v461 @ X0_v40 (System.DateTime), 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv477 = v466 == 0;\n\tv468 = ~v477;\n\tif (v468) goto L_010C;\n\tgoto L_010F;\nL_0107:\n\tv453 = \"empty\" == 0;\n\tif (v453) goto L_010F;\nL_010C:\n\t// 268 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v401 @ X23_v8 (System.String)\nL_010F:\n\tv290 = v67.Length;\n\tv473 = v67.Length < 5;\n\tv254 = ~v473;\n\tv246 = v67.Length - 5;\n\tv230 = v246 == 0;\n\tv474 = ~v254;\n\tv167 = v474 | v230;\n\tif (v167) goto L_0158;\n\tv67[5] = v282;\n\tv476 = v55 == 0;\n\tif (v476) goto L_0126;\n\t// 290 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v55 @ X0_v4 (System.String)\n\tv290 = v67.Length;\nL_0126:\n\tv480 = v290 < 6;\n\tv255 = ~v480;\n\tv247 = v290 - 6;\n\tv231 = v247 == 0;\n\tv481 = ~v255;\n\tv168 = v481 | v231;\n\tif (v168) goto L_0158;\n\tv67[6] = v55;\n\tv482 = v60 == 0;\n\tif (v482) goto L_013C;\n\t// 312 IsInst this @ X0 (EasyMobile.Contact), typeof(System.Object), v60 @ X0_v7 (System.String)\n\tv290 = v67.Length;\nL_013C:\n\tv485 = v290 < 7;\n\tv256 = ~v485;\n\tv248 = v290 - 7;\n\tv232 = v248 == 0;\n\tv486 = ~v256;\n\tv169 = v486 | v232;\n\tif (v169) goto L_0158;\n\tv67[7] = v60;\n\treturnVal2 = System.String::Format(\"Contact[Id={0}, First Name={1}, Middle Name={2}, Last Name={3}, Company={4}, Birthday={5}, PhoneNumber={6}, Email={7}]\", v67);\n\treturn returnVal2;\nL_0158:\n\tv291 = new System.IndexOutOfRangeException();\n\tgoto L_015D;\n\tv410 = new System.ArrayTypeMismatchException();\nL_015D:\n\tthrow v414;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 216 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_00b8: Expected O, but got I4
			//IL_00a9: Expected I4, but got O
			//IL_069a: Expected O, but got I
			//IL_0144: Expected O, but got I4
			//IL_0152: Expected I4, but got O
			//IL_06f8: Expected O, but got I
			//IL_01c4: Expected O, but got I4
			//IL_01d2: Expected I4, but got O
			//IL_0756: Expected O, but got I
			//IL_0244: Expected O, but got I4
			//IL_0252: Expected I4, but got O
			//IL_07b4: Expected O, but got I
			//IL_02c4: Expected O, but got I4
			//IL_02d2: Expected I4, but got O
			//IL_03da: Expected O, but got I4
			//IL_0406: Expected O, but got I4
			//IL_05de: Expected O, but got I
			//IL_0486: Expected O, but got I4
			//IL_063c: Expected O, but got I
			//IL_04d6: Expected O, but got I4
			KeyValuePair<string, string>[] array = PhoneNumbers;
			string text = ((Contact)(object)array).DictionaryToString(array);
			KeyValuePair<string, string>[] array2 = Emails;
			string text2 = ((Contact)(object)array2).DictionaryToString(array2);
			object[] array3 = new object[8];
			string text3 = ((Id != null) ? Id : "empty");
			bool flag = text3 == null;
			int num = 8;
			Contact contact;
			if (!flag)
			{
				contact = (Contact)(text3 as object);
				num = (int)typeof(object);
			}
			object obj = array3.Length;
			string text9;
			string text10;
			if (array3.Length != 0)
			{
				array3[0] = text3;
				string text4 = ((FirstName != null) ? FirstName : "empty");
				if (text4 != null)
				{
					contact = (Contact)(text4 as object);
					obj = array3.Length;
					num = (int)typeof(object);
				}
				bool flag2 = (long)(IntPtr)obj < 1L;
				bool flag3 = !flag2;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag4 = obj2 == null;
				bool flag5 = !flag3;
				if (!(flag5 || flag4))
				{
					array3[1] = text4;
					string text5 = ((MiddleName != null) ? MiddleName : "empty");
					if (text5 != null)
					{
						contact = (Contact)(text5 as object);
						obj = array3.Length;
						num = (int)typeof(object);
					}
					bool flag6 = (long)(IntPtr)obj < 2L;
					bool flag7 = !flag6;
					object obj3 = (long)(IntPtr)obj - 2L;
					bool flag8 = obj3 == null;
					bool flag9 = !flag7;
					if (!(flag9 || flag8))
					{
						array3[2] = text5;
						string text6 = ((LastName != null) ? LastName : "empty");
						if (text6 != null)
						{
							contact = (Contact)(text6 as object);
							obj = array3.Length;
							num = (int)typeof(object);
						}
						bool flag10 = (long)(IntPtr)obj < 3L;
						bool flag11 = !flag10;
						object obj4 = (long)(IntPtr)obj - 3L;
						bool flag12 = obj4 == null;
						bool flag13 = !flag11;
						if (!(flag13 || flag12))
						{
							array3[3] = text6;
							string text7 = ((Company != null) ? Company : "empty");
							if (text7 != null)
							{
								contact = (Contact)(text7 as object);
								obj = array3.Length;
								num = (int)typeof(object);
							}
							bool flag14 = (long)(IntPtr)obj < 4L;
							bool flag15 = !flag14;
							object obj5 = (long)(IntPtr)obj - 4L;
							bool flag16 = obj5 == null;
							bool flag17 = !flag15;
							if (!(flag17 || flag16))
							{
								array3[4] = text7;
								DateTime? dateTime = Birthday;
								if ((num & 0xFF) != 0)
								{
									DateTime value = Birthday.Value;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E96044 (inside System.DateTime::ParseExact +0x37C)");
									string text8 = default(string);
									bool flag18 = text8 == null;
									bool flag19 = !flag18;
									text9 = text8;
									if (flag19)
									{
										goto IL_03b6;
									}
									text10 = text8;
								}
								else
								{
									bool flag20 = "empty" == null;
									text9 = "empty";
									text10 = "empty";
									if (!flag20)
									{
										goto IL_03b6;
									}
								}
								goto IL_03d0;
							}
						}
					}
				}
			}
			goto IL_0504;
			IL_0504:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_03b6:
			contact = (Contact)(text9 as object);
			text10 = text9;
			goto IL_03d0;
			IL_03d0:
			object obj6 = array3.Length;
			bool flag21 = array3.Length < 5;
			bool flag22 = !flag21;
			object obj7 = array3.Length - 5;
			bool flag23 = obj7 == null;
			bool flag24 = !flag22;
			if (!(flag24 || flag23))
			{
				array3[5] = text10;
				if (text != null)
				{
					contact = (Contact)(text as object);
					obj6 = array3.Length;
				}
				bool flag25 = (long)(IntPtr)obj6 < 6L;
				bool flag26 = !flag25;
				object obj8 = (long)(IntPtr)obj6 - 6L;
				bool flag27 = obj8 == null;
				bool flag28 = !flag26;
				if (!(flag28 || flag27))
				{
					array3[6] = text;
					if (text2 != null)
					{
						contact = (Contact)(text2 as object);
						obj6 = array3.Length;
					}
					bool flag29 = (long)(IntPtr)obj6 < 7L;
					bool flag30 = !flag29;
					object obj9 = (long)(IntPtr)obj6 - 7L;
					bool flag31 = obj9 == null;
					bool flag32 = !flag30;
					if (!(flag32 || flag31))
					{
						array3[7] = text2;
						return string.Format("Contact[Id={0}, First Name={1}, Middle Name={2}, Last Name={3}, Company={4}, Birthday={5}, PhoneNumber={6}, Email={7}]", array3);
					}
				}
			}
			goto IL_0504;
		}

		[Token(Token = "0x60004FB")]
		[Address(RVA = "0xA548E0", Offset = "0xA548E0", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EF4938]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, dict, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021F98]) = v44;\nL_0016:\n\tv45 = dict == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tv58 = dict.Length <= 0;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0035;\n\tv96 = *([v63 @ X0_v3 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0035;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v63, dict, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv100 = EasyMobile.Contact+<>c;\nL_0035:\n\tv157 = v103.<>9__47_0;\n\tv108 = v103.<>9__47_0 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_005C;\n\tgoto L_004A;\n\tv173 = *([v99 @ X0_v4 (Il2CppClass<EasyMobile.Contact+<>c>)+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_004A;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v99, dict, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv191 = EasyMobile.Contact+<>c;\n\tv180 = *([v191 @ X8_v24+B8]);\nL_004A:\n\tv163 = new System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>();\n\tSystem.Func`2<System.Collections.Generic.KeyValuePair`2<System.String, System.String>, System.String>::.ctor(v163, v179.<>9, Il2CppMethodInfo);\n\tv166.<>9__47_0 = v163;\nL_005C:\n\tv172 = System.Linq.Enumerable::Select(dict, v157);\n\tv186 = System.Linq.Enumerable::ToArray(v172);\n\treturnVal2 = System.String::Join(\",\", v186);\n\treturn returnVal2;\n\tgoto L_007C;\nL_007C:\n\treturn *([v87 @ X8_v3 (System.String)]);\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string DictionaryToString(KeyValuePair<string, string>[] dict)
		{
			if (dict != null)
			{
				if (dict.Length > 0)
				{
					Func<KeyValuePair<string, string>, string> selector = _003C_003Ec._003C_003E9__47_0;
					if (_003C_003Ec._003C_003E9__47_0 == null)
					{
						selector = (_003C_003Ec._003C_003E9__47_0 = delegate(KeyValuePair<string, string> x)
						{
							//IL_0036: Expected O, but got I
							object arg = (((object)x != null) ? ((object)x) : ((object)"null"));
							IntPtr intPtr = default(IntPtr);
							object arg2 = ((intPtr != (IntPtr)0) ? ((object)(long)intPtr) : "null");
							return $"[{arg}, {arg2}]";
						});
					}
					IEnumerable<string> source = dict.Select(selector);
					string[] value = source.ToArray();
					return string.Join(",", value);
				}
				return "empty";
			}
			return "null";
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0xA54A3C", Offset = "0xA54A3C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB31F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021F99]) = v38;\nL_001A:\n\tthis.id = v44.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Contact()
		{
			id = string.Empty;
		}
	}
}
