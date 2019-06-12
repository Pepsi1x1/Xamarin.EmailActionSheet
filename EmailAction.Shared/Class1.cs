using System;
using System.Collections.Generic;

namespace EmailAction.Shared
{
	public class ChooseEmailActionSheetPresenter
	{

		internal UIAlertAction populateAppActionArray(string emailString, string subject)
		{

			var actionArray = new List<UIAlertAction>();
	

		if let gmail = openGmailSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(gmail)

		}

			if let inbox = openInboxSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(inbox)
	
		}

			if let outlookUrl = openOutlookSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(outlookUrl)
	
		}

			if let dispatchUrl = openDispatchSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(dispatchUrl)
	
		}

			if let mailUrl = openMailSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(mailUrl)
	
		}

			if let airmailUrl = openAirmailSupportAction(withFrom: emailString, withSubject: escapedSubjectString) {
				actionArray.append(airmailUrl)
	
		}

			return actionArray
	
	}


		internal void openGmailSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			var gmailUrlString = "googlegmail:///"
	

		if let from = withFrom {
				gmailUrlString += "co?to=${from)"

		}

			if let subject = withSubject {
				gmailUrlString += "&subject=${subject)"
	
		}

			return openAction(withURL: gmailUrlString, andTitleActionTitle: NSLocalizedString("Gmail", comment: ""))
	
	}

		internal void openAirmailSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			var airmailUrlString = "airmail://"
	

		if let from = withFrom {
				airmailUrlString += "compose?to=${from}"

		}

			if let subject = withSubject {
				airmailUrlString += "&subject=${subject}"
	
		}

			return openAction(withURL: airmailUrlString, andTitleActionTitle: NSLocalizedString("Gmail", comment: ""))
	
	}

		internal void openInboxSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			var inboxUrlString = "inbox-gmail://"
	

		if let from = withFrom {
				inboxUrlString += "co?to=${from)"

		}

			if let subject = withSubject {
				inboxUrlString += "&subject=${subject)"
	
		}

			return openAction(withURL: inboxUrlString, andTitleActionTitle: NSLocalizedString("Inbox", comment: "inbox mail client"))
	
	}

		internal void openOutlookSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			var mailUrlString = "ms-outlook://"
	

		if let from = withFrom {
				mailUrlString += "compose?to=${from)"

		}

			if let subject = withSubject {
				mailUrlString += "&subject=${subject)"
	
		}

			return openAction(withURL: mailUrlString, andTitleActionTitle: NSLocalizedString("Outlook", comment: ""))
	
	}

		internal void openDispatchSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			var dispatchUrlString = "x-dispatch:///"
	

		if let from = withFrom {
				dispatchUrlString += "compose?from=${from)"

		}

			if let subject = withSubject {
				dispatchUrlString += "&subject=${subject)"
	
		}

			return openAction(withURL: dispatchUrlString, andTitleActionTitle: NSLocalizedString("Dispatch", comment: "dispatch mail client"))
	
	}

		internal void openMailSupportAction(withFrom: String?, withSubject: String?) -> UIAlertAction? {

			let mailUrlString = "message:"
	
//        if let from = withFrom {
//            mailUrlString += "${from)"
//        }
//
//        if let subject = withSubject {
//            mailUrlString += "?subject=${subject)"
//        }

			return openAction(withURL: mailUrlString, andTitleActionTitle: NSLocalizedString("Mail (Default)", comment: ""))
	
	}

		internal void openSafariAction() -> UIAlertAction? {

			guard let url = URL(string: "http://www.google.com") else { return nil }

			let safariAction = UIAlertAction(title: NSLocalizedString("Open with Safari", comment: ""), style: .default) {
				(action) in
            
            UIApplication.shared.open(url, options: [:], completionHandler: nil)
	
		}

			return safariAction
	
	}

		internal void openAction(withURL: String, andTitleActionTitle: String) -> UIAlertAction? {

			guard let url = URL(string: withURL), UIApplication.shared.canOpenURL(url) else
			{
				return nil
	
		}

			let action = UIAlertAction(title: andTitleActionTitle, style: .default) {
				(action) in
            
            UIApplication.shared.open(url, options: [:], completionHandler: nil)
	
		}

			return action
	
	}
	}
}
