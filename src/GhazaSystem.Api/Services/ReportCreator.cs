using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using GhazaSystem.Api.Infrastructure;
using GhazaSystem.Common.DTOs;
using GhazaSystem.Common.DTOs.Report;
using GhazaSystem.Common.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Globalization;
using System.Threading.Tasks;

namespace GhazaSystem.Api.Services;

public class ReportCreator(GhazaDbContext context)
{
    PersianCalendar psc = new PersianCalendar();
    PersianCalendarService persianCalendarService = new PersianCalendarService();   
    private ListReportDailyDTO ReportDaily = new ListReportDailyDTO();
    private MontReportDTO MontReport = new MontReportDTO();


    public async Task<Response<ListReportDailyDTO>> InDayDailyFood(CalendarDay day)
    {
        ReportDaily = new ListReportDailyDTO();
        ReportDaily.daily!.Add(new DailyDTO { Fild1 = $"غذای امروز {day.DayName} ", Fild2 = $" تاریخ {day.PersianDate}" });
        ReportDaily.daily!.Add(new DailyDTO { Fild1 = "پرسنل ", Fild2 = "غذا" });
        var result = await context.Daily_Foods
            .Include(c => c.users)
            .Include(c => c.food)
            .Where(d => d.Date == day.GregorianDate)
            .ToListAsync();
        ReportDaily.Foods = new List<NOFoods>();
        foreach (var d in result)
        {
            int  userno = 0;
            if(d.users != null)
            foreach(var user in d.users)
            {
                    ReportDaily.daily.Add(new DailyDTO { Fild1 = $" {user.First_Name} {user.Last_Name} ", Fild2 = $"{d.food!.Name}" });
                    userno++;
             }
            string foodname = d.food!.Name!;
            if (foodname == null) foodname = "نام غذا خالیست";
            ReportDaily.Foods.Add(new NOFoods(userno, foodname));
        }
        return ResponseBuilder.Success(ReportDaily);
    }


    public async Task<Response<MontReportDTO>> InMontDailyFood(int mont)
    {
        MontReport = new MontReportDTO();
        MontReport.RowMontExcelsOut = new List<RowExcel>();
        CalendarMont calmont = persianCalendarService.GetMonthCalendar(mont);
        var resultuser = await context.User
            .Include(d => d.Daily_Foods!.Where(df => df.Mount == mont))
            .ThenInclude(f => f.food)
            .ToListAsync();

        var resultdaily = await context.Daily_Foods
            .Include(f => f.food)
            .Where(df => df.Mount == mont)
            .ToListAsync();

        MontReport.Mont = mont;
        MontReport.MontName = persianCalendarService.GetPersianMontName(mont);

        if (calmont != null)
        {
            var inrow = new RowExcel();
            inrow.CellOfRowExcel.Add(new CellMontExcel("نام پرسنل","","",DateOnly.FromDateTime(DateTime.Now),1));
            MontReport.Culoms++;
            int indexcount = 1;
            DateOnly lastdaily = new DateOnly();
            foreach (var daily in resultdaily)
            {
                
                    if (daily != null)
                    {
                    if(lastdaily==daily.Date) continue;

                        indexcount++;
                        DateTime date = daily.Date.ToDateTime(TimeOnly.MinValue);
                    string persiandate = $"{psc.GetYear(date)}/{mont:00}/{psc.GetDayOfMonth(date):00}";
                        inrow.CellOfRowExcel.Add(new CellMontExcel($"{persiandate}", "", $"{persiandate}", daily.Date, indexcount));
                        MontReport.Culoms++;
                    lastdaily = daily.Date;
                    }
                
            }
            MontReport.RowMontExcelsOut.Add(inrow);
            MontReport.Rows++;

            foreach(var us in resultuser)
            {
                int cel = 0;
                if (us != null)
                {
                    var userrow = new RowExcel();
                    userrow.CellOfRowExcel.Add(new CellMontExcel($"{us.First_Name+" "+us.Last_Name}", "", "", DateOnly.FromDateTime(DateTime.Now), 1));
                    foreach (var daily in inrow.CellOfRowExcel)
                    {
                        if (us.Daily_Foods == null) continue;
                        var dailyuser = us.Daily_Foods.FirstOrDefault(d => d.Date==daily.Date);
                        if (dailyuser == null) continue;
                        if(dailyuser.food == null) continue;
                        userrow.CellOfRowExcel.Add(new CellMontExcel($"{dailyuser.food.Name ?? "غذای بدون اسم"}", "", "", daily.Date, daily.Index));
                        cel++;
                    }
                    if (cel != 0)
                    {
                        MontReport.RowMontExcelsOut.Add(userrow);
                        MontReport.Rows++;
                    }
                }
            }



            return ResponseBuilder.Success(MontReport);

        }





        return ResponseBuilder.Failure<MontReportDTO>();
    }




}
