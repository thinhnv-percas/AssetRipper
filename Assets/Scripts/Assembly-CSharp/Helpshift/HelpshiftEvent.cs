using Cpp2ILInjected;

namespace Helpshift
{
	[Token(Token = "0x20007FD")]
	public class HelpshiftEvent
	{
		[Token(Token = "0x4001A9A")]
		public const string WIDGET_TOGGLE = "widgetToggle";

		[Token(Token = "0x4001A9B")]
		public const string DATA_SDK_VISIBLE = "visible";

		[Token(Token = "0x4001A9C")]
		public const string CONVERSATION_START = "conversationStart";

		[Token(Token = "0x4001A9D")]
		public const string DATA_MESSAGE = "message";

		[Token(Token = "0x4001A9E")]
		public const string MESSAGE_ADD = "messageAdd";

		[Token(Token = "0x4001A9F")]
		public const string DATA_MESSAGE_TYPE = "type";

		[Token(Token = "0x4001AA0")]
		public const string DATA_MESSAGE_BODY = "body";

		[Token(Token = "0x4001AA1")]
		public const string DATA_MESSAGE_TYPE_ATTACHMENT = "attachment";

		[Token(Token = "0x4001AA2")]
		public const string DATA_MESSAGE_TYPE_TEXT = "text";

		[Token(Token = "0x4001AA3")]
		public const string CSAT_SUBMIT = "csatSubmit";

		[Token(Token = "0x4001AA4")]
		public const string DATA_CSAT_RATING = "rating";

		[Token(Token = "0x4001AA5")]
		public const string DATA_ADDITIONAL_FEEDBACK = "additionalFeedback";

		[Token(Token = "0x4001AA6")]
		public const string CONVERSATION_STATUS = "conversationStatus";

		[Token(Token = "0x4001AA7")]
		public const string DATA_LATEST_ISSUE_ID = "latestIssueId";

		[Token(Token = "0x4001AA8")]
		public const string DATA_LATEST_ISSUE_PUBLISH_ID = "latestIssuePublishId";

		[Token(Token = "0x4001AA9")]
		public const string DATA_IS_ISSUE_OPEN = "open";

		[Token(Token = "0x4001AAA")]
		public const string CONVERSATION_END = "conversationEnd";

		[Token(Token = "0x4001AAB")]
		public const string CONVERSATION_REJECTED = "conversationRejected";

		[Token(Token = "0x4001AAC")]
		public const string CONVERSATION_RESOLVED = "conversationResolved";

		[Token(Token = "0x4001AAD")]
		public const string CONVERSATION_REOPENED = "conversationReopened";

		[Token(Token = "0x4001AAE")]
		public const string SDK_SESSION_STARTED = "helpshiftSessionStarted";

		[Token(Token = "0x4001AAF")]
		public const string SDK_SESSION_ENDED = "helpshiftSessionEnded";

		[Token(Token = "0x4001AB0")]
		public const string RECEIVED_UNREAD_MESSAGE_COUNT = "receivedUnreadMessageCount";

		[Token(Token = "0x4001AB1")]
		public const string DATA_MESSAGE_COUNT = "count";

		[Token(Token = "0x4001AB2")]
		public const string DATA_MESSAGE_COUNT_FROM_CACHE = "fromCache";

		[Token(Token = "0x4001AB3")]
		public const string ACTION_CLICKED = "userClickOnAction";

		[Token(Token = "0x4001AB4")]
		public const string DATA_ACTION = "actionType";

		[Token(Token = "0x4001AB5")]
		public const string DATA_ACTION_TYPE = "actionData";

		[Token(Token = "0x4001AB6")]
		public const string DATA_ACTION_TYPE_CALL = "call";

		[Token(Token = "0x4001AB7")]
		public const string DATA_ACTION_TYPE_LINK = "link";

		[Token(Token = "0x4001AB8")]
		public const string AGENT_MESSAGE_RECEIVED = "agentMessageReceived";

		[Token(Token = "0x4001AB9")]
		public const string DATA_PUBLISH_ID = "publishId";

		[Token(Token = "0x4001ABA")]
		public const string DATA_CREATED_TIME = "createdTs";

		[Token(Token = "0x4001ABB")]
		public const string DATA_ATTACHMENTS = "attachments";

		[Token(Token = "0x4001ABC")]
		public const string DATA_URL = "url";

		[Token(Token = "0x4001ABD")]
		public const string DATA_CONTENT_TYPE = "contentType";

		[Token(Token = "0x4001ABE")]
		public const string DATA_FILE_NAME = "fileName";

		[Token(Token = "0x4001ABF")]
		public const string DATA_SIZE = "size";

		[Token(Token = "0x4001AC0")]
		public const string DATA_MESSAGE_TYPE_APP_REVIEW_REQUEST = "app_review_request";

