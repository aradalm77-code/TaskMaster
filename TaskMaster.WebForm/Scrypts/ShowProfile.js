import { userBadge, userFullName, userLevel, userScore, userSidebarBadge, usersSidebarName, userUsername, userTopbarBadge, Userinfos, RoleBadge } from './elements.js';

export const ShowProfile = () => {
    const user = JSON.parse(localStorage.getItem("name"));
    if (!user) window.location.href = "Login.aspx"; return;
    let role = "";
    switch (user.Role) {
        case 0:
            role = "Designer";
            break;
        case 1:
            role = "Intern";
            break;
    }
    let level = "";
    switch (user.Level) {
        case 0:
            level = "Beginner";
            break;
        case 1:
            level = "MidLevel";
            break;
        case 2:
            level = "Advanced";
            break;
    }
    const fullName = user.Name + " " + User.LastName;
    userFullName.textContent = fullName;
    usersSidebarName.textContent = fullName;
    userUsername.textContent = `@${user.UserName}`;
    const UserBadge = user.Name[0] + user.Name[1];
    userBadge.textContent = UserBadge.ToUperCase();
    userTopbarBadge.textContent = UserBadge.ToUperCase();
    userSidebarBadge.textContent = UserBadge.ToUperCase();
    userLevel.textContent = level;
    userScore.textContent = user.Score;
    Userinfos[0].textContent = user.Name;
    Userinfos[1].textContent = user.LastName;
    Userinfos[2].textContent = user.UserName;
    Userinfos[3].textContent = role;
    RoleBadge.textContent = role;
}
if (document.querySelector("body").className == "DesignerMenu") document.addEventListener("DOMContentLoaded", ShowProfile);
