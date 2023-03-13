
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using System;
using WebApiTesting.Controllers;
using WebApiTesting.Models;

namespace WebApiTesting.Schedular
{
    public class BirthdayNotiSchedular
    {
        public static void Start()
        {
            IScheduler scheduler = (IScheduler)StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<BirthdayNoti>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                //.WithCronSchedule("0 25 14 ? *MON")
                //.ForJob("myJob", "group1")
                .WithDailyTimeIntervalSchedule(s =>
                s.WithIntervalInSeconds(30)
                .OnEveryDay()
                .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(23, 0))
                ).Build();

            scheduler.ScheduleJob(job, trigger);
        }
        public class BirthdayNoti : IJob
        {
            private readonly ApiTestingContext _db;
            public BirthdayNoti(ApiTestingContext db)
            {
                _db = db;
            }
            public async Task Execute(IJobExecutionContext context)
            {
                var emplist = _db.Employees.ToList();
                var bdList = emplist.Where(b => (b.EmpBd.Month)==DateTime.UtcNow.Month && ((b.EmpBd.Day)-(DateTime.UtcNow.Day)==0) || (b.EmpBd.Day) - (DateTime.UtcNow.Day) == 7).ToList();
                foreach (var bd in bdList)
                {
                    BirthdayWishInfo bdInfo = new BirthdayWishInfo();
                    bdInfo.UserName = bd.EmpName;
                    bdInfo.UserBd = bd.EmpBd;
                    bdInfo.IsPreBd = bd.EmpBd.Day != DateTime.UtcNow.Day ? true : false;
                    bdInfo.IsBd = bd.EmpBd.Day == DateTime.UtcNow.Day ? true : false;
                    await _db.BirthdayWishInfos.AddAsync(bdInfo);
                    await _db.SaveChangesAsync();
                    string title = bdInfo.IsPreBd == true ? "Your Birthday is coming..." : "Happy Birthday!.....";
                    var test = Helpers.Notification.SendFCMNotificationToAll(bdInfo,
                                                                    title,
                                                                    bdInfo.UserName);
                    await Console.Out.WriteLineAsync(" "+DateTime.UtcNow+ " ");
                }

                //BirthdayWishInfo bdInfo1 = new BirthdayWishInfo();
                //bdInfo1.UserName = "Aye Aye" ;
                //bdInfo1.UserBd = DateTime.UtcNow;
                //bdInfo1.IsPreBd = false;
                //bdInfo1.IsBd = false;
                //var test1 = Helpers.Notification.SendFCMNotificationToAll(bdInfo1,
                //                                                   "Happy Birthday",
                //                                                   bdInfo1.UserName,
                //                                                   "http://localhost:5068/swagger/index.html",
                //                                                   1,
                //                                                   1, false);
                //await Console.Out.WriteLineAsync("HB" + bdInfo1.UserName + DateTime.UtcNow);
            }
        }
    }


}
