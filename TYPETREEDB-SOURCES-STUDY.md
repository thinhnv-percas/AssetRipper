# Nghiên cứu: nguồn nào sinh `typetreedb/` hiệu quả nhất

Phần tiếp theo của [LIBIL2CPP-REPO-STUDY.md](LIBIL2CPP-REPO-STUDY.md). Ở đó kết luận
`libil2cpp` không đụng gì tới type-tree; tài liệu này đi tìm nguồn đúng cho
`typetreedb/`, và đo thử.

## Kết luận ngắn

**Dùng `lzma.tpk` của AssetRipper/Tpk.** Một file **203 KB** chứa type-tree
release của **1420 phiên bản Unity, 3.4.0 → 6000.7.0a3**. Đã dựng thử và đối chiếu
với đường `from-dumps` hiện có: **0 sai lệch** trên 20.111 và 20.653 node.

| Nguồn | Phải tải về | Phủ | Cần cài Unity? |
|---|---|---|---|
| `ClassAll.zip` (DevX, đang dùng để bootstrap) | 81 MB | 723 bản, trần **2021.2.7f1** | không |
| TypeTreeDumps `InfoJson/` (đường `from-dumps` hiện tại) | **13–17 MB/bản**, cả bộ 18,7 GB | 1420 bản, tới 6000.7.0a3 | không |
| TypeTreeDumps `StructsData/release/` | ~590 KB/bản, cả bộ 836 MB | 1422 bản | không |
| **AssetRipper/Tpk — `lzma.tpk`** | **203 KB cho TẤT CẢ** | **1420 bản** | không |
| AssetBundle tự build (`from-serialized`) | — | đúng 1 bản | **có** |

---

## 1. Bốn repo đáng quan tâm

