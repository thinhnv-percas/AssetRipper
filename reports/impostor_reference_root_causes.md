# Impostor — tám tham chiếu không đi theo được, và nguyên nhân từng cái

`reference_resolution_rate` 0,9942 (1368 trên 1376 tham chiếu có đích). Tám cái còn lại được truy
nguyên từng cái, và **không cái nào là lỗi phục hồi**: mỗi cái trỏ tới một type hoặc một asset
**không có trong bản build**.

Bằng chứng là chính `global-metadata.dat` của game — nếu tên một type không xuất hiện ở đó thì type
đó không tồn tại trong build, và không có gì để phân giải tới.

| tham chiếu | verdict | tên trong metadata | kết luận |
|---|---|---|---|
| `managers/AdsManager.prefab:44` `m_Script` | MISSING | `AdsManager` **0 lần** | type bị strip khỏi build |
| `managers/BaseTracking.prefab:44` `m_Script` | MISSING | `BaseTracking` **0 lần** | type bị strip khỏi build |
| `managers/GameManager.prefab:96` `m_Script` | MISSING | `Reporter` **0 lần** | type bị strip khỏi build |
| `managers/GameManager.prefab:108` `m_Script` | MISSING | `Reporter` **0 lần** | type bị strip khỏi build |
| `managers/AdvertisementManager.prefab:44` `m_Script` | BROKEN | `AdvertisementManager` **0 lần** | type bị strip khỏi build |
| `GoogleMobileAdsSettings.asset:12` `m_Script` | BROKEN | `GoogleMobileAdsSettings` **0 lần** | ScriptableObject chỉ dùng trong Editor, không vào player build |
| `LiberationSans SDF Material.mat:27` `m_Texture` | BROKEN | — | atlas thứ hai không có trong build |
| `LiberationSans SDF - Fallback.asset:47` (phần tử danh sách) | BROKEN | — | cùng atlas đó |

Đối chứng: `AdManager` và `GameManager` — hai type **có** phân giải được — xuất hiện đúng một lần
mỗi cái trong metadata dưới dạng token phân cách NUL. Nên phép đo phân biệt được, chứ không phải
"không tìm thấy gì nên kết luận không có gì".

## Vì sao hai tham chiếu font không phải lỗi gán GUID

Atlas `LiberationSans SDF Atlas.png` được rip xuất ra với GUID `c38f9234…` do chính `.meta` của nó
khai báo, và **bốn** document khác trỏ tới nó bằng đúng GUID đó và phân giải được:

```
LiberationSans SDF.asset             -> c38f9234…   phân giải được
LiberationSans SDF Material_0.mat    -> c38f9234…   phân giải được
LiberationSans SDF - Drop Shadow.mat -> c38f9234…   phân giải được
LiberationSans SDF - Outline.mat     -> c38f9234…   phân giải được
LiberationSans SDF Material.mat      -> 0b508b18…   không ai khai báo
LiberationSans SDF - Fallback.asset  -> 0b508b18…   không ai khai báo
```

Nếu việc gán GUID cho texture hỏng thì bốn cái đầu cũng hỏng. Chúng không hỏng, nên `0b508b18…` là
một atlas **khác** — bản mặc định của TMP Essential Resources — mà game không đóng gói vào build.

## Điều này thay đổi gì trong phép đo

Phép đo tham chiếu trước iteration này **bỏ sót mọi PPtr là phần tử của một danh sách**: `m_Materials`,
danh sách atlas của một font asset, danh sách component của một GameObject đều được viết dưới dạng
`- {fileID: …}` không có tên thuộc tính, và mẫu chỉ đọc dạng có tên. 305 tham chiếu vô hình trên
Impostor. Đây đúng là lỗi đã ghi ở iteration 044 — "đếm tham chiếu hỏng theo một hình dạng của nó thì
bỏ sót hình dạng kia" — lặp lại một tầng nữa.
