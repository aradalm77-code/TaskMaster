<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="TaskMasterEntity.src.WebForms.Users" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Users | TaskMaster</title>

    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link href="./Css/Users.css" rel="stylesheet" />
</head>

<body>
    <div class="form-message success" id="formMessage" role="status" aria-live="polite">
        <span class="message-icon" aria-hidden="true">
            <svg class="icon-success" viewBox="0 0 24 24" fill="none">
                <path d="M5 12.5L9.5 17L19 7" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
            </svg>

            <svg class="icon-error" viewBox="0 0 24 24" fill="none">
                <path d="M12 8V13" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" />
                <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                <circle cx="12" cy="12" r="9" stroke="currentColor" stroke-width="2" />
            </svg>

            <svg class="icon-warning" viewBox="0 0 24 24" fill="none">
                <path d="M12 8V13" stroke="currentColor"
                    stroke-width="2" stroke-linecap="round" />
                <circle cx="12" cy="16.5" r="1" fill="currentColor" />
                <path d="M10.3 4.8L2.8 18A2 2 0 0 0 4.5 21H19.5A2 2 0 0 0 21.2 18L13.7 4.8A2 2 0 0 0 10.3 4.8Z"
                    stroke="currentColor" stroke-width="2" stroke-linejoin="round" />
            </svg>
        </span>

        <span class="message-content">
            <strong class="message-title">Success</strong>
            <span class="message-text">Your account has been created successfully.</span>
        </span>

        <button type="button" class="message-close"
            aria-label="Dismiss message" id="closeMessage">
            &times;</button>
    </div>
    <form id="form1" runat="server">
        <asp:ScriptManager
            ID="ScriptManager1"
            runat="server"
            EnablePageMethods="true" />
        <main class="page">
            <div class="ambient ambient-one"></div>
            <div class="ambient ambient-two"></div>

            <div class="container">
                <nav class="topbar">
                    <div class="brand">
                        <div class="brand-icon">T</div>
                        <span>TaskMaster</span>
                    </div>

                    <div class="topbar-right">
                        <a class="top-link" href="Default.aspx">Dashboard</a>
                        <a class="top-link active" href="Users.aspx">Users</a>
                    </div>
                </nav>

                <header class="page-heading">
                    <div>
                        <span class="eyebrow">TEAM MANAGEMENT</span>
                        <h1>Team Members</h1>
                        <p class="subtitle">
                            Manage your team members, review their roles, and track their progress.
                        </p>
                    </div>

                    <a class="add-button" href="Default.aspx">
                        <span>＋</span>
                        Add New User
                    </a>
                </header>

                <section class="stats">
                    <article class="stat-card">
                        <div class="stat-icon">♙</div>
                        <div>
                            <div class="stat-label">Total Users</div>
                            <div class="stat-value userCount">128</div>
                        </div>
                    </article>

                    <article class="stat-card">
                        <div class="stat-icon">✳</div>
                        <div>
                            <div class="stat-label">Interns</div>
                            <div class="stat-value internCount">96</div>
                        </div>
                    </article>

                    <article class="stat-card">
                        <div class="stat-icon">✦</div>
                        <div>
                            <div class="stat-label">Designers</div>
                            <div class="stat-value designerCount">32</div>
                        </div>
                    </article>
                </section>

                <section class="users-panel">
                    <header class="panel-header">
                        <div>
                            <h2 class="panel-title">All Users</h2>
                            <p class="panel-description">
                                A complete overview of registered team members.
                            </p>
                        </div>

                        <span class="total-badge">128 MEMBERS</span>
                    </header>

                    <div class="filters">
                        <div class="search-wrap">
                            <span class="search-icon">⌕</span>
                            <input
                                type="search"
                                class="search-input"
                                placeholder="Search by name or username..."
                                aria-label="Search users" />
                        </div>

                        <select class="role-filter" aria-label="Filter by role">
                            <option value="">All roles</option>
                            <option value="Intern">Interns</option>
                            <option value="Designer">Designers</option>
                        </select>
                    </div>

                    <div class="table-wrap">
                        <table class="users-table">
                            <thead>
                                <tr>
                                    <th>User</th>
                                    <th>Role</th>
                                    <th>Level</th>
                                    <th>Score</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>

                            <tbody>
                                <tr>
                                    <td>
                                        <div class="user-cell">
                                            <div class="avatar">AM</div>
                                            <div>
                                                <div class="user-name">Alex Morgan</div>
                                                <div class="user-username">@alex_morgan</div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span class="role-badge">✳ Intern</span></td>
                                    <td><span class="level">Beginner</span></td>
                                    <td><span class="score">240 XP</span></td>
                                    <td>
                                        <div class="action-buttons">
                                            <button type="button" class="action-button" aria-label="View user">↗</button>
                                            <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div class="user-cell">
                                            <div class="avatar cyan">JD</div>
                                            <div>
                                                <div class="user-name">Jordan Davis</div>
                                                <div class="user-username">@jordan_design</div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span class="role-badge designer">✦ Designer</span></td>
                                    <td><span class="level">Advanced</span></td>
                                    <td><span class="score">890 XP</span></td>
                                    <td>
                                        <div class="action-buttons">
                                            <button type="button" class="action-button" aria-label="View user">↗</button>
                                            <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div class="user-cell">
                                            <div class="avatar orange">SC</div>
                                            <div>
                                                <div class="user-name">Sam Carter</div>
                                                <div class="user-username">@sam_carter</div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span class="role-badge">✳ Intern</span></td>
                                    <td><span class="level">Mid-Level</span></td>
                                    <td><span class="score">510 XP</span></td>
                                    <td>
                                        <div class="action-buttons">
                                            <button type="button" class="action-button" aria-label="View user">↗</button>
                                            <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div class="user-cell">
                                            <div class="avatar pink">RT</div>
                                            <div>
                                                <div class="user-name">Riley Taylor</div>
                                                <div class="user-username">@riley_t</div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span class="role-badge designer">✦ Designer</span></td>
                                    <td><span class="level">Beginner</span></td>
                                    <td><span class="score">120 XP</span></td>
                                    <td>
                                        <div class="action-buttons">
                                            <button type="button" class="action-button" aria-label="View user">↗</button>
                                            <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <div class="user-cell">
                                            <div class="avatar">KW</div>
                                            <div>
                                                <div class="user-name">Kai Wilson</div>
                                                <div class="user-username">@kai_wilson</div>
                                            </div>
                                        </div>
                                    </td>
                                    <td><span class="role-badge">✳ Intern</span></td>
                                    <td><span class="level">Mid-Level</span></td>
                                    <td><span class="score">365 XP</span></td>
                                    <td>
                                        <div class="action-buttons">
                                            <button type="button" class="action-button" aria-label="View user">↗</button>
                                            <button type="button" class="action-button delete" aria-label="Delete user">⌫</button>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <footer class="panel-footer">
                        <span class="footer-note">Showing sample users. Search, filtering, pagination, and actions are UI placeholders.
                        </span>

                        <nav class="pagination" aria-label="Pagination">
                            <a class="page-number" href="#">‹</a>
                            <a class="page-number active" href="#">1</a>
                            <a class="page-number" href="#">2</a>
                            <a class="page-number" href="#">3</a>
                            <a class="page-number" href="#">›</a>
                        </nav>
                    </footer>
                </section>

                <footer class="caption">
                    <span class="caption-dot"></span>
                    YOUR TEAM. YOUR PROGRESS.
                </footer>
            </div>
        </main>
    </form>
    <script src="./Scrypts/scrypt.js" type="module"></script>
</body>
</html>

