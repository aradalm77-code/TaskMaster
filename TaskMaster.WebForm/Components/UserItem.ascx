<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="UserItem.ascx.cs"
    Inherits="TaskMaster.WebForm.Components.UserItem" %>
<tr data-user-id="userRow" data-person-id="userRow" runat="server">
    <td>
        <div class="user-cell">
            <div class="avatar">
                <asp:Literal ID="litInitials"
                    runat="server" Mode="Encode" />
            </div>

            <div>
                <div class="user-name">
                    <asp:Literal ID="litName"
                        runat="server" Mode="Encode" />
                </div>

                <div class="user-username">
                    <asp:Literal ID="litUsername"
                        runat="server" Mode="Encode" />
                </div>
            </div>
        </div>
    </td>

    <td>
        <asp:Literal ID="litRole"
            runat="server" Mode="Encode" />
    </td>

    <td>
        <asp:Literal ID="litLevel"
            runat="server" Mode="Encode" />
    </td>

    <td>
        <asp:Literal ID="litScore"
            runat="server" Mode="Encode" />
    </td>

    <td>
        <div class="action-buttons">
            <button type="button" class="action-button" runat="server" onserverclick="EditUser">✎</button>
            <button
                id="btnDelete"
                runat="server"
                type="button"
                class="action-button delete"
                onserverclick="btnDelete_ServerClick">
                ⌫
            </button>
        </div>
    </td>
</tr>
