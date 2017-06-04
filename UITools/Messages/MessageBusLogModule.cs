using BrightIdeasSoftware;
using System;
using WinFwk.UIMessages;
using WinFwk.UIModules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WinFwk.UITools.Messages
{
    public partial class MessageBusLogModule : UIModule
    {
        BufferedSource<UIMessageInfo> dataSource;
        TaskFactory taskFactory;
        public MessageBusLogModule()
        {
            InitializeComponent();
            dataSource = new BufferedSource<UIMessageInfo>(dlvMessages);
            dlvMessages.InitColumns<UIMessageInfo>();
            dlvMessages.VirtualListDataSource = dataSource;
            taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
        }

        public override void Init()
        {
            Name = "MessageBusLog";
            Icon = Properties.Resources.small_raw_access_logs;
            dlvMessages.SelectedIndexChanged += OnSelectedIndexChanged;
            MessageBus.MessageSent += OnMessageSent;
        }

        private void OnMessageSent(UIMessageInfo msgInfo)
        {
            dataSource.AddObject(msgInfo);
            taskFactory.StartNew(() => dlvMessages.UpdateVirtualListSize());
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var msgInfo = dlvMessages.SelectedObject as UIMessageInfo;
            if (msgInfo != null)
            {
                pgObject.SelectedObject = msgInfo.Message;
            }
        }
    }

    public class BufferedSource<T> : AbstractVirtualListDataSource
    {
        private List<T> Buffer { get; set; }
        public BufferedSource(VirtualObjectListView listView) : base(listView)
        {
            Buffer = new List<T>();
        }

        public override object GetNthObject(int n)
        {
            return Buffer[n];
        }

        public override int GetObjectCount()
        {
            return Buffer.Count;
        }

        internal void AddObject(T obj)
        {
            Buffer.Insert(0, obj);
            while(Buffer.Count > 2000)
            {
                Buffer.RemoveAt(Buffer.Count - 1);
            }
        }
    }
}
