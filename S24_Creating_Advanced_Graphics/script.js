// Session 25: Creating Advanced Graphics
// Simple demonstration application

console.log('Session 25 loaded');

document.addEventListener('DOMContentLoaded', function() {
    // SVG Demo
    const svg = document.getElementById('svg-demo');
    const circle = document.createElementNS('http://www.w3.org/2000/svg', 'circle');
    circle.setAttribute('cx', '200');
    circle.setAttribute('cy', '150');
    circle.setAttribute('r', '50');
    circle.setAttribute('fill', '#667eea');
    svg.appendChild(circle);
    
    // Canvas Demo
    const canvas = document.getElementById('canvas-demo');
    const ctx = canvas.getContext('2d');
    ctx.fillStyle = '#764ba2';
    ctx.fillRect(50, 50, 100, 100);
    ctx.fillStyle = '#667eea';
    ctx.beginPath();
    ctx.arc(200, 150, 50, 0, Math.PI * 2);
    ctx.fill();
});
