// Drives the two-pane exported-project explorer: a lazy, collapsible folder tree
// on the left, and an AJAX-loaded preview panel on the right.
document.addEventListener('DOMContentLoaded', () => {
	const treePanel = document.getElementById('export-tree-panel');
	const treeRoot = document.getElementById('export-tree-root');
	const previewPanel = document.getElementById('export-preview-panel');

	if (!treePanel || !treeRoot || !previewPanel) {
		return;
	}

	const rootPath = treePanel.getAttribute('data-root');
	let activeItem = null;

	async function fetchChildren(path) {
		const response = await fetch(`/Export/Tree?Path=${encodeURIComponent(path)}`);
		if (!response.ok) {
			throw new Error(`Failed to list directory: ${response.statusText}`);
		}
		return await response.json();
	}

	async function selectFile(path, labelElement) {
		if (activeItem) {
			activeItem.classList.remove('active');
		}
		labelElement.classList.add('active');
		activeItem = labelElement;

		previewPanel.innerHTML = '<p class="text-muted">Loading...</p>';
		try {
			const response = await fetch(`/Export/Preview?Path=${encodeURIComponent(path)}`);
			previewPanel.innerHTML = await response.text();
			if (window.loadDynamicTextContent) {
				window.loadDynamicTextContent(previewPanel);
			}
		} catch (error) {
			previewPanel.innerHTML = `<p class="text-danger">Failed to load preview: ${error.message}</p>`;
		}
	}

	function buildList(ul, entries) {
		ul.innerHTML = '';
		entries.forEach((entry) => {
			const li = document.createElement('li');

			if (entry.IsDirectory) {
				li.appendChild(buildFolderItem(entry));
			} else {
				li.appendChild(buildFileItem(entry));
			}

			ul.appendChild(li);
		});
	}

	function buildFolderItem(entry) {
		const wrapper = document.createDocumentFragment();

		const header = document.createElement('div');
		header.className = 'export-tree-item export-tree-folder';

		const toggle = document.createElement('span');
		toggle.className = 'export-tree-toggle';
		toggle.textContent = '▶';
		header.appendChild(toggle);

		const label = document.createElement('span');
		label.className = 'export-tree-label';
		label.textContent = '📁 ' + entry.Name;
		header.appendChild(label);

		const childList = document.createElement('ul');
		childList.className = 'export-tree list-unstyled ps-3';
		childList.style.display = 'none';

		let loaded = false;
		header.addEventListener('click', async () => {
			const isExpanded = childList.style.display !== 'none';
			if (isExpanded) {
				childList.style.display = 'none';
				toggle.textContent = '▶';
				return;
			}

			if (!loaded) {
				try {
					const children = await fetchChildren(entry.Path);
					buildList(childList, children);
					loaded = true;
				} catch (error) {
					childList.innerHTML = `<li class="text-danger small">${error.message}</li>`;
				}
			}

			childList.style.display = '';
			toggle.textContent = '▼';
		});

		wrapper.appendChild(header);
		wrapper.appendChild(childList);
		return wrapper;
	}

	function buildFileItem(entry) {
		const label = document.createElement('div');
		label.className = 'export-tree-item export-tree-file';
		label.textContent = '📄 ' + entry.Name;
		label.addEventListener('click', () => selectFile(entry.Path, label));
		return label;
	}

	// Opening the folder is a side effect, so the page stays where it is and only says when it failed.
	const revealButton = document.getElementById('export-reveal-button');
	if (revealButton) {
		revealButton.addEventListener('click', () => {
			const original = revealButton.textContent;
			fetch(revealButton.dataset.revealUrl)
				.then((response) => {
					if (response.ok) {
						return;
					}
					return response.text().then((text) => { throw new Error(text || response.statusText); });
				})
				.catch((error) => {
					revealButton.textContent = 'Could not open folder';
					revealButton.title = error.message;
					setTimeout(() => { revealButton.textContent = original; }, 4000);
				});
		});
	}

	fetchChildren(rootPath)
		.then((entries) => buildList(treeRoot, entries))
		.catch((error) => {
			treeRoot.innerHTML = `<li class="text-danger small">Failed to load folder tree: ${error.message}</li>`;
		});
});
