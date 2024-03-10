using NetDelegatsCovarContrvarApp;

//Example.Covariant();

// covariant
MessageBuilder<EmailMessage> EmailMessageCreateHandler = EmailMessageCreate;
MessageBuilder<Message> MessageCreateHandler = EmailMessageCreate;

EmailMessage EmailMessageCreate(string text)
{
    return new EmailMessage(text);
}

// contrvariant
MessageReceiver<Message> messageReceiver = MessagePrint;

messageReceiver(new Message("Simple message"));
messageReceiver(new EmailMessage("Email message"));

void MessagePrint(Message message) => message.Print();
//{
//    message.Print();
//}


// contrvarian and covariant
MessageConverter<Message, EmailMessage> toEmailCoverter = MessageToEmailMessage;
MessageConverter<SmsMessage, Message> toMessageCoverter = toEmailCoverter;


EmailMessage emessage = toEmailCoverter(new Message("Message to Email object"));
emessage.Print();

var message = toMessageCoverter(new SmsMessage("Sms to Message object"));
message.Print();

EmailMessage MessageToEmailMessage(Message message) => new EmailMessage(message.Text);


delegate T MessageBuilder<out T>(string text);

delegate void MessageReceiver<in T>(T message);

delegate T2 MessageConverter<in T1, out T2>(T1 Message);

