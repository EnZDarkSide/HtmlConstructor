using DevExpress.Mvvm;
using HtmlConstructor.HtmlTools.Elements;
using HtmlConstructor.HtmlTools.Elements.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HtmlConstructor.ViewModels
{
    public class ToolkitViewModel : ViewModelBase
    {
        public int SelectedIndex { get; set; }
        public List<IHtmlElementView> toolViews => DataTransferAssistant.Default();

        public Commands.DelegateCommand ClickAdd
        {
            get => new Commands.DelegateCommand((_) => DataTransferAssistant.OnAddCommandInvoke(toolViews[SelectedIndex].Element), (_) => SelectedIndex != -1);
        }

        public Commands.DelegateCommand ClickClear
        {
            get => new Commands.DelegateCommand((_) => DataTransferAssistant.OnClearCommandInvoke());
        }
    }
}
