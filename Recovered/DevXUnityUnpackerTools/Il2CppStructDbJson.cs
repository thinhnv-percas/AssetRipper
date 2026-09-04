// Nạp DB layout struct runtime IL2CPP từ thư mục "structdb" (JSON, không mã hóa).
//
// Thay thế hoàn toàn cơ chế cũ: file "IL2CPPStructs/*.dvxil2c" = stream cipher
// (LCG kiểu java.util.Random, khóa "sdf3$wGSDGEh%$SdF2") -> GZip -> BinaryWriter.
// Ba lớp đó đã bị gỡ khỏi mã nguồn; xem structdb/README.md để biết schema.
//
// Vị trí tìm kiếm, theo thứ tự:
//   1. <StreamingAssets>/structdb/<unityVersion>-<x32|x64>.json
//   2. <thư mục exe>/structdb/<unityVersion>-<x32|x64>.json

using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;

// Bí danh cho các kiểu bị obfuscate, để đọc được phần dưới.
using StructDbArchive = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020;
using StructDbForArch = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020;
using StructLayout    = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020;
using StructField     = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A;

internal static class Il2CppStructDbJson
{
	internal const string DirectoryName = "structdb";

	private static string[] _searchRoots;
	private static Dictionary<string, string> _versionIndex;

	/// <summary>Các thư mục có thể chứa structdb, theo thứ tự ưu tiên.</summary>
	private static string[] SearchRoots
	{
		get
		{
			if (_searchRoots != null)
			{
				return _searchRoots;
			}
			List<string> list = new List<string>();
			if (!string.IsNullOrEmpty(DevXSystemInfo.StreamingAssets))
			{
				list.Add(Path.Combine(DevXSystemInfo.StreamingAssets, DirectoryName));
			}
			if (!string.IsNullOrEmpty(DevXSystemInfo.UnpackerRootDirectory))
			{
				list.Add(Path.Combine(DevXSystemInfo.UnpackerRootDirectory, DirectoryName));
			}
			_searchRoots = list.ToArray();
			return _searchRoots;
		}
	}

	/// <summary>
	/// Quét một lần, lập chỉ mục unityVersion -> thư mục chứa nó.
	/// Chỉ nhận version có ĐỦ cả hai file x32 và x64.
	/// </summary>
	private static Dictionary<string, string> VersionIndex
	{
		get
		{
			if (_versionIndex != null)
			{
				return _versionIndex;
			}
			_versionIndex = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			foreach (string root in SearchRoots)
			{
				if (!Directory.Exists(root))
				{
					continue;
				}
				foreach (string file in Directory.GetFiles(root, "*-x64.json", SearchOption.TopDirectoryOnly))
				{
					string name = Path.GetFileNameWithoutExtension(file);
					string version = name.Substring(0, name.Length - "-x64".Length);
					if (!_versionIndex.ContainsKey(version) && File.Exists(PathFor(root, version, is32Bit: true)))
					{
						_versionIndex[version] = root;
					}
				}
			}
			DbgLog.W("STRUCTDB", "đã lập chỉ mục " + _versionIndex.Count + " phiên bản Unity từ: "
				+ string.Join(" | ", SearchRoots));
			return _versionIndex;
		}
	}

	private static string PathFor(string root, string version, bool is32Bit) =>
		Path.Combine(root, version + (is32Bit ? "-x32.json" : "-x64.json"));

	/// <summary>Danh sách version có trong DB. Rỗng nếu chưa cài structdb.</summary>
	internal static IEnumerable<string> AvailableVersions => VersionIndex.Keys;

	/// <summary>true nếu có DB cho đúng version này (không tính fallback).</summary>
	internal static bool Has(string unityVersion) =>
		unityVersion != null && VersionIndex.ContainsKey(unityVersion);

