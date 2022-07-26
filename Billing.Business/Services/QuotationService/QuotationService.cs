using AutoMapper;
using Billing.Common.ExtensionMethods;
using Billing.Data.Entities;
using Billing.Data.Repos;
using Billing.DTOs.DTOs;
using Billing.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Business.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepo _quotationRepo;
        private readonly ITaxRepo _taxRepo;
        private readonly IMapper _mapper;

        public QuotationService(IQuotationRepo quotationRepo, IMapper mapper,
            ITaxRepo taxRepo)
        {
            _quotationRepo = quotationRepo;
            _mapper = mapper;
            _taxRepo = taxRepo;
        }

        public async Task<ResponseDTO> AddUpdateQuotation(RequestQuotationDTO entity)
        {
            try
            {
                decimal TotalSparePartAmount = 0;
                decimal TotalRepairingAmount = 0;
                decimal? TotalSparePartTaxAmount = 0;
                decimal TotalRepairingTaxAmount = 0;
                double TotalGST = 0;
                double TotalFST = 0;
                TotalGST = await _taxRepo.GetAll().Where(x => x.Type.ToLower() == "gst").Select(x => x.Percent).FirstOrDefaultAsync();
                if (TotalGST <= 0)
                    return new ResponseDTO() { IsSuccessful = false, Message = "Please set general sale tax ratio" };
                TotalFST = await _taxRepo.GetAll().Where(x => x.Type.ToLower() == "fst").Select(x => x.Percent).FirstOrDefaultAsync();
                if (TotalFST <= 0)
                    return new ResponseDTO() { IsSuccessful = false, Message = "Please set federal sale tax ratio" };
                var DbModel = await _quotationRepo.GetAll().Where(x => x.Id == entity.Id).SingleOrDefaultAsync();
                DbModel = DbModel == null ? new Quotation() : DbModel;
                DbModel.QuotationNo = entity.QuotationNo;
                DbModel.CarNo = entity.CarNo;
                DbModel.Status = entity.Id == 0 ? Enum.QuotationStatusEnum.Pending : DbModel.Status;
                DbModel.InvoiceDate = entity.InvoiceDate;
                DbModel.OrganizationId = entity.OrganizationTypeId == OrganizationEnum.OrganizationType.organization.GetHashCode() ? entity.OrganizationId :
                   entity.OrganizationTypeId == OrganizationEnum.OrganizationType.customer.GetHashCode() ? entity.OrganizationId : 0;
                DbModel.OrganizationTypeId = (OrganizationEnum.OrganizationType)entity.OrganizationTypeId;
                DbModel.WorkTypeId = (WorkTypeEnum)entity.WorkTypeId;
                DbModel.IsActive = true;
                DbModel.IsDeleted = false;

                if (entity.Id == 0)
                {
                    DbModel.CreatedBy = entity.UserId;
                    DbModel.CreatedDate = DateTime.Now;
                    #region[Add cases for all work type including sparepart, repairing work or both]
                    if (DbModel.WorkTypeId == WorkTypeEnum.SparePart)
                    {
                        foreach (var sparePart in entity.SparePartList)
                        {
                            var TempRateOntheBasisofQuantity = sparePart.SparePartQuantity > 1 ? sparePart.Price * sparePart.SparePartQuantity : sparePart.Price;
                            decimal? TempTaxAmountOntheBasisofQuantity = sparePart.TaxApply ? (sparePart.SparePartQuantity > 1 ?
                                ((decimal)TotalGST / 100) * (sparePart.Price * sparePart.SparePartQuantity) :
                                ((decimal)TotalGST / 100) * sparePart.Price) : null;
                            DbModel.QuotationSpareParts.Add(new QuotationSparePart
                            {
                                Quantity = sparePart.SparePartQuantity,
                                SparePartId = sparePart.SparePartId,
                                QuotationId = DbModel.Id,
                                Rate = sparePart.Price,
                                TaxApplied = sparePart.TaxApply,
                                TaxPercent = sparePart.TaxApply ? (decimal)TotalGST : null,
                                TaxAmount = TempTaxAmountOntheBasisofQuantity
                            });
                            TotalSparePartAmount += TotalSparePartAmount + TempRateOntheBasisofQuantity;
                            if (sparePart.TaxApply)
                                TotalSparePartTaxAmount += TempTaxAmountOntheBasisofQuantity;
                        }
                        DbModel.TotalAmount = TotalSparePartAmount;
                        DbModel.GSTTaxAmount = TotalSparePartTaxAmount;
                    }
                    else if (DbModel.WorkTypeId == WorkTypeEnum.Repair)
                    {
                        foreach (var repairingWork in entity.RepairWorkList)
                        {
                            DbModel.QuotationRepairings.Add(new QuotationRepairing
                            {
                                Rate = repairingWork.RepairingWorkPrice,
                                RepairingId = repairingWork.RepairingWorkId,
                                QuotationId = DbModel.Id,
                                TaxApplied = repairingWork.TaxApply,
                                TaxPercent = repairingWork.TaxApply ? (decimal)TotalFST : null,
                                TaxAmount = repairingWork.TaxApply ? ((decimal)TotalFST / 100) * repairingWork.RepairingWorkPrice : null
                            });
                            TotalRepairingAmount = TotalRepairingAmount + repairingWork.RepairingWorkPrice;
                            if (repairingWork.TaxApply)
                                TotalRepairingTaxAmount += ((decimal)TotalFST / 100) * repairingWork.RepairingWorkPrice;
                        }
                        DbModel.TotalAmount = TotalRepairingAmount;
                        DbModel.FederalServiceTaxAmount = TotalRepairingTaxAmount;
                    }
                    else
                    {
                        foreach (var sparePart in entity.SparePartList)
                        {
                            var TempRateOntheBasisofQuantity = sparePart.SparePartQuantity > 1 ? sparePart.Price * sparePart.SparePartQuantity : sparePart.Price;
                            decimal? TempTaxAmountOntheBasisofQuantity = sparePart.TaxApply ? (sparePart.SparePartQuantity > 1 ?
                                ((decimal)TotalGST / 100) * (sparePart.Price * sparePart.SparePartQuantity) :
                                ((decimal)TotalGST / 100) * sparePart.Price) : null;
                            DbModel.QuotationSpareParts.Add(new QuotationSparePart
                            {
                                Quantity = sparePart.SparePartQuantity,
                                SparePartId = sparePart.SparePartId,
                                QuotationId = DbModel.Id,
                                Rate = sparePart.Price,
                                TaxApplied = sparePart.TaxApply,
                                TaxPercent = sparePart.TaxApply ? (decimal)TotalGST : null,
                                TaxAmount = TempTaxAmountOntheBasisofQuantity
                            });
                            if (sparePart.TaxApply)
                                TotalSparePartTaxAmount += TempTaxAmountOntheBasisofQuantity.Value;
                            TotalSparePartAmount = TotalSparePartAmount + TempRateOntheBasisofQuantity;
                        }
                        DbModel.TotalAmount = TotalSparePartAmount;
                        DbModel.GSTTaxAmount = TotalSparePartTaxAmount;

                        foreach (var repairingWork in entity.RepairWorkList)
                        {
                            DbModel.QuotationRepairings.Add(new QuotationRepairing
                            {
                                Rate = repairingWork.RepairingWorkPrice,
                                RepairingId = repairingWork.RepairingWorkId,
                                QuotationId = DbModel.Id,
                                TaxApplied = repairingWork.TaxApply,
                                TaxPercent = repairingWork.TaxApply ? (decimal)TotalFST : null,
                                TaxAmount = repairingWork.TaxApply ? ((decimal)TotalFST / 100) * repairingWork.RepairingWorkPrice : null
                            });
                            TotalRepairingAmount = TotalRepairingAmount + repairingWork.RepairingWorkPrice;
                            if (repairingWork.TaxApply)
                                TotalRepairingTaxAmount += ((decimal)TotalFST / 100) * repairingWork.RepairingWorkPrice;
                        }
                        DbModel.TotalAmount += TotalRepairingAmount;
                        DbModel.FederalServiceTaxAmount = TotalRepairingTaxAmount;
                    }

                    await _quotationRepo.Add(DbModel);
                    return new ResponseDTO() { IsSuccessful = true, Message = "Quotation added successfully" };
                    #endregion
                }
                else
                {

                    DbModel.UpdatedBy = entity.UserId;
                    DbModel.UpdatedDate = DateTime.Now;
                }

                return new ResponseDTO() { };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> DeleteQuotation(QuotationDTO QuotationDTOs)
        {
            try
            {
                QuotationDTOs.IsDeleted = true;
                QuotationDTOs.DeletedDate = DateTime.Now;
                var entity = _mapper.Map<Quotation>(QuotationDTOs);
                await _quotationRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<QuotationListDTO>> GetAllQuotation()
        {
            try
            {
                var entity = _quotationRepo.GetAll()
                    .Include(x=>x.QuotationSpareParts)
                    .Include(x=>x.QuotationRepairings)
                    .Where(x => x.IsDeleted != true && x.IsActive);

                return await entity.Select(x => new QuotationListDTO
                {
                    Id = x.Id,
                    QuotationNo = x.QuotationNo,
                    CarNo = x.CarNo,
                    OrganizationTypeName = x.OrganizationTypeId.GetEnumDescription(),
                    TotalAmount = (double)x.TotalAmount,
                    StatusName = x.Status.GetEnumDescription(),
                    TotalRepairTax = x.FederalServiceTaxAmount.HasValue ? (x.FederalServiceTaxAmount.Value  ==  (decimal) 0.00 ? "0.00": x.FederalServiceTaxAmount.Value.ToString()) : "0.00",
                    TotalGstTax = x.GSTTaxAmount.HasValue ? (x.GSTTaxAmount.Value == (decimal)0.00 ? "0.00" : x.GSTTaxAmount.Value.ToString()) : "0.00",
                }).ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<QuotationDTO> GetQuotationById(long id)
        {
            try
            {
                var entity = await _quotationRepo.GetAll()
                    .Include(x=>x.QuotationSpareParts)
                    .Include(x=>x.QuotationRepairings)
                    .Where(x => x.Id == id)?.Select(x=> new QuotationDTO {
                        CarNo = x.CarNo,    
                        Id = x.Id,
                        WorkTypeId = x.WorkTypeId.GetHashCode(),
                        OrganizationTypeId = x.OrganizationTypeId .GetHashCode(),
                        RepairingWorkArray = x.QuotationRepairings.Select(x=>x.Id.ToString()).ToArray().Length > 0?
                        x.QuotationRepairings.Select(x => x.Id.ToString()).ToArray() : null,
                        SparePartArray = x.QuotationSpareParts.Select(x => x.Id.ToString()).ToArray().Length > 0 ?
                        x.QuotationSpareParts.Select(x => x.Id.ToString()).ToArray() : null,
                    }).FirstOrDefaultAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> UpdateQuotation(QuotationDTO QuotationDTO)
        {
            try
            {
                QuotationDTO.UpdatedDate = DateTime.Now;
                var entity = _mapper.Map<Quotation>(QuotationDTO);
                await _quotationRepo.Change(entity);
                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
