using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace EmailAction.Shared
{
	public static class ChooseEmailActionSheetPresenter
	{
		public static List<UIAlertAction> PopulateAppActionArray(string emailString, string escapedSubjectString)
		{

			var actionArray = new List<UIAlertAction>();


			var gmail = OpenGmailSupportAction(emailString, escapedSubjectString);

			if(gmail != null)
			{
				actionArray.Add(gmail);
			}

			var inbox = OpenInboxSupportAction(withFrom: emailString, withSubject: escapedSubjectString);

			if(inbox != null)
			{
				actionArray.Add(inbox);
			}

			var outlookUrl = OpenOutlookSupportAction(withFrom: emailString, withSubject: escapedSubjectString);

			if(outlookUrl != null)
			{
				actionArray.Add(outlookUrl);
			}

			var dispatchUrl = OpenDispatchSupportAction(withFrom: emailString, withSubject: escapedSubjectString);

			if(dispatchUrl != null)
			{
				actionArray.Add(dispatchUrl);
			}

			var mailUrl = OpenMailSupportAction(withFrom: emailString, withSubject: escapedSubjectString);

			if (mailUrl != null)
			{
				actionArray.Add(mailUrl);
			}

			var airmailUrl = OpenAirmailSupportAction(withFrom: emailString, withSubject: escapedSubjectString);

			if (airmailUrl != null)
			{
				actionArray.Add(airmailUrl);
			}

			return actionArray;
		}


		internal static UIAlertAction OpenGmailSupportAction(string withFrom, string withSubject)
		{
			ValidateOpenActionArguments(withFrom, withSubject);

			var gmailUrlString = "googlegmail:///";

			gmailUrlString += $"co?to={withFrom}";

			gmailUrlString += $"&subject={withSubject}";

			return OpenAction(withUrl: gmailUrlString, andTitleActionTitle: "Gmail");

		}

		private static void ValidateOpenActionArguments(string withFrom, string withSubject)
		{
			if (withFrom == null)
			{
				//throw new ArgumentException("Argument cannot be null", nameof(withFrom));
			}

			if (withSubject == null)
			{
				//throw new ArgumentException("Argument cannot be null", nameof(withSubject));
			}
		}

		internal static UIAlertAction OpenAirmailSupportAction(string withFrom, string withSubject)
		{

			ValidateOpenActionArguments(withFrom, withSubject);

			var airmailUrlString = "airmail://";
			airmailUrlString += $"compose?to={withFrom}";
			airmailUrlString += $"&subject={withSubject}";

			return OpenAction(withUrl: airmailUrlString, andTitleActionTitle: "Airmail");

		}

		internal static UIAlertAction OpenInboxSupportAction(string withFrom, string withSubject)
		{
			ValidateOpenActionArguments(withFrom, withSubject);

			var inboxUrlString = "inbox-gmail://";
			inboxUrlString += $"co?to={withFrom}";
			inboxUrlString += $"&subject={withSubject}";

			return OpenAction(withUrl: inboxUrlString, andTitleActionTitle: "Inbox");

		}

		internal static UIAlertAction OpenOutlookSupportAction(string withFrom, string withSubject)
		{
			ValidateOpenActionArguments(withFrom, withSubject);

			var mailUrlString = "ms-outlook://";
			mailUrlString += $"compose?to={withFrom}";
			mailUrlString += $"&subject={withSubject}";

			return OpenAction(withUrl: mailUrlString, andTitleActionTitle: "Outlook");

		}

		internal static UIAlertAction OpenDispatchSupportAction(string withFrom, string withSubject)
		{
			ValidateOpenActionArguments(withFrom, withSubject);

			var dispatchUrlString = "x-dispatch:///";
			dispatchUrlString += $"compose?from={withFrom}";
			dispatchUrlString += $"&subject={withSubject}";

			return OpenAction(withUrl: dispatchUrlString, andTitleActionTitle: "Dispatch");

		}

		internal static UIAlertAction OpenMailSupportAction(string withFrom, string withSubject)
		{
			ValidateOpenActionArguments(withFrom, withSubject);

			var mailUrlString = "message:";

			//mailUrlString += withFrom;
			//mailUrlString += $"?subject={withSubject}";

			return OpenAction(withUrl: mailUrlString, andTitleActionTitle: "Mail (Default)");

		}

		public static UIAlertAction OpenSafariAction(string url)
		{
            url += "";

			var nsurl = new NSUrl(url);


			var safariAction = UIAlertAction.Create("Open with Safari", UIAlertActionStyle.Default, action =>
			{
				UIApplication.SharedApplication.OpenUrl(nsurl);
			} );

			return safariAction;

		}

		internal static UIAlertAction OpenAction(string withUrl, string andTitleActionTitle)
		{
			var url = new NSUrl(withUrl);

			if (url == null)
			{
				throw new ArgumentException("Argument URL cannot be null", nameof(withUrl));
			}
			if(!UIApplication.SharedApplication.CanOpenUrl(url))
			{
				return null;
			}

			var action = UIAlertAction.Create(andTitleActionTitle, UIAlertActionStyle.Default,
				alertAction => { UIApplication.SharedApplication.OpenUrl(url); });

			return action;

		}
	}
}
