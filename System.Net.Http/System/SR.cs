using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Net.Http;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	private const string s_resourcesName = "FxResources.System.Net.Http.SR";

	private static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(ResourceType));

	internal static string net_securityprotocolnotsupported => GetResourceString("net_securityprotocolnotsupported", null);

	internal static string net_http_httpmethod_format_error => GetResourceString("net_http_httpmethod_format_error", null);

	internal static string net_http_reasonphrase_format_error => GetResourceString("net_http_reasonphrase_format_error", null);

	internal static string net_http_copyto_array_too_small => GetResourceString("net_http_copyto_array_too_small", null);

	internal static string net_http_headers_not_found => GetResourceString("net_http_headers_not_found", null);

	internal static string net_http_headers_single_value_header => GetResourceString("net_http_headers_single_value_header", null);

	internal static string net_http_headers_invalid_header_name => GetResourceString("net_http_headers_invalid_header_name", null);

	internal static string net_http_headers_invalid_value => GetResourceString("net_http_headers_invalid_value", null);

	internal static string net_http_headers_not_allowed_header_name => GetResourceString("net_http_headers_not_allowed_header_name", null);

	internal static string net_http_headers_invalid_host_header => GetResourceString("net_http_headers_invalid_host_header", null);

	internal static string net_http_headers_invalid_from_header => GetResourceString("net_http_headers_invalid_from_header", null);

	internal static string net_http_headers_invalid_etag_name => GetResourceString("net_http_headers_invalid_etag_name", null);

	internal static string net_http_headers_invalid_range => GetResourceString("net_http_headers_invalid_range", null);

	internal static string net_http_headers_no_newlines => GetResourceString("net_http_headers_no_newlines", null);

	internal static string net_http_content_buffersize_exceeded => GetResourceString("net_http_content_buffersize_exceeded", null);

	internal static string net_http_content_no_task_returned => GetResourceString("net_http_content_no_task_returned", null);

	internal static string net_http_content_stream_already_read => GetResourceString("net_http_content_stream_already_read", null);

	internal static string net_http_content_readonly_stream => GetResourceString("net_http_content_readonly_stream", null);

	internal static string net_http_content_invalid_charset => GetResourceString("net_http_content_invalid_charset", null);

	internal static string net_http_content_stream_copy_error => GetResourceString("net_http_content_stream_copy_error", null);

	internal static string net_http_argument_empty_string => GetResourceString("net_http_argument_empty_string", null);

	internal static string net_http_client_request_already_sent => GetResourceString("net_http_client_request_already_sent", null);

	internal static string net_http_operation_started => GetResourceString("net_http_operation_started", null);

	internal static string net_http_client_execution_error => GetResourceString("net_http_client_execution_error", null);

	internal static string net_http_client_absolute_baseaddress_required => GetResourceString("net_http_client_absolute_baseaddress_required", null);

	internal static string net_http_client_invalid_requesturi => GetResourceString("net_http_client_invalid_requesturi", null);

	internal static string net_http_client_http_baseaddress_required => GetResourceString("net_http_client_http_baseaddress_required", null);

	internal static string net_http_parser_invalid_base64_string => GetResourceString("net_http_parser_invalid_base64_string", null);

	internal static string net_http_handler_noresponse => GetResourceString("net_http_handler_noresponse", null);

	internal static string net_http_handler_norequest => GetResourceString("net_http_handler_norequest", null);

	internal static string net_http_message_not_success_statuscode => GetResourceString("net_http_message_not_success_statuscode", null);

	internal static string net_http_content_field_too_long => GetResourceString("net_http_content_field_too_long", null);

	internal static string net_http_log_headers_no_newlines => GetResourceString("net_http_log_headers_no_newlines", null);

	internal static string net_http_log_headers_invalid_quality => GetResourceString("net_http_log_headers_invalid_quality", null);

	internal static string net_http_log_headers_wrong_email_format => GetResourceString("net_http_log_headers_wrong_email_format", null);

	internal static string net_http_handler_not_assigned => GetResourceString("net_http_handler_not_assigned", null);

	internal static string net_http_invalid_enable_first => GetResourceString("net_http_invalid_enable_first", null);

	internal static string net_http_content_buffersize_limit => GetResourceString("net_http_content_buffersize_limit", null);

	internal static string net_http_value_not_supported => GetResourceString("net_http_value_not_supported", null);

	internal static string net_http_io_read => GetResourceString("net_http_io_read", null);

	internal static string net_http_io_read_incomplete => GetResourceString("net_http_io_read_incomplete", null);

	internal static string net_http_io_write => GetResourceString("net_http_io_write", null);

	internal static string net_http_chunked_not_allowed_with_empty_content => GetResourceString("net_http_chunked_not_allowed_with_empty_content", null);

	internal static string net_http_invalid_cookiecontainer => GetResourceString("net_http_invalid_cookiecontainer", null);

	internal static string net_http_invalid_proxyusepolicy => GetResourceString("net_http_invalid_proxyusepolicy", null);

	internal static string net_http_invalid_proxy => GetResourceString("net_http_invalid_proxy", null);

	internal static string net_http_handler_nocontentlength => GetResourceString("net_http_handler_nocontentlength", null);

	internal static string net_http_value_must_be_greater_than => GetResourceString("net_http_value_must_be_greater_than", null);

	internal static string MailHeaderFieldInvalidCharacter => GetResourceString("MailHeaderFieldInvalidCharacter", null);

	internal static string MailAddressInvalidFormat => GetResourceString("MailAddressInvalidFormat", null);

	internal static string MailHeaderFieldMalformedHeader => GetResourceString("MailHeaderFieldMalformedHeader", null);

	internal static string InvalidHeaderName => GetResourceString("InvalidHeaderName", null);

	internal static string net_cookie_attribute => GetResourceString("net_cookie_attribute", null);

	internal static string net_http_unix_invalid_credential => GetResourceString("net_http_unix_invalid_credential", null);

	internal static string net_http_unix_https_support_unavailable_libcurl => GetResourceString("net_http_unix_https_support_unavailable_libcurl", null);

	internal static string ArgumentOutOfRange_FileLengthTooBig => GetResourceString("ArgumentOutOfRange_FileLengthTooBig", null);

	internal static string IO_FileExists_Name => GetResourceString("IO_FileExists_Name", null);

	internal static string IO_FileNotFound => GetResourceString("IO_FileNotFound", null);

	internal static string IO_FileNotFound_FileName => GetResourceString("IO_FileNotFound_FileName", null);

	internal static string IO_PathNotFound_NoPathName => GetResourceString("IO_PathNotFound_NoPathName", null);

	internal static string IO_PathNotFound_Path => GetResourceString("IO_PathNotFound_Path", null);

	internal static string IO_PathTooLong => GetResourceString("IO_PathTooLong", null);

	internal static string IO_SharingViolation_File => GetResourceString("IO_SharingViolation_File", null);

	internal static string IO_SharingViolation_NoFileName => GetResourceString("IO_SharingViolation_NoFileName", null);

	internal static string UnauthorizedAccess_IODenied_NoPathName => GetResourceString("UnauthorizedAccess_IODenied_NoPathName", null);

	internal static string UnauthorizedAccess_IODenied_Path => GetResourceString("UnauthorizedAccess_IODenied_Path", null);

	internal static string net_http_content_no_concurrent_reads => GetResourceString("net_http_content_no_concurrent_reads", null);

	internal static string net_http_username_empty_string => GetResourceString("net_http_username_empty_string", null);

	internal static string net_http_no_concurrent_io_allowed => GetResourceString("net_http_no_concurrent_io_allowed", null);

	internal static string net_http_unix_invalid_response => GetResourceString("net_http_unix_invalid_response", null);

	internal static string net_http_unix_handler_disposed => GetResourceString("net_http_unix_handler_disposed", null);

	internal static string net_http_buffer_insufficient_length => GetResourceString("net_http_buffer_insufficient_length", null);

	internal static string net_http_response_headers_exceeded_length => GetResourceString("net_http_response_headers_exceeded_length", null);

	internal static string ArgumentOutOfRange_NeedPosNum => GetResourceString("ArgumentOutOfRange_NeedPosNum", null);

	internal static string NotSupported_UnreadableStream => GetResourceString("NotSupported_UnreadableStream", null);

	internal static string NotSupported_UnwritableStream => GetResourceString("NotSupported_UnwritableStream", null);

	internal static string ObjectDisposed_StreamClosed => GetResourceString("ObjectDisposed_StreamClosed", null);

	internal static string net_http_libcurl_callback_notsupported => GetResourceString("net_http_libcurl_callback_notsupported", null);

	internal static string net_http_libcurl_clientcerts_notsupported => GetResourceString("net_http_libcurl_clientcerts_notsupported", null);

	internal static string net_http_libcurl_revocation_notsupported => GetResourceString("net_http_libcurl_revocation_notsupported", null);

	internal static Type ResourceType => typeof(SR);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}
}
