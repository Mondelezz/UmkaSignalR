using BusinessLogic.Messages.Services;
using Zitadel.Credentials;
using Zitadel.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddAuthorization()
    .AddAuthentication()
    .AddZitadelIntrospection(
        "ZITADEL_JWT",
        o =>
        {
            o.Authority = "https://zitadel-libraries-l8boqa.zitadel.cloud";
            o.JwtProfile = Application.LoadFromJsonString(
                @"
{
  ""type"": ""application"",
  ""keyId"": ""253175728617633278"",
  ""key"": ""-----BEGIN RSA PRIVATE KEY-----\nMIIEowIBAAKCAQEArmuD96yPNTp3lTRGLi8w5ULC2elRAcX/REa6fRu0lbDFxLTp\n2qkZNqwLCF1sQ3mrpPn6M9j3GpgJdrTHtXTjvvz/tU1T4T21iuraJyaAmo1xRL2Z\nbshEDcpgUy0UZU1qdNhJi5srFInDKhid7qpOTZI/bwFjFJ45Z0tnyjINHEQOrodB\n+751PP9fZ7eMndaipAZaxgc4sJP958YxeDAfTxxdcxTN64cFQPIrfUvgmiCxUCbs\nCwhHPA83ze9coJ9fZ9+HDpkA5HxneLEob1Vk9ijx4cy6/Jb7Zbw/bdSJfAuEjbbc\nap6Hl3Ximey7RFTCslxxUfw8sSIomS7hUsMF0QIDAQABAoIBAEUbxpMo5Sky/FS6\n/J+qBRahqDDNWFJ6kBUObS/K/XdeLk4tXIdN/vaBnnF3CsGFgPQCNBe8/NOlsAI/\nyO1l3iM7fVnpxLV3TOo4+a0PfV8/ccTJ1vRlF0nbiOUL9Iva67ZWSHWvSpd9qj2Q\nuWrqQdJMgyPJieeOdbIu13Xu9PDggmu54Hwg2d62PUFo/8dNZ3MWcbMOqbmC8C7s\n1orutidzKIBUVvySksZ7dMm889bdtvyKcOh1Ss6pMy87lNce/1KQxNBX9XENJElq\nF+8g8dZotjr0MzJwfYvuuxx8vW08c0AFvCf98w/4gBXVV7iFGY+sduw7g0kROQZX\nu3+Gfh0CgYEA5S1zxDK6r120D5fOlwTWCqkRUUE3TU7a7DkNXVuss1UbaXX1t+7k\nZ9rjVaaH52lpK6phO1xOzo7wp92oDdigGImEYBBLJE3D2rs+/Oeq8Fs/eYUDXT7r\nkiSLKlcvWFBQvmehXO4R5nPQIiSi5D18U5wPAVsQ8343JewzgATceV8CgYEAwtVv\nDnsWqYNe81dgG/6D5NLh+4O5YnuJRvrUp6u3xTxAOfsA3a9T8HKQ+hZbQkEx8szZ\nB0gzxoBDK0R5T2e/pQXth7IodcNENtN8eAp2Q5gd18wx9I1vJ7XHD9TmOH78u8rh\nsF5U28J5kxXVJbXKDKF/Kx/bmwUmKVsE9tuUXs8CgYA/3wgJoT3ITCw3wE5SZoWk\n2PO7mppoEFcRSOFBqKAcJtcJ8Fc4GPtNOoLrRwtPYmBuTADnQ1WvWcUWc783hK0x\nyXm8MC5RAt9X4aGvaH2KmVO6cWi7nyKWS1sBxOSsD05Bkq41MSCKArL6IQ3I4J36\ny16fORsjUYTbK9Y6kqBDrwKBgCT3wGm7+zHQxmxfsNG++iGpzc0eUkeYbxSztTPX\nRjg7VWhq8uAdS0z9P/rj0Q8CNcr/CVLzZTeN0LDd/jKN2fQi6s3rhPfLRB8vA5f3\nTDdJHqh6iyP+zg930zxyxfgESEoNlcMUMv+7p7u70cSk+KBq6Ckzk0SXtoT0Sz3X\nrhBLAoGBALu85jswUb6yVkr1aW2AhlAVVabTGJRcLBK01wwtt1oCcUnqOfFwY6Xo\nKjumu+lO3NGW2+RSqkquChnwkGwiT7Q9xJaEldSEy2xGd8f1954u+UjzUerfejyr\nJCHGCjObTYNuHpwuAbIsHMKPdetBY/352FQXzPT7bN/xvAbdNauP\n-----END RSA PRIVATE KEY-----\n"",
  ""appId"": ""253166975641989506"",
  ""clientId"": ""253166975642055042@umka""
}");
        })
    .AddZitadelIntrospection(
        "ZITADEL_BASIC",
        o =>
        {
            o.Authority = "https://zitadel-libraries-l8boqa.zitadel.cloud/";
            o.ClientId = "253166975642055042@umka";
            o.ClientSecret = "m0rL2egG7genHyuvrZHeOgEktLuMMrRNVdpMiGrvnedhnpyCBkrQUTG2rOFU62bQ";
        })
    .AddZitadelFake("ZITADEL_FAKE",
        o =>
        {
            o.FakeZitadelId = "1337";
        });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>("/chat");

await app.RunAsync();



await app.RunAsync();
