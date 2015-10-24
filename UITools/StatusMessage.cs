﻿using WinFwk.UIMessages;

namespace WinFwk.UITools
{
    public enum StatusType { BeginTask, EndTask, Text}
    public class StatusMessage : AbstractUIMessage
    {
        public StatusType Status { get; private set; }
        public string Text { get; private set; }

        public StatusMessage(string text, StatusType status=StatusType.Text)
        {
            Status = status;
            Text = text;
        }
    }
}
