﻿namespace AssessmentPortal.Application.Notifications
{
    public class UserCreatedNotification : INotification
    {
        public Guid? Id { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? Role_id { get; set; }
    }
}
