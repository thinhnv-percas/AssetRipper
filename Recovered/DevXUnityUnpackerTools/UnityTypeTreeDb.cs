// Nạp type-tree của Unity built-in classes từ thư mục "typetreedb" (JSON, không mã hóa).
//
// Thay thế hoàn toàn cơ chế cũ: StreamingAssets/ClassAll.zip + UnityType.zip
// (ZIP 81 MB -> nạp TOÀN BỘ 718 XML vào RAM ngay lần tra cứu đầu tiên -> mỗi entry
// lại GZip nén ngược để giữ trong static dictionary -> tra cứu bằng substring
// "_v<version>" trên toàn bộ key, lặp qua hàng triệu chuỗi version ứng viên do
// AssetParser.Format2 sinh ra). Xem typetreedb/README.md để biết schema.
//
// Cơ chế mới giống hệt Il2CppStructDbJson (structdb):
//   * mỗi phiên bản Unity một file JSON, đọc bằng mắt và git diff được;
//   * index.json ánh xạ version -> file, nhiều version dùng chung một file khi
//     type-tree không đổi (khử trùng lặp, giữ tên file là version đầu tiên);
//   * nạp lười (lazy) đúng file cần, cache theo tên file;
//   * chọn version gần nhất bằng so sánh số, không phải sinh tổ hợp chuỗi.
//
// Vị trí tìm kiếm, theo thứ tự:
//   1. <StreamingAssets>/typetreedb/
//   2. <thư mục exe>/typetreedb/

using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;

// Bí danh cho các kiểu bị obfuscate, để đọc được phần dưới.
using TypeTreeNode = @as._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A;
using TypeTreeNodeInfo = @as._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020;
using TypeTreeHash = @as._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020;

namespace @as
{
	internal static class UnityTypeTreeDb
	{
		internal const string DirectoryName = "typetreedb";
		internal const string IndexFileName = "index.json";

		private static readonly object _gate = new object();

		private static string[] _searchRoots;

		/// <summary>unityVersion -> đường dẫn tuyệt đối của file JSON chứa nó.</summary>
		private static Dictionary<string, string> _versionIndex;

		/// <summary>đường dẫn file -> cây đã dựng. Nhiều version trỏ chung một file.</summary>
		private static readonly Dictionary<string, StrSth> _cache =
			new Dictionary<string, StrSth>(StringComparer.OrdinalIgnoreCase);

		/// <summary>Các thư mục có thể chứa typetreedb, theo thứ tự ưu tiên.</summary>
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
		/// Quét một lần: đọc index.json của từng root, thiếu index thì liệt kê *.json
		/// và lấy tên file làm version. Root đứng trước thắng khi trùng version.
		/// </summary>
		private static Dictionary<string, string> VersionIndex
		{
			get
			{
				if (_versionIndex != null)
				{
					return _versionIndex;
				}
				lock (_gate)
				{
					if (_versionIndex != null)
					{
						return _versionIndex;
					}
					Dictionary<string, string> index =
						new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
					foreach (string root in SearchRoots)
					{
						if (!Directory.Exists(root))
						{
							continue;
						}
						if (!TryReadIndex(root, index))
						{
							ScanDirectory(root, index);
						}
					}
					DbgLog.W("TYPETREEDB", "đã lập chỉ mục " + index.Count + " phiên bản Unity từ: "
						+ string.Join(" | ", SearchRoots));
					_versionIndex = index;
					return _versionIndex;
				}
			}
		}

