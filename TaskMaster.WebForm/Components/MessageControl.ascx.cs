
using System;
using System.Web;
using System.Web.UI;

namespace TaskMasterEntity.src.WebForms.Components
{
    public partial class MessageControl : UserControl
    {
        public enum MessageType
        {
            Success,
            Error,
            Warning
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ShowMessage(string message, MessageType type)
        {
            string typeName = type.ToString().ToLowerInvariant();

            litMessageTitle.Text = GetTitle(type);
            litMessageText.Text = Server.HtmlEncode(message);

            formMessage.Attributes["class"] =
                $"form-message {typeName} active";
        }
        public void HideMessage()
        {
            string currentClass =
                formMessage.Attributes["class"] ?? "form-message";

            currentClass = currentClass.Replace(" active", "");

            formMessage.Attributes["class"] = currentClass;
        }

        private string GetTitle(MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    return "Success";

                case MessageType.Error:
                    return "Error";

                case MessageType.Warning:
                    return "Warning";

                default:
                    return "Message";
            }
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            HideMessage();
        }
    }
}
