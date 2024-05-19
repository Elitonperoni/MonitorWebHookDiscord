using APIProducao.DTO;
using System.Text.Json;
using System.Text;

namespace APIWebHookDiscord.Notification
{
    public class DiscordNotification
    {
        public static async Task EnviarNotificacaoDiscord(string discordServer, string mensagem)
        {            
            var payload = new
            {
                content = mensagem
            };

            using (var httpClient = new HttpClient())
            {
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(discordServer, content);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Erro ao enviar notificação para o Discord");
                }
            }
        }
    }
}
