namespace Trp.Service.ViewModel
{
    public class UrlFilterContentViewModel
    {
        public bool SecureAccess { get; set; }
        public bool NonSecureAccess { get; set; }
        public bool AllPortsBlocked { get; set; }
        public string Url { get; set; }
        public bool DomainBlocked { get; set; }

    }
}
