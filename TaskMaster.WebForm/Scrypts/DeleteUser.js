import { usersTableBody } from './elements.js'
import { RenderMessage } from './RenderMessage.js'

const DeleteUser = () => {
    const deleteButton = event.target.closest(".delete");
    if (!deleteButton) return;
    const row = deleteButton.closest("tr");
    const usernameElement = row.querySelector(".user-username");
    const username = usernameElement.textContent.trim().replace(/^@/, "");

    PageMethods.DeleteUser(
        username,
        function (result) {
            RenderMessage(
                'succes',
                "User successfully Deleted",
                `${result}`
            );
            row.remove();
        },
        function (error) {
            RenderMessage(
                'error',
                "Something went wrong!",
                `${error.get_message()}`
            );
        }
    )
}

usersTableBody?.addEventListener("click", DeleteUser);