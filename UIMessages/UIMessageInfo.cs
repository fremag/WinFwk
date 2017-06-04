using BrightIdeasSoftware;
using System;

namespace WinFwk.UIMessages
{
    public class UIMessageInfo
    {
        public AbstractUIMessage Message { get; }

        [OLVColumn(AspectToStringFormat = "{0:HH:mm:ss.fff}")]
        public DateTime TimeStamp { get; }

        [OLVColumn]
        public string Type => Message.GetType().Name;

        [OLVColumn(FillsFreeSpace = true)]
        public string Text => Message.ToString();

        public UIMessageInfo(AbstractUIMessage message)
        {
            Message = message;
            TimeStamp = DateTime.Now;
        }
    }
}
