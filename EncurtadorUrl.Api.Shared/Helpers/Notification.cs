using System.Collections.ObjectModel;

namespace EncurtadorUrl.Api.Shared.Helpers
{
    public class Notification
    {
        private readonly Collection<NotificationItem> _notifications;

        public Notification()
        {
            _notifications = new Collection<NotificationItem>();
        }

        public void Add(string message)
        {
            if (_notifications.All(x => x.Message != message || x.Type != NotificationType.None))
                _notifications.Add(new NotificationItem(message, NotificationType.None));
        }

        public void Add(string message, NotificationType type)
        {
            if (_notifications.All(x => x.Message != message || x.Type != type))
                _notifications.Add(new NotificationItem(message, type));
        }

        public void Add(string prefix, string message, NotificationType type)
        {
            if (_notifications.All(x => x.Message != message || x.Type != type))
                _notifications.Add(new NotificationItem($"{prefix}: {message}", type));
        }

        public bool Any() => _notifications.Any();
        public bool Any(NotificationType type) => _notifications.Any(x => x.Type == type);

        public IEnumerable<string> Get(bool prefixType = false)
            => _notifications.Select(x => prefixType ? $"[{x.Type}] {x.Message}" : x.Message);
        public IEnumerable<string> Get(NotificationType type, bool prefixType = false)
            => _notifications.Where(x => x.Type == type).Select(x => prefixType ? $"[{x.Type}] {x.Message}" : x.Message);

        public void Clear() => _notifications.Clear();
    }

    internal class NotificationItem
    {
        internal NotificationItem(string message, NotificationType type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; }
        public NotificationType Type { get; }
    }

    public enum NotificationType
    {
        None,
        Error,
        Warning,
        Info,
        Success
    }
}
