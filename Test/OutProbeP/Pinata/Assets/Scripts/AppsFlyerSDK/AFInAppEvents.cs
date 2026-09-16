using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000002")]
public class AFInAppEvents
{
	[Token(Token = "0x4000001")]
	public const string LEVEL_ACHIEVED = "af_level_achieved";

	[Token(Token = "0x4000002")]
	public const string ADD_PAYMENT_INFO = "af_add_payment_info";

	[Token(Token = "0x4000003")]
	public const string ADD_TO_CART = "af_add_to_cart";

	[Token(Token = "0x4000004")]
	public const string ADD_TO_WISH_LIST = "af_add_to_wishlist";

	[Token(Token = "0x4000005")]
	public const string COMPLETE_REGISTRATION = "af_complete_registration";

	[Token(Token = "0x4000006")]
	public const string TUTORIAL_COMPLETION = "af_tutorial_completion";

	[Token(Token = "0x4000007")]
	public const string INITIATED_CHECKOUT = "af_initiated_checkout";

	[Token(Token = "0x4000008")]
	public const string PURCHASE = "af_purchase";

	[Token(Token = "0x4000009")]
	public const string RATE = "af_rate";

	[Token(Token = "0x400000A")]
	public const string SEARCH = "af_search";

	[Token(Token = "0x400000B")]
	public const string SPENT_CREDIT = "af_spent_credits";

	[Token(Token = "0x400000C")]
	public const string ACHIEVEMENT_UNLOCKED = "af_achievement_unlocked";

	[Token(Token = "0x400000D")]
	public const string CONTENT_VIEW = "af_content_view";

	[Token(Token = "0x400000E")]
	public const string TRAVEL_BOOKING = "af_travel_booking";

	[Token(Token = "0x400000F")]
	public const string SHARE = "af_share";

	[Token(Token = "0x4000010")]
	public const string INVITE = "af_invite";

	[Token(Token = "0x4000011")]
	public const string LOGIN = "af_login";

	[Token(Token = "0x4000012")]
	public const string RE_ENGAGE = "af_re_engage";

	[Token(Token = "0x4000013")]
	public const string UPDATE = "af_update";

	[Token(Token = "0x4000014")]
	public const string OPENED_FROM_PUSH_NOTIFICATION = "af_opened_from_push_notification";

	[Token(Token = "0x4000015")]
	public const string LOCATION_CHANGED = "af_location_changed";

	[Token(Token = "0x4000016")]
	public const string LOCATION_COORDINATES = "af_location_coordinates";

	[Token(Token = "0x4000017")]
	public const string ORDER_ID = "af_order_id";

	[Token(Token = "0x4000018")]
	public const string LEVEL = "af_level";

	[Token(Token = "0x4000019")]
	public const string SCORE = "af_score";

	[Token(Token = "0x400001A")]
	public const string SUCCESS = "af_success";

	[Token(Token = "0x400001B")]
	public const string PRICE = "af_price";

	[Token(Token = "0x400001C")]
	public const string CONTENT_TYPE = "af_content_type";

	[Token(Token = "0x400001D")]
	public const string CONTENT_ID = "af_content_id";

	[Token(Token = "0x400001E")]
	public const string CONTENT_LIST = "af_content_list";

	[Token(Token = "0x400001F")]
	public const string CURRENCY = "af_currency";

	[Token(Token = "0x4000020")]
	public const string QUANTITY = "af_quantity";

	[Token(Token = "0x4000021")]
	public const string REGSITRATION_METHOD = "af_registration_method";

	[Token(Token = "0x4000022")]
	public const string PAYMENT_INFO_AVAILIBLE = "af_payment_info_available";

	[Token(Token = "0x4000023")]
	public const string MAX_RATING_VALUE = "af_max_rating_value";

	[Token(Token = "0x4000024")]
	public const string RATING_VALUE = "af_rating_value";

	[Token(Token = "0x4000025")]
	public const string SEARCH_STRING = "af_search_string";

	[Token(Token = "0x4000026")]
	public const string DATE_A = "af_date_a";

	[Token(Token = "0x4000027")]
	public const string DATE_B = "af_date_b";

	[Token(Token = "0x4000028")]
	public const string DESTINATION_A = "af_destination_a";

	[Token(Token = "0x4000029")]
	public const string DESTINATION_B = "af_destination_b";

	[Token(Token = "0x400002A")]
	public const string DESCRIPTION = "af_description";

	[Token(Token = "0x400002B")]
	public const string CLASS = "af_class";

	[Token(Token = "0x400002C")]
	public const string EVENT_START = "af_event_start";

	[Token(Token = "0x400002D")]
	public const string EVENT_END = "af_event_end";

	[Token(Token = "0x400002E")]
	public const string LATITUDE = "af_lat";

	[Token(Token = "0x400002F")]
	public const string LONGTITUDE = "af_long";

	[Token(Token = "0x4000030")]
	public const string CUSTOMER_USER_ID = "af_customer_user_id";

	[Token(Token = "0x4000031")]
	public const string VALIDATED = "af_validated";

	[Token(Token = "0x4000032")]
	public const string REVENUE = "af_revenue";

	[Token(Token = "0x4000033")]
	public const string RECEIPT_ID = "af_receipt_id";

	[Token(Token = "0x4000034")]
	public const string PARAM_1 = "af_param_1";

	[Token(Token = "0x4000035")]
	public const string PARAM_2 = "af_param_2";

	[Token(Token = "0x4000036")]
	public const string PARAM_3 = "af_param_3";

	[Token(Token = "0x4000037")]
	public const string PARAM_4 = "af_param_4";

	[Token(Token = "0x4000038")]
	public const string PARAM_5 = "af_param_5";

	[Token(Token = "0x4000039")]
	public const string PARAM_6 = "af_param_6";

	[Token(Token = "0x400003A")]
	public const string PARAM_7 = "af_param_7";

	[Token(Token = "0x400003B")]
	public const string PARAM_8 = "af_param_8";

	[Token(Token = "0x400003C")]
	public const string PARAM_9 = "af_param_9";

	[Token(Token = "0x400003D")]
	public const string PARAM_10 = "af_param_10";

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x1661FBC", Offset = "0x1661FBC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AFInAppEvents()
	{
	}
}
