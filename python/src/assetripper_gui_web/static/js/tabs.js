// Minimal tab switching for the Bootstrap markup this GUI uses (2026-08-03).
//
// Only `bootstrap.min.css` is vendored, not `bootstrap.bundle.min.js`. Bootstrap's tab classes
// (`.nav-link.active`, `.tab-pane.show.active`) are pure CSS; its JS does nothing here but move
// those classes around on click. That is ~20 lines, so it lives here instead of adding an ~80 KB
// vendored script -- which would also have to be fetched at build time, and this port keeps its
// GUI assets fully offline (see ROADMAP Phase 11).
//
// Deliberately narrower than Bootstrap's real Tab component: no keyboard arrow navigation, no
// `show.bs.tab`/`shown.bs.tab` events, no fade timing. Nothing in this GUI uses any of that.
(function () {
  "use strict";

  function activate(trigger) {
    var selector = trigger.getAttribute("data-bs-target");
    var pane = selector && document.querySelector(selector);
    if (!pane) {
      return;
    }

    var tabList = trigger.closest("[role='tablist']");
    var paneGroup = pane.parentElement;
    if (!tabList || !paneGroup) {
      return;
    }

    tabList.querySelectorAll(".nav-link").forEach(function (other) {
      other.classList.remove("active");
      other.setAttribute("aria-selected", "false");
    });
    Array.prototype.forEach.call(paneGroup.children, function (other) {
      other.classList.remove("show", "active");
    });

    trigger.classList.add("active");
    trigger.setAttribute("aria-selected", "true");
    pane.classList.add("show", "active");
  }

  document.addEventListener("click", function (event) {
    var trigger = event.target.closest("[data-bs-toggle='tab']");
    if (trigger) {
      event.preventDefault();
      activate(trigger);
    }
  });
})();
