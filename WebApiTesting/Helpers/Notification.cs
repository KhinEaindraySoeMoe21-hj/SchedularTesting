using log4net;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WebApiTesting.Models;

namespace WebApiTesting.Helpers
{
    public class Notification
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task SendFCMNotificationToAll( BirthdayWishInfo bdinfo,string title, string body)
        {
            await Console.Out.WriteLineAsync("Notification"+title + bdinfo.UserName + bdinfo.UserBd);
            //try
            //{
            //    var fcmToken = "";
            //    var fcmSenderId = "";
            //    //if (isSentSeller)//seller
            //    //{
            //    //    fcmToken = MyPetConst.FCM_TOKEN_KEY_SELLER;
            //    //    fcmSenderId = MyPetConst.FCM_SENDER_ID_SELLER;
            //    //}
            //    //else
            //    //{
            //    //    fcmToken = MyPetConst.FCM_TOKEN_KEY_BUYER;
            //    //    fcmSenderId = MyPetConst.FCM_SENDER_ID_BUYER;
            //    //}

            //    //foreach (var item in topicList)
            //    //{
            //        WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            //        tRequest.Method = "POST";
            //        tRequest.Headers.Add(string.Format("Authorization: key={0}", fcmToken));
            //        tRequest.Headers.Add(string.Format("Sender: id={0}", fcmSenderId));
            //        tRequest.ContentType = "application/json";
            //        var payload = new
            //        {
            //            to = "/topics/" + bdinfo.BirthdayNotiID,
            //            priority = "high",
            //            content_available = true,
            //            notification = new
            //            {
            //                title = title,
            //                body = body
            //            },
            //            data = new Dictionary<string, string>()
            //            {
            //                ["RedirectAction"] = redirectAction,
            //                ["RedirectAttribute"] = redirectAttribute.ToString(),
            //                ["NotificationId"] = notificationId.ToString(),
            //            }
            //        };

            //        string postbody = JsonConvert.SerializeObject(payload).ToString();
            //        Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            //        tRequest.ContentLength = byteArray.Length;
            //        using (Stream dataStream = await tRequest.GetRequestStreamAsync())
            //        {
            //            dataStream.Write(byteArray, 0, byteArray.Length);
            //            using (WebResponse tResponse = await tRequest.GetResponseAsync())
            //            {
            //                using (Stream dataStreamResponse = tResponse.GetResponseStream())
            //                {
            //                    if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
            //                        {
            //                            String sResponseFromServer = tReader.ReadToEnd();
            //                        }
            //                }
            //            }
            //        }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}
        }
    }
}
