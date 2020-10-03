using HtmlConstructor.HtmlTools.Elements;

namespace HtmlConstructor.Data
{
    public static class DataTransferAssistant
    {
        public delegate void AddItemHandler(HtmlElement element);
        public static event AddItemHandler OnAddCommand;

        public delegate void ClearDocHandler();
        public static event ClearDocHandler OnClearCommand;

        public static void OnAddCommandInvoke(HtmlElement element)
        {
            OnAddCommand?.Invoke(element);
        }

        public static void OnClearCommandInvoke()
        {
            OnClearCommand?.Invoke();
        }
    }
}
