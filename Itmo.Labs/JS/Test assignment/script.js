const dragArea = document.getElementById('dragArea');
const draggables = document.querySelectorAll('.draggable');

draggables.forEach(draggable => {
    draggable.addEventListener('dragstart', () => {
        draggable.classList.add('dragging');
    });

    draggable.addEventListener('dragend', () => {
        draggable.classList.remove('dragging');
    });
});

dragArea.addEventListener('dragover', (event) => {
    event.preventDefault();
    dragArea.classList.add('hovered');
});

dragArea.addEventListener('dragleave', () => {
    dragArea.classList.remove('hovered');
});

dragArea.addEventListener('drop', (event) => {
    event.preventDefault(); 
    const draggingElement = document.querySelector('.dragging');
    dragArea.appendChild(draggingElement);
    dragArea.classList.remove('hovered');
});
