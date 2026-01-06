using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using GhazaSystem.Api.Services;
using GhazaSystem.Common.DTOs;
using GhazaSystem.Common.DTOs.Report;
using GhazaSystem.Common.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GhazaSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController
        (
        ReportCreator RC
        
        
        )
        : ControllerBase
    {
        PersianCalendarService psc = new PersianCalendarService();

        [HttpGet("inday/{sday}")]
        public async Task<IActionResult> IndayFoods(string sday)
        {

            CalendarDay day = psc.GetCalendarDay(DateTime.Parse(sday));
            using var workbook = new XLWorkbook();
            var sheetdailynow = workbook.AddWorksheet("غذای امروز کاربران");
            var result = await RC.InDayDailyFood(day);
            ListReportDailyDTO reportDailyDTO = new ListReportDailyDTO();
            reportDailyDTO = result.Data! as ListReportDailyDTO;
            int allfoods = 0;
            if (reportDailyDTO != null)
            {

                int row =0;
                foreach (var item in reportDailyDTO.daily!)
                {
                    row++;
                    sheetdailynow.Cell(row, 1).Value = item.Fild1;
                    sheetdailynow.Cell(row, 2).Value = item.Fild2;
                }
               
                foreach(var item in reportDailyDTO.Foods!)
                {
                    row++;
                    sheetdailynow.Cell(row, 2).Value = item.NumberUser;
                    sheetdailynow.Cell(row, 1).Value = item.NameFood;
                    allfoods += item.NumberUser;
                }
                row++;
                sheetdailynow.Cell(row, 2).Value = allfoods;
                sheetdailynow.Cell(row, 1).Value = "تعداد کل غذا ها";
            }

            //استایل دهی اکسل
            var table = sheetdailynow.Range(1, 1, allfoods + 6, 2).CreateTable();
            table.Theme = XLTableTheme.TableStyleLight16;
            var header = sheetdailynow.Range(2, 1, 2, 2);
            header.Style.Font.Bold = true;
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            header.Style.Fill.SetBackgroundColor(XLColor.BrightGreen);
            sheetdailynow.RightToLeft = true;
            sheetdailynow.Columns().AdjustToContents(minWidth:10,maxWidth:50);




            //ذخیره در رم برای ارسال دانلود
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            return File(stream.ToArray(), contentType, $"گزارش غذای روز {day.PersianDate}.xlsx");

        }

        [HttpGet("mont/{mont}")]
        public async Task<IActionResult> SelectMont(int mont)
        {
            using var workbook = new XLWorkbook();
            var sheetdailynow = workbook.AddWorksheet("لیست غذای ماهیانه");
            var result = await RC.InMontDailyFood(mont);
            var data = result.Data;
            int rowcount = 1;
            foreach ( var row in data!.RowMontExcelsOut!)
            {
                rowcount++;
                foreach(var cell in row.CellOfRowExcel)
                {
                    sheetdailynow.Cell(rowcount, cell.Index).Value = cell.SCell;
                }
            }
            

            //create header of excel mont report
            var header = sheetdailynow.Range(1, 1, 1, data.Culoms);
            header.Merge().Value = $"گزارش ماهانه غذای سازمانی {data.MontName} ماه";
            header.Style.Font.Bold = true;
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            header.Style.Fill.SetBackgroundColor(XLColor.BrightGreen);




            //استایل دهی اکسل
            sheetdailynow.RightToLeft = true;
            sheetdailynow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            sheetdailynow.Columns().AdjustToContents(minWidth: 10, maxWidth: 50);
            var table = sheetdailynow.Range(2, 1,data.Rows+1,data.Culoms).CreateTable();
            table.Theme = XLTableTheme.TableStyleLight16;


            //ذخیره در رم برای ارسال دانلود
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            return File(stream.ToArray(), contentType, $"غذای ماه {mont} ام.xlsx");
        }



    }
}