		/// <summary>Đọc index.json. Trả false nếu không có file hoặc file hỏng.</summary>
		private static bool TryReadIndex(string root, Dictionary<string, string> index)
		{
			string indexPath = Path.Combine(root, IndexFileName);
			if (!File.Exists(indexPath))
			{
				return false;
			}
			try
			{
				Dictionary<string, object> doc =
					Json.Deserialize(File.ReadAllText(indexPath)) as Dictionary<string, object>;
				if (doc == null || !doc.TryGetValue("versions", out object versionsObj)
					|| !(versionsObj is Dictionary<string, object> versions) || versions.Count == 0)
				{
					DbgLog.W("TYPETREEDB", "index.json không có mục \"versions\": " + indexPath);
					return false;
				}
				int added = 0;
				foreach (KeyValuePair<string, object> pair in versions)
				{
					string fileName = pair.Value as string;
					if (string.IsNullOrEmpty(pair.Key) || string.IsNullOrEmpty(fileName)
						|| index.ContainsKey(pair.Key))
					{
						continue;
					}
					string full = Path.Combine(root, fileName);
					if (!File.Exists(full))
					{
						DbgLog.W("TYPETREEDB", "index.json trỏ tới file không tồn tại: " + full);
						continue;
					}
					index[pair.Key] = full;
					added++;
				}
				return added > 0;
			}
			catch (Exception ex)
			{
				DbgLog.Ex("TYPETREEDB", "không đọc được " + indexPath, ex);
				return false;
			}
		}

		/// <summary>Dự phòng khi không có index.json: tên file chính là version.</summary>
		private static void ScanDirectory(string root, Dictionary<string, string> index)
		{
			foreach (string file in Directory.GetFiles(root, "*.json", SearchOption.TopDirectoryOnly))
			{
				string version = Path.GetFileNameWithoutExtension(file);
				if (string.Equals(version, "index", StringComparison.OrdinalIgnoreCase)
					|| index.ContainsKey(version))
				{
					continue;
				}
				index[version] = file;
			}
		}

		/// <summary>Danh sách version có trong DB. Rỗng nếu chưa cài typetreedb.</summary>
		internal static IEnumerable<string> AvailableVersions => VersionIndex.Keys;

		/// <summary>true nếu có DB cho đúng version này (không tính fallback).</summary>
		internal static bool Has(string unityVersion) =>
			!string.IsNullOrEmpty(unityVersion) && VersionIndex.ContainsKey(unityVersion);

