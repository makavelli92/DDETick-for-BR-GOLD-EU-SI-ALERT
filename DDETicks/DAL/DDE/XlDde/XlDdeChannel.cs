using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDde.Server;
using System;

namespace DDETicks.DAL.DDE.XlDde
{
    public abstract class XlDdeChannel
    {
        // **********************************************************************

        public abstract string Topic { get; set; }
        public abstract void ProcessTable(XlTable xt);

        // **********************************************************************

        public event Action ConversationAdded;
        public event Action ConversationRemoved;

        // **********************************************************************

        List<DdeConversation> conversations = new List<DdeConversation>();

        // **********************************************************************

        public int Conversations { get { return conversations.Count; } }

        // **********************************************************************

        public void AddConversation(DdeConversation dc)
        {
            lock (conversations)
                conversations.Add(dc);

            if (ConversationAdded != null)
                ConversationAdded();
        }

        // **********************************************************************

        public void RemoveConversation(DdeConversation dc)
        {
            bool removed;

            lock (conversations)
                removed = conversations.Remove(dc);

            if (removed && ConversationRemoved != null)
                ConversationRemoved();
        }

        // **********************************************************************

        public DdeConversation[] DropConversations()
        {
            DdeConversation[] dcArray;

            lock (conversations)
            {
                dcArray = conversations.ToArray();
                conversations.Clear();
            }

            if (ConversationRemoved != null)
                for (int i = 0; i < dcArray.Length; i++)
                    ConversationRemoved();

            return dcArray;
        }

        // **********************************************************************
    }
}
