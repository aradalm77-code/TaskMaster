
<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="MessageControl.ascx.cs"
    Inherits="TaskMaster.WebForm.Components.MessageControl" %>

<div id="formMessage"
     runat="server"
     class="form-message"
     role="status"
     aria-live="polite">

    <!-- Message Icon -->
    <span class="message-icon" aria-hidden="true">

        <!-- Success Icon -->
        <svg class="icon-success"
             xmlns="http://www.w3.org/2000/svg"
             viewBox="0 0 24 24"
             fill="none"
             stroke="currentColor"
             stroke-width="2"
             stroke-linecap="round"
             stroke-linejoin="round">

            <path d="M20 6L9 17l-5-5" />

        </svg>

        <!-- Error Icon -->
        <svg class="icon-error"
             xmlns="http://www.w3.org/2000/svg"
             viewBox="0 0 24 24"
             fill="none"
             stroke="currentColor"
             stroke-width="2"
             stroke-linecap="round"
             stroke-linejoin="round">

            <path d="M18 6L6 18" />
            <path d="M6 6l12 12" />

        </svg>

        <!-- Warning Icon -->
        <svg class="icon-warning"
             xmlns="http://www.w3.org/2000/svg"
             viewBox="0 0 24 24"
             fill="none"
             stroke="currentColor"
             stroke-width="2"
             stroke-linecap="round"
             stroke-linejoin="round">

            <path d="M12 3L2 21h20L12 3z" />
            <path d="M12 9v5" />
            <path d="M12 17h.01" />

        </svg>

    </span>

    <!-- Message Content -->
    <span class="message-content">

        <!-- Message Title -->
        <strong class="message-title">
            <asp:Literal
                ID="litMessageTitle"
                runat="server" />
        </strong>

        <!-- Message Text -->
        <span class="message-text">
            <asp:Literal
                ID="litMessageText"
                runat="server" />
        </span>

    </span>

    <!-- Close Button -->
    <asp:Button
        ID="btnClose"
        runat="server"
        Text="×"
        CssClass="message-close"
        ToolTip="Dismiss message"
        CausesValidation="false"
        UseSubmitBehavior="true"
        OnClick="btnClose_Click" />

</div>
