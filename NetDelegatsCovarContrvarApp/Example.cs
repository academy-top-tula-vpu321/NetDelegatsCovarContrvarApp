using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDelegatsCovarContrvarApp
{
    internal static class Example
    {
        static public void Covariant()
        {
            // Covarint
            MessageBuilder messageBuilder = EmailMessageCreate;

            Message message = messageBuilder("Hello world");
            message.Print();


            // Contrvariant
            EmailReceiver emailReceiver = ReceiveMessage;
            emailReceiver(new EmailMessage("Hello from email"));


            void ReceiveMessage(Message message) => message.Print();

            EmailMessage EmailMessageCreate(string text) => new EmailMessage(text);
        }
    }

    class Message
    {
        public string? Text { get; set; }
        public Message(string? text) => Text = text;
        public virtual void Print() => Console.WriteLine($"Message: {Text}");
    }

    class EmailMessage : Message
    {
        public EmailMessage(string? text) : base(text) { }
        public override void Print()
        {
            Console.WriteLine($"Email Message: {Text}");
        }
    }

    class SmsMessage : Message
    {
        public SmsMessage(string? text) : base(text) { }
        public override void Print()
        {
            Console.WriteLine($"Sms Message: {Text}");
        }
    }


    // covariant
    delegate Message MessageBuilder(string? text);

    // contrvariant
    delegate void EmailReceiver(EmailMessage message);
}
