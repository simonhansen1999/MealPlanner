// print.js
// Cross-platform print helper (Windows / Linux / macOS safe)

window.printDiv = function (divId) {
    try {
        const el = document.getElementById(divId);
        if (!el) return;

        // Prevent printing empty content
        const table = el.querySelector('table.print-table');
        if (!table || table.querySelectorAll('tbody tr').length === 0) return;

        // Extract list name
        const inputName = el.querySelector('input');
        const listName = inputName?.value?.trim() || "Indkøbsliste";

        // Remove existing wrapper if any
        document.getElementById('temp-print-wrapper')?.remove();

        // Create wrapper
        const wrapper = document.createElement('div');
        wrapper.id = 'temp-print-wrapper';

        // Header
        const now = new Date();
        const dateString = now.toLocaleDateString(undefined, {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });

        const header = document.createElement('div');
        header.className = 'print-header';
        header.innerHTML = `
            <h2>${escapeHtml(listName)}</h2>
            <div class="meta">Udskrevet: ${escapeHtml(dateString)}</div>
        `;

        // Clone content and remove UI elements
        const clone = el.cloneNode(true);
        clone.querySelectorAll(
            'button, input, select, .btn, .btn-group, .no-print, .accordion'
        ).forEach(n => n.remove());

        wrapper.appendChild(header);
        wrapper.appendChild(clone);
        document.body.appendChild(wrapper);

        setTimeout(() => {
            window.print();
            setTimeout(() => wrapper.remove(), 500);
        }, 200);

        function escapeHtml(text) {
            return text
                ?.replace(/&/g, "&amp;")
                .replace(/</g, "&lt;")
                .replace(/>/g, "&gt;")
                .replace(/"/g, "&quot;")
                .replace(/'/g, "&#39;") || "";
        }

    } catch (e) {
        console.error("printDiv failed", e);
    }
};
