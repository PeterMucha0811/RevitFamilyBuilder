using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

namespace UIAutomation.Utilities_FlaUI.EG_Methods
{
    public class ComboBoxHandler
    {
        private UIA3Automation _automation;

        public ComboBoxHandler()
        {
            _automation = new UIA3Automation();
        }

        public void SelectItemByAutomationId(Window appWindow, string comboBoxAutomationId, string itemToSelect)
        {
            // Find the ComboBox element by AutomationId
            var comboBoxElement = appWindow.FindFirstDescendant(cf => cf.ByAutomationId(comboBoxAutomationId));

            // Convert the element to a ComboBox object
            var comboBox = comboBoxElement.AsComboBox();

            // Select the desired item in the ComboBox
            comboBox.Select(itemToSelect);
        }
    }
}