	/// <summary>
	/// Chọn phiên bản gần nhất có trong DB: ưu tiên bản MỚI NHẤT còn ≤ version yêu
	/// cầu (layout chỉ đổi khi tiến lên), nếu không có thì lấy bản cũ nhất.
	/// Trả null nếu DB rỗng.
	///
	/// Thay cho bộ sinh ứng viên GetNearUnityVersionList của DevX: bộ đó chỉ dò
	/// patch 0..20 nên không bao giờ với tới được ví dụ "2022.3.62f2".
	/// </summary>
	internal static string FindNearest(string unityVersion)
	{
		if (Has(unityVersion))
		{
			return unityVersion;
		}
		int[] want = ParseVersion(unityVersion);
		if (want == null || VersionIndex.Count == 0)
		{
			return null;
		}
		string bestBelow = null, oldest = null;
		int[] bestBelowKey = null, oldestKey = null;
		foreach (string candidate in VersionIndex.Keys)
		{
			int[] key = ParseVersion(candidate);
			if (key == null)
			{
				continue;
			}
			if (oldestKey == null || Compare(key, oldestKey) < 0)
			{
				oldestKey = key;
				oldest = candidate;
			}
			if (Compare(key, want) <= 0 && (bestBelowKey == null || Compare(key, bestBelowKey) > 0))
			{
				bestBelowKey = key;
				bestBelow = candidate;
			}
		}
		return bestBelow ?? oldest;
	}

	/// <summary>"2022.3.62f2" -> {2022, 3, 62, 'f', 2}. null nếu không phân tích được.</summary>
	private static int[] ParseVersion(string v)
	{
		if (string.IsNullOrEmpty(v))
		{
			return null;
		}
		System.Text.RegularExpressions.Match m = System.Text.RegularExpressions.Regex.Match(
			v, @"^(\d+)\.(\d+)\.(\d+)([abfp])?(\d+)?");
		if (!m.Success)
		{
			return null;
		}
		// thứ tự phát hành: a (alpha) < b (beta) < f (final) < p (patch)
		int stage = m.Groups[4].Success ? "abfp".IndexOf(m.Groups[4].Value[0]) : 2;
		return new[]
		{
			int.Parse(m.Groups[1].Value),
			int.Parse(m.Groups[2].Value),
			int.Parse(m.Groups[3].Value),
			stage < 0 ? 2 : stage,
			m.Groups[5].Success ? int.Parse(m.Groups[5].Value) : 0
		};
	}

	private static int Compare(int[] a, int[] b)
	{
		for (int i = 0; i < a.Length && i < b.Length; i++)
		{
			if (a[i] != b[i])
			{
				return a[i] < b[i] ? -1 : 1;
			}
		}
		return 0;
	}

	/// <summary>
	/// Nạp cả hai bản x32 + x64 của một phiên bản Unity. Trả null nếu không có.
	/// </summary>
	internal static StructDbArchive Load(string unityVersion)
	{
		if (string.IsNullOrEmpty(unityVersion) || !VersionIndex.TryGetValue(unityVersion, out string root))
		{
			return null;
		}
		try
		{
			StructDbArchive archive = new StructDbArchive();
			archive._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A =
				ReadArch(PathFor(root, unityVersion, is32Bit: true), unityVersion, is32Bit: true);
			archive._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020 =
				ReadArch(PathFor(root, unityVersion, is32Bit: false), unityVersion, is32Bit: false);
			return archive;
		}
		catch (Exception ex)
		{
			DbgLog.Ex("STRUCTDB", "không đọc được DB cho Unity " + unityVersion, ex);
			return null;
		}
	}

