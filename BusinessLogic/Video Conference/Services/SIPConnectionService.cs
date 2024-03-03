using BusinessLogic.Video_Conference.Interfaces;
using SIPSorcery.SIP;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLogic.Video_Conference.Services
{
    public class SIPConnectionService : ISIPHandle
    {
        public async Task SIPInitialization()
        {
            int SIP_LISTEN_PORT = 5060;
            int SIPS_LISTEN_PORT = 5061;
            int SIP_WEBSOCKET_LISTEN_PORT = 80;

            SIPTransport sipTransport = new SIPTransport();

            // IPv4
            sipTransport.AddSIPChannel(new SIPUDPChannel(new IPEndPoint(IPAddress.Any, SIP_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPTCPChannel(new IPEndPoint(IPAddress.Any, SIP_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPTLSChannel(new X509Certificate2("localhost.pfx"), new IPEndPoint(IPAddress.Any, SIPS_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPWebSocketChannel(IPAddress.Any, SIP_WEBSOCKET_LISTEN_PORT));
            // IPv6
            sipTransport.AddSIPChannel(new SIPUDPChannel(new IPEndPoint(IPAddress.IPv6Any, SIP_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPTCPChannel(new IPEndPoint(IPAddress.IPv6Any, SIP_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPTLSChannel(new X509Certificate2("localhost.pfx"), new IPEndPoint(IPAddress.IPv6Any, SIPS_LISTEN_PORT)));
            sipTransport.AddSIPChannel(new SIPWebSocketChannel(IPAddress.IPv6Any, SIP_WEBSOCKET_LISTEN_PORT));

            // SIPTransportRequestReceived
            sipTransport.SIPTransportRequestReceived += (SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPRequest sipRequest) =>
            {
                Console.WriteLine($"Request received {localSIPEndPoint}<-{remoteEndPoint}: {sipRequest.StatusLine}");
                return Task.CompletedTask;
            };

            // SIPTransportResponseReceived
            sipTransport.SIPTransportResponseReceived += (SIPEndPoint localSIPEndPoint, SIPEndPoint remoteEndPoint, SIPResponse sipResponse) =>
            {
                Console.WriteLine($"Response received {localSIPEndPoint}<-{remoteEndPoint}: {sipResponse.ShortDescription}");
                return Task.CompletedTask;
            };
        }
    }
}
