# typetreedb — type-tree Unity built-in classes, dạng JSON không mã hoá

Bộ này thay hoàn toàn `StreamingAssets/ClassAll.zip` + `UnityType.zip` của
DevXUnity-Unpacker. Nó là **type-tree của các class dựng sẵn trong Unity**, dùng để
đọc `.assets` / AssetBundle — hoàn toàn độc lập với [`structdb/`](../structdb/README.md)
(layout struct C của runtime IL2CPP). Hai bộ dễ bị nhầm vì cùng được chọn theo
Unity version.

> **Thư mục này không chứa dữ liệu trong git.** Một bản DB đầy đủ nặng vài trăm MB,
> gấp nhiều lần `structdb/`. Sinh tại chỗ bằng [`tools/typetreedb_gen.py`](../tools/typetreedb_gen.py)
> rồi copy vào `StreamingAssets/typetreedb/` — `.gitignore` đã loại `*.json` ở đây.

Loader phía C#: [`UnityTypeTreeDb.cs`](../Recovered/DevXUnityUnpackerTools/UnityTypeTreeDb.cs).
Runtime tìm `<StreamingAssets>/typetreedb`, rồi `<thư mục exe>/typetreedb`.
Nhánh `ClassAll.zip` cũ đã bị gỡ khỏi mã nguồn; hai file zip đó có thể xoá.

---

## Cơ chế cũ hỏng ở đâu

| Cũ (`ClassAll.zip`) | Mới (`typetreedb/`) |
|---|---|
| `File.ReadAllBytes` cả 81 MB, bung **toàn bộ 718 XML** ngay lần tra cứu đầu tiên, mỗi entry lại GZip nén ngược để giữ trong static dictionary | Đọc `index.json` (vài chục KB), nạp **đúng một file** khi cần, cache theo file |
| Tra cứu bằng `key.Contains("_v" + s)` trên toàn bộ 718 key, lặp cho **từng** chuỗi version ứng viên mà `AssetParser.Format2` sinh ra (cỡ hàng triệu chuỗi) | So sánh số: chọn bản mới nhất còn ≤ version yêu cầu |
| `_c1` khớp nhầm `_c114`, `_c10`, `_c128` | Không có matching theo chuỗi |
| Trần 2021.2.7f1, không có đường bổ sung | Thêm bản mới bằng một lệnh |
| Thiếu file → `catch {}` rỗng → mọi type là unknown, không lỗi ở đâu | `Loader.LogEnvironment` probe và ghi cảnh báo vào `il2cpp-debug.log` |
| XML nén trong ZIP, không diff được | JSON thuần, `git diff` đọc được |

---

## Bố cục

```
typetreedb/
├── index.json          ← ánh xạ MỌI unityVersion -> tên file
├── 5.1.0f3.json
├── 2020.3.0f1.json
└── 2021.2.7f1.json
```

`index.json` là nguồn sự thật, không phải danh sách file:

```json
{
  "schema": 1,
  "versions": {
    "2020.3.0f1": "2020.3.0f1.json",
    "2021.2.0f1": "2020.3.0f1.json",
    "2021.2.7f1": "2021.2.7f1.json"
  }
}
```

Nhiều version trỏ chung một file là **cố ý**: các bản patch thường có type-tree y
hệt nhau, nên `typetreedb_gen.py index` khử trùng lặp và đặt tên file theo bản
**cũ nhất** trong nhóm. Trường `source.coversVersions` trong mỗi file liệt kê đủ
nhóm đó. Thực tế 718 version của ClassAll gom lại còn vài chục file.

Không có `index.json` thì loader tự liệt kê `*.json` và lấy tên file làm version —
dùng được nhưng mất phần khử trùng lặp.

---

## Định dạng file version

```jsonc
{
  "schema": 1,
  "unityVersion": "2021.2.0f1",
  "unityTypeVersion": 19,          // <root unity_type_version> của DB cũ
  "platform": 0,                   // Platform_BuildTarget; 0 = không ràng buộc
  "baseDefinitions": false,
  "source": { "origin": "…", "files": ["…"], "coversVersions": ["…"] },

  "types": [
    {
      "classID": 1,                // 0 = MonoBehaviour script, xem "Bẫy" §1
      "className": "GameObject",
      "serializedVersion": 5,
      "scriptID": null,            // hex 32 ký tự, chỉ có với MonoBehaviour
      "typeHash": null,
      "platform": 0,               // tuỳ chọn, ghi đè platform của file
      "nodes": [
        {
          "type": "GameObject", "name": "Base",
          "size": -1, "index": 0, "isArray": false,
          "metaFlag": 0, "serializedVersion": 1, "treeLevel": 0,
          "children": [
            { "type": "string", "name": "m_Name", "size": -1, "index": 1,
              "isArray": false, "metaFlag": 32769, "serializedVersion": 1,
              "treeLevel": 1, "children": [] }
          ]
        }
      ]
    }
  ]
}
```

### Field trong `nodes[*]`

| Khoá | Ý nghĩa | Tương ứng Unity |
|---|---|---|
| `type` | Kiểu của field (`int`, `string`, `PPtr<GameObject>`, `vector`…) | `m_Type` |
| `name` | Tên field. Node gốc luôn tên `Base` | `m_Name` |
| `size` | Số byte. **`-1` là hợp lệ** — kích thước động (string, vector) | `m_ByteSize` |
| `index` | Số thứ tự node trong cây, dùng để nối lại thứ tự đọc | `m_Index` |
| `isArray` | Node này là mảng (con đầu là `size`, con sau là phần tử) | `m_TypeFlags` |
| `metaFlag` | Cờ align/hide. Bit `0x4000` = align 4 byte sau khi đọc | `m_MetaFlag` |
| `serializedVersion` | Version của chính node | `m_Version` |
| `treeLevel` | Độ sâu. Dư thừa với lồng `children`, giữ cho người đọc | `m_Level` |
| `licenseType`, `value` | Chỉ có trong DB cũ của DevX, không dùng khi parse | — |

