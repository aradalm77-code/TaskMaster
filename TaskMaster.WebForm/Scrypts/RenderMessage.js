import { CloseMessageBtn, TitleMessageel, TextMessageel, ErrorMessageForm } from './elements.js';


    const allowedTypes = ['success', 'error', 'warning'];

// Show message
export const RenderMessage = (type, title, text) => {
    if (!allowedTypes.includes(type)) {
        type = 'success';
    }

    ErrorMessageForm.classList.remove('success', 'error', 'warning');
    ErrorMessageForm.classList.add(type);

    TitleMessageel.textContent = title;
    TextMessageel.textContent = text;

    // Restart the animation if already active
    ErrorMessageForm.classList.remove('active');

    requestAnimationFrame(function () {
        ErrorMessageForm.classList.add('active');
    });

}
// Close button
if (CloseMessageBtn) {
    CloseMessageBtn.addEventListener('click', () => {
        ErrorMessageForm.classList.remove('active');
    });
}
