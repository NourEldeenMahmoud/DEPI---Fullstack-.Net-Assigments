// Session 18: Creating a Form and Validating User Input
// Simple demonstration application

console.log('Session 18 loaded');

document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('demo-form');
    const resultDiv = document.getElementById('form-result');
    
    form.addEventListener('submit', function(e) {
        e.preventDefault();
        
        const formData = new FormData(form);
        const data = Object.fromEntries(formData);
        
        // Simple validation
        if (data.name && data.email && data.message) {
            resultDiv.className = 'success';
            resultDiv.style.display = 'block';
            resultDiv.innerHTML = `<strong>Success!</strong><br>Name: ${data.name}<br>Email: ${data.email}<br>Message: ${data.message}`;
            form.reset();
        } else {
            resultDiv.className = 'error';
            resultDiv.style.display = 'block';
            resultDiv.innerHTML = '<strong>Error!</strong> Please fill all fields.';
        }
    });
});
