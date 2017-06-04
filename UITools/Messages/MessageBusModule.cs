using BrightIdeasSoftware;
using System;
using System.Linq;
using WinFwk.UIMessages;
using WinFwk.UIModules;

namespace WinFwk.UITools.Messages
{
    public partial class MessageBusModule : UIModule
    {
        public MessageBusModule()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            Name = "MessageBus";
            Icon = Properties.Resources.small_chart_organisation;
            dtlvMessageTypes.InitData<AbstractMessageInformation>();
            dtlvMessageTypes.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var subscriberInfo = dtlvMessageTypes.SelectedObject as SubscriberInformation;
            if (subscriberInfo != null)
            {
                pgObject.SelectedObject = subscriberInfo.Instance;
            }
        }

        public override void PostInit()
        {
            var types = MessageBus.GetMessageTypes().Select(testc => new MessageTypeInformation(testc, MessageBus));
            dtlvMessageTypes.SetObjects(types);
        }
    }

    public abstract class AbstractMessageInformation : TreeNodeInformationAdapter<AbstractMessageInformation>
    {
        Type Type { get; set; }
        public AbstractMessageInformation(Type type)
        {
            Type = type;
        }

        [OLVColumn]
        public string Name => Type.Name;
    }

    public class MessageTypeInformation : AbstractMessageInformation
    {
        private MessageBus MessageBus { get; set; }
        public MessageTypeInformation(Type type, MessageBus bus) : base(type)
        {
            MessageBus = bus;
            Children = bus.GetSubscribers(type).Select(sub => new SubscriberInformation(sub)).OfType<AbstractMessageInformation>().ToList();
        }

        public override bool CanExpand => Children.Any();
    }

    public class SubscriberInformation : AbstractMessageInformation
    {
        public object Instance { get; }
        public SubscriberInformation(object instance) : base(instance.GetType())
        {
            Instance = instance;
        }
    }
}
