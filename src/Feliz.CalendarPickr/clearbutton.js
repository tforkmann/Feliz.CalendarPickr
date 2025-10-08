// clearbutton.js
export function attachClearButton(instance) {
    // avoid duplicates
    if (!instance || instance._hasClearButton) return;
    instance._hasClearButton = true;

    // create button element
    const button = document.createElement("button");
    button.type = "button";
    button.className = "flatpickr-clear-button";
    button.textContent = "Clear";

    // attach click event
    button.addEventListener("click", () => {
        if (instance && instance.clear) {
            instance.clear();
            instance.close();
        }
    });

    // add it to Flatpickr’s calendar container
    const calendar = instance.calendarContainer;
    if (calendar && !calendar.querySelector(".flatpickr-clear-button")) {
        calendar.appendChild(button);
    }
}

// Hook into Flatpickr lifecycle if globally available
if (window.flatpickr) {
    window.flatpickr.plugins = window.flatpickr.plugins || {};
    window.flatpickr.plugins.clearButton = function () {
        return {
            onReady: (dates, dateStr, instance) => attachClearButton(instance)
        };
    };
}
