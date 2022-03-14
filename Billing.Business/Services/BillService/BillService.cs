using AutoMapper;
using Billing.Common.Utils;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepo _billRepo;
        private readonly IMapper _mapper;

        public BillService(IBillRepo billRepo, IMapper mapper)
        {
            _billRepo = billRepo;
            _mapper = mapper;
        }

        public async Task<bool> AddBill(BillDTO entity)
        {
            var bill = await _billRepo.Get(entity.Id);
            if (bill == null)
            {
                bill = new();
            }
            bill.Id = entity.Id;
            bill.BillNo = entity.BillNo;
            bill.ItemName = entity.ItemName;
            bill.Quantity = entity.Quantity;
            bill.Rate = entity.Rate;
            bill.ApplicableTax = entity.ApplicableTax;
            bill.Organization = entity.Organization;
            bill.TotalAmount = entity.TotalAmount;
            bill.LaborAmount = entity.LaborAmount;
            bill.RepairAmount = entity.RepairAmount;
            bill.IsAactive = entity.IsAactive;
            bill.Status = entity.Status;
            bill.CreatedDate = entity.CreatedDate;
            bill.CreatedBy = entity.CreatedBy;
            bill.UpdatedDate = entity.UpdatedDate;
            bill.UpdatedBy = entity.UpdatedBy;
            bill.DeletedDate = entity.DeletedDate;
            bill.DeletedBy = entity.DeletedBy;
            bill.IsDeleted = entity.IsDeleted;
            if (entity.Id == 0)
            {
                await _billRepo.Add(bill);
            }
            else
            {
                await _billRepo.Change(bill);
            }
            return true;
        }

        public async Task<int> DeleteBill(int id)
        {
            await _billRepo.Delete(id);
            return id;
        }

        public List<BillDTO> GetAllBills()
        {
            var entity = _billRepo.GetAll().ToList();
            return new();
        }

        public async Task<BillDTO> GetBill(int id)
        {
            var entity = await _billRepo.Get(id);
            return new();
        }
    }
}
