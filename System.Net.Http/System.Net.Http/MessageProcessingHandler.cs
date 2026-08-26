using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public abstract class MessageProcessingHandler : DelegatingHandler
{
	private sealed class SendState : TaskCompletionSource<HttpResponseMessage>
	{
		internal readonly MessageProcessingHandler _handler;

		internal readonly CancellationToken _token;

		public SendState(MessageProcessingHandler handler, CancellationToken token)
		{
			_handler = handler;
			_token = token;
		}
	}

	protected MessageProcessingHandler()
	{
	}

	protected MessageProcessingHandler(HttpMessageHandler innerHandler)
		: base(innerHandler)
	{
	}

	protected abstract HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken);

	protected abstract HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken);

	protected internal sealed override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (request == null)
		{
			throw new ArgumentNullException("request", System.SR.net_http_handler_norequest);
		}
		SendState sendState = new SendState(this, cancellationToken);
		try
		{
			HttpRequestMessage request2 = ProcessRequest(request, cancellationToken);
			Task<HttpResponseMessage> task = base.SendAsync(request2, cancellationToken);
			task.ContinueWithStandard(sendState, delegate(Task<HttpResponseMessage> task2, object state)
			{
				SendState sendState2 = (SendState)state;
				MessageProcessingHandler handler = sendState2._handler;
				CancellationToken token = sendState2._token;
				if (task2.IsFaulted)
				{
					sendState2.TrySetException(task2.Exception.GetBaseException());
				}
				else if (task2.IsCanceled)
				{
					sendState2.TrySetCanceled();
				}
				else
				{
					if (task2.Result != null)
					{
						try
						{
							HttpResponseMessage result = handler.ProcessResponse(task2.Result, token);
							sendState2.TrySetResult(result);
							return;
						}
						catch (OperationCanceledException e2)
						{
							HandleCanceledOperations(token, sendState2, e2);
							return;
						}
						catch (Exception exception2)
						{
							sendState2.TrySetException(exception2);
							return;
						}
					}
					sendState2.TrySetException(new InvalidOperationException(System.SR.net_http_handler_noresponse));
				}
			});
		}
		catch (OperationCanceledException e)
		{
			HandleCanceledOperations(cancellationToken, sendState, e);
		}
		catch (Exception exception)
		{
			sendState.TrySetException(exception);
		}
		return sendState.Task;
	}

	private static void HandleCanceledOperations(CancellationToken cancellationToken, TaskCompletionSource<HttpResponseMessage> tcs, OperationCanceledException e)
	{
		if (cancellationToken.IsCancellationRequested && e.CancellationToken == cancellationToken)
		{
			tcs.TrySetCanceled();
		}
		else
		{
			tcs.TrySetException(e);
		}
	}
}
