// Session 19: Communicating with a Remote Data Source
// Simple demonstration application

console.log('Session 19 loaded');

document.addEventListener('DOMContentLoaded', function() {
    const fetchBtn = document.getElementById('fetch-btn');
    const display = document.getElementById('data-display');
    
    fetchBtn.addEventListener('click', function() {
        display.innerHTML = '<p>Loading...</p>';
        
        // Using fetch API (modern approach)
        fetch('https://jsonplaceholder.typicode.com/posts/1')
            .then(response => response.json())
            .then(data => {
                display.innerHTML = `
                    <div class="success">
                        <h4>Fetched Data:</h4>
                        <p><strong>Title:</strong> ${data.title}</p>
                        <p><strong>Body:</strong> ${data.body}</p>
                    </div>
                `;
            })
            .catch(error => {
                display.innerHTML = `<div class="error">Error: ${error.message}</div>`;
            });
    });
});