		[Token(Token = "0x4001AC1")]
		public const string DATA_MESSAGE_TYPE_SCREENSHOT_REQUEST = "screenshot_request";

		[Token(Token = "0x4001AC2")]
		public const string ATTRIBUTES_DATA_INVALID = "attributesDataInvalid";

		[Token(Token = "0x4001AC3")]
		public const string MASTER_ATTRIBUTES_VALIDATION_FAILED = "masterAttributesValidationFailed";

		[Token(Token = "0x4001AC4")]
		public const string MASTER_ATTRIBUTES_SYNC_FAILED = "masterAttributesSyncFailed";

		[Token(Token = "0x4001AC5")]
		public const string MASTER_ATTRIBUTES_LIMIT_EXCEEDED = "masterAttributesLimitExceeded";

		[Token(Token = "0x4001AC6")]
		public const string APP_ATTRIBUTES_VALIDATION_FAILED = "appAttributesValidationFailed";

		[Token(Token = "0x4001AC7")]
		public const string APP_ATTRIBUTES_SYNC_FAILED = "appAttributesSyncFailed";

		[Token(Token = "0x4001AC8")]
		public const string APP_ATTRIBUTES_LIMIT_EXCEEDED = "appAttributesLimitExceeded";

		[Token(Token = "0x4001AC9")]
		public const string IDENTITY_DATA_SYNC_FAILED = "identityDataSyncFailed";

		[Token(Token = "0x4001ACA")]
		public const string USER_SESSION_EXPIRED = "userSessionExpired";

		[Token(Token = "0x4001ACB")]
		public const string USER_IDENTITY_NOT_ENABLED = "userIdentityNotEnabled";

		[Token(Token = "0x4001ACC")]
		public const string REFRESH_USER_CREDENTIALS = "refreshUserCredentials";

		[Token(Token = "0x4001ACD")]
		public const string LOGIN_IN_PROGRESS = "loginInProgress";

		[Token(Token = "0x4001ACE")]
		public const string LOGIN_CONFIG_INVALID = "loginConfigInvalid";

		[Token(Token = "0x4001ACF")]
		public const string IDENTITY_TOKEN_INVALID = "identityTokenInvalid";

		[Token(Token = "0x4001AD0")]
		public const string IDENTITY_DATA_INVALID = "identitiesDataInvalid";

		[Token(Token = "0x4001AD1")]
		public const string LOGIN_CONFIG_SIZE_LIMIT_EXCEEDED = "loginConfigSizeLimitExceeded";

		[Token(Token = "0x4001AD2")]
		public const string IDENTITIES_SIZE_LIMIT_EXCEEDED = "identitiesSizeLimitExceeded";

		[Token(Token = "0x4001AD3")]
		public const string IDENTITY_FEATURE_NOT_ENABLED = "identityFeatureNotEnabled";

		[Token(Token = "0x4001AD4")]
		public const string UID_OR_EMAIL_IS_MANDATORY = "uidOrEmailIsMandatory";

		[Token(Token = "0x4001AD5")]
		public const string IAT_IS_MANDATORY = "iatIsMandatory";

		[Token(Token = "0x4001AD6")]
		public const string NETWORK_ERROR = "networkError";

		[Token(Token = "0x4001AD7")]
		public const string UNKNOWN_ERROR = "unknownError";

		[Token(Token = "0x4001AD8")]
		public const string INVALID_VALUE_TYPE = "invalidValueType";

		[Token(Token = "0x4001AD9")]
		public const string INVALID_DATA = "invalidData";

		[Token(Token = "0x4001ADA")]
		public const string EXCEEDED_KEY_LENGTH_LIMIT = "exceededKeyLengthLimit";

		[Token(Token = "0x4001ADB")]
		public const string METADATA_EXCEEDED_KEY_LENGTH_LIMIT = "metadataExceededKeyLengthLimit";

		[Token(Token = "0x4001ADC")]
		public const string EXCEEDED_VALUE_LENGTH_LIMIT = "exceededValueLengthLimit";

		[Token(Token = "0x4001ADD")]
		public const string METADATA_EXCEEDED_VALUE_LENGTH_LIMIT = "metadataExceededValueLengthLimit";

		[Token(Token = "0x4001ADE")]
		public const string EMPTY_DATA = "emptyData";

		[Token(Token = "0x4001ADF")]
		public const string METADATA_EMPTY_KEY_OR_VALUE = "metadataEmptyKeyOrValue";

		[Token(Token = "0x4001AE0")]
		public const string EXCEEDED_COUNT_LIMIT = "exceededCountLimit";

		[Token(Token = "0x4001AE1")]
		public const string METADATA_EXCEEDED_COUNT_LIMIT = "metadataExceededCountLimit";

		[Token(Token = "0x60021E8")]
		[Address(RVA = "0x3DCCBB8", Offset = "0x3DCCBB8", Length = "0x8")]
		public HelpshiftEvent()
		{
		}
	}
}
