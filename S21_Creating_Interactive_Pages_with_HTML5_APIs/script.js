// Session 22: Creating Interactive Pages with HTML5 APIs
// Simple demonstration application

console.log('Session 22 loaded');

document.addEventListener('DOMContentLoaded', function() {
    const fileInput = document.getElementById('file-input');
    const readBtn = document.getElementById('read-file-btn');
    const contentDiv = document.getElementById('file-content');
    
    readBtn.addEventListener('click', function() {
        const file = fileInput.files[0];
        if (!file) {
            contentDiv.innerHTML = '<p class="error">Please select a file first.</p>';
            return;
        }
        
        const reader = new FileReader();
        
        reader.onload = function(e) {
            contentDiv.innerHTML = `
                <div class="success">
                    <h4>File: ${file.name}</h4>
                    <p><strong>Size:</strong> ${file.size} bytes</p>
                    <p><strong>Type:</strong> ${file.type}</p>
                    <pre style="background: #f5f5f5; padding: 10px; border-radius: 5px; margin-top: 10px; overflow-x: auto;">${e.target.result}</pre>
                </div>
            `;
        };
        
        reader.onerror = function() {
            contentDiv.innerHTML = '<p class="error">Error reading file.</p>';
        };
        
        if (file.type.startsWith('text/') || file.name.endsWith('.json')) {
            reader.readAsText(file);
        } else {
            reader.readAsDataURL(file);
        }
    });
});