	private static StructDbForArch ReadArch(string path, string unityVersion, bool is32Bit)
	{
		Dictionary<string, object> root = Json.Deserialize(File.ReadAllText(path)) as Dictionary<string, object>;
		if (root == null)
		{
			throw new InvalidDataException("JSON hỏng: " + path);
		}

		StructDbForArch db = new StructDbForArch("il2cpp", unityVersion, is32Bit);

		if (root.TryGetValue("structs", out object structsObj)
			&& structsObj is Dictionary<string, object> structs)
		{
			foreach (KeyValuePair<string, object> pair in structs)
			{
				if (pair.Value is Dictionary<string, object> node)
				{
					db._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020[pair.Key] =
						ReadStruct(db, pair.Key, unityVersion, is32Bit, node);
				}
			}
		}

		CopyStringMap(root, "enums", db._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A);
		CopyStringMap(root, "defines", db._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A);
		CopyStringMap(root, "typedefs", db._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020);
		return db;
	}

	private static StructLayout ReadStruct(StructDbForArch db, string name, string unityVersion,
		bool is32Bit, Dictionary<string, object> node)
	{
		StructLayout layout = new StructLayout(db);
		layout._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A = unityVersion;
		layout._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A = name;
		layout._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020 = Int(node, "size");
		layout._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_0020 = Int(node, "pack");
		layout._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A = Bool(node, "union");
		layout._0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A = is32Bit;

		if (node.TryGetValue("fields", out object fieldsObj) && fieldsObj is List<object> fields)
		{
			foreach (object item in fields)
			{
				if (!(item is Dictionary<string, object> f))
				{
					continue;
				}
				StructField field = ReadField(f);
				layout._0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020
					[field._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020] = field;
				// Union và flexible-array-member làm nhiều field trùng offset;
				// bảng tra theo offset giữ field ĐẦU TIÊN, giống hành vi cũ.
				layout._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_000A
					[field._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A] = field;
			}
		}
		return layout;
	}

	private static StructField ReadField(Dictionary<string, object> f)
	{
		StructField field = new StructField();
		string type = Str(f, "type");
		field._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = Str(f, "name");
		field._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A = type;
		// realType chỉ có trong JSON khi khác type; model cũ luôn muốn một giá trị.
		field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A =
			f.ContainsKey("realType") ? Str(f, "realType") : type;
		field._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A = Int(f, "offset");

		// Model cũ lưu bề rộng theo BIT cho mọi field ("bits_len"), và suy ra byte bằng /8.
		// JSON lưu "size" (byte) cho field thường, "bits" cho bitfield.
		field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020 =
			f.ContainsKey("bits") ? Int(f, "bits") : Int(f, "size") * 8;

		if (f.ContainsKey("bits"))
		{
			// bitOrdinal là SỐ THỨ TỰ của DevX, không phải vị trí bit — giữ nguyên
			// để tương thích, nhưng BitOffset mới mới là thứ dùng để dịch bit.
			field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A = Int(f, "bitOrdinal");
			field.BitOffset = Int(f, "bitOffset");
			field.IsBitField = true;
		}
		else
		{
			field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A = null;
			field.BitOffset = 0;
			field.IsBitField = false;
		}

		field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A = Int(f, "arrayItemSize");
		field._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020 = Bool(f, "union");
		return field;
	}

	private static void CopyStringMap(Dictionary<string, object> root, string key, Dictionary<string, string> target)
	{
		if (target == null || !root.TryGetValue(key, out object obj) || !(obj is Dictionary<string, object> map))
		{
			return;
		}
		foreach (KeyValuePair<string, object> pair in map)
		{
			target[pair.Key] = pair.Value as string ?? string.Empty;
		}
	}

	// MiniJSON trả long cho số nguyên, double cho số thực.
	private static int Int(Dictionary<string, object> node, string key)
	{
		if (!node.TryGetValue(key, out object v) || v == null)
		{
			return 0;
		}
		if (v is long l) return (int)l;
		if (v is double d) return (int)d;
		int.TryParse(Convert.ToString(v), out int parsed);
		return parsed;
	}

	private static bool Bool(Dictionary<string, object> node, string key) =>
		node.TryGetValue(key, out object v) && v is bool b && b;

	private static string Str(Dictionary<string, object> node, string key) =>
		node.TryGetValue(key, out object v) ? (v as string ?? string.Empty) : string.Empty;
}
