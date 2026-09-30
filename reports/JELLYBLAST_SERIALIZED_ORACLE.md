# JellyBlast serialized oracle — iteration 063

Nhãn: **PROVEN**, **MEASURED**, **INFERRED**, **UNKNOWN**. Source: `develop` @ `462789cf` (pin). Bản rip:
`Test/Out63g-i` (mặc định, không opt-in). Nguyên liệu: `iterations/063/serialized/`.

## 1. Source là nhân chứng, derivation root là trọng tài

`reports/JELLYBLAST_BUILD_PROVENANCE.md` chứng minh source được suy ra từ chính IPA này: `fe27775f` là
một bản rip của pipeline này, rồi được sửa tay. Vậy mỗi khác biệt giữa source và bản rip hiện tại có
đúng ba nguồn có thể: bản rip hiện tại, bản rip đã tạo `fe27775f`, hoặc một chỉnh sửa tay sau đó. Chạy
cùng phép đo với **cả hai** (`develop` và `fe27775f`) tách được chúng: một khác biệt có với `develop`
mà không có với `fe27775f` là chỉnh sửa tay.

`Test/Scripts/serialized_reference_graph.py` so theo identity ngữ nghĩa (scene → GameObject → component →
field → target), GUID và fileID được chuẩn hoá, prefab instance được mở rộng — không so YAML thô.

## 2. Kết quả — MEASURED

| | `develop` | `fe27775f` (derivation root) |
|---|---|---|
| GameObject | 106 MATCHED, **19 MISSING_IN_RECOVERED** | **106/106** |
| Component | 387/387 | 387/387 |
| Script binding | 173/173 | 173/173 |
| Reference (exact) | 226 MATCH, 1 FIELD_ABSENT, 1 NULL_IN_RECOVERED, 8 SOURCE_TARGET_UNKNOWN | **228/228 MATCH**, 6 SOURCE_TARGET_UNKNOWN |
| `reference_match_rate_exact` | 0.9912 | **1.0000** |

Mọi khác biệt với `develop` biến mất khi so với derivation root: **19 GameObject, 1 field và 1 tham chiếu
null là chỉnh sửa tay sau khi suy ra** (`Main.unity` được sửa ở `12f6733e`, `606d4b1c`, `94273ae8`).
**Lỗi serialize quy cho bản phục hồi: 0.**

## 3. Một lỗi thật tìm được trên đường — PROVEN, đã sửa

Lần chạy đầu trên bản rip có `CPP2IL_RECOVER_ALSO` (phục hồi UGUI/TMP để đo source oracle) báo
**239 FIELD_ABSENT_IN_RECOVERED** so với cả hai source: mọi `UnityEngine.UI.Image` mất `m_Sprite` và
`m_Material` (41 → 2 trong `Main.unity`), log có 81 `Unable to read MonoBehaviour Structure ... layout
mismatched`. Nguyên nhân: widening. Một body TMP phục hồi chạm vào field private của UGUI, field bị widen
lên `public`, và Unity serialize mọi field public — layout của `Image` có thêm field, dữ liệu không đọc
được. Widen đổi ai gọi được field, không được đổi Unity có serialize nó hay không: field private không
`[SerializeField]` được widen lên public giờ mang `NotSerialized`. Sau sửa: 0 layout mismatch,
`m_Sprite` 41. Ở chế độ mặc định sửa này chạm 1–12 field mỗi fixture (log: "fields made public were
marked NonSerialized"), trước đó chưa từng gây mismatch đo được nhưng đúng về nguyên tắc.

## 4. Giới hạn

- Oracle này **DERIVED**: nó chỉ chứng minh bản rip hiện tại tái tạo đúng những gì bản rip cũ đã tạo ra,
  và rằng phần còn lại là sửa tay. Nó không chứng minh cả hai đúng với project gốc của studio (không có).
- `SOURCE_TARGET_UNKNOWN` 6–8: target mà source trỏ tới không có trong checkout (asset built-in).
