// Session 26: Animating the User Interface
// Simple demonstration application

console.log('Session 26 loaded');

document.addEventListener('DOMContentLoaded', function() {
    const box = document.querySelector('.animated-box');
    const btn = document.getElementById('animate-btn');
    
    btn.addEventListener('click', function() {
        box.classList.add('animate');
        setTimeout(() => {
            box.classList.remove('animate');
        }, 1000);
    });
});