`typeOffset` / `nameOffset` của blob gốc **không** được ghi lại: chúng chỉ là chỉ
số vào string buffer của file nguồn, vô nghĩa sau khi đã giải ra chuỗi thật.

---

## Sinh dữ liệu

```bash
# 1. Bootstrap từ DB cũ của DevX (mọi bản ≤ 2021.2.7f1)
python tools/typetreedb_gen.py from-zip \
    --zip "…/StreamingAssets/ClassAll.zip" \
    --zip "…/StreamingAssets/UnityType.zip" \
    --out typetreedb

# 2. Thêm một bản Unity mới — đường dễ nhất
#    Tải InfoJson/<version>.json từ bộ TypeTreeDumps công khai
python tools/typetreedb_gen.py from-dumps --input 6000.3.18f1.json --out typetreedb

# 3. Khi chưa ai dump bản đó: build một AssetBundle bằng chính bản Unity ấy
#    (Unity ghi type-tree vào bundle trừ khi bật DisableWriteTypeTree)
python tools/typetreedb_gen.py from-serialized \
    --input "build/*.bundle" --unity-version 6000.4.0f1 --out typetreedb

python tools/typetreedb_gen.py index  --out typetreedb   # khử trùng lặp lại
python tools/typetreedb_gen.py verify --out typetreedb
```

`from-serialized` **gộp** nhiều file vào cùng một version, nên cứ đưa vào tất cả
bundle đang có: mỗi bundle chỉ chứa type-tree của những type nó thực sự dùng, gom
nhiều bundle mới đủ độ phủ. Thêm `--overwrite` nếu muốn ghi đè thay vì gộp.

Cờ `--compact` cho JSON một dòng (nhỏ hơn ~2×) khi cần nhét vào bản phát hành;
mặc định là `indent=1` để `git diff` đọc được.

---

## Năm cái bẫy

### 1. MonoBehaviour script mang `classID = 0`

`StrSth.FindByStr` chỉ khớp khi `objectType == 0`, còn `FindByInt` khớp theo
`classID`. Trong DB cũ, mọi type script được lưu với `classID = 0` và định danh
nằm trong `className` (`MonoBehaviour:<assembly>:<type>`). `from-serialized` giữ
đúng quy ước đó: gặp `classID == 114` kèm `m_ScriptTypeIndex >= 0` thì ghi
`classID = 0`. Đổi quy ước này thì mọi MonoBehaviour tra không ra, im lặng.

### 2. Bảng CommonString là bảng cứng, không nằm trong file

Trong blob type-tree của SerializedFile, offset chuỗi có bit `0x80000000` trỏ vào
một bảng chuỗi **dựng cứng trong Unity**, không phải string buffer của file. Sai
bảng này thì mọi tên field vẫn ra một chuỗi nào đó — chỉ là sai. `_resolve_string`
vì thế bắt buộc offset phải rơi đúng đầu một chuỗi và ném lỗi nếu không, thay vì
sinh ra DB hỏng một cách lặng lẽ.

### 3. `m_EnableTypeTree = false` không phải lỗi

Player build release strip type-tree. File đó không dùng được để sinh DB. Dùng
AssetBundle (mặc định có type-tree) hoặc `globalgamemanagers` của một development
build. Tool báo rõ trường hợp này thay vì trả DB rỗng.

### 4. Bước bootstrap từ `ClassAll.zip` gần như bắt buộc

`ManyCodeCls` có một cổng kiểm tra license
([ManyCodeCls.cs:3049](../Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L3049))
gọi `AssetParser.createOrGetData(new VerFormat("5.6"), 19, 1)` và bật hộp thoại
`#LIC_MEATADATA` nếu kết quả null. Nghĩa là DB phải phủ tới Unity 5.6 và có
classID 19. Chạy `from-zip` trước, rồi mới bổ sung bản mới bằng `from-dumps`.
Cổng này đã tồn tại từ trước và hành xử y như khi thiếu `ClassAll.zip`.

### 5. `size = -1` là hợp lệ

Node có kích thước động (`string`, `vector`, `map`, `TypelessData`) luôn mang
`size = -1`. Bộ kiểm tra bất biến nào coi đó là lỗi sẽ báo hàng nghìn lỗi giả.

---

## Chọn version khi không khớp chính xác

`UnityTypeTreeDb.FindNearest` lấy bản **mới nhất còn ≤** version yêu cầu, không có
thì lấy bản cũ nhất. So sánh theo `(major, minor, patch, stage, build)` với thứ tự
phát hành `a < b < f < p`.

Đây là điểm khác quan trọng so với `AssetParser.Format2` cũ: bộ đó sinh chuỗi ứng
viên bằng vòng lặp `patch 0..20 × "pfba" × 0..9`, nên với một bản như `2022.3.62f2`
nó không bao giờ dò tới — patch 62 nằm ngoài dải 0..20. `Format2` vẫn còn trong
`AssetParser` nhưng chỉ để chọn `UnityDLL/*.zip`, không còn dính tới type-tree.