		/// <summary>
		/// Chọn phiên bản gần nhất có trong DB: ưu tiên bản MỚI NHẤT còn ≤ version yêu
		/// cầu, nếu không có thì lấy bản cũ nhất. Trả null nếu DB rỗng.
		///
		/// Thay cho AssetParser.Format2: bộ đó sinh hàng triệu chuỗi ứng viên rồi quét
		/// substring toàn bộ dictionary cho từng chuỗi, và vẫn không với tới được
		/// những version nằm ngoài dải patch 0..20 mà nó dò.
		/// </summary>
		internal static string FindNearest(string unityVersion)
		{
			if (Has(unityVersion))
			{
				return unityVersion;
			}
			int[] want = ParseVersion(unityVersion);
			// major == 0 không phải phiên bản Unity thật. Nó đến từ các probe nội bộ
			// kiểu VerFormat(0, 0, 0, "TST") / "CAL" — đừng nạp cả một DB cho chúng.
			if (want == null || want[0] <= 0 || VersionIndex.Count == 0)
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

		/// <summary>Nạp cây của đúng version này. Trả null nếu không có trong DB.</summary>
		internal static StrSth Load(string unityVersion)
		{
			if (string.IsNullOrEmpty(unityVersion)
				|| !VersionIndex.TryGetValue(unityVersion, out string path))
			{
				return null;
			}
			lock (_gate)
			{
				if (_cache.TryGetValue(path, out StrSth cached))
				{
					return cached;
				}
				StrSth tree = null;
				try
				{
					tree = ReadFile(path);
				}
				catch (Exception ex)
				{
					DbgLog.Ex("TYPETREEDB", "không đọc được DB cho Unity " + unityVersion, ex);
				}
				// Cache cả kết quả null: file hỏng thì đừng thử lại mỗi lần tra cứu.
				_cache[path] = tree;
				return tree;
			}
		}

		/// <summary>
		/// Nạp cây gần nhất cho một VerFormat. Đây là điểm vào mà AssetParser dùng.
		/// </summary>
		internal static StrSth LoadNearest(VerFormat ver)
		{
			string wanted = ver?.ToString();
			if (string.IsNullOrEmpty(wanted))
			{
				return null;
			}
			string picked = FindNearest(wanted);
			if (picked == null)
			{
				return null;
			}
			StrSth tree = Load(picked);
			if (tree != null && picked != wanted)
			{
				DbgLog.Lim("TYPETREEDB", "Unity " + wanted + " không có trong DB, dùng " + picked, 20);
			}
			return tree;
		}

		private static StrSth ReadFile(string path)
		{
			Dictionary<string, object> root =
				Json.Deserialize(File.ReadAllText(path)) as Dictionary<string, object>;
			if (root == null)
			{
				throw new InvalidDataException("JSON hỏng: " + path);
			}

			StrSth tree = new StrSth(Int(root, "unityTypeVersion"));
			// ConsoleData sao chép ver + unityTypeVersion từ cây lúc khởi tạo,
			// nên hai giá trị này phải được gán TRƯỚC khi dựng type nào.
			tree._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A =
				new VerFormat(Str(root, "unityVersion"));
			tree._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020 = Int(root, "platform");
			tree._0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020 = Bool(root, "baseDefinitions");

			if (root.TryGetValue("types", out object typesObj) && typesObj is List<object> types)
			{
				int i = 0;
				foreach (object item in types)
				{
					if (item is Dictionary<string, object> node)
					{
						tree.lics[i++] = ReadType(tree, node);
					}
				}
			}
			DbgLog.Lim("TYPETREEDB", "nạp " + Path.GetFileName(path) + ": "
				+ tree.lics.Count + " type", 40);
			return tree;
		}

		private static ConsoleData ReadType(StrSth tree, Dictionary<string, object> node)
		{
			ConsoleData data = new ConsoleData(tree);
			// SettingFLAGS = 0: objectType/size giữ nguyên giá trị thật, không bị
			// trộn bởi bộ mã hoá số nguyên chống sửa của DevX.
			data._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020 = 0;
			data.objectType = Int(node, "classID");
			data.SthStrValueForIndex = Str(node, "className");
			data._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A =
				node.ContainsKey("serializedVersion") ? Int(node, "serializedVersion") : 1;
			if (node.ContainsKey("platform"))
			{
				data._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020 = Int(node, "platform");
			}

			string scriptId = Str(node, "scriptID");
			if (!string.IsNullOrEmpty(scriptId))
			{
				data._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 =
					TypeTreeHash._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A(scriptId);
			}
			string typeHash = Str(node, "typeHash");
			if (!string.IsNullOrEmpty(typeHash))
			{
				data._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A =
					TypeTreeHash._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A(typeHash);
			}

			TypeTreeNode rootNode = new TypeTreeNode();
			data._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 = rootNode;
			if (node.TryGetValue("nodes", out object nodesObj) && nodesObj is List<object> nodes)
			{
				foreach (object item in nodes)
				{
					if (item is Dictionary<string, object> child)
					{
						AddNode(rootNode, child, data._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020);
					}
				}
			}
			rootNode._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020 =
				data.objectType + ": " + data.SthStrValueForIndex;
			return data;
		}

		/// <summary>Dựng một node con và đệ quy xuống "children".</summary>
		private static void AddNode(TypeTreeNode parent, Dictionary<string, object> node, int unityTypeVersion)
		{
			TypeTreeNode container = new TypeTreeNode();
			TypeTreeNodeInfo info = new TypeTreeNodeInfo(unityTypeVersion);
			container._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A = info;
			parent._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(container);

			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020 = 0; // SettingFLAGS
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A = Str(node, "type");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020 = Str(node, "name");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A = Int(node, "size");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A = Int(node, "index");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020 = Bool(node, "isArray");
			info._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A = Int(node, "metaFlag");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A =
				node.ContainsKey("serializedVersion") ? Int(node, "serializedVersion") : 1;
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020 = Int(node, "treeLevel");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A = Int(node, "typeOffset");
			info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020 = Int(node, "nameOffset");
			if (node.ContainsKey("licenseType"))
			{
				info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A = Str(node, "licenseType");
			}
			if (node.ContainsKey("value"))
			{
				info._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020 = Str(node, "value");
			}

			if (node.TryGetValue("children", out object childrenObj) && childrenObj is List<object> children)
			{
				foreach (object item in children)
				{
					if (item is Dictionary<string, object> child)
					{
						AddNode(container, child, unityTypeVersion);
					}
				}
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
}
