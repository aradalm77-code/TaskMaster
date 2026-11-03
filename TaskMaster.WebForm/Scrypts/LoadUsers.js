import { usersTableBody, SearchUserInput, TotalUsersNum, DesignerCount, InternCount } from './elements.js'
import { RenderMessage } from './RenderMessage.js'



const LoadUsers = () => {
    if (PageMethods.LoadUser == null) return;
    PageMethods.LoadUser(
        function (users) {
            TotalUsersNum.textContent = `${users.length}`;
            let designerCount = 0;
            let internCount = 0;
            users.forEach(user => {
                user.Role == 0 ? designerCount += 1 : internCount += 1;
            })
            DesignerCount.textContent = `${designerCount}`;
            InternCount.textContent = `${internCount}`;
            RenderUsers(users);
        },
        function (error) {
            RenderMessage(
                'error',
                "Failed to load users",
                `${error.get_message()}`
            )
        }
    )
}
const SearchUser = () => {
    let typingTimer;
    clearTimeout(typingTimer);

    typingTimer = setTimeout(() => {
        PageMethods.SearchUser(
            SearchUserInput.value,
            function (users) {
                RenderUsers(users);
            },
            function (error) {
                console.error("Failed to load users:", error.get_message());
            })
    }, 1000)
    console.log(SearchUserInput.value);
}

function RenderUsers(users) {
    usersTableBody.innerHTML = "";

    users.forEach((user) => {

        const fullName = `${user.FirstName} ${user.LastName}`;
        let level = "";
        switch (user.Level) {
            case 0:
                level = "Begginer";
                break;
            case 1:
                level = "MidLevel";
                break;
            case 2:
                level = "Advanced";
                break;
        }
        let role = "";
        switch (user.Role) {
            case 0:
                role = "Designer";
                break;
            case 1:
                role = "Intern"
        }

        const avatar = fullName[0].toUpperCase() + fullName[1].toUpperCase(); 

        const row = `
                    <tr>
                        <td>
                            <div class="user-cell">
                                <div class="avatar">${avatar}</div>
                                <div>
                                    <div class="user-name">${fullName}</div>
                                    <div class="user-username">@${user.Username}</div>
                                </div>
                            </div>
                        </td>
                        <td><span class="role-badge">✳ ${role}</span></td>
                        <td><span class="level">${level}</span></td>
                        <td><span class="score">${user.Score}</span></td>
                        <td>
                            <div class="action-buttons">
                                <button type="button" class="action-button" aria-label="View user">↗</button>
                                <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                            </div>
                        </td>
                    </tr>

`;

        usersTableBody.insertAdjacentHTML("beforeend", row)
    });
}

document.addEventListener("DOMContentLoaded", LoadUsers);
SearchUserInput?.addEventListener("input", SearchUser);