| Repo | Vai trò | Giấy phép |
|---|---|---|
| [AssetRipper/TypeTreeDumps](https://github.com/AssetRipper/TypeTreeDumps) | Kho dump thô. `InfoJson/` 1420 file JSON, `StructsData/{editor,release}/` bản nhị phân, `Classes/`, `StringsData/`, `RTTI_Dump/`, `StructsDump/` | — |
| [AssetRipper/Tpk](https://github.com/AssetRipper/Tpk) | Nén cả `InfoJson/` thành **một** package `.tpk`. CI chạy **hàng tuần** (`cron: 0 0 * * 0`), ra 4 biến thể brotli / lz4 / lzma / uncompressed | MIT |
| [DaZombieKiller/TypeTreeDumper](https://github.com/DaZombieKiller/TypeTreeDumper) | Tool sinh ra dump từ **Unity Editor** — thứ nuôi TypeTreeDumps. Cần cài đúng bản Editor | — |
| [Razmoth/UTTDumper](https://github.com/Razmoth/UTTDumper) | Sinh dump từ **binary game đã build** (`UnityPlayer.dll`) qua bảng RVA trong TOML. Fallback tốt hơn `from-serialized` khi TypeTreeDumps chưa có bản đó | — |

`nesrak1/TypeTreeDumpToTpk` đã archive (2026-07-02), chính tác giả trỏ sang
AssetRipper/Tpk.

---

## 2. Đo thật: `lzma.tpk` chứa gì

Lấy file từ wheel của UnityPy trên PyPI (`UnityPy/resources/lzma.tpk`, cũng chính
là artifact của AssetRipper/Tpk):

```
compressed        207.798 byte  (203 KB)
uncompressed    1.538.989 byte  (1,5 MB)
versions             1.420        3.4.0 → 6000.7.0a3
classes                415
node buffer         26.516 node duy nhất  (dùng chung cho MỌI phiên bản)
string buffer        7.363 chuỗi
```

26.516 node cho cả 1420 phiên bản, trong khi **một** phiên bản của `typetreedb/`
đã có ~20.000 node — đó là toàn bộ lý do 203 KB đủ chỗ. Node và chuỗi được chia sẻ
xuyên phiên bản, mỗi class chỉ lưu mốc version + id node gốc.

Đọc bằng Python: [`tpk_ar`](https://pypi.org/project/tpk-ar/) trên PyPI (MIT, ~300
dòng, thuần Python, không cần .NET). Bản C# `AssetRipper.Tpk` target **net10.0** —
repo này đang netstandard2.0 / net472 / net40 nên **không** tham chiếu trực tiếp
được; đó là lý do nên giải nén ở bước sinh (Python) chứ không phải ở runtime.

---

## 3. Kiểm chứng: tpk cho ra đúng kết quả của `from-dumps`

Viết một bộ chuyển tpk → đúng schema `typetreedb/` (hoist `Base`, `treeLevel`,
`index`, `metaFlag`, `isArray`, `serializedVersion`), rồi so từng node với output
của `tools/typetreedb_gen.py from-dumps` chạy trên `InfoJson/` cùng phiên bản:

| Phiên bản | type (InfoJson / tpk) | node so sánh | sai lệch `type/name/size/isArray/metaFlag/serializedVersion/treeLevel` | sai lệch `index` |
|---|---|---|---|---|
| 2019.4.40f1 | 294 / 294 | 20.111 | **0** | **0** |
| 2021.2.7f1 | 285 / 285 | 20.653 | **0** | **0** |

Số type bỏ qua vì không có cây cũng trùng (27 ở cả hai bản). Kích thước file JSON
sinh ra lệch 138 byte — chỉ do thứ tự khoá `source`.

Đầu vào: **13,3 MB InfoJson** cho một phiên bản, so với **203 KB tpk** cho cả 1420.

---

## 4. Khử trùng lặp và độ phủ

Hai phiên bản có type-tree y hệt nhau khi và chỉ khi bảng `classID → (tên class,
id node gốc)` của chúng giống nhau — node buffer đã dùng chung nên so id là đủ.
Tính trên toàn bộ tpk mất **0,3 giây**:

```
1.420 phiên bản  →  610 bộ type-tree release khác nhau
```

Nhóm lớn nhất gộp 16 bản (2017.4.17f1 → 2017.4.32f1). So với hiện trạng: 723
phiên bản của `ClassAll.zip` gom còn 313 file. Đổi sang tpk thì thành **610 file
phủ 1420 phiên bản** — hơn gấp đôi độ phủ với chưa tới gấp đôi số file.

Có mặt trong tpk: `2022.3.62f2` và `6000.3.18f1` — đúng hai phiên bản mà
`structdb/` đang có còn repo `libil2cpp` thì không. Nghĩa là hai DB sẽ phủ trọn
cùng một dải phiên bản.

Kích thước output không đổi (định dạng JSON giữ nguyên): ~6,0 MB/bản ở `indent=1`,
**2,79 MB** với `--compact`, 152 KB nếu gzip. Ước tính cả bộ 610 file: ~1,7 GB
compact. Tpk **không** làm nhỏ output — nó làm nhỏ **đầu vào** và bỏ hẳn ràng buộc
phải cài Unity.

---

## 5. Phát hiện phụ: bảng `COMMON_STRINGS` hardcode đang sai với Unity mới

`tools/typetreedb_gen.py` (đường `from-serialized`) hardcode một bảng
`COMMON_STRINGS` 109 mục. Tpk lưu bảng này **theo từng phiên bản**, và nó thay đổi
liên tục:

```
4.6.2f1     99      2018.3.0b1  107      2023.1.0a1   109      6000.1.0a2  110
5.5.0f3    100      2020.1.0a19 108      2023.3.0a16  110      6000.1.0b10 111
5.6.0b1    101      2021.1.0a2  109      6000.0.70f1  112      6000.1.0b12 110
2017.2.0b2 104      2022.3.74f1 112      6000.2.0a8   112      6000.5.0a8  113
2018.2.0b1 105                                                 6000.6.0a6  114
```

Bảng 109 mục trong repo **trùng khít** bảng của 2021.1.0a2 – 2022.3.73f1 (đúng thứ
tự, đúng nội dung). Bảng là append-only nên bản cũ vẫn an toàn: offset của 101 mục
đầu không đổi. Nhưng từ **2022.3.74f1 và toàn bộ 6000.x**, bảng dài thêm 1–5 mục
(`RenderingLayerMask`, `fixed_array`, `EntityId`, …) mà bảng hardcode không có →
`_resolve_string` sẽ ném lỗi vì offset rơi ra ngoài. Tức là `from-serialized`
**không đọc được** type-tree từ bundle Unity 6.x — đúng nhóm phiên bản mà cả bài
toán này sinh ra để phục vụ. Lấy bảng từ tpk (`CommonString.BuildMap`) là xử lý
được luôn, và bỏ được cái bảng chép tay.

---

## 6. Đề xuất

1. **Thêm nguồn `from-tpk` vào `tools/typetreedb_gen.py`.** Đầu vào một file 203 KB,
   đầu ra toàn bộ 610 file + `index.json` phủ 1420 phiên bản. Phụ thuộc: `tpk_ar`
   (PyPI, MIT) hoặc ~300 dòng tự viết.
2. **Thay bảng `COMMON_STRINGS` hardcode** bằng bảng theo phiên bản đọc từ tpk —
   sửa luôn lỗi ở §5.
3. **Giữ `from-dumps` và `from-serialized`.** `from-dumps` vẫn là đường kiểm chứng
   chéo (nó đã xác nhận đường tpk đúng). `from-serialized` vẫn cần cho bản Unity
   vừa ra mà CI của Tpk chưa kịp đóng gói — và ở đó `UTTDumper` là lựa chọn nhẹ hơn
   so với dựng AssetBundle.
4. **Chưa đụng tới runtime C#.** Đọc thẳng tpk lúc chạy sẽ bỏ được cả thư mục 1,6 GB,
   nhưng `AssetRipper.Tpk` target net10.0 nên phải tự port reader sang net472. Đó là
   một quyết định riêng, không nằm trong phạm vi bài này.

---

## 7. Tái lập

```bash
pip download --no-deps -d . UnityPy tpk_ar
unzip -q unitypy-*.whl -d wheel          # wheel/UnityPy/resources/lzma.tpk  (203 KB)
pip install tpk_ar-*.tar.gz
```

```python
import io, tpk_ar
blob = tpk_ar.TpkFile.parse(io.BytesIO(open("lzma.tpk", "rb").read())).GetDataBlob()
# UnityVersion là int gói: major<<48 | minor<<32 | build<<16 | type<<8 | typeNumber
# type: a=0 b=1 c=2 f=3 p=4 x=5   ->  2019.4.40f1 == 568297995161305857
cls = blob.ClassInformation[1].getVersionedClass(uv)   # ValueError nếu class chưa tồn tại
node = blob.NodeBuffer[cls.ReleaseRootNode]            # .TypeName/.Name là index vào StringBuffer
```

Đối chiếu: chạy `python tools/typetreedb_gen.py from-dumps --input <InfoJson>/<ver>.json`
rồi so từng node của hai cây. Lấy InfoJson:

```bash
git clone --filter=blob:none --depth 1 https://github.com/AssetRipper/TypeTreeDumps.git
git -C TypeTreeDumps show HEAD:InfoJson/2019.4.40f1.json > 2019.4.40f1.json
```
