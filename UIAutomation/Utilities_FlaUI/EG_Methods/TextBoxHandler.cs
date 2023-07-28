using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace UIAutomation.Utilities_FlaUI.EG_Methods
{
    public class TextBoxHandler
    {
        private UIA3Automation _automation;

        public TextBoxHandler()
        {
            _automation = new UIA3Automation();
        }

        public void SetTextBoxValueByAutomationId(Window appWindow, string automationId, string value)
        {
            // Find the textbox element by AutomationId
            var textBoxElement = appWindow.FindFirstDescendant(cf => cf.ByAutomationId(automationId));

            // Convert the element to a TextBox object
            var textBox = textBoxElement.AsTextBox();

            // Set the value of the textbox
            textBox.Enter(value);
        }
    }
}
