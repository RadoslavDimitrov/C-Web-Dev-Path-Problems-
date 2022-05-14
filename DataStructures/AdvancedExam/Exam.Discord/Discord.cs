using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Discord
{
    public class Discord : IDiscord
    {
        private Dictionary<string, Message> msgs;
        private Dictionary<string, List<Message>> channelsMsgs;

        public Discord()
        {
            this.msgs = new Dictionary<string, Message>();
            this.channelsMsgs = new Dictionary<string, List<Message>>();
        }
        public int Count => this.msgs.Count;

        public bool Contains(Message message)
        {
            return this.msgs.ContainsKey(message.Id);
        }

        public void DeleteMessage(string messageId)
        {
            if (!this.msgs.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            var msg = this.msgs[messageId];
            this.channelsMsgs[msg.Channel].Remove(msg);
            this.msgs.Remove(messageId);
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            return this.msgs.Values.OrderByDescending(msg => msg.Reactions.Count())
                .ThenBy(msg => msg.Timestamp)
                .ThenBy(msg => msg.Content.Length);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!this.channelsMsgs.ContainsKey(channel))
            {
                throw new ArgumentException();
            }

            var channelMsgs = this.channelsMsgs[channel];

            if(channelMsgs.Count == 0)
            {
                throw new ArgumentException();
            }

            return channelMsgs;
        }

        public Message GetMessage(string messageId)
        {
            if (!this.msgs.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            return this.msgs[messageId];
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            var messages = this.msgs.Values.Where(m => m.Timestamp >= lowerBound && m.Timestamp <= upperBound);

            var dict = new Dictionary<string, List<Message>>();

            foreach (var m in messages)
            {
                if (!dict.ContainsKey(m.Channel))
                {
                    dict.Add(m.Channel, new List<Message>());
                }

                dict[m.Channel].Add(m);
            }

            var d = dict.Values.OrderByDescending(m => m.Count);

            var result = new List<Message>();

            foreach (var item in d)
            {
                foreach (var m in item)
                {
                    result.Add(m);
                }
            }

            return result;
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            var msgs = new List<Message>();

            foreach (var m in this.msgs.Values)
            {
                int counter = 0;

                foreach (var react in reactions)
                {
                    if (m.Reactions.Contains(react))
                    {
                        counter++;
                    }
                }

                if(counter == reactions.Count)
                {
                    msgs.Add(m);
                }
            }

            return msgs.OrderByDescending(m => m.Reactions.Count)
                .ThenBy(m => m.Timestamp);

        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            return this.msgs.Values.OrderByDescending(msg => msg.Reactions.Count)
                .Take(3);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            if (!this.msgs.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            this.msgs[messageId].Reactions.Add(reaction);

        }

        public void SendMessage(Message message)
        {
            if (!this.channelsMsgs.ContainsKey(message.Channel))
            {
                this.channelsMsgs.Add(message.Channel, new List<Message>());
            }

            this.channelsMsgs[message.Channel].Add(message);
            this.msgs.Add(message.Id ,message);
        }
    }
}
