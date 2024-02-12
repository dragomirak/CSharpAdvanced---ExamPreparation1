using System.Collections;
using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();

        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            var mailToRemove = Inbox.FirstOrDefault(m => m.Sender == sender);
            if (mailToRemove == null)
            {
                return false;
            }

            return Inbox.Remove(mailToRemove);
        }

        public int ArchiveInboxMessages()
        {
            Archive.AddRange(Inbox);
            int removedMails = Inbox.Count;
            Inbox = new List<Mail>();

            return removedMails;
        }

        public string GetLongestMessage()
        {
            Mail longestMail = Inbox.OrderByDescending(m => m.Body).First();
            return longestMail.ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Inbox:");
            foreach (var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
