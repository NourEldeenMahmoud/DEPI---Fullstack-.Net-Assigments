// Session 23: Adding Offline Support to Web Applications
// Simple demonstration application

console.log('Session 23 loaded');

document.addEventListener('DOMContentLoaded', function() {
    const input = document.getElementById('storage-input');
    const saveBtn = document.getElementById('save-btn');
    const loadBtn = document.getElementById('load-btn');
    const clearBtn = document.getElementById('clear-btn');
    const display = document.getElementById('storage-display');
    
    saveBtn.addEventListener('click', function() {
        const data = input.value;
        if (data) {
            localStorage.setItem('demoData', data);
            display.innerHTML = '<p class="success">Data saved!</p>';
            input.value = '';
        }
    });
    
    loadBtn.addEventListener('click', function() {
        const data = localStorage.getItem('demoData');
        if (data) {
            display.innerHTML = `<p><strong>Stored data:</strong> ${data}</p>`;
        } else {
            display.innerHTML = '<p>No data found.</p>';
        }
    });
    
    clearBtn.addEventListener('click', function() {
        localStorage.removeItem('demoData');
        display.innerHTML = '<p>Data cleared.</p>';
    });
    
    // Load on page load
    loadBtn.click();
});
