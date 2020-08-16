using Microsoft.Azure.NotificationHubs;
using Microsoft.Azure.NotificationHubs.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT638June2020Group003Api.Configurations;

namespace ICT638June2020Group003Api.NotificationHubs
{
    public class NotificationHubProxy
    {
        private NotificationHubConfiguration _configuration;
        private NotificationHubClient _hubClient;

        public NotificationHubProxy(NotificationHubConfiguration configuration)
        {
            _configuration = configuration;
            _hubClient = NotificationHubClient.CreateClientFromConnectionString(_configuration.ConnectionString, _configuration.HubName);
        }

        public string getQuotedString(string str)
        {
            return "\"" + str + "\"";
        }

        public async Task<HubResponse<NotificationOutcome>> SendNotification(Notification newNotification)
        {
            try
            {
                NotificationOutcome outcome = null;
                string jsonPayload = 
                    "{" +
                            getQuotedString("data")+":"+
                            "{"+
                                getQuotedString("title") + ":" + getQuotedString(newNotification.Title) + ","+
                                getQuotedString("content") + ":" + getQuotedString(newNotification.Content) +
                            "}" +
                    "}";
                if (newNotification.Tags == null)
                    outcome = await _hubClient.SendFcmNativeNotificationAsync(jsonPayload);
                else
                    outcome = await _hubClient.SendFcmNativeNotificationAsync(newNotification.Content, newNotification.Tags);

                if (outcome != null)
                {
                    if (!((outcome.State == NotificationOutcomeState.Abandoned) ||
                        (outcome.State == NotificationOutcomeState.Unknown)))
                        return new HubResponse<NotificationOutcome>();
                }

                return new HubResponse<NotificationOutcome>().SetAsFailureResponse().AddErrorMessage("Notification was not sent due to issue. Please send again.");
            }

            catch (MessagingException ex)
            {
                return new HubResponse<NotificationOutcome>().SetAsFailureResponse().AddErrorMessage(ex.Message);
            }

            catch (ArgumentException ex)
            {
                return new HubResponse<NotificationOutcome>().SetAsFailureResponse().AddErrorMessage(ex.Message);
            }
        }
    }
}
