// For enabling and disabling descriptions based on the selected option in a select element
document.addEventListener('DOMContentLoaded', function () {
	// Get all select elements on the page
	var selects = document.querySelectorAll('select');

	// Iterate through each select element
	selects.forEach(function (select) {
		// Add event listener to the select element to update the descriptions
		select.addEventListener('change', function () {
			for (let i = 0; i < select.options.length; i++) {
				var option = select.options[i];
				var descriptionId = option.getAttribute('option-description');
				var description = document.getElementById(descriptionId);
				if (description) {
					if (i == select.selectedIndex) {
						//Enable description
						description.classList.remove('disabled');
					}
					else {
						//Disable description
						description.classList.add('disabled');
					}
				}
			}
		});

		// Trigger initial update to display the description for the default selected option
		select.dispatchEvent(new Event('change'));
	});
});

// For loading dynamic content into pre elements. Exposed on window so content
// injected later (e.g. by the exported-project explorer's AJAX preview panel)
// can trigger it again, since DOMContentLoaded only fires once.
window.loadDynamicTextContent = function (root = document) {
	const preElements = root.querySelectorAll('pre[dynamic-text-content]');

	preElements.forEach(async (preElement) => {
		const url = preElement.getAttribute('dynamic-text-content');

		try {
			const response = await fetch(url);
			if (!response.ok) {
				throw new Error(`Network response was not ok: ${response.statusText}`);
			}
			const data = await response.text();
			preElement.textContent = data;
		} catch (error) {
			console.error('Error fetching the content:', error);
			preElement.textContent = `Failed to load content: ${error.message}`;
		}
	});
};

document.addEventListener("DOMContentLoaded", () => {
	window.loadDynamicTextContent();
});

// For copying a value to the clipboard. Any element carrying a copy-text attribute copies it when
// clicked, which is delegated off the document so it also covers rows rendered after load.
//
// The clipboard API only exists in a secure context. AssetRipper is normally reached on localhost,
// which counts as one, but it can be bound to another address, so the selection fallback stays.
document.addEventListener('click', function (event) {
	const trigger = event.target.closest('[copy-text]');
	if (!trigger) {
		return;
	}

	event.preventDefault();
	const text = trigger.getAttribute('copy-text');

	const report = (ok) => {
		const original = trigger.getAttribute('copy-label') ?? trigger.textContent;
		trigger.setAttribute('copy-label', original);
		trigger.textContent = ok ? 'Copied' : 'Press Ctrl+C';
		setTimeout(() => { trigger.textContent = original; }, 1200);
	};

	if (navigator.clipboard && window.isSecureContext) {
		navigator.clipboard.writeText(text).then(() => report(true), () => report(copyBySelection(text)));
		return;
	}

	report(copyBySelection(text));
});

// The pre-clipboard-API way: put the text in an off-screen field, select it, and ask the document to
// copy the selection.
function copyBySelection(text) {
	const field = document.createElement('textarea');
	field.value = text;
	field.setAttribute('readonly', '');
	field.style.position = 'fixed';
	field.style.left = '-9999px';
	document.body.appendChild(field);

	try {
		field.select();
		return document.execCommand('copy');
	} catch (error) {
		console.error('Could not copy to the clipboard:', error);
		return false;
	} finally {
		document.body.removeChild(field);
	}
}
