using BusinessObjects.DTOs.AdminDashboard;
using BusinessObjects.Entities;
using BusinessObjects.Enums;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CountFacilitiesAsync()
        {
            return await _unitOfWork.GetRepository<Facility>().CountAsync();
        }

        public async Task<int> CountProfessionalsAsync()
        {
            return await _unitOfWork.GetRepository<Professional>().CountAsync();
        }

        public async Task<int> CountPatientsAsync()
        {
            return await _unitOfWork.GetRepository<Patient>().CountAsync();
        }

        public async Task<int> CountPaymentsAsync()
        {
            return await _unitOfWork.GetRepository<Payment>().CountAsync();
        }
        public async Task<List<AppointmentStatusDistributionDto>> GetAppointmentStatusDistributionAsync()
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync();

            var result = appointments
                .GroupBy(a => a.Status)
                .Select(g => new AppointmentStatusDistributionDto
                {
                    Label = g.Key switch
                    {
                        AppointmentStatus.AwaitingPayment => "Chờ thanh toán",
                        AppointmentStatus.Pending => "Chờ xác nhận",
                        AppointmentStatus.Confirmed => "Đã xác nhận",
                        AppointmentStatus.Completed => "Hoàn thành",
                        AppointmentStatus.Rescheduled => "Dời lịch",
                        AppointmentStatus.Cancelled => "Đã hủy",
                        AppointmentStatus.Rejected => "Từ chối",
                        AppointmentStatus.Expired => "Thanh toán thất bại",
                        _ => g.Key.ToString()
                    },
                    Count = g.Count()

                })
                .ToList();

            return result;
        }

        public async Task<List<MonthlyPaymentDto>> GetMonthlyPaymentStatsAsync()
        {
            var payments = await _unitOfWork.GetRepository<Payment>().GetAllAsync();

            var result = payments
                .Where(p => p.PaymentStatus == PaymentStatus.Completed && p.PaymentDate != null)
                .GroupBy(p => new { p.PaymentDate.Value.Year, p.PaymentDate.Value.Month })
                .OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
                .Select(g => new MonthlyPaymentDto
                {
                    Month = g.Key.Month,
                    Total = g.Sum(p => p.Price.Value) / 1_000m // Convert to million VND
                })
                .ToList();

            return result;
        }


    }
}
